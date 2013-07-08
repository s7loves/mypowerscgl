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
    public class ExportSDJyzylcl
    {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(IList<sdjls_jyzylcl> objlist) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\送电19线路绝缘子等值含盐量测量记录.xls";

            ex.Open(fname);
            //此处写填充内容代码
            int rowcount = 6;
            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(objlist.Count, 17))
            {
                pageindex = Ecommon.GetPagecount(objlist.Count, 17);
            }
            for (int j = 1; j <= pageindex; j++)
            {
                if (j > 1)
                {
                    ex.CopySheet(1, 1);
                }
                ex.SetCellValue(objlist[0].LineName, 3, 3);
            }
 
            for (int j = 1; j <= pageindex; j++)
            {

                ex.ActiveSheet(j);
               
                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * 17 + 1;
                int endrow = j * 17;
                
                if (objlist.Count > endrow)
                {
                    for (int i = 0; i < 17; i++)
                    {
                        ex.SetCellValue((i + 1).ToString(), rowcount + i, 1);
                        ex.SetCellValue(objlist[starow - 1 + i].gh, rowcount + i, 2);
                        ex.SetCellValue(objlist[starow - 1 + i].wz, rowcount + i, 3);
                        ex.SetCellValue(objlist[starow - 1 + i].xh, rowcount + i, 4);
                        ex.SetCellValue(objlist[starow - 1 + i].bmj, rowcount + i, 5);
                        ex.SetCellValue(objlist[starow - 1 + i].wd, rowcount + i, 6);
                        ex.SetCellValue(objlist[starow - 1 + i].dzhyl, rowcount + i, 7);
                        ex.SetCellValue(objlist[starow - 1 + i].scymz, rowcount + i, 8);
                        ex.SetCellValue(objlist[starow - 1 + i].scwhdj, rowcount + i, 9);
                        ex.SetCellValue(objlist[starow - 1 + i].whtz, rowcount + i, 10);
                        ex.SetCellValue(objlist[starow - 1 + i].clrq.Year.ToString(), rowcount + i, 11);
                        ex.SetCellValue(objlist[starow - 1 + i].clrq.Month.ToString(), rowcount + i, 12);
                        ex.SetCellValue(objlist[starow - 1 + i].clrq.Day.ToString(), rowcount + i, 13);
                    }
                }
                else if (objlist.Count <= endrow && objlist.Count >= starow)
                {
                    for (int i = 0; i < objlist.Count - starow + 1; i++)
                    {
                        ex.SetCellValue((i + 1).ToString(), rowcount + i, 1);
                        ex.SetCellValue(objlist[starow - 1 + i].gh, rowcount + i, 2);
                        ex.SetCellValue(objlist[starow - 1 + i].wz, rowcount + i, 3);
                        ex.SetCellValue(objlist[starow - 1 + i].xh, rowcount + i, 4);
                        ex.SetCellValue(objlist[starow - 1 + i].bmj, rowcount + i, 5);
                        ex.SetCellValue(objlist[starow - 1 + i].wd, rowcount + i, 6);
                        ex.SetCellValue(objlist[starow - 1 + i].dzhyl, rowcount + i, 7);
                        ex.SetCellValue(objlist[starow - 1 + i].scymz, rowcount + i, 8);
                        ex.SetCellValue(objlist[starow - 1 + i].scwhdj, rowcount + i, 9);
                        ex.SetCellValue(objlist[starow - 1 + i].whtz, rowcount + i, 10);
                        ex.SetCellValue(objlist[starow - 1 + i].clrq.Year.ToString(), rowcount + i, 11);
                        ex.SetCellValue(objlist[starow - 1 + i].clrq.Month.ToString(), rowcount + i, 12);
                        ex.SetCellValue(objlist[starow - 1 + i].clrq.Day.ToString(), rowcount + i, 13);
                    }
                }
            }
            ex.ActiveSheet(1);
            
           ex.ShowExcel();
        }
      
    }
}
