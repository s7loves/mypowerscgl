using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using Ebada.Client;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;


namespace Ebada.SCGL.WFlow.Tool
{
    /// <summary>
    /// TaskAlterFm 的摘要说明。
    /// </summary>
    public class fmTaskAlter : BaseForm_Single
    {
        public AlternateTask NowTask;
        public string UserId = "";//操作人账号，用作权限判断。
        public string UserName = "";//操作人姓名，用作显示。
        public string UserControlId = "";//关联表单id
        private TabControl tabControl1;
        private TabPage tabPage1;
        private PictureBox pictureBox1;
        private TabPage tabPage6;
        private CheckBox cbxJumpSelf;
        private CheckBox checkBox1;
        private TabPage tabPage3;
        private ContextMenu contextMenu1;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private TabPage tabPage2;
        private GroupBox groupBox5;
        private GroupBox groupBox7;
        private RadioButton rbOver;
        private RadioButton rbRemain;
        private TabPage tabPage4;
        private MenuItem menuItem5;
        private ContextMenu contextMenu2;
        private ContextMenu contextMenu3;
        private MenuItem menuItem7;
        private ListView lvOper;
        private Label label5;
        private GroupBox groupBox1;
        private RadioButton rbtEveryUser;
        private RadioButton rbtShareUser;
        private ListView lvCommand;
        private Label label4;
        private TextBox tbxTaskDes;
        private GroupBox groupBox2;
        private Button btnDeletecmd;
        private Button btnModifycmd;
        private Button btnAddcmd;
        private TextBox tbxTaskName;
        private Label label1;
        private Label label2;
        private Button btnDeleteOpr;
        private Button btnModifyOpr;
        private Button btnAddOpr;
        private ImageList imgListSmall;
        private Button btnDeleteVar;
        private Button btnModifyVar;
        private Button btnAddVar;
        private ListView lvVar;
        private CheckBox cbxInstancy;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private TabPage tabPage5;
        private CheckBox cbxReturn;
        private CheckBox cbxDyAssignNext;
        private CheckBox cbxAssign;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label18;
        private NumericUpDown tbxDay1;
        private NumericUpDown tbxMinute3;
        private NumericUpDown tbxHour3;
        private NumericUpDown tbxDay3;
        private NumericUpDown tbxMinute2;
        private NumericUpDown tbxHour2;
        private NumericUpDown tbxDay2;
        private NumericUpDown tbxMinute1;
        private NumericUpDown tbxHour1;
        private GroupBox groupBox6;
        private ListBox lbxOtMsgToUsers;
        private Button btnOtDelete;
        private Button btnOtAdd;
        private Label label9;
        private CheckBox cbxOtMail;
        private CheckBox cbxOtMessage;
        private CheckBox cbxOtSms;
        private GroupBox groupBox3;
        private ListBox lbxRmMsgToUsers;
        private Button btnRmDelete;
        private Button btnRmAdd;
        private Label label10;
        private CheckBox cbxRmMail;
        private CheckBox cbxRmMessage;
        private CheckBox cbxRmSms;
        private Label label3;
        private Label label14;
        private Label label19;
        private TextBox tbxModleName;
        private TextBox tbxFiledName;
        private TextBox tbxFormName;
        private Button btnSelectModle;
        private Button btnSelctField;
        private Button btnSelectCtrls;
        private IContainer components;//处理人

        public fmTaskAlter(AlternateTask alterTask, string userId, string userName)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            NowTask = alterTask;
            this.UserId = userId;
            this.UserName = userName;

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmTaskAlter));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbOver = new System.Windows.Forms.RadioButton();
            this.rbRemain = new System.Windows.Forms.RadioButton();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btnDeleteOpr = new System.Windows.Forms.Button();
            this.btnModifyOpr = new System.Windows.Forms.Button();
            this.btnAddOpr = new System.Windows.Forms.Button();
            this.lvOper = new System.Windows.Forms.ListView();
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtEveryUser = new System.Windows.Forms.RadioButton();
            this.rbtShareUser = new System.Windows.Forms.RadioButton();
            this.cbxJumpSelf = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lvVar = new System.Windows.Forms.ListView();
            this.btnDeleteVar = new System.Windows.Forms.Button();
            this.btnModifyVar = new System.Windows.Forms.Button();
            this.btnAddVar = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tbxMinute3 = new System.Windows.Forms.NumericUpDown();
            this.tbxHour3 = new System.Windows.Forms.NumericUpDown();
            this.tbxDay3 = new System.Windows.Forms.NumericUpDown();
            this.tbxMinute2 = new System.Windows.Forms.NumericUpDown();
            this.tbxHour2 = new System.Windows.Forms.NumericUpDown();
            this.tbxDay2 = new System.Windows.Forms.NumericUpDown();
            this.tbxMinute1 = new System.Windows.Forms.NumericUpDown();
            this.tbxHour1 = new System.Windows.Forms.NumericUpDown();
            this.tbxDay1 = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.cbxInstancy = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tbxModleName = new System.Windows.Forms.TextBox();
            this.tbxFiledName = new System.Windows.Forms.TextBox();
            this.tbxFormName = new System.Windows.Forms.TextBox();
            this.btnSelectModle = new System.Windows.Forms.Button();
            this.btnSelctField = new System.Windows.Forms.Button();
            this.btnSelectCtrls = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lvCommand = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxTaskDes = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeletecmd = new System.Windows.Forms.Button();
            this.btnModifycmd = new System.Windows.Forms.Button();
            this.btnAddcmd = new System.Windows.Forms.Button();
            this.tbxTaskName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.cbxDyAssignNext = new System.Windows.Forms.CheckBox();
            this.cbxAssign = new System.Windows.Forms.CheckBox();
            this.cbxReturn = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbxRmMsgToUsers = new System.Windows.Forms.ListBox();
            this.btnRmDelete = new System.Windows.Forms.Button();
            this.btnRmAdd = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxRmMail = new System.Windows.Forms.CheckBox();
            this.cbxRmMessage = new System.Windows.Forms.CheckBox();
            this.cbxRmSms = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbxOtMsgToUsers = new System.Windows.Forms.ListBox();
            this.btnOtDelete = new System.Windows.Forms.Button();
            this.btnOtAdd = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxOtMail = new System.Windows.Forms.CheckBox();
            this.cbxOtMessage = new System.Windows.Forms.CheckBox();
            this.cbxOtSms = new System.Windows.Forms.CheckBox();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.contextMenu3 = new System.Windows.Forms.ContextMenu();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMinute3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxHour3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDay3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMinute2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxHour2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDay2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMinute1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxHour1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.tabControl1);
            this.plclassFill.Size = new System.Drawing.Size(444, 485);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 419);
            this.plclassBottom.Size = new System.Drawing.Size(444, 66);
            // 
            // btnSave
            // 
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Text = "取消(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbOver);
            this.groupBox5.Controls.Add(this.rbRemain);
            this.groupBox5.Location = new System.Drawing.Point(10, 188);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(395, 49);
            this.groupBox5.TabIndex = 61;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "超时处理";
            // 
            // rbOver
            // 
            this.rbOver.Enabled = false;
            this.rbOver.Location = new System.Drawing.Point(188, 23);
            this.rbOver.Name = "rbOver";
            this.rbOver.Size = new System.Drawing.Size(112, 23);
            this.rbOver.TabIndex = 2;
            this.rbOver.Text = "跳过本节点处理";
            // 
            // rbRemain
            // 
            this.rbRemain.Enabled = false;
            this.rbRemain.Location = new System.Drawing.Point(12, 20);
            this.rbRemain.Name = "rbRemain";
            this.rbRemain.Size = new System.Drawing.Size(112, 23);
            this.rbRemain.TabIndex = 1;
            this.rbRemain.Text = "保留本节点处理";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.btnDeleteOpr);
            this.tabPage6.Controls.Add(this.btnModifyOpr);
            this.tabPage6.Controls.Add(this.btnAddOpr);
            this.tabPage6.Controls.Add(this.lvOper);
            this.tabPage6.Controls.Add(this.label5);
            this.tabPage6.Controls.Add(this.groupBox1);
            this.tabPage6.Controls.Add(this.cbxJumpSelf);
            this.tabPage6.Controls.Add(this.checkBox1);
            this.tabPage6.Location = new System.Drawing.Point(4, 21);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(424, 371);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "处理者";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // btnDeleteOpr
            // 
            this.btnDeleteOpr.Location = new System.Drawing.Point(245, 283);
            this.btnDeleteOpr.Name = "btnDeleteOpr";
            this.btnDeleteOpr.Size = new System.Drawing.Size(80, 23);
            this.btnDeleteOpr.TabIndex = 120;
            this.btnDeleteOpr.Text = "删除";
            this.btnDeleteOpr.Visible = false;
            this.btnDeleteOpr.Click += new System.EventHandler(this.btnDeleteOpr_Click);
            // 
            // btnModifyOpr
            // 
            this.btnModifyOpr.Location = new System.Drawing.Point(132, 283);
            this.btnModifyOpr.Name = "btnModifyOpr";
            this.btnModifyOpr.Size = new System.Drawing.Size(80, 23);
            this.btnModifyOpr.TabIndex = 119;
            this.btnModifyOpr.Text = "修改";
            this.btnModifyOpr.Visible = false;
            this.btnModifyOpr.Click += new System.EventHandler(this.btnModifyOpr_Click);
            // 
            // btnAddOpr
            // 
            this.btnAddOpr.Location = new System.Drawing.Point(32, 283);
            this.btnAddOpr.Name = "btnAddOpr";
            this.btnAddOpr.Size = new System.Drawing.Size(80, 23);
            this.btnAddOpr.TabIndex = 118;
            this.btnAddOpr.Text = "增加";
            this.btnAddOpr.Visible = false;
            this.btnAddOpr.Click += new System.EventHandler(this.btnAddOpr_Click);
            // 
            // lvOper
            // 
            this.lvOper.FullRowSelect = true;
            this.lvOper.Location = new System.Drawing.Point(13, 108);
            this.lvOper.Name = "lvOper";
            this.lvOper.Size = new System.Drawing.Size(389, 169);
            this.lvOper.SmallImageList = this.imgListSmall;
            this.lvOper.TabIndex = 117;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 93);
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
            this.groupBox1.Size = new System.Drawing.Size(389, 61);
            this.groupBox1.TabIndex = 112;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "处理者策略";
            // 
            // rbtEveryUser
            // 
            this.rbtEveryUser.AutoSize = true;
            this.rbtEveryUser.Location = new System.Drawing.Point(146, 30);
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
            // cbxJumpSelf
            // 
            this.cbxJumpSelf.AutoSize = true;
            this.cbxJumpSelf.Location = new System.Drawing.Point(32, 317);
            this.cbxJumpSelf.Name = "cbxJumpSelf";
            this.cbxJumpSelf.Size = new System.Drawing.Size(180, 16);
            this.cbxJumpSelf.TabIndex = 111;
            this.cbxJumpSelf.Text = "处理者是提交人则跳过本处理";
            this.cbxJumpSelf.UseVisualStyleBackColor = true;
            this.cbxJumpSelf.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(32, 339);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(168, 16);
            this.checkBox1.TabIndex = 110;
            this.checkBox1.Text = "无对应处理人则跳过本处理";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lvVar);
            this.tabPage3.Controls.Add(this.btnDeleteVar);
            this.tabPage3.Controls.Add(this.btnModifyVar);
            this.tabPage3.Controls.Add(this.btnAddVar);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(424, 371);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "任务变量";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Visible = false;
            // 
            // lvVar
            // 
            this.lvVar.FullRowSelect = true;
            this.lvVar.Location = new System.Drawing.Point(12, 15);
            this.lvVar.MultiSelect = false;
            this.lvVar.Name = "lvVar";
            this.lvVar.Size = new System.Drawing.Size(395, 285);
            this.lvVar.TabIndex = 7;
            this.lvVar.UseCompatibleStateImageBehavior = false;
            this.lvVar.View = System.Windows.Forms.View.Details;
            this.lvVar.SelectedIndexChanged += new System.EventHandler(this.lvVar_SelectedIndexChanged);
            this.lvVar.DoubleClick += new System.EventHandler(this.btnModifyVar_Click);
            // 
            // btnDeleteVar
            // 
            this.btnDeleteVar.Location = new System.Drawing.Point(256, 324);
            this.btnDeleteVar.Name = "btnDeleteVar";
            this.btnDeleteVar.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteVar.TabIndex = 6;
            this.btnDeleteVar.Text = "删除";
            this.btnDeleteVar.UseVisualStyleBackColor = true;
            this.btnDeleteVar.Click += new System.EventHandler(this.btnDeleteVar_Click);
            // 
            // btnModifyVar
            // 
            this.btnModifyVar.Location = new System.Drawing.Point(139, 323);
            this.btnModifyVar.Name = "btnModifyVar";
            this.btnModifyVar.Size = new System.Drawing.Size(75, 23);
            this.btnModifyVar.TabIndex = 5;
            this.btnModifyVar.Text = "修改";
            this.btnModifyVar.UseVisualStyleBackColor = true;
            this.btnModifyVar.Click += new System.EventHandler(this.btnModifyVar_Click);
            // 
            // btnAddVar
            // 
            this.btnAddVar.Location = new System.Drawing.Point(39, 324);
            this.btnAddVar.Name = "btnAddVar";
            this.btnAddVar.Size = new System.Drawing.Size(75, 23);
            this.btnAddVar.TabIndex = 4;
            this.btnAddVar.Text = "增加";
            this.btnAddVar.UseVisualStyleBackColor = true;
            this.btnAddVar.Click += new System.EventHandler(this.btnAddVar_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tbxMinute3);
            this.groupBox7.Controls.Add(this.tbxHour3);
            this.groupBox7.Controls.Add(this.tbxDay3);
            this.groupBox7.Controls.Add(this.tbxMinute2);
            this.groupBox7.Controls.Add(this.tbxHour2);
            this.groupBox7.Controls.Add(this.tbxDay2);
            this.groupBox7.Controls.Add(this.tbxMinute1);
            this.groupBox7.Controls.Add(this.tbxHour1);
            this.groupBox7.Controls.Add(this.tbxDay1);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.checkBox4);
            this.groupBox7.Controls.Add(this.checkBox3);
            this.groupBox7.Controls.Add(this.cbxInstancy);
            this.groupBox7.Location = new System.Drawing.Point(10, 19);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(395, 146);
            this.groupBox7.TabIndex = 59;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "超时设置";
            // 
            // tbxMinute3
            // 
            this.tbxMinute3.Location = new System.Drawing.Point(245, 84);
            this.tbxMinute3.Name = "tbxMinute3";
            this.tbxMinute3.Size = new System.Drawing.Size(50, 21);
            this.tbxMinute3.TabIndex = 40;
            // 
            // tbxHour3
            // 
            this.tbxHour3.Location = new System.Drawing.Point(173, 84);
            this.tbxHour3.Name = "tbxHour3";
            this.tbxHour3.Size = new System.Drawing.Size(50, 21);
            this.tbxHour3.TabIndex = 39;
            // 
            // tbxDay3
            // 
            this.tbxDay3.Location = new System.Drawing.Point(95, 84);
            this.tbxDay3.Name = "tbxDay3";
            this.tbxDay3.Size = new System.Drawing.Size(50, 21);
            this.tbxDay3.TabIndex = 38;
            // 
            // tbxMinute2
            // 
            this.tbxMinute2.Location = new System.Drawing.Point(245, 56);
            this.tbxMinute2.Name = "tbxMinute2";
            this.tbxMinute2.Size = new System.Drawing.Size(50, 21);
            this.tbxMinute2.TabIndex = 37;
            // 
            // tbxHour2
            // 
            this.tbxHour2.Location = new System.Drawing.Point(173, 56);
            this.tbxHour2.Name = "tbxHour2";
            this.tbxHour2.Size = new System.Drawing.Size(50, 21);
            this.tbxHour2.TabIndex = 36;
            // 
            // tbxDay2
            // 
            this.tbxDay2.Location = new System.Drawing.Point(95, 56);
            this.tbxDay2.Name = "tbxDay2";
            this.tbxDay2.Size = new System.Drawing.Size(50, 21);
            this.tbxDay2.TabIndex = 35;
            // 
            // tbxMinute1
            // 
            this.tbxMinute1.Location = new System.Drawing.Point(245, 25);
            this.tbxMinute1.Name = "tbxMinute1";
            this.tbxMinute1.Size = new System.Drawing.Size(50, 21);
            this.tbxMinute1.TabIndex = 34;
            // 
            // tbxHour1
            // 
            this.tbxHour1.Location = new System.Drawing.Point(173, 25);
            this.tbxHour1.Name = "tbxHour1";
            this.tbxHour1.Size = new System.Drawing.Size(50, 21);
            this.tbxHour1.TabIndex = 33;
            // 
            // tbxDay1
            // 
            this.tbxDay1.Location = new System.Drawing.Point(95, 25);
            this.tbxDay1.Name = "tbxDay1";
            this.tbxDay1.Size = new System.Drawing.Size(50, 21);
            this.tbxDay1.TabIndex = 32;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(23, 118);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(191, 12);
            this.label18.TabIndex = 31;
            this.label18.Text = "说明:设置完成任务所需要的时间。";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(299, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 12);
            this.label15.TabIndex = 28;
            this.label15.Text = "分";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(227, 88);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 26;
            this.label16.Text = "时";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(153, 88);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 24;
            this.label17.Text = "天";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(299, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "分";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(227, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 17;
            this.label12.Text = "时";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(153, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 15;
            this.label13.Text = "天";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(299, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "分";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(227, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "时";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "天";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(25, 27);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(48, 16);
            this.checkBox4.TabIndex = 2;
            this.checkBox4.Text = "普通";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(25, 56);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(48, 16);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "紧急";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // cbxInstancy
            // 
            this.cbxInstancy.AutoSize = true;
            this.cbxInstancy.Location = new System.Drawing.Point(25, 84);
            this.cbxInstancy.Name = "cbxInstancy";
            this.cbxInstancy.Size = new System.Drawing.Size(48, 16);
            this.cbxInstancy.TabIndex = 0;
            this.cbxInstancy.Text = "特急";
            this.cbxInstancy.UseVisualStyleBackColor = true;
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
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(9, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(432, 396);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.tbxModleName);
            this.tabPage1.Controls.Add(this.tbxFiledName);
            this.tabPage1.Controls.Add(this.tbxFormName);
            this.tabPage1.Controls.Add(this.btnSelectModle);
            this.tabPage1.Controls.Add(this.btnSelctField);
            this.tabPage1.Controls.Add(this.btnSelectCtrls);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lvCommand);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tbxTaskDes);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.btnDeletecmd);
            this.tabPage1.Controls.Add(this.btnModifycmd);
            this.tabPage1.Controls.Add(this.btnAddcmd);
            this.tabPage1.Controls.Add(this.tbxTaskName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(424, 371);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "常规";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(72, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 134;
            this.label3.Text = "模块名:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(35, 119);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 23);
            this.label14.TabIndex = 135;
            this.label14.Text = "可操作的字段:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(72, 92);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 23);
            this.label19.TabIndex = 136;
            this.label19.Text = "表单名:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxModleName
            // 
            this.tbxModleName.Location = new System.Drawing.Point(142, 65);
            this.tbxModleName.Name = "tbxModleName";
            this.tbxModleName.ReadOnly = true;
            this.tbxModleName.Size = new System.Drawing.Size(212, 21);
            this.tbxModleName.TabIndex = 133;
            // 
            // tbxFiledName
            // 
            this.tbxFiledName.Location = new System.Drawing.Point(142, 119);
            this.tbxFiledName.Name = "tbxFiledName";
            this.tbxFiledName.ReadOnly = true;
            this.tbxFiledName.Size = new System.Drawing.Size(212, 21);
            this.tbxFiledName.TabIndex = 132;
            // 
            // tbxFormName
            // 
            this.tbxFormName.Location = new System.Drawing.Point(142, 92);
            this.tbxFormName.Name = "tbxFormName";
            this.tbxFormName.ReadOnly = true;
            this.tbxFormName.Size = new System.Drawing.Size(212, 21);
            this.tbxFormName.TabIndex = 131;
            // 
            // btnSelectModle
            // 
            this.btnSelectModle.Location = new System.Drawing.Point(358, 64);
            this.btnSelectModle.Name = "btnSelectModle";
            this.btnSelectModle.Size = new System.Drawing.Size(41, 23);
            this.btnSelectModle.TabIndex = 128;
            // 
            // btnSelctField
            // 
            this.btnSelctField.Location = new System.Drawing.Point(358, 119);
            this.btnSelctField.Name = "btnSelctField";
            this.btnSelctField.Size = new System.Drawing.Size(41, 23);
            this.btnSelctField.TabIndex = 129;
            this.btnSelctField.Click += new System.EventHandler(this.btnSelctField_Click);
            // 
            // btnSelectCtrls
            // 
            this.btnSelectCtrls.Location = new System.Drawing.Point(358, 92);
            this.btnSelectCtrls.Name = "btnSelectCtrls";
            this.btnSelectCtrls.Size = new System.Drawing.Size(41, 23);
            this.btnSelectCtrls.TabIndex = 130;
            this.btnSelectCtrls.Click += new System.EventHandler(this.btnSelectCtrls_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 127;
            this.label2.Text = "处理:";
            // 
            // lvCommand
            // 
            this.lvCommand.FullRowSelect = true;
            this.lvCommand.Location = new System.Drawing.Point(22, 174);
            this.lvCommand.Name = "lvCommand";
            this.lvCommand.Size = new System.Drawing.Size(379, 166);
            this.lvCommand.SmallImageList = this.imgListSmall;
            this.lvCommand.TabIndex = 126;
            this.lvCommand.UseCompatibleStateImageBehavior = false;
            this.lvCommand.View = System.Windows.Forms.View.Details;
            this.lvCommand.DoubleClick += new System.EventHandler(this.btnModifycmd_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(64, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 23);
            this.label4.TabIndex = 125;
            this.label4.Text = "任务描述:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxTaskDes
            // 
            this.tbxTaskDes.Location = new System.Drawing.Point(144, 36);
            this.tbxTaskDes.Name = "tbxTaskDes";
            this.tbxTaskDes.Size = new System.Drawing.Size(259, 21);
            this.tbxTaskDes.TabIndex = 124;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(22, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 2);
            this.groupBox2.TabIndex = 123;
            this.groupBox2.TabStop = false;
            // 
            // btnDeletecmd
            // 
            this.btnDeletecmd.Location = new System.Drawing.Point(266, 346);
            this.btnDeletecmd.Name = "btnDeletecmd";
            this.btnDeletecmd.Size = new System.Drawing.Size(80, 23);
            this.btnDeletecmd.TabIndex = 122;
            this.btnDeletecmd.Text = "删除";
            this.btnDeletecmd.Click += new System.EventHandler(this.btnDeletecmd_Click);
            // 
            // btnModifycmd
            // 
            this.btnModifycmd.Location = new System.Drawing.Point(144, 346);
            this.btnModifycmd.Name = "btnModifycmd";
            this.btnModifycmd.Size = new System.Drawing.Size(80, 23);
            this.btnModifycmd.TabIndex = 121;
            this.btnModifycmd.Text = "修改";
            this.btnModifycmd.Click += new System.EventHandler(this.btnModifycmd_Click);
            // 
            // btnAddcmd
            // 
            this.btnAddcmd.Location = new System.Drawing.Point(44, 346);
            this.btnAddcmd.Name = "btnAddcmd";
            this.btnAddcmd.Size = new System.Drawing.Size(80, 23);
            this.btnAddcmd.TabIndex = 118;
            this.btnAddcmd.Text = "增加";
            this.btnAddcmd.Click += new System.EventHandler(this.btnAddcmd_Click);
            // 
            // tbxTaskName
            // 
            this.tbxTaskName.Location = new System.Drawing.Point(144, 9);
            this.tbxTaskName.Name = "tbxTaskName";
            this.tbxTaskName.Size = new System.Drawing.Size(259, 21);
            this.tbxTaskName.TabIndex = 116;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(64, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 23);
            this.label1.TabIndex = 115;
            this.label1.Text = "任务名称:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.cbxDyAssignNext);
            this.tabPage5.Controls.Add(this.cbxAssign);
            this.tabPage5.Controls.Add(this.cbxReturn);
            this.tabPage5.Location = new System.Drawing.Point(4, 21);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(424, 371);
            this.tabPage5.TabIndex = 6;
            this.tabPage5.Text = "控制权限";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // cbxDyAssignNext
            // 
            this.cbxDyAssignNext.AutoSize = true;
            this.cbxDyAssignNext.Location = new System.Drawing.Point(35, 77);
            this.cbxDyAssignNext.Name = "cbxDyAssignNext";
            this.cbxDyAssignNext.Size = new System.Drawing.Size(180, 16);
            this.cbxDyAssignNext.TabIndex = 2;
            this.cbxDyAssignNext.Text = "允许动态指定一下任务处理人";
            this.cbxDyAssignNext.UseVisualStyleBackColor = true;
            // 
            // cbxAssign
            // 
            this.cbxAssign.AutoSize = true;
            this.cbxAssign.Location = new System.Drawing.Point(35, 54);
            this.cbxAssign.Name = "cbxAssign";
            this.cbxAssign.Size = new System.Drawing.Size(120, 16);
            this.cbxAssign.TabIndex = 1;
            this.cbxAssign.Text = "允许指派他人处理";
            this.cbxAssign.UseVisualStyleBackColor = true;
            // 
            // cbxReturn
            // 
            this.cbxReturn.AutoSize = true;
            this.cbxReturn.Location = new System.Drawing.Point(35, 31);
            this.cbxReturn.Name = "cbxReturn";
            this.cbxReturn.Size = new System.Drawing.Size(72, 16);
            this.cbxReturn.TabIndex = 0;
            this.cbxReturn.Text = "允许退回";
            this.cbxReturn.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(424, 371);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "超时配置";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Visible = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Controls.Add(this.groupBox6);
            this.tabPage4.Location = new System.Drawing.Point(4, 21);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(424, 371);
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
            this.groupBox3.Location = new System.Drawing.Point(14, 197);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 165);
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
            this.lbxRmMsgToUsers.Size = new System.Drawing.Size(305, 88);
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
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lbxOtMsgToUsers);
            this.groupBox6.Controls.Add(this.btnOtDelete);
            this.groupBox6.Controls.Add(this.btnOtAdd);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.cbxOtMail);
            this.groupBox6.Controls.Add(this.cbxOtMessage);
            this.groupBox6.Controls.Add(this.cbxOtSms);
            this.groupBox6.Location = new System.Drawing.Point(14, 18);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(395, 157);
            this.groupBox6.TabIndex = 61;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "超时通知";
            // 
            // lbxOtMsgToUsers
            // 
            this.lbxOtMsgToUsers.FormattingEnabled = true;
            this.lbxOtMsgToUsers.ItemHeight = 12;
            this.lbxOtMsgToUsers.Location = new System.Drawing.Point(12, 63);
            this.lbxOtMsgToUsers.Name = "lbxOtMsgToUsers";
            this.lbxOtMsgToUsers.ScrollAlwaysVisible = true;
            this.lbxOtMsgToUsers.Size = new System.Drawing.Size(305, 88);
            this.lbxOtMsgToUsers.TabIndex = 12;
            // 
            // btnOtDelete
            // 
            this.btnOtDelete.Location = new System.Drawing.Point(322, 116);
            this.btnOtDelete.Name = "btnOtDelete";
            this.btnOtDelete.Size = new System.Drawing.Size(45, 23);
            this.btnOtDelete.TabIndex = 11;
            this.btnOtDelete.Text = "删除";
            this.btnOtDelete.UseVisualStyleBackColor = true;
            this.btnOtDelete.Click += new System.EventHandler(this.btnOtDelete_Click);
            // 
            // btnOtAdd
            // 
            this.btnOtAdd.Location = new System.Drawing.Point(322, 72);
            this.btnOtAdd.Name = "btnOtAdd";
            this.btnOtAdd.Size = new System.Drawing.Size(45, 23);
            this.btnOtAdd.TabIndex = 10;
            this.btnOtAdd.Text = "增加";
            this.btnOtAdd.UseVisualStyleBackColor = true;
            this.btnOtAdd.Click += new System.EventHandler(this.btnOtAdd_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(10, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "同时通知下列人员:";
            // 
            // cbxOtMail
            // 
            this.cbxOtMail.Location = new System.Drawing.Point(245, 22);
            this.cbxOtMail.Name = "cbxOtMail";
            this.cbxOtMail.Size = new System.Drawing.Size(112, 23);
            this.cbxOtMail.TabIndex = 7;
            this.cbxOtMail.Text = "邮件通知";
            // 
            // cbxOtMessage
            // 
            this.cbxOtMessage.Location = new System.Drawing.Point(12, 22);
            this.cbxOtMessage.Name = "cbxOtMessage";
            this.cbxOtMessage.Size = new System.Drawing.Size(112, 23);
            this.cbxOtMessage.TabIndex = 6;
            this.cbxOtMessage.Text = "即时消息通知";
            // 
            // cbxOtSms
            // 
            this.cbxOtSms.Location = new System.Drawing.Point(132, 22);
            this.cbxOtSms.Name = "cbxOtSms";
            this.cbxOtSms.Size = new System.Drawing.Size(112, 23);
            this.cbxOtSms.TabIndex = 5;
            this.cbxOtSms.Text = "手机短信通知";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.Text = "删除";
            // 
            // contextMenu2
            // 
            this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5});
            // 
            // contextMenu3
            // 
            this.contextMenu3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem7});
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 0;
            this.menuItem7.Text = "删除";
            // 
            // fmTaskAlter
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(444, 485);
            this.Name = "fmTaskAlter";
            this.Text = "交互节点配置";
            this.Load += new System.EventHandler(this.fmTaskAlter_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMinute3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxHour3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDay3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMinute2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxHour2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDay2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMinute1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxHour1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private void InitData()
        {
            tbxTaskName.Text = NowTask.TaskName;
            tbxTaskDes.Text = NowTask.Description;
            cbxJumpSelf.Checked = NowTask.IsJumpSelf;
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
            //*********表单
            DataTable ctrlTable = WorkFlowTask.GetTaskControls(NowTask.TaskId);
            if (ctrlTable != null && ctrlTable.Rows.Count > 0)
            {
                //tbxFormName.Text = ctrlTable.Rows[0]["mucCaption"].ToString();
                //UserControlId = ctrlTable.Rows[0]["UserControlId"].ToString();
                tbxFormName.Text = ctrlTable.Rows[0]["CellName"].ToString();
                UserControlId = ctrlTable.Rows[0]["LPID"].ToString();
            }
            //可操作字段
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
            //*********控制权限
            DataTable powerTable = WorkFlowTask.GetTaskPower(NowTask.WorkFlowId, NowTask.TaskId);
            string powerStr = "";
            foreach (DataRow dr in powerTable.Rows)
            {
                powerStr = powerStr + dr["PowerName"].ToString()+",";
            }
            cbxReturn.Checked=powerStr.IndexOf(WorkConst.WorkTask_Return) > -1;//退回
            cbxAssign.Checked = powerStr.IndexOf(WorkConst.WorkTask_Assign) >-1;//指派
            cbxDyAssignNext.Checked = powerStr.IndexOf(WorkConst.WorkTask_DyAssignNext) > -1;//动态指定下一任务处理人
            //********* 超时配置
            WorkOutTime ot = new WorkOutTime();
            ot.GetWorkOutTimeInfo(NowTask.TaskId);
            tbxDay1.Value = ot.Days;
            tbxDay2.Value = ot.Days1;
            tbxDay3.Value = ot.Days2;
            tbxHour1.Value = ot.Hours;
            tbxHour2.Value = ot.Hours1;
            tbxHour3.Value = ot.Hours2;
            tbxMinute1.Value = ot.Minutes;
            tbxMinute2.Value = ot.Minutes1;
            tbxMinute3.Value = ot.Minutes2;

            //********* 事件通知
            WorkFlowEvent ev = new WorkFlowEvent();
            ev.GetWorkFlowEventInfo(NowTask.TaskId);
            cbxOtMail.Checked = ev.OtEmail;
            cbxOtMessage.Checked = ev.OtMsg;
            cbxOtSms.Checked = ev.OtSms;
            string[] us= ev.OtToUsers.Split(',');
            foreach (string usr in us)
            {
                if (usr.Length>0)
                lbxOtMsgToUsers.Items.Add(usr);
            }
            cbxRmMail.Checked = ev.RmEmail;
            cbxRmMessage.Checked = ev.RmMsg;
            cbxRmSms.Checked = ev.RmSms;

            us = ev.RmToUsers.Split(',');
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
            NowTask.IsJumpSelf = cbxJumpSelf.Checked;
            if (rbtShareUser.Checked)
                NowTask.OperRule = "1";
            else
                if (rbtEveryUser.Checked)
                    NowTask.OperRule = "2";
            if (cbxReturn.Checked)
                NowTask.haveback = true;
            else
                NowTask.haveback = false;
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
                taskCommand.CommandId =lt.SubItems[1].Text;
                taskCommand.Description = lt.SubItems[2].Text;
                taskCommand.InsertWorkTaskCommands();
            }
            //保存关联表单
            WorkFlowTask.DeleteAllControls(NowTask.TaskId);
            WorkFlowTask.SetTaskUserCtrls(UserControlId,NowTask.WorkFlowId, NowTask.TaskId);

            //保存控制权限
            WorkFlowTask.DeleteAllPower(NowTask.WorkFlowId, NowTask.TaskId);
            if (cbxReturn.Checked)
            WorkFlowTask.SetTaskPower(WorkConst.WorkTask_Return,NowTask.WorkFlowId, NowTask.TaskId);
            if (cbxAssign.Checked)
            WorkFlowTask.SetTaskPower(WorkConst.WorkTask_Assign, NowTask.WorkFlowId, NowTask.TaskId);
            if (cbxDyAssignNext.Checked)
                WorkFlowTask.SetTaskPower(WorkConst.WorkTask_DyAssignNext, NowTask.WorkFlowId, NowTask.TaskId);

            //保存超时配置
            WorkOutTime.Delete(NowTask.TaskId);
            WorkOutTime ot = new WorkOutTime();
            ot.Guid = Guid.NewGuid().ToString();
            ot.WorkFlowId = NowTask.WorkFlowId;
            ot.WorkTaskId = NowTask.TaskId;
            ot.Days =Convert.ToInt16(tbxDay1.Value);
            ot.Days1 = Convert.ToInt16(tbxDay2.Value);
            ot.Days2 = Convert.ToInt16(tbxDay3.Value);
            ot.Hours = Convert.ToInt16(tbxHour1.Value);
            ot.Hours1 = Convert.ToInt16(tbxHour2.Value);
            ot.Hours2 = Convert.ToInt16(tbxHour3.Value);
            ot.Minutes = Convert.ToInt16(tbxMinute1.Value);
            ot.Minutes1 = Convert.ToInt16(tbxMinute2.Value);
            ot.Minutes2 = Convert.ToInt16(tbxMinute3.Value);
            ot.Insert();

            //保存事件
            WorkFlowEvent.Delete(NowTask.TaskId);
            WorkFlowEvent ev = new WorkFlowEvent();
            ev.Guid = Guid.NewGuid().ToString();
            ev.WorkFlowId = NowTask.WorkFlowId;
            ev.WorkTaskId = NowTask.TaskId;
            ev.OtMsg = cbxOtMessage.Checked;
            ev.OtSms = cbxOtSms.Checked;
            ev.OtEmail = cbxOtMail.Checked;
            string us = "";
            if (lbxOtMsgToUsers.Items.Count > 0)
            {
                for (int i = 0; i < lbxOtMsgToUsers.Items.Count - 1; i++)
                {
                    us = us + lbxOtMsgToUsers.Items[i].ToString() + ",";
                }
                us = us + lbxOtMsgToUsers.Items[lbxOtMsgToUsers.Items.Count - 1];
            }
            ev.OtToUsers = us;
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
                if (tmpfmOperator.OperDisplay.Length <= 0)
                {
                    MsgBox.ShowWarningMessageBox ("没有选择处理者!!");
                    return;
                }
                //Text = tmpfmOperator.OperId;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fmTaskAlter_Load(object sender, EventArgs e)
        {
            InitData();
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
            tmpfmTaskVar.varTableColumnName = "";
            tmpfmTaskVar.ShowDialog();
            DialogResult dlr = tmpfmTaskVar.DialogResult;
            if (dlr == DialogResult.OK)
            {
                if (tmpfmTaskVar.tbxVarName.Text.Trim().Length < 1) return;
                if (varExists(tmpfmTaskVar.tbxVarName.Text))
                {
                    MsgBox.ShowWarningMessageBox("变量" + tmpfmTaskVar.tbxVarName.Text + "已存在,不能填加!");
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
                tmpfmTaskVar.cbxVarType.Text = lvi1.SubItems[2].Text;
                tmpfmTaskVar.cbxVarModule.Text = lvi1.SubItems[3].Text;

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
                    if (lvi1.Text!=tmpfmTaskVar.tbxVarName.Text&&varExists(tmpfmTaskVar.tbxVarName.Text))
                    {
                        MsgBox.ShowWarningMessageBox ("变量" + tmpfmTaskVar.tbxVarName.Text + "已存在,请使用其他名称!");
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
                    if (tmpfmTaskVar.cbxAccessType.SelectedIndex>0)
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
            }
        }

        private void btnOtDelete_Click(object sender, EventArgs e)
        {
            if (lbxOtMsgToUsers.SelectedItems.Count > 0)
                lbxOtMsgToUsers.Items.Remove(lbxOtMsgToUsers.SelectedItem);
        }

        private void btnRmDelete_Click(object sender, EventArgs e)
        {
            if (lbxRmMsgToUsers.SelectedItems.Count > 0)
                lbxRmMsgToUsers.Items.Remove(lbxRmMsgToUsers.SelectedItem);
        }

        private void btnOtAdd_Click(object sender, EventArgs e)
        {
            fmSelectUser tmpfmSelectUser = new fmSelectUser();
            tmpfmSelectUser.ShowDialog();
            DialogResult dlr = tmpfmSelectUser.DialogResult;
            if (dlr == DialogResult.OK && tmpfmSelectUser.lvUser.SelectedItems.Count > 0)
            {
                string userid = tmpfmSelectUser.lvUser.SelectedItems[0].SubItems[0].Text;
                string username= tmpfmSelectUser.lvUser.SelectedItems[0].SubItems[1].Text;
                lbxOtMsgToUsers.Items.Add(userid + "|" + username);
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
            if (stf.ShowDialog() == DialogResult.OK)
            {
                tbxFiledName.Tag = stf.StrFieldidList;
                tbxFiledName.Text = stf.StrFieldNameList;
            }
        }

       

        
    }
}