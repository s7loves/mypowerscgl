﻿/**********************************************
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
using System.Collections;
using Ebada.Core;

namespace Ebada.Scgl.Xtgl {
    /// <summary>
    /// 组织机构
    /// </summary>
    [ToolboxItem(false)]
    public partial class UCrRoleOrgTree : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<mOrg> treeViewOperator;
        string m_RoleID;
        [Browsable(false)]
        public TreeViewOperation<mOrg> TreeViewOperator {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }

        private DataTable gridtable = null;
        public event SendDataEventHandler<mOrg> FocusedNodeChanged;
        public event SendDataEventHandler<mOrg> AfterAdd;
        public event SendDataEventHandler<mOrg> AfterEdit;
        public event SendDataEventHandler<mOrg> AfterDelete;
        public UCrRoleOrgTree() {
            InitializeComponent();
            treeViewOperator = new TreeViewOperation<mOrg>(treeList1, barManager1);
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
            treeViewOperator.AfterEdit += treeViewOperator_AfterEdit;
            treeViewOperator.AfterDelete += treeViewOperator_AfterDelete;
            //treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;

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
                FocusedNodeChanged(treeList1, treeList1.GetDataRecordByNode(e.Node) as mOrg);
        }

        void treeViewOperator_CreatingObject(mOrg newobj) {
            
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e); Init();
        }

        public void Init() {
            this.treeList1.KeyFieldName = "OrgID";
            this.treeList1.ParentFieldName = "ParentID";

        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            //treeViewOperator.RefreshData("order by parentid,sequence");
            RefreshData("  order by OrgCode");

        }
        
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string sqlwhere) {
            treeViewOperator.RefreshData(sqlwhere);
           
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RoleID {
            get {
                return this.m_RoleID;
            }
            set {
                this.m_RoleID = value;
                this.InitData();
                this.InitChecked();
                treeList1.ExpandAll();
            }
        }

        public bool Save() {
            bool flag = true;
            List<string> list = new List<string>();
            List<rRoleOrg> list2 = new List<rRoleOrg>();
            this.getCheckList(this.treeList1.Nodes, list);
            foreach (string str in list) {
                rRoleOrg function = new rRoleOrg();
                function.RoleID = this.m_RoleID;
                function.OrgID = str;
                list2.Add(function);
            }



            SqlQueryObject item = new SqlQueryObject(SqlQueryType.Delete, "DeleterRoleOrgByWhere", "where RoleID='" + this.m_RoleID + "'");

            try {
                List<SqlQueryObject> list3 = new List<SqlQueryObject>();
                list3.Add(item);
                if (list2.Count > 0) {
                    SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Insert, list2.ToArray());
                    list3.Add(obj3);
                }

                MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
            } catch (Exception exception) {
                MainHelper.ShowWarningMessageBox(exception.Message);
                flag = false;
            }
            return flag;
        }



        private void SetChecked(TreeListNodes nodes, Dictionary<string, rRoleOrg> dic) {
            foreach (TreeListNode node in nodes) {
                if (dic.ContainsKey(node["OrgID"].ToString())) {
                    node.Checked = true;
                    if (node.ParentNode != null && !node.ParentNode.Checked)
                        node.ParentNode.Checked = true;
                }
                if (node.HasChildren) {
                    this.SetChecked(node.Nodes, dic);
                }
            }
        }

        private void SetCheckedChildNodes(TreeListNode node, CheckState check) {
            for (int i = 0; i < node.Nodes.Count; i++) {
                node.Nodes[i].CheckState = check;
                this.SetCheckedChildNodes(node.Nodes[i], check);
            }
        }
        private void getCheckList(TreeListNodes nodes, IList<string> list) {
            foreach (TreeListNode node in nodes) {
                if (node.Checked ) {

                    list.Add(node["OrgID"].ToString());
                }
                if (node.HasChildren) {
                    this.getCheckList(node.Nodes, list);
                }
            }
        }

        private void InitChecked() {
            IList<rRoleOrg> list = MainHelper.PlatformSqlMap.GetList<rRoleOrg>(string.Format(" WHERE RoleID = '{0}'", this.m_RoleID));
            Dictionary<string, rRoleOrg> dic = new Dictionary<string, rRoleOrg>();
            foreach (rRoleOrg function in list) {
                if (!dic.ContainsKey(function.OrgID)) {
                    dic.Add(function.OrgID, function);
                }
            }
            this.treeList1.BeginUpdate();
            this.SetChecked(this.treeList1.Nodes, dic);
            this.treeList1.EndUpdate();
        }
        private void treeList1_AfterCheckNode(object sender, NodeEventArgs e) {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        private void treeList1_BeforeCheckNode(object sender, CheckNodeEventArgs e) {
            //e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }
        private void SetCheckedParentNodes(TreeListNode node, CheckState check) {
            if (node.ParentNode != null) {
                bool b = false;
                CheckState state;

                for (int i = 0; i < node.ParentNode.Nodes.Count; i++) {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state)) {
                        b = !b;
                        break;
                    }
                }

                node.ParentNode.CheckState = b ? CheckState.Checked : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }
    }
}
