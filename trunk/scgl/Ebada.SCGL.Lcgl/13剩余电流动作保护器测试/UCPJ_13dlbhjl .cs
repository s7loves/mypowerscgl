﻿/**********************************************
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

namespace Ebada.Scgl.Lcgl {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCPJ_13dlbhjl : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<PJ_13dlbhjl> gridViewOperation;
        public mOrg gds = null;
        public event SendDataEventHandler<PJ_13dlbhjl> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private PS_tqdlbh parentObj;

        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_13dlbhjl,LP_Record";
        private bool readOnly = false;
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                // btnOK.Visible = 
                //liuchbarSubItem.Enabled = !value;
                btAdd.Enabled = !value;
                btEdit.Enabled = !value;
                btDelete.Enabled = !value;

            }
        }

        public LP_Temple ParentTemple {
            get { return parentTemple; }
            set {
                parentTemple = value;
            }
        }
        public bool IsWorkflowCall {
            set {

                isWorkflowCall = value;
            }
        }
        public LP_Record CurrRecord {
            get { return currRecord; }
            set {
                currRecord = value;

            }
        }

        public DataTable RecordWorkFlowData {
            get {
                return WorkFlowData;
            }
            set {
                WorkFlowData = value;
            }
        }
        public string VarDbTableName {
            get { return varDbTableName; }
            set {
                varDbTableName = value; ;
            }
        }
        public UCPJ_13dlbhjl() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_13dlbhjl>(gridControl1, gridView1, barManager1, new frm13dlbhjlEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_13dlbhjl>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_13dlbhjl>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_13dlbhjl>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_13dlbhjl>(gridViewOperation_AfterDelete);
        }
        void gridViewOperation_AfterDelete(PJ_13dlbhjl obj) {

            string slqwhere = "";
            if (isWorkflowCall) {


                MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleRecordWorkTaskIns>("where ModleRecordID='" +
                   obj.ID + "'"
                   + " and ModleTableName='" + obj.GetType().ToString() + "'"
                   + " and WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                   + " and WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "'"
                   );
            }

            RefreshData(" where sbID='" + parentID + "' ");
        }
        void gridViewOperation_AfterAdd(PJ_13dlbhjl obj) {
            if (isWorkflowCall) {
                WF_ModleRecordWorkTaskIns mrwt = new WF_ModleRecordWorkTaskIns();
                mrwt.ModleRecordID = obj.ID;
                mrwt.RecordID = currRecord.ID;
                mrwt.WorkFlowId = WorkFlowData.Rows[0]["WorkFlowId"].ToString();
                mrwt.WorkFlowInsId = WorkFlowData.Rows[0]["WorkFlowInsId"].ToString();
                mrwt.WorkTaskId = WorkFlowData.Rows[0]["WorkTaskId"].ToString();
                mrwt.WorkTaskInsId = WorkFlowData.Rows[0]["WorkTaskInsId"].ToString();
                mrwt.CreatTime = DateTime.Now;
                mrwt.ModleTableName = obj.GetType().ToString();
                MainHelper.PlatformSqlMap.Create<WF_ModleRecordWorkTaskIns>(mrwt);
            }

            wfgzrz.CreatRiZhi(obj);



            RefreshData(" where sbID='" + parentID + "' ");

        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_13dlbhjl> e) {

        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_13dlbhjl> e) {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            InitColumns();//初始列
            //InitData();//初始数据
            if (this.Site != null) return;


        }

        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_13dlbhjl);
        }
        private void hideColumn(string colname) {
            gridView1.Columns[colname].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码
            //gridView1.Columns[9].Visible = false;
            hideColumn("gznrID");
            hideColumn("OrgCode");
            hideColumn("OrgName");
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere) {


            if (isWorkflowCall) {

                slqwhere = slqwhere + " and id in (select ModleRecordID from WF_ModleRecordWorkTaskIns where RecordID='" + CurrRecord.ID + "'";
                slqwhere = slqwhere + " and  WorkFlowId='" + WorkFlowData.Rows[0]["WorkFlowId"].ToString() + "'"
                   + " and  WorkFlowInsId='" + WorkFlowData.Rows[0]["WorkFlowInsId"].ToString() + "'"
                   + " and  WorkTaskId='" + WorkFlowData.Rows[0]["WorkTaskId"].ToString() + "'"
                   + " and  WorkTaskInsId='" + WorkFlowData.Rows[0]["WorkTaskInsId"].ToString() + "')";

            }
            slqwhere = slqwhere + "  order by CreateDate desc";
            gridViewOperation.RefreshData(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_13dlbhjl> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_13dlbhjl newobj) {
            if (parentID == null) return;
            //  mOrg mg = Client.ClientHelper.PlatformSqlMap.GetOne<mOrg>("where OrgCode in(select orgcode from ps_xl where linecode in(select xlcode from ps_tq where tqid='" + parentObj.tqID + "'))");

            if (gds != null) {
                newobj.OrgCode = gds.OrgCode;
                newobj.OrgName = gds.OrgName;
            }

            newobj.sbID = parentID;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentID {
            get { return parentID; }
            set {
                parentID = value;
                if (!string.IsNullOrEmpty(value)) {
                    RefreshData(" where sbID='" + value + "' ");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PS_tqdlbh ParentObj {
            get { return parentObj; }
            set {

                parentObj = value;
                if (value == null) {
                    parentID = null;
                } else {
                    ParentID = value.sbID;
                }
            }
        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (gridView1.FocusedRowHandle != -1) {
                Export13.ExportExcel(ParentObj);
            }
        }
    }
}
