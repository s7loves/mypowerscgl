using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
namespace Ebada.Scgl.Lcgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class Export24  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PJ_24 jl)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\24设备变更通知书.xls";

            ex.Open(fname);
            int row = 1;
            int col = 1;
            //
            ex.SetCellValue(jl.sj.Year.ToString(), row + 8, col);
            ex.SetCellValue(jl.sj.Month.ToString(), row + 8, col+2);
            ex.SetCellValue(jl.sj.Day.ToString(), row + 8, col+4);
            ex.SetCellValue(jl.dd, row + 5, col+6);
            ex.SetCellValue(jl.nr, row + 5, col + 7);
            ex.SetCellValue(jl.Remark, row + 5, col + 10);

            ex.ShowExcel();
        }
      
    }
}
