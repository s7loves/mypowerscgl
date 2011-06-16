using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using Ebada.Client;


namespace Ebada.SCGL.WFlow.Tool
{
	/// <summary>
	/// TaskStartFm 的摘要说明。
	/// </summary>
	public class fmTaskStart : BaseForm_Single
    {
		public string UserId="";//操作人账号，用作权限判断。
        public string UserName = "";
        public string UserControlId = "";//关联表单id
        private IContainer components;//操作人姓名，用作显示。
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label4;
        private TextBox tbxTaskDes;
        private Label label2;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private Button btnDeletecmd;
        private Button btnModifycmd;
        private Button btnAddcmd;
        private Label label3;
        private TextBox tbxFormName;
        private TextBox tbxTaskName;
        private Button btnSelectCtrls;
        private Label label1;
        private TabPage tabPage3;
        private Button btnDeleteOpr;
        private Button btnModifyOpr;
        private Button btnAddOpr;
        private Label label5;
        private GroupBox groupBox2;
        private RadioButton rbtEveryUser;
        private RadioButton rbtShareUser;
        private TabPage tabPage2;
        private ContextMenu contextMenu1;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private MenuItem menuItem4;
        private ContextMenu contextMenu2;
        private MenuItem menuItem8;
        private ContextMenu contextMenu3;
		/// <summary>
		/// 当前的任务节点
		/// </summary>
        public StartTask NowTask;
        private ImageList imgListSmall;
        private Button btnDeleteVar;
        private Button btnModifyVar;
        private Button btnAddVar;
        private ListView lvVar;
        private ListView lvCommand;
        private ListView lvOper;
 
	

		public fmTaskStart(StartTask startTask,string userId,string userName)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            NowTask=startTask;
			this.UserId=userId;
			this.UserName=userName;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmTaskStart));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtEveryUser = new System.Windows.Forms.RadioButton();
            this.rbtShareUser = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvVar = new System.Windows.Forms.ListView();
            this.btnDeleteVar = new System.Windows.Forms.Button();
            this.btnModifyVar = new System.Windows.Forms.Button();
            this.btnAddVar = new System.Windows.Forms.Button();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDeleteOpr = new System.Windows.Forms.Button();
            this.btnModifyOpr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lvOper = new System.Windows.Forms.ListView();
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.btnAddOpr = new System.Windows.Forms.Button();
            this.btnSelectCtrls = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxTaskDes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDeletecmd = new System.Windows.Forms.Button();
            this.btnModifycmd = new System.Windows.Forms.Button();
            this.btnAddcmd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxFormName = new System.Windows.Forms.TextBox();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvCommand = new System.Windows.Forms.ListView();
            this.tbxTaskName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.contextMenu3 = new System.Windows.Forms.ContextMenu();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.tabControl1);
            this.plclassFill.Size = new System.Drawing.Size(439, 448);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 401);
            this.plclassBottom.Size = new System.Drawing.Size(439, 47);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Location = new System.Drawing.Point(213, 12);
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(306, 12);
            this.btnClose.Text = "取消(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtEveryUser);
            this.groupBox2.Controls.Add(this.rbtShareUser);
            this.groupBox2.Location = new System.Drawing.Point(25, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 59);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "处理者策略";
            // 
            // rbtEveryUser
            // 
            this.rbtEveryUser.AutoSize = true;
            this.rbtEveryUser.Location = new System.Drawing.Point(170, 30);
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvVar);
            this.tabPage2.Controls.Add(this.btnDeleteVar);
            this.tabPage2.Controls.Add(this.btnModifyVar);
            this.tabPage2.Controls.Add(this.btnAddVar);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(415, 361);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "任务变量";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Visible = false;
            // 
            // lvVar
            // 
            this.lvVar.FullRowSelect = true;
            this.lvVar.Location = new System.Drawing.Point(17, 23);
            this.lvVar.MultiSelect = false;
            this.lvVar.Name = "lvVar";
            this.lvVar.Size = new System.Drawing.Size(381, 234);
            this.lvVar.TabIndex = 4;
            this.lvVar.UseCompatibleStateImageBehavior = false;
            this.lvVar.View = System.Windows.Forms.View.Details;
            this.lvVar.SelectedIndexChanged += new System.EventHandler(this.lvVar_SelectedIndexChanged);
            this.lvVar.DoubleClick += new System.EventHandler(this.btnModifyVar_Click);
            // 
            // btnDeleteVar
            // 
            this.btnDeleteVar.Location = new System.Drawing.Point(263, 286);
            this.btnDeleteVar.Name = "btnDeleteVar";
            this.btnDeleteVar.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteVar.TabIndex = 3;
            this.btnDeleteVar.Text = "删除";
            this.btnDeleteVar.UseVisualStyleBackColor = true;
            this.btnDeleteVar.Click += new System.EventHandler(this.btnDeleteVar_Click);
            // 
            // btnModifyVar
            // 
            this.btnModifyVar.Location = new System.Drawing.Point(146, 285);
            this.btnModifyVar.Name = "btnModifyVar";
            this.btnModifyVar.Size = new System.Drawing.Size(75, 23);
            this.btnModifyVar.TabIndex = 2;
            this.btnModifyVar.Text = "修改";
            this.btnModifyVar.UseVisualStyleBackColor = true;
            this.btnModifyVar.Click += new System.EventHandler(this.btnModifyVar_Click);
            // 
            // btnAddVar
            // 
            this.btnAddVar.Location = new System.Drawing.Point(46, 286);
            this.btnAddVar.Name = "btnAddVar";
            this.btnAddVar.Size = new System.Drawing.Size(75, 23);
            this.btnAddVar.TabIndex = 1;
            this.btnAddVar.Text = "增加";
            this.btnAddVar.UseVisualStyleBackColor = true;
            this.btnAddVar.Click += new System.EventHandler(this.btnAddVar_Click);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "添加";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "修改";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "删除";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 98;
            this.label5.Text = "处理者:";
            // 
            // btnDeleteOpr
            // 
            this.btnDeleteOpr.Location = new System.Drawing.Point(210, 315);
            this.btnDeleteOpr.Name = "btnDeleteOpr";
            this.btnDeleteOpr.Size = new System.Drawing.Size(80, 23);
            this.btnDeleteOpr.TabIndex = 101;
            this.btnDeleteOpr.Text = "删除";
            this.btnDeleteOpr.Click += new System.EventHandler(this.btnDeleteOpr_Click);
            // 
            // btnModifyOpr
            // 
            this.btnModifyOpr.Location = new System.Drawing.Point(111, 315);
            this.btnModifyOpr.Name = "btnModifyOpr";
            this.btnModifyOpr.Size = new System.Drawing.Size(80, 23);
            this.btnModifyOpr.TabIndex = 100;
            this.btnModifyOpr.Text = "修改";
            this.btnModifyOpr.Click += new System.EventHandler(this.btnModifyOpr_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(55, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "任务名称:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lvOper);
            this.tabPage3.Controls.Add(this.btnDeleteOpr);
            this.tabPage3.Controls.Add(this.btnModifyOpr);
            this.tabPage3.Controls.Add(this.btnAddOpr);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(415, 361);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "处理者";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lvOper
            // 
            this.lvOper.FullRowSelect = true;
            this.lvOper.Location = new System.Drawing.Point(25, 113);
            this.lvOper.Name = "lvOper";
            this.lvOper.Size = new System.Drawing.Size(355, 173);
            this.lvOper.SmallImageList = this.imgListSmall;
            this.lvOper.TabIndex = 102;
            this.lvOper.UseCompatibleStateImageBehavior = false;
            this.lvOper.View = System.Windows.Forms.View.Details;
            this.lvOper.DoubleClick += new System.EventHandler(this.btnModifyOpr_Click);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall.Images.SetKeyName(0, "12.bmp");
            // 
            // btnAddOpr
            // 
            this.btnAddOpr.Location = new System.Drawing.Point(25, 315);
            this.btnAddOpr.Name = "btnAddOpr";
            this.btnAddOpr.Size = new System.Drawing.Size(80, 23);
            this.btnAddOpr.TabIndex = 99;
            this.btnAddOpr.Text = "增加";
            this.btnAddOpr.Click += new System.EventHandler(this.btnAddOpr_Click);
            // 
            // btnSelectCtrls
            // 
            this.btnSelectCtrls.Location = new System.Drawing.Point(353, 51);
            this.btnSelectCtrls.Name = "btnSelectCtrls";
            this.btnSelectCtrls.Size = new System.Drawing.Size(41, 23);
            this.btnSelectCtrls.TabIndex = 11;
            this.btnSelectCtrls.Text = "";
            this.btnSelectCtrls.Click += new System.EventHandler(this.btnSelectCtrls_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(55, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 23);
            this.label4.TabIndex = 99;
            this.label4.Text = "任务描述:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxTaskDes
            // 
            this.tbxTaskDes.Location = new System.Drawing.Point(135, 80);
            this.tbxTaskDes.Name = "tbxTaskDes";
            this.tbxTaskDes.Size = new System.Drawing.Size(259, 21);
            this.tbxTaskDes.TabIndex = 98;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 97;
            this.label2.Text = "处理:";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 2);
            this.groupBox1.TabIndex = 96;
            this.groupBox1.TabStop = false;
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 0;
            this.menuItem4.Text = "删除";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 34);
            this.pictureBox1.TabIndex = 95;
            this.pictureBox1.TabStop = false;
            // 
            // btnDeletecmd
            // 
            this.btnDeletecmd.Location = new System.Drawing.Point(257, 320);
            this.btnDeletecmd.Name = "btnDeletecmd";
            this.btnDeletecmd.Size = new System.Drawing.Size(80, 23);
            this.btnDeletecmd.TabIndex = 16;
            this.btnDeletecmd.Text = "删除";
            this.btnDeletecmd.Click += new System.EventHandler(this.btnDeletecmd_Click);
            // 
            // btnModifycmd
            // 
            this.btnModifycmd.Location = new System.Drawing.Point(135, 320);
            this.btnModifycmd.Name = "btnModifycmd";
            this.btnModifycmd.Size = new System.Drawing.Size(80, 23);
            this.btnModifycmd.TabIndex = 15;
            this.btnModifycmd.Text = "修改";
            this.btnModifycmd.Click += new System.EventHandler(this.btnModifycmd_Click);
            // 
            // btnAddcmd
            // 
            this.btnAddcmd.Location = new System.Drawing.Point(35, 320);
            this.btnAddcmd.Name = "btnAddcmd";
            this.btnAddcmd.Size = new System.Drawing.Size(80, 23);
            this.btnAddcmd.TabIndex = 12;
            this.btnAddcmd.Text = "增加";
            this.btnAddcmd.Click += new System.EventHandler(this.btnAddcmd_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(67, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "表单名:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxFormName
            // 
            this.tbxFormName.Location = new System.Drawing.Point(135, 51);
            this.tbxFormName.Name = "tbxFormName";
            this.tbxFormName.ReadOnly = true;
            this.tbxFormName.Size = new System.Drawing.Size(212, 21);
            this.tbxFormName.TabIndex = 12;
            // 
            // contextMenu2
            // 
            this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4});
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvCommand);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tbxTaskDes);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.btnDeletecmd);
            this.tabPage1.Controls.Add(this.btnModifycmd);
            this.tabPage1.Controls.Add(this.btnAddcmd);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbxFormName);
            this.tabPage1.Controls.Add(this.tbxTaskName);
            this.tabPage1.Controls.Add(this.btnSelectCtrls);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(415, 361);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "常规";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvCommand
            // 
            this.lvCommand.FullRowSelect = true;
            this.lvCommand.Location = new System.Drawing.Point(15, 148);
            this.lvCommand.Name = "lvCommand";
            this.lvCommand.Size = new System.Drawing.Size(379, 166);
            this.lvCommand.SmallImageList = this.imgListSmall;
            this.lvCommand.TabIndex = 127;
            this.lvCommand.UseCompatibleStateImageBehavior = false;
            this.lvCommand.View = System.Windows.Forms.View.Details;
            this.lvCommand.DoubleClick += new System.EventHandler(this.btnModifycmd_Click);
            // 
            // tbxTaskName
            // 
            this.tbxTaskName.Location = new System.Drawing.Point(135, 23);
            this.tbxTaskName.Name = "tbxTaskName";
            this.tbxTaskName.Size = new System.Drawing.Size(259, 21);
            this.tbxTaskName.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(8, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(423, 386);
            this.tabControl1.TabIndex = 8;
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 0;
            this.menuItem8.Text = "删除";
            // 
            // contextMenu3
            // 
            this.contextMenu3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem8});
            // 
            // fmTaskStart
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(439, 448);
            this.Name = "fmTaskStart";
            this.Text = "启动节点";
            this.Load += new System.EventHandler(this.fmTaskStart_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
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
            lvOper.Columns.Add("处理类型", 100, HorizontalAlignment.Left);
            lvOper.Columns.Add("处理策略", 100, HorizontalAlignment.Left);
            lvOper.Columns.Add("处理者", 100, HorizontalAlignment.Left);  
            lvOper.Columns.Add("operDisplay", 100, HorizontalAlignment.Left);
            DataTable OperTable = WorkFlowTask.GetTaskOperator(NowTask.WorkFlowId,NowTask.TaskId);
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

            //*********变量
            lvVar.Columns.Add("变量名", 200, HorizontalAlignment.Left);
            lvVar.Columns.Add("TaskVarId", 0, HorizontalAlignment.Left);
            lvVar.Columns.Add("变量类型", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("变量模式", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("数据库名", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("数据表名", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("字段名", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("初始值", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("访问类型", 100, HorizontalAlignment.Left);
            //加载系统变量
            List<SystemVarItem> sysVarItem = SystemVarData.GetSystemVarItems();
            foreach (SystemVarItem var in sysVarItem)
            {
                ListViewItem lvi1 = new ListViewItem(var.VarName, 0);
                lvi1.SubItems.Add("");
                lvi1.SubItems.Add(var.VarType);
                lvi1.SubItems.Add("");
                lvi1.SubItems.Add("");
                lvi1.SubItems.Add("");
                lvi1.SubItems.Add("");
                lvi1.SubItems.Add("");
                lvi1.SubItems.Add("");
                lvi1.ForeColor = Color.Red;
                lvVar.Items.Add(lvi1);
            }
            DataTable VarTable = WorkFlowTask.GetTaskVar(NowTask.TaskId);
            foreach (DataRow dr in VarTable.Rows)
            {
                ListViewItem lvi1 = new ListViewItem(dr["VarName"].ToString(), 0);
                lvi1.SubItems.Add(dr["TaskVarId"].ToString());
                lvi1.SubItems.Add(dr["VarType"].ToString());
                lvi1.SubItems.Add(dr["VarModule"].ToString());
                lvi1.SubItems.Add(dr["DataBaseName"].ToString());
                lvi1.SubItems.Add(dr["TableName"].ToString());
                lvi1.SubItems.Add(dr["TableField"].ToString());
                lvi1.SubItems.Add(dr["InitValue"].ToString());
                lvi1.SubItems.Add(dr["AccessType"].ToString());
                lvVar.Items.Add(lvi1);
            } 
            //表单
            DataTable ctrlTable = WorkFlowTask.GetTaskControls(NowTask.TaskId);
            if (ctrlTable!=null &&ctrlTable.Rows.Count>0)
            {
                tbxFormName.Text = ctrlTable.Rows[0]["mucCaption"].ToString();
                UserControlId = ctrlTable.Rows[0]["UserControlId"].ToString();
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

            //保存任务处理者
            WorkFlowTask.DeleteAllOperator(NowTask.TaskId);
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

            //保存任务变量
            WorkFlowTask.DeleteAllTaskVar(NowTask.TaskId);
            foreach (ListViewItem lt in lvVar.Items)
            {
                bool isSysVar = SystemVarData.isSystemVar(lt.Text);
                if (isSysVar) continue;//跳过系统变量
                TaskVar tmpTaskVar = new TaskVar();
                tmpTaskVar.VarName = lt.Text;
                tmpTaskVar.WorkFlowId = NowTask.WorkFlowId;
                tmpTaskVar.WorkTaskId = NowTask.TaskId;
                tmpTaskVar.TaskVarId = lt.SubItems[1].Text;
                tmpTaskVar.VarType = lt.SubItems[2].Text;
                tmpTaskVar.VarModule = lt.SubItems[3].Text;
                tmpTaskVar.DataBaseName = lt.SubItems[4].Text;
                tmpTaskVar.TableName = lt.SubItems[5].Text;
                tmpTaskVar.TableField = lt.SubItems[6].Text;
                tmpTaskVar.InitValue = lt.SubItems[7].Text;
                tmpTaskVar.AccessType = lt.SubItems[8].Text;
                tmpTaskVar.InsertTaskVar();
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
            WorkFlowTask.SetTaskUserCtrls(UserControlId,NowTask.WorkFlowId,NowTask.TaskId);
 
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

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

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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

        private void fmTaskStart_Load(object sender, EventArgs e)
        {
            InitData();
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
               if (lvi1.SubItems[2].Text=="包含")
               tmpfmOperator.InorExclude =true;
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
                       lvi1.SubItems[2].Text="包含";
                   else
                       lvi1.SubItems[2].Text = "排除";
                   lvi1.SubItems[3].Text = tmpfmOperator.OperType.ToString();
                   lvi1.SubItems[4].Text = tmpfmOperator.Relation.ToString();
                   lvi1.SubItems[5].Text = tmpfmOperator.OperContent;
                   lvi1.SubItems[6].Text = tmpfmOperator.OperDisplay; 
               
               }

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

        private void btnDeleteOpr_Click(object sender, EventArgs e)
        {
            if (lvOper.SelectedItems.Count > 0)
            {
                lvOper.Items.Remove(lvOper.SelectedItems[0]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        private bool varExists(string varName)
        {
            if (lvVar.Items.Count > 0)
            {
                foreach (ListViewItem lt in lvVar.Items)
                {
                    if (varName == lt.Text)
                        return true;
                }
            }
            return false;
        }
        private void btnAddVar_Click(object sender, EventArgs e)
        {
            fmTaskVar tmpfmTaskVar = new fmTaskVar(WorkConst.STATE_ADD);
            tmpfmTaskVar.TaskVarId = Guid.NewGuid().ToString();
            tmpfmTaskVar.varDataBaseName = "";
            tmpfmTaskVar.varDataTableName = "";
            tmpfmTaskVar.varTableColumnName ="";
            tmpfmTaskVar.ShowDialog();
            DialogResult dlr = tmpfmTaskVar.DialogResult;
            if (dlr == DialogResult.OK)
            {
                if (varExists(tmpfmTaskVar.tbxVarName.Text))
                {
                    MsgBox.ShowWarningMessageBox ("变量" + tmpfmTaskVar.tbxVarName.Text + "已存在,不能填加!");
                    return;
                }
                ListViewItem lvi1 = new ListViewItem(tmpfmTaskVar.tbxVarName.Text, 0);
                lvi1.SubItems.Add(tmpfmTaskVar.TaskVarId);
                lvi1.SubItems.Add(tmpfmTaskVar.cbxVarType.SelectedItem.ToString());
                lvi1.SubItems.Add(tmpfmTaskVar.cbxVarModule.SelectedItem.ToString());
                lvi1.SubItems.Add(tmpfmTaskVar.varDataBaseName);
                lvi1.SubItems.Add(tmpfmTaskVar.cbxDataTable.Text);
                lvi1.SubItems.Add(tmpfmTaskVar.cbxTableColumns.Text);
                lvi1.SubItems.Add(tmpfmTaskVar.tbxIniValue.Text);
                lvi1.SubItems.Add(tmpfmTaskVar.cbxAccessType.SelectedIndex.ToString());
                lvVar.Items.Add(lvi1);
            }
        }

        private void btnModifyVar_Click(object sender, EventArgs e)
        {
            if (lvVar.SelectedItems.Count > 0)
            {

                ListViewItem lvi1 = lvVar.SelectedItems[0];
                bool isSysVar = SystemVarData.isSystemVar(lvi1.Text);
                if (isSysVar) return;//跳过系统变量
                fmTaskVar tmpfmTaskVar = new fmTaskVar(WorkConst.STATE_MOD);
                tmpfmTaskVar.tbxVarName.Text = lvi1.Text;
                tmpfmTaskVar.TaskVarId = lvi1.SubItems[1].Text;
                tmpfmTaskVar.cbxVarType.Text=lvi1.SubItems[2].Text;
                tmpfmTaskVar.cbxVarModule.Text=lvi1.SubItems[3].Text;
          
                tmpfmTaskVar.varDataBaseName = lvi1.SubItems[4].Text;
                tmpfmTaskVar.varDataTableName = lvi1.SubItems[5].Text;
                tmpfmTaskVar.varTableColumnName = lvi1.SubItems[6].Text;
                tmpfmTaskVar.tbxIniValue.Text = lvi1.SubItems[7].Text;
                string accessType = lvi1.SubItems[8].Text;
                if (accessType.Trim().Length == 0)
                {
                    tmpfmTaskVar.cbxAccessType.SelectedIndex = 0;
                }
                else
                {
                    if (char.IsNumber(accessType[0]))
                        tmpfmTaskVar.cbxAccessType.SelectedIndex = Convert.ToInt16(accessType);
                }
                tmpfmTaskVar.ShowDialog();
                DialogResult dlr = tmpfmTaskVar.DialogResult;
                if (dlr == DialogResult.OK)
                {
                    if (lvi1.Text != tmpfmTaskVar.tbxVarName.Text && varExists(tmpfmTaskVar.tbxVarName.Text))
                    {
                        MsgBox.ShowWarningMessageBox("变量" + tmpfmTaskVar.tbxVarName.Text + "已存在,请使用其他名称!");
                        return;
                    }
                    lvi1.Text = tmpfmTaskVar.tbxVarName.Text;
                    lvi1.SubItems[1].Text = tmpfmTaskVar.TaskVarId;
                    lvi1.SubItems[2].Text = tmpfmTaskVar.cbxVarType.SelectedItem.ToString();
                    lvi1.SubItems[3].Text = tmpfmTaskVar.cbxVarModule.SelectedItem.ToString();
                    lvi1.SubItems[4].Text = tmpfmTaskVar.varDataBaseName;
                    lvi1.SubItems[5].Text = tmpfmTaskVar.cbxDataTable.Text;
                    lvi1.SubItems[6].Text = tmpfmTaskVar.cbxTableColumns.Text;
                    lvi1.SubItems[7].Text = tmpfmTaskVar.tbxIniValue.Text;
                    
                    if (tmpfmTaskVar.cbxAccessType.SelectedIndex > 0)
                        lvi1.SubItems[8].Text = tmpfmTaskVar.cbxAccessType.SelectedIndex.ToString();
                    else
                        lvi1.SubItems[8].Text = "public";
                }

            }
        }

        private void btnDeleteVar_Click(object sender, EventArgs e)
        {
            if (lvVar.SelectedItems.Count > 0)
            {
                lvVar.Items.Remove(lvVar.SelectedItems[0]);
            }
        }

        private void btnDeletecmd_Click(object sender, EventArgs e)
        {
            if (lvCommand.SelectedItems.Count > 0)
            {
                lvCommand.Items.Remove(lvCommand.SelectedItems[0]);
            }
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

        private void lvVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvVar.SelectedItems.Count > 0)
            {
                ListViewItem lvi1 = lvVar.SelectedItems[0];
                bool isSysVar = SystemVarData.isSystemVar(lvi1.Text);
                btnModifyVar.Enabled = !isSysVar;
                btnDeleteVar.Enabled = !isSysVar;
            }
        }

       

        
	}
}
