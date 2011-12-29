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
    public class ExportCQJBYDTDJXJH
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
        public void ExportExcelCunJian(string orgid)
        {

            
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\供电所春秋查停电检修计划.xls";
            ex.Open(fname);
            string startmonth = "3", startday= "1", endmonth = "5", endtday = "31";
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select nr  from pj_dyk where  dx='供电所春秋查停电检修计划' and sx like '%{0}%' and nr!=''", "春查停电检修开始日期"));
            if (list.Count > 0)
            {

                Regex r1 = new Regex(@"[0-9]+(?=月)");
                if(r1.Match(list[0].ToString()).Value!="")
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
            string str = " where 1=1 and  TDtime between '" + DateTime.Now.Year + "-" + startmonth + "-" + startday + " 00:00:00' and  cast('"
                + DateTime.Now.Year + "-" + endmonth + "-" + endtday + " 23:59:59' as datetime) ";
            if (orgid != "") str += " and OrgCode='" + orgid + "' ";
            IList<PJ_cqctdjxjh> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_cqctdjxjh>(
               str
                );
            ExportExcel(ex, datalist);
            ex.ShowExcel();
        }
        public void ExportExcelQiuJian(string orgid)
        {


            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\供电所春秋查停电检修计划.xls";
            ex.Open(fname);
            string startmonth = "9", startday = "1", endmonth = "11", endtday = "30";
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select nr  from pj_dyk where  dx='供电所春秋查停电检修计划' and sx like '%{0}%' and nr!=''", "秋查停电检修开始日期"));
            if (list.Count > 0)
            {

                Regex r1 = new Regex(@"[0-9]+(?=月)");
                if (r1.Match(list[0].ToString()).Value != "")
                {
                    startmonth= r1.Match(list[0].ToString()).Value;
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
                    endtday= r1.Match(list[0].ToString()).Value;
                }
            }
            string str = " where 1=1 and  TDtime between '" + DateTime.Now.Year + "-" + startmonth + "-" + startday + " 00:00:00' and  cast('"
                + DateTime.Now.Year + "-" + endmonth + "-" + endtday + " 23:59:59' as datetime) ";
            if (orgid != "") str += " and OrgCode='" + orgid + "' ";
            IList<PJ_cqctdjxjh> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_cqctdjxjh>(
               str
                );
            ExportExcel(ex, datalist);
            ex.ShowExcel();
        }
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public  void ExportExcel(string orgid)
        {
            //lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\供电所春秋查停电检修计划.xls";
            ex.Open(fname);
            string str = " where 1=1 ";
            IList<PJ_cqctdjxjh> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_cqctdjxjh>(
               str
                );
            ExportExcel(ex, datalist);
            ex.ShowExcel();
           
        }
        public void ExportExcelChunQiu(string orgid)
        {
            //lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\供电所春秋查停电检修计划.xls";
            ex.Open(fname);
            string startday = "20";
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select nr from pj_dyk where  dx='供电所春秋查停电检修计划' and sx like '%{0}%' and nr!=''", "申报截止日期"));
            if (list.Count > 0)
                startday=list[0].ToString();
            string str = " where TDtime between '" + DateTime.Now.Year + "-"
                + DateTime.Now.Month + "-" + startday
                + " 00:00:00' and  dateadd(m,1,cast('"
                + DateTime.Now.Year + "-"
                + DateTime.Now.Month + "-" + startday + " 00:00:00' as datetime) ) ";
            IList<PJ_cqctdjxjh> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_cqctdjxjh>(
               str
                );
            ExportExcel(ex, datalist);
            ex.ShowExcel();

        }
        public void ExportExceljhbAllSubmitToWF_ModleRecordWorkTaskIns(string orgid)
        {

            string filter = "";
            int i = 0;
            if (orgid != "") filter = " and OrgCode='" + orgid + "'";
            string startday = "20";
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select nr from pj_dyk where  dx='供电所春秋查停电检修计划' and sx like '%{0}%' and nr!=''", "申报截止日期"));
            if (list.Count > 0)
                startday = list[0].ToString();

             filter = " where TDtime between '" + DateTime.Now.Year + "-"
                 + DateTime.Now.Month + "-" + startday
                 + " 00:00:00' and    dateadd(m,1,cast('"
                + DateTime.Now.Year + "-"
                + DateTime.Now.Month + "-" + startday + " 00:00:00' as datetime) )  and OrgCode='" + orgid + "'";
            if (isWorkflowCall)
            {
                filter = filter + " and (id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowInsId='"
                    + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "') "
                        + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                    + "    RecordID='" + currRecord.ID + "')) "
                    ;
            }
            IList<PJ_cqctdjxjh> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_cqctdjxjh>(
                 filter
                 );
            List<WF_ModleRecordWorkTaskIns> mrwtlist = new List<WF_ModleRecordWorkTaskIns>();
            
            if (isWorkflowCall)
            {
                for (i = 0; i < datalist.Count; i++)
                {

                    WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                    mrwt.ID = mrwt.CreateID();
                    mrwt.ModleRecordID = datalist[i].ID;
                    mrwt.RecordID = currRecord.ID;
                    mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                    mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                    mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                    mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                    mrwt.ModleTableName = datalist[i].GetType().ToString();
                    mrwt.CreatTime = DateTime.Now;
                    Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                    mrwtlist.Add(mrwt);
                }
            }

           


                List<SqlQueryObject> list3 = new List<SqlQueryObject>();
                if (mrwtlist.Count > 0)
                {
                    SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Insert, mrwtlist.ToArray());
                    list3.Add(obj3);
                }

                MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
            }

        
        public void ExportExcelSubmit(ref LP_Temple parentTemple,  string orgid, bool isShow)
        {
            DSOFramerControl dsoFramerWordControl1 = new DSOFramerControl();
            string fname = Application.StartupPath + "\\00记录模板\\供电所春秋查停电检修计划.xls";
            dsoFramerWordControl1.FileOpen(fname);
            string startday = "20";
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
                string.Format("select nr from pj_dyk where  dx='供电所春秋查停电检修计划' and sx like '%{0}%' and nr!=''", "申报截止日期"));
            if (list.Count > 0)
                startday = list[0].ToString();
            if (parentTemple == null)
            {
                parentTemple = new LP_Temple();
                parentTemple.Status = "文档生成";
            }
            parentTemple.DocContent = dsoFramerWordControl1.FileDataGzip;
            dsoFramerWordControl1.FileClose();
            dsoFramerWordControl1.FileDataGzip = parentTemple.DocContent;
            ExcelAccess ex = new ExcelAccess();
            Microsoft.Office.Interop.Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Microsoft.Office.Interop.Excel.Workbook;
            ex.MyWorkBook = wb;
            ex.MyExcel = wb.Application;
            string filter = " where TDtime between '" + DateTime.Now.Year + "-"
                + DateTime.Now.Month + "-" + startday
                + " 00:00:00' and    dateadd(m,1,cast('"
                + DateTime.Now.Year + "-"
                + DateTime.Now.Month + "-" + startday + " 00:00:00' as datetime) )  and OrgCode='" + orgid + "'";
            if (isWorkflowCall)
            {
                filter = filter + " and (id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where WorkFlowId='"
                    + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "') "
                        + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                    + "    RecordID='" + currRecord.ID + "')) "
                    ;
            }
            IList<PJ_cqctdjxjh> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_cqctdjxjh>(
                 filter
                  );
            ExportExcel(ex, datalist);
            if (parentTemple == null)
            {
                parentTemple = new LP_Temple();
                parentTemple.Status = "文档生成";
            }
            dsoFramerWordControl1.FileSave();
            parentTemple.DocContent = dsoFramerWordControl1.FileDataGzip;
            dsoFramerWordControl1.FileClose();
        }
        public void ExportExcel(ExcelAccess ex ,IList<PJ_cqctdjxjh> datalist)
        {
            //此处写填充内容代码
            int row = 8;
            int col = 1;
            int rowcount = 8;

            //

            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(datalist.Count, rowcount))
            {
                pageindex = Ecommon.GetPagecount(datalist.Count, rowcount);
            }
            for (int j = 1; j <= pageindex; j++)
            {
                if (j > 1)
                {
                    ex.CopySheet(1, 1);
                }
            }
            //DateTime dt = DateTime.Now;
            //dt=dt.AddMonths(1);
            //ex.SetCellValue(dt.Year + "年" + (dt.Month) + "月份配电设备停电检修计划表", 1, 1);
        
            for (int j = 0; j < datalist.Count; j++)
            {

                if (j % rowcount == 0)
                {
                    ex.ActiveSheet(j / rowcount + 1);
                    //ex.SetCellValue(datalist[j].OrgName, 2, 3);
                    //ex.SetCellValue(DateTime.Now.Year.ToString(), 2, 9);
                    //ex.SetCellValue(DateTime.Now.Month.ToString(), 2, 11);
                    //ex.SetCellValue(DateTime.Now.Day.ToString(), 2, 13);
                    ex.SetCellValue(DateTime.Now.ToString("yyyy年MM月dd日"), 4, 13);
                }
                ex.SetCellValue((j + 1).ToString(), row + j % rowcount, col);
                ex.SetCellValue(datalist[j].SQOrgname, row + j % rowcount, col + 1);
                ex.SetCellValue(datalist[j].JXSB, row + j % rowcount, col + 2);
                ex.SetCellValue(datalist[j].JXNR, row + j % rowcount, col + 3);
                //停送电时间
                ex.SetCellValue(datalist[j].TDtime.Month.ToString(), row + j % rowcount, col + 4);
                ex.SetCellValue(datalist[j].TDtime.Day.ToString(), row + j % rowcount, col + 5);
                ex.SetCellValue(datalist[j].TDtime.Hour.ToString(), row + j % rowcount, col + 6);
                ex.SetCellValue(datalist[j].TDtime.Minute.ToString(), row + j % rowcount, col + 7);

                ex.SetCellValue(datalist[j].SDtime.Month.ToString(), row + j % rowcount, col + 8);
                ex.SetCellValue(datalist[j].SDtime.Day.ToString(), row + j % rowcount, col + 9);
                ex.SetCellValue(datalist[j].SDtime.Hour.ToString(), row + j % rowcount, col + 10);
                ex.SetCellValue(datalist[j].SDtime.Minute.ToString(), row + j % rowcount, col + 11);
                //配合检修单位
                ex.SetCellValue(datalist[j].ASSOrgname, row + j % rowcount, col + 12);
                ex.SetCellValue(datalist[j].Remark, row + j % rowcount, col + 13);


            }
        }
    
    }
}
