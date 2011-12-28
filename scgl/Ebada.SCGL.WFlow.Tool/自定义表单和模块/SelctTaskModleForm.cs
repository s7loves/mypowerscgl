using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Client.Platform;
using Ebada.Core;
using System.Collections;
using Ebada.Scgl.Model;
using System.Reflection;
using System.Globalization;
using Ebada.UI.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;

namespace Ebada.SCGL.WFlow.Tool
{
    public partial class SelctTaskModleForm : FormBase
    {
        public SelctTaskModleForm()
        {
            InitializeComponent();
        }
        DataTable mdt = new DataTable();
        DataTable bdt = null;//功能列表
        DataTable udt = null;//已选功能列表
        private string worktaskId = "";
        private string workflowId = "";
        private string strmodleid = "";
        private string strmodlename = "";
        public string StrModleId
        {
            get { return strmodleid; }

            set { strmodleid = value; }

        }
        public string StrModleName
        {
            get { return strmodlename; }

            set { strmodlename = value; }

        }
        public string Taskid
        {
            get { return worktaskId; }

            set { worktaskId = value; }

        }
        public string Workflowid
        {
            get { return workflowId; }

            set { workflowId = value; }

        }
        private void SelctModleForm_Load(object sender, EventArgs e)
        {

            treeList1.BeginInit();
            treeList1.Nodes.Clear();
            treeList1.DataSource = null;
            string sqlwhere = " where 1=0";

            sqlwhere = "where ModuTypes != 'hide' order by ModuName";
            IList mlist = MainHelper.PlatformSqlMap.GetList("SelectmModuleList", sqlwhere);
            if (mlist.Count == 0)
            {
                mdt = new DataTable();
            }
            else
            {
                mdt = ConvertHelper.ToDataTable(mlist);
            }
            treeList1.DataSource = mdt;
            treeList1.EndInit();
            treeList1.CollapseAll();
            if (strmodleid != "")
            {
                mModule obj = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(strmodleid);
                if (obj != null)
                {
                    if (treeList1.FindNodeByKeyID(strmodleid) != null)
                    {
                        
                        treeList1.SetFocusedNode(treeList1.FindNodeByKeyID(strmodleid));
                    }
                }
            }
            else
            {
                mModule obj = MainHelper.PlatformSqlMap.GetOne<mModule>(" where ModuName='流程调用' ");
                if (obj != null)
                {
                    if (treeList1.FindNodeByKeyID(obj.Modu_ID) != null)
                    {
                        treeList1.FindNodeByKeyID(obj.Modu_ID).Expanded = true;
                        treeList1.SetFocusedNode(treeList1.FindNodeByKeyID(obj.Modu_ID));
                    }
                }
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            int i=0;
            mModule obj = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(treeList1.FocusedNode["Modu_ID"]);

          
            string sqlwhere = "where Modu_ID = '"+obj.Modu_ID+"'";
            IList mlist = MainHelper.PlatformSqlMap.GetList("SelectmModulFunList", sqlwhere);
            treeList2.ClearNodes();
            if(mlist.Count>0)
            {
               
                bdt= ConvertHelper.ToDataTable(mlist);
            }
            else if (bdt == null)
            {
                bdt = new DataTable();
                foreach (TreeListColumn tc in treeList2.Columns)
                {
                    bdt.Columns.Add(tc.FieldName, tc.ColumnType);
                }
            }
            treeList2.DataSource = bdt;
            sqlwhere = "where Modu_ID ='" + obj.Modu_ID + "' and WorktaskId='" + worktaskId + "' and WorkflowId='" + workflowId + "'";
            mlist = MainHelper.PlatformSqlMap.GetList("SelectWF_ModleUsedFuncList", sqlwhere);
            treeList3.ClearNodes();
            if (mlist.Count > 0)
            {
               
                udt = ConvertHelper.ToDataTable(mlist);
                
            }
            else if (udt == null)
            {
                udt = new DataTable();
                foreach (TreeListColumn tc in treeList3.Columns)
                {
                    udt.Columns.Add(tc.FieldName, tc.ColumnType);
                }
            }
            treeList3.DataSource = udt;
            for ( i = 0; i < udt.Rows.Count; i++)
            {

                TreeListNode td = treeList2.FindNodeByKeyID(udt.Rows[i]["FunID"]);
                treeList2.Nodes.Remove(td);
            }
            //if (obj.AssemblyFileName == "") return;
            //Assembly assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory+obj.AssemblyFileName);
            //Type tp = assembly.GetType(obj.ModuTypes);
            //object fromCtrl;
            //if (obj.MethodName == "")////窗体的构造函数不需要参数
            //    fromCtrl = Activator.CreateInstance(tp);
            //else//窗体的构造函数需要参数
            //    fromCtrl = Activator.CreateInstance(tp, obj.MethodName);
            //if (fromCtrl is UserControl)
            //{
            //    UserControl fromCtrl2 = fromCtrl as UserControl;
            //    foreach (Control c in fromCtrl2.Controls)
            //        {
            //            switch(c.GetType().FullName)
            //            {
            //                case "DevExpress.XtraEditors.SplitContainerControl":
            //                    DevExpress.XtraEditors.SplitContainerControl sc = c as DevExpress.XtraEditors.SplitContainerControl;
            //                    //sc.Visible = false;
            //                    sc.Name = sc.Name;
            //                    break;
            //            }

            //        }
            //    fromCtrl2.Visible = true;
            //    FormBase dlg = new FormBase();
            //    dlg.Text = obj.ModuName;
            //    dlg.MdiParent = MainHelper.MainForm;
            //    dlg.Controls.Add(fromCtrl2);
            //    fromCtrl2.Dock = DockStyle.Fill;
            //    dlg.Show();
            //    }
             
        }

        private void treeList2_DoubleClick(object sender, EventArgs e)
        {
            AddMoudle_Click(sender, e);
        }

        private void treeList3_DoubleClick(object sender, EventArgs e)
        {
            RemoveMoudle_Click(sender, e);
        }

        private void AddMoudle_Click(object sender, EventArgs e)
        {
            if (treeList2.FocusedNode == null)
                return;
             //TreeListHitInfo hit = treeList1.CalcHitInfo(treeList1.PointToClient(Control.MousePosition));
             //if (hit.Node != null && hit.Column != null)
            try
             {
                 mModulFun obj = MainHelper.PlatformSqlMap.GetOneByKey<mModulFun>(treeList2.FocusedNode["FunID"]);
                if (obj==null)
                {
                    return;
                }
                 WF_ModleUsedFunc um = new WF_ModleUsedFunc();
                 um.FunID = obj.FunID;
                 um.FunName = obj.FunName;
                 um.Modu_ID = obj.Modu_ID;
                 um.FunCode = obj.FunCode;
                 um.WorkflowId = workflowId;
                 um.WorktaskId = worktaskId;

                 DataRow dr = udt.NewRow();
                 dr["ID"] = um.ID;
                 dr["FunID"] = obj.FunID;
                 dr["FunName"] = obj.FunName;
                 dr["Modu_ID"] = obj.Modu_ID;
                 dr["FunCode"] = obj.FunCode;

                 udt.Rows.Add(dr);
                 treeList2.Nodes.Remove(treeList2.FocusedNode);
                 treeList3.Refresh();
                 //treeList1.FocusedNode = treeList1.FocusedNode.NextVisibleNode;
                 MainHelper.PlatformSqlMap.Create<WF_ModleUsedFunc>(um);
             }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void RemoveMoudle_Click(object sender, EventArgs e)
        {
            if (treeList3.FocusedNode == null)
                return;
            try
            {
                WF_ModleUsedFunc obj = MainHelper.PlatformSqlMap.GetOneByKey<WF_ModleUsedFunc>(treeList3.FocusedNode["ID"]);
                if (obj == null)
                {
                    return;
                }
                
                DataRow dr = bdt.NewRow();
                dr["FunID"] = obj.FunID;
                dr["FunName"] = obj.FunName;
                dr["Modu_ID"] = obj.Modu_ID;
                dr["FunCode"] = obj.FunCode;
                bdt.Rows.Add(dr);

                MainHelper.PlatformSqlMap.DeleteByKey<WF_ModleUsedFunc>(obj);
                treeList3.Nodes.Remove(treeList3.FocusedNode);
               
                treeList3.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode == null)
                return;
            mModule obj = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(treeList1.FocusedNode["Modu_ID"]);
                strmodleid = obj.Modu_ID;


                strmodlename = obj.ModuName;
        }
    
 

 

    }
}
