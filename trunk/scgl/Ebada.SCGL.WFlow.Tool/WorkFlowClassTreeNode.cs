using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace Ebada.SCGL.WFlow.Tool
{
    public class WorkFlowClassTreeNode : BaseTreeNode
    {

        /// <summary>
        /// 流程父分类Id
        /// </summary>
        public string WorkflowFatherClassId;
        /// <summary>
        /// 流程分类的描述
        /// </summary>
        public string Description;
        /// <summary>
        /// 分类等级
        /// </summary>
        public int clLevel;

        /// <summary>
        /// 递归装载全部流程类型
        /// </summary>
        /// <param name="key"></param>
        /// <param name="startNodes"></param>
        public static void LoadWorkFlowClass(string key, TreeNodeCollection startNodes)
        {
            try
            {
                DataTable table = WorkFlowClass.GetChildWorkflowClass(key);

                startNodes.Clear();
                foreach (DataRow row in table.Rows)
                {
                    WorkFlowClassTreeNode tmpNode = new WorkFlowClassTreeNode();
                    tmpNode.NodeId = row["WFClassId"].ToString();
                    tmpNode.ImageIndex = 0;
                    tmpNode.ToolTipText = "分类";
                    tmpNode.clLevel = Convert.ToInt16(row["clLevel"]);
                    tmpNode.SelectedImageIndex = 0;
                    tmpNode.Text = row["Caption"].ToString();
                    tmpNode.WorkflowFatherClassId = row["FatherId"].ToString();
                    tmpNode.Description = row["Description"].ToString();
                    tmpNode.MgrUrl = row["clmgrurl"].ToString();
                    tmpNode.NodeType = WorkConst.WORKFLOW_CLASS;
                    startNodes.Add(tmpNode);

                    LoadWorkFlowClass(tmpNode.NodeId, tmpNode.Nodes);

                }
                WorkFlowTreeNode.LoadWorkFlowSelectNode(key, startNodes);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 选中装载流程类型
        /// </summary>
        /// <param name="key"></param>
        /// <param name="startNodes"></param>
        public static void LoadWorkFlowClassSelectNode(string key, TreeNodeCollection startNodes)
        {
            try
            {
                DataTable table = WorkFlowClass.GetChildWorkflowClass(key);

                
                foreach (DataRow row in table.Rows)
                {
                    WorkFlowClassTreeNode tmpNode = new WorkFlowClassTreeNode();
                    tmpNode.NodeId = row["WFClassId"].ToString();
                    tmpNode.ImageIndex = 0;
                    tmpNode.ToolTipText = "分类";
                    tmpNode.SelectedImageIndex = 0;
                    tmpNode.clLevel = Convert.ToInt16(row["clLevel"]);
                    tmpNode.Text = row["Caption"].ToString();
                    tmpNode.WorkflowFatherClassId = row["FatherId"].ToString();
                    tmpNode.Description = row["Description"].ToString();
                    tmpNode.MgrUrl = row["clmgrurl"].ToString();
                    tmpNode.NodeType = WorkConst.WORKFLOW_CLASS;
                    startNodes.Add(tmpNode);

                    

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void InsertWorkflowClassNode()
        {
            try
            {
                WorkFlowClass workflowClass = new WorkFlowClass();
                workflowClass.WorkflowClassId = NodeId;
                workflowClass.WorkflowFatherClassId = WorkflowFatherClassId;
                workflowClass.WorkflowClassCaption = Text;
                workflowClass.Description = Description;
                workflowClass.clLevel = clLevel;
                workflowClass.MgrUrl = MgrUrl;
                workflowClass.InsertWorkflowClass();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateWorkflowClassNode()
        {
            try
            {
                WorkFlowClass workflowClass = new WorkFlowClass();
                workflowClass.WorkflowClassId = NodeId;
                workflowClass.WorkflowFatherClassId = WorkflowFatherClassId;
                workflowClass.WorkflowClassCaption = Text;
                workflowClass.Description = Description;
                workflowClass.clLevel = clLevel;
                workflowClass.MgrUrl = MgrUrl;
                workflowClass.UpdateWorkflowClass();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static void DeleteSelectClassNode(string NodeId)
        {
            WorkFlowClass.DeleteWorkflowClass(NodeId);
        }
    }
}
