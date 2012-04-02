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


namespace Ebada.SCGL.CADLib
{
    public class CAD
    {

        FlashWindow f = new FlashWindow();
        string color_str = "#0000FF";//线条颜色
        int zoom = 1000;             //放大比例

        AcadApplication cad;
        /// <summary>
        /// 导出线路到CAD
        /// </summary>
        /// <param name="linecode">线路编号数组</param>
        public void ToDwg(string[] linecode)
        {
            try
            {
                
                f.SetText("处理中请等待......");
                f.Show();
                cad = AutoCADConnector();
                cad.ActiveDocument.SendCommand("-units 2 8 1 0 0 n ");
                ArrayList nlist= getLineCode(linecode);
                if (cad != null)
                {
                    cad.ActiveDocument.Layers.Add("line");
                    cad.ActiveDocument.Layers.Add("gt");
                    cad.ActiveDocument.Layers.Add("gth");
                    cad.ActiveDocument.Layers.Add("text");
                    for (int n = 0; n < nlist.Count; n++)
                    {
                        f.SetText("正在处理线路" + nlist[n].ToString());
                        IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='" + nlist[n].ToString()+ "' order by gth");
                        IList<PS_gt> newlist = ReLoadList(list);
                        if (newlist.Count > 1)
                        {
                            CallCAD(cad, newlist);
                        }
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
        }
        /// <summary>
        /// 导出线路到CAD
        /// </summary>
        /// <param name="linecode">线路编号</param>
        public void ToDwg(string linecode)
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
                    IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='"+linecode+"' order by gth");
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
        }
        public AcadApplication AutoCADConnector()
        {
            AcadApplication cad;
            try
            {
                cad = (AcadApplication)Marshal.GetActiveObject("AutoCAD.Application.17");
                cad.Visible = false;
            }
            catch
            {
                try
                {
                    cad = new AcadApplicationClass();
                    cad.Visible = false;
                    return cad;
                }
                catch (Exception e2)
                {
                    MessageBox.Show("请安装AutoCAD2009或以上版本。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
            }
            return cad;
        }
        public IList<PS_gt> ReLoadList(IList<PS_gt> list)
        {
            IList<PS_gt> newlist = new List<PS_gt>();
            foreach (PS_gt gt in list)
            {
                if (gt.gtLat != 0 && gt.gtLon != 0)
                {
                    gt.gtLat = gt.gtLat * zoom;
                    gt.gtLon = gt.gtLon * zoom;
                    newlist.Add(gt);
                }
            }
            return newlist;
        }
        public ArrayList getLineCode(string[] code)
        {
            ArrayList r = new ArrayList();
            for (int i = 0; i < code.Length; i++)
            {
                string vol = "";
                string linecode=code[i];
                if (linecode.Length == 6) {
                    PS_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>("where linecode='" + code[i] + "'");

                    if (xl != null)
                        vol = " and linevol='" + xl.LineVol + "' ";
                } else {
                    vol = " and linevol='0.4' ";
                }
                IList<PS_xl> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_xl>("where LineCode like '" + code[i] + "%'"+vol+" order by LineCode");
                for (int j = 0; j < list.Count; j++)
                {
                    r.Add(list[j].LineID);
                }
            }
            return r;
        }
        int bl = 1000;
        public void CallCAD(AcadApplication cad, IList<PS_gt> list)
        {
            try
            {
                double[] col = new double[list.Count * 3];
                int k = 0;
                for (int i = 0; i < list.Count; i++)
                {
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

                for (int i = 0; i < list.Count; i++)
                {
                    double[] pnt = new double[3];
                    pnt[0] = Convert.ToDouble(list[i].gtLon.ToString("0.########"));
                    pnt[1] = Convert.ToDouble(list[i].gtLat.ToString("0.########"));
                    pnt[2] = 0;
                    AcadCircle cirz = cad.ActiveDocument.ModelSpace.AddCircle(pnt, 0.0001*bl);
                    cirz.Layer = "gt";
                    cirz.TrueColor = color;
                    AcadMText ntext = cad.ActiveDocument.ModelSpace.AddMText(pnt, 1, list[i].gth);
                    ntext.Height = 0.0001*bl;
                    ntext.Layer = "gth";
                }
                TX_Point tp =null;
                tp=Client.ClientHelper.PlatformSqlMap.GetOneByKey<TX_Point>(list[0].LineCode);
                if (tp != null) {
                    double[] ins = new double[3];
                    ins[0] = Math.Round(Convert.ToDouble(tp.x), 8) * zoom;
                    ins[1] = Math.Round(Convert.ToDouble(tp.y), 8) * zoom;
                    ins[2] = 0;
                    AcadMText text = cad.ActiveDocument.ModelSpace.AddMText(ins, 5, tp.Text);
                    text.Height = 0.0002 * bl;
                    text.Layer = "text";
                }else{
                
                    PS_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(" where LineID='" + list[0].LineCode + "'");
                    double[] ins = new double[3];
                    ins[0] = Convert.ToDouble(list[0].gtLon.ToString("0.########"));
                    ins[1] = Convert.ToDouble(list[0].gtLat.ToString("0.########"));
                    ins[2] = 0;
                    AcadMText text = cad.ActiveDocument.ModelSpace.AddMText(ins, 5, xl.LineName);
                    text.Height = 0.0002 * bl;
                    text.Layer = "text";
                }
                cad.Application.Update();
            }
            catch (Exception e) { MessageBox.Show(e.Message); };
        }
        /// <summary>
        /// 画线
        /// </summary>
        /// <param name="points"></param>
        /// <param name="color"></param>
        public void drawLines(PointF[] points, Color color) {
            double[] col = new double[points.Length * 3];
            for (int i = 0; i < points.Length; i++)
            {
                col[i * 3 + 0]=points[i].X;
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
            for (int i = 0; i < texts.Length; i++)
            {
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
            for (int i = 0; i < rects.Length; i++)
            {
                double[] pnt = new double[3];               
                pnt[0] = rects[i].Location.X;
                pnt[1] = rects[i].Location.Y;
                pnt[2] = 0;
                Acad3DSolid ntext = cad.ActiveDocument.ModelSpace.AddBox(pnt,0, rects[i].Width, rects[i].Height);
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
            for (int i = 0; i < rects.Length; i++)
            {
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
            for (int i = 0; i < rects.Length; i++)
            {
                double[] pnt = new double[3];
                pnt[0] = rects[i].Location.X + rects[i].Width / 2;
                pnt[1] = rects[i].Location.Y + rects[i].Height / 2;
                pnt[2] = 0;
                AcadCircle cir = cad.ActiveDocument.ModelSpace.AddCircle(pnt, rects[i].Width/2);
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
