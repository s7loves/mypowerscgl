using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;
using System.Collections;
using Ebada.Core;
using Ebada.SCGL.WFlow.Tool;

namespace Ebada.SCGL.WFlow.Engine
{
    public class WorkFlowInstance
    {
        //工作流实例WorkFlowInstance表的 访问参数
        //private SqlDataItem sqlDataItem = new SqlDataItem();
        private string[] fieldList ={ "WorkFlowInsId", "WorkflowId", "WorkflowNo", "FlowInsCaption", "Description",
                                      "Priority","Status","NowTaskId","isSubWorkflow","MainWorkflowInsId","MainWorktaskId",
                                        "MainWorkflowId","MainWorktaskInsId"};
                                    
        private string tableName = "WorkFlowInstance";
        private string keyField = "WorkFlowInsId";
        private string sqlString = "";

        public string WorkflowInsId;
        public string WorkflowId;
        public string WorkflowNo;
        public string WorkflowInsCaption;
        public string Description;
        public string Priority;
        public string Status;
        public string NowTaskId;
        public bool isSubWorkflow=false;
        public string MainWorkflowInsId = "";
        public string MainWorktaskId = "";
        public string MainWorkflowId="";
        public string MainWorktaskInsId="";

        public WorkFlowInstance()
        {
        }
        //private void setParameter()
        //{
        //    sqlDataItem.ParameterList.Clear();
        //    sqlDataItem.AppendParameter("@WorkflowInsId", this.WorkflowInsId);
        //    sqlDataItem.AppendParameter("@WorkflowId", this.WorkflowId);
        //    sqlDataItem.AppendParameter("@WorkflowNo", this.WorkflowNo);
        //    sqlDataItem.AppendParameter("@FlowInsCaption", this.WorkflowInsCaption);
        //    sqlDataItem.AppendParameter("@Description", this.Description);
        //    sqlDataItem.AppendParameter("@Priority", this.Priority);
        //    sqlDataItem.AppendParameter("@Status", this.Status);
        //    sqlDataItem.AppendParameter("@NowTaskId", this.NowTaskId);
        //    sqlDataItem.AppendParameter("@isSubWorkflow", this.isSubWorkflow,typeof(bool));
        //    sqlDataItem.AppendParameter("@MainWorkflowInsId", this.MainWorkflowInsId);
        //    sqlDataItem.AppendParameter("@MainWorktaskId", this.MainWorktaskId);
        //    sqlDataItem.AppendParameter("@MainWorkflowId", this.MainWorkflowId);
        //    sqlDataItem.AppendParameter("@MainWorktaskInsId", this.MainWorktaskInsId);
            

        //}
        ///**//// <summary>
        ///// 增加一个工作流实例的语句
        ///// </summary>
        //private void setInsertSql()
        //{
        //    string tmpValueList = "";
        //    string tmpFieldName = "";
        //    sqlString = "insert into " + tableName + "(";
        //    int tmpInt = this.fieldList.Length;
        //    for (int i = 0; i < tmpInt - 1; i++)
        //    {
        //        tmpFieldName = fieldList[i].ToString();
        //        sqlString = sqlString + tmpFieldName + ",";
        //        tmpValueList = tmpValueList + "@" + tmpFieldName + ",";

        //    }
        //    tmpFieldName = this.fieldList[tmpInt - 1].ToString();
        //    sqlString = sqlString + tmpFieldName;
        //    tmpValueList = tmpValueList + "@" + tmpFieldName;
        //    this.sqlString = sqlString + ")values(" + tmpValueList + ")";
        //    sqlDataItem.CommandText = sqlString;
        //}
        ///**//// <summary>
        ///// 修改当前工作流实例的语句
        ///// </summary>
        //private void setUpdateSql()
        //{
        //    string tmpFieldName = "";
        //    int tmpInt = this.fieldList.Length;
        //    sqlString = "update " + tableName + " set ";
        //    for (int i = 0; i < tmpInt - 1; i++)
        //    {
        //        tmpFieldName = this.fieldList[i].ToString();
        //        sqlString = sqlString + tmpFieldName + "=@" + tmpFieldName + ",";

        //    }
        //    tmpFieldName = fieldList[tmpInt - 1].ToString();
        //    sqlString = sqlString + tmpFieldName + "=@" + tmpFieldName;
        //    sqlString = sqlString + " where " + keyField + "=@" + this.keyField;
        //    sqlDataItem.CommandText = sqlString;
        //}
        /**//// <summary>
        /// 创建工作流实例
        /// </summary>
        public void Create()
        {
            try
            {
                //setInsertSql();//设定insert语句
                //setParameter();//设定参数
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
              //  DebugHF.WriteErrorLog("Create流程实例WorkflowInsCaption=" + WorkflowInsCaption + ",WorkflowInsId=" + WorkflowInsId, WorkflowInsId);
                WF_WorkFlowInstance workFlowIns = new WF_WorkFlowInstance();
                workFlowIns.WorkFlowInsId=this.WorkflowInsId;
                workFlowIns.WorkFlowId=this.WorkflowId;
                workFlowIns.WorkFlowNo=this.WorkflowNo;
                workFlowIns.FlowInsCaption=this.WorkflowInsCaption;
                workFlowIns.Description=this.Description;
                workFlowIns.Priority=this.Priority;
                workFlowIns.Status=this.Status;
                workFlowIns.NowTaskId=this.NowTaskId;
                workFlowIns.isSubWorkflow=this.isSubWorkflow;
                workFlowIns.MainWorkflowInsId=this.MainWorkflowInsId;
                workFlowIns.MainWorktaskId=this.MainWorktaskId;
                workFlowIns.MainWorkflowId=this.MainWorkflowId;
                workFlowIns.MainWorktaskInsId=this.MainWorktaskInsId;
                MainHelper.PlatformSqlMap.Create<WF_WorkFlowInstance>(workFlowIns);
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
        }
        /**////// <summary>
        ///// 可启动的流程
        ///// </summary>
        ///// <param name="userId">用户Id</param>
        ///// <returns>可启动的流程列表</returns>
        //public static DataTable StartWorkflow(string userId)
        //{
        //    try
        //    {
        //        SqlDataItem sqlItem = new SqlDataItem();
        //        sqlItem.CommandText = "WorkTaskSelectStartPro";
        //        sqlItem.CommandType = CommandType.StoredProcedure.ToString();
        //        sqlItem.AppendParameter("@userId", userId);
        //        ClientDBAgent agent = new ClientDBAgent();
        //        return  agent.ExecuteDataTable(sqlItem);
        
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /**//// <summary>
        /// 待办任务，包括新任务和已认领任务
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <param name="topsize">返回的的记录条数</param>
        /// <returns>返回待办任务列表</returns>
        public static DataTable WorkflowToDoWorkTasks(string userId, int topsize)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "WorkFlowToDoTasks";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@userId", userId);
                //sqlItem.AppendParameter("@topsize", topsize, typeof(int));
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);

                string filedstr = "Priority,WorkFlowNo,taskStartTime,TaskInsCaption,FlowInsCaption,OperContent,Status,FlowCaption," +
                         "TaskCaption,UserId,WorkFlowId,WorkTaskId,WorkFlowInsId,WorkTaskInsId,OperType,TaskTypeId,operatorInsId," +
                         "OperatedDes,OperDateTime,taskEndTime,flowStartTime,flowEndTime,pOperatedDes,Description,OperStatus,taskInsType,TaskInsDescription";

        	    string  sqlstr="select top "+topsize.ToString()+" * from (";
                 sqlstr=sqlstr+"  select "+filedstr +"  from WF_WorkTaskInstanceView  WHERE ";
                 sqlstr=sqlstr+" ((OperContent IN (SELECT OperContent FROM WF_OperContentView where UserId='"+userId+"') ) OR ";
                 sqlstr=sqlstr+" (OperContent = 'ALL')) and  (OperStatus='0') and ";
                 sqlstr=sqlstr+"(Status='1') "; //新任务
                 sqlstr=sqlstr+"union  ";
                 sqlstr=sqlstr+" select "+filedstr+ " from WF_WorkTaskInsAccreditView where ";
                 sqlstr=sqlstr+" AccreditToUserId='"+userId +"' and AccreditStatus='1' and status='1'  ";//--授权处理的任务
                 sqlstr=sqlstr+"union  ";
                 sqlstr=sqlstr+ " select "+filedstr +" from WF_WorkTaskInstanceView where UserId='"+userId+"' and (status='1' or status='2')";//--已认领任务
                 sqlstr=sqlstr+") a ";
                 sqlstr=sqlstr+"  order by status, taskStartTime desc ";
                Console.WriteLine (sqlstr);
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInstanceViewListValue", sqlstr);
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
        /**/
        /// <summary>
        /// 指定的未认领的任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="WorkFlowId">流程Id</param>
        /// <param name="WorkFlowInstanceId">流程实例Id</param>
        /// <returns>指定的未认领的任务列表</returns>
        public static DataTable SelectedWorkflowClaimingTask(string userId, string WorkFlowId, string WorkFlowInstanceId, int topsize)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "WorkTaskSelectClaimPro";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@userId", userId);
                //sqlItem.AppendParameter("@topsize", topsize,typeof(int));
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string filedstr = "Priority,WorkFlowNo,taskStartTime,TaskInsCaption,FlowInsCaption,OperContent,Status,FlowCaption," +
                         "TaskCaption,UserId,WorkFlowId,WorkTaskId,WorkFlowInsId,WorkTaskInsId,OperType,TaskTypeId,operatorInsId," +
                          "OperatedDes,OperDateTime,taskEndTime,flowStartTime,flowEndTime,pOperatedDes,Description,OperStatus,taskInsType,TaskInsDescription";


                string sqlstr = "select top " + topsize + " * from (";
                sqlstr = sqlstr + "  select " + filedstr + "  from WF_WorkTaskInstanceView  WHERE ";
                sqlstr = sqlstr + " ((OperContent IN (SELECT OperContent FROM WF_OperContentView where UserId='" + userId + "') ) OR (OperContent IN (SELECT RoleID FROM rUserRole where UserId='" + userId + "') ) OR ";
                sqlstr = sqlstr + " (OperContent = 'ALL')) and  (OperStatus='0') and ";
                sqlstr = sqlstr + " (Status='1') and (WorkFlowId='" + WorkFlowId + "' and WorkFlowInsId='" + WorkFlowInstanceId + "') ";
                sqlstr = sqlstr + "union  ";
                sqlstr = sqlstr + " select " + filedstr + " from WF_WorkTaskInsAccreditView where ";
                sqlstr = sqlstr + " AccreditToUserId='" + userId + "' and AccreditStatus='1'and status='1'  ";
                sqlstr = sqlstr + " ) a ";
                sqlstr = sqlstr + "  order by taskStartTime desc ";
                Console.WriteLine(sqlstr);
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInstanceViewListValue", sqlstr);
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
        /**//// <summary>
        /// 未认领的任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>未认领的任务列表</returns>
        public static DataTable WorkflowClaimingTask(string userId, int topsize)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "WorkTaskSelectClaimPro";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@userId", userId);
                //sqlItem.AppendParameter("@topsize", topsize,typeof(int));
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string filedstr = "Priority,WorkFlowNo,taskStartTime,TaskInsCaption,FlowInsCaption,OperContent,Status,FlowCaption," +
                         "TaskCaption,UserId,WorkFlowId,WorkTaskId,WorkFlowInsId,WorkTaskInsId,OperType,TaskTypeId,operatorInsId," +
                          "OperatedDes,OperDateTime,taskEndTime,flowStartTime,flowEndTime,pOperatedDes,Description,OperStatus,taskInsType,TaskInsDescription";


                string sqlstr="select top "+topsize+" * from (";
                sqlstr=sqlstr+"  select "+filedstr +"  from WF_WorkTaskInstanceView  WHERE ";
                sqlstr = sqlstr + " ((OperContent IN (SELECT OperContent FROM WF_OperContentView where UserId='" + userId + "') ) OR ";
                sqlstr=sqlstr+" (OperContent = 'ALL')) and  (OperStatus='0') and ";
                sqlstr=sqlstr+" (Status='1') ";
                sqlstr=sqlstr+"union  ";
                sqlstr = sqlstr + " select " + filedstr + " from WF_WorkTaskInsAccreditView where ";
                sqlstr=sqlstr+" AccreditToUserId='"+userId +"' and AccreditStatus='1'and status='1'  ";
                sqlstr=sqlstr+" ) a ";
                sqlstr=sqlstr+"  order by taskStartTime desc ";
                Console.WriteLine (sqlstr);
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInstanceViewListValue", sqlstr);
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
       
        /**//// <summary>
        /// 我参与的任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>我参与的任务列表</returns>
        public static DataTable WorkflowAllTask(string userId,int topsize)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "WorkflowMyTask";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@userId", userId);
                //sqlItem.AppendParameter("@flag", "ALL");
                //sqlItem.AppendParameter("@topsize", topsize, typeof(int));
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string sqlstr = " select top " + topsize + "  * from WF_WorkTaskInstanceView where UserId='" + userId + "' order by taskStartTime desc";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInstanceViewListValue2", sqlstr);
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
        /**//// <summary>
        /// 我已认领的任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>我已认领的任务列表</returns>
        public static DataTable WorkflowClaimedTask(string userId,int topsize)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "WorkflowMyTask";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@userId", userId);
                //sqlItem.AppendParameter("@flag", "2");
                //sqlItem.AppendParameter("@topsize", topsize, typeof(int));
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string sqlstr = " select top " + topsize + "   * from WF_WorkTaskInstanceView where UserId='" + userId + "' and status=2 order by taskStartTime desc";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInstanceViewListValue2", sqlstr);
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
        /**//// <summary>
        /// 正在运行的流程实例列表
        /// </summary>
        /// <param name="topsize">显示条数</param>
        /// <returns>正在运行的流程实例列表</returns>
        public static DataTable GetWorkFlowInstanceRunning( int topsize)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "WorkFlowInstanceRunning";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@topsize", topsize, typeof(int));
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);

                string sqlstr = " select top " + topsize + "   * from WF_WorkTaskInstanceView where   status=2 order by taskStartTime desc";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInstanceViewListValue2", sqlstr);
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
        /**//// <summary>
        /// 已完成的流程实例
        /// </summary>
        /// <param name="topsize">显示条数</param>
        /// <returns>已完成的流程实例列表</returns>
        public static DataTable GetWorkFlowInstanceComplete(int topsize)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "WorkFlowInstanceComplete";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@topsize", topsize, typeof(int));
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string sqlstr = "select top " + topsize + "  *  from WF_WorkFlowInstance  where Status='3'  order by  StartTime desc";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInstanceViewListValue2", sqlstr);
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
        /**//// <summary>
        /// 我已完成的任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>我已完成的任务表</returns>
        public static DataTable WorkflowCompletedTask(string userId,int topsize)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "WorkflowMyTask";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@userId", userId);
                //sqlItem.AppendParameter("@flag", "3");
                //sqlItem.AppendParameter("@topsize", topsize, typeof(int));
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string sqlstr = " select top " + topsize + "   * from WF_WorkTaskInstanceView where UserId='" + userId + "' and status=3 order by taskStartTime desc";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInstanceViewListValue2", sqlstr);
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
        /**//// <summary>
        /// 异常终止的任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>异常终止的任务表</returns>
        public static DataTable WorkflowAbnormalTask(string userId,int topsize)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "WorkflowMyTask";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@userId", userId);
                //sqlItem.AppendParameter("@flag", "4");
                //sqlItem.AppendParameter("@topsize", topsize, typeof(int));
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string sqlstr = " select top " + topsize + "   * from WF_WorkTaskInstanceView where UserId='" + userId + "' and status=4 order by taskStartTime desc";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInstanceViewListValue2", sqlstr);
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
        /**//// <summary>
        /// 获得一个流程实例实例的信息
        /// </summary>
        /// <param name="operatorInsId">处理者实例Id</param>
        /// <returns></returns>
        public static DataTable GetWorkflowInstance(string workflowInsId)
        {
            try
            {
                //string getSql = "select * from WorkflowInstance where workflowInsId=@workflowInsId";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = getSql;
                //sqlItem.AppendParameter("@workflowInsId", workflowInsId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string sqlstr = " where workflowInsId='" + workflowInsId + "'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkFlowInstanceList", sqlstr);
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
        /**//// <summary>
        /// 流程历史
        /// </summary>
        /// <returns></returns>
        public static DataTable GetWorkflowHistory(string workflowinsid)
        {
            try
            {
                //string getSql = " select distinct workflowid,worktaskid,workflowinsid,worktaskinsid,operatorinsid," +
                //               "flowcaption,taskcaption,operateddes,taskendtime from WorkTaskInstanceView  " +
                //               " where status='3' and workflowinsid=@workflowinsid  order by taskendtime";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = getSql;
                //sqlItem.AppendParameter("@workflowinsid", workflowinsid);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string sqlstr = " select distinct workflowid,worktaskid,workflowinsid,worktaskinsid,operatorinsid," +
                               "flowcaption,taskcaption,operateddes,taskendtime from WF_WorkTaskInstanceView  " +
                               " where status='3' and workflowinsid='" + workflowinsid + "'  order by taskendtime";
                 
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkFlowInstanceHistoryList", sqlstr);
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
        /**//// <summary>
        /// 设定流程实例正常结束
        /// </summary>
        public static void SetWorkflowInstanceOver(string workflowInsId)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "SetWorkflowInstanceOverPro";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@workflowInsId", workflowInsId);
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlItem);
                //WF_WorkFlowInstance workFlowIns = new WF_WorkFlowInstance();
                //workFlowIns.WorkFlowInsId = workflowInsId;
                //workFlowIns.Status = "3";
                //workFlowIns.EndTime = System.DateTime.Now;
                string strsql = "  update WF_WorkFlowInstance set Status='3',EndTime=getdate()  where WorkFlowInsId='" + workflowInsId + "'";
                MainHelper.PlatformSqlMap.Update("UpdateWF_WorkFlowInstanceValue", strsql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// 设定流程实例的当前位置
        /// </summary>
        public static void SetCurrTaskId(string workflowInsId, string nowtaskId)
        {
            try
            {
                //string sql = "update workflowinstance set nowtaskId=@nowtaskId where workflowInsid=@workflowInsid";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sql;
                //sqlItem.AppendParameter("@nowtaskId", nowtaskId);
                //sqlItem.AppendParameter("@workflowInsid", workflowInsId);
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlItem);
                //WF_WorkFlowInstance workFlowIns = new WF_WorkFlowInstance();
                //workFlowIns.WorkFlowInsId = workflowInsId;
                //workFlowIns.NowTaskId = nowtaskId;
                //MainHelper.PlatformSqlMap.Update<WF_WorkFlowInstance>(workFlowIns);

                string strsql = "  update WF_WorkFlowInstance set nowtaskId='" + nowtaskId + "' where workflowInsid='" + workflowInsId + "'";
                MainHelper.PlatformSqlMap.Update("UpdateWF_WorkFlowInstanceValue", strsql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// 设定流程实例挂起
        /// </summary>
        public static string SetSuspend(string workflowInsId)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "SetWorkflowInsSuspend";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@workflowInsId", workflowInsId);
                //ClientDBAgent agent = new ClientDBAgent();
                //int i= agent.ExecuteNonQuery(sqlItem);
                //if (i > 0)
                //{
                //    return WorkFlowConst.SuccessCode;
                //}
                //else
                //{
                //    return WorkFlowConst.WorkFlowSuspendErrorCode;
                //}
                string strsql = "  update WF_WorkFlowInstance set SuspendStaus=Status,Status='5',SuspendTime=getdate() where  WorkFlowInsId='" + workflowInsId + "' and Status<>'5'";
                int i = MainHelper.PlatformSqlMap.Update("UpdateWF_WorkFlowInstanceValue", strsql);
                if (i > 0)
                {
                    return WorkFlowConst.SuccessCode;
                }
                else
                {
                    return WorkFlowConst.WorkFlowSuspendErrorCode;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// 设定流程实例取消挂起
        /// </summary>
        public static string SetResume(string workflowInsId)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "SetWorkflowInsResume";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@workflowInsId", workflowInsId);
                //ClientDBAgent agent = new ClientDBAgent();
                //int i = agent.ExecuteNonQuery(sqlItem);
                //if (i > 0)
                //{
                //    return WorkFlowConst.SuccessCode;
                //}
                //else
                //{
                //    return WorkFlowConst.WorkFlowResumeErrorCode;
                //}
     
                string strsql = "update WF_WorkFlowInstance  set Status=SuspendStaus where  WorkFlowInsId='" + workflowInsId + "' and Status='5'";
                int i = MainHelper.PlatformSqlMap.Update("UpdateWF_WorkFlowInstanceValue", strsql);
                if (i > 0)
                {
                    return WorkFlowConst.SuccessCode;
                }
                else
                {
                    return WorkFlowConst.WorkFlowSuspendErrorCode;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// 设定流程实例异常终止
        /// </summary>
        public static string SetAbnormal(string workflowInsId,string userId,string msg)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "SetWorkflowInsAbnormal";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@workflowInsId", workflowInsId);
                //sqlItem.AppendParameter("@userId", userId);
                //sqlItem.AppendParameter("@msg", msg);
                //ClientDBAgent agent = new ClientDBAgent();
                //int i = agent.ExecuteNonQuery(sqlItem);
                //if (i > 0)
                //{
                //    return WorkFlowConst.SuccessCode;
                //}
                //else
                //{
                //    return WorkFlowConst.WorkFlowAbnormalErrorCode;
                //}
                
                string strsql = "update WF_WorkFlowInstance  set Status='4' where  WorkFlowInsId='" + workflowInsId + "' ";
                int i = MainHelper.PlatformSqlMap.Update("UpdateWF_WorkFlowInstanceValue", strsql);
                WF_WorkflowAbnormal workfolwab = new WF_WorkflowAbnormal();
                workfolwab.WorkflowInsId = workflowInsId;
                workfolwab.UserId = userId;
                workfolwab.AbnormalMsg = msg;
                MainHelper.PlatformSqlMap.Create<WF_WorkflowAbnormal>(workfolwab);
                if (i > 0)
                {
                    return WorkFlowConst.SuccessCode;
                }
                else
                {
                    return WorkFlowConst.WorkFlowSuspendErrorCode;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// 获得流程流水号
        /// </summary>
        public static string  GetWorkflowNO()
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "CreatAutoCode";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@Auto_Type", WorkConst.WORKFLOW_FLOW);
                //ClientDBAgent agent = new ClientDBAgent();
                //return  agent.ExecuteScalar(sqlItem);

                 
                string sqlstr = " where flagCode='" + WorkConst.WORKFLOW_FLOW + "'";
                IList<WF_FrmworkParamer> li = MainHelper.PlatformSqlMap.GetList<WF_FrmworkParamer>("SelectWF_FrmworkParamerList", sqlstr);
                if (li.Count > 0)
                {
                    li[0].FlagValue = Convert.ToString(Convert.ToInt32(li[0].FlagValue) + 1);
                    MainHelper.PlatformSqlMap.Update<WF_FrmworkParamer>(li[0]);

                    return li[0].FlagValue;
                }
                else
                    return "0003";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// 未认领任务的个数
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int GetClaimingTaskCount(string userId)
        {

            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = "GetTaskCountPro";
            //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
            //sqlItem.AppendParameter("@UserId", userId);
            //sqlItem.AppendParameter("@flag", "0");
            //ClientDBAgent agent = new ClientDBAgent();
            //return Convert.ToInt32(agent.ExecuteScalar(sqlItem));
            string sqlstr = " where ((OperContent IN (SELECT OperContent FROM WF_opercontentView where UserId='"+userId+"') ) OR (OperContent = 'ALL')) and  (OperStatus='0') and (Status='1') ";
            int i=Convert.ToInt32 (  MainHelper.PlatformSqlMap.GetObject("GetWF_WorkTaskInstanceViewRowCount", sqlstr))  ;
            sqlstr = " where AccreditToUserId='" + userId + "'   and AccreditStatus='1'and status='1' ";
            i += Convert.ToInt32(MainHelper.PlatformSqlMap.GetObject("GetWF_WorkTaskInsAccreditViewRowCount", sqlstr));
            return i;
        }
/************************************************************
    //功能：待办任务
    //说明：包括新任务和已认领任务
    //输入参数：
    //@UserId 当前用户的工号
    //输出：数据集
    //作者：刘恩国
    //创建日期：2008-03-31
*************************************************************/
        public static int GetToDoTasksCount(string userId)
        {
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = "WorkFlowToDoTasks";
            //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
            //sqlItem.AppendParameter("@userId", userId);
            //sqlItem.AppendParameter("@topsize", 99999, typeof(int));
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.ExecuteDataTable(sqlItem).Rows.Count;
            return WorkflowToDoWorkTasks(userId, 99999).Rows.Count;
        }
        /**//// <summary>
        /// 已认领任务个数
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int GetClaimedTaskCount(string userId)
        {
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = "GetTaskCountPro";
            //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
            //sqlItem.AppendParameter("@UserId", userId);
            //sqlItem.AppendParameter("@flag", "2");
            //ClientDBAgent agent = new ClientDBAgent();
            //return Convert.ToInt32(agent.ExecuteScalar(sqlItem));
            string sqlstr = " where UserId='" + userId + "' and (Status='2') ";
            return Convert.ToInt32(MainHelper.PlatformSqlMap.GetObject("GetWF_WorkTaskInstanceViewRowCount", sqlstr));
            
           
        }
        /**//// <summary>
        /// 我参与的任务个数
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int GetAllTaskCount(string userId)
        {
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = "GetTaskCountPro";
            //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
            //sqlItem.AppendParameter("@UserId", userId);
            //sqlItem.AppendParameter("@flag", "ALL");
            //ClientDBAgent agent = new ClientDBAgent();
            //return Convert.ToInt32(agent.ExecuteScalar(sqlItem));
            string sqlstr = " where UserId='" + userId + "'  ";
            return Convert.ToInt32(MainHelper.PlatformSqlMap.GetObject("GetWF_WorkTaskInstanceViewRowCount", sqlstr));
        }
        /**//// <summary>
        /// 我完成的任务个数
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int GetCompletedTaskCount(string userId)
        {
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = "GetTaskCountPro";
            //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
            //sqlItem.AppendParameter("@UserId", userId);
            //sqlItem.AppendParameter("@flag", "3");
            //ClientDBAgent agent = new ClientDBAgent();
            //return Convert.ToInt32(agent.ExecuteScalar(sqlItem));
            string sqlstr = " where UserId='" + userId + "' and (Status='3') ";
            return Convert.ToInt32(MainHelper.PlatformSqlMap.GetObject("GetWF_WorkTaskInstanceViewRowCount", sqlstr));
        }
        public static int GetAbnormalTaskCount(string userId)
        {
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = "GetTaskCountPro";
            //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
            //sqlItem.AppendParameter("@UserId", userId);
            //sqlItem.AppendParameter("@flag", "4");
            //ClientDBAgent agent = new ClientDBAgent();
            //return Convert.ToInt32(agent.ExecuteScalar(sqlItem));
            string sqlstr = " where UserId='" + userId + "' and (Status='4') ";
            return Convert.ToInt32(MainHelper.PlatformSqlMap.GetObject("GetWF_WorkTaskInstanceViewRowCount", sqlstr));

        } 
        
    }
}
