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
    public class Export06  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PJ_06sbxs obj) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\06设备巡视及缺陷消除记录.xls";

            ex.Open(fname);
            //每行显示文字长度
            int zc = 60;
            //与会人员之间的间隔符号
            char[] jksign = new char[1] { ';' };
            int row = 1;
            int col = 1;

            //主持人
            //ex.SetCellValue(obj.zcr, 4, 2);
            
           

            ex.ShowExcel();
           
        }
      
    }
}
