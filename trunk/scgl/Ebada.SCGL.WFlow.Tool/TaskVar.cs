using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Ebada.Client.Platform;
using System.Collections;
using Ebada.Core;
using Ebada.Scgl.Model;

namespace Ebada.SCGL.WFlow.Tool
{
    public class TaskVar
    {
        //�������TaskVar��� ���ʲ���
        //private SqlDataItem sqlDataItem = new SqlDataItem();
        private string[] fieldList ={ "TaskVarId", "WorkFlowId", "WorkTaskId", "VarName", "VarType",
                                      "VarModule","DataBaseName","TableName","TableField","InitValue","AccessType"};
        private string tableName = "TaskVar";
        private string keyField = "TaskVarId";
        private string sqlString = "";

        //��������������ֶ�
        public string TaskVarId = "";
        public string WorkFlowId = "";
        public string WorkTaskId = "";
        public string VarName="";
        public string VarType = "";
        public string VarModule="";
        public string DataBaseName = "";
        public string TableName;
        public string TableField = "";
        public string InitValue = "";
        public string AccessType = "public";
        /// <summary>
        /// ��ñ�����Ϣ
        /// </summary>
        /// <param name="TaskVarId">����Id</param>
        /// <returns>���ݱ�table</returns>
        public static DataTable GetTaskVarTable(string TaskVarId)
        {
            try
            {
                string tmpStr = " where  TaskVarId='" + TaskVarId + "'";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //sqlItem.AppendParameter("@TaskVarId", TaskVarId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                IList li = MainHelper.PlatformSqlMap.GetList("SelectPS_TaskVarList", tmpStr);
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
        //    sqlDataItem.AppendParameter("@TaskVarId", this.TaskVarId);
        //    sqlDataItem.AppendParameter("@WorkFlowId", this.WorkFlowId);
        //    sqlDataItem.AppendParameter("@WorkTaskId", this.WorkTaskId);
        //    sqlDataItem.AppendParameter("@VarName", this.VarName);
        //    sqlDataItem.AppendParameter("@VarType", this.VarType);
        //    sqlDataItem.AppendParameter("@VarModule", this.VarModule);
        //    sqlDataItem.AppendParameter("@DataBaseName", this.DataBaseName);
        //    sqlDataItem.AppendParameter("@TableName", this.TableName);
        //    sqlDataItem.AppendParameter("@TableField", this.TableField);
        //    sqlDataItem.AppendParameter("@InitValue", this.InitValue);
        //    sqlDataItem.AppendParameter("@AccessType", this.AccessType);
            

        //}
        ///// <summary>
        ///// ����һ�������ߵ����
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
        ///// �޸ĵ�ǰ�����ߵ����
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
        //    sqlString = sqlString + " where " + keyField + "=@" + this.keyField ;
        //    sqlDataItem.CommandText = sqlString;
        //}
        /// <summary>
        ///���ӱ���
        /// </summary>
        public void InsertTaskVar()
        {
            if (TaskVarId.Trim().Length == 0 || TaskVarId == null)
                throw new Exception("InsertTaskVar��������TaskVarId ����Ϊ�գ�");
            try
            {
                //setInsertSql();//�趨insert���
                //setParameter();//�趨����
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                PS_TaskVar tv = new PS_TaskVar();
                tv.TaskVarId=this.TaskVarId;
                tv.WorkFlowId=this.WorkFlowId;
                tv.WorkTaskId=this.WorkTaskId;
                tv.VarName=this.VarName;
                tv.VarType=this.VarType;
                tv.VarModule=this.VarModule;
                tv.DataBaseName=this.DataBaseName;
                tv.TableName=this.TableName;
                tv.TableField=this.TableField;
                tv.InitValue=this.InitValue;
                tv.AccessType = this.AccessType;
                if(MainHelper.PlatformSqlMap.GetOneByKey <PS_TaskVar>(tv)==null)
                MainHelper.PlatformSqlMap.Create<PS_TaskVar>(tv);
                else
                    MainHelper.PlatformSqlMap.Update<PS_TaskVar>(tv);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        /// <summary>
        /// �޸Ĵ�����
        /// </summary>
        public void UpdateTaskVar()
        {
            if (TaskVarId.Trim().Length == 0 || TaskVarId == null)
                throw new Exception("UpdateTaskVar��������TaskVarId ����Ϊ�գ�");
            try
            {
                //setUpdateSql();//�趨��Update���
                //setParameter();//�趨����
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                PS_TaskVar tv = new PS_TaskVar();
                tv.TaskVarId = this.TaskVarId;
                tv.WorkFlowId = this.WorkFlowId;
                tv.WorkTaskId = this.WorkTaskId;
                tv.VarName = this.VarName;
                tv.VarType = this.VarType;
                tv.VarModule = this.VarModule;
                tv.DataBaseName = this.DataBaseName;
                tv.TableName = this.TableName;
                tv.TableField = this.TableField;
                tv.InitValue = this.InitValue;
                tv.AccessType = this.AccessType;
                MainHelper.PlatformSqlMap.Update<PS_TaskVar>(tv);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// ɾ��һ��������
        /// </summary>
        /// <param name="workflowId"></param>
        /// <param name="worktaskId"></param>
        public static int DeleteTaskVar(string TaskVarId)
        {
            try
            {
                string tmpSql = " where TaskVarId='" + TaskVarId + "'";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpSql;
                //sqlItem.AppendParameter("@TaskVarId", TaskVarId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteNonQuery(sqlItem);
                return MainHelper.PlatformSqlMap.DeleteByWhere<PS_TaskVar>(tmpSql);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// ������̱����б�
        /// </summary>
        /// <param name="workflowId">����ģ��Id</param>
        /// <returns></returns>
        public static DataTable GetWorkflowVar(string workflowId)
        {
            try
            {
                string tmpSql = " where workflowId ='" + workflowId + "' and AccessType='public'";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpSql;
                //sqlItem.AppendParameter("@workflowId", workflowId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                IList li = MainHelper.PlatformSqlMap.GetList("SelectPS_TaskVarList", tmpSql);
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
        public static DataTable GetTaskVar(string taskId)
        {
            try
            {
                string tmpSql = " where WorkTaskId ='" + taskId + "' and AccessType='private'";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpSql;
                //sqlItem.AppendParameter("@WorkTaskId", taskId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                IList li = MainHelper.PlatformSqlMap.GetList("SelectPS_TaskVarList", tmpSql);
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
        /// <param name="taskName">������</param>
        /// <returns>��������б�</returns>
        public static DataTable GetTaskVarByName(string varName)
        {
            try
            {
                string tmpSql = " where VarName ='" + varName + "'";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpSql;
                //sqlItem.AppendParameter("@VarName", varName);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                IList li = MainHelper.PlatformSqlMap.GetList("SelectPS_TaskVarList", tmpSql);
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
        /// ������̱����б�
        /// </summary>
        /// <param name="workflowId">����ģ��Id</param>
        /// <returns></returns>
        public static DataTable GetWorkflowAllVar(string workflowId)
        {
            try
            {
                string tmpSql = " where workflowId ='" + workflowId + "'";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpSql;
                //sqlItem.AppendParameter("@workflowId", workflowId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                IList li = MainHelper.PlatformSqlMap.GetList("SelectPS_TaskVarList", tmpSql);
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
        public static bool Exists(string taskVarId)
        {
            string tmpSql = " where taskVarId='" + taskVarId + "'";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.AppendParameter("@taskVarId", taskVarId);
            //sqlItem.CommandText = tmpSql;
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.RecordExists(sqlItem);
            IList li = MainHelper.PlatformSqlMap.GetList("SelectPS_TaskVarList", tmpSql);
            if (li.Count > 0) return true;
            return false; 

        }

    }

}
