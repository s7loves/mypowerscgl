using System;
using System.Data;
using System.Collections;
using System.Drawing;
using Ebada.Client.Platform;

namespace Ebada.SCGL.WFlow.Tool
{
    /**//// <summary>
    /// 工作流模板的类 的摘要说明。
    /// 操作工作流模板的所有方法。
    /// </summary>
    public class WorkFlowData
    {
        

        //工作流模板的属性字段
        public string WorkFlowId = "";
        public string WorkFlowCaption = "";
        public string WorkFlowClassId = "";
        public bool isSignOut = false;
        /**//// <summary>
        /// 修改、新建、查看三种状态
        /// </summary>
        public string State;
        /**//// <summary>
        /// 节点集合
        /// </summary>
        public ArrayList TaskItems = new ArrayList();
        /**//// <summary>
        /// 连线集合
        /// </summary>
        public ArrayList LineItems=new ArrayList();    

        public WorkFlowData()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /**//// <summary>
        /// 生成工作流模板的类
        /// </summary>
        /// <param name="workflowId">工作流id</param>
        /// <param name="state">读写状态：新建\修改\浏览</param>
        /// <param name="taskItems"></param>
        /// <param name="lineItems"></param>
        public WorkFlowData(string workflowId, string state, ArrayList taskItems, ArrayList lineItems)
        {
            if (WorkFlowId.Trim().Length==0||WorkFlowId==null)
                throw new Exception("初始化WorkFlowData类错误，State 不能为空！");
            if (State.Trim().Length==0||State==null)
                throw new Exception("初始化WorkFlowData类错误，State 不能为空！");
            if (TaskItems==null)
                throw new Exception("初始化WorkFlowData类错误，TaskItems 不能为空！");
            if (LineItems==null)
                throw new Exception("初始化WorkFlowData类错误，LineItems 不能为空！");
            WorkFlowId=workflowId;
            TaskItems=taskItems;
            LineItems=lineItems;
            State=state;
        }
        
        /**//// <summary>
        /// 读取流程模板
        /// </summary>
        public void ReadWorkFlow( )
        {
            if (WorkFlowId.Trim().Length==0||WorkFlowId==null)
                throw new Exception("ReadWorkFlow方法错误，WorkFlowId 不能为空！");
            int taskType; 
            Point p = new Point(0, 0);
            TaskItems.Clear();
            LineItems.Clear();
            BaseComponent startTask=null, endTask=null;
            #region 读取任务节点
            //读取任务节点
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
                        case 1://启动节点
                            StartTask st=new StartTask(p,0);
                            st.TaskName = dr["TaskCaption"].ToString();
                            st.TaskId = dr["WorkTaskId"].ToString();
                            st.TaskType=taskType;
                            st.OperRule = dr["OperRule"].ToString();
                            st.WorkFlowId=dr["WorkFlowId"].ToString();
                            TaskItems.Add(st);
                            break;
                        case 2://结束节点
                            EndTask edTask=new EndTask(p,0);
                            edTask.TaskName = dr["TaskCaption"].ToString();
                            edTask.TaskId = dr["WorkTaskId"].ToString();
                            edTask.TaskType=taskType;
                            edTask.WorkFlowId=dr["WorkFlowId"].ToString();
                            TaskItems.Add(edTask);
                            break;
                        case 3://交互节点
                            AlternateTask alterTask=new AlternateTask(p,0);
                            alterTask.TaskName = dr["TaskCaption"].ToString();
                            alterTask.TaskId = dr["WorkTaskId"].ToString();
                            alterTask.TaskType=taskType;
                            alterTask.OperRule = dr["OperRule"].ToString();
                            alterTask.WorkFlowId=dr["WorkFlowId"].ToString();
                            alterTask.IsJumpSelf = Convert.ToBoolean(dr["IsJumpSelf"]);
                            TaskItems.Add(alterTask);
                            break;
                        case 4://判断节点
                            JudgeTask judgeTask=new JudgeTask(p,0);
                            judgeTask.TaskName = dr["TaskCaption"].ToString();
                            judgeTask.TaskId = dr["WorkTaskId"].ToString();
                            judgeTask.TaskType=taskType;
                            judgeTask.WorkFlowId=dr["WorkFlowId"].ToString();
                            judgeTask.TaskTypeAndOr = dr["TaskTypeAndOr"].ToString(); ;
                            TaskItems.Add(judgeTask);
                            break;
                        case 5://查看节点
                            ViewTask viewTask=new ViewTask(p,0);
                            viewTask.TaskName = dr["TaskCaption"].ToString();
                            viewTask.TaskId = dr["WorkTaskId"].ToString();
                            viewTask.TaskType=taskType;
                            viewTask.WorkFlowId=dr["WorkFlowId"].ToString();
                            viewTask.IsJumpSelf = Convert.ToBoolean(dr["IsJumpSelf"]);
                            TaskItems.Add(viewTask);
                            break;
                        
                        case 6://子流程节点
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
          #region 读取连线
             //**********读取任务节点end
            table = WorkFlowLink.GetWorkLinks(WorkFlowId);
            if (table!=null&&table.Rows.Count > 0 )
            {
                foreach (DataRow dr in table.Rows)
                {
                    for (int j = 0; j < TaskItems.Count; j++ )    //查找起止点
                    {
                        if(startTask==null || endTask==null)
                        {
                            if (startTask == null && ((BaseComponent)TaskItems[j]).TaskId.Equals(dr["StartTaskId"].ToString()) == true)
                            {
                                startTask = (BaseComponent)TaskItems[j];
                                if (MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskPowerList", " where WorkTaskId='" + startTask.TaskId + "' and WorkFlowId='" + startTask.WorkFlowId + "' and PowerName='退回'") != null)
                                {
                                    startTask.haveback =true ;
                                }
                            }
                            if (endTask == null && ((BaseComponent)TaskItems[j]).TaskId.Equals(dr["EndTaskId"].ToString()) == true)
                            {
                                endTask = (BaseComponent)TaskItems[j];
                                if (MainHelper.PlatformSqlMap.GetObject("SelectWF_WorkTaskPowerList", " where WorkTaskId='" + endTask.TaskId + "' and WorkFlowId='" + endTask.WorkFlowId + "' and PowerName='退回'") != null)
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
        /// 保存流程模板
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
                throw new Exception("SaveWorkFlow方法错误，WorkFlowId 不能为空！");
            if (State.Trim().Length==0||State==null)
                throw new Exception("SaveWorkFlow方法错误，State 不能为空！");
            if (TaskItems==null)
                throw new Exception("SaveWorkFlow方法错误，TaskItems 不能为空！");
            if (LineItems==null)
                throw new Exception("SaveWorkFlow方法错误，LineItems 不能为空！");

            if (this.State==WorkConst.STATE_ADD)
            {

                foreach (BaseComponent bc in TaskItems)
                {
                    if (bc.TaskExist())
                        bc.SaveUpdateTask();
                    else
                    bc.SaveInsertTask();

                }
                //保存连线
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
                //保存节点

                foreach (BaseComponent bc in TaskItems)
                {
                    if (bc.TaskExist())
                        bc.SaveUpdateTask();
                    else
                        bc.SaveInsertTask();

                }
                //保存连线
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

