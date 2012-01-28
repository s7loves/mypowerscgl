using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;
using System.Collections;
using Ebada.Core;
using Ebada.SCGL.WFlow.Tool;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Ebada.SCGL.WFlow.Engine
{
    public class WorkFlowInstance
    {
        //������ʵ��WorkFlowInstance��� ���ʲ���
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
        ///// ����һ��������ʵ�������
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
        ///// �޸ĵ�ǰ������ʵ�������
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
        /// ����������ʵ��
        /// </summary>
        public void Create()
        {
            try
            {
                //setInsertSql();//�趨insert���
                //setParameter();//�趨����
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
              //  DebugHF.WriteErrorLog("Create����ʵ��WorkflowInsCaption=" + WorkflowInsCaption + ",WorkflowInsId=" + WorkflowInsId, WorkflowInsId);
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
        ///// ������������
        ///// </summary>
        ///// <param name="userId">�û�Id</param>
        ///// <returns>�������������б�</returns>
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
        /// �������񣬰��������������������
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <param name="topsize">���صĵļ�¼����</param>
        /// <returns>���ش��������б�</returns>
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
                 sqlstr=sqlstr+"(Status='1') "; //������
                 sqlstr=sqlstr+"union  ";
                 sqlstr=sqlstr+" select "+filedstr+ " from WF_WorkTaskInsAccreditView where ";
                 sqlstr=sqlstr+" AccreditToUserId='"+userId +"' and AccreditStatus='1' and status='1'  ";//--��Ȩ���������
                 sqlstr=sqlstr+"union  ";
                 sqlstr=sqlstr+ " select "+filedstr +" from WF_WorkTaskInstanceView where UserId='"+userId+"' and (status='1' or status='2')";//--����������
                 sqlstr=sqlstr+") a ";
                 sqlstr = sqlstr + "  order by FlowCaption, status, taskStartTime desc ";
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

        /**/
        /// <summary>
        /// ָ��������
        /// </summary>
        /// <param name="WorkFlowId">����Id</param>
        /// <param name="WorkFlowInstanceId">����ʵ��Id</param>
        /// <returns>ָ����δ����������б�</returns>
        public static DataTable SelectedWorkflowTask(string WorkFlowId, string WorkFlowInstanceId, string WorkTaskInsId, int topsize)
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
                sqlstr = sqlstr + "  (WorkFlowId='" + WorkFlowId + "' and WorkFlowInsId='" + WorkFlowInstanceId + "') ";
                sqlstr = sqlstr + "union  ";
                sqlstr = sqlstr + " select " + filedstr + " from WF_WorkTaskInsAccreditView where ";
                sqlstr = sqlstr + " 1=1  ";
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
        /// <summary>
        /// ָ���ĵ�ǰ������
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <param name="WorkFlowId">����Id</param>
        /// <param name="WorkFlowInstanceId">����ʵ��Id</param>
        /// <param name="NowTaskId">�ڵ�ʵ��Id</param>
        /// <returns>ָ����δ����������б�</returns>
        public static DataTable SelectedWorkflowNowTaskExplorer(string userId, string WorkFlowId, string WorkFlowInstanceId, string NowTaskId, int topsize)
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

                string allworflowid = "";

                GetAllWorkFlowID(WorkFlowInstanceId, ref allworflowid);

                string sqlstr = "select top " + topsize + " * from (";
                sqlstr = sqlstr + "  select " + filedstr + "  from WF_WorkTaskInstanceView  WHERE ";
                sqlstr = sqlstr + " ((OperContent IN (SELECT OperContent FROM WF_OperContentView where UserId='" + userId + "') ) OR (OperContent IN (SELECT RoleID FROM rUserRole where UserId='" + userId + "') ) OR ";
                sqlstr = sqlstr + " (OperContent = 'ALL')) ";
                sqlstr = sqlstr + "  and ( (WorkFlowId='" + WorkFlowId + "' and WorkFlowInsId='" + WorkFlowInstanceId + "' and WorkTaskId='" + NowTaskId + "')  or WorkFlowInsId in (select WorkFlowInsId from  WF_WorkFlowInstance where " + allworflowid + " ))";
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
        /// <summary>
        /// ָ���ĵ�ǰ������
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <param name="WorkFlowId">����Id</param>
        /// <param name="WorkFlowInstanceId">����ʵ��Id</param>
        /// <param name="NowTaskId">�ڵ�ʵ��Id</param>
        /// <returns>ָ����δ����������б�</returns>
        public static DataTable SelectedWorkflowNowTask(string userId, string WorkFlowId, string WorkFlowInstanceId, string NowTaskId, int topsize)
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

                string allworflowid = "";
                
                GetAllWorkFlowID(WorkFlowInstanceId, ref allworflowid);
               
                string sqlstr = "select top " + topsize + " * from (";
                sqlstr = sqlstr + "  select " + filedstr + "  from WF_WorkTaskInstanceView  WHERE ";
                sqlstr = sqlstr + " ((OperContent IN (SELECT OperContent FROM WF_OperContentView where UserId='" + userId + "') ) OR (OperContent IN (SELECT RoleID FROM rUserRole where UserId='" + userId + "') ) OR ";
                sqlstr = sqlstr + " (OperContent = 'ALL')) and  (OperStatus='0') and ";
                sqlstr = sqlstr + " (Status='1' ) and ( (WorkFlowId='" + WorkFlowId + "' and WorkFlowInsId='" + WorkFlowInstanceId + "' and WorkTaskId='" + NowTaskId + "')  or WorkFlowInsId in (select WorkFlowInsId from  WF_WorkFlowInstance where " + allworflowid + " ))";
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
        public static void GetAllWorkFlowID(string workFlowInstanceId, ref string allworflowid)
        {
            IList<WF_WorkFlowInstance> wflist = MainHelper.PlatformSqlMap.GetListByWhere<WF_WorkFlowInstance>
                        (" where MainWorkflowInsId ='" + workFlowInstanceId + "'");
            if (allworflowid != "")
                allworflowid += " or MainWorkflowInsId='" + workFlowInstanceId + "'";
            else
                allworflowid = "MainWorkflowInsId='" + workFlowInstanceId + "'";

            if (wflist.Count > 0)
            {
               
                for (int i = 0; i < wflist.Count; i++)
                {
                    if (allworflowid!="")
                    allworflowid = allworflowid+ " or MainWorkflowInsId ='" + wflist[0].WorkFlowInsId + "' ";
                    else
                        allworflowid =   "  MainWorkflowInsId ='" + wflist[0].WorkFlowInsId + "' ";

                    GetAllWorkFlowID(wflist[i].WorkFlowInsId, ref  allworflowid);
                } 
            }
        }
        /// <summary>
        /// ָ����δ���������
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <param name="WorkFlowId">����Id</param>
        /// <param name="WorkFlowInstanceId">����ʵ��Id</param>
        /// <returns>ָ����δ����������б�</returns>
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
                string allworflowid = "";
                GetAllWorkFlowID(WorkFlowInstanceId, ref allworflowid);

               
                string filedstr = "Priority,WorkFlowNo,taskStartTime,TaskInsCaption,FlowInsCaption,OperContent,Status,FlowCaption," +
                         "TaskCaption,UserId,WorkFlowId,WorkTaskId,WorkFlowInsId,WorkTaskInsId,OperType,TaskTypeId,operatorInsId," +
                          "OperatedDes,OperDateTime,taskEndTime,flowStartTime,flowEndTime,pOperatedDes,Description,OperStatus,taskInsType,TaskInsDescription";


                string sqlstr = "select top " + topsize + " * from (";
                sqlstr = sqlstr + "  select " + filedstr + "  from WF_WorkTaskInstanceView  WHERE ";
                sqlstr = sqlstr + " ((OperContent IN (SELECT OperContent FROM WF_OperContentView where UserId='" + userId + "') ) OR (OperContent IN (SELECT RoleID FROM rUserRole where UserId='" + userId + "') ) OR ";
                sqlstr = sqlstr + " (OperContent = 'ALL')) and  (OperStatus='0' or OperStatus='3' ) and ";
                sqlstr = sqlstr + " (Status='1' or OperStatus='2') and ( (WorkFlowId='" + WorkFlowId + "' and WorkFlowInsId='" + WorkFlowInstanceId + "')  or WorkFlowInsId in (select WorkFlowInsId from  WF_WorkFlowInstance where " + allworflowid + "  ))";
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
        /// δ���������
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <returns>δ����������б�</returns>
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
        /// �Ҳ��������
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <returns>�Ҳ���������б�</returns>
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
        /// �������������
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <returns>��������������б�</returns>
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
        /// �������е�����ʵ���б�
        /// </summary>
        /// <param name="topsize">��ʾ����</param>
        /// <returns>�������е�����ʵ���б�</returns>
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
        /// ����ɵ�����ʵ��
        /// </summary>
        /// <param name="topsize">��ʾ����</param>
        /// <returns>����ɵ�����ʵ���б�</returns>
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
        /// ������ɵ�����
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <returns>������ɵ������</returns>
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
        /// �쳣��ֹ������
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <returns>�쳣��ֹ�������</returns>
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
        /// ���һ������ʵ��ʵ������Ϣ
        /// </summary>
        /// <param name="operatorInsId">������ʵ��Id</param>
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
        /// ������ʷ
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
        /// �趨����ʵ����������
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
        /**/
        /// <summary>
        /// �趨����ʵ���ĵ�ǰλ��
        /// </summary>
        public static void SetCurrTaskId(string workflowInsId, string nowtaskId)
        {
            SetCurrTaskId(workflowInsId, nowtaskId, "");
        }
        /**//// <summary>
        /// �趨����ʵ���ĵ�ǰλ��
        /// </summary>
        public static void SetCurrTaskId(string workflowInsId, string nowtaskId, string pretaskId)
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
                if (pretaskId == "")
                {
                    
                    MainHelper.PlatformSqlMap.Update("UpdateWF_WorkFlowInstanceValue", strsql);
                }
                else
                {
                    strsql = " where workflowInsid='" + workflowInsId + "' ";
                    WF_WorkFlowInstance wf=MainHelper.PlatformSqlMap.GetOne<WF_WorkFlowInstance>(strsql);
                    if (wf != null)
                    {
                        string nowtaskidtemp=wf.NowTaskId.Replace(pretaskId,"");
                        if (nowtaskidtemp == "")
                        {
                            nowtaskidtemp = nowtaskId;
                        }
                        else
                        {

                            nowtaskidtemp = wf.NowTaskId + "|" + nowtaskId;
                        }
                        wf.NowTaskId = nowtaskidtemp;
                        MainHelper.PlatformSqlMap.Update<WF_WorkFlowInstance>(wf);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// �趨����ʵ������
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
        /// �趨����ʵ��ȡ������
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
        /// �趨����ʵ���쳣��ֹ
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
        /// <summary>
        /// ��������ʵ����Bitmap
        /// </summary>
        /// <param name="workFlowId">����ID</param>
        /// <param name="workFlowInsId">����ʵ��ID</param>
        /// <param name="sz">ͼƬ����</param>
        /// <returns></returns>

        public static Bitmap WorkFlowBitmap(string workFlowId, string workFlowInsId, Size sz)
        {
            Bitmap objBitmap = new Bitmap(sz.Width , sz.Height );
            Graphics objGraphics = Graphics.FromImage(objBitmap);
            int Stringx = 400;
            int yspan = 0,ystrt=0;
            object obj=MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskList", " where workFlowId='" + workFlowId + "' and iYPosition in (select min(iYPosition) from WF_WorkTask where workFlowId='" + workFlowId + "')") ;
            if (obj != null)
            {
                ystrt = ((WF_WorkTask)obj).iYPosition;
            }
            obj = MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskList", " where workFlowId='" + workFlowId + "' and iYPosition in (select max(iYPosition) from WF_WorkTask where workFlowId='" + workFlowId + "')");
            if (obj != null)
            {
                yspan = ((WF_WorkTask)obj).iYPosition - ystrt;
            }
            obj = MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkFlowList", " where workFlowId='" + workFlowId + "'" );
            string displayName = ((WF_WorkFlow)obj).FlowCaption;
            System.Drawing.Font font = new System.Drawing.Font("����_GB2312", 14, FontStyle.Regular);
            StringFormat alignVertically = new StringFormat();
            SizeF sizeF = objGraphics.MeasureString(displayName, font);
            //InitTaskMapData(workFlowId, workFlowInsId, objGraphics, sz.Height/2 - yspan - ystrt );
            //InitLinkMapData(workFlowId, workFlowInsId, objGraphics, sz.Height/2 - yspan - ystrt );
            InitTaskMapData(workFlowId, workFlowInsId, objGraphics, sz.Height * 3/5 - yspan - ystrt );
            InitLinkMapData(workFlowId, workFlowInsId, objGraphics, sz.Height*3/5 - yspan - ystrt );
            Stringx =400 ;
            objGraphics.DrawString(displayName, font, Brushes.Black, sz.Width / 2, sz.Height * 1 / 4 , alignVertically);
            //objBitmap.Save(workFlowInsId + ".jpg", ImageFormat.Jpeg);

           
            return objBitmap;
        }
        /// <summary>
        /// ��ʼ������ڵ�ͼƬ��Ϣ
        /// </summary>
        /// <param name="workflowId">����ģ��ID</param>
        /// <param name="workflowInsId">ʵ������ģ��ID</param>
        /// <param name="gc"></param>
        /// <param name="yspan">ͼ��ƫ������ʹͼ���ڴ�ֱ�������</param>
        private static void InitTaskMapData(string workflowId, string workflowInsId, Graphics gc,int yspan)
        {
            DataTable tasktable = WorkFlowTask.GetWorkTasks(workflowId);
            string taskCaption = "";
            int taskX;
            int taskY;
            string operType = "";
            string taskId = "";
            string currTaskId = "";
            string taskDes = "";
            bool isPass;//�Ƿ�ͨ��
            bool isCurrent = false;//�Ƿ��ǵ�ǰ�ڵ�
            DataTable dtCurr = WorkFlowInstance.GetWorkflowInstance(workflowInsId);
            if (dtCurr.Rows.Count > 0)
            {
                currTaskId = dtCurr.Rows[0]["NowTaskId"].ToString();//����ʵ����ǰ�ڵ�
                //WF_WorkTask wt = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkTask>(currTaskId);
                //if (wt.TaskTypeId == "6")
                //{

                //    WF_WorkFlowInstance wf = (WF_WorkFlowInstance)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkFlowInstanceList", " where MainWorkflowInsId='" + workflowInsId + "' and MainWorktaskId='" + currTaskId + "'");
                //    if (wf != null)
                //    {
                //        currTaskId = wf.NowTaskId;
                    
                //    }
                //}
 
                gc.Clear(System.Drawing.Color.FromArgb(255, 253, 244));   // �ı䱳����ɫ
                foreach (DataRow dr in tasktable.Rows)
                {
                    taskId = dr["WorkTaskId"].ToString();
                    taskCaption = dr["TaskCaption"].ToString();
                    taskX = Convert.ToInt16(dr["iXPosition"]);
                    taskY = Convert.ToInt16(dr["iYPosition"]) - 10;
                    operType = dr["TaskTypeId"].ToString();
                    isPass = WorkFlowHelper.isPassJudge(workflowId, workflowInsId, taskId, WorkConst.Command_And);
                    if (currTaskId == taskId) isCurrent = true; else isCurrent = false;
                    taskDes = WorkTaskInstance.GetTaskDoneWhoMsg(taskId, workflowInsId);
                    drawTaskBitmap(gc, taskCaption, operType, taskX, taskY+yspan, isPass, isCurrent, taskDes);

                }
            }

        }
        /// <summary>
        ///  ��ʼ�����ߵ�ͼƬ��Ϣ
        /// </summary>
        /// <param name="workflowId">����ģ��ID</param>
        /// <param name="workflowInsId">ʵ������ģ��ID</param>
        /// <param name="gc"></param>
        /// <param name="yspan">ͼ��ƫ������ʹͼ���ڴ�ֱ�������</param>
        private static void InitLinkMapData(string workflowId, string workflowInsId, Graphics gc, int yspan)
        {
            DataTable linktable = WorkFlowLink.GetWorkLinks(workflowId);
            string linkDes = "";
            string startTaskId = "";
            string endTaskId = "";
            string linkBreakX;
            string linkBreakY;
            int starttaskX;
            int starttaskY;
            int endtaskX;
            int endtaskY;
            bool started;
            bool ended;
            bool fromStart;
            bool isPass;//�Ƿ�ͨ��
            Color linkColor;

            foreach (DataRow dr in linktable.Rows)
            {
                linkBreakX = dr["BreakX"].ToString();
                linkBreakY = dr["BreakY"].ToString();
                startTaskId = dr["startTaskId"].ToString();//�������ڵ㣬�ɴ����ж��ߵ���ɫ��
                endTaskId = dr["EndTaskId"].ToString();//ĩ������ڵ㣬�ɴ����ж��ߵ���ɫ��
                starttaskX = Convert.ToInt16(dr["starttaskX"]);
                starttaskY = Convert.ToInt16(dr["starttaskY"]);
                endtaskX = Convert.ToInt16(dr["endtaskX"]);
                endtaskY = Convert.ToInt16(dr["endtaskY"]);
                linkDes = dr["Description"].ToString() ;
                if (MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskPowerList", " where WorkTaskId='" + endTaskId + "'  and PowerName='�˻�'") != null)
                    linkDes = dr["Description"].ToString() + "/�˻�";
                started = WorkFlowHelper.isPassJudge(workflowId, workflowInsId, startTaskId, WorkConst.Command_And);
                ended = WorkFlowHelper.isPassJudge(workflowId, workflowInsId, endTaskId, WorkConst.Command_And);
                fromStart = isFromStartTask(workflowId, workflowInsId, startTaskId, endTaskId);
                isPass = (started && ended && fromStart);
                if (isPass) linkColor = Color.Red; else linkColor = Color.Green;

                drawLinkBitMap(gc, linkBreakX, linkBreakY, starttaskX, starttaskY + yspan, endtaskX, endtaskY+ yspan, linkColor, linkDes);
            }

        }
        private static void drawTaskBitmap(Graphics gc, string taskCaption, string operType, int x, int y, bool isPass, bool isCurrent, string taskDes)
        {
            Rectangle bounds;
            Bitmap taskBitmap = null;
            Font font;
            StringFormat alignVertically;
            Point pt = new Point(0, 0);
            Brush bcolor;
            int Captionx;
            string noPassflag = "��";//��ʾ��ɫͼƬ
            pt.X = x;
            pt.Y = y;
            font = new Font("Arial", 8);
            alignVertically = new StringFormat();
            alignVertically.LineAlignment = StringAlignment.Center;//ָ���ı��ڲ��־����о��ж���
            if (isPass) noPassflag = ""; else noPassflag = "��";
            switch (operType)
            {
                case "1"://�����ڵ�
                    taskBitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.�����ڵ�.ico")));
                    break;
                case "2"://��ֹ�ڵ� 
                    taskBitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.��ֹ�ڵ�.ico")));
                    break;
                case "3"://�����ڵ� 

                    taskBitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.�����ڵ�.ico")));
                    break;
                case "4"://���ƽڵ� 
                    taskBitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.���ƽڵ�.ico")));
                    break;
                case "5"://�鿴�ڵ� 
                    taskBitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.�鿴�ڵ�.ico")));
                    break;
                case "6"://�����̽ڵ� 
                    taskBitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.�����̽ڵ�.ico")));
                    break;
                case "7"://���нڵ� 
                    taskBitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.���нڵ�.ico")));
                    break;
                   
            }
            if (isCurrent)
            {
                bcolor = Brushes.Red;
                taskCaption = "��ǰ�ڵ�:" + taskCaption;
            }
            else bcolor = Brushes.Black;//��ǰ�ڵ�
            bounds = new Rectangle(pt, taskBitmap.Size);
            gc.DrawImage(taskBitmap, bounds.Left, bounds.Top);

            SizeF sizeF = gc.MeasureString(taskCaption, font);
            Captionx = bounds.Left - ((int)sizeF.Width) / 2 + bounds.Width / 2;
            gc.DrawString(taskCaption, font, bcolor, Captionx, bounds.Top + bounds.Height + 20, alignVertically);
            bcolor = Brushes.RoyalBlue;
            gc.DrawString(taskDes, font, bcolor, Captionx, bounds.Top + bounds.Height + 35, alignVertically);
        }
        private static bool isFromStartTask(string workflowId, string workflowInsId, string startTaskId, string endTaskId)
        {

            DataTable dt1 = WorkFlowTask.GetTaskInstance(workflowId, workflowInsId, endTaskId);
            //if (dt1 != null && dt1.Rows.Count > 0)
            foreach (DataRow dr in dt1.Rows )
            {
                string ptaskInsId = dr["PreviousTaskId"].ToString();//���ݺ�˽ڵ�ģ���ҵ�ǰһ����ʵ��
                DataTable dt2 = WorkTaskInstance.GetTaskInsTable(ptaskInsId);//����ǰһ����ʵ���ҵ�����ģ��
                //if (dt2 != null && dt2.Rows.Count > 0)

                foreach (DataRow dr2 in dt2.Rows)
                {
                    string staskid = dr2["WorktaskId"].ToString();
                    if (staskid == startTaskId)
                        return true;
                }
                //return false;
            }
            return false;
        }
        private static void drawLinkBitMap(Graphics gs, string linkBreakX, string linkBreakY,
                              int starttaskX, int starttaskY, int endtaskX, int endtaskY, Color clr, string linkDes)
        {
            ArrayList breakPointX = new ArrayList();
            ArrayList breakPointY = new ArrayList();

            string[] BreakX;
            string[] BreakY;
            breakPointX.Add(starttaskX + 20);
            breakPointY.Add(starttaskY + 10);

            if (linkBreakX.ToString() != "")
            {
                if (linkBreakX.IndexOf(",") != -1)
                {
                    BreakX = linkBreakX.Split(",".ToCharArray());
                    BreakY = linkBreakY.Split(",".ToCharArray());
                    for (int i = 0; i < BreakX.Length; i++)
                    {
                        breakPointX.Add(BreakX[i]);
                        breakPointY.Add(BreakY[i]);
                    }
                }
                else
                {
                    breakPointX.Add(linkBreakX);
                    breakPointY.Add(linkBreakY);
                }
            }
            breakPointX.Add(endtaskX);
            breakPointY.Add(endtaskY);
            if (breakPointX.Count < 2)
            {
                for (int i = 0; i < breakPointX.Count; i++)
                {
                    if (Convert.ToInt16(breakPointX[i]) < Convert.ToInt16(breakPointX[i + 1]))
                    {
                        if (Convert.ToInt16(breakPointY[i]) > Convert.ToInt16(breakPointY[i + 1]))
                        {
                            breakPointX[i] = Convert.ToInt16(breakPointX[i]);
                            breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]) + 10;
                        }
                        else
                        {

                            breakPointX[i] = Convert.ToInt16(breakPointX[i]);
                            breakPointY[i] = Convert.ToInt16(breakPointY[i]) + 10;
                        }

                    }
                    else
                    {
                        if (Convert.ToInt16(breakPointY[i]) > Convert.ToInt16(breakPointY[i + 1]))
                        {
                            breakPointX[i] = Convert.ToInt16(breakPointX[i]) - 10;
                            breakPointX[i + 1] = Convert.ToInt16(breakPointX[i + 1]) + 10;
                            breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]) + 10;
                        }
                        else
                        {
                            breakPointX[i] = Convert.ToInt16(breakPointX[i]) - 20;
                            breakPointY[i] = Convert.ToInt16(breakPointY[i]);
                            breakPointX[i + 1] = Convert.ToInt16(breakPointX[i + 1]) + 20;
                            //breakPointY[i+1]=Convert.ToInt16(breakPointY[i+1])+10;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < breakPointX.Count; i++)
                {
                    if (i == 0)
                    {
                        if (Convert.ToInt16(breakPointX[i]) < Convert.ToInt16(breakPointX[i + 1]))
                        {
                            if (Convert.ToInt16(breakPointY[i]) > Convert.ToInt16(breakPointY[i + 1]))
                            {
                                breakPointX[i] = Convert.ToInt16(breakPointX[i]);
                            }
                            else
                            {
                                if (Convert.ToInt16(breakPointY[i]) < Convert.ToInt16(breakPointY[i + 1]))
                                {
                                    breakPointX[i] = Convert.ToInt16(breakPointX[i]);
                                }
                                else
                                {
                                    breakPointX[i] = Convert.ToInt16(breakPointX[i]) + 20;//20
                                }
                            }

                        }
                        else
                        {
                            if (Convert.ToInt16(breakPointY[i]) > Convert.ToInt16(breakPointY[i + 1]))
                            {
                                breakPointX[i] = Convert.ToInt16(breakPointX[i]);
                            }
                            else
                            {
                                if (Convert.ToInt16(breakPointY[i]) < Convert.ToInt16(breakPointY[i + 1]))
                                {
                                    breakPointX[i] = Convert.ToInt16(breakPointX[i]) - 20;

                                    breakPointY[i] = Convert.ToInt16(breakPointY[i]);//20
                                }
                                else
                                {
                                    breakPointY[i] = Convert.ToInt16(breakPointY[i]);
                                }
                            }
                        }
                    }
                    if (i == breakPointX.Count - 2)
                    {
                        if (Convert.ToInt16(breakPointX[i]) < Convert.ToInt16(breakPointX[i + 1]))
                        {
                            if (Convert.ToInt16(breakPointY[i]) > Convert.ToInt16(breakPointY[i + 1]))
                            {
                                breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]);
                            }
                            else
                            {
                                if (Convert.ToInt16(breakPointY[i]) < Convert.ToInt16(breakPointY[i + 1]))
                                {
                                    breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]);
                                }
                                else
                                {
                                    breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]);
                                }
                            }

                        }
                        else
                        {
                            if (Convert.ToInt16(breakPointY[i]) > Convert.ToInt16(breakPointY[i + 1]))
                            {
                                breakPointX[i + 1] = Convert.ToInt16(breakPointX[i + 1]);
                                breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]);
                            }
                            else
                            {
                                if (Convert.ToInt16(breakPointY[i]) < Convert.ToInt16(breakPointY[i + 1]))
                                {
                                    breakPointX[i + 1] = Convert.ToInt16(breakPointX[i + 1]);
                                }
                                else
                                {
                                    breakPointX[i + 1] = Convert.ToInt16(breakPointX[i + 1]);//20
                                    breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]);
                                }
                            }
                        }
                    }
                }
            }
            Pen pen = new Pen(clr, 1);

            for (int i = 0; i < breakPointX.Count - 2; i++)
            {
                Point bp = new Point(Convert.ToInt16(breakPointX[i]), Convert.ToInt16(breakPointY[i]));
                Point bp2 = new Point(Convert.ToInt16(breakPointX[i + 1]), Convert.ToInt16(breakPointY[i + 1]));
                gs.DrawLine(pen, bp, bp2);
            }
            //�����һ������ͷ��  
            if (breakPointX.Count >= 2)
            {

                int ittX = Convert.ToInt16(breakPointX[breakPointX.Count - 2]);
                int ittY = Convert.ToInt16(breakPointY[breakPointX.Count - 2]);
                int itt2X = Convert.ToInt16(breakPointX[breakPointX.Count - 1]);
                int itt2Y = Convert.ToInt16(breakPointY[breakPointX.Count - 1]);
                Point tt = new Point(ittX, ittY);
                Point tt2 = new Point(itt2X, itt2Y);
                AdjustableArrowCap Arrow = new AdjustableArrowCap(3, 3);
                pen.CustomEndCap = Arrow;
                if (linkDes.IndexOf("�˻�")>-1)
                    pen.CustomStartCap  = Arrow;
                gs.DrawLine(pen, tt, tt2);
                //			}

                //��ע��	
                if (linkDes == "")
                    return;
                Font font = new Font("Arial", 8);
                StringFormat alignVertically = new StringFormat();
                alignVertically.LineAlignment = StringAlignment.Center;//ָ���ı��ڲ��־����о��ж���
                SizeF sizeF = gs.MeasureString(linkDes, font);
                int x = (Convert.ToInt16(breakPointX[0]) + Convert.ToInt16(breakPointX[1]) - (int)sizeF.Width) / 2;
                int y = (Convert.ToInt16(breakPointY[0]) + Convert.ToInt16(breakPointY[1])) / 2;
                gs.DrawString(linkDes, font, Brushes.Blue, x, y, alignVertically);
            }

        }
        /**//// <summary>
        /// ���������ˮ��
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
        /// δ��������ĸ���
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
    //���ܣ���������
    //˵�������������������������
    //���������
    //@UserId ��ǰ�û��Ĺ���
    //��������ݼ�
    //���ߣ�������
    //�������ڣ�2008-03-31
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
        /// �������������
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
        /// �Ҳ�����������
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
        /// ����ɵ��������
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
