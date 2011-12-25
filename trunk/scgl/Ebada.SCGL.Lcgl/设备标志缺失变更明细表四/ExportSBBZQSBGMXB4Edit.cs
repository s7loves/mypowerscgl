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
namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class ExportSBBZQSBGMXB4Edit
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
        public void ExportExcel(string orgid)
        {
            //lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\设备标志缺失变更明细表四.xls";
            ex.Open(fname);
            string filter= "where 1=1 ";
            if (orgid != "") filter += " and OrgCode='" + orgid + "'";
                IList<PJ_sbbzqsbgmxb4> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sbbzqsbgmxb4>(
                 filter
                 
                   );
                ExportExcel(ex, datalist,orgid);
           
           
            ex.ShowExcel();
           
        }
        public void ExportExcelYear(string orgid,string year)
        {
            ////lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\设备标志缺失变更明细表四.xls";
            ex.Open(fname);
            
            string strfirst = "";
            string filter = "";
            
                filter = "  where 1=1 ";
                if (orgid != "") filter += " and OrgCode='" + orgid + "'";

                if (isWorkflowCall)
                {
                    filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowInsId='"
                        + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "') "
                            + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                        + "    RecordID='" + currRecord.ID + "') "
                        ;
                }
                IList<PJ_sbbzqsbgmxb4> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sbbzqsbgmxb4>(
                 filter
                   );
                ExportExcel(ex, datalist,orgid);
            
          
          

            ex.ShowExcel();
        }
        public void ExportExceljhbAllSubmitToWF_ModleRecordWorkTaskIns(string orgid)
        {

            string filter = "";
            int i = 0;
          
            List<WF_ModleRecordWorkTaskIns> mrwtlist = new List<WF_ModleRecordWorkTaskIns>();
            
                filter = "  where 1=1 ";
                if (orgid != "") filter += " and OrgCode='" + orgid + "'";
                if (isWorkflowCall)
                {
                    filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowInsId='"
                        + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "') "
                            + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                        + "    RecordID='" + currRecord.ID + "') ";
                }
                IList<PJ_sbbzqsbgmxb4> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sbbzqsbgmxb4>(
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
            string fname = Application.StartupPath + "\\00记录模板\\设备标志缺失变更明细表四.xls";
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
           
           
           
                filter = "  where 1=1 ";
                if (orgid != "") filter += " and OrgCode='" + orgid + "'";

                if (isWorkflowCall)
                {
                    filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowInsId='"
                        + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "') "
                            + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                        + "    RecordID='" + currRecord.ID + "') "
                        ;
                }
                IList<PJ_sbbzqsbgmxb4> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sbbzqsbgmxb4>(
                 filter
                   );
                ExportExcel(ex, datalist, orgid);
            
          
            
            //ex.ActiveSheet(1);
            //ex.DeleteWorkSheet(1);
            //Excel.Worksheet sheet;
            //for (int i = 1; i <= wb.Application.Sheets.Count; i++)
            //{
            //    sheet = wb.Application.Sheets[i] as Excel.Worksheet;
            //    sheet.Cells.Clear();
            //    sheet.Cells.ClearContents();
            //    sheet.Cells.ClearOutline();
            //    sheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;
            //    dsoFramerWordControl1.FileSave();

                
            //    break;
            //}
            if (parentTemple == null)
            {
                parentTemple = new LP_Temple();
                parentTemple.Status = "文档生成";
            }
            dsoFramerWordControl1.FileSave();
            parentTemple.DocContent = dsoFramerWordControl1.FileDataGzip;
            dsoFramerWordControl1.FileClose();
        }

        public void ExportExcel(ExcelAccess ex, IList<PJ_sbbzqsbgmxb4> datalist, string orgid)
        {
            //此处写填充内容代码
            int row = 6;
            int col = 1;
            int rowcount = 15;

            //

            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(datalist.Count, rowcount))
            {
                pageindex = Ecommon.GetPagecount(datalist.Count, rowcount);
            }
            for (int j = 1; j <pageindex; j++)
            {

                ex.CopySheet(1, j);
               
            }
            for (int j = 0; j < datalist.Count; j++)
            {

                if (j % rowcount == 0)
                {
                    if(j==0)ex.ActiveSheet(1);
                    else ex.ActiveSheet((j / rowcount+1) );
                    if (orgid!="") ex.SetCellValue(datalist[j].OrgName, 4, 2);
                    else
                        ex.SetCellValue("全局", 4, 2);
                    ex.SetCellValue(DateTime.Now.ToString("yyyy年MM月dd日"), 4,5);

                }
                ex.SetCellValue((j + 1).ToString(), row + j % rowcount, col);
                ex.SetCellValue(datalist[j].sssbmc, row + j % rowcount, col + 1);
                ex.SetCellValue(datalist[j].sssswz, row + j % rowcount, col + 2);

                ex.SetCellValue(datalist[j].sssbbh, row + j % rowcount, col + 3);
                ex.SetCellValue(datalist[j].xw, row + j % rowcount, col + 4);
                ex.SetCellValue(datalist[j].statuts, row + j % rowcount, col + 5);
                ex.SetCellValue(datalist[j].xw, row + j % rowcount, col + 6);
                ex.SetCellValue(datalist[j].hj.Replace(datalist[j].xw,""), row + j % rowcount, col + 7);


            }
        }
    
    }
}
