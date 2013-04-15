﻿using System;
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
        
        /// <summary>
        /// 蓄电池调整及检测记录簿
        /// </summary>
        /// <param name="nrList">导出列表</param>
        public static void ExprotExcelXdcdzjlb(IList<bdjl_xdctzjlb> nrList)
        {
            #region 蓄电池调整及检测记录簿
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\蓄电池调整及检测记录簿.xls";
            ex.Open(fname);
            int row = 1;
            //加页
            int pageindex = 1;
            if (pageindex < Ecommonjh.GetPagecount(nrList.Count, 15))
            {
                pageindex = Ecommonjh.GetPagecount(nrList.Count, 15);
            }
            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(1);
                if (j > 1)
                {
                    ex.CopySheet(1, 1);
                }
                ex.SetCellValue(nrList[0].sj.Year+"年"+nrList[0].sj.Month+"月", 2, 1);

            }

            for (int j = 1; j <= pageindex; j++)
            {
                ex.ActiveSheet(j);
                //ex.ReNameWorkSheet(j, "Sheet" + (j));
                int prepageindex = j - 1;
                //主题
                int starow = prepageindex * 15 + 1;
                int endrow = j * 15;

                if (nrList.Count > endrow)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].sj.Day.ToString(), row + 5 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].sj.Hour.ToString(), row + 5 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].sj.Minute.ToString(), row + 5 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].dcdy, row + 5 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].dl, row + 5 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].trdcgs, row + 5 + i, 6);
                        string[] arr = nrList[starow - 1 + i].bzdcdy.Split('、');
                        for (int k = 0; k < arr.Length; k++)
                        {
                            ex.SetCellValue(arr[k], row + 5 + i, 6 + k + 1);
                        }
                        ex.SetCellValue(nrList[starow - 1 + i].jcr, row + 5 + i, 11);
                        //ex.SetCellValue(nrList[starow - 1 + i].zbrjsz, row + 3 + i, 6);
                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].sj.Day.ToString(), row + 5 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].sj.Hour.ToString(), row + 5 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].sj.Minute.ToString(), row + 5 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].dcdy, row + 5 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].dl, row + 5 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].trdcgs, row + 5 + i, 6);
                        string[] arr = nrList[starow - 1 + i].bzdcdy.Split('、');
                        for (int k = 0; k < arr.Length; k++)
                        {
                            ex.SetCellValue(arr[k], row + 5 + i, 6 + k + 1);
                        }
                        ex.SetCellValue(nrList[starow - 1 + i].jcr, row + 5 + i, 11);
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
            #endregion
        }

        /// <summary>
        /// 避雷器动作记录簿
        /// </summary>
        /// <param name="nrList">导出列表</param>
        public static void ExportExcelBlqdzjlb(IList<bdjl_blqdzjlcs> nrList)
        {
            #region 避雷器动作记录簿
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\避雷器动作记录簿.xls";
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
                
                //ex.SetCellValue(nrList[0].sj.Year + "年" + nrList[0].sj.Month + "月", 2, 1);

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
                        ex.SetCellValue(nrList[starow - 1 + i].dzrq.Year.ToString(), row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].dzrq.Month.ToString(), row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].dzrq.Day.ToString(), row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].dzrq.Hour.ToString(), row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].dzrq.Minute.ToString(), row + 4 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].Axjsqzss, row + 4 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].c1, row + 4 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].Bxjsqzss, row + 4 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].c2, row + 4 + i, 9);
                        ex.SetCellValue(nrList[starow - 1 + i].Cxjsqzss, row + 4 + i, 10);
                        ex.SetCellValue(nrList[starow - 1 + i].c3, row + 4 + i, 11);
                        ex.SetCellValue(nrList[starow - 1 + i].dzyy, row + 4 + i, 12);
                        ex.SetCellValue(nrList[starow - 1 + i].jlr, row + 4 + i, 13);
                        
                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].dzrq.Year.ToString(), row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].dzrq.Month.ToString(), row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].dzrq.Day.ToString(), row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].dzrq.Hour.ToString(), row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].dzrq.Minute.ToString(), row + 4 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].Axjsqzss, row + 4 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].c1, row + 4 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].Bxjsqzss, row + 4 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].c2, row + 4 + i, 9);
                        ex.SetCellValue(nrList[starow - 1 + i].Cxjsqzss, row + 4 + i, 10);
                        ex.SetCellValue(nrList[starow - 1 + i].c3, row + 4 + i, 11);
                        ex.SetCellValue(nrList[starow - 1 + i].dzyy, row + 4 + i, 12);
                        ex.SetCellValue(nrList[starow - 1 + i].jlr, row + 4 + i, 13);
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
            #endregion
        }

        /// <summary>
        /// 事故预想记录簿
        /// </summary>
        /// <param name="nrList">记录</param>
        public static void ExportExcelSgyxjlb(IList<bdjl_sgyxjlb> nrList)
        {
            #region 事故预想记录簿
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\事故预想记录簿.xls";
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
                    for (int i = 0; i < 1; i++)
                    {
                        ex.SetCellValue(Convert.ToDateTime(nrList[0].c1).Year + "年" + Convert.ToDateTime(nrList[0].c1).Month + "月"
                            + Convert.ToDateTime(nrList[0].c1).Day + "日", row+1+i, 2);
                        ex.SetCellValue(nrList[0].tq, row + 1 + i, 4);
                        ex.SetCellValue(nrList[0].cjry, row + 2 + i, 2);
                        ex.SetCellValue(nrList[0].dsyxfs, row + 3 + i, 2);
                        ex.SetCellValue(nrList[0].yxtm, row + 4 + i, 2);
                        ex.SetCellValue(nrList[0].sgxx, row + 5 + i, 2);
                        ex.SetCellValue(nrList[0].clbz, row + 6 + i, 2);
                        ex.SetCellValue(nrList[0].shyj, row + 7 + i, 2);
                        //ex.SetCellValue(nrList[starow - 1 + i].jlr, row + 4 + i, 13);

                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(Convert.ToDateTime(nrList[0].c1).Year + "年" + Convert.ToDateTime(nrList[0].c1).Month + "月"
                            + Convert.ToDateTime(nrList[0].c1).Day + "日", row + 1 + i, 2);
                        ex.SetCellValue(nrList[0].tq, row + 1 + i, 4);
                        ex.SetCellValue(nrList[0].cjry, row + 2 + i, 2);
                        ex.SetCellValue(nrList[0].dsyxfs, row + 3 + i, 2);
                        ex.SetCellValue(nrList[0].yxtm, row + 4 + i, 2);
                        ex.SetCellValue(nrList[0].sgxx, row + 5 + i, 2);
                        ex.SetCellValue(nrList[0].clbz, row + 6 + i, 2);
                        ex.SetCellValue(nrList[0].shyj, row + 7 + i, 2);
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
            #endregion
        }

        /// <summary>
        /// 反事故演习记录簿
        /// </summary>
        /// <param name="nrList">记录</param>
        public static void ExportExcelFsgyxjlb(IList<bdjl_fsgyxjlb> nrList)
        {
            #region 反事故演习记录簿
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\反事故演习记录簿.xls";
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
                    for (int i = 0; i < 1; i++)
                    {
                        ex.SetCellValue(Convert.ToDateTime(nrList[0].c1).Year + "年" +
                            Convert.ToDateTime(nrList[0].c1).Month + "月" +
                            Convert.ToDateTime(nrList[0].c1).Day + "日", row + 1 + i, 1);
                        ex.SetCellValue(nrList[0].yxdd, row + 2 + i, 2);
                        ex.SetCellValue(nrList[0].yxtm, row + 3 + i, 2);
                        ex.SetCellValue(Convert.ToDateTime(nrList[0].yxkssj).Hour.ToString(), row + 4 + i, 2);
                        ex.SetCellValue(Convert.ToDateTime(nrList[0].yxkssj).Minute.ToString(), row + 4 + i, 4);
                        ex.SetCellValue(Convert.ToDateTime(nrList[0].yxjssj).Hour.ToString(), row + 4 + i, 6);
                        ex.SetCellValue(Convert.ToDateTime(nrList[0].yxjssj).Minute.ToString(), row + 4 + i, 8);
                        ex.SetCellValue(nrList[0].cjry, row + 5 + i, 2);
                        ex.SetCellValue(nrList[0].cljg, row + 6 + i, 2);
                        ex.SetCellValue(nrList[0].wtjcs, row + 7 + i, 2);
                        ex.SetCellValue(nrList[0].jljpj, row + 8 + i, 2);
                        //ex.SetCellValue(nrList[starow - 1 + i].jlr, row + 4 + i, 13);

                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(Convert.ToDateTime(nrList[0].c1).Year + "年" +
                           Convert.ToDateTime(nrList[0].c1).Month + "月" +
                           Convert.ToDateTime(nrList[0].c1).Day + "日", row + 1 + i, 1);
                        ex.SetCellValue(nrList[0].yxdd, row + 2 + i, 2);
                        ex.SetCellValue(nrList[0].yxtm, row + 3 + i, 2);
                        ex.SetCellValue(Convert.ToDateTime(nrList[0].yxkssj).Hour.ToString(), row + 4 + i, 2);
                        ex.SetCellValue(Convert.ToDateTime(nrList[0].yxkssj).Minute.ToString(), row + 4 + i, 4);
                        ex.SetCellValue(Convert.ToDateTime(nrList[0].yxjssj).Hour.ToString(), row + 4 + i, 6);
                        ex.SetCellValue(Convert.ToDateTime(nrList[0].yxjssj).Minute.ToString(), row + 4 + i, 8);
                        ex.SetCellValue(nrList[0].cjry, row + 5 + i, 2);
                        ex.SetCellValue(nrList[0].cljg, row + 6 + i, 2);
                        ex.SetCellValue(nrList[0].wtjcs, row + 7 + i, 2);
                        ex.SetCellValue(nrList[0].jljpj, row + 8 + i, 2);
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
            #endregion
        }

        /// <summary>
        /// 安全活动记录簿
        /// </summary>
        /// <param name="nrList">记录</param>
        public static void ExportExcelAqhdjlb(IList<bdjl_aqhdjlb> nrList)
        {
            #region 安全活动记录簿
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\安全活动记录簿.xls";
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
                    for (int i = 0; i < 1; i++)
                    {
                        ex.SetCellValue(DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日", row + 1 + i, 1);
                        ex.SetCellValue(GetWeeks(DateTime.Now.DayOfWeek), row + 1 + i, 4);
                        ex.SetCellValue(nrList[0].zcr, row + 2 + i, 2);
                        ex.SetCellValue(Convert.ToDateTime(nrList[0].hdkssj).Year + "年" + Convert.ToDateTime(nrList[0].hdkssj).Month + "月"
                            + Convert.ToDateTime(nrList[0].hdkssj).Day + "日" + Convert.ToDateTime(nrList[0].hdkssj).Hour + "时"
                            + Convert.ToDateTime(nrList[0].hdkssj).Minute + "分", row + 2 + i, 5);
                        ex.SetCellValue(Convert.ToDateTime(nrList[0].hdjssj).Year + "年" + Convert.ToDateTime(nrList[0].hdjssj).Month + "月"
                            + Convert.ToDateTime(nrList[0].hdjssj).Day + "日" + Convert.ToDateTime(nrList[0].hdjssj).Hour + "时"
                            + Convert.ToDateTime(nrList[0].hdjssj).Minute + "分", row + 3 + i, 5);
                        ex.SetCellValue(nrList[0].cxry, row + 4 + i, 2);
                        ex.SetCellValue(nrList[0].qxry, row + 5 + i, 2);
                        ex.SetCellValue(nrList[0].hdnr, row + 6 + i, 2);
                        ex.SetCellValue(nrList[0].hdxj, row + 7 + i, 2);
                        ex.SetCellValue(nrList[0].ldjcpy, row + 8 + i, 2);
                        //ex.SetCellValue(nrList[starow - 1 + i].jlr, row + 4 + i, 13);

                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日", row + 1 + i, 1);
                        ex.SetCellValue(GetWeeks(DateTime.Now.DayOfWeek), row + 1 + i, 4);
                        ex.SetCellValue(nrList[0].zcr, row + 2 + i, 2);
                        ex.SetCellValue(Convert.ToDateTime(nrList[0].hdkssj).Year + "年" + Convert.ToDateTime(nrList[0].hdkssj).Month + "月"
                            + Convert.ToDateTime(nrList[0].hdkssj).Day + "日" + Convert.ToDateTime(nrList[0].hdkssj).Hour + "时"
                            + Convert.ToDateTime(nrList[0].hdkssj).Minute + "分", row + 2 + i, 5);
                        ex.SetCellValue(Convert.ToDateTime(nrList[0].hdjssj).Year + "年" + Convert.ToDateTime(nrList[0].hdjssj).Month + "月"
                            + Convert.ToDateTime(nrList[0].hdjssj).Day + "日" + Convert.ToDateTime(nrList[0].hdjssj).Hour + "时"
                            + Convert.ToDateTime(nrList[0].hdjssj).Minute + "分", row + 3 + i, 5);
                        ex.SetCellValue(nrList[0].cxry, row + 4 + i, 2);
                        ex.SetCellValue(nrList[0].qxry, row + 5 + i, 2);
                        ex.SetCellValue(nrList[0].hdnr, row + 6 + i, 2);
                        ex.SetCellValue(nrList[0].hdxj, row + 7 + i, 2);
                        ex.SetCellValue(nrList[0].ldjcpy, row + 8 + i, 2);
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
            #endregion
        }

        /// <summary>
        /// 事故、障碍及异常运行记录簿
        /// </summary>
        /// <param name="nrList">记录</param>
        public static void ExportExcelSgzajlb(IList<bdjl_sgzayc> nrList)
        {
            #region  事故障碍及异常运行记录簿
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\事故、障碍及异常运行记录簿.xls";
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
                    for (int i = 0; i < 1; i++)
                    {
                        ex.SetCellValue(Convert.ToDateTime(nrList[0].fssj).Year + "年" + Convert.ToDateTime(nrList[0].fssj).Month + "月"
                            + Convert.ToDateTime(nrList[0].fssj).Day + "日" + Convert.ToDateTime(nrList[0].fssj).Hour + "时" + Convert.ToDateTime(nrList[0].fssj).Minute + "分", row + 1 + i, 1);
                        ex.SetCellValue(nrList[0].xz, row + 1 + i, 4);
                        ex.SetCellValue(nrList[0].jt, row + 2 + i, 2);
                        ex.SetCellValue(nrList[0].fsjg, row + 3 + i, 2);
                        ex.SetCellValue(nrList[0].sgsxqk, row + 4 + i, 2);
                        ex.SetCellValue(nrList[0].yyjfzfx, row + 5 + i, 2);
                        ex.SetCellValue(nrList[0].dc, row + 6 + i, 2);
                        //ex.SetCellValue(nrList[starow - 1 + i].jlr, row + 4 + i, 13);

                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(Convert.ToDateTime(nrList[0].fssj).Year + "年" + Convert.ToDateTime(nrList[0].fssj).Month + "月"
                            + Convert.ToDateTime(nrList[0].fssj).Day + "日" + Convert.ToDateTime(nrList[0].fssj).Hour + "时" + Convert.ToDateTime(nrList[0].fssj).Minute + "分", row + 1 + i, 1);
                        ex.SetCellValue(nrList[0].xz, row + 1 + i, 4);
                        ex.SetCellValue(nrList[0].jt, row + 2 + i, 2);
                        ex.SetCellValue(nrList[0].fsjg, row + 3 + i, 2);
                        ex.SetCellValue(nrList[0].sgsxqk, row + 4 + i, 2);
                        ex.SetCellValue(nrList[0].yyjfzfx, row + 5 + i, 2);
                        ex.SetCellValue(nrList[0].dc, row + 6 + i, 2);
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
            #endregion
        }

        /// <summary>
        /// 运行分析记录簿
        /// </summary>
        /// <param name="nrList">记录</param>
        public static void ExportExcelYxfxjlb(IList<bdjl_yxfxjlb> nrList)
        {
            #region  运行分析记录簿
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\运行分析记录簿.xls";
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
                    for (int i = 0; i < 1; i++)
                    {
                        ex.SetCellValue(nrList[0].sj.Year + "年" + nrList[0].sj.Month + "月" + nrList[0].sj.Day + "日", row + 1 + i, 1);
                        ex.SetCellValue(nrList[0].cjry, row + 2 + i, 2);
                        ex.SetCellValue(nrList[0].nr, row + 3 + i, 2);
                        ex.SetCellValue(nrList[0].jl, row + 4 + i, 2);
                        //ex.SetCellValue(nrList[starow - 1 + i].jlr, row + 4 + i, 13);

                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(nrList[0].sj.Year + "年" + nrList[0].sj.Month + "月" + nrList[0].sj.Day + "日", row + 1 + i, 1);
                        ex.SetCellValue(nrList[0].cjry, row + 2 + i, 2);
                        ex.SetCellValue(nrList[0].nr, row + 3 + i, 2);
                        ex.SetCellValue(nrList[0].jl, row + 4 + i, 2);
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
            #endregion
        }

        /// <summary>
        /// 获得星期几
        /// </summary>
        /// <param name="dayweek">枚举英文</param>
        /// <returns></returns>
        private static string GetWeeks(DayOfWeek dayweek)
        {
            string returnweek = "";
            switch (dayweek)
            {
                case DayOfWeek.Monday:
                    returnweek = "星期一";
                    break;
                case DayOfWeek.Tuesday:
                    returnweek = "星期二";
                    break;
                case DayOfWeek.Wednesday:
                    returnweek = "星期三";
                    break;
                case DayOfWeek.Thursday:
                    returnweek = "星期四";
                    break;
                case DayOfWeek.Friday:
                    returnweek = "星期五";
                    break;
                case DayOfWeek.Saturday:
                    returnweek="星期六";
                    break;
                default:
                    returnweek = "星期天";
                    break;
            }
            return returnweek;
        }
    }
}
