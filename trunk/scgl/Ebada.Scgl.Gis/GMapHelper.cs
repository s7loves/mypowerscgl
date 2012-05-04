using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Ebada.Scgl.Model;
using System.Collections;
using System.Data;

namespace Ebada.Scgl.Gis {
    public class GMapHelper {
        /// <summary>
        /// 显示单线图
        /// </summary>
        /// <param name="lineCode">线路代码</param>
        public void ShowDxt(string lineCode) {
            frmMapNetwork dlg = new frmMapNetwork();
            dlg.ShowDxt(lineCode);
        }
        /// <summary>
        /// 显示地理图
        /// </summary>
        /// <param name="gdsCode">供电所代码，为all时显示全局</param>
        public void ShowDlt(string gdsCode) {
            frmMapNetwork dlg = new frmMapNetwork();
            dlg.ShowDlt(gdsCode);
        }
        /// <summary>
        /// 显示台区图
        /// </summary>
        /// <param name="tqCode">台区代码</param>
        public void ShowDyt(string tqCode) {
            frmMapNetwork dlg = new frmMapNetwork();
            dlg.ShowDyt(tqCode);

        }
        public static Bitmap GetDytqMap(string tqcode) {
            return GetDytqMap(tqcode, 800, 600);
        }
        /// <summary>
        ///获取低压台区网络图
        /// </summary>
        /// <param name="tqcode"></param>
        /// <returns></returns>
        public static Bitmap GetDytqMap(string tqcode ,int width,int height) {
            int w = width;
            int h = height;
            Bitmap bp = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(bp);
            IList<PS_xl> list = Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("where linecode like '" + tqcode + "%' and linevol='0.4'");
            RectangleF rf = RectangleF.Empty;
            int bl = 10000;
            Dictionary<PS_xl, IList<PS_gt>> gts = new Dictionary<PS_xl, IList<PS_gt>>();
            List<PS_gtsb> gtsbs = new List<PS_gtsb>();

            foreach (PS_xl xl in list) {
                IList<PS_gt> gtlist = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("where linecode ='" + xl.LineCode + "' order by gtcode");
                if (gtlist.Count == 0) continue;
                IList<PS_gtsb> gtsblist = Client.ClientHelper.PlatformSqlMap.GetList<PS_gtsb>(" where sbtype like '17%' and  gtid in (select gtid from ps_gt where linecode ='" + xl.LineCode + "')");
                gtsbs.AddRange(gtsblist);
                IList<PS_gt> gtlist2 = new List<PS_gt>();
                foreach (PS_gt gt in gtlist) {
                    if (gt.gtLat == 0 || gt.gtLon == 0) continue;
                    gtlist2.Add(gt);
                    if (rf.IsEmpty)
                        rf = new RectangleF((float)gt.gtLon*bl, (float)gt.gtLat*bl, 1f, 1f);
                    else
                        rf=RectangleF.Union(rf,new RectangleF((float)gt.gtLon*bl, (float)gt.gtLat*bl,1f,1f));
                    //rf..Inflate((float)gt.gtLon, (float)gt.gtLat);
                }
                gts.Add(xl, gtlist2);
            }
            DataTable gtbhtable = Ebada.Core.ConvertHelper.ToDataTable(gtsbs);
            //g.TranslateTransform(-rf.X, -rf.Y);
            rf.Inflate(3, 3);
            System.Drawing.Drawing2D.Matrix matrix = new System.Drawing.Drawing2D.Matrix();
            matrix.Translate(-rf.X, -rf.Y);
            float f1=w / rf.Width;
            float f2=h/rf.Height;
            float scale = Math.Min(f1,f2);


            matrix.Scale(scale, scale, System.Drawing.Drawing2D.MatrixOrder.Append);
            if (f1 < f2)
                matrix.Translate(0, (h - f1 * rf.Height) / 2, System.Drawing.Drawing2D.MatrixOrder.Append);
            else
                matrix.Translate((w - f2 * rf.Width) / 2, 0, System.Drawing.Drawing2D.MatrixOrder.Append);
            
            List<PointF> plist = new List<PointF>();
            g.Clear(Color.White);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Font f = new Font("宋体", 9);
            PointF p0 = Point.Empty;
            Pen pen0 = new Pen(Color.Blue);
            pen0.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            List<string> gt0list = new List<string>();//记录重叠杆塔
            List<RectangleF> gtboxlist = new List<RectangleF>();
            foreach (PS_xl xl in gts.Keys) {
                plist.Clear();
                foreach (PS_gt gt in gts[xl]) {
                    plist.Add(new PointF((float)gt.gtLon*bl, (float)gt.gtLat*bl));
                }
                if (plist.Count <2) continue;
                PointF[] pts=plist.ToArray();

                matrix.TransformPoints(pts);
                for(int i=0;i<pts.Length;i++){
                    pts[i].Y = h - pts[i].Y;
                }
                g.DrawLines(Pens.Blue,pts );
                bool b1 = Math.Abs(pts[0].X - pts[1].X) > Math.Abs(pts[0].Y - pts[1].Y);
                Point offset = new Point(b1 ? 0 : 20, b1 ? 20 : 0);
                for(int i=0;i<pts.Length;i++) {
                    PS_gt gt =gts[xl][i];
                    if (gt.gtLat==0.0m||gt.gtLon==0.0m) continue;
                    if (gt.gtJg == "是" && i==0) {
                        if (xl.ParentID.Length > 10) continue;//台区下干线除外
                        PointF pf0 = pts[i];
                        bool ret = false;
                        if (gt0list.Contains(xl.ParentID)) {
                            
                            foreach (RectangleF rtf in gtboxlist) {
                                if (rtf.Contains(pf0)) { ret = true; break; }
                            }
                        } else {
                            gt0list.Add(xl.ParentID);
                        }
                        if (ret) continue;
                        RectangleF rtf0 = RectangleF.Empty;
                        rtf0.Location = pf0;
                        rtf0.Inflate(10, 10);
                        gtboxlist.Add(rtf0);

                    }
                    
                    DataRow[] rows= gtbhtable.Select("gtid='" + gt.gtID + "'");
                    int n = 1;
                    foreach (DataRow row in rows) {
                        PS_gtsb gtsb = Ebada.Core.ConvertHelper.RowToObject<PS_gtsb>(row);
                        n *= -1;
                        PointF pf = new PointF(pts[i].X + (n * offset.X), pts[i].Y + (n * offset.Y));
                        RectangleF rtf = Rectangle.Empty;
                        rtf.Location = pf;
                        rtf.Inflate(12, 5);
                        Rectangle rt =Rectangle.Round(rtf);
                        g.DrawLine(Pens.Red, pts[i], pf);
                        g.FillRectangle(Brushes.White, rt);
                        g.DrawRectangle(Pens.Red, rt);
                        string num= gtsb.sbModle.Substring(0,1);
                        if (gtsb.sbNumber > 1) num = num + "x" + gtsb.sbNumber;
                        StringFormat sf =new StringFormat();
                        sf.Alignment= StringAlignment.Center;
                        
                        //sf.LineAlignment= StringAlignment.Center;
                        g.DrawString(num, f, Brushes.Red, rtf,sf);
                        
                        if (n == 1) break;
                    }
                    g.FillEllipse(Brushes.White, pts[i].X - 5, pts[i].Y - 5, 10, 10);
                    if (gt.gtJg == "是") {
                        g.DrawEllipse(pen0, pts[i].X - 5, pts[i].Y - 5, 10, 10);
                    } else {
                        g.DrawEllipse(Pens.Blue, pts[i].X - 5, pts[i].Y - 5, 10, 10);
                    }
                    g.DrawString((int)gt.gtHeight + "/" + (i + 1), f, Brushes.Black, pts[i].X - 10, pts[i].Y + 5);
                }
                p0 = Point.Empty;
            }

            return bp;
        }
    }
}
