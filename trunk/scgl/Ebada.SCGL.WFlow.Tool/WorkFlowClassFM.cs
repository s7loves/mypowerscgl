using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ebada.SCGL.WFlow.Tool
{
    public partial class fmWorkFlowClass :BaseForm_Single
    {
        private string formState;//����״̬�����޸Ļ����½�
        private string InfoId; //��������
        private BaseTreeNode nowTreeNode;//��ǰ�ڵ�
        public string UserId = "";
        public string UserName = "";
        public fmWorkFlowClass()
        {
            InitializeComponent();
        }
        public fmWorkFlowClass(string userId, string userName, string state, string infoId, BaseTreeNode node)
        {
            InitializeComponent();
            formState = state;
            UserId = userId;
            InfoId = infoId;
            UserName = userName;
            nowTreeNode = node;
            
            if (formState == WorkConst.STATE_ADD)
            {
                this.Text = "�½�";
                if (nowTreeNode.NodeType == WorkConst.WORKFLOW_CLASS)//�϶�����Ƿ���ڵ�
                {
                    this.tbxFatherClassCaption.Text = nowTreeNode.Text;
                    this.tbxCllevel.Text = Convert.ToString(nowTreeNode.Level + 1);
                    
                }   

            }
            else //�϶���������̽ڵ�
            {
                this.Text = "�޸�";

                getInfoById();
            }
        }
        private void getInfoById()
        {
            this.tbxClassCaption.Text = nowTreeNode.Text;
            if (nowTreeNode.Parent != null)
                this.tbxPath.Text = nowTreeNode.MgrUrl;
            this.tbxFatherClassCaption.Text = nowTreeNode.Parent.Text;
            this.tbxDescription.Text = (nowTreeNode as WorkFlowClassTreeNode).Description;
            this.tbxCllevel.Text = nowTreeNode.Level.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (formState == WorkConst.STATE_ADD)
            {
                WorkFlowClassTreeNode tmpNodeInfo = new WorkFlowClassTreeNode();
                tmpNodeInfo.WorkflowFatherClassId = InfoId;
                tmpNodeInfo.NodeId = Guid.NewGuid().ToString();
                tmpNodeInfo.NodeType = WorkConst.WORKFLOW_CLASS;
                tmpNodeInfo.Text = tbxClassCaption.Text;
                tmpNodeInfo.Description = tbxDescription.Text;
                tmpNodeInfo.clLevel =Convert.ToInt16( tbxCllevel.Text);
                tmpNodeInfo.InsertWorkflowClassNode();
                tmpNodeInfo.MgrUrl = tbxPath.Text;
                if (nowTreeNode.NodeType == WorkConst.WORKFLOW_CLASS)//������Ƿ���ڵ�
                {
                    nowTreeNode.Nodes.Add(tmpNodeInfo);
                }

            }
            else ////�϶���������̽ڵ�
            {

                nowTreeNode.Text = tbxClassCaption.Text;
                nowTreeNode.NodeType = WorkConst.WORKFLOW_CLASS;
                nowTreeNode.MgrUrl = tbxPath.Text;
                (nowTreeNode as WorkFlowClassTreeNode).Description = tbxDescription.Text;
                (nowTreeNode as WorkFlowClassTreeNode).clLevel =Convert.ToInt16( tbxCllevel.Text);
                (nowTreeNode as WorkFlowClassTreeNode).UpdateWorkflowClassNode();


            }
            this.Close();
        }

        private void btnBussWebPage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdb = new OpenFileDialog();

            fdb.Filter = "aspxҳ��|*.aspx|htmlҳ��|*.html|�����ļ�|*.*";
            fdb.FilterIndex = 1;
            fdb.RestoreDirectory = false;
            fdb.Multiselect = false;
            string fileName = "";
            string userControlPath = System.Configuration.ConfigurationSettings.AppSettings["ModulesPath"];//�û��ؼ�·��

            if (DialogResult.OK == fdb.ShowDialog())
            {
                fileName = fdb.FileName;
                int index = fileName.ToUpper().IndexOf(userControlPath.ToUpper());

                tbxPath.Text = fileName.Substring(index, fileName.Length - index);
            }
        }
    }
}

