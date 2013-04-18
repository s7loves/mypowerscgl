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

namespace Ebada.Scgl.Core {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCSD_dykSelector : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<sdjl_dyk> gridViewOperation;
        private MemoEdit txt;

        public event SendDataEventHandler<sdjl_dyk> FocusedRowChanged;
        private string parentID="";
        private sdjl_dyk parentObj;
        public UCSD_dykSelector()
        {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<sdjl_dyk>(gridControl1, gridView1, barManager1,null,new UCSD_dykFind());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<sdjl_dyk>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<sdjl_dyk>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged +=gridView1_FocusedRowChanged;
        }
        private IViewOperation<sdjl_dyk> childView;
        /// <summary>
        /// 获取和设置子表的数据操作接口
        /// </summary>
        [Browsable(false)]
        public IViewOperation<sdjl_dyk> ChildView {
            get { return childView; }
            set {
                childView = value;
                if (value != null) {
                    gridView1.Columns["bh"].Caption = "引用编号";
                    gridView1.Columns["zjm"].Caption = "备注";
                    bar3.Visible = false;
                }
            }
        }
        public MemoEdit TextMemo
        {
            get { return txt; }
            set { txt = value; }
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<sdjl_dyk> e) {
            if (childView != null && childView.BindingList.Count > 0) e.Cancel = true;
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<sdjl_dyk> e) {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            gridViewOperation.FindShowType = ShowType.Inside;
            InitColumns();//初始列
            //InitData();//初始数据
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
            btOK.Glyph = Ebada.Scgl.Core.Properties.Resources.ok1;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sdjl_dyk);
        }
        private void hideColumn(string colname) {
            gridView1.Columns[colname].Visible = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site!=null &&this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            RefreshData(" where parentid=''");
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码

            hideColumn("ParentID");
            hideColumn("dx");
            hideColumn("sx");

            gridView1.Columns["nr"].Width = 200;
            gridView1.Columns["nr2"].Width = 200;
            gridView1.Columns["nr3"].Width = 200;
            gridView1.Columns["nr4"].Width = 200;

            
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
        public GridViewOperation<sdjl_dyk> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(sdjl_dyk newobj) {
            newobj.ParentID = parentID;
            if (parentObj != null) {
                newobj.sx = parentObj.sx;
                newobj.dx = parentObj.dx;
            }
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[DesignTimeVisible(false)]
        public string ParentID {
            get { return parentID; }
            set {
                parentID = value;
                if (!string.IsNullOrEmpty(value)) {
                    RefreshData(" where parentid='"+value+"'");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public sdjl_dyk ParentObj {
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

        private void gridControl1_DoubleClick(object sender, EventArgs e) {
            //双击选中行
        }
        /// <summary>
        /// 获取选中的行
        /// </summary>
        /// <returns></returns>
        public sdjl_dyk GetSelectedRow() {
            sdjl_dyk dyk=null;
            if (gridView1.GetFocusedRow() != null)
                dyk = gridView1.GetFocusedRow() as sdjl_dyk;
            return dyk;
        }
        private void btOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (GetSelectedRow() != null)
                this.ParentForm.DialogResult = DialogResult.OK;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (GetSelectedRow() != null)
                this.ParentForm.DialogResult = DialogResult.OK;
        }
    }
}
