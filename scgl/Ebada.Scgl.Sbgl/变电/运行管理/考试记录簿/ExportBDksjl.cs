using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
namespace Ebada.Scgl.Sbgl
{
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class ExportBDksjl
    {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(bdjl_ksjl ksjl) {

            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\考试记录簿.xls";
            ex.Open(fname);
            //此处写填充内容代码
            int rowcount = 9;
            //加页
            IList<bdjl_ksnr> objlist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<bdjl_ksnr>("where parentid='" + ksjl.ID + "'");
            if (objlist == null)
                return;
            if (objlist.Count == 0)
                return;
            int pageindex = 1;
            if (pageindex < Ecommonjh.GetPagecount(objlist.Count, 16))
            {
                pageindex = Ecommonjh.GetPagecount(objlist.Count, 16);
            }
            for (int j = 1; j <= pageindex; j++)
            {
                ex.SetCellValue(ksjl.Ksrq.Year+"年"+ksjl.Ksrq.Month+"月"+ksjl.Ksrq.Day+"日"+"第"+ksjl.Sequence+"号", 4, 1);
                ex.SetCellValue(ksjl.Ksxm, 5, 3);
                ex.SetCellValue(ksjl.UserName, 6, 3);
                ex.SetCellValue(ksjl.PostName, 6, 6);
                ex.SetCellValue(ksjl.PostAge+"年", 6, 9);
                ex.SetCellValue(ksjl.LastExamTime.ToShortDateString(), 7, 4);
                ex.SetCellValue(ksjl.ExamStartTime, 8, 3);
                ex.SetCellValue(ksjl.ExamEndTime, 8, 8);
                
                if (j > 1)
                {
                    ex.CopySheet(1, 1);
                }
            }
            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(j);
                ex.ReNameWorkSheet(j, "Sheet" + (j));
                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * 13 + 1;
                int endrow = j * 13;
                if (objlist.Count > endrow)
                {
                    for (int i = 0; i < 13; i++)
                    {
                        ex.SetCellValue(objlist[starow - 1 + i].th, rowcount + 1 + i, 1);
                        ex.SetCellValue(objlist[starow - 1 + i].nr, rowcount + 1 + i, 2);
                        ex.SetCellValue(objlist[starow - 1 + i].pj, rowcount + 1 + i, 7);
                        //ex.SetCellValue(objlist[starow - 1 + i].CreateMan, rowcount + 1 + i, 12);
                    }
                }
                else if (objlist.Count <= endrow && objlist.Count >= starow)
                {
                    for (int i = 0; i < objlist.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(objlist[starow - 1 + i].th, rowcount + 1 + i, 1);
                        ex.SetCellValue(objlist[starow - 1 + i].nr, rowcount + 1 + i, 2);
                        ex.SetCellValue(objlist[starow - 1 + i].pj, rowcount + 1 + i, 7);
                    }
                }
            }
           ex.ActiveSheet(1);
           ex.ShowExcel();
        }
      
    }
}
