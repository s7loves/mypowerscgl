using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
using System.IO;
namespace Ebada.Scgl.Yxgl
{
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class ExportSD23
    {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(sdjl_23 obj)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\送电16电力设备产权、维护范围协议书.xls";
            if (obj.BigData != null)
            {
                if (obj.BigData.Length > 10)
                {
                    fname = Path.GetTempPath() + "送电16电力设备产权、维护范围协议书.xls";
                    //MemoryStream ms = new MemoryStream(obj.BigData);
                    FileStream fs = new FileStream(fname, FileMode.OpenOrCreate);
                    fs.Write(obj.BigData, 0, obj.BigData.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
            ex.Open(fname);
            ex.SetCellValue(obj.jf, 5, 4);
            ex.SetCellValue(obj.xybh, 4, 11);
            ex.SetCellValue(obj.cqdw + "：", 6, 4);
            string linename = "";
            if (obj.linename.Contains("线"))
            {
                linename = obj.linename.Substring(0, obj.linename.LastIndexOf("线"));
            }
            else
                linename = obj.linename;
            string[] filtchar = { "V", "v" };
            for (int i = 0; i < filtchar.Length; i++)
            {
                if (linename.Contains(filtchar[i]))
                {
                    linename = linename.Substring(linename.LastIndexOf(filtchar[i]) + 1);
                }
            }
            ex.SetCellValue(linename,9, 9);
            //string fzlinename = "";
            //if (obj.fzlinename.Contains("支"))
            //{
            //    fzlinename = obj.fzlinename.Substring(0, obj.fzlinename.LastIndexOf("支"));
            //}
            //else
            //    fzlinename = obj.fzlinename;
            //ex.SetCellValue(fzlinename, 10, 10);
            ex.SetCellValue(obj.cqfw, 10, 4);
            ex.SetCellValue("'" + obj.gh, 9, 12);
            ex.SetCellValue(obj.cqdw+"。", 12, 4);
            ex.SetCellValue(obj.jf, 11, 4);
            ex.SetCellValue(obj.qxydd, 15, 8);
            ex.SetCellValue(obj.qdrq.Year.ToString(), 21, 11);
            ex.SetCellValue(obj.qdrq.Month.ToString(), 21, 13);
            ex.SetCellValue(obj.qdrq.Day.ToString(), 21, 16);
            ex.ShowExcel();
        }

    }
}
