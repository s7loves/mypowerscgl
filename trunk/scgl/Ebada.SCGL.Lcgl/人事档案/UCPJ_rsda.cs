/**********************************************
系统:企业ERP
模块:
作者:Rabbit
创建时间:2011-6-3
最后一次修改:2011-6-3
***********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Client.Platform;

using DevExpress.XtraGrid.Columns;
using System.Reflection;
using Ebada.Client;
using DevExpress.XtraGrid.Views.Base;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using Ebada.Scgl.WFlow;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using DevExpress.XtraEditors.Repository;
using System.Collections;

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCPJ_rsda : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_ryda> gridViewOperation;

        public event SendDataEventHandler<PJ_ryda> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;

        private bool isWorkflowCall = false;
        private frmModleFjly fjly = null;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_ryda,LP_Record";
        public LP_Temple ParentTemple
        {
            get { return parentTemple; }
            set
            {
                parentTemple = value;
            }
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
            set
            {
                currRecord = value;

            }
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
                if (isWorkflowCall)
                {
                    if (RecordWorkTask.HaveRunSPYJRole(currRecord.Kind) || RecordWorkTask.HaveRunFuJianRole(currRecord.Kind))
                    {
                        if (fjly == null) fjly = new frmModleFjly();
                        barFJLY.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                    }
                    IList<WF_WorkTaskCommands> wtlist = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskCommands>("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
                    foreach (WF_WorkTaskCommands wt in wtlist)
                    {
                        if (wt.CommandName == "01")
                        {
                            liuchbarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                            SubmitButton.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                            if (wt.Description != "")
                                SubmitButton.Caption = wt.Description;
                            liuchenBarClear.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                            barFJLY.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        }
                        else
                            if (wt.CommandName == "02")
                            {
                                liuchbarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                                TaskOverButton.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                                if (wt.Description != "")
                                    TaskOverButton.Caption = wt.Description;
                                liuchenBarClear.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                            }

                    }

                }
            }
        }
        public string VarDbTableName
        {
            get { return varDbTableName; }
            set
            {
                varDbTableName = value; ;
            }
        }

        public UCPJ_rsda()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_ryda>(gridControl1, gridView1, barManager1, new frmrsdaTemplate());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_ryda>(gridViewOperation_BeforeAdd);
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<PJ_ryda>(gridViewOperation_BeforeUpdate);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_ryda>(gridViewOperation_AfterAdd);
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_ryda>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_ryda>(gridViewOperation_AfterDelete);
        }
        void gridViewOperation_AfterDelete(PJ_ryda newobj)
        {
            MainHelper.PlatformSqlMap.DeleteByWhere <WF_TableFieldValue>(" where    1=1 "
                                + " and   RecordId='" + newobj.ID  + "'"
                                + " and   WorkFlowId='" + newobj.ID + "'"
                                + " and   WorkFlowInsId='" + newobj.wdmc + "'"
                                + " and   WorkTaskId='安规电子档案'"
                                + " and WorkTaskInsId='安规电子档案'");
        }
        void gridViewOperation_AfterAdd(PJ_ryda newobj)
        {
            if (isWorkflowCall)
            {
                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                mrwt.ModleRecordID = newobj.ID;
                mrwt.RecordID = currRecord.ID;
                mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                mrwt.ModleTableName = newobj.GetType().ToString();
                mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                mrwt.CreatTime = DateTime.Now;
                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                currRecord.DocContent = newobj.BigData;
                MainHelper.PlatformSqlMap.Update<LP_Record>(currRecord);
            }
        }
        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<PJ_ryda> e)
        {
            if (e.Value.BigData == null)
            {
                e.Value.BigData = new byte[0];
            }

        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_ryda> e)
        {


            if (isWorkflowCall)
            {

                MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleRecordWorkTaskIns>(" where ModleRecordID='" + e.Value.ID + "' and RecordID='" + currRecord.ID + "'"
                    + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                    + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                    + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                    + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'");
            }
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_ryda> e)
        {
            if (parentID == null)
                e.Cancel = true;
            e.Value.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            e.Value.CreateMan = m_UserBase.RealName;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();//初始列
            InitData();//初始数据
            if (this.Site != null) return;
            RepositoryItem gdsDic2=new RepositoryItem ();
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>(" where 1=1 order by OrgCode");
                IList<DicType> dic = new List<DicType>();
                dic.Add(new DicType("0", "所有单位"));
                foreach (mOrg gds in list)
                {
                    dic.Add(new DicType(gds.OrgCode, gds.OrgName));
                }
                gdsDic2 = new LookUpDicType(dic);
            btGdsList.Edit = gdsDic2;
            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }
            repositoryItemComboBox1.Items.Clear();
            IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select  UserName  from mUser where   1=1");
            repositoryItemComboBox1.Items.AddRange (strlist);

        }

        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org=null;
            if (list.Count > 0)
                org = list[0];

            if (org != null)
            {
                ParentObj = org;
                repositoryItemComboBox1.Items.Clear();
                IList strlist = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select  UserName  from mUser where   orgcode='" + ParentObj.OrgCode + "'");
                repositoryItemComboBox1.Items.AddRange(strlist);
                if (SelectGdsChanged != null)
                    SelectGdsChanged(this, org);
            }
            else
            {
                RefreshData(" where 1=1");
            }
            

        }
        private void initImageList()
        {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_ryda);
        }
        private void hideColumn(string colname)
        {
            gridView1.Columns[colname].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            //RefreshData("");
            //if (MainHelper.UserOrg != null)
            {
                string strSQL = "where OrgCode='" + parentID + "' ";
                RefreshData(strSQL);
            }
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码


            //hideColumn("OrgName");
            hideColumn("OrgCode");
            hideColumn("S1");
            hideColumn("S2");
            hideColumn("S3");
            hideColumn("BigData");
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            //if (isWorkflowCall)
            //{
            //    if (slqwhere == "") slqwhere = " where 1=1";
            //    slqwhere = slqwhere + " and id  in (select ModleRecordID from WF_ModleRecordWorkTaskIns where RecordID='" + CurrRecord.ID + "'";
            //    slqwhere = slqwhere + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
            //       + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
            //       + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
            //       + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "')";
            //}
            slqwhere = slqwhere + " order by ID desc";

            gridViewOperation.RefreshData(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_ryda> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_ryda newobj)
        {
           if (parentID == null) return;
            newobj.OrgCode = parentID;
            newobj.OrgName = parentObj.OrgName;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentID
        {
            get { return parentID; }
            set
            {
                parentID = value;
                if (!string.IsNullOrEmpty(value))
                {
                    RefreshData(" where OrgCode ='" + value + "'");
                }
            }
        }

        
        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            if (parentID != "" && parentID != null)
            {
                RefreshData(" where OrgCode ='" + parentID + "' and wdmc='" + barEditItem1.EditValue + "'");
            }
            else
            {
                RefreshData(" where wdmc='" + barEditItem1.EditValue + "'");
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public mOrg ParentObj
        {
            get { return parentObj; }
            set
            {

                parentObj = value;
                if (value == null)
                {
                    parentID = null;
                }
                else
                {
                    ParentID = value.OrgID;
                }
            }
        }
        /// <summary>
        /// 获得Excel的表格数字位置，去掉字母
        /// </summary>
        /// <param name="cellpos">Excel的表格位置</param>
        /// <returns>Excel的表格数字位置</returns>
        public static int[] GetCellPos(string cellpos)
        {
            cellpos = cellpos.Replace("|", "");
            return new int[] { int.Parse(cellpos.Substring(1)), (int)cellpos[0] - 64 };
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
            ///循环判断当前目录下的文件和目录
            DSOFramerControl ds1 = new DSOFramerControl();

                string filepath = dialog.SelectedPath;
                GetFileList(ds1, filepath);
                //ds1.FileSave();
                //ds1.FileClose();
                ds1.Dispose();
                if (parentObj!=null)
                RefreshData( "where OrgCode ='" + parentObj.OrgCode    + "'");
            }
        }

       
        private void GetFileList(DSOFramerControl ds1, string strCurDir)
        {

            DirectoryInfo dir;
            ///针对当前目录建立目录引用对象
            DirectoryInfo dirInfo = new DirectoryInfo(strCurDir);
            foreach (FileSystemInfo fsi in dirInfo.GetFileSystemInfos())
            {
                if (fsi is FileInfo)
                {

                    if (fsi.Extension.IndexOf(".xls") < 0) continue;
                    string filename = fsi.FullName;
                    ds1.FileOpen(filename);
                    IList<LP_Temple> templeList = new List<LP_Temple>();
                    LP_Temple parentTemple = MainHelper.PlatformSqlMap.GetOne<LP_Temple>("where ParentID not in (select LPID from LP_Temple where 1=1 and  CtrlSize!='目录') and  CellName like '%安规电子档案%'");
                    if (parentTemple != null) templeList = MainHelper.PlatformSqlMap.GetList<LP_Temple>("SelectLP_TempleList",
                        "where ParentID ='" + parentTemple.LPID + "' order by SortID");
                    Excel.Worksheet xx = null;
                    Excel.Workbook wb = ds1.AxFramerControl.ActiveDocument as Excel.Workbook;
                    Excel.Worksheet sheet = wb.Application.Sheets[1] as Excel.Worksheet;
                    PJ_ryda currRecord = new PJ_ryda();
                    currRecord.CreateDate = DateTime.Now;
                    currRecord.BigData = ds1.FileDataGzip;
                    Excel.Range range;
                    WF_TableFieldValue wfv;
                    int i = 0;

                    foreach (LP_Temple lp in templeList)
                    {
                        string[] arrCellPos = lp.CellPos.Split('|');
                        arrCellPos = StringHelper.ReplaceEmpty(arrCellPos).Split('|');
                        if (lp.CtrlType.Contains("uc_gridcontrol"))
                        {
                            if (lp.CellName.IndexOf("培训情况") > -1)
                            {
                                for (i = 0; i < 6; i++)
                                {
                                    range = sheet.get_Range(sheet.Cells[11 + i, 1], sheet.Cells[11 + i, 1]);//坐标
                                    if (range.Value2 != null && range.Value2.ToString() != "")
                                    {
                                        wfv = new WF_TableFieldValue();
                                        wfv.ID = wfv.CreateID();
                                        wfv.RecordId = currRecord.ID;
                                        wfv.WorkFlowId = currRecord.ID;
                                        wfv.WorkFlowInsId = currRecord.wdmc;
                                        wfv.WorkTaskId = "安规电子档案";
                                        wfv.WorkTaskInsId = "安规电子档案";
                                        wfv.UserControlId = parentTemple.LPID;
                                        wfv.XExcelPos = GetCellPos(arrCellPos[0])[0];
                                        wfv.YExcelPos = GetCellPos(arrCellPos[0])[1];
                                        wfv.FieldId = lp.LPID;
                                        wfv.FieldName = lp.CellName + "-" + "培训时间1";
                                        wfv.ExcelSheetName = lp.KindTable;
                                        if (range.Value2 != null)
                                            wfv.ControlValue = range.Value2.ToString();
                                        if (wfv.ControlValue != "" && wfv.FieldName.IndexOf("时间") > 0)
                                        {
                                            wfv.ControlValue = range.Value2.ToString().Replace(".", "-");
                                            DateTime dt = Convert.ToDateTime(wfv.ControlValue);
                                            wfv.ControlValue = dt.ToString("yyyy年MM月dd日");
                                        }
                                        MainHelper.PlatformSqlMap.Create<WF_TableFieldValue>(wfv);

                                        Thread.Sleep(new TimeSpan(100000));//0.1毫秒

                                        range = sheet.get_Range(sheet.Cells[11 + i, 2], sheet.Cells[11 + i, 2]);//坐标
                                        wfv = new WF_TableFieldValue();
                                        wfv.ID = wfv.CreateID();
                                        wfv.RecordId = currRecord.ID;
                                        wfv.WorkFlowId = currRecord.ID;
                                        wfv.WorkFlowInsId = currRecord.wdmc;
                                        wfv.WorkTaskId = "安规电子档案";
                                        wfv.WorkTaskInsId = "安规电子档案";
                                        wfv.UserControlId = parentTemple.LPID;
                                        wfv.XExcelPos = GetCellPos(arrCellPos[1])[0];
                                        wfv.YExcelPos = GetCellPos(arrCellPos[1])[1];
                                        wfv.FieldId = lp.LPID;
                                        wfv.FieldName = lp.CellName + "-" + "培训类别1";
                                        wfv.ExcelSheetName = lp.KindTable;
                                        if (range.Value2 != null)
                                            wfv.ControlValue = range.Value2.ToString();
                                        MainHelper.PlatformSqlMap.Create<WF_TableFieldValue>(wfv);
                                    }

                                    Thread.Sleep(new TimeSpan(100000));//0.1毫秒

                                    range = sheet.get_Range(sheet.Cells[11 + i, 3], sheet.Cells[11 + i, 3]);//坐标
                                    if (range.Value2 != null && range.Value2.ToString() != "")
                                    {
                                        wfv = new WF_TableFieldValue();
                                        wfv.ID = wfv.CreateID();
                                        wfv.RecordId = currRecord.ID;
                                        wfv.WorkFlowId = currRecord.ID;
                                        wfv.WorkFlowInsId = currRecord.wdmc;
                                        wfv.WorkTaskId = "安规电子档案";
                                        wfv.WorkTaskInsId = "安规电子档案";
                                        wfv.UserControlId = parentTemple.LPID;
                                        wfv.XExcelPos = GetCellPos(arrCellPos[2])[0];
                                        wfv.YExcelPos = GetCellPos(arrCellPos[2])[1];
                                        wfv.FieldId = lp.LPID;
                                        wfv.FieldName = lp.CellName + "-" + "培训时间2";
                                        wfv.ExcelSheetName = lp.KindTable;
                                        if (range.Value2 != null)
                                            wfv.ControlValue = range.Value2.ToString();
                                        if (wfv.ControlValue != "" && wfv.FieldName.IndexOf("时间") > 0)
                                        {
                                            wfv.ControlValue = range.Value2.ToString().Replace(".", "-");
                                            DateTime dt = Convert.ToDateTime(wfv.ControlValue);
                                            wfv.ControlValue = dt.ToString("yyyy年MM月dd日");
                                        }

                                        MainHelper.PlatformSqlMap.Create<WF_TableFieldValue>(wfv);
                                        Thread.Sleep(new TimeSpan(100000));//0.1毫秒

                                        range = sheet.get_Range(sheet.Cells[11 + i, 4], sheet.Cells[11 + i, 4]);//坐标
                                        wfv = new WF_TableFieldValue();
                                        wfv.ID = wfv.CreateID();
                                        wfv.RecordId = currRecord.ID;
                                        wfv.WorkFlowId = currRecord.ID;
                                        wfv.WorkFlowInsId = currRecord.wdmc;
                                        wfv.WorkTaskId = "安规电子档案";
                                        wfv.WorkTaskInsId = "安规电子档案";
                                        wfv.UserControlId = parentTemple.LPID;
                                        wfv.XExcelPos = GetCellPos(arrCellPos[3])[0];
                                        wfv.YExcelPos = GetCellPos(arrCellPos[3])[1];
                                        wfv.FieldId = lp.LPID;
                                        wfv.FieldName = lp.CellName + "-" + "培训类别2";
                                        wfv.ExcelSheetName = lp.KindTable;
                                        if (range.Value2 != null)
                                            wfv.ControlValue = range.Value2.ToString();
                                        MainHelper.PlatformSqlMap.Create<WF_TableFieldValue>(wfv);
                                    }
                                }
                            }
                            else if (lp.CellName.IndexOf("考试情况") > -1)
                            {
                                for (i = 0; i < 12; i++)
                                {
                                    range = sheet.get_Range(sheet.Cells[19 + i, 1], sheet.Cells[19 + i, 1]);//坐标
                                    if (range.Value2 != null && range.Value2.ToString() != "")
                                    {

                                        wfv = new WF_TableFieldValue();
                                        wfv.ID = wfv.CreateID();
                                        wfv.RecordId = currRecord.ID;
                                        wfv.WorkFlowId = currRecord.ID;
                                        wfv.WorkFlowInsId = currRecord.wdmc;
                                        wfv.WorkTaskId = "安规电子档案";
                                        wfv.WorkTaskInsId = "安规电子档案";
                                        wfv.UserControlId = parentTemple.LPID;
                                        wfv.XExcelPos = GetCellPos(arrCellPos[0])[0];
                                        wfv.YExcelPos = GetCellPos(arrCellPos[0])[1];
                                        wfv.FieldId = lp.LPID;
                                        wfv.FieldName = lp.CellName + "-" + "考试时间";
                                        wfv.ExcelSheetName = lp.KindTable;
                                        if (range.Value2 != null)
                                            wfv.ControlValue = range.Value2.ToString();
                                        if (wfv.ControlValue != "" && wfv.FieldName.IndexOf("时间") > 0)
                                        {
                                            wfv.ControlValue = range.Value2.ToString().Replace(".", "-");
                                            DateTime dt = Convert.ToDateTime(wfv.ControlValue);
                                            wfv.ControlValue = dt.ToString("yyyy年MM月dd日");
                                        }
                                        MainHelper.PlatformSqlMap.Create<WF_TableFieldValue>(wfv);
                                        Thread.Sleep(new TimeSpan(100000));//0.1毫秒

                                        range = sheet.get_Range(sheet.Cells[19 + i, 2], sheet.Cells[19 + i, 2]);//坐标
                                        wfv = new WF_TableFieldValue();
                                        wfv.ID = wfv.CreateID();
                                        wfv.RecordId = currRecord.ID;
                                        wfv.WorkFlowId = currRecord.ID;
                                        wfv.WorkFlowInsId = currRecord.wdmc;
                                        wfv.WorkTaskId = "安规电子档案";
                                        wfv.WorkTaskInsId = "安规电子档案";
                                        wfv.UserControlId = parentTemple.LPID;
                                        wfv.XExcelPos = GetCellPos(arrCellPos[1])[0];
                                        wfv.YExcelPos = GetCellPos(arrCellPos[1])[1];
                                        wfv.FieldId = lp.LPID;
                                        wfv.FieldName = lp.CellName + "-" + "考试类别";
                                        wfv.ExcelSheetName = lp.KindTable;
                                        if (range.Value2 != null)
                                            wfv.ControlValue = range.Value2.ToString();
                                        MainHelper.PlatformSqlMap.Create<WF_TableFieldValue>(wfv);


                                        Thread.Sleep(new TimeSpan(100000));//0.1毫秒

                                        range = sheet.get_Range(sheet.Cells[19 + i, 3], sheet.Cells[19 + i, 3]);//坐标

                                        wfv = new WF_TableFieldValue();
                                        wfv.ID = wfv.CreateID();
                                        wfv.RecordId = currRecord.ID;
                                        wfv.WorkFlowId = currRecord.ID;
                                        wfv.WorkFlowInsId = currRecord.wdmc;
                                        wfv.WorkTaskId = "安规电子档案";
                                        wfv.WorkTaskInsId = "安规电子档案";
                                        wfv.UserControlId = parentTemple.LPID;
                                        wfv.XExcelPos = GetCellPos(arrCellPos[2])[0];
                                        wfv.YExcelPos = GetCellPos(arrCellPos[2])[1];
                                        wfv.FieldId = lp.LPID;
                                        wfv.FieldName = lp.CellName + "-" + "考试成绩";
                                        wfv.ExcelSheetName = lp.KindTable;
                                        if (range.Value2 != null)
                                            wfv.ControlValue = range.Value2.ToString();
                                        MainHelper.PlatformSqlMap.Create<WF_TableFieldValue>(wfv);

                                        Thread.Sleep(new TimeSpan(100000));//0.1毫秒

                                        range = sheet.get_Range(sheet.Cells[19 + i, 4], sheet.Cells[19 + i, 4]);//坐标
                                        wfv = new WF_TableFieldValue();
                                        wfv.ID = wfv.CreateID();
                                        wfv.RecordId = currRecord.ID;
                                        wfv.WorkFlowId = currRecord.ID;
                                        wfv.WorkFlowInsId = currRecord.wdmc;
                                        wfv.WorkTaskId = "安规电子档案";
                                        wfv.WorkTaskInsId = "安规电子档案";
                                        wfv.UserControlId = parentTemple.LPID;
                                        wfv.XExcelPos = GetCellPos(arrCellPos[3])[0];
                                        wfv.YExcelPos = GetCellPos(arrCellPos[3])[1];
                                        wfv.FieldId = lp.LPID;
                                        wfv.FieldName = lp.CellName + "-" + "考试评价";
                                        wfv.ExcelSheetName = lp.KindTable;
                                        if (range.Value2 != null)
                                            wfv.ControlValue = range.Value2.ToString();
                                        MainHelper.PlatformSqlMap.Create<WF_TableFieldValue>(wfv);

                                        Thread.Sleep(new TimeSpan(100000));//0.1毫秒

                                        range = sheet.get_Range(sheet.Cells[19 + i, 5], sheet.Cells[19 + i, 5]);//坐标
                                        wfv = new WF_TableFieldValue();
                                        wfv.ID = wfv.CreateID();
                                        wfv.RecordId = currRecord.ID;
                                        wfv.WorkFlowId = currRecord.ID;
                                        wfv.WorkFlowInsId = currRecord.wdmc;
                                        wfv.WorkTaskId = "安规电子档案";
                                        wfv.WorkTaskInsId = "安规电子档案";
                                        wfv.UserControlId = parentTemple.LPID;
                                        wfv.XExcelPos = GetCellPos(arrCellPos[4])[0];
                                        wfv.YExcelPos = GetCellPos(arrCellPos[4])[1];
                                        wfv.FieldId = lp.LPID;
                                        wfv.FieldName = lp.CellName + "-" + "年检情况";
                                        wfv.ExcelSheetName = lp.KindTable;
                                        if (range.Value2 != null)
                                            wfv.ControlValue = range.Value2.ToString();
                                        MainHelper.PlatformSqlMap.Create<WF_TableFieldValue>(wfv);
                                    }

                                }
                            }
                        }
                        else
                        {
                            range = sheet.get_Range(sheet.Cells[GetCellPos(arrCellPos[0])[0], GetCellPos(arrCellPos[0])[1]], sheet.Cells[GetCellPos(arrCellPos[0])[0], GetCellPos(arrCellPos[0])[1]]);//坐标
                            wfv = new WF_TableFieldValue();
                            wfv.ID = wfv.CreateID();
                            wfv.RecordId = currRecord.ID;
                            wfv.WorkFlowId = currRecord.ID;
                            wfv.WorkFlowInsId = currRecord.wdmc;
                            wfv.WorkTaskId = "安规电子档案";
                            wfv.WorkTaskInsId = "安规电子档案";
                            wfv.UserControlId = parentTemple.LPID;
                            wfv.XExcelPos = GetCellPos(arrCellPos[0])[0];
                            wfv.YExcelPos = GetCellPos(arrCellPos[0])[1];
                            wfv.FieldId = lp.LPID;
                            wfv.FieldName = lp.CellName;
                            wfv.ExcelSheetName = lp.KindTable;
                            if (range.Value2 != null)
                                wfv.ControlValue = range.Value2.ToString();
                            if (wfv.ControlValue != "" && lp.CellName == "出生年月日")
                            {
                                wfv.ControlValue = range.Value2.ToString().Replace(".", "-");
                                DateTime dt = Convert.ToDateTime(wfv.ControlValue);
                                wfv.ControlValue = dt.ToString("yyyy年MM月dd日");
                            }
                            if (wfv.ControlValue != "" && lp.CellName == "参加工作时间")
                            {
                                try
                                {
                                    wfv.ControlValue = range.Value2.ToString().Replace(".", "-");
                                    DateTime dt = Convert.ToDateTime(wfv.ControlValue);

                                    wfv.ControlValue = dt.ToString("yyyy年MM月dd日");
                                }
                                catch
                                {
                                    DateTime dt = new DateTime(Convert.ToInt32(wfv.ControlValue));

                                    wfv.ControlValue = dt.ToString("yyyy年MM月dd日");
                                }
                            }
                            if (lp.CellName == "姓名")
                            {
                                currRecord.wdmc = wfv.ControlValue;
                            }
                            else if (lp.CellName == "职务")
                            {
                                currRecord.wdlx = wfv.ControlValue;
                            }
                            else if (lp.CellName == "所在单位")
                            {
                                currRecord.OrgName = wfv.ControlValue.Replace("绥化市郊农电局", "");
                                mOrg org = MainHelper.PlatformSqlMap.GetOne<mOrg>("where OrgName='" + currRecord.OrgName + "'");
                                if (org != null)
                                {
                                    currRecord.OrgCode = org.OrgCode;
                                }
                            }
                            wfv.WorkFlowInsId = currRecord.wdmc;
                            MainHelper.PlatformSqlMap.Create<WF_TableFieldValue>(wfv);
                            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                        }
                    }
                    currRecord.CreateMan = MainHelper.User.UserName;
                    MainHelper.PlatformSqlMap.Create<PJ_ryda>(currRecord);
                    ds1.FileSave();
                    ds1.FileClose();
                }
                else
                {
                    dir = (DirectoryInfo)fsi;






                    //获取文件夹路径
                    GetFileList(ds1, strCurDir + "\\" + dir.Name);


                }
            }
        }


        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                PJ_ryda OBJECT = gridView1.GetRow(gridView1.FocusedRowHandle) as PJ_ryda;
                if (OBJECT.BigData != null)
                {
                    if (OBJECT.BigData.Length != 0)
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        string fname = "";
                        saveFileDialog1.Filter = "Microsoft Excel (*.xls)|*.xls";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            fname = saveFileDialog1.FileName;
                            //WriteDoc(OBJECT.BigData, fname );
                            DSOFramerControl ds1 = new DSOFramerControl();
                            ds1.FileDataGzip = OBJECT.BigData;
                            //ds1.FileSave();
                            //ds1.FileClose();
                            ds1.FileSave(fname, true);
                            //ExcelAccess ex = new ExcelAccess();

                            
                            //ex.Open(fname);
                            //此处写填充内容代码
                            //ds1.FileSave(fname,true);
                            ds1.FileClose();
                            ds1.Dispose();
                            //ex.ShowExcel();
                            if (MsgBox.ShowAskMessageBox("导出成功，是否打开该文档？") != DialogResult.OK)
                                return;

                            System.Diagnostics.Process.Start(fname);
                        }
                    }
                   

                }
                
            }
        }
        public static void WriteDoc(byte[] img,  string filename)
        {
            BinaryWriter bw;
            FileStream fs;
            try
            {
                byte[] newbt = new byte[img.Length - 10];
                for (int i = 0; i < newbt.Length; i++)
                {
                    newbt[i] = img[i];
                }
                byte[] _excbt = new byte[10];
                for (int i = 0; i < 10; i++)
                {
                    _excbt[i] = img[img.Length - 10 + i];
                }
            

                fs = new FileStream( filename , FileMode.Create, FileAccess.Write);
                bw = new BinaryWriter(fs);
                bw.Write(newbt);
                bw.Flush();
                bw.Close();
                fs.Close();
                
                //System.Diagnostics.Process.Start("C:\\" + filename + "." + Exc);
            }
            catch
            {

            }
        }
        private void SubmitButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void TaskOverButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认此节点结束，并进入下一流程?") != DialogResult.OK)
            {
                //SendMessage(this.Handle, 0x0010, (IntPtr)0, (IntPtr)0);
                return;
            }
            string strmes = "";

            if (RecordWorkTask.CheckOnRiZhi(WorkFlowData))
            {

                RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] {  currRecord });

            }
            WF_WorkTaskCommands wt = (WF_WorkTaskCommands)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
            if (wt != null)
            {
                strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), wt.CommandName);
            }
            else
            {
                strmes = RecordWorkTask.RunWorkFlow(MainHelper.User.UserID, WorkFlowData.Rows[0]["OperatorInsId"].ToString(), WorkFlowData.Rows[0]["WorkTaskInsId"].ToString(), "提交");
            }
            if (strmes.IndexOf("未提交至任何人") > -1)
            {
                MsgBox.ShowTipMessageBox("未提交至任何人,创建失败,请检查流程模板和组织机构配置是否正确!");
                return;
            }
            else
                MsgBox.ShowTipMessageBox(strmes);
            if (fjly == null) fjly = new frmModleFjly();
            fjly.btn_Submit_Click(sender, e);
            strmes = RecordWorkTask.GetWorkFlowTaskCaption(WorkFlowData.Rows[0]["WorkTaskInsId"].ToString());
            if (strmes == "结束节点1")
            {
                currRecord.Status = "存档";
            }
            else
            {
                currRecord.Status = strmes;
            }
            currRecord.LastChangeTime = DateTime.Now.ToString();
            if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
            if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
            MainHelper.PlatformSqlMap.Update("UpdateLP_Record", CurrRecord);
            gridControl1.FindForm().Close();
        }

        private void liuchenBarClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string strmess = "";
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认清除关联信息?") != DialogResult.OK)
            {
                return;
            }
            if (RecordWorkTask.DeleteModleRelationRecord(currRecord, WorkFlowData, ref strmess))
            {
                MsgBox.ShowTipMessageBox("清除成功");
            }
            else
            {
                MsgBox.ShowTipMessageBox("清除失败: " + strmess);
            }


        }

        private void barFJLY_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fjly == null) fjly = new frmModleFjly();
            fjly.CurrRecord = currRecord;
            fjly.RecordWorkFlowData = WorkFlowData;
            fjly.Kind = currRecord.Kind;
            fjly.Status = RecordWorkTask.GetWorkTaskStatus(WorkFlowData, currRecord);
            fjly.ShowDialog();
        }

        private void btEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                return;
            }
            PJ_ryda pj = gridView1.GetFocusedRow() as PJ_ryda;
            frmrsdaTemplate frm = new frmrsdaTemplate();
            frm.CurrRecord = pj;
            frm.RowData = pj;
            frm.Status = "edit";
            if (frm.ShowDialog() == DialogResult.OK)
            {

               
            }
            InitData();
        }

        private void btAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PJ_ryda newobj = new PJ_ryda();
            if (parentID == null) return;
            newobj.OrgCode = parentObj.OrgCode;
            newobj.OrgName = parentObj.OrgName;
            if (parentID != null)
            {
                newobj.OrgCode = parentObj.OrgCode;
                newobj.OrgName = parentObj.OrgName;
            }
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
            frmrsdaTemplate frm = new frmrsdaTemplate();
            frm.CurrRecord = newobj;
            frm.RowData = newobj;
            frm.Status = "add";
            if (frm.ShowDialog() == DialogResult.OK)
            {

                if (isWorkflowCall)
                {
                    WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                    mrwt.ModleRecordID = newobj.ID;
                    mrwt.RecordID = currRecord.ID;
                    mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                    mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                    mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                    mrwt.ModleTableName = newobj.GetType().ToString();
                    mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                    mrwt.CreatTime = DateTime.Now;
                    MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                    MainHelper.PlatformSqlMap.Update<LP_Record>(currRecord);
                }
            }
            InitData();
        }



      
    }
}
