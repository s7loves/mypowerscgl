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
    public class MainUserControl
    {
         /// <summary>
        /// ����Id
        /// </summary>
        public string MainUserCtrlId;
        /// <summary>
        /// ��������
        /// </summary>
        public string mucCaption;

        /// <summary>
        /// ��������
        /// </summary>
        public string mucDescription;


        //����MainUserControl ���ʲ���
        //private SqlDataItem sqlDataItem = new SqlDataItem();
        private string[] fieldList ={ "MainUserCtrlId", "mucCaption", "mucDescription" };
        private string tableName = "MainUserControl";
        private string keyField = "MainUserCtrlId";
        private string sqlString = "";
        public MainUserControl()
		{

		}
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="workflowClassId">����Id</param>
        /// <returns></returns>
        public static int DeleteMainUserCtrl(string mainUserCtrlId)
        {
            try
            {
                //string sqlStr = "delete MainUserControl where MainUserCtrlId=@mainUserCtrlId";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sqlStr;
                //sqlItem.AppendParameter("@mainUserCtrlId", mainUserCtrlId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return  agent.ExecuteNonQuery(sqlItem);
                string tmpStr = " where  MainUserCtrlId='" + mainUserCtrlId + "'";
                return MainHelper.PlatformSqlMap.DeleteByWhere<WF_MainUserControl>(tmpStr); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// ��������������ӱ��б�
        /// </summary>
        /// <param name="FatherClassId">����Id</param>
        /// <returns>�ӱ�table</returns>
        public static DataTable GetAllChildUserControls(string mainUserCtrlId)
        {
            try
            {
                //string tmpStr = "select * from UserControlsView where  MainUserCtrlId=@mainUserCtrlId order by CtrlOrderNbr";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //sqlItem.AppendParameter("@mainUserCtrlId", mainUserCtrlId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string tmpStr = " where  MainUserCtrlId='" + mainUserCtrlId + "' order by CtrlOrderNbr";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_UserControlsViewList", tmpStr);
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
        /// �����������
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllMainUserControls()
        {
            try
            {
                //string tmpStr = "select * from MainUserControl order by mucCaption";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string tmpStr = "  order by mucCaption";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_UserControlsViewList", tmpStr);
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
        //    sqlDataItem.AppendParameter("@MainUserCtrlId", MainUserCtrlId);
        //    sqlDataItem.AppendParameter("@mucCaption", mucCaption);
        //    sqlDataItem.AppendParameter("@mucDescription", mucDescription);




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
        /// �½� ����
        /// </summary>
        public void InsertMainUserCtrl()
        {
            if (MainUserCtrlId.Trim().Length == 0 || MainUserCtrlId == null)
                throw new Exception("InsertWorkFlowClass��������MainUserCtrlId ����Ϊ�գ�");

            try
            {
                //setInsertSql();//�趨insert���
                //setParameter();//�趨����
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                WF_MainUserControl muc = new WF_MainUserControl();
                muc.MainUserCtrlId= MainUserCtrlId;
                muc.mucCaption= mucCaption;
                muc.mucDescription = mucDescription;
                MainHelper.PlatformSqlMap.Create<WF_MainUserControl>(muc); 

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateMainUserCtrl()
        {
            if (MainUserCtrlId.Trim().Length == 0 || MainUserCtrlId == null)
                throw new Exception("UpdateMainUserCtrl��������MainUserCtrlId ����Ϊ�գ�");

            try
            {
                //setUpdateSql();//�趨��Update���
                //setParameter();//�趨����
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlDataItem);
                WF_MainUserControl muc = MainHelper.PlatformSqlMap.GetOneByKey<WF_MainUserControl>(MainUserCtrlId);
                muc.MainUserCtrlId = MainUserCtrlId;
                muc.mucCaption = mucCaption;
                muc.mucDescription = mucDescription;
                MainHelper.PlatformSqlMap.Update<WF_MainUserControl>(muc); 
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// ���һ������
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMainUserControl(string mainUserControlId)
        {
            try
            {
                //string tmpStr = "select * from MainUserControl where MainUserCtrlId=@mainUserControlId";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //sqlItem.AppendParameter("@mainUserControlId", mainUserControlId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string tmpStr = " where   MainUserCtrlId='" + mainUserControlId + "'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_MainUserControlList", tmpStr);
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
        /// ���һ������
        /// </summary>
        /// <param name="mainUserCtrlCaption">����</param>
        /// <returns></returns>
        public static DataTable GetMainUserControlByCaption(string mainUserCtrlCaption)
        {
            try
            {
                //string tmpStr = "select * from MainUserControl where mucCaption like @mucCaption";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //sqlItem.AppendParameter("@mucCaption", "%" + mainUserCtrlCaption + "%");
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);

                string tmpStr = "";
                if (mainUserCtrlCaption!="")
                    tmpStr = " where ( ParentID not in (select LPID from LP_Temple where 1=1 and  CtrlSize!='Ŀ¼') and  CtrlSize!='Ŀ¼' ) and  CellName like '%" + mainUserCtrlCaption + "%' order by CellName";
                else
                    tmpStr = " where ( ParentID not in (select LPID from LP_Temple where 1=1 and  CtrlSize!='Ŀ¼') and  CtrlSize!='Ŀ¼' ) order by cellname";

                IList li = MainHelper.PlatformSqlMap.GetList("SelectLP_TempleList", tmpStr);
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
        /// �����ӱ�
        /// </summary>
        /// <param name="mainUserCtrlId">����id</param>
        /// <param name="userContrlsId">�ӱ�id</param>
        /// <param name="ctrlOrderNbr">˳���,�Դ�����</param>
        public static void AddUserControls(string mainUserCtrlId, string userContrlsId, int ctrlOrderNbr,string ctrlState)
        {
            try
            {
                //string tmpSql = "insert UserControlsLink(MainUserCtrlId,UserControlId,CtrlOrderNbr,CtrlState) " +
                //             " values (@mainUserCtrlId,@userContrlsId,@ctrlOrderNbr,@ctrlState)";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpSql;
                //sqlItem.AppendParameter("@mainUserCtrlId", mainUserCtrlId);
                //sqlItem.AppendParameter("@userContrlsId", userContrlsId);
                //sqlItem.AppendParameter("@ctrlOrderNbr", ctrlOrderNbr,typeof(bool));
                //sqlItem.AppendParameter("@ctrlState", ctrlState);
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlItem);
                WF_UserControlsLink ucl = new WF_UserControlsLink();
                ucl.MainUserCtrlId= mainUserCtrlId;
                ucl.UserControlId= userContrlsId;
                ucl.CtrlOrderNbr= ctrlOrderNbr;
                ucl.CtrlState = ctrlState;
                MainHelper.PlatformSqlMap.Create<WF_UserControlsLink>(ucl); 


               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// �Ƴ��ӱ�
        /// </summary>
        /// <param name="mainUserCtrlId">����id</param>
        /// <param name="userContrlsId">�ӱ�id</param>
        public static void MoveUserControls(string mainUserCtrlId, string userContrlsId)
        {
            try
            {
                //string tmpSql = "delete UserControlsLink where mainUserCtrlId=@mainUserCtrlId and userContrlsId=@userContrlsId";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpSql;
                //sqlItem.AppendParameter("@mainUserCtrlId", mainUserCtrlId);
                //sqlItem.AppendParameter("@userContrlsId", userContrlsId);
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlItem);
                string tmpSql = " where mainUserCtrlId='" + mainUserCtrlId + "'and userContrlsId='" + userContrlsId + "'";
                 MainHelper.PlatformSqlMap.DeleteByWhere<WF_UserControlsLink>(tmpSql); 

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// �Ƴ������ӱ�
        /// </summary>
        /// <param name="mainUserCtrlId">����id</param>
        public static void MoveUserControlsOfMain(string mainUserCtrlId)
        {
            try
            {
                //string tmpSql = "delete UserControlsLink where mainUserCtrlId=@mainUserCtrlId";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpSql;
                //sqlItem.AppendParameter("@mainUserCtrlId", mainUserCtrlId);
                //ClientDBAgent agent = new ClientDBAgent();
                //agent.ExecuteNonQuery(sqlItem);
                string tmpSql = " where mainUserCtrlId='" + mainUserCtrlId + "'";
                MainHelper.PlatformSqlMap.DeleteByWhere<WF_UserControlsLink>(tmpSql); 

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetWorkFlowAllControlsLink(string workFlowId)
        {
            try
            {
                //string tmpStr = "select distinct ul.* from UserControlsLink ul left join worktaskcontrols wc on wc.usercontrolId=ul.mainuserctrlid " +
                //                         "  where wc.workflowid=@workFlowId";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //sqlItem.AppendParameter("@workFlowId", workFlowId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);

                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_UserControlsLinkleftJoinWorkTaskControlsByWorkFlowID", workFlowId);
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
        public static DataTable GetWorkFlowAllMainControls(string workFlowId)
        {
            try
            {
                //string tmpStr = "select distinct mc.* from UserControlsLink ul left join worktaskcontrols wc on wc.usercontrolId=ul.mainuserctrlid " +
                //   " left join MainUsercontrol mc on mc.mainuserctrlid=wc.usercontrolId " +
                //   " where wc.workflowid=@workFlowId";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //sqlItem.AppendParameter("@workFlowId", workFlowId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_MainUserControlJoinWorkTaskControlsByWorkFlowID", workFlowId);
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
        public static DataTable GetWorkFlowAllControls(string workFlowId)
        {
            try
            {
                //string tmpStr = "select distinct cl.* from UserControlsLink ul left join worktaskcontrols wc on wc.usercontrolId=ul.mainuserctrlid " +
                //               " left join usercontrols cl on ul.usercontrolId=cl.usercontrolId " +
                //               " where wc.workflowid=@workflowid";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //sqlItem.AppendParameter("@workFlowId", workFlowId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_UserControlsJoinWF_WorkTaskControlsByWorkFlowID", workFlowId);
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
        public static bool ExistsTaskControls(string taskControlId)
        {
            //string tmpSql = "select * from WorktaskControls where taskControlId=@taskControlId";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.AppendParameter("@taskControlId", taskControlId);
            //sqlItem.CommandText = tmpSql;
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.RecordExists(sqlItem);
            string tmpStr = " where  taskControlId='" + taskControlId + "'";
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorktaskControlsList", tmpStr);
            if (li.Count > 0) return true;
            return false; 
        }
        public static bool ExistsMainControls(string mainUserCtrlId)
        {
            //string tmpSql = "select * from MainUserControl where MainUserCtrlId=@mainUserCtrlId";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.AppendParameter("@mainUserCtrlId", mainUserCtrlId);
            //sqlItem.CommandText = tmpSql;
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.RecordExists(sqlItem);
            string tmpStr = " where  MainUserCtrlId='" + mainUserCtrlId + "'";
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_MainUserControlList", tmpStr);
            if (li.Count > 0) return true;
            return false; 

        }
        public static bool ExistsUserControls(string userCtrlId)
        {
            //string tmpSql = "select * from UserControls where UserControlId=@userCtrlId";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.AppendParameter("@userCtrlId", userCtrlId);
            //sqlItem.CommandText = tmpSql;
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.RecordExists(sqlItem);
            string tmpStr = " where  UserControlId='" + userCtrlId + "'";
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_UserControlsList", tmpStr);
            if (li.Count > 0) return true;
            return false; 

        }
        public static bool ExistsControlsLink(string ctrlLinkId)
        {
            //string tmpSql = "select * from UserControlsLink where mucLinkId=@ctrlLinkId";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.AppendParameter("@ctrlLinkId", ctrlLinkId);
            //sqlItem.CommandText = tmpSql;
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.RecordExists(sqlItem);
            string tmpStr = " where  mucLinkId='" + ctrlLinkId + "'";
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_UserControlsLinkList", tmpStr);
            if (li.Count > 0) return true;
            return false; 

        }

    }
}
