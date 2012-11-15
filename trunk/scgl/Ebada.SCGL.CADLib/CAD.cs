using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.Win32;
using Autodesk.AutoCAD;
using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Interop.Common;
using System.Runtime.InteropServices;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Configuration;
using Ebada.Scgl.Model;
using System.Text.RegularExpressions;


namespace Ebada.SCGL.CADLib {
    public class CAD {

        FlashWindow f = new FlashWindow();
        string color_str = "#0000FF";//线条颜色
        int zoom = 1000;             //放大比例

        AcadApplication cad;
        /// <summary>
        /// 导出线路到CAD
        /// </summary>
        /// <param name="linecode">线路编号数组</param>
        public void ToDwg(string[] linecode) {
            try {

                f.SetText("处理中请等待......");
                f.Show();
                cad = AutoCADConnector();
                cad.ActiveDocument.SendCommand("-units 2 8 1 0 0 n ");
                ArrayList nlist = getLineCode(linecode);
                if (cad != null) {
                    cad.ActiveDocument.Layers.Add("line");
                    cad.ActiveDocument.Layers.Add("gt");
                    cad.ActiveDocument.Layers.Add("gth");
                    cad.ActiveDocument.Layers.Add("text");
                    for (int n = 0; n < nlist.Count; n++) {
                        f.SetText("正在处理线路" + nlist[n].ToString());

                        IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='" + nlist[n].ToString() + "' order by gtcode");
                        IList<PS_gt> newlist = ReLoadList(list);
                        //PS_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>("where LineCode='" + nlist[n].ToString() + "'");
                        IList<PJ_05jcky> kylist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_05jcky>("where LineID='" + nlist[n].ToString() + "' order by jckyID");
                        IList<PJ_05jcky> newkylist = ReLoadKYList(kylist);
                        if (newlist.Count > 1) {
                            CallCAD(cad, newlist, newkylist);
                        }
                    }
                    cad.Visible = true;
                    cad.ActiveDocument.SendCommand("Z e ");
                    cad.ActiveDocument.SendCommand("audit y ");
                    f.Close();
                } else {
                    f.Close();
                }
            } catch (Exception e2) {
                MessageBox.Show("请安装AutoCAD2009或以上版本。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        /// <summary>
        /// 导出线路到CAD
        /// </summary>
        /// <param name="linecode">线路编号</param>
        /* public void ToDwg(string linecode)
         {
             try
             {
                 f.SetText("处理中请等待......");
                 f.Show();
                 cad = AutoCADConnector();
                 cad.ActiveDocument.SendCommand("-units 2 8 1 0 0 n ");
                 if (cad != null)
                 {
                     cad.ActiveDocument.Layers.Add("line");
                     cad.ActiveDocument.Layers.Add("gt");
                     cad.ActiveDocument.Layers.Add("gth");
                     cad.ActiveDocument.Layers.Add("text");
                     IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='" + linecode + "' order by gtcode");
                     IList<PS_gt> newlist = ReLoadList(list);
                     if (newlist.Count > 1)
                     {
                         CallCAD(cad, newlist);
                     }
                     cad.Visible = true;
                     cad.ActiveDocument.SendCommand("Z e ");
                     cad.ActiveDocument.SendCommand("audit y ");
                     f.Close();
                 }
                 else
                 {
                     f.Close();
                 }
             }
             catch (Exception e2)
             {
                 MessageBox.Show("请安装AutoCAD2009或以上版本。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

             }
         }*/
        public AcadApplication AutoCADConnector() {
            AcadApplication cad;
            try {
                cad = (AcadApplication)Marshal.GetActiveObject("AutoCAD.Application.17");
                cad.Visible = false;
            } catch {
                try {
                    cad = new AcadApplicationClass();
                    cad.Visible = false;
                    return cad;
                } catch (Exception e2) {
                    MessageBox.Show("请安装AutoCAD2009或以上版本。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
            }
            return cad;
        }

        public bool IsNumeric(string value) {
            return Regex.IsMatch(value, @"^[0-9]*$");
        }

        public IList<PS_gt> ReLoadList(IList<PS_gt> list) {
            IList<PS_gt> newlist = new List<PS_gt>();
            foreach (PS_gt gt in list) {
                if (gt.gtLat != 0 && gt.gtLon != 0) {
                    gt.gtLat = gt.gtLat * zoom;
                    gt.gtLon = gt.gtLon * zoom;
                    newlist.Add(gt);
                }
            }
            return newlist;
        }
        public IList<PJ_05jcky> ReLoadKYList(IList<PJ_05jcky> list) {
            IList<PJ_05jcky> newlist = new List<PJ_05jcky>();
            foreach (PJ_05jcky ky in list) {
                if (ky.kygh != "") {
                    string str = ky.kygh;
                    str = str.Replace("#", "");
                    str = str.Replace("-", "~");
                    str = str.Replace("号", "");
                    str = str.Replace("*", "");
                    string[] gh = str.Split("~".ToCharArray());
                    if (gh.Length > 1) {
                        if (IsNumeric(gh[0])) {
                            ky.kygh = Convert.ToDecimal(gh[0]).ToString();
                            newlist.Add(ky);
                        }
                    } else {
                        if (IsNumeric(str)) {
                            ky.kygh = Convert.ToDecimal(str).ToString();
                            newlist.Add(ky);
                        }
                    }

                }
            }
            return newlist;
        }
        public ArrayList getLineCode(string[] code) {
            ArrayList r = new ArrayList();
            for (int i = 0; i < code.Length; i++) {
                string vol = "";
                string linecode = code[i];
                if (linecode.Length == 6) {
                    PS_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>("where linecode='" + code[i] + "'");

                    if (xl != null)
                        vol = " and linevol='" + xl.LineVol + "' ";
                } else {
                    vol = " and (linevol='0.4'or linevol='10')";
                }
                IList<PS_xl> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>("where LineCode like '" + code[i] + "%'" + vol + " order by LineCode");
                for (int j = 0; j < list.Count; j++) {
                    r.Add(list[j].LineCode);
                }
            }
            return r;
        }

        public void CallCAD(AcadApplication cad, IList<PS_gt> list, IList<PJ_05jcky> kylist) {
            try {
                double[] col = new double[list.Count * 3];
                int k = 0;
                for (int i = 0; i < list.Count; i++) {
                    col[k] = Convert.ToDouble(list[i].gtLon.ToString("0.########"));
                    col[k + 1] = Convert.ToDouble(list[i].gtLat.ToString("0.########"));
                    col[k + 2] = 0;
                    k = k + 3;
                }
                AcadPolyline ple = cad.ActiveDocument.ModelSpace.AddPolyline(col);
                ple.ConstantWidth = 0;
                ple.Layer = "line";
                Color c1 = ColorTranslator.FromHtml(color_str);
                AcadAcCmColor color = (AcadAcCmColor)cad.ActiveDocument.Application.GetInterfaceObject("AutoCAD.AcCmColor.17");
                color.SetRGB(c1.R, c1.G, c1.B);
                ple.TrueColor = color;
                cad.Application.Update();


                int gtnum = 0;
                for (int i = 0; i < list.Count; i++) {
                    //if () continue;//跳过借杆
                    bool isjg = list[i].gtJg == "是";
                    double[] pnt = new double[3];
                    pnt[0] = Convert.ToDouble(list[i].gtLon.ToString("0.########"));
                    pnt[1] = Convert.ToDouble(list[i].gtLat.ToString("0.########"));
                    pnt[2] = 0;


                    gtnum++;

                   
                    bool hasbyq = false;
                    PS_tq tq = Client.ClientHelper.PlatformSqlMap.GetOne<PS_tq>(" where gtID='" + list[i].gtID + "'");
                    if (tq != null) {
                        //PS_tqbyq byq = Client.ClientHelper.PlatformSqlMap.GetOne<PS_tqbyq>(" where tqID='" + tq.tqID + "'");
                        //if (byq != null)
                        //{
                        //}
                        hasbyq = true;
                        PS_gt gt0 = null;
                        double a = 0;
                        if (i > 0) {
                            gt0 = list[i - 1];
                            a = getAndgle(gt0, list[i]);
                        } else if (list.Count > 1) {
                            a = getAndgle(list[0], list[1]);
                        }
                        if (double.IsNaN(a)) a = 0;
                        cad.ActiveDocument.ModelSpace.InsertBlock(pnt, Application.StartupPath + "\\byq.dwg", 0.3, 0.3, 1, a * Math.PI / 180, 0);
                    }
                    if (isjg)
                        continue;
                    bool isbtgt = false;
                    if (i < list.Count - 1) {
                        if (list[i + 1].gtSpan < 20) isbtgt = true;//如果下一杆塔的档距小于20作为变台杆塔,不与显示
                    }
                    if (hasbyq || isbtgt) { continue; } else {
                        AcadCircle cirz = cad.ActiveDocument.ModelSpace.AddCircle(pnt, 0.00005 * zoom);//杆塔
                        cirz.Layer = "gt";
                        cirz.TrueColor = color;
                    }
                    string gg = list[i].gtHeight.ToString("##");
                    pnt[0] += 0.00005d * zoom;
                    AcadMText ntext = cad.ActiveDocument.ModelSpace.AddMText(pnt, 2, gg + "/" + gtnum.ToString());
                    pnt[0] -= 0.00005d * zoom;
                    ntext.Height = 0.00005 * zoom;
                    ntext.Layer = "gth";
                    if (i < list.Count - 1 && list[i].gtSpan > 15) {
                        double[] n1 = new double[2];
                        n1[0] = Convert.ToDouble(list[i].gtLon);
                        n1[1] = Convert.ToDouble(list[i].gtLat);
                        double[] n2 = new double[2];
                        n2[0] = Convert.ToDouble(list[i + 1].gtLon);
                        n2[1] = Convert.ToDouble(list[i + 1].gtLat);
                        double[] n = new double[3];
                        n[0] = (n1[0] + n2[0]) / 2;
                        n[1] = (n1[1] + n2[1]) / 2;
                        n[2] = 0;
                        AcadMText mtext = cad.ActiveDocument.ModelSpace.AddMText(n, 2, list[i].gtSpan.ToString("#") + "M");
                        mtext.Height = 0.00005 * zoom;
                        mtext.Layer = "text";
                    }
                    for (int j = 0; j < kylist.Count; j++) {
                        if (kylist[j].kygh == gtnum.ToString()) {
                            PointF p1 = new PointF((float)pnt[0], (float)pnt[1]);
                            PointF p2 = new PointF((float)list[i + 1].gtLon, (float)list[i + 1].gtLat);
                            double x = pnt[0] > (double)list[i + 1].gtLon ? pnt[0] : (double)list[i + 1].gtLon;
                            double y = pnt[1] < (double)list[i + 1].gtLat ? pnt[1] : (double)list[i + 1].gtLat;
                            PointF p0 = new PointF((float)x, (float)y);
                            double[] ins = new double[3];
                            ins[0] = (p1.X + p2.X) / 2;
                            ins[1] = (p1.Y + p2.Y) / 2;
                            ins[2] = 0;
                            double ss = 0;
                            if (p1.Y < p2.Y) {
                                ss = getAngle(p1, p2, p0);
                            } else {
                                ss = getAngle(p2, p1, p0);
                            }
                            string block = getBlock(kylist[j].kymc);
                            cad.ActiveDocument.ModelSpace.InsertBlock(ins, Application.StartupPath + "\\" + block, 1, 1, 1, (ss + 90) * Math.PI / 180, 0);
                            ins[1] = ins[1] + 0.1;
                            AcadMText kytext = cad.ActiveDocument.ModelSpace.AddMText(ins, 1, kylist[j].kymc);
                            kytext.Height = 0.00005 * zoom;
                            kytext.Layer = "text";
                        }
                    }
                }
                TX_Point tp = null;
                tp = Client.ClientHelper.PlatformSqlMap.GetOneByKey<TX_Point>(list[0].LineCode);
                if (tp != null) {
                    double[] ins = new double[3];
                    ins[0] = Math.Round(Convert.ToDouble(tp.x), 8) * zoom;
                    ins[1] = Math.Round(Convert.ToDouble(tp.y), 8) * zoom;
                    ins[2] = 0;
                    AcadMText text = cad.ActiveDocument.ModelSpace.AddMText(ins, 2, tp.Text);
                    text.Height = 0.0001 * zoom;
                    text.Layer = "text";
                } else {
                    //线路名称放置最后一杆塔上
                    PS_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(" where LineCode='" + list[0].LineCode + "'");
                    double[] ins = new double[3];
                    ins[0] = Convert.ToDouble(list[list.Count - 1].gtLon.ToString("0.########"));
                    ins[1] = Convert.ToDouble(list[list.Count - 1].gtLat.ToString("0.########"));
                    ins[2] = 0;
                    AcadMText text = cad.ActiveDocument.ModelSpace.AddMText(ins, 2, xl.LineName);
                    text.Height = 0.0001 * zoom;
                    text.Layer = "text";
                    ins[1] = ins[1] + 0.3;
                    AcadMText text2 = cad.ActiveDocument.ModelSpace.AddMText(ins, 5, xl.WireType);
                    text2.Height = 0.0001 * zoom;
                    text2.Layer = "text";
                }
                cad.Application.Update();
            } catch (Exception e) { MessageBox.Show(e.Message); };
        }
        private double getAndgle(PS_gt gt0, PS_gt gt1) {
            int b = 10^6;
            //double[] pnt = new double[3];
            //pnt[0] = (double)gt0.gtLon*b;
            //pnt[1] = (double)gt0.gtLat*b;
            //PointF p1 = new PointF((float)pnt[0], (float)pnt[1]);
            //PointF p2 = new PointF((float)gt1.gtLon*b, (float)gt1.gtLat*b);
            //double x = pnt[0] > (double)gt1.gtLon*b  ? pnt[0]: (double)gt1.gtLon*b;
            //double y = pnt[1] < (double)gt1.gtLat*b  ? pnt[1]: (double)gt1.gtLat*b;
            //PointF p0 = new PointF((float)x, (float)y);
            //double ss = 0;
            //if (p1.Y < p2.Y) {
            //    ss = getAngle(p1, p2, p0);
            //} else {
            //    ss = getAngle(p2, p1, p0);
            //}
            double ss = 0;
            ss = getAngle((float)gt0.gtLon * b, (float)gt0.gtLat * b, (float)gt1.gtLon * b, (float)gt1.gtLat * b);
            return ss;
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
        public double getLineLength(PointF p1, PointF p2) {
            return Math.Sqrt(Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2));
        }
        public double getAngle(PointF p1, PointF p2, PointF p3) {
            double ab = getLineLength(p1, p2);
            double bc = getLineLength(p2, p3);
            double ac = getLineLength(p1, p3);
            double bac = (ab * ab + ac * ac - bc * bc) / (2 * ab * ac);
            double AngBAC = Math.Acos(bac);
            return AngBAC * 180 / Math.PI;
        }
        public string getBlock(string str) {
            if (str.Contains("铁路")) {
                return "tl.dwg";
            }
            if (str.Contains("公路") || str.Contains("道路") || str.Contains("村路") || str.Contains("绥巴路") ||
                str.Contains("绥望路") || str.Contains("绥八路") || str.Contains("哈里路") || str.Contains("街道")
                || str.Contains("秦三路") || str.Contains("乡道") || str.Contains("绥北路")) {
                return "gl.dwg";
            }
            if (str.Contains("河")) {
                return "hl.dwg";
            }
            if (str.Contains("房屋") || str.Contains("建筑物")) {
                return "fw.dwg";
            }
            if (str.Contains("弱电")) {
                return "rd.dwg";
            }
            if (str.Contains("树木")) {
                return "s.dwg";
            }
            if (str.Contains("桥")) {
                return "xq.dwg";
            }
            if (str.Contains("500") || str.Contains("220") || str.Contains("110") || str.Contains("66") || str.Contains("35")) {
                return "xl2.dwg";
            }
            if (str.Contains("通信") || str.Contains("通讯") || str.Contains("广播") || str.Contains("低压") || str.Contains("有线") || str.Contains("电力线路")) {
                return "xl1.dwg";
            } else {
                return "err.dwg";
            }
        }
        /// <summary>
        /// 画线
        /// </summary>
        /// <param name="points"></param>
        /// <param name="color"></param>
        public void drawLines(PointF[] points, Color color) {
            double[] col = new double[points.Length * 3];
            for (int i = 0; i < points.Length; i++) {
                col[i * 3 + 0] = points[i].X;
                col[i * 3 + 1] = points[i].Y;
                col[i * 3 + 2] = 0;
            }
            AcadPolyline ple = cad.ActiveDocument.ModelSpace.AddPolyline(col);
            ple.ConstantWidth = 0;
            ple.Layer = "line";
            AcadAcCmColor color2 = (AcadAcCmColor)cad.ActiveDocument.Application.GetInterfaceObject("AutoCAD.AcCmColor.17");
            color2.SetRGB(color.R, color.G, color.B);
            ple.TrueColor = color2;
            cad.Application.Update();
        }
        /// <summary>
        /// 画文本
        /// </summary>
        /// <param name="texts"></param>
        /// <param name="points"></param>
        /// <param name="color"></param>
        public void drawTexts(String[] texts, PointF[] points, Color color) {
            for (int i = 0; i < texts.Length; i++) {
                double[] pnt = new double[3];
                pnt[0] = points[i].X;
                pnt[1] = points[i].Y;
                pnt[2] = 0;
                AcadMText ntext = cad.ActiveDocument.ModelSpace.AddMText(pnt, 1, texts[i]);
                ntext.Height = 0.0001;
                ntext.Layer = "gth";
                AcadAcCmColor color2 = (AcadAcCmColor)cad.ActiveDocument.Application.GetInterfaceObject("AutoCAD.AcCmColor.17");
                color2.SetRGB(color.R, color.G, color.B);
                ntext.TrueColor = color2;
                cad.Application.Update();
            }
        }
        /// <summary>
        /// 画矩形
        /// </summary>
        /// <param name="rectf"></param>
        /// <param name="color"></param>
        public void drawRects(RectangleF[] rects, Color color) {
            for (int i = 0; i < rects.Length; i++) {
                double[] pnt = new double[3];
                pnt[0] = rects[i].Location.X;
                pnt[1] = rects[i].Location.Y;
                pnt[2] = 0;
                Acad3DSolid ntext = cad.ActiveDocument.ModelSpace.AddBox(pnt, 0, rects[i].Width, rects[i].Height);
                ntext.Layer = "line";
                AcadAcCmColor color2 = (AcadAcCmColor)cad.ActiveDocument.Application.GetInterfaceObject("AutoCAD.AcCmColor.17");
                color2.SetRGB(color.R, color.G, color.B);
                ntext.TrueColor = color2;
                cad.Application.Update();
            }
        }
        /// <summary>
        /// 画填充矩形
        /// </summary>
        /// <param name="rectf"></param>
        /// <param name="color"></param>
        public void drawFillRects(RectangleF[] rects, Color color) {
            for (int i = 0; i < rects.Length; i++) {
                double[] pnt = new double[3];
                pnt[0] = rects[i].Location.X;
                pnt[1] = rects[i].Location.Y;
                pnt[2] = 0;
                Acad3DSolid r = cad.ActiveDocument.ModelSpace.AddBox(pnt, 0, rects[i].Width, rects[i].Height);
                r.Layer = "line";
                AcadAcCmColor color2 = (AcadAcCmColor)cad.ActiveDocument.Application.GetInterfaceObject("AutoCAD.AcCmColor.17");
                color2.SetRGB(color.R, color.G, color.B);
                r.TrueColor = color2;
                AcadHatch wt = cad.ActiveDocument.ModelSpace.AddHatch(0, "solid", true, 0);
                wt.color = ACAD_COLOR.acBlue;
                AcadEntity[] ot = new AcadEntity[1];
                ot[0] = (AcadEntity)r;
                wt.AppendOuterLoop(ot);
                wt.Evaluate();
                cad.Application.Update();
            }
        }
        /// <summary>
        /// 画圆
        /// </summary>
        /// <param name="rectf"></param>
        /// <param name="color"></param>
        public void drawCircles(RectangleF[] rects, Color color) {
            for (int i = 0; i < rects.Length; i++) {
                double[] pnt = new double[3];
                pnt[0] = rects[i].Location.X + rects[i].Width / 2;
                pnt[1] = rects[i].Location.Y + rects[i].Height / 2;
                pnt[2] = 0;
                AcadCircle cir = cad.ActiveDocument.ModelSpace.AddCircle(pnt, rects[i].Width / 2);
                cir.Layer = "line";
                AcadAcCmColor color2 = (AcadAcCmColor)cad.ActiveDocument.Application.GetInterfaceObject("AutoCAD.AcCmColor.17");
                color2.SetRGB(color.R, color.G, color.B);
                cir.TrueColor = color2;
                cad.Application.Update();
            }
        }
        /// <summary>
        /// 画块(块在此类中内部定义方法)
        /// </summary>
        /// <param name="points"></param>
        /// <param name="blockName"></param>
        /// <param name="color"></param>
        public void drawBlocks(PointF[] points, string blockName, Color color) {
            switch (blockName) {
                case "Block1":
                    drawBlockName1(points, color);
                    break;
                case "":
                    break;

            }
        }

        void drawBlockName1(PointF[] points, Color color) {
            //块方法

        }
    }


}
