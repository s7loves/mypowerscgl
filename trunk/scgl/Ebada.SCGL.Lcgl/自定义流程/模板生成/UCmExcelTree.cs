/**********************************************
系统:企业ERP
模块:组织机构
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
using Ebada.Scgl.Core;
using DevExpress.XtraTreeList.Columns;

namespace Ebada.Scgl.Lcgl
{
    /// <summary>
    /// 组织机构
    /// </summary>
    public partial class UCmExcelTree : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<WF_WorkFlow> treeViewOperator;
        [Browsable(false)]
        public TreeViewOperation<WF_WorkFlow> TreeViewOperator {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }
        private IViewOperation<WF_WorkFlow> childView;
        /// <summary>
        /// 获取和设置子表的数据操作接口
        /// </summary>
        [Browsable(false)]
        public IViewOperation<WF_WorkFlow> ChildView
        {
            get { return childView; }
            set {
                childView = value;
            }
        }
        public event SendDataEventHandler<WF_WorkFlow> FocusedNodeChanged;
        public event SendDataEventHandler<WF_WorkFlow> AfterAdd;
        public event SendDataEventHandler<WF_WorkFlow> AfterEdit;
        public event SendDataEventHandler<WF_WorkFlow> AfterDelete;
        private DataTable dt = null;
        public UCmExcelTree() {
            InitializeComponent();           
            treeViewOperator = new TreeViewOperation<WF_WorkFlow>(treeList1, barManager1,new frmExcelEdit());
            
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
            treeViewOperator.AfterEdit += treeViewOperator_AfterEdit;
            treeViewOperator.AfterDelete += treeViewOperator_AfterDelete;
            treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            
        }

        void treeViewOperator_AfterDelete(WF_WorkFlow newobj) {
            if (AfterDelete != null)
                AfterDelete(treeList1, newobj);                
        }

        void treeViewOperator_AfterEdit(WF_WorkFlow newobj) {
            if (AfterAdd != null)
                AfterEdit(treeList1, newobj);
        }

        void treeViewOperator_AfterAdd(WF_WorkFlow newobj) {
            if (AfterAdd != null)
                AfterAdd(treeList1, newobj);
        }
        
        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (FocusedNodeChanged != null)
                FocusedNodeChanged(treeList1, treeList1.GetDataRecordByNode(e.Node) as WF_WorkFlow);
        }

        void treeViewOperator_CreatingObject(WF_WorkFlow newobj) {
            //newobj.OrgType = "0";
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            Init();
        }
        public void Init() {

            foreach (TreeListColumn tc in treeList1.Columns)
            {
                tc.Visible = false;
            }
            //treeList1.Columns["CellName"].Visible = true;
            //treeList1.Columns["OrgType"].ColumnEdit = DicTypeHelper.OrgTypeDic;
            if (this.Site == null)
                InitData();

        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            //treeViewOperator.RefreshData("where 1=1");
            
        }
        public bool BarManagerVisible
        {            
            get { return bar1.Visible; }
            set { bar1.Visible = value; }
        }
    }
}
