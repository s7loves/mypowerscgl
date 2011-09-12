using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class Export11 {
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExcelbyq(IList<PJ_yfsyjl> datalist, string sheetname)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";
            ex.Open(fname);
            int pagecount = 0, i = 0, pageindex = 0,sheetindex=0;
            Excel.Workbook wb =ex.MyWorkBook  as Excel.Workbook;
          
            pagecount =Convert.ToInt32 (Math.Ceiling(datalist.Count / 2.0));
            ex.ActiveSheet(sheetname );
            for (i = 1; i <= wb.Application.Worksheets.Count; i++)
            {
               Excel.Worksheet sheet= wb.Application.Worksheets[i] as Excel.Worksheet;
               if (sheet.Name == sheetname)
               {
                   sheetindex = sheet.Index;
                   break;
               }
            }
            int itemp = sheetindex;
            for (i = 1; i < pagecount ; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp+1, sheetname + (i + 1));
                itemp++;

            }
            for (i = 0; i < datalist.Count; i++)
            {



            }
            ex.ActiveSheet(sheetname);
            ex.ShowExcel();
        }
        /// <summary>
        /// 文档格式预定义好的，生成台账
        /// </summary>
        /// <param name="obj"></param>
        public static void ExportExceldlq(IList<PJ_yfsyhcjl> datalist, string sheetname)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";

            ex.Open(fname);
            
            ex.ActiveSheet(1);
            ex.ShowExcel();
        }
    }
}
