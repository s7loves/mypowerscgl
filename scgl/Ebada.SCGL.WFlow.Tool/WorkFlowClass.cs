using System;
using System.Data;
using Ebada.Client.Platform;
using Ebada.Scgl.Model;
using System.Collections;
using Ebada.Core;



namespace Ebada.SCGL.WFlow.Tool
{
	/// <summary>
	/// Class1 的摘要说明。
	/// </summary>
	public class WorkFlowClass
	{
        /// <summary>
        /// 流程分类Id
        /// </summary>
        public string WorkflowClassId;
        /// <summary>
        /// 流程分类名称
        /// </summary>
        public string WorkflowClassCaption;
        /// <summary>
        /// 流程父分类Id
        /// </summary>
        public string WorkflowFatherClassId;
        /// <summary>
        /// 流程分类的描述
        /// </summary>
        public string Description;

        /// <summary>
        /// 分类等级
        /// </summary>
        public int clLevel;
        public string MgrUrl;


        //工作流模板WorkFlowClass表的 访问参数
        //private SqlDataItem sqlDataItem = new SqlDataItem();
        private string[] fieldList ={ "WFClassId", "Caption", "FatherId", "Description", "clLevel","clMgrUrl" };
        private string tableName = "WorkFlowClass";
        private string keyField = "WFClassId";
        private string sqlString = "";

        public WorkFlowClass()
		{

		}
        /// <summary>
        /// 删除流程分类
        /// </summary>
        /// <param name="workflowClassId">流程分类Id</param>
        /// <returns></returns>
        public static int DeleteWorkflowClass(string workflowClassId)
        {
            try
            {
                string tmpSql = " where WFClassId=@WFClassId";
                
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpSql;
                //sqlItem.AppendParameter("@WFClassId", workflowClassId);
                //ClientDBAgent agent = new ClientDBAgent();
                return MainHelper.PlatformSqlMap.DeleteByWhere<WF_WorkFlowClass>(tmpSql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获得流程分类的所有子分类列表
        /// </summary>
        /// <param name="FatherClassId">父分类Id</param>
        /// <returns>子分类table</returns>
        public static DataTable GetChildWorkflowClass(string fatherClassId)
        {
            try
            {
                string tmpStr = "where  FatherId='" + fatherClassId + "'";//有效的树信息
                IList li = (IList)MainHelper.PlatformSqlMap.GetList<WF_WorkFlowClass>("SelectWF_WorkFlowClassList", tmpStr);
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
        /// 获得流程分类下的所有流程列表
        /// </summary>
        /// <param name="classId">流程分类Id</param>
        /// <returns>流程列表</returns>
        public static DataTable GetWorkflowsByClassId(string classId)
        {
            try
            {
                string tmpStr = " where WFClassId='"+classId+"'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkFlowList", tmpStr);
                if (li.Count  == 0)
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
        /// 获得流程分类类
        /// </summary>
        /// <param name="classId">流程分类Id</param>
        /// <returns>流程列表</returns>
        public void  GetWorkflowClassInfo(string classId)
        {
            try
            {
                string tmpStr = " where WFClassId='" + classId + "'";
                DataTable dt = GetWorkflowsByClassId(classId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    WorkflowClassId = dt.Rows[0]["WFClassId"].ToString();
                    WorkflowClassCaption = dt.Rows[0]["Caption"].ToString();
                    WorkflowFatherClassId = dt.Rows[0]["FatherId"].ToString();
                    Description = dt.Rows[0]["Description"].ToString();
                    clLevel =Convert.ToInt16( dt.Rows[0]["clLevel"]);
                    MgrUrl = dt.Rows[0]["clMgrUrl"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //private void setParameter()
        //{
        //    sqlDataItem.ParameterList.Clear();
        //    sqlDataItem.AppendParameter("@WFClassId", WorkflowClassId);
        //    sqlDataItem.AppendParameter("@Caption", WorkflowClassCaption);
        //    sqlDataItem.AppendParameter("@FatherId", WorkflowFatherClassId);
        //    sqlDataItem.AppendParameter("@Description", Description);
        //    sqlDataItem.AppendParameter("@cllevel", clLevel,typeof(int));
        //    sqlDataItem.AppendParameter("@clMgrUrl", MgrUrl);



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
        /// 新建 一个流程模板
        /// </summary>
        public void InsertWorkflowClass()
        {
            if (WorkflowClassId.Trim().Length == 0 || WorkflowClassId == null)
                throw new Exception("InsertWorkFlowClass方法错误，WorkflowClassId 不能为空！");

            try
            {
                //setInsertSql();//设定insert语句
                //setParameter();//设定参数
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                WF_WorkFlowClass wf = new WF_WorkFlowClass();
                
                wf.WFClassId=WorkflowClassId;
                wf.Caption=WorkflowClassCaption;
                wf.FatherId= WorkflowFatherClassId;
                wf.Description=Description;
                wf.clLevel= clLevel;
                wf.clMgrUrl= MgrUrl;
                MainHelper.PlatformSqlMap.Create<WF_WorkFlowClass>(wf);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 修改一个流程模板
        /// </summary>
        public void UpdateWorkflowClass()
        {
            if (WorkflowClassId.Trim().Length == 0 || WorkflowClassId == null)
                throw new Exception("UpdateWorkflowClass方法错误，WorkflowClassId 不能为空！");

            try
            {
                //setUpdateSql();//设定定Update语句
                //setParameter();//设定参数
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                WF_WorkFlowClass wf = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkFlowClass>(WorkflowClassId);

                wf.WFClassId = WorkflowClassId;
                wf.Caption = WorkflowClassCaption;
                wf.FatherId = WorkflowFatherClassId;
                wf.Description = Description;
                wf.clLevel = clLevel;
                wf.clMgrUrl = MgrUrl;
                MainHelper.PlatformSqlMap.Update <WF_WorkFlowClass>(wf);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
		
	}
}
