﻿using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using Ebada.Client.Platform;
using Ebada.Components;
using System.Threading;
using System.Text.RegularExpressions;
namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class ExportGDSCKEdit
    {
        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set { parentTemple = value; }
        }
        public bool IsWorkflowCall
        {
            set
            {
                isWorkflowCall = value;
            }
        }
        public LP_Record CurrRecord
        {
            get { return currRecord; }
            set { currRecord = value; }
        }

        public DataTable RecordWorkFlowData
        {
            get
            {
                return WorkFlowData;
            }
            set
            {
                WorkFlowData = value;
            }
        }

        /// <summary>
        /// 导出出库单
        /// </summary>
        /// <param name="orgCode"></param>
        /// <param name="jingbanren"></param>
        public void ExportGDSRKDExcel(string orgCode, string jingbanren, DateTime enterTime)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\供电所材料出库单.xls";
            ex.Open(fname);

            string orgname = (string)ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", "select top 1 OrgName from mOrg where OrgCode='" + orgCode + "'");
            string suozhang = (string)ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", "select top 1 UserName from mUser where OrgCode='" + orgCode + "' and PostName='所长'");
            string shengjibanzhang = (string)ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", "select top 1 UserName from mUser where OrgCode='" + orgCode + "' and PostName='生技班长'");

            ex.SetCellValue(orgname, 3, 3);
            ex.SetCellValue(suozhang, 47, 4);
            ex.SetCellValue(shengjibanzhang, 47, 6);
            ex.SetCellValue(jingbanren, 47, 8);

            IList<PJ_gdscrk> datalist = ClientHelper.PlatformSqlMap.GetList<PJ_gdscrk>(" where OrgCode='" + orgCode + "' and type='出库' and ckdate >= '" + enterTime + "' order by ckdate desc,wpmc");

            #region 开始导出
            //此处写填充内容代码
            int row = 5;
            int col = 1;
            int rowcount = 42;
            if (datalist.Count < 1) return;
            Regex r1 = new Regex("[0-9]+");
            string str = r1.Match(datalist[0].num).Value;
            if (str == "")
            {
                str = datalist[0].num;
            }
            string tablename = "供电所材料出库单";
            if (tablename.Length > 30)
            {
                tablename = tablename.Substring(tablename.Length - 31);
            }
            //
            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(datalist.Count, rowcount))
            {
                pageindex = Ecommon.GetPagecount(datalist.Count, rowcount);
            }

            for (int j = 1; j < pageindex; j++)
            {

                ex.CopySheet(1, j);
                ex.ReNameWorkSheet(j + 1, tablename + "(" + (j) + ")");
            }
            for (int j = 0; j < datalist.Count; j++)
            {
                if (j % rowcount == 0)
                {
                    if (j == 0) ex.ActiveSheet(tablename);
                    else ex.ActiveSheet(tablename + "(" + (j / rowcount + 1) + ")");
                }
                // 填值
                ex.SetCellValue((j + 1).ToString(), row + j % rowcount, col);
                ex.SetCellValue(datalist[j].wpmc, row + j % rowcount, col + 1);
                ex.SetCellValue(datalist[j].wpgg, row + j % rowcount, col + 2);
                ex.SetCellValue(datalist[j].wpdw, row + j % rowcount, col + 3);
                ex.SetCellValue(datalist[j].cksl, row + j % rowcount, col + 4);
                ex.SetCellValue(datalist[j].ckdate.ToString(), row + j % rowcount, col + 5);
                ex.SetCellValue(datalist[j].yt, row + j % rowcount, col + 6);
                ex.SetCellValue(datalist[j].Remark, row + j % rowcount, col + 7);
            }
            #endregion
            //ex.DeleteSheet(1);
            ex.ActiveSheet(tablename);
            ex.ShowExcel();
        }


        /// <summary>
        /// 一次一导出入库单
        /// </summary>
        /// <param name="orgCode"></param>
        /// <param name="jingbanren"></param>
        public void ExportOne(PJ_gdscrk obj)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\供电所材料出库单.xls";
            ex.Open(fname);

            string orgname = (string)ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", "select top 1 OrgName from mOrg where OrgCode='" + obj.OrgCode + "'");
            string suozhang = (string)ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", "select top 1 UserName from mUser where OrgCode='" + obj.OrgCode + "' and PostName='所长'");
            string shengjibanzhang = (string)ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", "select top 1 UserName from mUser where OrgCode='" + obj.OrgCode + "' and PostName='生技班长'");

            ex.SetCellValue(orgname, 3, 3);
            ex.SetCellValue(suozhang, 47, 4);
            ex.SetCellValue(shengjibanzhang, 47, 6);

            int row = 5;
            int col = 1;

            ex.SetCellValue("1", row, col);
            ex.SetCellValue(obj.wpmc, row, col + 1);
            ex.SetCellValue(obj.wpgg, row, col + 2);
            ex.SetCellValue(obj.wpdw, row, col + 3);
            ex.SetCellValue(obj.cksl, row, col + 4);
            ex.SetCellValue(obj.ckdate.ToString(), row, col + 5);
            ex.SetCellValue(obj.yt, row, col + 6);
            ex.SetCellValue(obj.Remark, row, col + 7);
            ex.ShowExcel();
        }


        /// <summary>
        /// 根据查询条件导出入库单
        /// </summary>
        /// <param name="orgCode"></param>
        /// <param name="jingbanren"></param>
        public void ExportExcelForSQL(string orgCode, string jingbanren, string sql)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\供电所材料出库单.xls";
            ex.Open(fname);

            string orgname = (string)ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", "select top 1 OrgName from mOrg where OrgCode='" + orgCode + "'");
            string suozhang = (string)ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", "select top 1 UserName from mUser where OrgCode='" + orgCode + "' and PostName='所长'");
            string shengjibanzhang = (string)ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", "select top 1 UserName from mUser where OrgCode='" + orgCode + "' and PostName='生技班长'");

            ex.SetCellValue(orgname, 3, 3);
            ex.SetCellValue(suozhang, 47, 4);
            ex.SetCellValue(shengjibanzhang, 47, 6);
            ex.SetCellValue(jingbanren, 47, 8);

            IList<PJ_gdscrk> datalist = ClientHelper.PlatformSqlMap.GetList<PJ_gdscrk>(sql);

            #region 开始导出
            //此处写填充内容代码
            int row = 5;
            int col = 1;
            int rowcount = 42;
            if (datalist.Count < 1) return;
            Regex r1 = new Regex("[0-9]+");
            string str = r1.Match(datalist[0].num).Value;
            if (str == "")
            {
                str = datalist[0].num;
            }
            string tablename = "供电所材料出库单";
            if (tablename.Length > 30)
            {
                tablename = tablename.Substring(tablename.Length - 31);
            }
            //
            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(datalist.Count, rowcount))
            {
                pageindex = Ecommon.GetPagecount(datalist.Count, rowcount);
            }

            for (int j = 1; j < pageindex; j++)
            {

                ex.CopySheet(1, j);
                ex.ReNameWorkSheet(j + 1, tablename + "(" + (j) + ")");
            }
            for (int j = 0; j < datalist.Count; j++)
            {
                if (j % rowcount == 0)
                {
                    if (j == 0) ex.ActiveSheet(tablename);
                    else ex.ActiveSheet(tablename + "(" + (j / rowcount + 1) + ")");
                }
                // 填值
                ex.SetCellValue((j + 1).ToString(), row + j % rowcount, col);
                ex.SetCellValue(datalist[j].wpmc, row + j % rowcount, col + 1);
                ex.SetCellValue(datalist[j].wpgg, row + j % rowcount, col + 2);
                ex.SetCellValue(datalist[j].wpdw, row + j % rowcount, col + 3);
                ex.SetCellValue(datalist[j].cksl, row + j % rowcount, col + 4);
                ex.SetCellValue(datalist[j].ckdate.ToString(), row + j % rowcount, col + 5);
                ex.SetCellValue(datalist[j].yt, row + j % rowcount, col + 6);
                ex.SetCellValue(datalist[j].Remark, row + j % rowcount, col + 7);
            }
            #endregion
            //ex.DeleteSheet(1);
            ex.ActiveSheet(tablename);
            ex.ShowExcel();
        }
    }
}
