using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Ebada.Client;
using Ebada.Kcgl.Model;
using Ebada.jhgl;
using System.Windows.Forms;

namespace Ebada.Kcgl
{
    public class ExportExcel
    {
        /// <summary>
        /// 入库明细表
        /// </summary>
        /// <param name="nrList"></param>
        internal static void ExportRKMX(List<kc_入库明细表> nrList)
        {
            ExcelAccess ex = new ExcelAccess();
            string filename  = Application.StartupPath + "\\00记录模板\\入库明细表.xls";
            if (!File.Exists(filename))
            {
                MsgBox.ShowWarningMessageBox("导出模板不存在，导出失败!");
                return;
            }
            ex.Open(filename);
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
                        ex.SetCellValue(nrList[starow - 1 + i].工程类别, row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].供货厂家, row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].入库日期.ToShortDateString(), row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].材料名称, row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].规格及型号, row + 4 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].计量单位, row + 4 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].单价.ToString(), row + 4 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].数量.ToString(), row + 4 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].总计.ToString(), row + 4 + i, 9);
                        //ex.SetCellValue(nrList[starow - 1 + i].单位名称, row + 2 + i, 1);

                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].工程类别, row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].供货厂家, row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].入库日期.ToShortDateString(), row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].材料名称, row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].规格及型号, row + 4 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].计量单位, row + 4 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].单价.ToString(), row + 4 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].数量.ToString(), row + 4 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].总计.ToString(), row + 4 + i, 9);
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
        }

        /// <summary>
        /// 出库明细表
        /// </summary>
        /// <param name="nrList"></param>
        internal static void ExportCKMX(List<kc_出库明细表> nrList)
        {
            ExcelAccess ex = new ExcelAccess();
            string filename = Application.StartupPath + "\\00记录模板\\出库明细表.xls";
            if (!File.Exists(filename))
            {
                MsgBox.ShowWarningMessageBox("导出模板不存在，导出失败!");
                return;
            }
            ex.Open(filename);
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
                        ex.SetCellValue(nrList[starow - 1 + i].工程类别, row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].出库单位, row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].出库日期.ToShortDateString(), row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].材料名称, row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].规格及型号, row + 4 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].计量单位, row + 4 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].单价.ToString(), row + 4 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].数量.ToString(), row + 4 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].总计.ToString(), row + 4 + i, 9);
                        //ex.SetCellValue(nrList[starow - 1 + i].单位名称, row + 2 + i, 1);

                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].工程类别, row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].出库单位, row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].出库日期.ToShortDateString(), row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].材料名称, row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].规格及型号, row + 4 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].计量单位, row + 4 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].单价.ToString(), row + 4 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].数量.ToString(), row + 4 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].总计.ToString(), row + 4 + i, 9);
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
        }

        /// <summary>
        /// 退货明细表
        /// </summary>
        /// <param name="nrList"></param>
        internal static void ExportTHMX(List<kc_退货明细表> nrList)
        {
            ExcelAccess ex = new ExcelAccess();
            string filename = Application.StartupPath + "\\00记录模板\\退货明细表.xls";
            if (!File.Exists(filename))
            {
                MsgBox.ShowWarningMessageBox("导出模板不存在，导出失败!");
                return;
            }
            ex.Open(filename);
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
                        ex.SetCellValue(nrList[starow - 1 + i].工程类别, row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].退货厂家, row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].退货日期.ToShortDateString(), row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].材料名称, row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].规格及型号, row + 4 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].计量单位, row + 4 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].单价.ToString(), row + 4 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].数量.ToString(), row + 4 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].总计.ToString(), row + 4 + i, 9);
                        //ex.SetCellValue(nrList[starow - 1 + i].单位名称, row + 2 + i, 1);

                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].工程类别, row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].退货厂家, row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].退货日期.ToShortDateString(), row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].材料名称, row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].规格及型号, row + 4 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].计量单位, row + 4 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].单价.ToString(), row + 4 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].数量.ToString(), row + 4 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].总计.ToString(), row + 4 + i, 9);
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
        }

        /// <summary>
        /// 库存信息查询
        /// </summary>
        /// <param name="nrList"></param>
        internal static void ExportKCXXCX(List<v库存明细表> nrList)
        {
            ExcelAccess ex = new ExcelAccess();
            string filename = Application.StartupPath + "\\00记录模板\\库存信息查询.xls";
            if (!File.Exists(filename))
            {
                MsgBox.ShowWarningMessageBox("导出模板不存在，导出失败!");
                return;
            }
            ex.Open(filename);
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
                        ex.SetCellValue(nrList[starow - 1 + i].工程类别, row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].材料名称, row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].规格及型号, row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].计量单位, row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].单价.ToString(), row + 4 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].库存数量.ToString(), row + 4 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].总计.ToString(), row + 4 + i, 7);
                        //ex.SetCellValue(nrList[starow - 1 + i].单位名称, row + 2 + i, 1);

                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].工程类别, row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].材料名称, row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].规格及型号, row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].计量单位, row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].单价.ToString(), row + 4 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].库存数量.ToString(), row + 4 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].总计.ToString(), row + 4 + i, 7);
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
        }

        /// <summary>
        /// 库存汇总
        /// </summary>
        /// <param name="nrList"></param>
        internal static void ExportKCHZCX(List<v库存汇总表> nrList)
        {
            ExcelAccess ex = new ExcelAccess();
            string filename = Application.StartupPath + "\\00记录模板\\库存汇总表.xls";
            if (!File.Exists(filename))
            {
                MsgBox.ShowWarningMessageBox("导出模板不存在，导出失败!");
                return;
            }
            ex.Open(filename);
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
                        
                        ex.SetCellValue(nrList[starow - 1 + i].材料名称, row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].规格及型号, row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].计量单位, row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].库存数量.ToString(), row + 4 + i, 4);
                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].材料名称, row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].规格及型号, row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].计量单位, row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].库存数量.ToString(), row + 4 + i, 4);
                    }
                }

            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
        }

        /// <summary>
        /// 工程到货查询
        /// </summary>
        /// <param name="nrList"></param>
        internal static void ExportGCDHCX(IList<v工程到货查询表> nrList)
        {
            ExcelAccess ex = new ExcelAccess();
            string filename = Application.StartupPath + "\\00记录模板\\工程到货查询.xls";
            if (!File.Exists(filename))
            {
                MsgBox.ShowWarningMessageBox("导出模板不存在，导出失败!");
                return;
            }
            ex.Open(filename);
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

                        ex.SetCellValue(nrList[starow - 1 + i].项目名称, row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].工程类别, row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].材料名称, row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].规格及型号, row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].计量单位, row + 4 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].计划数量.ToString(), row + 4 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].到货数量.ToString(), row + 4 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].差值.ToString(), row + 4 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].计划日期.ToShortDateString(), row + 4 + i, 9);
                        ex.SetCellValue(nrList[starow - 1 + i].合同到货日期.ToShortDateString(), row + 4 + i, 10);
                        ex.SetCellValue(nrList[starow - 1 + i].供货厂家, row + 4 + i, 11);
                        ex.SetCellValue(nrList[starow - 1 + i].联系人, row + 4 + i, 12);
                        ex.SetCellValue(nrList[starow - 1 + i].联系电话, row + 4 + i, 13);
                       
                        
                    }
                }
                else if (nrList.Count <= endrow && nrList.Count >= starow)
                {
                    for (int i = 0; i < nrList.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(nrList[starow - 1 + i].项目名称, row + 4 + i, 1);
                        ex.SetCellValue(nrList[starow - 1 + i].工程类别, row + 4 + i, 2);
                        ex.SetCellValue(nrList[starow - 1 + i].材料名称, row + 4 + i, 3);
                        ex.SetCellValue(nrList[starow - 1 + i].规格及型号, row + 4 + i, 4);
                        ex.SetCellValue(nrList[starow - 1 + i].计量单位, row + 4 + i, 5);
                        ex.SetCellValue(nrList[starow - 1 + i].计划数量.ToString(), row + 4 + i, 6);
                        ex.SetCellValue(nrList[starow - 1 + i].到货数量.ToString(), row + 4 + i, 7);
                        ex.SetCellValue(nrList[starow - 1 + i].差值.ToString(), row + 4 + i, 8);
                        ex.SetCellValue(nrList[starow - 1 + i].计划日期.ToShortDateString(), row + 4 + i, 9);
                        ex.SetCellValue(nrList[starow - 1 + i].合同到货日期.ToShortDateString(), row + 4 + i, 10);
                        ex.SetCellValue(nrList[starow - 1 + i].供货厂家, row + 4 + i, 11);
                        ex.SetCellValue(nrList[starow - 1 + i].联系人, row + 4 + i, 12);
                        ex.SetCellValue(nrList[starow - 1 + i].联系电话, row + 4 + i, 13);
                    }
                }
            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
        }

        /// <summary>
        /// 工程结算查询
        /// </summary>
        /// <param name="nrList"></param>
        internal static void ExportGCJSCX(IList<v工程结算查询> nrList1,IList<v出库汇总表_项目除返库> nrList2)
        {
            ExcelAccess ex = new ExcelAccess();
            string filename = Application.StartupPath + "\\00记录模板\\工程结算表.xls";
            if (!File.Exists(filename))
            {
                MsgBox.ShowWarningMessageBox("导出模板不存在，导出失败!");
                return;
            }
            ex.Open(filename);
            int row = 1;
            //加页
            int pageindex = 1;
            if (pageindex < Ecommonjh.GetPagecount(nrList1.Count, 12))
            {
                pageindex = Ecommonjh.GetPagecount(nrList1.Count, 12);
            }
            if (pageindex < Ecommonjh.GetPagecount(nrList2.Count, 12))
            {
                pageindex = Ecommonjh.GetPagecount(nrList2.Count, 12);
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
                int starow = prepageindex * 12 + 1;
                int endrow = j * 12;

                if (nrList1.Count > endrow)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        ex.SetCellValue(nrList1[starow - 1 + i].工程类别, row + 4 + i, 1);
                        ex.SetCellValue(nrList1[starow - 1 + i].材料名称, row + 4 + i, 2);
                        ex.SetCellValue(nrList1[starow - 1 + i].规格及型号, row + 4 + i, 3);
                        ex.SetCellValue(nrList1[starow - 1 + i].计量单位, row + 4 + i, 4);
                        ex.SetCellValue(nrList1[starow - 1 + i].单价.ToString(), row + 4 + i, 5);
                        ex.SetCellValue(nrList1[starow - 1 + i].到货数量.ToString(), row + 4 + i, 6);
                        ex.SetCellValue(nrList1[starow - 1 + i].使用数量.ToString(), row + 4 + i, 7);
                        ex.SetCellValue(nrList1[starow - 1 + i].结余数量.ToString(), row + 4 + i, 8);
                        ex.SetCellValue(nrList1[starow - 1 + i].总价.ToString(), row + 4 + i, 9);
                    }
                }
                else if (nrList1.Count <= endrow && nrList1.Count >= starow)
                {
                    for (int i = 0; i < nrList1.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(nrList1[starow - 1 + i].工程类别, row + 4 + i, 1);
                        ex.SetCellValue(nrList1[starow - 1 + i].材料名称, row + 4 + i, 2);
                        ex.SetCellValue(nrList1[starow - 1 + i].规格及型号, row + 4 + i, 3);
                        ex.SetCellValue(nrList1[starow - 1 + i].计量单位, row + 4 + i, 4);
                        ex.SetCellValue(nrList1[starow - 1 + i].单价.ToString(), row + 4 + i, 5);
                        ex.SetCellValue(nrList1[starow - 1 + i].到货数量.ToString(), row + 4 + i, 6);
                        ex.SetCellValue(nrList1[starow - 1 + i].使用数量.ToString(), row + 4 + i, 7);
                        ex.SetCellValue(nrList1[starow - 1 + i].结余数量.ToString(), row + 4 + i, 8);
                        ex.SetCellValue(nrList1[starow - 1 + i].总价.ToString(), row + 4 + i, 9);
                    }
                }

                if (nrList2.Count > endrow)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        ex.SetCellValue(nrList2[starow - 1 + i].工程项目名称, row + 21 + i, 1);
                        ex.SetCellValue(nrList2[starow - 1 + i].材料名称, row + 21 + i, 2);
                        ex.SetCellValue(nrList2[starow - 1 + i].规格及型号, row + 21 + i, 3);
                        ex.SetCellValue(nrList2[starow - 1 + i].计量单位, row + 21 + i, 4);
                        ex.SetCellValue(nrList2[starow - 1 + i].单价.ToString(), row + 21 + i, 5);
                        ex.SetCellValue(nrList2[starow - 1 + i].数量.ToString(), row + 21 + i, 6);
                        ex.SetCellValue(nrList2[starow - 1 + i].总价.ToString(), row + 21 + i, 6);
                    }
                }
                else if (nrList2.Count <= endrow && nrList1.Count >= starow)
                {
                    for (int i = 0; i < nrList2.Count - starow + 1; i++)
                    {
                        ex.SetCellValue(nrList2[starow - 1 + i].工程项目名称, row + 21 + i, 1);
                        ex.SetCellValue(nrList2[starow - 1 + i].材料名称, row + 21 + i, 2);
                        ex.SetCellValue(nrList2[starow - 1 + i].规格及型号, row + 21 + i, 3);
                        ex.SetCellValue(nrList2[starow - 1 + i].计量单位, row + 21 + i, 4);
                        ex.SetCellValue(nrList2[starow - 1 + i].单价.ToString(), row + 21 + i, 5);
                        ex.SetCellValue(nrList2[starow - 1 + i].数量.ToString(), row + 21 + i, 6);
                        ex.SetCellValue(nrList2[starow - 1 + i].总价.ToString(), row + 21 + i, 6);
                    }
                }
                
            }
            ex.ActiveSheet(1);
            ex.ShowExcel();
        }
    }
}
