using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Ebada.Client.Platform;
using System.Collections;
using Ebada.Core;

namespace Ebada.SCGL.WFlow.Tool
{
    class RoleGroupData
    {
        public static DataTable GetRoleGroupTableByName(string strSQL)
        {

            try
            {


                IList li = MainHelper.PlatformSqlMap.GetList("SelectmRoleList", strSQL);
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
    }
}
