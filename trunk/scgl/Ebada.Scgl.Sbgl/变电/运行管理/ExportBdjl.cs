using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using System.Windows.Forms;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Sbgl
{
    public class ExportBdjl
    {
        /// <summary>
        /// 调度操作指令记录簿
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="nrList">导出列表</param>
        public static void ExportExcelDdczzl(string title, IList<bdjl_ddzczl> nrList)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\调度操作指令记录簿.xls";
            ex.Open(fname);
            int row = 1;
            //加页
            int pageindex = 1;
            if (pageindex < Ecommonjh.GetPagecount(nrList.Count, 18))
            {
                pageindex = Ecommonjh.GetPagecount(nrList.Count, 18);
            }
            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(1);
                if (j > 1)
                {
                    ex.CopySheet(1, 1);
                }
                if (!string.IsNullOrEmpty(title))
                    ex.SetCellValue(title, 3, 1);
            }
            
            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(j);
                //ex.ReNameWorkSheet(j, "Sheet" + (j));
                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * 18 + 1;
                int endrow = j * 18;

                if (nrList.Count > endrow)
                {
                    for (int i = 0; i < 18; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].lb, row + 5 + i, 1);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].kssj).Month.ToString(), row + 5 + i, 2);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].kssj).Day.ToString(), row + 5 + i, 3);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].kssj).Hour.ToString(), row + 5 + i, 4);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].kssj).Minute.ToString(), row + 5 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].dd, row + 5 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].bds, row + 5 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].zlbh, row + 5 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].nr, row + 5 + i, 9);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].zzsj).Hour.ToString(), row + 5 + i, 10);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].zzsj).Minute.ToString(), row + 5 + i, 11);
                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].lb, row + 5 + i, 1);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].kssj).Month.ToString(), row + 5 + i, 2);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].kssj).Day.ToString(), row + 5 + i, 3);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].kssj).Hour.ToString(), row + 5 + i, 4);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].kssj).Minute.ToString(), row + 5 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].dd, row + 5 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].bds, row + 5 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].zlbh, row + 5 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].nr, row + 5 + i, 9);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].zzsj).Hour.ToString(), row + 5 + i, 10);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].zzsj).Minute.ToString(), row + 5 + i, 11);
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();

        }

        /// <summary>
        /// 设备缺陷记录簿
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="nrList">导出列表</param>
        public static void ExportExcelSbqxjl(string title, IList<bdjl_sbqxjl> nrList)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\设备缺陷记录簿.xls";
            ex.Open(fname);
            int row = 1;
            //加页
            int pageindex = 1;
            if (pageindex < Ecommonjh.GetPagecount(nrList.Count, 16))
            {
                pageindex = Ecommonjh.GetPagecount(nrList.Count, 16);
            }
            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(1);
                if (j > 1)
                {
                    ex.CopySheet(1, 1);
                }
                if (!string.IsNullOrEmpty(title))
                    ex.SetCellValue(title, 2, 2);
            }

            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(j);
                //ex.ReNameWorkSheet(j, "Sheet" + (j));
                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * 16 + 1;
                int endrow = j * 16;

                if (nrList.Count > endrow)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].fxrq.Year.ToString(), row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].fxrq.Month.ToString(), row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].fxrq.Day.ToString(), row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].fxr, row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].qxnr, row + 4 + i, 5);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].c1).Year.ToString(), row + 4 + i, 6);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].c1).Month.ToString(), row + 4 + i, 7);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].c1).Day.ToString(), row + 4 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].c2, row + 4 + i, 9);
                        ex.SetCellValue(nrList[starow - 1 + i].c3, row + 4 + i, 10);

                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].fxrq.Year.ToString(), row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].fxrq.Month.ToString(), row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].fxrq.Day.ToString(), row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].fxr, row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].qxnr, row + 4 + i, 5);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].c1).Year.ToString(), row + 4 + i, 6);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].c1).Month.ToString(), row + 4 + i, 7);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].c1).Day.ToString(), row + 4 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].c2, row + 4 + i, 9);
                        ex.SetCellValue(nrList[starow - 1 + i].c3, row + 4 + i, 10);
                       
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();

        }
        /// <summary>
        /// 开关跳闸记录簿
        /// </summary>
        /// <param name="nrList"></param>
        public static void ExportExcelKgtzjl(IList<bdjl_kgtzjl> nrList)
        {
            #region 开关跳闸记录
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\断路器故障跳闸记录簿.xls";
            ex.Open(fname);
            int row = 1;
            //加页
            int pageindex = 1;
            if (pageindex < Ecommonjh.GetPagecount(nrList.Count, 16))
            {
                pageindex = Ecommonjh.GetPagecount(nrList.Count, 16);
            }
            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(1);
                if (j > 1)
                {
                    ex.CopySheet(1, 1);
                }
                ex.SetCellValue(nrList[0].kgmc, 2, 4);
                ex.SetCellValue(nrList[0].dlqyxgztzcs.ToString(), 2, 10);

            }

            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(j);
                //ex.ReNameWorkSheet(j, "Sheet" + (j));
                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * 16 + 1;
                int endrow = j * 16;

                if (nrList.Count > endrow)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].c1).Year.ToString(), row + 4 + i, 1);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].c1).Month.ToString(), row + 4 + i, 2);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].c1).Day.ToString(), row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].tzrq.Year.ToString(), row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].tzrq.Month.ToString(), row + 4 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].tzrq.Day.ToString(), row + 4 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].sdfzcs.ToString(), row + 4 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].sgtzcs.ToString(), row + 4 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].bhzhzzdqk, row + 4 + i, 9);
                        ex.SetCellValue(nrList[starow - 1 + i].jlr, row + 4 + i, 10);
                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {

                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].c1).Year.ToString(), row + 4 + i, 1);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].c1).Month.ToString(), row + 4 + i, 2);
                        ex.SetCellValue(Convert.ToDateTime(nrList[starow - 1 + i].c1).Day.ToString(), row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].tzrq.Year.ToString(), row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].tzrq.Month.ToString(), row + 4 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].tzrq.Day.ToString(), row + 4 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].sdfzcs.ToString(), row + 4 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].sgtzcs.ToString(), row + 4 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].bhzhzzdqk, row + 4 + i, 9);
                        ex.SetCellValue(nrList[starow - 1 + i].jlr, row + 4 + i, 10);

                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
            #endregion
            
        }

        /// <summary>
        /// 继电保护记录
        /// </summary>
        /// <param name="nrList">导出列表</param>
        public static void ExprotExcelJdbhjl(IList<bdjl_jdbhjl> nrList)
        {
            #region 继电保护记录
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\继电保护及自动装置调试工作记录簿.xls";
            ex.Open(fname);
            int row = 1;
            //加页
            int pageindex = 1;
            if (pageindex < Ecommonjh.GetPagecount(nrList.Count, 17))
            {
                pageindex = Ecommonjh.GetPagecount(nrList.Count, 17);
            }
            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(1);
                if (j > 1)
                {
                    ex.CopySheet(1, 1);
                }
                ex.SetCellValue(nrList[0].sbmc, 2, 4);

            }

            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(j);
                //ex.ReNameWorkSheet(j, "Sheet" + (j));
                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * 17 + 1;
                int endrow = j * 17;

                if (nrList.Count > endrow)
                {
                    for (int i = 0; i < 17; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].rq.Year.ToString(), row + 3 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].rq.Month.ToString(), row + 3 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].rq.Day.ToString(), row + 3 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].tsnrjjl, row + 3 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].jdfzr, row + 3 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].zbrjsz, row + 3 + i, 6);
                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].rq.Year.ToString(), row + 3 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].rq.Month.ToString(), row + 3 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].rq.Day.ToString(), row + 3 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].tsnrjjl, row + 3 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].jdfzr, row + 3 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].zbrjsz, row + 3 + i, 6);
                       
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
            #endregion
        }

        /// <summary>
        /// 设备检修记录簿
        /// </summary>
        /// <param name="nrList"></param>
        public static void ExportExcelSbjxjl(IList<bdjl_sbjxjl> nrList)
        {
            #region 设备检修记录簿
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\设备检修、试验记录簿.xls";
            ex.Open(fname);
            int row = 1;
            //加页
            int pageindex = 1;
            if (pageindex < Ecommonjh.GetPagecount(nrList.Count, 17))
            {
                pageindex = Ecommonjh.GetPagecount(nrList.Count, 17);
            }
            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(1);
                if (j > 1)
                {
                    ex.CopySheet(1, 1);
                }
                ex.SetCellValue(nrList[0].sbmc, 2, 4);

            }

            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(j);
                //ex.ReNameWorkSheet(j, "Sheet" + (j));
                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * 17 + 1;
                int endrow = j * 17;

                if (nrList.Count > endrow)
                {
                    for (int i = 0; i < 17; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].jxrq.Year.ToString(), row + 3 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].jxrq.Month.ToString(), row + 3 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].jxrq.Day.ToString(), row + 3 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].jxxm + "|" + nrList[starow - 1 + i].ysyj, row + 3 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].jxfzr, row + 3 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].ysr, row + 3 + i, 6);
                        //ex.SetCellValue(nrList[starow - 1 + i].zbrjsz, row + 3 + i, 6);
                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].jxrq.Year.ToString(), row + 3 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].jxrq.Month.ToString(), row + 3 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].jxrq.Day.ToString(), row + 3 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].jxxm + "|" + nrList[starow - 1 + i].ysyj, row + 3 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].jxfzr, row + 3 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].ysr, row + 3 + i, 6);
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
            #endregion
        }

    }
}
