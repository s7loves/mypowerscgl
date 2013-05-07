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
    public class ExportSDsgbp
    {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(IList<sdjls_sgbp> objlist) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\送电15事故备品备件清册.xls";

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
                ex.SetCellValue(objlist[0].OrgName, 3, 3);
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
                        ex.SetCellValue(objlist[starow - 1 + i].bpbjmc, rowcount + i, 2);
                        ex.SetCellValue(objlist[starow - 1 + i].gexh, rowcount + i, 3);
                        ex.SetCellValue(objlist[starow - 1 + i].dw, rowcount + i, 4);
                        ex.SetCellValue(objlist[starow - 1 + i].lrsl, rowcount + i, 5);
                        ex.SetCellValue(objlist[starow - 1 + i].lrsj.Year.ToString(), rowcount + i, 6);
                        ex.SetCellValue(objlist[starow - 1 + i].lrsj.Month.ToString(), rowcount + i, 7);
                        ex.SetCellValue(objlist[starow - 1 + i].lrsj.Day.ToString(), rowcount + i, 8);
                        ex.SetCellValue(objlist[starow - 1 + i].lcsl, rowcount + i, 9);
                        ex.SetCellValue(Convert.ToDateTime(objlist[starow - 1 + i].lcsj).Year.ToString(), rowcount + i, 10);
                        ex.SetCellValue(Convert.ToDateTime(objlist[starow - 1 + i].lcsj).Month.ToString(), rowcount + i, 11);
                        ex.SetCellValue(Convert.ToDateTime(objlist[starow - 1 + i].lcsj).Day.ToString(), rowcount + i, 12);
                        ex.SetCellValue(objlist[starow - 1 + i].lyr, rowcount + i, 13);
                        ex.SetCellValue(objlist[starow - 1 + i].kcsl, rowcount + i, 14);
                       
                    }
                }
                else if (objlist.Count <= endrow && objlist.Count >= starow)
                {
                    for (int i = 0; i < objlist.Count - starow + 1; i++)
                    {
                        ex.SetCellValue((i + 1).ToString(), rowcount + i, 1);
                        ex.SetCellValue(objlist[starow - 1 + i].bpbjmc, rowcount + i, 2);
                        ex.SetCellValue(objlist[starow - 1 + i].gexh, rowcount + i, 3);
                        ex.SetCellValue(objlist[starow - 1 + i].dw, rowcount + i, 4);
                        ex.SetCellValue(objlist[starow - 1 + i].lrsl, rowcount + i, 5);
                        ex.SetCellValue(objlist[starow - 1 + i].lrsj.Year.ToString(), rowcount + i, 6);
                        ex.SetCellValue(objlist[starow - 1 + i].lrsj.Month.ToString(), rowcount + i, 7);
                        ex.SetCellValue(objlist[starow - 1 + i].lrsj.Day.ToString(), rowcount + i, 8);
                        ex.SetCellValue(objlist[starow - 1 + i].lcsl, rowcount + i, 9);
                        ex.SetCellValue(Convert.ToDateTime(objlist[starow - 1 + i].lcsj).Year.ToString(), rowcount + i, 10);
                        ex.SetCellValue(Convert.ToDateTime(objlist[starow - 1 + i].lcsj).Month.ToString(), rowcount + i, 11);
                        ex.SetCellValue(Convert.ToDateTime(objlist[starow - 1 + i].lcsj).Day.ToString(), rowcount + i, 12);
                        ex.SetCellValue(objlist[starow - 1 + i].lyr, rowcount + i, 13);
                        ex.SetCellValue(objlist[starow - 1 + i].kcsl, rowcount + i, 14);
                    }
                }
            }
            ex.ActiveSheet(1);
            
           ex.ShowExcel();
        }
      
    }
}
