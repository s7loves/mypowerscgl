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
    public partial class UCmUserRoleTree : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<mUser> treeViewOperator;
        string m_RoleID;
        [Browsable(false)]
        public TreeViewOperation<mUser> TreeViewOperator {
            get { return treeViewOperator; }
            set { treeViewOperator = value; }
        }

        private DataTable gridtable = null;
        public event SendDataEventHandler<mUser> FocusedNodeChanged;
        public event SendDataEventHandler<mUser> AfterAdd;
        public event SendDataEventHandler<mUser> AfterEdit;
        public event SendDataEventHandler<mUser> AfterDelete;
        public UCmUserRoleTree() {
            InitializeComponent();
            treeViewOperator = new TreeViewOperation<mUser>(treeList1, barManager1);
            treeViewOperator.CreatingObjectEvent += treeViewOperator_CreatingObject;
            treeViewOperator.AfterAdd += treeViewOperator_AfterAdd;
            treeViewOperator.AfterEdit += treeViewOperator_AfterEdit;
            treeViewOperator.AfterDelete += treeViewOperator_AfterDelete;
            //treeList1.FocusedNodeChanged += treeList1_FocusedNodeChanged;
            
        }

        void treeViewOperator_AfterDelete(mUser newobj) {
            if (AfterDelete != null)
                AfterDelete(treeList1, newobj);
        }

        void treeViewOperator_AfterEdit(mUser newobj) {
            if (AfterAdd != null)
                AfterEdit(treeList1, newobj);
        }

        void treeViewOperator_AfterAdd(mUser newobj) {
            if (AfterAdd != null)
                AfterAdd(treeList1, newobj);
        }

        void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (FocusedNodeChanged != null)
                FocusedNodeChanged(treeList1, treeList1.GetDataRecordByNode(e.Node) as mUser);
        }

        void treeViewOperator_CreatingObject(mUser newobj) {
            newobj.Valid= true;
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e); Init();
        }
        
        public void Init() {
            this.treeList1.KeyFieldName = "UserID";
            //this.treeList1.ParentFieldName = "ParentID";

        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() {
            //treeViewOperator.RefreshData("order by parentid,sequence");
            RefreshData("  order by LoginID");

        }
        private void IniWFTData(string WFClassId,ref List<mModule> list2)
        { 
                IList<WF_WorkFlow> wfli = MainHelper.PlatformSqlMap.GetList<WF_WorkFlow>("SelectWF_WorkFlowList", "where WFClassId='" + WFClassId+"'");
                foreach (WF_WorkFlow wf in wfli)
                {
                   

                    mModule md = new mModule();
                    md.Modu_ID = wf.WorkFlowId;
                    md.ModuName = wf.FlowCaption;
                    md.ModuTypes = "hide";
                    md.ParentID = WFClassId;
                    md.Description = "工作流";
                    list2.Add(md); 
                    IList<WF_WorkTask> wftli = MainHelper.PlatformSqlMap.GetList<WF_WorkTask>("SelectWF_WorkTaskList", "where WorkFlowId='" + wf.WorkFlowId + "'");
                    foreach (WF_WorkTask wft in wftli)
                    {
                        
                         md = new mModule();
                         md.Modu_ID = wft.WorkTaskId;
                         md.ModuName = wft.TaskCaption;
                         md.ParentID = wf.WorkFlowId;
                         md.ModuTypes = "hide";
                        md.Description = "工作流";
                        list2.Add(md); 
                    
                    }
                }
        }
        //private void ReWFData(string WFClassId,ref List<mUser> list2)
        //{
        //    IList<WF_WorkFlowClass> wfcli = MainHelper.PlatformSqlMap.GetList<WF_WorkFlowClass>("SelectWF_WorkFlowClassList", "where FatherId='" + WFClassId +"'");
        //    foreach (WF_WorkFlowClass wfc in wfcli)
        //    {
                
        //        IniWFTData(wfc.WFClassId, ref list2);
        //        ReWFData(wfc.WFClassId, ref list2);

        //        mUser md = new mUser();
        //        md.Modu_ID = wfc.WFClassId;
        //        md.ModuName = wfc.Caption;
        //        md.ParentID = WFClassId;
        //        md.ModuTypes = "hide";
        //        md.Description = "工作流";
        //        list2.Add(md); 
        //    }
        //}
        //private void IniWFData(string parentid)
        //{
        //    List<mUser> list2 = new List<mUser>();
        //    IList<WF_WorkFlowClass> wfcli = MainHelper.PlatformSqlMap.GetList<WF_WorkFlowClass>("SelectWF_WorkFlowClassList", "where clLevel='0'");
        //    foreach (WF_WorkFlowClass wfc in wfcli)
        //    {

        //        mUser md = new mUser();
        //        md.Modu_ID = wfc.WFClassId;
        //        md.ModuName = wfc.Caption;
        //        md.ParentID = parentid;
        //        md.ModuTypes = "hide";
        //        md.Description = "工作流";
        //        list2.Add(md);
        //        IniWFTData(wfc.WFClassId, ref list2);
        //        ReWFData(wfc.WFClassId, ref list2);

        //    }
        //    SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Update, "InsertWFmUser", list2.ToArray());
        //    try
        //    {
        //        List<SqlQueryObject> list3 = new List<SqlQueryObject>();
        //        list3.Add(obj3);
        //        MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
        //    }
        //    catch (Exception exception)
        //    {
        //        MainHelper.ShowWarningMessageBox(exception.Message);
               
        //    }
          

        //}
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            if (gridtable != null)gridtable.Rows.Clear();
            treeList1.Nodes.Clear();
            //mUser md = MainHelper.PlatformSqlMap.GetOne<mUser>(" where ModuName='工作流设置'");
            //if(md!=null)
            //    IniWFData(md.Modu_ID );
            IList<mUser> li = MainHelper.PlatformSqlMap.GetList<mUser>("SelectmUserList", slqwhere);
            if (li.Count != 0)
            {
                //gridtable = ConvertHelper.ToDataTable((IList)li);
                this.treeList1.BeginUpdate();
                treeList1.DataSource = li;
                this.treeList1.EndUpdate();
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
            List<rUserRole> list2 = new List<rUserRole>();
            this.getCheckList(this.treeList1.Nodes, list);
            foreach (string str in list) {
                rUserRole function = new rUserRole();
                function.RoleID = this.m_RoleID;
                function.UserID = str;
                list2.Add(function);
            }



            SqlQueryObject item = new SqlQueryObject(SqlQueryType.Delete, "DeleterUserRoleByWhere", "where RoleID='" + this.m_RoleID + "'");
            
            try {
                List<SqlQueryObject> list3 = new List<SqlQueryObject>();
                list3.Add(item);
                if (list2.Count>0)
                {
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

       

        private void SetChecked(TreeListNodes nodes, Dictionary<string, rUserRole> dic) {
            foreach (TreeListNode node in nodes) {
                if (dic.ContainsKey(node["UserID"].ToString()))
                {
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
                    list.Add(node["UserID"].ToString());
                }
                if (node.HasChildren) {
                    this.getCheckList(node.Nodes, list);
                }
            }
        }

        private void InitChecked() {
            IList<rUserRole> list = MainHelper.PlatformSqlMap.GetList<rUserRole>(string.Format(" WHERE RoleID = '{0}'", this.m_RoleID));
            Dictionary<string, rUserRole> dic = new Dictionary<string, rUserRole>();
            foreach (rUserRole function in list)
            {
                if (!dic.ContainsKey(function.UserID)) {
                    dic.Add(function.UserID, function);
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
