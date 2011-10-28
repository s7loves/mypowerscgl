using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;
using Ebada.Core;
using System.Collections;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Ebada.Components;
using DevExpress.XtraGrid.Columns;
using Ebada.UI.Base;

namespace Ebada.SCGL.WFlow.Tool
{
    public partial class SelectTableFiledFm : FormBase
    {
        public SelectTableFiledFm()
        {
            InitializeComponent();
        }
        DataTable mdt = new DataTable();
        DataTable udt = new DataTable();
        private string tableid = "";
        private string worktaskId = "";
        private string workflowId = "";
        private string strfieldidlist = "";
        private string strfieldnamelist = "";
        public string StrFieldNameList
        {
            get { return strfieldnamelist; }

            set { strfieldnamelist = value; }

        }
        public string StrFieldidList
        {
            get { return strfieldidlist; }

            set { strfieldidlist = value; }

        }
        public string TableID
        {
            get { return tableid; }

            set { tableid = value; }

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
        private void SelectTableFiledFm_Load(object sender, EventArgs e)
        {
            treeList1.BeginInit();
            treeList1.Nodes.Clear();
            treeList1.DataSource = null;

            IList mlist = MainHelper.PlatformSqlMap.GetList("SelectLP_TempleList", "where ParentID ='" + tableid + "' order by Sortid, Status");
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
            IList ulist = MainHelper.PlatformSqlMap.GetList("SelectWF_TableUsedFieldList", "where UserControlId ='" + tableid + "' and WorktaskId='" + worktaskId + "' and WorkflowId='" + workflowId + "'");
            if (ulist.Count == 0)
            {
                udt = new DataTable ();
                foreach (GridColumn gc in gridView1.Columns)
                {
                    udt.Columns.Add(gc.FieldName, gc.ColumnType);
                }
            }
            else 
            {
                udt = ConvertHelper.ToDataTable(ulist);
                
            }
            gridControl1.DataSource = udt;
            for (int i = 0; i < udt.Rows.Count; i++)
            {

                TreeListNode td = treeList1.FindNodeByKeyID(udt.Rows[i]["FieldId"]);
                treeList1.Nodes.Remove(td);
            }
        }

        private void AddMoudle_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode == null)
                return;
             //TreeListHitInfo hit = treeList1.CalcHitInfo(treeList1.PointToClient(Control.MousePosition));
             //if (hit.Node != null && hit.Column != null)
            try
             {
                 LP_Temple obj = MainHelper.PlatformSqlMap.GetOneByKey<LP_Temple>(treeList1.FocusedNode["LPID"]);


                 WF_TableUsedField um = new WF_TableUsedField();
                 um.UserControlId = tableid;
                 um.FieldName =obj.CellName ;
                 um.FieldId =obj.LPID ;
                 um.WorkflowId= workflowId;  
                 um.WorktaskId=worktaskId;
                 DataRow dr = udt.NewRow();
                 dr["ID"] = um.ID;
                 dr["UserControlId"] = um.UserControlId;
                 dr["FieldName"] = um.FieldName;
                 dr["FieldId"] = um.FieldId;
                 dr["WorkflowId"] = um.WorkflowId;
                 dr["WorktaskId"] = um.WorktaskId;
                
                 udt.Rows.Add(dr);
                 treeList1.Nodes.Remove(treeList1.FocusedNode);
                 //treeList1.FocusedNode = treeList1.FocusedNode.NextVisibleNode;
                 MainHelper.PlatformSqlMap.Create<WF_TableUsedField>(um);

             }
            catch( Exception ex)
            {
                Console.WriteLine(ex.Message ); 
            }
        }

        private void RemoveMoudle_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle   <0)
                return;
            try
            {
                DataRow udr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                if (udr == null) return;
                string umid = udr["ID"].ToString();
                LP_Temple obj = MainHelper.PlatformSqlMap.GetOneByKey<LP_Temple>(udr["FieldId"]);
               
                DataRow dr = mdt.NewRow();
                dr["LPID"] = obj.LPID;
                dr["CellName"] = obj.CellName;
                dr["ParentID"] = obj.ParentID;
                mdt.Rows.Add(dr);
                udt.Rows.Remove(udr);
                MainHelper.PlatformSqlMap.DeleteByKey<WF_TableUsedField>(umid);
                //IList<WF_TableUsedField> il = MainHelper.PlatformSqlMap.GetList<WF_TableUsedField>("SelectWF_TableUsedFieldList", "where UserControlId ='" + tableid + "' and WorktaskId='" + taskid + "' and WorkflowId='" + Workflowid + "'");

                //SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Update, "UpdateWF_TableUsedField", il);
                //List<SqlQueryObject> list3 = new List<SqlQueryObject>();
                //list3.Add(obj3);
                //MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
                treeList1.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            AddMoudle_Click(sender, e);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            RemoveMoudle_Click(sender, e);
        }

        private void SelectTableFiledFm_FormClosed(object sender, FormClosedEventArgs e)
        {
            strfieldidlist = "";
            strfieldnamelist = "";
            for (int i = 0; i < udt.Rows.Count; i++)
            {
                if (strfieldidlist == "")
                    strfieldidlist += udt.Rows[i]["FieldId"];
                else
                    strfieldidlist += "," + udt.Rows[i]["FieldId"];

                if (strfieldnamelist == "")
                    strfieldnamelist += udt.Rows[i]["FieldName"];
                else
                    strfieldnamelist += "," + udt.Rows[i]["FieldName"];

            
            }
        }
    }
}
