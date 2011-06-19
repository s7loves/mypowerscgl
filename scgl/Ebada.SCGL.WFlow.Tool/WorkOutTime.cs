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
    public class WorkOutTime
    {
        //private SqlDataItem sqlDataItem = new SqlDataItem();
        private string[] fieldList ={ "Guid", "WorkFlowId", "WorkTaskId", "Name", "Days", "Hours", "Minutes", "Days1", "Hours1", "Minutes1", "Days2", "Hours2", "Minutes2", "Done" };
        private string tableName = "WorkOutTime";
        private string keyField = "WorkTaskId";
        private string sqlString = "";
        public string Guid = "";
        public string WorkFlowId = "";
        public string WorkTaskId = "";
        public string Name = "";
        public int Days = 0;
        public int Hours = 0;
        public int Minutes = 0;
        public int Days1 = 0;
        public int Hours1 = 0;
        public int Minutes1 = 0;
        public int Days2 = 0;
        public int Hours2 = 0;
        public int Minutes2 = 0;
        public string Done = "";

        public WorkOutTime()
        {
        }
        //private void setParameter()
        //{
        //    sqlDataItem.ParameterList.Clear();
        //    sqlDataItem.AppendParameter("@Guid", Guid);
        //    sqlDataItem.AppendParameter("@WorkFlowId", WorkFlowId);
        //    sqlDataItem.AppendParameter("@WorkTaskId", WorkTaskId);
        //    sqlDataItem.AppendParameter("@Name", Name);
        //    sqlDataItem.AppendParameter("@Days", Days,typeof(int));
        //    sqlDataItem.AppendParameter("@Hours", Hours, typeof(int));
        //    sqlDataItem.AppendParameter("@Minutes", Minutes, typeof(int));
        //    sqlDataItem.AppendParameter("@Days1", Days1, typeof(int));
        //    sqlDataItem.AppendParameter("@Hours1", Hours1, typeof(int));
        //    sqlDataItem.AppendParameter("@Minutes1", Minutes1, typeof(int));
        //    sqlDataItem.AppendParameter("@Days2", Days2, typeof(int));
        //    sqlDataItem.AppendParameter("@Hours2", Hours2, typeof(int));
        //    sqlDataItem.AppendParameter("@Minutes2", Minutes2, typeof(int));
        //    sqlDataItem.AppendParameter("@Done", Done);

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
        /// <summary>
        /// 增加WorkOutTime
        /// </summary>
        public void Insert()
        {
            try
            {
                //setInsertSql();//设定insert语句
                //setParameter();//设定参数
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                WF_WorkOutTime wfOut = new WF_WorkOutTime();
                wfOut.Guid=Guid;
                wfOut.WorkFlowId=WorkFlowId;
                wfOut.WorkTaskId=WorkTaskId;
                wfOut.Name=Name;
                wfOut.Days=Days;
                wfOut.Hours=Hours;
                wfOut.Minutes=Minutes;
                wfOut.Days1=Days1;
                wfOut.Hours1=Hours1;
                wfOut.Minutes1=Minutes1;
                wfOut.Days2=Days2;
                wfOut.Hours2=Hours2;
                wfOut.Minutes2=Minutes2 ;
                wfOut.Done=Done;
                MainHelper.PlatformSqlMap.Create<WF_WorkOutTime>(wfOut);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 更新WorkOutTime
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

                WF_WorkOutTime wfOut = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkOutTime>(Guid);
                wfOut.Guid = Guid;
                wfOut.WorkFlowId = WorkFlowId;
                wfOut.WorkTaskId = WorkTaskId;
                wfOut.Name = Name;
                wfOut.Days = Days;
                wfOut.Hours = Hours;
                wfOut.Minutes = Minutes;
                wfOut.Days1 = Days1;
                wfOut.Hours1 = Hours1;
                wfOut.Minutes1 = Minutes1;
                wfOut.Days2 = Days2;
                wfOut.Hours2 = Hours2;
                wfOut.Minutes2 = Minutes2;
                wfOut.Done = Done;
                MainHelper.PlatformSqlMap.Update<WF_WorkOutTime>(wfOut);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获得WorkOutTime表
        /// </summary>
        /// <param name=WorkTaskId></param>
        /// <returns></returns>
        public static DataTable GetWorkOutTimeTable(string workTaskId)
        {
            try
            {
                string sqlStr = " where WorkTaskId='"+workTaskId+"'";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sqlStr;
                //sqlItem.AppendParameter("@workTaskId", workTaskId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                IList li = (IList)MainHelper.PlatformSqlMap.GetList("SelectWF_WorkOutTimeList", sqlStr);
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
        public static DataTable GetWorkFlowAllOutTimeTable(string workFlowId)
        {
            try
            {
                string sqlStr = "where workFlowId='" + workFlowId + "'";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sqlStr;
                //sqlItem.AppendParameter("@workFlowId", workFlowId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                IList li = (IList)MainHelper.PlatformSqlMap.GetList("SelectWF_WorkOutTimeList", sqlStr);
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
        public void GetWorkOutTimeInfo(string worktaskid)
        {
            DataTable dt = GetWorkOutTimeTable(worktaskid);
            if (dt != null && dt.Rows.Count > 0)
            {
                Guid = dt.Rows[0]["Guid"].ToString();
                WorkFlowId = dt.Rows[0]["WorkFlowId"].ToString();
                WorkTaskId = dt.Rows[0]["WorkTaskId"].ToString();
                Name = dt.Rows[0]["Name"].ToString();
                Days = Convert.ToInt16(dt.Rows[0]["Days"].ToString());
                Hours = Convert.ToInt16(dt.Rows[0]["Hours"].ToString());
                Minutes = Convert.ToInt16(dt.Rows[0]["Minutes"].ToString());
                Days1 = Convert.ToInt16(dt.Rows[0]["Days1"].ToString());
                Hours1 = Convert.ToInt16(dt.Rows[0]["Hours1"].ToString());
                Minutes1 = Convert.ToInt16(dt.Rows[0]["Minutes1"].ToString());
                Days2 = Convert.ToInt16(dt.Rows[0]["Days2"].ToString());
                Hours2 = Convert.ToInt16(dt.Rows[0]["Hours2"].ToString());
                Minutes2 = Convert.ToInt16(dt.Rows[0]["Minutes2"].ToString());
                Done = dt.Rows[0]["Done"].ToString();

            }
        }
        /// <summary>
        /// 根据主键删除记录
        /// </summary>
        /// <param name=WorkTaskId></param>
        /// <returns></returns>
        public static int Delete(string workTaskId)
        {
            try
            {
                string sqlStr = " where WorkTaskId='" + workTaskId + "'";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sqlStr;
                //sqlItem.AppendParameter("@workTaskId", workTaskId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteNonQuery(sqlItem);
                return MainHelper.PlatformSqlMap.DeleteByWhere<WF_WorkOutTime>(sqlStr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
