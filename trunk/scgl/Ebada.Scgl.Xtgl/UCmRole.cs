/**********************************************
系统:企业ERP
模块:示例
作者:Rabbit
创建时间:2011-2-28
最后一次修改:2011-2-28
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

namespace Ebada.Scgl.Xtgl {

    public partial class UCmRole : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<mRole> gridViewOperation;
        
        public event SendDataEventHandler<mRole> FocusedRowChanged;
        private string parentID;
        private mOrg parentObj;
        public UCmRole() {
            InitializeComponent();
            initImageList();

            gridViewOperation = new GridViewOperation<mRole>(gridControl1, gridView1, barManager1);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<mRole>(gridViewOperation_BeforeAdd);
            gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
            gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<mRole>(gridViewOperation_BeforeInsert);
            gridViewOperation.BeforeUpdate += new ObjectOperationEventHandler<mRole>(gridViewOperation_BeforeUpdate);
            
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            InitData();
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site != null && this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            initColumns();
            gridViewOperation.RefreshData("");
        }
        void gridViewOperation_BeforeUpdate(object render, ObjectOperationEventArgs<mRole> e) {
        }

        void gridViewOperation_BeforeInsert(object render, ObjectOperationEventArgs<mRole> e) {
        }
        /// <summary>
        /// 设置隐藏列
        /// </summary>
        void initColumns() {
            hideColumn("C1");
            hideColumn("C2");
            hideColumn("C3");
            hideColumn("C4");
            hideColumn("C5");
        }
        private void hideColumn(string colname) {
            gridView1.Columns[colname].Visible = false;
        }
        void repositoryItemTextEdit1_EditValueChanged(object sender, EventArgs e) {
            
        }
        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<mRole> e) {
            
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as mRole);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public GridViewOperation<mRole> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(mRole newobj) {
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentID {
            get { return parentID; }
            set {

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
            }
        }

        private void btRight_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

        }
    }
}
