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
    public class ExportSDxlwh
    {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcel(IList<sdjls_xlwhjl> objlist) {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\送电20线路污秽地段记录.xls";

            ex.Open(fname);
            //此处写填充内容代码
            int rowcount = 7;
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
                ex.SetCellValue(objlist[0].LineName, 4, 2);
                ex.SetCellValue(objlist[0].LineVol, 4, 6);
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
                        ex.SetCellValue(objlist[starow - 1 + i].whqd, rowcount + i, 1);
                        ex.SetCellValue(objlist[starow - 1 + i].wyxz, rowcount + i, 2);
                        ex.SetCellValue(objlist[starow - 1 + i].whdj, rowcount + i, 3);
                        ex.SetCellValue(objlist[starow - 1 + i].xlbj, rowcount + i, 4);
                        ex.SetCellValue(objlist[starow - 1 + i].jyzxh, rowcount + i, 5);
                        ex.SetCellValue(objlist[starow - 1 + i].zhfs, rowcount + i, 6);
                        ex.SetCellValue(objlist[starow - 1 + i].bz, rowcount + i, 7);
                    }
                }
                else if (objlist.Count <= endrow && objlist.Count >= starow)
                {
                    for (int i = 0; i < objlist.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(objlist[starow - 1 + i].whqd, rowcount + i, 1);
                        ex.SetCellValue(objlist[starow - 1 + i].wyxz, rowcount + i, 2);
                        ex.SetCellValue(objlist[starow - 1 + i].whdj, rowcount + i, 3);
                        ex.SetCellValue(objlist[starow - 1 + i].xlbj, rowcount + i, 4);
                        ex.SetCellValue(objlist[starow - 1 + i].jyzxh, rowcount + i, 5);
                        ex.SetCellValue(objlist[starow - 1 + i].zhfs, rowcount + i, 6);
                        ex.SetCellValue(objlist[starow - 1 + i].bz, rowcount + i, 7);
                    }
                }
            }
            ex.ActiveSheet(1);
            
           ex.ShowExcel();
        }
      
    }
}
