using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ebada.SCGL.WFlow.Tool
{
    public partial class fmSelectTaskOperUser : BaseForm_Single
    {
        string Key = "";
        public fmSelectTaskOperUser(string iKey)
        {
            InitializeComponent();
            Key = iKey;
        }
        private void InitializeUIData()
        {
            lvTask.Columns.Add("»ŒŒÒ√˚≥∆", 100, HorizontalAlignment.Left);
            lvTask.Columns.Add("taskId", 0, HorizontalAlignment.Left);
            lvTask.Columns.Add("√Ë ˆ", 200, HorizontalAlignment.Left);
            DataTable dtSearch = WorkFlowTask.GetWorkTasks(Key);
            foreach (DataRow dr in dtSearch.Rows)
            {
                ListViewItem lvi1 = new ListViewItem(dr["taskCaption"].ToString(), 0);
                lvi1.SubItems.Add(dr["worktaskId"].ToString());
                lvi1.SubItems.Add(dr["description"].ToString());
                lvTask.Items.Add(lvi1);

            }

        }
        private void fmSelectTaskOperUser_Load(object sender, EventArgs e)
        {
            InitializeUIData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

