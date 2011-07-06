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
        /// ����������ʵ��
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
            int       operType;   //��������
            string    OperContent;//������id
            int       OperRelation;//�����߹�ϵ
            string OperContentText = "";//�����ߵ�����

            //��ָ̬����һ��������
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


            tmpTeDt = WorkFlowTask.GetTaskOperator(workFlowId, workTaskId);//�������б� 
            //���û�д�����
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
                {//�ڴ˺����м��봦���߲���
                    case 1://����������
                        string StartflowUser = InstanceType.GetStartWorkflowUser(workFlowInstanceId);
                        string StartflowUserName = UserData.GetUserNameById(StartflowUser);
                        operParam.OperContent=StartflowUser;
                        operParam.OperContenText = StartflowUserName;
                        if (OperRelation == 0)//�޴������ϵ
                            InstanceType.AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        else
                            InstanceType.UserRelation(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);

                        break;
                    case 2://ĳһ����ʵ�ʴ�����
                        DataTable dtTaskUser = InstanceType.GetTaskInstanceUser(workFlowInstanceId, OperContent);

                        foreach (DataRow drUser in dtTaskUser.Rows)
                        {
                            string rlUserId = drUser["UserID"].ToString();
                            string rlUserName = UserData.GetUserNameById(rlUserId);
                            operParam.OperContent = rlUserId;
                            operParam.OperContenText = rlUserName;
                            if (OperRelation == 0)//�޴������ϵ
                                InstanceType.AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                            else

                                InstanceType.UserRelation(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);

                        }
                        
                        break;
                    case 3://ָ����Ա
                        if (OperRelation == 0)
                            InstanceType.AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        else
                            InstanceType.UserRelation(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId,operParam);
                        break;
                    case 4://����
                        if (OperRelation == 0)
                            InstanceType.AssignArchitecture(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        else
                            InstanceType.ArchRelation(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        break;
                    case 5://��ɫ
                        InstanceType.AssignGroup(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        break;
                    case 6://��λ
                        InstanceType.AssignArchitecture(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        break;
                    case 7://�ӱ����л�ȡ
                        string varUser = getWorkTaskVarValue(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, OperContent);
                        string varUserName = UserData.GetUserNameById(varUser);
                        operParam.OperContent = varUser;
                        operParam.OperContenText = varUserName;
                        if (OperRelation == 0)//�޴����߹�ϵ
                            InstanceType.AssignUser(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        else
                            InstanceType.UserRelation(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);

                        break;
                    case 8://ĳһ����ѡ��Ĵ�����
                        Console.WriteLine("�޴�����");
                        break;
                    case 9://������
                        InstanceType.AssignAll(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, operParam);
                        break;
                    case 10://ָ��
                        Console.WriteLine("�޴�����");
                        break;
                    case 11://��Ȩ
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
            string varName = "";//������<%��ǰ�û�%>
            string varValue = "";
            string expressText = "";//����ǰ���ʽ
            int len = 0;//���ʽ����
            char firstchar;
            char secondchar;
            char startVar = '2';//0��ʼȡ�����ģ�1 ȡ����������2����
            expressText = condition;//����ǰ���ʽ
            len = expressText.Length;
            if (expressText.Trim().Length == 0) { expressText = "1=1"; }//������
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
                    else//����ȡvarname
                        if (startVar == '1')
                        {
                            string varflag = "";
                            varName = varName + firstchar + secondchar;
                            if (varName.Length >= 6)
                            {
                                varflag = varName.Substring(2, 4);
                            }
                            if (varflag==WorkFlowConst.SYS_VarFlag)//ϵͳ����
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
        /// ����һ�����ʽ��ֵ
        /// </summary>
        private  static bool ExpressPass(string userId, string workFlowId, string workTaskId, string workFlowInstanceId, string WorkTaskInstanceId,string condition)
        {
            try
            {
                string expressText = GetExpressResult(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, condition);
                //DebugHF.WriteErrorLog("����"+condition+":" + expressText, workFlowInstanceId);
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
        /// ȡϵͳ����ֵ
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
        /// ȡ���̱��������������ֵ�����ߵı����������ظ�
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
            string varAccessType = "";//��������
            string varType = "";
            string varSql = "";
            string resultValue = "";
            string tmpVarName = "";
            tmpVarName = varName.Substring(2, varName.Length - 4);//ȥ����ͷ��<%%>

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

            if (varAccessType == WorkFlowConst.Access_WorkFlow)//���̱���
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
                if (varAccessType == WorkFlowConst.Access_WorkTask)//���̱���
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
            if (varType == WorkFlowConst.SYSVarType_string) resultValue = "'" + resultValue + "'";//�ַ���Ҫ�ӵ�����
            if (string.IsNullOrEmpty(resultValue)) resultValue = "'" + resultValue + "'";//Ĭ�Ϸ��ش����ŵĿ��ַ���
            return resultValue;
        }       

            /**//// <summary>
            /// �������з�������������ʵ��
            /// </summary>
            /// <param name="userId">������Id</param>
            /// <param name="workFlowId">������ģ��id</param>
            /// <param name="workTaskId">��ǰ����Id</param>
            /// <param name="workFlowInstanceId">������ʵ��Id</param>
            /// <param name="WorkTaskInstanceId">ԭ����ʵ��Id</param>
            /// <param name="operatorInstanceId">������ʵ��Id</param>
            /// <param name="commandName">����</param>
        public static string CreateNextTaskInstance(string userId, string workFlowId, string workTaskId, 
               string workFlowInstanceId, string WorkTaskInstanceId,string operatorInstanceId, string commandName)
        {        
            string condition = "";//����
            string priority  = "";//���ȼ���ִֻ�����ȼ���ߵķ�֧��������ȼ���ͬ ��ôͬʱִ�С�
            string endTaskId = "";//��������ڵ�Id
            string endoperRule = "";//���������߲���
            string startoperRule = "";//��ǰ�������߲���  
            string taskType = "";//�ڵ�����
            string endTaskTypeAndOr = "";//���ƽڵ�ר�ã���ʾand/or
            string userName = "";
            userName = UserData.GetUserNameById(userId);
            OperParameter OperParam = new OperParameter();//���������߲���
            DataTable dt = GetLineEndTasks(workFlowId, workTaskId, commandName);
            if (dt != null && dt.Rows.Count > 0)
            {
                //�����˺����ڵ�
                    #region �����˺����ڵ�
                int l = dt.Rows.Count;
                string branchPriority = dt.Rows[0]["priority"].ToString();//���ȼ�
                //����������������������ڵ�
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
                    if (priority != branchPriority) break;//ִֻ�����ȼ���ߵķ�֧
                    if (ExpressPass(userId, workFlowId, workTaskId, workFlowInstanceId, WorkTaskInstanceId, condition))//��������������ڵ�
                    {
                        switch (taskType)
                        {

                            case "2"://�����ڵ�
                                {
                                    //�����ڵ�
                                    #region �����ڵ�
                                    //����һ�������ڵ��ʵ��
                                    string newEndTaskId = Guid.NewGuid().ToString();//����������ʵ��Id
                                    WorkTaskInstance endWorktaskIns = new WorkTaskInstance();
                                    endWorktaskIns.WorkflowId = workFlowId;
                                    endWorktaskIns.WorktaskId = endTaskId;
                                    endWorktaskIns.WorkflowInsId = workFlowInstanceId;
                                    endWorktaskIns.WorktaskInsId = newEndTaskId;
                                    endWorktaskIns.PreviousTaskId = WorkTaskInstanceId;
                                    endWorktaskIns.TaskInsCaption = WorkFlowTask.GetTaskCaption(endTaskId);
                                    endWorktaskIns.Status = "2";//�����ڵ㲻��Ҫ�ٴ���,���˴�����Ϊ3,���ý���ʵ�����޸ĸ�ֵ=3
                                    endWorktaskIns.Create();

                                    //���ô�����ʵ����������
                                    OperatorInstance.SetOperatorInstanceOver(userId, operatorInstanceId);
                                    //��������ʵ����������
                                    WorkTaskInstance.SetWorkTaskInstanceOver(userName, WorkTaskInstanceId);
                                    WorkTaskInstance.SetWorkTaskInstanceOver(userName, newEndTaskId);//�����ڵ�ʵ�� ����
                                    //��������ʵ����������
                                    WorkFlowInstance.SetWorkflowInstanceOver(workFlowInstanceId);
                                    //�趨����ʵ���ĵ�ǰλ��
                                    WorkFlowInstance.SetCurrTaskId(workFlowInstanceId, endTaskId);
                                    WorkTaskInstance.SetSuccessMsg(WorkFlowConst.WorkflowOverMsg, WorkTaskInstanceId);//�����ڵ㵥������,�����ύ��˭��
                                    //����Ƿ������̵���
                                    DataTable OperInfo;
                                    OperInfo = WorkFlowInstance.GetWorkflowInstance(workFlowInstanceId);
                                    if (OperInfo != null && OperInfo.Rows.Count > 0)
                                    {
                                        bool isSubWorkflow = false;//�Ƿ��������̵���
                                        string MainWorkflowInsId = "";
                                        string MainWorktaskId = "";
                                        string MainWorkflowId = "";
                                        string MainWorktaskInsId = "";
                                        isSubWorkflow = Convert.ToBoolean(OperInfo.Rows[0]["isSubWorkflow"]);
                                        MainWorkflowInsId = OperInfo.Rows[0]["MainWorkflowInsId"].ToString();//������ʵ��Id
                                        MainWorktaskId = OperInfo.Rows[0]["MainWorktaskId"].ToString();//�����̽ڵ�ģ��Id
                                        MainWorkflowId = OperInfo.Rows[0]["MainWorkflowId"].ToString();//������ģ��Id
                                        MainWorktaskInsId = OperInfo.Rows[0]["MainWorktaskInsId"].ToString();//������ʵ��Id�������ӽڵ�ǰ������ڵ�ʵ��
                                        if (isSubWorkflow)
                                        {
                                            //����һ�������̽ڵ�ʵ���ۼ�����ʾ�����̽ڵ㴦�����
                                            string newTaskId = Guid.NewGuid().ToString();//����������ʵ��Id
                                            WorkTaskInstance workTaskInstance = new WorkTaskInstance();
                                            workTaskInstance.WorkflowId = MainWorkflowId;
                                            workTaskInstance.WorktaskId = MainWorktaskId;
                                            workTaskInstance.WorkflowInsId = MainWorkflowInsId;
                                            workTaskInstance.WorktaskInsId = newTaskId;
                                            workTaskInstance.PreviousTaskId = MainWorktaskInsId;
                                            workTaskInstance.TaskInsCaption = "������";
                                            workTaskInstance.Status = "3";
                                            workTaskInstance.Create();
                                            string result=  CreateNextTaskInstance(userId, MainWorkflowId, MainWorktaskId, MainWorkflowInsId, newTaskId, operatorInstanceId, "�ύ");
                                            if (result != WorkFlowConst.SuccessCode) return result;
                                        }

                                    }


                                    #endregion
                                    break;
                                }

                            case "3":
                                {
                                    //�����ڵ�
                                    #region �����ڵ�

                                    if (endoperRule == "1")//���������񣬴�ʱֻ����һ������ʵ�����������ʵ��
                                    {
                                        //����һ������ʵ��
                                        string newTaskId = Guid.NewGuid().ToString();//����������ʵ��Id
                                        WorkTaskInstance workTaskInstance = new WorkTaskInstance();
                                        workTaskInstance.WorkflowId = workFlowId;
                                        workTaskInstance.WorktaskId = endTaskId;
                                        workTaskInstance.WorkflowInsId = workFlowInstanceId;
                                        workTaskInstance.WorktaskInsId = newTaskId;
                                        workTaskInstance.PreviousTaskId = WorkTaskInstanceId;
                                        workTaskInstance.TaskInsCaption = WorkFlowTask.GetTaskCaption(endTaskId);
                                        workTaskInstance.Status = "1";
                                        workTaskInstance.Create();

                                        //�������������

                                       string result= CreateOperInstance(userId, WorkTaskInstanceId, workTaskId, workFlowId, endTaskId, workFlowInstanceId, newTaskId, OperParam);//����������ʵ��
                                       if (result != WorkFlowConst.SuccessCode) return result;
                                    }
                                    else
                                        if (endoperRule == "2")//�������˶�Ҫ������ʱÿ�������߲���һ������ʵ��
                                        {
                                            //��������ʵ���ʹ�����

                                           string result= CreateOperInstance(userId, WorkTaskInstanceId, workTaskId, workFlowId, endTaskId, workFlowInstanceId, WorkTaskInstanceId, OperParam);
                                           if (result != WorkFlowConst.SuccessCode) return result;
                                        }
                                    //���ô�����ʵ����������
                                    OperatorInstance.SetOperatorInstanceOver(userId, operatorInstanceId);
                                    //��������ʵ����������
                                    WorkTaskInstance.SetWorkTaskInstanceOver(userName, WorkTaskInstanceId);
                                    //�趨����ʵ���ĵ�ǰλ��
                                    WorkFlowInstance.SetCurrTaskId(workFlowInstanceId, endTaskId);
                                    //�趨����ʵ���ɹ��ύ��Ϣ
                                    WorkTaskInstance.SetSuccessMsg(WorkFlowConst.SuccessMsg, WorkTaskInstanceId);
                                    #endregion
                                    break;
                                }

                            case "4"://���ƽڵ�
                                {
                                    //���ƽڵ�
                                    #region ���ƽڵ�
                                    //���ô�����ʵ����������
                                    OperatorInstance.SetOperatorInstanceOver(userId, operatorInstanceId);
                                    //��������ʵ����������
                                    WorkTaskInstance.SetWorkTaskInstanceOver(userName, WorkTaskInstanceId);
                                    //�趨����ʵ���ĵ�ǰλ��
                                    WorkFlowInstance.SetCurrTaskId(workFlowInstanceId, endTaskId);
                                    //�趨����ʵ���ɹ��ύ��Ϣ
                                    WorkTaskInstance.SetSuccessMsg(WorkFlowConst.SuccessMsg, WorkTaskInstanceId);
                                    //******start����жϽڵ�ǰ������Խڵ������ʵ���Ƿ����


                                    //ȡ���ƽڵ�ǰ�����Խڵ�,��������ж�
                                    DataTable dtstart = GetLineStartTasks(workFlowId, endTaskId);
                                    bool allPass = true;//ȫ��ͨ��
                                    foreach (DataRow dr1 in dtstart.Rows)
                                    {
                                        string taskId = dr1["StartTaskId"].ToString();
                                        if (endTaskTypeAndOr == WorkConst.Command_Or)//or��֧
                                        {
                                            if (isPassJudge(workFlowId, workFlowInstanceId, taskId, endTaskTypeAndOr))//�ж�ÿ���ڵ�ʵ���Ƿ����
                                            {
                                                allPass = true;
                                                break;//�����һ��ͨ�����ɡ�
                                            }
                                            else allPass = false;
                                        }
                                        else//and��֧
                                        {
                                            if (!isPassJudge(workFlowId, workFlowInstanceId, taskId, endTaskTypeAndOr))//�ж�ÿ���ڵ�ʵ���Ƿ����
                                            {
                                                allPass = false;
                                                break;//�����һ��δ��ɵģ��������µ�ʵ�������̵ȴ���
                                            }
                                        }

                                      

                                    }

                                    //********end����жϽڵ�ǰ������Խڵ������ʵ������

                                    //����жϽڵ�ǰ�������ʵ��ȫ����ɣ��Զ����еݹ飬������һ����ʵ����
                                    if (allPass)
                                    {
                                        //����һ���жϽڵ�ʵ��
                                        string newTaskId = Guid.NewGuid().ToString();//����������ʵ��Id
                                        WorkTaskInstance workTaskInstance = new WorkTaskInstance();
                                        workTaskInstance.WorkflowId = workFlowId;
                                        workTaskInstance.WorktaskId = endTaskId;
                                        workTaskInstance.WorkflowInsId = workFlowInstanceId;
                                        workTaskInstance.WorktaskInsId = newTaskId;
                                        workTaskInstance.PreviousTaskId = WorkTaskInstanceId;
                                        workTaskInstance.TaskInsCaption = endTaskTypeAndOr;
                                        workTaskInstance.Status = "3";
                                        workTaskInstance.Create();
                                        string result= CreateNextTaskInstance(userId, workFlowId, endTaskId, workFlowInstanceId, newTaskId, operatorInstanceId, "�ύ");
                                        if (result != WorkFlowConst.SuccessCode) return result;
                                    }
                                    #endregion
                                    break;
                                }
                            case "5"://�鿴�ڵ�
                                {
                                    //�鿴�ڵ�
                                    #region �鿴�ڵ�
                                    if (endoperRule == "1")//���������񣬴�ʱֻ����һ������ʵ�����������ʵ��
                                    {
                                        //����һ������ʵ��
                                        string newTaskId = Guid.NewGuid().ToString();//����������ʵ��Id
                                        WorkTaskInstance workTaskInstance = new WorkTaskInstance();
                                        workTaskInstance.WorkflowId = workFlowId;
                                        workTaskInstance.WorktaskId = endTaskId;
                                        workTaskInstance.WorkflowInsId = workFlowInstanceId;
                                        workTaskInstance.WorktaskInsId = newTaskId;
                                        workTaskInstance.PreviousTaskId = WorkTaskInstanceId;
                                        workTaskInstance.TaskInsCaption = WorkFlowTask.GetTaskCaption(endTaskId);
                                        workTaskInstance.Status = "1";
                                        workTaskInstance.Create();

                                        //�������������

                                       string result= CreateOperInstance(userId, WorkTaskInstanceId, workTaskId, workFlowId, endTaskId, workFlowInstanceId, newTaskId, OperParam);//��������ʵ��
                                       if (result != WorkFlowConst.SuccessCode) return result;
                                    }
                                    else
                                        if (endoperRule == "2")//�������˶�Ҫ������ʱÿ�������߲���һ������ʵ��
                                        {
                                            //��������ʵ���ʹ�����

                                          string result=CreateOperInstance(userId, WorkTaskInstanceId, workTaskId, workFlowId, endTaskId, workFlowInstanceId, WorkTaskInstanceId, OperParam);
                                          if (result != WorkFlowConst.SuccessCode) return result;
                                        }
                                    //���ô�����ʵ����������
                                    OperatorInstance.SetOperatorInstanceOver(userId, operatorInstanceId);
                                    //��������ʵ����������
                                    WorkTaskInstance.SetWorkTaskInstanceOver(userName, WorkTaskInstanceId);
                                    //�趨����ʵ���ĵ�ǰλ��
                                    WorkFlowInstance.SetCurrTaskId(workFlowInstanceId, endTaskId);
                                    //�趨����ʵ���ɹ��ύ��Ϣ
                                    WorkTaskInstance.SetSuccessMsg(WorkFlowConst.SuccessMsg, WorkTaskInstanceId);
                                    #endregion
                                    break;
                                }
                            case "6"://�����̽ڵ�
                                {
                                    //�����̽ڵ�
                                    #region �����̽ڵ�
                                    DataTable subWf = SubWorkFlow.GetSubWorkflowTable(workFlowId, endTaskId);
                                    if (subWf != null && subWf.Rows.Count > 0)
                                    {
                                        string subWorkflowId = subWf.Rows[0]["subWorkflowId"].ToString();
                                        string subStartTaskId = subWf.Rows[0]["subStartTaskId"].ToString();
                                        string subWorkflowCaption = subWf.Rows[0]["subWorkflowCaption"].ToString();
                                        //*******����������
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
                                        wfruntime.MainWorktaskInsId = WorkTaskInstanceId;//��¼����������֮ǰ������ʵ��
                                        wfruntime.WorkFlowNo = "subWorkflow";
                                        wfruntime.CommandName = "�ύ";
                                        wfruntime.WorkflowInsCaption = subWorkflowCaption;
                                        wfruntime.IsDraft = true;//��ʼ�ڵ���Ҫ�������ݸ�״̬���ݲ��ύ
                                        wfruntime.Start();
                                        //���ô�����ʵ����������
                                        OperatorInstance.SetOperatorInstanceOver(userId, operatorInstanceId);
                                        //��������ʵ����������
                                        WorkTaskInstance.SetWorkTaskInstanceOver(userName, WorkTaskInstanceId);
                                        //�趨����ʵ���ĵ�ǰλ��
                                        WorkFlowInstance.SetCurrTaskId(workFlowInstanceId, endTaskId);
                                        //�趨����ʵ���ɹ��ύ��Ϣ
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
            {   //δ���ú����ڵ�
                return WorkFlowConst.NoFoundTaskCode;
            }
            return WorkFlowConst.SuccessCode;
           
        }

        /**//// <summary>
        ///  ȡ������ĩ�˵������б�table
        /// </summary>
        /// <param name="workFlowId">������ģ��Id</param>
        /// <param name="workTaskId">��ʼ������ģ��Id</param>
        /// <param name="commandName">��������</param>
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
        /// ȡ������ǰ�˵������б�table
        /// </summary>
        /// <param name="workFlowId">������ģ��Id</param>
        /// <param name="workTaskId">ĩ������ģ��Id</param>
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
        /// �жϽڵ�ʵ���Ƿ����
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
                if (taskTypeAndOr == WorkConst.Command_And)//and ��֧
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
                else//or��֧
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
        /// �ж�����ʵ���Ƿ������,�Դ����жϱ����ظ��ύ
        /// </summary>
        /// <param name="worktaskInsId">����ʵ��Id</param>
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
