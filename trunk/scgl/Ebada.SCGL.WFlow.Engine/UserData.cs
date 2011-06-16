using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Ebada.Client.Platform;
using Ebada.Core;
using Ebada.Scgl.Model;

namespace Ebada.SCGL.WFlow.Engine
{
    class UserData
    {
        public static DataTable GetAllUser()
        {
            string tmpStr = "where 1=1";
            IList li = MainHelper.PlatformSqlMap.GetList("SelectmUserList", tmpStr);
            if (li.Count == 0)
            {
                DataTable dt = new DataTable();
                return dt;
            }
            return ConvertHelper.ToDataTable(li); 
        
        }
        /// <summary>
        /// 取得用户名
        /// </summary>
        /// <param name="userId">用户帐号</param>
        /// <returns>用户</returns>
        public static string GetUserNameById(string userId)
        {
            try
            {
                //string tmpSql = "select UserName from Usr_User where UserId = @userid";

                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.AppendParameter("@userid", userId);
                //sqlItem.CommandText = tmpSql;
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteScalar(sqlItem);
                //userId = "010003";
                return MainHelper.PlatformSqlMap.GetOneByKey<mUser>(userId).UserName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获得用户所属部门
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public static DataTable ArchOfUserTable(string userId)
        {
            try
            {
                //string tmpSql = "select * from ArchDutyUserView where UserId=@UserId "
                //              + " and typename=@typename";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.AppendParameter("@UserId", userId);
                //sqlItem.AppendParameter("@typename", WorkConst.ARCHITECTURE_ARCH);
                //sqlItem.CommandText = tmpSql;
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
               
                mUser user=MainHelper.PlatformSqlMap.GetOneByKey<mUser>(userId);
                string tmpStr = " where  OrgCode ='" + user.OrgCode + "' ";
                mOrg org = (mOrg)MainHelper.PlatformSqlMap.GetObject("SelectmOrgList", tmpStr);
                DataTable dt = new DataTable();
                dt.Columns.Add("OrgID", typeof(string));
                dt.Columns.Add("OrgCode", typeof(string));
                dt.Columns.Add("OrgName ", typeof(string));
                DataRow dr = dt.NewRow();
                dr["OrgID"] = org.OrgID;
                dr["OrgCode"] = user.OrgCode;
                dr["OrgName"] = user.OrgName;
                dt.Rows.Add(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获得用户上级部门
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns>上级部门table</returns>
        public static DataTable HigherArchOfUserTable(string userId)
        {
            try
            {
                //string tmpSql = "select * from UserHigherArchView where UserId=@UserId "
                //              + " and typename= @typename";

                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.AppendParameter("@UserId", userId);
                //sqlItem.AppendParameter("@typename", WorkConst.ARCHITECTURE_ARCH);
                //sqlItem.CommandText = tmpSql;
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string tmpStr = " where  UserID  ='" + userId + "' ";
                mUser user = (mUser)MainHelper.PlatformSqlMap.GetObject("SelectmUserList", tmpStr);
                tmpStr = " where  OrgCode ='" + user.OrgCode + "' ";
                mOrg org = (mOrg)MainHelper.PlatformSqlMap.GetObject("SelectmOrgList", tmpStr);
                DataTable dt = new DataTable();
                dt.Columns.Add("OrgID", typeof(string));
                dt.Columns.Add("OrgCode", typeof(string));
                dt.Columns.Add("OrgName ", typeof(string));
                if (org != null)
                {
                    DataRow dr = dt.NewRow();
                    dr["OrgID"] = org.OrgID;
                    dr["OrgCode"] = org.OrgCode;
                    dr["OrgName"] = org.OrgName;
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获得用户下级部门
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns>下级部门table</returns>
        public static DataTable LowerArchOfUserTable(string userId)
        {
            try
            {
                //string tmpSql = "select * from UserLowerArchView where UserId=@UserId "
                //              + " and typename=@typename";


                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.AppendParameter("@UserId", userId);
                //sqlItem.AppendParameter("@typename", WorkConst.ARCHITECTURE_ARCH);
                //sqlItem.CommandText = tmpSql;
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string tmpStr = " where  UserID  ='" + userId + "' ";
                mUser user = (mUser)MainHelper.PlatformSqlMap.GetObject("SelectmUserList", tmpStr);
                tmpStr = " where  OrgCode ='" + user.OrgCode  + "' ";
                mOrg org = (mOrg)MainHelper.PlatformSqlMap.GetObject("SelectmOrgList", tmpStr);
                tmpStr = " where  ParentID  ='" + org.OrgID  + "' ";
                org = (mOrg)MainHelper.PlatformSqlMap.GetObject("SelectmOrgList", tmpStr);

                DataTable dt = new DataTable();
                dt.Columns.Add("OrgID", typeof(string));
                dt.Columns.Add("OrgCode", typeof(string));
                dt.Columns.Add("OrgName ", typeof(string));
                if (org != null)
                {
                    DataRow dr = dt.NewRow();
                    dr["OrgID"] = org.OrgID;
                    dr["OrgCode"] = org.OrgCode;
                    dr["OrgName"] = org.OrgName;
                    dt.Rows.Add(dr);
                   
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
