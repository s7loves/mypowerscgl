using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ebada.SCGL.WFlow.Tool
{
    public partial class fmSelectVar :BaseForm_Single
    {
        string WorkTaskId = "";
        string WorkflowId = "";
        public fmSelectVar(string workflowId,string taskId)
        {
            WorkTaskId = taskId;
            WorkflowId = workflowId;
            InitializeComponent();
        }
        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void InitializeUIData()
        {
            //列出所有用户
            lvVar.Columns.Add("变量名", 200, HorizontalAlignment.Left);
            lvVar.Columns.Add("变量类型", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("变量模式", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("数据库名", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("数据表名", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("字段名", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("初始值", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("访问类型", 100, HorizontalAlignment.Left);

            //加载流程变量
            DataTable dtSearch = TaskVar.GetWorkflowVar(WorkflowId);
            foreach (DataRow dr in dtSearch.Rows)
            {
                ListViewItem lvi1 = new ListViewItem(dr["VarName"].ToString(), 0);
                lvi1.SubItems.Add(dr["VarType"].ToString());
                lvi1.SubItems.Add(dr["VarModule"].ToString());
                lvi1.SubItems.Add(dr["DataBaseName"].ToString());
                lvi1.SubItems.Add(dr["TableName"].ToString());
                lvi1.SubItems.Add(dr["TableField"].ToString());
                lvi1.SubItems.Add(dr["InitValue"].ToString());
                lvi1.SubItems.Add(dr["AccessType"].ToString());
                lvVar.Items.Add(lvi1);
            }

            //加载任务变量
            dtSearch = TaskVar.GetTaskVar(WorkTaskId);
            foreach (DataRow dr in dtSearch.Rows)
            {
                ListViewItem lvi1 = new ListViewItem(dr["VarName"].ToString(), 0);
                lvi1.SubItems.Add(dr["VarType"].ToString());
                lvi1.SubItems.Add(dr["VarModule"].ToString());
                lvi1.SubItems.Add(dr["DataBaseName"].ToString());
                lvi1.SubItems.Add(dr["TableName"].ToString());
                lvi1.SubItems.Add(dr["TableField"].ToString());
                lvi1.SubItems.Add(dr["InitValue"].ToString());
                lvi1.SubItems.Add(dr["AccessType"].ToString());
                lvVar.Items.Add(lvi1);
            }

        }

        private void SelectVar_Load(object sender, EventArgs e)
        {
            InitializeUIData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            

        }
    }
}

