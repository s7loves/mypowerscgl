using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client.Platform;
using System.Data;
using Ebada.SCGL.WFlow.Tool;
using Ebada.SCGL.WFlow.Engine;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.WFlow
{
    public class RecordWorkTask
    {

        
        /// <summary>
        /// 获得用户是否可以启动运行定期分析权限
        /// </summary>
        /// <returns></returns>
        public static  bool HaveDQFXRole()
        {
            if (MainHelper.UserOrg.OrgName.IndexOf("供电所") > -1)
            {
                return WorkFlowTemplate.GetSelectedNameWorkFlows(MainHelper.User.UserID, "供电所定期分析").Rows.Count > 0 ? true : false;

            }
            else if (MainHelper.UserOrg.OrgName.IndexOf("局") > -1)
            {
                return WorkFlowTemplate.GetSelectedNameWorkFlows(MainHelper.User.UserID, "局定期分析").Rows.Count > 0 ? true : false;

            }
            else
                return false;
        }
        /// <summary>
        /// 生成运行定期分析流程
        /// </summary>
        /// <returns></returns>
        public static string RunNewDQFXRecord(string recordID)
        {
            DataTable dt = null;
            if (MainHelper.UserOrg.OrgName.IndexOf("供电所") > -1)
            {
                dt= WorkFlowTemplate.GetSelectedNameWorkFlows(MainHelper.User.UserID, "供电所定期分析");
                
            }
            else if (MainHelper.UserOrg.OrgName.IndexOf("局") > -1)
            {
                dt= WorkFlowTemplate.GetSelectedNameWorkFlows(MainHelper.User.UserID, "局定期分析");

            }
            WorkFlowRuntime wfruntime = new WorkFlowRuntime();
            wfruntime.UserId = MainHelper.User.UserID;
            wfruntime.WorkFlowId = dt.Rows[0]["WorkFlowId"].ToString();
            wfruntime.WorkTaskId = dt.Rows[0]["workTaskId"].ToString();
            wfruntime.WorkFlowInstanceId = Guid.NewGuid().ToString();
            wfruntime.WorkTaskInstanceId = Guid.NewGuid().ToString();
            wfruntime.WorkFlowNo = WorkFlowInstance.GetWorkflowNO();
            wfruntime.CommandName = "提交";
            wfruntime.WorkflowInsCaption = dt.Rows[0]["FlowCaption"].ToString();
            wfruntime.IsDraft = false;//保存并执行流程流转

            WFP_RecordWorkTaskIns wpfrecord = new WFP_RecordWorkTaskIns();
            wpfrecord.RecordID = recordID;
            wpfrecord.workflowId = wfruntime.WorkFlowId;
            wpfrecord.workflowInsId = wfruntime.WorkFlowInstanceId;
            wpfrecord.worktaskId = wfruntime.WorkTaskId;
            wpfrecord.worktaskInsId = wfruntime.WorkTaskInstanceId;
            MainHelper.PlatformSqlMap.Create<WFP_RecordWorkTaskIns>(wpfrecord);

            wfruntime.Start();
            return toollips(wpfrecord.worktaskInsId);
        }
        public static string toollips(string workTaskInsId)
        {
            string title = "";
            string TaskToWhoMsg = "";
            string ResultMsg = "";

            TaskToWhoMsg = WorkTaskInstance.GetTaskToWhoMsg(workTaskInsId);
            ResultMsg = WorkTaskInstance.GetResultMsg(workTaskInsId);

            title = "操作结果:" + ResultMsg;
            if (TaskToWhoMsg.Length <= 0)
            {
                TaskToWhoMsg = "未提交至任何人,请检查流程模板和组织机构配置是否正确!";
                if (ResultMsg == WorkFlowConst.WorkflowOverMsg)//流程结束
                {
                    TaskToWhoMsg = "流程结束!";
                }
                if (ResultMsg == WorkFlowConst.TaskBackMsg)
                {
                    TaskToWhoMsg = WorkFlowConst.TaskBackMsg;
                }
            }

            return TaskToWhoMsg = "成功提交至:" + TaskToWhoMsg + "。你已完成该任务处理,可以关闭该窗口。";
        }

    }
}
