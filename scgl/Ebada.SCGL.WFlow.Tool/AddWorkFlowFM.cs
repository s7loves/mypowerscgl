using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace Ebada.SCGL.WFlow.Tool
{
    public partial class fmAddWorkFlow : BaseForm_Single
    {
        private string formState;//窗体状态，是修改还是新建
        private string InfoId; //操做主键
        private BaseTreeNode nowTreeNode;//当前节点
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
                this.Text = "新建";
                if (nowTreeNode.NodeType == WorkConst.WORKFLOW_CLASS)//点击的是分类节点
                {
                    this.tbxClassCaption.Text = nowTreeNode.Text;
                    InfoId = infoId;
                    
                }
                else
                    if (nowTreeNode.NodeType == WorkConst.WORKFLOW_FLOW)//点击的是流程节点
                    {
                        this.tbxClassCaption.Text = nowTreeNode.Parent.Text;
                        InfoId = (nowTreeNode.Parent as BaseTreeNode).NodeId;
                        
                    }
                
            }
            else //肯定点的是流程节点
            {
                this.Text = "修改";
                getInfoById();
            }
            
        }
        private void getInfoById()
        {          
            this.tbxWorkflowCaption.Text = nowTreeNode.Text;
            this.tbxClassCaption.Text = nowTreeNode.Parent.Text;
            tbxPath.Text = (nowTreeNode as WorkFlowTreeNode).MgrUrl;
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
                tmpNodeInfo.MgrUrl = tbxPath.Text;
                if (cbxStatus.Checked) tmpNodeInfo.Status = "1";
                else
                    tmpNodeInfo.Status = "0";
                tmpNodeInfo.Description = tbxDescription.Text;
                tmpNodeInfo.InsertWorkflowNode();
                if (nowTreeNode.NodeType == WorkConst.WORKFLOW_CLASS)//点击的是分类节点
                {
                    nowTreeNode.Nodes.Add(tmpNodeInfo);
                }
                else
                    if (nowTreeNode.NodeType == WorkConst.WORKFLOW_FLOW)//点击的是流程节点
                    {
                        nowTreeNode.Parent.Nodes.Add(tmpNodeInfo);
                    }
               
            }
            else ////肯定点的是流程节点
            {

                nowTreeNode.Text = tbxWorkflowCaption.Text;
                (nowTreeNode as WorkFlowTreeNode).MgrUrl = tbxPath.Text;
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
            OpenFileDialog fdb = new OpenFileDialog();

            fdb.Filter = "aspx页面|*.aspx|html页面|*.html|所以文件|*.*";
            fdb.FilterIndex = 1;
            fdb.RestoreDirectory = false;
            fdb.Multiselect = false;
            string fileName = "";
            string userControlPath = System.Configuration.ConfigurationSettings.AppSettings["ModulesPath"];//用户控件路径
            
            if (DialogResult.OK == fdb.ShowDialog())
            {
                fileName = fdb.FileName;
                int index = fileName.ToUpper().IndexOf(userControlPath.ToUpper());

                tbxPath.Text = fileName.Substring(index, fileName.Length - index);
            }
        }

    }
}

