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
using System.Reflection;
using DevExpress.XtraTab;
using Excel = Microsoft.Office.Interop.Excel;
using Ebada.Client;
using Ebada.Scgl.Core;
using System.Threading;

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
        public static void GetPreviousTask(string taskid, string workFlowId, ref Hashtable taskht)
        {

            string tmpStr = " where  EndTaskId='" + taskid + "' and WorkFlowId='" + workFlowId + "'";
            IList<WF_WorkTaskLinkView> li = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskLinkView>("SelectWF_WorkTaskLinkViewList", tmpStr);
            foreach (WF_WorkTaskLinkView tl in li)
            {
                if (!taskht.ContainsKey(tl.StartTaskId))
                    taskht.Add(tl.StartTaskId, tl.startTaskCaption);
                GetPreviousTask(tl.StartTaskId, workFlowId, ref  taskht);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="WorkFlowData"></param>
        /// <param name="currRecord"></param>
        /// <returns></returns>
        public static Hashtable GetExploerLP_TempleList(DataTable WorkFlowData, LP_Record currRecord)
        {
            Hashtable templehs = new Hashtable();
            Hashtable hs = new Hashtable();
            IList<WFP_RecordWorkTaskIns> wf = MainHelper.PlatformSqlMap.GetList<WFP_RecordWorkTaskIns>("SelectWFP_RecordWorkTaskInsList", "where RecordID='" + currRecord.ID + "'");
            if (WorkFlowData.Rows.Count > 0)
            {
                if (!hs.ContainsKey(WorkFlowData.Rows[0]["WorkTaskId"].ToString()))
                    hs.Add(WorkFlowData.Rows[0]["WorkTaskId"].ToString(), WorkFlowData.Rows[0]["TaskCaption"].ToString());
                GetPreviousTask(WorkFlowData.Rows[0]["WorkTaskId"].ToString(), wf[0].WorkFlowId, ref hs);
            }
            else if (currRecord.Status == "存档")
            {

                if (wf.Count > 0)
                {
                    IList<WF_WorkTask> tasklist = MainHelper.PlatformSqlMap.GetList<WF_WorkTask>("SelectWF_WorkTaskList", "where TaskTypeId='1' and WorkFlowId='" + wf[0].WorkFlowId + "'");
                    if (!hs.ContainsKey(tasklist[0].WorkTaskId))
                        hs.Add(tasklist[0].WorkTaskId, tasklist[0].TaskCaption);
                    GetPreviousTask(tasklist[0].WorkTaskId, tasklist[0].TaskCaption, ref hs);
                }
            }
            ArrayList akeys = new ArrayList(hs.Keys);
            for (int i = 0; i < akeys.Count; i++)
            {
                if (!RecordWorkTask.HaveWorkFlowAllExploreRole(akeys[i].ToString(), wf[0].WorkFlowId))
                {

                    if (!RecordWorkTask.HaveWorkFlowExploreRole(akeys[i].ToString(), wf[0].WorkFlowId))
                    {
                        continue;
                    }

                }
                LP_Temple temp = GetWorkTaskTemple(currRecord, wf[0].WorkFlowId, wf[0].WorkFlowInsId, akeys[i].ToString());
                if (temp != null && temp.Status == "节点审核")
                {
                    if (!templehs.Contains(temp)) templehs.Add(temp, akeys[i].ToString());
                }
                else if (temp != null)
                {
                    if (!templehs.Contains(temp.LPID)) templehs.Add(temp.LPID, akeys[i].ToString());
                }
            }

            return templehs;
        }
        /// <summary>
        /// 获得当前流程是否有流程结束后允许导出的权限
        /// </summary>
        /// <param name="kind">流程名称</param>
        /// <returns>bool true有权限 false 无权限</returns>

        public static bool HaveFlowEndExploreRole(string kind)
        {
            string strkind = kind;
            if (kind == "dzczp")
                strkind = "电力线路倒闸操作票";
            else if (kind == "yzgzp")
                strkind = "电力线路第一种工作票";
            else if (kind == "ezgzp")
                strkind = "电力线路第二种工作票";
            else if (kind == "xlqxp")
                strkind = "电力线路事故应急抢修单";
            WF_WorkFlow wf = (WF_WorkFlow)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkFlowList", " where FlowCaption='" + strkind + "'");
            if (wf == null) return false;


            return HaveRunPowerRole(WorkConst.WorkTask_FlowEndExplore, wf.WorkFlowId, wf.WorkFlowId);


        }
        /// <summary>
        /// 获得当前流程是否有附件的权限
        /// </summary>
        /// <param name="kind">流程名称</param>
        /// <returns>bool true有权限 false 无权限</returns>

        public static bool HaveRunFuJianRole(string kind)
        {
            string strkind = kind;
            if (kind == "dzczp")
                strkind = "电力线路倒闸操作票";
            else if (kind == "yzgzp")
                strkind = "电力线路第一种工作票";
            else if (kind == "ezgzp")
                strkind = "电力线路第二种工作票";
            else if (kind == "xlqxp")
                strkind = "电力线路事故应急抢修单";
            WF_WorkFlow wf = (WF_WorkFlow)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkFlowList", " where FlowCaption='" + strkind + "'");
            if (wf == null) return false;


            return HaveRunPowerRole(WorkConst.WorkTask_FuJian, wf.WorkFlowId, wf.WorkFlowId);


        }
        /// <summary>
        /// 获得当前流程是否有审批意见的权限
        /// </summary>
        /// <param name="kind">流程名称</param>
        /// <returns>bool true有权限 false 无权限</returns>

        public static bool HaveRunSPYJRole(string kind)
        {

            string strkind = kind;
            if (kind == "dzczp")
                strkind = "电力线路倒闸操作票";
            else if (kind == "yzgzp")
                strkind = "电力线路第一种工作票";
            else if (kind == "ezgzp")
                strkind = "电力线路第二种工作票";
            else if (kind == "xlqxp")
                strkind = "电力线路事故应急抢修单";
            WF_WorkFlow wf = (WF_WorkFlow)MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkFlowList", " where FlowCaption='" + strkind + "'");
            if (wf == null) return false;


            return HaveRunPowerRole(WorkConst.WorkTask_SPYJ, wf.WorkFlowId, wf.WorkFlowId);


        }
        /// <summary>
        /// 获得当前流程是否有输入名称的权限（）
        /// </summary>
        /// <param name="TaskPower">控制权限名称</param>
        /// <param name="WorkFlowId">WorkFlowId</param>
        /// <param name="WorkTaskId">WorkTaskId</param>
        /// <returns>bool true有权限 false 无权限</returns>

        public static bool HaveRunPowerRole(string TaskPower, string WorkFlowId, string WorkTaskId)
        {

            object obj = MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskPowerList", " where PowerName='" + TaskPower + "' and WorkFlowId='" + WorkFlowId + "' and WorkTaskId='" + WorkTaskId + "'");
            if (obj == null) return false;

            return true;


        }
        /// <summary>
        /// 生成日志记录
        /// </summary>
        /// <param name="WorkFlowData">流程数据信息</param>
        /// <param name="dsoFramerWordControl1">Excel控件</param>
        /// <param name="recordID">记录ID</param>
        /// <param name="modlecordlist">模块相关记录集</param>
        public static void CreatRiZhi(DataTable WorkFlowData, DSOFramerControl dsoFramerWordControl1, string recordID, params   object[] modlecordlist)
        {

            WF_TaskVar tvAddress = RecordWorkTask.GetWorkTaskRiZhi(WorkFlowData, "工作地点");
            WF_TaskVar tvProject = RecordWorkTask.GetWorkTaskRiZhi(WorkFlowData, "项目");
            WF_TaskVar tvCharMan = RecordWorkTask.GetWorkTaskRiZhi(WorkFlowData, "负责人");
            WF_TaskVar tvAttendMan = RecordWorkTask.GetWorkTaskRiZhi(WorkFlowData, "参加人员");

            PJ_gzrjnr gzr = new PJ_gzrjnr();
            gzr.gzrjID = gzr.CreateID();
            gzr.ParentID = recordID;
            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            IList<PJ_01gzrj> gzrj01 = MainHelper.PlatformSqlMap.GetList<PJ_01gzrj>("SelectPJ_01gzrjList", "where rq between '" + DateTime.Now.ToString("yyyy-MM-dd 00:00:00") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd 23:59:59") + "'");

            if (gzrj01.Count > 0)
            {
                gzr.gzrjID = gzrj01[0].gzrjID;
            }
            else
            {
                PJ_01gzrj pj = new PJ_01gzrj();
                pj.gzrjID = pj.CreateID();
                pj.CreateDate = DateTime.Now;
                pj.CreateMan = MainHelper.User.UserName;
                gzr.gzrjID = pj.gzrjID;
                pj.rq = DateTime.Now.Date;
                pj.xq = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
                Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                MainHelper.PlatformSqlMap.Create<PJ_01gzrj>(pj);

                //MsgBox.ShowWarningMessageBox("未填写今日工作日记");
                //return;
            }
            IList<PJ_gzrjnr> gzrlist = MainHelper.PlatformSqlMap.GetList<PJ_gzrjnr>("SelectPJ_gzrjnrList", "where ParentID  = '" + gzr.ParentID + "' order by seq  ");
            if (gzrlist.Count > 0)
            {
                gzr.seq = gzrlist[gzrlist.Count - 1].seq + 1;
            }
            else
                gzr.seq = 1;

            gzr.gznr = GetTaskVarRiZhiValue(tvAddress, dsoFramerWordControl1, recordID, GetModleRecordObj(tvAddress, modlecordlist))
                + GetTaskVarRiZhiValue(tvProject, dsoFramerWordControl1, recordID, GetModleRecordObj(tvProject, modlecordlist));
            gzr.fzr = GetTaskVarRiZhiValue(tvCharMan, dsoFramerWordControl1, recordID, GetModleRecordObj(tvCharMan, modlecordlist));
            gzr.cjry = GetTaskVarRiZhiValue(tvAttendMan, dsoFramerWordControl1, recordID, GetModleRecordObj(tvAttendMan, modlecordlist));
            gzr.CreateDate = DateTime.Now;
            gzr.CreateMan = MainHelper.User.UserName;
            MainHelper.PlatformSqlMap.Create<PJ_gzrjnr>(gzr);

        }
        /// <summary>
        /// 找到工作日志关联的记录
        /// </summary>
        /// <param name="tv">日志任务变量</param>
        /// <param name="modleRecordlist">模块相关记录集</param>
        /// <returns>返回工作日志关联的记录</returns>
        public static object GetModleRecordObj(WF_TaskVar tv, object[] modleRecordlist)
        {
            object obj = null;
            for (int i = 0; i < modleRecordlist.Length && tv.TableName != "" && tv.VarModule == "数据库"; i++)
            {
                if (modleRecordlist[i].GetType().ToString().IndexOf(tv.TableName) > -1)
                {
                    obj = modleRecordlist[i];
                    break;

                }

            }

            return obj;
        }

        /// <summary>
        /// 获得任务日志变量
        /// </summary>
        /// <param name="workflowData">流程信息</param>
        /// <param name="varName">要获得的日志变量设置的名称</param>
        /// <returns>返回任务日志设置变量</returns>
        public static WF_TaskVar GetWorkTaskRiZhi(DataTable workflowData, string varName)
        {
            return WorkFlowTask.GetTaskRiZhiVar(workflowData.Rows[0]["WorktaskId"].ToString(), varName);
        }
        /// <summary>
        /// 读取工作日志变量对应的值
        /// </summary>
        /// <param name="tv">工作日志变量</param>
        /// <param name="dsoFramerWordControl1">Excel控件</param>
        /// <param name="recordID">记录ID</param>
        /// <param name="modlecord">模块记录</param>
        /// <returns>返回工作日志变量对应的值，不存在则为空</returns>
        public static string GetTaskVarRiZhiValue(WF_TaskVar tv, DSOFramerControl dsoFramerWordControl1, string recordID, object modlecord)
        {

            Excel.Worksheet xx = null;
            if (tv.TableName != "" && dsoFramerWordControl1 != null && tv.VarModule == "Excel")
            {
                Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
                for (int i = 1; i < wb.Application.Sheets.Count; i++)
                {
                    Excel.Worksheet sheet = wb.Application.Sheets[i] as Excel.Worksheet;
                    if (sheet.Name == tv.TableName)
                    {
                        xx = sheet;
                        break;
                    }
                }
            }
            return GetTaskVarRiZhiValue(tv, xx, recordID, modlecord);
        }
        /// <summary>
        /// 读取工作日志变量对应的值
        /// </summary>
        /// <param name="tv">工作日志变量</param>
        /// <param name="sheet">工作日志变量对应的工作表</param>
        /// <param name="recordID">记录ID</param>
        /// <returns>返回工作日志变量对应的值，不存在则为空</returns>
        public static string GetTaskVarRiZhiValue(WF_TaskVar tv, Excel.Worksheet sheet, string recordID)
        {
            return GetTaskVarRiZhiValue(tv, sheet, recordID, null);
        }
        /// <summary>
        /// 返回工作日志变量对应的值，不存在则为空
        /// </summary>
        /// <param name="tv">工作日志变量</param>
        /// <param name="sheet">工作日志变量对应的工作表</param>
        /// <param name="recordID">记录ID</param>
        /// <param name="modlecord">模块记录</param>
        /// <returns>返回工作日志变量对应的值，不存在则为空</returns>
        public static string GetTaskVarRiZhiValue(WF_TaskVar tv, Excel.Worksheet sheet, string recordID, object modlecord)
        {
            string strvalue = "";
            if (tv.VarModule == "固定值")
            {
                strvalue = tv.InitValue;
            }
            else if (tv.VarModule == "表单")
            {
                //LP_Temple tp = MainHelper.PlatformSqlMap.GetOneByKey<LP_Temple>(tvAddress.TableField);
                IList<WF_TableFieldValue> filedvaluelist = MainHelper.PlatformSqlMap.GetList<WF_TableFieldValue>("SelectWF_TableFieldValueList",
                    "where RecordId  = '" + recordID + "' and FieldId='" + tv.TableField
                    + "' and WorkFlowId='" + tv.WorkFlowId
                    + "' and WorkTaskId='" + tv.WorkTaskId + "' order by seq  ");
                if (filedvaluelist.Count > 0)
                {
                    strvalue = filedvaluelist[0].ControlValue;
                }
            }
            else if (tv.VarModule == "Excel")
            {
                if (tv.TableName != "")
                {

                    string[] arrCellPos = tv.TableField.Split('|');
                    arrCellPos = StringHelper.ReplaceEmpty(arrCellPos).Split('|');
                    string strcellvalue = "";
                    for (int i = 0; i < arrCellPos.Length; i++)
                    {
                        Excel.Range range = sheet.get_Range(sheet.Cells[GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]], sheet.Cells[GetCellPos(arrCellPos[i])[0], GetCellPos(arrCellPos[i])[1]]);//坐标
                        strcellvalue += range.Value2;
                    }
                    strvalue = strcellvalue;
                }

            }
            else if (tv.VarModule == "数据库" && modlecord != null)
            {
                if (modlecord.GetType().ToString().IndexOf(tv.TableName) > -1)
                {
                    //if (modlecord.GetType().GetProperty(tvAddress.TableField) != null && modlecord.GetType().GetProperty(tvAddress.TableField).GetValue(modlecord, null) != null)
                    //{
                    //strvalue = modlecord.GetType().GetProperty(tvAddress.TableField).GetValue(modlecord, null).ToString();
                    string strsql = "";
                    strsql = tv.InitValue;
                    strsql = SetSQLValue(strsql, modlecord);
                    try
                    {
                        IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", strsql);
                        if (list.Count > 0)
                        {
                            for (int i = 0; i < list.Count; i++)
                            {
                                strvalue += list[i].ToString();
                            }
                        }
                        else
                        {
                            strvalue = "无数据";
                        }
                    }
                    catch (Exception ex)
                    {
                        strvalue = "出错:" + ex.Message;
                    }
                    //}

                }
            }
            return strvalue;
        }
        /// <summary>
        /// 设置SQL语句里的变量值
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="modlecord">模块相关记录</param>
        /// <returns>返回新的SQL语句</returns>
        public static string SetSQLValue(string strSQL, object modlecord)
        {
            int index1 = -1, index2 = -1;
            string strtemp = "", strnewsql = strSQL;
            if ((index1 = strSQL.IndexOf("{")) > -1 && (index2 = strSQL.IndexOf("}")) > -1)
            {

                strtemp = strSQL.Substring(index1 + 1, index2 - index1 - 1);
                if (modlecord.GetType().GetProperty(strtemp) != null && modlecord.GetType().GetProperty(strtemp).GetValue(modlecord, null) != null)
                {
                    strnewsql = strSQL.Substring(0, index1) + modlecord.GetType().GetProperty(strtemp).GetValue(modlecord, null) + strSQL.Substring(index2 + 1);
                    return SetSQLValue(strnewsql, modlecord);
                }

            }
            return strnewsql;
        }
        /// <summary>
        /// 获得Excel的表格数字位置，去掉字母
        /// </summary>
        /// <param name="cellpos">Excel的表格位置</param>
        /// <returns>Excel的表格数字位置</returns>
        public static int[] GetCellPos(string cellpos)
        {
            cellpos = cellpos.Replace("|", "");
            return new int[] { int.Parse(cellpos.Substring(1)), (int)cellpos[0] - 64 };
        }
        /// <summary>
        /// 确认工作日志是否开启
        /// </summary>
        /// <param name="workflowData">流程信息</param>
        /// <returns>true 开启 false 没开启日志功能</returns>
        public static bool CheckOnRiZhi(DataTable workflowData)
        {
            if (workflowData == null || workflowData.Rows.Count == 0) return false;

            return WorkFlowTask.CheckTaskPowerExit(workflowData.Rows[0]["WorkflowId"].ToString(), workflowData.Rows[0]["WorktaskId"].ToString(), "工作日志");
        }
        /// <summary>
        /// 关联表单的字段值
        /// </summary>
        /// <param name="temple"></param>
        /// <param name="currRecord"></param>
        /// <param name="WorkflowId"></param>
        /// <param name="WorkFlowInsId"></param>
        public static void iniTableRecordData(ref LP_Temple temple, LP_Record currRecord, string WorkflowId, string WorkFlowInsId)
        {
            iniTableRecordData(ref temple, currRecord, WorkflowId, WorkFlowInsId, false);
        }
        /// <summary>
        /// 关联表单的字段值
        /// </summary>
        /// <param name="temple"></param>
        /// <param name="currRecord"></param>
        /// <param name="WorkflowId"></param>
        /// <param name="WorkFlowInsId"></param>
        /// <param name="isExplorerCall"></param>
        public static void iniTableRecordData(ref LP_Temple temple, LP_Record currRecord, string WorkflowId, string WorkFlowInsId, bool isExplorerCall)
        {
            if (temple != null)
            {
                DSOFramerControl dsoFramerWordControl1 = new DSOFramerControl();
                dsoFramerWordControl1.FileDataGzip = temple.DocContent;
                IList<WF_TableFieldValue> tfvli = MainHelper.PlatformSqlMap.GetList<WF_TableFieldValue>("SelectWF_TableFieldValueList",
                    " where RecordId='" + currRecord.ID + "' and UserControlId='" + temple.LPID + "' and   WorkflowId='" + WorkflowId + "' and WorkFlowInsId='" + WorkFlowInsId + "' ");
                Excel.Workbook wb = dsoFramerWordControl1.AxFramerControl.ActiveDocument as Excel.Workbook;
                Excel.Worksheet xx;
                ExcelAccess ea = new ExcelAccess();
                ea.MyWorkBook = wb;
                ea.MyExcel = wb.Application;
                string activeSheetName = "";
                xx = wb.Application.Sheets[1] as Excel.Worksheet;
                int i = 0;
                ArrayList al = new ArrayList();
                for (i = 1; i <= wb.Application.Sheets.Count; i++)
                {
                    xx = wb.Application.Sheets[i] as Excel.Worksheet;
                    if (!al.Contains(xx.Name)) al.Add(xx.Name);
                }
                for (i = 0; i < tfvli.Count; i++)
                {
                    if (!al.Contains(tfvli[i].ExcelSheetName))
                    {

                        continue;
                    }
                    if (isExplorerCall)
                    {

                        LP_Temple field = MainHelper.PlatformSqlMap.GetOneByKey<LP_Temple>(tfvli[i].FieldId);
                        if (field != null)
                        {
                            if (field.isExplorer == 1)
                            {
                                continue;
                            }
                        }
                    }
                    if (activeSheetName != tfvli[i].ExcelSheetName)
                    {
                        if (activeSheetName != "")
                        {

                            xx = wb.Application.Sheets[activeSheetName] as Excel.Worksheet;


                        }
                        xx = wb.Application.Sheets[tfvli[i].ExcelSheetName] as Excel.Worksheet;

                        activeSheetName = tfvli[i].ExcelSheetName;

                        ea.ActiveSheet(xx.Index);
                    }

                    ea.SetCellValue(tfvli[i].ControlValue, tfvli[i].XExcelPos, tfvli[i].YExcelPos);

                }
                dsoFramerWordControl1.FileSave();
                temple.DocContent = dsoFramerWordControl1.FileDataGzip;

            }
        }
        /// <summary>
        /// 获得流程的输入的节点关联的表单
        /// </summary>
        /// <param name="record"></param>
        /// <param name="workflowId"></param>
        /// <param name="workFlowInsId"></param>
        /// <param name="worktaskId"></param>
        /// <returns></returns>
        public static LP_Temple GetWorkTaskTemple(LP_Record record, string workflowId, string workFlowInsId, string worktaskId)
        {
            LP_Temple tp = null;
            string strsql = "";
            WF_WorkTaskControls wtc = MainHelper.PlatformSqlMap.GetOne<WF_WorkTaskControls>(" where WorkflowId='" + workflowId
                + "' and WorktaskId='" + worktaskId + "'");
            if (wtc == null)
            {
                return null;
            }
            if (wtc.ControlType == "绑定节点")
            {
                DataTable ctrlTable = WorkFlowTask.GetTaskControls(worktaskId);
                bool notable = true;
                for (int i = 0; i < ctrlTable.Rows.Count; i++)
                {
                    if (ctrlTable.Rows[i]["LPID"].ToString() != "节点审核")
                    {
                        notable = false;
                        break;
                    }
                }
                if (notable)
                {
                    ctrlTable = WorkFlowTask.GetTaskBindTaskContent(wtc.WorktaskId);
                    strsql = " where WorkflowId='" + workflowId + "'"
                        + " and WorktaskId='" + ctrlTable.Rows[0]["UserControlId"] + "'"
                          + " and WorkFlowInsId='" + workFlowInsId + "'"

                          + " and RecordId='" + record.ID + "' order by Creattime desc";
                    WF_ModleCheckTable mct = MainHelper.PlatformSqlMap.GetOne<WF_ModleCheckTable>(strsql);
                    if (mct != null)
                    {
                        tp = new LP_Temple();
                        tp.Status = "节点审核";
                        tp.LPID = mct.ID;
                        tp.DocContent = mct.DocContent;
                        return tp;
                    }

                }//是节点审核
                else
                {

                    tp = MainHelper.PlatformSqlMap.GetOneByKey<LP_Temple>(ctrlTable.Rows[0]["LPID"]);

                    if (tp != null)
                    {
                         ctrlTable = WorkFlowTask.GetTaskBindTaskContent(wtc.WorktaskId);
                    strsql = " where WorkflowId='" + workflowId + "'"
                        + " and WorktaskId='" + ctrlTable.Rows[0]["UserControlId"] + "'"
                          + " and WorkFlowInsId='" + workFlowInsId + "'"

                          + " and RecordId='" + record.ID + "' order by Creattime desc";
                    WF_ModleCheckTable mct = MainHelper.PlatformSqlMap.GetOne<WF_ModleCheckTable>(strsql);
                    if (mct != null)
                    {
                        tp.DocContent = mct.DocContent;
                    }
                        /***
                        * 绑定的节点是表单，则把它的字段值填上
                        * 
                        * **/
                        iniTableRecordData(ref  tp, record, workflowId, workFlowInsId);
                        return tp;
                    }
                }//是表单
            }//绑定节点
            else
            {
                if (wtc.UserControlId == "节点审核")
                {
                    strsql = " where WorkflowId='" + workflowId + "'"
                        + " and WorktaskId='" + wtc.WorktaskId + "'"
                          + " and WorkFlowInsId='" + workFlowInsId + "'"

                          + " and RecordId='" + record.ID + "' order by Creattime desc";
                    WF_ModleCheckTable mct = MainHelper.PlatformSqlMap.GetOne<WF_ModleCheckTable>(strsql);
                    if (mct != null)
                    {
                        tp = new LP_Temple();
                        tp.Status = "节点审核";
                        tp.LPID = mct.ID;
                        tp.DocContent = mct.DocContent;
                        return tp;
                    }
                }
                else
                {
                    tp = MainHelper.PlatformSqlMap.GetOneByKey<LP_Temple>(wtc.UserControlId);
                    if (tp != null)
                    {

                        return tp;
                    }
                }
            }//非绑定节点
            return null;
        }
        /// <summary>
        /// 获得流程的输入的节点关联的表单
        /// </summary>
        /// <param name="workflowData">流程信息列表</param>

        /// <returns>关联的表单</returns>

        public static LP_Temple GetWorkTaskTemple(DataTable workflowData, LP_Record record)
        {

            if (workflowData.Rows.Count > 0)
            {

                return GetWorkTaskTemple(record, workflowData.Rows[0]["WorkflowId"].ToString(),
                    workflowData.Rows[0]["WorkFlowInsId"].ToString(),
                    workflowData.Rows[0]["WorktaskId"].ToString());
            }

            return null;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uc"></param>
        /// <param name="mulist"></param>
        /// <param name="outisfind"></param>
        public static void IniControl(System.Windows.Forms.Control.ControlCollection uc, IList<WF_ModleUsedFunc> mulist, ref bool outisfind)
        {
            bool isfind = false;
            foreach (Control ct in uc)
            {
                isfind = false;
                foreach (WF_ModleUsedFunc ufc in mulist)
                {
                    if (ct.Name == ufc.FunCode)
                    {
                        isfind = true;
                        outisfind = true;
                        break;
                    }
                }
                if (!isfind)
                    IniControl(ct.Controls, mulist, ref isfind);
                if (ct is XtraTabPage)
                {
                    ((XtraTabPage)ct).PageVisible = isfind;
                }
                if (isfind) outisfind = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="formCtr"></param>
        /// <param name="mulist"></param>
        public static void IniCreatModle(object formCtr, IList<WF_ModleUsedFunc> mulist)
        {
            if (formCtr == null) return;
            if (mulist.Count == 0) return;
            bool isfind = false;
            if (formCtr is UserControl)
            {
                UserControl uc = formCtr as UserControl;
                IniControl(uc.Controls, mulist, ref isfind);
            }
            else if (formCtr is Form)
            {
                Form fm = formCtr as Form;
                IniControl(fm.Controls, mulist, ref isfind);
            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblyFileName"></param>
        /// <param name="moduTypes"></param>
        /// <param name="methodName"></param>
        /// <param name="moduName"></param>
        /// <returns></returns>
        public static object CreatNewMoldeIns(string assemblyFileName, string moduTypes, string methodName, string moduName)
        {
            object fromCtrl;
            Assembly assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + assemblyFileName);
            Type tp = assembly.GetType(moduTypes);
            MethodInfo method = tp.GetMethod(methodName);
            //if (methodName == "")////窗体的构造函数不需要参数
                fromCtrl = Activator.CreateInstance(tp);
            //else//窗体的构造函数需要参数
            //    fromCtrl = Activator.CreateInstance(tp, methodName);
            if (fromCtrl is UserControl)
            {
                UserControl uc = fromCtrl as UserControl;
                uc.Name = moduName;

            }
            else if (fromCtrl is Form)
            {
                Form fm = fromCtrl as Form;
                fm.Name = moduName;
            }
            //if (method != null)
            //{
            //    object[] objArray = new object[0];
            //    method.Invoke(fromCtrl, objArray);
            //}
            //else
            //{
            //    ((Form)fromCtrl).ShowDialog();
            //}

            return fromCtrl;
        }
        /// <summary>
        /// 获得流程的当前节点关联的模块
        /// </summary>
        /// <param name="kind">流程名称（工作票：dzczp操作票、yzgzp一种工作票、ezgzp二种工作票、xlqxp抢修单）</param>
        /// <param name="userID">用户ID</param>
        /// <returns>bool true有权限 false 无权限</returns>
        public static object GetWorkTaskModle(DataTable workflowData)
        {
            if (workflowData.Rows.Count > 0)
            {
                return GetWorkTaskModle(workflowData.Rows[0]["WorkflowId"].ToString(), workflowData.Rows[0]["WorktaskId"].ToString());
            }

            return null;
        }
        public static object GetWorkTaskModle(string workflowId, string worktaskId)
        {


            object fromCtrl;
            WF_WorkTaskModle wtc = MainHelper.PlatformSqlMap.GetOne<WF_WorkTaskModle>(" where WorkflowId='" + workflowId + "' and WorktaskId='" + worktaskId + "'");
            //if (wtc == null) return null;
            mModule tp=null;
            if (wtc != null)
            {
                 tp = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(wtc.Modu_ID);
            }
            if (tp == null)
            {
                fromCtrl = CreatNewMoldeIns("Ebada.Scgl.Lcgl.dll", "Ebada.Scgl.Lcgl.frmLP", "", "表单执行平台");
            }
            else
            {
                fromCtrl = CreatNewMoldeIns(tp.AssemblyFileName, tp.ModuTypes, tp.MethodName, tp.ModuName);

            }
            if (tp != null)
            {
                IList<WF_ModleUsedFunc> mulist = MainHelper.PlatformSqlMap.GetList<WF_ModleUsedFunc>(" where WorkflowId='" + workflowId + "' and WorktaskId='" + worktaskId + "' and Modu_ID='" + tp.Modu_ID + "'");
                if (mulist.Count > 0) IniCreatModle(fromCtrl, mulist);
            }
            return fromCtrl;


            return null;


        }
        /// <summary>
        /// 获得新创建的流程的第一个节点关联的模块
        /// </summary>
        /// <param name="kind">流程名称（工作票：dzczp操作票、yzgzp一种工作票、ezgzp二种工作票、xlqxp抢修单）</param>
        /// <param name="userID">用户ID</param>
        /// <returns>bool true有权限 false 无权限</returns>

        public static object GetNewWorkTaskModle(string kind, string userID)
        {
            DataTable dt = null;
            object fromCtrl;
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
            if (dt.Rows.Count > 0)
            {
                WF_WorkTaskModle wtc = MainHelper.PlatformSqlMap.GetOne<WF_WorkTaskModle>(" where WorkflowId='" + dt.Rows[0]["WorkflowId"] + "' and WorktaskId='" + dt.Rows[0]["WorktaskId"] + "'");
                if (wtc == null) return null;
                mModule tp = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(wtc.Modu_ID);
                if (tp == null)
                {
                    fromCtrl = CreatNewMoldeIns("Ebada.Scgl.Lcgl.dll", "frmLP", "", "表单执行平台");
                }
                else
                {
                    fromCtrl = CreatNewMoldeIns(tp.AssemblyFileName, tp.ModuTypes, tp.MethodName, tp.ModuName);

                }
                IList<WF_ModleUsedFunc> mulist = MainHelper.PlatformSqlMap.GetList<WF_ModleUsedFunc>(" where WorkflowId='" + dt.Rows[0]["WorkflowId"] + "' and WorktaskId='" + dt.Rows[0]["WorktaskId"] + "' and Modu_ID='" + tp.Modu_ID + "'");
                if (mulist.Count > 0) IniCreatModle(fromCtrl, mulist);
                return fromCtrl;
            }

            return null;


        }
        /// <summary>
        /// 获得新创建的流程的第一个节点关联的表单
        /// </summary>
        /// <param name="kind">流程名称（工作票：dzczp操作票、yzgzp一种工作票、ezgzp二种工作票、xlqxp抢修单）</param>
        /// <param name="userID">用户ID</param>
        /// <returns>bool true有权限 false 无权限</returns>

        public static LP_Temple GetNewWorkTaskTemple(string kind, string userID)
        {
            DataTable dt = null;
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
            if (dt.Rows.Count > 0)
            {
                WF_WorkTaskControls wtc = MainHelper.PlatformSqlMap.GetOne<WF_WorkTaskControls>(" where WorkflowId='" + dt.Rows[0]["WorkflowId"] + "' and WorktaskId='" + dt.Rows[0]["WorktaskId"] + "'");
                if (wtc == null) return null;
                LP_Temple tp = MainHelper.PlatformSqlMap.GetOneByKey<LP_Temple>(wtc.UserControlId);
                if (tp == null) return null;
                else
                    return tp;
            }

            return null;


        }
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
        public static DataTable GetGZPRecordSartWorkData(string kind, string userID)
        {

            DataTable dt = null;
            string workFlowId = "", workTaskId = "";

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
            //workFlowId = dt.Rows[0]["WorkFlowId"].ToString();
            //workTaskId = dt.Rows[0]["workTaskId"].ToString();
            //WF_WorkTask wt = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkTask>(workTaskId);
            return dt;
        }
        public static string GetGZPRecordSartStatus(string kind, string userID)
        {

            DataTable dt = null;
            string workFlowId = "", workTaskId = "";

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
            return wt.TaskCaption;
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
            return RunNewGZPRecord(recordID, kind, userID, true);
        }
        /// <summary>
        /// 创建工作票流程
        /// </summary>
        /// <param name="recordID">记录ID</param>
        /// <param name="kind">工作票种类（01操作票、02一种工作票、03二种工作票、04抢修单）</param>
        /// <param name="userID">用户ID</param>
        /// <param name="IsRun">流程是否流转</param>
        /// <returns>流程创建信息二维数组，[0]流程创建结果 [1]运行后流程的任务节点名称</returns>
        public static string[] RunNewGZPRecord(string recordID, string kind, string userID, bool IsRun)
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
            string[] strmes = new string[2];
            strmes[0] = CreatWorkFlow(userID, workFlowId, workTaskId, workFlowInstanceId, workTaskInstanceId, flowCaption, command, IsRun);

            WFP_RecordWorkTaskIns wpfrecord = new WFP_RecordWorkTaskIns();
            wpfrecord.RecordID = recordID;
            wpfrecord.WorkFlowId = workFlowId;
            wpfrecord.WorkFlowInsId = workFlowInstanceId;
            wpfrecord.WorkTaskId = workTaskId;
            wpfrecord.WorkTaskInsId = workTaskInstanceId;
            if (strmes[0].IndexOf("未提交至任何人") == -1) MainHelper.PlatformSqlMap.Create<WFP_RecordWorkTaskIns>(wpfrecord);

            strtemp = RecordWorkTask.GetWorkFlowTaskCaption(workTaskInstanceId);
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
            string nowtaskId = "", strsql = "", strtemp = "";
            string str1 = "未提交至任何人,请检查流程模板和组织机构配置是否正确!";

            WF_WorkTaskInstance workins = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkTaskInstance>(workTaskInsId);

            WF_OperatorInstance operins = MainHelper.PlatformSqlMap.GetOneByKey<WF_OperatorInstance>(operatorInsId);
            IList<WFP_RecordWorkTaskIns> wf = MainHelper.PlatformSqlMap.GetList<WFP_RecordWorkTaskIns>("SelectWFP_RecordWorkTaskInsList", "where RecordID='" + recordData.ID + "'");
            if (wf.Count == 0) return str1;
            object obj = MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskList", " where TaskCaption='" + newWorkTaskCap + "' and WorkFlowId='" + wf[0].WorkFlowId + "'  ");
            if (obj != null && operins != null)
            {



                mUser fromuser = MainHelper.PlatformSqlMap.GetOneByKey<mUser>(userID);
                nowtaskId = ((WF_WorkTask)obj).WorkTaskId;
                workins.SuccessMsg = "跳转至状态(" + newWorkTaskCap + ")!";
                workins.WorkTaskInsId = operins.WorkTaskInsId;
                workins.OperatedDes = fromuser.UserName;
                MainHelper.PlatformSqlMap.Update("UpdateWF_WorkTaskInstanceSuccessMsgByWorkTaskInsId", workins);
                workins =new WF_WorkTaskInstance ();
                //MainHelper.PlatformSqlMap.Delete<WF_WorkTaskInstance>(workins);
                workins.WorkTaskInsId = Guid.NewGuid().ToString();
                workins.WorkTaskId = nowtaskId;
                workins.StartTime = DateTime.Now;
                workins.TaskInsCaption = ((WF_WorkTask)obj).TaskCaption;
                workins.WorkFlowId= ((WF_WorkTask)obj).WorkFlowId;
                workins.WorkFlowInsId = wf[0].WorkFlowInsId;
                workins.OperatedDes = userID;
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


                        MainHelper.PlatformSqlMap.Create<WF_OperatorInstance>(operins);


                    }
                    recordData.Status = newWorkTaskCap;
                    strsql = "  update WF_WorkFlowInstance set nowtaskId='" + nowtaskId + "' where workflowInsid='" + workins.WorkFlowInsId + "'";
                    MainHelper.PlatformSqlMap.Update("UpdateWF_WorkFlowInstanceValue", strsql);
                    MainHelper.PlatformSqlMap.DeleteByWhere<WF_OperatorInstance>(" where WorkFlowInsId='" + operins.WorkFlowInsId + "' and WorkTaskInsId='" + workTaskInsId + "' ");
                    MainHelper.PlatformSqlMap.Update<LP_Record>(recordData);
                    MainHelper.PlatformSqlMap.Create<WF_WorkTaskInstance>(workins);
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
                if (recordIkind == "定期分析")
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
        public static bool HaveRunRecordFollowRole(string recordID, string userID)
        {
            IList<WFP_RecordWorkTaskIns> wf = MainHelper.PlatformSqlMap.GetList<WFP_RecordWorkTaskIns>("SelectWFP_RecordWorkTaskInsList", "where RecordID='" + recordID + "'");
            if (wf.Count == 0) return false;
            object obj = MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskPowerList", " where PowerName='全程跟踪' and WorkFlowId='" + wf[0].WorkFlowId + "' and WorkTaskId='" + wf[0].WorkFlowId + "'");
                    if (obj == null)
                        return false;
            string strSQL = " where Modu_ID='" + ((WF_WorkTaskPower)obj).Powerid + "' and RoleID in ( select RoleID from rUserRole where UserID='" +userID+ "')";
             return MainHelper.PlatformSqlMap.GetRowCount<rRoleModul>(strSQL) > 0 ? true : false;
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
            DataTable dt = WorkFlowInstance.SelectedWorkflowNowTask(userID, wf[0].WorkFlowId, wf[0].WorkFlowInsId, wfi.NowTaskId, 999);
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
            DataTable dt = WorkFlowInstance.SelectedWorkflowTask(wf[0].WorkFlowId, wf[0].WorkFlowInsId, wfi.NowTaskId, 999);
            return dt;
        }
        /// <summary>
        /// 获得流程图片（Bitmap）
        /// </summary>
        /// <param name="recordID">记录ID</param>
        /// <param name="sz">图片大小</param>
        /// <returns>Bitmap</returns>
        public static Bitmap WorkFlowBitmap(string recordID, Size sz)
        {
            Bitmap objBitmap = new Bitmap(sz.Width, sz.Height);
            IList<WFP_RecordWorkTaskIns> wf = MainHelper.PlatformSqlMap.GetList<WFP_RecordWorkTaskIns>("SelectWFP_RecordWorkTaskInsList", "where RecordID='" + recordID + "'");
            if (wf.Count == 0) return null;
            objBitmap = WorkFlowInstance.WorkFlowBitmap(wf[0].WorkFlowId, wf[0].WorkFlowInsId, sz);
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
            string strmes = CreatWorkFlow(userID, workFlowId, workTaskId, workFlowInstanceId, workTaskInstanceId, flowCaption, command);

            WFP_RecordWorkTaskIns wpfrecord = new WFP_RecordWorkTaskIns();
            wpfrecord.RecordID = recordID;
            wpfrecord.WorkFlowId = workFlowId;
            wpfrecord.WorkFlowInsId = workFlowInstanceId;
            wpfrecord.WorkTaskId = workTaskId;
            wpfrecord.WorkTaskInsId = workTaskInstanceId;

            if (strmes.IndexOf("未提交至任何人") == -1) MainHelper.PlatformSqlMap.Create<WFP_RecordWorkTaskIns>(wpfrecord);


            return strmes;
        }
        /// <summary>
        /// 删除指定记录相关的记录
        /// </summary>
        /// <param name="recordID">记录ID</param>
        public static void DeleteRecord(string recordID)
        {
            MainHelper.PlatformSqlMap.DeleteByWhere<PJ_gzrjnr>(" where ParentID='" + recordID + "'");
            MainHelper.PlatformSqlMap.DeleteByWhere<PJ_lcfj>(" where recordID='" + recordID + "'");
            MainHelper.PlatformSqlMap.DeleteByWhere<PJ_lcspyj>(" where recordID='" + recordID + "'");
            MainHelper.PlatformSqlMap.DeleteByWhere<WF_TableFieldValue>(" where recordID='" + recordID + "'");
            MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleCheckTable>(" where recordID='" + recordID + "'");
            IList<WFP_RecordWorkTaskIns> wf = MainHelper.PlatformSqlMap.GetList<WFP_RecordWorkTaskIns>("SelectWFP_RecordWorkTaskInsList", "where RecordID='" + recordID + "'");
            if (wf.Count == 0) return;
            {
                MainHelper.PlatformSqlMap.Delete<WFP_RecordWorkTaskIns>(wf[0]);
                MainHelper.PlatformSqlMap.DeleteByWhere<WF_ModleRecordWorkTaskIns>(" where RecordID='" + recordID + "' and WorkFlowInsId='" + wf[0].WorkFlowInsId + "'");
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

            return CreatWorkFlow(userID, WorkFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, FlowCaption, command, true);
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
        /// <param name="IsRun">流程是否流转</param>
        /// <returns>返回流程执行结果</returns>

        public static string CreatWorkFlow(string userID, string WorkFlowId, string workTaskId, string workFlowInstanceId, string WorkTaskInstanceId, string FlowCaption, string command, bool IsRun)
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
            wfruntime.IsDraft = (IsRun == false);//执行流程流转,IsRun是true流转，否则保存
            wfruntime.Start();
            if (!IsRun)
            {
                return userID;
            }
            return Toollips(WorkTaskInstanceId);
            //return "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="WorkTaskInsId"></param>
        /// <returns></returns>
        public static string GetWorkFlowTaskCaption(string WorkTaskInsId)
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

                            return wt.TaskCaption;

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
        public static bool HaveWorkFlowBackRole(string WorkTaskId, string WorkFlowId)
        {
            if (MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskPowerList", " where WorkTaskId='" + WorkTaskId + "' and WorkFlowId='" + WorkFlowId + "' and PowerName='" + WorkConst.WorkTask_Return + "'") != null)
                return true;
            return false;
        }
        /// <summary>
        /// 流程是否可以所有人导出
        /// </summary>
        /// <param name="WorkTaskId">任务节点id</param>
        /// <param name="WorkFlowId">流程ID</param>
        /// <returns>true ，可以导出 反之不能</returns>
        public static bool HaveWorkFlowAllExploreRole(string WorkTaskId, string WorkFlowId)
        {
            if (MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskPowerList", " where WorkTaskId='" + WorkTaskId + "' and WorkFlowId='" + WorkFlowId + "' and PowerName='" + WorkConst.WorkTask_WorkAllExplore + "'") != null)
                return true;
            return false;
        }
        /// <summary>
        /// 流程是否可以导出
        /// </summary>
        /// <param name="WorkTaskId">任务节点id</param>
        /// <param name="WorkFlowId">流程ID</param>
        /// <returns>true ，可以导出 反之不能</returns>
        public static bool HaveWorkFlowExploreRole(string WorkTaskId, string WorkFlowId)
        {
            if (MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskPowerList", " where WorkTaskId='" + WorkTaskId + "' and WorkFlowId='" + WorkFlowId + "' and PowerName='" + WorkConst.WorkTask_WorkExplore + "'") != null)
                return true;
            return false;
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
            if (TaskToWhoMsg == "")
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
                                    sql = "where MainWorkflowInsId='" + subwf.MainWorkflowInsId + "' and MainWorktaskId='" + subwf.MainWorktaskId + "'and WorkTaskId='" + subwf.NowTaskId + "' order by opertype";
                                    li = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskInstanceView>("SelectWF_WorkTaskInstanceViewList", sql);
                                    if (li.Count > 0)
                                    {
                                        TaskToWhoMsg = WorkTaskInstance.GetTaskToWhoMsg(li[0].PreviousTaskId);
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

            return TaskToWhoMsg = "成功提交至:" + TaskToWhoMsg + "。已完成该任务处理,可以关闭该窗口。";
        }

    }
}
