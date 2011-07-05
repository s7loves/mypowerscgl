using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;



namespace Ebada.SCGL.WFlow.Tool
{
    public partial class fmAddWorkFlow : BaseForm_Single
    {
        private string formState;//����״̬�����޸Ļ����½�
        private string InfoId; //��������
        private BaseTreeNode nowTreeNode;//��ǰ�ڵ�
        public string UserId="";
        public string UserName="";

        public fmAddWorkFlow()
        {
            InitializeComponent();
        }


        public fmAddWorkFlow(string userId,string userName,string state,string infoId,BaseTreeNode node)
        {
            InitializeComponent();
            formState = state;
            
            UserId = userId;
            UserName = userName;
          
            nowTreeNode = node;
            
            if (formState == WorkConst.STATE_ADD)
            {
                this.Text = "�½�";
                if (nowTreeNode.NodeType == WorkConst.WORKFLOW_CLASS)//������Ƿ���ڵ�
                {
                    this.tbxClassCaption.Text = nowTreeNode.Text;
                    InfoId = infoId;
                    
                }
                else
                    if (nowTreeNode.NodeType == WorkConst.WORKFLOW_FLOW)//����������̽ڵ�
                    {
                        this.tbxClassCaption.Text = nowTreeNode.Parent.Text;
                        InfoId = (nowTreeNode.Parent as BaseTreeNode).NodeId;
                        
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
            this.tbxWorkflowCaption.Text = nowTreeNode.Text;
            this.tbxClassCaption.Text = nowTreeNode.Parent.Text;
            if (nowTreeNode.Parent != null)
            {
                mModule md = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(nowTreeNode.MgrUrl);
                if (md != null)
                {
                    this.tbxPath.Text = md.ModuName;
                    this.tbxPath.Tag = md.Modu_ID;
                }
            }
            //tbxPath.Text = (nowTreeNode as WorkFlowTreeNode).MgrUrl;
            cbxStatus.Checked = (nowTreeNode as WorkFlowTreeNode).Status == "1"; 
            this.tbxDescription.Text = (nowTreeNode as WorkFlowTreeNode).Description;
        }
    

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            
            if (formState == WorkConst.STATE_ADD)
            {
                WorkFlowTreeNode tmpNodeInfo = new WorkFlowTreeNode();
                tmpNodeInfo.WorkFlowClassId = InfoId;
                tmpNodeInfo.NodeId = Guid.NewGuid().ToString();
                tmpNodeInfo.NodeType = WorkConst.WORKFLOW_FLOW;
                tmpNodeInfo.Text = tbxWorkflowCaption.Text;
                if (tbxPath.Tag!=null)
                tmpNodeInfo.MgrUrl = tbxPath.Tag.ToString();
                if (cbxStatus.Checked) tmpNodeInfo.Status = "1";
                else
                    tmpNodeInfo.Status = "0";
                tmpNodeInfo.Description = tbxDescription.Text;
                tmpNodeInfo.InsertWorkflowNode();
                if (nowTreeNode.NodeType == WorkConst.WORKFLOW_CLASS)//������Ƿ���ڵ�
                {
                    nowTreeNode.Nodes.Add(tmpNodeInfo);
                }
                else
                    if (nowTreeNode.NodeType == WorkConst.WORKFLOW_FLOW)//����������̽ڵ�
                    {
                        nowTreeNode.Parent.Nodes.Add(tmpNodeInfo);
                    }
               
            }
            else ////�϶���������̽ڵ�
            {

                nowTreeNode.Text = tbxWorkflowCaption.Text;
                (nowTreeNode as WorkFlowTreeNode).MgrUrl = tbxPath.Tag.ToString();
                nowTreeNode.NodeType = WorkConst.WORKFLOW_FLOW;
                (nowTreeNode as WorkFlowTreeNode).Description = tbxDescription.Text;
                if (cbxStatus.Checked) (nowTreeNode as WorkFlowTreeNode).Status = "1";
                else
                    (nowTreeNode as WorkFlowTreeNode).Status = "0";
                (nowTreeNode as WorkFlowTreeNode).UpdateWorkflowNode();
               
               
            }
            this.Close();
            

        }

        private void cmbxNodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void btnBussWebPage_Click(object sender, EventArgs e)
        {
            SelectModuleFm smf = new SelectModuleFm();
            smf.strmoduleid = "";
            smf.strmodulename = "";

            smf.ShowDialog();
            if (smf.strmoduleid != "")
            {
                tbxPath.Tag = smf.strmoduleid;
                tbxPath.Text = smf.strmodulename;
            }
            //OpenFileDialog fdb = new OpenFileDialog();

            //fdb.Filter = "aspxҳ��|*.aspx|htmlҳ��|*.html|�����ļ�|*.*";
            //fdb.FilterIndex = 1;
            //fdb.RestoreDirectory = false;
            //fdb.Multiselect = false;
            //string fileName = "";
            //string userControlPath = System.Configuration.ConfigurationSettings.AppSettings["ModulesPath"];//�û��ؼ�·��
            
            //if (DialogResult.OK == fdb.ShowDialog())
            //{
            //    fileName = fdb.FileName;
            //    int index = fileName.ToUpper().IndexOf(userControlPath.ToUpper());

            //    tbxPath.Text = fileName.Substring(index, fileName.Length - index);
            //}
        }

    }
}

