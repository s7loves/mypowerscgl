using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;
namespace Ebada.Scgl.Lcgl {
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class ExportLCFXWTJZGLS
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
        public void ExportExcelCunChaYear(string orgid,string year)
        {
            ////lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\春秋查内查发现问题及整改落实情况记录.xls";
            ex.Open(fname);

            string startmonth = "3", startday = "1", endmonth = "5", endtday = "31";
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select nr  from pj_dyk where  dx='供电所春秋查停电检修计划' and sx like '%{0}%' and nr!=''", "春查停电检修开始日期"));
            if (list.Count > 0)
            {

                Regex r1 = new Regex(@"[0-9]+(?=月)");
                if (r1.Match(list[0].ToString()).Value != "")
                {
                    startmonth = r1.Match(list[0].ToString()).Value;
                }
                r1 = new Regex(@"(?<=月)[0-9]+");
                if (r1.Match(list[0].ToString()).Value != "")
                {
                    startday = r1.Match(list[0].ToString()).Value;
                }
            }
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
               string.Format("select nr  from pj_dyk where  dx='供电所春秋查停电检修计划' and sx like '%{0}%' and nr!=''", "春查停电检修截止日期"));
            if (list.Count > 0)
            {

                Regex r1 = new Regex(@"[0-9]+(?=月)");
                if (r1.Match(list[0].ToString()).Value != "")
                {
                    endmonth = r1.Match(list[0].ToString()).Value;
                }
                r1 = new Regex(@"(?<=月)[0-9]+");
                if (r1.Match(list[0].ToString()).Value != "")
                {
                    endtday = r1.Match(list[0].ToString()).Value;
                }
            }
            string strfirst = "";
            string filter = "";
            filter = "  where 1=1";
            if (year!="全部") filter += " and  jhwcsj between '" + year + "-" + startmonth + "-" + startday + " 00:00:00' and  cast('"
                + year + "-" + endmonth + "-" + endtday + " 23:59:59' as datetime) ";
            if (orgid != "") filter += " and OrgCode='" + orgid + "' ";
            if (isWorkflowCall)
            {
                filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowId='"
                    + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "') "
                        + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                    + "    RecordID='" + currRecord.ID + "') "
                    ;
            }
            IList<PJ_lcfxwtjzgls> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_lcfxwtjzgls>(
             filter
               );
            ExportExcel(ex, datalist);




            ex.ShowExcel();
        }
        public void ExportExcelQiuChaYear(string orgid, string year)
        {
            ////lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\春秋查内查发现问题及整改落实情况记录.xls";
            ex.Open(fname);

            string startmonth = "9", startday = "1", endmonth = "11", endtday = "30";
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select nr  from pj_dyk where  dx='供电所春秋查停电检修计划' and sx like '%{0}%' and nr!=''", "秋查停电检修开始日期"));
            if (list.Count > 0)
            {

                Regex r1 = new Regex(@"[0-9]+(?=月)");
                if (r1.Match(list[0].ToString()).Value != "")
                {
                    startmonth = r1.Match(list[0].ToString()).Value;
                }
                r1 = new Regex(@"(?<=月)[0-9]+");
                if (r1.Match(list[0].ToString()).Value != "")
                {
                    startday = r1.Match(list[0].ToString()).Value;
                }
            }
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
               string.Format("select nr  from pj_dyk where  dx='供电所春秋查停电检修计划' and sx like '%{0}%' and nr!=''", "秋查停电检修截止日期"));
            if (list.Count > 0)
            {

                Regex r1 = new Regex(@"[0-9]+(?=月)");
                if (r1.Match(list[0].ToString()).Value != "")
                {
                    endmonth = r1.Match(list[0].ToString()).Value;
                }
                r1 = new Regex(@"(?<=月)[0-9]+");
                if (r1.Match(list[0].ToString()).Value != "")
                {
                    endtday = r1.Match(list[0].ToString()).Value;
                }
            }
            string strfirst = "";
            string filter = "";

            filter = "  where 1=1";
            if (year != "全部") filter += " and  ssrq between '" + year + "-" + startmonth + "-" + startday + " 00:00:00' and  cast('"
                + year + "-" + endmonth + "-" + endtday + " 23:59:59' as datetime) ";
            if (orgid != "") filter += " and OrgCode='" + orgid + "' ";
            if (isWorkflowCall)
            {
                filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowId='"
                    + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "') "
                        + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                    + "    RecordID='" + currRecord.ID + "') "
                    ;
            }
            IList<PJ_lcfxwtjzgls> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_lcfxwtjzgls>(
             filter
               );
            ExportExcel(ex, datalist);




            ex.ShowExcel();
        }
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public void ExportExcel()
        {
            ////lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\春秋查内查发现问题及整改落实情况记录.xls";
            ex.Open(fname);

            string strfirst = "";
            string filter = "";

            filter = "  where 1=1 ";
            if (isWorkflowCall)
            {
                filter = filter + " and id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                    + "    RecordID='" + currRecord.ID + "') "
                    ;
            }
            IList<PJ_lcfxwtjzgls> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_lcfxwtjzgls>(
             filter
               );
            ExportExcel(ex, datalist);




            ex.ShowExcel();
        }
        public void ExportExcel(ExcelAccess ex, IList<PJ_lcfxwtjzgls> datalist)
        {
            //此处写填充内容代码
            int row = 4;
            int col = 1;
            int rowcount = 3;

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
              
            }
            for (int j = 0; j < datalist.Count; j++)
            {

                if (j % rowcount == 0)
                {
                    if (j == 0) ex.ActiveSheet(1);
                    else ex.ActiveSheet( (j / rowcount + 1));

                    //ex.SetCellValue(DateTime.Now.ToString("yyyy年") + "春秋查内查发现问题及整改落实情况记录", 2, 1);

                    //ex.SetCellValue(DateTime.Now.ToString("yyyy年MM月dd日") , 3, 8);

                }
                ex.SetCellValue((j + 1).ToString(), row + j % rowcount, col);
                ex.SetCellValue(datalist[j].ccwt, row + j % rowcount, col + 1);
                ex.SetCellValue(datalist[j].zgcs, row + j % rowcount, col + 2);
                ex.SetCellValue(datalist[j].jhwcsj.ToString("MM月dd日"), row + j % rowcount, col + 3);

                ex.SetCellValue(datalist[j].lszgsj.ToString("MM月dd日"), row + j % rowcount, col + 4);
                ex.SetCellValue(datalist[j].lsqk, row + j % rowcount, col + 5);
                ex.SetCellValue(datalist[j].lsr, row + j % rowcount, col + 6);
                ex.SetCellValue(datalist[j].dbr, row + j % rowcount, col + 7);
                ex.SetCellValue(datalist[j].Remark, row + j % rowcount, col +8);


            }
        
        }
    }
}
