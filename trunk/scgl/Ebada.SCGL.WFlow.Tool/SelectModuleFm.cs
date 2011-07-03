using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Client;
using System.Collections;
using Ebada.Client.Platform;
using Ebada.Core;


namespace Ebada.SCGL.WFlow.Tool
{
    public partial class SelectModuleFm : Form 
    {
        DataTable mdt = new DataTable();
        public string strmoduleid = "";
        public string strmodulename = "";
        public SelectModuleFm()
        {
            InitializeComponent();
        }
        private void SelectModuleFm_Load(object sender, EventArgs e)
        {

            IList mlist = MainHelper.PlatformSqlMap.GetList("SelectmModuleList", "where ModuTypes != 'hide'");
            if (mlist.Count == 0)
            {
                mdt = new DataTable();
            }
            else
            {
                mdt = ConvertHelper.ToDataTable(mlist);
            }
            treeList1.DataSource = mdt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode == null)
                return;
            strmoduleid = treeList1.FocusedNode["Modu_ID"].ToString();
            strmodulename = treeList1.FocusedNode["ModuName"].ToString();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

       
    }
}

