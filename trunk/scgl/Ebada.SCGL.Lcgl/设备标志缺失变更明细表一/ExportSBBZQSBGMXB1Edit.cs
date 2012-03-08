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
    public class ExportSBBZQSBGMXB1Edit
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
            string fname = Application.StartupPath + "\\00记录模板\\设备标志缺失变更明细表一.xls";
            ex.Open(fname);
            string filter= "where 1=1 ";
            if (orgid != "") filter += " and OrgCode='" + orgid + "'";
                IList<PJ_sbbzqsbgmxb1> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sbbzqsbgmxb1>(
                 filter
                 
                   );
                ExportExcel(ex, datalist, orgid, "设备标志缺失变更明细表一");
           
           
            ex.ShowExcel();
           
        }
        public void ExportExcelYear(string orgid,string year)
        {
            ////lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\设备标志缺失变更明细表一.xls";
            ex.Open(fname);
            
            string strfirst = "";
            string filter = "";
            
                filter = "  where 1=1 ";
                if (orgid != "") filter += " and OrgCode='" + orgid + "'";

                if (isWorkflowCall)
                {
                    filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowId='"
                        + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "') "
                            + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                        + "    RecordID='" + currRecord.ID + "') "
                        ;
                }
                IList<PJ_sbbzqsbgmxb1> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sbbzqsbgmxb1>(
                 filter
                   );
                ExportExcel(ex, datalist, orgid, "设备标志缺失变更明细表一");
            
          
          

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
                    filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowId='"
                        + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "') "
                            + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                        + "    RecordID='" + currRecord.ID + "') ";
                }
                Object datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sbbzqsbgmxb1>(
                 filter
                   );
                if (isWorkflowCall)
                {
                    for (i = 0; i < ((IList)datalist).Count; i++)
                    {
                        WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                        mrwt.ID = mrwt.CreateID();
                        mrwt.ModleRecordID = (((IList<PJ_sbbzqsbgmxb1>)datalist)[i]).ID;
                        mrwt.RecordID = currRecord.ID;
                        mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                        mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                        mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                        mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                        mrwt.ModleTableName = (((IList<PJ_sbbzqsbgmxb1>)datalist)[i]).GetType().ToString();
                        mrwt.CreatTime = DateTime.Now;
                        Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                        mrwtlist.Add(mrwt);
                    }
                }
                datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sbbzqsbgmxb2>(
                 filter
                   );
                if (isWorkflowCall)
                {
                    for (i = 0; i < ((IList)datalist).Count; i++)
                    {
                        WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                        mrwt.ID = mrwt.CreateID();
                        mrwt.ModleRecordID = (((IList<PJ_sbbzqsbgmxb2>)datalist)[i]).ID;
                        mrwt.RecordID = currRecord.ID;
                        mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                        mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                        mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                        mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                        mrwt.ModleTableName = (((IList<PJ_sbbzqsbgmxb2>)datalist)[i]).GetType().ToString();
                        mrwt.CreatTime = DateTime.Now;
                        Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                        mrwtlist.Add(mrwt);
                    }
                }
                datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sbbzqsbgmxb3>(
                 filter
                   );
                if (isWorkflowCall)
                {
                    for (i = 0; i < ((IList)datalist).Count; i++)
                    {
                        WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                        mrwt.ID = mrwt.CreateID();
                        mrwt.ModleRecordID = (((IList<PJ_sbbzqsbgmxb3>)datalist)[i]).ID;
                        mrwt.RecordID = currRecord.ID;
                        mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                        mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                        mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                        mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                        mrwt.ModleTableName = (((IList<PJ_sbbzqsbgmxb3>)datalist)[i]).GetType().ToString();
                        mrwt.CreatTime = DateTime.Now;
                        Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                        mrwtlist.Add(mrwt);
                    }
                }
                datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sbbzqsbgmxb4>(
                 filter
                   );
                if (isWorkflowCall)
                {
                    for (i = 0; i < ((IList)datalist).Count; i++)
                    {
                        WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                        mrwt.ID = mrwt.CreateID();
                        mrwt.ModleRecordID = (((IList<PJ_sbbzqsbgmxb4>)datalist)[i]).ID;
                        mrwt.RecordID = currRecord.ID;
                        mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                        mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                        mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                        mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                        mrwt.ModleTableName = (((IList<PJ_sbbzqsbgmxb4>)datalist)[i]).GetType().ToString();
                        mrwt.CreatTime = DateTime.Now;
                        Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                        mrwtlist.Add(mrwt);
                    }
                }
                datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sbbzqsbgmxb5>(
                 filter
                   );
                if (isWorkflowCall)
                {
                    for (i = 0; i < ((IList)datalist).Count; i++)
                    {
                        WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                        mrwt.ID = mrwt.CreateID();
                        mrwt.ModleRecordID = (((IList<PJ_sbbzqsbgmxb5>)datalist)[i]).ID;
                        mrwt.RecordID = currRecord.ID;
                        mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                        mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                        mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                        mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                        mrwt.ModleTableName = (((IList<PJ_sbbzqsbgmxb5>)datalist)[i]).GetType().ToString();
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
            string fname = Application.StartupPath + "\\00记录模板\\设备标志缺失变更明细表.xls";
            dsoFramerWordControl1.FileOpen(fname);

            if (parentTemple == null)
            {
                parentTemple = new LP_Temple();
                parentTemple.Status = "文档生成";
            }
            parentTemple.DocContent = dsoFramerWordControl1.FileDataGzip;
            dsoFramerWordControl1.FileSave();
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
                    filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowId='"
                        + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "') "
                            + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                        + "    RecordID='" + currRecord.ID + "') "
                        ;
                }
               Object datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sbbzqsbgmxb1>(
                 filter
                   );
                ExportExcel(ex, datalist, orgid, "设备标志缺失变更明细表一");
                datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sbbzqsbgmxb2>(
                    filter
                      );
                ExportExcel(ex, datalist, orgid, "设备标志缺失变更明细表二");
                datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sbbzqsbgmxb3>(
                    filter
                      );
                ExportExcel(ex, datalist, orgid, "设备标志缺失变更明细表三");
                datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sbbzqsbgmxb4>(
                    filter
                      );
                ExportExcel(ex, datalist, orgid, "设备标志缺失变更明细表四");

                datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sbbzqsbgmxb5>(
                    filter
                      );
                ExportExcel(ex, datalist, orgid, "设备标志缺失变更明细表五");
          
          
            
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
            dsoFramerWordControl1.FileSave();
            dsoFramerWordControl1.FileClose();
        }

        public void ExportExcel(ExcelAccess ex, Object datalist, string orgid, string sheetname)
        {
            //此处写填充内容代码
            int row = 6;
            int col = 1;
            int rowcount = 2;
            int i = 0, sheetindex = 0;
            //
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;
            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(((IList)datalist).Count, rowcount))
            {
                pageindex = Ecommon.GetPagecount(((IList)datalist).Count, rowcount);
            }
            for (i = 1; i <= wb.Application.Worksheets.Count; i++)
            {
                Excel.Worksheet sheet = wb.Application.Worksheets[i] as Excel.Worksheet;
                if (sheet.Name == sheetname)
                {
                    sheetindex = sheet.Index;
                    break;
                }
            }
            int itemp = sheetindex;
            //for (int j = 1; j <pageindex; j++)
            //{

            //    ex.CopySheet(1, j);
               
            //}
            for (i = 1; i < pageindex; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp + 1, sheetname + (i + 1));
                itemp++;

            }
            for (int j = 0; j < ((IList)datalist).Count; j++)
            {

                if (j % rowcount == 0)
                {
                    if (j == 0) ex.ActiveSheet(sheetname);
                    else ex.ActiveSheet(sheetname+(j / rowcount + 1));

                    if (orgid != "")
                    {
                        if (datalist is IList<PJ_sbbzqsbgmxb1>)
                        {
                            ex.SetCellValue(((PJ_sbbzqsbgmxb1)((IList)datalist)[j]).OrgName, 4, 2);
                        }
                        else if (datalist is IList<PJ_sbbzqsbgmxb2>)
                        {
                            ex.SetCellValue(((PJ_sbbzqsbgmxb2)((IList)datalist)[j]).OrgName, 4, 2);
                        }
                        else if (datalist is IList<PJ_sbbzqsbgmxb3>)
                        {
                            ex.SetCellValue(((PJ_sbbzqsbgmxb3)((IList)datalist)[j]).OrgName, 4, 2);
                        }
                        else if (datalist is IList<PJ_sbbzqsbgmxb4>)
                        {
                            ex.SetCellValue(((PJ_sbbzqsbgmxb4)((IList)datalist)[j]).OrgName, 4, 2);
                        }
                        else if (datalist is IList<PJ_sbbzqsbgmxb5>)
                        {
                            ex.SetCellValue(((PJ_sbbzqsbgmxb5)((IList)datalist)[j]).OrgName, 4, 2);
                        }

                    }

                    else
                        ex.SetCellValue("全局", 4, 2);
                  
                    ex.SetCellValue(DateTime.Now.ToString("yyyy年MM月dd日"), 4,5);

                }
                
                ex.SetCellValue((j + 1).ToString(), row + j % rowcount, col);
                if (datalist is IList<PJ_sbbzqsbgmxb1>)
                {

                    ex.SetCellValue(((PJ_sbbzqsbgmxb1)((IList)datalist)[j]).sssbmc, row + j % rowcount, col + 1);
                    ex.SetCellValue(((PJ_sbbzqsbgmxb1)((IList)datalist)[j]).sssswz, row + j % rowcount, col + 2);

                    ex.SetCellValue(((PJ_sbbzqsbgmxb1)((IList)datalist)[j]).sssbbh, row + j % rowcount, col + 3);
                    ex.SetCellValue(((PJ_sbbzqsbgmxb1)((IList)datalist)[j]).statuts, row + j % rowcount, col + 4);
                    ex.SetCellValue(((PJ_sbbzqsbgmxb1)((IList)datalist)[j]).Remark, row + j % rowcount, col + 5);
                }
                else
                    if (datalist is IList<PJ_sbbzqsbgmxb2>)
                    {

                        ex.SetCellValue(((PJ_sbbzqsbgmxb2)((IList)datalist)[j]).sssbmc, row + j % rowcount, col + 1);
                        ex.SetCellValue(((PJ_sbbzqsbgmxb2)((IList)datalist)[j]).sssswz, row + j % rowcount, col + 2);

                        ex.SetCellValue(((PJ_sbbzqsbgmxb2)((IList)datalist)[j]).sssbbh, row + j % rowcount, col + 3);
                        ex.SetCellValue(((PJ_sbbzqsbgmxb2)((IList)datalist)[j]).statuts, row + j % rowcount, col + 4);
                        ex.SetCellValue(((PJ_sbbzqsbgmxb2)((IList)datalist)[j]).Remark, row + j % rowcount, col + 5);
                    }
                    else
                        if (datalist is IList<PJ_sbbzqsbgmxb3>)
                        {

                            ex.SetCellValue(((PJ_sbbzqsbgmxb3)((IList)datalist)[j]).sssbmc, row + j % rowcount, col + 1);
                            ex.SetCellValue(((PJ_sbbzqsbgmxb3)((IList)datalist)[j]).sssswz, row + j % rowcount, col + 2);

                            ex.SetCellValue(((PJ_sbbzqsbgmxb3)((IList)datalist)[j]).sssbbh, row + j % rowcount, col + 3);
                            ex.SetCellValue(((PJ_sbbzqsbgmxb3)((IList)datalist)[j]).statuts, row + j % rowcount, col + 4);
                            ex.SetCellValue(((PJ_sbbzqsbgmxb3)((IList)datalist)[j]).Remark, row + j % rowcount, col + 5);
                        }

                        else
                            if (datalist is IList<PJ_sbbzqsbgmxb4>)
                            {

                                ex.SetCellValue(((PJ_sbbzqsbgmxb4)((IList)datalist)[j]).sssbmc, row + j % rowcount, col + 1);
                                ex.SetCellValue(((PJ_sbbzqsbgmxb4)((IList)datalist)[j]).sssswz, row + j % rowcount, col + 2);

                                ex.SetCellValue(((PJ_sbbzqsbgmxb4)((IList)datalist)[j]).sssbbh, row + j % rowcount, col + 3);
                                ex.SetCellValue(((PJ_sbbzqsbgmxb4)((IList)datalist)[j]).statuts, row + j % rowcount, col + 4);
                                ex.SetCellValue(((PJ_sbbzqsbgmxb4)((IList)datalist)[j]).statuts, row + j % rowcount, col + 5);
                                ex.SetCellValue(((PJ_sbbzqsbgmxb4)((IList)datalist)[j]).xw, row + j % rowcount, col + 6);
                                ex.SetCellValue(((PJ_sbbzqsbgmxb4)((IList)datalist)[j]).hj.Replace(((PJ_sbbzqsbgmxb4)((IList)datalist)[j]).xw, ""), row + j % rowcount, col + 7);
                            }

                            else
                                if (datalist is IList<PJ_sbbzqsbgmxb5>)
                                {

                                    ex.SetCellValue(((PJ_sbbzqsbgmxb5)((IList)datalist)[j]).sssbmc, row + j % rowcount, col + 1);
                                    ex.SetCellValue(((PJ_sbbzqsbgmxb5)((IList)datalist)[j]).sssswz, row + j % rowcount, col + 2);

                                    ex.SetCellValue(((PJ_sbbzqsbgmxb5)((IList)datalist)[j]).sssbbh, row + j % rowcount, col + 3);
                                    ex.SetCellValue(((PJ_sbbzqsbgmxb5)((IList)datalist)[j]).statuts, row + j % rowcount, col + 4);
                                    ex.SetCellValue(((PJ_sbbzqsbgmxb5)((IList)datalist)[j]).statuts, row + j % rowcount, col + 5);
                                    ex.SetCellValue(((PJ_sbbzqsbgmxb5)((IList)datalist)[j]).xw, row + j % rowcount, col + 6);
                                    ex.SetCellValue(((PJ_sbbzqsbgmxb5)((IList)datalist)[j]).hj.Replace(((PJ_sbbzqsbgmxb4)((IList)datalist)[j]).xw, ""), row + j % rowcount, col + 7);
                                }


                //ex.SetCellValue(datalist[j].zrr, row + j % rowcount, col + 7);


            }
        }
    
    }
}
