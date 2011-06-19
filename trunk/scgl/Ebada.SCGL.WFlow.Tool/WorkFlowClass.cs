using System;
using System.Data;
using Ebada.Client.Platform;
using Ebada.Scgl.Model;
using System.Collections;
using Ebada.Core;



namespace Ebada.SCGL.WFlow.Tool
{
	/// <summary>
	/// Class1 ��ժҪ˵����
	/// </summary>
	public class WorkFlowClass
	{
        /// <summary>
        /// ���̷���Id
        /// </summary>
        public string WorkflowClassId;
        /// <summary>
        /// ���̷�������
        /// </summary>
        public string WorkflowClassCaption;
        /// <summary>
        /// ���̸�����Id
        /// </summary>
        public string WorkflowFatherClassId;
        /// <summary>
        /// ���̷��������
        /// </summary>
        public string Description;

        /// <summary>
        /// ����ȼ�
        /// </summary>
        public int clLevel;
        public string MgrUrl;


        //������ģ��WorkFlowClass��� ���ʲ���
        //private SqlDataItem sqlDataItem = new SqlDataItem();
        private string[] fieldList ={ "WFClassId", "Caption", "FatherId", "Description", "clLevel","clMgrUrl" };
        private string tableName = "WorkFlowClass";
        private string keyField = "WFClassId";
        private string sqlString = "";

        public WorkFlowClass()
		{

		}
        /// <summary>
        /// ɾ�����̷���
        /// </summary>
        /// <param name="workflowClassId">���̷���Id</param>
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
        /// ������̷���������ӷ����б�
        /// </summary>
        /// <param name="FatherClassId">������Id</param>
        /// <returns>�ӷ���table</returns>
        public static DataTable GetChildWorkflowClass(string fatherClassId)
        {
            try
            {
                string tmpStr = "where  FatherId='" + fatherClassId + "'";//��Ч������Ϣ
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
        /// ������̷����µ����������б�
        /// </summary>
        /// <param name="classId">���̷���Id</param>
        /// <returns>�����б�</returns>
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
        /// ������̷�����
        /// </summary>
        /// <param name="classId">���̷���Id</param>
        /// <returns>�����б�</returns>
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
        /// �½� һ������ģ��
        /// </summary>
        public void InsertWorkflowClass()
        {
            if (WorkflowClassId.Trim().Length == 0 || WorkflowClassId == null)
                throw new Exception("InsertWorkFlowClass��������WorkflowClassId ����Ϊ�գ�");

            try
            {
                //setInsertSql();//�趨insert���
                //setParameter();//�趨����
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
        /// �޸�һ������ģ��
        /// </summary>
        public void UpdateWorkflowClass()
        {
            if (WorkflowClassId.Trim().Length == 0 || WorkflowClassId == null)
                throw new Exception("UpdateWorkflowClass��������WorkflowClassId ����Ϊ�գ�");

            try
            {
                //setUpdateSql();//�趨��Update���
                //setParameter();//�趨����
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
