/**********************************************
系统:企业ERP
模块:示例
作者:Rabbit
创建时间:2011-5-18
最后一次修改:2011-5-19
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
using DevExpress.XtraTreeList.Nodes;
using Ebada.Client.Platform;
using DevExpress.XtraTreeList;
using Ebada.Scgl.Model;
using DevExpress.XtraEditors.Controls;

namespace Ebada.Scgl.Xtgl
{
    /// <summary>
    /// TreeList数据操作示例
    /// </summary>
    public partial class UCmOrgTree : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<mOrg> treeViewOperator;

        public TreeViewOperation<mOrg> TreeViewOperator {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }
        public event SendDataEventHandler<mOrg> FocusedNodeChanged;
        public event SendDataEventHandler<mOrg> AfterAdd;
        public event SendDataEventHandler<mOrg> AfterEdit;
        public event SendDataEventHandler<mOrg> AfterDelete;
        public UCmOrgTree() {
            InitializeComponent();
            treeViewOperator = new TreeViewOperation<mOrg>(treeList1,barManager1);
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
            treeViewOperator.AfterEdit +=treeViewOperator_AfterEdit;
            treeViewOperator.AfterDelete +=treeViewOperator_AfterDelete;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            Init();
        }

        void treeViewOperator_AfterDelete(mOrg newobj) {
            if (AfterDelete != null)
                AfterDelete(treeList1, newobj);
        }

        void treeViewOperator_AfterEdit(mOrg newobj) {
            if (AfterAdd != null)
                AfterEdit(treeList1, newobj);
        }

        void treeViewOperator_AfterAdd(mOrg newobj) {
            if (AfterAdd != null)
                AfterAdd(treeList1, newobj);
        }

        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (FocusedNodeChanged != null)
                FocusedNodeChanged(treeList1,treeList1.GetDataRecordByNode(e.Node) as mOrg);
        }

        void treeViewOperator_CreatingObject(mOrg newobj) {
            newobj.OrgType = "0";
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            
        }
        public void Init() {


            treeList1.Columns["OrgType"].ColumnEdit = DicTypeHelper.OrgTypeDic;
            if (this.Site == null)
                InitData();
            
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            treeViewOperator.RefreshData("order by parentid,orgcode");    
        }
        
    }
}
