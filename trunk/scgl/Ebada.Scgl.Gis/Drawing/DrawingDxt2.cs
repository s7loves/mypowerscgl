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
        public static int mWidth = 1400;
        public static int mHeight = 800;
        public static int mMinDJ = 80;//最小档距
        public static bool isHrow = false;//文字是否自动换行
        private int n300 = 300;
        public List<string> strList = new List<string>();
        public Image GetImage(string linecode) {
            xl xl = new xl();
            Bitmap img = new Bitmap(mWidth, mHeight);
            xl.xlValue=Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>("where linecode='"+ linecode + "'");
            if (xl.xlValue == null) return null;
            IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>(" where  parentgt in (select gtcode from ps_gt where  linecode='" + xl.xlValue.LineCode + "')");
            if (xlList.Count == 0) {

                xlList = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>(" where parentid='" + xl.xlValue.LineID + "'");
                if (xlList.Count > 0)
                    xl.xlValue = xlList[0];
            }
            n300 = mHeight / 2;
            xlList.Clear();
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
               if (strList.Contains(xl.xlValue.LineCode)) continue;
               strList.Add(xl.xlValue.LineCode);
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
                renderbdz(g, 50, n300, org.OrgName);
            }
            strList.Clear();
            strList.Add(xl.xlValue.LineCode);
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
            int top = n300;

            if (drawcount < 2) step = (mWidth - 150) * 1.0f / 2;

            g.DrawLine(Pens.BlueViolet, 50, top, 50+step*drawcount, top);
            //if (!xl.nodes[0].NeedDraw) {
            //    xl.nodes[0].Location = new Point(50+(int)step, top);
            //    xl.nodes[0].render(g);
            //}
            
            if (!node0.NeedDraw) {
                node0.Location = new Point(50 +(int)( step * drawcount), top);
                node0.render(g);
            }
            int j = -1;
            int i = 0;
            Point offset = new Point(1, 1 * j);
            int nlines = 0;
            foreach (gtNode node in xl.nodes) {
                
                if (!node.NeedDraw) continue;
                i++;
                if (node.lines.Count > 0) {
                    nlines++;
                }
                node.Location = new Point( 50 + (int)(i * step),top);
                node.render(g);
                
                foreach (xl xl0 in node.lines) {
                    if (strList.Contains(xl0.xlValue.LineCode)) continue;
                    xl0.index = nlines;
                    strList.Add(xl0.xlValue.LineCode);
                    drawchildxltop(g, xl0, offset, (int)step * 2, mHeight-n300);
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
            if (drawcount == 1) step /= 2;
            step = Math.Min(mMinDJ, step);
            height =(int) (step * drawcount);
            step *= offset.Y;
            int left = xl.parentNode.Location.X;
            int bottom = xl.parentNode.Location.Y;
            int top = bottom + offset.Y* height;
            int offx = xl.getOffx()*offset.Y;
            top += offx;
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
            int nlines = 0;
            //Point offset = new Point(0, 50 * j);
            foreach (gtNode node in xl.nodes) {

                if (!node.NeedDraw) continue;
                i++;

                if (node.lines.Count > 0) {
                    nlines++;
                }

                node.Location = new Point(left, offx+bottom + (int)(i * step));
                
                node.render(g);

                foreach (xl xl0 in node.lines) {
                    if (strList.Contains(xl0.xlValue.LineCode)) continue;
                    xl0.index = nlines;
                    xl0.isV = true;
                    strList.Add(xl0.xlValue.LineCode);

                    drawchildxlright(g, xl0, offset, width,(int)Math.Abs(step)*3/2);
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
            if (drawcount == 1) step /= 2;
            
            step = Math.Min(mMinDJ, step);
            step = Math.Max(1, step);
            while (step < 30) step *= 2;
            width = (int)(step * drawcount);
            step *= offset.X;
            int left = xl.parentNode.Location.X;
            int bottom = xl.parentNode.Location.Y;
            int right = left + offset.X * width;

            int offx = xl.getOffx() * offset.X;
            right += offx;

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
            int nlines = 0;
            foreach (gtNode node in xl.nodes) {

                if (!node.NeedDraw) continue;
                i++;
                if (node.lines.Count > 0) {
                    nlines++;
                }
                node.Location = new Point(offx+ left + (int)(i * step),bottom);
                node.render(g);
                foreach (xl xl0 in node.lines) {
                    if (strList.Contains(xl0.xlValue.LineCode)) continue;
                    xl0.index = nlines;
                    strList.Add(xl0.xlValue.LineCode);
                    drawchildxltop(g, xl0, offset, (int)step * 3/2, height);
                }
                offset.Y *= -1;
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
            Rectangle r2 = new Rectangle(x - sf.Width / 2, y + 15, 70, 30);
            g.DrawString(name, mFont, Brushes.Black, x - sf.Width / 2, y + 15);


        }
        public static void renderbyq(Graphics g, int x, int y, string name,bool flag) {
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
            if (flag) {
                Rectangle r3 = new Rectangle(x + 7, y - 10, 20, 130);

                g.DrawString(name, mFont, Brushes.Black, r3);
            }
            else {
                if (isHrow) {
                    Rectangle r3 = new Rectangle(x + 7, y - 10, mMinDJ, 30);

                    g.DrawString(name, mFont, Brushes.Black, r3);
                }
                else {
                    g.DrawString(name, mFont, Brushes.Black, x + 7, y - 10);
                }
            }
            
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
            private bool hasNextTq {
                get { 
                    List<gtNode> list = ownerLine.nodes;
                    bool flag = false;

                    int index = list.IndexOf(this);
                    for (int i = index + 1; i < list.Count; i++) {
                        if (list[i].tqList.Count > 0) {
                            flag = true; break;
                        }
                    }

                    return flag;
                }
            }
            public bool NeedDraw {
                get {
                    return kgList.Count + tqList.Count + lines.Count > 0;
                }
            }
            private bool isLine3 {
                get { return ownerLine.xlValue.LineType == "3" && ownerLine.tqNodes.Count>1 && ownerLine.isV; }
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
                g.DrawString(gtValue.gth, f, Brushes.Blue, p.X-22, Location.Y + 3);
                int i = 0;
                bool flag = isLine3;
                
                foreach (PS_tq tq in tqList) {
                    DrawingDxt2.renderbyq(g, Location.X, Location.Y+i*14, tq.tqName,isLine3);
                    i++; break;
                }
                foreach (PS_kg kg in kgList) {
                    DrawingDxt2.renderkg(g, Location.X, Location.Y, kg.kgModle); break;
                }
            }
        }
        class xl {
            public List<gtNode> nodes;
            public List<xl> lines;
            public PS_xl xlValue;
            public gtNode parentNode;
            public List<gtNode> tqNodes;
            public int index = 0;
            public bool isV = false;//是否横向
            public xl() {
                nodes = new List<gtNode>();
                lines = new List<xl>();
                tqNodes = new List<gtNode>();
        }
            public int getOffx() {
                return ((index + 1) % 4 == 0 || index % 4 == 0) ? 12 : 0;
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
                    if (node != null) {
                        node.tqList.Add(tq);
                        if (!tqNodes.Contains(node))
                            tqNodes.Add(node);
                    }

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
