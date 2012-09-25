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
       public static void ExportExcelYear(JH_yearkst year, IList<JH_yearks> nrList) {

           ExcelAccess ex = new ExcelAccess();
           SaveFileDialog saveFileDialog1 = new SaveFileDialog();
           string fname = Application.StartupPath + "\\00记录模板\\pdca循环一览表.xls";
           ex.Open(fname);
           int row = 1;
           int col = 1;
           //加页
           int pageindex = 1;
           if (pageindex < Ecommonjh.GetPagecount(nrList.Count, 7)) {
               pageindex = Ecommonjh.GetPagecount(nrList.Count, 7);
           }
           for (int j = 1; j <= pageindex; j++) {
               if (j > 1) {
                   ex.CopySheet(1, 1);
               }
           }
           // PS_xl xlobject = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_xl>(jl.LineID);
           ex.ActiveSheet(1);
           ex.SetCellValue(year.标题.Replace("计划", "PDCA循环一览表"), row, col);
           ex.SetCellValue(year.单位代码, row + 2, col); ;
           ex.SetCellValue(year.开始日期.ToString("yyyy-MM-dd"), 3, 8);
           ex.SetCellValue(year.结束日期.ToString("yyyy-MM-dd"), 3, 11);

           for (int j = 1; j <= pageindex; j++) {
               ex.ActiveSheet(j);
               //ex.ReNameWorkSheet(j, "Sheet" + (j));
               int prepageindex = j - 1;
               //主题
               int starow = prepageindex * 7 + 1;
               int endrow = j * 7;

               if (nrList.Count > endrow) {
                   for (int i = 0; i < 7; i++) {
                       ex.SetCellValue(nrList[starow - 1 + i].计划项目, row + 5 + i, 2);
                       ex.SetCellValue(nrList[starow - 1 + i].预计时间.ToString("yyyy-MM-dd"), row + 5 + i, 3);
                       ex.SetCellValue(nrList[starow - 1 + i].主要负责人, row + 5 + i, 4);
                       ex.SetCellValue(nrList[starow - 1 + i].参加人员, row + 5 + i, 5);
                       ex.SetCellValue(nrList[starow - 1 + i].实施内容, row + 5 + i, 6);
                       ex.SetCellValue(nrList[starow - 1 + i].完成标记, row + 5 + i, 7);
                       ex.SetCellValue(nrList[starow - 1 + i].未完成原因, row + 5 + i, 8);
                       ex.SetCellValue(nrList[starow - 1 + i].完成时间.ToString("yyyy-MM-dd"), row + 5 + i, 9);
                       ex.SetCellValue(nrList[starow - 1 + i].总结提升, row + 5 + i, 10);


                   }
               } else if (nrList.Count <= endrow && nrList.Count >= starow) {
                   for (int i = 0; i < nrList.Count - starow + 1; i++) {
                       ex.SetCellValue(nrList[starow - 1 + i].计划项目, row + 5 + i, 2);
                       ex.SetCellValue(nrList[starow - 1 + i].预计时间.ToString("yyyy-MM-dd"), row + 5 + i, 3);
                       ex.SetCellValue(nrList[starow - 1 + i].主要负责人, row + 5 + i, 4);
                       ex.SetCellValue(nrList[starow - 1 + i].参加人员, row + 5 + i, 5);
                       ex.SetCellValue(nrList[starow - 1 + i].实施内容, row + 5 + i, 6);
                       ex.SetCellValue(nrList[starow - 1 + i].完成标记, row + 5 + i, 7);
                       ex.SetCellValue(nrList[starow - 1 + i].未完成原因, row + 5 + i, 8);
                       ex.SetCellValue(nrList[starow - 1 + i].完成时间.ToString("yyyy-MM-dd"), row + 5 + i, 9);
                       ex.SetCellValue(nrList[starow - 1 + i].总结提升, row + 5 + i, 10);

                   }
               }

           }
           ex.ActiveSheet(1);
           ex.ShowExcel();
       }
       public static void ExportExcelMoth(JH_yearkst year, IList<JH_monthks> nrList)
       {
           
           ExcelAccess ex = new ExcelAccess();
           SaveFileDialog saveFileDialog1 = new SaveFileDialog();
           string fname = Application.StartupPath + "\\00记录模板\\pdca循环一览表.xls";
           ex.Open(fname);
           int row = 1;
           int col = 1;
           //加页
           int pageindex = 1;
           if (pageindex < Ecommonjh.GetPagecount(nrList.Count, 7))
           {
               pageindex = Ecommonjh.GetPagecount(nrList.Count, 7);
           }
           for (int j = 1; j <= pageindex; j++)
           {
               if (j > 1)
               {
                   ex.CopySheet(1, 1);
               }
           }
           // PS_xl xlobject = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_xl>(jl.LineID);
           ex.ActiveSheet(1);
           ex.SetCellValue(year.标题.Replace("计划", "PDCA循环一览表"), row, col);
           ex.SetCellValue(year.单位代码,row+2,col);;
           ex.SetCellValue(year.开始日期.ToString("yyyy-MM-dd"), 3, 8);
           ex.SetCellValue(year.结束日期.ToString("yyyy-MM-dd"), 3, 11);

           for (int j = 1; j <= pageindex; j++)
           {
               ex.ActiveSheet(j);
               //ex.ReNameWorkSheet(j, "Sheet" + (j));
               int prepageindex = j - 1;
               //主题
               int starow = prepageindex * 7 + 1;
               int endrow = j * 7;

               if (nrList.Count > endrow)
               {
                   for (int i = 0; i < 7; i++)
                   {
                       ex.SetCellValue(nrList[starow - 1 + i].计划项目, row + 5 + i, 2);
                       ex.SetCellValue(nrList[starow - 1 + i].预计时间.ToString("yyyy-MM-dd"), row + 5 + i, 3);
                       ex.SetCellValue(nrList[starow - 1 + i].主要负责人, row + 5 + i, 4);
                       ex.SetCellValue(nrList[starow - 1 + i].参加人员, row + 5 + i, 5);
                       ex.SetCellValue(nrList[starow - 1 + i].实施内容, row + 5 + i, 6);
                       ex.SetCellValue(nrList[starow - 1 + i].完成标记, row + 5 + i, 7);
                       ex.SetCellValue(nrList[starow - 1 + i].未完成原因, row + 5 + i, 8);
                       if (nrList[starow - 1 + i].完成时间.Year != 1900)
                       ex.SetCellValue(nrList[starow - 1 + i].完成时间.ToString("yyyy-MM-dd"), row + 5 + i, 9);
                       ex.SetCellValue(nrList[starow - 1 + i].总结提升, row + 5 + i, 10);
                     

                   }
               }
               else if (nrList.Count <= endrow && nrList.Count >= starow)
               {
                   for (int i = 0; i < nrList.Count - starow + 1; i++)
                   {
                       ex.SetCellValue(nrList[starow - 1 + i].计划项目, row + 5 + i, 2);
                       ex.SetCellValue(nrList[starow - 1 + i].预计时间.ToString("yyyy-MM-dd"), row + 5 + i, 3);
                       ex.SetCellValue(nrList[starow - 1 + i].主要负责人, row + 5 + i, 4);
                       ex.SetCellValue(nrList[starow - 1 + i].参加人员, row + 5 + i, 5);
                       ex.SetCellValue(nrList[starow - 1 + i].实施内容, row + 5 + i, 6);
                       ex.SetCellValue(nrList[starow - 1 + i].完成标记, row + 5 + i, 7);
                       ex.SetCellValue(nrList[starow - 1 + i].未完成原因, row + 5 + i, 8);
                       if (nrList[starow - 1 + i].完成时间.Year != 1900)
                       ex.SetCellValue(nrList[starow - 1 + i].完成时间.ToString("yyyy-MM-dd"), row + 5 + i, 9);
                       ex.SetCellValue(nrList[starow - 1 + i].总结提升, row + 5 + i, 10);

                   }
               }

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
           //加页
           int pageindex = 1;
           if (pageindex < Ecommonjh.GetPagecount(nrList.Count, 7))
           {
               pageindex = Ecommonjh.GetPagecount(nrList.Count, 7);
           }
           for (int j = 1; j <= pageindex; j++)
           {
               if (j > 1)
               {
                   ex.CopySheet(1, 1);
               }
           }
           ex.ActiveSheet(1);
           ex.SetCellValue(year.标题.Replace("计划", "PDCA循环一览表"), row, col);
           ex.SetCellValue(year.单位代码, row + 2, col); ;
           ex.SetCellValue(year.开始日期.ToString("yyyy-MM-dd"), 3, 8);
           ex.SetCellValue(year.结束日期.ToString("yyyy-MM-dd"), 3, 11);
           for (int j = 1; j <= pageindex; j++)
           {
               ex.ActiveSheet(j);
               //ex.ReNameWorkSheet(j, "Sheet" + (j));
               int prepageindex = j - 1;
               //主题
               int starow = prepageindex * 7 + 1;
               int endrow = j * 7;

               if (nrList.Count > endrow)
               {
                   for (int i = 0; i < 7; i++)
                   {
                       ex.SetCellValue(nrList[starow - 1 + i].计划项目, row + 5 + i, 2);
                       ex.SetCellValue(nrList[starow - 1 + i].预计时间.ToString("yyyy-MM-dd"), row + 5 + i, 3);
                       ex.SetCellValue(nrList[starow - 1 + i].主要负责人, row + 5 + i, 4);
                       ex.SetCellValue(nrList[starow - 1 + i].参加人员, row + 5 + i, 5);
                       ex.SetCellValue(nrList[starow - 1 + i].实施内容, row + 5 + i, 6);
                       ex.SetCellValue(nrList[starow - 1 + i].完成标记, row + 5 + i, 7);
                       ex.SetCellValue(nrList[starow - 1 + i].未完成原因, row + 5 + i, 8);
                       if(nrList[starow - 1 + i].完成时间.Year!=1900)
                       ex.SetCellValue(nrList[starow - 1 + i].完成时间.ToString("yyyy-MM-dd"), row + 5 + i, 9);
                       ex.SetCellValue(nrList[starow - 1 + i].总结提升, row + 5 + i, 10);


                   }
               }
               else if (nrList.Count <= endrow && nrList.Count >= starow)
               {
                   for (int i = 0; i < nrList.Count - starow + 1; i++)
                   {
                       ex.SetCellValue(nrList[starow - 1 + i].计划项目, row + 5 + i, 2);
                       ex.SetCellValue(nrList[starow - 1 + i].预计时间.ToString("yyyy-MM-dd"), row + 5 + i, 3);
                       ex.SetCellValue(nrList[starow - 1 + i].主要负责人, row + 5 + i, 4);
                       ex.SetCellValue(nrList[starow - 1 + i].参加人员, row + 5 + i, 5);
                       ex.SetCellValue(nrList[starow - 1 + i].实施内容, row + 5 + i, 6);
                       ex.SetCellValue(nrList[starow - 1 + i].完成标记, row + 5 + i, 7);
                       ex.SetCellValue(nrList[starow - 1 + i].未完成原因, row + 5 + i, 8);
                       if (nrList[starow - 1 + i].完成时间.Year != 1900)
                       ex.SetCellValue(nrList[starow - 1 + i].完成时间.ToString("yyyy-MM-dd"), row + 5 + i, 9);
                       ex.SetCellValue(nrList[starow - 1 + i].总结提升, row + 5 + i, 10);

                   }
               }

           }
           ex.ActiveSheet(1);
           ex.ShowExcel();
       }
    }
}
