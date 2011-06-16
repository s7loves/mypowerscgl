using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client.Platform;
using System.Collections;
using System.Data;
using Ebada.Core;

namespace Ebada.SCGL.WFlow.Engine
{
    class UserRoleViewData
    {
        /// <summary>
        /// 列出指定组的所有用户
        /// </summary>
        public static DataTable ListUserOfGroup(string RoleId)
        {

            //string tmpSql = "select * from UserGroupView where GroupId=@GroupId";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.AppendParameter("@GroupId", GroupId); ;
            //sqlItem.CommandText = tmpSql;
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.ExecuteDataTable(sqlItem);
            string tmpStr = "where RoleId ='" + RoleId + "'";
            IList li = MainHelper.PlatformSqlMap.GetList("SelectmPS_UserRoleViewList", tmpStr);
            if (li.Count == 0)
            {
                DataTable dt = new DataTable();
                return dt;
            }
            return ConvertHelper.ToDataTable(li); 
        }
    }
}
