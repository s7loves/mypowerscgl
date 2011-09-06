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
        /// 获得当前用户是否可以填写工作票的权限
        /// </summary>
        /// <param name="kind">工作票种类（dzczp操作票、yzgzp一种工作票、ezgzp二种工作票、xlqxp抢修单）</param>
        /// <param name="userID">用户ID</param>
        /// <returns>bool true有权限 false 无权限</returns>

        public static bool HaveRunNewGZPRole(string kind, string userID)
        {

            if (kind == "dzczp")
                    return WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "电力线路倒闸操作票").Rows.Count > 0 ? true : false;
            else if (kind == "yzgzp")
                    return WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "电力线路第一种工作票").Rows.Count > 0 ? true : false;
            else if (kind == "ezgzp")
                    return WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "电力线路第二种工作票").Rows.Count > 0 ? true : false;
            else if (kind == "xlqxp")
                return WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "电力线路事故应急抢修单").Rows.Count > 0 ? true : false;
            else
            {

                return WorkFlowTemplate.GetSelectedNameWorkFlows(userID, kind).Rows.Count > 0 ? true : false;
            }
            return false;
           
              
        }
        public static string GetGZPRecordSartStatus( string kind, string userID)
        {

            DataTable dt = null;
            string  workFlowId = "", workTaskId = "";
            
            if (kind == "dzczp")
                dt = WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "电力线路倒闸操作票");
            else if (kind == "yzgzp")
                dt = WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "电力线路第一种工作票");
            else if (kind == "ezgzp")
                dt = WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "电力线路第二种工作票");
            else if (kind == "xlqxp")
                dt = WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "电力线路事故应急抢修单");
            else
                dt = WorkFlowTemplate.GetSelectedNameWorkFlows(userID, kind);
            workFlowId = dt.Rows[0]["WorkFlowId"].ToString();
            workTaskId = dt.Rows[0]["workTaskId"].ToString();
            WF_WorkTask wt = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkTask>(workTaskId);
            return wt.TaskCaption ;
        }
      
        /// <summary>
        /// 创建工作票流程
        /// </summary>
        /// <param name="recordID">记录ID</param>
        /// <param name="kind">工作票种类（01操作票、02一种工作票、03二种工作票、04抢修单）</param>
        /// <param name="userID">用户ID</param>
        /// <returns>流程创建信息二维数组，[0]流程创建结果 [1]运行后流程的任务节点名称</returns>
        public static string[] RunNewGZPRecord(string recordID, string kind, string userID)
        {
            DataTable dt = null;
            string command = "", workFlowId = "", workTaskId = "", flowCaption = "", workFlowInstanceId = "", workTaskInstanceId = "";
            string strtemp = "";
            if (kind == "dzczp")
                dt = WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "电力线路倒闸操作票");
            else if (kind == "yzgzp")
                dt = WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "电力线路第一种工作票");
            else if (kind == "ezgzp")
                dt = WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "电力线路第二种工作票");
            else if (kind == "xlqxp")
                dt = WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "电力线路事故应急抢修单");
            else
                dt = WorkFlowTemplate.GetSelectedNameWorkFlows(userID, kind);   
            workFlowId = dt.Rows[0]["WorkFlowId"].ToString();
            workTaskId = dt.Rows[0]["workTaskId"].ToString();
            flowCaption = dt.Rows[0]["FlowCaption"].ToString();
            workFlowInstanceId = Guid.NewGuid().ToString();
            workTaskInstanceId = Guid.NewGuid().ToString();
            DataTable taskCommand = WorkFlowTask.GetTaskCommands(workFlowId, workTaskId);
            if (taskCommand.Rows.Count > 0)
            {
                command = taskCommand.Rows[0]["CommandName"].ToString();
            }
            else
            {
                command = "提交";
            }
            string[] strmes=new  string[2] ;
            strmes[0]= CreatWorkFlow(userID, workFlowId, workTaskId, workFlowInstanceId, workTaskInstanceId, flowCaption, command);
            
            WFP_RecordWorkTaskIns wpfrecord = new WFP_RecordWorkTaskIns();
            wpfrecord.RecordID = recordID;
            wpfrecord.WorkFlowId = workFlowId;
            wpfrecord.WorkFlowInsId = workFlowInstanceId;
            wpfrecord.WorkTaskId = workTaskId;
            wpfrecord.WorkTaskInsId = workTaskInstanceId;
            if (strmes[0].IndexOf("未提交至任何人") == -1) MainHelper.PlatformSqlMap.Create<WFP_RecordWorkTaskIns>(wpfrecord);
            
            strtemp=RecordWorkTask.GetWorkFlowTaskCaption (workTaskInstanceId);
            if (strtemp == "结束节点1")
            {
                strmes[1] = "存档";
            }
            else
            {
                strmes[1] = strtemp;
            }
            return strmes;
        }

        public static string RunGZPWorkFlowChange(string userID, LP_Record recordData, string operatorInsId, string workTaskInsId, string newWorkTaskCap)
        {
            string nowtaskId = "",strsql ="",strtemp="";
            string str1 = "未提交至任何人,请检查流程模板和组织机构配置是否正确!";

            WF_WorkTaskInstance workins = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkTaskInstance>(workTaskInsId);
            
            WF_OperatorInstance operins = MainHelper.PlatformSqlMap.GetOneByKey<WF_OperatorInstance>(operatorInsId);
            IList<WFP_RecordWorkTaskIns> wf = MainHelper.PlatformSqlMap.GetList<WFP_RecordWorkTaskIns>("SelectWFP_RecordWorkTaskInsList", "where RecordID='" + recordData.ID  + "'");
            if (wf.Count == 0) return str1;
            object obj = MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskList", " where TaskCaption='" + newWorkTaskCap + "' and WorkFlowId='" + wf[0].WorkFlowId + "'  ");
            if (obj != null && operins != null)
            {
                nowtaskId = ((WF_WorkTask)obj).WorkTaskId;
                workins.WorkTaskId = nowtaskId;
                workins.StartTime = DateTime.Now;
                workins.TaskInsCaption =((WF_WorkTask)obj).TaskCaption;
                MainHelper.PlatformSqlMap.Delete <WF_WorkTaskInstance>(workins);
                workins.WorkTaskInsId = Guid.NewGuid().ToString();
                workins.Status = "1";
                //WF_Operator op = (WF_Operator)MainHelper.PlatformSqlMap.GetObject("SelectWF_OperatorList", " where WorkTaskId='" + nowtaskId + "' and WorkFlowId='" + workins.WorkFlowId + "'");
                IList<WF_Operator> li = MainHelper.PlatformSqlMap.GetList<WF_Operator>("SelectWF_OperatorList", " where  WorkTaskId='" + nowtaskId + "' and WorkFlowId='" + workins.WorkFlowId + "'");
                if (li.Count > 0)
                {
                    foreach (WF_Operator op in li)
                    {


                        operins.OperatorInsId = Guid.NewGuid().ToString(); 
                        operins.WorkTaskId = nowtaskId;
                        operins.OperContent = op.OperContent;
                        operins.OperContentText = op.OperDisplay;
                        operins.OperDateTime = DateTime.Now;
                        operins.WorkTaskInsId = workins.WorkTaskInsId;
                        operins.OperStatus = "0";
                        if (strtemp != "")
                        {
                            strtemp = strtemp + "," + op.OperDisplay;
                        }
                        else
                        {
                            strtemp = op.OperDisplay;
                        }

                            
                        MainHelper.PlatformSqlMap.Create <WF_OperatorInstance>(operins);

                        
                    }
                    recordData.Status = newWorkTaskCap;
                    strsql = "  update WF_WorkFlowInstance set nowtaskId='" + nowtaskId + "' where workflowInsid='" + workins.WorkFlowInsId + "'";
                    MainHelper.PlatformSqlMap.Update("UpdateWF_WorkFlowInstanceValue", strsql);
                    MainHelper.PlatformSqlMap.DeleteByWhere<WF_OperatorInstance>(" where WorkFlowInsId='" + operins.WorkFlowInsId + "' and WorkTaskInsId='" + workTaskInsId + "' ");
                    MainHelper.PlatformSqlMap.Update<LP_Record>(recordData);
                    MainHelper.PlatformSqlMap.Create <WF_WorkTaskInstance>(workins);
                }
                else
                {
                    return str1;
                }
            }
            else
            {
                return str1;
            }




            return "成功提交至:" + strtemp + "。你已完成该任务处理,可以关闭该窗口。";
        }

        /// <summary>
        /// 获得当前用户是否可以新建运行分析记录权限
        /// </summary>
        /// <param name="recordIkind">运行分析记录种类</param>
        /// <param name="userID">用户ID</param>
        /// <returns>bool true有权限 false 无权限</returns>
        public static bool HaveRewNewYXFXRole(string recordIkind, string userID)
        {
            if (MainHelper.UserOrg.OrgName.IndexOf("供电所") > -1)
            {
                if (recordIkind=="定期分析")
                    return WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "供电所定期分析").Rows.Count > 0 ? true : false;
                else if (recordIkind == "专题分析")
                    return WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "供电所专题分析").Rows.Count > 0 ? true : false;

                return false;
            }
            //else if (MainHelper.UserOrg.OrgName.IndexOf("局") > -1)
            else
            {
                if (recordIkind == "定期分析")
                    return WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "局定期分析").Rows.Count > 0 ? true : false;
                else if (recordIkind == "专题分析")
                    return WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "局专题分析").Rows.Count > 0 ? true : false;
                return false;
            }
            //else
            //    return false;
        }
       
     /// <summary>
     /// 获得当前用户是否可以运行当前记录权限
     /// </summary>
        /// <param name="recordID">记录ID</param>
        /// <param name="userID">用户ID</param>
        /// <returns>true:有权限反之无权限</returns>
        public static bool HaveRunRecordRole(string recordID, string userID)
        {
            IList<WFP_RecordWorkTaskIns> wf = MainHelper.PlatformSqlMap.GetList<WFP_RecordWorkTaskIns>("SelectWFP_RecordWorkTaskInsList", "where RecordID='" + recordID + "'");
            if (wf.Count == 0) return false;
            DataTable dt = WorkFlowInstance.SelectedWorkflowClaimingTask(userID, wf[0].WorkFlowId, wf[0].WorkFlowInsId, 999);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
                return false;
        }

        /// <summary>
        /// 获得当前用户可以运行当前记录的流程信息
        /// </summary>
        /// <param name="recordID">记录ID</param>
        /// <param name="userID">用户ID</param>
        /// <returns>返回指定记录的流程信息</returns>
        public static DataTable GetRecordWorkFlowData(string recordID, string userID)
        {
            DataTable dtnull = new DataTable();
            IList<WFP_RecordWorkTaskIns> wf = MainHelper.PlatformSqlMap.GetList<WFP_RecordWorkTaskIns>("SelectWFP_RecordWorkTaskInsList", "where RecordID='" + recordID + "'");
            if (wf.Count == 0) return dtnull;
            WF_WorkFlowInstance wfi = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkFlowInstance>(wf[0].WorkFlowInsId); 
            DataTable dt = WorkFlowInstance.SelectedWorkflowClaimingTask(userID, wf[0].WorkFlowId, wf[0].WorkFlowInsId, 999);
           // DataTable dt = WorkFlowInstance.SelectedWorkflowTask (userID, wf[0].WorkFlowId, wf[0].WorkFlowInsId,wfi.NowTaskId , 999);
            return dt;
        }
        /// <summary>
        /// 获得当前记录的流程信息,不限定流程状态
        /// </summary>
        /// <param name="recordID">记录ID</param>
        /// <returns>返回指定记录的流程信息</returns>
        public static DataTable GetRecordWorkFlowData2(string recordID)
        {
            DataTable dtnull = new DataTable();
            IList<WFP_RecordWorkTaskIns> wf = MainHelper.PlatformSqlMap.GetList<WFP_RecordWorkTaskIns>("SelectWFP_RecordWorkTaskInsList", "where RecordID='" + recordID + "'");
            if (wf.Count == 0) return dtnull;
            WF_WorkFlowInstance wfi = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkFlowInstance>(wf[0].WorkFlowInsId);
            // DataTable dt = WorkFlowInstance.SelectedWorkflowClaimingTask(userID, wf[0].WorkFlowId, wf[0].WorkFlowInsId, 999);
            DataTable dt = WorkFlowInstance.SelectedWorkflowTask( wf[0].WorkFlowId, wf[0].WorkFlowInsId, wfi.NowTaskId, 999);
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
        /// <param name="userID">用户ID</param>
       /// <returns>流程创建结果</returns>
        public static string RunNewYXFXRecord(string recordID, string recordIkind, string userID)
        {
            DataTable dt = null;
            string command = "", workFlowId = "", workTaskId = "", flowCaption = "", workFlowInstanceId = "", workTaskInstanceId = "";
            if (MainHelper.UserOrg.OrgName.IndexOf("供电所") > -1)
            {
                if (recordIkind == "定期分析")
                {
                    dt = WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "供电所定期分析");
                }
                else if (recordIkind == "专题分析")
                {
                    dt = WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "供电所专题分析");
                }

                
            }
            //else if (MainHelper.UserOrg.OrgName.IndexOf("局") > -1)
            else  
            {
                if (recordIkind == "定期分析")
                {
                    dt = WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "局定期分析");
                }
                else if (recordIkind == "专题分析")
                {
                    dt = WorkFlowTemplate.GetSelectedNameWorkFlows(userID, "局专题分析");
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
            string strmes = CreatWorkFlow(userID, workFlowId, workTaskId, workFlowInstanceId, workTaskInstanceId, flowCaption, command);
           
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
                MainHelper.PlatformSqlMap.DeleteByWhere<WF_OperatorInstance>(" where (WorkFlowInsId='" + wf[0].WorkFlowInsId + "' or  WorkFlowInsId in ( select WorkFlowInsId from  WF_WorkFlowInstance where MainWorkflowInsId ='" + wf[0].WorkFlowInsId + "' ) )");
                MainHelper.PlatformSqlMap.DeleteByWhere<WF_WorkTaskInstance>(" where (WorkFlowInsId='" + wf[0].WorkFlowInsId + "' or  WorkFlowInsId in ( select WorkFlowInsId from  WF_WorkFlowInstance where MainWorkflowInsId ='" + wf[0].WorkFlowInsId + "' ) )");
                MainHelper.PlatformSqlMap.DeleteByWhere<WF_WorkFlowInstance>(" where (WorkFlowInsId='" + wf[0].WorkFlowInsId + "' or  WorkFlowInsId in ( select WorkFlowInsId from  WF_WorkFlowInstance where MainWorkflowInsId ='" + wf[0].WorkFlowInsId + "' ) )");
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

            return Toollips(WorkTaskInstanceId);
            //return "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="WorkTaskInsId"></param>
        /// <returns></returns>
        public static string GetWorkFlowTaskCaption( string WorkTaskInsId)
        {
            string sql = "where ( previoustaskid='" + WorkTaskInsId + "'  or WorkTaskId in ( select NowTaskId  from WF_WorkFlowInstance where MainWorktaskInsId='" + WorkTaskInsId + "' ) ) and operstatus='0' order by opertype";
            
            IList<WF_WorkTaskInstanceView> li = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskInstanceView>("SelectWF_WorkTaskInstanceViewList", sql);
            if (li.Count > 0)
            {
                return li[0].TaskInsCaption;
            }
            else
            {
                sql = "where previoustaskid='" + WorkTaskInsId + "' order by opertype";
                li = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskInstanceView>("SelectWF_WorkTaskInstanceViewList", sql);
                if (li.Count > 0)
                {
                    if (li[0].isSubWorkflow == false)
                    {
                        return li[0].TaskInsCaption;
                    }
                    else
                    {
                         WF_WorkFlowInstance mainwf = (WF_WorkFlowInstance)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkFlowInstanceList", "where  WorkflowInsId='" + li[0].MainWorkflowInsId + "'");
                         if (mainwf != null)
                        {
                            //WF_WorkTaskInstance wti = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkTaskInstance>(mainwf.NowTaskId);
                            WF_WorkTask wt = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkTask>(mainwf.NowTaskId);
                            if (wt.TaskTypeId == "6")
                            {
                                WF_WorkFlowInstance subwf = (WF_WorkFlowInstance)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkFlowInstanceList", "where  MainWorkflowInsId='" + li[0].MainWorkflowInsId + "'and MainWorktaskId='" + mainwf.NowTaskId + "' ");
                                wt = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkTask>(subwf.NowTaskId);
                                
                            }
                           
                                return wt.TaskCaption ;

                        }
                    }
                }

                return "";
            }
        }
        
        /// <summary>
        /// 流程是否可以退回
        /// </summary>
        /// <param name="WorkTaskId">任务节点id</param>
        /// <param name="WorkFlowId">流程ID</param>
        /// <returns>true ，可以退回 反之不能</returns>
        public static bool  HaveWorkFlowBackRole(string WorkTaskId, string WorkFlowId)
        {
            if (MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskPowerList", " where WorkTaskId='" + WorkTaskId + "' and WorkFlowId='" + WorkFlowId+ "' and PowerName='"+WorkConst.WorkTask_Return+"'") != null)
                return true;
            return false ;
        }

        
        /// <summary>
        /// 流程退回
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="OperatorInsId">操作ID</param>
        /// <param name="WorkTaskInsId">实例任务节点ID</param>
        /// <returns>返回流程执行结果</returns>
        public static string RunWorkFlowBack(string userID, string OperatorInsId, string WorkTaskInsId)
        {
            WorkFlowRuntime wfruntime = new WorkFlowRuntime();
            wfruntime.UserId = userID;
            wfruntime.OperatorInstanceId = OperatorInsId;
            wfruntime.TaskBack();

            return Toollips(WorkTaskInsId);
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
            if (ResultMsg != WorkFlowConst.SuccessMsg && ResultMsg.IndexOf ("退回")==-1)
            {
                TaskToWhoMsg = "未提交至任何人,请检查流程模板和组织机构配置是否正确!";
                if (ResultMsg == WorkFlowConst.WorkflowOverMsg)//流程结束
                {
                    string sql = "where previoustaskid='" + workTaskInsId + "' order by opertype";
                    IList<WF_WorkTaskInstanceView> li = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskInstanceView>("SelectWF_WorkTaskInstanceViewList", sql);
                    if (li.Count > 0)
                    {
                        if (li[0].isSubWorkflow == false)
                        {
                            TaskToWhoMsg = "流程结束!";
                        }
                        else
                        {
                            WF_WorkFlowInstance mainwf = (WF_WorkFlowInstance)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkFlowInstanceList", "where  WorkflowInsId='" + li[0].MainWorkflowInsId + "'");
                            if (mainwf != null)
                            {
                                //WF_WorkTaskInstance wti = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkTaskInstance>(mainwf.NowTaskId);
                                WF_WorkTask wt = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkTask>(mainwf.NowTaskId);
                                if (wt.TaskTypeId == "6")
                                {
                                    WF_WorkFlowInstance subwf = (WF_WorkFlowInstance)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkFlowInstanceList", "where  MainWorkflowInsId='" + li[0].MainWorkflowInsId + "'and MainWorktaskId='" + mainwf.NowTaskId + "' ");
                                    sql = "where MainWorkflowInsId='" + subwf.MainWorkflowInsId + "' and MainWorktaskId='" + subwf.MainWorktaskId  + "'and WorkTaskId='" + subwf .NowTaskId+ "' order by opertype";
                                    li = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskInstanceView>("SelectWF_WorkTaskInstanceViewList", sql);
                                    if (li.Count > 0)
                                    {
                                        TaskToWhoMsg = WorkTaskInstance.GetTaskToWhoMsg(li[0].PreviousTaskId   );
                                    }
                                }
                                else
                                    if (wt.TaskTypeId == "2")
                                    {
                                        TaskToWhoMsg = "流程结束!";
                                    }

                               

                            }
                        }
                    }
                    
                }
                if (ResultMsg == WorkFlowConst.TaskBackMsg)
                {
                    TaskToWhoMsg = WorkFlowConst.TaskBackMsg;
                }
            }

            return TaskToWhoMsg ="成功提交至:" + TaskToWhoMsg + "。已完成该任务处理,可以关闭该窗口。";
        }
     
    }
}
