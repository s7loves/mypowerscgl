using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Ebada.SCGL.WFlow.Tool;
using System.Collections;
using Ebada.Client.Platform;
using Ebada.Scgl.Model;
using Ebada.Core;

//支持，一人多部门，一人多岗位的情况。
namespace Ebada.SCGL.WFlow.Engine
{
    public class InstanceType
    {
        /**//// <summary>
        /// 指定处理人
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="workFlowId">流程模板Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <param name="workFlowInstanceId">流程实例Id</param>
        /// <param name="WorkTaskInstanceId">任务实例Id</param>
        /// <param name="operContent">处理者</param>
        /// <param name="operRule">处理策略</param>
        /// <param name="operRealtion">处理关系</param>
        /// <returns>是否成功</returns>
        public static bool AssignUser(string userId, string workFlowId, string workTaskId, string workFlowInstanceId,
                                      string WorkTaskInstanceId, OperParameter operParam)
        {

           // DebugHF.WriteErrorLog("AssignUser处理者类型:operContent= " + operParam.OperContent, workFlowInstanceId);
            if (operParam.OperContent == null || operParam.OperContent == "") return false;

            if (operParam.OperRule == "1")//只产生处理者实例
            {
                //创建处理人实例
                OperatorInstance operatorInstance = new OperatorInstance();
                operatorInstance.OperatorInsId = Guid.NewGuid().ToString();
                operatorInstance.WorkflowId = workFlowId;
                operatorInstance.WorktaskId = workTaskId;
                operatorInstance.WorkflowInsId = workFlowInstanceId;
                operatorInstance.WorktaskInsId = WorkTaskInstanceId;//此时是新任务Id
                operatorInstance.UserId = "";
                operatorInstance.OperRealtion = operParam.OperRelation;
                operatorInstance.OperContent = operParam.OperContent;
                operatorInstance.OperContentText = operParam.OperContenText;
                operatorInstance.OperType = operParam.OperType;//此处保留原来的处理类型
                operatorInstance.Create();

                if ((userId == operParam.OperContent) && (operParam.IsJumpSelf))//处理者是提交人，自动处理
                {
                    WorkFlowRuntime wfrun = new WorkFlowRuntime();
                    wfrun.Run(userId, operatorInstance.OperatorInsId,"提交");
                }
            }
            else
                if (operParam.OperRule == "2")//为每个处理者产生一个任务实例
            {
                //创建任务实例
                string newTaskId = Guid.NewGuid().ToString();//新任务实例Id
                WorkTaskInstance WorkTaskInstance = new WorkTaskInstance();
                WorkTaskInstance.WorkflowId = workFlowId;
                WorkTaskInstance.WorktaskId = workTaskId;
                WorkTaskInstance.WorkflowInsId = workFlowInstanceId;
                WorkTaskInstance.WorktaskInsId = newTaskId;
                WorkTaskInstance.PreviousTaskId = WorkTaskInstanceId;//此时是当前任务Id
                WorkTaskInstance.TaskInsCaption = WorkFlowTask.GetTaskCaption(workTaskId);
                WorkTaskInstance.Status = "1";
                WorkTaskInstance.Create();

                //创建处理人实例
                OperatorInstance operatorInstance = new OperatorInstance();
                operatorInstance.OperatorInsId = Guid.NewGuid().ToString();
                operatorInstance.WorkflowId = workFlowId;
                operatorInstance.WorktaskId = workTaskId;
                operatorInstance.WorkflowInsId = workFlowInstanceId;
                operatorInstance.WorktaskInsId = newTaskId;
                operatorInstance.UserId = "";
                operatorInstance.OperRealtion = operParam.OperRelation;
                operatorInstance.OperContent = operParam.OperContent;
                operatorInstance.OperContentText = operParam.OperContenText;
                operatorInstance.OperType = 3;//此处修改为指定处理人
                operatorInstance.Create();
                if ((userId == operParam.OperContent) && (operParam.IsJumpSelf))//处理者是提交人，自动处理
                {
                    WorkFlowRuntime wfrun = new WorkFlowRuntime();
                    wfrun.Run(userId, operatorInstance.OperatorInsId, "提交");
                }
            }
            return true;
        }
        /**//// <summary>
        /// 组织机构处理者
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="workFlowId">流程模板Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <param name="workFlowInstanceId">流程实例Id</param>
        /// <param name="WorkTaskInstanceId">任务实例Id</param>
        /// <param name="operContent">处理者</param>
        /// <param name="operRule">处理策略</param>
        /// <param name="operRealtion">处理关系</param>
        /// <returns>是否成功</returns>
        public static bool AssignArchitecture(string userId, string workFlowId, string workTaskId, string workFlowInstanceId,
                                      string WorkTaskInstanceId, OperParameter operParam)
        {

            //DebugHF.WriteErrorLog("AssignArchitecture处理者类型:operContent= " + operParam.OperContent, workFlowInstanceId);
            
            string tmpUser = "";
            string tmpUserName = "";
            if (operParam.OperContent == null || operParam.OperContent == "") return false;
            if (operParam.OperRule == "1")//只产生处理者实例
                {
                    //创建处理人实例
                    AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                }
            else
                    if (operParam.OperRule == "2")//为每个处理者产生一个任务实例
                {
                    DataTable archUser = mOrgData.GetUserList(operParam.OperContent);
                    if (archUser == null || archUser.Rows.Count <= 0)
                    {
                       // throw new Exception("引擎没有找到处理者,请检查是否配置处理者。");
                        //DebugHF.WriteErrorLog("部门或者岗位[" + operParam.OperContenText + "]没有配置处理人!!!", workFlowInstanceId);
                    }
                    foreach (DataRow dr in archUser.Rows)
                    {
                        tmpUser = dr["UserID"].ToString();
                        tmpUserName = dr["UserName"].ToString();
                        operParam.OperContent = tmpUser;
                        operParam.OperContenText = tmpUserName;
                        AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                    }
                }
            return true;
        }
        /**//// <summary>
        /// 角色处理者
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="workFlowId">流程模板Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <param name="workFlowInstanceId">流程实例Id</param>
        /// <param name="WorkTaskInstanceId">任务实例Id</param>
        /// <param name="operContent">处理者</param>
        /// <param name="operRule">处理策略</param>
        /// <param name="operRealtion">处理关系</param>
        /// <returns>是否成功</returns>
        public static bool AssignGroup(string userId, string workFlowId, string workTaskId, string workFlowInstanceId,
                                      string WorkTaskInstanceId, OperParameter operParam)
        {

            //DebugHF.WriteErrorLog("AssignGroup处理者类型:operContent= " + operParam.OperContent, workFlowInstanceId);
            
            string tmpUser = "";
            string tmpUserName = "";
            if (operParam.OperContent == null || operParam.OperContent == "") return false;
            if (operParam.OperRule == "1")//只产生处理者实例
            {
                //创建处理人实例
                AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
            }
            else
                if (operParam.OperRule == "2")//为每个处理者产生一个任务实例
                {
                    DataTable archUser = UserRoleViewData.ListUserOfGroup(operParam.OperContent);
                    if (archUser == null || archUser.Rows.Count <= 0)
                    {
                        //throw new Exception("引擎没有找到处理者,请检查是否配置处理者。");
                        //DebugHF.WriteErrorLog("角色[" + operParam.OperContenText + "]没有配置处理人!!!", workFlowInstanceId);
                    }
                    foreach (DataRow dr in archUser.Rows)
                    {
                        tmpUser = dr["UserID"].ToString();
                        tmpUserName = dr["UserName"].ToString();
                        operParam.OperContent = tmpUser;
                        operParam.OperContenText = tmpUserName;
                        AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);

                    }
                }
            return true;
        }
        /**//// <summary>
        /// 所有人
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="workFlowId">流程模板Id</param>
        /// <param name="workTaskId">任务模板Id</param>
        /// <param name="workFlowInstanceId">流程实例Id</param>
        /// <param name="WorkTaskInstanceId">任务实例Id</param>
        /// <param name="operContent">处理者</param>
        /// <param name="operRule">处理策略</param>
        /// <param name="operRealtion">处理关系</param>
        /// <returns>是否成功</returns>
        public static bool AssignAll(string userId, string workFlowId, string workTaskId, string workFlowInstanceId,
                                      string WorkTaskInstanceId, OperParameter operParam)
        {

            //DebugHF.WriteErrorLog("AssignAll处理者类型:operContent= " + operParam.OperContent, workFlowInstanceId);

            string tmpUser = "";
            string tmpUserName="";
            if (operParam.OperContent == null || operParam.OperContent == "") return false;
            if (operParam.OperRule == "1")//只产生处理者实例
            {
                //创建处理人实例
                operParam.OperContent = "ALL";
                AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
            }
            else
                if (operParam.OperRule == "2")//为每个处理者产生一个任务实例
                {
                    DataTable dtAllUser = UserData.GetAllUser();
                    if (dtAllUser == null || dtAllUser.Rows.Count <= 0)
                    {
                        //throw new Exception("引擎没有找到处理者,请检查是否配置处理者。");
                       // DebugHF.WriteErrorLog("所有人" + operParam.OperContenText + "]没有配置处理人!!!", workFlowInstanceId);
                    }
                    foreach (DataRow dr in dtAllUser.Rows)
                    {
                        tmpUser = dr["UserID"].ToString();
                        tmpUserName = dr["UserName"].ToString();
                        operParam.OperContent = tmpUser;
                        operParam.OperContenText = tmpUserName;
                        AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);

                    }
                }
            return true;
        }
        /**//// <summary>
        /// 获得流程启动者
        /// </summary>
        /// <param name="workFlowInstanceId">流程实例Id</param>
        /// <returns>流程处理者</returns>
        public static string GetStartWorkflowUser(string workFlowInstanceId)
        {
            //string sql = "select UserId from WorkTaskInstanceView where WorkFlowInsId=@WorkFlowInsId and tasktypeid='1'";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = sql;
            //sqlItem.AppendParameter("@WorkFlowInsId", workFlowInstanceId);
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.ExecuteScalar(sqlItem);
            string tmpStr = " where WorkFlowInsId='" + workFlowInstanceId + "' and tasktypeid='1'";
            IList<WF_WorkTaskInstanceView> li = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskInstanceView>("SelectWF_WorkTaskInstanceViewList", tmpStr);

            if (li.Count > 0) return li[0].UserId ;
            return ""; 
        }
        /**//// <summary>
        /// 某一任务实际处理者
       /// </summary>
       /// <param name="workFlowInstanceId">流程实例Id</param>
       /// <param name="workTaskInsName">任务名</param>
       /// <returns>某一任务实际处理者</returns>
        public static DataTable GetTaskInstanceUser(string workFlowInstanceId,string worktaskId)
        {
            //string sql = "select distinct UserId from WorkTaskInstanceView where WorkFlowInsId=@WorkFlowInsId and status='3' and " +
            //             " worktaskId=@worktaskId";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = sql;
            //sqlItem.AppendParameter("@WorkFlowInsId", workFlowInstanceId);
            //sqlItem.AppendParameter("@worktaskId", worktaskId);
            //ClientDBAgent agent = new ClientDBAgent();
            //return agent.ExecuteDataTable(sqlItem);
            string tmpStr = " select distinct UserId from WorkTaskInstanceView where WorkFlowInsId='" + workFlowInstanceId + "' and status='3' and "+
                         " worktaskId='"+worktaskId+"'";
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkFlowInstanceUserIdList", tmpStr);
            if (li.Count == 0)
            {
                DataTable dt = new DataTable();

                return dt;
            }
            return ConvertHelper.ToDataTable(li); 
        }

        public static bool UserRelation(string userId, string workFlowId, string workTaskId, string workFlowInstanceId,
                                      string WorkTaskInstanceId, OperParameter operParam)
        {

            switch (operParam.OperRelation)
            {
                case 1://本部门领导
                    //获得用户所属部门
                    DataTable dtArch = UserData.ArchOfUserTable(operParam.OperContent);//获得用户所属部门
                    foreach (DataRow drArch in dtArch.Rows)//可能一个人属于多个部门
                    {
                        string archId = drArch["OrgID"].ToString();
                        //获取部门主管岗位
                        DataTable dtDuty = mOrgData.GetLeaderOfArch(archId);//获得部门主管岗位
                        foreach (DataRow drDuty in dtDuty.Rows)//可能一个部门有多个主管岗位
                        {
                            //获取岗位对应的用户
                            string dutyId = drDuty["OrgID"].ToString();
                            DataTable dtUser = mOrgData.GetUserList(dutyId);
                            foreach (DataRow drUser in dtUser.Rows)
                            {
                                string ldruserId=drUser["UserID"].ToString();
                                string ldruserName=drUser["UserName"].ToString();
                                operParam.OperContent = ldruserId;
                                operParam.OperContenText = ldruserName;
                                AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                            }
                        }
                    }
                    break;
                case 2://所在部门
                    DataTable dtinArch = UserData.ArchOfUserTable(operParam.OperContent);//获得用户所属部门
                    foreach (DataRow drArch in dtinArch.Rows)//可能一个人属于多个部门
                    {
                        string archId = drArch["OrgID"].ToString();
                        string archName = drArch["OrgName"].ToString();
                        operParam.OperContent = archId;
                        operParam.OperContenText = archName;
                        AssignArchitecture(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                    }
                    break;
                case 3://上级部门
                    DataTable dthigArch = UserData.HigherArchOfUserTable(operParam.OperContent);//获得用户上级部门
                    foreach (DataRow drhigArch in dthigArch.Rows)//可能有多个上级部门
                    {
                        string archId = drhigArch["OrgID"].ToString();
                        string archName = drhigArch["OrgName"].ToString();
                        operParam.OperContent = archId;
                        operParam.OperContenText = archName;
                        AssignArchitecture(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                    }
                    break;
                case 4://下级部门
                    DataTable dtlowArch = UserData.LowerArchOfUserTable(operParam.OperContent);//获得用户下级部门
                    foreach (DataRow drlowArch in dtlowArch.Rows)//可能有多个下级部门
                    {
                        string archId = drlowArch["OrgID"].ToString();
                        string archName = drlowArch["OrgName"].ToString();
                        operParam.OperContent = archId;
                        operParam.OperContenText = archName;
                        AssignArchitecture(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                    }
                    break;
                case 5://上级领导
                    //获得用户上级部门
                    DataTable dthigldrArch = UserData.HigherArchOfUserTable(operParam.OperContent);//获得用户上级部门
                    foreach (DataRow drhigldrArch in dthigldrArch.Rows)//可能有多个上级部门(一人多部门的情况)
                    {
                        string archId = drhigldrArch["OrgID"].ToString();
                        //获取部门主管岗位
                        DataTable dtDuty = mOrgData.GetLeaderOfArch(archId);//获得部门主管岗位
                        foreach (DataRow drDuty in dtDuty.Rows)//可能一个部门有多个主管岗位
                        {
                            //获取岗位对应的用户
                            string dutyId = drDuty["OrgID"].ToString();
                            DataTable dtUser = mOrgData.GetUserList(dutyId);
                            foreach (DataRow drUser in dtUser.Rows)
                            {
                                string ldruserId = drUser["UserID"].ToString();
                                string ldruserName = drUser["UserName"].ToString();
                                operParam.OperContent = ldruserId;
                                operParam.OperContenText = ldruserName;
                                AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                            }
                        }
                    }
                    break;
                case 6://下级领导
                    //获得用户下级部门
                    DataTable dtlowldrArch = UserData.LowerArchOfUserTable(operParam.OperContent);//获得用户下级部门
                    foreach (DataRow drlowldrArch in dtlowldrArch.Rows)//可能有多个下级部门(一人多部门的情况)
                    {
                        string archId = drlowldrArch["OrgID"].ToString();
                        //获取部门主管岗位
                        DataTable dtDuty = mOrgData.GetLeaderOfArch(archId);//获得部门主管岗位
                        foreach (DataRow drDuty in dtDuty.Rows)//可能一个部门有多个主管岗位
                        {
                            //获取岗位对应的用户
                            string dutyId = drDuty["OrgID"].ToString();
                            DataTable dtUser = mOrgData.GetUserList(dutyId);
                            foreach (DataRow drUser in dtUser.Rows)
                            {
                                string ldruserId = drUser["UserID"].ToString();
                                string ldruserName = drUser["UserName"].ToString();
                                operParam.OperContent = ldruserId;
                                operParam.OperContenText = ldruserName;
                                AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                            }
                        }
                    }
                    break;
            }
            return true;
        }
        public static bool ArchRelation(string userId, string workFlowId, string workTaskId, string workFlowInstanceId,
                                      string WorkTaskInstanceId, OperParameter operParam)
        {
            switch (operParam.OperRelation)
            {
                case 1://本部门领导
                    DataTable dtDuty = mOrgData.GetLeaderOfArch(operParam.OperContent);//获得部门主管岗位
                    foreach (DataRow drDuty in dtDuty.Rows)//可能一个部门有多个主管岗位
                    {
                        //获取岗位对应的用户
                        string dutyId = drDuty["OrgID"].ToString();
                        DataTable dtUser = mOrgData.GetUserList(dutyId);
                        foreach (DataRow drUser in dtUser.Rows)
                        {
                            string ldruserId = drUser["UserID"].ToString();
                            string ldruserName = drUser["UserName"].ToString();
                            operParam.OperContent = ldruserId;
                            operParam.OperContenText = ldruserName;
                            AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        }
                    }
                    break;
                case 2://无此情况
                    break;
                case 3://上级部门,一个部门只有一个上级部门
                    string fatherId = mOrgData.GetFatherArchId(operParam.OperContent);
                    mOrgData arh = new mOrgData();
                    arh.GetArchitecture(fatherId);
                    operParam.OperContent = fatherId;
                    operParam.OperContenText = arh.ArchCaption;
                    AssignArchitecture(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                    break;
                case 4://下级部门
                    DataTable dtlowArch = mOrgData.GetLowerArch(operParam.OperContent);
                    
                    foreach (DataRow drlowArch in dtlowArch.Rows)//可能有多个下级部门
                    {
                        string archId = drlowArch["OrgID"].ToString();
                        mOrgData arhcp = new mOrgData();
                        arhcp.GetArchitecture(archId);
                        operParam.OperContent = archId;
                        operParam.OperContenText = arhcp.ArchCaption;
                        AssignArchitecture(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                    }
                    break;
                case 5://上级部门领导
                    fatherId = mOrgData.GetFatherArchId(operParam.OperContent);
                    dtDuty = mOrgData.GetLeaderOfArch(fatherId);//获得部门主管岗位
                    foreach (DataRow drDuty in dtDuty.Rows)//可能一个部门有多个主管岗位
                    {
                        //获取岗位对应的用户
                        string dutyId = drDuty["OrgID"].ToString();
                        DataTable dtUser = mOrgData.GetUserList(dutyId);
                        foreach (DataRow drUser in dtUser.Rows)
                        {
                            string ldruserId = drUser["UserID"].ToString();
                            string ldruserName = drUser["UserName"].ToString();
                            operParam.OperContent = ldruserId;
                            operParam.OperContenText = ldruserName;
                            AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        }
                    }
                    break;
                case 6://下级部门领导
                    dtlowArch = mOrgData.GetLowerArch(operParam.OperContent);
                    foreach (DataRow drlowArch in dtlowArch.Rows)//可能有多个下级部门
                    {
                        string archId = drlowArch["OrgID"].ToString();
                        //获取部门主管岗位
                        dtDuty = mOrgData.GetLeaderOfArch(archId);//获得部门主管岗位
                        foreach (DataRow drDuty in dtDuty.Rows)//可能一个部门有多个主管岗位
                        {
                            //获取岗位对应的用户
                            string dutyId = drDuty["OrgID"].ToString();
                            DataTable dtUser = mOrgData.GetUserList(dutyId);
                            foreach (DataRow drUser in dtUser.Rows)
                            {
                                string ldruserId = drUser["OrgID"].ToString();
                                string ldruserName = drUser["UserName"].ToString();
                                operParam.OperContent = ldruserId;
                                operParam.OperContenText = ldruserName;
                                AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                            }
                        }
                    }
                    break;
            }
            return true;
        }
 

    }
}
