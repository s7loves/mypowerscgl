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
        /// ����ڵ�����
        /// </summary>
        public String TaskName;
        /// <summary>
        /// ����ڵ��id
        /// </summary>
        public string TaskId;
        /// <summary>
        /// ����ģ���id
        /// </summary>
        public string WorkFlowId;
        /// <summary>
        /// �ڵ�����
        /// </summary>
        public int TaskType;
        /// <summary>
        /// �жϽڵ�and/or
        /// </summary>
        public string TaskTypeAndOr="";
        /// <summary>
        /// �ڵ�����
        /// </summary>
        public int X, Y;
        /// <summary>
        /// �����߲���
        /// </summary>
        public string OperRule="";
        /// <summary>
        /// ��ע
        /// </summary>
        public string Description = "";
        /// <summary>
        /// �������Ǳ���ʱ��������
        /// </summary>
        public bool IsJumpSelf = false;
        /// <summary>
        /// ��������ڵ�����
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
        ///// ����һ������ڵ�����
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
        ///// �޸ĵ�ǰ����ڵ�����
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
        ///��������ڵ�
        /// </summary>
        public void InsertTask()
        {
            if (TaskId.Trim().Length == 0 || TaskId == null)
                throw new Exception("InsertTask��������TaskId ����Ϊ�գ�");
            try
            {
                //setInsertSql();//�趨insert���
                //setParameter();//�趨����
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
        /// �޸�����ڵ�
        /// </summary>
        public void UpdateTask()
        {
            if (TaskId.Trim().Length == 0 || TaskId == null)
                throw new Exception("UpdateTask��������TaskId ����Ϊ�գ�");
            try
            {
                //setUpdateSql();//�趨��Update���
                //setParameter();//�趨����
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
        /// ɾ��һ������ڵ�
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
        /// ɾ����������Դ�����
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
        /// ɾ������������������
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
        /// ɾ�������������������
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
        /// ɾ����������п���Ȩ��
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
        /// ɾ����������б�
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
        /// ��������б�
        /// </summary>
        /// <param name="workflowId">����Id</param>
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
        /// ������������б�
      /// </summary>
      /// <param name="workflowId">������ģ��Id</param>
      /// <param name="taskId">����ģ��Id</param>
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
        /// ������������б�
        /// </summary>
        /// <param name="workflowId">������ģ��Id</param>
        /// <param name="taskId">����ģ��Id</param>
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
        /// ��ÿ���Ȩ��
        /// </summary>
        /// <param name="workflowId">������ģ��Id</param>
        /// <param name="taskId">����ģ��Id</param>
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
        /// ��ÿ�ʼ�ڵ�
        /// </summary>
        /// <param name="workflowId">����ģ��Id</param>
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
        /// �жϽڵ��Ƿ����
        /// </summary>
        /// <returns></returns>
        public static bool ExistTask(string workTaskId)
        {
            try
            {
                bool isfind = false;
                if (workTaskId.Trim().Length == 0 || workTaskId == null)
                    throw new Exception("ExistTask��������workTaskId ����Ϊ��!");

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
        /// �����������
        /// </summary>
        /// <param name="worktaskId">����ģ��Id</param>
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
        /// ��������б�
        /// </summary>
        /// <param name="worktaskId">����ģ��Id</param>
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
        /// ���һ������ģ��������ʵ���е���������ʵ��
        /// </summary>
        /// <param name="worktaskId">����ģ��Id</param>
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
        /// �����������б�
        /// </summary>
        /// <param name="workflowId">����ģ��Id</param>
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
        /// �������ڵ�󶨵ı�
        /// </summary>
        /// <param name="workflowId">����ģ��Id</param>
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
        /// ����ڵ�󶨱�
        /// </summary>
        /// <param name="mainUserCtrlId">����id</param>
        /// <param name="userContrlsId">����ڵ�id</param>
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
        /// ��������ڵ�Ŀ���Ȩ��
        /// </summary>
        /// <param name="powerName">Ȩ����</param>
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
