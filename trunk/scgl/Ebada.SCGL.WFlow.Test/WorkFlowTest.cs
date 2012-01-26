using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.SCGL.WFlow.Engine;
using Ebada.SCGL.WFlow.Tool;
using Ebada.Client;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections;
using HF.WorkFlow.Engine;

namespace Ebada.SCGL.WFlow.Test
{
    public partial class WorkFlowTest : Form
    {
        public WorkFlowTest()
        {
            InitializeComponent();
        }
        string workTaskId ="";
        string workFlowId = "";
        string workTaskInsId ="";
        string workFlowInsId = "";
        string operatorInsId = "";
        string pageState = "修改";//新建,修改,查看
        string OperStatus = "";//操作状态,0 未处理未认领，1处理完成，2指派他人，3认领未处理
        string userId = "010003";
        int x = 10;
        DataTable startdt = null;
        DataTable dt = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WorkFlowTest());
        }
        public string  toollips()
        {
         string title = "";
            string TaskToWhoMsg = "";
            string ResultMsg = "";
            
            TaskToWhoMsg = WorkTaskInstance.GetTaskToWhoMsg(workTaskInsId);
            ResultMsg = WorkTaskInstance.GetResultMsg(workTaskInsId);

            title = "操作结果:"+ResultMsg;
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
           
          return  TaskToWhoMsg = "成功提交至:" + TaskToWhoMsg+"。你已完成该任务处理,可以关闭该窗口。";
        }
        private void WorkFlowTest_Load(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "未认领任务(" + WorkFlowInstance.GetClaimingTaskCount(userId) + ")";
                label2.Text = "已认领任务(" + WorkFlowInstance.GetClaimedTaskCount(userId) + ")";
                label3.Text = "已完成任务(" + WorkFlowInstance.GetCompletedTaskCount(userId) + ")";
                label4.Text = "我参与的任务(" + WorkFlowInstance.GetAllTaskCount(userId) + ")";
                label5.Text = "异常终止的任务(" + WorkFlowInstance.GetAbnormalTaskCount(userId) + ")";
                label6.Text = "待办任务(" + WorkFlowInstance.GetToDoTasksCount(userId) + ")";
                startdt = WorkFlowTemplate.GetAllowsStartWorkFlows(userId);
                //gridControl1.DataSource = startdt; 
                label7.Text = "业务流程(" + startdt.Rows.Count + ")";
                //gridView1.FocusedRowHandle =0;  
                drpPriority.Items.Add("普通");
                drpPriority.Items.Add("紧急");
                drpPriority.Items.Add("特急");
                drpPriority.SelectedIndex = 1;
                if(dt==null)dt = new DataTable();
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("index", typeof(string));
                DataRow dr = dt.NewRow();
                dr["name"] = label1.Text;
                dr["index"] = 1;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["index"] = 2;
                dr["name"] = label2.Text;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["index"] = 3;
                dr["name"] = label3.Text;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["index"] = 4;
                dr["name"] = label4.Text;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["index"] = 5;
                dr["name"] = label5.Text;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["index"] = 6;
                dr["name"] = label6.Text;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["index"] = 7;
                dr["name"] = label7.Text;
                dt.Rows.Add(dr);
                gridControl2.DataSource = dt;
                gridView2.FocusedRowHandle = 0;
            }
            catch (Exception err)
            {
                this.Cursor = Cursors.Default;
                MsgBox.ShowException(err);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //fmWorkFlowIDE fm = new fmWorkFlowIDE("003",userId,"");
            fmWorkFlowIDE fm = new fmWorkFlowIDE();
            fm.ShowDialog();
        }
        
        /// <summary>
        /// 控制流程流转的命令按钮，如提交等
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runButtonEvent(object sender, EventArgs e)
        {
            //if (SaveUserControl(false))
            //{
            string command = (sender as Button).Text;
            WorkFlowRuntime wfruntime = new WorkFlowRuntime();
            wfruntime.UserId = userId;
            wfruntime.WorkFlowId = workFlowId;
            wfruntime.WorkTaskId = workTaskId;
            wfruntime.WorkFlowInstanceId = workFlowInsId;
            wfruntime.WorkTaskInstanceId = workTaskInsId;
            wfruntime.WorkFlowNo = FlowNo.Text;
            wfruntime.CommandName = command;
            wfruntime.Priority = drpPriority.SelectedIndex.ToString()  ;
            wfruntime.WorkflowInsCaption = WorkflowCaption.Text;
            wfruntime.IsDraft = false;//保存并执行流程流转
            wfruntime.Start();

            tooltip.Text = toollips();
            //}
        }
        /// <summary>
        /// 保存表单业务数据
        /// </summary>
        private bool SaveUserControl(bool IsDraft)
        {
            ////if (pageState == WorkConst.STATE_VIEW) return true;
            //if (WorkflowCaption.Text.Length == 0)
            //{
            //    MsgBox.ShowWarningMessageBox ("流程业务名不能为空!");
            //    WorkflowCaption.Focus();
            //    return false;
            //}
            //try
            //{
            //    foreach (BaseUserControl bc in UserCtrlList)
            //    {
            //        if (bc.CtrlState == WorkConst.STATE_VIEW) continue;//查看状态不执行保存
            //        bc.SaveUserControl(IsDraft);
            //    }
                return true;
            //}
            //catch
            //{
            //    throw;
            //}
        }
        private void TooltipInitData()
        {
            
                //string title = "";
                //string TaskToWhoMsg = "";
                //string ResultMsg = "";
                //worktaskInsId = Request["worktaskInsId"].ToString();
                //TaskToWhoMsg = WorkTaskInstance.GetTaskToWhoMsg(worktaskInsId);
                //ResultMsg = WorkTaskInstance.GetResultMsg(worktaskInsId);

                //title = "操作结果:" + ResultMsg;
                //if (TaskToWhoMsg.Length <= 0)
                //{
                //    TaskToWhoMsg = "未提交至任何人,请检查流程模板和组织机构配置是否正确!";
                //    if (ResultMsg == WorkFlowConst.WorkflowOverMsg)//流程结束
                //    {
                //        TaskToWhoMsg = "流程结束!";
                //    }
                //    if (ResultMsg == WorkFlowConst.TaskBackMsg)
                //    {
                //        TaskToWhoMsg = WorkFlowConst.TaskBackMsg;
                //    }
                //}

                //TaskToWhoMsg = "成功提交至:" + TaskToWhoMsg + "。你已完成该任务处理,可以关闭该窗口。";

                //System.Text.StringBuilder builder = new System.Text.StringBuilder();
                //builder.Append("<script>\r\n");
                //builder.Append("setTimeout('Finish();',1000);\r\n");
                //builder.Append("function Finish(){\r\n");
                //builder.Append("document.all('Image2').src='../images/home.gif';\r\n");
                //builder.Append("document.all('" + this.lbTitle.ClientID + "').innerText='" + title + "';\r\n");
                //builder.Append("document.all('" + this.lbDescription.ClientID + "').innerText='" + TaskToWhoMsg + "';\r\n");
                ////builder.Append("alert('ok');\r\n");
                //builder.Append("clearTimeout();\r\n");
                //builder.Append("}\r\n");
                //builder.Append("</script>\r\n");
                //this.Page.RegisterClientScriptBlock("test", builder.ToString());
            
        }

    
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int index = gridView1.FocusedRowHandle;
           
            if (index < 0) return;

            workTaskId = gridView1.GetDataRow(index)["WorkTaskId"].ToString();
            workFlowId = gridView1.GetDataRow(index)["WorkFlowId"].ToString();
            workTaskInsId = Guid.NewGuid().ToString();
            workFlowInsId = Guid.NewGuid().ToString();
            tbWorkTaskInsId.Text = workTaskInsId;
            tbWorkFlowInsId.Text = workFlowInsId;
            FlowNo.Text = WorkFlowInstance.GetWorkflowNO();
           
            WorkFlowTemplate wt = new WorkFlowTemplate();
            wt.GetWorkflowInfo(workFlowId);
            WorkflowCaption0.Text = gridView1.GetDataRow(index)["FlowCaption"].ToString();
            WorkflowCaption.Text = wt.WorkFlowCaption + FlowNo.Text;
            WorkflowDes.Text = wt.WorkFlowCaption + FlowNo.Text;
            StartTaskCaption.Text = gridView1.GetDataRow(index)["TaskCaption"].ToString();

            cmdHisPlace.Visible = false;
            labelControl7.Visible = false;
            txtime.Visible = false;
            initButton();

        }
        /// <summary>
        /// 初始化流程命令按钮
        /// </summary>
        private void initButton()
        {
            DataTable taskCommand = WorkFlowTask.GetTaskCommands(workFlowId, workTaskId);
            int x = 10, i = 1;
            cmdBtnPlace.Controls.Clear();
            foreach (DataRow dr in taskCommand.Rows)
            {
                string cmdName = dr["CommandName"].ToString();
                Button btnCommand = new Button();

                btnCommand.Text = cmdName;
                btnCommand.Top = 50;
                btnCommand.Left =  x;
                x = x + btnCommand.Width+10;
                i++;
                btnCommand.Click += new EventHandler(runButtonEvent);
                cmdBtnPlace.Controls.Add(btnCommand);
              
            }
            //Bitmap objBitmap = new Bitmap(600, 600);
            //Graphics objGraphics = Graphics.FromImage(objBitmap);
            //InitTaskMapData(workFlowId, workFlowInsId, objGraphics);
            //InitLinkMapData(workFlowId, workFlowInsId, objGraphics);
            //objBitmap.Save(workFlowId + ".jpg", ImageFormat.Jpeg);
            //pictureBox1.Image = objBitmap;
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int index = gridView2.FocusedRowHandle;
            if (index < 0) return;

            int i =Convert.ToInt32 ( gridView2.GetDataRow(index)["index"]);
            //label1.Text = "未认领任务(" + WorkFlowInstance.GetClaimingTaskCount(userId) + ")";
            //label2.Text = "已认领任务(" + WorkFlowInstance.GetClaimedTaskCount(userId) + ")";
            //label3.Text = "已完成任务(" + WorkFlowInstance.GetCompletedTaskCount(userId) + ")";
            //label4.Text = "我参与的任务(" + WorkFlowInstance.GetAllTaskCount(userId) + ")";
            //label5.Text = "异常终止的任务(" + WorkFlowInstance.GetAbnormalTaskCount(userId) + ")";
            //label6.Text = "待办任务(" + WorkFlowInstance.GetToDoTasksCount(userId) + ")";
            //startdt = WorkFlowTemplate.GetAllowsStartWorkFlows(userId);
            button2.Visible = false; 
            switch (i)
            {
                case 1:

                    gridControl1.Visible =  false;
                    gridControl3.Visible = true;
                    gridControl3.DataSource = WorkFlowInstance.WorkflowClaimingTask(userId, 999);
                    if (gridView3.DataRowCount >0)
                    button2.Visible = true; 
                    break;
                case 2:
                    gridControl1.Visible = false;
                    gridControl3.Visible = true;
                    gridControl3.DataSource = WorkFlowInstance.WorkflowClaimedTask (userId, 999); 
                    break;
                case 3:
                    gridControl1.Visible = false;
                    gridControl3.Visible = true;
                    gridControl3.DataSource = WorkFlowInstance.WorkflowCompletedTask (userId, 999);
                    break;
                case 4:
                    gridControl1.Visible = false;
                    gridControl3.Visible = true;
                    gridControl3.DataSource = WorkFlowInstance.WorkflowAllTask (userId, 999);
                    break;
                case 5:
                    gridControl1.Visible = false;
                    gridControl3.Visible = true;
                    gridControl3.DataSource = WorkFlowInstance.WorkflowAbnormalTask (userId, 999);
                    break;
                case 6:
                    gridControl1.Visible = false;
                    gridControl3.Visible = true;
                    gridControl3.DataSource = WorkFlowInstance.WorkflowToDoWorkTasks (userId, 999);
                    break;
                case 7:
                    gridControl1.Visible =   true;
                    gridControl3.Visible = false;
                    gridControl1.DataSource = WorkFlowTemplate.GetAllowsStartWorkFlows(userId);
                    break; 
            
            }
        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
            int index = gridView3.FocusedRowHandle;

            if (index < 0) return;
            if (gridView3.GetDataRow(index) == null) return;
            workTaskId = gridView3.GetDataRow(index)["WorkTaskId"].ToString();
            workFlowId = gridView3.GetDataRow(index)["WorkFlowId"].ToString();
            workTaskInsId = gridView3.GetDataRow(index)["WorkTaskInsId"].ToString();
            workFlowInsId = gridView3.GetDataRow(index)["WorkFlowInsId"].ToString();
            OperStatus = gridView3.GetDataRow(index)["OperStatus"].ToString();
            txtime.Text = gridView3.GetDataRow(index)["taskStartTime"].ToString();
            if( gridView2.FocusedRowHandle==0)
                operatorInsId = gridView3.GetDataRow(index)["OperatorInsId"].ToString(); 
            tbWorkTaskInsId.Text = workTaskInsId;
            tbWorkFlowInsId.Text = workFlowInsId;
            FlowNo.Text = gridView3.GetDataRow(index)["WorkFlowNo"].ToString();
            drpPriority.SelectedIndex =Convert.ToInt32( gridView3.GetDataRow(index)["Priority"]);
            //绑定流程历史
            GetWorkflowHistory(workFlowInsId);
            
            cmdBtnPlace.Controls.Clear();


            cmdHisPlace.Visible = true;
            labelControl7.Visible = true;
            txtime.Visible = true; 
            generalCmdButton();//常用的按钮
            powerButton();//根据控制权限创建的按钮
           

            WorkFlowTemplate wt = new WorkFlowTemplate();
            wt.GetWorkflowInfo(workFlowId);
            WorkflowCaption0.Text = gridView3.GetDataRow(index)["FlowCaption"].ToString();
            WorkflowCaption.Text = wt.WorkFlowCaption + FlowNo.Text;
            WorkflowDes.Text = wt.WorkFlowCaption + FlowNo.Text;
            StartTaskCaption.Text = gridView3.GetDataRow(index)["TaskCaption"].ToString();
            initButton();
            //Bitmap objBitmap = new Bitmap(600, 600);
            //Graphics objGraphics = Graphics.FromImage(objBitmap);
            //InitTaskMapData(workFlowId, workFlowInsId, objGraphics);
            //InitLinkMapData(workFlowId, workFlowInsId, objGraphics);
            //objBitmap.Save(workFlowId + ".jpg", ImageFormat.Jpeg);
            pictureBox1.Image = WorkFlowInstance.WorkFlowBitmap(workFlowId, workFlowInsId, new Size(600, 600));
            //tooltip.Text = toollips();
        }
        #region 动态加载任务命令按钮,退回,指派，动态指定下一任务处理人按钮
        /// <summary>
        /// 根据权限加载 退回,指派，动态指定下一任务处理人按钮
        /// </summary>
        private void powerButton()
        {
            string powerStr = "";
            DataTable dt = WorkFlowTask.GetTaskPower(workFlowId, workTaskId);
            foreach (DataRow dr in dt.Rows)
            {
                powerStr = powerStr + dr["PowerName"].ToString() + ",";
            }
            if (powerStr.IndexOf(WorkConst.WorkTask_Return) > -1)//允许退回
            {
                Button btnCommand = new Button();
                btnCommand.Text = "退回";
                btnCommand.Left = x;
                x = x + btnCommand.Width + 10;
                btnCommand.Click += new EventHandler(taskBackButtonEvent);
                btnCommand.Enabled = (pageState != WorkConst.STATE_VIEW && OperStatus != "0");
                cmdBtnPlace.Controls.Add(btnCommand);
               
                
            }
            if (powerStr.IndexOf(WorkConst.WorkTask_Assign) > -1)//允许指派
            {
                Button btnCommand = new Button();
                btnCommand.Text = "指派";
                btnCommand.Left = x;
                x = x + btnCommand.Width + 10;
                btnCommand.Click += new EventHandler(taskAssignButtonEvent);
                btnCommand.Enabled = (pageState != WorkConst.STATE_VIEW && OperStatus != "0");
                cmdBtnPlace.Controls.Add(btnCommand);
            }
            if (powerStr.IndexOf(WorkConst.WorkTask_DyAssignNext) > -1)//允许动态指定下一步处理人
            {
                //BaseUserControl c = (BaseUserControl)this.LoadControl(@"..\BaseUserControls\DyAssignNext.ascx");
                //c.WorkflowId = WorkflowId;
                //c.ID = "nextCtrl";//必须指定名称。js代码才能取到
                //c.PageState = pageState;
                //c.CtrlState = WorkConst.STATE_MOD;
                //c.WorkflowInsId = WorkflowInsId;
                //c.WorktaskId = WorktaskId;
                //c.WorktaskInsId = WorktaskInsId;
                //c.OperatorInsId = OperatorInsId;
                //c.InitUserControl();//执行控件的初始化事件
                //UserCtrlList.Add(c);//加到用户控件列表中
                //DyAssignPlace.Controls.Add(c);

            }
            initButton();//流程按钮


        }
       
        
        private void wfruntime_RunSuccess(object sender, WorkFlowEventArgs e)
        {

        }
        private void wfruntime_RunFail(object sender, WorkFlowEventArgs e)
        {

        }
        /// <summary>
        /// 任务退回事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taskBackButtonEvent(object sender, EventArgs e)
        {
            WorkFlowRuntime wfruntime = new WorkFlowRuntime();
            wfruntime.UserId =userId;
            wfruntime.OperatorInstanceId = operatorInsId;
            wfruntime.TaskBack();
            tooltip.Text = toollips();
        }


        /// <summary>
        /// 任务指派事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taskAssignButtonEvent(object sender, EventArgs e)
        {

           // string dlg = "window.open( 'AssignTask.aspx?OperatorInstanceId=" + OperatorInsId + "','newwindow'," +
           //" 'height=200,width=650,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no')";
           // if (!this.IsStartupScriptRegistered(UserId))
           //     this.RegisterStartupScript(UserId, "<script>" + dlg + "</script>");


        }
        #endregion
        #region 常用按钮,认领,草稿,放弃

        /// <summary>
        /// 常用按钮,认领,草稿,放弃
        /// </summary>
        private void generalCmdButton()
        {

            Button btnCommand = new Button();
            btnCommand.Text = "认领";
            btnCommand.Left = x;
            x = x + btnCommand.Width + 10;
            btnCommand.Click += new EventHandler(claimButtonEvent);
            btnCommand.Enabled = (pageState != WorkConst.STATE_VIEW && OperStatus == "0");
            cmdBtnPlace.Controls.Add(btnCommand);
         
           

            btnCommand = new Button();
            btnCommand.Text = "草稿";
            btnCommand.Left = x;
            x = x + btnCommand.Width + 10;
            btnCommand.Click += new EventHandler(saveButtonEvent);
            btnCommand.Enabled = (pageState != WorkConst.STATE_VIEW && OperStatus != "0");
            cmdBtnPlace.Controls.Add(btnCommand);
           
           

            btnCommand = new Button();
            btnCommand.Text = "放弃";
            btnCommand.Left = x;
            x = x + btnCommand.Width + 10;
            btnCommand.Click += new EventHandler(taskAbnegateButtonEvent);
            btnCommand.Enabled = (pageState != WorkConst.STATE_VIEW && OperStatus != "0");
            cmdBtnPlace.Controls.Add(btnCommand);
            

        }
        /// <summary>
        /// 草稿
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButtonEvent(object sender, EventArgs e)
        {
            if (SaveUserControl(true))
               MsgBox.ShowTipMessageBox  ( "保存草稿成功。");
        }
        /// <summary>
        /// 任务放弃认领
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taskAbnegateButtonEvent(object sender, EventArgs e)
        {

            WorkFlowRuntime wfruntime = new WorkFlowRuntime();
            wfruntime.UserId = userId;
            // wfruntime.WorkTaskInstanceId = WorktaskInsId;
            wfruntime.OperatorInstanceId = operatorInsId;
            wfruntime.TaskUnClaim();
           
        }
        /// <summary>
        /// 认领任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void claimButtonEvent(object sender, EventArgs e)
        {
            WorkFlowRuntime wfruntime = new WorkFlowRuntime();
            wfruntime.UserId = userId;
            // wfruntime.WorkTaskInstanceId = WorktaskInsId;
            wfruntime.OperatorInstanceId = operatorInsId;
            wfruntime.TaskClaim();
           
        }
        #endregion

        //绑定流程历史
        private void GetWorkflowHistory(string workflowinsid)
        {
            DataTable dt = WorkFlowInstance.GetWorkflowHistory(workflowinsid);
            gvHistory.DataSource = dt;
           
        }
            private void drawTaskBitmap(Graphics gc, string taskCaption, string operType, int x, int y, bool isPass,bool isCurrent,string taskDes)
    {
        Rectangle bounds;
        Bitmap taskBitmap = null;
        Font font;
        StringFormat alignVertically;
        Point pt = new Point(0, 0);
        Brush bcolor;
        int Captionx;
        string noPassflag = "灰";//表示灰色图片
        pt.X = x;
        pt.Y = y;
        font = new Font("Arial", 8);
        alignVertically = new StringFormat();
        alignVertically.LineAlignment = StringAlignment.Center;//指定文本在布局矩形中居中对齐
        if (isPass) noPassflag = ""; else noPassflag = "灰";
        switch (operType)
        {
            case "1"://启动节点
                taskBitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.启动节点.ico")));
                break;
            case "2"://终止节点 
                taskBitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.终止节点.ico")));
                break;
            case "3"://交互节点 

                taskBitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.交互节点.ico")));
                break;
            case "4"://控制节点 
                taskBitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.控制节点.ico")));
                break;
            case "5"://查看节点 
                taskBitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.查看节点.ico")));
                break;
            case "6"://子流程节点 
                taskBitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.子流程节点.ico")));
                break;
            case "7"://并行节点 
                taskBitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.并行节点.ico")));
                break;
            default:
                taskBitmap = new Bitmap(Image.FromStream(typeof(BaseComponent).Assembly.GetManifestResourceStream("Ebada.SCGL.WFlow.Tool.Resources.查看节点.ico")));
                break;
        }
        if (isCurrent)
        {
            bcolor = Brushes.Red;
            taskCaption = "当前节点:"+taskCaption;
        }
        else bcolor = Brushes.Black;//当前节点
        bounds = new Rectangle(pt, taskBitmap.Size);
        gc.DrawImage(taskBitmap, bounds.Left, bounds.Top);

        SizeF sizeF = gc.MeasureString(taskCaption, font);
        Captionx = bounds.Left - ((int)sizeF.Width) / 2 + bounds.Width / 2;
        gc.DrawString(taskCaption, font, bcolor, Captionx, bounds.Top + bounds.Height+20, alignVertically);
        bcolor = Brushes.RoyalBlue;
        gc.DrawString(taskDes, font, bcolor, Captionx, bounds.Top + bounds.Height + 35, alignVertically);
    }
    private void drawLinkBitMap(Graphics gs, string linkBreakX, string linkBreakY,
                                int starttaskX, int starttaskY, int endtaskX, int endtaskY, Color clr, string linkDes)
    {
        ArrayList breakPointX = new ArrayList();
        ArrayList breakPointY = new ArrayList();

        string[] BreakX;
        string[] BreakY;
        breakPointX.Add(starttaskX + 20);
        breakPointY.Add(starttaskY + 10);

        if (linkBreakX.ToString() != "")
        {
            if (linkBreakX.IndexOf(",") != -1)
            {
                BreakX = linkBreakX.Split(",".ToCharArray());
                BreakY = linkBreakY.Split(",".ToCharArray());
                for (int i = 0; i < BreakX.Length; i++)
                {
                    breakPointX.Add(BreakX[i]);
                    breakPointY.Add(BreakY[i]);
                }
            }
            else
            {
                breakPointX.Add(linkBreakX);
                breakPointY.Add(linkBreakY);
            }
        }
        breakPointX.Add(endtaskX);
        breakPointY.Add(endtaskY);
        if (breakPointX.Count < 2)
        {
            for (int i = 0; i < breakPointX.Count; i++)
            {
                if (Convert.ToInt16(breakPointX[i]) < Convert.ToInt16(breakPointX[i + 1]))
                {
                    if (Convert.ToInt16(breakPointY[i]) > Convert.ToInt16(breakPointY[i + 1]))
                    {
                        breakPointX[i] = Convert.ToInt16(breakPointX[i]);
                        breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]) + 10;
                    }
                    else
                    {

                        breakPointX[i] = Convert.ToInt16(breakPointX[i]);
                        breakPointY[i] = Convert.ToInt16(breakPointY[i]) + 10;
                    }

                }
                else
                {
                    if (Convert.ToInt16(breakPointY[i]) > Convert.ToInt16(breakPointY[i + 1]))
                    {
                        breakPointX[i] = Convert.ToInt16(breakPointX[i]) - 10;
                        breakPointX[i + 1] = Convert.ToInt16(breakPointX[i + 1]) + 10;
                        breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]) + 10;
                    }
                    else
                    {
                        breakPointX[i] = Convert.ToInt16(breakPointX[i]) - 20;
                        breakPointY[i] = Convert.ToInt16(breakPointY[i]);
                        breakPointX[i + 1] = Convert.ToInt16(breakPointX[i + 1]) + 20;
                        //breakPointY[i+1]=Convert.ToInt16(breakPointY[i+1])+10;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < breakPointX.Count; i++)
            {
                if (i == 0)
                {
                    if (Convert.ToInt16(breakPointX[i]) < Convert.ToInt16(breakPointX[i + 1]))
                    {
                        if (Convert.ToInt16(breakPointY[i]) > Convert.ToInt16(breakPointY[i + 1]))
                        {
                            breakPointX[i] = Convert.ToInt16(breakPointX[i]);
                        }
                        else
                        {
                            if (Convert.ToInt16(breakPointY[i]) < Convert.ToInt16(breakPointY[i + 1]))
                            {
                                breakPointX[i] = Convert.ToInt16(breakPointX[i]);
                            }
                            else
                            {
                                breakPointX[i] = Convert.ToInt16(breakPointX[i]) + 20;//20
                            }
                        }

                    }
                    else
                    {
                        if (Convert.ToInt16(breakPointY[i]) > Convert.ToInt16(breakPointY[i + 1]))
                        {
                            breakPointX[i] = Convert.ToInt16(breakPointX[i]);
                        }
                        else
                        {
                            if (Convert.ToInt16(breakPointY[i]) < Convert.ToInt16(breakPointY[i + 1]))
                            {
                                breakPointX[i] = Convert.ToInt16(breakPointX[i]) - 20;

                                breakPointY[i] = Convert.ToInt16(breakPointY[i]);//20
                            }
                            else
                            {
                                breakPointY[i] = Convert.ToInt16(breakPointY[i]);
                            }
                        }
                    }
                }
                if (i == breakPointX.Count - 2)
                {
                    if (Convert.ToInt16(breakPointX[i]) < Convert.ToInt16(breakPointX[i + 1]))
                    {
                        if (Convert.ToInt16(breakPointY[i]) > Convert.ToInt16(breakPointY[i + 1]))
                        {
                            breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]);
                        }
                        else
                        {
                            if (Convert.ToInt16(breakPointY[i]) < Convert.ToInt16(breakPointY[i + 1]))
                            {
                                breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]);
                            }
                            else
                            {
                                breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]);
                            }
                        }

                    }
                    else
                    {
                        if (Convert.ToInt16(breakPointY[i]) > Convert.ToInt16(breakPointY[i + 1]))
                        {
                            breakPointX[i + 1] = Convert.ToInt16(breakPointX[i + 1]);
                            breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]);
                        }
                        else
                        {
                            if (Convert.ToInt16(breakPointY[i]) < Convert.ToInt16(breakPointY[i + 1]))
                            {
                                breakPointX[i + 1] = Convert.ToInt16(breakPointX[i + 1]);
                            }
                            else
                            {
                                breakPointX[i + 1] = Convert.ToInt16(breakPointX[i + 1]);//20
                                breakPointY[i + 1] = Convert.ToInt16(breakPointY[i + 1]);
                            }
                        }
                    }
                }
            }
        }
        Pen pen = new Pen(clr, 1);

        for (int i = 0; i < breakPointX.Count - 2; i++)
        {
            Point bp = new Point(Convert.ToInt16(breakPointX[i]), Convert.ToInt16(breakPointY[i]));
            Point bp2 = new Point(Convert.ToInt16(breakPointX[i + 1]), Convert.ToInt16(breakPointY[i + 1]));
            gs.DrawLine(pen, bp, bp2);
        }
        //画最后一条带箭头的  
        if (breakPointX.Count >= 2)
        {

            int ittX = Convert.ToInt16(breakPointX[breakPointX.Count - 2]);
            int ittY = Convert.ToInt16(breakPointY[breakPointX.Count - 2]);
            int itt2X = Convert.ToInt16(breakPointX[breakPointX.Count - 1]);
            int itt2Y = Convert.ToInt16(breakPointY[breakPointX.Count - 1]);
            Point tt = new Point(ittX, ittY);
            Point tt2 = new Point(itt2X, itt2Y);
            AdjustableArrowCap Arrow = new AdjustableArrowCap(3, 3);
            pen.CustomEndCap = Arrow;
            gs.DrawLine(pen, tt, tt2);
            //			}

            //画注释	
            if (linkDes == "")
                return;
            Font font = new Font("Arial", 8);
            StringFormat alignVertically = new StringFormat();
            alignVertically.LineAlignment = StringAlignment.Center;//指定文本在布局矩形中居中对齐
            SizeF sizeF = gs.MeasureString(linkDes, font);
            int x = (Convert.ToInt16(breakPointX[0]) + Convert.ToInt16(breakPointX[1]) - (int)sizeF.Width) / 2;
            int y = (Convert.ToInt16(breakPointY[0]) + Convert.ToInt16(breakPointY[1])) / 2;
            gs.DrawString(linkDes, font, Brushes.Blue, x, y, alignVertically);
        }

    }
    private void InitTaskMapData(string workflowId, string workflowInsId, Graphics gc)
    {
        DataTable tasktable = WorkFlowTask.GetWorkTasks(workflowId);
        string taskCaption = "";
        int taskX;
        int taskY;
        string operType = "";
        string taskId = "";
        string currTaskId = "";
        string taskDes="";
        bool isPass;//是否通过
        bool isCurrent=false;//是否是当前节点
        DataTable dtCurr= WorkFlowInstance.GetWorkflowInstance(workflowInsId);
        if (dtCurr.Rows.Count > 0)
        {
            currTaskId = dtCurr.Rows[0]["NowTaskId"].ToString();//流程实例当前节点
            gc.Clear(System.Drawing.Color.FromArgb(255, 253, 244));   // 改变背景颜色
            foreach (DataRow dr in tasktable.Rows)
            {
                taskId = dr["WorkTaskId"].ToString();
                taskCaption = dr["TaskCaption"].ToString();
                taskX = Convert.ToInt16(dr["iXPosition"]);
                taskY = Convert.ToInt16(dr["iYPosition"]) - 10;
                operType = dr["TaskTypeId"].ToString();
                isPass = WorkFlowHelper.isPassJudge(workflowId, workflowInsId, taskId, WorkConst.Command_And);
                if (currTaskId == taskId) isCurrent = true; else isCurrent = false;
                taskDes = WorkTaskInstance.GetTaskDoneWhoMsg(taskId, workflowInsId);
                drawTaskBitmap(gc, taskCaption, operType, taskX, taskY, isPass, isCurrent, taskDes);

            }
        }

    }
    private bool isFromStartTask(string workflowId, string workflowInsId,string startTaskId, string endTaskId)
    {

        DataTable dt1 = WorkFlowTask.GetTaskInstance(workflowId, workflowInsId, endTaskId);
        if (dt1!=null&&dt1.Rows.Count>0)
        {
            string ptaskInsId = dt1.Rows[0]["PreviousTaskId"].ToString();//根据后端节点模板找到前一任务实例
            DataTable dt2 = WorkTaskInstance.GetTaskInsTable(ptaskInsId);//根据前一任务实例找到任务模板
            if (dt2 != null && dt2.Rows.Count > 0)
            {
                string staskid=dt2.Rows[0]["WorktaskId"].ToString();
                if (staskid == startTaskId)
                    return true;
            }
            return false;
        }
        return false;
    }
    private void InitLinkMapData(string workflowId, string workflowInsId, Graphics gc)
    {
        DataTable linktable = WorkFlowLink.GetWorkLinks(workflowId);
        string linkDes = "";
        string startTaskId = "";
        string endTaskId = "";
        string linkBreakX;
        string linkBreakY;
        int starttaskX;
        int starttaskY;
        int endtaskX;
        int endtaskY;
        bool started;
        bool ended;
        bool fromStart;
        bool isPass;//是否通过
        Color linkColor;

        foreach (DataRow dr in linktable.Rows)
        {
            linkBreakX = dr["BreakX"].ToString();
            linkBreakY = dr["BreakY"].ToString();
            startTaskId = dr["startTaskId"].ToString();//起端任务节点，由此来判断线的颜色。
            endTaskId = dr["EndTaskId"].ToString();//末端任务节点，由此来判断线的颜色。
            starttaskX = Convert.ToInt16(dr["starttaskX"]);
            starttaskY = Convert.ToInt16(dr["starttaskY"]);
            endtaskX = Convert.ToInt16(dr["endtaskX"]);
            endtaskY = Convert.ToInt16(dr["endtaskY"]);
            linkDes = dr["Description"].ToString();
            started = WorkFlowHelper.isPassJudge(workflowId, workflowInsId, startTaskId, WorkConst.Command_And);
            ended = WorkFlowHelper.isPassJudge(workflowId, workflowInsId, endTaskId, WorkConst.Command_And);
            fromStart = isFromStartTask(workflowId, workflowInsId, startTaskId, endTaskId);
            isPass = (started && ended && fromStart);
            if (isPass) linkColor = Color.Red; else linkColor = Color.Green;
            drawLinkBitMap(gc, linkBreakX, linkBreakY, starttaskX, starttaskY, endtaskX, endtaskY, linkColor, linkDes);
        }

    }

    private void button2_Click(object sender, EventArgs e)
    {
       
        WorkFlowRuntime wfruntime = new WorkFlowRuntime();
        wfruntime.UserId = userId;
        
        workTaskInsId = gridView3.GetDataRow(gridView3.FocusedRowHandle)["WorkTaskInsId"].ToString();
        operatorInsId = gridView3.GetDataRow(gridView3.FocusedRowHandle)["OperatorInsId"].ToString(); 
        wfruntime.WorkTaskInstanceId = workTaskInsId;
        wfruntime.OperatorInstanceId = operatorInsId;
        wfruntime.TaskClaim();

        //tooltip.Text = toollips();
    }
    }
}
