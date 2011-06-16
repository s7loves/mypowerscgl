using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


namespace Ebada.SCGL.WFlow.Tool
{
	/// <summary>
	/// TaskExamineFm 的摘要说明。
	/// </summary>
    public class fmTaskView : BaseForm_Single
    {
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		public ViewTask NowTask;
        public string UserId = "";
        public string UserControlId = "";//关联表单id
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TextBox tbxTaskDes;
        private TextBox tbxFormName;
        private TextBox tbxTaskName;
        private Label label4;
        private Label label3;
        private Button btnSelectCtrls;
        private Label label1;
        private PictureBox pictureBox1;
        private TabPage tabPage6;
        private Button btnDeleteOpr;
        private Button btnModifyOpr;
        private Button btnAddOpr;
        private ListView lvOper;
        private Label label5;
        private GroupBox groupBox1;
        private RadioButton rbtEveryUser;
        private RadioButton rbtShareUser;
        private TabPage tabPage4;
        private GroupBox groupBox3;
        private ListBox lbxRmMsgToUsers;
        private Button btnRmDelete;
        private Button btnRmAdd;
        private Label label10;
        private CheckBox cbxRmMail;
        private CheckBox cbxRmMessage;
        private CheckBox cbxRmSms;
        private Label label2;
        private ListView lvCommand;
        private Button btnDeletecmd;
        private Button btnModifycmd;
        private Button btnAddcmd;//操作人账号，用作权限判断。
		public string UserName="";//操作人姓名，用作显示。

		public fmTaskView(ViewTask viewTask,string userId,string userName)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			NowTask=viewTask;
			this.UserId=userId;
			this.UserName=userName;

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmTaskView));
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btnDeleteOpr = new System.Windows.Forms.Button();
            this.btnModifyOpr = new System.Windows.Forms.Button();
            this.btnAddOpr = new System.Windows.Forms.Button();
            this.lvOper = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtEveryUser = new System.Windows.Forms.RadioButton();
            this.rbtShareUser = new System.Windows.Forms.RadioButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.lvCommand = new System.Windows.Forms.ListView();
            this.btnDeletecmd = new System.Windows.Forms.Button();
            this.btnModifycmd = new System.Windows.Forms.Button();
            this.btnAddcmd = new System.Windows.Forms.Button();
            this.tbxTaskDes = new System.Windows.Forms.TextBox();
            this.tbxFormName = new System.Windows.Forms.TextBox();
            this.tbxTaskName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectCtrls = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbxRmMsgToUsers = new System.Windows.Forms.ListBox();
            this.btnRmDelete = new System.Windows.Forms.Button();
            this.btnRmAdd = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxRmMail = new System.Windows.Forms.CheckBox();
            this.cbxRmMessage = new System.Windows.Forms.CheckBox();
            this.cbxRmSms = new System.Windows.Forms.CheckBox();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.tabControl1);
            this.plclassFill.Size = new System.Drawing.Size(452, 392);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 344);
            this.plclassBottom.Size = new System.Drawing.Size(452, 48);
            // 
            // btnSave
            // 
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.btnDeleteOpr);
            this.tabPage6.Controls.Add(this.btnModifyOpr);
            this.tabPage6.Controls.Add(this.btnAddOpr);
            this.tabPage6.Controls.Add(this.lvOper);
            this.tabPage6.Controls.Add(this.label5);
            this.tabPage6.Controls.Add(this.groupBox1);
            this.tabPage6.Location = new System.Drawing.Point(4, 21);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(424, 305);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "处理者";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // btnDeleteOpr
            // 
            this.btnDeleteOpr.Location = new System.Drawing.Point(233, 259);
            this.btnDeleteOpr.Name = "btnDeleteOpr";
            this.btnDeleteOpr.Size = new System.Drawing.Size(80, 23);
            this.btnDeleteOpr.TabIndex = 120;
            this.btnDeleteOpr.Text = "删除";
            this.btnDeleteOpr.Click += new System.EventHandler(this.btnDeleteOpr_Click);
            // 
            // btnModifyOpr
            // 
            this.btnModifyOpr.Location = new System.Drawing.Point(135, 259);
            this.btnModifyOpr.Name = "btnModifyOpr";
            this.btnModifyOpr.Size = new System.Drawing.Size(80, 23);
            this.btnModifyOpr.TabIndex = 119;
            this.btnModifyOpr.Text = "修改";
            this.btnModifyOpr.Click += new System.EventHandler(this.btnModifyOpr_Click);
            // 
            // btnAddOpr
            // 
            this.btnAddOpr.Location = new System.Drawing.Point(38, 259);
            this.btnAddOpr.Name = "btnAddOpr";
            this.btnAddOpr.Size = new System.Drawing.Size(80, 23);
            this.btnAddOpr.TabIndex = 118;
            this.btnAddOpr.Text = "增加";
            this.btnAddOpr.Click += new System.EventHandler(this.btnAddOpr_Click);
            // 
            // lvOper
            // 
            this.lvOper.FullRowSelect = true;
            this.lvOper.Location = new System.Drawing.Point(13, 112);
            this.lvOper.Name = "lvOper";
            this.lvOper.Size = new System.Drawing.Size(389, 141);
            this.lvOper.TabIndex = 117;
            this.lvOper.UseCompatibleStateImageBehavior = false;
            this.lvOper.View = System.Windows.Forms.View.Details;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 113;
            this.label5.Text = "处理者:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtEveryUser);
            this.groupBox1.Controls.Add(this.rbtShareUser);
            this.groupBox1.Location = new System.Drawing.Point(13, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 63);
            this.groupBox1.TabIndex = 112;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "处理者策略";
            // 
            // rbtEveryUser
            // 
            this.rbtEveryUser.AutoSize = true;
            this.rbtEveryUser.Location = new System.Drawing.Point(144, 30);
            this.rbtEveryUser.Name = "rbtEveryUser";
            this.rbtEveryUser.Size = new System.Drawing.Size(131, 16);
            this.rbtEveryUser.TabIndex = 1;
            this.rbtEveryUser.Text = "所有用户处理(会签)";
            this.rbtEveryUser.UseVisualStyleBackColor = true;
            // 
            // rbtShareUser
            // 
            this.rbtShareUser.AutoSize = true;
            this.rbtShareUser.Checked = true;
            this.rbtShareUser.Location = new System.Drawing.Point(25, 30);
            this.rbtShareUser.Name = "rbtShareUser";
            this.rbtShareUser.Size = new System.Drawing.Size(95, 16);
            this.rbtShareUser.TabIndex = 0;
            this.rbtShareUser.TabStop = true;
            this.rbtShareUser.Text = "任意用户处理";
            this.rbtShareUser.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lvCommand);
            this.tabPage1.Controls.Add(this.btnDeletecmd);
            this.tabPage1.Controls.Add(this.btnModifycmd);
            this.tabPage1.Controls.Add(this.btnAddcmd);
            this.tabPage1.Controls.Add(this.tbxTaskDes);
            this.tabPage1.Controls.Add(this.tbxFormName);
            this.tabPage1.Controls.Add(this.tbxTaskName);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnSelectCtrls);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(424, 305);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "常规";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 132;
            this.label2.Text = "处理:";
            // 
            // lvCommand
            // 
            this.lvCommand.FullRowSelect = true;
            this.lvCommand.Location = new System.Drawing.Point(24, 141);
            this.lvCommand.Name = "lvCommand";
            this.lvCommand.Size = new System.Drawing.Size(379, 120);
            this.lvCommand.TabIndex = 131;
            this.lvCommand.UseCompatibleStateImageBehavior = false;
            this.lvCommand.View = System.Windows.Forms.View.Details;
            // 
            // btnDeletecmd
            // 
            this.btnDeletecmd.Location = new System.Drawing.Point(276, 267);
            this.btnDeletecmd.Name = "btnDeletecmd";
            this.btnDeletecmd.Size = new System.Drawing.Size(80, 23);
            this.btnDeletecmd.TabIndex = 130;
            this.btnDeletecmd.Text = "删除";
            this.btnDeletecmd.Click += new System.EventHandler(this.btnDeletecmd_Click);
            // 
            // btnModifycmd
            // 
            this.btnModifycmd.Location = new System.Drawing.Point(144, 267);
            this.btnModifycmd.Name = "btnModifycmd";
            this.btnModifycmd.Size = new System.Drawing.Size(80, 23);
            this.btnModifycmd.TabIndex = 129;
            this.btnModifycmd.Text = "修改";
            this.btnModifycmd.Click += new System.EventHandler(this.btnModifycmd_Click);
            // 
            // btnAddcmd
            // 
            this.btnAddcmd.Location = new System.Drawing.Point(52, 267);
            this.btnAddcmd.Name = "btnAddcmd";
            this.btnAddcmd.Size = new System.Drawing.Size(80, 23);
            this.btnAddcmd.TabIndex = 128;
            this.btnAddcmd.Text = "增加";
            this.btnAddcmd.Click += new System.EventHandler(this.btnAddcmd_Click);
            // 
            // tbxTaskDes
            // 
            this.tbxTaskDes.Location = new System.Drawing.Point(144, 94);
            this.tbxTaskDes.Name = "tbxTaskDes";
            this.tbxTaskDes.Size = new System.Drawing.Size(259, 21);
            this.tbxTaskDes.TabIndex = 124;
            // 
            // tbxFormName
            // 
            this.tbxFormName.Location = new System.Drawing.Point(144, 65);
            this.tbxFormName.Name = "tbxFormName";
            this.tbxFormName.ReadOnly = true;
            this.tbxFormName.Size = new System.Drawing.Size(212, 21);
            this.tbxFormName.TabIndex = 119;
            // 
            // tbxTaskName
            // 
            this.tbxTaskName.Location = new System.Drawing.Point(144, 37);
            this.tbxTaskName.Name = "tbxTaskName";
            this.tbxTaskName.Size = new System.Drawing.Size(259, 21);
            this.tbxTaskName.TabIndex = 116;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(64, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 23);
            this.label4.TabIndex = 125;
            this.label4.Text = "任务描述:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(76, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 120;
            this.label3.Text = "表单名:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelectCtrls
            // 
            this.btnSelectCtrls.Location = new System.Drawing.Point(362, 65);
            this.btnSelectCtrls.Name = "btnSelectCtrls";
            this.btnSelectCtrls.Size = new System.Drawing.Size(41, 23);
            this.btnSelectCtrls.TabIndex = 117;
            this.btnSelectCtrls.Text = "";
            this.btnSelectCtrls.Click += new System.EventHandler(this.btnSelectCtrls_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(64, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 23);
            this.label1.TabIndex = 115;
            this.label1.Text = "任务名称:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 34);
            this.pictureBox1.TabIndex = 109;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(10, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(432, 330);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Location = new System.Drawing.Point(4, 21);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(424, 305);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "任务通知";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbxRmMsgToUsers);
            this.groupBox3.Controls.Add(this.btnRmDelete);
            this.groupBox3.Controls.Add(this.btnRmAdd);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cbxRmMail);
            this.groupBox3.Controls.Add(this.cbxRmMessage);
            this.groupBox3.Controls.Add(this.cbxRmSms);
            this.groupBox3.Location = new System.Drawing.Point(14, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 182);
            this.groupBox3.TabIndex = 62;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "到达通知";
            // 
            // lbxRmMsgToUsers
            // 
            this.lbxRmMsgToUsers.FormattingEnabled = true;
            this.lbxRmMsgToUsers.ItemHeight = 12;
            this.lbxRmMsgToUsers.Location = new System.Drawing.Point(12, 63);
            this.lbxRmMsgToUsers.Name = "lbxRmMsgToUsers";
            this.lbxRmMsgToUsers.ScrollAlwaysVisible = true;
            this.lbxRmMsgToUsers.Size = new System.Drawing.Size(305, 100);
            this.lbxRmMsgToUsers.TabIndex = 12;
            // 
            // btnRmDelete
            // 
            this.btnRmDelete.Location = new System.Drawing.Point(323, 119);
            this.btnRmDelete.Name = "btnRmDelete";
            this.btnRmDelete.Size = new System.Drawing.Size(45, 23);
            this.btnRmDelete.TabIndex = 11;
            this.btnRmDelete.Text = "删除";
            this.btnRmDelete.UseVisualStyleBackColor = true;
            this.btnRmDelete.Click += new System.EventHandler(this.btnRmDelete_Click);
            // 
            // btnRmAdd
            // 
            this.btnRmAdd.Location = new System.Drawing.Point(323, 72);
            this.btnRmAdd.Name = "btnRmAdd";
            this.btnRmAdd.Size = new System.Drawing.Size(45, 23);
            this.btnRmAdd.TabIndex = 10;
            this.btnRmAdd.Text = "增加";
            this.btnRmAdd.UseVisualStyleBackColor = true;
            this.btnRmAdd.Click += new System.EventHandler(this.btnRmAdd_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label10.Location = new System.Drawing.Point(10, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "同时通知下列人员:";
            // 
            // cbxRmMail
            // 
            this.cbxRmMail.Location = new System.Drawing.Point(245, 22);
            this.cbxRmMail.Name = "cbxRmMail";
            this.cbxRmMail.Size = new System.Drawing.Size(112, 23);
            this.cbxRmMail.TabIndex = 7;
            this.cbxRmMail.Text = "邮件通知";
            // 
            // cbxRmMessage
            // 
            this.cbxRmMessage.Location = new System.Drawing.Point(12, 22);
            this.cbxRmMessage.Name = "cbxRmMessage";
            this.cbxRmMessage.Size = new System.Drawing.Size(112, 23);
            this.cbxRmMessage.TabIndex = 6;
            this.cbxRmMessage.Text = "即时消息通知";
            // 
            // cbxRmSms
            // 
            this.cbxRmSms.Location = new System.Drawing.Point(132, 22);
            this.cbxRmSms.Name = "cbxRmSms";
            this.cbxRmSms.Size = new System.Drawing.Size(112, 23);
            this.cbxRmSms.TabIndex = 5;
            this.cbxRmSms.Text = "手机短信通知";
            // 
            // fmTaskView
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(452, 392);
            this.Name = "fmTaskView";
            this.Text = "查看节点配置";
            this.Load += new System.EventHandler(this.fmTaskView_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private void InitData()
        {
            tbxTaskName.Text = NowTask.TaskName;
            tbxTaskDes.Text = NowTask.Description;
         
            if (NowTask.OperRule == "1")
                rbtShareUser.Checked = true;
            else
                if (NowTask.OperRule == "2")
                    rbtEveryUser.Checked = true;

            //*********任务命令
            lvCommand.Columns.Add("处理命令", 200, HorizontalAlignment.Left);
            lvCommand.Columns.Add("CommandId", 0, HorizontalAlignment.Left);
            lvCommand.Columns.Add("描述", 100, HorizontalAlignment.Left);
            DataTable taskCommand = WorkFlowTask.GetTaskCommands(NowTask.WorkFlowId, NowTask.TaskId);
            foreach (DataRow dr in taskCommand.Rows)
            {
                ListViewItem lvi1 = new ListViewItem(dr["CommandName"].ToString(), 0);
                lvi1.SubItems.Add(dr["CommandId"].ToString());
                lvi1.SubItems.Add(dr["Description"].ToString());

                lvCommand.Items.Add(lvi1);
            }

            //*********处理者
            lvOper.Columns.Add("处理者信息", 200, HorizontalAlignment.Left);
            lvOper.Columns.Add("OperatorId", 0, HorizontalAlignment.Left);
            lvOper.Columns.Add("包含/排除", 100, HorizontalAlignment.Left);
            lvOper.Columns.Add("处理类型", 0, HorizontalAlignment.Left);
            lvOper.Columns.Add("处理策略", 0, HorizontalAlignment.Left);
            lvOper.Columns.Add("处理者", 0, HorizontalAlignment.Left);
            lvOper.Columns.Add("operDisplay", 0, HorizontalAlignment.Left);
            DataTable OperTable = WorkFlowTask.GetTaskOperator(NowTask.WorkFlowId, NowTask.TaskId);
            foreach (DataRow dr in OperTable.Rows)
            {
                ListViewItem lvi1 = new ListViewItem(dr["Description"].ToString(), 0);
                lvi1.SubItems.Add(dr["OperatorId"].ToString());
                if (Convert.ToBoolean(dr["InorExclude"]))
                    lvi1.SubItems.Add("包含");
                else
                    lvi1.SubItems.Add("排除");
                lvi1.SubItems.Add(dr["OperType"].ToString());
                lvi1.SubItems.Add(dr["Relation"].ToString());
                lvi1.SubItems.Add(dr["OperContent"].ToString());
                lvi1.SubItems.Add(dr["operDisplay"].ToString());
                lvOper.Items.Add(lvi1);
            }

          
            //*********表单
            DataTable ctrlTable = WorkFlowTask.GetTaskControls(NowTask.TaskId);
            if (ctrlTable != null && ctrlTable.Rows.Count > 0)
            {
                tbxFormName.Text = ctrlTable.Rows[0]["mucCaption"].ToString();
                UserControlId = ctrlTable.Rows[0]["UserControlId"].ToString();
            }
            

            //********* 事件通知
            WorkFlowEvent ev = new WorkFlowEvent();
            ev.GetWorkFlowEventInfo(NowTask.TaskId);
            
            cbxRmMail.Checked = ev.RmEmail;
            cbxRmMessage.Checked = ev.RmMsg;
            cbxRmSms.Checked = ev.RmSms;

           string[]  us = ev.RmToUsers.Split(',');
            foreach (string usr in us)
            {
                if (usr.Length > 0)
                    lbxRmMsgToUsers.Items.Add(usr);
            }

        }
        private void SaveData()
        {
            //保存任务
            NowTask.TaskName = tbxTaskName.Text;
            NowTask.Description = tbxTaskDes.Text;
          
            if (rbtShareUser.Checked)
                NowTask.OperRule = "1";
            else
                if (rbtEveryUser.Checked)
                    NowTask.OperRule = "2";
            NowTask.SaveUpdateTask();
            WorkFlowTask.DeleteAllOperator(NowTask.TaskId);
            //保存处理者
            foreach (ListViewItem lt in lvOper.Items)
            {
                Operator oper = new Operator();
                oper.OperatorId = lt.SubItems[1].Text;
                oper.WorkFlowId = NowTask.WorkFlowId;
                oper.WorkTaskId = NowTask.TaskId;
                oper.Description = lt.Text;
                if (lt.SubItems[2].Text == "包含")
                {
                    oper.InorExclude = true;
                }
                else
                    if (lt.SubItems[2].Text == "排除")
                    {
                        oper.InorExclude = false;
                    }

                oper.OperType = Convert.ToInt16(lt.SubItems[3].Text);
                oper.Relation = Convert.ToInt16(lt.SubItems[4].Text);
                oper.OperContent = lt.SubItems[5].Text;
                oper.OperDisplay = lt.SubItems[6].Text;
                oper.InsertOperator();
            }
            //保存任务命令
            WorkFlowTask.DeleteAllCommands(NowTask.TaskId);
            foreach (ListViewItem lt in lvCommand.Items)
            {
                WorkTaskCommands taskCommand = new WorkTaskCommands();
                taskCommand.WorkFlowId = NowTask.WorkFlowId;
                taskCommand.WorkTaskId = NowTask.TaskId;
                taskCommand.CommandName = lt.Text;
                taskCommand.CommandId = lt.SubItems[1].Text;
                taskCommand.Description = lt.SubItems[2].Text;
                taskCommand.InsertWorkTaskCommands();
            }

           
            //保存关联表单
            WorkFlowTask.DeleteAllControls(NowTask.TaskId);
            WorkFlowTask.SetTaskUserCtrls(UserControlId, NowTask.WorkFlowId, NowTask.TaskId);

            //保存事件
            WorkFlowEvent.Delete(NowTask.TaskId);
            WorkFlowEvent ev = new WorkFlowEvent();
            ev.Guid = Guid.NewGuid().ToString();
            ev.WorkFlowId = NowTask.WorkFlowId;
            ev.WorkTaskId = NowTask.TaskId;
           
            string us = "";
           
            ev.RmMsg = cbxRmMessage.Checked;
            ev.RmEmail = cbxRmMail.Checked;
            ev.RmSms = cbxRmSms.Checked;

            us = "";
            if (lbxRmMsgToUsers.Items.Count > 0)
            {
                for (int i = 0; i < lbxRmMsgToUsers.Items.Count - 1; i++)
                {
                    us = us + lbxRmMsgToUsers.Items[i].ToString() + ",";
                }
                us = us + lbxRmMsgToUsers.Items[lbxRmMsgToUsers.Items.Count - 1];
            }
            ev.RmToUsers = us;
            ev.Insert();

        }

        private void btnAddOpr_Click(object sender, EventArgs e)
        {
            fmOperator tmpfmOperator = new fmOperator(WorkConst.STATE_ADD);
            tmpfmOperator.OperId = Guid.NewGuid().ToString();
            tmpfmOperator.WorkflowId = NowTask.WorkFlowId;
            tmpfmOperator.ShowDialog();
            DialogResult dlr = tmpfmOperator.DialogResult;
            if (dlr == DialogResult.OK)
            {
                Text = tmpfmOperator.OperId;
                ListViewItem lvi1 = new ListViewItem(tmpfmOperator.Description, 0);
                lvi1.SubItems.Add(tmpfmOperator.OperId);
                if (tmpfmOperator.InorExclude)
                    lvi1.SubItems.Add("包含");
                else
                    lvi1.SubItems.Add("排除");
                lvi1.SubItems.Add(tmpfmOperator.OperType.ToString());
                lvi1.SubItems.Add(tmpfmOperator.Relation.ToString());
                lvi1.SubItems.Add(tmpfmOperator.OperContent);
                lvi1.SubItems.Add(tmpfmOperator.OperDisplay);
                lvOper.Items.Add(lvi1);
            }
        }

        private void btnModifyOpr_Click(object sender, EventArgs e)
        {
            if (lvOper.SelectedItems.Count > 0)
            {

                ListViewItem lvi1 = lvOper.SelectedItems[0];
                fmOperator tmpfmOperator = new fmOperator(WorkConst.STATE_MOD);
                tmpfmOperator.Description = lvi1.Text;
                tmpfmOperator.WorkflowId = NowTask.WorkFlowId;
                tmpfmOperator.OperId = lvi1.SubItems[1].Text;
                if (lvi1.SubItems[2].Text == "包含")
                    tmpfmOperator.InorExclude = true;
                else
                    if (lvi1.SubItems[2].Text == "排除")
                        tmpfmOperator.InorExclude = false;
                tmpfmOperator.OperType = Convert.ToInt16(lvi1.SubItems[3].Text);
                tmpfmOperator.Relation = Convert.ToInt16(lvi1.SubItems[4].Text);
                tmpfmOperator.OperContent = lvi1.SubItems[5].Text;
                tmpfmOperator.OperDisplay = lvi1.SubItems[6].Text;
                tmpfmOperator.ShowDialog();
                DialogResult dlr = tmpfmOperator.DialogResult;
                if (dlr == DialogResult.OK)
                {
                    lvi1.Text = tmpfmOperator.Description;
                    lvi1.SubItems[1].Text = tmpfmOperator.OperId;
                    if (tmpfmOperator.InorExclude)
                        lvi1.SubItems[2].Text = "包含";
                    else
                        lvi1.SubItems[2].Text = "排除";
                    lvi1.SubItems[3].Text = tmpfmOperator.OperType.ToString();
                    lvi1.SubItems[4].Text = tmpfmOperator.Relation.ToString();
                    lvi1.SubItems[5].Text = tmpfmOperator.OperContent;
                    lvi1.SubItems[6].Text = tmpfmOperator.OperDisplay;


                }

            }
        }

        private void btnDeleteOpr_Click(object sender, EventArgs e)
        {
            if (lvOper.SelectedItems.Count > 0)
            {
                lvOper.Items.Remove(lvOper.SelectedItems[0]);
            }
        }

        private void fmTaskView_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelectCtrls_Click(object sender, EventArgs e)
        {
            fmSelectMainUserCtrl tmpfmSelectCtrl = new fmSelectMainUserCtrl(tbxFormName.Text);
            tmpfmSelectCtrl.ShowDialog();
            DialogResult dlr = tmpfmSelectCtrl.DialogResult;
            if (dlr == DialogResult.OK && tmpfmSelectCtrl.lvMainUserCtrl.SelectedItems.Count > 0)
            {
                UserControlId = tmpfmSelectCtrl.lvMainUserCtrl.SelectedItems[0].SubItems[1].Text;
                tbxFormName.Text = tmpfmSelectCtrl.lvMainUserCtrl.SelectedItems[0].Text;
            }
        }

        private void btnRmAdd_Click(object sender, EventArgs e)
        {
            fmSelectUser tmpfmSelectUser = new fmSelectUser();
            tmpfmSelectUser.ShowDialog();
            DialogResult dlr = tmpfmSelectUser.DialogResult;
            if (dlr == DialogResult.OK && tmpfmSelectUser.lvUser.SelectedItems.Count > 0)
            {
                string userid = tmpfmSelectUser.lvUser.SelectedItems[0].SubItems[0].Text;
                string username = tmpfmSelectUser.lvUser.SelectedItems[0].SubItems[1].Text;
                lbxRmMsgToUsers.Items.Add(userid + "|" + username);
            }
        }

        private void btnRmDelete_Click(object sender, EventArgs e)
        {
            if (lbxRmMsgToUsers.SelectedItems.Count > 0)
                lbxRmMsgToUsers.Items.Remove(lbxRmMsgToUsers.SelectedItem);

        }

        private void btnAddcmd_Click(object sender, EventArgs e)
        {
            fmAddCommands tmpfmCommand = new fmAddCommands(WorkConst.STATE_ADD);
            tmpfmCommand.CommandId = Guid.NewGuid().ToString();
            tmpfmCommand.ShowDialog();
            DialogResult dlr = tmpfmCommand.DialogResult;
            if (dlr == DialogResult.OK)
            {

                ListViewItem lvi1 = new ListViewItem(tmpfmCommand.tbxCommandName.Text, 0);
                lvi1.SubItems.Add(tmpfmCommand.CommandId);
                lvi1.SubItems.Add(tmpfmCommand.tbxDes.Text);
                lvCommand.Items.Add(lvi1);
            }
        }

        private void btnModifycmd_Click(object sender, EventArgs e)
        {
            if (lvCommand.SelectedItems.Count > 0)
            {

                ListViewItem lvi1 = lvCommand.SelectedItems[0];
                fmAddCommands tmpfmCommand = new fmAddCommands(WorkConst.STATE_MOD);
                tmpfmCommand.tbxCommandName.Text = lvi1.Text;
                tmpfmCommand.CommandId = lvi1.SubItems[1].Text;
                tmpfmCommand.tbxDes.Text = lvi1.SubItems[2].Text;

                tmpfmCommand.ShowDialog();
                DialogResult dlr = tmpfmCommand.DialogResult;
                if (dlr == DialogResult.OK)
                {
                    lvi1.Text = tmpfmCommand.tbxCommandName.Text;
                    lvi1.SubItems[1].Text = tmpfmCommand.CommandId;
                    lvi1.SubItems[2].Text = tmpfmCommand.tbxDes.Text;
                }
            }
        }

        private void btnDeletecmd_Click(object sender, EventArgs e)
        {
            if (lvCommand.SelectedItems.Count > 0)
            {
                lvCommand.Items.Remove(lvCommand.SelectedItems[0]);
            }
        }

       

        
	}
}
