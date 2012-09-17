using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
using Ebada.Scgl.Core;

namespace Ebada.jhgl
{
   public class ExportPDCA
    {
       public static void ExportExcelMoth(JH_yearkst year, IList<JH_monthks> nrList)
       {
           
           ExcelAccess ex = new ExcelAccess();
           SaveFileDialog saveFileDialog1 = new SaveFileDialog();
           string fname = Application.StartupPath + "\\00记录模板\\pdca循环一览表.xls";
           ex.Open(fname);
           int row = 1;
           int col = 1;
           ex.SetCellValue(year.标题,row,col);
           ex.SetCellValue(year.单位代码,row+2,col);;
           ex.SetCellValue(year.开始日期.ToString(), 3, 9);
           ex.SetCellValue(year.结束日期.ToString(), 3, 11);
           for (int i = 0; i < nrList.Count;i++ )
           {

               ex.SetCellValue(nrList[i].计划项目, row + 5 + i, 2);
               ex.SetCellValue(nrList[i].预计时间.ToString(), row + 5 + i, 3);
               ex.SetCellValue(nrList[i].主要负责人, row + 5 + i, 4);
               ex.SetCellValue(nrList[i].参加人员, row + 5 + i, 5);
               ex.SetCellValue(nrList[i].实施内容, row + 5 + i,6);
               ex.SetCellValue(nrList[i].完成时间.ToString(), row + 5 + i, 7);
               ex.SetCellValue(nrList[i].未完成原因, row + 5 + i, 8);
                 ex.SetCellValue(nrList[i].完成时间.ToString(), row + 5 + i, 9);
                ex.SetCellValue(nrList[i].总结提升, row + 5 + i, 10);
                
           }
           ex.ActiveSheet(1);
           ex.ShowExcel();
       }
       public static void ExportExcelWeek(JH_yearkst year, IList<JH_weekks> nrList)
       {

           ExcelAccess ex = new ExcelAccess();
           SaveFileDialog saveFileDialog1 = new SaveFileDialog();
           string fname = Application.StartupPath + "\\00记录模板\\pdca循环一览表.xls";
           ex.Open(fname);
           int row = 1;
           int col = 1;
           ex.SetCellValue(year.标题, row, col);
           ex.SetCellValue(year.单位代码, row + 2, col); ;
           ex.SetCellValue(year.开始日期.ToString(), 3, 9);
           ex.SetCellValue(year.结束日期.ToString(), 3, 11);
           for (int i = 0; i < nrList.Count; i++)
           {

               ex.SetCellValue(nrList[i].计划项目, row + 5 + i, 2);
               ex.SetCellValue(nrList[i].预计时间.ToString(), row + 5 + i, 3);
               ex.SetCellValue(nrList[i].主要负责人, row + 5 + i, 4);
               ex.SetCellValue(nrList[i].参加人员, row + 5 + i, 5);
               ex.SetCellValue(nrList[i].实施内容, row + 5 + i, 6);
               ex.SetCellValue(nrList[i].完成时间.ToString(), row + 5 + i, 7);
               ex.SetCellValue(nrList[i].未完成原因, row + 5 + i, 8);
               ex.SetCellValue(nrList[i].完成时间.ToString(), row + 5 + i, 9);
               ex.SetCellValue(nrList[i].总结提升, row + 5 + i, 10);

           }
           ex.ActiveSheet(1);
           ex.ShowExcel();
       }
    }
}
