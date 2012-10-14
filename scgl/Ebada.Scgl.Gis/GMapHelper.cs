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
        static void drawArrow(Graphics g, float x0, float y0, float x1, float y1) {
            //float d=(float)Math.Sqrt((y1-y0)*(y1-y0)+(x1-x0)*(x1-x0));
            //float Xa = x1 + 10 * ((x0 - x1) + (y0 - y1) / 2) / d;
            //float Ya = y1 + 10 * ((y0 - y1) - (x0 - x1) / 2) / d;
            //float Xb = x1 + 10 * ((x0 - x1) - (y0 - y1) / 2) / d;
            //float Yb = y1 + 10 * ((y0 - y1) + (x0 - x1) / 2) / d;
            //g.DrawLine(Pens.Black, new PointF(x0, y0), new PointF(x1, y1));
            //g.DrawLine(Pens.Black, new PointF(Xa, Ya), new PointF(Xb, Yb));
            PointF p3 = new PointF(x0-(x1 -x0)*3, y0 - (y1-y0) *3);
            Pen pen=getPenArrow();
            g.DrawLine(pen, p3, new PointF(x1, y1));
            //pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            //g.DrawLine(pen, p3, new PointF(x1, y1));
        }

        static double getAngle(float px1, float py1, float px2, float py2) {
            //两点的x、y值
            float x = px2 - px1;
            float y = py2 - py1;
            double hypotenuse = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            //斜边长度
            if (x < 0) { x *= -1; y *= -1; }//保存角度在-90到90之间
            double cos = x / hypotenuse;
            double radian = Math.Acos(cos);
            //求出弧度
            double angle = 180 / (Math.PI / radian);
            //用弧度算出角度        
            if (y < 0) {
                angle = -angle;
            } else if ((y == 0) && (x < 0)) {
                angle = 180;
            }
            return angle;
        }
        static Pen getPenArrow() {
            System.Drawing.Drawing2D.AdjustableArrowCap lineCap = new System.Drawing.Drawing2D.AdjustableArrowCap(5, 6, true);

            Pen RedPen = new Pen(Color.Black, 2);

            RedPen.CustomEndCap = lineCap;

            return RedPen;
        }
        private static void draw指南针(Graphics g) {
            Rectangle r =new Rectangle(0,0,20,20);
            Pen pen = new Pen(Color.Black);
            pen.Width = 1.5f;
            pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            g.DrawEllipse(pen, r);
            Point p0= new Point(10,0);
            Point p1 = new Point(4, 16);
            Point p2 = new Point(10, 10);
            Point p3 = new Point(16, 16);
            Point[] pts = new Point[]{p0,p1,p2,p3,p0,p2 };

            g.DrawLines(pen, pts);
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
            DataTable gtbhtable = Ebada.Core.ConvertHelper.ToDataTable(gtsbs,typeof(PS_gtsb));
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
                int gtnum = 0;
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
                        gtnum += 1;
                        g.DrawEllipse(Pens.Blue, pts[i].X - 5, pts[i].Y - 5, 10, 10);
                        g.DrawString((int)gt.gtHeight + "/" + (gtnum), f, Brushes.Black, pts[i].X - 10, pts[i].Y + 5);

                    }
                }
                p0 = Point.Empty;
            }
            foreach (PS_xl xl in gts.Keys) {
                plist.Clear();
                foreach (PS_gt gt in gts[xl]) {
                    plist.Add(new PointF((float)gt.gtLon * bl, (float)gt.gtLat * bl));
                }
                if (plist.Count < 2) continue;
                PointF[] pts = plist.ToArray();

                matrix.TransformPoints(pts);
                for (int i = 0; i < pts.Length; i++) {
                    pts[i].Y = h - pts[i].Y;
                }
                PointF curgt = pts[0];
                for (int i = 1; i < pts.Length; i++) {
                    PS_gt gt = gts[xl][i];
                    if (gt.gtSpan > 1) {
                        drawSpan(g,(int)gt.gtSpan, curgt.X, curgt.Y, pts[i].X, pts[i].Y);
                    }
                    curgt = pts[i];
                }
                drawLineModel(g, xl.WireType, pts[pts.Length - 2].X, pts[pts.Length -2].Y, pts[pts.Length - 1].X, pts[pts.Length - 1].Y);
            }

            //绘制10线路方向

            IList<PS_xl> xllist0 = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("where parentid='" + tqcode + "' and linevol ='0.4' ");
            
            foreach (PS_xl xl0 in xllist0) {

                IList<PS_gt> gtlist = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("where linecode='" + xl0.LineCode + "' order by gtcode");
                if (gtlist.Count >= 2) {
                    PointF p1 = new PointF((float)gtlist[0].gtLon * bl, (float)gtlist[0].gtLat * bl);
                    PointF p2 = new PointF((float)gtlist[1].gtLon * bl, (float)gtlist[1].gtLat * bl);
                    PointF[] pts = new PointF[] { p1, p2 };
                    matrix.TransformPoints(pts);
                    //drawArrow(g, pts[0].X, h - pts[0].Y, pts[1].X, h - pts[1].Y);
                }

            }
            PS_tq tq = Client.ClientHelper.PlatformSqlMap.GetOne<PS_tq>("where tqcode='" + tqcode + "'");
            if (tq != null) {
                IList<PS_gt> gtlist = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("where linecode='" + tq.xlCode2 + "' order by gtcode");
                if (gtlist.Count>1) {
                    for(int i=0;i<gtlist.Count;i++) {
                        if (gtlist[i].gtCode == tq.gtID) {
                            if (i > 0) {
                                PointF p1 = new PointF((float)gtlist[i-1].gtLon * bl, (float)gtlist[i-1].gtLat * bl);
                                PointF p2 = new PointF((float)gtlist[i].gtLon * bl, (float)gtlist[i].gtLat * bl);
                                PointF[] pts = new PointF[] { p1, p2 };
                                matrix.TransformPoints(pts);
                                drawArrow(g, pts[0].X, h - pts[0].Y, pts[1].X, h - pts[1].Y);
                            }
                            break;
                        }
                    }
                }
            }
            //绘制指南针
            g.TranslateTransform(width - 50, 20);
            g.ScaleTransform(1.5f, 1.5f);
            draw指南针(g);
            return bp;
        }

        private static void drawSpan(Graphics g, int p, float x0, float y0, float x1, float y1) {
            var gc= g.BeginContainer();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            float x = (x1 + x0) / 2;
            float y = (y1 + y0) / 2;
            g.TranslateTransform(x-5, y);
            Font f = new Font("Arial Narrow", 8);
            float angle = (float)getAngle(x0, y0, x1, y1);
            if (angle > 90) angle -= 180;
            g.RotateTransform(angle);
            g.DrawString(p.ToString(), f, Brushes.Red, 0, 0);
            g.EndContainer(gc);
        }
        private static void drawLineModel(Graphics g, string xh, float x0, float y0, float x1, float y1) {
            if (string.IsNullOrEmpty(xh)) return;
            var gc = g.BeginContainer();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            float x = (x1 + x0) / 2;
            float y = (y1 + y0) / 2;
            g.TranslateTransform(x - 5, y-20);
            Font f = new Font("Arial Black", 9);
            float angle = (float)getAngle(x0, y0, x1, y1);
            if (float.IsNaN(angle)) return;
            if (angle > 0) g.TranslateTransform(15, 0);
            //if (x1 < x0 && y1 < y0) angle += 180;
            //if (angle > 90) { 
            //    angle -= 180; 
            //    g.TranslateTransform(-15, 0); 
            //}
            g.RotateTransform(angle);
            g.DrawString(xh, f, Brushes.BlueViolet, 0, 0);
            g.EndContainer(gc);
        }
    }
}
