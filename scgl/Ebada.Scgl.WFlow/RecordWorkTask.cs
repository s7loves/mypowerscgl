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
        /// 获得当前用户是否可以新建运行定期分析记录权限
        /// </summary>
        /// <returns></returns>
        public static  bool HaveRewNewDQFXRole()
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
        /// 获得当前用户是否可以运行当前定期分析记录权限
        /// </summary>
        /// <returns></returns>
        public static bool HaveRunDQFXRole(string recordID)
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
        public static DataTable GetDQFXRecord(string recordID)
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
            wpfrecord.WorkFlowId  = wfruntime.WorkFlowId;
            wpfrecord.WorkFlowInsId  = wfruntime.WorkFlowInstanceId;
            wpfrecord.WorkTaskId  = wfruntime.WorkTaskId;
            wpfrecord.WorkTaskInsId = wfruntime.WorkTaskInstanceId;
            wfruntime.Start();
            string strmes = Toollips(wpfrecord.WorkTaskInsId);
            if ( strmes.IndexOf("未提交至任何人")== -1)
              
            MainHelper.PlatformSqlMap.Create<WFP_RecordWorkTaskIns>(wpfrecord);


            return strmes;
        }
        /// <summary>
        /// 更新运行定期分析流程
        /// </summary>
        /// <returns></returns>
        public static string RunDQFXRecord(string recordID, string OperatorInsId,string WorkTaskInsId, string command)
        {
            //IList<WFP_RecordWorkTaskIns> wf = MainHelper.PlatformSqlMap.GetList<WFP_RecordWorkTaskIns>("SelectWFP_RecordWorkTaskInsList", "where RecordID='" + recordID + "'");
            //if (wf.Count == 0) return "Error";
            //DataTable dt = WorkFlowInstance.SelectedWorkflowClaimingTask(MainHelper.User.UserID,wf[0].WorkFlowId,wf[0].WorkFlowInsId ,999);
           
            WorkFlowRuntime wfruntime = new WorkFlowRuntime();
            //wfruntime.RunSuccess += new WorkFlowRuntime.RunSuccessEventHandler(wfruntime_RunSuccess);
            //wfruntime.RunFail += new WorkFlowRuntime.RunFailEventHandler(wfruntime_RunFail);
            wfruntime.Run(MainHelper.User.UserID, OperatorInsId, command);
            //wfruntime.UserId = MainHelper.User.UserID;
            //wfruntime.WorkFlowId = wf[0].WorkFlowId;
            //wfruntime.WorkTaskId = wf[0].WorkTaskId;
            //wfruntime.WorkFlowInstanceId = wf[0].WorkFlowInsId ;
            //wfruntime.WorkTaskInstanceId = wf[0].WorkTaskInsId ;
            //wfruntime.WorkFlowNo = WorkFlowInstance.GetWorkflowNO();
            //wfruntime.CommandName = "提交";
            //wfruntime.WorkflowInsCaption = wf[0].w;
            //wfruntime.IsDraft = false;//保存并执行流程流转

            //WFP_RecordWorkTaskIns wpfrecord = new WFP_RecordWorkTaskIns();
            //wpfrecord.RecordID = recordID;
            //wpfrecord.WorkFlowId  = wfruntime.WorkFlowId;
            //wpfrecord.WorkFlowInsId  = wfruntime.WorkFlowInstanceId;
            //wpfrecord.WorkTaskId  = wfruntime.WorkTaskId;
            //wpfrecord.WorkTaskInsId  = wfruntime.WorkTaskInstanceId;
            //MainHelper.PlatformSqlMap.Create<WFP_RecordWorkTaskIns>(wpfrecord);

            //wfruntime.Start();
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
