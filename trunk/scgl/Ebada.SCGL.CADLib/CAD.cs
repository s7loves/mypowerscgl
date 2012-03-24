﻿using System;
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
using System.Xml;
using System.Configuration;
using Ebada.Scgl.Model;


namespace Ebada.SCGL.CADLib
{
    public class CAD
    {

        FlashWindow f = new FlashWindow();
        string color_str = "#00FF00";//线条颜色
        /// <summary>
        /// 导出线路到CAD
        /// </summary>
        /// <param name="linecode">线路编号数组</param>
        public void ToDwg(string[] linecode)
        {
            try
            {
                AcadApplication cad;
                f.SetText("处理中请等待......");
                f.Show();
                cad = AutoCADConnector();
                cad.ActiveDocument.SendCommand("-units 2 8 1 0 0 n ");
                if (cad != null)
                {
                    AcadLayer layer = cad.ActiveDocument.Layers.Add("line");
                    for (int n = 0; n < linecode.Length; n++)
                    {
                        f.SetText("正在处理线路"+linecode[n]);
                        IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='"+linecode[n]+"' order by gth");
                        CallCAD(cad, list);
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
                AcadApplication cad;
                f.SetText("处理中请等待......");
                f.Show();
                cad = AutoCADConnector();
                cad.ActiveDocument.SendCommand("-units 2 8 1 0 0 n ");
                if (cad != null)
                {
                    AcadLayer layer = cad.ActiveDocument.Layers.Add("line");
                    IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PS_gt>("where LineCode='"+linecode+"' order by gth");
                    CallCAD(cad, list);
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

                PS_xl xl= Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>(" where LineID='"+list[0].LineCode+"'");
                double[] ins = new double[3];
                ins[0] = Convert.ToDouble(list[0].gtLon.ToString("0.########"));
                ins[1] = Convert.ToDouble(list[0].gtLat.ToString("0.########"));
                ins[2] = 0;
                AcadMText text = cad.ActiveDocument.ModelSpace.AddMText(ins, 5, xl.LineName);
                text.Height = 0.005;
                text.Layer = "line";
                cad.Application.Update();
            }
            catch (Exception e) { MessageBox.Show(e.Message); };
        }
    }

}
