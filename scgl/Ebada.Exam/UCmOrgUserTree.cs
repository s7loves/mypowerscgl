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

namespace Ebada.Exam
{
    /// <summary>
    /// 组织机构
    /// </summary>
    //[ToolboxItem(false)]
    public partial class UCmOrgUserTree : DevExpress.XtraEditors.XtraUserControl {

        TreeViewOperation<mUser> treeViewOperator;
        //单位或者人员
        public string Type = "org";


        string orgidall;

        string orgids;
        string userids;

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
        public UCmOrgUserTree()
        {
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
           // RefreshData("  order by LoginID");
            RefreshData("  where OrgCode in (" +OrgIDAll + ") order by LoginID");

        }
     
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="slqwhere">sql where 子句 ，为空时查询全部数据</param>
        public void RefreshData(string slqwhere)
        {
            if (OrgIDAll==null||OrgIDAll==string.Empty)
            {
                return;
            }
            if (gridtable != null)gridtable.Rows.Clear();
            treeList1.Nodes.Clear();
            //mUser md = MainHelper.PlatformSqlMap.GetOne<mUser>(" where ModuName='工作流设置'");
            //if(md!=null)
            //    IniWFData(md.Modu_ID );
            //IList<mOrg> orgli = MainHelper.PlatformSqlMap.GetList<mOrg>("SelectmOrgList", "order by OrgType");
            //IList<mUser> li = MainHelper.PlatformSqlMap.GetList<mUser>("SelectmUserList", slqwhere);

            IList<mOrg> orgli = MainHelper.PlatformSqlMap.GetList<mOrg>("SelectmOrgList", "where OrgCode in (" + OrgIDAll + ")order by OrgType");
            if (Type=="user")
            {
                IList<mUser> li = MainHelper.PlatformSqlMap.GetList<mUser>("SelectmUserList", slqwhere);
                foreach (mOrg or in orgli)
                {
                    mUser user = new mUser();
                    user.UserID = or.OrgID;
                    user.UserName = or.OrgName;
                    user.OrgCode = or.ParentID;
                    user.Type = "orgtemp";
                    li.Add(user);
                }
                if (li.Count != 0)
                {
                    //gridtable = ConvertHelper.ToDataTable((IList)li);
                    this.treeList1.BeginUpdate();
                    treeList1.DataSource = li;
                    this.treeList1.EndUpdate();
                }

            }
            else
            {
                IList<mUser> li = new List<mUser>();
                foreach (mOrg or in orgli)
                {
                    mUser user = new mUser();
                    user.UserID = or.OrgID;
                    user.UserName = or.OrgName;
                    user.OrgCode = or.ParentID;
                    user.Type = "orgtemp";
                    li.Add(user);
                }
                if (li.Count != 0)
                {
                    //gridtable = ConvertHelper.ToDataTable((IList)li);
                    this.treeList1.BeginUpdate();
                    treeList1.DataSource = li;
                    this.treeList1.EndUpdate();
                }
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
        public string OrgIDAll
        {
            get
            {
                return this.orgidall;
            }
            set
            {
                this.orgidall = value;
                //this.InitData();
                //this.InitChecked();
                //treeList1.ExpandAll();
            }
        }

        public string OrgIDs
        {
            get
            {
                return this.orgids;
            }
            set
            {
                this.orgids = value;
                this.InitData();
                this.InitChecked();
                treeList1.ExpandAll();
            }
        }

        public string UserIDs
        {
            get
            {
                return this.userids;
            }
            set
            {
                this.userids = value;
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

        public  string GetUserIDS()
        {
            string strresult = string.Empty;

            if (Type=="user")
            {
                List<string> list = new List<string>();

                this.getCheckList(this.treeList1.Nodes, list);

                foreach (string str in list)
                {
                    strresult += str + spchar;
                }
                if (strresult.Length > 2)
                {
                    strresult = strresult.Substring(0, strresult.Length - 1);
                }
                
            }
            else
            {
                string sqlwhere = "  where OrgCode in (" + GetOrgIDS() + ") order by LoginID";
                    IList<mUser> li = MainHelper.PlatformSqlMap.GetList<mUser>("SelectmUserList", sqlwhere);
                    if (li.Count != 0)
                    {
                       foreach (mUser user in li)
                        {
                            strresult += user.UserID + spchar;
                        }
                    }
                
            }

            

            return strresult;
        }

        public string GetOrgIDS()
        {
            string strresult = string.Empty;
            List<string> list = new List<string>();

            this.getOrgCheckList(this.treeList1.Nodes, list);

            foreach (string str in list)
            {
                strresult += str + spchar;
            }
            if (strresult.Length > 2)
            {
                strresult = strresult.Substring(0, strresult.Length - 1);
            }

            return strresult;
        }

        //private void SetChecked(TreeListNodes nodes, Dictionary<string, rUserRole> dic) {
        //    foreach (TreeListNode node in nodes) {
        //        if (dic.ContainsKey(node["UserID"].ToString()))
        //        {
        //            node.Checked = true;
        //            if (node.ParentNode != null && !node.ParentNode.Checked)
        //                node.ParentNode.Checked = true;
        //        }
        //        if (node.HasChildren) {
        //            this.SetChecked(node.Nodes, dic);
        //        }
        //    }
        //}

        private void SetChecked(TreeListNodes nodes, Dictionary<string, string > dic)
        {
            foreach (TreeListNode node in nodes)
            {
                if (dic.ContainsKey(node["UserID"].ToString()))
                {
                    node.Checked = true;
                    if (node.ParentNode != null && !node.ParentNode.Checked)
                        node.ParentNode.Checked = true;
                }
                if (node.HasChildren)
                {
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
                if (node.Checked&&node["Type"].ToString ()!= "orgtemp") {
                    
                    list.Add(node["UserID"].ToString());
                }
                if (node.HasChildren) {
                    this.getCheckList(node.Nodes, list);
                }
            }
        }
        private void getOrgCheckList(TreeListNodes nodes, IList<string> list)
        {
            foreach (TreeListNode node in nodes)
            {
                if (node.Checked && node["Type"].ToString() == "orgtemp")
                {

                    list.Add(node["UserID"].ToString());
                }
                if (node.HasChildren)
                {
                    this.getOrgCheckList(node.Nodes, list);
                }
            }
        }
        char spchar = ',';
        private void InitChecked() {
            //IList<rUserRole> list = MainHelper.PlatformSqlMap.GetList<rUserRole>(string.Format(" WHERE RoleID = '{0}'", this.m_RoleID));
            //Dictionary<string, rUserRole> dic = new Dictionary<string, rUserRole>();
            //foreach (rUserRole function in list)
            //{
            //    if (!dic.ContainsKey(function.UserID)) {
            //        dic.Add(function.UserID, function);
            //    }
            //}
            //this.treeList1.BeginUpdate();
            //this.SetChecked(this.treeList1.Nodes, dic);
            //this.treeList1.EndUpdate();


            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (Type=="user")
            {
                if (UserIDs == null || UserIDs == string.Empty)
                {
                    return;
                }
                string[] strarry = UserIDs.Split(spchar);
                if (strarry.Length > 0)
                {
                    for (int i = 0; i < strarry.Length; i++)
                    {
                        dic.Add(strarry[i], strarry[i]);
                    }
                }

                this.treeList1.BeginUpdate();
                this.SetChecked(this.treeList1.Nodes, dic);
                this.treeList1.EndUpdate();
            }
            else
            {
                if (OrgIDs==null||OrgIDs==string.Empty)
                {
                    return;
                }
                string[] strarry = OrgIDs.Split(spchar);
                if (strarry.Length > 0)
                {
                    for (int i = 0; i < strarry.Length; i++)
                    {
                        dic.Add(strarry[i], strarry[i]);
                    }
                }

                this.treeList1.BeginUpdate();
                this.SetChecked(this.treeList1.Nodes, dic);
                this.treeList1.EndUpdate();
            }
            
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
