using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
using System.Data;
//using Ebada.Scgl.Core;

namespace Ebada.jhgl
{
   public class ExportPDCA
    {

       public static void ExportOutInDetail(DataTable dt)
       {
           if (dt.Rows.Count < 1)
               return;
           int inCount = 0;
           decimal inMoney = 0;
           int outCount = 0;
           decimal outMoney = 0;
           //结存数量
           int allCount = 0;
           //结存金额
           decimal allMoney = 0;
           string 单位 = dt.Rows[0]["工程类别"].ToString();
           string 品名 = dt.Rows[0]["材料名称"].ToString();
           string 规格 = dt.Rows[0]["规格及型号"].ToString();
           string year = Convert.ToDateTime(dt.Rows[0]["日期"]).Year.ToString();
           ExcelAccess ex = new ExcelAccess();
           SaveFileDialog saveFileDialog1 = new SaveFileDialog();
           string fname = Application.StartupPath + "\\00记录模板\\财务-材料明细分类账.xls";
           ex.Open(fname);
           int row = 7;
           int col = 1;
           //加页
           int pageindex = 1;
           if (pageindex < Ecommonjh.GetPagecount(dt.Rows.Count, 28))
           {
               pageindex = Ecommonjh.GetPagecount(dt.Rows.Count, 28);
           }
           for (int j = 1; j <= pageindex; j++)
           {
               ex.ActiveSheet(1);
               if (j > 1)
               {
                   ex.CopySheet(1, 1);
               }
               ex.SetCellValue(string.Format("第{0}页",j), 1, 3);
               ex.SetCellValue(单位, 2, 3);
               ex.SetCellValue(品名, 3, 3);
               ex.SetCellValue(规格, 4, 3);
               ex.SetCellValue(year,5, 1);
           }
           for (int j = 1; j <= pageindex; j++)
           {
               ex.ActiveSheet(j);
               //ex.ReNameWorkSheet(j, "Sheet" + (j));
               int prepageindex = j - 1;
               //主题
               int starow = prepageindex * 28 + 1;
               int endrow = j * 28;

               if (dt.Rows.Count > endrow)
               {
                   for (int i = 0; i < 28; i++)
                   {
                       ex.SetCellValue(Convert.ToDateTime(dt.Rows[starow - 1 + i]["日期"]).Month.ToString(), row + i, 1);
                       ex.SetCellValue(Convert.ToDateTime(dt.Rows[starow - 1 + i]["日期"]).Day.ToString(), row + i, 2);
                       ex.SetCellValue(dt.Rows[starow - 1 + i]["类型"].ToString(), row + i, 3);
                       if (dt.Rows[starow - 1 + i]["类型"].ToString().Trim() == "入库")
                       {
                           ex.SetCellValue(dt.Rows[starow - 1 + i]["数量"].ToString(), row + i, 4);
                           ex.SetCellValue(dt.Rows[starow - 1 + i]["单价"].ToString(), row + i, 5);
                           decimal numin = Math.Round(Convert.ToDecimal(dt.Rows[starow - 1 + i]["合计"]), 2);
                           int numLength = numin.ToString().Length;

                           int startNumin = 5 + 10 - numLength;

                           if (numin.ToString().IndexOf(".") < 0)
                           {
                               startNumin = startNumin - 2;
                               for (int k = 1; k <= numLength; k++)
                               {
                                   string numstr = numin.ToString()[k - 1].ToString();
                                   ex.SetCellValue(numstr, row + i, startNumin + k);
                               }
                               ex.SetCellValue("0", row + i, startNumin + numLength + 1);
                               ex.SetCellValue("0", row + i, startNumin + numLength + 2);
                           }
                           else
                           {
                               int spotposition = numin.ToString().IndexOf(".");
                               for (int k = 1; k <= numLength; k++)
                               {
                                   string numstr = numin.ToString()[k - 1].ToString();
                                   if (k != spotposition)
                                   {
                                       ex.SetCellValue(numstr, row + i, startNumin + k);
                                   }

                               }
                           }



                           allCount = allCount + Convert.ToInt32(dt.Rows[starow - 1 + i]["数量"]);
                           inCount = inCount + Convert.ToInt32(dt.Rows[starow - 1 + i]["数量"]);
                           ex.SetCellValue(allCount.ToString(), row - 1 + i, 28);
                           ex.SetCellValue(dt.Rows[starow - 1 + i]["单价"].ToString(), row + i, 29);
                           allMoney = allMoney + Math.Round(Convert.ToDecimal(dt.Rows[starow - 1 + i]["合计"]), 2);
                           inMoney = inMoney + Math.Round(Convert.ToDecimal(dt.Rows[starow - 1 + i]["合计"]), 2);
                           int startNumAll = 29 + 10 - allMoney.ToString().Length;

                           if (allMoney.ToString().IndexOf(".") < 0)
                           {
                               startNumAll = startNumAll - 2;
                               for (int m = 1; m <= allMoney.ToString().Length; m++)
                               {
                                   string numstr = allMoney.ToString()[m - 1].ToString();
                                   ex.SetCellValue(numstr, row + i, startNumAll + m);
                               }
                               ex.SetCellValue("0", row + i, startNumAll + allMoney.ToString().Length+1);
                               ex.SetCellValue("0", row + i, startNumAll + allMoney.ToString().Length + 2);
                           }
                           else
                           {
                               int spotposition = allMoney.ToString().IndexOf(".");
                               for (int m = 1; m <= numLength; m++)
                               {
                                   string numstr = allMoney.ToString()[m - 1].ToString();
                                   if (m != spotposition)
                                   {
                                       ex.SetCellValue(numstr, row + i, startNumAll + m);
                                   }

                               }
                           }

                           //for (int m = 1; m <= allMoney.ToString().Length; m++)
                           //{
                           //    string numstr = allMoney.ToString()[m-1].ToString();
                           //    ex.SetCellValue(numstr, row + i, startNumAll + m);
                           //}
                       }
                       else
                       {
                           ex.SetCellValue(dt.Rows[starow - 1 + i]["数量"].ToString(), row + i, 16);
                           ex.SetCellValue(dt.Rows[starow - 1 + i]["单价"].ToString(), row + i, 17);
                           decimal numout = Math.Round(Convert.ToDecimal(dt.Rows[starow - 1 + i]["合计"]), 2);
                           int numLength = numout.ToString().Length;
                           int startNumin = 17 + 10 - numLength;
                           if (numout.ToString().IndexOf(".") < 0)
                           {
                               startNumin = startNumin - 2;
                               for (int k = 1; k <= numLength; k++)
                               {
                                   string numstr = numout.ToString()[k - 1].ToString();
                                   ex.SetCellValue(numstr, row + i, startNumin + k);
                               }
                               ex.SetCellValue("0", row + i, startNumin + numLength + 1);
                               ex.SetCellValue("0", row + i, startNumin + numLength + 2);
                           }
                           else
                           {
                               int spotposition = numout.ToString().IndexOf(".");
                               for (int k = 1; k <= numLength; k++)
                               {
                                   string numstr = numout.ToString()[k - 1].ToString();
                                   if (k != spotposition)
                                   {
                                       ex.SetCellValue(numstr, row + i, startNumin + k);
                                   }

                               }
                           }
                           allCount = allCount - Convert.ToInt32(dt.Rows[starow - 1 + i]["数量"]);
                           outCount = outCount + Convert.ToInt32(dt.Rows[starow - 1 + i]["数量"]);
                           ex.SetCellValue(allCount.ToString(), row - 1 + i, 28);
                           ex.SetCellValue(dt.Rows[starow - 1 + i]["单价"].ToString(), row + i, 29);
                           allMoney = allMoney - Math.Round(Convert.ToDecimal(dt.Rows[starow - 1 + i]["合计"]), 2);
                           outMoney = outMoney + Math.Round(Convert.ToDecimal(dt.Rows[starow - 1 + i]["合计"]), 2);
                           int startNumAll = 29 + 10 - allMoney.ToString().Length;
                           if (allCount.ToString().IndexOf(".") < 0)
                           {
                               startNumAll = startNumAll - 2;
                               for (int m = 1; m <= allMoney.ToString().Length; m++)
                               {
                                   string numstr = allMoney.ToString()[m - 1].ToString();
                                   ex.SetCellValue(numstr, row + i, startNumAll + m);
                               }
                               ex.SetCellValue("0", row + i, startNumAll + allMoney.ToString().Length + 1);
                               ex.SetCellValue("0", row + i, startNumAll + allMoney.ToString().Length + 2);
                           }
                           else
                           {
                               int spotposition = allMoney.ToString().IndexOf(".");
                               for (int m = 1; m <= numLength; m++)
                               {
                                   string numstr = allMoney.ToString()[m - 1].ToString();
                                   if (m != spotposition)
                                   {
                                       ex.SetCellValue(numstr, row + i, startNumAll + m);
                                   }

                               }
                           }

                       }
                   }
               }
               else if (dt.Rows.Count <= endrow && dt.Rows.Count >= starow)
               {
                   for (int i = 0; i < dt.Rows.Count - starow + 1; i++)
                   {
                       ex.SetCellValue(Convert.ToDateTime(dt.Rows[starow - 1 + i]["日期"]).Month.ToString(), row + i, 1);
                       ex.SetCellValue(Convert.ToDateTime(dt.Rows[starow - 1 + i]["日期"]).Day.ToString(), row + i, 2);
                       ex.SetCellValue(dt.Rows[starow - 1 + i]["类型"].ToString(), row + i, 3);
                       if (dt.Rows[starow - 1 + i]["类型"].ToString().Trim() == "入库")
                       {
                           ex.SetCellValue(dt.Rows[starow - 1 + i]["数量"].ToString(), row + i, 4);
                           ex.SetCellValue(dt.Rows[starow - 1 + i]["单价"].ToString(), row + i, 5);
                           decimal numin = Math.Round(Convert.ToDecimal(dt.Rows[starow - 1 + i]["合计"]), 2);
                           int numLength = numin.ToString().Length;

                           int startNumin = 5 + 10 - numLength;

                           if (numin.ToString().IndexOf(".") < 0)
                           {
                               startNumin = startNumin - 2;
                               for (int k = 1; k <= numLength; k++)
                               {
                                   string numstr = numin.ToString()[k - 1].ToString();
                                   ex.SetCellValue(numstr, row + i, startNumin + k);
                               }
                               ex.SetCellValue("0", row + i, startNumin + numLength + 1);
                               ex.SetCellValue("0", row + i, startNumin + numLength + 2);
                           }
                           else
                           {
                               int spotposition = numin.ToString().IndexOf(".");
                               for (int k = 1; k <= numLength; k++)
                               {
                                   string numstr = numin.ToString()[k - 1].ToString();
                                   if (k != spotposition)
                                   {
                                       ex.SetCellValue(numstr, row + i, startNumin + k);
                                   }

                               }
                           }



                           allCount = allCount + Convert.ToInt32(dt.Rows[starow - 1 + i]["数量"]);
                           inCount = inCount + Convert.ToInt32(dt.Rows[starow - 1 + i]["数量"]);
                           ex.SetCellValue(allCount.ToString(), row + i, 28);
                           ex.SetCellValue(dt.Rows[starow - 1 + i]["单价"].ToString(), row + i, 29);
                           allMoney = allMoney + Math.Round(Convert.ToDecimal(dt.Rows[starow - 1 + i]["合计"]), 2);
                           inMoney = inMoney + Math.Round(Convert.ToDecimal(dt.Rows[starow - 1 + i]["合计"]), 2);
                           int startNumAll = 29 + 10 - allMoney.ToString().Length;

                           if (allMoney.ToString().IndexOf(".") < 0)
                           {
                               startNumAll = startNumAll - 2;
                               for (int m = 1; m <= allMoney.ToString().Length; m++)
                               {
                                   string numstr = allMoney.ToString()[m - 1].ToString();
                                   ex.SetCellValue(numstr, row + i, startNumAll + m);
                               }
                               ex.SetCellValue("0", row + i, startNumAll + allMoney.ToString().Length + 1);
                               ex.SetCellValue("0", row + i, startNumAll + allMoney.ToString().Length + 2);
                           }
                           else
                           {
                               int spotposition = allMoney.ToString().IndexOf(".");
                               for (int m = 1; m <= numLength; m++)
                               {
                                   string numstr = allMoney.ToString()[m - 1].ToString();
                                   if (m != spotposition)
                                   {
                                       ex.SetCellValue(numstr, row + i, startNumAll + m);
                                   }

                               }
                           }

                           //for (int m = 1; m <= allMoney.ToString().Length; m++)
                           //{
                           //    string numstr = allMoney.ToString()[m-1].ToString();
                           //    ex.SetCellValue(numstr, row + i, startNumAll + m);
                           //}
                       }
                       else
                       {
                           ex.SetCellValue(dt.Rows[starow - 1 + i]["数量"].ToString(), row + i, 16);
                           ex.SetCellValue(dt.Rows[starow - 1 + i]["单价"].ToString(), row + i, 17);
                           decimal numout = Math.Round(Convert.ToDecimal(dt.Rows[starow - 1 + i]["合计"]), 2);
                           int numLength = numout.ToString().Length;
                           int startNumin = 17 + 10 - numLength;
                           if (numout.ToString().IndexOf(".") < 0)
                           {
                               startNumin = startNumin - 2;
                               for (int k = 1; k <= numLength; k++)
                               {
                                   string numstr = numout.ToString()[k - 1].ToString();
                                   ex.SetCellValue(numstr, row + i, startNumin + k);
                               }
                               ex.SetCellValue("0", row + i, startNumin + numLength + 1);
                               ex.SetCellValue("0", row + i, startNumin + numLength + 2);
                           }
                           else
                           {
                               int spotposition = numout.ToString().IndexOf(".");
                               for (int k = 1; k <= numLength; k++)
                               {
                                   string numstr = numout.ToString()[k - 1].ToString();
                                   if (k != spotposition)
                                   {
                                       ex.SetCellValue(numstr, row + i, startNumin + k);
                                   }

                               }
                           }
                           allCount = allCount - Convert.ToInt32(dt.Rows[starow - 1 + i]["数量"]);
                           outCount = outCount + Convert.ToInt32(dt.Rows[starow - 1 + i]["数量"]);
                           ex.SetCellValue(allCount.ToString(), row + i, 28);
                           ex.SetCellValue(dt.Rows[starow - 1 + i]["单价"].ToString(), row + i, 29);
                           allMoney = allMoney - Math.Round(Convert.ToDecimal(dt.Rows[starow - 1 + i]["合计"]), 2);
                           outMoney = outMoney + Math.Round(Convert.ToDecimal(dt.Rows[starow - 1 + i]["合计"]), 2);
                           int startNumAll = 29 + 10 - allMoney.ToString().Length;
                           if (allCount.ToString().IndexOf(".") < 0)
                           {
                               startNumAll = startNumAll - 2;
                               for (int m = 1; m <= allMoney.ToString().Length; m++)
                               {
                                   string numstr = allMoney.ToString()[m - 1].ToString();
                                   ex.SetCellValue(numstr, row + i, startNumAll + m);
                               }
                               ex.SetCellValue("0", row + i, startNumAll + allMoney.ToString().Length + 1);
                               ex.SetCellValue("0", row + i, startNumAll + allMoney.ToString().Length + 2);
                           }
                           else
                           {
                               int spotposition = allMoney.ToString().IndexOf(".");
                               for (int m = 1; m <= numLength; m++)
                               {
                                   string numstr = allMoney.ToString()[m - 1].ToString();
                                   if (m != spotposition)
                                   {
                                       ex.SetCellValue(numstr, row + i, startNumAll + m);
                                   }

                               }
                           }

                       }
                   }
               }
               //累计 入库
               int startin = 5 + 10 - inMoney.ToString().Length;
               ex.SetCellValue(inCount.ToString(), 35, 4);
               if (inMoney.ToString().IndexOf(".") < 0)
               {
                   startin = startin - 2;
                   for (int k = 1; k <= inMoney.ToString().Length; k++)
                   {
                       string numstr = inMoney.ToString()[k - 1].ToString();
                       ex.SetCellValue(numstr, 35, startin + k);
                   }
                   ex.SetCellValue("0", 35, startin + inMoney.ToString().Length + 1);
                   ex.SetCellValue("0", 35, startin + inMoney.ToString().Length + 2);
               }
               else
               {
                   int spotposition = inMoney.ToString().IndexOf(".");
                   for (int k = 1; k <=inMoney.ToString().Length; k++)
                   {
                       string numstr = inMoney.ToString()[k - 1].ToString();
                       if (k != spotposition)
                       {
                           ex.SetCellValue(numstr, 35, startin + k);
                       }

                   }
               }
               //累计出库
               int startout = 17 + 10 - outMoney.ToString().Length;
               ex.SetCellValue(outCount.ToString(), 35, 16);
               if (outMoney.ToString().IndexOf(".") < 0)
               {
                   startout = startout - 2;
                   for (int k = 1; k <= outMoney.ToString().Length; k++)
                   {
                       string numstr = outMoney.ToString()[k - 1].ToString();
                       ex.SetCellValue(numstr, 35, startout + k);
                   }
                   ex.SetCellValue("0", 35, startout + outMoney.ToString().Length + 1);
                   ex.SetCellValue("0", 35, startout + outMoney.ToString().Length + 2);
               }
               else
               {
                   int spotposition = outMoney.ToString().IndexOf(".");
                   for (int k = 1; k <= outMoney.ToString().Length; k++)
                   {
                       string numstr = outMoney.ToString()[k - 1].ToString();
                       if (k != spotposition)
                       {
                           ex.SetCellValue(numstr, 35, startout + k);
                       }

                   }
               }
               //累计合并
               int startinout = 29 + 10 - allMoney.ToString().Length;
               ex.SetCellValue(allCount.ToString(), 35, 28);
               if (allMoney.ToString().IndexOf(".") < 0)
               {
                   startinout = startinout - 2;
                   for (int k = 1; k <= allMoney.ToString().Length; k++)
                   {
                       string numstr = allMoney.ToString()[k - 1].ToString();
                       ex.SetCellValue(numstr, 35, startinout + k);
                   }
                   ex.SetCellValue("0", 35, startinout + allMoney.ToString().Length + 1);
                   ex.SetCellValue("0", 35, startinout + allMoney.ToString().Length + 2);
               }
               else
               {
                   int spotposition = allMoney.ToString().IndexOf(".");
                   for (int k = 1; k <= allMoney.ToString().Length; k++)
                   {
                       string numstr = allMoney.ToString()[k - 1].ToString();
                       if (k != spotposition)
                       {
                           ex.SetCellValue(numstr, 35, startinout + k);
                       }

                   }
               }

               
           }
           ex.ActiveSheet(1);
           ex.ShowExcel();
       }

       private static void SetInCountValue(int i,DataTable dt, ref int allCount, ref decimal allMoney, ExcelAccess ex, int row, int starow)
       {
          
              
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
       
   }
}
