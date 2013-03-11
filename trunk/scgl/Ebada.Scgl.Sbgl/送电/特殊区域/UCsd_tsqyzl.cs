/**********************************************
系统:企业ERP
模块:变电所维护
作者:Rabbit
创建时间:2011-5-20
最后一次修改:2011-5-20
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

namespace Ebada.Scgl.Sbgl {
    /// <summary>
    /// 变电所
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCsd_tsqyzl : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<sd_tsqyzl> gridViewOperation;
        
        public event SendDataEventHandler<sd_tsqyzl> FocusedRowChanged;
        private string parentID;
        public UCsd_tsqyzl()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sd_tsqyzl>(gridControl1, gridView1, barManager1);
            gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<sd_tsqyzl>(gridViewOperation_BeforeInsert);
            gridView1.FocusedRowChanged +=gridView1_FocusedRowChanged;
            gridView1.Click += new EventHandler(gridView1_Click);
            //btAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //btDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        void gridViewOperation_BeforeInsert(object render, ObjectOperationEventArgs<sd_tsqyzl> e)
        {
            sd_tsqyzl sbzl = e.Value as sd_tsqyzl;
            IList<sd_tsqyzl> sbzlList= Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_tsqyzl>("where zldm='"+sbzl.zldm+"'");
            if (sbzlList.Count > 0)
            {
                MessageBox.Show("种类代码重复，添加失败!");
                e.Cancel = true;
            }
        }

        void gridView1_Click(object sender, EventArgs e) {
            if (FocusedRowChanged != null && focusedRow!=gridView1.GetFocusedRow()) {
                focusedRow = gridView1.GetFocusedRow();
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sd_tsqyzl);
            }
        }

        void treeViewOperator_BeforeInsert(object render, ObjectOperationEventArgs<sd_tsqyzl> e) {
            
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            btFind.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btExport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            InitColumns();//初始列
            InitData();//初始数据
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        object focusedRow;
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null) {
                focusedRow = gridView1.GetFocusedRow();
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sd_tsqyzl);
            }
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site!=null &&this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码

            RefreshData("order by id" );
            gridView1.BestFitColumns();
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码
            //gridView1.Columns["OrgType"].Visible = false;
            //gridView1.Columns["ParentID"].Visible = false;

            foreach (GridColumn c in gridView1.Columns) {
                c.Visible = false;
            }
            gridView1.Columns["zlmc"].Visible = true;
            gridView1.Columns["zldm"].Visible = true;
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
        public GridViewOperation<sd_tsqyzl> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(sd_tsqyzl newobj) {
           
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
            }
        }

        public void HideList() {
            bar1.Visible = false;
            bar3.Visible = false;
        }
    }
}
