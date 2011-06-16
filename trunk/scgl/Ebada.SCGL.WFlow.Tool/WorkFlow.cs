using System;
using System.Data;
using HF.Framework.DataContract;
using HF.Framework.DataClientDBAgent;
using System.Collections;
using HF.Framework;
namespace HF.WorkFlow.Template
{
	/// <summary>
	/// ������ģ����� ��ժҪ˵����
    /// ����������ģ������з�����
	/// </summary>
	public class WorkFlowTemplate
	{
        //������ģ��workflow��� ���ʲ���
        private SqlDataItem sqlDataItem = new SqlDataItem();
        private string[] fieldList ={ "WorkFlowId", "WFClassId", "FlowCaption", "Description", "Status","MgrUrl" };
		private string tableName="WorkFlow";
        private string keyField = "WorkFlowId";
		private string sqlString="";

        //������ģ��������ֶ�
		public string WorkFlowId="";
		public string WorkFlowCaption="";
		public string WorkFlowClassId="";
        public string Description = "";
        public string Status = "";
        public string MgrUrl = "";

		

		public WorkFlowTemplate()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ���ɹ�����ģ�����
		/// </summary>
		/// <param name="workflowId">������id</param>
		/// <param name="state">��д״̬���½�\�޸�\���</param>
		/// <param name="taskItems"></param>
		/// <param name="lineItems"></param>
        public WorkFlowTemplate(string workflowId, string state)
		{
			if (WorkFlowId.Trim().Length==0||WorkFlowId==null)
                throw new Exception("��ʼ��WorkFlow�����State ����Ϊ�գ�");
			
			WorkFlowId=workflowId;
			
		}
		private void setParameter()
		{
            sqlDataItem.ParameterList.Clear();
            sqlDataItem.AppendParameter("@WorkFlowId", WorkFlowId);
            sqlDataItem.AppendParameter("@WFClassId", WorkFlowClassId);
            sqlDataItem.AppendParameter("@FlowCaption", WorkFlowCaption);
            sqlDataItem.AppendParameter("@Description", Description);
            sqlDataItem.AppendParameter("@Status", Status);
            sqlDataItem.AppendParameter("@MgrUrl", MgrUrl);
			


		}
		private void setInsertSql()
		{
			string tmpValueList="";
			string tmpFieldName="";
			sqlString="insert into "+tableName+"(";
			int tmpInt=this.fieldList.Length;
			for(int i=0;i<tmpInt-1;i++)
			{
				tmpFieldName=fieldList[i].ToString();
				sqlString=sqlString+tmpFieldName+",";
				tmpValueList=tmpValueList+"@"+tmpFieldName+",";

			}
			tmpFieldName=this.fieldList[tmpInt-1].ToString();
			sqlString=sqlString+tmpFieldName;
			tmpValueList=tmpValueList+"@"+tmpFieldName;
			this.sqlString=sqlString+")values("+tmpValueList+")";
            sqlDataItem.CommandText = sqlString;
		}
		private void setUpdateSql()
		{
			string tmpFieldName="";
			int tmpInt=this.fieldList.Length;
			sqlString="update "+tableName+" set ";
			for(int i=0;i<tmpInt-1;i++)
			{
				tmpFieldName=this.fieldList[i].ToString();
				sqlString=sqlString+tmpFieldName+"=@"+tmpFieldName+",";
				
			}
			tmpFieldName=fieldList[tmpInt-1].ToString();
			sqlString=sqlString+tmpFieldName+"=@"+tmpFieldName;
			sqlString=sqlString+" where "+keyField+"=@"+keyField;
            sqlDataItem.CommandText = sqlString;
		}

		/// <summary>
		/// �½� һ������ģ��
		/// </summary>
        public void InsertWorkFlow()
		{
			if (WorkFlowId.Trim().Length==0||WorkFlowId==null)
                throw new Exception("InsertWorkFlow��������WorkFlowId ����Ϊ�գ�");
			
			try
			{
				setInsertSql();//�趨insert���
				setParameter();//�趨����
                ClientDBAgent agent = new ClientDBAgent();
                agent.ExecuteNonQuery(sqlDataItem);
			}
            catch (Exception ex)
            {
                throw ex;
            }
		}
		/// <summary>
		/// �޸�һ������ģ��
		/// </summary>
        public void UpdateWorkFlow()
		{
			if (WorkFlowId.Trim().Length==0||WorkFlowId==null)
                throw new Exception("UpdateWorkFlow��������WorkFlowId ����Ϊ�գ�");

			try
			{
				setUpdateSql();//�趨��Update���
				setParameter();//�趨����
                ClientDBAgent agent = new ClientDBAgent();
                agent.ExecuteNonQuery(sqlDataItem);
			}
			catch(Exception ex)
			{
				throw ex;
			}

		}
        public static int DeleteWorkFlow(string workflowId)
        {
            if (workflowId.Trim().Length == 0 || workflowId == null)
                throw new Exception("DeleteWorkFlow��������workflowId ����Ϊ�գ�");
            try
            {
                SqlDataItem sqlItem = new SqlDataItem();
                sqlItem.CommandText = "DeleteWorkflow";
                sqlItem.CommandType = CommandType.StoredProcedure;
                sqlItem.AppendParameter("@WorkflowId", workflowId);
                ClientDBAgent agent = new ClientDBAgent();
                return agent.ExecuteNonQuery(sqlItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       

        /// <summary>
        /// ��ù�����ģ����Ϣ
        /// </summary>
        /// <param name="workflowId">����ģ��Id</param>
        /// <returns></returns>
        public static DataTable GetWorkflowTable(string workflowId)
        {
            try
            {
                string tmpStr = "select * from workflow where WorkFlowId=@workflowId";
                SqlDataItem sqlItem = new SqlDataItem();
                sqlItem.CommandText = tmpStr;
                sqlItem.AppendParameter("@workflowId", workflowId);
                ClientDBAgent agent = new ClientDBAgent();
                return agent.ExecuteDataTable(sqlItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetWorkFlowAllControlsTable(string workflowId)
        {
            try
            {
                string tmpStr = "select  * from worktaskControls where WorkFlowId=@workflowId";
                SqlDataItem sqlItem = new SqlDataItem();
                sqlItem.CommandText = tmpStr;
                sqlItem.AppendParameter("@workflowId", workflowId);
                ClientDBAgent agent = new ClientDBAgent();
                return agent.ExecuteDataTable(sqlItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetWorkflowInfo(string workflowId)
        {
            DataTable dt = GetWorkflowTable(workflowId);
            if (dt != null && dt.Rows.Count > 0)
            {
                WorkFlowId = dt.Rows[0]["WorkFlowId"].ToString();
                WorkFlowCaption = dt.Rows[0]["FlowCaption"].ToString();
                WorkFlowClassId = dt.Rows[0]["WFClassId"].ToString();
                Description = dt.Rows[0]["Description"].ToString();
                Status = dt.Rows[0]["Status"].ToString();
                MgrUrl = dt.Rows[0]["MgrUrl"].ToString();
            }
        }
        /// <summary>
        /// ��ù�����ģ����Ϣ
        /// </summary>
        /// <param name="workflowId">����ģ������</param>
        /// <returns></returns>
        public static DataTable GetWorkflowsByCaption(string workflowCaption)
        {
           
            string tmpStr = "select * from workflow where FlowCaption like @workflowCaption";
            try
            {
                SqlDataItem sqlItem = new SqlDataItem();
                sqlItem.CommandText = tmpStr;
                sqlItem.AppendParameter("@workflowCaption", "%" + workflowCaption + "%");
                ClientDBAgent agent = new ClientDBAgent();
                return agent.ExecuteDataTable(sqlItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool Exists(string workFlowid)
        {
            string tmpSql = "select * from workflow where workflowId=@workFlowid";
            SqlDataItem sqlItem = new SqlDataItem();
            sqlItem.AppendParameter("@workFlowid", workFlowid);
            sqlItem.CommandText = tmpSql;
            ClientDBAgent agent = new ClientDBAgent();
            return agent.RecordExists(sqlItem);

        }
        /// <summary>
        /// ���ù�����ģ��״̬��status=1 ���ã�status=0 ����
        /// </summary>
        /// <param name="workflowId">����ģ��Id</param>
        /// <returns></returns>
        public static int SetWorkflowStatus(string workflowId,string status)
        {
            try
            {
                string tmpSql = "update workflow set status=@status where WorkFlowId=@workflowId";
                SqlDataItem sqlItem = new SqlDataItem();
                sqlItem.CommandText = tmpSql;
                sqlItem.AppendParameter("@workflowId", workflowId);
                sqlItem.AppendParameter("@status", status);
                ClientDBAgent agent = new ClientDBAgent();
                return agent.ExecuteNonQuery(sqlItem);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// �������̷���
        /// </summary>
        /// <param name="workflowId">����ģ��Id</param>
        /// <param name="wfclassid">���̷���Id</param>
        /// <returns></returns>
        public static int SetWorkflowClass(string workflowId,string wfclassid)
        {
            try
            {
                string tmpSql = "update workflow set wfclassId=@wfclassid where WorkFlowId=@workflowId";
                SqlDataItem sqlItem = new SqlDataItem();
                sqlItem.CommandText = tmpSql;
                sqlItem.AppendParameter("@workflowId", workflowId);
                sqlItem.AppendParameter("@wfclassid", wfclassid);
                ClientDBAgent agent = new ClientDBAgent();
                return agent.ExecuteNonQuery(sqlItem);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		
	}
}
