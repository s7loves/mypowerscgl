using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class Export23  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PJ_23 obj) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\23配电线路产权维护范围协议书.xls";

            ex.Open(fname);
            //此处写填充内容代码

            ex.SetCellValue(obj.xybh, 4, 8);
            ex.SetCellValue(obj.cqdw + "：", 6, 4);
            string linename = "";
            if (obj.linename.Contains("线"))
            {
                linename = obj.linename.Substring(0, obj.linename.LastIndexOf("线"));
            }
            else
                linename = obj.linename;
            ex.SetCellValue(linename, 10, 7);
            string fzlinename = "";
            if (obj.fzlinename.Contains("支"))
            {
                fzlinename = obj.fzlinename.Substring(0, obj.fzlinename.LastIndexOf("支"));
            }
            else
                fzlinename = obj.fzlinename;
            ex.SetCellValue(obj.fzlinename, 10, 10);
            ex.SetCellValue("'" + obj.gh, 10, 16);
            ex.SetCellValue(obj.cqfw, 11, 4);
            ex.SetCellValue(obj.cqdw, 13, 4);
            ex.SetCellValue(obj.cqdw, 15, 8);
            ex.SetCellValue(obj.qdrq.Year.ToString(), 21, 7);
            ex.SetCellValue(obj.qdrq.Month.ToString(), 21, 9);
            ex.SetCellValue(obj.qdrq.Day.ToString(), 21, 11);
           ex.ShowExcel();
        }
      
    }
}
