using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HF.WorkFlow.Engine;
using Ebada.SCGL.WFlow.Tool;

namespace Ebada.SCGL.WFlow.Engine
{
   
    public class WorkFlowRuntime
    {
        /**//// <summary>
        /// �û�Id
        /// </summary>
        public string UserId="";
        /**//// <summary>
        /// ����ģ���Id
        /// </summary>
        public string WorkFlowId="";
        /**//// <summary>
        /// ����ģ���Id
        /// </summary>
        public string WorkTaskId="";
        /**//// <summary>
        /// ����ʵ����Id
        /// </summary>
        public string WorkFlowInstanceId="";
        /**//// <summary>
        /// ����ʵ����Id
        /// </summary>
        public string WorkTaskInstanceId="";
        /**//// <summary>
        /// ������ʵ����Id
        /// </summary>
        public string OperatorInstanceId = "";
        /**//// <summary>
        /// ִ�е�������
        /// </summary>
        public string CommandName="";
        /**//// <summary>
        /// ���̱��
        /// </summary>
        public string WorkFlowNo = "";
        /**//// <summary>
        /// ��������ʵ��������
        /// </summary>
        public string WorkflowInsCaption = "";
        /**//// <summary>
        /// ��������ʵ��˵����Ϣ
        /// </summary>
        public string Description = "";
        /**//// <summary>
        /// ��������ʵ�����ȼ�
        /// </summary>
        public string Priority = "1";
        /**//// <summary>
        /// ��������ʵ��״̬
        /// </summary>
        public string Status = "2";
        /**//// <summary>
        /// ��������ʵ����ǰ����ڵ�
        /// </summary>
        public string NowTaskId = "";
       
        /**//// <summary>
        /// �Ƿ���������
        /// </summary>
        public bool isSubWorkflow = false;
        /**//// <summary>
        /// �ݸ�״̬��ֻ���治�ύ
        /// </summary>
        public bool IsDraft = false;
        /**//// <summary>
        /// ������ʵ��Id
        /// </summary>
        public string MainWorkflowInsId = "";
        /**//// <summary>
        /// ������ģ��Id,������������ڵ��Id
        /// </summary>
        public string MainWorktaskId = "";
        /**//// <summary>
        /// ������ģ��Id
        /// </summary>
        public string MainWorkflowId = "";
        /**//// <summary>
        /// ������ʵ��Id�������ӽڵ�ǰ������ڵ�ʵ��
        /// </summary>
        public string MainWorktaskInsId = "";
        /**//// <summary>
        /// ָ����������û�Id
        /// </summary>
        public string AssignUserId = "";
        public delegate void RunSuccessEventHandler(Object sender, WorkFlowEventArgs e);
        public delegate void RunFailEventHandler(Object sender, WorkFlowEventArgs e);  
        /**//// <summary>
        /// ������ת�ɹ�����ת���������ύ��
        /// </summary>
        public event  RunSuccessEventHandler RunSuccess;
        /**//// <summary>
        /// ������תʧ�ܣ���ת���������ύ��
        /// </summary>
        public event RunFailEventHandler RunFail;
        public WorkFlowRuntime()
        {
            
        }
        public string Run()
        {
            try
            {
                if (string.IsNullOrEmpty(UserId))     return WorkFlowConst.IsNullUserIdCode;
                if (string.IsNullOrEmpty(WorkFlowId)) return WorkFlowConst.IsNullWorkFlowIdCode;
                if (string.IsNullOrEmpty(WorkTaskId)) return WorkFlowConst.IsNullWorkTaskIdCode;
                if (string.IsNullOrEmpty(WorkFlowInstanceId)) return WorkFlowConst.IsNullWorkFlowInsIdCode;
                if (string.IsNullOrEmpty(WorkTaskInstanceId)) return WorkFlowConst.IsNullWorkTaskInsIdCode;
                if (string.IsNullOrEmpty(OperatorInstanceId)) return WorkFlowConst.IsNullOperatorInsIdCode;
                if (string.IsNullOrEmpty(CommandName)) return WorkFlowConst.IsNullCommandNameCode;
                if (WorkFlowHelper.isTaskInsCompleted(WorkTaskInstanceId)) return WorkFlowConst.InstanceIsCompletedCode;//����ʵ������ɣ������ظ��ύ
                string result= WorkFlowHelper.CreateNextTaskInstance(UserId, WorkFlowId, WorkTaskId, WorkFlowInstanceId, WorkTaskInstanceId, OperatorInstanceId, CommandName);
                if (result != WorkFlowConst.SuccessCode)
                {
                    WorkFlowEventArgs e = new WorkFlowEventArgs(this);
                    e.ResultMsg = result;
                    OnRunFail(this, e);
                    return result;
                }
                else
                {
                    WorkFlowEventArgs e = new WorkFlowEventArgs(this);
                    e.ResultMsg = WorkFlowConst.SuccessMsg;
                    OnRunSuccess(this, e);
                }
                return WorkFlowConst.SuccessCode;
            }
            catch (Exception ex)
            {
                string msg =string.Format(WorkFlowConst.EngineErrorMsg,ex.Message);
                WorkFlowEventArgs e = new WorkFlowEventArgs(this);
                e.ResultMsg = msg;
                OnRunFail(this, e);
                return WorkFlowConst.OtherErrorCode;
            }
        }
        /**//// <summary>
        /// �ύ����
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="operatorInsId"></param>
        /// <param name="commandName"></param>
        public string Run(string userid, string operatorInsId, string commandName)
        {
            if (string.IsNullOrEmpty(userid)) return WorkFlowConst.IsNullUserIdCode;
            if (string.IsNullOrEmpty(operatorInsId)) return WorkFlowConst.IsNullOperatorInsIdCode;
            if (string.IsNullOrEmpty(commandName)) return WorkFlowConst.IsNullCommandNameCode;
            DataTable operdt = OperatorInstance.GetOperatorInstance(operatorInsId);
            if (operdt != null && operdt.Rows.Count > 0)
            {
                WorkFlowId = operdt.Rows[0]["workflowId"].ToString();
                WorkTaskId = operdt.Rows[0]["WorkTaskId"].ToString();
                WorkFlowInstanceId = operdt.Rows[0]["workflowInsId"].ToString();
                WorkTaskInstanceId = operdt.Rows[0]["worktaskInsId"].ToString();
                UserId = userid;
                OperatorInstanceId = operatorInsId;
                CommandName = commandName;
                return Run();
            }
            else
            {
                return WorkFlowConst.NoFoundInstanceCode;
            }

        }
       /**//// <summary>
       /// �������̣��ݸ����������״̬
       /// </summary>
        public string Start()
        {
            try
            {
                if (string.IsNullOrEmpty(WorkFlowInstanceId))
                    WorkFlowInstanceId = Guid.NewGuid().ToString();
                if (string.IsNullOrEmpty(WorkTaskInstanceId))
                    WorkTaskInstanceId = Guid.NewGuid().ToString();
                if (string.IsNullOrEmpty(OperatorInstanceId))
                    OperatorInstanceId = Guid.NewGuid().ToString();
                if (string.IsNullOrEmpty(UserId))      return WorkFlowConst.IsNullUserIdCode;
                if (string.IsNullOrEmpty(WorkFlowId))  return WorkFlowConst.IsNullWorkFlowIdCode;
                if (string.IsNullOrEmpty(WorkTaskId))  return WorkFlowConst.IsNullWorkTaskIdCode;
                if (string.IsNullOrEmpty(CommandName)) return WorkFlowConst.IsNullCommandNameCode;
                if (string.IsNullOrEmpty(WorkFlowNo))  return WorkFlowConst.IsNullWorkFlowNoCode;
                if (string.IsNullOrEmpty(WorkflowInsCaption)) return WorkFlowConst.IsNullWorkflowInsCaption;
                if (WorkFlowHelper.isTaskInsCompleted(WorkTaskInstanceId)) return WorkFlowConst.InstanceIsCompletedCode;//����ʵ������ɣ������ظ��ύ
                
                //����Ƿ��Ѿ�������ݸ塣����Ѿ����������Ҫ�ٴ���ʵ����ֻ����ҵ�������,
                //�˴��Ĵ����뽻���ڵ�Ĵ���ͬ����Ҫ���жϡ�

                if (WorkTaskInstance.Exists(WorkTaskInstanceId)==false)//ʵ�������ڣ�˵��δ�����
                {
                    //��������ʵ��
                    WorkFlowInstance workflowInstance = new WorkFlowInstance();
                    workflowInstance.WorkflowId = WorkFlowId;
                    workflowInstance.WorkflowInsId = WorkFlowInstanceId;
                    workflowInstance.WorkflowNo = WorkFlowNo;
                    workflowInstance.WorkflowInsCaption = WorkflowInsCaption;
                    workflowInstance.Description = Description;
                    workflowInstance.Priority = Priority;
                    if (IsDraft) workflowInstance.Status = "1";
                    else
                    workflowInstance.Status = Status;
                    workflowInstance.NowTaskId = WorkTaskId;//��ǰ������������ģ���λ��
                    workflowInstance.isSubWorkflow = isSubWorkflow;
                    workflowInstance.MainWorkflowInsId = MainWorkflowInsId;
                    workflowInstance.MainWorktaskId = MainWorktaskId;
                    workflowInstance.MainWorkflowId = MainWorkflowId;
                    workflowInstance.MainWorktaskInsId = MainWorktaskInsId;
                    workflowInstance.Create();
                    //���������ڵ������ʵ��
                    WorkTaskInstance workTaskInstance = new WorkTaskInstance();
                    workTaskInstance.WorkflowId = WorkFlowId;
                    workTaskInstance.WorktaskId = WorkTaskId;
                    workTaskInstance.WorkflowInsId = WorkFlowInstanceId;
                    workTaskInstance.WorktaskInsId = WorkTaskInstanceId;

                    workTaskInstance.TaskInsCaption = WorkFlowTask.GetTaskCaption(WorkTaskId);
                    if (isSubWorkflow)//�������̵��ã���Ҫ�ŵ�δ����������
                    {
                        //workTaskInstance.PreviousTaskId = WorkTaskInstanceId;
                        workTaskInstance.PreviousTaskId = MainWorktaskInsId;
                        workTaskInstance.Status = "1";
                    }
                    else//���������̵���,�����ڵ�ֱ�ӷ���������������
                    {
                        workTaskInstance.PreviousTaskId = WorkTaskInstanceId;//��ʼ�ڵ��ǰһ�ڵ�����Լ� 
                        if (IsDraft) workTaskInstance.Status = "1";
                        else
                        workTaskInstance.Status = "2";
                    }
                    workTaskInstance.Create();

                    //���������ڵ�Ĵ�����ʵ��
                    OperatorInstance operatorInstance = new OperatorInstance();
                    operatorInstance.OperatorInsId = OperatorInstanceId;
                    operatorInstance.WorkflowId = WorkFlowId;
                    operatorInstance.WorktaskId = WorkTaskId;
                    operatorInstance.WorkflowInsId = WorkFlowInstanceId;
                    operatorInstance.WorktaskInsId = WorkTaskInstanceId;
                    operatorInstance.UserId = UserId;
                    operatorInstance.OperRealtion = 0;
                    operatorInstance.OperContent = UserId;
                    string userName = UserData.GetUserNameById(UserId);
                    if (string.IsNullOrEmpty(userName))
                        userName = "δ�ҵ�������";
                    operatorInstance.OperContentText = userName;
                    operatorInstance.OperType = 3;
                    if (isSubWorkflow)//�������̵��ã���Ҫ�ŵ�δ����������
                        operatorInstance.OperStatus = "0";
                    else//���������̵���,�����ڵ�ֱ�ӷ���������������
                    {
                        if (IsDraft) operatorInstance.OperStatus = "0";
                        else
                        operatorInstance.OperStatus = "3";
                    }

                    operatorInstance.Create();
                }
                if (!IsDraft)//���ǲݸ�״̬���ύ����
                {
                    string result= WorkFlowHelper.CreateNextTaskInstance(UserId, WorkFlowId, WorkTaskId, WorkFlowInstanceId, WorkTaskInstanceId, OperatorInstanceId, CommandName);
                    if (result != WorkFlowConst.SuccessCode)
                    {
                        WorkFlowEventArgs e = new WorkFlowEventArgs(this);
                        e.ResultMsg = result;
                        OnRunFail(this, e);
                        return result;
                    }
                    else
                    {
                        WorkFlowEventArgs e = new WorkFlowEventArgs(this);
                        e.ResultMsg = WorkFlowConst.SuccessMsg;
                        OnRunSuccess(this, e);
                    }
                }
                return WorkFlowConst.SuccessCode;
            }
            catch (Exception ex)
            {
                string msg = string.Format(WorkFlowConst.EngineErrorMsg, ex.Message);
                WorkFlowEventArgs e = new WorkFlowEventArgs(this);
                e.ResultMsg = msg;
                OnRunFail(this, e);
                return WorkFlowConst.OtherErrorCode;
            }
           
  
        }

        public virtual void OnRunSuccess(Object sender, WorkFlowEventArgs e)
        {
            if (RunSuccess != null)
                RunSuccess(this, e);//�ύ�ɹ��󴥷��ɹ��¼�
 
        }
        public virtual void OnRunFail(Object sender, WorkFlowEventArgs e)
        {
            if (RunFail != null)
                RunFail(this, e);
        }

        /**//// <summary>
        /// ����ָ��
        /// </summary>
        public string TaskAssign()
        {
            try
            {
                if (string.IsNullOrEmpty(UserId)) return WorkFlowConst.IsNullUserIdCode;
                if (string.IsNullOrEmpty(AssignUserId)) return WorkFlowConst.IsNullUserIdCode;
                if (string.IsNullOrEmpty(OperatorInstanceId)) return WorkFlowConst.IsNullOperatorInsIdCode;
                return WorkTaskInstance.WorkTaskAssign(UserId, AssignUserId, OperatorInstanceId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**//// <summary>
        /// ��������
        /// </summary>

        public string TaskClaim()
        {
            try
            {
                if (string.IsNullOrEmpty(UserId)) return WorkFlowConst.IsNullUserIdCode;
                if (string.IsNullOrEmpty(OperatorInstanceId)) return WorkFlowConst.IsNullOperatorInsIdCode;
                return  WorkTaskInstance.WorkTaskClaim(UserId, OperatorInstanceId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**//// <summary>
        /// ȡ����������
        /// </summary>
        public string TaskUnClaim()
        {
            try
            {
                if (string.IsNullOrEmpty(UserId)) return WorkFlowConst.IsNullUserIdCode;
                if (string.IsNullOrEmpty(OperatorInstanceId)) return WorkFlowConst.IsNullOperatorInsIdCode;
                return WorkTaskInstance.WorkTaskUnClaim(UserId, OperatorInstanceId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**//// <summary>
        /// ����ȡ��
        /// </summary>
        public void TaskRetake()
        {
            throw new System.NotImplementedException();
        }
        /**//// <summary>
        /// �����˻�
        /// </summary>
        public string TaskBack()
        {
            try
            {
                if (string.IsNullOrEmpty(UserId)) return WorkFlowConst.IsNullUserIdCode;
                if (string.IsNullOrEmpty(OperatorInstanceId)) return WorkFlowConst.IsNullOperatorInsIdCode;
                return WorkTaskInstance.WorkTaskBack(UserId, OperatorInstanceId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// ���̹���
        /// </summary>
        public string SetSuspend(string workflowInsId)
        {
            try
            {
                if (string.IsNullOrEmpty(workflowInsId)) return WorkFlowConst.IsNullWorkFlowInsIdCode;
                return WorkFlowInstance.SetSuspend(workflowInsId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// ������Ȩ
        /// </summary>
        /// <param name="fromUserId">��ȨUserId</param>
        /// <param name="toUserId">����ȨUserId</param>
        /// <param name="workflowId">����ģ��Id</param>
        /// <param name="worktaskId">����ģ��Id</param>
        /// <returns></returns>
        public string  AssignAccredit(string fromUserId, string toUserId, string workflowId, string worktaskId)
        {
            try
            {
                AccreditUser au = new AccreditUser();
                au.AUserId = Guid.NewGuid().ToString();
                au.AccreditFromUserId = fromUserId;
                au.AccreditToUserId = toUserId;
                au.AcWorkflowId = workflowId;
                au.AcWorktaskId = worktaskId;
                au.Insert();
                return WorkFlowConst.SuccessCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

    }
}
