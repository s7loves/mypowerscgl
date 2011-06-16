using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;
using System.Collections;
using Ebada.Core;


namespace Ebada.SCGL.WFlow.Engine
{
    public class OperatorInstance
    {
        //任务实例OperatorInstance表的 访问参数
        //private SqlDataItem sqlDataItem = new SqlDataItem();
        private string[] fieldList ={ "OperatorInsId", "WorkFlowId", "WorkTaskId", "WorkFlowInsId", "WorkTaskInsId",
                                      "UserId","OperType","OperRealtion","OperContent","OperContentText","OperStatus"};
        private string tableName = "OperatorInstance";
        private string keyField = "OperatorInsId";
        private string sqlString = "";

        public string OperatorInsId;
        public string WorkflowId;
        public string WorktaskId;
        public string WorkflowInsId;
        public string WorktaskInsId;
        public string UserId;
        public int    OperType;
        public int    OperRealtion;
        public string OperContent;
        public string OperContentText;
        public DateTime OperDateTime;
        public string OperStatus = "0";
        public string ChangeOperator;


        public OperatorInstance()
        {
        }
        //private void setParameter()
        //{
        //    sqlDataItem.ParameterList.Clear();
        //    sqlDataItem.AppendParameter("@OperatorInsId", this.OperatorInsId);
        //    sqlDataItem.AppendParameter("@WorkflowId", this.WorkflowId);
        //    sqlDataItem.AppendParameter("@WorktaskId", this.WorktaskId);
        //    sqlDataItem.AppendParameter("@WorkFlowInsId", this.WorkflowInsId);
        //    sqlDataItem.AppendParameter("@WorktaskInsId", this.WorktaskInsId);
        //    sqlDataItem.AppendParameter("@UserId", this.UserId);
        //    sqlDataItem.AppendParameter("@OperType", this.OperType,typeof(int));
        //    sqlDataItem.AppendParameter("@OperRealtion", this.OperRealtion,typeof(int));
        //    sqlDataItem.AppendParameter("@OperContent", this.OperContent);
        //    sqlDataItem.AppendParameter("@OperContentText", this.OperContentText);
        //    sqlDataItem.AppendParameter("@OperStatus", this.OperStatus);


        //}
        ///**//// <summary>
        ///// 增加一个处理者实例的语句
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
        ///// 修改当处理者实例的语句
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
        /// 判断处理者实例是否已经存在，避免重复数据
        /// </summary>
        /// <returns></returns>
        private bool operExists()
        {
            //string sql = "select * from OperatorInstance where WorkflowInsId=@WorkflowInsId and worktaskId=@worktaskId" +
            //              "   and operContent=@operContent and operstatus=@operstatus";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = sql;
            //sqlItem.AppendParameter("@WorkflowInsId", WorkflowInsId);
            //sqlItem.AppendParameter("@worktaskId", WorktaskInsId);
            //sqlItem.AppendParameter("@opertype", OperType,typeof(int));
            //sqlItem.AppendParameter("@operContent", OperContent);
            //sqlItem.AppendParameter("@operstatus", "0");
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.RecordExists(sqlItem);
            string tmpStr = " where WorkflowInsId='" + WorkflowId + "' and worktaskId='" + WorktaskId
               + "' and operContent='" + OperContent + "' and operstatus='" + 0 + "'";
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_OperatorInstanceList", tmpStr);
            if (li.Count > 0) return true;
            return false;

        }
        /**//// <summary>
        /// 是否排除该处理人
        /// </summary>
        /// <returns></returns>
        private bool operisExclue()
        {
            //string sql = "select * from Operator where WorkFlowId=@WorkFlowId and WorkTaskId=@WorkTaskId and InorExclude=@InorExclude " +
            //             " and operContent=@operContent";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = sql;
            //sqlItem.AppendParameter("@WorkFlowId", WorkflowId);
            //sqlItem.AppendParameter("@worktaskId", WorktaskId);
            //sqlItem.AppendParameter("@operContent", OperContent);
            //sqlItem.AppendParameter("@InorExclude", "0");
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.RecordExists(sqlItem);
            string tmpStr = " where WorkFlowId='" + WorkflowId + "' and WorkTaskId='" + WorktaskId
               + "' and operContent='" + OperContent + "' and InorExclude='" + 0 + "'";
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_OperatorList", tmpStr);
            if (li.Count > 0) return true;
            return false;

        }
        /**//// <summary>
        /// 创建处理者实例
        /// </summary>
        public void Create()
        {
            try
            {
                if (operExists()) return;//不重复添加
                if (operisExclue()) return;//排除的在外的处理人不添加
                //setInsertSql();//设定insert语句
                //setParameter();//设定参数
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                WF_OperatorInstance operInsta = new WF_OperatorInstance();
                operInsta.OperatorInsId=this.OperatorInsId;
                operInsta.WorkFlowId=this.WorkflowId;
                operInsta.WorkTaskId=this.WorktaskId;
                operInsta.WorkFlowInsId=this.WorkflowInsId;
                operInsta.WorkTaskInsId=this.WorktaskInsId;
                operInsta.UserId=this.UserId;
                operInsta.OperType=this.OperType;
                operInsta.OperRealtion=this.OperRealtion;
                operInsta.OperContent=this.OperContent;
                operInsta.OperContentText=this.OperContentText;
                operInsta.OperStatus = this.OperStatus;
                MainHelper.PlatformSqlMap.Create<WF_OperatorInstance>(operInsta); 

               // DebugHF.WriteErrorLog("Create处理者实例OperContent=" + OperContent + ",OperatorInsId=" + OperatorInsId, WorkflowInsId);

            }
            catch (Exception ex)
            {
                throw ex;
            }
 
        }
        /**//// <summary>
        /// 获得一个要处理的信息
        /// </summary>
        /// <param name="operatorInsId">处理者实例Id</param>
        /// <returns></returns>
        public static DataTable GetOperatorInstance(string operatorInsId)
        {
            try
            {
                //string getSql = "select * from WorkTaskInstanceView where OperatorInsId=@operatorInsId";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = getSql;
                //sqlItem.AppendParameter("@operatorInsId", operatorInsId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string tmpStr = "where OperatorInsId='" + operatorInsId + "'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInstanceViewList", tmpStr);
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
        /// 设定处理者实例正常结束
        /// </summary>
        public static void SetOperatorInstanceOver(string userId, string operatorInsId)
        {
            try
            {
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = "SetOperatorInstanceOverPro";
                //sqlItem.CommandType = CommandType.StoredProcedure.ToString();
                //sqlItem.AppendParameter("@UserId", userId);
                //sqlItem.AppendParameter("@operatorInsId", operatorInsId);
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlItem);
                WF_OperatorInstance operInsta = new WF_OperatorInstance();
                operInsta.OperatorInsId =operatorInsId;

                operInsta.UserId = userId;

                MainHelper.PlatformSqlMap.Update("UpdateWF_OperatorInstanceUserOverProByOperatorInsId",operInsta); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
