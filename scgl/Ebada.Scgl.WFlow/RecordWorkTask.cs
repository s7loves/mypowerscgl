using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Client.Platform;
using System.Data;
using Ebada.SCGL.WFlow.Tool;
using Ebada.SCGL.WFlow.Engine;
using Ebada.Scgl.Model;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Ebada.Scgl.WFlow
{
    public class AttributeHelper
    {
        public static string GetDisplayName(Type modelType, string propertyDisplayName)
        {
            return (System.ComponentModel.TypeDescriptor.GetProperties(modelType)[propertyDisplayName].Attributes[typeof(System.ComponentModel.DisplayNameAttribute)] as System.ComponentModel.DisplayNameAttribute).DisplayName;
        }
    }
    public class RecordWorkTask
    {

    
    
 
        /// <summary>
        /// 获得当前用户是否可以新建运行分析记录权限
        /// </summary>
        /// <param name="recordIkind">运行分析记录种类</param>
        /// <returns>bool true有权限 false 无权限</returns>
        public static bool HaveRewNewYXFXRole(string recordIkind)
        {
            if (MainHelper.UserOrg.OrgName.IndexOf("供电所") > -1)
            {
                if (recordIkind=="定期分析")
                return WorkFlowTemplate.GetSelectedNameWorkFlows(MainHelper.User.UserID, "供电所定期分析").Rows.Count > 0 ? true : false;
                else if (recordIkind == "专题分析")
                    return WorkFlowTemplate.GetSelectedNameWorkFlows(MainHelper.User.UserID, "供电所专题分析").Rows.Count > 0 ? true : false;

                return false;
            }
            else if (MainHelper.UserOrg.OrgName.IndexOf("局") > -1)
            {
                if (recordIkind == "定期分析")
                return WorkFlowTemplate.GetSelectedNameWorkFlows(MainHelper.User.UserID, "局定期分析").Rows.Count > 0 ? true : false;
                else if (recordIkind == "专题分析")
                    return WorkFlowTemplate.GetSelectedNameWorkFlows(MainHelper.User.UserID, "局专题分析").Rows.Count > 0 ? true : false;
                return false;
            }
            else
                return false;
        }
        /// <summary>
        /// 获得当前用户是否可以运行当前分析记录权限
        /// </summary>
        /// <returns></returns>
        public static bool HaveRunYXFXRole(string recordID)
        {
            IList<WFP_RecordWorkTaskIns> wf = MainHelper.PlatformSqlMap.GetList<WFP_RecordWorkTaskIns>("SelectWFP_RecordWorkTaskInsList", "where RecordID='" + recordID + "'");
            if (wf.Count == 0) return false;
            DataTable dt = WorkFlowInstance.SelectedWorkflowClaimingTask(MainHelper.User.UserID, wf[0].WorkFlowId, wf[0].WorkFlowInsId, 999);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
                return false;
        }
        /// <summary>
        /// 获得当前用户可以运行当前记录的流程信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetYXFXRecord(string recordID)
        {
            DataTable dtnull = new DataTable();
            IList<WFP_RecordWorkTaskIns> wf = MainHelper.PlatformSqlMap.GetList<WFP_RecordWorkTaskIns>("SelectWFP_RecordWorkTaskInsList", "where RecordID='" + recordID + "'");
            if (wf.Count == 0) return dtnull;
            DataTable dt = WorkFlowInstance.SelectedWorkflowClaimingTask(MainHelper.User.UserID, wf[0].WorkFlowId, wf[0].WorkFlowInsId, 999);
           
            return dt;
        }
        /// <summary>
        /// 获得流程图片（Bitmap）
        /// </summary>
        /// <param name="recordID">记录ID</param>
        /// <param name="sz">图片大小</param>
        /// <returns>Bitmap</returns>
        public static Bitmap WorkFlowBitmap(string recordID,Size sz)
        {
            Bitmap objBitmap = new Bitmap(sz.Width, sz.Height );
            IList<WFP_RecordWorkTaskIns> wf = MainHelper.PlatformSqlMap.GetList<WFP_RecordWorkTaskIns>("SelectWFP_RecordWorkTaskInsList", "where RecordID='" + recordID + "'");
            if (wf.Count == 0) return null;
            objBitmap=WorkFlowInstance.WorkFlowBitmap(wf[0].WorkFlowId, wf[0].WorkFlowInsId, sz);
            //System.IO.MemoryStream _ImageMem = new System.IO.MemoryStream();
            //objBitmap.Save(recordID + ".jpg", ImageFormat.Jpeg);
            //objBitmap.Save(_ImageMem, ImageFormat.Bmp);
            //byte[] _ImageBytes = _ImageMem.GetBuffer();
            return objBitmap;
        }
       /// <summary>
        /// 创建运行分析流程
       /// </summary>
       /// <param name="recordID">记录ID</param>
        /// <param name="recordIkind">运行分析记录种类</param>
       /// <returns>流程创建结果</returns>
        public static string RunNewYXFXRecord(string recordID, string recordIkind)
        {
            DataTable dt = null;
            string command = "", workFlowId = "", workTaskId = "", flowCaption = "", workFlowInstanceId = "", workTaskInstanceId = "";
            if (MainHelper.UserOrg.OrgName.IndexOf("供电所") > -1)
            {
                if (recordIkind == "定期分析")
                {
                    dt = WorkFlowTemplate.GetSelectedNameWorkFlows(MainHelper.User.UserID, "供电所定期分析");
                }
                else if (recordIkind == "专题分析")
                {
                    dt = WorkFlowTemplate.GetSelectedNameWorkFlows(MainHelper.User.UserID, "供电所专题分析");
                }

                
            }
            else if (MainHelper.UserOrg.OrgName.IndexOf("局") > -1)
            {
                if (recordIkind == "定期分析")
                {
                    dt = WorkFlowTemplate.GetSelectedNameWorkFlows(MainHelper.User.UserID, "局定期分析");
                }
                else if (recordIkind == "专题分析")
                {
                    dt = WorkFlowTemplate.GetSelectedNameWorkFlows(MainHelper.User.UserID, "局专题分析");
                }


            }
            workFlowId = dt.Rows[0]["WorkFlowId"].ToString();
            workTaskId = dt.Rows[0]["workTaskId"].ToString();
            flowCaption=dt.Rows[0]["FlowCaption"].ToString();
            workFlowInstanceId=Guid.NewGuid().ToString();
            workTaskInstanceId = Guid.NewGuid().ToString();
            DataTable taskCommand = WorkFlowTask.GetTaskCommands(workFlowId,workTaskId);
            if (taskCommand.Rows.Count > 0)
            {
                command = taskCommand.Rows[0]["CommandName"].ToString();
            }
            else
            {
                command = "提交";
            }
            string strmes = CreatWorkFlow(MainHelper.User.UserID, workFlowId, workTaskId, workFlowInstanceId, workTaskInstanceId, flowCaption, command);
           
            WFP_RecordWorkTaskIns wpfrecord = new WFP_RecordWorkTaskIns();
            wpfrecord.RecordID = recordID;
            wpfrecord.WorkFlowId = workFlowId;
            wpfrecord.WorkFlowInsId  = workFlowInstanceId;
            wpfrecord.WorkTaskId = workTaskId;
            wpfrecord.WorkTaskInsId = workTaskInstanceId;
          
            if ( strmes.IndexOf("未提交至任何人")== -1) MainHelper.PlatformSqlMap.Create<WFP_RecordWorkTaskIns>(wpfrecord);


            return strmes;
        }
        /// <summary>
        /// 删除指定记录相关的记录
        /// </summary>
        /// <param name="recordID">记录ID</param>
        public static void DeleteRecord(string recordID)
        {
            MainHelper.PlatformSqlMap.DeleteByWhere<PJ_gzrjnr>(" where ParentID='" + recordID + "'");
            IList<WFP_RecordWorkTaskIns> wf = MainHelper.PlatformSqlMap.GetList<WFP_RecordWorkTaskIns>("SelectWFP_RecordWorkTaskInsList", "where RecordID='" + recordID + "'");
            if (wf.Count == 0) return ;
            {
                MainHelper.PlatformSqlMap.Delete<WFP_RecordWorkTaskIns>(wf[0]);
                MainHelper.PlatformSqlMap.DeleteByWhere<WF_OperatorInstance>(" where WorkFlowInsId='" + wf[0].WorkFlowInsId  + "'");
                MainHelper.PlatformSqlMap.DeleteByWhere<WF_WorkTaskInstance>(" where WorkFlowInsId='" + wf[0].WorkFlowInsId + "'");
                MainHelper.PlatformSqlMap.DeleteByWhere<WF_WorkFlowInstance>(" where WorkFlowInsId='" + wf[0].WorkFlowInsId + "'");
            }
            
            //return "";
        }
        
        /// <summary>
        /// 创建流程
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="WorkFlowId">流程ID</param>
        /// <param name="workTaskId">任务ID</param>
        /// <param name="workFlowInstanceId">流程实例ID</param>
        /// <param name="WorkTaskInstanceId">任务实例ID</param>
        /// <param name="FlowCaption">流程名称</param>
        /// <param name="command">按钮命令名称</param>
        /// <returns>返回流程执行结果</returns>
        
        public static string CreatWorkFlow(string userID, string WorkFlowId, string workTaskId, string workFlowInstanceId, string WorkTaskInstanceId, string FlowCaption, string command)
        {

            WorkFlowRuntime wfruntime = new WorkFlowRuntime();
            wfruntime.UserId = userID;
            wfruntime.WorkFlowId = WorkFlowId;
            wfruntime.WorkTaskId = workTaskId;
            wfruntime.WorkFlowInstanceId = workFlowInstanceId;
            wfruntime.WorkTaskInstanceId = WorkTaskInstanceId;
            wfruntime.WorkFlowNo = WorkFlowInstance.GetWorkflowNO();
            wfruntime.CommandName = command;
            wfruntime.WorkflowInsCaption = FlowCaption;
            wfruntime.IsDraft = false;//保存并执行流程流转
            wfruntime.Start();

            return Toollips(wfruntime.WorkTaskInstanceId);
            //return "";
        }
       /// <summary>
        /// 执行流程
       /// </summary>
        /// <param name="userID">用户ID</param>
       /// <param name="OperatorInsId">操作ID</param>
       /// <param name="WorkTaskInsId">任务记录ID</param>
       /// <param name="command">命令名称</param>
       /// <returns>返回流程执行结果</returns>
        public static string RunWorkFlow(string userID, string OperatorInsId, string WorkTaskInsId, string command)
        {
           
            WorkFlowRuntime wfruntime = new WorkFlowRuntime();
            //wfruntime.RunSuccess += new WorkFlowRuntime.RunSuccessEventHandler(wfruntime_RunSuccess);
            //wfruntime.RunFail += new WorkFlowRuntime.RunFailEventHandler(wfruntime_RunFail);
            wfruntime.Run(userID, OperatorInsId, command);
            
            return Toollips(WorkTaskInsId);
            //return "";
        }
        /// <summary>
        /// 返回任务实例的操作结果
        /// </summary>
        /// <param name="workTaskInsId">任务实例ID</param>
        /// <returns>操作结果</returns>
        public static string Toollips(string workTaskInsId)
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
