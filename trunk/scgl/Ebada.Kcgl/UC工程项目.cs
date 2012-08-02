﻿/**********************************************
系统:库存管理
模块:工程项目管理
作者:Rabbit
创建时间:2012-7-28
最后一次修改:2012-7-28
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
using Ebada.Kcgl.Model;

namespace Ebada.Kcgl {
    /// <summary>
    /// 工程项目管理
    /// </summary>
    [ToolboxItem(false)]
    public partial class UC工程项目 : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<Model.kc_工程项目> gridViewOperation;

        public event SendDataEventHandler<Model.kc_工程项目> FocusedRowChanged;
        private string parentID;
        public UC工程项目() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<Model.kc_工程项目>(gridControl1, gridView1, barManager1,true);

            gridViewOperation.BeforeInsert += new ObjectOperationEventHandler<kc_工程项目>(gridViewOperation_BeforeSave);
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridView1.FocusedRowChanged +=gridView1_FocusedRowChanged;
            gridView1.OptionsView.ColumnAutoWidth = true;
            btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        void gridViewOperation_BeforeSave(object render, ObjectOperationEventArgs<kc_工程项目> e) {
            if (string.IsNullOrEmpty(e.Value.工程项目名称)) {
                MsgBox.ShowAskMessageBox(string.Format("【{0}不能为空！】",kc_工程项目.f_工程项目名称)); e.Cancel = true;
            }
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            gridViewOperation.SqlMap = Client.ClientHelper.TransportSqlMap;
            InitColumns();//初始列
            InitData();//初始数据
        }
        private IViewOperation<kc_工程计划明细表> childView;
        /// <summary>
        /// 获取和设置子表的数据操作接口
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IViewOperation<Model.kc_工程计划明细表> ChildView {
            get { return childView; }
            set {
                childView = value;
                if (value != null) {
                    bar3.Visible = false;
                    hideColumn(kc_工程项目.f_工程类别, kc_工程项目.f_开工日期, kc_工程项目.f_完成日期, kc_工程项目.f_预算费用);
                }
            }
        }
        private void hideColumn(string col, params string[] cols) {
            try { gridView1.Columns[col].Visible = false; } catch { }
            foreach (var item in cols) {
                try { gridView1.Columns[item].Visible = false; } catch { }
            }
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as Model.kc_工程项目);
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            if (this.Site!=null &&this.Site.DesignMode) return;//必要的，否则设计时可能会报错
            //需要初始化数据时在这写代码
            RefreshData("");
        }
        /// <summary>
        /// 初始化列,
        /// </summary>
        public void InitColumns() {

            //需要隐藏列时在这写代码

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
        public GridViewOperation<Model.kc_工程项目> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(Model.kc_工程项目 newobj) {
            newobj.工程项目名称 = "工程项目";
            newobj.开工日期 = DateTime.Now;
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        public string ParentID {
            get { return parentID; }
            set {
                parentID = value;
            }
        }
    }
}
