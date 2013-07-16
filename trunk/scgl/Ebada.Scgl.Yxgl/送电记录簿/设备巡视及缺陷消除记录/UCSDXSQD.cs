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

namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCSDXSQD : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<sdjl_sbxsqd> gridViewOperation;

        public event SendDataEventHandler<sdjl_sbxsqd> FocusedRowChanged;
        public event SendDataEventHandler<mOrg> SelectGdsChanged;
        private string parentID = null;
        private mOrg parentObj;
        private sdjl_06sbxs xsobj;
        frmSDxsDialog fdialog = null;
        public UCSDXSQD()
        {
            InitializeComponent();
            fdialog = new frmSDxsDialog();
            initImageList();
            gridViewOperation = new GridViewOperation<sdjl_sbxsqd>(gridControl1, gridView1, barManager1, fdialog);
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<sdjl_sbxsqd>(gridViewOperation_BeforeAdd);
            gridViewOperation.BeforeEdit += new ObjectOperationEventHandler<sdjl_sbxsqd>(gridViewOperation_BeforEdit);
            gridViewOperation.CreatingObjectEvent += gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<sdjl_sbxsqd>(gridViewOperation_BeforeDelete);

            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            bar3.Visible = false;

        }
        void gridViewOperation_BeforEdit(object render, ObjectOperationEventArgs<sdjl_sbxsqd> e) {
            if (ParentID == null) {
                e.Cancel = true;
            }
            fdialog.orgcode = parentObj.OrgID;
            //fdialog.RowData = gridView1.GetRow(gridView1.FocusedRowHandle) as sdjl_sbxsqd;
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<sdjl_sbxsqd> e) {

        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<sdjl_sbxsqd> e) {
            if (parentID == null)
                e.Cancel = true;

        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            InitColumns();//初始列
            InitData();//初始数据
            if (this.Site != null) return;
            btGdsList.Edit = DicTypeHelper.GdsDic;
            btGdsList.EditValueChanged += new EventHandler(btGdsList_EditValueChanged);
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1") {//如果是供电所人员，则锁定
                btGdsList.EditValue = MainHelper.UserOrg.OrgCode;
                btGdsList.Edit.ReadOnly = true;
            }

        }

        void btGdsList_EditValueChanged(object sender, EventArgs e) {
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>("where orgcode='" + btGdsList.EditValue + "'");
            mOrg org = null;
            if (list.Count > 0)
                org = list[0];

            if (org != null) {
                ParentObj = org;
                if (SelectGdsChanged != null)
                    SelectGdsChanged(this, org);
            }


        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sdjl_sbxsqd);
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
            gridView1.Columns["LineCode"].Caption = "线路编号";
            hideColumn("c1");
            hideColumn("c2");
            hideColumn("c3");
            hideColumn("c4");
            hideColumn("c5");
            //hideColumn("OrgCode");
            //hideColumn("LineCode");
            //Init_linecode();
            //hideColumn("gzrjID");
        }
        //将关联单位标识改为关联单位
        //并以中文显示
        DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit comboBox;
        public void Init_linecode() {
            if (comboBox == null) {
                gridView1.Columns["LineCode"].Caption = "关联单位";
                comboBox = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                gridView1.Columns["LineCode"].ColumnEdit = comboBox;
                comboBox.DisplayMember = "LineName";
                comboBox.ValueMember = "LineID";
            }
            IList<sd_xl> xl_list = ClientHelper.PlatformSqlMap.GetList<sd_xl>(string.Format(" where orgcode='{0}' and  linevol='35'", parentObj.OrgCode));
            comboBox.DataSource = xl_list;

        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere) {
            gridViewOperation.RefreshData(slqwhere);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<sdjl_sbxsqd> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(sdjl_sbxsqd newobj) {
            if (parentID == null) return;
            if (xsobj == null)
                return;

            fdialog.orgcode = parentObj.OrgID;
            fdialog.lineid = xsobj.LineID;
            //newobj.OrgCode = parentID;
            //newobj.OrgName = parentObj.OrgName;
            //newobj.CreateDate = DateTime.Now;
            //Ebada.Core.UserBase m_UserBase = MainHelper.ValidateLogin();
            //newobj.CreateMan = m_UserBase.RealName;
            //newobj.xssj = DateTime.Now;
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
                    RefreshData(" where LineCode in(select lineid from sd_xl where OrgCode='" + value + "')");
                }
            }
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public sdjl_06sbxs SbxsObj {
            get { return xsobj; }
            set {
                xsobj = value;
                //if (!string.IsNullOrEmpty(value))
                //{
                //    RefreshData(" where LineCode in(select lineid from ps_xl where OrgCode='" + value + "')");
                //}
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public mOrg ParentObj {
            get { return parentObj; }
            set {

                parentObj = value;
                if (value == null) {
                    parentID = null;
                } else {
                    ParentID = value.OrgID;
                }
                Init_linecode();
            }
        }

        private void btView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            //frm06sbxsLine frm = new frm06sbxsLine();
            //frm.orgcode = btGdsList.EditValue.ToString();
            //if (frm.ShowDialog()==DialogResult.OK)
            //{

            //    IList<sdjl_sbxsqd> pj06list = new List<sdjl_sbxsqd>();
            //    pj06list = Client.ClientHelper.PlatformSqlMap.GetList<sdjl_sbxsqd>(" where LineName='" + frm.linename + "'");
            //    Export06.ExportExcel(pj06list);
            //}

        }
    }
}
