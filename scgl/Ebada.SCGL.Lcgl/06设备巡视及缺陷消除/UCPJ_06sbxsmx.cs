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

namespace Ebada.Scgl.Lcgl {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCPJ_06sbxsmx : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<PJ_06sbxsmx> gridViewOperation;

        public event SendDataEventHandler<PJ_06sbxsmx> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private PJ_06sbxs parentObj;
        frm06sbxsmxEdit fmx = new frm06sbxsmxEdit();

        private bool isWorkflowCall = false;
        private LP_Record currRecord = null;
        private DataTable WorkFlowData = null;//实例流程信息
        private LP_Temple parentTemple = null;
        private string varDbTableName = "PJ_06sbxs,PJ_06sbxsmx,LP_Record";
        private bool readOnly = false;
        public bool ReadOnly {
            get { return readOnly; }
            set {
                readOnly = value;
                // btnOK.Visible = 
                // liuchbarSubItem.Enabled = !value;
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
        public UCPJ_06sbxsmx() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<PJ_06sbxsmx>(gridControl1, gridView1, barManager1, fmx);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<PJ_06sbxsmx>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<PJ_06sbxsmx>(gridViewOperation_BeforeDelete);
            gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<PJ_06sbxsmx>(gridViewOperation_BeforeEdit);
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridViewOperation.AfterAdd += new ObjectEventHandler<PJ_06sbxsmx>(gridViewOperation_AfterAdd);
            gridViewOperation.AfterEdit += new ObjectEventHandler<PJ_06sbxsmx>(gridViewOperation_AfterEdit);
            gridViewOperation.AfterDelete += new ObjectEventHandler<PJ_06sbxsmx>(gridViewOperation_AfterDelete);
        }

        void gridViewOperation_AfterDelete(PJ_06sbxsmx obj)
        {
            Delqxmx(obj.ID);
        }

        void gridViewOperation_AfterEdit(PJ_06sbxsmx obj)
        {
            Addqxmx(obj);
        }
        void gridViewOperation_AfterAdd(PJ_06sbxsmx newobj) {
            if (isWorkflowCall) {

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
                //currRecord.DocContent = newobj.BigData;
                //MainHelper.PlatformSqlMap.Update<LP_Record>(currRecord);

            }
            wfgzrz.CreatRiZhi(newobj);
            Addqxmx(newobj);
        }

        //处理缺陷明细  lgmqx
        private void Addqxmx(PJ_06sbxsmx obj)
        {
            PJ_qxfl tempobj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(obj.ID);
            if (obj.xcr == string.Empty)
            {
                if (tempobj == null || tempobj.xcr == string.Empty)
                {
                    MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(obj.ID);
                    PJ_qxfl mx = new PJ_qxfl();
                    mx.ID = obj.ID;
                    mx.OrgCode = obj.OrgCode;
                    mx.OrgName = obj.OrgName;
                    mx.LineID = "07";
                    mx.LineName = obj.LineName;
                    mx.xlqd = obj.xlqd;
                    mx.xssj = obj.xssj;
                    mx.xsr = obj.xsr;
                    mx.qxly = "设备巡视及缺陷消除记录";
                    mx.qxnr = obj.qxnr;
                    mx.qxlb = obj.qxlb;
                    mx.xcqx = obj.xcqx;
                    //lgmqxlast
                    mx.xlid = obj.xlid;
                    mx.xlname = obj.xlname;
                    mx.tqid = obj.tqid;
                    mx.tqname = obj.tqname;
                    mx.byqid = obj.byqid;
                    mx.byqname = obj.byqname;
                    mx.kgid = obj.kgid;
                    mx.kgname = obj.kgname;
                   
                    MainHelper.PlatformSqlMap.Create<PJ_qxfl>(mx);
                }

            }
            else
            {
                if (tempobj != null && tempobj.xcr == string.Empty)
                {
                    MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(obj.ID);
                }

            }

        }
        private void Delqxmx(string id)
        {
            PJ_qxfl tempobj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(id);
            if (tempobj != null && tempobj.xcr == string.Empty)
            {
                MainHelper.PlatformSqlMap.DeleteByKey<PJ_qxfl>(id);
            }
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<PJ_06sbxsmx> e) {

        }
        void gridViewOperation_BeforeEdit(object render, ObjectOperationEventArgs<PJ_06sbxsmx> e) {
            fmx.ParentObj = ParentObj;

           
            //lgmqxlast
            PJ_qxfl tempobj = MainHelper.PlatformSqlMap.GetOneByKey<PJ_qxfl>(e.ValueOld.ID);
            if (tempobj != null)
            {
                e.ValueOld.gdstemp = ParentObj.OrgCode;
                e.ValueOld.xlid = tempobj.xlid;
                e.ValueOld.xlname = tempobj.xlname;
                e.ValueOld.tqid = tempobj.tqid;
                e.ValueOld.tqname = tempobj.tqname;
                e.ValueOld.byqid = tempobj.byqid;
                e.ValueOld.byqname = tempobj.byqname;
                e.ValueOld.kgid = tempobj.kgid;
                e.ValueOld.kgname = tempobj.kgname;
            }
        }
        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<PJ_06sbxsmx> e) {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            //InitColumns();//初始列
            // InitData();//初始数据
            //if (this.Site != null) return;
            //btGdsList.Edit = DicTypeHelper.GdsDic;
            //btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            //if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            //{//如果是供电所人员，则锁定
            //    btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
            //    btGdsList.Edit.ReadOnly = true;
            //}

        }

        void btGdsList_EditValueChanged(object sender, EventArgs e) {
            //IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            //mOrg org=null;
            //if (list.Count > 0)
            //    org = list[0];

            //if (org != null)
            //{
            //    ParentObj = org;
            //    if (SelectGdsChanged != null)
            //        SelectGdsChanged(this, org);
            //}


        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as PJ_06sbxsmx);
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

            hideColumn("OrgCode");
            hideColumn("LineID");
            hideColumn("gzrjID");
            //hideColumn("xcqx");
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere) {
            gridViewOperation.RefreshData(slqwhere);
            this.gridView1.BestFitColumns();
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<PJ_06sbxsmx> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(PJ_06sbxsmx newobj) {
            if (parentID == null) return;
            newobj.ParentID = parentID;
            newobj.LineName = ParentObj.LineName;
            newobj.xlqd = ParentObj.xlqd;
            newobj.OrgCode = parentObj.OrgCode;
            newobj.OrgName = parentObj.OrgName;
            newobj.CreateDate = DateTime.Now;
            Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            newobj.CreateMan = m_UserBase.RealName;
            newobj.xssj = DateTime.Now;
            newobj.xcrq = DateTime.Now;
            fmx.ParentObj = ParentObj;
            try { frmLP.ReadTaskData(newobj, RecordWorkFlowData, ParentTemple, CurrRecord); } catch { }

            newobj.gdstemp = parentObj.OrgCode;
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
                    RefreshData(" where ParentID='" + value + "' order by CreateDate desc");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PJ_06sbxs ParentObj {
            get { return parentObj; }
            set {

                parentObj = value;
                if (value == null) {
                    parentID = null;
                } else {
                    ParentID = value.ID;
                }
            }
        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            ////frm06sbxsLine frm = new frm06sbxsLine();
            ////frm.orgcode = btGdsList.EditValue.ToString();
            ////if (frm.ShowDialog()==DialogResult.OK)
            ////{

            ////    IList<PJ_06sbxsmx> pj06list = new List<PJ_06sbxsmx>();
            ////    pj06list = Client.ClientHelper.PlatformSqlMap.GetList<PJ_06sbxsmx>(" where LineName='" + frm.linename + "'");
            ////    if (pj06list.Count>0)
            ////    {
            ////        Export06.ExportExcel(pj06list);
            ////    }
            ////   else
            ////    {
            ////        MsgBox.ShowTipMessageBox("此线路没有添加巡视情况。");
            ////        return;
            ////    }
            ////}

            //Dictionary<string, List<PJ_06sbxsmx>> diclist = new Dictionary<string, List<PJ_06sbxsmx>>();
            //for (int i = 0; i < gridView1.RowCount;i++ )
            //{
            //    PJ_06sbxsmx _pj = gridView1.GetRow(i) as PJ_06sbxsmx;
            //    if (diclist.ContainsKey(_pj.LineID))
            //    {
            //        diclist[_pj.LineID].Add(_pj);
            //    }
            //    else
            //    {
            //        List<PJ_06sbxsmx> lispj = new List<PJ_06sbxsmx>();
            //        lispj.Add(_pj);
            //        diclist[_pj.LineID] = lispj;
            //    }
            //}
            //foreach (KeyValuePair<string, List<PJ_06sbxsmx>> pp in diclist)
            //{
            //    List<PJ_06sbxsmx> objlist = pp.Value;
            //    if (objlist.Count > 0)
            //    {
            //        Export06.ExportExcel(objlist);
            //    }

            //}

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            //if (parentID == null) return;
            //frmXSQD pd = new frmXSQD();
            //pd.parentobj = ParentObj;
            //if (gridView1.FocusedRowHandle >= 0)
            //{
            //    pd.xsobj = gridView1.GetRow(gridView1.FocusedRowHandle) as PJ_06sbxsmx;
            //}

            //pd.ShowDialog();

        }
    }
}
