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
    public class WorkServiceMessage
    {
        //private SqlDataItem sqlDataItem = new SqlDataItem();
        private string[] fieldList ={ "MessageId", "WorkflowId", "WorktaskId", "WorkflowInsId", "WorktaskInsId", "Content", "SendTime1", "SendTime2", "SendTime3", "DoneFlag1", "DoneFlag2", "DoneFlag3", "MsgType", "Users1", "Users2", "Users3" };
        private string tableName = "WorkServiceMessage";
        private string keyField = "MessageId";
        private string sqlString = "";
        public string MessageId = "";
        public string WorkflowId = "";
        public string WorktaskId = "";
        public string WorkflowInsId = "";
        public string WorktaskInsId = "";
        public string Content = "";
        public string SendTime1 = "";
        public string SendTime2 = "";
        public string SendTime3 = "";
        public int DoneFlag1 = 0;
        public int DoneFlag2 = 0;
        public int DoneFlag3 = 0;
        public string MsgType = "";
        public string Users1 = "";
        public string Users2 = "";
        public string Users3 = "";

        public WorkServiceMessage()
        {
        }
        //private void setParameter()
        //{
        //    sqlDataItem.ParameterList.Clear();
        //    sqlDataItem.AppendParameter("@MessageId", MessageId);
        //    sqlDataItem.AppendParameter("@WorkflowId", WorkflowId);
        //    sqlDataItem.AppendParameter("@WorktaskId", WorktaskId);
        //    sqlDataItem.AppendParameter("@WorkflowInsId", WorkflowInsId);
        //    sqlDataItem.AppendParameter("@WorktaskInsId", WorktaskInsId);
        //    sqlDataItem.AppendParameter("@Content", Content);
        //    sqlDataItem.AppendParameter("@SendTime1", SendTime1);
        //    sqlDataItem.AppendParameter("@SendTime2", SendTime2);
        //    sqlDataItem.AppendParameter("@SendTime3", SendTime3);
        //    sqlDataItem.AppendParameter("@DoneFlag1", DoneFlag1,typeof(int));
        //    sqlDataItem.AppendParameter("@DoneFlag2", DoneFlag2, typeof(int));
        //    sqlDataItem.AppendParameter("@DoneFlag3", DoneFlag3, typeof(int));
        //    sqlDataItem.AppendParameter("@MsgType", MsgType);
        //    sqlDataItem.AppendParameter("@Users1", Users1);
        //    sqlDataItem.AppendParameter("@Users2", Users2);
        //    sqlDataItem.AppendParameter("@Users3", Users3);

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
        /// 增加WorkServiceMessage
        /// </summary>
        public void Insert()
        {
            try
            {
                //setInsertSql();//设定insert语句
                //setParameter();//设定参数
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                WF_WorkServiceMessage workSer = new WF_WorkServiceMessage();
 
                workSer.MessageId=MessageId;
                workSer.WorkflowId=WorkflowId;
                workSer.WorktaskId=WorktaskId;
                workSer.WorkflowInsId=WorkflowInsId;
                workSer.WorktaskInsId=WorktaskInsId;
                workSer.Content=Content;
                workSer.SendTime1=Convert.ToDateTime(  SendTime1);
                workSer.SendTime2=Convert.ToDateTime( SendTime2);
                workSer.SendTime3=Convert.ToDateTime( SendTime3);
                workSer.DoneFlag1=DoneFlag1;
                workSer.DoneFlag2=DoneFlag2;
                workSer.DoneFlag3=DoneFlag3;
                workSer.MsgType=MsgType;
                workSer.Users1=Users1;
                workSer.Users2=Users2;
                workSer.Users3 = Users3;
                MainHelper.PlatformSqlMap.Create<WF_WorkServiceMessage>(workSer); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// 更新WorkServiceMessage
        /// </summary>
        public void Update()
        {
            if (MessageId.Trim().Length == 0 || MessageId == null)
                throw new Exception("Update方法错误，MessageId不能为空！");
            try
            {
                //setUpdateSql();//设定Update语句
                //setParameter();//设定参数
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);

                WF_WorkServiceMessage workSer = new WF_WorkServiceMessage();

                workSer.MessageId = MessageId;
                workSer.WorkflowId = WorkflowId;
                workSer.WorktaskId = WorktaskId;
                workSer.WorkflowInsId = WorkflowInsId;
                workSer.WorktaskInsId = WorktaskInsId;
                workSer.Content = Content;
                workSer.SendTime1 = Convert.ToDateTime(SendTime1);
                workSer.SendTime2 = Convert.ToDateTime(SendTime2);
                workSer.SendTime3 = Convert.ToDateTime(SendTime3);
                workSer.DoneFlag1 = DoneFlag1;
                workSer.DoneFlag2 = DoneFlag2;
                workSer.DoneFlag3 = DoneFlag3;
                workSer.MsgType = MsgType;
                workSer.Users1 = Users1;
                workSer.Users2 = Users2;
                workSer.Users3 = Users3;
                MainHelper.PlatformSqlMap.Update <WF_WorkServiceMessage>(workSer); 
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// 获得WorkServiceMessage表
        /// </summary>
        /// <param name=MessageId></param>
        /// <returns></returns>
        public static DataTable GetWorkServiceMessageTable(string messageid)
        {
            try
            {
                //string sql = "select * from WorkServiceMessage where MessageId=@messageid";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sql;
                //sqlItem.AppendParameter("@messageid", messageid);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string sql = "where MessageId='"+messageid+"'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkServiceMessageList", messageid);
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
        public void GetWorkServiceMessageInfo(string messageid)
        {
            DataTable dt = GetWorkServiceMessageTable(messageid);
            if (dt != null && dt.Rows.Count > 0)
            {
                MessageId = dt.Rows[0]["MessageId"].ToString();
                WorkflowId = dt.Rows[0]["WorkflowId"].ToString();
                WorktaskId = dt.Rows[0]["WorktaskId"].ToString();
                WorkflowInsId = dt.Rows[0]["WorkflowInsId"].ToString();
                WorktaskInsId = dt.Rows[0]["WorktaskInsId"].ToString();
                Content = dt.Rows[0]["Content"].ToString();
                SendTime1 = dt.Rows[0]["SendTime1"].ToString();
                SendTime2 = dt.Rows[0]["SendTime2"].ToString();
                SendTime3 = dt.Rows[0]["SendTime3"].ToString();
                DoneFlag1 = Convert.ToInt16(dt.Rows[0]["DoneFlag1"].ToString());
                DoneFlag2 = Convert.ToInt16(dt.Rows[0]["DoneFlag2"].ToString());
                DoneFlag3 = Convert.ToInt16(dt.Rows[0]["DoneFlag3"].ToString());
                MsgType = dt.Rows[0]["MsgType"].ToString();
                Users1 = dt.Rows[0]["Users1"].ToString();
                Users2 = dt.Rows[0]["Users2"].ToString();
                Users3 = dt.Rows[0]["Users3"].ToString();

            }
        }
        /**//// <summary>
        /// 根据主键删除记录
        /// </summary>
        /// <param name=MessageId></param>
        /// <returns></returns>
        public static int Delete(string messageid)
        {
            try
            {
                //string sql = "delete from WorkServiceMessage where MessageId=@messageid";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sql;
                //sqlItem.AppendParameter("@messageid", messageid);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteNonQuery(sqlItem);
                WF_WorkServiceMessage workSer = new WF_WorkServiceMessage();
                workSer.MessageId = messageid;
                return MainHelper.PlatformSqlMap.Delete<WF_WorkServiceMessage>(workSer); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
