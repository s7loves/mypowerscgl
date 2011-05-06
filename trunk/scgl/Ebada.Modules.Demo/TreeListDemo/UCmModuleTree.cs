/**********************************************
系统:Ebada物流企业ERP
模块:示例
作者:Rabbit
创建时间:2011-2-22
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
    /// <summary>
    /// TreeList数据操作示例
    /// </summary>
    public partial class UCmModuleTree : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<mModule> treeViewOperator;

        public TreeViewOperation<mModule> TreeViewOperator {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }
        public event SendDataEventHandler<mModule> FocusedNodeChanged;
        public event SendDataEventHandler<mModule> AfterAdd;
        public event SendDataEventHandler<mModule> AfterEdit;
        public event SendDataEventHandler<mModule> AfterDelete;
        public UCmModuleTree() {
            InitializeComponent();
            treeViewOperator = new TreeViewOperation<mModule>(treeList1,barManager1);
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
            treeViewOperator.AfterEdit +=treeViewOperator_AfterEdit;
            treeViewOperator.AfterDelete +=treeViewOperator_AfterDelete;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
        }

        void treeViewOperator_AfterDelete(mModule newobj) {
            if (AfterDelete != null)
                AfterDelete(treeList1, newobj);
        }

        void treeViewOperator_AfterEdit(mModule newobj) {
            if (AfterAdd != null)
                AfterEdit(treeList1, newobj);
        }

        void treeViewOperator_AfterAdd(mModule newobj) {
            if (AfterAdd != null)
                AfterAdd(treeList1, newobj);
        }

        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (FocusedNodeChanged != null)
                FocusedNodeChanged(treeList1,treeList1.GetDataRecordByNode(e.Node) as mModule);
        }

        void treeViewOperator_CreatingObject(mModule newobj) {
            newobj.Modu_ID = newobj.CreateID();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e); 
                   
        }
       
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            treeViewOperator.RefreshData("order by parentid,Sequence");    
        }
    }
}
