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
namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class ExportFSCTZEdit
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
        public void ExportExcel(string orgid, string year)
        {
            //lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\非生产台账.xls";
            ex.Open(fname);
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_fsctz order by wpmc");
            string  strfirst = "";
            foreach (string mc in mclist)
            {
                IList<PJ_fsctz> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_fsctz>(
                   " where CONVERT(varchar(50) , indate, 112 )   like '" + year + "%' and wpmc='" + mc + "'"
                   + " and OrgCode='" + orgid + "' order by wpmc"
                   );
                ExportExcel(ex, datalist, mc);
            }
            ex.DeleteSheet(1);
            ex.ShowExcel();
           
        }
        public void ExportExcelYear(string orgid, string year)
        {
            ////lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\生产台账.xls";
            ex.Open(fname);
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_sctz order by wpmc");
            string strfirst = "";
            string filter = "";
            foreach (string mc in mclist)
            {
                filter = "  where CONVERT(varchar(50) , indate, 112 )   like '" + year + "%' and wpmc='" + mc + "'";
                if (orgid != "") filter += " and OrgCode='" + orgid + "'";

                if (isWorkflowCall)
                {
                    filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowInsId='"
                        + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "') "
                            + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                        + "    RecordID='" + currRecord.ID + "') "
                        ;
                }
                IList<PJ_sctz> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sctz>(
                 filter
                   );
                ExportExcel(ex, datalist, mc);
            }
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_fsctz order by wpmc");
            strfirst = "";
            foreach (string mc in mclist)
            {
                filter = "  where CONVERT(varchar(50) , indate, 112 )   like '" + year + "%' and wpmc='" + mc + "'";
                if (orgid != "") filter += " and OrgCode='" + orgid + "'";

                if (isWorkflowCall)
                {
                    filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowInsId='"
                        + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "') "
                            + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                        + "    RecordID='" + currRecord.ID + "') "
                        ;
                }
                IList<PJ_fsctz> datalist2 = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_fsctz>(
                 filter
                   );
                ExportExcel(ex, datalist2, mc);
            }
            ex.DeleteSheet(1);

        }
        public void ExportExceljhbAllSubmitToWF_ModleRecordWorkTaskIns(string orgid,string year)
        {

            string filter = "";
            int i = 0;
            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_sctz order by wpmc");

            List<WF_ModleRecordWorkTaskIns> mrwtlist = new List<WF_ModleRecordWorkTaskIns>();
            foreach (string mc in mclist)
            {
                filter = "  where CONVERT(varchar(50) , indate, 112 )   like '" + year + "%' and wpmc='" + mc + "'";
                if (orgid != "") filter += " and OrgCode='" + orgid + "'";
                if (isWorkflowCall)
                {
                    filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowInsId='"
                        + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "') "
                            + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                        + "    RecordID='" + currRecord.ID + "') ";
                }
                IList<PJ_sctz> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sctz>(
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
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_fsctz order by wpmc");


            foreach (string mc in mclist)
            {
                filter = "  where CONVERT(varchar(50) , indate, 112 )   like '" + year + "%' and wpmc='" + mc + "'";
                if (orgid != "") filter += " and OrgCode='" + orgid + "'";
                if (isWorkflowCall)
                {
                    filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowInsId='"
                        + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "') "
                            + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                        + "    RecordID='" + currRecord.ID + "') ";
                }
                IList<PJ_fsctz> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_fsctz>(
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


        public void ExportExcelSubmit(ref LP_Temple parentTemple, string orgid, string year, bool isShow)
        {
            DSOFramerControl dsoFramerWordControl1 = new DSOFramerControl();
            string fname = Application.StartupPath + "\\00记录模板\\非生产台账.xls";
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

            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_sctz order by wpmc");

            foreach (string mc in mclist)
            {
                filter = "  where CONVERT(varchar(50) , indate, 112 )   like '" + year + "%' and wpmc='" + mc + "'";
                if (orgid != "") filter += " and OrgCode='" + orgid + "'";

                if (isWorkflowCall)
                {
                    filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowInsId='"
                        + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "') "
                            + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                        + "    RecordID='" + currRecord.ID + "') "
                        ;
                }
                IList<PJ_sctz> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_sctz>(
                 filter
                   );
                ExportExcel(ex, datalist, mc);
            }
            mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_fsctz order by wpmc");

            foreach (string mc in mclist)
            {
                filter = "  where CONVERT(varchar(50) , indate, 112 )   like '" + year + "%' and wpmc='" + mc + "'";
                if (orgid != "") filter += " and OrgCode='" + orgid + "'";

                if (isWorkflowCall)
                {
                    filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowInsId='"
                        + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "') "
                            + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                        + "    RecordID='" + currRecord.ID + "') "
                        ;
                }
                IList<PJ_fsctz> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_fsctz>(
                 filter
                   );
                ExportExcel(ex, datalist, mc);
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
        public void ExportExcel(ExcelAccess ex ,IList<PJ_fsctz> datalist,string wpmc)
        {
            //此处写填充内容代码
            int row = 5;
            int col = 1;
            int rowcount = 30;

            //

            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(datalist.Count, rowcount))
            {
                pageindex = Ecommon.GetPagecount(datalist.Count, rowcount);
            }
            for (int j = 1; j <= pageindex; j++)
            {

                ex.CopySheet(1, j);
                if(j==1)ex.ReNameWorkSheet(j + 1, wpmc );
                else
                    ex.ReNameWorkSheet(j + 1, wpmc + (j ));
            }
            for (int j = 0; j < datalist.Count; j++)
            {

                if (j % rowcount == 0)
                {
                    if(j==0)ex.ActiveSheet(wpmc);
                    else ex.ActiveSheet(wpmc+(j / rowcount+1) );
                    ex.SetCellValue(datalist[j].OrgName, 2, 2);
                    ex.SetCellValue(datalist[0].OrgName.Trim() + datalist[0].indate.ToString("yyyy年") + "非生产台账", 1, 1);

                }
                ex.SetCellValue((j + 1).ToString(), row + j % rowcount, col);
                ex.SetCellValue(datalist[j].wpmc, row + j % rowcount, col + 1);
                ex.SetCellValue(datalist[j].wpgg, row + j % rowcount, col + 2);

                ex.SetCellValue(datalist[j].wpdw, row + j % rowcount, col + 3);
                ex.SetCellValue(datalist[j].wpsl, row + j % rowcount, col + 4);
                ex.SetCellValue(datalist[j].indate.ToString("yyyy年MM月dd日"), row + j % rowcount, col + 5);
                ex.SetCellValue(datalist[j].Remark, row + j % rowcount, col + 6);
                //ex.SetCellValue(datalist[j].zrr, row + j % rowcount, col + 7);


            }
        }
        public void ExportExcel(ExcelAccess ex, IList<PJ_sctz> datalist, string wpmc)
        {
            //此处写填充内容代码
            int row = 5;
            int col = 1;
            int rowcount = 30;

            //

            //加页
            int pageindex = 1;
            if (pageindex < Ecommon.GetPagecount(datalist.Count, rowcount))
            {
                pageindex = Ecommon.GetPagecount(datalist.Count, rowcount);
            }
            for (int j = 1; j <= pageindex; j++)
            {

                ex.CopySheet(1, j);
                if (j == 1) ex.ReNameWorkSheet(j + 1, wpmc);
                else
                    ex.ReNameWorkSheet(j + 1, wpmc + (j));
            }
            for (int j = 0; j < datalist.Count; j++)
            {

                if (j % rowcount == 0)
                {
                    if (j == 0) ex.ActiveSheet(wpmc);
                    else ex.ActiveSheet(wpmc + (j / rowcount + 1));
                    ex.SetCellValue(datalist[j].OrgName, 2, 2);
                    ex.SetCellValue(datalist[0].OrgName.Trim() + datalist[0].indate.ToString("yyyy年") + "生产台账", 1, 1);

                }
                ex.SetCellValue((j + 1).ToString(), row + j % rowcount, col);
                ex.SetCellValue(datalist[j].wpmc, row + j % rowcount, col + 1);
                ex.SetCellValue(datalist[j].wpgg, row + j % rowcount, col + 2);

                ex.SetCellValue(datalist[j].wpdw, row + j % rowcount, col + 3);
                ex.SetCellValue(datalist[j].wpsl, row + j % rowcount, col + 4);
                ex.SetCellValue(datalist[j].indate.ToString("yyyy年MM月dd日"), row + j % rowcount, col + 5);
                ex.SetCellValue(datalist[j].Remark, row + j % rowcount, col + 6);
                //ex.SetCellValue(datalist[j].zrr, row + j % rowcount, col + 7);


            }
        }
    }
}
