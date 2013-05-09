using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
//using Ebada.Scgl.Core;

namespace Ebada.jhgl
{
   public class ExportPDCA
    {
       /// <summary>
       /// 员工月工作写实
       /// </summary>
       /// <param name="title"></param>
       /// <param name="nrList"></param>
       public static void ExportExcelMantthMonth(string title, IList<JH_weekmant> nrList)
       {
           ExcelAccess ex = new ExcelAccess();
           SaveFileDialog saveFileDialog1 = new SaveFileDialog();
           string fname = Application.StartupPath + "\\00记录模板\\员工月工作写实.xls";
           ex.Open(fname);
           int row = 1;
           int col = 1;
           //加页
           int pageindex = 1;
           if (pageindex < Ecommonjh.GetPagecount(nrList.Count, 20))
           {
               pageindex = Ecommonjh.GetPagecount(nrList.Count, 20);
           }
           for (int j = 1; j <= pageindex; j++)
           {
               ex.ActiveSheet(1);
               if (j > 1)
               {
                   ex.CopySheet(1, 1);
               }
               ex.SetCellValue(title, 1, 2);
           }
           // PS_xl xlobject = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_xl>(jl.LineID);



           for (int j = 1; j <= pageindex; j++)
           {
               ex.ActiveSheet(j);
               //ex.ReNameWorkSheet(j, "Sheet" + (j));
               int prepageindex = j - 1;
               //主题
               int starow = prepageindex * 20 + 1;
               int endrow = j * 20;

               if (nrList.Count > endrow)
               {
                   for (int i = 0; i < 20; i++)
                   {
                       ex.SetCellValue(nrList[starow - 1 + i].单位名称, row + 2 + i, 1);
                       if (nrList[starow - 1 + i].考核时间 == "")
                       {
                           nrList[starow - 1 + i].考核时间 = DateTime.Now.ToShortDateString();
                       }
                       ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].考核时间).Month.ToString(), row + 2 + i, 2);
                       ex.SetCellValue(nrList[starow - 1 + i].姓名, row + 2 + i, 3);
                       ex.SetCellValue(nrList[starow - 1 + i].职务, row + 2 + i, 4);
                       ex.SetCellValue(nrList[starow - 1 + i].考核结果 + "总分" + nrList[starow - 1 + i].c3, row + 2 + i, 5);
                       ex.SetCellValue(nrList[starow - 1 + i].考核人, row + 2 + i, 6);
                       ex.SetCellValue(nrList[starow - 1 + i].考核时间, row + 2 + i, 7);
                   }
               }
               else if (nrList.Count <= endrow && nrList.Count >= starow)
               {
                   for (int i = 0; i < nrList.Count - starow + 1; i++)
                   {
                       ex.SetCellValue(nrList[starow - 1 + i].单位名称, row + 2 + i, 1);
                       if (nrList[starow - 1 + i].考核时间 == "")
                       {
                           nrList[starow - 1 + i].考核时间 = DateTime.Now.ToShortDateString();
                       }
                       ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].考核时间).Month.ToString(), row + 2 + i, 2);
                       ex.SetCellValue(nrList[starow - 1 + i].姓名, row + 2 + i, 3);
                       ex.SetCellValue(nrList[starow - 1 + i].职务, row + 2 + i, 4);
                       ex.SetCellValue(nrList[starow - 1 + i].考核结果 + "总分" + nrList[starow - 1 + i].c3, row + 2 + i, 5);
                       ex.SetCellValue(nrList[starow - 1 + i].考核人, row + 2 + i, 6);
                       ex.SetCellValue(nrList[starow - 1 + i].考核时间, row + 2 + i, 7);
                   }
               }

           }
           ex.ActiveSheet(1);
           ex.ShowExcel();

       }

       /// <summary>
       /// 员工年工作写实
       /// </summary>
       /// <param name="title"></param>
       /// <param name="nrList"></param>
       public static void ExportExcelMantthYear(string title, IList<JH_weekmant> nrList)
       {
           ExcelAccess ex = new ExcelAccess();
           SaveFileDialog saveFileDialog1 = new SaveFileDialog();
           string fname = Application.StartupPath + "\\00记录模板\\员工年工作写实.xls";
           ex.Open(fname);
           int row = 1;
           int col = 1;
           //加页
           int pageindex = 1;
           if (pageindex < Ecommonjh.GetPagecount(nrList.Count, 20))
           {
               pageindex = Ecommonjh.GetPagecount(nrList.Count, 20);
           }
           for (int j = 1; j <= pageindex; j++)
           {
               ex.ActiveSheet(1);
               if (j > 1)
               {
                   ex.CopySheet(1, 1);
               }
               ex.SetCellValue(title, 1, 2);
           }
           // PS_xl xlobject = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_xl>(jl.LineID);



           for (int j = 1; j <= pageindex; j++)
           {
               ex.ActiveSheet(j);
               //ex.ReNameWorkSheet(j, "Sheet" + (j));
               int prepageindex = j - 1;
               //主题
               int starow = prepageindex * 20 + 1;
               int endrow = j * 20;

               if (nrList.Count > endrow)
               {
                   for (int i = 0; i < 20; i++)
                   {
                       ex.SetCellValue(nrList[starow - 1 + i].单位名称, row + 2 + i, 1);
                       if (nrList[starow - 1 + i].考核时间 == "")
                       {
                           nrList[starow - 1 + i].考核时间 = DateTime.Now.ToShortDateString();
                       }
                       ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].考核时间).Year.ToString(), row + 2 + i, 2);
                       ex.SetCellValue(nrList[starow - 1 + i].姓名, row + 2 + i, 3);
                       ex.SetCellValue(nrList[starow - 1 + i].职务, row + 2 + i, 4);
                       ex.SetCellValue(nrList[starow - 1 + i].考核结果 + "总分" + nrList[starow - 1 + i].c3, row + 2 + i, 5);
                       ex.SetCellValue(nrList[starow - 1 + i].考核人, row + 2 + i, 6);
                       ex.SetCellValue(nrList[starow - 1 + i].考核时间, row + 2 + i, 7);
                   }
               }
               else if (nrList.Count <= endrow && nrList.Count >= starow)
               {
                   for (int i = 0; i < nrList.Count - starow + 1; i++)
                   {
                       ex.SetCellValue(nrList[starow - 1 + i].单位名称, row + 2 + i, 1);
                       if (nrList[starow - 1 + i].考核时间 == "")
                       {
                           nrList[starow - 1 + i].考核时间 = DateTime.Now.ToShortDateString();
                       }
                       ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].考核时间).Year.ToString(), row + 2 + i, 2);
                       ex.SetCellValue(nrList[starow - 1 + i].姓名, row + 2 + i, 3);
                       ex.SetCellValue(nrList[starow - 1 + i].职务, row + 2 + i, 4);
                       ex.SetCellValue(nrList[starow - 1 + i].考核结果 + "总分" + nrList[starow - 1 + i].c3, row + 2 + i, 5);
                       ex.SetCellValue(nrList[starow - 1 + i].考核人, row + 2 + i, 6);
                       ex.SetCellValue(nrList[starow - 1 + i].考核时间, row + 2 + i, 7);
                   }
               }

           }
           ex.ActiveSheet(1);
           ex.ShowExcel();

       }


       public static void ExportExcelMantthz(string title, IList<JH_weekmant> nrList)
       {
           ExcelAccess ex = new ExcelAccess();
           SaveFileDialog saveFileDialog1 = new SaveFileDialog();
           string fname = Application.StartupPath + "\\00记录模板\\员工工作写实年终总分表.xls";
           ex.Open(fname);
           int row = 1;
           int col = 1;
           //加页
           int pageindex = 1;
           if (pageindex < Ecommonjh.GetPagecount(nrList.Count, 20))
           {
               pageindex = Ecommonjh.GetPagecount(nrList.Count, 20);
           }
           for (int j = 1; j <= pageindex; j++)
           {
               ex.ActiveSheet(1);
               if (j > 1)
               {
                   ex.CopySheet(1, 1);
               }
               ex.SetCellValue(title, row, col);
           }
           // PS_xl xlobject = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_xl>(jl.LineID);
          

           
           for (int j = 1; j <= pageindex; j++)
           {
               ex.ActiveSheet(j);
               //ex.ReNameWorkSheet(j, "Sheet" + (j));
               int prepageindex = j - 1;
               //主题
               int starow = prepageindex * 20 + 1;
               int endrow = j * 20;

               if (nrList.Count > endrow)
               {
                   for (int i = 0; i < 20; i++)
                   {
                       ex.SetCellValue(nrList[starow - 1 + i].单位名称, row + 2 + i, 1);
                       ex.SetCellValue(nrList[starow - 1 + i].姓名, row + 2 + i, 3);
                       ex.SetCellValue(nrList[starow - 1 + i].考核结果, row + 2 + i, 5);
                       ex.SetCellValue(nrList[starow - 1 + i].c3, row + 2 + i, 10); 
                   }
               }
               else if (nrList.Count <= endrow && nrList.Count >= starow)
               {
                   for (int i = 0; i < nrList.Count - starow + 1; i++)
                   {
                       ex.SetCellValue(nrList[starow - 1 + i].单位名称, row + 2 + i, 1);
                       ex.SetCellValue(nrList[starow - 1 + i].姓名, row + 2 + i, 3);
                       ex.SetCellValue(nrList[starow - 1 + i].考核结果, row + 2 + i, 5);
                       ex.SetCellValue(nrList[starow - 1 + i].c3, row + 2 + i, 10);
                   }
               }

           }
           ex.ActiveSheet(1);
           ex.ShowExcel();

       }
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
               ex.ActiveSheet(j);
               if (j > 1) {
                   ex.CopySheet(1, 1);
               }
               ex.SetCellValue(year.标题.Replace("计划", "PDCA循环一览表"), row, col);

               ex.SetCellValue(year.单位代码, row + 2, col); ;
               ex.SetCellValue(year.开始日期.ToString("yyyy-MM-dd"), 3, 9);
               ex.SetCellValue(year.结束日期.ToString("yyyy-MM-dd"), 3, 11);
           }
           // PS_xl xlobject = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_xl>(jl.LineID);
           //ex.ActiveSheet(1);
     
           //ex.SetCellValue(year.标题.Replace("计划", "PDCA循环一览表"), row, col);

           //ex.SetCellValue(year.单位代码, row + 2, col); ;
           //ex.SetCellValue(year.开始日期.ToString("yyyy-MM-dd"), 3, 9);
           //ex.SetCellValue(year.结束日期.ToString("yyyy-MM-dd"), 3, 11);

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
                       if (nrList[starow - 1 + i].完成时间.Year != 1900)
                       ex.SetCellValue(nrList[starow - 1 + i].完成时间.ToString("yyyy-MM-dd"), row + 5 + i, 9);
                       ex.SetCellValue(nrList[starow - 1 + i].总结提升, row + 5 + i, 10);

                      // ex.SetCellValue(nrList[starow - 1 + i].完成时间.ToString("yyyy-MM-dd"), row + 5 + i, 9);
                      // ex.SetCellValue(nrList[starow - 1 + i].总结提升, row + 5 + i, 10);


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
                      if (nrList[starow - 1 + i].完成时间.Year != 1900)
                       ex.SetCellValue(nrList[starow - 1 + i].完成时间.ToString("yyyy-MM-dd"), row + 5 + i, 9);
                       ex.SetCellValue(nrList[starow - 1 + i].总结提升, row + 5 + i, 10);


                      // ex.SetCellValue(nrList[starow - 1 + i].完成时间.ToString("yyyy-MM-dd"), row + 5 + i, 9);
                       //ex.SetCellValue(nrList[starow - 1 + i].总结提升, row + 5 + i, 10);

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
               ex.ActiveSheet(j);//xjq change
               if (j > 1)
               {
                   ex.CopySheet(1, 1);
               }
               ex.SetCellValue(year.标题.Replace("计划", "PDCA循环一览表"), row, col);//xjq change
               ex.SetCellValue(year.单位代码, row + 2, col); ;
               ex.SetCellValue(year.开始日期.ToString("yyyy-MM-dd"), 3, 9);
               ex.SetCellValue(year.结束日期.ToString("yyyy-MM-dd"), 3, 11);
           }
           // PS_xl xlobject = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_xl>(jl.LineID);
           //ex.ActiveSheet(1);
           //ex.SetCellValue(year.标题.Replace("计划", "PDCA循环一览表"), row, col);
           //ex.SetCellValue(year.单位代码,row+2,col);;
           //ex.SetCellValue(year.开始日期.ToString("yyyy-MM-dd"), 3, 9);
           //ex.SetCellValue(year.结束日期.ToString("yyyy-MM-dd"), 3, 11);

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
       public static void ExportExcelWeek(JH_yearkst year, IList<JH_weekks> nrList) {

           ExcelAccess ex = new ExcelAccess();
           SaveFileDialog saveFileDialog1 = new SaveFileDialog();
           string fname = Application.StartupPath + "\\00记录模板\\pdca周循环一览表.xls";
           ex.Open(fname);
           int row = 1;
           int col = 1;
           //加页
           int pageindex = 1;
           if (pageindex < Ecommonjh.GetPagecount(nrList.Count, 7)) {
               pageindex = Ecommonjh.GetPagecount(nrList.Count, 7);
           }
           for (int j = 1; j <= pageindex; j++) {
               ex.ActiveSheet(j);//xjq change 2013-03-01;
               if (j > 1) {
                   ex.CopySheet(1, 1);
               }
               string strWeek = "";//xjq change 2013-03-01;
               string strYearMonth = "";
               int pos = year.标题.IndexOf("第");
               if (pos >= 0)
               {
                   strWeek = year.标题.Substring(pos, 3);
                   strYearMonth = year.标题.Substring(0, pos);
               }

               // ex.SetCellValue(year.标题.Replace("计划", "PDCA循环一览表"), row, col);
               ex.SetCellValue(strYearMonth, row, 1);
               ex.SetCellValue("(" + strWeek + ")", row, 6);
               ex.SetCellValue("PDCA循环一览表", row, 7);

               ex.SetCellValue(year.单位代码, row + 2, col); ;
               ex.SetCellValue(year.开始日期.ToString("yyyy-MM-dd"), 3, 10);
               ex.SetCellValue(year.结束日期.ToString("yyyy-MM-dd"), 3, 12);
           }
           //ex.ActiveSheet(1);
           //string strWeek = "";
           //string strYearMonth = "";
           //int pos = year.标题.IndexOf("第");
           //if (pos >= 0) {
           //    strWeek = year.标题.Substring(pos, 3);
           //    strYearMonth = year.标题.Substring(0, pos);
           //}

           //// ex.SetCellValue(year.标题.Replace("计划", "PDCA循环一览表"), row, col);
           //ex.SetCellValue(strYearMonth, row, 1);
           //ex.SetCellValue("(" + strWeek + ")", row, 6);
           //ex.SetCellValue("PDCA循环一览表", row, 7);

           //ex.SetCellValue(year.单位代码, row + 2, col); ;
           //ex.SetCellValue(year.开始日期.ToString("yyyy-MM-dd"), 3, 10);
           //ex.SetCellValue(year.结束日期.ToString("yyyy-MM-dd"), 3, 12);
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
                       ex.SetCellValue(nrList[starow - 1 + i].完成标记, row + 5 + i, 8);
                       ex.SetCellValue(nrList[starow - 1 + i].未完成原因, row + 5 + i, 9);
                       if (nrList[starow - 1 + i].完成时间.Year != 1900)
                           ex.SetCellValue(nrList[starow - 1 + i].完成时间.ToString("yyyy-MM-dd"), row + 5 + i, 10);
                       ex.SetCellValue(nrList[starow - 1 + i].总结提升, row + 5 + i, 11);


                   }
               } else if (nrList.Count <= endrow && nrList.Count >= starow) {
                   for (int i = 0; i < nrList.Count - starow + 1; i++) {
                       ex.SetCellValue(nrList[starow - 1 + i].计划项目, row + 5 + i, 2);
                       ex.SetCellValue(nrList[starow - 1 + i].预计时间.ToString("yyyy-MM-dd"), row + 5 + i, 3);
                       ex.SetCellValue(nrList[starow - 1 + i].主要负责人, row + 5 + i, 4);
                       ex.SetCellValue(nrList[starow - 1 + i].参加人员, row + 5 + i, 5);
                       ex.SetCellValue(nrList[starow - 1 + i].实施内容, row + 5 + i, 6);
                       ex.SetCellValue(nrList[starow - 1 + i].完成标记, row + 5 + i, 8);
                       ex.SetCellValue(nrList[starow - 1 + i].未完成原因, row + 5 + i, 9);
                       if (nrList[starow - 1 + i].完成时间.Year != 1900)
                           ex.SetCellValue(nrList[starow - 1 + i].完成时间.ToString("yyyy-MM-dd"), row + 5 + i, 10);
                       ex.SetCellValue(nrList[starow - 1 + i].总结提升, row + 5 + i, 11);

                   }
               }

           }
           ex.ActiveSheet(1);
           ex.ShowExcel();
       }
       //xi
       public static void ExportExcelWeekMan(JH_weekmant year, IList<JH_weekman> nrList) {

           ExcelAccess ex = new ExcelAccess();
           SaveFileDialog saveFileDialog1 = new SaveFileDialog();
           string fname = Application.StartupPath + "\\00记录模板\\员工工作写实.xls";
           ex.Open(fname);
           int row = 1;
           int col = 1;
           int pageRowNum = 7;
           //加页
           int pageindex = 1;
           if (pageindex < Ecommonjh.GetPagecount(nrList.Count, pageRowNum)) {
               pageindex = Ecommonjh.GetPagecount(nrList.Count, pageRowNum);
           }
           for (int j = 1; j <= pageindex; j++) {
               ex.ActiveSheet(j);//xjq change 2013-03-01;
               if (j > 1) {
                   ex.CopySheet(1, 1);
               }
               string strWeek = "";//xjq change 2013-03-01;
               string strYearMonth = "";
               int pos = year.标题.IndexOf("第");
               if (pos >= 0)
               {
                   strWeek = year.标题.Substring(pos, 3);
                   strYearMonth = year.标题.Substring(0, pos);
               }

               ex.SetCellValue(year.标题.Replace("第", " （第 ").Replace("周", " 周）").Replace("计划", ""), 3, 2);
               ex.SetCellValue(year.姓名, 4, 2);
               ex.SetCellValue(year.职务, 4, 5);
               ex.SetCellValue(year.考核结果, 4, 8);
               string sdate = string.Format("{0} － {1}", year.开始日期.ToString("yyyy年MM月dd日"), year.结束日期.ToString("yyyy年MM月dd日"));

               ex.SetCellValue(sdate, 4, 9); ;
           }
           //ex.ActiveSheet(1);
           //string strWeek = "";
           //string strYearMonth = "";
           //int pos = year.标题.IndexOf("第");
           //if (pos >= 0) {
           //    strWeek = year.标题.Substring(pos, 3);
           //    strYearMonth = year.标题.Substring(0, pos);
           //}

           //ex.SetCellValue(year.标题.Replace("第"," （第 ").Replace("周"," 周）").Replace("计划",""), 3, 2);
           //ex.SetCellValue(year.姓名, 4, 2);
           //ex.SetCellValue(year.职务, 4, 5);
           //ex.SetCellValue(year.考核结果, 4, 8);
           //string sdate = string.Format("{0} － {1}", year.开始日期.ToString("yyyy年MM月dd日"), year.结束日期.ToString("yyyy年MM月dd日"));

           //ex.SetCellValue(sdate, 4, 9); ;
           //ex.SetCellValue(year.开始日期.ToString("yyyy-MM-dd"), 3, 10);
           //ex.SetCellValue(year.结束日期.ToString("yyyy-MM-dd"), 3, 12);
           row += 6;
           for (int j = 1; j <= pageindex; j++) {
               ex.ActiveSheet(j);
               //ex.ReNameWorkSheet(j, "Sheet" + (j));
               int prepageindex = j - 1;
               //主题
               int starow = prepageindex * pageRowNum + 1;
               int endrow = j * pageRowNum;

               if (nrList.Count > endrow) {
                   for (int i = 0; i < pageRowNum; i++) {
                       ex.SetCellValue(nrList[starow - 1 + i].计划项目, row  + i, 3);
                       ex.SetCellValue(nrList[starow - 1 + i].预计时间.ToString("yyyy-MM-dd"), row  + i, 5);
                       ex.SetCellValue(nrList[starow - 1 + i].协作人员, row  + i, 6);
                       ex.SetCellValue(nrList[starow - 1 + i].工作内容, row  + i, 7);
                       ex.SetCellValue(nrList[starow - 1 + i].完成标记, row  + i, 8);
                       ex.SetCellValue(nrList[starow - 1 + i].未完成原因, row + i, 9);
                       if (nrList[starow - 1 + i].完成时间.Year != 1900)
                           ex.SetCellValue(nrList[starow - 1 + i].完成时间.ToString("yyyy-MM-dd"), row + i, 10);
                       ex.SetCellValue(nrList[starow - 1 + i].总结提升, row +  i, 12);
                       ex.SetCellValue(nrList[starow - 1 + i].评语考核人, row  + i, 11);


                   }
               } else if (nrList.Count <= endrow && nrList.Count >= starow) {
                   for (int i = 0; i < nrList.Count - starow + 1; i++) {
                       ex.SetCellValue(nrList[starow - 1 + i].计划项目, row  + i, 3);
                       ex.SetCellValue(nrList[starow - 1 + i].预计时间.ToString("yyyy-MM-dd"), row  + i, 5);
                       ex.SetCellValue(nrList[starow - 1 + i].协作人员, row  + i, 6);
                       ex.SetCellValue(nrList[starow - 1 + i].工作内容, row  + i, 7);
                       ex.SetCellValue(nrList[starow - 1 + i].评语考核人, row  + i, 11);
                       ex.SetCellValue(nrList[starow - 1 + i].完成标记, row  + i, 8);
                       ex.SetCellValue(nrList[starow - 1 + i].未完成原因, row  + i, 9);
                       if (nrList[starow - 1 + i].完成时间.Year != 1900)
                           ex.SetCellValue(nrList[starow - 1 + i].完成时间.ToString("yyyy-MM-dd"), row  + i, 10);
                       ex.SetCellValue(nrList[starow - 1 + i].总结提升, row  + i, 12);

                   }
               }

           }
           DateTime dt2 = year.结束日期.AddDays(1);
           JH_weekmant year2 = ClientHelper.PlatformSqlMap.GetOne<JH_weekmant>(string.Format(" where 姓名='{0}' and 开始日期='{1}' and 单位代码='{2}' ", year.姓名, year.结束日期.AddDays(1), year.单位代码));
           if (year2 != null) {
               IList<JH_weekman> nrList2 = ClientHelper.PlatformSqlMap.GetList<JH_weekman>(string.Format("where parentid='{0}'", year2.ID));
               row += 6;
               for (int j = 1; j <= pageindex; j++) {
                   ex.ActiveSheet(j);
                   //ex.ReNameWorkSheet(j, "Sheet" + (j));
                   int prepageindex = j - 1;
                   //主题
                   int starow = prepageindex * pageRowNum + 1;
                   int endrow = j * pageRowNum;

                   if (nrList2.Count > endrow) {
                       for (int i = 0; i < pageRowNum; i++) {
                           ex.SetCellValue(nrList2[starow - 1 + i].计划项目, row + i, 3);
                           ex.SetCellValue(nrList2[starow - 1 + i].预计时间.ToString("yyyy-MM-dd"), row + i, 5);
                           ex.SetCellValue(nrList2[starow - 1 + i].协作人员, row + i, 6);
                           ex.SetCellValue(nrList2[starow - 1 + i].工作内容, row + i, 7);
                           //ex.SetCellValue(nrList2[starow - 1 + i].完成标记, row + i, 8);
                           //ex.SetCellValue(nrList2[starow - 1 + i].未完成原因, row + i, 9);
                           //if (nrList[starow - 1 + i].完成时间.Year != 1900)
                           //    ex.SetCellValue(nrList2[starow - 1 + i].完成时间.ToString("yyyy-MM-dd"), row + i, 10);
                           //ex.SetCellValue(nrList2[starow - 1 + i].总结提升, row + i, 12);
                           //ex.SetCellValue(nrList2[starow - 1 + i].评语考核人, row + i, 11);


                       }
                   } else if (nrList2.Count <= endrow && nrList2.Count >= starow) {
                       for (int i = 0; i < nrList.Count - starow + 1; i++) {
                           ex.SetCellValue(nrList2[starow - 1 + i].计划项目, row + i, 3);
                           ex.SetCellValue(nrList2[starow - 1 + i].预计时间.ToString("yyyy-MM-dd"), row + i, 5);
                           ex.SetCellValue(nrList2[starow - 1 + i].协作人员, row + i, 6);
                           ex.SetCellValue(nrList2[starow - 1 + i].工作内容, row + i, 7);
                           //ex.SetCellValue(nrList2[starow - 1 + i].评语考核人, row + i, 11);
                           //ex.SetCellValue(nrList2[starow - 1 + i].完成标记, row + i, 8);
                           //ex.SetCellValue(nrList2[starow - 1 + i].未完成原因, row + i, 9);
                           //if (nrList[starow - 1 + i].完成时间.Year != 1900)
                           //    ex.SetCellValue(nrList2[starow - 1 + i].完成时间.ToString("yyyy-MM-dd"), row + i, 10);
                           //ex.SetCellValue(nrList2[starow - 1 + i].总结提升, row + i, 12);

                       }
                   }

               }
           }
           ex.ActiveSheet(1);
           ex.ShowExcel();
       }


       /// <summary>
       /// 员工周工作写实
       /// </summary>
       /// <param name="year"></param>
       /// <param name="nrList"></param>
       public static void ExportExcelWeekMan1(JH_weekmant year, IList<JH_weekman> nrList)
       {

           ExcelAccess ex = new ExcelAccess();
           SaveFileDialog saveFileDialog1 = new SaveFileDialog();
           string fname = Application.StartupPath + "\\00记录模板\\员工周工作写实.xls";
           ex.Open(fname);
          
           //加页

           ex.ActiveSheet(1);
           string Title = year.标题.Substring(0, 11) + "员工工作写实";
           ex.SetCellValue(Title, 2, 2);
           ex.SetCellValue(year.姓名, 3, 2);
           ex.SetCellValue(year.考核结果, 3, 9);
           int count = 7;
           if (nrList.Count < 7)
               count = nrList.Count;
           for (int i = 0; i < count; i++)
           {
               ex.SetCellValue(nrList[i].单位名称, 5 + i, 1);
               ex.SetCellValue(nrList[i].计划项目, 5 + i, 2);
               ex.SetCellValue(nrList[i].工作内容, 5 + i, 3);
               ex.SetCellValue(nrList[i].协作人员, 5 + i, 4);
               ex.SetCellValue(nrList[i].完成标记, 5 + i, 5);
               if (nrList[i].完成时间.Year > Convert.ToDateTime("2000-10-10").Year)
                   ex.SetCellValue(nrList[i].完成时间.ToShortDateString(), 5 + i, 6);
               ex.SetCellValue(nrList[i].未完成原因, 5 + i, 7);
               ex.SetCellValue(nrList[i].总结提升, 5 + i, 8);

           }
           ex.SetCellValue(year.考核人, 12, 9);
           ex.ActiveSheet(1);
           ex.ShowExcel();
       }
   }
}
