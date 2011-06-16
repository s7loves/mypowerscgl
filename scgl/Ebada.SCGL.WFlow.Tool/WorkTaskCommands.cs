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
    public class WorkTaskCommands
    {
        //任务命令WorkTaskCommands表的 访问参数
        //private SqlDataItem sqlDataItem = new SqlDataItem();
        private string[] fieldList ={ "CommandId", "WorkFlowId", "WorkTaskId", "CommandName", "Description"};
        private string tableName = "WorkTaskCommands";
        private string keyField = "CommandId";
        private string sqlString = "";

        //任务命令的属性字段
        public string CommandId = "";
        public string WorkFlowId = "";
        public string WorkTaskId = "";
        public string CommandName = "";
        public string Description = "";

       
        public static DataTable GetTaskCommandsTable(string commandId)
        {
            try
            {
                string tmpStr = " where  CommandId='"+commandId+"'";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //sqlItem.AppendParameter("@commandId", commandId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskCommandsList", tmpStr);
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
        //private void setParameter()
        //{
        //    sqlDataItem.ParameterList.Clear();
        //    sqlDataItem.AppendParameter("@CommandId", this.CommandId);
        //    sqlDataItem.AppendParameter("@WorkFlowId", this.WorkFlowId);
        //    sqlDataItem.AppendParameter("@WorkTaskId", this.WorkTaskId);
        //    sqlDataItem.AppendParameter("@CommandName", this.CommandName);
        //    sqlDataItem.AppendParameter("@Description", this.Description);
            

        //}
        ///// <summary>
        ///// 增加一个任务命令的语句
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
        ///// 修改当前任务命令的语句
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
        ///增加任务命令
        /// </summary>
        public void InsertWorkTaskCommands()
        {
            if (CommandId.Trim().Length == 0 || CommandId == null)
                throw new Exception("InsertWorkTaskCommands方法错误，commandId 不能为空！");
            try
            {
                //setInsertSql();//设定insert语句
                //setParameter();//设定参数
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                WF_WorkTaskCommands wtc = new WF_WorkTaskCommands();
                wtc.CommandId=this.CommandId;
                wtc.WorkFlowId= this.WorkFlowId;
                wtc.WorkTaskId=this.WorkTaskId;
                wtc.CommandName=this.CommandName;
                wtc.Description=this.Description;
                MainHelper.PlatformSqlMap.Create<WF_WorkTaskCommands>(wtc); 
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        /// <summary>
        /// 修改任务命令
        /// </summary>
        public void UpdateWorkTaskCommands()
        {
            if (CommandId.Trim().Length == 0 || CommandId == null)
                throw new Exception("UpdateWorkTaskCommands方法错误，commandId 不能为空！");
            try
            {
                //setUpdateSql();//设定定Update语句
                //setParameter();//设定参数
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                WF_WorkTaskCommands wtc = new WF_WorkTaskCommands();
                wtc.CommandId = this.CommandId;
                wtc.WorkFlowId = this.WorkFlowId;
                wtc.WorkTaskId = this.WorkTaskId;
                wtc.CommandName = this.CommandName;
                wtc.Description = this.Description;
                MainHelper.PlatformSqlMap.Update<WF_WorkTaskCommands>(wtc); 
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 删除一个任务命令
        /// </summary>
        /// <param name="workflowId"></param>
        /// <param name="worktaskId"></param>
        public static int DeleteWorkTaskCommands(string commandId)
        {
            try
            {
                string sqlStr = " where CommandId='"+commandId+"'";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sqlStr;
                //sqlItem.AppendParameter("@commandId", commandId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteNonQuery(sqlItem);
                return MainHelper.PlatformSqlMap.DeleteByWhere<WF_WorkTaskCommands>(sqlStr);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetWorkFlowAllCommands(string workFlowId)
        {
            try
            {
                string tmpStr = " where  WorkflowId='" + workFlowId + "'";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //sqlItem.AppendParameter("@workFlowId", workFlowId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskCommandsList", tmpStr);
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
        public static bool Exists(string commandId)
        {
            string tmpSql = " where CommandId='" + commandId + "'";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.AppendParameter("@commandId", commandId);
            //sqlItem.CommandText = tmpSql;
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.RecordExists(sqlItem);
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskCommandsList", tmpSql);
            if (li.Count > 0) return true;
            return false ; 


        }
       
    }
}
