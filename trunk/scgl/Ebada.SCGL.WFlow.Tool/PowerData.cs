using System;
using System.Collections.Generic;
using System.Text;
namespace Ebada.SCGL.WFlow.Tool
{
    public class PowerData
    {
        /// <summary>
        ///  �ж��Ƿ���Ȩ��
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="operationId"></param>
        /// <returns></returns>
        public static bool IsPower(string userId,string operationId)
        {
            //if (userId.ToLower() == "admin")
                return true;
            //string tmpSql = "select * from Sys_V_Power where UserId=@UserId and OperationId=@OperationId";
            //SqlDataItem sqlItem = new SqlDataItem();
            //try
            //{
            //    sqlItem.AppendParameter("@UserId", userId);
            //    sqlItem.AppendParameter("@OperationId", operationId);
            //    sqlItem.CommandText = tmpSql;
            //    ClientDBAgent agent = new ClientDBAgent();
            //    return agent.RecordExists(sqlItem);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

        }
        /// <summary>
        /// �ж�Ȩ���ڸ������Ƿ��Ѵ���
        /// </summary>
        /// <param name="operationId">Ȩ����,������ģ��Id������Id�Ͳ���Id</param>
        /// <param name="groupId">Ȩ����id</param>
        /// <returns>�Ƿ����</returns>
        public static bool PowerExistInGroup(string operationId, string groupId)
        {
            return true;
            //string tmpSql = "select * from Usr_Purview where OperationId like @OperationId  and GroupId=@groupId";
            //SqlDataItem sqlItem = new SqlDataItem();
            //try
            //{
            //    sqlItem.AppendParameter("@GroupId", groupId);
            //    sqlItem.AppendParameter("@OperationId", operationId + "%");
            //    sqlItem.CommandText = tmpSql;
            //    ClientDBAgent agent = new ClientDBAgent();
            //    return agent.RecordExists(sqlItem);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
 
        }
        /// <summary>
        /// ΪȨ��������Ȩ��
        /// </summary>
        /// <param name="operationId">Ȩ����,������ģ��Id������Id�Ͳ���Id</param>
        /// <param name="groupId">Ȩ����Id</param>
        public static void SetPowerToGroup(string operationId, string groupId)
        {
            //SqlDataItem sqlItem1 = new SqlDataItem();
            //SqlDataItem sqlItem2 = new SqlDataItem();
            //SqlDataItemArray sqlItemAry = new SqlDataItemArray();
            return ;
            //try
            //{
            //    sqlItem1.CommandText = "delete Usr_Purview where GroupId=@GroupId and OperationId like @operationId";
            //    sqlItem1.AppendParameter("@operationId", operationId + "%");
            //    sqlItem1.AppendParameter("@groupId", groupId);

            //    sqlItem2.CommandText = "insert into Usr_Purview(GroupId,OperationId) select @groupId,OperationId from Sys_Operation " +
            //                              " where OperationId like @operationId";
            //    sqlItem2.AppendParameter("@operationId", operationId + "%");
            //    sqlItem2.AppendParameter("@groupId", groupId);

            //    sqlItemAry.AppendSqlItem(sqlItem1);
            //    sqlItemAry.AppendSqlItem(sqlItem2);

            //    ClientDBAgent agent = new ClientDBAgent();
            //    agent.ExecuteNonQueryArray(sqlItemAry);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
         /// <summary>
        /// ɾ��Ȩ�����Ȩ��
        /// </summary>
        /// <param name="operationId">Ȩ����,������ģ��Id������Id�Ͳ���Id</param>
        /// <param name="groupId">Ȩ����Id</param>
        public static void DeletePowerFromGroup(string operationId, string groupId)
        {
            //SqlDataItem sqlItem1 = new SqlDataItem();
            //ClientDBAgent agent = new ClientDBAgent();
            //try
            //{
            //    sqlItem1.CommandText = "delete Usr_Purview where GroupId=@GroupId and OperationId like @operationId";
            //    sqlItem1.AppendParameter("@operationId", operationId + "%");
            //    sqlItem1.AppendParameter("@groupId", groupId);
            //    agent.ExecuteNonQuery(sqlItem1);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return ;
        }
       
    }
}
