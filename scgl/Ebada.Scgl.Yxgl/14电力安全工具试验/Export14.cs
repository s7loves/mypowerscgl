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
            //lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\14电力安全工具试验记录.xls";

            ex.Open(fname);
            //计算页码
            int pagecout = Ecommon.GetPagecount(objlist.Count, 17);
            //复制空模板并重命名
            for (int m = 1; m < pagecout; m++)
            {
                ex.CopySheet(1, m);
                ex.ReNameWorkSheet(m + 1, "Sheet" + (m + 1));
            }
            for (int p = 0; p < pagecout; p++)
            {
                ex.ActiveSheet(p + 1);
                for (int i = 0; i < 17; i++)
                {
                    if (p * 17 + i >= objlist.Count)
                    {
                        break;
                    }
                    PJ_14aqgjsy tempobj = objlist[p * 17 + i];
                    //时间
                    ex.SetCellValue(tempobj.rq.Year.ToString(), 8 + i, 1);
                    ex.SetCellValue(tempobj.rq.Month.ToString(), 8 + i, 2);
                    ex.SetCellValue(tempobj.rq.Day.ToString(), 8 + i, 3);
                    //
                    ex.SetCellValue(tempobj.jr, 8 + i, 4);
                    //送检人
           //         ex.SetCellValue(tempobj.sjr, 8 + i, 5);
                    //实验人
          //          ex.SetCellValue(tempobj.syr, 8 + i, 6);
                    //安监签字
          //          ex.SetCellValue(tempobj.ajqz, 8 + i, 7);
                    // 下次实验日期
                    ex.SetCellValue(tempobj.xcsyrq.Year.ToString(), 8 + i, 8);
                    ex.SetCellValue(tempobj.xcsyrq.Month.ToString(), 8 + i, 9);
                    ex.SetCellValue(tempobj.xcsyrq.Day.ToString(), 8 + i, 10);
                }

            }

            ex.ActiveSheet(1);
           
            ex.SetCellValue(obj.sbName, 5, 1);
            ex.SetCellValue(obj.sbCode, 5, 4);
            ex.SetCellValue(obj.syzq.ToString()+"年", 5, 5);
            ex.SetCellValue(obj.syxm, 5, 8);


            ex.ActiveSheet(1);
           ex.ShowExcel();
        }
      
    }
}
