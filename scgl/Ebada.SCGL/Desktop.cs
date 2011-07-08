using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Client.Platform;
using Ebada.Scgl.Model;
using Ebada.SCGL.WFlow.Engine;
using System.Collections;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using Ebada.Scgl.WFlow;

namespace Ebada.SCGL
{
    public partial class Desktop : UserControl
    {
        public Desktop()
        {
            InitializeComponent();
              
        }
        DataTable dt = null;
        DataTable taskdt = null;
        public frmMain2 PlatForm = null;
      
        public  void iniUsualCtrl()
        {
            UsuaslPanel.Controls.Clear();
            int xstart = 0, ystart = 10, ispan = 30,jspan=10,firstlincount=0;
            Hashtable hs = new Hashtable();
            IList<mUserModule> mlist = MainHelper.PlatformSqlMap.GetList<mUserModule>("SelectmUserModuleList", "where UserID='" + MainHelper.User.UserID + "' order by SortID");
            labelWid.Visible = true;
            foreach (mUserModule umodule in mlist)
            {
                SimpleButton bt = new SimpleButton();
                bt.Text = umodule.mMouleName;
                
                labelWid.Text = bt.Text;
                bt.Width = labelWid.Width + 20;
                if (bt.Width < 100) bt.Width = 100;
               
                bt.Tag = umodule;
                bt.Click += new EventHandler(runButtonEvent);
                if (xstart + bt.Width + ispan <= UsuaslPanel.Width)
                {
                    bt.Left = xstart + ispan;
                    bt.Top = ystart;
                    xstart = bt.Left + bt.Width;
                     firstlincount++;
                   
                }
                else
                {
                    xstart = 0;
                    firstlincount=1;
                    ystart = ystart + bt.Height + jspan;
                    bt.Left = xstart + ispan;
                    bt.Top = ystart;
                    xstart = bt.Left + bt.Width;
                }
                 if (ystart == 10)
                    {
                       
                        hs.Add(firstlincount, bt.Width);
                    }
                    else if (ystart > 10)
                    {
                        if (Convert.ToInt32(hs[firstlincount]) > bt.Width)
                        {
                            bt.Width = Convert.ToInt32(hs[firstlincount]);
                            xstart = bt.Left + bt.Width;
                        }
                    }
                UsuaslPanel.Controls.Add(bt);
            }
            labelWid.Visible = false;
        
        }
        private void runButtonEvent(object sender, EventArgs e)
        {

            mUserModule um = (mUserModule)(sender as SimpleButton).Tag;
            mModule md = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(um.mMouleID);
            if (md != null)
            {
                PlatForm.OpenModule(md);
            }
            
        }
        private void IniWorkFlowData(DataTable claimdt, int parentid)
        {
            Hashtable ht = new Hashtable();
            Hashtable ht2 = new Hashtable();
            DataRow dr=null;
            foreach (DataRow tdr in claimdt.Rows)
            {
                if (ht.Contains(tdr["FlowCaption"]))
                {
                    ht[tdr["FlowCaption"]] = Convert.ToInt32(ht[tdr["FlowCaption"]]) + 1;
                }
                else
                {
                    ht.Add(tdr["FlowCaption"], 1);
                    ht2.Add(tdr["FlowCaption"], tdr["WorkFlowId"]);
                }
            }
            foreach (DictionaryEntry de in ht)
            {
                dr = dt.NewRow();
                dr["name"] = de.Key.ToString() + "(" + de.Value.ToString() + ")";
                dr["id"] = Guid.NewGuid().ToString();
                dr["parentid"] = parentid;
                WF_WorkFlow wf = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkFlow>(ht2[de.Key].ToString());
                if (wf != null)
                    dr["Modu_ID"] = wf.MgrUrl;
                dt.Rows.Add(dr);

            }

        }
        public void refreshTreeData()
        {
            DataTable workTaskdt = WorkFlowInstance.WorkflowToDoWorkTasks(MainHelper.User.UserID, 999);
            
            treeList1.Nodes.Clear(); 
            DataRow dr = dt.NewRow();
            dr["name"] = "我的任务(" + workTaskdt.Rows.Count + ")";
            dr["id"] = 0;
            dt.Rows.Add(dr);
            taskdt.Rows.Clear();
            foreach (DataRow tdr in workTaskdt.Rows)
            {

                DataRow taskdr = taskdt.NewRow();
                foreach (DataColumn gc in taskdt.Columns)
                {
                    if (gc.ColumnName == "Modu_ID" || gc.ColumnName == "butt") continue;
                    taskdr[gc.ColumnName] = tdr[gc.ColumnName];
                }
                WF_WorkFlow wf = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkFlow>(tdr["WorkFlowId"]);
                taskdr["Modu_ID"] = wf.MgrUrl;
                taskdr["butt"] = "进入";
                taskdr["Image"] = WorkFlowInstance.WorkFlowBitmap(tdr["WorkFlowId"].ToString(), tdr["WorkFlowInsId"].ToString(), imageEdit1.PopupFormSize);
                taskdt.Rows.Add(taskdr);

                
              
            }
            IniWorkFlowData(workTaskdt, 0);
            treeList1.DataSource = dt;
            treeList1.ExpandAll();
            gridTalskCon.DataSource = taskdt;
        }
        private void Desktop_Load(object sender, EventArgs e)
        {
            
            
            if (dt == null) dt = new DataTable();
            dt.Columns.Clear();
            dt.Rows.Clear();
            dt.Columns.Clear();
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("parentid", typeof(string));
            dt.Columns.Add("Modu_ID", typeof(string));
            dt.Columns.Add("WorkFlowId", typeof(string));
            if (taskdt == null) taskdt = new DataTable();
            taskdt.Columns.Clear();
            taskdt.Columns.Add("FlowCaption", typeof(string));
            taskdt.Columns.Add("TaskCaption", typeof(string));
            taskdt.Columns.Add("taskStartTime", typeof(string));
            taskdt.Columns.Add("WorkFlowId", typeof(string));
            taskdt.Columns.Add("WorkTaskInsId", typeof(string));
            taskdt.Columns.Add("WorkTaskId", typeof(string));
            taskdt.Columns.Add("Modu_ID", typeof(string));
            taskdt.Columns.Add("butt", typeof(string));
            taskdt.Columns.Add("Image", typeof(Bitmap));
            refreshTreeData();
            //iniUsualCtrl();
        }

     

       

        private void UsualCtrl_SizeChanged(object sender, EventArgs e)
        {
            iniUsualCtrl();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            UsualForm uf = new UsualForm();
            uf.desk = this; 
            uf.Show ();
            //iniUsualCtrl();
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            int ihand = gridTalskView.FocusedRowHandle;
            if (ihand < 0)
                return;
            DataRow dr = gridTalskView.GetDataRow(ihand);
            mModule md = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(dr["Modu_ID"]);
            if (md != null)
            {
                PlatForm.OpenModule(md);
            }
        }

        private void gridTalskView_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridTalskView.FocusedColumn.FieldName != "butt" && gridTalskView.FocusedColumn.FieldName != "Image")
                e.Cancel = true;
        }

        private void picFresh_Click(object sender, EventArgs e)
        {
            refreshTreeData();

        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            xtraTabControl2.SelectedTabPage =taskTabPage ;
        }

     

     
    }
}
