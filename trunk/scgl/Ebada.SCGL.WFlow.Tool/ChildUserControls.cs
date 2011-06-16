using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HF.Framework.DataClientDBAgent;
using HF.Framework.DataContract;


namespace HF.WorkFlow.Template
{
    public class ChildUserControls
    {
        //子表单的 访问参数
        private SqlDataItem sqlDataItem = new SqlDataItem();
        private string[] fieldList ={ "UserControlId", "ucCaption", "ucPath", "ucDescription", "ucID" };
        private string tableName = "UserControls";
        private string keyField = "UserControlId";
        private string sqlString = "";

        //子表单的属性字段
        public string UserControlId = "";
        public string ucCaption = "";
        public string ucPath = "";
        public string ucDescription = "";
        public string ucID = "";

        public ChildUserControls()
        { 
        }
       
		private void setParameter()
		{
            sqlDataItem.ParameterList.Clear();
            sqlDataItem.AppendParameter("@UserControlId", UserControlId);
            sqlDataItem.AppendParameter("@ucCaption", ucCaption);
            sqlDataItem.AppendParameter("@ucPath", ucPath);
            sqlDataItem.AppendParameter("@ucDescription", ucDescription);
            sqlDataItem.AppendParameter("@ucID", ucID);

			


		}
		private void setInsertSql()
		{
			string tmpValueList="";
			string tmpFieldName="";
			sqlString="insert into "+tableName+"(";
			int tmpInt=this.fieldList.Length;
			for(int i=0;i<tmpInt-1;i++)
			{
				tmpFieldName=fieldList[i].ToString();
				sqlString=sqlString+tmpFieldName+",";
				tmpValueList=tmpValueList+"@"+tmpFieldName+",";

			}
			tmpFieldName=this.fieldList[tmpInt-1].ToString();
			sqlString=sqlString+tmpFieldName;
			tmpValueList=tmpValueList+"@"+tmpFieldName;
			this.sqlString=sqlString+")values("+tmpValueList+")";
            sqlDataItem.CommandText = sqlString;
		}
		private void setUpdateSql()
		{
			string tmpFieldName="";
			int tmpInt=this.fieldList.Length;
			sqlString="update "+tableName+" set ";
			for(int i=0;i<tmpInt-1;i++)
			{
				tmpFieldName=this.fieldList[i].ToString();
				sqlString=sqlString+tmpFieldName+"=@"+tmpFieldName+",";
				
			}
			tmpFieldName=fieldList[tmpInt-1].ToString();
			sqlString=sqlString+tmpFieldName+"=@"+tmpFieldName;
            sqlString = sqlString + " where " + keyField + "=@" + keyField;
            sqlDataItem.CommandText = sqlString;
		}

		/// <summary>
		/// 新建 子表单
		/// </summary>
        public void InsertUserControl()
		{
            if (UserControlId.Trim().Length == 0 || UserControlId == null)
                throw new Exception("InsertUserControl方法错误，UserControlId 不能为空！");
            if (ucCaption.Trim().Length == 0 || ucCaption == null)
                throw new Exception("InsertUserControl方法错误，ucCaption 不能为空！");
			try
			{
				setInsertSql();//设定insert语句
				setParameter();//设定参数
                ClientDBAgent agent = new ClientDBAgent();
                agent.ExecuteNonQuery(sqlDataItem);
			}
            catch (Exception ex)
            {
                throw ex;
            }
		}
		/// <summary>
		/// 修改一个子表单
		/// </summary>
        public void UpdateUserControl()
		{
            if (UserControlId.Trim().Length == 0 || UserControlId == null)
                throw new Exception("UpdateUserControl方法错误，UserControlId 不能为空！");
            if (ucCaption.Trim().Length == 0 || ucCaption == null)
                throw new Exception("InsertUserControl方法错误，ucCaption 不能为空！");
			try
			{
				setUpdateSql();//设定定Update语句
				setParameter();//设定参数
                ClientDBAgent agent = new ClientDBAgent();
                agent.ExecuteNonQuery(sqlDataItem);
			}
			catch(Exception ex)
			{
				throw ex;
			}

		}
        public static int DeleteUserControl(string userControlId)
        {
            if (userControlId.Trim().Length == 0 || userControlId == null)
                throw new Exception("DeleteUserControl方法错误，userControlId 不能为空！");
            try
            {
                string sqlStr = "delete from UserControls where userControlId=@userControlId";
                SqlDataItem sqlItem = new SqlDataItem();
                sqlItem.CommandText = sqlStr;
                sqlItem.AppendParameter("@userControlId", userControlId);
                ClientDBAgent agent = new ClientDBAgent();
                return  agent.ExecuteNonQuery(sqlItem);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 删除子表单隶属的组关系
        /// </summary>
        /// <param name="userControlId"></param>
        /// <returns></returns>
        public static int DeleteMainCtrlsOfUser(string userControlId)
        {
            if (userControlId.Trim().Length == 0 || userControlId == null)
                throw new Exception("DeleteMainCtrlsOfUser方法错误，userControlId 不能为空！");
            try
            {
                string sqlStr = "delete from UserControlsLink where userControlId=@userControlId";
                SqlDataItem sqlItem = new SqlDataItem();
                sqlItem.CommandText = sqlStr;
                sqlItem.AppendParameter("@userControlId", userControlId);
                ClientDBAgent agent = new ClientDBAgent();
                return agent.ExecuteNonQuery(sqlItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获得所有子表单
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllChildUserControls()
        {
            try
            {
                string tmpStr = "select * from UserControls order by ucCaption";
                SqlDataItem sqlItem = new SqlDataItem();
                sqlItem.CommandText = tmpStr;
                ClientDBAgent agent = new ClientDBAgent();
                return agent.ExecuteDataTable(sqlItem);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获得一个子表单
        /// </summary>
        /// <returns></returns>
        public static DataTable GetChildUserControl(string userControlId)
        {
            try
            {
                string tmpStr = "select * from UserControls where userControlId=@userControlId";
                SqlDataItem sqlItem = new SqlDataItem();
                sqlItem.CommandText = tmpStr;
                sqlItem.AppendParameter("@userControlId", userControlId);
                ClientDBAgent agent = new ClientDBAgent();
                return agent.ExecuteDataTable(sqlItem);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获得子表单隶属的主表单
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMainCtrlsOfChild(string userControlId)
        {
            try
            {
                string tmpStr = "select * from UserControlsView where UserControlId=@UserControlId order by mucCaption";
                SqlDataItem sqlItem = new SqlDataItem();
                sqlItem.CommandText = tmpStr;
                sqlItem.AppendParameter("@userControlId", userControlId);
                ClientDBAgent agent = new ClientDBAgent();
                return agent.ExecuteDataTable(sqlItem);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
