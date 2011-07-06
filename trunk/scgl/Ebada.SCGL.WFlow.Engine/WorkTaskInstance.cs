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
    public class WorkTaskInstance
    {
         //任务实例WorkTaskInstance表的 访问参数
        //private SqlDataItem sqlDataItem = new SqlDataItem();
        private string[] fieldList ={ "WorkTaskInsId", "WorkFlowId", "WorkTaskId", "WorkFlowInsId", "PreviousTaskId",
                                      "TaskInsCaption","Status"};
        private string tableName = "WorkTaskInstance";
        private string keyField = "WorkTaskInsId";
        private string sqlString = "";
        /**//// <summary>
        /// 新任务实例Id
        /// </summary>
        public string WorktaskInsId;
        public string WorkflowId;
        /**//// <summary>
        /// 新任务模板Id
        /// </summary>
        public string WorktaskId;

        public string WorkflowInsId;
        /**//// <summary>
        /// 前一任务实例Id
        /// </summary>

        public string PreviousTaskId;
        public string TaskInsCaption;
        public DateTime StartTime;
        public DateTime EndTime;
        public string Status;
        public string OperatedDes;


        public WorkTaskInstance()
        {
        }
        //private void setParameter()
        //{
        //    sqlDataItem.ParameterList.Clear();
        //    sqlDataItem.AppendParameter("@WorkTaskInsId", this.WorktaskInsId);
        //    sqlDataItem.AppendParameter("@WorkflowId", this.WorkflowId);
        //    sqlDataItem.AppendParameter("@WorktaskId", this.WorktaskId);
        //    sqlDataItem.AppendParameter("@WorkFlowInsId", this.WorkflowInsId);
        //    sqlDataItem.AppendParameter("@PreviousTaskId", this.PreviousTaskId);
        //    sqlDataItem.AppendParameter("@TaskInsCaption", this.TaskInsCaption);
        //    sqlDataItem.AppendParameter("@Status", this.Status);



        //}
        ///**//// <summary>
        ///// 增加一个任务实例的语句
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
        ///// 修改当前任务实例的语句
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
        /// 创建新任务实例
        /// </summary>
        public void Create()
        {
            try
            {
                //setInsertSql();//设定insert语句
                //setParameter();//设定参数
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                WF_WorkTaskInstance worktastIns = new WF_WorkTaskInstance();
                worktastIns.WorkTaskInsId=this.WorktaskInsId;
                worktastIns.WorkFlowId =this.WorkflowId;
                worktastIns.WorkTaskId =this.WorktaskId;
                worktastIns.WorkFlowInsId=this.WorkflowInsId;
                worktastIns.PreviousTaskId=this.PreviousTaskId;
                worktastIns.TaskInsCaption=this.TaskInsCaption;
                worktastIns.Status = this.Status;
                MainHelper.PlatformSqlMap.Create<WF_WorkTaskInstance>(worktastIns); 

                //DebugHF.WriteErrorLog("Create任务实例TaskInsCaption=" + TaskInsCaption + ",WorktaskInsId= " + WorktaskInsId, WorkflowInsId);
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
        }
        public static bool Exists(string worktaskInsId)
        {
            //string sql = "select * from WorkTaskInstance where WorkTaskInsId=@worktaskInsId";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = sql;
            //sqlItem.AppendParameter("@worktaskInsId", worktaskInsId);
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.RecordExists(sqlItem);
            string tmpStr = " where WorkTaskInsId='" + worktaskInsId + "'";
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInstanceList", tmpStr);
            if (li.Count > 0) return true;
            return false;
        }
        /**//// <summary>
        /// 设定任务实例正常结束
        /// </summary>
        public static void SetWorkTaskInstanceOver(string operatedDes,string worktaskInsId)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "SetWorkTaskInstanceOverPro";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@operatedDes", operatedDes);
                //sqlItem.AppendParameter("@worktaskInsId", worktaskInsId);
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlItem);
                WF_WorkTaskInstance worktastIns = new WF_WorkTaskInstance();
                worktastIns.WorkTaskInsId = worktaskInsId;
                worktastIns.OperatedDes = operatedDes;
                worktastIns.Status ="3";
                MainHelper.PlatformSqlMap.Update("UpdateWF_WorkTaskInstanceOverProByWorkTaskInsId", worktastIns); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// 设定任务实例成功提交信息
        /// </summary>
        public static void SetSuccessMsg(string successMsg, string worktaskInsId)
        {
            //string sql = "update WorkTaskInstance set SuccessMsg=@successMsg where WorkTaskInsId=@worktaskInsId";
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sql;
                //sqlItem.AppendParameter("@successMsg", successMsg);
                //sqlItem.AppendParameter("@worktaskInsId", worktaskInsId);
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlItem);
                WF_WorkTaskInstance worktastIns = new WF_WorkTaskInstance();
                worktastIns.WorkTaskInsId = worktaskInsId;
                worktastIns.SuccessMsg = successMsg;

                MainHelper.PlatformSqlMap.Update("UpdateWF_WorkTaskInstanceSuccessMsgByWorkTaskInsId", worktastIns); 

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// 获得任务实例成功提交信息
        /// </summary>
        public static string GetTaskToWhoMsg(string worktaskInsId)
        {
            try
            {
                string result = "";
                //string sql = "select * from WorkTaskInstanceView  where previoustaskid= @worktaskInsId and operstatus='0' order by opertype";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sql;
                //sqlItem.AppendParameter("@worktaskInsId", worktaskInsId);
                //ClientDBAgent agent = new ClientDBAgent();
                //DataTable dt= agent.ExecuteDataTable(sqlItem);
                string sql = "where previoustaskid='" + worktaskInsId + "' and operstatus='0' order by opertype";
                 DataTable dt=null;
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInstanceViewList", sql);
                if (li.Count == 0)
                {
                     dt = new DataTable();
                    
                }
                else
                dt= ConvertHelper.ToDataTable(li); 
                if (dt != null & dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        result = result +dt.Rows[i]["operContentText"].ToString() + ",";
                    }
                    result = result  + dt.Rows[dt.Rows.Count - 1]["operContentText"].ToString();
                }
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// 获得任务被谁处理
        /// </summary>
        public static string GetTaskDoneWhoMsg(string worktaskId,string workflowInsId)
        {
            try
            {
                string result = "";
                //string sql = "select distinct workflowInsId,worktaskid,operateddes,taskendtime from WorkTaskInstanceView  where WorkTaskId= @worktaskId " +
                //             " and status=3 and workflowInsId=@workflowInsId order by taskendtime";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sql;
                //sqlItem.AppendParameter("@worktaskId", worktaskId);
                //sqlItem.AppendParameter("@workflowInsId", workflowInsId);
                //ClientDBAgent agent = new ClientDBAgent();
                //DataTable dt = agent.ExecuteDataTable(sqlItem);
                string sql = "where WorkTaskId='" + worktaskId + "' and status=3 and workflowInsId='" + workflowInsId+"' order by taskendtime";
                DataTable dt = null;
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInstanceViewDistinctList", sql);
                if (li.Count == 0)
                {
                    dt = new DataTable();

                }
                else
                dt = ConvertHelper.ToDataTable(li); 
                if (dt != null & dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        result = result + dt.Rows[i]["operateddes"].ToString() + "|";
                    }
                    result = result + dt.Rows[dt.Rows.Count - 1]["operateddes"].ToString();
                }
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// 获得任务实例提交后返回信息
        /// </summary>
        public static string GetResultMsg(string worktaskInsId)
        {
            try
            {
                //string sql = "select SuccessMsg from WorkTaskInstance  where worktaskInsId= @worktaskInsId ";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sql;
                //sqlItem.AppendParameter("@worktaskInsId", worktaskInsId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return  agent.ExecuteScalar(sqlItem);
                string sql = "where worktaskInsId='" + worktaskInsId + "'";
               
                IList<WF_WorkTaskInstance> li = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskInstance>("SelectWF_WorkTaskInstanceSuccessMsgList", sql);
                if (li.Count == 0)
                {
                    return "";

                }
               return li[0].SuccessMsg ; 

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// 认领任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="worktaskInsId">任务实例Id</param>
        public static string WorkTaskClaim(string userId, string operatorInsId)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "WorkTaskClaimPro";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@OperatorInstanceId", operatorInsId);
                //sqlItem.AppendParameter("@UserId", userId);
                //ClientDBAgent agent = new ClientDBAgent();
                //int i=agent.ExecuteNonQuery(sqlItem);
                //if (i > 0)
                //{
                //    return WorkFlowConst.SuccessCode;
                //}
                //else
                //{
                //    return WorkFlowConst.TaskClaimErrorCode;
                //}
                string sql = "where OperatorInsId='" + operatorInsId + "'";

                IList<WF_OperatorInstance> li = MainHelper.PlatformSqlMap.GetList<WF_OperatorInstance>("SelectWF_OperatorInstanceList", sql);

                if (li.Count > 0)
                {
                    for (int i = 0; i < li.Count; i++)
                    {
                        //sql = "where WorkTaskInsId='" + li[i].WorkTaskInsId + "'and Status='1'";
                        WF_WorkTaskInstance worktaskins = new WF_WorkTaskInstance();

                        worktaskins.Status = "2";
                        worktaskins.OperatorInsId = operatorInsId;
                        worktaskins.WorkTaskInsId = li[i].WorkTaskInsId;
                        MainHelper.PlatformSqlMap.Update("UpdateWF_WorkTaskInstanceOperatorInsIdByWorkTaskInsId", worktaskins);

                    }
                }
                WF_OperatorInstance operIns = new WF_OperatorInstance();
                operIns.OperatorInsId = operatorInsId;
                operIns.OperStatus = "3";
                operIns.UserId = userId;
                MainHelper.PlatformSqlMap.Update("UpdateWF_OperatorInstanceOperStatusByOperatorInsId", operIns);
                return WorkFlowConst.SuccessCode;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message ); 
                return WorkFlowConst.TaskClaimErrorCode;
                //throw ex;
               
            }
            
                
           
            
        }
        /**//// <summary>
        /// 放弃认领任务
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="worktaskInsId">任务实例Id</param>
        public static string WorkTaskUnClaim(string userId, string operatorInsId)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "WorkTaskAbnegatePro";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@OperatorInstanceId", operatorInsId);
                //sqlItem.AppendParameter("@UserId", userId);
                //ClientDBAgent agent = new ClientDBAgent();
                //int i = agent.ExecuteNonQuery(sqlItem);
                //if (i > 0)
                //{
                //    return WorkFlowConst.SuccessCode;
                //}
                //else
                //{
                //    return WorkFlowConst.TaskUnClaimErrorCode;
                //}
                string sql = "where OperatorInsId='" + operatorInsId + "'";

                IList<WF_OperatorInstance> li = MainHelper.PlatformSqlMap.GetList<WF_OperatorInstance>("SelectWF_OperatorInstanceList", sql);

                if (li.Count > 0)
                {
                    for (int i = 0; i < li.Count; i++)
                    {
                        //sql = "where WorkTaskInsId='" + li[i].WorkTaskInsId + "'and Status='1'";
                        WF_WorkTaskInstance worktaskins = new WF_WorkTaskInstance();

                        worktaskins.Status = "1";
                        worktaskins.OperatorInsId = null;
                        worktaskins.WorkTaskInsId = li[i].WorkTaskInsId;
                        MainHelper.PlatformSqlMap.Update("UpdateWF_WorkTaskInstanceOperatorInsStatusIdByWorkTaskInsId", worktaskins);

                    }
                }
                WF_OperatorInstance operIns = new WF_OperatorInstance();
                operIns.OperatorInsId = operatorInsId;
                operIns.OperStatus = "0";
                operIns.UserId = null;
                MainHelper.PlatformSqlMap.Update("UpdateWF_OperatorInstanceUserIdOperStatusByOperatorInsId", operIns);
                return WorkFlowConst.SuccessCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return WorkFlowConst.TaskUnClaimErrorCode;
                //throw ex;

            }
            
        }
        public static string WorkTaskAssign(string userId, string assignUserId,  string operatorInsId)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "WorkTaskAssignPro";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@AssignUserId", assignUserId);
                //sqlItem.AppendParameter("@operatorInsId", operatorInsId);
                //sqlItem.AppendParameter("@UserId", userId);
                //ClientDBAgent agent = new ClientDBAgent();
                //int i=agent.ExecuteNonQuery(sqlItem);
                //if (i > 0)
                //{
                //    return WorkFlowConst.SuccessCode;
                //}
                //else
                //{
                //    return WorkFlowConst.TaskAssignErrorCode;
                //}
                mUser touser = MainHelper.PlatformSqlMap.GetOneByKey<mUser>(assignUserId);
                mUser fromuser = MainHelper.PlatformSqlMap.GetOneByKey<mUser>(userId);

             if (touser == null)
             {
                 return WorkFlowConst.TaskAssignErrorCode;
             }
             WF_OperatorInstance operins = MainHelper.PlatformSqlMap.GetOneByKey<WF_OperatorInstance>(operatorInsId);
             string sql = "where OperatorInsId='" + operatorInsId + "' and operstatus='3'";

             IList<WF_OperatorInstance> li = MainHelper.PlatformSqlMap.GetList<WF_OperatorInstance>("SelectWF_OperatorInstanceList", sql);
             if (li.Count > 0)
             {
                 WF_OperatorInstance newoperins = new WF_OperatorInstance();
                 newoperins.OperatorInsId = Guid.NewGuid().ToString();
                 newoperins.WorkFlowId = li[0].WorkFlowId;
                 newoperins.WorkTaskId = li[0].WorkTaskId;
                 newoperins.WorkFlowInsId = li[0].WorkFlowInsId;
                 newoperins.WorkTaskInsId = li[0].WorkTaskInsId;
                 newoperins.UserId = null;
                 newoperins.OperType = 10;
                 newoperins.OperContent = assignUserId;
                 newoperins.OperStatus = "0";
                 newoperins.ChangeOperator = userId;
                 newoperins.OperRealtion = li[0].OperRealtion;
                 MainHelper.PlatformSqlMap.Create<WF_OperatorInstance>(newoperins);
             }
             sql = "where WorkTaskInsId='" + operins.WorkTaskInsId  + "' and Status='2'";
             IList<WF_WorkTaskInstance> li2 = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskInstance>("SelectWF_WorkTaskInstanceList", sql);
             for (int i = 0; i <li2.Count; i++)
             {
                 li2[i].Status = "1";
                 li2[i].OperatorInsId = "";
                 if (li2[i].OperatedDes==null) li2[i].OperatedDes = "";
                 li2[i].OperatedDes = li2[i].OperatedDes + "指派[" + touser.UserName+"]处理,";
                 li2[i].TaskInsDescription = "由" + fromuser .UserName+ "指派";
                 MainHelper.PlatformSqlMap.Update<WF_OperatorInstance>(li2[i]);
             }
             WF_OperatorInstance operIns = new WF_OperatorInstance();
             operIns.ChangeOperator = assignUserId;
             operIns.OperStatus = "2";
             operIns.OperatorInsId = operatorInsId;
             MainHelper.PlatformSqlMap.Update("UpdateWF_OperatorInstanceUserIdOperStatusByOperatorInsId", operIns);
             return WorkFlowConst.SuccessCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return WorkFlowConst.TaskAssignErrorCode;
                //throw ex;
            }
        }
        public static string WorkTaskBack(string userId, string operatorInsId)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "WorkTaskSubmitBackPro";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@OperatorInstanceId", operatorInsId);
                //sqlItem.AppendParameter("@UserId", userId);
                //ClientDBAgent agent = new ClientDBAgent();
                //int i = agent.ExecuteNonQuery(sqlItem);
                //if (i > 0)
                //{
                //    return WorkFlowConst.SuccessCode;
                //}
                //else
                //{
                //    return WorkFlowConst.TaskAssignErrorCode;
                //}
                 mUser fromuser = MainHelper.PlatformSqlMap.GetOneByKey<mUser>(userId);
                WF_OperatorInstance operins = MainHelper.PlatformSqlMap.GetOneByKey<WF_OperatorInstance>(operatorInsId);
                WF_WorkTaskInstance workins = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkTaskInstance>(operins.WorkTaskInsId);
                SetWorkTaskInstanceOver(userId, operins.WorkTaskInsId);
                OperatorInstance.SetOperatorInstanceOver(userId, operatorInsId);
                WF_WorkTaskInstance workins2 = new WF_WorkTaskInstance();
                workins2.SuccessMsg = "退回至提交人(" + fromuser.UserName  + ")!";
                workins2.WorkTaskInsId = operins.WorkTaskInsId;
                workins2.OperatedDes = userId;
                MainHelper.PlatformSqlMap.Update("UpdateWF_WorkTaskInstanceSuccessMsgByWorkTaskInsId", workins2);
                WF_WorkTaskInstance preworkins = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkTaskInstance>(workins.PreviousTaskId);
                //创建一个任务实例
                string newTaskId = Guid.NewGuid().ToString();//新任务处理者实例Id
                WorkTaskInstance workTaskInstance = new WorkTaskInstance();
                workTaskInstance.WorkflowId = preworkins.WorkFlowId ;
                workTaskInstance.WorktaskId = preworkins.WorkTaskId ;
                workTaskInstance.WorkflowInsId = preworkins.WorkFlowInsId ;
                workTaskInstance.WorktaskInsId = newTaskId;
                workTaskInstance.PreviousTaskId = workins.WorkTaskInsId ;
                workTaskInstance.TaskInsCaption = preworkins.TaskInsCaption ;
                workTaskInstance.Status = "1";
                workTaskInstance.Create();


                WF_OperatorInstance op = (WF_OperatorInstance)MainHelper.PlatformSqlMap.GetObject("SelectWF_OperatorInstanceList", " where WorkTaskInsId='" + workins.PreviousTaskId + "' ");
                //创建处理人实例
                OperatorInstance operatorInstance = new OperatorInstance();
                operatorInstance.OperatorInsId = Guid.NewGuid().ToString();
                operatorInstance.WorkflowId = operins.WorkFlowId ;
                operatorInstance.WorktaskId = operins.WorkTaskId ;
                operatorInstance.WorkflowInsId = workTaskInstance.WorkflowInsId;
                operatorInstance.WorktaskInsId = workTaskInstance.WorktaskInsId;
                operatorInstance.UserId = op.UserId ;
                operatorInstance.OperRealtion = op.OperRealtion ;
                operatorInstance.OperContent = op.OperContent;
                operatorInstance.OperContentText = op.OperContentText;
                operatorInstance.OperType = 3;//此处修改为指定处理人
                operatorInstance.Create();

                string strsql = "  update WF_WorkFlowInstance set nowtaskId='" + workTaskInstance.WorktaskId  + "' where workflowInsid='" + workTaskInstance.WorkflowInsId + "'";
                MainHelper.PlatformSqlMap.Update("UpdateWF_WorkFlowInstanceValue", strsql);

                //string sql = "update WF_WorkTaskInstance set EndTime=getdate(),status='2',OperatedDes=isnull(OperatedDes,'')+',但被[+" + fromuser.UserName + "+]退回,' where WorkTaskInsId='" + workins.PreviousTaskId + "' and Status=3";
                //MainHelper.PlatformSqlMap.Update("UpdateWF_WorkTaskInstanceByValue", sql);
                return WorkFlowConst.SuccessCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return WorkFlowConst.TaskAssignErrorCode;
                //throw ex;
            }
        }
        /**//// <summary>
        /// 获得任务实例列表
        /// </summary>
        /// <param name="worktaskId">任务实例Id</param>
        /// <returns></returns>
        public static DataTable GetTaskInsTable(string worktaskInsId)
        {
            try
            {
                //string sql = "select * from WorkTaskInstanceView where WorkTaskInsId=@WorkTaskInsId";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sql;
                //sqlItem.AppendParameter("@WorkTaskInsId", worktaskInsId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string sql = " where WorkTaskInsId='" + worktaskInsId + "'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInstanceViewList", sql);
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
        /// 获得加签处理人
        /// </summary>
        /// <param name="workflowId"></param>
        /// <param name="worktaskId"></param>
        /// <param name="workflowInsId"></param>
        /// <param name="worktaskInsId"></param>
        /// <returns></returns>
        public static DataTable GetTaskInsNextOperTable(string workflowId, string worktaskId, string workflowInsId, string worktaskInsId)
        {
            try
            {
                //string sql = "select * from WorkTaskInsNextOper where workflowId=@workflowId and worktaskId=@worktaskId " +
                //             " and workflowInsId=@workflowInsId and worktaskInsId=@worktaskInsId";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sql;
                //sqlItem.AppendParameter("@workflowId", workflowId);
                //sqlItem.AppendParameter("@worktaskId", worktaskId);
                //sqlItem.AppendParameter("@workflowInsId", workflowInsId);
                //sqlItem.AppendParameter("@worktaskInsId", worktaskInsId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string tmpStr = "where workflowId='" + workflowId + "' and worktaskId='" + worktaskId + "'"+
                 " and workflowInsId='" + workflowInsId + "' and worktaskInsId='" + worktaskInsId + "'";

                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInsNextOperList", tmpStr);
                if (li.Count == 0)
                {
                    DataTable dt = new DataTable();
                    return dt;
                }
                return ConvertHelper.ToDataTable(li); 
            }
            catch (Exception ex)
            {
                throw new Exception("加签处理人错误,"+ex.Message.ToString()); ;
            }
        }
       
    }
}
