using System;
using System.Data;
using System.Collections;
using System.Drawing;
using Ebada.Client.Platform;

namespace Ebada.SCGL.WFlow.Tool
{
    /**//// <summary>
    /// ������ģ����� ��ժҪ˵����
    /// ����������ģ������з�����
    /// </summary>
    public class WorkFlowData
    {
        

        //������ģ��������ֶ�
        public string WorkFlowId = "";
        public string WorkFlowCaption = "";
        public string WorkFlowClassId = "";
        public bool isSignOut = false;
        /**//// <summary>
        /// �޸ġ��½����鿴����״̬
        /// </summary>
        public string State;
        /**//// <summary>
        /// �ڵ㼯��
        /// </summary>
        public ArrayList TaskItems = new ArrayList();
        /**//// <summary>
        /// ���߼���
        /// </summary>
        public ArrayList LineItems=new ArrayList();    

        public WorkFlowData()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }
        /**//// <summary>
        /// ���ɹ�����ģ�����
        /// </summary>
        /// <param name="workflowId">������id</param>
        /// <param name="state">��д״̬���½�\�޸�\���</param>
        /// <param name="taskItems"></param>
        /// <param name="lineItems"></param>
        public WorkFlowData(string workflowId, string state, ArrayList taskItems, ArrayList lineItems)
        {
            if (WorkFlowId.Trim().Length==0||WorkFlowId==null)
                throw new Exception("��ʼ��WorkFlowData�����State ����Ϊ�գ�");
            if (State.Trim().Length==0||State==null)
                throw new Exception("��ʼ��WorkFlowData�����State ����Ϊ�գ�");
            if (TaskItems==null)
                throw new Exception("��ʼ��WorkFlowData�����TaskItems ����Ϊ�գ�");
            if (LineItems==null)
                throw new Exception("��ʼ��WorkFlowData�����LineItems ����Ϊ�գ�");
            WorkFlowId=workflowId;
            TaskItems=taskItems;
            LineItems=lineItems;
            State=state;
        }
        
        /**//// <summary>
        /// ��ȡ����ģ��
        /// </summary>
        public void ReadWorkFlow( )
        {
            if (WorkFlowId.Trim().Length==0||WorkFlowId==null)
                throw new Exception("ReadWorkFlow��������WorkFlowId ����Ϊ�գ�");
            int taskType; 
            Point p = new Point(0, 0);
            TaskItems.Clear();
            LineItems.Clear();
            BaseComponent startTask=null, endTask=null;
            #region ��ȡ����ڵ�
            //��ȡ����ڵ�
            DataTable table = WorkFlowTask.GetWorkTasks(WorkFlowId);
            if (table!=null&&table.Rows.Count > 0 )
            {
                foreach (DataRow dr in table.Rows)
                {
                    taskType = Convert.ToInt32(dr["TaskTypeId"].ToString());
                    p.X = Convert.ToInt32(dr["iXPosition"].ToString());
                    p.Y = Convert.ToInt32(dr["iYPosition"].ToString());
                    
                    switch (taskType)
                    {
                        case 1://�����ڵ�
                            StartTask st=new StartTask(p,0);
                            st.TaskName = dr["TaskCaption"].ToString();
                            st.TaskId = dr["WorkTaskId"].ToString();
                            st.TaskType=taskType;
                            st.OperRule = dr["OperRule"].ToString();
                            st.WorkFlowId=dr["WorkFlowId"].ToString();
                            TaskItems.Add(st);
                            break;
                        case 2://�����ڵ�
                            EndTask edTask=new EndTask(p,0);
                            edTask.TaskName = dr["TaskCaption"].ToString();
                            edTask.TaskId = dr["WorkTaskId"].ToString();
                            edTask.TaskType=taskType;
                            edTask.WorkFlowId=dr["WorkFlowId"].ToString();
                            TaskItems.Add(edTask);
                            break;
                        case 3://�����ڵ�
                            AlternateTask alterTask=new AlternateTask(p,0);
                            alterTask.TaskName = dr["TaskCaption"].ToString();
                            alterTask.TaskId = dr["WorkTaskId"].ToString();
                            alterTask.TaskType=taskType;
                            alterTask.OperRule = dr["OperRule"].ToString();
                            alterTask.WorkFlowId=dr["WorkFlowId"].ToString();
                            alterTask.IsJumpSelf = Convert.ToBoolean(dr["IsJumpSelf"]);
                            TaskItems.Add(alterTask);
                            break;
                        case 4://�жϽڵ�
                            JudgeTask judgeTask=new JudgeTask(p,0);
                            judgeTask.TaskName = dr["TaskCaption"].ToString();
                            judgeTask.TaskId = dr["WorkTaskId"].ToString();
                            judgeTask.TaskType=taskType;
                            judgeTask.WorkFlowId=dr["WorkFlowId"].ToString();
                            judgeTask.TaskTypeAndOr = dr["TaskTypeAndOr"].ToString(); ;
                            TaskItems.Add(judgeTask);
                            break;
                        case 5://�鿴�ڵ�
                            ViewTask viewTask=new ViewTask(p,0);
                            viewTask.TaskName = dr["TaskCaption"].ToString();
                            viewTask.TaskId = dr["WorkTaskId"].ToString();
                            viewTask.TaskType=taskType;
                            viewTask.WorkFlowId=dr["WorkFlowId"].ToString();
                            viewTask.IsJumpSelf = Convert.ToBoolean(dr["IsJumpSelf"]);
                            TaskItems.Add(viewTask);
                            break;
                        
                        case 6://�����̽ڵ�
                            SubFlowTask subFlowTask=new SubFlowTask(p,0);
                            subFlowTask.TaskName = dr["TaskCaption"].ToString();
                            subFlowTask.TaskId = dr["WorkTaskId"].ToString();
                            subFlowTask.TaskType=taskType;
                            subFlowTask.WorkFlowId=dr["WorkFlowId"].ToString();
                            TaskItems.Add(subFlowTask);
                            break;


                    }

                }
                
            }
            #endregion
          #region ��ȡ����
             //**********��ȡ����ڵ�end
            table = WorkFlowLink.GetWorkLinks(WorkFlowId);
            if (table!=null&&table.Rows.Count > 0 )
            {
                foreach (DataRow dr in table.Rows)
                {
                    for (int j = 0; j < TaskItems.Count; j++ )    //������ֹ��
                    {
                        if(startTask==null || endTask==null)
                        {
                            if (startTask == null && ((BaseComponent)TaskItems[j]).TaskId.Equals(dr["StartTaskId"].ToString()) == true)
                            {
                                startTask = (BaseComponent)TaskItems[j];
                                if (MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskPowerList", " where WorkTaskId='" + startTask.TaskId + "' and WorkFlowId='" + startTask.WorkFlowId + "' and PowerName='�˻�'") != null)
                                {
                                    startTask.haveback =true ;
                                }
                            }
                            if (endTask == null && ((BaseComponent)TaskItems[j]).TaskId.Equals(dr["EndTaskId"].ToString()) == true)
                            {
                                endTask = (BaseComponent)TaskItems[j];
                                if (MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskPowerList", " where WorkTaskId='" + endTask.TaskId + "' and WorkFlowId='" + endTask.WorkFlowId + "' and PowerName='�˻�'") != null)
                                {
                                    endTask.haveback = true;
                                }
                            }
                        }
                    }

                    Link lnk = new Link(startTask, endTask);
                    lnk.linkGuid = dr["WorkLinkId"].ToString();
                    lnk.flowGuid = dr["WorkFlowId"].ToString();
                    lnk.CommandName = dr["CommandName"].ToString();
                    lnk.Condition = dr["Condition"].ToString();
                    lnk.Des=dr["Description"].ToString();
                    if(startTask!=endTask)
                    {
                        if(dr["BreakX"].ToString()!="")
                        {
                            string[] xx=dr["BreakX"].ToString().Split(',');
                            string[] yy=dr["BreakY"].ToString().Split(',');                        
                            for(int mm=0;mm<xx.Length;mm++)
                            {
                                lnk.breakPointX.Insert(lnk.breakPointX.Count-1,xx[mm]);
                                lnk.breakPointY.Insert(lnk.breakPointY.Count-1,yy[mm]);
                            }
                        }
                    }
                    LineItems.Add(lnk);
                    startTask=null;
                    endTask=null;
                }
            }
            #endregion

        }       
        /**//// <summary>
        /// ��������ģ��
        /// </summary>    
        public void SaveWorkFlow()
        {
            SaveWorkFlow(WorkFlowId,TaskItems,LineItems,State);

        }
        public    void SaveWorkFlow(string workFlowId,ArrayList taskItems,ArrayList lineItems,string state)
        {
            TaskItems=taskItems;
            LineItems=lineItems;
            WorkFlowId=workFlowId;
            State=state;
            if (WorkFlowId.Trim().Length==0||WorkFlowId==null)
                throw new Exception("SaveWorkFlow��������WorkFlowId ����Ϊ�գ�");
            if (State.Trim().Length==0||State==null)
                throw new Exception("SaveWorkFlow��������State ����Ϊ�գ�");
            if (TaskItems==null)
                throw new Exception("SaveWorkFlow��������TaskItems ����Ϊ�գ�");
            if (LineItems==null)
                throw new Exception("SaveWorkFlow��������LineItems ����Ϊ�գ�");

            if (this.State==WorkConst.STATE_ADD)
            {

                foreach (BaseComponent bc in TaskItems)
                {
                    if (bc.TaskExist())
                        bc.SaveUpdateTask();
                    else
                    bc.SaveInsertTask();

                }
                //��������
                foreach (Link lk in LineItems)
                {
                    if (lk.LinkExist())
                        lk.SaveUpdateLink();
                    else
                    lk.SaveInsertLink();
                    
                }

            }
            else
                if (this.State==WorkConst.STATE_MOD)
            {
                //����ڵ�

                foreach (BaseComponent bc in TaskItems)
                {
                    if (bc.TaskExist())
                        bc.SaveUpdateTask();
                    else
                        bc.SaveInsertTask();

                }
                //��������
                foreach (Link lk in LineItems)
                {
                    if (lk.LinkExist())
                        lk.SaveUpdateLink();
                    else
                        lk.SaveInsertLink();
                    
                }

            }

            
        }
    }
}

