using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Ebada.SCGL.WFlow.Tool;
using System.Collections;
using Ebada.Client.Platform;
using Ebada.Core;
using Ebada.Scgl.Model;
namespace Ebada.SCGL.WFlow.Engine
{
    public  class  WorkFlowHelper
    {
       
        public WorkFlowHelper()
        {
 
        }
        /**//// <summary>
        /// 创建处理者实例
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="oldWorktaskInsId"></param>
        /// <param name="oldworktaskId"></param>
        /// <param name="workFlowId"></param>
        /// <param name="workTaskId"></param>
        /// <param name="workFlowInstanceId"></param>
        /// <param name="WorkTaskInstanceId"></param>
        /// <param name="operRule"></param>
        /// <returns></returns>
        private static string CreateOperInstance(string userId, string oldWorktaskInsId,string oldworktaskId,string workFlowId, string workTaskId,
                                               string workFlowInstanceId, string WorkTaskInstanceId, OperParameter operParam)
        {

            DataTable tmpDyDt,tmpTeDt;
            int       operType;   //处理类型
            string    OperContent;//处理者id
            int       OperRelation;//处理者关系
            string OperContentText = "";//处理者的名称

            //动态指定下一任务处理人
            tmpDyDt = WorkTaskInstance.GetTaskInsNextOperTable(workFlowId, oldworktaskId, workFlowInstanceId, oldWorktaskInsId);
            foreach (DataRow dr in tmpDyDt.Rows)
            {
                OperContent = dr["UserID"].ToString();
                if (string.IsNullOrEmpty(OperContent)) continue;
                string userName = UserData.GetUserNameById(OperContent);
                operParam.OperContent = OperContent;
                operParam.OperContenText = userName;
                operParam.OperRelation = 0;
                operParam.OperType = 3;
                InstanceType.AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
            }


            tmpTeDt = WorkFlowTask.GetTaskOperator(workFlowId, workTaskId);//处理者列表 
            //如果没有处理者
            if ((tmpTeDt == null || tmpTeDt.Rows.Count <= 0) && (tmpDyDt == null || tmpDyDt.Rows.Count <= 0))
            {

                return WorkFlowConst.NoFoundTaskCode;
            }
            foreach (DataRow dr in tmpTeDt.Rows)
            {
                operType = System.Convert.ToInt16(dr["OperType"].ToString());
                OperContent = dr["OperContent"].ToString();
                OperRelation = Convert.ToInt16(dr["Relation"]);
                OperContentText = dr["OperDisplay"].ToString();
                operParam.OperType = operType;
                operParam.OperContent = OperContent;
                operParam.OperRelation = OperRelation;
                operParam.OperContenText = OperContentText;
                switch (operType)
                {//在此函数中加入处理者策略
                    case 1://流程启动者
                        string StartflowUser = InstanceType.GetStartWorkflowUser(workFlowInstanceId);
                        string StartflowUserName = UserData.GetUserNameById(StartflowUser);
                        operParam.OperContent=StartflowUser;
                        operParam.OperContenText = StartflowUserName;
                        if (OperRelation == 0)//无处理这关系
                            InstanceType.AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        else
                            InstanceType.UserRelation(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);

                        break;
                    case 2://某一任务实际处理者
                        DataTable dtTaskUser = InstanceType.GetTaskInstanceUser(workFlowInstanceId, OperContent);

                        foreach (DataRow drUser in dtTaskUser.Rows)
                        {
                            string rlUserId = drUser["UserID"].ToString();
                            string rlUserName = UserData.GetUserNameById(rlUserId);
                            operParam.OperContent = rlUserId;
                            operParam.OperContenText = rlUserName;
                            if (OperRelation == 0)//无处理这关系
                                InstanceType.AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                            else

                                InstanceType.UserRelation(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);

                        }
                        
                        break;
                    case 3://指定人员
                        if (OperRelation == 0)
                            InstanceType.AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        else
                            InstanceType.UserRelation(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId,operParam);
                        break;
                    case 4://部门
                        if (OperRelation == 0)
                            InstanceType.AssignArchitecture(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        else
                            InstanceType.ArchRelation(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        break;
                    case 5://角色
                        InstanceType.AssignGroup(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        break;
                    case 6://岗位
                        InstanceType.AssignArchitecture(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        break;
                    case 7://从变量中获取
                        string varUser = getWorkTaskVarValue(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, OperContent);
                        string varUserName = UserData.GetUserNameById(varUser);
                        operParam.OperContent = varUser;
                        operParam.OperContenText = varUserName;
                        if (OperRelation == 0)//无处理者关系
                            InstanceType.AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        else
                            InstanceType.UserRelation(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);

                        break;
                    case 8://某一任务选择的处理者
                        Console.WriteLine("无此类型");
                        break;
                    case 9://所有人
                        InstanceType.AssignAll(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        break;
                    case 10://指派
                        Console.WriteLine("无此类型");
                        break;
                    case 11://授权
                        Console.WriteLine("Case 2");
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
               

            }
            return WorkFlowConst.SuccessCode;
        }
        private  static string GetExpressResult(string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string WorkTaskInstanceId, string condition)
        {
            string varName = "";//变量名<%当前用户%>
            string varValue = "";
            string expressText = "";//解析前表达式
            int len = 0;//表达式长度
            char firstchar;
            char secondchar;
            char startVar = '2';//0开始取变量的，1 取变量结束，2空闲
            expressText = condition;//解析前表达式
            len = expressText.Length;
            if (expressText.Trim().Length == 0) { expressText = "1=1"; }//无条件
            else
                for (int i = 0; i < len - 1; i++)
                {

                    firstchar = expressText[i];
                    if (i + 1 < len) { secondchar = expressText[i + 1]; }
                    else secondchar = firstchar;
                    if (firstchar == '<' && secondchar == '%') startVar = '0';
                    else
                        if (firstchar == '%' && secondchar == '>') startVar = '1';

                    if (startVar == '0')
                    {
                        varName = varName + firstchar;
                    }
                    else//结束取varname
                        if (startVar == '1')
                        {
                            string varflag = "";
                            varName = varName + firstchar + secondchar;
                            if (varName.Length >= 6)
                            {
                                varflag = varName.Substring(2, 4);
                            }
                            if (varflag==WorkFlowConst.SYS_VarFlag)//系统变量
                            {
                                varValue = getSysVarValue(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, varName);
                            }
                            else
                            {
                                varValue = getWorkTaskVarValue(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, varName);
                            }
                            expressText = expressText.Replace(varName, varValue);
                            return GetExpressResult(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, expressText);

                        }
                }
            return expressText;

        }

        /**//// <summary>
        /// 返回一个表达式的值
        /// </summary>
        private  static bool ExpressPass(string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string WorkTaskInstanceId,string condition)
        {
            try
            {
                string expressText = GetExpressResult(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, condition);
                //DebugHF.WriteErrorLog("条件"+condition+":" + expressText, workFlowInstanceId);
                //string sqlStr = "select 1 where " + expressText;
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sqlStr;
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.RecordExists(sqlItem);
                string sql = "select '1' as Name from WF_WorkTaskView where " + expressText; 
                IList li = MainHelper.PlatformSqlMap.GetList("GetTableName2", sql);
                if (li.Count == 0) return false;
                return true;
            }
            catch (Exception ex)
            {
                //DebugHF.WriteErrorLog(string.Format(WorkFlowConst.ExpressErrorMsg, condition, ex.Message), workFlowInstanceId);
                throw new Exception(string.Format(WorkFlowConst.ExpressErrorMsg, condition, ex.Message));
            }
            
        }
        /**//// <summary>
        /// 取系统变量值
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="workFlowId"></param>
        /// <param name="workTaskId"></param>
        /// <param name="workFlowInstanceId"></param>
        /// <param name="WorkTaskInstanceId"></param>
        /// <returns></returns>
        private static string getSysVarValue(string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string WorkTaskInstanceId,string varName)
        {
      
            string result = "";
            
            return result;
        }
        /**//// <summary>
        /// 取流程变量或者任务变量值，两者的变量名不能重复
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="workFlowId"></param>
        /// <param name="workTaskId"></param>
        /// <param name="workFlowInstanceId"></param>
        /// <param name="WorkTaskInstanceId"></param>
        /// <returns></returns>
        private static string getWorkTaskVarValue(string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string WorkTaskInstanceId, string varName)
        {
            string varDataBase = "";
            string varTableName = "";
            string varFieldName = "";
            string varInitValue = "";
            string varAccessType = "";//变量类型
            string varType = "";
            string varSql = "";
            string resultValue = "";
            string tmpVarName = "";
            tmpVarName = varName.Substring(2, varName.Length - 4);//去掉两头的<%%>

            DataTable dt = TaskVar.GetTaskVarByName(tmpVarName);
            if (dt != null && dt.Rows.Count > 0)
            {
                varDataBase  = dt.Rows[0]["DataBaseName"].ToString();
                varTableName = dt.Rows[0]["TableName"].ToString();
                varFieldName = dt.Rows[0]["TableField"].ToString();
                varInitValue = dt.Rows[0]["InitValue"].ToString();
                varAccessType= dt.Rows[0]["AccessType"].ToString();
                varType = dt.Rows[0]["varType"].ToString();
            }

            if (varAccessType == WorkFlowConst.Access_WorkFlow)//流程变量
            {
                //varSql = "select " + varFieldName + " from " + varTableName + " where WorkFlowId=@workflowId and WorkFlowInsId=@workFlowInstanceId";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = varSql;
                //sqlItem.AppendParameter("@workflowId", workFlowId);
                //sqlItem.AppendParameter("@workFlowInstanceId", workFlowInstanceId);
                //ClientDBAgent agent = new ClientDBAgent();
                //resultValue= agent.ExecuteScalar(sqlItem);
                varSql = "select " + varFieldName + " as name from " + varTableName + " where id in (select RecordID  from WFP_RecordWorkTaskIns where WorkFlowId='" + workFlowId + "' and WorkFlowInsId='" + workFlowInstanceId + "')";

                //DataTable dt2 = null;
                IList li = MainHelper.PlatformSqlMap.GetList("GetTableName2", varSql);
                if (li.Count > 0)
                {
                     //dt2 = new DataTable();
                    resultValue = ((WF_WorkFlow)li[0]).Name;
                }
                //else
                //dt2 = ConvertHelper.ToDataTable(li);
                //if (!dt2.Columns.Contains(varFieldName))
                //dt2.Columns.Add(varFieldName, typeof(string));
                //for (int i = 0; i < dt2.Rows.Count; i++)
                //{
                //    dt2.Rows[i][varFieldName] = dt2.Rows[i]["name"];
                //}
                
            }
            else
                if (varAccessType == WorkFlowConst.Access_WorkTask)//流程变量
                {

                    //varSql = "select " + varFieldName + "  from " + varTableName + " where WorkFlowId=@workflowId and WorkFlowInsId=@workFlowInstanceId " +
                    //      " and WorkTaskInsId=@WorkTaskInsId ";
                    //SqlDataItem sqlItem = new SqlDataItem();
                    //sqlItem.CommandText = varSql;
                    //sqlItem.AppendParameter("@workflowId", workFlowId);
                    //sqlItem.AppendParameter("@workFlowInstanceId", workFlowInstanceId);
                    //sqlItem.AppendParameter("@WorkTaskInsId", WorkTaskInstanceId);
                    //ClientDBAgent agent = new ClientDBAgent();
                    //resultValue = agent.ExecuteScalar(sqlItem);
                    varSql = "select " + varFieldName + " as name from " + varTableName + " where WorkFlowId='" + workFlowId + "' and WorkFlowInsId='" + workFlowInstanceId + "'" +
                          " and WorkTaskInsId='" + WorkTaskInstanceId + "' ";

                    DataTable dt2 = null;
                    IList li = MainHelper.PlatformSqlMap.GetList("GetTableName2", varSql);
                    if (li.Count > 0)
                    {
                        //dt2 = new DataTable();
                        resultValue = ((WF_WorkFlow)li[0]).Name;
                    }
                    //if (li.Count == 0)
                    //{
                    //    dt2 = new DataTable();

                    //}
                    //dt2.Columns.Add(varFieldName, typeof(string));
                    //dt2 = ConvertHelper.ToDataTable(li);
                    //for (int i = 0; i < dt2.Rows.Count; i++)
                    //{
                    //    dt2.Rows[i][varFieldName] = dt2.Rows[i]["name"];
                    //}
                }

            if (string.IsNullOrEmpty(resultValue)) resultValue = varInitValue;
            if (varType == WorkFlowConst.SYSVarType_string) resultValue = "'" + resultValue + "'";//字符型要加单引号
            if (string.IsNullOrEmpty(resultValue)) resultValue = "'" + resultValue + "'";//默认返回带引号的空字符串
            return resultValue;
        }       

            /**//// <summary>
            /// 创建所有符合条件的任务实例
            /// </summary>
            /// <param name="userId">处理人Id</param>
            /// <param name="workFlowId">工作流模板id</param>
            /// <param name="workTaskId">当前任务Id</param>
            /// <param name="workFlowInstanceId">工作流实例Id</param>
            /// <param name="WorkTaskInstanceId">原任务实例Id</param>
            /// <param name="operatorInstanceId">处理者实例Id</param>
            /// <param name="commandName">命令</param>
        public static string CreateNextTaskInstance(string userId, string workFlowId, string workTaskId, 
               string workFlowInstanceId, string WorkTaskInstanceId,string operatorInstanceId, string commandName)
        {        
            string condition = "";//条件
            string priority  = "";//优先级，只执行优先级最高的分支，如果优先级相同 那么同时执行。
            string endTaskId = "";//后续任务节点Id
            string endoperRule = "";//新任务处理者策略
            string startoperRule = "";//当前任务处理者策略  
            string taskType = "";//节点类型
            string endTaskTypeAndOr = "";//控制节点专用，表示and/or
            string userName = "";
            userName = UserData.GetUserNameById(userId);
            OperParameter OperParam = new OperParameter();//创建处理者参数
            DataTable dt = GetLineEndTasks(workFlowId, workTaskId, commandName);
            if (dt != null && dt.Rows.Count > 0)
            {
                //配置了后续节点
                    #region 配置了后续节点
                int l = dt.Rows.Count;
                string branchPriority = dt.Rows[0]["priority"].ToString();//优先级
                //遍历满足条件的所有任务节点
                for (int i = 0; i < l; i++)
                {
                    DataRow dr = dt.Rows[i];
                    condition = dr["condition"].ToString();
                    priority = dr["priority"].ToString();
                    endTaskId = dr["endTaskId"].ToString();
                    endoperRule = dr["endoperRule"].ToString();
                    startoperRule = dr["startOperRule"].ToString();
                    taskType = dr["EndTaskTypeId"].ToString();
                    endTaskTypeAndOr = dr["endTaskTypeAndOr"].ToString();
                    OperParam.OperRule = endoperRule;
                    OperParam.IsJumpSelf = Convert.ToBoolean(dr["IsJumpSelf"]);
                    if (priority != branchPriority) break;//只执行优先级最高的分支
                    if (ExpressPass(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, condition))//满足条件的任务节点
                    {
                        switch (taskType)
                        {

                            case "2"://结束节点
                                {
                                    //结束节点
                                    #region 结束节点
                                    //产生一个结束节点的实例
                                    string newEndTaskId = Guid.NewGuid().ToString();//新任务处理者实例Id
                                    WorkTaskInstance endWorktaskIns = new WorkTaskInstance();
                                    endWorktaskIns.WorkflowId = workFlowId;
                                    endWorktaskIns.WorktaskId = endTaskId;
                                    endWorktaskIns.WorkflowInsId = workFlowInstanceId;
                                    endWorktaskIns.WorktaskInsId = newEndTaskId;
                                    endWorktaskIns.PreviousTaskId = WorkTaskInstanceId;
                                    endWorktaskIns.TaskInsCaption = WorkFlowTask.GetTaskCaption(endTaskId);
                                    endWorktaskIns.Status = "2";//结束节点不需要再处理,但此处不能为3,设置结束实例会修改该值=3
                                    endWorktaskIns.Create();

                                    //设置处理者实例正常结束
                                    OperatorInstance.SetOperatorInstanceOver(userId, operatorInstanceId);
                                    //设置任务实例正常结束
                                    WorkTaskInstance.SetWorkTaskInstanceOver(userName, WorkTaskInstanceId);
                                    WorkTaskInstance.SetWorkTaskInstanceOver(userName, newEndTaskId);//结束节点实例 结束
                                    //设置流程实例正常结束
                                    WorkFlowInstance.SetWorkflowInstanceOver(workFlowInstanceId);
                                    //设定流程实例的当前位置
                                    WorkFlowInstance.SetCurrTaskId(workFlowInstanceId, endTaskId);
                                    WorkTaskInstance.SetSuccessMsg(WorkFlowConst.WorkflowOverMsg, WorkTaskInstanceId);//结束节点单独处理,任务提交给谁了
                                    //检查是否子流程调用
                                    DataTable OperInfo;
                                    OperInfo = WorkFlowInstance.GetWorkflowInstance(workFlowInstanceId);
                                    if (OperInfo != null && OperInfo.Rows.Count > 0)
                                    {
                                        bool isSubWorkflow = false;//是否是子流程调用
                                        string MainWorkflowInsId = "";
                                        string MainWorktaskId = "";
                                        string MainWorkflowId = "";
                                        string MainWorktaskInsId = "";
                                        isSubWorkflow = Convert.ToBoolean(OperInfo.Rows[0]["isSubWorkflow"]);
                                        MainWorkflowInsId = OperInfo.Rows[0]["MainWorkflowInsId"].ToString();//主流程实例Id
                                        MainWorktaskId = OperInfo.Rows[0]["MainWorktaskId"].ToString();//子流程节点模板Id
                                        MainWorkflowId = OperInfo.Rows[0]["MainWorkflowId"].ToString();//主流程模板Id
                                        MainWorktaskInsId = OperInfo.Rows[0]["MainWorktaskInsId"].ToString();//主任务实例Id，进入子节点前的任务节点实例
                                        if (isSubWorkflow)
                                        {
                                            //创建一个子流程节点实例痕迹，表示子流程节点处理完成
                                            string newTaskId = Guid.NewGuid().ToString();//新任务处理者实例Id
                                            WorkTaskInstance workTaskInstance = new WorkTaskInstance();
                                            workTaskInstance.WorkflowId = MainWorkflowId;
                                            workTaskInstance.WorktaskId = MainWorktaskId;
                                            workTaskInstance.WorkflowInsId = MainWorkflowInsId;
                                            workTaskInstance.WorktaskInsId = newTaskId;
                                            workTaskInstance.PreviousTaskId = MainWorktaskInsId;
                                            workTaskInstance.TaskInsCaption = "子流程";
                                            workTaskInstance.Status = "3";
                                            workTaskInstance.Create();
                                            string result=  CreateNextTaskInstance(userId, MainWorkflowId, MainWorktaskId, MainWorkflowInsId, newTaskId, operatorInstanceId, "提交");
                                            if (result != WorkFlowConst.SuccessCode) return result;
                                        }

                                    }


                                    #endregion
                                    break;
                                }

                            case "3":
                                {
                                    //交互节点
                                    #region 交互节点

                                    if (endoperRule == "1")//共享处理任务，此时只产生一个任务实例多个处理者实例
                                    {
                                        //创建一个任务实例
                                        string newTaskId = Guid.NewGuid().ToString();//新任务处理者实例Id
                                        WorkTaskInstance workTaskInstance = new WorkTaskInstance();
                                        workTaskInstance.WorkflowId = workFlowId;
                                        workTaskInstance.WorktaskId = endTaskId;
                                        workTaskInstance.WorkflowInsId = workFlowInstanceId;
                                        workTaskInstance.WorktaskInsId = newTaskId;
                                        workTaskInstance.PreviousTaskId = WorkTaskInstanceId;
                                        workTaskInstance.TaskInsCaption = WorkFlowTask.GetTaskCaption(endTaskId);
                                        workTaskInstance.Status = "1";
                                        workTaskInstance.Create();

                                        //创建多个处理人

                                       string result= CreateOperInstance(userId, WorkTaskInstanceId, workTaskId, workFlowId, endTaskId, workFlowInstanceId, newTaskId, OperParam);//创建处理者实例
                                       if (result != WorkFlowConst.SuccessCode) return result;
                                    }
                                    else
                                        if (endoperRule == "2")//所以有人都要处理，此时每个处理者产生一个任务实例
                                        {
                                            //创建任务实例和处理人

                                           string result= CreateOperInstance(userId, WorkTaskInstanceId, workTaskId, workFlowId, endTaskId, workFlowInstanceId, WorkTaskInstanceId, OperParam);
                                           if (result != WorkFlowConst.SuccessCode) return result;
                                        }
                                    //设置处理者实例正常结束
                                    OperatorInstance.SetOperatorInstanceOver(userId, operatorInstanceId);
                                    //设置任务实例正常结束
                                    WorkTaskInstance.SetWorkTaskInstanceOver(userName, WorkTaskInstanceId);
                                    //设定流程实例的当前位置
                                    WorkFlowInstance.SetCurrTaskId(workFlowInstanceId, endTaskId);
                                    //设定任务实例成功提交信息
                                    WorkTaskInstance.SetSuccessMsg(WorkFlowConst.SuccessMsg, WorkTaskInstanceId);
                                    #endregion
                                    break;
                                }

                            case "4"://控制节点
                                {
                                    //控制节点
                                    #region 控制节点
                                    //设置处理者实例正常结束
                                    OperatorInstance.SetOperatorInstanceOver(userId, operatorInstanceId);
                                    //设置任务实例正常结束
                                    WorkTaskInstance.SetWorkTaskInstanceOver(userName, WorkTaskInstanceId);
                                    //设定流程实例的当前位置
                                    WorkFlowInstance.SetCurrTaskId(workFlowInstanceId, endTaskId);
                                    //设定任务实例成功提交信息
                                    WorkTaskInstance.SetSuccessMsg(WorkFlowConst.SuccessMsg, WorkTaskInstanceId);
                                    //******start检查判断节点前面的所以节点的任务实例是否都完成


                                    //取控制节点前端所以节点,进行逐个判断
                                    DataTable dtstart = GetLineStartTasks(workFlowId, endTaskId);
                                    bool allPass = true;//全部通过
                                    foreach (DataRow dr1 in dtstart.Rows)
                                    {
                                        string taskId = dr1["StartTaskId"].ToString();
                                        if (endTaskTypeAndOr == WorkConst.Command_Or)//or分支
                                        {
                                            if (isPassJudge(workFlowId, workFlowInstanceId, taskId, endTaskTypeAndOr))//判断每个节点实例是否完成
                                            {
                                                allPass = true;
                                                break;//如果有一个通过即可。
                                            }
                                            else allPass = false;
                                        }
                                        else//and分支
                                        {
                                            if (!isPassJudge(workFlowId, workFlowInstanceId, taskId, endTaskTypeAndOr))//判断每个节点实例是否完成
                                            {
                                                allPass = false;
                                                break;//如果有一个未完成的，不产生新的实例，流程等待。
                                            }
                                        }

                                      

                                    }

                                    //********end检查判断节点前面的所以节点的任务实例结束

                                    //如果判断节点前面的流程实例全部完成，自动进行递归，创建下一任务实例。
                                    if (allPass)
                                    {
                                        //创建一个判断节点实例
                                        string newTaskId = Guid.NewGuid().ToString();//新任务处理者实例Id
                                        WorkTaskInstance workTaskInstance = new WorkTaskInstance();
                                        workTaskInstance.WorkflowId = workFlowId;
                                        workTaskInstance.WorktaskId = endTaskId;
                                        workTaskInstance.WorkflowInsId = workFlowInstanceId;
                                        workTaskInstance.WorktaskInsId = newTaskId;
                                        workTaskInstance.PreviousTaskId = WorkTaskInstanceId;
                                        workTaskInstance.TaskInsCaption = endTaskTypeAndOr;
                                        workTaskInstance.Status = "3";
                                        workTaskInstance.Create();
                                        string result= CreateNextTaskInstance(userId, workFlowId, endTaskId, workFlowInstanceId, newTaskId, operatorInstanceId, "提交");
                                        if (result != WorkFlowConst.SuccessCode) return result;
                                    }
                                    #endregion
                                    break;
                                }
                            case "5"://查看节点
                                {
                                    //查看节点
                                    #region 查看节点
                                    if (endoperRule == "1")//共享处理任务，此时只产生一个任务实例多个处理者实例
                                    {
                                        //创建一个任务实例
                                        string newTaskId = Guid.NewGuid().ToString();//新任务处理者实例Id
                                        WorkTaskInstance workTaskInstance = new WorkTaskInstance();
                                        workTaskInstance.WorkflowId = workFlowId;
                                        workTaskInstance.WorktaskId = endTaskId;
                                        workTaskInstance.WorkflowInsId = workFlowInstanceId;
                                        workTaskInstance.WorktaskInsId = newTaskId;
                                        workTaskInstance.PreviousTaskId = WorkTaskInstanceId;
                                        workTaskInstance.TaskInsCaption = WorkFlowTask.GetTaskCaption(endTaskId);
                                        workTaskInstance.Status = "1";
                                        workTaskInstance.Create();

                                        //创建多个处理人

                                       string result= CreateOperInstance(userId, WorkTaskInstanceId, workTaskId, workFlowId, endTaskId, workFlowInstanceId, newTaskId, OperParam);//创建任务实例
                                       if (result != WorkFlowConst.SuccessCode) return result;
                                    }
                                    else
                                        if (endoperRule == "2")//所以有人都要处理，此时每个处理者产生一个任务实例
                                        {
                                            //创建任务实例和处理人

                                          string result=CreateOperInstance(userId, WorkTaskInstanceId, workTaskId, workFlowId, endTaskId, workFlowInstanceId, WorkTaskInstanceId, OperParam);
                                          if (result != WorkFlowConst.SuccessCode) return result;
                                        }
                                    //设置处理者实例正常结束
                                    OperatorInstance.SetOperatorInstanceOver(userId, operatorInstanceId);
                                    //设置任务实例正常结束
                                    WorkTaskInstance.SetWorkTaskInstanceOver(userName, WorkTaskInstanceId);
                                    //设定流程实例的当前位置
                                    WorkFlowInstance.SetCurrTaskId(workFlowInstanceId, endTaskId);
                                    //设定任务实例成功提交信息
                                    WorkTaskInstance.SetSuccessMsg(WorkFlowConst.SuccessMsg, WorkTaskInstanceId);
                                    #endregion
                                    break;
                                }
                            case "6"://子流程节点
                                {
                                    //子流程节点
                                    #region 子流程节点
                                    DataTable subWf = SubWorkFlow.GetSubWorkflowTable(workFlowId, endTaskId);
                                    if (subWf != null && subWf.Rows.Count > 0)
                                    {
                                        string subWorkflowId = subWf.Rows[0]["subWorkflowId"].ToString();
                                        string subStartTaskId = subWf.Rows[0]["subStartTaskId"].ToString();
                                        string subWorkflowCaption = subWf.Rows[0]["subWorkflowCaption"].ToString();
                                        //*******进入子流程
                                        WorkFlowRuntime wfruntime = new WorkFlowRuntime();
                                        wfruntime.UserId = userId;
                                        wfruntime.WorkFlowId = subWorkflowId;
                                        wfruntime.WorkTaskId = subStartTaskId;
                                        wfruntime.WorkFlowInstanceId = Guid.NewGuid().ToString();
                                        wfruntime.WorkTaskInstanceId = Guid.NewGuid().ToString();
                                        wfruntime.isSubWorkflow = true;
                                        wfruntime.MainWorkflowId = workFlowId;
                                        wfruntime.MainWorkflowInsId = workFlowInstanceId;
                                        wfruntime.MainWorktaskId = endTaskId;
                                        wfruntime.MainWorktaskInsId = WorkTaskInstanceId;//记录进入子流程之前的任务实例
                                        wfruntime.WorkFlowNo = "subWorkflow";
                                        wfruntime.CommandName = "提交";
                                        wfruntime.WorkflowInsCaption = subWorkflowCaption;
                                        wfruntime.IsDraft = true;//开始节点需要交互，草稿状态，暂不提交
                                        wfruntime.Start();
                                        //设置处理者实例正常结束
                                        OperatorInstance.SetOperatorInstanceOver(userId, operatorInstanceId);
                                        //设置任务实例正常结束
                                        WorkTaskInstance.SetWorkTaskInstanceOver(userName, WorkTaskInstanceId);
                                        //设定流程实例的当前位置
                                        WorkFlowInstance.SetCurrTaskId(workFlowInstanceId, endTaskId);
                                        //设定任务实例成功提交信息
                                        WorkTaskInstance.SetSuccessMsg(WorkFlowConst.SuccessMsg, WorkTaskInstanceId);
                                    }
                                    #endregion
                                    break;
                                }
                        }

                    }
                }
                #endregion
            }
            else
            {   //未配置后续节点
                return WorkFlowConst.NoFoundTaskCode;
            }
            return WorkFlowConst.SuccessCode;
           
        }

        /**//// <summary>
        ///  取得连线末端的任务列表table
        /// </summary>
        /// <param name="workFlowId">工作流模板Id</param>
        /// <param name="workTaskId">起始端任务模板Id</param>
        /// <param name="commandName">所属命令</param>
        /// <returns></returns>
        private  static DataTable GetLineEndTasks(string workFlowId, string workTaskId, string commandName)
        {
            try
            {
                
                //string sqlStr = "SELECT * FROM WorkTaskLinkView " +
                //              " where CommandName=@CommandName and starttaskid=@WorkflowTaskId and WorkFlowId=@WorkFlowId order by Priority";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sqlStr;
                //sqlItem.AppendParameter("@CommandName", commandName);
                //sqlItem.AppendParameter("@WorkflowTaskId", workTaskId);
                //sqlItem.AppendParameter("@WorkFlowId", workFlowId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return  agent.ExecuteDataTable(sqlItem);
                string tmpStr = " where  CommandName='" + commandName + "' and starttaskid='" + workTaskId + "' and WorkFlowId='" + workFlowId + "'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskLinkViewList", tmpStr);
                if (li.Count == 0)
                {
                    DataTable dt = new DataTable();

                    return dt;
                }
                return ConvertHelper.ToDataTable(li); 

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// 取得连线前端的任务列表table
        /// </summary>
        /// <param name="workFlowId">工作流模板Id</param>
        /// <param name="workTaskId">末端任务模板Id</param>
        /// <returns></returns>
        private  static DataTable GetLineStartTasks(string workFlowId, string workTaskId)
        {
            try
            {
               
                //string sqlStr = "SELECT * FROM WorkTaskLinkView " +
                //              " where  EndTaskId=@workTaskId and WorkFlowId=@WorkFlowId order by Priority";
                //SqlDataItem sqlItem = new SqlDataItem();
                //sqlItem.CommandText = sqlStr;
                //sqlItem.AppendParameter("@workTaskId", workTaskId);
                //sqlItem.AppendParameter("@WorkFlowId", workFlowId);
                //ClientDBAgent agent = new ClientDBAgent();
                //return agent.ExecuteDataTable(sqlItem);
                string tmpStr = " where  EndTaskId='" + workTaskId + "' and WorkFlowId=" + workFlowId + "'";
                IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskLinkViewList", workFlowId);
                if (li.Count == 0)
                {
                    DataTable dt = new DataTable();

                    return dt;
                }
                return ConvertHelper.ToDataTable(li); 
            }
            catch (Exception ex)
            {
                throw ex ;
            }
        }
        /**//// <summary>
        /// 判断节点实例是否都完成
        /// </summary>
        /// <param name="workFlowId"></param>
        /// <param name="workFlowInstanceId"></param>
        /// <param name="judgeTaskId"></param>
        /// <returns></returns>
        public static bool isPassJudge(string workFlowId, string workFlowInstanceId, string judgeTaskId, string taskTypeAndOr)
        {
            bool result = true;
            try
            {
                if (taskTypeAndOr == WorkConst.Command_And)//and 分支
                {
                    //string sql = "select * from WorkTaskInstance where WorkFlowInsId=@WorkFlowId"
                    //           +" and WorkTaskId=@workTaskId";
                    //SqlDataItem sqlItem = new SqlDataItem();
                    //sqlItem.CommandText = sql;
                    //sqlItem.AppendParameter("@workTaskId", judgeTaskId);
                    //sqlItem.AppendParameter("@WorkFlowId", workFlowInstanceId);
                    //ClientDBAgent agent = new ClientDBAgent();
                    string tmpStr = " where  WorkFlowInsId='" + workFlowInstanceId + "' and WorkTaskId='" + judgeTaskId + "'";
                    IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInstanceList", tmpStr);
                    if (li.Count == 0)
                    {
                        result = false;
                    }
                    else
                    {
                        DataTable dt = ConvertHelper.ToDataTable(li);
                         
                        if (dt == null || dt.Rows.Count == 0) result = false;
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["Status"].ToString() != "3")
                            { result = false; break; }

                        }
                    }
                }
                else//or分支
                {
                    //string sql = "select * from WorkTaskInstance where WorkFlowInsId='" + workFlowInstanceId
                    //      + "' and WorkTaskId='" + judgeTaskId+"'" ;
                    //SqlDataItem sqlItem = new SqlDataItem();
                    //sqlItem.CommandText = sql;
                    //sqlItem.AppendParameter("@workTaskId", judgeTaskId);
                    //sqlItem.AppendParameter("@WorkFlowId", workFlowInstanceId);
                    //ClientDBAgent agent = new ClientDBAgent();
                    //DataTable dt = agent.ExecuteDataTable(sqlItem);
                   
                    //if (dt == null || dt.Rows.Count == 0) result = false;
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    if (dr["Status"].ToString()== "3")
                    //    { result = true; break; }

                    //}
                    string tmpStr = " where  WorkFlowInsId='" + workFlowInstanceId + "' and WorkTaskId='" + judgeTaskId + "'";
                    IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInstanceList", tmpStr);
                    if (li.Count == 0)
                    {
                        result = false;
                    }
                    else
                    {
                        DataTable dt = ConvertHelper.ToDataTable(li);

                        if (dt == null || dt.Rows.Count == 0) result = false;
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["Status"].ToString() != "3")
                            { result = false; break; }

                        }
                    }
                }
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /**//// <summary>
        /// 判断任务实例是否已完成,以此来判断避免重复提交
        /// </summary>
        /// <param name="worktaskInsId">流程实例Id</param>
        /// <returns></returns>
        public static bool isTaskInsCompleted(string worktaskInsId)
        {
            //string sql = "select * from WorkTaskInstance where WorkTaskInsId=@worktaskInsId and Status='3'";
            //SqlDataItem sqlItem = new SqlDataItem();
            //sqlItem.CommandText = sql;
            //sqlItem.AppendParameter("@worktaskInsId", worktaskInsId);

            //ClientDBAgent agent = new ClientDBAgent();
            //DataTable dt = agent.ExecuteDataTable(sqlItem);
            //return agent.RecordExists(sqlItem);
            string tmpStr = " where  WorkTaskInsId='" + worktaskInsId + "' and Status='3'";
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_WorkTaskInstanceList", tmpStr);
            if (li.Count == 0)
            {
                return false;
            }
            return true;
        }
    }

    
}
