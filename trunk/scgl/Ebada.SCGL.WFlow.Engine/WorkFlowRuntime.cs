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
        /// 用户Id
        /// </summary>
        public string UserId="";
        /**//// <summary>
        /// 流程模版的Id
        /// </summary>
        public string WorkFlowId="";
        /**//// <summary>
        /// 任务模版的Id
        /// </summary>
        public string WorkTaskId="";
        /**//// <summary>
        /// 流程实例的Id
        /// </summary>
        public string WorkFlowInstanceId="";
        /**//// <summary>
        /// 任务实例的Id
        /// </summary>
        public string WorkTaskInstanceId="";
        /**//// <summary>
        /// 处理者实例的Id
        /// </summary>
        public string OperatorInstanceId = "";
        /**//// <summary>
        /// 执行的命令名
        /// </summary>
        public string CommandName="";
        /**//// <summary>
        /// 流程编号
        /// </summary>
        public string WorkFlowNo = "";
        /**//// <summary>
        /// 流程流程实例的名称
        /// </summary>
        public string WorkflowInsCaption = "";
        /**//// <summary>
        /// 流程流程实例说明信息
        /// </summary>
        public string Description = "";
        /**//// <summary>
        /// 流程流程实例优先级
        /// </summary>
        public string Priority = "1";
        /**//// <summary>
        /// 流程流程实例状态
        /// </summary>
        public string Status = "2";
        /**//// <summary>
        /// 流程流程实例当前任务节点
        /// </summary>
        public string NowTaskId = "";
       
        /**//// <summary>
        /// 是否是子流程
        /// </summary>
        public bool isSubWorkflow = false;
        /**//// <summary>
        /// 草稿状态，只保存不提交
        /// </summary>
        public bool IsDraft = false;
        /**//// <summary>
        /// 主流程实例Id
        /// </summary>
        public string MainWorkflowInsId = "";
        /**//// <summary>
        /// 主任务模板Id,即子流程任务节点的Id
        /// </summary>
        public string MainWorktaskId = "";
        /**//// <summary>
        /// 主流程模板Id
        /// </summary>
        public string MainWorkflowId = "";
        /**//// <summary>
        /// 主任务实例Id，进入子节点前的任务节点实例
        /// </summary>
        public string MainWorktaskInsId = "";
        /**//// <summary>
        /// 指派任务接受用户Id
        /// </summary>
        public string AssignUserId = "";
        public delegate void RunSuccessEventHandler(Object sender, WorkFlowEventArgs e);
        public delegate void RunFailEventHandler(Object sender, WorkFlowEventArgs e);  
        /**//// <summary>
        /// 流程流转成功，流转动作包括提交等
        /// </summary>
        public event  RunSuccessEventHandler RunSuccess;
        /**//// <summary>
        /// 流程流转失败，流转动作包括提交等
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
                if (WorkFlowHelper.isTaskInsCompleted(WorkTaskInstanceId)) return WorkFlowConst.InstanceIsCompletedCode;//流程实例已完成，不能重复提交
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
        /// 提交流程
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
       /// 启动流程，草稿和启动两种状态
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
                if (WorkFlowHelper.isTaskInsCompleted(WorkTaskInstanceId)) return WorkFlowConst.InstanceIsCompletedCode;//流程实例已完成，不能重复提交
                
                //检查是否已经保存过草稿。如果已经保存过则不需要再创建实例，只保存业务表单数据,
                //此处的处理与交互节点的处理不同，需要加判断。

                if (WorkTaskInstance.Exists(WorkTaskInstanceId)==false)//实例不存在，说明未保存过
                {
                    //创建流程实例
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
                    workflowInstance.NowTaskId = WorkTaskId;//当前流程所处流程模板的位置
                    workflowInstance.isSubWorkflow = isSubWorkflow;
                    workflowInstance.MainWorkflowInsId = MainWorkflowInsId;
                    workflowInstance.MainWorktaskId = MainWorktaskId;
                    workflowInstance.MainWorkflowId = MainWorkflowId;
                    workflowInstance.MainWorktaskInsId = MainWorktaskInsId;
                    workflowInstance.Create();
                    //创建启动节点的任务实例
                    WorkTaskInstance workTaskInstance = new WorkTaskInstance();
                    workTaskInstance.WorkflowId = WorkFlowId;
                    workTaskInstance.WorktaskId = WorkTaskId;
                    workTaskInstance.WorkflowInsId = WorkFlowInstanceId;
                    workTaskInstance.WorktaskInsId = WorkTaskInstanceId;

                    workTaskInstance.TaskInsCaption = WorkFlowTask.GetTaskCaption(WorkTaskId);
                    if (isSubWorkflow)//是子流程调用，需要放到未认领任务中
                    {
                        //workTaskInstance.PreviousTaskId = WorkTaskInstanceId;
                        workTaskInstance.PreviousTaskId = MainWorktaskInsId;
                        workTaskInstance.Status = "1";
                    }
                    else//不是子流程调用,启动节点直接放入已认领任务中
                    {
                        workTaskInstance.PreviousTaskId = WorkTaskInstanceId;//开始节点的前一节点等于自己 
                        if (IsDraft) workTaskInstance.Status = "1";
                        else
                        workTaskInstance.Status = "2";
                    }
                    workTaskInstance.Create();

                    //创建启动节点的处理人实例
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
                        userName = "未找到处理人";
                    operatorInstance.OperContentText = userName;
                    operatorInstance.OperType = 3;
                    if (isSubWorkflow)//是子流程调用，需要放到未认领任务中
                        operatorInstance.OperStatus = "0";
                    else//不是子流程调用,启动节点直接放入已认领任务中
                    {
                        if (IsDraft) operatorInstance.OperStatus = "0";
                        else
                        operatorInstance.OperStatus = "3";
                    }

                    operatorInstance.Create();
                }
                if (!IsDraft)//不是草稿状态，提交任务
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
                RunSuccess(this, e);//提交成功后触发成功事件
 
        }
        public virtual void OnRunFail(Object sender, WorkFlowEventArgs e)
        {
            if (RunFail != null)
                RunFail(this, e);
        }

        /**//// <summary>
        /// 任务指派
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
        /// 任务认领
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
        /// 取消认领任务
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
        /// 任务取回
        /// </summary>
        public void TaskRetake()
        {
            throw new System.NotImplementedException();
        }
        /**//// <summary>
        /// 任务退回
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
        /// 流程挂起
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
        /// 任务授权
        /// </summary>
        /// <param name="fromUserId">授权UserId</param>
        /// <param name="toUserId">被授权UserId</param>
        /// <param name="workflowId">流程模板Id</param>
        /// <param name="worktaskId">任务模板Id</param>
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
