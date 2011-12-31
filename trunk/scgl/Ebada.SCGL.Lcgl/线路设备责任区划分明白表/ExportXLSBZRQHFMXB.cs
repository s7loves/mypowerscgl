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
    public class ExportXLSBZRQHFMXB
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
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        public  void ExportExcel(string orgid)
        {
            //lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\线路设备责任区划分明白表.xls";
            ex.Open(fname);
            string sdtrorg=" ";
            if (orgid != "")
            {
                
                sdtrorg += "  and OrgCode='" + orgid + "'";
            }
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct zrr  from PJ_xlsbzrqhfmbb where  1=1 " + sdtrorg);
            foreach (string mc in mclist)
            {
                string str = " where 1=1 and zrr='"+mc+"' ";
                if (orgid != "")
                {
                    str += "  and OrgCode='" + orgid + "'";
                }
                IList<PJ_xlsbzrqhfmbb> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_xlsbzrqhfmbb>(
                   str
                    );
                ExportExcel(ex, datalist,mc);
            }
            ex.DeleteSheet(1);
            ex.ShowExcel();
           
        }
        
        public void ExportExceljhbAllSubmitToWF_ModleRecordWorkTaskIns(string orgid)
        {

            string filter = "";
            int i = 0;


            string sdtrorg = " ";
            if (orgid != "")
            {

                sdtrorg += "  and OrgCode='" + orgid + "'";
            }
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct zrr  from PJ_xlsbzrqhfmbb where  1=1 " + sdtrorg);
            List<WF_ModleRecordWorkTaskIns> mrwtlist = new List<WF_ModleRecordWorkTaskIns>();
            foreach (string mc in mclist)
            {
                filter = " where 1=1 and zrr='" + mc + "' ";
                if (orgid != "") filter = " and OrgCode='" + orgid + "'";
                if (isWorkflowCall)
                {
                    filter = filter + " and (id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowInsId='"
                        + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "') "
                            + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                        + "    RecordID='" + currRecord.ID + "')) "
                        ;
                }

                IList<PJ_xlsbzrqhfmbb> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_xlsbzrqhfmbb>(
                     filter
                     );
                

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
            string fname = Application.StartupPath + "\\00记录模板\\线路设备责任区划分明白表.xls";
            dsoFramerWordControl1.FileOpen(fname);
            
        
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
           string filter = "";
            int i = 0;


            string sdtrorg = " ";
            if (orgid != "")
            {

                sdtrorg += "  and OrgCode='" + orgid + "'";
            }
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct zrr  from PJ_xlsbzrqhfmbb where  1=1 " + sdtrorg);
            List<WF_ModleRecordWorkTaskIns> mrwtlist = new List<WF_ModleRecordWorkTaskIns>();
            foreach (string mc in mclist)
            {
                filter = " where 1=1 and zrr='" + mc + "' ";
                if (orgid != "") filter = " and OrgCode='" + orgid + "'";
                if (isWorkflowCall)
                {
                    filter = filter + " and (id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowInsId='"
                        + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "') "
                            + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                        + "    RecordID='" + currRecord.ID + "')) "
                        ;
                }

                IList<PJ_xlsbzrqhfmbb> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_xlsbzrqhfmbb>(
                     filter
                     );
                ExportExcel(ex, datalist,mc);
            }
            ex.DeleteSheet(1);
            if (parentTemple == null)
            {
                parentTemple = new LP_Temple();
                parentTemple.Status = "文档生成";
            }
            dsoFramerWordControl1.FileSave();
            parentTemple.DocContent = dsoFramerWordControl1.FileDataGzip;
            dsoFramerWordControl1.FileClose();
        }
        public void ExportExcel(ExcelAccess ex, IList<PJ_xlsbzrqhfmbb> datalist, string wpmc)
        {
            //此处写填充内容代码
            int row = 5;
            int col = 1;
            int rowcount = 6;
            int rowspan = 8;


            //

            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(datalist.Count, rowcount))
            {
                pageindex = Ecommon.GetPagecount(datalist.Count, rowcount);
            }
            //for (int j = 1; j <= pageindex; j++)
            //{
            //    if (j > 1)
            //    {
            //        ex.CopySheet(1, 1);
            //    }
            //}
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;
            for (int j = 1; j <= pageindex; j++)
            {

                ex.CopySheet(1, wb.Application.Worksheets.Count);
                if (j == 1) ex.ReNameWorkSheet( wb.Application.Worksheets.Count, wpmc);
                else
                    ex.ReNameWorkSheet( wb.Application.Worksheets.Count, wpmc + (j));
            }
            //DateTime dt = DateTime.Now;
            //dt=dt.AddMonths(1);
            //ex.SetCellValue(dt.Year + "年" + (dt.Month) + "月份配电设备停电检修计划表", 1, 1);
        
            for (int j = 0; j < datalist.Count; j++)
            {

                if (j % rowcount == 0)
                {
                    if (j == 0) ex.ActiveSheet(wpmc);
                    else ex.ActiveSheet(wpmc + (j / rowcount + 1));
                    //ex.SetCellValue(datalist[j].OrgName, 2, 3);
                    //ex.SetCellValue(DateTime.Now.Year.ToString(), 2, 9);
                    //ex.SetCellValue(DateTime.Now.Month.ToString(), 2, 11);
                    //ex.SetCellValue(DateTime.Now.Day.ToString(), 2, 13);
                    ex.SetCellValue(DateTime.Now.ToString("yyyy年MM月dd日"), 4, 13);
                }
               
                ex.SetCellValue(datalist[j].jsxl, row + j % rowcount, col );
                ex.SetCellValue(datalist[j].zjxl, row + j % rowcount, col + 1);

                ex.SetCellValue(datalist[j].gytq, row + j % rowcount + rowspan, col);
                ex.SetCellValue(datalist[j].zytq, row + j % rowcount + rowspan, col + 1);
                ////停送电时间
                //ex.SetCellValue(datalist[j].TDtime.Month.ToString(), row + j % rowcount, col + 4);
                //ex.SetCellValue(datalist[j].TDtime.Day.ToString(), row + j % rowcount, col + 5);
                //ex.SetCellValue(datalist[j].TDtime.Hour.ToString(), row + j % rowcount, col + 6);
                //ex.SetCellValue(datalist[j].TDtime.Minute.ToString(), row + j % rowcount, col + 7);

                //ex.SetCellValue(datalist[j].SDtime.Month.ToString(), row + j % rowcount, col + 8);
                //ex.SetCellValue(datalist[j].SDtime.Day.ToString(), row + j % rowcount, col + 9);
                //ex.SetCellValue(datalist[j].SDtime.Hour.ToString(), row + j % rowcount, col + 10);
                //ex.SetCellValue(datalist[j].SDtime.Minute.ToString(), row + j % rowcount, col + 11);
                ////配合检修单位
                //ex.SetCellValue(datalist[j].ASSOrgname, row + j % rowcount, col + 12);
                //ex.SetCellValue(datalist[j].Remark, row + j % rowcount, col + 13);


            }
        }
    
    }
}
