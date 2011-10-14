using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using Ebada.Client;
using Ebada.Client.Platform;
using Ebada.Scgl.Model;
using System.Reflection;
using Ebada.Core;


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
        public string UserModleId = "";//关联模块id
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
        private Label label6;
        private TextBox tbxModleName;
        private Button btnSelectModle;
        private Label label7;
        private TextBox tbxFiledName;
        private Button btnSelctField;
        private TabPage tabPage4;
        private GroupBox groupBox11;
        private ComboBox cbxWorkDbTableColumns;
        private ComboBox cbxWorkDbTable;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private RadioButton rbnWorkDatabase;
        private DevExpress.XtraEditors.TextEdit tetWorkFixValue;
        private DevExpress.XtraEditors.TextEdit tetWorkExcelName;
        private DevExpress.XtraEditors.TextEdit tetWorkPos;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private ComboBox cbxWorkTableColumns;
        private ComboBox cbxWorkDataTable;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private RadioButton rbnWorkFixValue;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private RadioButton rbnWorkExcel;
        private RadioButton rbnWorkTable;
        private GroupBox groupBox9;
        private ComboBox cbxCharManDbTableColumns;
        private ComboBox cbxCharManDbTable;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        private DevExpress.XtraEditors.LabelControl labelControl28;
        private RadioButton rbnCharManDatabase;
        private DevExpress.XtraEditors.TextEdit tetCharManFixValue;
        private DevExpress.XtraEditors.TextEdit tetCharManExcelName;
        private DevExpress.XtraEditors.TextEdit tetCharManPos;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private ComboBox cbxCharManTableColumns;
        private ComboBox cbxCharManDataTable;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private RadioButton rbnCharManFixValue;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private RadioButton rbnCharManExcel;
        private RadioButton rbnCharManTable;
        private GroupBox groupBox8;
        private ComboBox cbxAttendManDbTableColumns;
        private DevExpress.XtraEditors.TextEdit tetAttendManFixValue;
        private ComboBox cbxAttendManDbTable;
        private DevExpress.XtraEditors.LabelControl labelControl30;
        private DevExpress.XtraEditors.TextEdit tetAttendManExcelName;
        private DevExpress.XtraEditors.LabelControl labelControl29;
        private DevExpress.XtraEditors.TextEdit tetAttendManPos;
        private RadioButton rbnAttendManDatabase;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private ComboBox cbxAttendManTableColumns;
        private ComboBox cbxAttendManDataTable;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private RadioButton rbnAttendManFixValue;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private RadioButton rbnAttendManExcel;
        private RadioButton rbnAttendManTable;
        private GroupBox groupBox10;
        private ComboBox cbxProjectDbTableColumns;
        private ComboBox cbxProjectDbTable;
        private DevExpress.XtraEditors.LabelControl labelControl25;
        private DevExpress.XtraEditors.LabelControl labelControl26;
        private RadioButton rbnProjectDatabase;
        private DevExpress.XtraEditors.TextEdit tetProjectFixValue;
        private DevExpress.XtraEditors.TextEdit tetProjectExcelName;
        private DevExpress.XtraEditors.TextEdit tetProjectPos;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private ComboBox cbxProjectTableColumns;
        private ComboBox cbxProjectDataTable;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private RadioButton rbnProjectFixValue;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private RadioButton rbnProjectExcel;
        private RadioButton rbnProjectTable;
        private CheckBox cbxRiZhi;
        private ListView lvOper;
        private Button btnModleClear;
        private Button btnFieldClear;
        private Button btnTableClear;
        private string varDbTableName = "";
 
	

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
            this.btnModleClear = new System.Windows.Forms.Button();
            this.btnFieldClear = new System.Windows.Forms.Button();
            this.btnTableClear = new System.Windows.Forms.Button();
            this.lvCommand = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxModleName = new System.Windows.Forms.TextBox();
            this.tbxFiledName = new System.Windows.Forms.TextBox();
            this.btnSelectModle = new System.Windows.Forms.Button();
            this.btnSelctField = new System.Windows.Forms.Button();
            this.tbxTaskName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cbxRiZhi = new System.Windows.Forms.CheckBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.cbxProjectDbTableColumns = new System.Windows.Forms.ComboBox();
            this.cbxProjectDbTable = new System.Windows.Forms.ComboBox();
            this.labelControl25 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl26 = new DevExpress.XtraEditors.LabelControl();
            this.rbnProjectDatabase = new System.Windows.Forms.RadioButton();
            this.tetProjectFixValue = new DevExpress.XtraEditors.TextEdit();
            this.tetProjectExcelName = new DevExpress.XtraEditors.TextEdit();
            this.tetProjectPos = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.cbxProjectTableColumns = new System.Windows.Forms.ComboBox();
            this.cbxProjectDataTable = new System.Windows.Forms.ComboBox();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.rbnProjectFixValue = new System.Windows.Forms.RadioButton();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.rbnProjectExcel = new System.Windows.Forms.RadioButton();
            this.rbnProjectTable = new System.Windows.Forms.RadioButton();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.cbxWorkDbTableColumns = new System.Windows.Forms.ComboBox();
            this.cbxWorkDbTable = new System.Windows.Forms.ComboBox();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.rbnWorkDatabase = new System.Windows.Forms.RadioButton();
            this.tetWorkFixValue = new DevExpress.XtraEditors.TextEdit();
            this.tetWorkExcelName = new DevExpress.XtraEditors.TextEdit();
            this.tetWorkPos = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.cbxWorkTableColumns = new System.Windows.Forms.ComboBox();
            this.cbxWorkDataTable = new System.Windows.Forms.ComboBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.rbnWorkFixValue = new System.Windows.Forms.RadioButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.rbnWorkExcel = new System.Windows.Forms.RadioButton();
            this.rbnWorkTable = new System.Windows.Forms.RadioButton();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.cbxCharManDbTableColumns = new System.Windows.Forms.ComboBox();
            this.cbxCharManDbTable = new System.Windows.Forms.ComboBox();
            this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl28 = new DevExpress.XtraEditors.LabelControl();
            this.rbnCharManDatabase = new System.Windows.Forms.RadioButton();
            this.tetCharManFixValue = new DevExpress.XtraEditors.TextEdit();
            this.tetCharManExcelName = new DevExpress.XtraEditors.TextEdit();
            this.tetCharManPos = new DevExpress.XtraEditors.TextEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.cbxCharManTableColumns = new System.Windows.Forms.ComboBox();
            this.cbxCharManDataTable = new System.Windows.Forms.ComboBox();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.rbnCharManFixValue = new System.Windows.Forms.RadioButton();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.rbnCharManExcel = new System.Windows.Forms.RadioButton();
            this.rbnCharManTable = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cbxAttendManDbTableColumns = new System.Windows.Forms.ComboBox();
            this.tetAttendManFixValue = new DevExpress.XtraEditors.TextEdit();
            this.cbxAttendManDbTable = new System.Windows.Forms.ComboBox();
            this.labelControl30 = new DevExpress.XtraEditors.LabelControl();
            this.tetAttendManExcelName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl29 = new DevExpress.XtraEditors.LabelControl();
            this.tetAttendManPos = new DevExpress.XtraEditors.TextEdit();
            this.rbnAttendManDatabase = new System.Windows.Forms.RadioButton();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.cbxAttendManTableColumns = new System.Windows.Forms.ComboBox();
            this.cbxAttendManDataTable = new System.Windows.Forms.ComboBox();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.rbnAttendManFixValue = new System.Windows.Forms.RadioButton();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.rbnAttendManExcel = new System.Windows.Forms.RadioButton();
            this.rbnAttendManTable = new System.Windows.Forms.RadioButton();
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
            this.tabPage4.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tetProjectFixValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetProjectExcelName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetProjectPos.Properties)).BeginInit();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkFixValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkExcelName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkPos.Properties)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tetCharManFixValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetCharManExcelName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetCharManPos.Properties)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tetAttendManFixValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetAttendManExcelName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetAttendManPos.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.tabControl1);
            this.plclassFill.Size = new System.Drawing.Size(557, 583);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 536);
            this.plclassBottom.Size = new System.Drawing.Size(557, 47);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Location = new System.Drawing.Point(385, 12);
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(470, 12);
            this.btnClose.Text = "取消(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtEveryUser);
            this.groupBox2.Controls.Add(this.rbtShareUser);
            this.groupBox2.Location = new System.Drawing.Point(25, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(489, 101);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "处理者策略";
            // 
            // rbtEveryUser
            // 
            this.rbtEveryUser.AutoSize = true;
            this.rbtEveryUser.Location = new System.Drawing.Point(170, 48);
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
            this.rbtShareUser.Location = new System.Drawing.Point(25, 48);
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
            this.tabPage2.Size = new System.Drawing.Size(538, 495);
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
            this.lvVar.Size = new System.Drawing.Size(502, 440);
            this.lvVar.TabIndex = 4;
            this.lvVar.UseCompatibleStateImageBehavior = false;
            this.lvVar.View = System.Windows.Forms.View.Details;
            this.lvVar.SelectedIndexChanged += new System.EventHandler(this.lvVar_SelectedIndexChanged);
            this.lvVar.DoubleClick += new System.EventHandler(this.btnModifyVar_Click);
            // 
            // btnDeleteVar
            // 
            this.btnDeleteVar.Location = new System.Drawing.Point(265, 469);
            this.btnDeleteVar.Name = "btnDeleteVar";
            this.btnDeleteVar.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteVar.TabIndex = 3;
            this.btnDeleteVar.Text = "删除";
            this.btnDeleteVar.UseVisualStyleBackColor = true;
            this.btnDeleteVar.Click += new System.EventHandler(this.btnDeleteVar_Click);
            // 
            // btnModifyVar
            // 
            this.btnModifyVar.Location = new System.Drawing.Point(147, 469);
            this.btnModifyVar.Name = "btnModifyVar";
            this.btnModifyVar.Size = new System.Drawing.Size(75, 23);
            this.btnModifyVar.TabIndex = 2;
            this.btnModifyVar.Text = "修改";
            this.btnModifyVar.UseVisualStyleBackColor = true;
            this.btnModifyVar.Click += new System.EventHandler(this.btnModifyVar_Click);
            // 
            // btnAddVar
            // 
            this.btnAddVar.Location = new System.Drawing.Point(43, 469);
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
            this.label5.Location = new System.Drawing.Point(23, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 98;
            this.label5.Text = "处理者:";
            // 
            // btnDeleteOpr
            // 
            this.btnDeleteOpr.Location = new System.Drawing.Point(210, 456);
            this.btnDeleteOpr.Name = "btnDeleteOpr";
            this.btnDeleteOpr.Size = new System.Drawing.Size(80, 23);
            this.btnDeleteOpr.TabIndex = 101;
            this.btnDeleteOpr.Text = "删除";
            this.btnDeleteOpr.Visible = false;
            this.btnDeleteOpr.Click += new System.EventHandler(this.btnDeleteOpr_Click);
            // 
            // btnModifyOpr
            // 
            this.btnModifyOpr.Location = new System.Drawing.Point(111, 456);
            this.btnModifyOpr.Name = "btnModifyOpr";
            this.btnModifyOpr.Size = new System.Drawing.Size(80, 23);
            this.btnModifyOpr.TabIndex = 100;
            this.btnModifyOpr.Text = "修改";
            this.btnModifyOpr.Visible = false;
            this.btnModifyOpr.Click += new System.EventHandler(this.btnModifyOpr_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(66, 35);
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
            this.tabPage3.Size = new System.Drawing.Size(538, 495);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "处理者";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lvOper
            // 
            this.lvOper.FullRowSelect = true;
            this.lvOper.Location = new System.Drawing.Point(25, 146);
            this.lvOper.Name = "lvOper";
            this.lvOper.Size = new System.Drawing.Size(489, 304);
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
            this.btnAddOpr.Location = new System.Drawing.Point(25, 456);
            this.btnAddOpr.Name = "btnAddOpr";
            this.btnAddOpr.Size = new System.Drawing.Size(80, 23);
            this.btnAddOpr.TabIndex = 99;
            this.btnAddOpr.Text = "增加";
            this.btnAddOpr.Visible = false;
            this.btnAddOpr.Click += new System.EventHandler(this.btnAddOpr_Click);
            // 
            // btnSelectCtrls
            // 
            this.btnSelectCtrls.Location = new System.Drawing.Point(472, 113);
            this.btnSelectCtrls.Name = "btnSelectCtrls";
            this.btnSelectCtrls.Size = new System.Drawing.Size(41, 23);
            this.btnSelectCtrls.TabIndex = 11;
            this.btnSelectCtrls.Text = "...";
            this.btnSelectCtrls.Click += new System.EventHandler(this.btnSelectCtrls_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(66, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 23);
            this.label4.TabIndex = 99;
            this.label4.Text = "任务描述:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxTaskDes
            // 
            this.tbxTaskDes.Location = new System.Drawing.Point(146, 62);
            this.tbxTaskDes.Name = "tbxTaskDes";
            this.tbxTaskDes.Size = new System.Drawing.Size(320, 21);
            this.tbxTaskDes.TabIndex = 98;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 97;
            this.label2.Text = "处理:";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 2);
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
            this.pictureBox1.Location = new System.Drawing.Point(21, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 34);
            this.pictureBox1.TabIndex = 95;
            this.pictureBox1.TabStop = false;
            // 
            // btnDeletecmd
            // 
            this.btnDeletecmd.Location = new System.Drawing.Point(252, 455);
            this.btnDeletecmd.Name = "btnDeletecmd";
            this.btnDeletecmd.Size = new System.Drawing.Size(80, 23);
            this.btnDeletecmd.TabIndex = 16;
            this.btnDeletecmd.Text = "删除";
            this.btnDeletecmd.Click += new System.EventHandler(this.btnDeletecmd_Click);
            // 
            // btnModifycmd
            // 
            this.btnModifycmd.Location = new System.Drawing.Point(130, 455);
            this.btnModifycmd.Name = "btnModifycmd";
            this.btnModifycmd.Size = new System.Drawing.Size(80, 23);
            this.btnModifycmd.TabIndex = 15;
            this.btnModifycmd.Text = "修改";
            this.btnModifycmd.Click += new System.EventHandler(this.btnModifycmd_Click);
            // 
            // btnAddcmd
            // 
            this.btnAddcmd.Location = new System.Drawing.Point(30, 455);
            this.btnAddcmd.Name = "btnAddcmd";
            this.btnAddcmd.Size = new System.Drawing.Size(80, 23);
            this.btnAddcmd.TabIndex = 12;
            this.btnAddcmd.Text = "增加";
            this.btnAddcmd.Click += new System.EventHandler(this.btnAddcmd_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(76, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "表单名:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxFormName
            // 
            this.tbxFormName.Location = new System.Drawing.Point(146, 113);
            this.tbxFormName.Name = "tbxFormName";
            this.tbxFormName.ReadOnly = true;
            this.tbxFormName.Size = new System.Drawing.Size(320, 21);
            this.tbxFormName.TabIndex = 12;
            // 
            // contextMenu2
            // 
            this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4});
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnModleClear);
            this.tabPage1.Controls.Add(this.btnFieldClear);
            this.tabPage1.Controls.Add(this.btnTableClear);
            this.tabPage1.Controls.Add(this.lvCommand);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tbxTaskDes);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.btnDeletecmd);
            this.tabPage1.Controls.Add(this.btnModifycmd);
            this.tabPage1.Controls.Add(this.btnAddcmd);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbxModleName);
            this.tabPage1.Controls.Add(this.tbxFiledName);
            this.tabPage1.Controls.Add(this.tbxFormName);
            this.tabPage1.Controls.Add(this.btnSelectModle);
            this.tabPage1.Controls.Add(this.btnSelctField);
            this.tabPage1.Controls.Add(this.tbxTaskName);
            this.tabPage1.Controls.Add(this.btnSelectCtrls);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(538, 495);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "常规";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnModleClear
            // 
            this.btnModleClear.Image = global::Ebada.SCGL.WFlow.Tool.Properties.Resources.删除;
            this.btnModleClear.Location = new System.Drawing.Point(513, 86);
            this.btnModleClear.Name = "btnModleClear";
            this.btnModleClear.Size = new System.Drawing.Size(20, 23);
            this.btnModleClear.TabIndex = 131;
            this.btnModleClear.Tag = "清除";
            this.btnModleClear.Click += new System.EventHandler(this.btnModleClear_Click);
            // 
            // btnFieldClear
            // 
            this.btnFieldClear.Image = ((System.Drawing.Image)(resources.GetObject("btnFieldClear.Image")));
            this.btnFieldClear.Location = new System.Drawing.Point(513, 139);
            this.btnFieldClear.Name = "btnFieldClear";
            this.btnFieldClear.Size = new System.Drawing.Size(20, 23);
            this.btnFieldClear.TabIndex = 130;
            this.btnFieldClear.Tag = "清除";
            this.btnFieldClear.Click += new System.EventHandler(this.btnFieldClear_Click);
            // 
            // btnTableClear
            // 
            this.btnTableClear.Image = ((System.Drawing.Image)(resources.GetObject("btnTableClear.Image")));
            this.btnTableClear.Location = new System.Drawing.Point(513, 115);
            this.btnTableClear.Name = "btnTableClear";
            this.btnTableClear.Size = new System.Drawing.Size(20, 23);
            this.btnTableClear.TabIndex = 129;
            this.btnTableClear.Tag = "清除";
            this.btnTableClear.Click += new System.EventHandler(this.btnTableClear_Click);
            // 
            // lvCommand
            // 
            this.lvCommand.FullRowSelect = true;
            this.lvCommand.Location = new System.Drawing.Point(15, 212);
            this.lvCommand.Name = "lvCommand";
            this.lvCommand.Size = new System.Drawing.Size(500, 237);
            this.lvCommand.SmallImageList = this.imgListSmall;
            this.lvCommand.TabIndex = 127;
            this.lvCommand.UseCompatibleStateImageBehavior = false;
            this.lvCommand.View = System.Windows.Forms.View.Details;
            this.lvCommand.DoubleClick += new System.EventHandler(this.btnModifycmd_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(76, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "模块名:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(39, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "可操作的字段:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxModleName
            // 
            this.tbxModleName.Location = new System.Drawing.Point(146, 86);
            this.tbxModleName.Name = "tbxModleName";
            this.tbxModleName.ReadOnly = true;
            this.tbxModleName.Size = new System.Drawing.Size(320, 21);
            this.tbxModleName.TabIndex = 12;
            // 
            // tbxFiledName
            // 
            this.tbxFiledName.Location = new System.Drawing.Point(146, 140);
            this.tbxFiledName.Name = "tbxFiledName";
            this.tbxFiledName.ReadOnly = true;
            this.tbxFiledName.Size = new System.Drawing.Size(320, 21);
            this.tbxFiledName.TabIndex = 12;
            // 
            // btnSelectModle
            // 
            this.btnSelectModle.Location = new System.Drawing.Point(472, 85);
            this.btnSelectModle.Name = "btnSelectModle";
            this.btnSelectModle.Size = new System.Drawing.Size(41, 23);
            this.btnSelectModle.TabIndex = 11;
            this.btnSelectModle.Text = "...";
            this.btnSelectModle.Click += new System.EventHandler(this.btnSelectModle_Click);
            // 
            // btnSelctField
            // 
            this.btnSelctField.Location = new System.Drawing.Point(472, 140);
            this.btnSelctField.Name = "btnSelctField";
            this.btnSelctField.Size = new System.Drawing.Size(41, 23);
            this.btnSelctField.TabIndex = 11;
            this.btnSelctField.Text = "...";
            this.btnSelctField.Click += new System.EventHandler(this.btnSelctField_Click);
            // 
            // tbxTaskName
            // 
            this.tbxTaskName.Location = new System.Drawing.Point(146, 35);
            this.tbxTaskName.Name = "tbxTaskName";
            this.tbxTaskName.Size = new System.Drawing.Size(320, 21);
            this.tbxTaskName.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(8, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(546, 520);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cbxRiZhi);
            this.tabPage4.Controls.Add(this.groupBox10);
            this.tabPage4.Controls.Add(this.groupBox11);
            this.tabPage4.Controls.Add(this.groupBox9);
            this.tabPage4.Controls.Add(this.groupBox8);
            this.tabPage4.Location = new System.Drawing.Point(4, 21);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(538, 495);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "日志功能";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cbxRiZhi
            // 
            this.cbxRiZhi.AutoSize = true;
            this.cbxRiZhi.Location = new System.Drawing.Point(10, 10);
            this.cbxRiZhi.Name = "cbxRiZhi";
            this.cbxRiZhi.Size = new System.Drawing.Size(72, 16);
            this.cbxRiZhi.TabIndex = 34;
            this.cbxRiZhi.Text = "开启日志";
            this.cbxRiZhi.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.cbxProjectDbTableColumns);
            this.groupBox10.Controls.Add(this.cbxProjectDbTable);
            this.groupBox10.Controls.Add(this.labelControl25);
            this.groupBox10.Controls.Add(this.labelControl26);
            this.groupBox10.Controls.Add(this.rbnProjectDatabase);
            this.groupBox10.Controls.Add(this.tetProjectFixValue);
            this.groupBox10.Controls.Add(this.tetProjectExcelName);
            this.groupBox10.Controls.Add(this.tetProjectPos);
            this.groupBox10.Controls.Add(this.labelControl12);
            this.groupBox10.Controls.Add(this.cbxProjectTableColumns);
            this.groupBox10.Controls.Add(this.cbxProjectDataTable);
            this.groupBox10.Controls.Add(this.labelControl11);
            this.groupBox10.Controls.Add(this.rbnProjectFixValue);
            this.groupBox10.Controls.Add(this.labelControl10);
            this.groupBox10.Controls.Add(this.labelControl9);
            this.groupBox10.Controls.Add(this.labelControl8);
            this.groupBox10.Controls.Add(this.rbnProjectExcel);
            this.groupBox10.Controls.Add(this.rbnProjectTable);
            this.groupBox10.Location = new System.Drawing.Point(9, 145);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(510, 103);
            this.groupBox10.TabIndex = 33;
            this.groupBox10.TabStop = false;
            // 
            // cbxProjectDbTableColumns
            // 
            this.cbxProjectDbTableColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProjectDbTableColumns.FormattingEnabled = true;
            this.cbxProjectDbTableColumns.Location = new System.Drawing.Point(409, 76);
            this.cbxProjectDbTableColumns.Name = "cbxProjectDbTableColumns";
            this.cbxProjectDbTableColumns.Size = new System.Drawing.Size(99, 20);
            this.cbxProjectDbTableColumns.TabIndex = 45;
            // 
            // cbxProjectDbTable
            // 
            this.cbxProjectDbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProjectDbTable.FormattingEnabled = true;
            this.cbxProjectDbTable.Location = new System.Drawing.Point(410, 54);
            this.cbxProjectDbTable.Name = "cbxProjectDbTable";
            this.cbxProjectDbTable.Size = new System.Drawing.Size(99, 20);
            this.cbxProjectDbTable.TabIndex = 46;
            this.cbxProjectDbTable.SelectedIndexChanged += new System.EventHandler(this.cbxProjectDbTable_SelectedIndexChanged);
            // 
            // labelControl25
            // 
            this.labelControl25.Location = new System.Drawing.Point(360, 78);
            this.labelControl25.Name = "labelControl25";
            this.labelControl25.Size = new System.Drawing.Size(36, 14);
            this.labelControl25.TabIndex = 43;
            this.labelControl25.Text = "字段：";
            // 
            // labelControl26
            // 
            this.labelControl26.Location = new System.Drawing.Point(361, 56);
            this.labelControl26.Name = "labelControl26";
            this.labelControl26.Size = new System.Drawing.Size(36, 14);
            this.labelControl26.TabIndex = 44;
            this.labelControl26.Text = "表名：";
            // 
            // rbnProjectDatabase
            // 
            this.rbnProjectDatabase.AutoSize = true;
            this.rbnProjectDatabase.Location = new System.Drawing.Point(359, 33);
            this.rbnProjectDatabase.Name = "rbnProjectDatabase";
            this.rbnProjectDatabase.Size = new System.Drawing.Size(83, 16);
            this.rbnProjectDatabase.TabIndex = 42;
            this.rbnProjectDatabase.Text = "从数据库取";
            this.rbnProjectDatabase.UseVisualStyleBackColor = true;
            // 
            // tetProjectFixValue
            // 
            this.tetProjectFixValue.Location = new System.Drawing.Point(157, 11);
            this.tetProjectFixValue.Name = "tetProjectFixValue";
            this.tetProjectFixValue.Size = new System.Drawing.Size(111, 21);
            this.tetProjectFixValue.TabIndex = 36;
            // 
            // tetProjectExcelName
            // 
            this.tetProjectExcelName.Location = new System.Drawing.Point(242, 51);
            this.tetProjectExcelName.Name = "tetProjectExcelName";
            this.tetProjectExcelName.Size = new System.Drawing.Size(110, 21);
            this.tetProjectExcelName.TabIndex = 36;
            // 
            // tetProjectPos
            // 
            this.tetProjectPos.Location = new System.Drawing.Point(242, 76);
            this.tetProjectPos.Name = "tetProjectPos";
            this.tetProjectPos.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tetProjectPos.Properties.Mask.EditMask = "([a-zA-Z]{1,2}\\d{1,3}[|])+";
            this.tetProjectPos.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.tetProjectPos.Size = new System.Drawing.Size(110, 21);
            this.tetProjectPos.TabIndex = 35;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(159, 79);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(72, 14);
            this.labelControl12.TabIndex = 34;
            this.labelControl12.Text = "单元格位置：";
            this.labelControl12.UseWaitCursor = true;
            // 
            // cbxProjectTableColumns
            // 
            this.cbxProjectTableColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProjectTableColumns.FormattingEnabled = true;
            this.cbxProjectTableColumns.Location = new System.Drawing.Point(50, 75);
            this.cbxProjectTableColumns.Name = "cbxProjectTableColumns";
            this.cbxProjectTableColumns.Size = new System.Drawing.Size(99, 20);
            this.cbxProjectTableColumns.TabIndex = 30;
            // 
            // cbxProjectDataTable
            // 
            this.cbxProjectDataTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProjectDataTable.FormattingEnabled = true;
            this.cbxProjectDataTable.Location = new System.Drawing.Point(51, 51);
            this.cbxProjectDataTable.Name = "cbxProjectDataTable";
            this.cbxProjectDataTable.Size = new System.Drawing.Size(99, 20);
            this.cbxProjectDataTable.TabIndex = 31;
            this.cbxProjectDataTable.SelectedIndexChanged += new System.EventHandler(this.cbxProjectDataTable_SelectedIndexChanged);
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(1, 77);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(36, 14);
            this.labelControl11.TabIndex = 27;
            this.labelControl11.Text = "字段：";
            // 
            // rbnProjectFixValue
            // 
            this.rbnProjectFixValue.AutoSize = true;
            this.rbnProjectFixValue.Checked = true;
            this.rbnProjectFixValue.Location = new System.Drawing.Point(72, 14);
            this.rbnProjectFixValue.Name = "rbnProjectFixValue";
            this.rbnProjectFixValue.Size = new System.Drawing.Size(59, 16);
            this.rbnProjectFixValue.TabIndex = 32;
            this.rbnProjectFixValue.TabStop = true;
            this.rbnProjectFixValue.Text = "固定值";
            this.rbnProjectFixValue.UseVisualStyleBackColor = true;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(170, 54);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(60, 14);
            this.labelControl10.TabIndex = 26;
            this.labelControl10.Text = "工作表名：";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(2, 53);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(36, 14);
            this.labelControl9.TabIndex = 29;
            this.labelControl9.Text = "表名：";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(6, 14);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(36, 14);
            this.labelControl8.TabIndex = 28;
            this.labelControl8.Text = "项目：";
            // 
            // rbnProjectExcel
            // 
            this.rbnProjectExcel.AutoSize = true;
            this.rbnProjectExcel.Location = new System.Drawing.Point(161, 36);
            this.rbnProjectExcel.Name = "rbnProjectExcel";
            this.rbnProjectExcel.Size = new System.Drawing.Size(77, 16);
            this.rbnProjectExcel.TabIndex = 24;
            this.rbnProjectExcel.Text = "从EXCEL取";
            this.rbnProjectExcel.UseVisualStyleBackColor = true;
            // 
            // rbnProjectTable
            // 
            this.rbnProjectTable.AutoSize = true;
            this.rbnProjectTable.Location = new System.Drawing.Point(6, 30);
            this.rbnProjectTable.Name = "rbnProjectTable";
            this.rbnProjectTable.Size = new System.Drawing.Size(71, 16);
            this.rbnProjectTable.TabIndex = 25;
            this.rbnProjectTable.Text = "从表单取";
            this.rbnProjectTable.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.cbxWorkDbTableColumns);
            this.groupBox11.Controls.Add(this.cbxWorkDbTable);
            this.groupBox11.Controls.Add(this.labelControl23);
            this.groupBox11.Controls.Add(this.labelControl24);
            this.groupBox11.Controls.Add(this.rbnWorkDatabase);
            this.groupBox11.Controls.Add(this.tetWorkFixValue);
            this.groupBox11.Controls.Add(this.tetWorkExcelName);
            this.groupBox11.Controls.Add(this.tetWorkPos);
            this.groupBox11.Controls.Add(this.labelControl7);
            this.groupBox11.Controls.Add(this.cbxWorkTableColumns);
            this.groupBox11.Controls.Add(this.cbxWorkDataTable);
            this.groupBox11.Controls.Add(this.labelControl5);
            this.groupBox11.Controls.Add(this.rbnWorkFixValue);
            this.groupBox11.Controls.Add(this.labelControl6);
            this.groupBox11.Controls.Add(this.labelControl3);
            this.groupBox11.Controls.Add(this.labelControl2);
            this.groupBox11.Controls.Add(this.rbnWorkExcel);
            this.groupBox11.Controls.Add(this.rbnWorkTable);
            this.groupBox11.Location = new System.Drawing.Point(9, 28);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(509, 111);
            this.groupBox11.TabIndex = 31;
            this.groupBox11.TabStop = false;
            // 
            // cbxWorkDbTableColumns
            // 
            this.cbxWorkDbTableColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkDbTableColumns.FormattingEnabled = true;
            this.cbxWorkDbTableColumns.Location = new System.Drawing.Point(405, 89);
            this.cbxWorkDbTableColumns.Name = "cbxWorkDbTableColumns";
            this.cbxWorkDbTableColumns.Size = new System.Drawing.Size(99, 20);
            this.cbxWorkDbTableColumns.TabIndex = 40;
            // 
            // cbxWorkDbTable
            // 
            this.cbxWorkDbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkDbTable.FormattingEnabled = true;
            this.cbxWorkDbTable.Location = new System.Drawing.Point(406, 65);
            this.cbxWorkDbTable.Name = "cbxWorkDbTable";
            this.cbxWorkDbTable.Size = new System.Drawing.Size(99, 20);
            this.cbxWorkDbTable.TabIndex = 41;
            this.cbxWorkDbTable.SelectedIndexChanged += new System.EventHandler(this.cbxWorkDbTable_SelectedIndexChanged);
            // 
            // labelControl23
            // 
            this.labelControl23.Location = new System.Drawing.Point(356, 91);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(36, 14);
            this.labelControl23.TabIndex = 38;
            this.labelControl23.Text = "字段：";
            // 
            // labelControl24
            // 
            this.labelControl24.Location = new System.Drawing.Point(357, 67);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(36, 14);
            this.labelControl24.TabIndex = 39;
            this.labelControl24.Text = "表名：";
            // 
            // rbnWorkDatabase
            // 
            this.rbnWorkDatabase.AutoSize = true;
            this.rbnWorkDatabase.Location = new System.Drawing.Point(355, 44);
            this.rbnWorkDatabase.Name = "rbnWorkDatabase";
            this.rbnWorkDatabase.Size = new System.Drawing.Size(83, 16);
            this.rbnWorkDatabase.TabIndex = 37;
            this.rbnWorkDatabase.Text = "从数据库取";
            this.rbnWorkDatabase.UseVisualStyleBackColor = true;
            // 
            // tetWorkFixValue
            // 
            this.tetWorkFixValue.Location = new System.Drawing.Point(157, 17);
            this.tetWorkFixValue.Name = "tetWorkFixValue";
            this.tetWorkFixValue.Size = new System.Drawing.Size(111, 21);
            this.tetWorkFixValue.TabIndex = 36;
            // 
            // tetWorkExcelName
            // 
            this.tetWorkExcelName.Location = new System.Drawing.Point(242, 63);
            this.tetWorkExcelName.Name = "tetWorkExcelName";
            this.tetWorkExcelName.Size = new System.Drawing.Size(110, 21);
            this.tetWorkExcelName.TabIndex = 36;
            // 
            // tetWorkPos
            // 
            this.tetWorkPos.Location = new System.Drawing.Point(242, 88);
            this.tetWorkPos.Name = "tetWorkPos";
            this.tetWorkPos.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tetWorkPos.Properties.Mask.EditMask = "([a-zA-Z]{1,2}\\d{1,3}[|])+";
            this.tetWorkPos.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.tetWorkPos.Size = new System.Drawing.Size(110, 21);
            this.tetWorkPos.TabIndex = 35;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(159, 91);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(72, 14);
            this.labelControl7.TabIndex = 34;
            this.labelControl7.Text = "单元格位置：";
            this.labelControl7.UseWaitCursor = true;
            // 
            // cbxWorkTableColumns
            // 
            this.cbxWorkTableColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkTableColumns.FormattingEnabled = true;
            this.cbxWorkTableColumns.Location = new System.Drawing.Point(55, 87);
            this.cbxWorkTableColumns.Name = "cbxWorkTableColumns";
            this.cbxWorkTableColumns.Size = new System.Drawing.Size(99, 20);
            this.cbxWorkTableColumns.TabIndex = 30;
            // 
            // cbxWorkDataTable
            // 
            this.cbxWorkDataTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkDataTable.FormattingEnabled = true;
            this.cbxWorkDataTable.Location = new System.Drawing.Point(56, 63);
            this.cbxWorkDataTable.Name = "cbxWorkDataTable";
            this.cbxWorkDataTable.Size = new System.Drawing.Size(99, 20);
            this.cbxWorkDataTable.TabIndex = 31;
            this.cbxWorkDataTable.SelectedIndexChanged += new System.EventHandler(this.cbxWorkDataTable_SelectedIndexChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(6, 89);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 27;
            this.labelControl5.Text = "字段：";
            // 
            // rbnWorkFixValue
            // 
            this.rbnWorkFixValue.AutoSize = true;
            this.rbnWorkFixValue.Checked = true;
            this.rbnWorkFixValue.Location = new System.Drawing.Point(71, 20);
            this.rbnWorkFixValue.Name = "rbnWorkFixValue";
            this.rbnWorkFixValue.Size = new System.Drawing.Size(59, 16);
            this.rbnWorkFixValue.TabIndex = 32;
            this.rbnWorkFixValue.TabStop = true;
            this.rbnWorkFixValue.Text = "固定值";
            this.rbnWorkFixValue.UseVisualStyleBackColor = true;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(170, 66);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 14);
            this.labelControl6.TabIndex = 26;
            this.labelControl6.Text = "工作表名：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(7, 65);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "表名：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 20);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 28;
            this.labelControl2.Text = "工作地址：";
            // 
            // rbnWorkExcel
            // 
            this.rbnWorkExcel.AutoSize = true;
            this.rbnWorkExcel.Location = new System.Drawing.Point(158, 44);
            this.rbnWorkExcel.Name = "rbnWorkExcel";
            this.rbnWorkExcel.Size = new System.Drawing.Size(77, 16);
            this.rbnWorkExcel.TabIndex = 24;
            this.rbnWorkExcel.Text = "从EXCEL取";
            this.rbnWorkExcel.UseVisualStyleBackColor = true;
            // 
            // rbnWorkTable
            // 
            this.rbnWorkTable.AutoSize = true;
            this.rbnWorkTable.Location = new System.Drawing.Point(5, 42);
            this.rbnWorkTable.Name = "rbnWorkTable";
            this.rbnWorkTable.Size = new System.Drawing.Size(71, 16);
            this.rbnWorkTable.TabIndex = 25;
            this.rbnWorkTable.Text = "从表单取";
            this.rbnWorkTable.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.cbxCharManDbTableColumns);
            this.groupBox9.Controls.Add(this.cbxCharManDbTable);
            this.groupBox9.Controls.Add(this.labelControl27);
            this.groupBox9.Controls.Add(this.labelControl28);
            this.groupBox9.Controls.Add(this.rbnCharManDatabase);
            this.groupBox9.Controls.Add(this.tetCharManFixValue);
            this.groupBox9.Controls.Add(this.tetCharManExcelName);
            this.groupBox9.Controls.Add(this.tetCharManPos);
            this.groupBox9.Controls.Add(this.labelControl17);
            this.groupBox9.Controls.Add(this.cbxCharManTableColumns);
            this.groupBox9.Controls.Add(this.cbxCharManDataTable);
            this.groupBox9.Controls.Add(this.labelControl16);
            this.groupBox9.Controls.Add(this.rbnCharManFixValue);
            this.groupBox9.Controls.Add(this.labelControl15);
            this.groupBox9.Controls.Add(this.labelControl14);
            this.groupBox9.Controls.Add(this.labelControl13);
            this.groupBox9.Controls.Add(this.rbnCharManExcel);
            this.groupBox9.Controls.Add(this.rbnCharManTable);
            this.groupBox9.Location = new System.Drawing.Point(11, 260);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(509, 105);
            this.groupBox9.TabIndex = 30;
            this.groupBox9.TabStop = false;
            // 
            // cbxCharManDbTableColumns
            // 
            this.cbxCharManDbTableColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCharManDbTableColumns.FormattingEnabled = true;
            this.cbxCharManDbTableColumns.Location = new System.Drawing.Point(405, 77);
            this.cbxCharManDbTableColumns.Name = "cbxCharManDbTableColumns";
            this.cbxCharManDbTableColumns.Size = new System.Drawing.Size(99, 20);
            this.cbxCharManDbTableColumns.TabIndex = 50;
            // 
            // cbxCharManDbTable
            // 
            this.cbxCharManDbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCharManDbTable.FormattingEnabled = true;
            this.cbxCharManDbTable.Location = new System.Drawing.Point(406, 55);
            this.cbxCharManDbTable.Name = "cbxCharManDbTable";
            this.cbxCharManDbTable.Size = new System.Drawing.Size(99, 20);
            this.cbxCharManDbTable.TabIndex = 51;
            this.cbxCharManDbTable.SelectedIndexChanged += new System.EventHandler(this.cbxCharManDbTable_SelectedIndexChanged);
            // 
            // labelControl27
            // 
            this.labelControl27.Location = new System.Drawing.Point(356, 79);
            this.labelControl27.Name = "labelControl27";
            this.labelControl27.Size = new System.Drawing.Size(36, 14);
            this.labelControl27.TabIndex = 48;
            this.labelControl27.Text = "字段：";
            // 
            // labelControl28
            // 
            this.labelControl28.Location = new System.Drawing.Point(357, 57);
            this.labelControl28.Name = "labelControl28";
            this.labelControl28.Size = new System.Drawing.Size(36, 14);
            this.labelControl28.TabIndex = 49;
            this.labelControl28.Text = "表名：";
            // 
            // rbnCharManDatabase
            // 
            this.rbnCharManDatabase.AutoSize = true;
            this.rbnCharManDatabase.Location = new System.Drawing.Point(355, 34);
            this.rbnCharManDatabase.Name = "rbnCharManDatabase";
            this.rbnCharManDatabase.Size = new System.Drawing.Size(83, 16);
            this.rbnCharManDatabase.TabIndex = 47;
            this.rbnCharManDatabase.Text = "从数据库取";
            this.rbnCharManDatabase.UseVisualStyleBackColor = true;
            // 
            // tetCharManFixValue
            // 
            this.tetCharManFixValue.Location = new System.Drawing.Point(155, 12);
            this.tetCharManFixValue.Name = "tetCharManFixValue";
            this.tetCharManFixValue.Size = new System.Drawing.Size(111, 21);
            this.tetCharManFixValue.TabIndex = 36;
            // 
            // tetCharManExcelName
            // 
            this.tetCharManExcelName.Location = new System.Drawing.Point(242, 52);
            this.tetCharManExcelName.Name = "tetCharManExcelName";
            this.tetCharManExcelName.Size = new System.Drawing.Size(110, 21);
            this.tetCharManExcelName.TabIndex = 36;
            // 
            // tetCharManPos
            // 
            this.tetCharManPos.Location = new System.Drawing.Point(242, 77);
            this.tetCharManPos.Name = "tetCharManPos";
            this.tetCharManPos.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tetCharManPos.Properties.Mask.EditMask = "([a-zA-Z]{1,2}\\d{1,3}[|])+";
            this.tetCharManPos.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.tetCharManPos.Size = new System.Drawing.Size(110, 21);
            this.tetCharManPos.TabIndex = 35;
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(159, 80);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(72, 14);
            this.labelControl17.TabIndex = 34;
            this.labelControl17.Text = "单元格位置：";
            this.labelControl17.UseWaitCursor = true;
            // 
            // cbxCharManTableColumns
            // 
            this.cbxCharManTableColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCharManTableColumns.FormattingEnabled = true;
            this.cbxCharManTableColumns.Location = new System.Drawing.Point(52, 79);
            this.cbxCharManTableColumns.Name = "cbxCharManTableColumns";
            this.cbxCharManTableColumns.Size = new System.Drawing.Size(99, 20);
            this.cbxCharManTableColumns.TabIndex = 30;
            // 
            // cbxCharManDataTable
            // 
            this.cbxCharManDataTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCharManDataTable.FormattingEnabled = true;
            this.cbxCharManDataTable.Location = new System.Drawing.Point(52, 52);
            this.cbxCharManDataTable.Name = "cbxCharManDataTable";
            this.cbxCharManDataTable.Size = new System.Drawing.Size(99, 20);
            this.cbxCharManDataTable.TabIndex = 31;
            this.cbxCharManDataTable.SelectedIndexChanged += new System.EventHandler(this.cbxCharManDataTable_SelectedIndexChanged);
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(2, 78);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(36, 14);
            this.labelControl16.TabIndex = 27;
            this.labelControl16.Text = "字段：";
            // 
            // rbnCharManFixValue
            // 
            this.rbnCharManFixValue.AutoSize = true;
            this.rbnCharManFixValue.Checked = true;
            this.rbnCharManFixValue.Location = new System.Drawing.Point(84, 14);
            this.rbnCharManFixValue.Name = "rbnCharManFixValue";
            this.rbnCharManFixValue.Size = new System.Drawing.Size(59, 16);
            this.rbnCharManFixValue.TabIndex = 32;
            this.rbnCharManFixValue.TabStop = true;
            this.rbnCharManFixValue.Text = "固定值";
            this.rbnCharManFixValue.UseVisualStyleBackColor = true;
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(169, 55);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(60, 14);
            this.labelControl15.TabIndex = 26;
            this.labelControl15.Text = "工作表名：";
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(3, 54);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(36, 14);
            this.labelControl14.TabIndex = 29;
            this.labelControl14.Text = "表名：";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(9, 15);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(72, 14);
            this.labelControl13.TabIndex = 28;
            this.labelControl13.Text = "工作负责人：";
            // 
            // rbnCharManExcel
            // 
            this.rbnCharManExcel.AutoSize = true;
            this.rbnCharManExcel.Location = new System.Drawing.Point(156, 34);
            this.rbnCharManExcel.Name = "rbnCharManExcel";
            this.rbnCharManExcel.Size = new System.Drawing.Size(77, 16);
            this.rbnCharManExcel.TabIndex = 24;
            this.rbnCharManExcel.Text = "从EXCEL取";
            this.rbnCharManExcel.UseVisualStyleBackColor = true;
            // 
            // rbnCharManTable
            // 
            this.rbnCharManTable.AutoSize = true;
            this.rbnCharManTable.Location = new System.Drawing.Point(9, 33);
            this.rbnCharManTable.Name = "rbnCharManTable";
            this.rbnCharManTable.Size = new System.Drawing.Size(71, 16);
            this.rbnCharManTable.TabIndex = 25;
            this.rbnCharManTable.Text = "从表单取";
            this.rbnCharManTable.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cbxAttendManDbTableColumns);
            this.groupBox8.Controls.Add(this.tetAttendManFixValue);
            this.groupBox8.Controls.Add(this.cbxAttendManDbTable);
            this.groupBox8.Controls.Add(this.labelControl30);
            this.groupBox8.Controls.Add(this.tetAttendManExcelName);
            this.groupBox8.Controls.Add(this.labelControl29);
            this.groupBox8.Controls.Add(this.tetAttendManPos);
            this.groupBox8.Controls.Add(this.rbnAttendManDatabase);
            this.groupBox8.Controls.Add(this.labelControl22);
            this.groupBox8.Controls.Add(this.cbxAttendManTableColumns);
            this.groupBox8.Controls.Add(this.cbxAttendManDataTable);
            this.groupBox8.Controls.Add(this.labelControl21);
            this.groupBox8.Controls.Add(this.rbnAttendManFixValue);
            this.groupBox8.Controls.Add(this.labelControl20);
            this.groupBox8.Controls.Add(this.labelControl19);
            this.groupBox8.Controls.Add(this.labelControl18);
            this.groupBox8.Controls.Add(this.rbnAttendManExcel);
            this.groupBox8.Controls.Add(this.rbnAttendManTable);
            this.groupBox8.Location = new System.Drawing.Point(8, 371);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(524, 118);
            this.groupBox8.TabIndex = 29;
            this.groupBox8.TabStop = false;
            // 
            // cbxAttendManDbTableColumns
            // 
            this.cbxAttendManDbTableColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAttendManDbTableColumns.FormattingEnabled = true;
            this.cbxAttendManDbTableColumns.Location = new System.Drawing.Point(415, 86);
            this.cbxAttendManDbTableColumns.Name = "cbxAttendManDbTableColumns";
            this.cbxAttendManDbTableColumns.Size = new System.Drawing.Size(99, 20);
            this.cbxAttendManDbTableColumns.TabIndex = 50;
            // 
            // tetAttendManFixValue
            // 
            this.tetAttendManFixValue.Location = new System.Drawing.Point(157, 17);
            this.tetAttendManFixValue.Name = "tetAttendManFixValue";
            this.tetAttendManFixValue.Size = new System.Drawing.Size(111, 21);
            this.tetAttendManFixValue.TabIndex = 36;
            // 
            // cbxAttendManDbTable
            // 
            this.cbxAttendManDbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAttendManDbTable.FormattingEnabled = true;
            this.cbxAttendManDbTable.Location = new System.Drawing.Point(416, 64);
            this.cbxAttendManDbTable.Name = "cbxAttendManDbTable";
            this.cbxAttendManDbTable.Size = new System.Drawing.Size(99, 20);
            this.cbxAttendManDbTable.TabIndex = 51;
            this.cbxAttendManDbTable.SelectedIndexChanged += new System.EventHandler(this.cbxAttendManDbTable_SelectedIndexChanged);
            // 
            // labelControl30
            // 
            this.labelControl30.Location = new System.Drawing.Point(366, 88);
            this.labelControl30.Name = "labelControl30";
            this.labelControl30.Size = new System.Drawing.Size(36, 14);
            this.labelControl30.TabIndex = 48;
            this.labelControl30.Text = "字段：";
            // 
            // tetAttendManExcelName
            // 
            this.tetAttendManExcelName.Location = new System.Drawing.Point(253, 60);
            this.tetAttendManExcelName.Name = "tetAttendManExcelName";
            this.tetAttendManExcelName.Size = new System.Drawing.Size(110, 21);
            this.tetAttendManExcelName.TabIndex = 36;
            // 
            // labelControl29
            // 
            this.labelControl29.Location = new System.Drawing.Point(367, 66);
            this.labelControl29.Name = "labelControl29";
            this.labelControl29.Size = new System.Drawing.Size(36, 14);
            this.labelControl29.TabIndex = 49;
            this.labelControl29.Text = "表名：";
            // 
            // tetAttendManPos
            // 
            this.tetAttendManPos.Location = new System.Drawing.Point(253, 86);
            this.tetAttendManPos.Name = "tetAttendManPos";
            this.tetAttendManPos.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tetAttendManPos.Properties.Mask.EditMask = "([a-zA-Z]{1,2}\\d{1,3}[|])+";
            this.tetAttendManPos.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.tetAttendManPos.Size = new System.Drawing.Size(110, 21);
            this.tetAttendManPos.TabIndex = 35;
            // 
            // rbnAttendManDatabase
            // 
            this.rbnAttendManDatabase.AutoSize = true;
            this.rbnAttendManDatabase.Location = new System.Drawing.Point(367, 43);
            this.rbnAttendManDatabase.Name = "rbnAttendManDatabase";
            this.rbnAttendManDatabase.Size = new System.Drawing.Size(83, 16);
            this.rbnAttendManDatabase.TabIndex = 47;
            this.rbnAttendManDatabase.Text = "从数据库取";
            this.rbnAttendManDatabase.UseVisualStyleBackColor = true;
            // 
            // labelControl22
            // 
            this.labelControl22.Location = new System.Drawing.Point(170, 89);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(72, 14);
            this.labelControl22.TabIndex = 34;
            this.labelControl22.Text = "单元格位置：";
            this.labelControl22.UseWaitCursor = true;
            // 
            // cbxAttendManTableColumns
            // 
            this.cbxAttendManTableColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAttendManTableColumns.FormattingEnabled = true;
            this.cbxAttendManTableColumns.Location = new System.Drawing.Point(58, 85);
            this.cbxAttendManTableColumns.Name = "cbxAttendManTableColumns";
            this.cbxAttendManTableColumns.Size = new System.Drawing.Size(99, 20);
            this.cbxAttendManTableColumns.TabIndex = 30;
            // 
            // cbxAttendManDataTable
            // 
            this.cbxAttendManDataTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAttendManDataTable.FormattingEnabled = true;
            this.cbxAttendManDataTable.Location = new System.Drawing.Point(59, 61);
            this.cbxAttendManDataTable.Name = "cbxAttendManDataTable";
            this.cbxAttendManDataTable.Size = new System.Drawing.Size(99, 20);
            this.cbxAttendManDataTable.TabIndex = 31;
            this.cbxAttendManDataTable.SelectedIndexChanged += new System.EventHandler(this.cbxAttendManDataTable_SelectedIndexChanged);
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(9, 87);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(36, 14);
            this.labelControl21.TabIndex = 27;
            this.labelControl21.Text = "字段：";
            // 
            // rbnAttendManFixValue
            // 
            this.rbnAttendManFixValue.AutoSize = true;
            this.rbnAttendManFixValue.Checked = true;
            this.rbnAttendManFixValue.Location = new System.Drawing.Point(74, 20);
            this.rbnAttendManFixValue.Name = "rbnAttendManFixValue";
            this.rbnAttendManFixValue.Size = new System.Drawing.Size(59, 16);
            this.rbnAttendManFixValue.TabIndex = 32;
            this.rbnAttendManFixValue.TabStop = true;
            this.rbnAttendManFixValue.Text = "固定值";
            this.rbnAttendManFixValue.UseVisualStyleBackColor = true;
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(181, 64);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(60, 14);
            this.labelControl20.TabIndex = 26;
            this.labelControl20.Text = "工作表名：";
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(10, 63);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(36, 14);
            this.labelControl19.TabIndex = 29;
            this.labelControl19.Text = "表名：";
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(11, 20);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(60, 14);
            this.labelControl18.TabIndex = 28;
            this.labelControl18.Text = "参加人员：";
            // 
            // rbnAttendManExcel
            // 
            this.rbnAttendManExcel.AutoSize = true;
            this.rbnAttendManExcel.Location = new System.Drawing.Point(171, 41);
            this.rbnAttendManExcel.Name = "rbnAttendManExcel";
            this.rbnAttendManExcel.Size = new System.Drawing.Size(77, 16);
            this.rbnAttendManExcel.TabIndex = 24;
            this.rbnAttendManExcel.Text = "从EXCEL取";
            this.rbnAttendManExcel.UseVisualStyleBackColor = true;
            // 
            // rbnAttendManTable
            // 
            this.rbnAttendManTable.AutoSize = true;
            this.rbnAttendManTable.Location = new System.Drawing.Point(9, 40);
            this.rbnAttendManTable.Name = "rbnAttendManTable";
            this.rbnAttendManTable.Size = new System.Drawing.Size(71, 16);
            this.rbnAttendManTable.TabIndex = 25;
            this.rbnAttendManTable.Text = "从表单取";
            this.rbnAttendManTable.UseVisualStyleBackColor = true;
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
            this.ClientSize = new System.Drawing.Size(557, 583);
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
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tetProjectFixValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetProjectExcelName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetProjectPos.Properties)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkFixValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkExcelName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkPos.Properties)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tetCharManFixValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetCharManExcelName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetCharManPos.Properties)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tetAttendManFixValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetAttendManExcelName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetAttendManPos.Properties)).EndInit();
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
            //*********控制权限
            DataTable powerTable = WorkFlowTask.GetTaskPower(NowTask.WorkFlowId, NowTask.TaskId);
            string powerStr = "";
            foreach (DataRow dr in powerTable.Rows)
            {
                powerStr = powerStr + dr["PowerName"].ToString() + ",";
            }
            cbxRiZhi.Checked = powerStr.IndexOf(WorkConst.WorkTask_WorkRiZhi) > -1;//工作日志
            //模块
            DataTable modleTable = WorkFlowTask.GetTaskModle(NowTask.TaskId);
            if (modleTable != null && modleTable.Rows.Count > 0)
            {
                tbxModleName.Text = modleTable.Rows[0]["ModuName"].ToString();
                UserModleId = modleTable.Rows[0]["Modu_ID"].ToString();
                mModule obj = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(UserModleId);
                object fromCtrl = CreatNewMoldeIns(obj.AssemblyFileName, obj.ModuTypes, obj.MethodName, obj.ModuName);

                if (fromCtrl.GetType().GetProperty("VarDbTableName") != null && fromCtrl.GetType().GetProperty("VarDbTableName").GetValue(fromCtrl, null) != null)
                    varDbTableName = fromCtrl.GetType().GetProperty("VarDbTableName").GetValue(fromCtrl, null).ToString();
               
            }
            //表单
            DataTable ctrlTable = WorkFlowTask.GetTaskControls(NowTask.TaskId);
            if (ctrlTable!=null &&ctrlTable.Rows.Count>0)
            {
                tbxFormName.Text = ctrlTable.Rows[0]["CellName"].ToString();
                UserControlId = ctrlTable.Rows[0]["LPID"].ToString();
            }
            //可操作字段
            if(UserControlId!="节点审核")
            {
                IList<WF_TableUsedField> ulist = MainHelper.PlatformSqlMap.GetList<WF_TableUsedField>("SelectWF_TableUsedFieldList", "where UserControlId ='" + UserControlId + "' and WorktaskId='" + NowTask.TaskId + "' and WorkflowId='" + NowTask.WorkFlowId + "'");
                for (int i = 0; i < ulist.Count; i++)
                {
                    if (tbxFiledName.Text == "")
                    {
                        tbxFiledName.Text = ulist[i].FieldName;
                    }
                    else
                    {
                        tbxFiledName.Text += "," + ulist[i].FieldName;

                    }

                }
            }
            else
            {
                label2.Text = "处理(任务命令可用代码{01：提交文件模块，02：手动结束}):";
                tbxFiledName.Text = "不可用";
                tbxFiledName.Tag = null;
                btnSelectCtrls.Enabled = false;
                btnSelctField.Enabled = false;
            }

            //*********日志控制
            iniRiZhiData();
        }
        public static object CreatNewMoldeIns(string assemblyFileName, string moduTypes, string methodName, string moduName)
        {
            object fromCtrl;
            Assembly assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + assemblyFileName);
            Type tp = assembly.GetType(moduTypes);
            if (methodName == "")////窗体的构造函数不需要参数
                fromCtrl = Activator.CreateInstance(tp);
            else//窗体的构造函数需要参数
                fromCtrl = Activator.CreateInstance(tp, methodName);
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
            return fromCtrl;
        }
        private void iniRiZhiTablelcbxData(ComboBox cbxtable, ComboBox cbxtablefield, string taskID, string tableID, string fieldID)
        {
            //string tmpStr = " where ParentID not in (select LPID from LP_Temple where 1=1) ";

            //IList li = MainHelper.PlatformSqlMap.GetList("SelectLP_TempleList", tmpStr);
            //DataTable dt = ConvertHelper.ToDataTable(li);
            DataTable dt = null;
            IList li;
            if (UserControlId != "" && UserControlId != "节点审核")
            {
                if (dt == null)
                {
                    dt = new DataTable();
                    dt.Columns.Add("LPID", typeof(string));
                    dt.Columns.Add("CellName", typeof(string));
                }

                DataRow dr = dt.NewRow();
                dr["LPID"] = UserControlId;
                dr["CellName"] = tbxFormName.Text;
                dt.Rows.Add(dr);
            }
            else
            {
                dt = new DataTable();
            }
            WinFormFun.LoadComboBox(cbxtable, dt, "LPID", "CellName", tableID);
            if (tableID != "")
            {

                li = MainHelper.PlatformSqlMap.GetList("SelectWF_TableUsedFieldList", "where UserControlId ='" + tableID + "' and WorktaskId='" + taskID + "'");
                DataTable dtrow = null;
                if (li.Count > 0)
                    dtrow = ConvertHelper.ToDataTable(li);
                else
                    dtrow = new DataTable();
                WinFormFun.LoadComboBox(cbxtablefield, dtrow, "FieldId", "FieldName", fieldID);
            }
            else
            {
                DataTable dtrow = new DataTable();
                WinFormFun.LoadComboBox(cbxtablefield, dtrow, "FieldId", "FieldName", fieldID);
            }
        }
        private void iniRiZhiDbcbxData(ComboBox cbxtable, ComboBox cbxtablefield, string varDbTableName, string tablename, string fieldID)
        {
            // IList li = MainHelper.PlatformSqlMap.GetList("GetTableName", "  where type = 'U' and  1=1 ");
            DataTable dt = null;
            IList li;
            if (varDbTableName != "")
            {
                string[] strname = varDbTableName.Split(',');
                if (dt == null)
                {
                    dt = new DataTable();
                    dt.Columns.Add("name", typeof(string));
                }
                for (int i = 0; i < strname.Length; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["name"] = strname[i];
                    dt.Rows.Add(dr);
                }
            }
            else
            {
                //li = MainHelper.PlatformSqlMap.GetList("GetTableName", "  where type = 'U' and  1=1 ");
                //dt = ConvertHelper.ToDataTable(li);
                dt = new DataTable();
            }


            WinFormFun.LoadComboBox(cbxtable, dt, "name", "name", tablename);
            if (tablename != "")
            {
                li = MainHelper.PlatformSqlMap.GetList("GetTableColumns", tablename);
                DataTable dtrow = null;
                if (li.Count > 0)
                    dtrow = ConvertHelper.ToDataTable(li);
                else
                    dtrow = new DataTable();
                WinFormFun.LoadComboBox(cbxtablefield, dtrow, "name", "name", fieldID);
            }
            else
            {
                DataTable dtrow = new DataTable();
                WinFormFun.LoadComboBox(cbxtablefield, dtrow, "name", "name", fieldID);
            }

        }
        private void iniRiZhiData()
        {
            WF_TaskVar tv = WorkFlowTask.GetTaskRiZhiVar(NowTask.TaskId, "工作地点");
            if (tv != null)
            {
                if (tv.VarModule == "固定值")
                {
                    rbnWorkFixValue.Checked = true;
                    tetWorkFixValue.Text = tv.InitValue;
                    iniRiZhiTablelcbxData(cbxWorkDataTable, cbxWorkTableColumns, NowTask.TaskId, UserControlId, "");
                    iniRiZhiDbcbxData(cbxWorkDbTable, cbxWorkDbTableColumns, varDbTableName, "", "");
                }
                else if (tv.VarModule == "表单")
                {
                    rbnWorkTable.Checked = true;
                    iniRiZhiTablelcbxData(cbxWorkDataTable, cbxWorkTableColumns, NowTask.TaskId, tv.TableName, tv.TableField);
                    iniRiZhiDbcbxData(cbxWorkDbTable, cbxWorkDbTableColumns, varDbTableName, "", "");
                }
                else if (tv.VarModule == "Excel")
                {
                    rbnWorkExcel.Checked = true;
                    tetWorkExcelName.Text = tv.TableName;
                    tetWorkPos.Text = tv.TableField;
                }
                else if (tv.VarModule == "数据库")
                {
                    rbnWorkDatabase.Checked = true;
                    cbxWorkDbTable.Text = tv.TableName;
                    cbxWorkDbTableColumns.Text = tv.TableField;
                    iniRiZhiDbcbxData(cbxWorkDbTable, cbxWorkDbTableColumns, varDbTableName, tv.TableName, tv.TableField);
                    iniRiZhiTablelcbxData(cbxWorkDataTable, cbxWorkTableColumns, NowTask.TaskId, UserControlId, "");
                }
            }
            else
            {

                iniRiZhiTablelcbxData(cbxWorkDataTable, cbxWorkTableColumns, NowTask.TaskId, UserControlId, "");
                iniRiZhiDbcbxData(cbxWorkDbTable, cbxWorkDbTableColumns, varDbTableName, "", "");
            }
            tv = WorkFlowTask.GetTaskRiZhiVar(NowTask.TaskId, "项目");
            if (tv != null)
            {
                if (tv.VarModule == "固定值")
                {
                    rbnProjectFixValue.Checked = true;
                    tetProjectFixValue.Text = tv.InitValue;

                    iniRiZhiTablelcbxData(cbxProjectDataTable, cbxProjectTableColumns, NowTask.TaskId, UserControlId, "");
                    iniRiZhiDbcbxData(cbxProjectDbTable, cbxProjectDbTableColumns, varDbTableName, "", "");
                }
                else if (tv.VarModule == "表单")
                {
                    rbnProjectTable.Checked = true;
                    iniRiZhiTablelcbxData(cbxProjectDataTable, cbxProjectTableColumns, NowTask.TaskId, tv.TableName, tv.TableField);
                    iniRiZhiDbcbxData(cbxProjectDbTable, cbxProjectDbTableColumns, varDbTableName, "", "");
                }
                else if (tv.VarModule == "Excel")
                {
                    rbnProjectExcel.Checked = true;
                    tetProjectExcelName.Text = tv.TableName;
                    tetProjectPos.Text = tv.TableField;
                }
                else if (tv.VarModule == "数据库")
                {

                    rbnProjectDatabase.Checked = true;
                    iniRiZhiDbcbxData(cbxProjectDbTable, cbxProjectDbTableColumns, varDbTableName, tv.TableName, tv.TableField);
                    iniRiZhiTablelcbxData(cbxProjectDataTable, cbxProjectTableColumns, NowTask.TaskId, UserControlId, "");
                }
            }
            else
            {

                iniRiZhiTablelcbxData(cbxProjectDataTable, cbxProjectTableColumns, NowTask.TaskId, UserControlId, "");
                iniRiZhiDbcbxData(cbxProjectDbTable, cbxProjectDbTableColumns, varDbTableName, "", "");
            }
            tv = WorkFlowTask.GetTaskRiZhiVar(NowTask.TaskId, "负责人");
            if (tv != null)
            {
                if (tv.VarModule == "固定值")
                {
                    rbnCharManFixValue.Checked = true;
                    tetCharManFixValue.Text = tv.InitValue;
                    iniRiZhiTablelcbxData(cbxCharManDataTable, cbxCharManTableColumns, NowTask.TaskId, UserControlId, "");
                    iniRiZhiDbcbxData(cbxCharManDbTable, cbxCharManDbTableColumns, varDbTableName, "", "");
                }
                else if (tv.VarModule == "表单")
                {
                    rbnCharManTable.Checked = true;
                    iniRiZhiTablelcbxData(cbxCharManDataTable, cbxCharManTableColumns, NowTask.TaskId, tv.TableName, tv.TableField);
                    iniRiZhiDbcbxData(cbxCharManDbTable, cbxCharManDbTableColumns, varDbTableName, "", "");
                }
                else if (tv.VarModule == "Excel")
                {
                    rbnCharManExcel.Checked = true;
                    tetCharManExcelName.Text = tv.TableName;
                    tetCharManPos.Text = tv.TableField;
                }
                else if (tv.VarModule == "数据库")
                {

                    rbnCharManDatabase.Checked = true;
                    iniRiZhiDbcbxData(cbxCharManDbTable, cbxCharManDbTableColumns, varDbTableName, tv.TableName, tv.TableField);
                    iniRiZhiTablelcbxData(cbxCharManDataTable, cbxCharManTableColumns, NowTask.TaskId, UserControlId, "");
                }
            }
            else
            {
                iniRiZhiTablelcbxData(cbxCharManDataTable, cbxCharManTableColumns, NowTask.TaskId, UserControlId, "");
                iniRiZhiDbcbxData(cbxCharManDbTable, cbxCharManDbTableColumns, varDbTableName, "", "");
            }
            tv = WorkFlowTask.GetTaskRiZhiVar(NowTask.TaskId, "参加人员");
            if (tv != null)
            {
                if (tv.VarModule == "固定值")
                {
                    rbnAttendManFixValue.Checked = true;
                    tetAttendManFixValue.Text = tv.InitValue;
                    iniRiZhiTablelcbxData(cbxAttendManDataTable, cbxAttendManTableColumns, NowTask.TaskId, UserControlId, "");
                    iniRiZhiDbcbxData(cbxAttendManDbTable, cbxAttendManDbTableColumns, varDbTableName, "", "");
                }
                else if (tv.VarModule == "表单")
                {
                    rbnAttendManTable.Checked = true;
                    iniRiZhiTablelcbxData(cbxAttendManDataTable, cbxAttendManTableColumns, NowTask.TaskId, tv.TableName, tv.TableField);
                    iniRiZhiDbcbxData(cbxAttendManDbTable, cbxAttendManDbTableColumns, varDbTableName, "", "");

                }
                else if (tv.VarModule == "Excel")
                {
                    rbnAttendManExcel.Checked = true;
                    tetAttendManExcelName.Text = tv.TableName;
                    tetAttendManPos.Text = tv.TableField;
                }
                else if (tv.VarModule == "数据库")
                {

                    rbnAttendManDatabase.Checked = true;
                    iniRiZhiDbcbxData(cbxAttendManDbTable, cbxAttendManDbTableColumns, varDbTableName, tv.TableName, tv.TableField);
                    iniRiZhiDbcbxData(cbxAttendManDbTable, cbxAttendManDbTableColumns, varDbTableName, "", "");
                }
            }
            else
            {

                iniRiZhiTablelcbxData(cbxAttendManDataTable, cbxAttendManTableColumns, NowTask.TaskId, UserControlId, "");
                iniRiZhiDbcbxData(cbxAttendManDbTable, cbxAttendManDbTableColumns, varDbTableName, "", "");
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

            //保存控制权限
            WorkFlowTask.DeleteAllPower(NowTask.WorkFlowId, NowTask.TaskId);
           
            if (cbxRiZhi.Checked)
            {
                WorkFlowTask.SetTaskPower(WorkConst.WorkTask_WorkRiZhi, NowTask.WorkFlowId, NowTask.TaskId);
                SaveRiZhiData();
            }
            //保存关联表单
            WorkFlowTask.DeleteAllControls(NowTask.TaskId);
            if (UserControlId != "") WorkFlowTask.SetTaskUserCtrls(UserControlId, NowTask.WorkFlowId, NowTask.TaskId);
            //保存关联模块
            WorkFlowTask.DeleteAllModle(NowTask.TaskId);
            if (UserModleId != "") WorkFlowTask.SetTaskUserModle(UserModleId, NowTask.WorkFlowId, NowTask.TaskId);
 
        }
        private void SaveRiZhiData()
        {
            TaskVar tv = new TaskVar();
            tv.WorkFlowId = NowTask.WorkFlowId;
            tv.WorkTaskId = NowTask.TaskId;
            tv.VarName = "工作地点";
            tv.AccessType = WorkConst.WorkTask_WorkRiZhi;
            if (rbnWorkFixValue.Checked == true)
            {
                tv.VarModule = "固定值";
                tv.InitValue = tetWorkFixValue.Text;
            }
            else if (rbnWorkTable.Checked == true)
            {
                tv.VarModule = "表单";
                tv.TableName = ((ListItem)cbxWorkDataTable.SelectedItem).ID;
                tv.TableField = ((ListItem)cbxWorkTableColumns.SelectedItem).ID;
            }
            else if (rbnWorkExcel.Checked == true)
            {

                tv.VarModule = "Excel";
                tv.TableName = tetWorkExcelName.Text;
                tv.TableField = tetWorkPos.Text;
            }
            else if (rbnWorkDatabase.Checked == true)
            {

                tv.VarModule = "数据库";
                tv.TableName = ((ListItem)cbxWorkDbTable.SelectedItem).ID;
                tv.TableField = ((ListItem)cbxWorkDbTableColumns.SelectedItem).ID;
            }
            tv.InsertTaskVar();
            tv = new TaskVar();
            tv.WorkFlowId = NowTask.WorkFlowId;
            tv.WorkTaskId = NowTask.TaskId;
            tv.VarName = "项目";
            tv.AccessType = WorkConst.WorkTask_WorkRiZhi;
            if (tv != null)
            {
                if (rbnProjectFixValue.Checked == true)
                {
                    tv.VarModule = "固定值";
                    tv.InitValue = tetProjectFixValue.Text;
                }
                else if (rbnProjectTable.Checked == true)
                {

                    tv.VarModule = "表单";
                    tv.TableName = ((ListItem)cbxProjectDataTable.SelectedItem).ID;
                    tv.TableField = ((ListItem)cbxProjectTableColumns.SelectedItem).ID;
                }
                else if (rbnProjectExcel.Checked == true)
                {

                    tv.VarModule = "Excel";
                    tv.TableName = tetProjectExcelName.Text;
                    tv.TableField = tetProjectPos.Text;
                }
                else if (rbnProjectDatabase.Checked == true)
                {


                    tv.VarModule = "数据库";
                    tv.TableName = ((ListItem)cbxProjectDbTable.SelectedItem).ID;
                    tv.TableField = ((ListItem)cbxProjectDbTableColumns.SelectedItem).ID;
                }
            }
            tv.InsertTaskVar();
            tv = new TaskVar();
            tv.WorkFlowId = NowTask.WorkFlowId;
            tv.WorkTaskId = NowTask.TaskId;
            tv.VarName = "负责人";
            tv.AccessType = WorkConst.WorkTask_WorkRiZhi;
            if (tv != null)
            {
                if (rbnCharManFixValue.Checked == true)
                {
                    tv.VarModule = "固定值";
                    tetCharManFixValue.Text = tv.InitValue;
                }
                else if (rbnCharManTable.Checked == true)
                {
                    tv.VarModule = "表单";
                    tv.TableName = ((ListItem)cbxCharManDataTable.SelectedItem).ID;
                    tv.TableField = ((ListItem)cbxCharManTableColumns.SelectedItem).ID;
                }
                else if (rbnCharManExcel.Checked == true)
                {
                    tv.VarModule = "Excel";
                    tv.TableName = tetCharManExcelName.Text;
                    tv.TableField = tetCharManPos.Text;
                }
                else if (rbnCharManDatabase.Checked == true)
                {

                    tv.VarModule = "数据库";
                    tv.TableName = ((ListItem)cbxCharManDbTable.SelectedItem).ID;
                    tv.TableField = ((ListItem)cbxCharManDbTableColumns.SelectedItem).ID;
                }
            }
            tv.InsertTaskVar();
            tv = new TaskVar();
            tv.WorkFlowId = NowTask.WorkFlowId;
            tv.WorkTaskId = NowTask.TaskId;
            tv.VarName = "参加人员";
            tv.AccessType = WorkConst.WorkTask_WorkRiZhi;
            if (tv != null)
            {
                if (rbnAttendManFixValue.Checked == true)
                {
                    tv.VarModule = "固定值";
                    tv.InitValue = tetAttendManFixValue.Text;
                }
                else if (rbnAttendManTable.Checked == true)
                {
                    tv.VarModule = "表单";
                    tv.TableName = ((ListItem)cbxAttendManDataTable.SelectedItem).ID;
                    tv.TableField = ((ListItem)cbxAttendManTableColumns.SelectedItem).ID;
                }
                else if (rbnAttendManExcel.Checked == true)
                {
                    tv.VarModule = "Excel";
                    tv.TableName = tetAttendManExcelName.Text;
                    tv.TableField = tetAttendManPos.Text;
                }
                else if (rbnAttendManDatabase.Checked == true)
                {


                    tv.VarModule = "数据库";
                    tv.TableName = ((ListItem)cbxAttendManDbTable.SelectedItem).ID;
                    tv.TableField = ((ListItem)cbxAttendManDbTableColumns.SelectedItem).ID;
                }
            }
            tv.InsertTaskVar();

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
                if (tmpfmTaskVar.tbxVarName.Text.Trim().Length == 0)
                {
                    return;
                }
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
                    if (tmpfmTaskVar.tbxVarName.Text.Trim().Length == 0)
                    {
                        return;
                    }
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

                tbxFiledName.Tag = null;
                tbxFiledName.Text = "";
                iniRiZhiData();
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

        private void btnSelectModle_Click(object sender, EventArgs e)
        {
            SelctTaskModleForm fm = new SelctTaskModleForm();
            fm.Workflowid = NowTask.WorkFlowId;
            fm.Taskid = NowTask.TaskId;
            fm.StrModleId = UserModleId;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                UserModleId = fm.StrModleId;
                tbxModleName.Text = fm.StrModleName;
                mModule obj = MainHelper.PlatformSqlMap.GetOneByKey<mModule>(UserModleId);
                if (obj != null &&  obj.ModuTypes.IndexOf("frmLP") == -1)
                {
                    UserControlId = "节点审核";
                    tbxFormName.Text = "节点提交";

                    tbxFiledName.Tag = null;
                    tbxFiledName.Text = "不可用";
                    label2.Text = "处理(任务命令可用代码{01：提交文件模块，02：手动结束}):";
                }
                else
                {
                    if (UserControlId == "节点审核")
                    {
                        UserControlId = "";
                        tbxFormName.Text = "";

                        tbxFiledName.Tag = null;
                        tbxFiledName.Text = "";
                        label2.Text = "处理";
                    }
                }
              
                object fromCtrl = CreatNewMoldeIns(obj.AssemblyFileName, obj.ModuTypes, obj.MethodName, obj.ModuName);

                if (fromCtrl.GetType().GetProperty("VarDbTableName") != null && fromCtrl.GetType().GetProperty("VarDbTableName").GetValue(fromCtrl, null) != null)
                    varDbTableName = fromCtrl.GetType().GetProperty("VarDbTableName").GetValue(fromCtrl, null).ToString();
                iniRiZhiData();
            }
        }

       
        private void btnSelctField_Click(object sender, EventArgs e)
        {
            if (UserControlId == "")
            {
                MsgBox.ShowWarningMessageBox("请先选择表单");
                return;
            }
            SelectTableFiledFm stf = new SelectTableFiledFm();
            stf.TableID = UserControlId;
            stf.Taskid = NowTask.TaskId;
            stf.Workflowid = NowTask.WorkFlowId;
            if (stf.ShowDialog() == DialogResult.OK )
            {
                tbxFiledName.Tag = stf.StrFieldidList;
                tbxFiledName.Text = stf.StrFieldNameList;
                iniRiZhiData();
            }
        }

        private void cbxWorkDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxWorkDataTable.SelectedIndex == 0) return;
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_TableUsedFieldList",
                "where UserControlId ='" + ((ListItem)cbxWorkDataTable.SelectedItem).ID + "' and WorktaskId='" + NowTask.TaskId + "'");
            DataTable dt = new DataTable();
            if (li.Count > 0) dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxWorkTableColumns, dt, "FieldId", "FieldName");
            cbxWorkTableColumns.SelectedIndex = 0;
        }

        private void cbxWorkDbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxWorkDbTable.SelectedIndex == 0) return;
            IList li = MainHelper.PlatformSqlMap.GetList("GetTableColumns", ((ListItem)cbxWorkDbTable.SelectedItem).ID);
            DataTable dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxWorkDbTableColumns, dt, "name", "name");
            cbxWorkDbTableColumns.SelectedIndex = 0;
        }

        private void cbxProjectDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxProjectDataTable.SelectedIndex == 0) return;
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_TableUsedFieldList",
                "where UserControlId ='" + ((ListItem)cbxProjectDataTable.SelectedItem).ID + "' and WorktaskId='" + NowTask.TaskId + "'");
            DataTable dt = new DataTable();
            if (li.Count > 0) dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxProjectTableColumns, dt, "FieldId", "FieldName");
            cbxProjectTableColumns.SelectedIndex = 0;
        }

        private void cbxProjectDbTable_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxProjectDbTable.SelectedIndex == 0) return;
            IList li = MainHelper.PlatformSqlMap.GetList("GetTableColumns", ((ListItem)cbxProjectDbTable.SelectedItem).ID);
            DataTable dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxProjectDbTableColumns, dt, "name", "name");
            cbxProjectDbTableColumns.SelectedIndex = 0;
        }

        private void cbxCharManDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxCharManDataTable.SelectedIndex == 0) return;
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_TableUsedFieldList",
                "where UserControlId ='" + ((ListItem)cbxCharManDataTable.SelectedItem).ID + "' and WorktaskId='" + NowTask.TaskId + "'");
            DataTable dt = new DataTable();
            if (li.Count > 0) dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxCharManTableColumns, dt, "FieldId", "FieldName");
            cbxCharManTableColumns.SelectedIndex = 0;
        }

        private void cbxCharManDbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCharManDbTable.SelectedIndex == 0) return;
            IList li = MainHelper.PlatformSqlMap.GetList("GetTableColumns", ((ListItem)cbxCharManDbTable.SelectedItem).ID);
            DataTable dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxCharManDbTableColumns, dt, "name", "name");
            cbxCharManDbTableColumns.SelectedIndex = 0;
        }

        private void cbxAttendManDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxAttendManDataTable.SelectedIndex == 0) return;
            IList li = MainHelper.PlatformSqlMap.GetList("SelectWF_TableUsedFieldList",
                "where UserControlId ='" + ((ListItem)cbxAttendManDataTable.SelectedItem).ID + "' and WorktaskId='" + NowTask.TaskId + "'");
            DataTable dt = new DataTable();
            if (li.Count > 0) dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxAttendManTableColumns, dt, "FieldId", "FieldName");
            cbxAttendManTableColumns.SelectedIndex = 0;
        }

        private void cbxAttendManDbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxAttendManDbTable.SelectedIndex == 0) return;
            IList li = MainHelper.PlatformSqlMap.GetList("GetTableColumns", ((ListItem)cbxAttendManDbTable.SelectedItem).ID);
            DataTable dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxAttendManDbTableColumns, dt, "name", "name");
            cbxAttendManDbTableColumns.SelectedIndex = 0;
        }

        private void btnModleClear_Click(object sender, EventArgs e)
        {
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认清除关联模块?") != DialogResult.OK)
            {
                return;
            }
            //保存关联模块
            WorkFlowTask.DeleteAllModle(NowTask.TaskId);
            WorkFlowTask.DeleteAllModleField(NowTask.WorkFlowId, NowTask.TaskId);
            UserModleId = "";
            tbxModleName.Text = "";
            btnSelectCtrls.Enabled = true;
            btnSelctField.Enabled = true;
        }

        private void btnTableClear_Click(object sender, EventArgs e)
        {
            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认清除关联表单?") != DialogResult.OK)
            {
                return;
            }
            //保存关联表单
            WorkFlowTask.DeleteAllControls(NowTask.TaskId);
            WorkFlowTask.DeleteAllTableField(NowTask.WorkFlowId, NowTask.TaskId);
            UserControlId = "";
            tbxFormName.Text = "";
            tbxFiledName.Tag = null;
            tbxFiledName.Text = "";
            label2.Text = "处理";
        }

        private void btnFieldClear_Click(object sender, EventArgs e)
        {

            //请求确认
            if (MsgBox.ShowAskMessageBox("是否确认清除关联字段?") != DialogResult.OK)
            {
                return;
            }
            WorkFlowTask.DeleteAllTableField(NowTask.WorkFlowId, NowTask.TaskId);
            tbxFiledName.Tag = null;
            tbxFiledName.Text = "";
        }


        
	}
}
