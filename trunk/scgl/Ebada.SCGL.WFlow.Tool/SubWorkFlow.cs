using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;
using System.Collections;
using Ebada.Core;


namespace Ebada.SCGL.WFlow.Tool
{
   
    /// <summary>
    /// �����̽ڵ����ñ�
    /// </summary>
    public  class SubWorkFlow
    {
        //������subworkflow��� ���ʲ���
        //private SqlDataItem sqlDataItem = new SqlDataItem();
        private string[] fieldList ={ "SubId", "WorkflowId", "WorkTaskId", "subWorkflowId", "subStartTaskId", "subWorkflowCaption", "Description" };
        private string tableName = "SubWorkFlow";
        private string keyField = "SubId";
        private string sqlString = "";

        //�����ֶ�
        public string SubId = "";
        public string WorkflowId = "";
        public string WorkTaskId = "";
        public string SubWorkflowId = "";
        public string SubStartTaskId = "";
        public string SubWorkflowCaption="";
        public string Description = "";
        /// <summary>
		/// �������������ñ����
		/// </summary>
		/// <param name="workflowId">������id</param>
		/// <param name="state">��д״̬���½�\�޸�\���</param>
		/// <param name="taskItems"></param>
		/// <param name="lineItems"></param>
        public SubWorkFlow(string subId, string state)
		{
            if (SubId.Trim().Length == 0 || SubId == null)
                throw new Exception("��ʼ��SubWorkFlow�����State ����Ϊ�գ�");

            SubId = subId;
			
		}
        public SubWorkFlow()
        {
 
        }
        //private void setParameter()
        //{
        //    sqlDataItem.ParameterList.Clear();
        //    sqlDataItem.AppendParameter("@SubId", SubId);
        //    sqlDataItem.AppendParameter("@WorkflowId", WorkflowId);
        //    sqlDataItem.AppendParameter("@WorkTaskId", WorkTaskId);
        //    sqlDataItem.AppendParameter("@subWorkflowId", SubWorkflowId);
        //    sqlDataItem.AppendParameter("@subStartTaskId", SubStartTaskId);
        //    sqlDataItem.AppendParameter("@SubWorkflowCaption", SubWorkflowCaption);
        //    sqlDataItem.AppendParameter("@Description", Description);
			


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
        //    sqlString = sqlString + " where " + keyField + "=@" + this.keyField ;
        //    sqlDataItem.CommandText = sqlString;
        //}

		/// <summary>
		/// �½� һ������ģ��
		/// </summary>
        public void InsertSubWorkFlow()
		{
            if (SubId.Trim().Length == 0 || SubId == null)
                throw new Exception("InsertSubWorkFlow��������SubId ����Ϊ�գ�");
			
			try
			{
                //setInsertSql();//�趨insert���
                //setParameter();//�趨����
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                PS_SubWorkFlow swf = new PS_SubWorkFlow();
                swf.subId= SubId;
                swf.WorkflowId= WorkflowId;
                swf.WorkTaskId= WorkTaskId;
                swf.subWorkflowId= SubWorkflowId;
                swf.subStartTaskId= SubStartTaskId;
                swf.subWorkflowCaption= SubWorkflowCaption;
                swf.Description = Description;
                MainHelper.PlatformSqlMap.Create<PS_SubWorkFlow>(swf); 
			}
            catch (Exception ex)
            {
                throw ex;
            }
		}
		/// <summary>
		/// �޸�һ������������
		/// </summary>
        public void UpdateSubWorkFlow()
		{
            if (SubId.Trim().Length == 0 || SubId == null)
                throw new Exception("UpdateWorkFlow��������SubId ����Ϊ�գ�");

			try
			{
                //setUpdateSql();//�趨��Update���
                //setParameter();//�趨����
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                PS_SubWorkFlow swf = new PS_SubWorkFlow();
                swf.subId = SubId;
                swf.WorkflowId = WorkflowId;
                swf.WorkTaskId = WorkTaskId;
                swf.subWorkflowId = SubWorkflowId;
                swf.subStartTaskId = SubStartTaskId;
                swf.subWorkflowCaption = SubWorkflowCaption;
                swf.Description = Description;
                MainHelper.PlatformSqlMap.Update<PS_SubWorkFlow>(swf); 
			}
			catch(Exception ex)
			{
				throw ex;
			}

		}
        public static int DeleteSubWorkFlow(string workflowId, string taskId)
        {
           
            try
            {
                //string sqlStr = "delete from SubWorkFlow where WorkFlowId=@WorkFlowId and WorkTaskId=@WorkTaskId";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sqlStr;
                //sqlItem.AppendParameter("@WorkFlowId", workflowId);
                //sqlItem.AppendParameter("@WorkTaskId", taskId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteNonQuery(sqlItem);
                string tmpStr = " where  WorkFlowId='" + workflowId + "' and WorkTaskId='" + taskId + "'";
                return MainHelper.PlatformSqlMap.DeleteByWhere<PS_SubWorkFlow>(tmpStr); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       

        /// <summary>
        /// ���������������Ϣ
        /// </summary>
        /// <param name="workflowId"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public static DataTable GetSubWorkflowTable(string workflowId,string taskId)
        {
            try
            {
                //string sqlStr = "select * from SubWorkFlow where WorkFlowId=@WorkFlowId and WorkTaskId=@WorkTaskId";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sqlStr;
                //sqlItem.AppendParameter("@WorkFlowId", workflowId);
                //sqlItem.AppendParameter("@WorkTaskId", taskId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string tmpStr = " where   WorkFlowId='" + workflowId + "' and WorkTaskId='" + taskId + "'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectPS_SubWorkFlowList", tmpStr);
                if (li.Count == 0)
                {
                    DataTable dt = new DataTable();

                    return dt;
                }
                return ConvertHelper.ToDataTable(li); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// ������̵�����������
        /// </summary>
        /// <param name="workflowId"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public static DataTable GetWorkflowAllSub(string workflowId)
        {
            try
            {
                //string sqlStr = "select * from SubWorkFlow where WorkFlowId=@WorkFlowId ";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sqlStr;
                //sqlItem.AppendParameter("@WorkFlowId", workflowId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string tmpStr = " where   WorkFlowId='" + workflowId + "'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectPS_SubWorkFlowList", tmpStr);
                if (li.Count == 0)
                {
                    DataTable dt = new DataTable();

                    return dt;
                }
                return ConvertHelper.ToDataTable(li); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// �ж�������������Ϣ�Ƿ����
        /// </summary>
        /// <param name="workflowId"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public static bool ExistsSubWorkflow(string workflowId, string taskId)
        {
            //string sqlStr = "select * from SubWorkFlow where  WorkFlowId=@WorkFlowId and WorkTaskId=@WorkTaskId";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = sqlStr;
            //sqlItem.AppendParameter("@WorkFlowId", workflowId);
            //sqlItem.AppendParameter("@WorkTaskId", taskId);
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.RecordExists(sqlItem);
            string tmpStr = " where   WorkFlowId='" + workflowId + "' and WorkTaskId='" + taskId + "'";
            IList li = MainHelper.PlatformSqlMap.GetList("SelectPS_SubWorkFlowList", tmpStr);
            if (li.Count > 0) return true;
            return false; 

        }
        /// <summary>
        /// �ж��������Ƿ����
        /// </summary>
        /// <param name="workflowId"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public static bool Exists(string subId)
        {
        //    string sqlStr = "select * from SubWorkFlow where  subId=@subId";
        //    SqlDataItem sqlItem = new SqlDataItem();
        //    sqlItem.CommandText = sqlStr;
        //    sqlItem.AppendParameter("@subId", subId);
        //    ClientDBAgent agent = new ClientDBAgent();
        //    return agent.RecordExists(sqlItem);
            string tmpStr = " where   subId='" + subId  + "'";
            IList li = MainHelper.PlatformSqlMap.GetList("SelectPS_SubWorkFlowList", tmpStr);
            if (li.Count > 0) return true;
            return false; 
        }

       
    }
}
