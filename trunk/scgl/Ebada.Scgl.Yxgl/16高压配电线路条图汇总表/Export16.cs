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
    public class Export16  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PJ_16 obj)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\16高压配电线路条图汇总表.xls";

            ex.Open(fname);
            //此处写填充内容代码
            //线路名称
            ex.SetCellValue(obj.LineName, 4, 2);
            //总的杆塔数
            string sumgt = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", "where LineCode='" + obj.LineCode + "'").ToString();
            ex.SetCellValue(sumgt, 7, 2);
            sumgt = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", "where LineCode='" + obj.LineCode + "'and gtType='铁塔'").ToString();
            ex.SetCellValue(sumgt, 8, 2);
            sumgt = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", "where LineCode='" + obj.LineCode + "'and gtType='钢管杆'").ToString();
            ex.SetCellValue(sumgt, 9, 2);
            sumgt = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", "where LineCode='" + obj.LineCode + "'and gtType='水泥杆'").ToString();
            ex.SetCellValue(sumgt, 10, 2);
            sumgt = Client.ClientHelper.PlatformSqlMap.GetObject("GetPS_gtRowCount", "where LineCode='" + obj.LineCode + "'and gtType='木杆'").ToString();
            ex.SetCellValue(sumgt, 11, 2);
           ex.ShowExcel();
        }
      
    }
}
