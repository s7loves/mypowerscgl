﻿/**********************************************
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
using Ebada.Platform.Model;
using DevExpress.XtraGrid.Columns;
using System.Reflection;
using Ebada.Client;
using DevExpress.XtraGrid.Views.Base;

namespace Ebada.Modules.Demo {

    public partial class UCRight : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<Empolyees> gridViewOperation;
        
        public event SendDataEventHandler<Empolyees> FocusedRowChanged;
        private string parentID;
        public UCRight() {
            InitializeComponent();
            initImageList();
            initColumns();
            gridViewOperation = new GridViewOperation<Empolyees>(gridControl1, gridView1, barManager1, new frmEmpolyeesEdit(),new UCBottomFind());
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.BeforeAdd += new ObjectOperationEventHandler<Empolyees>(gridViewOperation_BeforeAdd);
            gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
        }
        /// <summary>
        /// 设置隐藏列
        /// </summary>
        void initColumns() {
            
        }
        void gridViewOperation_BeforeAdd(object render, ObjectOperationEventArgs<Empolyees> e) {
            if (string.IsNullOrEmpty(parentID)) {
                e.Cancel = true;
                MainHelper.ShowWarningMessageBox("请先选择单位后增加职员！");
            }
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, gridView1.GetFocusedRow() as Empolyees);
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<Empolyees> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(Empolyees newobj) {
            newobj.Org_ID = parentID;
        }
        /// <summary>
        /// 父表ID
        /// </summary>
        [Browsable(false)]
        public string ParentID {
            get { return parentID; }
            set {
                parentID = value;
                string str=" where 1>1";
                if(!string.IsNullOrEmpty(value)){
                    str = string.Format("where Org_ID='{0}'", value);
                }
                gridViewOperation.RefreshData(str);
            }
        }
    }
}
