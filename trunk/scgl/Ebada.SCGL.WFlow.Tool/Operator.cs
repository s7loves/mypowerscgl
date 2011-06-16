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

    public class Operator
    {
        //������ģ��Operator��� ���ʲ���
        //private SqlDataItem sqlDataItem = new SqlDataItem();
        private string[] fieldList ={ "OperatorId", "WorkFlowId", "WorkTaskId", "OperType", "OperContent",
                                      "Relation","Description","InorExclude","OperDisplay"};
        private string tableName = "Operator";
        private string keyField = "OperatorId";
        private string sqlString = "";

        //������ģ��������ֶ�
        public string OperatorId = "";
        public string WorkFlowId = "";
        public string WorkTaskId = "";
        public int OperType ;
        public string OperContent = "";
        public int Relation ;
        public string Description = "";
        public bool InorExclude ;
        public string OperDisplay = "";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operId"></param>
        /// <returns></returns>
        public static DataTable GetOperatorTable(string operId)
        {
            try
            {
                string tmpStr = " where  OperatorId='" + operId + "'";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //sqlItem.AppendParameter("@OperatorId",  operId );
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                IList li = MainHelper.PlatformSqlMap.GetList("SelectPS_OperatorList", tmpStr);
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
        //    sqlDataItem.AppendParameter("@OperatorId", this.OperatorId);
        //    sqlDataItem.AppendParameter("@WorkFlowId", this.WorkFlowId);
        //    sqlDataItem.AppendParameter("@WorkTaskId", this.WorkTaskId);
        //    sqlDataItem.AppendParameter("@OperType", this.OperType,typeof(int));
        //    sqlDataItem.AppendParameter("@OperContent", this.OperContent);
        //    sqlDataItem.AppendParameter("@Relation", this.Relation, typeof(int));
        //    sqlDataItem.AppendParameter("@Description", this.Description);
        //    sqlDataItem.AppendParameter("@InorExclude", this.InorExclude,typeof(bool));
        //    sqlDataItem.AppendParameter("@OperDisplay", this.OperDisplay);

        //}
        /// <summary>
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
        //    sqlString = sqlString + " where " + keyField + "=@" + this.keyField;
        //    sqlDataItem.CommandText = sqlString;
        //}
        /// <summary>
        ///���Ӵ�����
        /// </summary>
        public void InsertOperator()
        {
            if (OperatorId.Trim().Length == 0 || OperatorId == null)
                throw new Exception("InsertOperator��������OperatorId ����Ϊ�գ�");
            try
            {
                //setInsertSql();//�趨insert���
                //setParameter();//�趨����
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                PS_Operator op = new PS_Operator();
                op.OperatorId=this.OperatorId;
                op.WorkFlowId=this.WorkFlowId;
                op.WorkTaskId=this.WorkTaskId;
                op.OperType=this.OperType;
                op.OperContent=this.OperContent;
                op.Relation=this.Relation;
                op.Description=this.Description;
                op.InorExclude = this.InorExclude;
                op.OperDisplay = this.OperDisplay;
                MainHelper.PlatformSqlMap.Create<PS_Operator>(op); 

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        /// <summary>
        /// �޸Ĵ�����
        /// </summary>
        public void UpdateOperator()
        {
            if (OperatorId.Trim().Length == 0 || OperatorId == null)
                throw new Exception("UpdateOperator��������OperatorId ����Ϊ�գ�");
            try
            {
                //setUpdateSql();//�趨��Update���
                //setParameter();//�趨����
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                PS_Operator op = new PS_Operator();
                op.OperatorId = this.OperatorId;
                op.WorkFlowId = this.WorkFlowId;
                op.WorkTaskId = this.WorkTaskId;
                op.OperType = this.OperType;
                op.OperContent = this.OperContent;
                op.Relation = this.Relation;
                op.Description = this.Description;
                op.InorExclude = this.InorExclude;
                op.OperDisplay = this.OperDisplay;
                MainHelper.PlatformSqlMap.Update<PS_Operator>(op); 
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
        public static int DeleteOperator(string OperatorId)
        {
            try
            {
                string sqlStr = "delete Operator where OperatorId='" + OperatorId + "'";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sqlStr;
                //sqlItem.AppendParameter("@OperatorId", OperatorId);
                //ClientDBAgent agent = new ClientDBAgent();
                return MainHelper.PlatformSqlMap.DeleteByWhere<PS_Operator>(sqlStr); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// ���ģ���еĴ�����
        /// </summary>
        /// <param name="worktaskId">����ģ��Id</param>
        /// <returns></returns>
        public static string GetOperContent(string operatorId)
        {
            try
            {
                string tmpStr = " where OperatorId='" + operatorId + "'";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //sqlItem.AppendParameter("@OperatorId", operatorId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteScalar(sqlItem);
                IList<PS_Operator> li = MainHelper.PlatformSqlMap.GetList<PS_Operator>("SelectPS_OperatorList", tmpStr);
                if (li.Count >0) return li[0].OperContent ;
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// ��ô����߲���
        /// </summary>
        /// <param name="worktaskId">������Id</param>
        /// <returns></returns>
        public static string GetOperRelation(string OperatorId)
        {
            try
            {
                //string tmpStr = "select Relation from WorkTask where OperatorId=@OperatorId";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //sqlItem.AppendParameter("@OperatorId", OperatorId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteScalar(sqlItem);
                string tmpStr = " where OperatorId='" + OperatorId + "'";
                IList<PS_Operator> li = MainHelper.PlatformSqlMap.GetList<PS_Operator>("SelectPS_OperatorList", tmpStr);
                if (li.Count > 0) return li[0].Relation.ToString();
                return "";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetWorkFlowAllOperator(string workFlowid)
        {
            try
            {
                //string tmpStr = "select * from Operator where  workflowId=@workflowId";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //sqlItem.AppendParameter("@workflowId", workFlowid);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string tmpStr = " where  workflowId='" + workFlowid + "'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectPS_OperatorList", tmpStr);
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
        public static bool Exists(string operatorId)
        {
            //string tmpSql = "select * from operator where OperatorId=@operatorId";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.AppendParameter("@operatorId", operatorId);
            //sqlItem.CommandText = tmpSql;
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.RecordExists(sqlItem);

            string tmpStr = " where  OperatorId='" + operatorId + "'";
            IList li = MainHelper.PlatformSqlMap.GetList("SelectPS_OperatorList", tmpStr);
            if (li.Count > 0) return true;
            return false; 
        }
    }
}
