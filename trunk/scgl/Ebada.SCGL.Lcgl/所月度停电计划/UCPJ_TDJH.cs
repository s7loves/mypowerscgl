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
using DevExpress.Utils;
using Ebada.Scgl.Lcgl;
using Ebada.Scgl.WFlow;
using DevExpress.XtraEditors.Repository;
namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCPJ_TDJH : DevExpress.XtraEditors.XtraUserControl
    {
        private GridViewOperation<PJ_tdjh> gridViewOperation;

        public event SendDataEventHandler<PJ_tdjh> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;

        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_tdjh,LP_Record";
        private bool readOnly = false;
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                // btnOK.Visible = 
                liuchbarSubItem.Enabled = !value;
                btAdd.Enabled = !value;
                btEdit.Enabled = !value;
                btDelete.Enabled = !value;

            }
        }

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

                if (isWorkflowCall)
                {
                    IList<WF_WorkTaskCommands> wtlist = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskCommands>("SelectWF_WorkTaskCommandsList", " where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "' and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'");
                    foreach (WF_WorkTaskCommands wt in wtlist)
                    {
                        if (wt.CommandName == "01")
                        {
                            liuchbarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                            SubmitButton.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            SubmitButton.Caption = wt.Description;
                            liuchenBarClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        }
                        else
                            if (wt.CommandName == "02")
                            {
                                liuchbarSubItem.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                                TaskOverButton.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
                                if (wt.Description != "") TaskOverButton.Caption = wt.Description;
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
                varDbTableName = value;
            }
        }
        public UCPJ_TDJH()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_tdjh>(gridControl1, gridView1, barManager1, new frmTDJHEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_tdjh>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_tdjh>(gridViewOperation_AfterDelete);
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_tdjh>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridView1.RowUpdated += new RowObjectEventHandler(gridView1_RowUpdated);
            btjqx.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btqx.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btzdqx.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        void gridView1_RowUpdated(object sender, RowObjectEventArgs e) {
            try {
                ClientHelper.PlatformSqlMap.Update<PJ_tdjh>(e.Row);
            } catch { }
        }

        private void ChangeText()
        {
            btView.Caption = "导出" + btGdsList.EditValue + "全部历使计划";
            barExplorMonth.Caption = "导出" + btGdsList.EditValue + "下月计划";
        }

        void gridViewOperation_AfterDelete(PJ_tdjh obj)
        {

            if (isWorkflowCall)
            {

                MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleRecordWorkTaskIns>(" where ModleRecordID='" + obj.ID + "' and RecordID='" + currRecord.ID + "'"
                    + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                    + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                    + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                    + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'");
            }

            //if (isWorkflowCall)
            //{

            //    slqwhere = slqwhere + " and id in (select ModleRecordID from WF_ModleRecordWorkTaskIns where RecordID='" + CurrRecord.ID + "'";
            //    slqwhere = slqwhere + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
            //       + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
            //       + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
            //       + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "')";
            //}

            RefreshData(" where OrgCode='" + parentID + "' and IsSelect='false' or IsSelect is null ");
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_tdjh> e)
        {

        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_tdjh> e)
        {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitColumns();//初始列
            //InitData();//初始数据
            if (this.Site != null) return;
            btGdsList.Edit = DicTypeHelper.GdsDic;
            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }

        }

        void btGdsList_EditValueChanged(object sender, EventArgs e)
        {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org = null;
            if (list.Count > 0)
                org = list[0];

            if (org != null)
            {
                ParentObj = org;
                if (SelectGdsChanged != null)
                    SelectGdsChanged(this, org);
            }

            ChangeText();
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
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_tdjh);
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
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns()
        {

            //需要隐藏列时在这写代码

            hideColumn("OrgCode");
            hideColumn("OrgName");
            // hideColumn("S1");
            //hideColumn("S2");
            hideColumn("S3");

            gridView1.Columns["S1"].Caption = "序号";
            gridView1.Columns["S1"].VisibleIndex = 0;
            gridView1.Columns["SQOrgname"].Caption = "供电所名称";
            gridView1.Columns["SQOrgname"].VisibleIndex = 1;
            gridView1.Columns["S2"].Caption = "缺陷发现日期";
            // gridView1.Columns["S3"].Caption = "选择流程";
            gridView1.Columns["IsSelect"].OptionsColumn.AllowEdit = true;
            gridView1.Columns["IsSelect"].ColumnEdit = repositoryItemCheckEdit1;
            gridView1.Columns["TDtime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["TDtime"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            gridView1.Columns["SDtime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["SDtime"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";

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
            //gridViewOperation.RefreshData(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_tdjh> GridViewOperation
        {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_tdjh newobj)
        {
            if (parentID == null) return;
            IList<PJ_tdjh> list = gridControl1.DataSource as IList<PJ_tdjh>;
            newobj.S1 = (list.Count + 1).ToString();
            newobj.OrgCode = parentID;
            newobj.OrgName = parentObj.OrgName;
            newobj.CreateDate = DateTime.Now;
            newobj.TDtime = newobj.CreateDate;
            newobj.SDtime = newobj.CreateDate;
            try { frmLP.ReadTaskData(newobj, RecordWorkFlowData, ParentTemple, CurrRecord); }
            catch { }
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[DesignTimeVisible(false)]
        public string ParentID
        {
            get { return parentID; }
            set
            {
                parentID = value;
                if (!string.IsNullOrEmpty(value))
                {
                    //RefreshData(" where OrgCode='" + value + "'and IsSelect='false'or IsSelect is null ");
                    RefreshData(" where OrgCode='" + value + "' ");
                }
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

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IList<PJ_tdjh> datalist = gridView1.DataSource as IList<PJ_tdjh>;
            ExportTDJH etdjh = new ExportTDJH();
            etdjh.ExportExcel(datalist);



        }

        private void barExplorMonth_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportTDJH etdjh = new ExportTDJH();
            frmTDJHMonthSet fms = new frmTDJHMonthSet();
            if (fms.ShowDialog() == DialogResult.OK)
            {
                //fms.dtTime = fms.dtTime.AddMonths(-1);
                etdjh.ExportExcelMonth(fms.dtTime, fms.dtTime2, parentObj.OrgCode);
            }
        }

        private void SubmitButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmModleSubmit fm = new frmModleSubmit();
            fm.RecordWorkFlowData = WorkFlowData;
            fm.CurrRecord = currRecord;
            if (currRecord.Status == "申报")
                fm.Status = "add";
            else
                fm.Status = "edit";
            fm.Kind = currRecord.Kind;
            frmTDJHMonthSet fms = new frmTDJHMonthSet();
            if (fms.ShowDialog() == DialogResult.OK)
            {
                ExportTDJH export = new ExportTDJH();
                export.CurrRecord = currRecord;
                export.IsWorkflowCall = isWorkflowCall;
                export.ParentTemple = parentTemple;
                export.RecordWorkFlowData = WorkFlowData;

                fms.dtTime = fms.dtTime.AddMonths(-1);
                export.ExportExcelSubmit(fms.dtTime, fms.dtTime2, ref parentTemple, parentID, false);

                fm.ParentTemple = parentTemple;
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    if (MainHelper.UserOrg.OrgName.IndexOf("局") == -1)
                        export.ExportExceljhbAllSubmitToWF_ModleRecordWorkTaskIns(fms.dtTime, fms.dtTime2, parentID);
                    else
                        export.ExportExceljhbAllSubmitToWF_ModleRecordWorkTaskIns(fms.dtTime, fms.dtTime2, parentID);
                    gridControl1.FindForm().Close();
                }
            }
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

                RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { currRecord });

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

        private void btjqx_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isWorkflowCall)
            {
                IList<PJ_tdjh> list = gridView1.DataSource as IList<PJ_tdjh>;
                //PJ_tdjh obj = gridView1.GetFocusedRow() as PJ_tdjh;
                foreach (PJ_tdjh obj in list)
                {
                    if (obj.IsSelect)
                    {
                        WF_ModleRecordWorkTaskIns mrwt = null;
                        mrwt = MainHelper.PlatformSqlMap.GetOne<WF_ModleRecordWorkTaskIns>(" where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"] + "'"
                                + " and WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"] + "'"
                                + " and ModleRecordID='" + obj.ID + "'"
                                + " and WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'"
                                + " and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"

                        );
                        if (mrwt == null)
                        {
                            mrwt = new WF_ModleRecordWorkTaskIns();
                            mrwt.ModleRecordID = obj.ID;
                            mrwt.RecordID = currRecord.ID;
                            mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                            mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                            mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                            mrwt.ModleTableName = obj.GetType().ToString();
                            mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                            mrwt.CreatTime = DateTime.Now;
                            MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                        }
                    }
                    MainHelper.PlatformSqlMap.Update<PJ_tdjh>(obj);
                }


            }
            string statustemp = currRecord.Status;
            currRecord.Status = "紧急缺陷";
            MainHelper.PlatformSqlMap.Update<LP_Record>(currRecord);
            string strmes = "";


            if (RecordWorkTask.CheckOnRiZhi(WorkFlowData))
            {

                RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { currRecord });

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
                currRecord.Status = statustemp;
                if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
                if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
                MainHelper.PlatformSqlMap.Update("UpdateLP_Record", CurrRecord);
                return;
            }
            else
                MsgBox.ShowTipMessageBox(strmes);
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

        private void btzdqx_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isWorkflowCall)
            {
                IList<PJ_tdjh> list = gridView1.DataSource as IList<PJ_tdjh>;
                //PJ_tdjh obj = gridView1.GetFocusedRow() as PJ_tdjh;
                foreach (PJ_tdjh obj in list)
                {
                    if (obj.IsSelect)
                    {
                        WF_ModleRecordWorkTaskIns mrwt = null;
                        mrwt = MainHelper.PlatformSqlMap.GetOne<WF_ModleRecordWorkTaskIns>(" where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"] + "'"
                                + " and WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"] + "'"
                                + " and ModleRecordID='" + obj.ID + "'"
                                + " and WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'"
                                + " and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"

                        );
                        if (mrwt == null)
                        {
                            mrwt = new WF_ModleRecordWorkTaskIns();
                            mrwt.ModleRecordID = obj.ID;
                            mrwt.RecordID = currRecord.ID;
                            mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                            mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                            mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                            mrwt.ModleTableName = obj.GetType().ToString();
                            mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                            mrwt.CreatTime = DateTime.Now;
                            MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                        }
                    }
                    MainHelper.PlatformSqlMap.Update<PJ_tdjh>(obj);
                }
            }
            string statustemp = currRecord.Status;
            currRecord.Status = "重大缺陷";
            MainHelper.PlatformSqlMap.Update<LP_Record>(currRecord);
            string strmes = "";


            if (RecordWorkTask.CheckOnRiZhi(WorkFlowData))
            {

                RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { currRecord });

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
                currRecord.Status = statustemp;
                if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
                if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
                MainHelper.PlatformSqlMap.Update("UpdateLP_Record", CurrRecord);
                return;
            }
            else
                MsgBox.ShowTipMessageBox(strmes);
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

        private void btqx_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isWorkflowCall)
            {
                IList<PJ_tdjh> list = gridView1.DataSource as IList<PJ_tdjh>;
                //PJ_tdjh obj = gridView1.GetFocusedRow() as PJ_tdjh;
                foreach (PJ_tdjh obj in list)
                {
                    if (obj.IsSelect)
                    {
                        WF_ModleRecordWorkTaskIns mrwt = null;
                        mrwt = MainHelper.PlatformSqlMap.GetOne<WF_ModleRecordWorkTaskIns>(" where WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"] + "'"
                                + " and WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"] + "'"
                                + " and ModleRecordID='" + obj.ID + "'"
                                + " and WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'"
                                + " and WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"

                        );
                        if (mrwt == null)
                        {
                            mrwt = new WF_ModleRecordWorkTaskIns();
                            mrwt.ModleRecordID = obj.ID;
                            mrwt.RecordID = currRecord.ID;
                            mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                            mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                            mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                            mrwt.ModleTableName = obj.GetType().ToString();
                            mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                            mrwt.CreatTime = DateTime.Now;
                            MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
                        }
                    }
                    MainHelper.PlatformSqlMap.Update<PJ_tdjh>(obj);
                }
            }
            string statustemp = currRecord.Status;
            currRecord.Status = "一般缺陷";
            MainHelper.PlatformSqlMap.Update<LP_Record>(currRecord);
            string strmes = "";


            if (RecordWorkTask.CheckOnRiZhi(WorkFlowData))
            {

                RecordWorkTask.CreatRiZhi(WorkFlowData, null, currRecord.ID, new object[] { currRecord });

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
                currRecord.Status = statustemp;
                if (currRecord.ImageAttachment == null) currRecord.ImageAttachment = new byte[0];
                if (currRecord.SignImg == null) currRecord.SignImg = new byte[0];
                MainHelper.PlatformSqlMap.Update("UpdateLP_Record", CurrRecord);
                return;
            }
            else
                MsgBox.ShowTipMessageBox(strmes);
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

        private void repositoryItemCheckEdit1_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                PJ_tdjh obj = gridView1.GetRow(gridView1.FocusedRowHandle) as PJ_tdjh;
                obj.IsSelect = Convert.ToBoolean(repositoryItemCheckEdit1.ValueChecked);


            }
        }

    }
}
