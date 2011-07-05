using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Data;
using Ebada.Client.Platform;
using Ebada.Scgl.Model;
using Ebada.Core;
namespace Ebada.SCGL.WFlow.Tool
{
   public class WorkFlowLink
    {
        public string LinkId="";
        public string WorkflowId="";
        public string StartTaskId;
        public string EndTaskId;
        public string Condition="";
        public string CommandName = "";
        public int Priority;
        /// <summary>
        /// 连接线起点
        /// </summary>
        public Point startPoint;
        /// <summary>
        /// 连接线终点
        /// </summary>
        public Point endPoint;
        /// <summary>
        /// 选定标志
        /// </summary>
        public bool selected;
        /// <summary>
        /// 锚点的x坐标，包括开始点和结束点，开始点索引号是0，结束点索引号是breakPointX.Count-1;
        /// </summary>			
        public ArrayList breakPointX;
        /// 锚点的y坐标，包括开始点和结束点，开始点索引号是0，结束点索引号是breakPointY.Count-1;
        public ArrayList breakPointY;
        /// <summary>
        /// 说明
        /// </summary>
        public string Des;
        /// <summary>
        /// 与节点属性对话框关联的dll
        /// </summary>
        public string DllFileName = "";
        public string DllClassName = "";

        private string[] fieldList ={ "WorkLinkId", "WorkFlowId", "StartTaskId", "EndTaskId", "BreakX", "BreakY", 
                                       "Description","Condition","CommandName","Priority" };
        private string tableName = "WorkLink";
        private string keyField = "WorkLinkId";
        private string sqlString = "";
        //private void setParameter()
        //{
        //    string xx = "", yy = "";
        //    for (int mm = 1; mm < this.breakPointX.Count - 1; mm++)
        //    {
        //        xx += this.breakPointX[mm] + ",";
        //        yy += this.breakPointY[mm] + ",";
        //    }
        //    if (this.breakPointX.Count > 2)
        //    {
        //        xx = xx.Substring(0, xx.Length - 1);
        //        yy = yy.Substring(0, yy.Length - 1);
        //    }
        //    sqlDataItem.ParameterList.Clear();
        //    sqlDataItem.AppendParameter("@WorkLinkId", this.LinkId);
        //    sqlDataItem.AppendParameter("@WorkFlowId", this.WorkflowId);
        //    sqlDataItem.AppendParameter("@StartTaskId", StartTaskId);
        //    sqlDataItem.AppendParameter("@EndTaskId", EndTaskId);
        //    sqlDataItem.AppendParameter("@BreakX", xx);
        //    sqlDataItem.AppendParameter("@BreakY", yy);
        //    sqlDataItem.AppendParameter("@Description", this.Des);
        //    sqlDataItem.AppendParameter("@Condition", this.Condition);
        //    if (CommandName == "") CommandName = "提交";//默认提交
        //    sqlDataItem.AppendParameter("@CommandName", this.CommandName);
        //    sqlDataItem.AppendParameter("@Priority", this.Priority,typeof(int));

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
        //    sqlString = sqlString + " where " + keyField + "=@" + this.keyField;
        //    sqlDataItem.CommandText = sqlString;
        //}
        /// <summary>
        /// 判断连线是否存在
        /// </summary>
        /// <returns></returns>
        public bool LinkExist()
        {
            return LinkExist(LinkId);

        }
        public static bool LinkExist(string linkId)
        {
            if (linkId.Trim().Length == 0 || linkId == null)
                throw new Exception("LinkExist方法错误，linkId 不能为空！");
            string tmpStr = " where WorkLinkId='" + linkId + "'";
            bool isfimd = false;
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkLinkList", tmpStr);
            if (li.Count > 0) isfimd = true;
            return isfimd;
        }
        public void InsertLink()
        {
            if (LinkId.Trim().Length == 0 || LinkId == null)
                throw new Exception("InsertLink方法错误，LinkId 不能为空！");
            if (WorkflowId.Trim().Length == 0 || WorkflowId == null)
                throw new Exception("InsertLink方法错误，WorkflowId 不能为空！");
            if (StartTaskId == null)
                throw new Exception("InsertLink方法错误，StartTask 不能为空！");
            if (EndTaskId == null)
                throw new Exception("InsertLink方法错误，EndTask 不能为空！");

            try
            {
                //setInsertSql();//设定insert语句
                //setParameter();//设定参数
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                string xx = "", yy = "";
                for (int mm = 1; mm < this.breakPointX.Count - 1; mm++)
                {
                    xx += this.breakPointX[mm] + ",";
                    yy += this.breakPointY[mm] + ",";
                }
                if (this.breakPointX.Count > 2)
                {
                    xx = xx.Substring(0, xx.Length - 1);
                    yy = yy.Substring(0, yy.Length - 1);
                }
                WF_WorkLink wl = new WF_WorkLink();
                wl.WorkLinkId=this.LinkId;
                wl.WorkFlowId=this.WorkflowId;
                wl.StartTaskId=StartTaskId;
                wl.EndTaskId=EndTaskId;
                wl.BreakX=xx;
                wl.BreakY=yy;
                wl.Description=this.Des;
                wl.Condition=this.Condition;
                //if (CommandName == "")
                {
                    string tmpStr = " where  WorkFlowId='" + WorkflowId + "' and WorkTaskId='"+StartTaskId+"'";
                    IList<WF_WorkTaskCommands> li = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskCommands>("SelectWF_WorkTaskCommandsList", tmpStr);
                    if (li.Count > 0)
                    {
                        CommandName = li[0].CommandName  ;//默认提交
                        
                    }
                    else
                    {
                        CommandName = "提交";//默认提交
                    }
                }
                wl.CommandName = this.CommandName;
                wl.Priority = this.Priority;
                MainHelper.PlatformSqlMap.Create<WF_WorkLink>(wl);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void UpdateLink()
        {
            if (LinkId.Trim().Length == 0 || LinkId == null)
                throw new Exception("UpdateLink方法错误，LinkId 不能为空！");
            if (WorkflowId.Trim().Length == 0 || WorkflowId == null)
                throw new Exception("UpdateLink方法错误，WorkflowId 不能为空！");
            if (StartTaskId == null)
                throw new Exception("UpdateLink方法错误，StartTaskId 不能为空！");
            if (EndTaskId == null)
                throw new Exception("UpdateLink方法错误，EndTaskId 不能为空！");
            try
            {
                //setUpdateSql();//设定定Update语句
                //setParameter();//设定参数
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                string xx = "", yy = "";
                for (int mm = 1; mm < this.breakPointX.Count - 1; mm++)
                {
                    xx += this.breakPointX[mm] + ",";
                    yy += this.breakPointY[mm] + ",";
                }
                if (this.breakPointX.Count > 2)
                {
                    xx = xx.Substring(0, xx.Length - 1);
                    yy = yy.Substring(0, yy.Length - 1);
                }
                WF_WorkLink wl = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkLink>(LinkId);
                if (wl == null) wl = new WF_WorkLink();
                wl.WorkLinkId = this.LinkId;
                wl.WorkFlowId = this.WorkflowId;
                wl.StartTaskId = StartTaskId;
                wl.EndTaskId = EndTaskId;
                wl.BreakX = xx;
                wl.BreakY = yy;
                wl.Description = this.Des;
                wl.Condition = this.Condition;
                //if (CommandName == "") CommandName = "提交";//默认提交
                //if (CommandName == "")
                {
                    string tmpStr = " where  WorkFlowId='" + WorkflowId + "' and WorkTaskId='" + StartTaskId + "'";
                    IList<WF_WorkTaskCommands> li = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskCommands>("SelectWF_WorkTaskCommandsList", tmpStr);
                    if (li.Count > 0)
                    {
                        CommandName = li[0].CommandName;//默认提交

                    }
                    else
                    {
                        CommandName = "提交";//默认提交
                    }
                }
                wl.CommandName = this.CommandName;
                wl.Priority = this.Priority;
                if (MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkLink>(LinkId) == null)
                    MainHelper.PlatformSqlMap.Create <WF_WorkLink>(wl);
                else
                MainHelper.PlatformSqlMap.Update <WF_WorkLink>(wl);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        // <summary>
        /// 从Worklink表中删除一条连线
        /// </summary>
        /// <param name="workflowId"></param>
        /// <param name="worktaskId"></param>
        public static int DeleteLine(string workflowId, string workLinkId)
        {
            try
            {
                string tmpSql = "where WorkFlowId='" + workflowId + "' and WorkLinkId='" + workLinkId + "'";

                return MainHelper.PlatformSqlMap.DeleteByWhere<WF_WorkLink>(tmpSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 获得连线
        /// </summary>
        /// <param name="workflowId">流程Id</param>
        /// <returns></returns>
        public static DataTable GetWorkLinks(string workflowId)
        {
            try
            {
                string tmpStr = "where WorkFlowId='" + workflowId +"'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskLinkViewList", tmpStr);
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

    }
}
