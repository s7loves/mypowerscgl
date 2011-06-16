using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
namespace Ebada.SCGL.WFlow.Tool
{
	/// <summary>
	/// Class1 的摘要说明。
	/// </summary>
    public class WorkFlowTreeNode : BaseTreeNode
	{

        //工作流模板的属性字段

        public string WorkFlowClassId = "";
        public string Description = "";
        public string Status = "";
        
    
        public WorkFlowTreeNode()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			


		}
        public static void DeleteSelectWorkflowNode(string NodeId)
        {
            WorkFlowTemplate.DeleteWorkFlow(NodeId);
        }
        
		/// <summary>
		/// 选中装载流程列表
		/// </summary>
		/// <param name="iSqlstr"></param>
		/// <param name="StartNotes"></param>
        public static void LoadWorkFlowSelectNode(string key, TreeNodeCollection startNodes)
		{
			if (startNodes==null)
                throw new Exception("LoadWorkFlowSelectNode的参数startNotes不能为空！");

            DataTable table = WorkFlowClass.GetWorkflowsByClassId(key);
			//startNodes.Clear();
            //deleteNode(startNodes);
			foreach(DataRow row in table.Rows)
			{

                WorkFlowTreeNode tmpNode = new WorkFlowTreeNode();
                tmpNode.NodeId = row["WorkFlowId"].ToString();
                tmpNode.WorkFlowClassId = row["WFClassId"].ToString();
				tmpNode.ImageIndex=2;
				tmpNode.SelectedImageIndex=2;
                tmpNode.ToolTipText = "流程";
                tmpNode.Status = row["Status"].ToString();
                tmpNode.Text = row["FlowCaption"].ToString();
                tmpNode.MgrUrl=row["mgrurl"].ToString();
                tmpNode.Description = row["Description"].ToString();
                tmpNode.NodeType = WorkConst.WORKFLOW_FLOW;
				startNodes.Add(tmpNode);

			}

		}
        public void InsertWorkflowNode()
        {
            try
            {
                WorkFlowTemplate workflowTemplate = new WorkFlowTemplate();
                workflowTemplate.WorkFlowId = NodeId;
                workflowTemplate.WorkFlowClassId = WorkFlowClassId;
                workflowTemplate.WorkFlowCaption = Text;
                workflowTemplate.Status = Status;
                workflowTemplate.MgrUrl = MgrUrl;
                workflowTemplate.Description = Description;
                workflowTemplate.InsertWorkFlow();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateWorkflowNode()
        {
            try
            {
                WorkFlowTemplate workflowTemplate = new WorkFlowTemplate();
                workflowTemplate.WorkFlowId = NodeId;
                workflowTemplate.WorkFlowClassId = WorkFlowClassId;
                workflowTemplate.WorkFlowCaption = Text;
                workflowTemplate.Status = Status;
                workflowTemplate.MgrUrl = MgrUrl;
                workflowTemplate.Description = Description;
                workflowTemplate.UpdateWorkFlow();
            }
            catch(Exception ex)
            
            {
                throw ex;
            }
 
        }
       
		
		
		
	}
}
