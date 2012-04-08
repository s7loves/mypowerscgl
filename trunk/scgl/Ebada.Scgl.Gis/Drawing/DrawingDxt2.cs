using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Gis {
    /// <summary>
    /// 规则单线图绘制类
    /// </summary>
    public class DrawingDxt2 {
        public const string  kgfilter = " where gtid in (select gtid from ps_gt  where Linecode='{0}')";
        public const string byqfilter = "select a.*,b.gtid from ps_tqbyq a ,ps_tq b,ps_gt c  where a.tqid=b.tqid and  b.gtid=c.gtid and c.Linecode='{0}' ";
        public const string tqfilter = " where gtid in (select gtid from ps_gt  where Linecode='{0}')";
        static Font mFont = new Font("宋体", 9);
        int mWidth = 1400;
        int mHeight = 600;
        public Image GetImage(string linecode) {
            xl xl = new xl();
            Bitmap img = new Bitmap(mWidth, mHeight);
            xl.xlValue=Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>("where linecode='"+ linecode + "'");
            if (xl.xlValue == null) return null;

            buildChild(xl);
            draw(Graphics.FromImage(img), xl);
            
            return img;
        }
        void buildChild(xl line) {
            IList<PS_gt> gtlist= Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("where linecode='" + line.xlValue.LineCode + "' order by gtcode");
            line.addGt(gtlist);
            line.initgtsb();
           IList<PS_xl> xlList= Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>(" where  parentgt in (select gtcode from ps_gt where  linecode='" + line.xlValue.LineCode + "')");
           line.addXl(xlList);
           foreach (xl xl in line.lines) {
               buildChild(xl);
           }
        }
        void drawlineinfo(Graphics g ,xl xl) {
            string text = xl.xlValue.LineVol + "kV" + xl.xlValue.LineName + "系统图";
            Font f = new Font("宋体", 30, FontStyle.Bold);
            Size sf = g.MeasureString(text, f).ToSize();
            
            g.DrawString(text, f, Brushes.BlueViolet, mWidth/2-sf.Width/2, 20);

        }
        void draw(Graphics g, xl xl) {
            g.Clear(Color.White);
            mOrg org= Client.ClientHelper.PlatformSqlMap.GetOne<mOrg>("where orgcode='" + xl.xlValue.OrgCode2 + "'");
            if (org != null) {
                renderbdz(g, 50, 300, org.OrgName);
            }
            drawgt(g, xl);
            drawlineinfo(g, xl);
        }
        void drawgt(Graphics g, xl xl) {
            int drawcount = 0;
            foreach (gtNode node in xl.nodes) {

                if (node.NeedDraw) drawcount++;
            }
            gtNode node0 = xl.nodes[xl.nodes.Count - 1];
            if (!node0.NeedDraw)
            drawcount += 1;
            float step= (mWidth-150) *1.0f/drawcount;
            int top = 300;
            
            g.DrawLine(Pens.BlueViolet, 50, top, mWidth-100, top);
            //if (!xl.nodes[0].NeedDraw) {
            //    xl.nodes[0].Location = new Point(50+(int)step, top);
            //    xl.nodes[0].render(g);
            //}
            
            if (!node0.NeedDraw) {
                node0.Location = new Point(mWidth-100, top);
                node0.render(g);
            }
            int j = -1;
            int i = 0;
            Point offset = new Point(1, 1 * j);
            foreach (gtNode node in xl.nodes) {
                
                if (!node.NeedDraw) continue;
                i++;
                node.Location = new Point( 50 + (int)(i * step),top);
                node.render(g);
                foreach (xl xl0 in node.lines) {
                    drawchildxltop(g, xl0, offset, (int)step * 2, 250);
                    offset.Y *= -1;
                }
                
            }
        }
        void drawchildxltop(Graphics g,xl xl, Point offset, int width,int height) {
            int drawcount = 0;
            foreach (gtNode node in xl.nodes) {

                if (node.NeedDraw) drawcount++;
            }
            gtNode node0 = xl.nodes[xl.nodes.Count - 1];
            if (!node0.NeedDraw)
            drawcount += 1;
            float step = height / drawcount;

            step = Math.Min(50, step);
            height =(int) (step * drawcount);
            step *= offset.Y;
            int left = xl.parentNode.Location.X;
            int bottom = xl.parentNode.Location.Y;
            int top = bottom + offset.Y* height;
            g.DrawLine(Pens.BlueViolet, left, bottom, left, top);
            //if (!xl.nodes[0].NeedDraw) {
            //    xl.nodes[0].Location = new Point(left,(int)step);
            //    xl.nodes[0].render(g);
            //}
            
            if (!node0.NeedDraw) {
                node0.Location = new Point(left, top);
                node0.render(g);
            }
            int j = -1;
            int i = 0;
            //Point offset = new Point(0, 50 * j);
            foreach (gtNode node in xl.nodes) {

                if (!node.NeedDraw) continue;
                i++;
                node.Location = new Point(left,bottom+(int)(i * step));
                node.render(g);
                foreach (xl xl0 in node.lines) {
                    
                    drawchildxlright(g, xl0, offset,2* (int)Math.Abs(step), 100);
                    offset.X *= -1;
                }
                
            }
        }
        void drawchildxlright(Graphics g, xl xl, Point offset, int width, int height) {
            int drawcount = 0;
            foreach (gtNode node in xl.nodes) {

                if (node.NeedDraw) drawcount++;
            }
            gtNode node0 = xl.nodes[xl.nodes.Count - 1];
            if (!node0.NeedDraw)
                drawcount += 1;
            float step = width / drawcount;

            step = Math.Min(30, step);
            width = (int)(step * drawcount);
            step *= offset.X;
            int left = xl.parentNode.Location.X;
            int bottom = xl.parentNode.Location.Y;
            int right = left + offset.X * width;
            g.DrawLine(Pens.BlueViolet, left, bottom, right, bottom);
            //if (!xl.nodes[0].NeedDraw) {
            //    xl.nodes[0].Location = new Point(left,(int)step);
            //    xl.nodes[0].render(g);
            //}

            if (!node0.NeedDraw) {
                node0.Location = new Point(right, bottom);
                node0.render(g);
            }
            int j = -1;
            int i = 0;
            //Point offset = new Point(0, 50 * j);
            foreach (gtNode node in xl.nodes) {

                if (!node.NeedDraw) continue;
                i++;
                node.Location = new Point( left + (int)(i * step),bottom);
                node.render(g);
                //foreach (xl xl0 in node.lines) {
                //    drawchildxl(g, xl0, offset, (int)step * 2, 200);
                //}
                //offset.Y *= -1;
            }
        }
        void renderbdz(Graphics g, int x, int y, string name) {
            Point p = new Point(x, y);
            p.Offset(-10, -10);
            Rectangle r = new Rectangle(p.X, p.Y, 20, 20);
            Point p1 = new Point(r.Left + r.Width / 2, r.Top);
            Point p2 = new Point(r.Left, r.Bottom);
            Point p3 = new Point(r.Right, r.Bottom);
            g.FillPolygon(Brushes.Blue, new Point[]{p1,p2,p3});
            g.DrawRectangle(Pens.Blue, r);
            Size sf = g.MeasureString(name, mFont).ToSize();

            g.DrawString(name, mFont, Brushes.Black, x  - sf.Width / 2, y + 15);


        }
        public static void renderbyq(Graphics g, int x, int y, string name) {
            System.Drawing.Point p1 = new System.Drawing.Point(x, y);
            p1.Offset(-7, -5);
            //new Pen(Color.FromArgb(144, Color.MidnightBlue));
            Rectangle r = new Rectangle(p1.X, p1.Y, 10, 10);
            Rectangle r2 = new Rectangle(p1.X + 5, p1.Y, 10, 10);
            //g.FillEllipse(Brushes.White, r);
            //g.FillEllipse(Brushes.White, r2);
            g.DrawEllipse(Pens.Blue, r);
            g.DrawEllipse(Pens.Blue, r2);
            
            //Size sf = g.MeasureString(name, mFont).ToSize();

            //g.DrawString(name, mFont, Brushes.Black, x + 7 - sf.Width / 2, y - 15);

            g.DrawString(name, mFont, Brushes.Black, x + 7 , y-5 );
            
        }
        public static void renderkg(Graphics g, int x, int y, string name) {
            System.Drawing.Point p1 = new System.Drawing.Point(x, y);
            //new Pen(Color.FromArgb(144, Color.MidnightBlue));
            p1.Offset(-4, -2);
            Rectangle r = new Rectangle(p1, new Size(8,4));
            g.FillRectangle(Brushes.Red, r);
            if (!string.IsNullOrEmpty(name)) {
                Size sf = g.MeasureString(name, mFont).ToSize();

                g.DrawString(name, mFont, Brushes.Black, x + 10, y - 2);
            }
        }
        class gtNode {
            public List<xl> lines;
            public PS_gt gtValue;
            public xl ownerLine;

            public List<PS_kg> kgList;
            //public List<PS_tqbyq> byqList;
            public List<PS_tq> tqList;
            public bool NeedDraw {
                get {
                    return kgList.Count + tqList.Count + lines.Count > 0;
                }
            }
            public Point Location;
            public gtNode() {
                lines = new List<xl>();
                kgList = new List<PS_kg>();
                //byqList = new List<PS_tqbyq>();
                tqList = new List<PS_tq>();
            }

            internal void addLine(xl xl) {
                lines.Add(xl);
            }

            public void render(Graphics g) {
                Point p = Location;
                p.Offset(-3, -3);
                Rectangle r = new Rectangle(p, new Size(6, 6));
                g.FillEllipse(Brushes.White, r);
                g.DrawEllipse(Pens.BlueViolet, r);
                Font f = new Font("宋体", 9);
                g.DrawString(gtValue.gth, f, Brushes.Blue, p.X, Location.Y + 3);
                int i = 0;
                foreach (PS_tq tq in tqList) {
                    DrawingDxt2.renderbyq(g, Location.X, Location.Y+i*14, tq.tqName);
                    i++;
                }
                foreach (PS_kg kg in kgList) {
                    DrawingDxt2.renderkg(g, Location.X, Location.Y, kg.kgModle);
                }
            }
        }
        class xl {
            public List<gtNode> nodes;
            public List<xl> lines;
            public PS_xl xlValue;
            public gtNode parentNode;
            public xl() {
                nodes = new List<gtNode>();
                lines = new List<xl>();

        }
            public void addGt(ICollection<PS_gt> list) {
                foreach (PS_gt gt in list) {
                    if (gt.gth == "0000") continue;
                    nodes.Add(new gtNode() { gtValue = gt, ownerLine= this });
                }
            }

            internal void addXl(IList<PS_xl> xlList) {
                foreach (PS_xl line in xlList) {
                    xl xl = new xl() { xlValue = line };
                    lines.Add(xl);
                    gtNode node = getNodeByCode(line.ParentGT);
                    
                    if (node != null) {
                        xl.parentNode = node;
                        node.addLine(xl);
                    }
                }
            }
            internal void initgtsb() {
                IList<PS_tq> tqlist = Client.ClientHelper.PlatformSqlMap.GetList<PS_tq>(string.Format(DrawingDxt2.tqfilter, xlValue.LineCode));
                foreach (PS_tq tq in tqlist) {
                    gtNode node = getNodeByID(tq.gtID);
                    if (node != null) node.tqList.Add(tq);

                }
                IList<PS_kg> kglist = Client.ClientHelper.PlatformSqlMap.GetList<PS_kg>(string.Format(DrawingDxt2.kgfilter, xlValue.LineCode));
                foreach (PS_kg kg in kglist) {
                    gtNode node = getNodeByID(kg.gtID);
                    if (node != null) node.kgList.Add(kg);
                }
            }
            private gtNode getNodeByCode(string p) {
                foreach (gtNode node in nodes) {
                    if (node.gtValue.gtCode == p) return node;
                }

                return null;
            }
            private gtNode getNodeByID(string p) {
                foreach (gtNode node in nodes) {
                    if (node.gtValue.gtID == p) return node;
                }

                return null;
            }
        }
    }
}
