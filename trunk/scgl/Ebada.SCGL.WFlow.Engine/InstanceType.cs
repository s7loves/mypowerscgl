using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Ebada.SCGL.WFlow.Tool;
using System.Collections;
using Ebada.Client.Platform;
using Ebada.Scgl.Model;
using Ebada.Core;

//֧�֣�һ�˶ಿ�ţ�һ�˶��λ�������
namespace Ebada.SCGL.WFlow.Engine
{
    public class InstanceType
    {
        /**//// <summary>
        /// ָ��������
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <param name="workFlowId">����ģ��Id</param>
        /// <param name="workTaskId">����ģ��Id</param>
        /// <param name="workFlowInstanceId">����ʵ��Id</param>
        /// <param name="WorkTaskInstanceId">����ʵ��Id</param>
        /// <param name="operContent">������</param>
        /// <param name="operRule">�������</param>
        /// <param name="operRealtion">�����ϵ</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public static bool AssignUser(string userId, string workFlowId, string workTaskId, string workFlowInstanceId,
                                      string WorkTaskInstanceId, OperParameter operParam)
        {

           // DebugHF.WriteErrorLog("AssignUser����������:operContent= " + operParam.OperContent, workFlowInstanceId);
            if (operParam.OperContent == null || operParam.OperContent == "") return false;

            if (operParam.OperRule == "1")//ֻ����������ʵ��
            {
                //����������ʵ��
                OperatorInstance operatorInstance = new OperatorInstance();
                operatorInstance.OperatorInsId = Guid.NewGuid().ToString();
                operatorInstance.WorkflowId = workFlowId;
                operatorInstance.WorktaskId = workTaskId;
                operatorInstance.WorkflowInsId = workFlowInstanceId;
                operatorInstance.WorktaskInsId = WorkTaskInstanceId;//��ʱ��������Id
                operatorInstance.UserId = "";
                operatorInstance.OperRealtion = operParam.OperRelation;
                operatorInstance.OperContent = operParam.OperContent;
                operatorInstance.OperContentText = operParam.OperContenText;
                operatorInstance.OperType = operParam.OperType;//�˴�����ԭ���Ĵ�������
                operatorInstance.Create();

                if ((userId == operParam.OperContent) && (operParam.IsJumpSelf))//���������ύ�ˣ��Զ�����
                {
                    WorkFlowRuntime wfrun = new WorkFlowRuntime();
                    wfrun.Run(userId, operatorInstance.OperatorInsId,"�ύ");
                }
            }
            else
                if (operParam.OperRule == "2")//Ϊÿ�������߲���һ������ʵ��
            {
                //��������ʵ��
                string newTaskId = Guid.NewGuid().ToString();//������ʵ��Id
                WorkTaskInstance WorkTaskInstance = new WorkTaskInstance();
                WorkTaskInstance.WorkflowId = workFlowId;
                WorkTaskInstance.WorktaskId = workTaskId;
                WorkTaskInstance.WorkflowInsId = workFlowInstanceId;
                WorkTaskInstance.WorktaskInsId = newTaskId;
                WorkTaskInstance.PreviousTaskId = WorkTaskInstanceId;//��ʱ�ǵ�ǰ����Id
                WorkTaskInstance.TaskInsCaption = WorkFlowTask.GetTaskCaption(workTaskId);
                WorkTaskInstance.Status = "1";
                WorkTaskInstance.Create();

                //����������ʵ��
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
                operatorInstance.OperType = 3;//�˴��޸�Ϊָ��������
                operatorInstance.Create();
                if ((userId == operParam.OperContent) && (operParam.IsJumpSelf))//���������ύ�ˣ��Զ�����
                {
                    WorkFlowRuntime wfrun = new WorkFlowRuntime();
                    wfrun.Run(userId, operatorInstance.OperatorInsId, "�ύ");
                }
            }
            return true;
        }
        /**//// <summary>
        /// ��֯����������
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <param name="workFlowId">����ģ��Id</param>
        /// <param name="workTaskId">����ģ��Id</param>
        /// <param name="workFlowInstanceId">����ʵ��Id</param>
        /// <param name="WorkTaskInstanceId">����ʵ��Id</param>
        /// <param name="operContent">������</param>
        /// <param name="operRule">�������</param>
        /// <param name="operRealtion">�����ϵ</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public static bool AssignArchitecture(string userId, string workFlowId, string workTaskId, string workFlowInstanceId,
                                      string WorkTaskInstanceId, OperParameter operParam)
        {

            //DebugHF.WriteErrorLog("AssignArchitecture����������:operContent= " + operParam.OperContent, workFlowInstanceId);
            
            string tmpUser = "";
            string tmpUserName = "";
            if (operParam.OperContent == null || operParam.OperContent == "") return false;
            if (operParam.OperRule == "1")//ֻ����������ʵ��
                {
                    //����������ʵ��
                    AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                }
            else
                    if (operParam.OperRule == "2")//Ϊÿ�������߲���һ������ʵ��
                {
                    DataTable archUser = mOrgData.GetUserList(operParam.OperContent);
                    if (archUser == null || archUser.Rows.Count <= 0)
                    {
                       // throw new Exception("����û���ҵ�������,�����Ƿ����ô����ߡ�");
                        //DebugHF.WriteErrorLog("���Ż��߸�λ[" + operParam.OperContenText + "]û�����ô�����!!!", workFlowInstanceId);
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
        /// ��ɫ������
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <param name="workFlowId">����ģ��Id</param>
        /// <param name="workTaskId">����ģ��Id</param>
        /// <param name="workFlowInstanceId">����ʵ��Id</param>
        /// <param name="WorkTaskInstanceId">����ʵ��Id</param>
        /// <param name="operContent">������</param>
        /// <param name="operRule">�������</param>
        /// <param name="operRealtion">�����ϵ</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public static bool AssignGroup(string userId, string workFlowId, string workTaskId, string workFlowInstanceId,
                                      string WorkTaskInstanceId, OperParameter operParam)
        {

            //DebugHF.WriteErrorLog("AssignGroup����������:operContent= " + operParam.OperContent, workFlowInstanceId);
            
            string tmpUser = "";
            string tmpUserName = "";
            if (operParam.OperContent == null || operParam.OperContent == "") return false;
            if (operParam.OperRule == "1")//ֻ����������ʵ��
            {
                //����������ʵ��
                AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
            }
            else
                if (operParam.OperRule == "2")//Ϊÿ�������߲���һ������ʵ��
                {
                    DataTable archUser = UserRoleViewData.ListUserOfGroup(operParam.OperContent);
                    if (archUser == null || archUser.Rows.Count <= 0)
                    {
                        //throw new Exception("����û���ҵ�������,�����Ƿ����ô����ߡ�");
                        //DebugHF.WriteErrorLog("��ɫ[" + operParam.OperContenText + "]û�����ô�����!!!", workFlowInstanceId);
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
        /// ������
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <param name="workFlowId">����ģ��Id</param>
        /// <param name="workTaskId">����ģ��Id</param>
        /// <param name="workFlowInstanceId">����ʵ��Id</param>
        /// <param name="WorkTaskInstanceId">����ʵ��Id</param>
        /// <param name="operContent">������</param>
        /// <param name="operRule">�������</param>
        /// <param name="operRealtion">�����ϵ</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public static bool AssignAll(string userId, string workFlowId, string workTaskId, string workFlowInstanceId,
                                      string WorkTaskInstanceId, OperParameter operParam)
        {

            //DebugHF.WriteErrorLog("AssignAll����������:operContent= " + operParam.OperContent, workFlowInstanceId);

            string tmpUser = "";
            string tmpUserName="";
            if (operParam.OperContent == null || operParam.OperContent == "") return false;
            if (operParam.OperRule == "1")//ֻ����������ʵ��
            {
                //����������ʵ��
                operParam.OperContent = "ALL";
                AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
            }
            else
                if (operParam.OperRule == "2")//Ϊÿ�������߲���һ������ʵ��
                {
                    DataTable dtAllUser = UserData.GetAllUser();
                    if (dtAllUser == null || dtAllUser.Rows.Count <= 0)
                    {
                        //throw new Exception("����û���ҵ�������,�����Ƿ����ô����ߡ�");
                       // DebugHF.WriteErrorLog("������" + operParam.OperContenText + "]û�����ô�����!!!", workFlowInstanceId);
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
        /// �������������
        /// </summary>
        /// <param name="workFlowInstanceId">����ʵ��Id</param>
        /// <returns>���̴�����</returns>
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
        /// ĳһ����ʵ�ʴ�����
       /// </summary>
       /// <param name="workFlowInstanceId">����ʵ��Id</param>
       /// <param name="workTaskInsName">������</param>
       /// <returns>ĳһ����ʵ�ʴ�����</returns>
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
                case 1://�������쵼
                    //����û���������
                    DataTable dtArch = UserData.ArchOfUserTable(operParam.OperContent);//����û���������
                    foreach (DataRow drArch in dtArch.Rows)//����һ�������ڶ������
                    {
                        string archId = drArch["OrgID"].ToString();
                        //��ȡ�������ܸ�λ
                        DataTable dtDuty = mOrgData.GetLeaderOfArch(archId);//��ò������ܸ�λ
                        foreach (DataRow drDuty in dtDuty.Rows)//����һ�������ж�����ܸ�λ
                        {
                            //��ȡ��λ��Ӧ���û�
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
                case 2://���ڲ���
                    DataTable dtinArch = UserData.ArchOfUserTable(operParam.OperContent);//����û���������
                    foreach (DataRow drArch in dtinArch.Rows)//����һ�������ڶ������
                    {
                        string archId = drArch["OrgID"].ToString();
                        string archName = drArch["OrgName"].ToString();
                        operParam.OperContent = archId;
                        operParam.OperContenText = archName;
                        AssignArchitecture(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                    }
                    break;
                case 3://�ϼ�����
                    DataTable dthigArch = UserData.HigherArchOfUserTable(operParam.OperContent);//����û��ϼ�����
                    foreach (DataRow drhigArch in dthigArch.Rows)//�����ж���ϼ�����
                    {
                        string archId = drhigArch["OrgID"].ToString();
                        string archName = drhigArch["OrgName"].ToString();
                        operParam.OperContent = archId;
                        operParam.OperContenText = archName;
                        AssignArchitecture(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                    }
                    break;
                case 4://�¼�����
                    DataTable dtlowArch = UserData.LowerArchOfUserTable(operParam.OperContent);//����û��¼�����
                    foreach (DataRow drlowArch in dtlowArch.Rows)//�����ж���¼�����
                    {
                        string archId = drlowArch["OrgID"].ToString();
                        string archName = drlowArch["OrgName"].ToString();
                        operParam.OperContent = archId;
                        operParam.OperContenText = archName;
                        AssignArchitecture(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                    }
                    break;
                case 5://�ϼ��쵼
                    //����û��ϼ�����
                    DataTable dthigldrArch = UserData.HigherArchOfUserTable(operParam.OperContent);//����û��ϼ�����
                    foreach (DataRow drhigldrArch in dthigldrArch.Rows)//�����ж���ϼ�����(һ�˶ಿ�ŵ����)
                    {
                        string archId = drhigldrArch["OrgID"].ToString();
                        //��ȡ�������ܸ�λ
                        DataTable dtDuty = mOrgData.GetLeaderOfArch(archId);//��ò������ܸ�λ
                        foreach (DataRow drDuty in dtDuty.Rows)//����һ�������ж�����ܸ�λ
                        {
                            //��ȡ��λ��Ӧ���û�
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
                case 6://�¼��쵼
                    //����û��¼�����
                    DataTable dtlowldrArch = UserData.LowerArchOfUserTable(operParam.OperContent);//����û��¼�����
                    foreach (DataRow drlowldrArch in dtlowldrArch.Rows)//�����ж���¼�����(һ�˶ಿ�ŵ����)
                    {
                        string archId = drlowldrArch["OrgID"].ToString();
                        //��ȡ�������ܸ�λ
                        DataTable dtDuty = mOrgData.GetLeaderOfArch(archId);//��ò������ܸ�λ
                        foreach (DataRow drDuty in dtDuty.Rows)//����һ�������ж�����ܸ�λ
                        {
                            //��ȡ��λ��Ӧ���û�
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
                case 1://�������쵼
                    DataTable dtDuty = mOrgData.GetLeaderOfArch(operParam.OperContent);//��ò������ܸ�λ
                    foreach (DataRow drDuty in dtDuty.Rows)//����һ�������ж�����ܸ�λ
                    {
                        //��ȡ��λ��Ӧ���û�
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
                case 2://�޴����
                    break;
                case 3://�ϼ�����,һ������ֻ��һ���ϼ�����
                    string fatherId = mOrgData.GetFatherArchId(operParam.OperContent);
                    mOrgData arh = new mOrgData();
                    arh.GetArchitecture(fatherId);
                    operParam.OperContent = fatherId;
                    operParam.OperContenText = arh.ArchCaption;
                    AssignArchitecture(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                    break;
                case 4://�¼�����
                    DataTable dtlowArch = mOrgData.GetLowerArch(operParam.OperContent);
                    
                    foreach (DataRow drlowArch in dtlowArch.Rows)//�����ж���¼�����
                    {
                        string archId = drlowArch["OrgID"].ToString();
                        mOrgData arhcp = new mOrgData();
                        arhcp.GetArchitecture(archId);
                        operParam.OperContent = archId;
                        operParam.OperContenText = arhcp.ArchCaption;
                        AssignArchitecture(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                    }
                    break;
                case 5://�ϼ������쵼
                    fatherId = mOrgData.GetFatherArchId(operParam.OperContent);
                    dtDuty = mOrgData.GetLeaderOfArch(fatherId);//��ò������ܸ�λ
                    foreach (DataRow drDuty in dtDuty.Rows)//����һ�������ж�����ܸ�λ
                    {
                        //��ȡ��λ��Ӧ���û�
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
                case 6://�¼������쵼
                    dtlowArch = mOrgData.GetLowerArch(operParam.OperContent);
                    foreach (DataRow drlowArch in dtlowArch.Rows)//�����ж���¼�����
                    {
                        string archId = drlowArch["OrgID"].ToString();
                        //��ȡ�������ܸ�λ
                        dtDuty = mOrgData.GetLeaderOfArch(archId);//��ò������ܸ�λ
                        foreach (DataRow drDuty in dtDuty.Rows)//����һ�������ж�����ܸ�λ
                        {
                            //��ȡ��λ��Ӧ���û�
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
