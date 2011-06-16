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
    public class WorkFlowTask
    {
        /// <summary>
        /// 任务节点名称
        /// </summary>
        public String TaskName;
        /// <summary>
        /// 任务节点的id
        /// </summary>
        public string TaskId;
        /// <summary>
        /// 流程模版的id
        /// </summary>
        public string WorkFlowId;
        /// <summary>
        /// 节点类型
        /// </summary>
        public int TaskType;
        /// <summary>
        /// 判断节点and/or
        /// </summary>
        public string TaskTypeAndOr="";
        /// <summary>
        /// 节点坐标
        /// </summary>
        public int X, Y;
        /// <summary>
        /// 处理者策略
        /// </summary>
        public string OperRule="";
        /// <summary>
        /// 备注
        /// </summary>
        public string Description = "";
        /// <summary>
        /// 处理者是本人时跳过处理
        /// </summary>
        public bool IsJumpSelf = false;
        /// <summary>
        /// 更新任务节点数据
        /// </summary>
        private string[] fieldList ={ "WorkTaskId", "TaskCaption", "WorkFlowId", "TaskTypeId", "iXPosition", "iYPosition",
                                     "OperRule","Description","TaskTypeAndOr","IsJumpSelf" };
        private string tableName = "WorkTask";
        private string keyField = "WorkTaskId";
        private string sqlString = "";
        //private void setParameter()
        //{
        //    sqlDataItem.ParameterList.Clear();
        //    sqlDataItem.AppendParameter("@WorkTaskId", this.TaskId);
        //    sqlDataItem.AppendParameter("@TaskCaption", this.TaskName);
        //    sqlDataItem.AppendParameter("@WorkFlowId", this.WorkFlowId);
        //    sqlDataItem.AppendParameter("@TaskTypeId", this.TaskType,typeof(int));
        //    sqlDataItem.AppendParameter("@iXPosition", this.X,typeof(int));
        //    sqlDataItem.AppendParameter("@iYPosition", this.Y,typeof(int));
        //    sqlDataItem.AppendParameter("@OperRule", this.OperRule);
        //    sqlDataItem.AppendParameter("@Description", this.Description);
        //    sqlDataItem.AppendParameter("@TaskTypeAndOr", this.TaskTypeAndOr);
        //    sqlDataItem.AppendParameter("@IsJumpSelf", this.IsJumpSelf,typeof(bool));

        //}
        ///// <summary>
        ///// 增加一个任务节点的语句
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
        ///// <summary>
        ///// 修改当前任务节点的语句
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
        /// <summary>
        ///增加任务节点
        /// </summary>
        public void InsertTask()
        {
            if (TaskId.Trim().Length == 0 || TaskId == null)
                throw new Exception("InsertTask方法错误，TaskId 不能为空！");
            try
            {
                //setInsertSql();//设定insert语句
                //setParameter();//设定参数
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                WF_WorkTask wf = new WF_WorkTask();
                wf.WorkTaskId = this.TaskId;
                wf.TaskCaption = this.TaskName;
                wf.WorkFlowId = this.WorkFlowId;
                wf.TaskTypeId = this.TaskType.ToString();
                wf.iXPosition = this.X;
                wf.iYPosition = this.Y;
                wf.OperRule = this.OperRule;
                wf.Description = this.Description;
                wf.TaskTypeAndOr = this.TaskTypeAndOr;
                wf.IsJumpSelf = this.IsJumpSelf;
                MainHelper.PlatformSqlMap.Create<WF_WorkTask>(wf); 
            }
            catch (Exception ex)
            {
                throw  ex;
            }


        }
        /// <summary>
        /// 修改任务节点
        /// </summary>
        public void UpdateTask()
        {
            if (TaskId.Trim().Length == 0 || TaskId == null)
                throw new Exception("UpdateTask方法错误，TaskId 不能为空！");
            try
            {
                //setUpdateSql();//设定定Update语句
                //setParameter();//设定参数
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                WF_WorkTask wf = new WF_WorkTask();
                wf.WorkTaskId = this.TaskId;
                wf.TaskCaption = this.TaskName;
                wf.WorkFlowId = this.WorkFlowId;
                wf.TaskTypeId = this.TaskType.ToString();
                wf.iXPosition = this.X;
                wf.iYPosition = this.Y;
                wf.OperRule = this.OperRule;
                wf.Description = this.Description;
                wf.TaskTypeAndOr = this.TaskTypeAndOr;
                wf.IsJumpSelf = this.IsJumpSelf;
                MainHelper.PlatformSqlMap.Update<WF_WorkTask>(wf); 
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 删除一个任务节点
        /// </summary>
        /// <param name="workflowId"></param>
        /// <param name="worktaskId"></param>
        public static int DeleteTask(string workflowId, string worktaskId)
        {
            try
            {
                string tmpStr = "delete WF_WorkTask where workflowid='" + workflowId + "' and WorkTaskId='" + worktaskId + "'";



                return MainHelper.PlatformSqlMap.DeleteByWhere<WF_WorkTask>(tmpStr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 删除任务的所以处理人
        /// </summary>
        /// <param name="worktaskId"></param>
        /// <returns></returns>
        public static int DeleteAllOperator(string worktaskId)
        {
            try
            {

                string tmpStr = " where worktaskId='" + worktaskId + "'";



                return MainHelper.PlatformSqlMap.DeleteByWhere<WF_Operator>(tmpStr);

            }
            catch (Exception ex)
            {
                throw ex;
            }
 
        }
        /// <summary>
        /// 删除任务的所有任务变量
        /// </summary>
        /// <param name="worktaskId"></param>
        /// <returns></returns>
        public static int DeleteAllTaskVar(string worktaskId)
        {
            try
            {
                string sqlStr = " where  WorkTaskId='" + worktaskId + "'";

                //int i = MainHelper.PlatformSqlMap.Update("UpdateWF_TaskVarDeleteByValue", sqlStr);
                int i= MainHelper.PlatformSqlMap.DeleteByWhere<WF_TaskVar>(sqlStr);
                return i;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 删除任务的所有任务命令
        /// </summary>
        /// <param name="worktaskId"></param>
        /// <returns></returns>
        public static int DeleteAllCommands(string worktaskId)
        {
            try
            {
                string sqlStr = "where  WorkTaskId='" + worktaskId + "'";

                return MainHelper.PlatformSqlMap.DeleteByWhere<WF_WorkTaskCommands>(sqlStr);



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 删除任务的所有控制权限
        /// </summary>
        /// <param name="worktaskId"></param>
        /// <returns></returns>
        public static int DeleteAllPower(string workflowId,string worktaskId)
        {
            try
            {
                string sqlStr = " where  workflowId='" + workflowId + "' and  WorkTaskId='" + worktaskId + "'";


                return MainHelper.PlatformSqlMap.DeleteByWhere<WF_WorkTaskPower>(sqlStr);



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 删除任务的所有表单
        /// </summary>
        /// <param name="worktaskId"></param>
        /// <returns></returns>
        public static int DeleteAllControls(string worktaskId)
        {
            try
            {
                string sqlStr = " where  WorkTaskId='" + worktaskId + "'";

                return MainHelper.PlatformSqlMap.DeleteByWhere<WF_WorkTaskControls>(sqlStr);



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 获得任务列表
        /// </summary>
        /// <param name="workflowId">流程Id</param>
        /// <returns></returns>
        public static DataTable GetWorkTasks(string workflowId)
        {
            try
            {
                string sqlStr = "where WorkFlowId = '" + workflowId + "' order by TaskCaption";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskByWhere", sqlStr);
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
        /// 获得任务处理者列表
      /// </summary>
      /// <param name="workflowId">工作流模板Id</param>
      /// <param name="taskId">任务模板Id</param>
      /// <returns></returns>
        public static DataTable GetTaskOperator(string workflowId,string workTaskId)
        {
            try
            {
                string sqlStr = "where WorkTaskId ='" + workTaskId + "' and workflowId='" + workflowId + "'";

                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_OperatorByWhere", sqlStr);
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
        /// 获得任务命令列表
        /// </summary>
        /// <param name="workflowId">工作流模板Id</param>
        /// <param name="taskId">任务模板Id</param>
        /// <returns></returns>
        public static DataTable GetTaskCommands(string workFlowId, string workTaskId)
        {
            try
            {
                string sqlStr = " where WorkTaskId ='"+workTaskId+"'and workflowId='"+workFlowId+"'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskCommandsList", sqlStr);
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
        /// 获得控制权限
        /// </summary>
        /// <param name="workflowId">工作流模板Id</param>
        /// <param name="taskId">任务模板Id</param>
        /// <returns></returns>
        public static DataTable GetTaskPower(string workFlowId, string workTaskId)
        {
            try
            {
                string sqlStr = "where WorkTaskId ='" + workTaskId + "'and workflowId='" + workFlowId + "'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskPowerList", sqlStr);
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
        /// 获得开始节点
        /// </summary>
        /// <param name="workflowId">流程模板Id</param>
        /// <returns></returns>
        public static DataTable GetStartTask(string workFlowId)
        {
            try
            {
                string sqlStr = "where TaskTypeId = '1' and  workflowId='" + workFlowId + "'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskPowerList", sqlStr);
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
        /// 判断节点是否存在
        /// </summary>
        /// <returns></returns>
        public static bool ExistTask(string workTaskId)
        {
            try
            {
                bool isfind = false;
                if (workTaskId.Trim().Length == 0 || workTaskId == null)
                    throw new Exception("ExistTask方法错误，workTaskId 不能为空!");

                string sqlStr = " where WorkTaskId='" + workTaskId + "'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskList", sqlStr);
                if (li.Count > 0) isfind = true;
                return isfind;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获得任务名称
        /// </summary>
        /// <param name="worktaskId">任务模板Id</param>
        /// <returns></returns>
        public static string GetTaskCaption(string workTaskId)
        {
            try
            {
                string strturn = "";
                string sqlStr = "where WorkTaskId ='" + workTaskId+"'";

                IList<WF_WorkTask> li = MainHelper.PlatformSqlMap.GetList<WF_WorkTask>("SelectWF_WorkTaskList", sqlStr);
                if (li.Count > 0) strturn = li[0].TaskCaption;
                return strturn;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获得任务列表
        /// </summary>
        /// <param name="worktaskId">任务模板Id</param>
        /// <returns></returns>
        public static DataTable GetTaskTable(string workTaskId)
        {
            try
            {
                string sqlStr = " where WorkTaskId ='" + workTaskId + "'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskViewList", sqlStr);
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
        /// 获得一个任务模板在流程实例中的所有任务实例
        /// </summary>
        /// <param name="worktaskId">任务模板Id</param>
        /// <returns></returns>
        public static DataTable GetTaskInstance(string workflowId, string workflowInsId, string workaskId)
        {
            try
            {
                string sqlStr = " where   workflowId='" + workflowId + "'" +
                    " and workflowInsId='" + workflowInsId + "' and WorkTaskId ='" + workaskId + "'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInstanceList", sqlStr);
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
        /// 获得任务变量列表
        /// </summary>
        /// <param name="workflowId">任务模板Id</param>
        /// <returns></returns>
        public static DataTable GetTaskVar(string workaskId)
        {
            try
            {
                string sqlStr = " where WorkTaskId  ='" + workaskId + "'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_TaskVarList", sqlStr);
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
        /// 获得任务节点绑定的表单
        /// </summary>
        /// <param name="workflowId">任务模板Id</param>
        /// <returns></returns>
        public static DataTable GetTaskControls(string workTaskId)
        {
            try
            {
                string sqlStr = " where WorkTaskId ='"+workTaskId+"' order by CtrlOrderNbr";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskControlsViewList", sqlStr);
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
        /// 任务节点绑定表单
        /// </summary>
        /// <param name="mainUserCtrlId">主表单id</param>
        /// <param name="userContrlsId">任务节点id</param>
        public static void SetTaskUserCtrls(string userCtrlId, string workflowid,string worktaskId)
        {
            try
            {
             
                WF_WorkTaskControls wt = new WF_WorkTaskControls();
                wt.UserControlId= userCtrlId;
                wt.WorkflowId=workflowid;
                wt.WorktaskId = worktaskId;
                if (MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkTaskControls>(wt)==null)
                MainHelper.PlatformSqlMap.Create<WF_WorkTaskControls>(wt);
                else
                MainHelper.PlatformSqlMap.Update <WF_WorkTaskControls>(wt);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 设置任务节点的控制权限
        /// </summary>
        /// <param name="powerName">权限名</param>
        /// <param name="workflowid">workflowid</param>
        /// <param name="worktaskId">worktaskId</param>
        public static void SetTaskPower(string powerName, string workflowid, string worktaskId)
        {
            try
            {

                WF_WorkTaskPower wt = new WF_WorkTaskPower();
                wt.PowerName = powerName;
                wt.WorkFlowId = workflowid;
                wt.WorkTaskId = worktaskId;
                MainHelper.PlatformSqlMap.Create<WF_WorkTaskPower>(wt);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
