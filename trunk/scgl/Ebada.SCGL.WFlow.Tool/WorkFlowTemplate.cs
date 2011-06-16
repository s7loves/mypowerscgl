using System;
using System.Data;
using System.Collections;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;
using Ebada.Core;
namespace Ebada.SCGL.WFlow.Tool
{
	/// <summary>
	/// ������ģ����� ��ժҪ˵����
    /// ����������ģ������з�����
	/// </summary>
	public class WorkFlowTemplate
	{
        //������ģ��workflow��� ���ʲ���
        //private SqlDataItem sqlDataItem = new SqlDataItem();
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
        //private void setParameter()
        //{
        //    sqlDataItem.ParameterList.Clear();
        //    sqlDataItem.AppendParameter("@WorkFlowId", WorkFlowId);
        //    sqlDataItem.AppendParameter("@WFClassId", WorkFlowClassId);
        //    sqlDataItem.AppendParameter("@FlowCaption", WorkFlowCaption);
        //    sqlDataItem.AppendParameter("@Description", Description);
        //    sqlDataItem.AppendParameter("@Status", Status);
        //    sqlDataItem.AppendParameter("@MgrUrl", MgrUrl);
			


        //}
        //private void setInsertSql()
        //{
        //    string tmpValueList="";
        //    string tmpFieldName="";
        //    sqlString="insert into "+tableName+"(";
        //    int tmpInt=this.fieldList.Length;
        //    for(int i=0;i<tmpInt-1;i++)
        //    {
        //        tmpFieldName=fieldList[i].ToString();
        //        sqlString=sqlString+tmpFieldName+",";
        //        tmpValueList=tmpValueList+"@"+tmpFieldName+",";

        //    }
        //    tmpFieldName=this.fieldList[tmpInt-1].ToString();
        //    sqlString=sqlString+tmpFieldName;
        //    tmpValueList=tmpValueList+"@"+tmpFieldName;
        //    this.sqlString=sqlString+")values("+tmpValueList+")";
        //    sqlDataItem.CommandText = sqlString;
        //}
        //private void setUpdateSql()
        //{
        //    string tmpFieldName="";
        //    int tmpInt=this.fieldList.Length;
        //    sqlString="update "+tableName+" set ";
        //    for(int i=0;i<tmpInt-1;i++)
        //    {
        //        tmpFieldName=this.fieldList[i].ToString();
        //        sqlString=sqlString+tmpFieldName+"=@"+tmpFieldName+",";
				
        //    }
        //    tmpFieldName=fieldList[tmpInt-1].ToString();
        //    sqlString=sqlString+tmpFieldName+"=@"+tmpFieldName;
        //    sqlString=sqlString+" where "+keyField+"=@"+keyField;
        //    sqlDataItem.CommandText = sqlString;
        //}

		/// <summary>
		/// �½� һ������ģ��
		/// </summary>
        public void InsertWorkFlow()
		{
			if (WorkFlowId.Trim().Length==0||WorkFlowId==null)
                throw new Exception("InsertWorkFlow��������WorkFlowId ����Ϊ�գ�");
			
			try
			{
                //setInsertSql();//�趨insert���
                //setParameter();//�趨����
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                PS_WorkFlow wf = new PS_WorkFlow();
                wf.WorkFlowId= WorkFlowId;
                wf.WFClassId= WorkFlowClassId;
                wf.FlowCaption= WorkFlowCaption;
                wf.Description= Description;
                wf.Status= Status;
                wf.MgrUrl= MgrUrl;
                MainHelper.PlatformSqlMap.Create<PS_WorkFlow>(wf);
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
                //setUpdateSql();//�趨��Update���
                //setParameter();//�趨����
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                PS_WorkFlow wf = new PS_WorkFlow();
                wf.WorkFlowId = WorkFlowId;
                wf.WFClassId = WorkFlowClassId;
                wf.FlowCaption = WorkFlowCaption;
                wf.Description = Description;
                wf.Status = Status;
                wf.MgrUrl = MgrUrl;
                MainHelper.PlatformSqlMap.Update<PS_WorkFlow>(wf);
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
                PS_WorkFlow wf = new PS_WorkFlow();
                wf.WorkFlowId = workflowId;
                return MainHelper.PlatformSqlMap.DeleteByKey<PS_WorkFlow>(wf);
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
                string tmpStr = " where WorkFlowId='" + workflowId + "'";
                IList list = (IList)MainHelper.PlatformSqlMap.GetList<PS_WorkFlow>("SelectPS_WorkFlowList", tmpStr);
                if (list.Count == 0)
                {
                    DataTable dt = new DataTable();
                    return dt;
                
                }
                return ConvertHelper.ToDataTable(list);
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
                string tmpStr = " where WorkFlowId='" + workflowId + "'";
                IList list = (IList)MainHelper.PlatformSqlMap.GetList("SelectPS_WorkTaskControlsList", tmpStr);

                return ConvertHelper.ToDataTable(list);
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
        /// �����Ȩ������������
        /// </summary>
        /// <param name="FatherClassId">������Id</param>
        /// <returns>�ӷ���table</returns>
        public static DataTable GetAllowsStartWorkFlows(string userId)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "WorkTaskSelectStartPro";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@UserId", userId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                //string str = "select * from ( select  distinct  WFClassId,Caption,FatherId,WorkFlowId,FlowCaption,WorkTaskid,TaskCaption,cllevel,mgrurl,clmgrurl from WorkTaskView  where ((OperContent IN (SELECT OperContent FROM opercontentView where UserId='"+userId+"') ) OR (OperContent = 'ALL')) and TaskTypeId='1'and Status='1' union select distinct  WFClassId,Caption,FatherId,WorkFlowId,FlowCaption,WorkTaskid,TaskCaption,cllevel,mgrurl,clmgrurl  from WorkTaskAccreditView  where AccreditToUserId=@UserId and AccreditStatus='1'and   TaskTypeId='1') a order by cllevel,Caption";
                string tmpStr = " '" + userId + "'";
                IList list = MainHelper.PlatformSqlMap.GetList("SelectPS_WorkTaskViewStartList", tmpStr);
                if (list.Count == 0)
                {
                    DataTable dt = new DataTable();
                    return dt;
                
                }
                return ConvertHelper.ToDataTable(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// ��ù�����ģ����Ϣ
        /// </summary>
        /// <param name="workflowId">����ģ������</param>
        /// <returns></returns>
        public static DataTable GetWorkflowsByCaption(string workflowCaption)
        {
           
            string tmpStr = "where FlowCaption like '%"+workflowCaption+"%'";
            try
            {

                IList list = (IList)MainHelper.PlatformSqlMap.GetList("SelectPS_WorkFlowList", tmpStr);

                return ConvertHelper.ToDataTable(list);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool Exists(string workFlowid)
        {
            string tmpSql = " where workflowId='"+workFlowid+"'";

            IList list = (IList)MainHelper.PlatformSqlMap.GetList("SelectPS_WorkFlowList", tmpSql);

            if (list.Count > 0) return true;
            return false;

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
                PS_WorkFlow wf = new PS_WorkFlow();
                wf.WorkFlowId=workflowId;
                wf.Status=status;
                return MainHelper.PlatformSqlMap.Update<PS_WorkFlow>(wf);

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
                PS_WorkFlow wf = new PS_WorkFlow();
                wf.WorkFlowId = workflowId;
                wf.WFClassId= wfclassid;
                return MainHelper.PlatformSqlMap.Update<PS_WorkFlow>(wf);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		
	}
}
