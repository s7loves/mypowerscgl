using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using GMap.NET;
using System.Drawing;

namespace Ebada.Scgl.Gis {
    /// <summary>
    /// 低压图
    /// </summary>
    public class DrawingDyt:DrawingBase {
        DataTable sbTable;
        int tableHeight = 0;
        int tableWidth = 0;
        Rectangle tableRect;
        private Pen penin = new Pen(Color.Black, 2);
        private Pen penout = new Pen(Color.Black, 4);
        class sbrow {
            public string zl;
            public string xh;
            public int sl;
            public object[] DataArray {
                get { return new object[] { zl, xh, sl }; }
            }
        }
        public DrawingDyt(RMap c) {
            map = c;
            map.Drawing = this;
        }
        public override void Create(string p) {
            CreateSbtjInfoLine(p);
        }
        public override void Draw(System.Drawing.Graphics g) {
            if (Bounds.IsEmpty) return;
            GPoint p1 = map.FromLatLngToLocal(Bounds.LocationTopLeft);
            GPoint p2 = map.FromLatLngToLocal(Bounds.LocationRightBottom);
            Font font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);
            SizeF fs = g.MeasureString(Title, font);
            int x1 = p1.X;
            int y1 = p1.Y;
            int x2 = p2.X;
            int y2 = p2.Y;
            Rectangle r1 = new Rectangle(x1, y1 - (int)fs.Height, x2 - x1, y2 - y1 + (int)fs.Height);
            tableHeight = (int)(map.Font.GetHeight(g) * (sbTable.Rows.Count + 1));
            tableWidth = 60 * 3;
            tableRect = new Rectangle(r1.Right, r1.Top + (int)fs.Height, tableWidth, tableHeight);
            r1.Width += tableWidth;
            r1.Height = (int)Math.Max(r1.Height, 2 * fs.Height + tableHeight);
            Rectangle r2 = r1;
            r2.Inflate(5, 5);
            Point p3 = new Point(r1.Left + (r1.Width - (int)fs.Width) / 2, r1.Top + 5);
            g.DrawString(Title, font, Brushes.Black, p3);
            g.DrawRectangle(penin, r1);
            g.DrawRectangle(penout, r2);
            tableRect.Y = r1.Bottom - tableRect.Height - 1;
            drawsbtjInfo(g, tableRect.Location);
        }
        Dictionary<string, sbrow> sbrows = new Dictionary<string, sbrow>();
        void CreateSbtjInfoLine(string p) {
            
            //亘长
            //杆塔
            sbrows.Clear();
            sbrows.Add("水泥杆", new sbrow() { zl = "杆塔", xh = "水泥杆" });
            sbrows.Add("木杆", new sbrow() { zl = "杆塔", xh = "木杆" });
            sbrows.Add("铁塔", new sbrow() { zl = "杆塔", xh = "铁塔" });
            sbrows.Add("其它杆", new sbrow() { zl = "杆塔", xh = "其它" });

            if (sbTable == null) {
                sbTable = new DataTable();
                sbTable.Columns.Add("zl", typeof(String));
                sbTable.Columns.Add("xh", typeof(String));
                sbTable.Columns.Add("sl", typeof(int));
            }
            sbTable.Rows.Clear();

            string gtfilter = string.Format("select gttype zl,gtheight xh,count(gtid) sl from ps_gt "
            + "where gtjg='否' and  linecode in (select linecode from ps_xl  where left(Linecode,{0})='{1}' and LineVol = '0.4')"
            + " group by gttype,gtheight", p.Length, p);
            IList gtlist = Client.ClientHelper.PlatformSqlMap.GetList("Select", gtfilter);
            DataTable dt = null;

            dt = DataConvert.HashTablesToDataTable(gtlist);
            if (dt != null) {
                foreach (DataRow row in dt.Rows) {
                    string zl = row["zl"].ToString();
                    if (zl.Contains("混")) {
                        sbrows["水泥杆"].sl += Convert.ToInt32(row["sl"]);
                    } else if (zl.Contains("木")) {
                        sbrows["木杆"].sl += Convert.ToInt32(row["sl"]);
                    } else if (zl.Contains("铁")) {
                        sbrows["铁塔"].sl += Convert.ToInt32(row["sl"]);
                    } else {
                        sbrows["其它杆"].sl += Convert.ToInt32(row["sl"]);
                    }
                }
            }

            //变压器
            
            //开关

            
            /*            */
            //绝缘子
            //避雷器
            //
            foreach (string key in sbrows.Keys) {
                sbTable.Rows.Add(sbrows[key].DataArray);
            }
            //lay.IsVisibile = true;
        }
        void drawsbtjInfo(Graphics g, PointF pt) {
            if (sbTable == null || sbTable.Rows.Count == 0) return;
            float h = map.Font.GetHeight(g);
            float rh = h * sbTable.Rows.Count + h;
            float rw1 = 60;// g.MeasureString("12345678901234", Font).Width;
            float rw = rw1 * 3;
            g.FillRectangle(Brushes.White, pt.X, pt.Y, rw, rh);
            g.DrawRectangle(Pens.Black, pt.X, pt.Y, rw, rh);
            Font penfont=map.Font;
            float x = pt.X;
            float y = pt.Y;
            g.DrawString("种类", penfont, Brushes.Black, x, y);
            g.DrawString("规格", penfont, Brushes.Black, x + rw / 3, y);
            g.DrawString("数量", penfont, Brushes.Black, x + rw / 3 * 2, y);
            g.DrawLine(Pens.Black, x + rw1, y, x + rw1, y + rh);
            g.DrawLine(Pens.Black, x + rw1 * 2, y, x + rw1 * 2, y + rh);
            y += h;

            foreach (DataRow row in sbTable.Rows) {
                object[] data = row.ItemArray;
                g.DrawLine(Pens.Black, x, y, x + rw, y);
                g.DrawString(data[0].ToString(), penfont, Brushes.Black, x, y);
                g.DrawString(data[1].ToString(), penfont, Brushes.Black, x + rw / 3, y);
                g.DrawString(data[2].ToString(), penfont, Brushes.Black, x + rw / 3 * 2, y);
                y += h;
            }

        }
    }
}
