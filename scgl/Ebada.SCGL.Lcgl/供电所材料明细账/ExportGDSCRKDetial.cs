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
    public class ExportGDSCRKDetial
    {
        /// <summary>
        /// 导出入库单
        /// </summary>
        /// <param name="orgCode"></param>
        /// <param name="jingbanren"></param>
        public void ExportGDSRKDExcel(string orgCode, string endTime)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\供电所材料季度明细账.xls";
            ex.Open(fname);

            string orgname = (string)ClientHelper.PlatformSqlMap.GetObject("SelectOneStr", "select top 1 OrgName from mOrg where OrgCode='" + orgCode + "'");

            ex.SetCellValue(orgname, 3, 2);
            ex.SetCellValue(endTime, 3, 5);

            IList<PJ_gdscrk> datalist = ClientHelper.PlatformSqlMap.GetList<PJ_gdscrk>(" where OrgCode='" + orgCode + "' and type!='原始入库材料'  and (indate <= '" + endTime + "' or ckdate<='" + endTime + "') order by wpmc ");

            if (datalist.Count <= 0)
            {
                return;
            }
            #region 开始导出
            //此处写填充内容代码
            int row = 5;
            int col = 1;
            int rowcount = 41;
            if (datalist.Count < 1) return;
            Regex r1 = new Regex("[0-9]+");
            string str = r1.Match(datalist[0].num).Value;
            if (str == "")
            {
                str = datalist[0].num;
            }
            string tablename = "供电所材料季度明细账";
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
                ex.SetCellValue(datalist[j].wpmc, row + j % rowcount, col);
                ex.SetCellValue(datalist[j].wpgg, row + j % rowcount, col + 1);
                ex.SetCellValue(datalist[j].wpdw, row + j % rowcount, col + 2);
                ex.SetCellValue(datalist[j].rkslcount, row + j % rowcount, col + 3);
                ex.SetCellValue(datalist[j].ckslcount, row + j % rowcount, col + 4);
                ex.SetCellValue(datalist[j].kcslcount, row + j % rowcount, col + 5);
            }
            #endregion
            ex.ShowExcel();
        }
    }
}
