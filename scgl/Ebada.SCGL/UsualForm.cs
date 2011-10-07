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

namespace Ebada.SCGL
{
    public partial class UsualForm : FormBase
    {
        public UsualForm()
        {
            InitializeComponent();
        }
        DataTable mdt = new DataTable();
        DataTable udt = new DataTable();
        public Desktop desk = null;
        private void UsualForm_Load(object sender, EventArgs e)
        {
            treeList1.BeginInit();
            treeList1.Nodes.Clear();
            treeList1.DataSource = null;
            string sqlwhere = " where 1=0";
            sqlwhere = "  a " +
               "where a.modu_id in (select b.modu_id from rRoleModul b " +
               "inner join rUserRole c on b.roleid=c.roleid " +
               "where a.visiableflag=1" + " and c.userid='" + MainHelper.User.UserID + "' and ModuTypes != 'hide')";
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
            IList ulist = MainHelper.PlatformSqlMap.GetList("SelectmUserModuleList", "where UserID='" + MainHelper.User.UserID + "' order by SortID");
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
            //for (int i = 0; i < udt.Rows.Count; i++)
            //{

            //    TreeListNode td = treeList1.FindNodeByKeyID(udt.Rows[i]["mMouleID"]);
            //    treeList1.Nodes.Remove(td);  
            //}
        }

        private void AddMoudle_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode == null)
                return;
             //TreeListHitInfo hit = treeList1.CalcHitInfo(treeList1.PointToClient(Control.MousePosition));
             //if (hit.Node != null && hit.Column != null)
            try
             {
                 mModule obj = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(treeList1.FocusedNode["Modu_ID"]);
                
                 if ((mUserModule)MainHelper.PlatformSqlMap.GetObject("SelectmUserModuleList", "where UserID='" + MainHelper.User.UserID + "' and mMouleID='" + obj.Modu_ID + "'") != null)
                 {
                     return;
                 }
                 mUserModule um=new mUserModule ();
                 um.mMouleID =obj.Modu_ID ;
                 um.mMouleName =obj .ModuName ;
                 um .mMouleParentID =obj.ParentID ;
                 um.UserID = MainHelper.User.UserID;  
                 um.SortID=Convert.ToInt32 (  MainHelper.PlatformSqlMap.GetObject("GetmUserModuleMaxSortID", "where 1=1"))+1;
                 DataRow dr = udt.NewRow();
                 dr["ID"] = um.ID;
                 dr["mMouleID"] = um.mMouleID;
                 dr["mMouleName"] = um.mMouleName;
                 dr["mMouleParentID"] = um.mMouleParentID;
                 dr["SortID"] = um.SortID;
                 udt.Rows.Add(dr);
                 treeList1.FocusedNode = treeList1.FocusedNode.NextVisibleNode;
                 //treeList1.Nodes.Remove(treeList1.FocusedNode);
                 MainHelper.PlatformSqlMap.Create<mUserModule>(um);
                 desk.iniUsualCtrl();

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
                //mModule obj = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(udr["mMouleID"]);
                //mUserModule um = new mUserModule();
                //um.mMouleID = obj.Modu_ID;
                //DataRow dr = mdt.NewRow();
                //dr["Modu_ID"] = obj.Modu_ID ;
                //dr["ModuName"] = obj.ModuName;
                //dr["ParentID"] = obj.ParentID;
                //mdt.Rows.Add(dr);
                udt.Rows.Remove(udr);
                MainHelper.PlatformSqlMap.DeleteByKey<mUserModule>(umid);
                IList<mUserModule> il = MainHelper.PlatformSqlMap.GetList<mUserModule>("SelectmUserModuleList", "where UserID='" + MainHelper.User.UserID + "' order by SortID");
                for (int i = 0; i < il.Count; i++)
                {
                    il[i].SortID = i + 1;
                    
                
                }
                SqlQueryObject obj3 = new SqlQueryObject(SqlQueryType.Update,"UpdatemUserModule", il);
                List<SqlQueryObject> list3 = new List<SqlQueryObject>();
                list3.Add(obj3);
                MainHelper.PlatformSqlMap.ExecuteTransationUpdate(list3);
                desk.iniUsualCtrl();
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
    }
}
