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
    public class ExportCLRKYSEdit
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
            ////lgm
            //ExcelAccess ex = new ExcelAccess();
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //string fname = Application.StartupPath + "\\00记录模板\\材料入库单.xls";
            //ex.Open(fname);
            //IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_clrkysd order by wpmc");
            //string  strfirst = "",str="";
            //foreach (string mc in mclist)
            //{
            //    if (year == "全部")
            //        str = "  where 1=1 and wpmc='" + mc + "' ";
            //    else
            //        str = " where CONVERT(varchar(50) , indate, 112 )   like '" + year + "%' and wpmc='" + mc + "' ";
            //    if (orgid != "")
            //        str+= " and OrgCode='" + orgid + "' ";

            //    str +=  "' order by wpmc";
            //    IList<PJ_clrkysd> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_clrkysd>(
            //      str
            //       );
            //    ExportExcel(ex, datalist);
            //}
            //ex.DeleteSheet(1);
            //ex.ShowExcel();

        }
        public void ExportExcelProjectCKD(string orgid, string strProject, string strfenProject)
        {
            ////lgm
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\验收单.xls";
            ex.Open(fname);
            string strfirst = "";
            string filter = "";
            string filter2 = "";
            string filter3 = "";
            string filter4 = "";
            if (strProject != "全部")
                filter2 = "  where 1=1 and ssgc='" + strProject + "'  ";
            else
                filter2 = "  where 1=1  ";

            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct ssgc  from PJ_clrkysd " + filter2 + " order by ssgc");
            
            foreach (string mc in mclist)
            {
                if (strfenProject == "全部")
                    filter3 = "  where 1=1 ";
                else
                    filter3 = "  where  ssxm='" + strfenProject + "'  ";

                IList xmlist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct ssxm  from PJ_clrkysd " + filter3 + " order by ssxm");
                foreach (string xm in xmlist)
                {
                    filter4 = "  where 1=1"
                        + "  and ssgc='" + mc + "' "
                        +"  and ssxm='" + xm + "' ";
                    IList sjlist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct dhht  from PJ_clrkysd " + filter4 + " ");
                    foreach (string sj in sjlist)
                    {
                        filter = "  where 1=1"
                        + "  and ssgc='" + mc + "' "
                        + "  and ssxm='" + xm
                        + "' and  dhht='" + sj + "' ";
                        if (isWorkflowCall)
                        {
                          
                            filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowId='"
                                + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "') "
                                    + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                                + "    RecordID='" + currRecord.ID + "') "
                                ;
                        }

                        IList<PJ_clrkysd> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_clrkysd>(
                         filter
                           );
                        ExportExcel(ex, datalist);
                    }
                }

            }


            ex.DeleteSheet(1);
            ex.ShowExcel();
        }
        public void ExportExcelYear(string orgid,string year)
        {
            //////lgm
            //ExcelAccess ex = new ExcelAccess();
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //string fname = Application.StartupPath + "\\00记录模板\\验收单.xls";
            //ex.Open(fname);
            //IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_clrkysd order by wpmc");
            //string strfirst = "";
            //string filter = "";
            //foreach (string mc in mclist)
            //{
            //    if (year=="全部")
            //        filter = "  where 1=1 and wpmc='" + mc + "'  and type = '入库单' ";
            //    else
            //        filter = "  where CONVERT(varchar(50) , indate, 112 )   like '" + year + "%' and wpmc='" + mc + "'  and type = '入库单' ";

            //    if (orgid != "") filter += " and OrgCode='" + orgid + "'";

            //    if (isWorkflowCall)
            //    {
            //        filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowId='"
            //            + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "') "
            //                + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
            //            + "    RecordID='" + currRecord.ID + "') "
            //            ;
            //    }
            //    IList<PJ_clrkysd> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_clrkysd>(
            //     filter
            //       );
            //    ExportExcel(ex, datalist);
            //} 
            //mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct wpmc  from PJ_fsctz order by wpmc");
            //strfirst = "";
            //foreach (string mc in mclist)
            //{
            //    filter = "  where 1=1 and wpmc='" + mc + "' and type = '入库单' ";
            //    if (year != "全部") filter += " and CONVERT(varchar(50) , indate, 112 )   like '" + year + "%' and type = '入库单' ";
                
            //    if (orgid != "") filter += " and OrgCode='" + orgid + "'";

            //    if (isWorkflowCall)
            //    {
            //        filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowId='"
            //            + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "') "
            //                + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
            //            + "    RecordID='" + currRecord.ID + "') "
            //            ;
            //    }
            //    IList<PJ_fsctz> datalist2 = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_fsctz>(
            //     filter
            //       );
            //    ExportExcel(ex, datalist2, mc);
            //}
            //ex.DeleteSheet(1);

            //ex.ShowExcel();
        }
        public void ExportExceljhbAllSubmitToWF_ModleRecordWorkTaskIns(string orgid, string strProject, string strfenProject)
        {

            string filter = "";
            int i = 0;
            List<WF_ModleRecordWorkTaskIns> mrwtlist = new List<WF_ModleRecordWorkTaskIns>();
            string strfirst = "";
            string filter2 = "";
            string filter3 = "";
            string filter4 = "";
            if (strProject != "全部")
                filter2 = "  where 1=1 and ssgc='" + strProject + "'  ";
            else
                filter2 = "  where 1=1  ";

            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct ssgc  from PJ_clrkysd " + filter2 + " order by ssgc");

            foreach (string mc in mclist)
            {
                if (strfenProject == "全部")
                    filter3 = "  where 1=1 ";
                else
                    filter3 = "  where  ssxm='" + strfenProject + "'  ";

                IList xmlist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct ssxm  from PJ_clrkysd " + filter3 + " order by ssxm");
                foreach (string xm in xmlist)
                {
                    filter4 = "  where 1=1"
                        + "  and ssgc='" + mc + "' "
                        + "  and ssxm='" + xm + "' ";
                    IList sjlist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct dhht  from PJ_clrkysd " + filter4 + " ");
                    foreach (string sj in sjlist)
                    {
                        filter = "  where 1=1"
                        + "  and ssgc='" + mc + "' "
                        + "  and ssxm='" + xm
                        + "' and  dhht='" + sj + "' ";
                        if (isWorkflowCall)
                        {

                            filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowId='"
                                + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "') "
                                    + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                                + "    RecordID='" + currRecord.ID + "') "
                                ;
                        }

                        IList<PJ_clrkysd> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_clrkysd>(
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

        
        public void ExportExcelSubmit(ref LP_Temple parentTemple,  string orgid, string strProject, string strfenProject, bool isShow)
        {
            DSOFramerControl dsoFramerWordControl1 = new DSOFramerControl();
            string fname = Application.StartupPath + "\\00记录模板\\验收单.xls";
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

            string strfirst = "";
            string filter = "";
            string filter2 = "";
            string filter3 = "";
            string filter4 = "";
            if (strProject != "全部")
                filter2 = "  where 1=1 and ssgc='" + strProject + "'  ";
            else
                filter2 = "  where 1=1  ";

            IList mclist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct ssgc  from PJ_clrkysd " + filter2 + " order by ssgc");

            foreach (string mc in mclist)
            {
                if (strfenProject == "全部")
                    filter3 = "  where 1=1 ";
                else
                    filter3 = "  where  ssxm='" + strfenProject + "'  ";

                IList xmlist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct ssxm  from PJ_clrkysd " + filter3 + " order by ssxm");
                foreach (string xm in xmlist)
                {
                    filter4 = "  where 1=1"
                        + "  and ssgc='" + mc + "' "
                        + "  and ssxm='" + xm + "' ";
                    IList sjlist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct dhht  from PJ_clrkysd " + filter4 + " ");
                    foreach (string sj in sjlist)
                    {
                        filter = "  where 1=1"
                        + "  and ssgc='" + mc + "' "
                        + "  and ssxm='" + xm
                        + "' and  dhht='" + sj + "' ";
                        if (isWorkflowCall)
                        {
                           
                            filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  WorkFlowId='"
                                + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "') "
                                    + " or id in  (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                                + "    RecordID='" + currRecord.ID + "') "
                                ;
                        }

                        IList<PJ_clrkysd> datalist = Client.ClientHelper.PlatformSqlMap.GetListByWhere<PJ_clrkysd>(
                         filter
                           );
                        ExportExcel(ex, datalist);
                    }
                }

            }
            //ex.ActiveSheet(1);
            //ex.DeleteWorkSheet(1);
            Excel.Worksheet sheet;
            for (int i = 1; i <= wb.Application.Sheets.Count; i++)
            {
                sheet = wb.Application.Sheets[i] as Excel.Worksheet;
                sheet.Cells.Clear();
                sheet.Cells.ClearContents();
                sheet.Cells.ClearOutline();
                sheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;
                dsoFramerWordControl1.FileSave();

                
                break;
            }
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
        
        public void ExportExcel(ExcelAccess ex ,IList<PJ_clrkysd> datalist)
        {
            //此处写填充内容代码
            int row = 9;
            int col = 1;
            int rowcount = 7;
            if (datalist.Count < 1) return;
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
                if (j == 1)
                {

                    ex.ReNameWorkSheet(j + 1, datalist[0].ssgc + datalist[0].ssxm + datalist[0].dhht);
                }
                else
                    ex.ReNameWorkSheet(j + 1, datalist[0].ssgc + datalist[0].ssxm + datalist[0].dhht + "(" + (j) + ")");
            }
            for (int j = 0; j < datalist.Count; j++)
            {

                if (j % rowcount == 0)
                {
                    if (j == 0) ex.ActiveSheet(datalist[0].ssgc + datalist[0].ssxm + datalist[0].dhht);
                    else ex.ActiveSheet(datalist[0].ssgc + datalist[0].ssxm + datalist[0].dhht + "(" + (j / rowcount + 1) + ")");
                    ex.SetCellValue(datalist[j].ssgc, 3, 2);
                    ex.SetCellValue(datalist[j].xmdw, 5, 3); ;
                    ex.SetCellValue(datalist[j].ghdw, 5, 10);
                    ex.SetCellValue(datalist[j].ssxm, 6, 3);
                    //ex.SetCellValue(datalist[j].indate.ToString("yyyy"), 4, 1);
                    //ex.SetCellValue(datalist[j].indate.ToString("MM"), 4, 3);
                    //ex.SetCellValue(datalist[j].indate.ToString("dd"), 4, 5);

                    ex.SetCellValue(datalist[j].scbh, 27, 8);
                    ex.SetCellValue(datalist[j].jcjg, 28, 3);
                    ex.SetCellValue(datalist[j].czwt, 29, 3);
                    ex.SetCellValue(datalist[j].cljg, 30, 3);
                }
                ex.SetCellValue(datalist[j].dhht, row + j % rowcount, col);
                ex.SetCellValue(datalist[j].dhht, row + j % rowcount+8, col);
                ex.SetCellValue(datalist[j].wpmc, row + j % rowcount, col+1);
                ex.SetCellValue(datalist[j].wpgg, row + j % rowcount, col + 3);
                ex.SetCellValue(datalist[j].wpdw, row + j % rowcount, col + 5);

                ex.SetCellValue(datalist[j].wpsl, row + j % rowcount, col + 7);
                ex.SetCellValue(datalist[j].wpdj, row + j % rowcount, col + 9);
                ex.SetCellValue(datalist[j].htjg, row + j % rowcount, col + 11);
                ex.SetCellValue(datalist[j].yfk, row + j % rowcount, col + 13);

                

               
                //ex.SetCellValue(datalist[j].zrr, row + j % rowcount, col + 7);


            }
        }
    
    }
}
