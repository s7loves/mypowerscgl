/**********************************************
系统:Ebada物流企业ERP
模块:示例
作者:Rabbit
创建时间:2011-2-28
最后一次修改:2011-3-1
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

    public partial class UCTop : DevExpress.XtraEditors.XtraUserControl {
        private GridViewOperation<mOrg> gridViewOperation;
        private IViewOperation<Empolyees> childView;
        /// <summary>
        /// 获取和设置子表的数据操作接口
        /// </summary>
        public IViewOperation<Empolyees> ChildView {
            get { return childView; }
            set { childView = value; }
        }
        public event SendDataEventHandler<mOrg> FocusedRowChanged;
        private string parentID;
        public UCTop() {
            InitializeComponent();
            initImageList();
            gridViewOperation = new GridViewOperation<mOrg>(gridControl1, gridView1, barManager1, new frmOrgEdit());
            gridViewOperation.CreatingObjectEvent +=gridViewOperation_CreatingObjectEvent;
            gridViewOperation.FocusedRowChanged +=gridViewOperation_FocusedRowChanged;
            gridViewOperation.BeforeDelete += gridViewOperation_BeforeDelete;
        }

        void gridViewOperation_BeforeDelete(object render, ObjectOperationEventArgs<mOrg> e) {
            if (ChildView != null && childView.BindingList.Count > 0) {
                e.Cancel = true;
                MainHelper.ShowWarningMessageBox("当前要删除的记录已被引用，不可删除！");
            }

        }

        void gridViewOperation_FocusedRowChanged(object sender, mOrg obj) {
            if (FocusedRowChanged != null)
                FocusedRowChanged(gridView1, obj);
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }
        /// <summary>
        /// 封装了数据操作的对象
        /// </summary>
        [Browsable(false)]
        public GridViewOperation<mOrg> GridViewOperation {
            get { return gridViewOperation; }
            set { gridViewOperation = value; }
        }
        /// <summary>
        /// 新建对象设置Key值
        /// </summary>
        /// <param name="newobj"></param>
        void gridViewOperation_CreatingObjectEvent(mOrg newobj) {
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
