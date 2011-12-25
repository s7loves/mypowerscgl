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
    public class ExportDYJCZZSZTZEdit
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
            string fname = Application.StartupPath + "\\00记录模板\\电压监测装置设置台帐.xls";
            ex.Open(fname);
           
                IList<PJ_dyjczzsztz> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_dyjczzsztz>(
                   " where OrgCode='" + orgid + "' order by id"
                   );
                ExportExcel(ex, datalist);
            
           
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
                IList<PJ_dyjczzsztz> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_dyjczzsztz>(
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
                


                List<SqlQueryObject> list3 = new List<SqlQueryObject>();
                if (mrwtlist.Count > 0)
                {
                    SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Insert, mrwtlist.ToArray());
                    list3.Add(obj3);
                }
                MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
            }



            
        }


        public void ExportExcelSubmit(ref LP_Temple parentTemple, string orgid, string year, bool isShow)
        {
            DSOFramerControl dsoFramerWordControl1 = new DSOFramerControl();
            string fname = Application.StartupPath + "\\00记录模板\\电压监测装置设置台帐.xls";
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
                    filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowId='"
                        + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "') "
                            + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                        + "    RecordID='" + currRecord.ID + "') "
                        ;
                }
                IList<PJ_dyjczzsztz> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_dyjczzsztz>(
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
        public void ExportExcel(ExcelAccess ex, IList<PJ_dyjczzsztz> datalist)
        {
            //此处写填充内容代码
            int row = 5;
            int col = 1;
            int rowcount = 18;

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
                    else ex.ActiveSheet(j / rowcount + 1);
                    ex.SetCellValue(datalist[j].OrgName, 3, 6);
                    //ex.SetCellValue(datalist[0].OrgName.Trim() + datalist[0].indate.ToString("yyyy年") + "生产台账", 1, 1);

                }
                ex.SetCellValue((j + 1).ToString(), row + j % rowcount, col);
                ex.SetCellValue(datalist[j].zzszwz, row + j % rowcount, col + 1);
                ex.SetCellValue(datalist[j].zzVol, row + j % rowcount, col + 2);
                
                ex.SetCellValue(datalist[j].zzdlb, row + j % rowcount, col + 3);
                ex.SetCellValue(datalist[j].zzxh, row + j % rowcount, col + 4);
                ex.SetCellValue(datalist[j].zzFactory, row + j % rowcount, col + 5);
                ex.SetCellValue(datalist[j].jddate.ToString("yyyy年MM月dd日"), row + j % rowcount, col + 6);
                ex.SetCellValue(datalist[j].zdz, row + j % rowcount, col + 7);
                ex.SetCellValue(datalist[j].cjfs, row + j % rowcount, col + 8);
                ex.SetCellValue(datalist[j].Remark, row + j % rowcount, col + 9);
                //ex.SetCellValue(datalist[j].zrr, row + j % rowcount, col + 7);


            }
        }
    }
}
