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
    /// 子流程节点配置表
    /// </summary>
    public  class SubWorkFlow
    {
        //子流程subworkflow表的 访问参数
        //private SqlDataItem sqlDataItem = new SqlDataItem();
        private string[] fieldList ={ "SubId", "WorkflowId", "WorkTaskId", "subWorkflowId", "subStartTaskId", "subWorkflowCaption", "Description" };
        private string tableName = "SubWorkFlow";
        private string keyField = "SubId";
        private string sqlString = "";

        //属性字段
        public string SubId = "";
        public string WorkflowId = "";
        public string WorkTaskId = "";
        public string SubWorkflowId = "";
        public string SubStartTaskId = "";
        public string SubWorkflowCaption="";
        public string Description = "";
        /// <summary>
		/// 生成子流程配置表的类
		/// </summary>
		/// <param name="workflowId">工作流id</param>
		/// <param name="state">读写状态：新建\修改\浏览</param>
		/// <param name="taskItems"></param>
		/// <param name="lineItems"></param>
        public SubWorkFlow(string subId, string state)
		{
            if (SubId.Trim().Length == 0 || SubId == null)
                throw new Exception("初始化SubWorkFlow类错误，State 不能为空！");

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
		/// 新建 一个流程模板
		/// </summary>
        public void InsertSubWorkFlow()
		{
            if (SubId.Trim().Length == 0 || SubId == null)
                throw new Exception("InsertSubWorkFlow方法错误，SubId 不能为空！");
			
			try
			{
                //setInsertSql();//设定insert语句
                //setParameter();//设定参数
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
		/// 修改一个子流程设置
		/// </summary>
        public void UpdateSubWorkFlow()
		{
            if (SubId.Trim().Length == 0 || SubId == null)
                throw new Exception("UpdateWorkFlow方法错误，SubId 不能为空！");

			try
			{
                //setUpdateSql();//设定定Update语句
                //setParameter();//设定参数
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
        /// 获得子流程配置信息
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
        /// 获得流程的所有子流程
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
        /// 判断子流程配置信息是否存在
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
        /// 判断子流程是否存在
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
