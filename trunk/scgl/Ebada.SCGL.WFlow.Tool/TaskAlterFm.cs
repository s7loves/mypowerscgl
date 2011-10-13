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
using Ebada.Core;
using System.Reflection;


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
        public string UserModleId = "";//关联模块id
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
        private CheckBox cbxbindTable;
        private CheckBox cbxbindTask;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private ComboBox comTaskboBox;
        private Button btnModleClear;
        private Button btnFieldClear;
        private Button btnTableClear;
        private IContainer components;
        private TabPage tabPage7;
        private GroupBox groupBox11;
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
        private GroupBox groupBox10;
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
        private GroupBox groupBox9;
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
        private DevExpress.XtraEditors.TextEdit tetAttendManPos;
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
        private CheckBox cbxRiZhi;
        private DevExpress.XtraEditors.TextEdit tetWorkFixValue;
        private DevExpress.XtraEditors.TextEdit tetProjectFixValue;
        private DevExpress.XtraEditors.TextEdit tetCharManFixValue;
        private DevExpress.XtraEditors.TextEdit tetAttendManFixValue;
        private DevExpress.XtraEditors.TextEdit tetAttendManExcelName;
        private ComboBox cbxWorkDbTableColumns;
        private ComboBox cbxWorkDbTable;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private RadioButton rbnWorkDatabase;
        private ComboBox cbxProjectDbTableColumns;
        private ComboBox cbxProjectDbTable;
        private DevExpress.XtraEditors.LabelControl labelControl25;
        private DevExpress.XtraEditors.LabelControl labelControl26;
        private RadioButton rbnProjectDatabase;
        private ComboBox cbxCharManDbTableColumns;
        private ComboBox cbxCharManDbTable;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        private DevExpress.XtraEditors.LabelControl labelControl28;
        private RadioButton rbnCharManDatabase;
        private ComboBox cbxAttendManDbTableColumns;
        private ComboBox cbxAttendManDbTable;
        private DevExpress.XtraEditors.LabelControl labelControl30;
        private DevExpress.XtraEditors.LabelControl labelControl29;
        private RadioButton rbnAttendManDatabase;//处理人
        private string varDbTableName = "";
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
            this.btnModleClear = new System.Windows.Forms.Button();
            this.btnFieldClear = new System.Windows.Forms.Button();
            this.btnTableClear = new System.Windows.Forms.Button();
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
            this.comTaskboBox = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cbxDyAssignNext = new System.Windows.Forms.CheckBox();
            this.cbxAssign = new System.Windows.Forms.CheckBox();
            this.cbxbindTask = new System.Windows.Forms.CheckBox();
            this.cbxbindTable = new System.Windows.Forms.CheckBox();
            this.cbxReturn = new System.Windows.Forms.CheckBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.cbxRiZhi = new System.Windows.Forms.CheckBox();
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
            this.tabPage7.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkFixValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkExcelName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkPos.Properties)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tetProjectFixValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetProjectExcelName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetProjectPos.Properties)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tetCharManFixValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetCharManExcelName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetCharManPos.Properties)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tetAttendManFixValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetAttendManExcelName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetAttendManPos.Properties)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.tabControl1);
            this.plclassFill.Size = new System.Drawing.Size(550, 529);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 482);
            this.plclassBottom.Size = new System.Drawing.Size(550, 47);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(374, 12);
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(466, 12);
            this.btnClose.Text = "取消(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbOver);
            this.groupBox5.Controls.Add(this.rbRemain);
            this.groupBox5.Location = new System.Drawing.Point(10, 322);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(498, 49);
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
            this.tabPage6.Size = new System.Drawing.Size(528, 454);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "处理者";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // btnDeleteOpr
            // 
            this.btnDeleteOpr.Location = new System.Drawing.Point(266, 345);
            this.btnDeleteOpr.Name = "btnDeleteOpr";
            this.btnDeleteOpr.Size = new System.Drawing.Size(80, 23);
            this.btnDeleteOpr.TabIndex = 120;
            this.btnDeleteOpr.Text = "删除";
            this.btnDeleteOpr.Visible = false;
            this.btnDeleteOpr.Click += new System.EventHandler(this.btnDeleteOpr_Click);
            // 
            // btnModifyOpr
            // 
            this.btnModifyOpr.Location = new System.Drawing.Point(153, 345);
            this.btnModifyOpr.Name = "btnModifyOpr";
            this.btnModifyOpr.Size = new System.Drawing.Size(80, 23);
            this.btnModifyOpr.TabIndex = 119;
            this.btnModifyOpr.Text = "修改";
            this.btnModifyOpr.Visible = false;
            this.btnModifyOpr.Click += new System.EventHandler(this.btnModifyOpr_Click);
            // 
            // btnAddOpr
            // 
            this.btnAddOpr.Location = new System.Drawing.Point(53, 345);
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
            this.lvOper.Location = new System.Drawing.Point(53, 160);
            this.lvOper.Name = "lvOper";
            this.lvOper.Size = new System.Drawing.Size(449, 169);
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
            this.label5.Location = new System.Drawing.Point(51, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 113;
            this.label5.Text = "处理者:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtEveryUser);
            this.groupBox1.Controls.Add(this.rbtShareUser);
            this.groupBox1.Location = new System.Drawing.Point(53, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 96);
            this.groupBox1.TabIndex = 112;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "处理者策略";
            // 
            // rbtEveryUser
            // 
            this.rbtEveryUser.AutoSize = true;
            this.rbtEveryUser.Location = new System.Drawing.Point(149, 41);
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
            this.rbtShareUser.Location = new System.Drawing.Point(28, 41);
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
            this.cbxJumpSelf.Location = new System.Drawing.Point(53, 379);
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
            this.checkBox1.Location = new System.Drawing.Point(53, 401);
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
            this.tabPage3.Size = new System.Drawing.Size(528, 454);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "任务变量";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Visible = false;
            // 
            // lvVar
            // 
            this.lvVar.FullRowSelect = true;
            this.lvVar.Location = new System.Drawing.Point(47, 26);
            this.lvVar.MultiSelect = false;
            this.lvVar.Name = "lvVar";
            this.lvVar.Size = new System.Drawing.Size(462, 343);
            this.lvVar.TabIndex = 7;
            this.lvVar.UseCompatibleStateImageBehavior = false;
            this.lvVar.View = System.Windows.Forms.View.Details;
            this.lvVar.SelectedIndexChanged += new System.EventHandler(this.lvVar_SelectedIndexChanged);
            this.lvVar.DoubleClick += new System.EventHandler(this.btnModifyVar_Click);
            // 
            // btnDeleteVar
            // 
            this.btnDeleteVar.Location = new System.Drawing.Point(264, 392);
            this.btnDeleteVar.Name = "btnDeleteVar";
            this.btnDeleteVar.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteVar.TabIndex = 6;
            this.btnDeleteVar.Text = "删除";
            this.btnDeleteVar.UseVisualStyleBackColor = true;
            this.btnDeleteVar.Click += new System.EventHandler(this.btnDeleteVar_Click);
            // 
            // btnModifyVar
            // 
            this.btnModifyVar.Location = new System.Drawing.Point(147, 391);
            this.btnModifyVar.Name = "btnModifyVar";
            this.btnModifyVar.Size = new System.Drawing.Size(75, 23);
            this.btnModifyVar.TabIndex = 5;
            this.btnModifyVar.Text = "修改";
            this.btnModifyVar.UseVisualStyleBackColor = true;
            this.btnModifyVar.Click += new System.EventHandler(this.btnModifyVar_Click);
            // 
            // btnAddVar
            // 
            this.btnAddVar.Location = new System.Drawing.Point(47, 392);
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
            this.groupBox7.Size = new System.Drawing.Size(498, 297);
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
            this.label18.Location = new System.Drawing.Point(23, 120);
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
            this.pictureBox1.Location = new System.Drawing.Point(48, 33);
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
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(9, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(536, 479);
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
            this.tabPage1.Controls.Add(this.btnModleClear);
            this.tabPage1.Controls.Add(this.btnFieldClear);
            this.tabPage1.Controls.Add(this.btnTableClear);
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
            this.tabPage1.Size = new System.Drawing.Size(528, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "常规";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(105, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 134;
            this.label3.Text = "模块名:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(68, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 23);
            this.label14.TabIndex = 135;
            this.label14.Text = "可操作的字段:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(105, 108);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 23);
            this.label19.TabIndex = 136;
            this.label19.Text = "表单名:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxModleName
            // 
            this.tbxModleName.Location = new System.Drawing.Point(175, 81);
            this.tbxModleName.Name = "tbxModleName";
            this.tbxModleName.ReadOnly = true;
            this.tbxModleName.Size = new System.Drawing.Size(261, 21);
            this.tbxModleName.TabIndex = 133;
            // 
            // tbxFiledName
            // 
            this.tbxFiledName.Location = new System.Drawing.Point(175, 135);
            this.tbxFiledName.Name = "tbxFiledName";
            this.tbxFiledName.ReadOnly = true;
            this.tbxFiledName.Size = new System.Drawing.Size(261, 21);
            this.tbxFiledName.TabIndex = 132;
            // 
            // tbxFormName
            // 
            this.tbxFormName.Location = new System.Drawing.Point(175, 108);
            this.tbxFormName.Name = "tbxFormName";
            this.tbxFormName.ReadOnly = true;
            this.tbxFormName.Size = new System.Drawing.Size(261, 21);
            this.tbxFormName.TabIndex = 131;
            // 
            // btnModleClear
            // 
            this.btnModleClear.Image = global::Ebada.SCGL.WFlow.Tool.Properties.Resources.删除;
            this.btnModleClear.Location = new System.Drawing.Point(486, 80);
            this.btnModleClear.Name = "btnModleClear";
            this.btnModleClear.Size = new System.Drawing.Size(20, 23);
            this.btnModleClear.TabIndex = 128;
            this.btnModleClear.Tag = "清除";
            this.btnModleClear.Click += new System.EventHandler(this.btnModleClear_Click);
            // 
            // btnFieldClear
            // 
            this.btnFieldClear.Image = ((System.Drawing.Image)(resources.GetObject("btnFieldClear.Image")));
            this.btnFieldClear.Location = new System.Drawing.Point(486, 133);
            this.btnFieldClear.Name = "btnFieldClear";
            this.btnFieldClear.Size = new System.Drawing.Size(20, 23);
            this.btnFieldClear.TabIndex = 128;
            this.btnFieldClear.Tag = "清除";
            this.btnFieldClear.Click += new System.EventHandler(this.btnFieldClear_Click);
            // 
            // btnTableClear
            // 
            this.btnTableClear.Image = ((System.Drawing.Image)(resources.GetObject("btnTableClear.Image")));
            this.btnTableClear.Location = new System.Drawing.Point(486, 109);
            this.btnTableClear.Name = "btnTableClear";
            this.btnTableClear.Size = new System.Drawing.Size(20, 23);
            this.btnTableClear.TabIndex = 128;
            this.btnTableClear.Tag = "清除";
            this.btnTableClear.Click += new System.EventHandler(this.btnTableClear_Click);
            // 
            // btnSelectModle
            // 
            this.btnSelectModle.Location = new System.Drawing.Point(445, 80);
            this.btnSelectModle.Name = "btnSelectModle";
            this.btnSelectModle.Size = new System.Drawing.Size(41, 23);
            this.btnSelectModle.TabIndex = 128;
            this.btnSelectModle.Text = "...";
            this.btnSelectModle.Click += new System.EventHandler(this.btnSelectModle_Click);
            // 
            // btnSelctField
            // 
            this.btnSelctField.Location = new System.Drawing.Point(445, 135);
            this.btnSelctField.Name = "btnSelctField";
            this.btnSelctField.Size = new System.Drawing.Size(41, 23);
            this.btnSelctField.TabIndex = 129;
            this.btnSelctField.Text = "...";
            this.btnSelctField.Click += new System.EventHandler(this.btnSelctField_Click);
            // 
            // btnSelectCtrls
            // 
            this.btnSelectCtrls.Location = new System.Drawing.Point(445, 108);
            this.btnSelectCtrls.Name = "btnSelectCtrls";
            this.btnSelectCtrls.Size = new System.Drawing.Size(41, 23);
            this.btnSelectCtrls.TabIndex = 130;
            this.btnSelectCtrls.Text = "...";
            this.btnSelectCtrls.Click += new System.EventHandler(this.btnSelectCtrls_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 127;
            this.label2.Text = "处理:";
            // 
            // lvCommand
            // 
            this.lvCommand.FullRowSelect = true;
            this.lvCommand.Location = new System.Drawing.Point(70, 214);
            this.lvCommand.Name = "lvCommand";
            this.lvCommand.Size = new System.Drawing.Size(416, 185);
            this.lvCommand.SmallImageList = this.imgListSmall;
            this.lvCommand.TabIndex = 126;
            this.lvCommand.UseCompatibleStateImageBehavior = false;
            this.lvCommand.View = System.Windows.Forms.View.Details;
            this.lvCommand.DoubleClick += new System.EventHandler(this.btnModifycmd_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(97, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 23);
            this.label4.TabIndex = 125;
            this.label4.Text = "任务描述:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxTaskDes
            // 
            this.tbxTaskDes.Location = new System.Drawing.Point(177, 52);
            this.tbxTaskDes.Name = "tbxTaskDes";
            this.tbxTaskDes.Size = new System.Drawing.Size(259, 21);
            this.tbxTaskDes.TabIndex = 124;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(70, 194);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 2);
            this.groupBox2.TabIndex = 123;
            this.groupBox2.TabStop = false;
            // 
            // btnDeletecmd
            // 
            this.btnDeletecmd.Location = new System.Drawing.Point(304, 405);
            this.btnDeletecmd.Name = "btnDeletecmd";
            this.btnDeletecmd.Size = new System.Drawing.Size(80, 23);
            this.btnDeletecmd.TabIndex = 122;
            this.btnDeletecmd.Text = "删除";
            this.btnDeletecmd.Click += new System.EventHandler(this.btnDeletecmd_Click);
            // 
            // btnModifycmd
            // 
            this.btnModifycmd.Location = new System.Drawing.Point(182, 406);
            this.btnModifycmd.Name = "btnModifycmd";
            this.btnModifycmd.Size = new System.Drawing.Size(80, 23);
            this.btnModifycmd.TabIndex = 121;
            this.btnModifycmd.Text = "修改";
            this.btnModifycmd.Click += new System.EventHandler(this.btnModifycmd_Click);
            // 
            // btnAddcmd
            // 
            this.btnAddcmd.Location = new System.Drawing.Point(82, 406);
            this.btnAddcmd.Name = "btnAddcmd";
            this.btnAddcmd.Size = new System.Drawing.Size(80, 23);
            this.btnAddcmd.TabIndex = 118;
            this.btnAddcmd.Text = "增加";
            this.btnAddcmd.Click += new System.EventHandler(this.btnAddcmd_Click);
            // 
            // tbxTaskName
            // 
            this.tbxTaskName.Location = new System.Drawing.Point(177, 25);
            this.tbxTaskName.Name = "tbxTaskName";
            this.tbxTaskName.Size = new System.Drawing.Size(259, 21);
            this.tbxTaskName.TabIndex = 116;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(97, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 23);
            this.label1.TabIndex = 115;
            this.label1.Text = "任务名称:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.comTaskboBox);
            this.tabPage5.Controls.Add(this.labelControl1);
            this.tabPage5.Controls.Add(this.cbxDyAssignNext);
            this.tabPage5.Controls.Add(this.cbxAssign);
            this.tabPage5.Controls.Add(this.cbxbindTask);
            this.tabPage5.Controls.Add(this.cbxbindTable);
            this.tabPage5.Controls.Add(this.cbxReturn);
            this.tabPage5.Location = new System.Drawing.Point(4, 21);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(528, 454);
            this.tabPage5.TabIndex = 6;
            this.tabPage5.Text = "控制权限";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // comTaskboBox
            // 
            this.comTaskboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comTaskboBox.FormattingEnabled = true;
            this.comTaskboBox.Location = new System.Drawing.Point(111, 51);
            this.comTaskboBox.Name = "comTaskboBox";
            this.comTaskboBox.Size = new System.Drawing.Size(99, 20);
            this.comTaskboBox.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(218, 54);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "数据";
            // 
            // cbxDyAssignNext
            // 
            this.cbxDyAssignNext.AutoSize = true;
            this.cbxDyAssignNext.Location = new System.Drawing.Point(35, 96);
            this.cbxDyAssignNext.Name = "cbxDyAssignNext";
            this.cbxDyAssignNext.Size = new System.Drawing.Size(180, 16);
            this.cbxDyAssignNext.TabIndex = 2;
            this.cbxDyAssignNext.Text = "允许动态指定一下任务处理人";
            this.cbxDyAssignNext.UseVisualStyleBackColor = true;
            this.cbxDyAssignNext.Visible = false;
            // 
            // cbxAssign
            // 
            this.cbxAssign.AutoSize = true;
            this.cbxAssign.Location = new System.Drawing.Point(35, 73);
            this.cbxAssign.Name = "cbxAssign";
            this.cbxAssign.Size = new System.Drawing.Size(120, 16);
            this.cbxAssign.TabIndex = 1;
            this.cbxAssign.Text = "允许指派他人处理";
            this.cbxAssign.UseVisualStyleBackColor = true;
            this.cbxAssign.Visible = false;
            // 
            // cbxbindTask
            // 
            this.cbxbindTask.AutoSize = true;
            this.cbxbindTask.Location = new System.Drawing.Point(35, 53);
            this.cbxbindTask.Name = "cbxbindTask";
            this.cbxbindTask.Size = new System.Drawing.Size(72, 16);
            this.cbxbindTask.TabIndex = 0;
            this.cbxbindTask.Text = "基于节点";
            this.cbxbindTask.UseVisualStyleBackColor = true;
            // 
            // cbxbindTable
            // 
            this.cbxbindTable.AutoSize = true;
            this.cbxbindTable.Location = new System.Drawing.Point(35, 33);
            this.cbxbindTable.Name = "cbxbindTable";
            this.cbxbindTable.Size = new System.Drawing.Size(180, 16);
            this.cbxbindTable.TabIndex = 0;
            this.cbxbindTable.Text = "关联流程内本表单的相关数据";
            this.cbxbindTable.UseVisualStyleBackColor = true;
            // 
            // cbxReturn
            // 
            this.cbxReturn.AutoSize = true;
            this.cbxReturn.Location = new System.Drawing.Point(35, 17);
            this.cbxReturn.Name = "cbxReturn";
            this.cbxReturn.Size = new System.Drawing.Size(72, 16);
            this.cbxReturn.TabIndex = 0;
            this.cbxReturn.Text = "允许退回";
            this.cbxReturn.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.cbxRiZhi);
            this.tabPage7.Controls.Add(this.groupBox11);
            this.tabPage7.Controls.Add(this.groupBox10);
            this.tabPage7.Controls.Add(this.groupBox9);
            this.tabPage7.Controls.Add(this.groupBox8);
            this.tabPage7.Location = new System.Drawing.Point(4, 21);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(528, 454);
            this.tabPage7.TabIndex = 7;
            this.tabPage7.Text = "日志功能";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // cbxRiZhi
            // 
            this.cbxRiZhi.AutoSize = true;
            this.cbxRiZhi.Location = new System.Drawing.Point(15, 5);
            this.cbxRiZhi.Name = "cbxRiZhi";
            this.cbxRiZhi.Size = new System.Drawing.Size(72, 16);
            this.cbxRiZhi.TabIndex = 28;
            this.cbxRiZhi.Text = "开启日志";
            this.cbxRiZhi.UseVisualStyleBackColor = true;
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
            this.groupBox11.Location = new System.Drawing.Point(13, 14);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(509, 111);
            this.groupBox11.TabIndex = 27;
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
            this.rbnWorkExcel.Location = new System.Drawing.Point(153, 44);
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
            this.groupBox10.Location = new System.Drawing.Point(13, 120);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(510, 97);
            this.groupBox10.TabIndex = 26;
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
            this.rbnProjectExcel.Location = new System.Drawing.Point(153, 32);
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
            this.groupBox9.Location = new System.Drawing.Point(13, 220);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(509, 105);
            this.groupBox9.TabIndex = 25;
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
            this.groupBox8.Location = new System.Drawing.Point(13, 325);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(510, 118);
            this.groupBox8.TabIndex = 24;
            this.groupBox8.TabStop = false;
            // 
            // cbxAttendManDbTableColumns
            // 
            this.cbxAttendManDbTableColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAttendManDbTableColumns.FormattingEnabled = true;
            this.cbxAttendManDbTableColumns.Location = new System.Drawing.Point(404, 86);
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
            this.cbxAttendManDbTable.Location = new System.Drawing.Point(405, 64);
            this.cbxAttendManDbTable.Name = "cbxAttendManDbTable";
            this.cbxAttendManDbTable.Size = new System.Drawing.Size(99, 20);
            this.cbxAttendManDbTable.TabIndex = 51;
            this.cbxAttendManDbTable.SelectedIndexChanged += new System.EventHandler(this.cbxAttendManDbTable_SelectedIndexChanged);
            // 
            // labelControl30
            // 
            this.labelControl30.Location = new System.Drawing.Point(355, 88);
            this.labelControl30.Name = "labelControl30";
            this.labelControl30.Size = new System.Drawing.Size(36, 14);
            this.labelControl30.TabIndex = 48;
            this.labelControl30.Text = "字段：";
            // 
            // tetAttendManExcelName
            // 
            this.tetAttendManExcelName.Location = new System.Drawing.Point(242, 60);
            this.tetAttendManExcelName.Name = "tetAttendManExcelName";
            this.tetAttendManExcelName.Size = new System.Drawing.Size(110, 21);
            this.tetAttendManExcelName.TabIndex = 36;
            // 
            // labelControl29
            // 
            this.labelControl29.Location = new System.Drawing.Point(356, 66);
            this.labelControl29.Name = "labelControl29";
            this.labelControl29.Size = new System.Drawing.Size(36, 14);
            this.labelControl29.TabIndex = 49;
            this.labelControl29.Text = "表名：";
            // 
            // tetAttendManPos
            // 
            this.tetAttendManPos.Location = new System.Drawing.Point(242, 86);
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
            this.rbnAttendManDatabase.Location = new System.Drawing.Point(354, 43);
            this.rbnAttendManDatabase.Name = "rbnAttendManDatabase";
            this.rbnAttendManDatabase.Size = new System.Drawing.Size(83, 16);
            this.rbnAttendManDatabase.TabIndex = 47;
            this.rbnAttendManDatabase.Text = "从数据库取";
            this.rbnAttendManDatabase.UseVisualStyleBackColor = true;
            // 
            // labelControl22
            // 
            this.labelControl22.Location = new System.Drawing.Point(159, 89);
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
            this.cbxAttendManTableColumns.Location = new System.Drawing.Point(47, 85);
            this.cbxAttendManTableColumns.Name = "cbxAttendManTableColumns";
            this.cbxAttendManTableColumns.Size = new System.Drawing.Size(99, 20);
            this.cbxAttendManTableColumns.TabIndex = 30;
            // 
            // cbxAttendManDataTable
            // 
            this.cbxAttendManDataTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAttendManDataTable.FormattingEnabled = true;
            this.cbxAttendManDataTable.Location = new System.Drawing.Point(48, 61);
            this.cbxAttendManDataTable.Name = "cbxAttendManDataTable";
            this.cbxAttendManDataTable.Size = new System.Drawing.Size(99, 20);
            this.cbxAttendManDataTable.TabIndex = 31;
            this.cbxAttendManDataTable.SelectedIndexChanged += new System.EventHandler(this.cbxAttendManDataTable_SelectedIndexChanged);
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(-2, 87);
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
            this.labelControl20.Location = new System.Drawing.Point(170, 64);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(60, 14);
            this.labelControl20.TabIndex = 26;
            this.labelControl20.Text = "工作表名：";
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(-1, 63);
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
            this.rbnAttendManExcel.Location = new System.Drawing.Point(152, 41);
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(528, 454);
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
            this.tabPage4.Size = new System.Drawing.Size(528, 454);
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
            this.groupBox3.Location = new System.Drawing.Point(14, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(497, 222);
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
            this.groupBox6.Size = new System.Drawing.Size(497, 197);
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
            this.ClientSize = new System.Drawing.Size(550, 529);
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
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkFixValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkExcelName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkPos.Properties)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tetProjectFixValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetProjectExcelName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetProjectPos.Properties)).EndInit();
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
            //*********模块
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
            //*********表单
            DataTable ctrlTable = WorkFlowTask.GetTaskControls(NowTask.TaskId);
            if (ctrlTable != null && ctrlTable.Rows.Count > 0)
            {
                //tbxFormName.Text = ctrlTable.Rows[0]["mucCaption"].ToString();
                //UserControlId = ctrlTable.Rows[0]["UserControlId"].ToString();
                tbxFormName.Text = ctrlTable.Rows[0]["CellName"].ToString();
                UserControlId = ctrlTable.Rows[0]["LPID"].ToString();
            }
            //*********可操作字段
            if (UserControlId != "节点审核")
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
                tbxFiledName.Text = "不可用";
                tbxFiledName.Tag = null;
            }
            //*********控制权限
            DataTable powerTable = WorkFlowTask.GetTaskPower(NowTask.WorkFlowId, NowTask.TaskId);
            string powerStr = "";
            foreach (DataRow dr in powerTable.Rows)
            {
                powerStr = powerStr + dr["PowerName"].ToString()+",";
            }
            cbxReturn.Checked = powerStr.IndexOf(WorkConst.WorkTask_Return) > -1;//退回
            cbxbindTable.Checked = powerStr.IndexOf(WorkConst.WorkTask_BindTable) > -1;//绑定表单内容
            cbxbindTask.Checked = powerStr.IndexOf(WorkConst.WorkTask_BindTask) > -1;//基于节点内容
            cbxAssign.Checked = powerStr.IndexOf(WorkConst.WorkTask_Assign) > -1;//指派
            cbxRiZhi.Checked = powerStr.IndexOf(WorkConst.WorkTask_WorkRiZhi) > -1;//工作日志
            cbxDyAssignNext.Checked = powerStr.IndexOf(WorkConst.WorkTask_DyAssignNext) > -1;//动态指定下一任务处理人
            iniBindTask();
            //*********日志控制
            iniRiZhiData();
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
        private void iniRiZhiTablelcbxData(ComboBox cbxtable, ComboBox cbxtablefield, string taskID, string tableID, string fieldID)
        {
            //string tmpStr = " where ParentID not in (select LPID from LP_Temple where 1=1) ";

            //IList li = MainHelper.PlatformSqlMap.GetList("SelectLP_TempleList", tmpStr);
            //DataTable dt = ConvertHelper.ToDataTable(li);
            DataTable dt = null;
            IList li;
            if (UserControlId != ""&&UserControlId!="节点审核")
            {
                if (dt == null)
                {
                    dt = new DataTable();
                    dt.Columns.Add("LPID", typeof(string));
                    dt.Columns.Add("CellName", typeof(string));
                }
              
                    DataRow dr = dt.NewRow();
                    dr["LPID"] = UserControlId;
                    dr["CellName"] = tbxFormName.Text ;
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
        private void iniRiZhiDbcbxData(ComboBox cbxtable, ComboBox cbxtablefield,string varDbTableName, string tablename, string fieldID)
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
                    dt.Columns.Add("name",typeof(string));
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
            WF_TaskVar tv = WorkFlowTask.GetTaskRiZhiVar(NowTask.TaskId,"工作地点");
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
                    rbnWorkTable.Checked = true;
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
            else {

                iniRiZhiTablelcbxData(cbxWorkDataTable, cbxWorkTableColumns, NowTask.TaskId, UserControlId, "");
                iniRiZhiDbcbxData(cbxWorkDbTable, cbxWorkDbTableColumns, varDbTableName, "","");
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
                    rbnProjectTable.Checked = true;
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
                    rbnCharManTable.Checked = true;
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
                iniRiZhiTablelcbxData(cbxCharManDataTable, cbxCharManTableColumns, NowTask.TaskId, UserControlId,"");
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
                    rbnAttendManTable.Checked = true;
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
            else {

                iniRiZhiTablelcbxData(cbxAttendManDataTable, cbxAttendManTableColumns, NowTask.TaskId, UserControlId, "");
                iniRiZhiDbcbxData(cbxAttendManDbTable, cbxAttendManDbTableColumns, varDbTableName, "", "");
            }
        }
        private void iniBindTask()
        {
            Hashtable hs = new Hashtable();
            GetFormTask(NowTask.TaskId,NowTask.WorkFlowId,ref hs);
            ArrayList akeys=new ArrayList(hs.Keys);
            string taskcaption = "";
            for (int i = 0; i < akeys.Count; i++)
            {
                taskcaption= hs[akeys[i]] as string;
                ListItem item = new ListItem(akeys[i].ToString(),taskcaption);
                comTaskboBox.Items.Add(item);
            }
            if (comTaskboBox.Items.Count > 0) comTaskboBox.SelectedIndex = 0;
            DataTable binddt = WorkFlowTask.GetTaskBindTaskContent(NowTask.TaskId);
            if (binddt.Rows.Count > 0)
            {
                WF_WorkTask wt = MainHelper.PlatformSqlMap.GetOneByKey<WF_WorkTask>(binddt.Rows[0]["UserControlId"]);
                if (wt != null)
                {
                    comTaskboBox.Text = wt.TaskCaption;
                    for (int i = 0; i < comTaskboBox.Items.Count;i++ )
                    {
                        ListItem item =comTaskboBox.Items[i] as ListItem;
                        if (item.ID==wt.WorkTaskId)
                        {

                            comTaskboBox.SelectedIndex = i;
                            comTaskboBox.SelectedItem = item;
                            break;
                        }
                    }
                       
                }

            }
        }
        private void GetFormTask(string taskid, string workFlowId, ref Hashtable taskht)
        {
            
            string tmpStr = " where  EndTaskId='" + taskid + "' and WorkFlowId='" + workFlowId + "'";
            IList<WF_WorkTaskLinkView> li = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskLinkView>("SelectWF_WorkTaskLinkViewList", tmpStr);
            foreach (WF_WorkTaskLinkView tl in li)
            {
                if (!taskht.ContainsKey(tl.StartTaskId))
                taskht.Add(tl.StartTaskId, tl.startTaskCaption);
                GetFormTask(tl.StartTaskId, workFlowId, ref  taskht);
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
            if (UserControlId != "") WorkFlowTask.SetTaskUserCtrls(UserControlId, NowTask.WorkFlowId, NowTask.TaskId);
            //保存关联模块
            WorkFlowTask.DeleteAllModle(NowTask.TaskId);
            if (UserModleId!="") WorkFlowTask.SetTaskUserModle(UserModleId, NowTask.WorkFlowId, NowTask.TaskId);

            //保存控制权限
            WorkFlowTask.DeleteAllPower(NowTask.WorkFlowId, NowTask.TaskId);
            if (cbxReturn.Checked)
                WorkFlowTask.SetTaskPower(WorkConst.WorkTask_Return, NowTask.WorkFlowId, NowTask.TaskId);
            if (cbxbindTable.Checked)
                WorkFlowTask.SetTaskPower(WorkConst.WorkTask_BindTable, NowTask.WorkFlowId, NowTask.TaskId);
            if (cbxbindTask.Checked)
            {
                WorkFlowTask.SetTaskPower(WorkConst.WorkTask_BindTask, NowTask.WorkFlowId, NowTask.TaskId);
                WorkFlowTask.SetTaskBindTaskContent(((ListItem)comTaskboBox.SelectedItem).ID, NowTask.WorkFlowId, NowTask.TaskId);
            }
            if (cbxAssign.Checked)
            WorkFlowTask.SetTaskPower(WorkConst.WorkTask_Assign, NowTask.WorkFlowId, NowTask.TaskId);
            if (cbxDyAssignNext.Checked)
                WorkFlowTask.SetTaskPower(WorkConst.WorkTask_DyAssignNext, NowTask.WorkFlowId, NowTask.TaskId);
            if (cbxRiZhi.Checked)
            {
                WorkFlowTask.SetTaskPower(WorkConst.WorkTask_WorkRiZhi, NowTask.WorkFlowId, NowTask.TaskId);
                SaveRiZhiData();
            }
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
        private void SaveRiZhiData()
        {
            TaskVar tv = new TaskVar();
            tv.WorkFlowId = NowTask.WorkFlowId;
            tv.WorkTaskId = NowTask.TaskId;
                tv.VarName = "工作地点";
                tv.AccessType = WorkConst.WorkTask_WorkRiZhi;
                if ( rbnWorkFixValue.Checked == true)
                {
                    tv.VarModule = "固定值";
                    tv.InitValue=tetWorkFixValue.Text ;
                }
                else if ( rbnWorkTable.Checked == true)
                {
                    tv.VarModule = "表单";
                    tv.TableName=((ListItem)cbxWorkDataTable.SelectedItem).ID;
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
                    tv.VarModule ="固定值";
                    tv.InitValue=tetProjectFixValue.Text;
                }
                else if (rbnProjectTable.Checked == true)
                {
                    
                    tv.VarModule = "表单";
                    tv.TableName=((ListItem)cbxProjectDataTable.SelectedItem).ID;
                    tv.TableField=((ListItem)cbxProjectTableColumns.SelectedItem).ID;
                }
                else if (rbnProjectExcel.Checked == true)
                {
                    
                    tv.VarModule = "Excel";
                    tv.TableName=tetProjectExcelName.Text;
                    tv.TableField=tetProjectPos.Text;
                }
                else if (rbnProjectDatabase.Checked == true)
                {

                   
                    tv.VarModule = "数据库";
                    tv.TableName=((ListItem)cbxProjectDbTable.SelectedItem).ID;
                    tv.TableField=((ListItem)cbxProjectDbTableColumns.SelectedItem).ID;
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
                if ( rbnCharManFixValue.Checked ==true)
                {
                    tv.VarModule = "固定值";
                    tetCharManFixValue.Text = tv.InitValue;
                } 
                else if ( rbnCharManTable.Checked == true)
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

                    tv.VarModule ="数据库";
                    tv.TableName =((ListItem) cbxCharManDbTable.SelectedItem).ID;
                    tv.TableField =((ListItem) cbxCharManDbTableColumns.SelectedItem).ID;
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
                if ( rbnAttendManFixValue.Checked == true)
                {
                    tv.VarModule = "固定值";
                    tv.InitValue=tetAttendManFixValue.Text;
                }
                else if ( rbnAttendManTable.Checked == true)
                {
                    tv.VarModule ="表单";
                    tv.TableName = ((ListItem)cbxAttendManDataTable.SelectedItem).ID;
                    tv.TableField =((ListItem) cbxAttendManTableColumns.SelectedItem).ID;
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
                    tv.TableName =((ListItem) cbxAttendManDbTable.SelectedItem).ID;
                    tv.TableField = ((ListItem)cbxAttendManDbTableColumns.SelectedItem).ID;
                }
            }
            tv.InsertTaskVar();
        
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
                iniRiZhiData();
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
                iniRiZhiData();
            }
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
                object fromCtrl = CreatNewMoldeIns(obj.AssemblyFileName,obj.ModuTypes,obj.MethodName,obj.ModuName);

                if (fromCtrl.GetType().GetProperty("VarDbTableName") != null && fromCtrl.GetType().GetProperty("VarDbTableName").GetValue(fromCtrl, null) != null)
                    varDbTableName = fromCtrl.GetType().GetProperty("VarDbTableName").GetValue(fromCtrl, null).ToString();
                else
                {
                    MsgBox.ShowWarningMessageBox("模块不支持，请咨询开发人员!");
                    return;
                }
                if (obj != null && obj.ModuTypes.IndexOf("frmLP") == -1)
                {
                    UserControlId = "节点审核";
                    tbxFormName.Text = "节点提交";

                    tbxFiledName.Tag = null;
                    tbxFiledName.Text = "不可用";
                    label2.Text = "处理(任务命令可用代码{01：代表调用提交文件模块，02：手动结束}):";
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
                iniRiZhiData();
            }
        }

        private void btnModleClear_Click(object sender, EventArgs e)
        {
            //保存关联模块
            WorkFlowTask.DeleteAllModle(NowTask.TaskId);
            WorkFlowTask.DeleteAllModleField(NowTask.WorkFlowId,NowTask.TaskId);
            UserModleId = "";
            tbxModleName.Text = "";
        }

        private void btnTableClear_Click(object sender, EventArgs e)
        {
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


            WorkFlowTask.DeleteAllTableField(NowTask.WorkFlowId, NowTask.TaskId);
            tbxFiledName.Tag = null;
            tbxFiledName.Text = "";
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
            IList li = MainHelper.PlatformSqlMap.GetList("GetTableColumns", ((ListItem)cbxProjectDbTable.SelectedItem).ID );
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
            IList li = MainHelper.PlatformSqlMap.GetList("GetTableColumns",((ListItem)cbxCharManDbTable.SelectedItem).ID );
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
            IList li = MainHelper.PlatformSqlMap.GetList("GetTableColumns",((ListItem)cbxAttendManDbTable.SelectedItem).ID);
            DataTable dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxAttendManDbTableColumns, dt, "name", "name");
            cbxAttendManDbTableColumns.SelectedIndex = 0;
        }

     

 
       

      

      

    
     
      

       

        
    }
}