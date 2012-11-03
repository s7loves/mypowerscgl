using System;
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
        /// 导出入库单
        /// </summary>
        /// <param name="orgCode"></param>
        /// <param name="jingbanren"></param>
        public void ExportGDSRKDExcel(string orgCode, string jingbanren)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\供电所材料出库单.xls";
            ex.Open(fname);

            string orgname = (string)ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", "select top 1 OrgName from mOrg where OrgCode='" + orgCode + "'");
            string suozhang = (string)ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", "select top 1 UserName from mUser where OrgCode='" + orgCode + "' and type='所长'");
            string shengjibanzhang = (string)ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", "select top 1 UserName from mUser where OrgCode='" + orgCode + "' and type='生计班长'");

            ex.SetCellValue(orgname, 3, 3);
            ex.SetCellValue(suozhang, 47, 4);
            ex.SetCellValue(shengjibanzhang, 47, 6);
            ex.SetCellValue(jingbanren, 47, 7);

            IList<PJ_gdscrk> datalist = ClientHelper.PlatformSqlMap.GetList<PJ_gdscrk>(" where OrgCode='" + orgCode + "' and type='出库'");

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
                ex.SetCellValue((j + 1).ToString(), row + j, col);
                ex.SetCellValue(datalist[j].wpmc, row + j, col + 1);
                ex.SetCellValue(datalist[j].wpgg, row + j, col + 2);
                ex.SetCellValue(datalist[j].wpdw, row + j, col + 3);
                ex.SetCellValue(datalist[j].cksl, row + j, col + 4);
                ex.SetCellValue(datalist[j].ckdate.ToString(), row + j, col + 5);
                ex.SetCellValue(datalist[j].yt, row + j, col + 6);
                ex.SetCellValue(datalist[j].Remark, row + j, col + 7);
            }
            #endregion
            //ex.DeleteSheet(1);
            ex.ShowExcel();
        }
    }
}
