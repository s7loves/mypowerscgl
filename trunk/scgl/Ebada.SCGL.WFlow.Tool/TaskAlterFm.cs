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
using System.Text.RegularExpressions;


namespace Ebada.SCGL.WFlow.Tool
{
    /// <summary>
    /// TaskAlterFm ��ժҪ˵����
    /// </summary>
    public class fmTaskAlter : BaseForm_Single
    {
        public AlternateTask NowTask;
        public string UserId = "";//�������˺ţ�����Ȩ���жϡ�
        public string UserName = "";//������������������ʾ��
        public string UserControlId = "";//������id
        public string UserModleId = "";//����ģ��id
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
        private CheckBox cbxTaskAllExplore;
        private CheckBox cbxTaskExplore;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private CheckBox cbxRiZhi;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.CheckEdit ceBind;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.MemoEdit tetWorkFixValue;
        private DevExpress.XtraEditors.MemoEdit tetWorkSQL;
        private ComboBox cbxWorkDbTableColumns;
        private ComboBox cbxWorkDbTable;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private RadioButton rbnWorkDatabase;
        private DevExpress.XtraEditors.TextEdit cbxWorkExcelTable;
        private DevExpress.XtraEditors.TextEdit tetWorkPos;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private ComboBox cbxWorkTableColumns;
        private ComboBox columnBox;
        private ComboBox cbxWorkDataTable;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private RadioButton rbnWorkFixValue;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private RadioButton rbnWorkExcel;
        private RadioButton rbnWorkTable;//������
        private string varDbTableName = "";
        private DataTable rizdt = null;
        public fmTaskAlter(AlternateTask alterTask, string userId, string userName)
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();
            NowTask = alterTask;
            this.UserId = userId;
            this.UserName = userName;

            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
        }

        /// <summary>
        /// ������������ʹ�õ���Դ��
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

        #region Windows ������������ɵĴ���
        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
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
            this.cbxTaskAllExplore = new System.Windows.Forms.CheckBox();
            this.cbxTaskExplore = new System.Windows.Forms.CheckBox();
            this.cbxReturn = new System.Windows.Forms.CheckBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cbxRiZhi = new System.Windows.Forms.CheckBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.ceBind = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.tetWorkFixValue = new DevExpress.XtraEditors.MemoEdit();
            this.tetWorkSQL = new DevExpress.XtraEditors.MemoEdit();
            this.cbxWorkDbTableColumns = new System.Windows.Forms.ComboBox();
            this.cbxWorkDbTable = new System.Windows.Forms.ComboBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.rbnWorkDatabase = new System.Windows.Forms.RadioButton();
            this.cbxWorkExcelTable = new DevExpress.XtraEditors.TextEdit();
            this.tetWorkPos = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.cbxWorkTableColumns = new System.Windows.Forms.ComboBox();
            this.columnBox = new System.Windows.Forms.ComboBox();
            this.cbxWorkDataTable = new System.Windows.Forms.ComboBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.rbnWorkFixValue = new System.Windows.Forms.RadioButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.rbnWorkExcel = new System.Windows.Forms.RadioButton();
            this.rbnWorkTable = new System.Windows.Forms.RadioButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceBind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkFixValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkSQL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxWorkExcelTable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkPos.Properties)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.tabControl1);
            this.plclassFill.Size = new System.Drawing.Size(553, 529);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 491);
            this.plclassBottom.Size = new System.Drawing.Size(553, 38);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(374, 3);
            this.btnSave.Text = "ȷ��(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(466, 3);
            this.btnClose.Text = "ȡ��(&C)";
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
            this.groupBox5.Text = "��ʱ����";
            // 
            // rbOver
            // 
            this.rbOver.Enabled = false;
            this.rbOver.Location = new System.Drawing.Point(188, 23);
            this.rbOver.Name = "rbOver";
            this.rbOver.Size = new System.Drawing.Size(112, 23);
            this.rbOver.TabIndex = 2;
            this.rbOver.Text = "�������ڵ㴦��";
            // 
            // rbRemain
            // 
            this.rbRemain.Enabled = false;
            this.rbRemain.Location = new System.Drawing.Point(12, 20);
            this.rbRemain.Name = "rbRemain";
            this.rbRemain.Size = new System.Drawing.Size(112, 23);
            this.rbRemain.TabIndex = 1;
            this.rbRemain.Text = "�������ڵ㴦��";
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
            this.tabPage6.Size = new System.Drawing.Size(536, 466);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "������";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // btnDeleteOpr
            // 
            this.btnDeleteOpr.Location = new System.Drawing.Point(266, 374);
            this.btnDeleteOpr.Name = "btnDeleteOpr";
            this.btnDeleteOpr.Size = new System.Drawing.Size(80, 23);
            this.btnDeleteOpr.TabIndex = 120;
            this.btnDeleteOpr.Text = "ɾ��";
            this.btnDeleteOpr.Visible = false;
            this.btnDeleteOpr.Click += new System.EventHandler(this.btnDeleteOpr_Click);
            // 
            // btnModifyOpr
            // 
            this.btnModifyOpr.Location = new System.Drawing.Point(153, 374);
            this.btnModifyOpr.Name = "btnModifyOpr";
            this.btnModifyOpr.Size = new System.Drawing.Size(80, 23);
            this.btnModifyOpr.TabIndex = 119;
            this.btnModifyOpr.Text = "�޸�";
            this.btnModifyOpr.Visible = false;
            this.btnModifyOpr.Click += new System.EventHandler(this.btnModifyOpr_Click);
            // 
            // btnAddOpr
            // 
            this.btnAddOpr.Location = new System.Drawing.Point(53, 374);
            this.btnAddOpr.Name = "btnAddOpr";
            this.btnAddOpr.Size = new System.Drawing.Size(80, 23);
            this.btnAddOpr.TabIndex = 118;
            this.btnAddOpr.Text = "����";
            this.btnAddOpr.Visible = false;
            this.btnAddOpr.Click += new System.EventHandler(this.btnAddOpr_Click);
            // 
            // lvOper
            // 
            this.lvOper.FullRowSelect = true;
            this.lvOper.Location = new System.Drawing.Point(53, 160);
            this.lvOper.Name = "lvOper";
            this.lvOper.Size = new System.Drawing.Size(449, 208);
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
            this.label5.Text = "������:";
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
            this.groupBox1.Text = "�����߲���";
            // 
            // rbtEveryUser
            // 
            this.rbtEveryUser.AutoSize = true;
            this.rbtEveryUser.Location = new System.Drawing.Point(149, 41);
            this.rbtEveryUser.Name = "rbtEveryUser";
            this.rbtEveryUser.Size = new System.Drawing.Size(131, 16);
            this.rbtEveryUser.TabIndex = 1;
            this.rbtEveryUser.Text = "�����û�����(��ǩ)";
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
            this.rbtShareUser.Text = "�����û�����";
            this.rbtShareUser.UseVisualStyleBackColor = true;
            // 
            // cbxJumpSelf
            // 
            this.cbxJumpSelf.AutoSize = true;
            this.cbxJumpSelf.Location = new System.Drawing.Point(53, 408);
            this.cbxJumpSelf.Name = "cbxJumpSelf";
            this.cbxJumpSelf.Size = new System.Drawing.Size(180, 16);
            this.cbxJumpSelf.TabIndex = 111;
            this.cbxJumpSelf.Text = "���������ύ��������������";
            this.cbxJumpSelf.UseVisualStyleBackColor = true;
            this.cbxJumpSelf.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(53, 430);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(168, 16);
            this.checkBox1.TabIndex = 110;
            this.checkBox1.Text = "�޶�Ӧ������������������";
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
            this.menuItem1.Text = "���";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "�޸�";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "ɾ��";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lvVar);
            this.tabPage3.Controls.Add(this.btnDeleteVar);
            this.tabPage3.Controls.Add(this.btnModifyVar);
            this.tabPage3.Controls.Add(this.btnAddVar);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(536, 466);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "�������";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Visible = false;
            // 
            // lvVar
            // 
            this.lvVar.FullRowSelect = true;
            this.lvVar.Location = new System.Drawing.Point(47, 26);
            this.lvVar.MultiSelect = false;
            this.lvVar.Name = "lvVar";
            this.lvVar.Size = new System.Drawing.Size(462, 388);
            this.lvVar.TabIndex = 7;
            this.lvVar.UseCompatibleStateImageBehavior = false;
            this.lvVar.View = System.Windows.Forms.View.Details;
            this.lvVar.SelectedIndexChanged += new System.EventHandler(this.lvVar_SelectedIndexChanged);
            this.lvVar.DoubleClick += new System.EventHandler(this.btnModifyVar_Click);
            // 
            // btnDeleteVar
            // 
            this.btnDeleteVar.Location = new System.Drawing.Point(267, 421);
            this.btnDeleteVar.Name = "btnDeleteVar";
            this.btnDeleteVar.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteVar.TabIndex = 6;
            this.btnDeleteVar.Text = "ɾ��";
            this.btnDeleteVar.UseVisualStyleBackColor = true;
            this.btnDeleteVar.Click += new System.EventHandler(this.btnDeleteVar_Click);
            // 
            // btnModifyVar
            // 
            this.btnModifyVar.Location = new System.Drawing.Point(150, 420);
            this.btnModifyVar.Name = "btnModifyVar";
            this.btnModifyVar.Size = new System.Drawing.Size(75, 23);
            this.btnModifyVar.TabIndex = 5;
            this.btnModifyVar.Text = "�޸�";
            this.btnModifyVar.UseVisualStyleBackColor = true;
            this.btnModifyVar.Click += new System.EventHandler(this.btnModifyVar_Click);
            // 
            // btnAddVar
            // 
            this.btnAddVar.Location = new System.Drawing.Point(50, 421);
            this.btnAddVar.Name = "btnAddVar";
            this.btnAddVar.Size = new System.Drawing.Size(75, 23);
            this.btnAddVar.TabIndex = 4;
            this.btnAddVar.Text = "����";
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
            this.groupBox7.Text = "��ʱ����";
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
            this.label18.Text = "˵��:���������������Ҫ��ʱ�䡣";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(299, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 12);
            this.label15.TabIndex = 28;
            this.label15.Text = "��";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(227, 88);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 26;
            this.label16.Text = "ʱ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(153, 88);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 24;
            this.label17.Text = "��";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(299, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "��";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(227, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 17;
            this.label12.Text = "ʱ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(153, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 15;
            this.label13.Text = "��";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(299, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "��";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(227, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "ʱ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "��";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(25, 27);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(48, 16);
            this.checkBox4.TabIndex = 2;
            this.checkBox4.Text = "��ͨ";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(25, 56);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(48, 16);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "����";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // cbxInstancy
            // 
            this.cbxInstancy.AutoSize = true;
            this.cbxInstancy.Location = new System.Drawing.Point(25, 84);
            this.cbxInstancy.Name = "cbxInstancy";
            this.cbxInstancy.Size = new System.Drawing.Size(48, 16);
            this.cbxInstancy.TabIndex = 0;
            this.cbxInstancy.Text = "�ؼ�";
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
            this.tabControl1.Size = new System.Drawing.Size(544, 491);
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
            this.tabPage1.Size = new System.Drawing.Size(536, 466);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "����";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(105, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 134;
            this.label3.Text = "ģ����:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(68, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 23);
            this.label14.TabIndex = 135;
            this.label14.Text = "�ɲ������ֶ�:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(105, 108);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 23);
            this.label19.TabIndex = 136;
            this.label19.Text = "����:";
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
            this.btnModleClear.Image = global::Ebada.SCGL.WFlow.Tool.Properties.Resources.ɾ��;
            this.btnModleClear.Location = new System.Drawing.Point(486, 80);
            this.btnModleClear.Name = "btnModleClear";
            this.btnModleClear.Size = new System.Drawing.Size(20, 23);
            this.btnModleClear.TabIndex = 128;
            this.btnModleClear.Tag = "���";
            this.btnModleClear.Click += new System.EventHandler(this.btnModleClear_Click);
            // 
            // btnFieldClear
            // 
            this.btnFieldClear.Image = ((System.Drawing.Image)(resources.GetObject("btnFieldClear.Image")));
            this.btnFieldClear.Location = new System.Drawing.Point(486, 133);
            this.btnFieldClear.Name = "btnFieldClear";
            this.btnFieldClear.Size = new System.Drawing.Size(20, 23);
            this.btnFieldClear.TabIndex = 128;
            this.btnFieldClear.Tag = "���";
            this.btnFieldClear.Click += new System.EventHandler(this.btnFieldClear_Click);
            // 
            // btnTableClear
            // 
            this.btnTableClear.Image = ((System.Drawing.Image)(resources.GetObject("btnTableClear.Image")));
            this.btnTableClear.Location = new System.Drawing.Point(486, 109);
            this.btnTableClear.Name = "btnTableClear";
            this.btnTableClear.Size = new System.Drawing.Size(20, 23);
            this.btnTableClear.TabIndex = 128;
            this.btnTableClear.Tag = "���";
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
            this.label2.Text = "����:";
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
            this.label4.Text = "��������:";
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
            this.btnDeletecmd.Text = "ɾ��";
            this.btnDeletecmd.Click += new System.EventHandler(this.btnDeletecmd_Click);
            // 
            // btnModifycmd
            // 
            this.btnModifycmd.Location = new System.Drawing.Point(182, 406);
            this.btnModifycmd.Name = "btnModifycmd";
            this.btnModifycmd.Size = new System.Drawing.Size(80, 23);
            this.btnModifycmd.TabIndex = 121;
            this.btnModifycmd.Text = "�޸�";
            this.btnModifycmd.Click += new System.EventHandler(this.btnModifycmd_Click);
            // 
            // btnAddcmd
            // 
            this.btnAddcmd.Location = new System.Drawing.Point(82, 406);
            this.btnAddcmd.Name = "btnAddcmd";
            this.btnAddcmd.Size = new System.Drawing.Size(80, 23);
            this.btnAddcmd.TabIndex = 118;
            this.btnAddcmd.Text = "����";
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
            this.label1.Text = "��������:";
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
            this.tabPage5.Controls.Add(this.cbxTaskAllExplore);
            this.tabPage5.Controls.Add(this.cbxTaskExplore);
            this.tabPage5.Controls.Add(this.cbxReturn);
            this.tabPage5.Location = new System.Drawing.Point(4, 21);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(536, 466);
            this.tabPage5.TabIndex = 6;
            this.tabPage5.Text = "����Ȩ��";
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
            this.labelControl1.Text = "����";
            // 
            // cbxDyAssignNext
            // 
            this.cbxDyAssignNext.AutoSize = true;
            this.cbxDyAssignNext.Location = new System.Drawing.Point(35, 212);
            this.cbxDyAssignNext.Name = "cbxDyAssignNext";
            this.cbxDyAssignNext.Size = new System.Drawing.Size(180, 16);
            this.cbxDyAssignNext.TabIndex = 2;
            this.cbxDyAssignNext.Text = "����ָ̬��һ����������";
            this.cbxDyAssignNext.UseVisualStyleBackColor = true;
            this.cbxDyAssignNext.Visible = false;
            // 
            // cbxAssign
            // 
            this.cbxAssign.AutoSize = true;
            this.cbxAssign.Location = new System.Drawing.Point(35, 189);
            this.cbxAssign.Name = "cbxAssign";
            this.cbxAssign.Size = new System.Drawing.Size(120, 16);
            this.cbxAssign.TabIndex = 1;
            this.cbxAssign.Text = "����ָ�����˴���";
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
            this.cbxbindTask.Text = "���ڽڵ�";
            this.cbxbindTask.UseVisualStyleBackColor = true;
            // 
            // cbxbindTable
            // 
            this.cbxbindTable.AutoSize = true;
            this.cbxbindTable.Location = new System.Drawing.Point(35, 33);
            this.cbxbindTable.Name = "cbxbindTable";
            this.cbxbindTable.Size = new System.Drawing.Size(180, 16);
            this.cbxbindTable.TabIndex = 0;
            this.cbxbindTable.Text = "���������ڱ������������";
            this.cbxbindTable.UseVisualStyleBackColor = true;
            // 
            // cbxTaskAllExplore
            // 
            this.cbxTaskAllExplore.AutoSize = true;
            this.cbxTaskAllExplore.Location = new System.Drawing.Point(35, 99);
            this.cbxTaskAllExplore.Name = "cbxTaskAllExplore";
            this.cbxTaskAllExplore.Size = new System.Drawing.Size(108, 16);
            this.cbxTaskAllExplore.TabIndex = 0;
            this.cbxTaskAllExplore.Text = "���������˵���";
            this.cbxTaskAllExplore.UseVisualStyleBackColor = true;
            // 
            // cbxTaskExplore
            // 
            this.cbxTaskExplore.AutoSize = true;
            this.cbxTaskExplore.Location = new System.Drawing.Point(35, 77);
            this.cbxTaskExplore.Name = "cbxTaskExplore";
            this.cbxTaskExplore.Size = new System.Drawing.Size(72, 16);
            this.cbxTaskExplore.TabIndex = 0;
            this.cbxTaskExplore.Text = "������";
            this.cbxTaskExplore.UseVisualStyleBackColor = true;
            // 
            // cbxReturn
            // 
            this.cbxReturn.AutoSize = true;
            this.cbxReturn.Location = new System.Drawing.Point(35, 17);
            this.cbxReturn.Name = "cbxReturn";
            this.cbxReturn.Size = new System.Drawing.Size(72, 16);
            this.cbxReturn.TabIndex = 0;
            this.cbxReturn.Text = "�����˻�";
            this.cbxReturn.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.groupControl1);
            this.tabPage7.Location = new System.Drawing.Point(4, 21);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(536, 466);
            this.tabPage7.TabIndex = 7;
            this.tabPage7.Text = "��־����";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cbxRiZhi);
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Controls.Add(this.simpleButton3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.memoEdit1);
            this.groupControl1.Controls.Add(this.ceBind);
            this.groupControl1.Controls.Add(this.simpleButton2);
            this.groupControl1.Controls.Add(this.tetWorkFixValue);
            this.groupControl1.Controls.Add(this.tetWorkSQL);
            this.groupControl1.Controls.Add(this.cbxWorkDbTableColumns);
            this.groupControl1.Controls.Add(this.cbxWorkDbTable);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl23);
            this.groupControl1.Controls.Add(this.labelControl24);
            this.groupControl1.Controls.Add(this.rbnWorkDatabase);
            this.groupControl1.Controls.Add(this.cbxWorkExcelTable);
            this.groupControl1.Controls.Add(this.tetWorkPos);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.cbxWorkTableColumns);
            this.groupControl1.Controls.Add(this.columnBox);
            this.groupControl1.Controls.Add(this.cbxWorkDataTable);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.rbnWorkFixValue);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.rbnWorkExcel);
            this.groupControl1.Controls.Add(this.rbnWorkTable);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(530, 460);
            this.groupControl1.TabIndex = 36;
            // 
            // cbxRiZhi
            // 
            this.cbxRiZhi.AutoSize = true;
            this.cbxRiZhi.Location = new System.Drawing.Point(5, 3);
            this.cbxRiZhi.Name = "cbxRiZhi";
            this.cbxRiZhi.Size = new System.Drawing.Size(72, 16);
            this.cbxRiZhi.TabIndex = 69;
            this.cbxRiZhi.Text = "������־";
            this.cbxRiZhi.UseVisualStyleBackColor = true;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(5, 327);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(522, 162);
            this.gridControl1.TabIndex = 68;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(415, 283);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(49, 29);
            this.simpleButton3.TabIndex = 67;
            this.simpleButton3.Text = "���";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(428, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 66;
            this.labelControl2.Text = "˵��";
            // 
            // memoEdit1
            // 
            this.memoEdit1.EditValue = "";
            this.memoEdit1.Location = new System.Drawing.Point(415, 44);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(115, 233);
            this.memoEdit1.TabIndex = 65;
            // 
            // ceBind
            // 
            this.ceBind.EditValue = true;
            this.ceBind.Location = new System.Drawing.Point(201, 26);
            this.ceBind.Name = "ceBind";
            this.ceBind.Properties.Caption = "�������̼�¼";
            this.ceBind.Size = new System.Drawing.Size(100, 19);
            this.ceBind.TabIndex = 64;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Location = new System.Drawing.Point(462, 432);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(56, 23);
            this.simpleButton2.TabIndex = 63;
            this.simpleButton2.Text = "ȡ��";
            // 
            // tetWorkFixValue
            // 
            this.tetWorkFixValue.Location = new System.Drawing.Point(69, 46);
            this.tetWorkFixValue.Name = "tetWorkFixValue";
            this.tetWorkFixValue.Size = new System.Drawing.Size(340, 23);
            this.tetWorkFixValue.TabIndex = 61;
            // 
            // tetWorkSQL
            // 
            this.tetWorkSQL.Location = new System.Drawing.Point(55, 201);
            this.tetWorkSQL.Name = "tetWorkSQL";
            this.tetWorkSQL.Size = new System.Drawing.Size(346, 117);
            this.tetWorkSQL.TabIndex = 61;
            // 
            // cbxWorkDbTableColumns
            // 
            this.cbxWorkDbTableColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkDbTableColumns.FormattingEnabled = true;
            this.cbxWorkDbTableColumns.Location = new System.Drawing.Point(275, 167);
            this.cbxWorkDbTableColumns.Name = "cbxWorkDbTableColumns";
            this.cbxWorkDbTableColumns.Size = new System.Drawing.Size(108, 20);
            this.cbxWorkDbTableColumns.TabIndex = 59;
            this.cbxWorkDbTableColumns.SelectedIndexChanged += new System.EventHandler(this.cbxWorkDbTableColumns_SelectedIndexChanged);
            // 
            // cbxWorkDbTable
            // 
            this.cbxWorkDbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkDbTable.FormattingEnabled = true;
            this.cbxWorkDbTable.Location = new System.Drawing.Point(63, 167);
            this.cbxWorkDbTable.Name = "cbxWorkDbTable";
            this.cbxWorkDbTable.Size = new System.Drawing.Size(127, 20);
            this.cbxWorkDbTable.TabIndex = 60;
            this.cbxWorkDbTable.SelectedIndexChanged += new System.EventHandler(this.cbxWorkDbTable_SelectedIndexChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(15, 204);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 14);
            this.labelControl4.TabIndex = 56;
            this.labelControl4.Text = "SQL��";
            // 
            // labelControl23
            // 
            this.labelControl23.Location = new System.Drawing.Point(226, 169);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(36, 14);
            this.labelControl23.TabIndex = 57;
            this.labelControl23.Text = "�ֶΣ�";
            // 
            // labelControl24
            // 
            this.labelControl24.Location = new System.Drawing.Point(15, 170);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(36, 14);
            this.labelControl24.TabIndex = 58;
            this.labelControl24.Text = "������";
            // 
            // rbnWorkDatabase
            // 
            this.rbnWorkDatabase.AutoSize = true;
            this.rbnWorkDatabase.Location = new System.Drawing.Point(13, 147);
            this.rbnWorkDatabase.Name = "rbnWorkDatabase";
            this.rbnWorkDatabase.Size = new System.Drawing.Size(83, 16);
            this.rbnWorkDatabase.TabIndex = 55;
            this.rbnWorkDatabase.Text = "�����ݿ�ȡ";
            this.rbnWorkDatabase.UseVisualStyleBackColor = true;
            // 
            // cbxWorkExcelTable
            // 
            this.cbxWorkExcelTable.Location = new System.Drawing.Point(299, 82);
            this.cbxWorkExcelTable.Name = "cbxWorkExcelTable";
            this.cbxWorkExcelTable.Properties.Mask.EditMask = "([a-zA-Z]{1,2}\\d{1,3}[|])+";
            this.cbxWorkExcelTable.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.cbxWorkExcelTable.Size = new System.Drawing.Size(110, 21);
            this.cbxWorkExcelTable.TabIndex = 52;
            // 
            // tetWorkPos
            // 
            this.tetWorkPos.Location = new System.Drawing.Point(299, 112);
            this.tetWorkPos.Name = "tetWorkPos";
            this.tetWorkPos.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tetWorkPos.Properties.Mask.EditMask = "([a-zA-Z]{1,2}\\d{1,3}[|])+";
            this.tetWorkPos.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.tetWorkPos.Size = new System.Drawing.Size(110, 21);
            this.tetWorkPos.TabIndex = 52;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(229, 114);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(72, 14);
            this.labelControl7.TabIndex = 51;
            this.labelControl7.Text = "��Ԫ��λ�ã�";
            this.labelControl7.UseWaitCursor = true;
            // 
            // cbxWorkTableColumns
            // 
            this.cbxWorkTableColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkTableColumns.FormattingEnabled = true;
            this.cbxWorkTableColumns.Location = new System.Drawing.Point(63, 114);
            this.cbxWorkTableColumns.Name = "cbxWorkTableColumns";
            this.cbxWorkTableColumns.Size = new System.Drawing.Size(158, 20);
            this.cbxWorkTableColumns.TabIndex = 48;
            // 
            // columnBox
            // 
            this.columnBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.columnBox.FormattingEnabled = true;
            this.columnBox.Location = new System.Drawing.Point(69, 23);
            this.columnBox.Name = "columnBox";
            this.columnBox.Size = new System.Drawing.Size(126, 20);
            this.columnBox.TabIndex = 49;
            this.columnBox.SelectedIndexChanged += new System.EventHandler(this.columnBox_SelectedIndexChanged);
            // 
            // cbxWorkDataTable
            // 
            this.cbxWorkDataTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkDataTable.FormattingEnabled = true;
            this.cbxWorkDataTable.Location = new System.Drawing.Point(64, 90);
            this.cbxWorkDataTable.Name = "cbxWorkDataTable";
            this.cbxWorkDataTable.Size = new System.Drawing.Size(158, 20);
            this.cbxWorkDataTable.TabIndex = 49;
            this.cbxWorkDataTable.SelectedIndexChanged += new System.EventHandler(this.cbxWorkDataTable_SelectedIndexChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(14, 116);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 46;
            this.labelControl5.Text = "�ֶΣ�";
            // 
            // rbnWorkFixValue
            // 
            this.rbnWorkFixValue.AutoSize = true;
            this.rbnWorkFixValue.Checked = true;
            this.rbnWorkFixValue.Location = new System.Drawing.Point(12, 47);
            this.rbnWorkFixValue.Name = "rbnWorkFixValue";
            this.rbnWorkFixValue.Size = new System.Drawing.Size(59, 16);
            this.rbnWorkFixValue.TabIndex = 50;
            this.rbnWorkFixValue.TabStop = true;
            this.rbnWorkFixValue.Text = "�̶�ֵ";
            this.rbnWorkFixValue.UseVisualStyleBackColor = true;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(18, 25);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 47;
            this.labelControl3.Text = "������";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(240, 89);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 14);
            this.labelControl6.TabIndex = 45;
            this.labelControl6.Text = "����������";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(15, 92);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(36, 14);
            this.labelControl8.TabIndex = 47;
            this.labelControl8.Text = "������";
            // 
            // rbnWorkExcel
            // 
            this.rbnWorkExcel.AutoSize = true;
            this.rbnWorkExcel.Location = new System.Drawing.Point(227, 69);
            this.rbnWorkExcel.Name = "rbnWorkExcel";
            this.rbnWorkExcel.Size = new System.Drawing.Size(101, 16);
            this.rbnWorkExcel.TabIndex = 43;
            this.rbnWorkExcel.Text = "�ӵ�ǰExcelȡ";
            this.rbnWorkExcel.UseVisualStyleBackColor = true;
            // 
            // rbnWorkTable
            // 
            this.rbnWorkTable.AutoSize = true;
            this.rbnWorkTable.Location = new System.Drawing.Point(13, 69);
            this.rbnWorkTable.Name = "rbnWorkTable";
            this.rbnWorkTable.Size = new System.Drawing.Size(71, 16);
            this.rbnWorkTable.TabIndex = 44;
            this.rbnWorkTable.Text = "�ӱ�ȡ";
            this.rbnWorkTable.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(536, 466);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "��ʱ����";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Visible = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Controls.Add(this.groupBox6);
            this.tabPage4.Location = new System.Drawing.Point(4, 21);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(536, 466);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "����֪ͨ";
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
            this.groupBox3.Text = "����֪ͨ";
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
            this.btnRmDelete.Text = "ɾ��";
            this.btnRmDelete.UseVisualStyleBackColor = true;
            this.btnRmDelete.Click += new System.EventHandler(this.btnRmDelete_Click);
            // 
            // btnRmAdd
            // 
            this.btnRmAdd.Location = new System.Drawing.Point(323, 72);
            this.btnRmAdd.Name = "btnRmAdd";
            this.btnRmAdd.Size = new System.Drawing.Size(45, 23);
            this.btnRmAdd.TabIndex = 10;
            this.btnRmAdd.Text = "����";
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
            this.label10.Text = "ͬʱ֪ͨ������Ա:";
            // 
            // cbxRmMail
            // 
            this.cbxRmMail.Location = new System.Drawing.Point(245, 22);
            this.cbxRmMail.Name = "cbxRmMail";
            this.cbxRmMail.Size = new System.Drawing.Size(112, 23);
            this.cbxRmMail.TabIndex = 7;
            this.cbxRmMail.Text = "�ʼ�֪ͨ";
            // 
            // cbxRmMessage
            // 
            this.cbxRmMessage.Location = new System.Drawing.Point(12, 22);
            this.cbxRmMessage.Name = "cbxRmMessage";
            this.cbxRmMessage.Size = new System.Drawing.Size(112, 23);
            this.cbxRmMessage.TabIndex = 6;
            this.cbxRmMessage.Text = "��ʱ��Ϣ֪ͨ";
            // 
            // cbxRmSms
            // 
            this.cbxRmSms.Location = new System.Drawing.Point(132, 22);
            this.cbxRmSms.Name = "cbxRmSms";
            this.cbxRmSms.Size = new System.Drawing.Size(112, 23);
            this.cbxRmSms.TabIndex = 5;
            this.cbxRmSms.Text = "�ֻ�����֪ͨ";
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
            this.groupBox6.Text = "��ʱ֪ͨ";
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
            this.btnOtDelete.Text = "ɾ��";
            this.btnOtDelete.UseVisualStyleBackColor = true;
            this.btnOtDelete.Click += new System.EventHandler(this.btnOtDelete_Click);
            // 
            // btnOtAdd
            // 
            this.btnOtAdd.Location = new System.Drawing.Point(322, 72);
            this.btnOtAdd.Name = "btnOtAdd";
            this.btnOtAdd.Size = new System.Drawing.Size(45, 23);
            this.btnOtAdd.TabIndex = 10;
            this.btnOtAdd.Text = "����";
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
            this.label9.Text = "ͬʱ֪ͨ������Ա:";
            // 
            // cbxOtMail
            // 
            this.cbxOtMail.Location = new System.Drawing.Point(245, 22);
            this.cbxOtMail.Name = "cbxOtMail";
            this.cbxOtMail.Size = new System.Drawing.Size(112, 23);
            this.cbxOtMail.TabIndex = 7;
            this.cbxOtMail.Text = "�ʼ�֪ͨ";
            // 
            // cbxOtMessage
            // 
            this.cbxOtMessage.Location = new System.Drawing.Point(12, 22);
            this.cbxOtMessage.Name = "cbxOtMessage";
            this.cbxOtMessage.Size = new System.Drawing.Size(112, 23);
            this.cbxOtMessage.TabIndex = 6;
            this.cbxOtMessage.Text = "��ʱ��Ϣ֪ͨ";
            // 
            // cbxOtSms
            // 
            this.cbxOtSms.Location = new System.Drawing.Point(132, 22);
            this.cbxOtSms.Name = "cbxOtSms";
            this.cbxOtSms.Size = new System.Drawing.Size(112, 23);
            this.cbxOtSms.TabIndex = 5;
            this.cbxOtSms.Text = "�ֻ�����֪ͨ";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.Text = "ɾ��";
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
            this.menuItem7.Text = "ɾ��";
            // 
            // fmTaskAlter
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(553, 529);
            this.Name = "fmTaskAlter";
            this.Text = "�����ڵ�����";
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceBind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkFixValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkSQL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxWorkExcelTable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkPos.Properties)).EndInit();
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

            //*********��������
            lvCommand.Columns.Add("��������", 200, HorizontalAlignment.Left);
            lvCommand.Columns.Add("CommandId", 0, HorizontalAlignment.Left);
            lvCommand.Columns.Add("����", 100, HorizontalAlignment.Left);
            DataTable taskCommand = WorkFlowTask.GetTaskCommands(NowTask.WorkFlowId, NowTask.TaskId);
            foreach (DataRow dr in taskCommand.Rows)
            {
                ListViewItem lvi1 = new ListViewItem(dr["CommandName"].ToString(), 0);
                lvi1.SubItems.Add(dr["CommandId"].ToString());
                lvi1.SubItems.Add(dr["Description"].ToString());

                lvCommand.Items.Add(lvi1);
            }

            //*********������
            lvOper.Columns.Add("��������Ϣ", 200, HorizontalAlignment.Left);
            lvOper.Columns.Add("OperatorId", 0, HorizontalAlignment.Left);
            lvOper.Columns.Add("����/�ų�", 100, HorizontalAlignment.Left);
            lvOper.Columns.Add("��������", 0, HorizontalAlignment.Left);
            lvOper.Columns.Add("�������", 0, HorizontalAlignment.Left);
            lvOper.Columns.Add("������", 0, HorizontalAlignment.Left);
            lvOper.Columns.Add("operDisplay", 0, HorizontalAlignment.Left);
            DataTable OperTable = WorkFlowTask.GetTaskOperator(NowTask.WorkFlowId, NowTask.TaskId);
            foreach (DataRow dr in OperTable.Rows)
            {
                ListViewItem lvi1 = new ListViewItem(dr["Description"].ToString(), 0);
                lvi1.SubItems.Add(dr["OperatorId"].ToString());
                if (Convert.ToBoolean(dr["InorExclude"]))
                    lvi1.SubItems.Add("����");
                else
                    lvi1.SubItems.Add("�ų�");
                lvi1.SubItems.Add(dr["OperType"].ToString());
                lvi1.SubItems.Add(dr["Relation"].ToString());
                lvi1.SubItems.Add(dr["OperContent"].ToString());
                lvi1.SubItems.Add(dr["operDisplay"].ToString());
                lvOper.Items.Add(lvi1);
            }

            //*********����
            lvVar.Columns.Add("������", 200, HorizontalAlignment.Left);
            lvVar.Columns.Add("TaskVarId", 0, HorizontalAlignment.Left);
            lvVar.Columns.Add("��������", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("����ģʽ", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("���ݿ���", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("���ݱ���", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("�ֶ���", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("��ʼֵ", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("��������", 100, HorizontalAlignment.Left);
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
            //*********ģ��
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
            //*********��
            DataTable ctrlTable = WorkFlowTask.GetTaskControls(NowTask.TaskId);
            if (ctrlTable != null && ctrlTable.Rows.Count > 0)
            {
                //tbxFormName.Text = ctrlTable.Rows[0]["mucCaption"].ToString();
                //UserControlId = ctrlTable.Rows[0]["UserControlId"].ToString();
                tbxFormName.Text = ctrlTable.Rows[0]["CellName"].ToString();
                UserControlId = ctrlTable.Rows[0]["LPID"].ToString();
            }
            //*********�ɲ����ֶ�
            if (UserControlId != "�ڵ����")
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
                label2.Text = "����(����������ô���{01���ύ�ļ�ģ�飬02���ֶ�����}):";
                tbxFiledName.Text = "������";
                tbxFiledName.Tag = null;
                btnSelectCtrls.Enabled = false;
                btnSelctField.Enabled = false;
            }
            //*********����Ȩ��
            DataTable powerTable = WorkFlowTask.GetTaskPower(NowTask.WorkFlowId, NowTask.TaskId);
            string powerStr = "";
            foreach (DataRow dr in powerTable.Rows)
            {
                powerStr = powerStr + dr["PowerName"].ToString()+",";
            }
            cbxReturn.Checked = powerStr.IndexOf(WorkConst.WorkTask_Return) > -1;//�˻�
            cbxbindTable.Checked = powerStr.IndexOf(WorkConst.WorkTask_BindTable) > -1;//�󶨱�����
            cbxbindTask.Checked = powerStr.IndexOf(WorkConst.WorkTask_BindTask) > -1;//���ڽڵ�����
            cbxAssign.Checked = powerStr.IndexOf(WorkConst.WorkTask_Assign) > -1;//ָ��
            cbxRiZhi.Checked = powerStr.IndexOf(WorkConst.WorkTask_WorkRiZhi) > -1;//������־
            cbxDyAssignNext.Checked = powerStr.IndexOf(WorkConst.WorkTask_DyAssignNext) > -1;//��ָ̬����һ��������
            cbxTaskExplore.Checked = powerStr.IndexOf(WorkConst.WorkTask_WorkExplore) > -1;//������
            cbxTaskAllExplore.Checked = powerStr.IndexOf(WorkConst.WorkTask_WorkAllExplore) > -1;//���������˵���
            iniBindTask();
            //*********��־����
            iniRiZhiData();
            //********* ��ʱ����
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

            //********* �¼�֪ͨ
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
            if (UserControlId != ""&&UserControlId!="�ڵ����")
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
        private void memoEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            e.Cancel = true;
        }
        private void iniRiZhiData()
        {
            int i = 0;
            memoEdit1.Text = "˵�� SQL���֧���е��������\r\n �̶�ֵ�� ����+����:{1+10}��ʾ1��10������� {sortid}:��ǰ�������Ϊsortid���ֶ�\r\n{recordid}:ƱLP_Record��ID\r\n{orgcode}:�û���λ���\r\n{userid}:�û����\r\n";
            this.memoEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.memoEdit1_EditValueChanging);

            if (rizdt == null)
            {
                rizdt = new DataTable();
                rizdt.Columns.Add("name", typeof(string));
                rizdt.Columns.Add("sql", typeof(string));
                gridControl1.DataSource = rizdt;
                gridView1.Columns["name"].Caption = "����";
                gridView1.Columns["name"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["name"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView1.Columns["name"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView1.Columns["sql"].Caption = "SQL���";
                gridView1.Columns["sql"].OptionsColumn.AllowEdit = true;
                gridView1.Columns["sql"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView1.Columns["sql"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            rizdt.Rows.Clear();
            IList li = MainHelper.PlatformSqlMap.GetList("SelectLP_TempleList", " where ( ParentID not in (select LPID from LP_Temple where 1=1 and  CtrlSize!='Ŀ¼') and  CtrlSize!='Ŀ¼' ) order by cellname ");
            DataTable dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxWorkDataTable, dt, "LPID", "CellName");
            li = MainHelper.PlatformSqlMap.GetList("SelectOneStr", "select name as 'name' from sysobjects where xtype='U'  or xtype='V' order by xtype ,name");

            dt = new DataTable();
            dt.Columns.Add("name", typeof(string));

            for (i = 0; i < li.Count; i++)
            {
                DataRow dr2 = dt.NewRow();
                dr2["name"] = li[i];
                dt.Rows.Add(dr2);
            }
            WinFormFun.LoadComboBox(cbxWorkDbTable, dt, "name", "name");

            WF_TaskVar tv = WorkFlowTask.GetTaskRiZhiVar(NowTask.TaskId, "�����ص�");
            if (tv == null) tv = new WF_TaskVar();
            DataRow dr = rizdt.NewRow();
            dr["name"] = "�����ص�";
            dr["sql"] = tv.InitValue;
            rizdt.Rows.Add(dr);

            tv = WorkFlowTask.GetTaskRiZhiVar(NowTask.TaskId, "��Ŀ");
            if (tv == null) tv = new WF_TaskVar();
            dr = rizdt.NewRow();
            dr["name"] = "��Ŀ";
            dr["sql"] = tv.InitValue;
            rizdt.Rows.Add(dr);

            tv = WorkFlowTask.GetTaskRiZhiVar(NowTask.TaskId, "������");
            if (tv == null) tv = new WF_TaskVar();
            dr = rizdt.NewRow();
            dr["name"] = "������";
            dr["sql"] = tv.InitValue;
            rizdt.Rows.Add(dr);

            tv = WorkFlowTask.GetTaskRiZhiVar(NowTask.TaskId, "�μ���Ա");
            if (tv == null) tv = new WF_TaskVar();
            dr = rizdt.NewRow();
            dr["name"] = "�μ���Ա";
            dr["sql"] = tv.InitValue;
            rizdt.Rows.Add(dr);


            WinFormFun.LoadComboBox(columnBox, rizdt, "sql", "name");
        }
        private void iniBindTask()
        {
            Hashtable hs = new Hashtable();
            GetPreviousTask(NowTask.TaskId, NowTask.WorkFlowId, ref hs);
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
        private void GetPreviousTask(string taskid, string workFlowId, ref Hashtable taskht)
        {
            
            string tmpStr = " where  EndTaskId='" + taskid + "' and WorkFlowId='" + workFlowId + "'";
            IList<WF_WorkTaskLinkView> li = MainHelper.PlatformSqlMap.GetList<WF_WorkTaskLinkView>("SelectWF_WorkTaskLinkViewList", tmpStr);
            foreach (WF_WorkTaskLinkView tl in li)
            {
                if (!taskht.ContainsKey(tl.StartTaskId))
                    taskht.Add(tl.StartTaskId, tl.startTaskCaption);
                else
                    return;
                GetPreviousTask(tl.StartTaskId, workFlowId, ref  taskht);
            }
            
        }
        private void SaveData()
        {
            //��������
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
            //���洦����
            foreach (ListViewItem lt in lvOper.Items)
            {
                Operator oper = new Operator();
                oper.OperatorId = lt.SubItems[1].Text;
                oper.WorkFlowId = NowTask.WorkFlowId;
                oper.WorkTaskId = NowTask.TaskId;
                oper.Description = lt.Text;
                if (lt.SubItems[2].Text == "����")
                {
                    oper.InorExclude = true;
                }
                else
                    if (lt.SubItems[2].Text == "�ų�")
                    {
                        oper.InorExclude = false;
                    }

                oper.OperType = Convert.ToInt16(lt.SubItems[3].Text);
                oper.Relation = Convert.ToInt16(lt.SubItems[4].Text);
                oper.OperContent = lt.SubItems[5].Text;
                oper.OperDisplay = lt.SubItems[6].Text;
                oper.InsertOperator();
            }
            //�����������
            WorkFlowTask.DeleteAllTaskVar(NowTask.TaskId);
            foreach (ListViewItem lt in lvVar.Items)
            {
                bool isSysVar = SystemVarData.isSystemVar(lt.Text);
                if (isSysVar) continue;//����ϵͳ����

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
            //������������
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
            //���������
            WorkFlowTask.DeleteAllControls(NowTask.TaskId);
            if (UserControlId != "") WorkFlowTask.SetTaskUserCtrls(UserControlId, NowTask.WorkFlowId, NowTask.TaskId);
            //�������ģ��
            WorkFlowTask.DeleteAllModle(NowTask.TaskId);
            if (UserModleId!="") WorkFlowTask.SetTaskUserModle(UserModleId, NowTask.WorkFlowId, NowTask.TaskId);

            //�������Ȩ��
            WorkFlowTask.DeleteAllPower(NowTask.WorkFlowId, NowTask.TaskId);
            if (cbxReturn.Checked)
                WorkFlowTask.SetTaskPower(WorkConst.WorkTask_Return, NowTask.WorkFlowId, NowTask.TaskId);
            if (cbxbindTable.Checked)
                WorkFlowTask.SetTaskPower(WorkConst.WorkTask_BindTable, NowTask.WorkFlowId, NowTask.TaskId);
            if (cbxbindTask.Checked)
            {
                WorkFlowTask.SetTaskPower(WorkConst.WorkTask_BindTask, NowTask.WorkFlowId, NowTask.TaskId);
                if (comTaskboBox.SelectedItem!=null)
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
            if (cbxTaskExplore.Checked)
            {
                WorkFlowTask.SetTaskPower(WorkConst.WorkTask_WorkExplore, NowTask.WorkFlowId, NowTask.TaskId);
            }
            if (cbxTaskAllExplore.Checked)
            {
                WorkFlowTask.SetTaskPower(WorkConst.WorkTask_WorkAllExplore, NowTask.WorkFlowId, NowTask.TaskId);
            }
            //���泬ʱ����
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

            //�����¼�
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
            foreach (DataRow dr in rizdt.Rows)
            {
                TaskVar tv = new TaskVar();
                tv.WorkFlowId = NowTask.WorkFlowId;
                tv.WorkTaskId = NowTask.TaskId;
                tv.VarName = dr["name"].ToString();
                tv.AccessType = WorkConst.WorkTask_WorkRiZhi;
                tv.InitValue = dr["sql"].ToString();
                tv.InsertTaskVar();
            }

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
                    MsgBox.ShowWarningMessageBox ("û��ѡ������!!");
                    return;
                }
                //Text = tmpfmOperator.OperId;
                ListViewItem lvi1 = new ListViewItem(tmpfmOperator.Description, 0);
                lvi1.SubItems.Add(tmpfmOperator.OperId);
                if (tmpfmOperator.InorExclude)
                    lvi1.SubItems.Add("����");
                else
                    lvi1.SubItems.Add("�ų�");
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
                if (lvi1.SubItems[2].Text == "����")
                    tmpfmOperator.InorExclude = true;
                else
                    if (lvi1.SubItems[2].Text == "�ų�")
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
                        lvi1.SubItems[2].Text = "����";
                    else
                        lvi1.SubItems[2].Text = "�ų�";
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
                    MsgBox.ShowWarningMessageBox("����" + tmpfmTaskVar.tbxVarName.Text + "�Ѵ���,�������!");
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
                if (isSysVar) return;//����ϵͳ����

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
                        MsgBox.ShowWarningMessageBox ("����" + tmpfmTaskVar.tbxVarName.Text + "�Ѵ���,��ʹ����������!");
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
                MsgBox.ShowWarningMessageBox("����ѡ���");
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
            //if (methodName == "")////����Ĺ��캯������Ҫ����
                fromCtrl = Activator.CreateInstance(tp);
            //else//����Ĺ��캯����Ҫ����
            //    fromCtrl = Activator.CreateInstance(tp, methodName);
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
                    MsgBox.ShowWarningMessageBox("ģ�鲻֧�֣�����ѯ������Ա!");
                    return;
                }
                if (obj != null && obj.ModuTypes.IndexOf("frmLP") == -1)
                {
                    UserControlId = "�ڵ����";
                    tbxFormName.Text = "�ڵ��ύ";

                    tbxFiledName.Tag = null;
                    tbxFiledName.Text = "������";
                    label2.Text = "����(����������ô���{01���ύ�ļ�ģ�飬02���ֶ�����}):";
                    btnSelectCtrls.Enabled = false;
                    btnSelctField.Enabled = false;
                }
                else
                {
                    if (UserControlId == "�ڵ����")
                    {
                        UserControlId = "";
                        tbxFormName.Text = "";

                        tbxFiledName.Tag = null;
                        tbxFiledName.Text = "";
                        label2.Text = "����";
                        btnSelectCtrls.Enabled = true;
                        btnSelctField.Enabled = true;
                    }
                }
                iniRiZhiData();
            }
        }

        private void btnModleClear_Click(object sender, EventArgs e)
        {

            //����ȷ��
            if (MsgBox.ShowAskMessageBox("�Ƿ�ȷ���������ģ��?") != DialogResult.OK)
            {
                return;
            }
            //�������ģ��
            WorkFlowTask.DeleteAllModle(NowTask.TaskId);
            WorkFlowTask.DeleteAllModleField(NowTask.WorkFlowId,NowTask.TaskId);
            UserModleId = "";
            tbxModleName.Text = "";
            btnSelectCtrls.Enabled = true;
            btnSelctField.Enabled = true;
        }

        private void btnTableClear_Click(object sender, EventArgs e)
        {
            //����ȷ��
            if (MsgBox.ShowAskMessageBox("�Ƿ�ȷ�����������?") != DialogResult.OK)
            {
                return;
            }
            //���������
            WorkFlowTask.DeleteAllControls(NowTask.TaskId);
            WorkFlowTask.DeleteAllTableField(NowTask.WorkFlowId, NowTask.TaskId);
            UserControlId = "";
            tbxFormName.Text = "";
            tbxFiledName.Tag = null;
            tbxFiledName.Text = "";
            label2.Text = "����";
        }

        private void btnFieldClear_Click(object sender, EventArgs e)
        {

            //����ȷ��
            if (MsgBox.ShowAskMessageBox("�Ƿ�ȷ����������ֶ�?") != DialogResult.OK)
            {
                return;
            }

            WorkFlowTask.DeleteAllTableField(NowTask.WorkFlowId, NowTask.TaskId);
            tbxFiledName.Tag = null;
            tbxFiledName.Text = "";
        }



        private void SetDataBaseSQL(DevExpress.XtraEditors.TextEdit tetSQL, ComboBox cbxDbTable, ComboBox cbxDbTableColumns)
        {
            if (cbxDbTable.SelectedIndex > 0 && cbxDbTableColumns.SelectedIndex > 0)
            {
                IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select   COLUMN_NAME   from   INFORMATION_SCHEMA.KEY_COLUMN_USAGE  where   TABLE_NAME   =   '" + ((ListItem)cbxDbTable.SelectedItem).ID + "'");
                if (list.Count > 0 && 1 == 0)
                {
                    tetSQL.Text = "select " + cbxDbTableColumns.Text + " from " + cbxDbTable.Text + " where 5=5 and " + list[0].ToString() + "='{" + list[0].ToString() + "}'";
                }
                else
                {
                    tetSQL.Text = "select " + cbxDbTableColumns.Text + " from " + cbxDbTable.Text + " where 5=5 ";
                }
                if (ceBind.Checked)
                {
                    if (cbxDbTable.Text == "WF_TableFieldValueView")
                        tetSQL.Text = "" + tetSQL.Text + " and id='{recordid}'";
                    else
                        if (cbxDbTable.Text == "LP_Record")
                            tetSQL.Text = "" + tetSQL.Text + " and id='{recordid}'";
                        else
                        {


                            tetSQL.Text = "" + tetSQL.Text + " and " + list[0].ToString()
                                + " in (select ModleRecordID from WF_ModleRecordWorkTaskIns where  RecordID='{recordid}')";
                        }

                }
            }

        }



        private void columnBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSQLtemp = ((ListItem)columnBox.SelectedItem).ID;
            if (columnBox.SelectedIndex < 1) return;
            if (strSQLtemp != "")
            {
                simpleButton3.Text = "�޸�";
                if (strSQLtemp.IndexOf("9=9") > -1)
                {
                    rbnWorkFixValue.Checked = true;

                    tetWorkFixValue.Text = strSQLtemp.Replace("select top 1 '", "").Replace("' from LP_Temple where 9=9", "");
                }
                else if (strSQLtemp.IndexOf("Excel:") > -1)
                {
                    rbnWorkExcel.Checked = true;
                    int index1 = strSQLtemp.LastIndexOf(":");
                    string tablename = strSQLtemp.Substring(6, index1 - 6);
                    string cellpos = strSQLtemp.Substring(index1 + 1);

                    cbxWorkExcelTable.Text = tablename;
                    tetWorkPos.Text = cellpos;
                }
                else if (strSQLtemp.IndexOf("10=10") > -1)
                {
                    rbnWorkTable.Checked = true;
                    Regex r1 = new Regex(@"(?<=UserControlId=').*?(?=')");
                    //cbxWorkDataTable.Text = r1.Match(strSQL).Value;
                    setComoboxFocusIndex(cbxWorkDataTable, r1.Match(strSQLtemp).Value);
                    r1 = new Regex(@"(?<=FieldId=').*?(?=')");
                    //cbxWorkTableColumns.Text = r1.Match(strSQL).Value;
                    setComoboxFocusIndex(cbxWorkTableColumns, r1.Match(strSQLtemp).Value);
                }
                else
                {
                    rbnWorkDatabase.Checked = true;
                    int index1 = strSQLtemp.ToLower().IndexOf("select");
                    int index2 = strSQLtemp.ToLower().IndexOf("from");
                    int index3 = strSQLtemp.ToLower().IndexOf("where");
                    string tablename = "";
                    if (index1 == -1 || index2 == -1 || index3 == -1) return;
                    tablename = strSQLtemp.Substring(index2 + 4, index3 - (index2 + 4)).Trim();
                    string cellpos = strSQLtemp.Substring(index1 + 6, index2 - (index1 + 6)).Trim();
                    //cbxWorkDbTable.SelectedItem = tablename;
                    //cbxWorkTableColumns.Text = cellpos;
                    setComoboxFocusIndex(cbxWorkDbTable, tablename);
                    setComoboxFocusIndex(cbxWorkDbTableColumns, cellpos);
                    tetWorkSQL.Text = strSQLtemp;
                }

            }
            else
            {
                tetWorkFixValue.Text = "";
                tetWorkSQL.Text = "";
                simpleButton3.Text = "���";
            }
        }

        private void cbxWorkDbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxWorkDbTable.SelectedIndex < 1) return;
            IList li = MainHelper.PlatformSqlMap.GetList("GetTableColumns", ((ListItem)cbxWorkDbTable.SelectedItem).ID);
            DataTable dt = ConvertHelper.ToDataTable(li);
            WinFormFun.LoadComboBox(cbxWorkDbTableColumns, dt, "name", "name");
            cbxWorkDbTableColumns.SelectedIndex = 0;
            SetDataBaseSQL(tetWorkSQL, cbxWorkDbTable, cbxWorkDbTableColumns);
        }

        private void cbxWorkDbTableColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataBaseSQL(tetWorkSQL, cbxWorkDbTable, cbxWorkDbTableColumns);
        }
        void setComoboxFocusIndex(ComboBox cbx, string text)
        {
            int focusindex = -1, i = 0;
            foreach (ListItem it in cbx.Items)
            {

                ListItem l = it as ListItem;
                if (l.ID == text)
                {
                    focusindex = i;
                    break;
                }
                i++;
            }
            cbx.SelectedIndex = focusindex;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string strSQLtemp = "";
            simpleButton3.Text = "�޸�";
            if (rbnWorkFixValue.Checked == true)
            {

                strSQLtemp = "select top 1 '" + tetWorkFixValue.Text.Replace("\r\n", " ") + "' from LP_Temple where 9=9";
            }
            else if (rbnWorkTable.Checked == true)
            {
                strSQLtemp = "select ControlValue from WF_TableFieldValue where 10=10  "
                    + "and UserControlId='" + ((ListItem)cbxWorkDataTable.SelectedItem).ID + "' "
                    + " and FieldId='" + ((ListItem)cbxWorkTableColumns.SelectedItem).ID + "' ";
                if (ceBind.Checked)
                {
                    strSQLtemp = strSQLtemp + " and RecordId='{recordid}'";
                }

            }
            else if (rbnWorkExcel.Checked == true)
            {
                strSQLtemp = "Excel:" + cbxWorkExcelTable.Text + ":" + tetWorkPos.Text;
            }
            else if (rbnWorkDatabase.Checked == true)
            {
                strSQLtemp = tetWorkSQL.Text;
            }


            int i = 0;
            foreach (DataRow dr in rizdt.Rows)
            {
                if (dr["name"].ToString() == columnBox.Text)
                {
                    dr["sql"] = strSQLtemp;
                    break;
                }
                i++;
            }
            if (columnBox.Items.Count > i + 1) ((ListItem)columnBox.Items[i + 1]).ID = strSQLtemp;
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

       

 
       

      

      

    
     
      

       

        
    }
}