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
        /// ��ʼ����������
        /// </summary>
        private void InitializeUIData()
        {
            //�г������û�
            lvVar.Columns.Add("������", 200, HorizontalAlignment.Left);
            lvVar.Columns.Add("��������", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("����ģʽ", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("���ݿ���", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("���ݱ���", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("�ֶ���", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("��ʼֵ", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("��������", 100, HorizontalAlignment.Left);

            //�������̱���
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

            //�����������
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

