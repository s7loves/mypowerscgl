using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client;
using Ebada.Scgl.Model;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;
using Ebada.Scgl.Core;
using System.Data;
using Ebada.Client.Platform;
using Ebada.Components;
using System.Threading;
namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 使用ExcelAccess生成Excel文档
    /// 文档
    /// </summary>
    public class Export11 {
        private bool isWorkfowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set { parentTemple = value; }
        }
        public bool IsWorkfowCall
        {
            set
            {

                isWorkfowCall = value;

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
        public void ExportExceljhbAllSubmitToWF_ModleRecordWorkTaskIns(string orgid)
        {
            
            string filter = "";
            int i = 0;
            if (orgid != "") filter = " and OrgCode='" + orgid + "'";
            if (isWorkfowCall)
            {
                filter = filter + " and id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where RecordID='"
                   + CurrRecord.ID + "' and   WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "') ";
            }
            List<WF_ModleRecordWorkTaskIns> mrwtlist = new List<WF_ModleRecordWorkTaskIns>();
            IList<PJ_yfsyjl> byqdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='变压器'   and planExpTime like '%" + DateTime.Now.Year + "%' " + filter + " order by xh ");
            if (isWorkfowCall)
            {
                for (i = 0; i < byqdatalist.Count; i++)
                {

                    WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                    mrwt.ID = mrwt.CreateID();
                    mrwt.ModleRecordID = byqdatalist[i].ID;
                    mrwt.RecordID = currRecord.ID;
                    mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                    mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                    mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                    mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                    mrwt.ModleTableName = byqdatalist[i].GetType().ToString();
                    mrwt.CreatTime = DateTime.Now;
                    Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                    mrwtlist.Add(mrwt);
                }
            }
            
            byqdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='断路器'  and planExpTime like '%" + DateTime.Now.Year + "%' " + filter + " order by xh ");
            if (isWorkfowCall)
            {
                for (i = 0; i < byqdatalist.Count; i++)
                {

                    WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                    mrwt.ID = mrwt.CreateID();
                    mrwt.ModleRecordID = byqdatalist[i].ID;
                    mrwt.RecordID = currRecord.ID;
                    mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                    mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                    mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                    mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                    mrwt.ModleTableName = byqdatalist[i].GetType().ToString();
                    mrwt.CreatTime = DateTime.Now;
                    Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                    mrwtlist.Add(mrwt);
                }
            }
            

            byqdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='避雷器'  and planExpTime like '%" + DateTime.Now.Year + "%' " + filter + " order by xh ");
            if (isWorkfowCall)
            {
                for (i = 0; i < byqdatalist.Count; i++)
                {

                    WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                    mrwt.ID = mrwt.CreateID();
                    mrwt.ModleRecordID = byqdatalist[i].ID;
                    mrwt.RecordID = currRecord.ID;
                    mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                    mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                    mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                    mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                    mrwt.ModleTableName = byqdatalist[i].GetType().ToString();
                    mrwt.CreatTime = DateTime.Now;
                    Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                    mrwtlist.Add(mrwt);
                }
            }

          
            byqdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='电容器'  and planExpTime like '%" + DateTime.Now.Year + "%' " + filter + " order by xh ");
            if (isWorkfowCall)
            {
                for (i = 0; i < byqdatalist.Count; i++)
                {

                    WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                    mrwt.ID = mrwt.CreateID();
                    mrwt.ModleRecordID = byqdatalist[i].ID;
                    mrwt.RecordID = currRecord.ID;
                    mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                    mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                    mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                    mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                    mrwt.ModleTableName = byqdatalist[i].GetType().ToString();
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
        public  void ExportExceljhbAllSubmit(ref LP_Temple parentTemple, string cellname, string sheetname, string orgid, bool isShow)
        {
            DSOFramerControl dsoFramerWordControl1 = new DSOFramerControl();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";
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
            Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
            ex.MyWorkBook = wb;
            ex.MyExcel = wb.Application;
            ExportExceljhbAllEx(ex, cellname, sheetname, orgid, isShow);
            string filter = "";
            int i = 0;
            if (orgid != "") filter = " and OrgCode='" + orgid + "'";
            if (isWorkfowCall)
            {
                filter = filter + "  and  id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
                + " WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                    + " and   WorkFlowInsId !='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                   + ")";
            }
            List<WF_ModleRecordWorkTaskIns> mrwtlist = new List<WF_ModleRecordWorkTaskIns>();
            IList<PJ_yfsyjl> byqdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='变压器'   and planExpTime like '%" + DateTime.Now.Year + "%' " + filter + " order by xh ");
            
            Export11.ExportExcelbyqEx(ex, byqdatalist, "变压器预防性试验记录", orgid, isShow);
           // IList<PJ_yfsyjl> byqjhbdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='变压器'   and planExpTime like '%" + DateTime.Now.Year + "%' " + filter + " order by xh ");
            IList<PJ_yfsyjl> byqjhbdatalist = byqdatalist;
            Export11.ExportExcelbyqjhbEx(ex, byqdatalist, "变压器" + "预防性试验计划表", orgid, isShow);
            if (currRecord.Status != "申报")
            {
                Export11.ExportExcelbyqssqkEx(ex, byqdatalist, "变压器" + "预防性试验实施情况记录", orgid, isShow);
                Export11.ExportExcelbyqwcqkEx(ex, byqdatalist, "变压器" + "预防性试验完成情况报表", orgid, isShow);
            }

            byqdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='断路器'  and planExpTime like '%" + DateTime.Now.Year + "%' " + filter + " order by xh ");
           
            Export11.ExportExceldlqEx(ex, byqdatalist, "断路器" + "预防性试验记录", orgid, isShow);
            //byqjhbdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='断路器'   and planExpTime like '%" + DateTime.Now.Year + "%' " + filter + " order by xh ");
            byqjhbdatalist = byqdatalist;
            Export11.ExportExceldlqjhbEx(ex, byqdatalist, "断路器" + "预防性试验计划表", orgid, isShow);
            if (currRecord.Status != "申报")
            {
                Export11.ExportExceldlqssqkEx(ex, byqdatalist, "断路器" + "预防性试验实施情况记录", orgid, isShow);
                Export11.ExportExceldlqwcqkEx(ex, byqdatalist, "断路器" + "预防性试验完成情况报表", orgid, isShow);
            }

            byqdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='避雷器'  and planExpTime like '%" + DateTime.Now.Year + "%' " + filter + " order by xh ");
          
            
            Export11.ExportExcelblqEx(ex, byqdatalist, "避雷器" + "预防性试验记录", orgid, isShow);
            //byqjhbdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='避雷器'   and planExpTime like '%" + DateTime.Now.Year + "%' " + filter + " order by xh ");
            byqjhbdatalist = byqdatalist;
            Export11.ExportExcelblqjhbEx(ex, byqdatalist, "避雷器" + "预防性试验计划表", orgid, isShow);
            if (currRecord.Status != "申报")
            {
                Export11.ExportExcelblqssqkEx(ex, byqdatalist, "避雷器" + "预防性试验实施情况记录", orgid, isShow);
                Export11.ExportExcelblqwcqkEx(ex, byqdatalist, "避雷器" + "预防性试验完成情况报表", orgid, isShow);
            }

            byqdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='电容器'  and planExpTime like '%" + DateTime.Now.Year + "%' " + filter + " order by xh ");
           
            Export11.ExportExceldrqEx(ex, byqdatalist, "电容器" + "预防性试验记录", orgid, isShow);
            //byqjhbdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='电容器'   and planExpTime like '%" + DateTime.Now.Year + "%' " + filter + " order by xh ");
            byqjhbdatalist = byqdatalist;
            Export11.ExportExceldrqjhbEx(ex, byqjhbdatalist, "电容器" + "预防性试验计划表", orgid, isShow);
            if (currRecord.Status != "申报")
            {
                Export11.ExportExceldrqssqkEx(ex, byqdatalist, "电容器" + "预防性试验实施情况记录", orgid, isShow);
                Export11.ExportExceldrqwcqkEx(ex, byqdatalist, "电容器" + "预防性试验完成情况报表", orgid, isShow);
            }

            IList<PJ_yfsyhcjl> hcdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyhcjl>("SelectPJ_yfsyhcjlList", " where  1=1 " + filter + " order by xh ");
            Export11.ExportExcelhcEx(ex, hcdatalist, "设备维护实施记录", orgid, isShow);
            if (parentTemple == null)
            {
                parentTemple = new LP_Temple();
                parentTemple.Status = "文档生成";
            }
            dsoFramerWordControl1.FileSave();
            parentTemple.DocContent = dsoFramerWordControl1.FileDataGzip;
            dsoFramerWordControl1.FileClose();

        }
        public  void ExportExceljhbAll(string cellname, string sheetname, string orgid)
        {
            ExportExceljhbAll(cellname, sheetname, orgid, true);
        }
        public  void ExportExceljhbAll(string cellname, string sheetname, string orgid,bool isShow)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";
            ex.Open(fname);
            ExportExceljhbAllEx(ex, cellname, sheetname, orgid);
            string filter="";
            if (orgid != "") filter = " and OrgCode='" + orgid + "'";
            if (isWorkfowCall)
            {
                filter = filter + " and  id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
               + " WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                   + " and   WorkFlowInsId !='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                  + ")";
            }
            IList<PJ_yfsyjl> byqdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='变压器'" + filter + " order by xh ");
            Export11.ExportExcelbyqEx(ex, byqdatalist, "变压器预防性试验记录", orgid, isShow);
            IList<PJ_yfsyjl> byqjhbdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='变压器'   and planExpTime like '%" + DateTime.Now.Year + "%' " + filter + " order by xh ");
            Export11.ExportExcelbyqjhbEx(ex, byqdatalist, "变压器" + "预防性试验计划表", orgid, isShow);
            Export11.ExportExcelbyqssqkEx(ex, byqdatalist, "变压器" + "预防性试验实施情况记录", orgid, isShow);
            Export11.ExportExcelbyqwcqkEx(ex, byqdatalist, "变压器" + "预防性试验完成情况报表", orgid, isShow);

            byqdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='断路器'" + filter + " order by xh ");
            Export11.ExportExceldlqEx(ex, byqdatalist, "断路器" + "预防性试验记录", orgid, isShow);
            byqjhbdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='断路器'   and planExpTime like '%" + DateTime.Now.Year + "%' " + filter + " order by xh ");
            Export11.ExportExceldlqjhbEx(ex, byqdatalist, "断路器" + "预防性试验计划表", orgid, isShow);
            Export11.ExportExceldlqssqkEx(ex, byqdatalist, "断路器" + "预防性试验实施情况记录", orgid, isShow);
            Export11.ExportExceldlqwcqkEx(ex, byqdatalist, "断路器" + "预防性试验完成情况报表", orgid, isShow);

            byqdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='避雷器'" + filter + " order by xh ");
            Export11.ExportExcelblqEx(ex, byqdatalist, "避雷器" + "预防性试验记录", orgid, isShow);
            byqjhbdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='避雷器'   and planExpTime like '%" + DateTime.Now.Year + "%' " + filter + " order by xh ");
            Export11.ExportExcelblqjhbEx(ex, byqdatalist, "避雷器" + "预防性试验计划表", orgid, isShow);
            Export11.ExportExcelblqssqkEx(ex, byqdatalist, "避雷器" + "预防性试验实施情况记录", orgid, isShow);
            Export11.ExportExcelblqwcqkEx(ex, byqdatalist, "避雷器" + "预防性试验完成情况报表", orgid, isShow);

            byqdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='电容器'" + filter + " order by xh ");
            Export11.ExportExceldrqEx(ex, byqdatalist, "电容器" + "预防性试验记录", orgid, isShow);
            byqjhbdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyjl>("SelectPJ_yfsyjlList", " where  type='电容器'   and planExpTime like '%" + DateTime.Now.Year + "%' " + filter + " order by xh ");
            Export11.ExportExceldrqjhbEx(ex, byqdatalist, "电容器" + "预防性试验计划表", orgid, isShow);
            Export11.ExportExceldrqssqkEx(ex, byqdatalist, "电容器" + "预防性试验实施情况记录", orgid, isShow);
            Export11.ExportExceldrqwcqkEx(ex, byqdatalist, "电容器" + "预防性试验完成情况报表", orgid, isShow);
            string filter2 = "";
            if (orgid != "") filter2 = " and OrgCode='" + orgid + "'";
            if (isWorkfowCall)
            {
                filter2 = filter2 + " and  id  in (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
               + " WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                   + " and   WorkFlowInsId ='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                   + " and   RecordID ='" + currRecord.ID+ "'"
                  + ")";
            }
            IList<PJ_yfsyhcjl> hcdatalist = Client.ClientHelper.PlatformSqlMap.GetList<PJ_yfsyhcjl>("SelectPJ_yfsyhcjlList", " where  1=1 " + filter2 + " order by xh ");
            Export11.ExportExcelhcEx(ex, hcdatalist, "设备维护实施记录", orgid, isShow); 

        }
        public static void ExportExcelAll(string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";
            ex.Open(fname);

           
        }
        public  void ExportExceljhbAllEx(ExcelAccess ex, string cellname, string sheetname, string orgid)
        {
            ExportExceljhbAllEx(ex, cellname, sheetname, orgid, true);
        }
        public  void ExportExceljhbAllEx(ExcelAccess ex, string cellname, string sheetname, string orgid,bool isShow)
        {

            int pagecount = 0, i = 0, j = 0, istart = 4, jstart = 1, jmax = 4, imax2 = 6, sheetindex = 0, itemp = 0,spanadd=0, spanadd2 = 0;
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;
            string filter = "";
            if (orgid != "") filter = " and a.OrgCode='" + orgid + "' ";
            if (isWorkfowCall)
            {
                filter = filter + "  and  id not in (select ModleRecordID from WF_ModleRecordWorkTaskIns where "
               + " WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                   + " and   WorkFlowInsId !='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                  + ")";
            }
            IList typelist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct  type    from dbo.PJ_yfsyjl a  where 1=1 " + filter );
            Hashtable hmodnum = new Hashtable();
            Hashtable hnamemod = new Hashtable();
            Hashtable hnamepro = new Hashtable();
            for (i = 0; i < typelist.Count;i++ )
            {
                string type = typelist[i].ToString();
                IList prolist = new ArrayList();
                IList modlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct  sbModle    from dbo.PJ_yfsyjl a  where  type='" + type + "' " + filter);
                IList proorlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct  syProject    from dbo.PJ_yfsyjl a  where type='" + type + "' " + filter);
                for (j = 0; j < modlist.Count; j++)
                {
                    IList modnumlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneInt", "select sum(sl)    from dbo.PJ_yfsyjl a  where  type='" + type + "'and sbModle='" + modlist[j] + "' " + filter);
                    if (type == "变压器")
                    {
                        modnumlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneInt", "select count(*)    from dbo.PJ_yfsyjl a  where  type='" + type + "'and sbModle='" + modlist[j] + "' " + filter);
                    }
                    if (modnumlist.Count > 0)
                    {
                        if (hmodnum.Contains(type + "-" + modlist[j])) hmodnum[type + "-" + modlist[j]] = modnumlist[0];
                        else
                            hmodnum.Add(type + "-" + modlist[j], modnumlist[0]);
                    }
                    else
                    {

                        if (hmodnum.Contains(type + "-" + modlist[j])) hmodnum[type + "-" + modlist[j]] = 0;
                        else
                            hmodnum.Add(type + "-" + modlist[j], 0);
                    
                    }
                }
                for (itemp = 0; itemp < proorlist.Count; itemp++)
                {
                    string[] ss = proorlist[itemp].ToString().Split('、');
                    for (j = 0; j < ss.Length; j++)
                    {
                        if (!prolist.Contains(ss[j]))
                        prolist.Add(ss[j]); 
                    
                    }
                
                }
                hnamemod.Add(type, modlist);
                hnamepro.Add(type, prolist);

            }

            for (i = 0; i < typelist.Count; i ++)
            {
                IList mlist = hnamemod[typelist[i]] as IList;
                IList plist = hnamepro[typelist[i]] as IList;
                int icount= mlist.Count   >plist.Count ?mlist.Count:plist.Count;
                spanadd2 += Convert.ToInt32(Math.Ceiling(icount / (imax2 + 0.0))); 

            }
            pagecount = Convert.ToInt32(Math.Ceiling((spanadd2) / (jmax + 0.0)));
            ex.ActiveSheet(sheetname);
            for (i = 1; i <= wb.Application.Worksheets.Count; i++)
            {
                Excel.Worksheet sheet = wb.Application.Worksheets[i] as Excel.Worksheet;
                if (sheet.Name == sheetname)
                {
                    sheetindex = sheet.Index;
                    break;
                }
            }
            itemp = sheetindex;
            for (i = 1; i < pagecount; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp + 1, sheetname + (i + 1));
                itemp++;

            }
            spanadd2 = 0;
            for (i = 0; i < typelist.Count; i++)
            {
                IList mlist = hnamemod[typelist[i]] as IList;
                IList plist = hnamepro[typelist[i]] as IList;
                IList menlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct  charMan    from dbo.PJ_yfsyjl a  where  type='" + typelist[i] + "' " + filter);
                string typedw = "";
                switch (typelist[i].ToString())
                {
                    case "变压器":
                         typedw="台"; 
                        break;

                    case "避雷器":

                        typedw = "只"; 
                        break;

                    case "断路器":
                        typedw = "台"; 

                        break;

                    case "电容器":
                        typedw = "台"; 

                        break;

                }
                string dx = "预防性试验";
                string sx = "单位";
                string nr = typelist[i] + "预防性试验";
                IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr2 from pj_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}' and nr='{2}' ", dx, sx, nr));
                if (list.Count > 0 && list[0] != null && list[0].ToString() != "")
                {
                    typedw = list[0].ToString();
                }
                for (itemp = 0; itemp < mlist.Count || itemp < plist.Count; itemp++)
                {
                    if (Math.Ceiling((1.0 + spanadd+ itemp / imax2) / (jmax)) > 1)
                    {
                        ex.ActiveSheet(sheetname + Math.Ceiling((1.0 + spanadd + itemp / imax2) / (jmax)));

                    }
                    else
                        ex.ActiveSheet(sheetname);
                    if (mlist.Count > itemp)
                    {
                        ex.SetCellValue(mlist[itemp].ToString(), istart + (spanadd + itemp / imax2) % jmax * imax2 + itemp % imax2, jstart + 2);
                        ex.SetCellValue(hmodnum[typelist[i] + "-" + mlist[itemp]].ToString(), istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 3);
                    }
                    if (plist.Count > itemp)
                    {
                        ex.SetCellValue(plist[itemp].ToString(), istart + (spanadd + itemp / imax2) % jmax * imax2 + itemp % imax2, jstart + 5);
                    }
                    if(itemp % 6 == 0)
                    {
                        ex.SetCellValue(Convert.ToString(i + 1), istart + ((spanadd + itemp / imax2) % jmax) * imax2 , jstart);
                        ex.SetCellValue(Convert.ToString(typelist[i] + cellname), istart + ((spanadd + itemp / imax2) % jmax) * imax2 , jstart + 1);
                        if (menlist.Count >0)
                            ex.SetCellValue(Convert.ToString(menlist[0]), istart + ((spanadd + itemp / imax2) % jmax) * imax2, jstart + 6);
                        ex.SetCellValue(typedw , istart + ((spanadd + itemp / imax2) % jmax) * imax2, jstart+4);
                        spanadd2++;
                    }
               
                    
                    
                   
                }
                spanadd=spanadd2;
            }
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(orgid);
            for (i = 0; i < pagecount; i++)
            {
                if (Math.Ceiling((i + 1.0)) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0)));
                else
                    ex.ActiveSheet(sheetname);
                if (org != null)
                    ex.SetCellValue(org.OrgName, 2, 2);
                else
                    ex.SetCellValue("全局", 2, 2);

                //if (datalist.Count > 0)
                //    ex.SetCellValue(datalist[0].charMan, 29, 14);
            }
            if (isShow)
            {
                ex.ActiveSheet(sheetname);
                ex.ShowExcel();
            }
        }

        public  void ExportExcelhc(IList<PJ_yfsyhcjl> datalist, string sheetname, string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";
            ex.Open(fname);
            ExportExcelhcEx(ex, datalist, sheetname, orgid);
        }
        public static void ExportExcelhcEx(ExcelAccess ex, IList<PJ_yfsyhcjl> datalist, string sheetname, string orgid)
        {
            ExportExcelhcEx(ex, datalist, sheetname, orgid, true);
        }
        public static void ExportExcelhcEx(ExcelAccess ex, IList<PJ_yfsyhcjl> datalist, string sheetname, string orgid,bool isShow)
        {

            int pagecount = 0, i = 0, istart = 5, jstart = 1, jmax = 20, sheetindex = 0;
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;
          
            pagecount = Convert.ToInt32(Math.Ceiling(datalist.Count / (jmax + 0.0)));
            if (pagecount == 0)
            {
                pagecount = 1;
            }
            ex.ActiveSheet(sheetname);
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
            for (i = 1; i < pagecount; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp + 1, sheetname + (i + 1));
                itemp++;

            }
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(orgid);
            for (i = 0; i < pagecount; i++)
            {
                if (Math.Ceiling((i + 1.0)) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0)));
                else
                    ex.ActiveSheet(sheetname);
                if (org != null)
                    ex.SetCellValue(org.OrgName, 2, 2);
                else
                    ex.SetCellValue("全局", 2, 2);

                //if (datalist.Count > 0)
                //    ex.SetCellValue(datalist[0].charMan, 29, 14);
            }
            for (i = 0; i < datalist.Count; i++)
            {
                if (Math.Ceiling((i + 1.0) / (jmax)) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0) / (jmax)));
                else
                    ex.ActiveSheet(sheetname);
                ex.SetCellValue(Convert.ToString(i + 1), istart + i % jmax, jstart);

                ex.SetCellValue(datalist[i].sj.Year.ToString(), istart + i % jmax, jstart + 1);
                ex.SetCellValue(datalist[i].sj.Month.ToString(), istart + i % jmax, jstart + 2);
                ex.SetCellValue(datalist[i].sj.Day.ToString(), istart + i % jmax, jstart + 3);

                ex.SetCellValue(datalist[i].yssbName, istart + i % jmax, jstart + 4);

                ex.SetCellValue(datalist[i].xhclName, istart + i % jmax, jstart + 5);
                ex.SetCellValue(datalist[i].sbModle, istart + i % jmax, jstart + 6);
                ex.SetCellValue(datalist[i].dw, istart + i % jmax, jstart + 7);

                ex.SetCellValue(datalist[i].sl.ToString(), istart + i % jmax, jstart + 8);
                ex.SetCellValue(datalist[i].ysMan, istart + i % jmax, jstart + 9);
                ex.SetCellValue(datalist[i].yxdwMan, istart + i % jmax, jstart + 10);
                ex.SetCellValue(datalist[i].Remark , istart + i % jmax, jstart + 11);

            }
            if (isShow)
            {
                ex.ActiveSheet(sheetname);
                ex.ShowExcel();
            }
        }





        public  void ExportExcelbyqwcqk(IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";
            ex.Open(fname);
            ExportExcelbyqwcqkEx(ex, datalist, sheetname, orgid);
        }
        public static void ExportExcelbyqwcqkEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExportExcelbyqwcqkEx(ex, datalist, sheetname, orgid, true);
        
        }
        public static void ExportExcelbyqwcqkEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid, bool isShow)
        {

            int pagecount = 0, i = 0, istart = 5, jstart = 1, jmax = 24, sheetindex = 0;
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;

            pagecount = Convert.ToInt32(Math.Ceiling(datalist.Count / (jmax + 0.0)));
            ex.ActiveSheet(sheetname);
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
            for (i = 1; i < pagecount; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp + 1, sheetname + (i + 1));
                itemp++;

            }
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(orgid);
            for (i = 0; i < pagecount; i++)
            {
                if (Math.Ceiling((i + 1.0)) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0)));
                else
                    ex.ActiveSheet(sheetname);
                if (org != null)
                    ex.SetCellValue(org.OrgName, 2, 2);
                else
                    ex.SetCellValue("全局", 2, 2);
                if (datalist.Count > 0)
                    ex.SetCellValue(datalist[0].charMan, 29, 14);
            }
            for (i = 0; i < datalist.Count; i++)
            {
                if (Math.Ceiling((i + 1.0) / (jmax)) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0) / (jmax)));
                else
                    ex.ActiveSheet(sheetname);
                ex.SetCellValue(Convert.ToString(i + 1), istart + i % jmax, jstart);
                ex.SetCellValue(datalist[i].sbInstallAdress, istart + i % jmax, jstart + 1);
                ex.SetCellValue(datalist[i].sbModle, istart + i % jmax, jstart + 2);
                ex.SetCellValue(datalist[i].sbCapacity.ToString(), istart + i % jmax, jstart + 3);
                ex.SetCellValue(datalist[i].syProject, istart + i % jmax, jstart + 4);
                //ex.SetCellValue(datalist[i].syPeriod, istart + i % jmax, jstart + 5);

                ex.SetCellValue(datalist[i].preExpTime.Year.ToString(), istart + i % jmax, jstart + 5);
                ex.SetCellValue(datalist[i].preExpTime.Month.ToString(), istart + i % jmax, jstart + 6);
                ex.SetCellValue(datalist[i].preExpTime.Day.ToString(), istart + i % jmax, jstart + 7);

                ex.SetCellValue(datalist[i].iswc , istart + i % jmax, jstart + 8);

                ex.SetCellValue(datalist[i].planExpTime.Year.ToString(), istart + i % jmax, jstart + 9);
                ex.SetCellValue(datalist[i].planExpTime.Month.ToString(), istart + i % jmax, jstart + 10);
                ex.SetCellValue(datalist[i].planExpTime.Day.ToString(), istart + i % jmax, jstart + 11);
               
                ex.SetCellValue(datalist[i].syjg , istart + i % jmax, jstart + 12);
                ex.SetCellValue(datalist[i].wcRemark, istart + i % jmax, jstart + 13);

            }
            if (isShow)
            {
                ex.ActiveSheet(sheetname);
                ex.ShowExcel();
            }
        }
        public  void ExportExcelbyqssqk(IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";
            ex.Open(fname);
            ExportExcelbyqssqkEx(ex, datalist, sheetname, orgid);
        }
        public static void ExportExcelbyqssqkEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExportExcelbyqssqkEx(ex, datalist, sheetname, orgid,true);
        
        }
        public static void ExportExcelbyqssqkEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid, bool isShow)
        {

            int pagecount = 0, i = 0, istart = 5, jstart = 1, jmax = 24, sheetindex = 0;
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;

            pagecount = Convert.ToInt32(Math.Ceiling(datalist.Count / (jmax + 0.0)));
            ex.ActiveSheet(sheetname);
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
            for (i = 1; i < pagecount; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp + 1, sheetname + (i + 1));
                itemp++;

            }
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(orgid);
            for (i = 0; i < pagecount; i++)
            {
                if (Math.Ceiling((i + 1.0) ) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0)));
                else
                    ex.ActiveSheet(sheetname);
                if (org != null)
                    ex.SetCellValue(org.OrgName, 2, 2);
                else
                    ex.SetCellValue("全局", 2, 2);
                if (datalist.Count > 0)
                    ex.SetCellValue(datalist[0].charMan, 29, 14);
            }
            for (i = 0; i < datalist.Count; i++)
            {
                if (Math.Ceiling((i + 1.0) / (jmax)) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0) / (jmax)));
                else
                    ex.ActiveSheet(sheetname);
                ex.SetCellValue(Convert.ToString(i + 1), istart + i % jmax, jstart);
                ex.SetCellValue(datalist[i].sbInstallAdress, istart + i % jmax, jstart + 1);
                ex.SetCellValue(datalist[i].sbModle, istart + i % jmax, jstart + 2);
                ex.SetCellValue(datalist[i].sbCapacity.ToString(), istart + i % jmax, jstart + 3);
                ex.SetCellValue(datalist[i].syProject, istart + i % jmax, jstart + 4);
                //ex.SetCellValue(datalist[i].syPeriod, istart + i % jmax, jstart + 5);

                ex.SetCellValue(datalist[i].planExpTime.Year.ToString(), istart + i % jmax, jstart + 5);
                ex.SetCellValue(datalist[i].planExpTime.Month.ToString(), istart + i % jmax, jstart + 6);
                ex.SetCellValue(datalist[i].planExpTime.Day.ToString(), istart + i % jmax, jstart + 7);

                ex.SetCellValue(datalist[i].sjExpTime.Year.ToString(), istart + i % jmax, jstart + 8);
                ex.SetCellValue(datalist[i].sjExpTime.Month.ToString(), istart + i % jmax, jstart + 9);
                ex.SetCellValue(datalist[i].sjExpTime.Day.ToString(), istart + i % jmax, jstart + 10);
                ex.SetCellValue(datalist[i].syjg, istart + i % jmax, jstart + 11);
                ex.SetCellValue(datalist[i].charMan, istart + i % jmax, jstart + 12);
                ex.SetCellValue(datalist[i].syMan , istart + i % jmax, jstart + 13);

            }
            if (isShow)
            {
                ex.ActiveSheet(sheetname);
                ex.ShowExcel();
            }
        }
        public  void ExportExcelbyqjhb(IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";
            ex.Open(fname);
            ExportExcelbyqjhbEx(ex, datalist, sheetname, orgid);
        }
        public static void ExportExcelbyqjhbEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExportExcelbyqjhbEx(ex, datalist, sheetname, orgid, true);
        }
        public static void ExportExcelbyqjhbEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid, bool isShow)
        {

            int pagecount = 0, i = 0, istart = 5, jstart = 1, jmax = 24, sheetindex = 0;
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;

            pagecount = Convert.ToInt32(Math.Ceiling(datalist.Count / (jmax + 0.0)));
            ex.ActiveSheet(sheetname);
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
            for (i = 1; i < pagecount; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp + 1, sheetname + (i + 1));
                itemp++;

            }
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(orgid);
            for (i = 0; i < pagecount; i++)
            {
                if (Math.Ceiling((i + 1.0) ) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0) ));
                else
                    ex.ActiveSheet(sheetname);
                if (org != null)
                    ex.SetCellValue(org.OrgName, 2, 2);
                else
                    ex.SetCellValue("全局", 2, 2);
                if (datalist.Count > 0)
                    ex.SetCellValue(datalist[0].charMan, 29, 14);
            }
            for (i = 0; i < datalist.Count; i++)
            {
                if (Math.Ceiling((i + 1.0) / (jmax)) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0) / (jmax)));
                else
                    ex.ActiveSheet(sheetname);
                ex.SetCellValue(Convert.ToString(i + 1), istart + i % jmax, jstart);
                ex.SetCellValue(datalist[i].sbInstallAdress, istart + i % jmax, jstart + 1);
                ex.SetCellValue(datalist[i].sbModle, istart + i % jmax, jstart + 2);
                ex.SetCellValue(datalist[i].sbCapacity.ToString(), istart + i % jmax, jstart + 3);
                ex.SetCellValue(datalist[i].syProject, istart + i % jmax, jstart + 4);
                ex.SetCellValue(datalist[i].syPeriod, istart + i % jmax, jstart + 5);

                ex.SetCellValue(datalist[i].preExpTime.Year.ToString(), istart + i % jmax, jstart + 6);
                ex.SetCellValue(datalist[i].preExpTime.Month.ToString(), istart + i % jmax, jstart + 7);
                ex.SetCellValue(datalist[i].preExpTime.Day.ToString(), istart + i % jmax, jstart + 8);

                ex.SetCellValue(datalist[i].planExpTime.Year.ToString(), istart + i % jmax, jstart + 9);
                ex.SetCellValue(datalist[i].planExpTime.Month.ToString(), istart + i % jmax, jstart + 10);
                ex.SetCellValue(datalist[i].planExpTime.Day.ToString(), istart + i % jmax, jstart + 11);
                ex.SetCellValue(datalist[i].Remark, istart + i % jmax, jstart + 12);

            }
            ex.ActiveSheet(sheetname);
            ex.ShowExcel();
        }
        /// <summary>
        /// 文档格式预定义好的，只填写内容
        /// </summary>
        /// <param name="obj"></param>
        /// 
        public  void ExportExcelbyq(IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";
            ex.Open(fname);
            ExportExcelbyqEx(ex, datalist, sheetname, orgid);
        }
        public static void ExportExcelbyqEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExportExcelbyqEx(ex, datalist, sheetname, orgid, true);
        }
        public static void ExportExcelbyqEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid, bool isShow)
        {
            
            int pagecount = 0, i = 0, istart = 6,jstart=1,jmax=24,sheetindex=0;
            Excel.Workbook wb =ex.MyWorkBook  as Excel.Workbook;
          
            pagecount =Convert.ToInt32 (Math.Ceiling(datalist.Count /(jmax+0.0)));
            ex.ActiveSheet(sheetname );
            for (i = 1; i <= wb.Application.Worksheets.Count; i++)
            {
               Excel.Worksheet sheet= wb.Application.Worksheets[i] as Excel.Worksheet;
               if (sheet.Name == sheetname)
               {
                   sheetindex = sheet.Index;
                   break;
               }
            }
            int itemp = sheetindex;
            for (i = 1; i < pagecount ; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp+1, sheetname + (i + 1));
                itemp++;

            }
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(orgid);
            for (i = 0; i < pagecount; i++)
            {
                if (Math.Ceiling((i + 1.0) ) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0)));
                else
                    ex.ActiveSheet(sheetname);
                if (org != null)
                    ex.SetCellValue(org.OrgName, 3, 2);
                else
                    ex.SetCellValue("全局", 3, 2);
                if (datalist.Count >0)
                    ex.SetCellValue(datalist[0].charMan , 30,12);
            }
            for (i = 0; i < datalist.Count; i++)
            {
                if (Math.Ceiling((i + 1.0) / (jmax)) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0) / (jmax))); 
                else
                    ex.ActiveSheet(sheetname );
                ex.SetCellValue(Convert.ToString(i+1), istart +i%jmax , jstart );
                ex.SetCellValue(datalist[i].sbInstallAdress , istart + i % jmax, jstart + 1);
                ex.SetCellValue(datalist[i].sbModle, istart + i % jmax, jstart + 2);
                ex.SetCellValue(datalist[i].sbCapacity.ToString(), istart + i % jmax, jstart + 3);
                ex.SetCellValue(datalist[i].syProject , istart + i % jmax, jstart + 4);
                ex.SetCellValue(datalist[i].syPeriod , istart + i % jmax, jstart + 5);

                ex.SetCellValue(datalist[i].preExpTime.Year.ToString(), istart + i % jmax, jstart + 6);
                ex.SetCellValue(datalist[i].preExpTime.Month .ToString(), istart + i % jmax, jstart + 7);
                ex.SetCellValue(datalist[i].preExpTime.Day.ToString(), istart + i % jmax, jstart + 8);

                ex.SetCellValue(datalist[i].planExpTime.Year.ToString(), istart + i % jmax, jstart + 9);
                ex.SetCellValue(datalist[i].planExpTime.Month.ToString(), istart + i % jmax, jstart + 10);
                ex.SetCellValue(datalist[i].planExpTime.Day.ToString(), istart + i % jmax, jstart + 11);
                ex.SetCellValue(datalist[i].Remark, istart + i % jmax, jstart + 12);

            }
            if (isShow)
            {
                ex.ActiveSheet(sheetname);
                ex.ShowExcel();
            }
        }



        public  void ExportExceldlqwcqk(IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";

            ex.Open(fname);
            ExportExceldlqwcqkEx(ex, datalist, sheetname, orgid);

        }
        public static void ExportExceldlqwcqkEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExportExceldlqwcqkEx(ex, datalist, sheetname, orgid,true);
        }
        public static void ExportExceldlqwcqkEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid, bool isShow)
        {

            int pagecount = 0, i = 0, istart = 6, jstart = 1, jmax = 4, sheetindex = 0, spanlistcount = 0, itemp = 0, imax2 = 5, spanadd = 0;
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;
            for (i = 0; i < datalist.Count; i++)
            {
                string[] sname = datalist[i].syProject.Split('、');
                if (sname.Length > 5)
                {
                    spanlistcount += sname.Length / imax2;
                }

            }
            pagecount = Convert.ToInt32(Math.Ceiling((datalist.Count + spanlistcount) / (jmax + 0.0)));
            ex.ActiveSheet(sheetname);
            for (i = 1; i <= wb.Application.Worksheets.Count; i++)
            {
                Excel.Worksheet sheet = wb.Application.Worksheets[i] as Excel.Worksheet;
                if (sheet.Name == sheetname)
                {
                    sheetindex = sheet.Index;
                    break;
                }
            }
            itemp = sheetindex;
            for (i = 1; i < pagecount; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp + 1, sheetname + (i + 1));
                itemp++;

            }
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(orgid);
            for (i = 0; i < pagecount; i++)
            {
                if (Math.Ceiling((i + 1.0)) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0)));
                else
                    ex.ActiveSheet(sheetname);
                if (org != null)
                    ex.SetCellValue(org.OrgName, 3, 2);
                else
                    ex.SetCellValue("全局",3, 2);
                if (datalist.Count > 0)
                    ex.SetCellValue(datalist[0].charMan, 26, 14);
            }
            for (i = 0; i < datalist.Count; i++)
            {
                if (Math.Ceiling((i + 1.0 + spanadd) / (jmax)) > 1)
                {
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0 + spanadd) / (jmax)));

                }
                else
                    ex.ActiveSheet(sheetname);
                ex.SetCellValue(Convert.ToString(i + 1), istart + ((i + spanadd) % jmax) * imax2, jstart);
                ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((i + spanadd) % jmax) * imax2, jstart + 1);
                ex.SetCellValue(datalist[i].sbModle, istart + ((i + spanadd) % jmax) * imax2, jstart + 2);
                ex.SetCellValue(datalist[i].sl.ToString(), istart + ((i + spanadd) % jmax) * imax2, jstart + 3);

                //ex.SetCellValue(datalist[i].syPeriod, istart + ((i + spanadd) % jmax) * imax2, jstart + 6);

                ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((i + spanadd) % jmax) * imax2, jstart + 6);
                ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((i + spanadd) % jmax) * imax2, jstart + 7);
                ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((i + spanadd) % jmax) * imax2, jstart + 8);

                ex.SetCellValue(datalist[i].iswc , istart + ((i + spanadd) % jmax) * imax2, jstart + 9);

                ex.SetCellValue(datalist[i].sjExpTime.Year.ToString() + "年", istart + ((i + spanadd) % jmax) * imax2, jstart + 10);
                ex.SetCellValue(datalist[i].sjExpTime.Month.ToString() + "月", istart + ((i + spanadd) % jmax) * imax2, jstart + 11);
                ex.SetCellValue(datalist[i].sjExpTime.Day.ToString() + "日", istart + ((i + spanadd) % jmax) * imax2, jstart + 12);
                ex.SetCellValue(datalist[i].syjg, istart + ((i + spanadd) % jmax) * imax2, jstart + 13);
                ex.SetCellValue(datalist[i].wcRemark , istart + ((i + spanadd) % jmax) * imax2, jstart + 14);

                string[] sname = datalist[i].syProject.Split('、');
                for (itemp = 0; itemp < sname.Length; itemp++)
                {
                    if (itemp < 5)
                        ex.SetCellValue(sname[itemp], istart + ((i + spanadd) % jmax) * imax2 + itemp, jstart + 5);
                    else
                    {
                        spanadd++;
                        setwcSpanExcel(ex, datalist[i], i, istart, jmax, jstart, ref spanadd, imax2, sheetname, sname, itemp);

                        break;
                    }
                }


            }
            if (isShow)
            {
                ex.ActiveSheet(sheetname);
                ex.ShowExcel();
            }
        }
        public static void setwcSpanExcel(ExcelAccess ex, PJ_yfsyjl data, int i, int istart, int jmax, int jstart, ref int spanadd, int imax2, string sheetname, string[] sname, int itemp)
        {
            if (Math.Ceiling((i + 1.0 + spanadd) / (jmax)) > 1)
            {
                ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0 + spanadd) / (jmax)));


            }
            else
                ex.ActiveSheet(sheetname);
            ex.SetCellValue(Convert.ToString(i + 1), istart + ((i + spanadd) % jmax) * imax2, jstart);
            ex.SetCellValue(data.sbInstallAdress, istart + ((i + spanadd) % jmax) * imax2, jstart + 1);
            ex.SetCellValue(data.sbModle, istart + ((i + spanadd) % jmax) * imax2, jstart + 2);
            ex.SetCellValue(data.sl.ToString(), istart + ((i + spanadd) % jmax) * imax2, jstart + 3);

            //ex.SetCellValue(data.syPeriod, istart + ((i + spanadd) % jmax ) * imax2, jstart + 6);
            ex.SetCellValue(data.planExpTime.Year.ToString() + "年", istart + ((i + spanadd) % jmax) * imax2, jstart + 6);
            ex.SetCellValue(data.planExpTime.Month.ToString() + "月", istart + ((i + spanadd) % jmax) * imax2, jstart + 7);
            ex.SetCellValue(data.planExpTime.Day.ToString() + "日", istart + ((i + spanadd) % jmax) * imax2, jstart + 8);

            ex.SetCellValue(data.iswc, istart + ((i + spanadd) % jmax) * imax2, jstart + 9);

            ex.SetCellValue(data.sjExpTime.Year.ToString() + "年", istart + ((i + spanadd) % jmax) * imax2, jstart + 10);
            ex.SetCellValue(data.sjExpTime.Month.ToString() + "月", istart + ((i + spanadd) % jmax) * imax2, jstart + 11);
            ex.SetCellValue(data.sjExpTime.Day.ToString() + "日", istart + ((i + spanadd) % jmax) * imax2, jstart + 12);
            ex.SetCellValue(data.syjg , istart + ((i + spanadd) % jmax) * imax2, jstart + 13);
            ex.SetCellValue(data.wcRemark, istart + ((i + spanadd) % jmax) * imax2, jstart + 14);

            for (int m = 0; m + itemp < sname.Length; m++)
            {
                if (m < 4)
                    ex.SetCellValue(sname[itemp], istart + ((i + spanadd) % jmax) * imax2 + m, jstart + 5);
                else
                {
                    spanadd++;
                    setwcSpanExcel(ex, data, i, istart, jmax, jstart, ref spanadd, imax2, sheetname, sname, m + itemp);
                    break;
                }
            }
        }

        public  void ExportExceldlqssqk(IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";

            ex.Open(fname);
            ExportExceldlqssqkEx(ex, datalist, sheetname, orgid);

        }
        public static void ExportExceldlqssqkEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExportExceldlqssqkEx(ex, datalist, sheetname, orgid, true);
        }
        public static void ExportExceldlqssqkEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid, bool isShow)
        {

            int pagecount = 0, i = 0, istart = 6, jstart = 1, jmax = 4, sheetindex = 0, spanlistcount = 0, itemp = 0, imax2 = 5, spanadd = 0;
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;
            for (i = 0; i < datalist.Count; i++)
            {
                string[] sname = datalist[i].syProject.Split('、');
                if (sname.Length > 5)
                {
                    spanlistcount += sname.Length / imax2;
                }

            }
            pagecount = Convert.ToInt32(Math.Ceiling((datalist.Count + spanlistcount) / (jmax + 0.0)));
            ex.ActiveSheet(sheetname);
            for (i = 1; i <= wb.Application.Worksheets.Count; i++)
            {
                Excel.Worksheet sheet = wb.Application.Worksheets[i] as Excel.Worksheet;
                if (sheet.Name == sheetname)
                {
                    sheetindex = sheet.Index;
                    break;
                }
            }
            itemp = sheetindex;
            for (i = 1; i < pagecount; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp + 1, sheetname + (i + 1));
                itemp++;

            }
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(orgid);
            for (i = 0; i < pagecount; i++)
            {
                if (Math.Ceiling((i + 1.0) ) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0)));
                else
                    ex.ActiveSheet(sheetname);
                if (org != null)
                    ex.SetCellValue(org.OrgName, 3, 2);
                else
                    ex.SetCellValue("全局", 3, 2);
                if (datalist.Count > 0)
                    ex.SetCellValue(datalist[0].charMan, 26, 14);
            }
            for (i = 0; i < datalist.Count; i++)
            {
                if (Math.Ceiling((i + 1.0 + spanadd) / (jmax)) > 1)
                {
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0 + spanadd) / (jmax)));

                }
                else
                    ex.ActiveSheet(sheetname);
                ex.SetCellValue(Convert.ToString(i + 1), istart + ((i + spanadd) % jmax) * imax2, jstart);
                ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((i + spanadd) % jmax) * imax2, jstart + 1);
                ex.SetCellValue(datalist[i].sbModle, istart + ((i + spanadd) % jmax) * imax2, jstart + 2);
                ex.SetCellValue(datalist[i].sl.ToString(), istart + ((i + spanadd) % jmax) * imax2, jstart + 3);

                //ex.SetCellValue(datalist[i].syPeriod, istart + ((i + spanadd) % jmax) * imax2, jstart + 6);

                ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((i + spanadd) % jmax) * imax2, jstart + 6);
                ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((i + spanadd) % jmax) * imax2, jstart + 7);
                ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((i + spanadd) % jmax) * imax2, jstart + 8);

                ex.SetCellValue(datalist[i].sjExpTime.Year.ToString() + "年", istart + ((i + spanadd) % jmax) * imax2, jstart + 9);
                ex.SetCellValue(datalist[i].sjExpTime.Month.ToString() + "月", istart + ((i + spanadd) % jmax) * imax2, jstart + 10);
                ex.SetCellValue(datalist[i].sjExpTime.Day.ToString() + "日", istart + ((i + spanadd) % jmax) * imax2, jstart + 11);
                ex.SetCellValue(datalist[i].syjg , istart + ((i + spanadd) % jmax) * imax2, jstart + 12);
                ex.SetCellValue(datalist[i].charMan, istart + ((i + spanadd) % jmax) * imax2, jstart + 13);
                ex.SetCellValue(datalist[i].syMan , istart + ((i + spanadd) % jmax) * imax2, jstart + 14);

                string[] sname = datalist[i].syProject.Split('、');
                for (itemp = 0; itemp < sname.Length; itemp++)
                {
                    if (itemp < 5)
                        ex.SetCellValue(sname[itemp], istart + ((i + spanadd) % jmax) * imax2 + itemp, jstart + 5);
                    else
                    {
                        spanadd++;
                        setssSpanExcel(ex, datalist[i], i, istart, jmax, jstart, ref spanadd, imax2, sheetname, sname, itemp);

                        break;
                    }
                }


            }
            if (isShow)
            {
                ex.ActiveSheet(sheetname);
                ex.ShowExcel();
            }
        }
        public static void setssSpanExcel(ExcelAccess ex, PJ_yfsyjl data, int i, int istart, int jmax, int jstart, ref int spanadd, int imax2, string sheetname, string[] sname, int itemp)
        {
            if (Math.Ceiling((i + 1.0 + spanadd) / (jmax)) > 1)
            {
                ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0 + spanadd) / (jmax)));


            }
            else
                ex.ActiveSheet(sheetname);
            ex.SetCellValue(Convert.ToString(i + 1), istart + ((i + spanadd) % jmax) * imax2, jstart);
            ex.SetCellValue(data.sbInstallAdress, istart + ((i + spanadd) % jmax) * imax2, jstart + 1);
            ex.SetCellValue(data.sbModle, istart + ((i + spanadd) % jmax) * imax2, jstart + 2);
            ex.SetCellValue(data.sl.ToString(), istart + ((i + spanadd) % jmax) * imax2, jstart + 3);

            //ex.SetCellValue(data.syPeriod, istart + ((i + spanadd) % jmax ) * imax2, jstart + 6);
            ex.SetCellValue(data.planExpTime.Year.ToString() + "年", istart + ((i + spanadd) % jmax) * imax2, jstart + 6);
            ex.SetCellValue(data.planExpTime.Month.ToString() + "月", istart + ((i + spanadd) % jmax) * imax2, jstart + 7);
            ex.SetCellValue(data.planExpTime.Day.ToString() + "日", istart + ((i + spanadd) % jmax) * imax2, jstart + 8);

            ex.SetCellValue(data.sjExpTime.Year.ToString() + "年", istart + ((i + spanadd) % jmax) * imax2, jstart + 9);
            ex.SetCellValue(data.sjExpTime.Month.ToString() + "月", istart + ((i + spanadd) % jmax) * imax2, jstart + 10);
            ex.SetCellValue(data.sjExpTime.Day.ToString() + "日", istart + ((i + spanadd) % jmax) * imax2, jstart + 11);
            ex.SetCellValue(data.charMan, istart + ((i + spanadd) % jmax) * imax2, jstart + 12);
            ex.SetCellValue(data.Remark, istart + ((i + spanadd) % jmax) * imax2, jstart + 13);

            for (int m = 0; m + itemp < sname.Length; m++)
            {
                if (m < 4)
                    ex.SetCellValue(sname[itemp], istart + ((i + spanadd) % jmax) * imax2 + m, jstart + 5);
                else
                {
                    spanadd++;
                    setssSpanExcel(ex, data, i, istart, jmax, jstart, ref spanadd, imax2, sheetname, sname, m + itemp);
                    break;
                }
            }
        }
        /// <summary>
        /// 文档格式预定义好的，生成台账
        /// </summary>
        /// <param name="obj"></param>
        public  void ExportExceldlqjhb(IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";

            ex.Open(fname);
            ExportExceldlqjhbEx(ex, datalist, sheetname, orgid);

        }
        public static void ExportExceldlqjhbEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExportExceldlqjhbEx(ex, datalist, sheetname, orgid, true);
        }
        public static void ExportExceldlqjhbEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid, bool isShow)
        {

            int pagecount = 0, i = 0, istart = 6, jstart = 1, jmax = 4, sheetindex = 0, spanlistcount = 0, itemp = 0, imax2 = 5, spanadd = 0;
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;
            for (i = 0; i < datalist.Count; i++)
            {
                string[] sname = datalist[i].syProject.Split('、');
                if (sname.Length > 5)
                {
                    spanlistcount += sname.Length / imax2;
                }

            }
            pagecount = Convert.ToInt32(Math.Ceiling((datalist.Count + spanlistcount) / (jmax + 0.0)));
            ex.ActiveSheet(sheetname);
            for (i = 1; i <= wb.Application.Worksheets.Count; i++)
            {
                Excel.Worksheet sheet = wb.Application.Worksheets[i] as Excel.Worksheet;
                if (sheet.Name == sheetname)
                {
                    sheetindex = sheet.Index;
                    break;
                }
            }
            itemp = sheetindex;
            for (i = 1; i < pagecount; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp + 1, sheetname + (i + 1));
                itemp++;

            }
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(orgid);
            for (i = 0; i < pagecount; i++)
            {
                if (Math.Ceiling((i + 1.0) ) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0)));
                else
                    ex.ActiveSheet(sheetname);
                if (org != null)
                    ex.SetCellValue(org.OrgName, 3, 2);
                else
                    ex.SetCellValue("全局", 3, 2);
                if (datalist.Count > 0)
                    ex.SetCellValue(datalist[0].charMan, 26, 15);
            }
            for (i = 0; i < datalist.Count; i++)
            {
                if (Math.Ceiling((i + 1.0 + spanadd) / (jmax)) > 1)
                {
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0 + spanadd) / (jmax)));

                }
                else
                    ex.ActiveSheet(sheetname);
                ex.SetCellValue(Convert.ToString(i + 1), istart + ((i + spanadd) % jmax) * imax2, jstart);
                ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((i + spanadd) % jmax) * imax2, jstart + 1);
                ex.SetCellValue(datalist[i].sbModle, istart + ((i + spanadd) % jmax) * imax2, jstart + 2);
                ex.SetCellValue(datalist[i].sl.ToString(), istart + ((i + spanadd) % jmax) * imax2, jstart + 3);

                ex.SetCellValue(datalist[i].syPeriod, istart + ((i + spanadd) % jmax) * imax2, jstart + 6);

                ex.SetCellValue(datalist[i].preExpTime.Year.ToString() + "年", istart + ((i + spanadd) % jmax) * imax2, jstart + 7);
                ex.SetCellValue(datalist[i].preExpTime.Month.ToString() + "月", istart + ((i + spanadd) % jmax) * imax2, jstart + 8);
                ex.SetCellValue(datalist[i].preExpTime.Day.ToString() + "日", istart + ((i + spanadd) % jmax) * imax2, jstart + 9);

                ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((i + spanadd) % jmax) * imax2, jstart + 10);
                ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((i + spanadd) % jmax) * imax2, jstart + 11);
                ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((i + spanadd) % jmax) * imax2, jstart + 12);
                ex.SetCellValue(datalist[i].charMan , istart + ((i + spanadd) % jmax) * imax2, jstart + 13);
                ex.SetCellValue(datalist[i].Remark, istart + ((i + spanadd) % jmax) * imax2, jstart + 14);

                string[] sname = datalist[i].syProject.Split('、');
                for (itemp = 0; itemp < sname.Length; itemp++)
                {
                    if (itemp < 5)
                        ex.SetCellValue(sname[itemp], istart + ((i + spanadd) % jmax) * imax2 + itemp, jstart + 5);
                    else
                    {
                        spanadd++;
                        setSpanExcel(ex, datalist[i], i, istart, jmax, jstart, ref spanadd, imax2, sheetname, sname, itemp);

                        break;
                    }
                }


            }
            if (isShow)
            {
                ex.ActiveSheet(sheetname);
                ex.ShowExcel();
            }
        }
        /// <summary>
        /// 文档格式预定义好的，生成台账
        /// </summary>
        /// <param name="obj"></param>
        public  void ExportExceldlq(IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";

            ex.Open(fname);
            ExportExceldlqEx(ex, datalist, sheetname, orgid);
        
        }
        public static void ExportExceldlqEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExportExceldlqEx(ex, datalist, sheetname, orgid, true);
        }
        public static void ExportExceldlqEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid, bool isShow)
        {
            
            int pagecount = 0, i = 0, istart = 6, jstart = 1, jmax = 4, sheetindex = 0, spanlistcount = 0, itemp = 0, imax2 = 5, spanadd = 0;
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;
            for (i = 0; i < datalist.Count; i++)
            {
                string[] sname = datalist[i].syProject.Split('、');
                if (sname.Length > 5)
                {
                    spanlistcount +=sname.Length / imax2;
                }
            
            }
            pagecount = Convert.ToInt32(Math.Ceiling((datalist.Count + spanlistcount) / (jmax + 0.0)));
            ex.ActiveSheet(sheetname);
            for (i = 1; i <= wb.Application.Worksheets.Count; i++)
            {
                Excel.Worksheet sheet = wb.Application.Worksheets[i] as Excel.Worksheet;
                if (sheet.Name == sheetname)
                {
                    sheetindex = sheet.Index;
                    break;
                }
            }
             itemp = sheetindex;
            for (i = 1; i < pagecount; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp + 1, sheetname + (i + 1));
                itemp++;

            }
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(orgid);
            for (i = 0; i < pagecount; i++)
            {
                if (Math.Ceiling((i + 1.0 )) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0)));
                else
                    ex.ActiveSheet(sheetname);
                if (org != null)
                    ex.SetCellValue(org.OrgName, 3, 2);
                else
                    ex.SetCellValue("全局", 3, 2);
                if (datalist.Count > 0)
                    ex.SetCellValue(datalist[0].charMan, 26, 15);
            }
            for (i = 0; i < datalist.Count; i++)
            {
                if (Math.Ceiling((i + 1.0 + spanadd) / (jmax)) > 1)
                {
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0 + spanadd) / (jmax)));
                    
                }
                else
                    ex.ActiveSheet(sheetname);
                ex.SetCellValue(Convert.ToString(i + 1), istart + ((i + spanadd) % jmax ) * imax2, jstart);
                ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((i + spanadd) % jmax) * imax2, jstart + 1);
                ex.SetCellValue(datalist[i].sbModle, istart + ((i + spanadd) % jmax ) * imax2, jstart + 2);
                ex.SetCellValue(datalist[i].sl.ToString(), istart + ((i + spanadd) % jmax) * imax2, jstart + 3);

                ex.SetCellValue(datalist[i].syPeriod, istart + ((i + spanadd) % jmax ) * imax2, jstart + 6);

                ex.SetCellValue(datalist[i].preExpTime.Year.ToString() + "年", istart + ((i + spanadd) % jmax) * imax2, jstart + 7);
                ex.SetCellValue(datalist[i].preExpTime.Month.ToString() + "月", istart + ((i + spanadd) % jmax) * imax2, jstart + 8);
                ex.SetCellValue(datalist[i].preExpTime.Day.ToString() + "日", istart + ((i + spanadd) % jmax) * imax2, jstart + 9);

                ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((i + spanadd) % jmax) * imax2, jstart + 10);
                ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((i + spanadd) % jmax) * imax2, jstart + 11);
                ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((i + spanadd) % jmax) * imax2, jstart + 12);
                ex.SetCellValue(datalist[i].Remark, istart + ((i + spanadd) % jmax) * imax2, jstart + 13);

                string[] sname = datalist[i].syProject.Split('、');
                for ( itemp = 0; itemp < sname.Length; itemp++)
                {
                    if (itemp < 5)
                        ex.SetCellValue(sname[itemp], istart + ((i + spanadd) % jmax) * imax2 + itemp, jstart + 5);
                    else
                    {
                        spanadd++;
                        setSpanExcel(ex, datalist[i], i, istart, jmax, jstart,ref spanadd,imax2,sheetname ,sname ,itemp );
                        
                        break;
                    }
                }


            }
            if (isShow)
            {
                ex.ActiveSheet(sheetname);
                ex.ShowExcel();
            }
        }
        public static void setSpanExcel(ExcelAccess ex, PJ_yfsyjl data, int i, int istart, int jmax, int jstart, ref int spanadd, int imax2, string sheetname, string[] sname, int itemp)
        {
            if (Math.Ceiling((i + 1.0 + spanadd) / (jmax)) > 1)
            {
                ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0 + spanadd) / (jmax)));


            }
            else
                ex.ActiveSheet(sheetname);
            ex.SetCellValue(Convert.ToString(i + 1), istart + ((i + spanadd) % jmax) * imax2, jstart);
            ex.SetCellValue(data.sbInstallAdress, istart + ((i + spanadd) % jmax) * imax2, jstart + 1);
            ex.SetCellValue(data.sbModle, istart + ((i + spanadd) % jmax) * imax2, jstart + 2);
            ex.SetCellValue(data.sl.ToString(), istart + ((i + spanadd) % jmax) * imax2, jstart + 3);

            ex.SetCellValue(data.syPeriod, istart + ((i + spanadd) % jmax) * imax2, jstart + 6);
            ex.SetCellValue(data.preExpTime.Year.ToString() + "年", istart + ((i + spanadd) % jmax) * imax2, jstart + 7);
            ex.SetCellValue(data.preExpTime.Month.ToString() + "月", istart + ((i + spanadd) % jmax) * imax2, jstart + 8);
            ex.SetCellValue(data.preExpTime.Day.ToString() + "日", istart + ((i + spanadd) % jmax) * imax2, jstart + 9);

            ex.SetCellValue(data.planExpTime.Year.ToString() + "年", istart + ((i + spanadd) % jmax) * imax2, jstart + 10);
            ex.SetCellValue(data.planExpTime.Month.ToString() + "月", istart + ((i + spanadd) % jmax) * imax2, jstart + 11);
            ex.SetCellValue(data.planExpTime.Day.ToString() + "日", istart + ((i + spanadd) % jmax) * imax2, jstart + 12);
            //ex.SetCellValue(data.charMan, istart + ((i + spanadd) % jmax) * imax2, jstart + 13);
            ex.SetCellValue(data.Remark, istart + ((i + spanadd) % jmax) * imax2, jstart + 13);

            for (int m = 0; m + itemp < sname.Length; m++)
            {
                if (m < 4)
                    ex.SetCellValue(sname[itemp], istart + ((i + spanadd) % jmax) * imax2 + m, jstart + 5);
                else
                {
                    spanadd++;
                    setSpanExcel(ex, data, i, istart, jmax, jstart, ref spanadd, imax2, sheetname, sname, m + itemp);
                    break;
                }
            }
        }




        public  void ExportExcelblqwcqk(IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";

            ex.Open(fname);
            ExportExcelblqwcqkEx(ex, datalist, sheetname, orgid);
        }
        public static void ExportExcelblqwcqkEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExportExcelblqwcqkEx(ex, datalist, sheetname, orgid, true);
        }
        public static void ExportExcelblqwcqkEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid, bool isShow)
        {

            int pagecount = 0, i = 0, istart = 6, jstart = 1, jmax = 5, sheetindex = 0, spanlistcount = 0, itemp = 0, imax2 = 4, spanadd = 0, spanadd2 = 0;
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;
            for (i = 0; i < datalist.Count; i++)
            {
                string[] sname = datalist[i].syProject.Split('、');
                if (sname.Length > 4)
                {
                    spanlistcount += sname.Length / imax2;
                }
                else
                    spanlistcount++;

            }
            pagecount = Convert.ToInt32(Math.Ceiling((spanlistcount) / (jmax + 0.0)));
            ex.ActiveSheet(sheetname);
            for (i = 1; i <= wb.Application.Worksheets.Count; i++)
            {
                Excel.Worksheet sheet = wb.Application.Worksheets[i] as Excel.Worksheet;
                if (sheet.Name == sheetname)
                {
                    sheetindex = sheet.Index;
                    break;
                }
            }
            itemp = sheetindex;
            for (i = 1; i < pagecount; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp + 1, sheetname + (i + 1));
                itemp++;

            }
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(orgid);
            for (i = 0; i < pagecount; i++)
            {
                if (Math.Ceiling((i + 1.0)) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0)));
                else
                    ex.ActiveSheet(sheetname);
                if (org != null)
                    ex.SetCellValue(org.OrgName, 3, 2);
                else
                    ex.SetCellValue("全局", 3, 2);
                if (datalist.Count > 0)
                    ex.SetCellValue(datalist[0].charMan, 26, 15);
            }
            for (i = 0; i < datalist.Count; i++)
            {

                if (Math.Ceiling((spanadd2 + 0.0) / (jmax)) > 1)
                {
                    ex.ActiveSheet(sheetname + Math.Ceiling((spanadd2 + 0.0) / (jmax)));

                }
                else
                    ex.ActiveSheet(sheetname);
                //ex.SetCellValue(datalist[i].xh.ToString(), istart + ((spanadd2) % jmax) * imax2, jstart);
                ex.SetCellValue(Convert.ToString(spanadd + 1), istart + ((spanadd2) % jmax) * imax2, jstart);
                ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((spanadd2) % jmax) * imax2, jstart + 1);
                ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd2) % jmax) * imax2, jstart + 2);
                ex.SetCellValue(datalist[i].sl.ToString(), istart + ((spanadd2) % jmax) * imax2, jstart + 3);

                //ex.SetCellValue(datalist[i].syPeriod, istart + ((spanadd2) % jmax) * imax2, jstart + 6);

                ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((spanadd2) % jmax) * imax2, jstart + 6);
                ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((spanadd2) % jmax) * imax2, jstart + 7);
                ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((spanadd2) % jmax) * imax2, jstart + 8);

                ex.SetCellValue(datalist[i].iswc , istart + ((spanadd2) % jmax) * imax2, jstart + 9);

                ex.SetCellValue(datalist[i].sjExpTime.Year.ToString() + "年", istart + ((spanadd2) % jmax) * imax2, jstart + 10);
                ex.SetCellValue(datalist[i].sjExpTime.Month.ToString() + "月", istart + ((spanadd2) % jmax) * imax2, jstart + 11);
                ex.SetCellValue(datalist[i].sjExpTime.Day.ToString() + "日", istart + ((spanadd2) % jmax) * imax2, jstart + 12);
                ex.SetCellValue(datalist[i].syjg , istart + ((spanadd2) % jmax) * imax2, jstart + 13);
                ex.SetCellValue(datalist[i].wcRemark, istart + ((spanadd2) % jmax) * imax2, jstart + 14);
                string[] sname = datalist[i].syProject.Split('、');
                for (itemp = 0; itemp < sname.Length; itemp++)
                {

                    if ((istart + ((spanadd + itemp / imax2)) * imax2) / 25.0 > 1)
                    {
                        ex.ActiveSheet(sheetname + Math.Ceiling((istart + ((spanadd + itemp / imax2)) * imax2) / 25.0));


                    }
                    else
                        ex.ActiveSheet(sheetname);
                    ex.SetCellValue(sname[itemp], (istart + ((spanadd + itemp / imax2) % jmax) * imax2) + itemp % imax2, jstart + 5);
                    if (itemp % 4 == 0)
                    {
                        //ex.SetCellValue(datalist[i].xh.ToString(), istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart);
                        ex.SetCellValue(Convert.ToString(spanadd + 1), istart + ((spanadd2) % jmax) * imax2, jstart);
                        ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 1);
                        ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 2);
                        ex.SetCellValue(datalist[i].sl.ToString(), istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 3);

                        //ex.SetCellValue(datalist[i].syPeriod, istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 6);


                        ex.SetCellValue(datalist[i].syjg, istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 13);
                        ex.SetCellValue(datalist[i].wcRemark, istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 14);

                        ex.SetCellValue(datalist[i].preExpTime.Year.ToString() + "年", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 6);
                        ex.SetCellValue(datalist[i].preExpTime.Month.ToString() + "月", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 7);
                        ex.SetCellValue(datalist[i].preExpTime.Day.ToString() + "日", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 8);

                        ex.SetCellValue(datalist[i].iswc, istart + ((spanadd2) % jmax) * imax2, jstart + 9);

                        ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 10);
                        ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 11);
                        ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 12);
                        spanadd2++;
                    }
                }
                spanadd = spanadd2;
            }
            if (isShow)
            {
                ex.ActiveSheet(sheetname);
                ex.ShowExcel();
            }
        }
        public  void ExportExcelblqssqk(IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";

            ex.Open(fname);
            ExportExcelblqssqkEx(ex, datalist, sheetname, orgid);
        }
        public static void ExportExcelblqssqkEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExportExcelblqssqkEx(ex, datalist, sheetname, orgid, true);
        }
        public static void ExportExcelblqssqkEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid, bool isShow)
        {

            int pagecount = 0, i = 0, istart = 6, jstart = 1, jmax = 5, sheetindex = 0, spanlistcount = 0, itemp = 0, imax2 = 4, spanadd = 0, spanadd2 = 0;
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;
            for (i = 0; i < datalist.Count; i++)
            {
                string[] sname = datalist[i].syProject.Split('、');
                if (sname.Length > 4)
                {
                    spanlistcount += sname.Length / imax2;
                }
                else
                    spanlistcount++;

            }
            pagecount = Convert.ToInt32(Math.Ceiling((spanlistcount) / (jmax + 0.0)));
            ex.ActiveSheet(sheetname);
            for (i = 1; i <= wb.Application.Worksheets.Count; i++)
            {
                Excel.Worksheet sheet = wb.Application.Worksheets[i] as Excel.Worksheet;
                if (sheet.Name == sheetname)
                {
                    sheetindex = sheet.Index;
                    break;
                }
            }
            itemp = sheetindex;
            for (i = 1; i < pagecount; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp + 1, sheetname + (i + 1));
                itemp++;

            }
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(orgid);
            for (i = 0; i < pagecount; i++)
            {
                if (Math.Ceiling((i + 1.0) ) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0)));
                else
                    ex.ActiveSheet(sheetname);
                if (org != null)
                    ex.SetCellValue(org.OrgName, 3, 2);
                else
                    ex.SetCellValue("全局", 3, 2);
                if (datalist.Count > 0)
                    ex.SetCellValue(datalist[0].charMan, 26, 15);
            }
            for (i = 0; i < datalist.Count; i++)
            {

                if (Math.Ceiling((spanadd2 + 0.0) / (jmax)) > 1)
                {
                    ex.ActiveSheet(sheetname + Math.Ceiling((spanadd2 + 0.0) / (jmax)));

                }
                else
                    ex.ActiveSheet(sheetname);
                //ex.SetCellValue(datalist[i].xh.ToString(), istart + ((spanadd2) % jmax) * imax2, jstart);
                ex.SetCellValue(Convert.ToString(spanadd + 1), istart + ((spanadd2) % jmax) * imax2, jstart);
                ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((spanadd2) % jmax) * imax2, jstart + 1);
                ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd2) % jmax) * imax2, jstart + 2);
                ex.SetCellValue(datalist[i].sl.ToString(), istart + ((spanadd2) % jmax) * imax2, jstart + 3);

                //ex.SetCellValue(datalist[i].syPeriod, istart + ((spanadd2) % jmax) * imax2, jstart + 6);

                ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((spanadd2) % jmax) * imax2, jstart + 6);
                ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((spanadd2) % jmax) * imax2, jstart + 7);
                ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((spanadd2) % jmax) * imax2, jstart + 8);

                ex.SetCellValue(datalist[i].sjExpTime.Year.ToString() + "年", istart + ((spanadd2) % jmax) * imax2, jstart + 9);
                ex.SetCellValue(datalist[i].sjExpTime.Month.ToString() + "月", istart + ((spanadd2) % jmax) * imax2, jstart + 10);
                ex.SetCellValue(datalist[i].sjExpTime.Day.ToString() + "日", istart + ((spanadd2) % jmax) * imax2, jstart + 11);

                string[] sname = datalist[i].syProject.Split('、');
                for (itemp = 0; itemp < sname.Length; itemp++)
                {

                    if ((istart + ((spanadd + itemp / imax2)) * imax2) / 25.0 > 1)
                    {
                        ex.ActiveSheet(sheetname + Math.Ceiling((istart + ((spanadd + itemp / imax2)) * imax2) / 25.0));


                    }
                    else
                        ex.ActiveSheet(sheetname);
                    ex.SetCellValue(sname[itemp], (istart + ((spanadd + itemp / imax2) % jmax) * imax2) + itemp % imax2, jstart + 5);
                    if (itemp % 4 == 0)
                    {
                        //ex.SetCellValue(datalist[i].xh.ToString(), istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart);
                        ex.SetCellValue(Convert.ToString(spanadd + 1), istart + ((spanadd2) % jmax) * imax2, jstart);
                        ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 1);
                        ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 2);
                        ex.SetCellValue(datalist[i].sl.ToString(), istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 3);

                        //ex.SetCellValue(datalist[i].syPeriod, istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 6);


                        ex.SetCellValue(datalist[i].syjg , istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 12);
                        ex.SetCellValue(datalist[i].charMan, istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 13);
                        ex.SetCellValue(datalist[i].syMan , istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 14);

                        ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 6);
                        ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 7);
                        ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 8);

                        ex.SetCellValue(datalist[i].sjExpTime.Year.ToString() + "年", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 9);
                        ex.SetCellValue(datalist[i].sjExpTime.Month.ToString() + "月", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 10);
                        ex.SetCellValue(datalist[i].sjExpTime.Day.ToString() + "日", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 11);
                        spanadd2++;
                    }
                }
                spanadd = spanadd2;
            }
            if (isShow)
            {
                ex.ActiveSheet(sheetname);
                ex.ShowExcel();
            }
        }
        public  void ExportExcelblqjhb(IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";

            ex.Open(fname);
            ExportExcelblqjhbEx(ex, datalist, sheetname, orgid);
        }
        public static void ExportExcelblqjhbEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExportExcelblqjhbEx(ex, datalist, sheetname, orgid, true);
        }
        public static void ExportExcelblqjhbEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid, bool isShow)
        {

            int pagecount = 0, i = 0, istart = 6, jstart = 1, jmax = 5, sheetindex = 0, spanlistcount = 0, itemp = 0, imax2 = 4, spanadd = 0, spanadd2 = 0;
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;
            for (i = 0; i < datalist.Count; i++)
            {
                string[] sname = datalist[i].syProject.Split('、');
                if (sname.Length > 4)
                {
                    spanlistcount += sname.Length / imax2;
                }
                else
                    spanlistcount++;

            }
            pagecount = Convert.ToInt32(Math.Ceiling((spanlistcount) / (jmax + 0.0)));
            ex.ActiveSheet(sheetname);
            for (i = 1; i <= wb.Application.Worksheets.Count; i++)
            {
                Excel.Worksheet sheet = wb.Application.Worksheets[i] as Excel.Worksheet;
                if (sheet.Name == sheetname)
                {
                    sheetindex = sheet.Index;
                    break;
                }
            }
            itemp = sheetindex;
            for (i = 1; i < pagecount; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp + 1, sheetname + (i + 1));
                itemp++;

            }
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(orgid);
            for (i = 0; i < pagecount; i++)
            {
                if (Math.Ceiling((i + 1.0)) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0) ));
                else
                    ex.ActiveSheet(sheetname);
                if (org != null)
                    ex.SetCellValue(org.OrgName, 3, 2);
                else
                    ex.SetCellValue("全局", 3, 2);
                if (datalist.Count > 0)
                    ex.SetCellValue(datalist[0].charMan, 26, 15);
            }
            for (i = 0; i < datalist.Count; i++)
            {

                if (Math.Ceiling((spanadd2 + 0.0) / (jmax)) > 1)
                {
                    ex.ActiveSheet(sheetname + Math.Ceiling((spanadd2 + 0.0) / (jmax)));

                }
                else
                    ex.ActiveSheet(sheetname);
                //ex.SetCellValue(datalist[i].xh.ToString(), istart + ((spanadd2) % jmax) * imax2, jstart);
                ex.SetCellValue(Convert.ToString(spanadd+1), istart + ((spanadd2) % jmax) * imax2, jstart);
                ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((spanadd2) % jmax) * imax2, jstart + 1);
                ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd2) % jmax) * imax2, jstart + 2);
                ex.SetCellValue(datalist[i].sl.ToString(), istart + ((spanadd2) % jmax) * imax2, jstart + 3);

                ex.SetCellValue(datalist[i].syPeriod, istart + ((spanadd2) % jmax) * imax2, jstart + 6);

                ex.SetCellValue(datalist[i].preExpTime.Year.ToString() + "年", istart + ((spanadd2) % jmax) * imax2, jstart + 7);
                ex.SetCellValue(datalist[i].preExpTime.Month.ToString() + "月", istart + ((spanadd2) % jmax) * imax2, jstart + 8);
                ex.SetCellValue(datalist[i].preExpTime.Day.ToString() + "日", istart + ((spanadd2) % jmax) * imax2, jstart + 9);

                ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((spanadd2) % jmax) * imax2, jstart + 10);
                ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((spanadd2) % jmax) * imax2, jstart + 11);
                ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((spanadd2) % jmax) * imax2, jstart + 12);

                string[] sname = datalist[i].syProject.Split('、');
                for (itemp = 0; itemp < sname.Length; itemp++)
                {

                    if ((istart + ((spanadd + itemp / imax2)) * imax2) / 25.0 > 1)
                    {
                        ex.ActiveSheet(sheetname + Math.Ceiling((istart + ((spanadd + itemp / imax2)) * imax2) / 25.0));


                    }
                    else
                        ex.ActiveSheet(sheetname);
                    ex.SetCellValue(sname[itemp], (istart + ((spanadd + itemp / imax2) % jmax) * imax2) + itemp % imax2, jstart + 5);
                    if (itemp % 4 == 0)
                    {
                        //ex.SetCellValue(datalist[i].xh.ToString(), istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart);
                        ex.SetCellValue(Convert.ToString(spanadd + 1), istart + ((spanadd2) % jmax) * imax2, jstart);
                        ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 1);
                        ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 2);
                        ex.SetCellValue(datalist[i].sl.ToString(), istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 3);

                        ex.SetCellValue(datalist[i].syPeriod, istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 6);


                        ex.SetCellValue(datalist[i].Remark, istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 13);

                        ex.SetCellValue(datalist[i].preExpTime.Year.ToString() + "年", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 7);
                        ex.SetCellValue(datalist[i].preExpTime.Month.ToString() + "月", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 8);
                        ex.SetCellValue(datalist[i].preExpTime.Day.ToString() + "日", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 9);

                        ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 10);
                        ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 11);
                        ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 12);
                        spanadd2++;
                    }
                }
                spanadd = spanadd2;
            }
            if (isShow)
            {
                ex.ActiveSheet(sheetname);
                ex.ShowExcel();
            }
        }
        public  void ExportExcelblq(IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";

            ex.Open(fname);
            ExportExcelblqEx(ex, datalist, sheetname, orgid);
        }
        public static void ExportExcelblqEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExportExcelblqEx(ex, datalist, sheetname, orgid, true);
        }
        public static void ExportExcelblqEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid, bool isShow)
        {
            
            int pagecount = 0, i = 0, istart = 6, jstart = 1, jmax = 5, sheetindex = 0, spanlistcount = 0, itemp = 0,  imax2 = 4, spanadd = 0, spanadd2 = 0;
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;
            for (i = 0; i < datalist.Count; i++)
            {
                string[] sname = datalist[i].syProject.Split('、');
                if (sname.Length > 4 )
                {
                    spanlistcount += sname.Length / imax2 ;
                }
                else
                    spanlistcount++;

            }
            pagecount = Convert.ToInt32(Math.Ceiling(( spanlistcount) / (jmax + 0.0)));
            ex.ActiveSheet(sheetname);
            for (i = 1; i <= wb.Application.Worksheets.Count; i++)
            {
                Excel.Worksheet sheet = wb.Application.Worksheets[i] as Excel.Worksheet;
                if (sheet.Name == sheetname)
                {
                    sheetindex = sheet.Index;
                    break;
                }
            }
            itemp = sheetindex;
            for (i = 1; i < pagecount; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp + 1, sheetname + (i + 1));
                itemp++;

            }
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(orgid);
            for (i = 0; i < pagecount; i++)
            {
                if (Math.Ceiling((i + 1.0) ) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0)));
                else
                    ex.ActiveSheet(sheetname);
                if (org != null)
                    ex.SetCellValue(org.OrgName, 3, 2);
                else
                    ex.SetCellValue("全局", 3, 2);
                if (datalist.Count > 0)
                    ex.SetCellValue(datalist[0].charMan, 26, 15);
            }
            for (i = 0; i < datalist.Count; i ++)
            {

                if (Math.Ceiling(( spanadd2+0.0) / (jmax)) > 1)
                {
                    ex.ActiveSheet(sheetname + Math.Ceiling((spanadd2 + 0.0) / (jmax)));

                }
                else
                    ex.ActiveSheet(sheetname);
                //ex.SetCellValue(datalist[i].xh.ToString(), istart + ((spanadd2) % jmax) * imax2, jstart);
                ex.SetCellValue(Convert.ToString(spanadd + 1), istart + ((spanadd2) % jmax) * imax2, jstart);
                ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((spanadd2) % jmax) * imax2, jstart + 1);
                ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd2) % jmax) * imax2, jstart + 2);
                ex.SetCellValue(datalist[i].sl.ToString(), istart + ((spanadd2) % jmax) * imax2, jstart + 3);

                ex.SetCellValue(datalist[i].syPeriod, istart + ((spanadd2) % jmax) * imax2, jstart + 6);

                ex.SetCellValue(datalist[i].preExpTime.Year.ToString() + "年", istart + ((spanadd2) % jmax) * imax2, jstart + 7);
                ex.SetCellValue(datalist[i].preExpTime.Month.ToString() + "月", istart + ((spanadd2) % jmax) * imax2, jstart + 8);
                ex.SetCellValue(datalist[i].preExpTime.Day.ToString() + "日", istart + ((spanadd2) % jmax) * imax2, jstart + 9);

                ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((spanadd2) % jmax) * imax2, jstart + 10);
                ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((spanadd2) % jmax) * imax2, jstart + 11);
                ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((spanadd2) % jmax) * imax2, jstart + 12);

                string[] sname = datalist[i].syProject.Split('、');
                for (itemp = 0; itemp < sname.Length; itemp++)
                {

                    if ((istart + ((spanadd + itemp / imax2)) * imax2) / 25.0 > 1)
                    {
                        ex.ActiveSheet(sheetname + Math.Ceiling((istart + ((spanadd + itemp / imax2)) * imax2) / 25.0));


                    }
                    else
                        ex.ActiveSheet(sheetname);
                    ex.SetCellValue(sname[itemp], (istart + ((spanadd + itemp / imax2) % jmax) * imax2) + itemp % imax2, jstart + 5);
                    if (itemp % 4== 0)
                    {
                        //ex.SetCellValue(datalist[i].xh.ToString(), istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart);
                        ex.SetCellValue(Convert.ToString(spanadd + 1), istart + ((spanadd2) % jmax) * imax2, jstart);
                        ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 1);
                        ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 2);
                        ex.SetCellValue(datalist[i].sl.ToString(), istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 3);

                        ex.SetCellValue(datalist[i].syPeriod, istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 6);


                        ex.SetCellValue(datalist[i].Remark, istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 13);

                        ex.SetCellValue(datalist[i].preExpTime.Year.ToString() + "年", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 7);
                        ex.SetCellValue(datalist[i].preExpTime.Month.ToString() + "月", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 8);
                        ex.SetCellValue(datalist[i].preExpTime.Day.ToString() + "日", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 9);

                        ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 10);
                        ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 11);
                        ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((spanadd + itemp / imax2) % jmax) * imax2 + itemp % imax2, jstart + 12);
                        spanadd2++;
                    }
                }
                spanadd = spanadd2;
            }
            if (isShow)
            {
                ex.ActiveSheet(sheetname);
                ex.ShowExcel();
            }
        }
    

        public  void ExportExceldrqwcqk(IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";

            ex.Open(fname);
            ExportExceldrqwcqkEx(ex, datalist, sheetname, orgid);
        }
        public static void ExportExceldrqwcqkEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExportExceldrqwcqkEx(ex, datalist, sheetname, orgid, true);
        }
        public static void ExportExceldrqwcqkEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid, bool isShow)
        {


            int pagecount = 0, i = 0, istart = 6, jstart = 1, jmax = 4, sheetindex = 0, spanlistcount = 0, itemp = 0, imax1 = 4, imax2 = 5, spanadd = 0, spanadd2 = 0;
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;
            for (i = 0; i < datalist.Count - 1; i += 2)
            {
                string[] sname = datalist[i].syProject.Split('、');
                string[] sname2 = datalist[i + 1].syProject.Split('、');
                if (sname.Length > 4 || sname2.Length > 1)
                {
                    spanlistcount += sname.Length / imax1 > sname2.Length ? sname.Length / imax1 : sname2.Length;
                }
                else
                    spanlistcount++;

            }
            pagecount = Convert.ToInt32(Math.Ceiling((spanlistcount) / (jmax + 0.0)));
            ex.ActiveSheet(sheetname);
            for (i = 1; i <= wb.Application.Worksheets.Count; i++)
            {
                Excel.Worksheet sheet = wb.Application.Worksheets[i] as Excel.Worksheet;
                if (sheet.Name == sheetname)
                {
                    sheetindex = sheet.Index;
                    break;
                }
            }
            itemp = sheetindex;
            for (i = 1; i < pagecount; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp + 1, sheetname + (i + 1));
                itemp++;

            }
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(orgid);
            for (i = 0; i < pagecount; i++)
            {
                if (Math.Ceiling((i + 1.0)) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0)));
                else
                    ex.ActiveSheet(sheetname);
                if (org != null)
                    ex.SetCellValue(org.OrgName, 3, 2);
                else
                    ex.SetCellValue("全局",3, 2);
                if (datalist.Count > 0)
                    ex.SetCellValue(datalist[0].charMan, 26, 15);
            }

            for (i = 0; i < datalist.Count - 1; i += 2)
            {

                if (Math.Ceiling((1.0 + spanadd2) / (jmax)) > 1)
                {
                    ex.ActiveSheet(sheetname + Math.Ceiling((1.0 + spanadd2) / (jmax)));

                }
                else
                    ex.ActiveSheet(sheetname);
                //ex.SetCellValue(datalist[i].xh.ToString(), istart + ((spanadd2) % jmax) * imax2, jstart);
                ex.SetCellValue(Convert.ToString(i / 2 + 1), istart + ((spanadd2) % jmax) * imax2, jstart);
                ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((spanadd2) % jmax) * imax2, jstart + 1);
                ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd2) % jmax) * imax2, jstart + 2);
                ex.SetCellValue(datalist[i].sl.ToString(), istart + ((spanadd2) % jmax) * imax2, jstart + 3);

                //ex.SetCellValue(datalist[i].syPeriod, istart + ((spanadd2) % jmax) * imax2, jstart + 6);

                ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((spanadd2) % jmax) * imax2, jstart +6);
                ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((spanadd2) % jmax) * imax2, jstart + 7);
                ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((spanadd2) % jmax) * imax2, jstart + 8);

                ex.SetCellValue(datalist[i].iswc , istart + ((spanadd2) % jmax) * imax2, jstart + 9);

                ex.SetCellValue(datalist[i].sjExpTime.Year.ToString() + "年", istart + ((spanadd2) % jmax) * imax2, jstart + 10);
                ex.SetCellValue(datalist[i].sjExpTime.Month.ToString() + "月", istart + ((spanadd2) % jmax) * imax2, jstart + 11);
                ex.SetCellValue(datalist[i].sjExpTime.Day.ToString() + "日", istart + ((spanadd2) % jmax) * imax2, jstart + 12);

                ex.SetCellValue(datalist[i].syjg, istart + ((spanadd2) % jmax) * imax2 , jstart + 13);
                ex.SetCellValue(datalist[i].wcRemark, istart + ((spanadd2) % jmax) * imax2 , jstart + 14);

                string[] sname = datalist[i].syProject.Split('、');
                for (itemp = 0; itemp < sname.Length; itemp++)
                {

                    if ((istart + ((spanadd + itemp / imax1)) * imax2) / 25.0 > 1)
                    {
                        ex.ActiveSheet(sheetname + Math.Ceiling((istart + ((spanadd + itemp / imax1)) * imax2) / 25.0));


                    }
                    else
                        ex.ActiveSheet(sheetname);
                    ex.SetCellValue(sname[itemp], (istart + ((spanadd + itemp / imax1) % jmax) * imax2) + itemp % imax1, jstart + 5);
                    if (itemp % 4 == 0)
                    {
                        //ex.SetCellValue(datalist[i].xh.ToString(), istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart);
                        ex.SetCellValue(Convert.ToString(i / 2 + 1), istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart);
                        ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 1);
                        ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 2);
                        ex.SetCellValue(datalist[i].sl.ToString(), istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 3);
                        //ex.SetCellValue(datalist[i].syPeriod, istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 6);

                        //ex.SetCellValue(datalist[i].syjg, istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 12);
                        //ex.SetCellValue(datalist[i].charMan, istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 13);
                        //ex.SetCellValue(datalist[i].syMan, istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 14);

                        ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 6);
                        ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 7);
                        ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 8);

                        ex.SetCellValue(datalist[i].iswc, istart + ((spanadd2) % jmax) * imax2, jstart + 9);

                        ex.SetCellValue(datalist[i].sjExpTime.Year.ToString() + "年", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 10);
                        ex.SetCellValue(datalist[i].sjExpTime.Month.ToString() + "月", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 11);
                        ex.SetCellValue(datalist[i].sjExpTime.Day.ToString() + "日", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 12);
                        ex.SetCellValue(datalist[i].syjg, istart + ((spanadd2) % jmax) * imax2, jstart + 13);
                        ex.SetCellValue(datalist[i].wcRemark, istart + ((spanadd2) % jmax) * imax2, jstart + 14);
                        spanadd2++;
                    }


                }
                if (datalist[i + 1].syProject != "")
                {
                    string[] sname2 = datalist[i + 1].syProject.Split('、');

                    for (itemp = 0; itemp < sname2.Length; itemp++)
                    {
                        if ((istart + ((spanadd + itemp)) * imax2 + 4) / 26.0 > 1)
                        {
                            ex.ActiveSheet(sheetname + Math.Ceiling((istart + ((spanadd + itemp)) * imax2 + 4) / 26.0));


                        }
                        else
                            ex.ActiveSheet(sheetname);
                        //ex.SetCellValue(datalist[i].xh.ToString(), istart + ((spanadd + itemp) % jmax) * imax2, jstart);
                        ex.SetCellValue(Convert.ToString(i / 2 + 1), istart + ((spanadd + itemp) % jmax) * imax2, jstart);
                        ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((spanadd + itemp) % jmax) * imax2, jstart + 1);
                        ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd + itemp) % jmax) * imax2, jstart + 2);
                        ex.SetCellValue(datalist[i].sl.ToString(), istart + ((spanadd + itemp) % jmax) * imax2, jstart + 3);

                        ex.SetCellValue(sname2[itemp], (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 5);

                        //ex.SetCellValue(datalist[i + 1].syPeriod, (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 6);

                        ex.SetCellValue(datalist[i + 1].preExpTime.Year.ToString() + "年", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 6);
                        ex.SetCellValue(datalist[i + 1].preExpTime.Month.ToString() + "月", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 7);
                        ex.SetCellValue(datalist[i + 1].preExpTime.Day.ToString() + "日", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 8);

                        ex.SetCellValue(datalist[i + 1].iswc, (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 9);

                        //ex.SetCellValue(datalist[i + 1].syjg, istart + ((spanadd + itemp) % jmax) * imax2 + 4, jstart + 12);
                        //ex.SetCellValue(datalist[i + 1].charMan, istart + ((spanadd + itemp) % jmax) * imax2 + 4, jstart + 13);
                        //ex.SetCellValue(datalist[i + 1].syMan, istart + ((spanadd + itemp) % jmax) * imax2 + 4, jstart + 14);

                        ex.SetCellValue(datalist[i + 1].planExpTime.Year.ToString() + "年", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 10);
                        ex.SetCellValue(datalist[i + 1].planExpTime.Month.ToString() + "月", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 11);
                        ex.SetCellValue(datalist[i + 1].planExpTime.Day.ToString() + "日", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 12);
                        ex.SetCellValue(datalist[i + 1].syjg, istart + ((spanadd + itemp) % jmax) * imax2 + 4, jstart + 13);
                        ex.SetCellValue(datalist[i + 1].wcRemark, istart + ((spanadd + itemp) % jmax) * imax2 + 4, jstart + 14);





                    }

                    spanadd = spanadd2;
                }


            }
            if (isShow)
            {
                ex.ActiveSheet(sheetname);
                ex.ShowExcel();
            }
        }
        public  void ExportExceldrqssqk(IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";

            ex.Open(fname);
            ExportExceldrqssqkEx(ex, datalist, sheetname, orgid);
        }
        public static void ExportExceldrqssqkEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExportExceldrqssqkEx(ex, datalist, sheetname, orgid, true);
        }
        public static void ExportExceldrqssqkEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid, bool isShow)
        {


            int pagecount = 0, i = 0, istart = 6, jstart = 1, jmax = 4, sheetindex = 0, spanlistcount = 0, itemp = 0, imax1 = 4, imax2 = 5, spanadd = 0, spanadd2 = 0;
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;
            for (i = 0; i < datalist.Count - 1; i += 2)
            {
                string[] sname = datalist[i].syProject.Split('、');
                string[] sname2 = datalist[i + 1].syProject.Split('、');
                if (sname.Length > 4 || sname2.Length > 1)
                {
                    spanlistcount += sname.Length / imax1 > sname2.Length ? sname.Length / imax1 : sname2.Length;
                }
                else
                    spanlistcount++;

            }
            pagecount = Convert.ToInt32(Math.Ceiling((spanlistcount) / (jmax + 0.0)));
            ex.ActiveSheet(sheetname);
            for (i = 1; i <= wb.Application.Worksheets.Count; i++)
            {
                Excel.Worksheet sheet = wb.Application.Worksheets[i] as Excel.Worksheet;
                if (sheet.Name == sheetname)
                {
                    sheetindex = sheet.Index;
                    break;
                }
            }
            itemp = sheetindex;
            for (i = 1; i < pagecount; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp + 1, sheetname + (i + 1));
                itemp++;

            }
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(orgid);
            for (i = 0; i < pagecount; i++)
            {
                if (Math.Ceiling((i + 1.0) ) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0)));
                else
                    ex.ActiveSheet(sheetname);
                if (org != null)
                    ex.SetCellValue(org.OrgName,3, 2);
                else
                    ex.SetCellValue("全局",3, 2);
                if (datalist.Count > 0)
                    ex.SetCellValue(datalist[0].charMan, 26, 14);
            }

            for (i = 0; i < datalist.Count - 1; i += 2)
            {

                if (Math.Ceiling((1.0 + spanadd2) / (jmax)) > 1)
                {
                    ex.ActiveSheet(sheetname + Math.Ceiling((1.0 + spanadd2) / (jmax)));

                }
                else
                    ex.ActiveSheet(sheetname);
                //ex.SetCellValue(datalist[i].xh.ToString(), istart + ((spanadd2) % jmax) * imax2, jstart);
                ex.SetCellValue(Convert.ToString(i / 2 + 1), istart + ((spanadd2) % jmax) * imax2, jstart);
                ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((spanadd2) % jmax) * imax2, jstart + 1);
                ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd2) % jmax) * imax2, jstart + 2);
                ex.SetCellValue(datalist[i].sl.ToString(), istart + ((spanadd2) % jmax) * imax2, jstart + 3);

                //ex.SetCellValue(datalist[i].syPeriod, istart + ((spanadd2) % jmax) * imax2, jstart + 6);

                ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((spanadd2) % jmax) * imax2, jstart + 6);
                ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((spanadd2) % jmax) * imax2, jstart + 7);
                ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((spanadd2) % jmax) * imax2, jstart + 8);

                ex.SetCellValue(datalist[i].sjExpTime.Year.ToString() + "年", istart + ((spanadd2) % jmax) * imax2, jstart + 9);
                ex.SetCellValue(datalist[i].sjExpTime.Month.ToString() + "月", istart + ((spanadd2) % jmax) * imax2, jstart + 10);
                ex.SetCellValue(datalist[i].sjExpTime.Day.ToString() + "日", istart + ((spanadd2) % jmax) * imax2, jstart + 11);

                string[] sname = datalist[i].syProject.Split('、');
                for (itemp = 0; itemp < sname.Length; itemp++)
                {

                    if ((istart + ((spanadd + itemp / imax1)) * imax2) / 25.0 > 1)
                    {
                        ex.ActiveSheet(sheetname + Math.Ceiling((istart + ((spanadd + itemp / imax1)) * imax2) / 25.0));


                    }
                    else
                        ex.ActiveSheet(sheetname);
                    ex.SetCellValue(sname[itemp], (istart + ((spanadd + itemp / imax1) % jmax) * imax2) + itemp % imax1, jstart + 5);
                    if (itemp % 4 == 0)
                    {
                        //ex.SetCellValue(datalist[i].xh.ToString(), istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart);
                        ex.SetCellValue(Convert.ToString(i / 2 + 1), istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart);
                        ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 1);
                        ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 2);
                        ex.SetCellValue(datalist[i].sl.ToString(), istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 3);
                        //ex.SetCellValue(datalist[i].syPeriod, istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 6);

                        ex.SetCellValue(datalist[i].syjg, istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 12);
                        ex.SetCellValue(datalist[i].charMan , istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 13);
                        ex.SetCellValue(datalist[i].syMan , istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 14);

                        ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 6);
                        ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 7);
                        ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 8);

                        ex.SetCellValue(datalist[i].sjExpTime.Year.ToString() + "年", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 9);
                        ex.SetCellValue(datalist[i].sjExpTime.Month.ToString() + "月", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 10);
                        ex.SetCellValue(datalist[i].sjExpTime.Day.ToString() + "日", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 11);
                        spanadd2++;
                    }


                }
                if (datalist[i + 1].syProject != "")
                {
                    string[] sname2 = datalist[i + 1].syProject.Split('、');

                    for (itemp = 0; itemp < sname2.Length; itemp++)
                    {
                        if ((istart + ((spanadd + itemp)) * imax2 + 4) / 26.0 > 1)
                        {
                            ex.ActiveSheet(sheetname + Math.Ceiling((istart + ((spanadd + itemp)) * imax2 + 4) / 26.0));


                        }
                        else
                            ex.ActiveSheet(sheetname);
                        //ex.SetCellValue(datalist[i].xh.ToString(), istart + ((spanadd + itemp) % jmax) * imax2, jstart);
                        ex.SetCellValue(Convert.ToString(i / 2 + 1), istart + ((spanadd + itemp) % jmax) * imax2, jstart);
                        ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((spanadd + itemp) % jmax) * imax2, jstart + 1);
                        ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd + itemp) % jmax) * imax2, jstart + 2);
                        ex.SetCellValue(datalist[i].sl.ToString(), istart + ((spanadd + itemp) % jmax) * imax2, jstart + 3);

                        ex.SetCellValue(sname2[itemp], (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 5);

                        //ex.SetCellValue(datalist[i + 1].syPeriod, (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 6);

                        ex.SetCellValue(datalist[i + 1].preExpTime.Year.ToString() + "年", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 6);
                        ex.SetCellValue(datalist[i + 1].preExpTime.Month.ToString() + "月", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 7);
                        ex.SetCellValue(datalist[i + 1].preExpTime.Day.ToString() + "日", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 8);


                        ex.SetCellValue(datalist[i + 1].syjg, istart + ((spanadd + itemp) % jmax) * imax2 + 4, jstart + 12);
                        ex.SetCellValue(datalist[i + 1].charMan, istart + ((spanadd + itemp) % jmax) * imax2 + 4, jstart + 13);
                        ex.SetCellValue(datalist[i + 1].syMan, istart + ((spanadd + itemp) % jmax) * imax2 + 4, jstart + 14);

                        ex.SetCellValue(datalist[i + 1].planExpTime.Year.ToString() + "年", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 9);
                        ex.SetCellValue(datalist[i + 1].planExpTime.Month.ToString() + "月", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart +10);
                        ex.SetCellValue(datalist[i + 1].planExpTime.Day.ToString() + "日", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 11);





                    }

                    spanadd = spanadd2;
                }


            }
            if (isShow)
            {
                ex.ActiveSheet(sheetname);
                ex.ShowExcel();
            }
        }
        public  void ExportExceldrqjhb(IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";

            ex.Open(fname);
            ExportExceldrqjhbEx(ex, datalist, sheetname, orgid);
        }
        public static void ExportExceldrqjhbEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExportExceldrqjhbEx(ex, datalist, sheetname, orgid, true);
        }
        public static void ExportExceldrqjhbEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid, bool isShow)
        {


            int pagecount = 0, i = 0, istart = 6, jstart = 1, jmax = 4, sheetindex = 0, spanlistcount = 0, itemp = 0, imax1 = 4, imax2 = 5, spanadd = 0, spanadd2 = 0;
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;
            for (i = 0; i < datalist.Count - 1; i += 2)
            {
                string[] sname = datalist[i].syProject.Split('、');
                string[] sname2 = datalist[i + 1].syProject.Split('、');
                if (sname.Length > 4 || sname2.Length > 1)
                {
                    spanlistcount += sname.Length / imax1 > sname2.Length ? sname.Length / imax1 : sname2.Length;
                }
                else
                    spanlistcount++;

            }
            pagecount = Convert.ToInt32(Math.Ceiling((spanlistcount) / (jmax + 0.0)));
            ex.ActiveSheet(sheetname);
            for (i = 1; i <= wb.Application.Worksheets.Count; i++)
            {
                Excel.Worksheet sheet = wb.Application.Worksheets[i] as Excel.Worksheet;
                if (sheet.Name == sheetname)
                {
                    sheetindex = sheet.Index;
                    break;
                }
            }
            itemp = sheetindex;
            for (i = 1; i < pagecount; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp + 1, sheetname + (i + 1));
                itemp++;

            }
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(orgid);
            for (i = 0; i < pagecount; i++)
            {
                if (Math.Ceiling((i + 1.0) ) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0) ));
                else
                    ex.ActiveSheet(sheetname);
                if (org != null)
                    ex.SetCellValue(org.OrgName, 3, 2);
                else
                    ex.SetCellValue("全局", 3, 2);
                if (datalist.Count > 0)
                    ex.SetCellValue(datalist[0].charMan, 26, 14);
            }
            
            for (i = 0; i < datalist.Count - 1; i += 2)
            {

                if (Math.Ceiling((1.0 + spanadd2) / (jmax)) > 1)
                {
                    ex.ActiveSheet(sheetname + Math.Ceiling((1.0 + spanadd2) / (jmax)));

                }
                else
                    ex.ActiveSheet(sheetname);
                //ex.SetCellValue(datalist[i].xh.ToString(), istart + ((spanadd2) % jmax) * imax2, jstart);
                ex.SetCellValue(Convert.ToString(i/2 + 1), istart + ((spanadd2) % jmax) * imax2, jstart);
                ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((spanadd2) % jmax) * imax2, jstart + 1);
                ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd2) % jmax) * imax2, jstart + 2);
                ex.SetCellValue(datalist[i].sl.ToString(), istart + ((spanadd2) % jmax) * imax2, jstart + 3);

                ex.SetCellValue(datalist[i].syPeriod, istart + ((spanadd2) % jmax) * imax2, jstart + 6);

                ex.SetCellValue(datalist[i].preExpTime.Year.ToString() + "年", istart + ((spanadd2) % jmax) * imax2, jstart + 7);
                ex.SetCellValue(datalist[i].preExpTime.Month.ToString() + "月", istart + ((spanadd2) % jmax) * imax2, jstart + 8);
                ex.SetCellValue(datalist[i].preExpTime.Day.ToString() + "日", istart + ((spanadd2) % jmax) * imax2, jstart + 9);

                ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((spanadd2) % jmax) * imax2, jstart + 10);
                ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((spanadd2) % jmax) * imax2, jstart + 11);
                ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((spanadd2) % jmax) * imax2, jstart + 12);

                string[] sname = datalist[i].syProject.Split('、');
                for (itemp = 0; itemp < sname.Length; itemp++)
                {

                    if ((istart + ((spanadd + itemp / imax1)) * imax2) / 25.0 > 1)
                    {
                        ex.ActiveSheet(sheetname + Math.Ceiling((istart + ((spanadd + itemp / imax1)) * imax2) / 25.0));


                    }
                    else
                        ex.ActiveSheet(sheetname);
                    ex.SetCellValue(sname[itemp], (istart + ((spanadd + itemp / imax1) % jmax) * imax2) + itemp % imax1, jstart + 5);
                    if (itemp % 4 == 0)
                    {
                        //ex.SetCellValue(datalist[i].xh.ToString(), istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart);
                        ex.SetCellValue(Convert.ToString(i / 2 + 1), istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart);
                        ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 1);
                        ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 2);
                        ex.SetCellValue(datalist[i].sl.ToString(), istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 3);
                        ex.SetCellValue(datalist[i].syPeriod, istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 6);

                        ex.SetCellValue(datalist[i].Remark, istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 13);

                        ex.SetCellValue(datalist[i].preExpTime.Year.ToString() + "年", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 7);
                        ex.SetCellValue(datalist[i].preExpTime.Month.ToString() + "月", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 8);
                        ex.SetCellValue(datalist[i].preExpTime.Day.ToString() + "日", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 9);

                        ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 10);
                        ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 11);
                        ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 12);
                        spanadd2++;
                    }


                }
                if (datalist[i + 1].syProject != "")
                {
                    string[] sname2 = datalist[i + 1].syProject.Split('、');

                    for (itemp = 0; itemp < sname2.Length; itemp++)
                    {
                        if ((istart + ((spanadd + itemp)) * imax2 + 4) / 26.0 > 1)
                        {
                            ex.ActiveSheet(sheetname + Math.Ceiling((istart + ((spanadd + itemp)) * imax2 + 4) / 26.0));


                        }
                        else
                            ex.ActiveSheet(sheetname);
                        //ex.SetCellValue(datalist[i].xh.ToString(), istart + ((spanadd + itemp) % jmax) * imax2, jstart);
                        ex.SetCellValue(Convert.ToString(i / 2 + 1), istart + ((spanadd + itemp) % jmax) * imax2, jstart);
                        ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((spanadd + itemp) % jmax) * imax2, jstart + 1);
                        ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd + itemp) % jmax) * imax2, jstart + 2);
                        ex.SetCellValue(datalist[i].sl.ToString(), istart + ((spanadd + itemp) % jmax) * imax2, jstart + 3);

                        ex.SetCellValue(sname2[itemp], (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 5);

                        ex.SetCellValue(datalist[i + 1].syPeriod, (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 6);

                        ex.SetCellValue(datalist[i + 1].preExpTime.Year.ToString() + "年", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 7);
                        ex.SetCellValue(datalist[i + 1].preExpTime.Month.ToString() + "月", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 8);
                        ex.SetCellValue(datalist[i + 1].preExpTime.Day.ToString() + "日", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 9);


                        ex.SetCellValue(datalist[i + 1].Remark, istart + ((spanadd + itemp) % jmax) * imax2 + 4, jstart + 13);

                        ex.SetCellValue(datalist[i + 1].planExpTime.Year.ToString() + "年", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 10);
                        ex.SetCellValue(datalist[i + 1].planExpTime.Month.ToString() + "月", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 11);
                        ex.SetCellValue(datalist[i + 1].planExpTime.Day.ToString() + "日", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 12);





                    }

                    spanadd = spanadd2;
                }


            }
            if (isShow)
            {
                ex.ActiveSheet(sheetname);
                ex.ShowExcel();
            }
        }
        public  void ExportExceldrq(IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExcelAccess ex = new ExcelAccess();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string fname = Application.StartupPath + "\\00记录模板\\预防性试验记录.xls";

            ex.Open(fname);
            ExportExceldrqEx( ex, datalist,  sheetname,  orgid);
        }
        public static void ExportExceldrqEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid)
        {
            ExportExceldrqEx(ex, datalist, sheetname, orgid, true);
        }
        public static void ExportExceldrqEx(ExcelAccess ex, IList<PJ_yfsyjl> datalist, string sheetname, string orgid, bool isShow)
        {


            int pagecount = 0, i = 0, istart = 6, jstart = 1, jmax = 4, sheetindex = 0, spanlistcount = 0, itemp = 0, imax1 = 4, imax2 = 5, spanadd = 0, spanadd2 = 0;
            Excel.Workbook wb = ex.MyWorkBook as Excel.Workbook;
            for (i = 0; i < datalist.Count-1; i+=2)
            {
                string[] sname = datalist[i].syProject.Split('、');
                string[] sname2 = datalist[i+1].syProject.Split('、');
                if (sname.Length > 4 || sname2.Length > 1)
                {
                    spanlistcount += sname.Length / imax1 > sname2.Length ? sname.Length / imax1 : sname2.Length;
                }
                else
                    spanlistcount++;

            }
            pagecount = Convert.ToInt32(Math.Ceiling(( spanlistcount) / (jmax + 0.0)));
            ex.ActiveSheet(sheetname);
            for (i = 1; i <= wb.Application.Worksheets.Count; i++)
            {
                Excel.Worksheet sheet = wb.Application.Worksheets[i] as Excel.Worksheet;
                if (sheet.Name == sheetname)
                {
                    sheetindex = sheet.Index;
                    break;
                }
            }
            itemp = sheetindex;
            for (i = 1; i < pagecount; i++)
            {

                ex.CopySheet(sheetindex, itemp);
                ex.ReNameWorkSheet(itemp + 1, sheetname + (i + 1));
                itemp++;

            }
            mOrg org = Client.ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>(orgid);
            for (i = 0; i < pagecount; i++)
            {
                if (Math.Ceiling((i + 1.0) ) > 1)
                    ex.ActiveSheet(sheetname + Math.Ceiling((i + 1.0) ));
                else
                    ex.ActiveSheet(sheetname);
                if (org != null)
                    ex.SetCellValue(org.OrgName, 3, 2);
                else
                    ex.SetCellValue("全局", 3, 2);
                if (datalist.Count > 0)
                    ex.SetCellValue(datalist[0].charMan, 26, 14);
            }
            for (i = 0; i < datalist.Count-1; i+=2)
            {
                
                if (Math.Ceiling((1.0 + spanadd2) / (jmax)) > 1)
                {
                    ex.ActiveSheet(sheetname + Math.Ceiling((1.0 + spanadd2) / (jmax)));

                }
                else
                    ex.ActiveSheet(sheetname);
                //ex.SetCellValue(datalist[i].xh.ToString(), istart + ((spanadd2) % jmax) * imax2, jstart);
                ex.SetCellValue(Convert.ToString(i/2 + 1), istart + ((spanadd2) % jmax) * imax2, jstart);
                ex.SetCellValue(datalist[i].sbInstallAdress, istart + (( spanadd2) % jmax) * imax2, jstart + 1);
                ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd2) % jmax) * imax2, jstart + 2);
                ex.SetCellValue(datalist[i].sl.ToString(), istart + (( spanadd2) % jmax) * imax2, jstart + 3);

                ex.SetCellValue(datalist[i].syPeriod, istart + (( spanadd2) % jmax) * imax2, jstart + 6);

                ex.SetCellValue(datalist[i].preExpTime.Year.ToString() + "年", istart + ((spanadd2) % jmax) * imax2, jstart + 7);
                ex.SetCellValue(datalist[i].preExpTime.Month.ToString() + "月", istart + ((spanadd2) % jmax) * imax2, jstart + 8);
                ex.SetCellValue(datalist[i].preExpTime.Day.ToString() + "日", istart + ((spanadd2) % jmax) * imax2, jstart + 9);

                ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((spanadd2) % jmax) * imax2, jstart + 10);
                ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((spanadd2) % jmax) * imax2, jstart + 11);
                ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((spanadd2) % jmax) * imax2, jstart + 12);

                string[] sname = datalist[i].syProject.Split('、');
                for (itemp = 0; itemp < sname.Length; itemp++)
                {
                 
                    if ((istart + (( spanadd + itemp/imax1 )) * imax2 ) / 25.0 > 1)
                    {
                        ex.ActiveSheet(sheetname + Math.Ceiling((istart + (( spanadd + itemp / imax1)) * imax2) / 25.0));


                    }
                    else
                        ex.ActiveSheet(sheetname);
                    ex.SetCellValue(sname[itemp], (istart + (( spanadd + itemp / imax1) % jmax) * imax2) + itemp % imax1, jstart + 5);
                    if (itemp % 4 == 0)
                    {
                        //ex.SetCellValue(datalist[i].xh.ToString(), istart + (( spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart);
                        ex.SetCellValue(Convert.ToString(i / 2 + 1), istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart);
                        ex.SetCellValue(datalist[i].sbInstallAdress, istart + (( spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 1);
                        ex.SetCellValue(datalist[i].sbModle, istart + (( spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 2);
                        ex.SetCellValue(datalist[i].sl.ToString(), istart + (( spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 3);
                        ex.SetCellValue(datalist[i].syPeriod, istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 6);

                        ex.SetCellValue(datalist[i].Remark, istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 13);

                        ex.SetCellValue(datalist[i].preExpTime.Year.ToString() + "年", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 7);
                        ex.SetCellValue(datalist[i].preExpTime.Month.ToString() + "月", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 8);
                        ex.SetCellValue(datalist[i].preExpTime.Day.ToString() + "日", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 9);

                        ex.SetCellValue(datalist[i].planExpTime.Year.ToString() + "年", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 10);
                        ex.SetCellValue(datalist[i].planExpTime.Month.ToString() + "月", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 11);
                        ex.SetCellValue(datalist[i].planExpTime.Day.ToString() + "日", istart + ((spanadd + itemp / imax1) % jmax) * imax2 + itemp % imax1, jstart + 12);
                        spanadd2++;
                    }
                    
     
                }
                if (datalist[i + 1].syProject != "")
                {
                    string[] sname2 = datalist[i + 1].syProject.Split('、');
                   
                    for (itemp = 0; itemp < sname2.Length; itemp++)
                    {
                        if ((istart + ((spanadd + itemp)) * imax2 + 4 )/ 26.0> 1)
                        {
                            ex.ActiveSheet(sheetname + Math.Ceiling((istart + (( spanadd + itemp)) * imax2 + 4) / 26.0));


                        }
                        else
                            ex.ActiveSheet(sheetname);
                        //ex.SetCellValue(datalist[i].xh.ToString(), istart + (( spanadd + itemp) % jmax) * imax2, jstart);
                        ex.SetCellValue(Convert.ToString(i / 2 + 1), istart + ((spanadd + itemp) % jmax) * imax2, jstart);
                        ex.SetCellValue(datalist[i].sbInstallAdress, istart + ((spanadd + itemp) % jmax) * imax2, jstart + 1);
                        ex.SetCellValue(datalist[i].sbModle, istart + ((spanadd + itemp) % jmax) * imax2, jstart + 2);
                        ex.SetCellValue(datalist[i].sl.ToString(), istart + (( spanadd + itemp) % jmax) * imax2, jstart + 3);

                            ex.SetCellValue(sname2[itemp], (istart + ((spanadd+ itemp ) % jmax) * imax2 + 4), jstart + 5);

                            ex.SetCellValue(datalist[i + 1].syPeriod, (istart + (( spanadd + itemp) % jmax) * imax2 + 4), jstart + 6);

                            ex.SetCellValue(datalist[i + 1].preExpTime.Year.ToString() + "年", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 7);
                            ex.SetCellValue(datalist[i + 1].preExpTime.Month.ToString() + "月", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 8);
                            ex.SetCellValue(datalist[i + 1].preExpTime.Day.ToString() + "日", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 9);


                            ex.SetCellValue(datalist[i+1].Remark, istart + ((spanadd + itemp) % jmax) * imax2 +4, jstart + 13);

                            ex.SetCellValue(datalist[i + 1].planExpTime.Year.ToString() + "年", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 10);
                            ex.SetCellValue(datalist[i + 1].planExpTime.Month.ToString() + "月", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 11);
                            ex.SetCellValue(datalist[i + 1].planExpTime.Day.ToString() + "日", (istart + ((spanadd + itemp) % jmax) * imax2 + 4), jstart + 12);
                           
                      
                            
                            

                      }

                    spanadd = spanadd2;
                }


            }
            if (isShow)
            {
                ex.ActiveSheet(sheetname);
                ex.ShowExcel();
            }
        }
    }
}
