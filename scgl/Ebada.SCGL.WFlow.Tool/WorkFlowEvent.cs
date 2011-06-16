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
    public class WorkFlowEvent
    {
        //private SqlDataItem sqlDataItem = new SqlDataItem();
        private string[] fieldList ={ "Guid", "WorkFlowId", "WorkTaskId", "Remark", "OtSms", "OtMsg", "OtEmail", "RmSms", "RmMsg", "RmEmail", "OtToUsers", "RmToUsers" };
        private string tableName = "WorkFlowEvent";
        private string keyField = "WorkTaskId";
        private string sqlString = "";
        public string Guid = "";
        public string WorkFlowId = "";
        public string WorkTaskId = "";
        public string Remark = "";
        public bool OtSms ;
        public bool OtMsg ;
        public bool OtEmail ;
        public bool RmSms ;
        public bool RmMsg ;
        public bool RmEmail ;
        public string OtToUsers = "";
        public string RmToUsers = "";

        public WorkFlowEvent()
        {
        }
        //private void setParameter()
        //{
        //    sqlDataItem.ParameterList.Clear();
        //    sqlDataItem.AppendParameter("@Guid", Guid);
        //    sqlDataItem.AppendParameter("@WorkFlowId", WorkFlowId);
        //    sqlDataItem.AppendParameter("@WorkTaskId", WorkTaskId);
        //    sqlDataItem.AppendParameter("@Remark", Remark);
        //    sqlDataItem.AppendParameter("@OtSms", OtSms,typeof(bool));
        //    sqlDataItem.AppendParameter("@OtMsg", OtMsg, typeof(bool));
        //    sqlDataItem.AppendParameter("@OtEmail", OtEmail, typeof(bool));
        //    sqlDataItem.AppendParameter("@RmSms", RmSms, typeof(bool));
        //    sqlDataItem.AppendParameter("@RmMsg", RmMsg, typeof(bool));
        //    sqlDataItem.AppendParameter("@RmEmail", RmEmail, typeof(bool));
        //    sqlDataItem.AppendParameter("@OtToUsers", OtToUsers);
        //    sqlDataItem.AppendParameter("@RmToUsers", RmToUsers);

        //}
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
        //    sqlString = sqlString + " where " + keyField + "=@" + keyField ;
        //    sqlDataItem.CommandText = sqlString;
        //}
        /// <summary>
        /// 增加WorkFlowEvent
        /// </summary>
        public void Insert()
        {
            try
            {
                //setInsertSql();//设定insert语句
                //setParameter();//设定参数
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 更新WorkFlowEvent
        /// </summary>
        public void Update()
        {
            if (WorkTaskId.Trim().Length == 0 || WorkTaskId == null)
                throw new Exception("Update方法错误，WorkTaskId不能为空！");
            try
            {
                //setUpdateSql();//设定Update语句
                //setParameter();//设定参数
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                WF_WorkFlowEvent wfEvent = new WF_WorkFlowEvent();
                wfEvent.Guid= Guid;
                wfEvent.WorkFlowId= WorkFlowId;
                wfEvent.WorkTaskId= WorkTaskId;
                wfEvent.Remark= Remark;
                wfEvent.OtSms= OtSms ;
                wfEvent.OtMsg= OtMsg ;
                wfEvent.OtEmail= OtEmail ;
                wfEvent.RmSms= RmSms ;
                wfEvent.RmMsg= RmMsg ;
                wfEvent.RmEmail= RmEmail ;
                wfEvent.OtToUsers= OtToUsers;
                wfEvent.RmToUsers= RmToUsers;
                MainHelper.PlatformSqlMap.Create<WF_WorkFlowEvent>(wfEvent); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获得WorkFlowEvent表
        /// </summary>
        /// <param name=WorkTaskId></param>
        /// <returns></returns>
        public static DataTable GetWorkFlowEventTable(string worktaskid)
        {
            try
            {
                string tmpStr = " where WorkTaskId='"+worktaskid+"'";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //sqlItem.AppendParameter("@worktaskid", worktaskid);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkFlowEventList", tmpStr);
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
        public static DataTable GetWorkFlowAllEventTable(string workFlowId)
        {
            try
            {
                string tmpStr = " where workFlowId='" + workFlowId + "'";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //sqlItem.AppendParameter("@workFlowId", workFlowId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkFlowEventList", tmpStr);
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
        public void GetWorkFlowEventInfo(string worktaskid)
        {
            DataTable dt = GetWorkFlowEventTable(worktaskid);
            if (dt != null && dt.Rows.Count > 0)
            {
                Guid = dt.Rows[0]["Guid"].ToString();
                WorkFlowId = dt.Rows[0]["WorkFlowId"].ToString();
                WorkTaskId = dt.Rows[0]["WorkTaskId"].ToString();
                Remark = dt.Rows[0]["Remark"].ToString();
                OtSms = Convert.ToBoolean(dt.Rows[0]["OtSms"].ToString());
                OtMsg = Convert.ToBoolean(dt.Rows[0]["OtMsg"].ToString());
                OtEmail = Convert.ToBoolean(dt.Rows[0]["OtEmail"].ToString());
                RmSms = Convert.ToBoolean(dt.Rows[0]["RmSms"].ToString());
                RmMsg = Convert.ToBoolean(dt.Rows[0]["RmMsg"].ToString());
                RmEmail = Convert.ToBoolean(dt.Rows[0]["RmEmail"].ToString());
                OtToUsers = dt.Rows[0]["OtToUsers"].ToString();
                RmToUsers = dt.Rows[0]["RmToUsers"].ToString();

            }
        }
        /// <summary>
        /// 根据主键删除记录
        /// </summary>
        /// <param name=WorkTaskId></param>
        /// <returns></returns>
        public static int Delete(string worktaskid)
        {
            try
            {
                string tmpSql = " where WorkTaskId='" + worktaskid + "'";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpSql;
                //sqlItem.AppendParameter("@worktaskid", worktaskid);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteNonQuery(sqlItem);
                return MainHelper.PlatformSqlMap.DeleteByWhere<WF_WorkFlowEvent>(tmpSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
