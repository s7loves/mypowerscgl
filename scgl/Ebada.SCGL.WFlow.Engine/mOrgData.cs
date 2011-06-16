using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;
using System.Collections;
using System.Data;
using Ebada.Core;

namespace Ebada.SCGL.WFlow.Engine
{
    class mOrgData
    {
        public string ArchId = "";
        public string ArchFatherId = "";
        public string ArchFullName = "";
        public string ArchCaption = "";
        public string ArchTypeName = "";
        public string ArchFullId = "";
        public string ArchDutyId = "";
        public string ArchLevel = "";
        public string ArchDes = "";
        public int ArchLeader = 2;
        /// <summary>
        /// 获得本部门下的所有领导岗位
        /// </summary>
        /// <param name="FatherClassId">组织机构Id</param>
        /// <returns>岗位table</returns>
        public static DataTable GetLeaderOfArch(string ArchId)
        {
            try
            {
                //string tmpStr = "select * from Architecture where  FatherId=@FatherId and TypeName=@typename "
                //               + " and (leader=0 or leader=1)";

                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //sqlItem.AppendParameter("@FatherId", ArchId);
                //sqlItem.AppendParameter("@typename", WorkConst.ARCHITECTURE_DUTY);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string tmpStr = " where  OrgCode ='"+ArchId+"' ";
                mOrg org  =(mOrg) MainHelper.PlatformSqlMap.GetObject("SelectmOrgList",tmpStr) ;

                DataTable dt = new DataTable();
                dt.Columns.Add("OrgID", typeof(string));
                dt.Columns.Add("OrgCode", typeof(string));
                dt.Columns.Add("OrgName ", typeof(string));
                tmpStr = " where  ParentID  ='" + org.OrgID + "' ";
                GetChildTable(ref dt, tmpStr);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void GetChildTable(ref DataTable dt, string tmpStr)
        {
            mOrg org = (mOrg)MainHelper.PlatformSqlMap.GetObject("SelectmOrgList", tmpStr);
            if (org != null)
            {
                DataRow dr = dt.NewRow();
                dr["OrgID"] = org.OrgID;
                dr["OrgCode"] = org.OrgCode;
                dr["OrgName"] = org.OrgName;
                dt.Rows.Add(dr);
                tmpStr = " where  ParentID  ='" + org.OrgID + "' ";
                GetChildTable(ref dt, tmpStr);
                GetChildTable(ref dt, tmpStr);
            }
            return;
        }
        /// <summary>
        /// 读取组织机构下的用户
        /// </summary>
        /// <param name="iArchId">组织机构Id</param>
        /// <returns>返回组织机构所有用户<returns>
        public static DataTable GetUserList(string iArchId)
        {
            //string tmpSql = "select * from ArchDutyUserView where ArchitectureId=@ArchitectureId";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = tmpSql;
            //sqlItem.AppendParameter("@ArchitectureId", iArchId);
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.ExecuteDataTable(sqlItem);
            mOrg org = MainHelper.PlatformSqlMap.GetOneByKey<mOrg>(iArchId);
            string tmpStr = "where OrgCode ='" + org.OrgCode  + "'";
            IList li = MainHelper.PlatformSqlMap.GetList("SelectmUserList", tmpStr);
            if (li.Count == 0)
            {
                DataTable dt = new DataTable();
                return dt;
            }
            return ConvertHelper.ToDataTable(li); 
        }
        /// <summary>
        /// 获取上级机构Id
        /// </summary>
        /// <param name="ArchitectureId">组织机构Id</param>
        /// <returns>上级组织机构Id</returns>
        public static string GetFatherArchId(string archId)
        {
            try
            {
                //string tmpStr = "select FatherId from Architecture where ArchitectureId=@ArchitectureId";

                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //sqlItem.AppendParameter("@ArchitectureId", archId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteScalar(sqlItem);
                string tmpStr = " where  OrgID  ='" + archId + "' ";
                mOrg org = (mOrg)MainHelper.PlatformSqlMap.GetObject("SelectmOrgList", tmpStr);

                return MainHelper.PlatformSqlMap.GetOneByKey<mOrg>(org).OrgID;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 取得一个组织结构类的实体
        /// </summary>
        /// <param name="iArchId"></param>
        public void GetArchitecture(string iArchId)
        {
            if (iArchId == "" || iArchId == null) iArchId = ArchId;
            //string tmpSql = "select * from Architecture where ArchitectureId=@ArchitectureId";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = tmpSql;
            //sqlItem.AppendParameter("@ArchitectureId", iArchId);
            //ClientDBAgent agent = new ClientDBAgent();
            //DataTable dt = agent.ExecuteDataTable(sqlItem);
            string tmpStr = "where OrgCode ='" + iArchId + "'";
            IList li = MainHelper.PlatformSqlMap.GetList("SelectmOrgList", tmpStr);
            if (li.Count == 0)
            {
                
                return ;
            }
            DataTable dt = ConvertHelper.ToDataTable(li); 
            if (dt != null && dt.Rows.Count > 0)
            {
                this.ArchFatherId = dt.Rows[0]["ParentID"].ToString();
                this.ArchId = dt.Rows[0]["OrgID"].ToString();
                this.ArchFullName = dt.Rows[0]["OrgName"].ToString();
                this.ArchCaption = dt.Rows[0]["OrgName"].ToString();
                this.ArchTypeName = dt.Rows[0]["OrgType "].ToString();
                
            }

        }
        /// <summary>
        /// 获得下级部门列表
        /// </summary>
        /// <param name="FatherClassId">机构Id</param>
        /// <returns>下级部门table</returns>
        public static DataTable GetLowerArch(string fatherArcheId)
        {
            try
            {
                //string tmpStr = "select * from Architecture where  FatherId=@FatherId " +
                //      " and typename=@typename";

                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = tmpStr;
                //sqlItem.AppendParameter("@FatherId", fatherArcheId);
                //sqlItem.AppendParameter("@typename", WorkConst.ARCHITECTURE_ARCH);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
              
                string tmpStr = "where ParentID ='" + fatherArcheId + "'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectmOrgList", tmpStr);
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
