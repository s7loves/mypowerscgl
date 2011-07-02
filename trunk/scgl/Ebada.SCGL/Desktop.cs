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

namespace Ebada.SCGL
{
    public partial class Desktop : UserControl
    {
        public Desktop()
        {
            InitializeComponent();
              
        }
        DataTable dt = null;
        public frmMain2 PlatForm = null;
      
        public  void iniUsualCtrl()
        {
            UsuaslPanel.Controls.Clear();
            int xstart = 0, ystart = 0, ispan = 30,jspan=10;
            IList<mUserModule> mlist = MainHelper.PlatformSqlMap.GetList<mUserModule>("SelectmUserModuleList", "where UserID='" + MainHelper.User.UserID + "' order by SortID");
            foreach (mUserModule umodule in mlist)
            {
                Button bt = new Button();
                bt.Text = umodule.mMouleName;
                bt.AutoSize = true;
                bt.Tag = umodule;
                bt.Click += new EventHandler(runButtonEvent);
                if (xstart + bt.Width + ispan <= UsuaslPanel.Width)
                {
                    bt.Left = xstart + ispan;
                    bt.Top = ystart;
                    xstart = bt.Left + bt.Width;
                }
                else
                {
                    xstart = 0;
                    ystart = ystart + bt.Height + jspan;
                    bt.Left = xstart + ispan;
                    bt.Top = ystart;
                    xstart = bt.Left + bt.Width;
                }
                UsuaslPanel.Controls.Add(bt);
            }
           
        
        }
        private void runButtonEvent(object sender, EventArgs e)
        {
          
            mUserModule um = (mUserModule)(sender as Button).Tag;
            mModule md = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(um.mMouleID);
            if (md != null)
            {
                PlatForm.OpenModule(md);
            }
            
        }
        private void Desktop_Load(object sender, EventArgs e)
        {
            string userId = MainHelper.User.UserID;
            if (dt == null) dt = new DataTable();
            dt.Columns.Clear();
            dt.Rows.Clear();
            dt.Columns.Add("name", typeof(string));
            DataRow dr = dt.NewRow();
            dr["name"] = "未认领任务(" + WorkFlowInstance.GetClaimingTaskCount(userId) + ")";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["name"] = "已认领任务(" + WorkFlowInstance.GetClaimedTaskCount(userId) + ")";
            dt.Rows.Add(dr);
            //dr = dt.NewRow();
            //dr["name"] = "已完成任务(" + WorkFlowInstance.GetCompletedTaskCount(userId) + ")";
            //dt.Rows.Add(dr);
            //dr = dt.NewRow();
            //dr["name"] = "异常终止的任务(" + WorkFlowInstance.GetAbnormalTaskCount(userId) + ")";
            //dt.Rows.Add(dr);
            //dr = dt.NewRow();
            //dr["name"] = "我参与的任务(" + WorkFlowInstance.GetAllTaskCount(userId) + ")";
            //dt.Rows.Add(dr);
            gridControl1.DataSource = dt;
            iniUsualCtrl();
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

     
    }
}
