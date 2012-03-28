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
    public class Export25  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PJ_25 obj) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\25双自备电源协议书.xls";

            ex.Open(fname);
            //此处写填充内容代码
        
            IList<PJ_25zbdymx> list = Client.ClientHelper.PlatformSqlMap.GetList<PJ_25zbdymx>("where ParentID='" + obj.ID + "'and Type='发电机'");
            IList<PJ_25zbdymx> list1 = Client.ClientHelper.PlatformSqlMap.GetList<PJ_25zbdymx>("where ParentID='" + obj.ID + "'and Type='原动机'");


            ex.SetCellValue("乙 方：" + obj.cqdw, 5, 1);
            ex.SetCellValue(obj.qdrq.Year.ToString(), 42, 6);
            ex.SetCellValue(obj.qdrq.Month.ToString(), 42, 8);
            ex.SetCellValue(obj.qdrq.Day.ToString(), 42, 10);
            for (int i = 0; i < list.Count; i++)
            {
                ex.SetCellValue(list[i].xh, 26 + i, 1);
                ex.SetCellValue(list[i].gl.ToString() + "/" + list[i].ts.ToString(), 26 + i, 2);
                ex.SetCellValue(list[i].dy.ToString(), 26 + i, 3);
                ex.SetCellValue(list[i].azrq.ToString("yyyy-MM-dd"), 26 + i, 4);
                ex.SetCellValue(list[i].sccj, 26 + i, 5);
            }
            for (int i = 0; i < list1.Count; i++)
            {
                ex.SetCellValue(list[i].xh, 26 + i, 8);
                ex.SetCellValue(list[i].gl.ToString() + "/" + list[i].ts.ToString(), 26 + i, 11);
                ex.SetCellValue(list[i].dy.ToString(), 26 + i, 12);
                ex.SetCellValue(list[i].azrq.ToString("yyyy-MM-dd"), 26 + i, 13);
                ex.SetCellValue(list[i].sccj, 26 + i, 14);
            }
            ex.SetCellValue(obj.bszz, 30, 2);
            ex.SetCellValue(obj.fzcs, 31, 2);
           ex.ShowExcel();
        }
      
    }
}
