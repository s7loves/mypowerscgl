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
        private string formState;//窗体状态，是修改还是新建
        private string InfoId; //操做主键
        private BaseTreeNode nowTreeNode;//当前节点
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
                this.Text = "新建";
                if (nowTreeNode.NodeType == WorkConst.WORKFLOW_CLASS)//肯定点的是分类节点
                {
                    this.tbxFatherClassCaption.Text = nowTreeNode.Text;
                    this.tbxCllevel.Text = Convert.ToString(nowTreeNode.Level + 1);
                    
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
                if (nowTreeNode.NodeType == WorkConst.WORKFLOW_CLASS)//点击的是分类节点
                {
                    nowTreeNode.Nodes.Add(tmpNodeInfo);
                }

            }
            else ////肯定点的是流程节点
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

