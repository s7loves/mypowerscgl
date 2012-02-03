using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;
using System.Threading;
using Ebada.Client;



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
            //*********控制权限
            DataTable powerTable = WorkFlowTask.GetTaskPower((nowTreeNode as WorkFlowTreeNode).NodeId, (nowTreeNode as WorkFlowTreeNode).NodeId);
            string powerStr = "";
            foreach (DataRow dr in powerTable.Rows)
            {
                powerStr = powerStr + dr["PowerName"].ToString() + ",";
            }
            cbxFuJian.Checked = powerStr.IndexOf(WorkConst.WorkTask_FuJian) > -1;//附件
            checkHuiQianYiJian.Checked = powerStr.IndexOf(WorkConst.WorkTask_SPYJ) > -1;//审批意见
            cbxExplore.Checked = powerStr.IndexOf(WorkConst.WorkTask_FlowEndExplore) > -1;//流程结束后允许导出
            checkFollow.Checked = powerStr.IndexOf(WorkConst.WorkTask_WorkFollow) > -1;//全程跟踪
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
                
                if (tmpNodeInfo.NodeType == WorkConst.WORKFLOW_CLASS)//点击的是分类节点
                {
                    tmpNodeInfo.InsertWorkflowNode();
                    nowTreeNode.Nodes.Add(tmpNodeInfo);
                }
                else
                    if (tmpNodeInfo.NodeType == WorkConst.WORKFLOW_FLOW)//点击的是流程节点
                    {
                        //nowTreeNode.Parent.Nodes.Add(tmpNodeInfo);
                        WF_WorkFlow wf = (WF_WorkFlow)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkFlowList", " where FlowCaption='" + tbxWorkflowCaption.Text + "'");
                        if(wf!=null)
                        {
                            MsgBox.ShowWarningMessageBox("流程名 " + tbxWorkflowCaption.Text + " 已经存在，不能重复");
                            return;
                        }
                        tmpNodeInfo.InsertWorkflowNode();
                        nowTreeNode.Nodes.Add(tmpNodeInfo);
                        //保存控制权限
                        WorkFlowTask.DeleteAllPower((tmpNodeInfo as WorkFlowTreeNode).NodeId, (tmpNodeInfo as WorkFlowTreeNode).NodeId);
                        if (cbxFuJian.Checked)
                        {
                            WorkFlowTask.SetTaskPower(WorkConst.WorkTask_FuJian, tmpNodeInfo.NodeId, tmpNodeInfo.NodeId);
                            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                        }
                        if (cbxFuJian.Checked)
                        {
                            WorkFlowTask.SetTaskPower(WorkConst.WorkTask_SPYJ, tmpNodeInfo.NodeId, tmpNodeInfo.NodeId);
                            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                        }

                        if (cbxExplore.Checked)
                        {
                            WorkFlowTask.SetTaskPower(WorkConst.WorkTask_FlowEndExplore, tmpNodeInfo.NodeId, tmpNodeInfo.NodeId);
                            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                        }
                        if (checkFollow.Checked)
                        {
                            WorkFlowTask.SetTaskPower(WorkConst.WorkTask_WorkFollow, tmpNodeInfo.NodeId, tmpNodeInfo.NodeId);
                            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                        }
                        
                    }
               
            }
            else ////肯定点的是流程节点
            {

                nowTreeNode.Text = tbxWorkflowCaption.Text;
                if (tbxPath.Tag!=null) (nowTreeNode as WorkFlowTreeNode).MgrUrl = tbxPath.Tag.ToString();
                nowTreeNode.NodeType = WorkConst.WORKFLOW_FLOW;
                (nowTreeNode as WorkFlowTreeNode).Description = tbxDescription.Text;
                if (cbxStatus.Checked) (nowTreeNode as WorkFlowTreeNode).Status = "1";
                else
                    (nowTreeNode as WorkFlowTreeNode).Status = "0";
                (nowTreeNode as WorkFlowTreeNode).UpdateWorkflowNode(); 
                //保存控制权限
                WorkFlowTask.DeleteAllPower((nowTreeNode as WorkFlowTreeNode).NodeId, (nowTreeNode as WorkFlowTreeNode).NodeId);
                if (cbxFuJian.Checked)
                {
                   WorkFlowTask.SetTaskPower(WorkConst.WorkTask_FuJian, (nowTreeNode as WorkFlowTreeNode).NodeId, (nowTreeNode as WorkFlowTreeNode).NodeId);
                   Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                }
                if (checkHuiQianYiJian.Checked)
                {
                    WorkFlowTask.SetTaskPower(WorkConst.WorkTask_SPYJ, (nowTreeNode as WorkFlowTreeNode).NodeId, (nowTreeNode as WorkFlowTreeNode).NodeId);
                    Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                }
                if (cbxExplore.Checked)
                {
                    WorkFlowTask.SetTaskPower(WorkConst.WorkTask_FlowEndExplore, (nowTreeNode as WorkFlowTreeNode).NodeId, (nowTreeNode as WorkFlowTreeNode).NodeId);
                    Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                }
                if (checkFollow.Checked)
                {
                    WorkFlowTask.SetTaskPower(WorkConst.WorkTask_WorkFollow, (nowTreeNode as WorkFlowTreeNode).NodeId, (nowTreeNode as WorkFlowTreeNode).NodeId);
                    Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                }
               
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

            //fdb.Filter = "aspx页面|*.aspx|html页面|*.html|所以文件|*.*";
            //fdb.FilterIndex = 1;
            //fdb.RestoreDirectory = false;
            //fdb.Multiselect = false;
            //string fileName = "";
            //string userControlPath = System.Configuration.ConfigurationSettings.AppSettings["ModulesPath"];//用户控件路径
            
            //if (DialogResult.OK == fdb.ShowDialog())
            //{
            //    fileName = fdb.FileName;
            //    int index = fileName.ToUpper().IndexOf(userControlPath.ToUpper());

            //    tbxPath.Text = fileName.Substring(index, fileName.Length - index);
            //}
        }

    }
}

