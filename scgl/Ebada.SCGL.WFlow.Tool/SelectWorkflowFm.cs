using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Client;

namespace Ebada.SCGL.WFlow.Tool
{
    public partial class fmSelectWorkflow : BaseForm_Single
    {
        public fmSelectWorkflow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void InitializeUIData()
        {

            //列出所有用户

            lvWorkflow.Columns.Add("流程名", 100, HorizontalAlignment.Left);
            lvWorkflow.Columns.Add("WorkflowId", 100, HorizontalAlignment.Left);
            lvWorkflow.Columns.Add("描述", 200, HorizontalAlignment.Left);

        }

        private void fmSelectWorkflow_Load(object sender, EventArgs e)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbxWorkflowCaption.Text.Length == 0)
            {
                MsgBox.ShowWarningMessageBox ("请输入流程名!");
                tbxWorkflowCaption.Focus();
                return;

            }
            lvWorkflow.Clear();
            InitializeUIData();
            DataTable dtSearch = null;
            dtSearch = WorkFlowTemplate.GetWorkflowsByCaption(tbxWorkflowCaption.Text);
            foreach (DataRow dr in dtSearch.Rows)
            {
                ListViewItem lvi1 = new ListViewItem(dr["FlowCaption"].ToString(), 0);
                lvi1.SubItems.Add(dr["WorkFlowId"].ToString());
                lvi1.SubItems.Add(dr["Description"].ToString());
                lvWorkflow.Items.Add(lvi1);

            }
        }
    }
}

