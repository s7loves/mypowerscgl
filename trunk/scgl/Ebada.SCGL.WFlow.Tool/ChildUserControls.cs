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
        //�ӱ��� ���ʲ���
        private SqlDataItem sqlDataItem = new SqlDataItem();
        private string[] fieldList ={ "UserControlId", "ucCaption", "ucPath", "ucDescription", "ucID" };
        private string tableName = "UserControls";
        private string keyField = "UserControlId";
        private string sqlString = "";

        //�ӱ��������ֶ�
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
		/// �½� �ӱ�
		/// </summary>
        public void InsertUserControl()
		{
            if (UserControlId.Trim().Length == 0 || UserControlId == null)
                throw new Exception("InsertUserControl��������UserControlId ����Ϊ�գ�");
            if (ucCaption.Trim().Length == 0 || ucCaption == null)
                throw new Exception("InsertUserControl��������ucCaption ����Ϊ�գ�");
			try
			{
				setInsertSql();//�趨insert���
				setParameter();//�趨����
                ClientDBAgent agent = new ClientDBAgent();
                agent.ExecuteNonQuery(sqlDataItem);
			}
            catch (Exception ex)
            {
                throw ex;
            }
		}
		/// <summary>
		/// �޸�һ���ӱ�
		/// </summary>
        public void UpdateUserControl()
		{
            if (UserControlId.Trim().Length == 0 || UserControlId == null)
                throw new Exception("UpdateUserControl��������UserControlId ����Ϊ�գ�");
            if (ucCaption.Trim().Length == 0 || ucCaption == null)
                throw new Exception("InsertUserControl��������ucCaption ����Ϊ�գ�");
			try
			{
				setUpdateSql();//�趨��Update���
				setParameter();//�趨����
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
                throw new Exception("DeleteUserControl��������userControlId ����Ϊ�գ�");
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
        /// ɾ���ӱ����������ϵ
        /// </summary>
        /// <param name="userControlId"></param>
        /// <returns></returns>
        public static int DeleteMainCtrlsOfUser(string userControlId)
        {
            if (userControlId.Trim().Length == 0 || userControlId == null)
                throw new Exception("DeleteMainCtrlsOfUser��������userControlId ����Ϊ�գ�");
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
        /// ��������ӱ�
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
        /// ���һ���ӱ�
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
        /// ����ӱ�����������
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
