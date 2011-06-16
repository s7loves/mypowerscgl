using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
namespace Ebada.SCGL.WFlow.Tool
{
	/// <summary>
	/// Class1 ��ժҪ˵����
	/// </summary>
    public class WorkFlowTreeNode : BaseTreeNode
	{

        //������ģ��������ֶ�

        public string WorkFlowClassId = "";
        public string Description = "";
        public string Status = "";
        
    
        public WorkFlowTreeNode()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			


		}
        public static void DeleteSelectWorkflowNode(string NodeId)
        {
            WorkFlowTemplate.DeleteWorkFlow(NodeId);
        }
        
		/// <summary>
		/// ѡ��װ�������б�
		/// </summary>
		/// <param name="iSqlstr"></param>
		/// <param name="StartNotes"></param>
        public static void LoadWorkFlowSelectNode(string key, TreeNodeCollection startNodes)
		{
			if (startNodes==null)
                throw new Exception("LoadWorkFlowSelectNode�Ĳ���startNotes����Ϊ�գ�");

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
                tmpNode.ToolTipText = "����";
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
