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

namespace Ebada.Scgl.Yxgl {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCSD_gzrjnr : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<sdjl_gzrjnr> gridViewOperation;
        
        public event SendDataEventHandler<sdjl_gzrjnr> FocusedRowChanged;
        private string parentID=null;
        private sdjl_01gzrj parentObj;
        private static UCSD_gzrjnr mInstance;
        public UCSD_gzrjnr()
        {
            InitializeComponent();
            bar3.Visible = false;
            initImageList();
            gridViewOperation = new GridViewOperation<sdjl_gzrjnr>(gridControl1, gridView1, barManager1,new frmSDgzrjnrEdit());
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<sdjl_gzrjnr>(gridViewOperation_BeforeAdd);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeDelete += new ObjectOperationEventHandler<sdjl_gzrjnr>(gridViewOperation_BeforeDelete);
            gridView1.FocusedRowChanged +=gridView1_FocusedRowChanged;
            this.Disposed += new EventHandler(UCPJ_gzrjnr_Disposed);
            mInstance = this;
        }

        void UCPJ_gzrjnr_Disposed(object sender, EventArgs e) {
            mInstance = null;
        }
        
        private IViewOperation<sdjl_gzrjnr> childView;
        /// <summary>
        /// 获取和设置子表的数据操作接口
        /// </summary>
        [Browsable(false)]
        public IViewOperation<sdjl_gzrjnr> ChildView {
            get { return childView; }
            set {
                childView = value;
            }
        }
        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<sdjl_gzrjnr> e) {
            if (childView != null && childView.BindingList.Count > 0) e.Cancel = true;
        }

        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<sdjl_gzrjnr> e) {
            if (parentID == null)
                e.Cancel = true;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            InitColumns();//初始列
            //InitData();//初始数据
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as sdjl_gzrjnr);
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
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码

            gridView1.Columns["seq"].VisibleIndex = 0;

            hideColumn("gzrjID");
            hideColumn("ParentID");
            hideColumn("c1");
            hideColumn("c2");
            hideColumn("c3");
            hideColumn("c4");
            hideColumn("c5");
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
        public GridViewOperation<sdjl_gzrjnr> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(sdjl_gzrjnr newobj) {
            if (parentID == null) return;
            newobj.gzrjID = parentID;
            newobj.CreateDate = DateTime.Now;
            newobj.fssj = DateTime.Now;
            newobj.seq = getSeq();
            newobj.CreateMan = MainHelper.User.UserName;
        }

        private int getSeq() {
            int max = 0;
            foreach (sdjl_gzrjnr nr in gridViewOperation.BindingList) {
                max = Math.Max(max, nr.seq);
            }
            return ++max;
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
                    RefreshData(" where gzrjID='" + value + "' order by seq");
                }
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public sdjl_01gzrj ParentObj {
            get { return parentObj; }
            set {
                
                parentObj = value;
                if (value == null) {
                    parentID = null;
                } else {
                    ParentID = value.gzrjID;
                }
            }
        }

        internal static string GetGdsCode() {
            return mInstance.ParentObj.GdsCode;
        }
    }
}
