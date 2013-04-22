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
    public class ExportSD26
    {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(sdjl_26 obj) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\送电26防护通知书.xls";

            ex.Open(fname);
            //此处写填充内容代码
            ex.ActiveSheet(1);
            ex.SetCellValue(obj.tzdw, 5, 1);
            ex.SetCellValue(obj.lineVol, 6, 11);
            ex.SetCellValue(obj.c1, 7, 3);
            ex.SetCellValue(obj.fxwt, 8, 2);
            ex.SetCellValue(obj.clcs, 14, 2);

           ex.ShowExcel();
        }
      
    }
}
