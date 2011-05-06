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
using Ebada.Components;
using Ebada.Client;
using Ebada.Platform.Model;
using DevExpress.XtraTreeList.Nodes;
using Ebada.Client.Platform;
using DevExpress.XtraTreeList;

namespace Ebada.Modules.Demo {
    public partial class UCLeft : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<VOrgLevel> treeViewOperator;
        private IViewOperation<Empolyees> childView;
        /// <summary>
        /// 获取和设置子表的数据操作接口
        /// </summary>
        [Browsable(false)]
        public IViewOperation<Empolyees> ChildView {
            get { return childView; }
            set { childView = value; }
        }
        public event SendDataEventHandler<VOrgLevel> FocusedNodeChanged;
        public UCLeft() {
            InitializeComponent();
            initImageList();
            treeViewOperator = new TreeViewOperation<VOrgLevel>(treeList1,barManager1,new frmOrg2Edit());
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            treeViewOperator.BeforeDelete += treeViewOperator_BeforeDelete;
        }

        void treeViewOperator_BeforeDelete(object render, ObjectOperationEventArgs<VOrgLevel> e) {
            //检查子表是否有相关联数据
            if (ChildView != null && childView.BindingList.Count > 0) {
                e.Cancel = true;
                MainHelper.ShowWarningMessageBox("当前要删除的记录已被引用，不可删除！");
            }
        }
        private void initImageList() {
            ImageList imagelist = new ImageList();
            imagelist.ImageStream = (Ebada.Client.Resource.UCGridToolbar.UCGridToolbarImageList);
            barManager1.Images = imagelist;
        }

        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (FocusedNodeChanged != null)
                FocusedNodeChanged(treeList1,treeList1.GetDataRecordByNode(e.Node) as VOrgLevel);
        }

        void treeViewOperator_CreatingObject(VOrgLevel newobj) {
            newobj.Org_ID = mOrg.Newid();
            newobj.OrgL_ID = new mOrgLevel().CreateID();
            
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            treeList1.KeyFieldName = "OrgL_ID";
            treeList1.ParentFieldName = "ParentID";
        }
       
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            treeViewOperator.RefreshData("order by parentid,Sequence");
            treeList1.ExpandAll();
        }
    }
}
