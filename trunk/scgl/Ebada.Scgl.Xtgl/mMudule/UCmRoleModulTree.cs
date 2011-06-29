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
using System.Collections;
using Ebada.Core;

namespace Ebada.Scgl.Xtgl {
    /// <summary>
    /// 组织机构
    /// </summary>
    public partial class UCmRoleModulTree : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<mModule> treeViewOperator;
        string m_RoleID;
        [Browsable(false)]
        public TreeViewOperation<mModule> TreeViewOperator {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }

        private DataTable gridtable = null;
        public event SendDataEventHandler<mModule> FocusedNodeChanged;
        public event SendDataEventHandler<mModule> AfterAdd;
        public event SendDataEventHandler<mModule> AfterEdit;
        public event SendDataEventHandler<mModule> AfterDelete;
        public UCmRoleModulTree() {
            InitializeComponent();
            treeViewOperator = new TreeViewOperation<mModule>(treeList1, barManager1);
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
            treeViewOperator.AfterEdit += treeViewOperator_AfterEdit;
            treeViewOperator.AfterDelete += treeViewOperator_AfterDelete;
            //treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            
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
                FocusedNodeChanged(treeList1, treeList1.GetDataRecordByNode(e.Node) as mModule);
        }

        void treeViewOperator_CreatingObject(mModule newobj) {
            newobj.visiableFlag = true;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e); Init();
        }
        
        public void Init() {
            this.treeList1.KeyFieldName = "Modu_ID";
            this.treeList1.ParentFieldName = "ParentID";

        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            //treeViewOperator.RefreshData("order by parentid,sequence");
            RefreshData("order by parentid,sequence");

        }
        private void IniWFTData(string WFClassId)
        { 
                IList<WF_WorkFlow> wfli = MainHelper.PlatformSqlMap.GetList<WF_WorkFlow>("SelectWF_WorkFlowList", "where WFClassId='" + WFClassId+"'");
                foreach (WF_WorkFlow wf in wfli)
                {
                    DataRow dr = gridtable.NewRow();
                    dr["ParentID"] = WFClassId;
                    dr["ModuName"] = wf.FlowCaption ;
                    dr["Modu_ID"] = wf.WorkFlowId ;
                    gridtable.Rows.Add(dr);

                    IList<WF_WorkTask> wftli = MainHelper.PlatformSqlMap.GetList<WF_WorkTask>("SelectWF_WorkTaskList", "where WorkFlowId='" + wf.WorkFlowId + "'");
                    foreach (WF_WorkTask wft in wftli)
                    {
                        dr = gridtable.NewRow();
                        dr["ParentID"] = wf.WorkFlowId ;
                        dr["ModuName"] = wft.TaskCaption ;
                        dr["Modu_ID"] = wft.WorkTaskId ;
                        gridtable.Rows.Add(dr);
                    
                    }
                }
        }
        private void ReWFData(string WFClassId)
        {
            IList<WF_WorkFlowClass> wfcli = MainHelper.PlatformSqlMap.GetList<WF_WorkFlowClass>("SelectWF_WorkFlowClassList", "where FatherId='" + WFClassId +"'");
            foreach (WF_WorkFlowClass wfc in wfcli)
            {
                DataRow dr = gridtable.NewRow();
                dr["ParentID"] = WFClassId;
                dr["ModuName"] = wfc.Caption;
                dr["Modu_ID"] = wfc.WFClassId;
                gridtable.Rows.Add(dr);
                IniWFTData(wfc.WFClassId);
                ReWFData(wfc.WFClassId);
            
            }
        }
        private void IniWFData(string parentid)
        {
           
            IList<WF_WorkFlowClass> wfcli = MainHelper.PlatformSqlMap.GetList<WF_WorkFlowClass>("SelectWF_WorkFlowClassList", "where clLevel='0'");
            foreach (WF_WorkFlowClass wfc in wfcli)
            {
                DataRow dr = gridtable.NewRow();
                dr["ParentID"] = parentid;
                dr["ModuName"] = wfc.Caption;
                dr["Modu_ID"] = wfc.WFClassId;
                gridtable.Rows.Add(dr);
                IniWFTData(wfc.WFClassId);
                ReWFData(wfc.WFClassId);
               
                
                
            }

        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            if (gridtable != null) gridtable.Rows.Clear();
            IList<mModule> li = MainHelper.PlatformSqlMap.GetList<mModule>("SelectmModuleList", slqwhere);
            if (li.Count != 0)
            {
                gridtable = ConvertHelper.ToDataTable((IList)li);
                IniWFData( gridtable.Rows[0]["Modu_ID"].ToString());
                treeList1.DataSource = gridtable;
            }
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
            List<rRoleModul> list2 = new List<rRoleModul>();
            this.getCheckList(this.treeList1.Nodes, list);
            foreach (string str in list) {
                rRoleModul function = new rRoleModul();
                function.RoleID = this.m_RoleID;
                function.Modu_ID = str;
                list2.Add(function);
            }
           

            Console.WriteLine(list[8]); 
            SqlQueryObject item = new SqlQueryObject(SqlQueryType.Delete, "DeleterRoleModulByWhere", "where RoleID='" + this.m_RoleID + "'");
            SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Insert, list2.ToArray());
            try {
                List<SqlQueryObject> list3 = new List<SqlQueryObject>();
                list3.Add(item);
                list3.Add(obj3);
                MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
            } catch (Exception exception) {
                MainHelper.ShowWarningMessageBox(exception.Message);
                flag = false;
            }
            return flag;
        }

       

        private void SetChecked(TreeListNodes nodes, Dictionary<string, rRoleModul> dic) {
            foreach (TreeListNode node in nodes) {
                if (dic.ContainsKey(node["Modu_ID"].ToString())) {
                    node.Checked = true;
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
                if (node.Checked) {
                    list.Add(node["Modu_ID"].ToString());
                }
                if (node.HasChildren) {
                    this.getCheckList(node.Nodes, list);
                }
            }
        }

        private void InitChecked() {
            IList<rRoleModul> list = MainHelper.PlatformSqlMap.GetList<rRoleModul>(string.Format(" WHERE RoleID = '{0}'", this.m_RoleID));
            Dictionary<string, rRoleModul> dic = new Dictionary<string, rRoleModul>();
            foreach (rRoleModul function in list) {
                if (!dic.ContainsKey(function.Modu_ID)) {
                    dic.Add(function.Modu_ID, function);
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
