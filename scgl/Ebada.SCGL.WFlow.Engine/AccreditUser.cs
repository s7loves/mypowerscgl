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
    public class AccreditUser
    {
        //private SqlDataItem sqlDataItem = new SqlDataItem();
        private string[] fieldList ={ "AUserId", "AccreditFromUserId", "AccreditToUserId", "AcWorkflowId", "AcWorktaskId" };
        private string tableName = "AccreditUser";
        private string keyField = "AUserId";
        private string sqlString = "";
        public string AUserId = "";
        public string AccreditFromUserId = "";
        public string AccreditToUserId = "";
        public string AcWorkflowId = "";
        public string AcWorktaskId = "";

        public AccreditUser()
        {
        }
        //private void setParameter()
        //{
        //    sqlDataItem.ParameterList.Clear();
        //    sqlDataItem.AppendParameter("@AUserId", AUserId);
        //    sqlDataItem.AppendParameter("@AccreditFromUserId", AccreditFromUserId);
        //    sqlDataItem.AppendParameter("@AccreditToUserId", AccreditToUserId);
        //    sqlDataItem.AppendParameter("@AcWorkflowId", AcWorkflowId);
        //    sqlDataItem.AppendParameter("@AcWorktaskId", AcWorktaskId);

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
        //    sqlString = sqlString + " where " + keyField + "=@" + keyField;
        //    sqlDataItem.CommandText = sqlString;
        //}
        /**//// <summary>
        /// 增加AccreditUser
        /// </summary>
        public void Insert()
        {
            try
            {
                if (!accreditExists())
                {
                    //setInsertSql();//设定insert语句
                    //setParameter();//设定参数
                    //ClientDBAgent agent = new ClientDBAgent();
                    //agent.ExecuteNonQuery(sqlDataItem);
                    WF_AccreditUser accuser = new WF_AccreditUser();
                    accuser.AUserId = AUserId;
                    accuser.AccreditFromUserId = AccreditFromUserId;
                    accuser.AccreditToUserId = AccreditToUserId;
                    accuser.AcWorkflowId = AcWorkflowId;
                    accuser.AcWorktaskId = AcWorktaskId;
                    MainHelper.PlatformSqlMap.Create<WF_AccreditUser>(accuser); 
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool accreditExists()
        {
            //string sql = "select * from AccreditUser where AccreditFromUserId=@fromUserId and "+
            //             " AccreditToUserId=@toUserId and AcWorkflowId=@AcWorkflowId and "+
            //              "AcWorktaskId=@AcWorktaskId and AccreditStatus='1'";//有效的授权是否存在
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = sql;
            //sqlItem.AppendParameter("@fromUserId", AccreditFromUserId);
            //sqlItem.AppendParameter("@toUserId", AccreditToUserId);
            //sqlItem.AppendParameter("@AcWorkflowId", AcWorkflowId);
            //sqlItem.AppendParameter("@AcWorktaskId", AcWorktaskId);
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.RecordExists(sqlItem);
            string tmpStr = " where AccreditFromUserId='" + AccreditFromUserId + "' and AccreditToUserId='" + AccreditToUserId
                + "' and AcWorkflowId='" + AcWorkflowId + "' and AccreditStatus='1'";
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_AccreditUserList", tmpStr);
            if (li.Count > 0) return true;
            return false;

        }
        /**//// <summary>
        /// 判断用户是否是该任务节点的操作者，如果不是不允许授权该任务，
        /// 对于根据处理者策略获取的处理者类型，需要在流程模板中单独增加
        /// 该处理人才能授权。
        //
        /**//// </summary>
        /// <param name="userId"></param>
        /// <param name="workflowId"></param>
        /// <param name="worktaskId"></param>
        /// <returns></returns>
        public static bool isTaskOperator(string userId, string workflowId, string worktaskId)
        {
            //string sql = "select  * from WorkTaskView  where (" +
            //            "(OperContent IN (SELECT OperContent FROM opercontentView where UserId=@userId) or OperContent='ALL' ) and " +
            //            " workflowId=@workflowId and worktaskId=@worktaskId)";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = sql;
            //sqlItem.AppendParameter("@userId", userId);
            //sqlItem.AppendParameter("@workflowId", workflowId);
            //sqlItem.AppendParameter("@worktaskId", worktaskId);
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.RecordExists(sqlItem);
            string tmpStr = " where (OperContent IN (SELECT OperContent FROM opercontentView where UserId='" + userId + "'  or OperContent='ALL' ) and workflowId='" + workflowId
               + "' and worktaskId='" + worktaskId + "' )";
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskViewList", tmpStr);
            if (li.Count > 0) return true;
            return false;


        }
        public bool isTaskOperator()
        {
         return   isTaskOperator(AccreditFromUserId, AcWorkflowId,AcWorktaskId);
        }
        /**//// <summary>
        /// 更新AccreditUser
        /// </summary>
        public void Update()
        {
            if (AUserId.Trim().Length == 0 || AUserId == null)
                throw new Exception("Update方法错误，AUserId不能为空！");
            try
            {
                //setUpdateSql();//设定Update语句
                //setParameter();//设定参数
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                WF_AccreditUser accuser = new WF_AccreditUser();
                accuser.AUserId = AUserId;
                accuser.AccreditFromUserId = AccreditFromUserId;
                accuser.AccreditToUserId = AccreditToUserId;
                accuser.AcWorkflowId = AcWorkflowId;
                accuser.AcWorktaskId = AcWorktaskId;
                MainHelper.PlatformSqlMap.Update<WF_AccreditUser>(accuser); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// 获得AccreditUser表
        /// </summary>
        /// <param name=AUserId></param>
        /// <returns></returns>
        public static DataTable GetAccreditUserTable(string auserid)
        {
            try
            {
                //string sql = "select * from AccreditUser where AUserId=@AUserId";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sql;
                //sqlItem.AppendParameter("@AUserId", auserid);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string tmpStr = "where AUserId='" + auserid + "'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_AccreditUserList", tmpStr);
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
        /// 已授出的权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static DataTable GetToAccreditTable(string userId)
        {
            //string sql = "select distinct flowcaption,taskcaption,workflowid,"+
            //            "auserid,worktaskid,accreditfromuserid,accredittouserid,UserName "+
            //            " from WorkTaskAccreditView where accreditstatus='1' and accreditfromuserid=@userId " +
            //              " order by flowcaption,taskcaption";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = sql;
            //sqlItem.AppendParameter("@userId", userId);
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.ExecuteDataTable(sqlItem);
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskAccreditViewListByAccreditFromUserId", userId);
            if (li.Count == 0)
            {
                DataTable dt = new DataTable();
                return dt;
            }
            return ConvertHelper.ToDataTable(li); 

        }
        /**//// <summary>
        /// 被授予的权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static DataTable GetHaveAccreditTable(string userId)
        {
            //string sql = "select distinct flowcaption,taskcaption,workflowid," +
            //            "auserid,worktaskid,accreditfromuserid,accredittouserid,fromUserName " +
            //            " from WorkTaskAccreditView where accreditstatus='1' and accredittouserid=@userId " +
            //              " order by flowcaption,taskcaption";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = sql;
            //sqlItem.AppendParameter("@userId", userId);
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.ExecuteDataTable(sqlItem);
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskAccreditViewListByAccreditToUserId", userId);
            if (li.Count == 0)
            {
                DataTable dt = new DataTable();
                return dt;
            }
            return ConvertHelper.ToDataTable(li); 


        }
        public static void MoveAccredit(string AuserId)
        {
            //string sql = "update AccreditUser set accreditstatus='0' where auserid=@auserid";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = sql;
            //sqlItem.AppendParameter("@auserid", AuserId);
            //ClientDBAgent agent = new ClientDBAgent();
            //agent.ExecuteDataTable(sqlItem);
            MainHelper.PlatformSqlMap.Update("UpdateWF_AccreditUserAccreditStatusByAUserId", AuserId); 
        }
        public void GetAccreditUserInfo(string auserid)
        {
            DataTable dt = GetAccreditUserTable(auserid);
            if (dt != null && dt.Rows.Count > 0)
            {
                AUserId = dt.Rows[0]["AUserId"].ToString();
                AccreditFromUserId = dt.Rows[0]["AccreditFromUserId"].ToString();
                AccreditToUserId = dt.Rows[0]["AccreditToUserId"].ToString();
                AcWorkflowId = dt.Rows[0]["AcWorkflowId"].ToString();
                AcWorktaskId = dt.Rows[0]["AcWorktaskId"].ToString();

            }
        }

        /**//// <summary>
        /// 根据主键删除记录
        /// </summary>
        /// <param name=AUserId></param>
        /// <returns></returns>
        public static int Delete(string aUserid)
        {
            try
            {
                //string sql = "delete from AccreditUser where AUserId=@auserid";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sql;
                //sqlItem.AppendParameter("@auserid", aUserid);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteNonQuery(sqlItem);
                WF_AccreditUser accuser = new WF_AccreditUser();
                accuser.AUserId = aUserid;
                return MainHelper.PlatformSqlMap.Delete<WF_AccreditUser>(accuser); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

