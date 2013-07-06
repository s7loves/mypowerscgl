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
    public class ExportSD08
    {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(IList<sdjl_07jdzz> objlist) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\送电08接地装置检测.xls";
            ex.Open(fname);
            //此处写填充内容代码
            int rowcount = 6;
            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(objlist.Count, 16))
            {
                pageindex = Ecommon.GetPagecount(objlist.Count, 16);
            }
            for (int j = 1; j <= pageindex; j++)
            {
                ex.SetCellValue(objlist[0].LineName, 4, 3);
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
                int starow = prepageindex * 16 + 1;
                int endrow = j * 16;
                if (objlist.Count > endrow)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        ex.SetCellValue(objlist[starow - 1 + i].gth, rowcount + 1 + i, 1);
                        ex.SetCellValue(objlist[starow - 1 + i].gzwz, rowcount + 1 + i, 2);
                        ex.SetCellValue(objlist[starow - 1 + i].sbmc, rowcount + 1 + i, 3);
                        ex.SetCellValue(objlist[starow - 1 + i].jddz.ToString(), rowcount + 1 + i, 4);
                        ex.SetCellValue(objlist[starow - 1 + i].CreateDate.Year.ToString(), rowcount + 1 + i, 5);
                        ex.SetCellValue(objlist[starow - 1 + i].CreateDate.Month.ToString(), rowcount + 1 + i, 6);
                        ex.SetCellValue(objlist[starow - 1 + i].CreateDate.Day.ToString(), rowcount + 1 + i, 7);
                        ex.SetCellValue(objlist[starow - 1 + i].trdzr.ToString(), rowcount + 1 + i, 8);
                        ex.SetCellValue(objlist[starow - 1 + i].tz.ToString(), rowcount + 1 + i, 9);
                        ex.SetCellValue(objlist[starow - 1 + i].xhgg, rowcount + 1 + i, 10);
                        ex.SetCellValue(objlist[starow - 1 + i].fzxl, rowcount + 1 + i, 11);
                        ex.SetCellValue(objlist[starow - 1 + i].CreateMan, rowcount + 1 + i, 12);
                    }
                }
                else if (objlist.Count <= endrow && objlist.Count >= starow)
                {
                    for (int i = 0; i < objlist.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(objlist[starow - 1 + i].gth, rowcount + 1 + i, 1);
                        ex.SetCellValue(objlist[starow - 1 + i].gzwz, rowcount + 1 + i, 2);
                        ex.SetCellValue(objlist[starow - 1 + i].sbmc, rowcount + 1 + i, 3);
                        ex.SetCellValue(objlist[starow - 1 + i].jddz.ToString(), rowcount + 1 + i, 4);
                        ex.SetCellValue(objlist[starow - 1 + i].CreateDate.Year.ToString(), rowcount + 1 + i, 5);
                        ex.SetCellValue(objlist[starow - 1 + i].CreateDate.Month.ToString(), rowcount + 1 + i, 6);
                        ex.SetCellValue(objlist[starow - 1 + i].CreateDate.Day.ToString(), rowcount + 1 + i, 7);
                        ex.SetCellValue(objlist[starow - 1 + i].trdzr.ToString(), rowcount + 1 + i, 8);
                        ex.SetCellValue(objlist[starow - 1 + i].tz.ToString(), rowcount + 1 + i, 9);
                        ex.SetCellValue(objlist[starow - 1 + i].xhgg, rowcount + 1 + i, 10);
                        ex.SetCellValue(objlist[starow - 1 + i].fzxl, rowcount + 1 + i, 11);
                        ex.SetCellValue(objlist[starow - 1 + i].CreateMan, rowcount + 1 + i, 12);
                        //ex.SetCellValue(objlist[starow - 1 + i].Remark, rowcount + i, 10);
                    }
                }
            }
           ex.ActiveSheet(1);
           ex.ShowExcel();
        }
      
    }
}
