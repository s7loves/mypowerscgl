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
    public class Export14  {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(PS_aqgj obj,IList<PJ_14aqgjsy> objlist)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\14电力安全工具试验记录.xls";

            ex.Open(fname);
            //此处写填充内容代码
            ex.SetCellValue(obj.sbName, 5, 1);
            ex.SetCellValue(obj.sbCode, 5, 4);
            ex.SetCellValue(obj.syzq.ToString(), 5, 5);
            ex.SetCellValue(obj.syxm, 5, 8);
            for (int i = 0; i < objlist.Count; i++)
            {
                if (i>=17)
                {
                    //多页处理
                }
                else
                {
                    //时间
                    ex.SetCellValue(objlist[i].rq.Year.ToString(), 8 + i, 1);
                    ex.SetCellValue(objlist[i].rq.Month.ToString(), 8 + i, 2);
                    ex.SetCellValue(objlist[i].rq.Day.ToString(), 8 + i, 3);
                    //
                    ex.SetCellValue(objlist[i].jr, 8 + i, 4);
                    //送检人
                    //ex.SetCellValue(objlist[i].sjr, 8 + i, 5);
                    //实验人
                    ex.SetCellValue(objlist[i].syr, 8 + i, 6);
                    //安监签字
                    ex.SetCellValue(objlist[i].ajqz, 8 + i, 4);
                    // 下次实验日期
                    ex.SetCellValue(objlist[i].xcsyrq.Year.ToString(), 8 + i, 8);
                    ex.SetCellValue(objlist[i].xcsyrq.Month.ToString(), 8 + i, 9);
                    ex.SetCellValue(objlist[i].xcsyrq.Day.ToString(), 8 + i, 10);
                }
               
            }

           ex.ShowExcel();
        }
      
    }
}
