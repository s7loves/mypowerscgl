using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Ebada.Scgl.Model;

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
            foreach (PS_xl xl in list) {
                IList<PS_gt> gtlist = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("where linecode ='" + xl.LineCode + "' order by gth");
                if (gtlist.Count == 0) continue;
                
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
            Font f = new Font("宋体", 9);
            foreach (PS_xl xl in gts.Keys) {
                plist.Clear();
                foreach (PS_gt gt in gts[xl]) {
                    plist.Add(new PointF((float)gt.gtLon*bl, (float)gt.gtLat*bl));
                }
                if (plist.Count == 0) continue;
                PointF[] pts=plist.ToArray();

                matrix.TransformPoints(pts);
                for(int i=0;i<pts.Length;i++){
                    pts[i].Y = h - pts[i].Y;
                }
                g.DrawLines(Pens.Blue,pts );
                for(int i=0;i<pts.Length;i++) {
                    PS_gt gt =gts[xl][i];
                    if (gt.gth == "0000" || gt.gtLat==0.0m||gt.gtLon==0.0m) continue;
                    g.DrawEllipse(Pens.Blue, pts[i].X - 5, pts[i].Y - 5, 10, 10);
                    g.DrawString((int)gt.gtHeight+"/"+(i+1), f, Brushes.Black, pts[i].X - 10, pts[i].Y + 5);
                }
            }

            return bp;
        }
    }
}
