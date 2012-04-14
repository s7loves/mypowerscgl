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
using System.Globalization;
using System.Text.RegularExpressions;


namespace Ebada.SCGL.WFlow.Tool
{
	/// <summary>
	/// TaskStartFm 的摘要说明。
	/// </summary>
	public class fmTaskStart : BaseForm_Single
    {
        public string UserId = "";//操作人账号，用作权限判断。
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
        private ListView lvOper;
        private Button btnModleClear;
        private Button btnFieldClear;
        private Button btnTableClear;
        private TabPage tabPage5;
        private CheckBox cbxTaskAllExplore;
        private CheckBox cbxTaskExplore;
        private string varDbTableName = "";
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
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
        private DevExpress.XtraEditors.TextEdit tetWorkPos;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private ComboBox cbxWorkTableColumns;
        private ComboBox columnBox;
        private ComboBox cbxWorkDataTable;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private RadioButton rbnWorkFixValue;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private RadioButton rbnWorkExcel;
        private RadioButton rbnWorkTable;
        private DevExpress.XtraEditors.TextEdit cbxWorkExcelTable;
        private CheckBox cbxRiZhi;
        private DataTable rizdt = null;


        public fmTaskStart(StartTask startTask, string userId, string userName)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            NowTask = startTask;
            this.UserId = userId;
            this.UserName = userName;
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cbxRiZhi = new System.Windows.Forms.CheckBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.rbnWorkExcel = new System.Windows.Forms.RadioButton();
            this.rbnWorkTable = new System.Windows.Forms.RadioButton();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.cbxTaskAllExplore = new System.Windows.Forms.CheckBox();
            this.cbxTaskExplore = new System.Windows.Forms.CheckBox();
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
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.tabControl1);
            this.plclassFill.Size = new System.Drawing.Size(558, 583);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 536);
            this.plclassBottom.Size = new System.Drawing.Size(558, 47);
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
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(8, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(546, 520);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 21);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(538, 495);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "日志功能";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cbxRiZhi);
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Controls.Add(this.simpleButton3);
            this.groupControl1.Controls.Add(this.labelControl1);
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
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.rbnWorkExcel);
            this.groupControl1.Controls.Add(this.rbnWorkTable);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(532, 489);
            this.groupControl1.TabIndex = 35;
            // 
            // cbxRiZhi
            // 
            this.cbxRiZhi.AutoSize = true;
            this.cbxRiZhi.Location = new System.Drawing.Point(5, 3);
            this.cbxRiZhi.Name = "cbxRiZhi";
            this.cbxRiZhi.Size = new System.Drawing.Size(72, 16);
            this.cbxRiZhi.TabIndex = 69;
            this.cbxRiZhi.Text = "开启日志";
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
            this.simpleButton3.Text = "添加";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(428, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 66;
            this.labelControl1.Text = "说明";
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
            this.ceBind.Properties.Caption = "关联流程记录";
            this.ceBind.Size = new System.Drawing.Size(100, 19);
            this.ceBind.TabIndex = 64;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Location = new System.Drawing.Point(464, 461);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(56, 23);
            this.simpleButton2.TabIndex = 63;
            this.simpleButton2.Text = "取消";
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
            this.labelControl4.Text = "SQL：";
            // 
            // labelControl23
            // 
            this.labelControl23.Location = new System.Drawing.Point(226, 169);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(36, 14);
            this.labelControl23.TabIndex = 57;
            this.labelControl23.Text = "字段：";
            // 
            // labelControl24
            // 
            this.labelControl24.Location = new System.Drawing.Point(15, 170);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(36, 14);
            this.labelControl24.TabIndex = 58;
            this.labelControl24.Text = "表名：";
            // 
            // rbnWorkDatabase
            // 
            this.rbnWorkDatabase.AutoSize = true;
            this.rbnWorkDatabase.Location = new System.Drawing.Point(13, 147);
            this.rbnWorkDatabase.Name = "rbnWorkDatabase";
            this.rbnWorkDatabase.Size = new System.Drawing.Size(83, 16);
            this.rbnWorkDatabase.TabIndex = 55;
            this.rbnWorkDatabase.Text = "从数据库取";
            this.rbnWorkDatabase.UseVisualStyleBackColor = true;
            // 
            // cbxWorkExcelTable
            // 
            this.cbxWorkExcelTable.Location = new System.Drawing.Point(299, 86);
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
            this.labelControl7.Text = "单元格位置：";
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
            this.labelControl5.Text = "字段：";
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
            this.rbnWorkFixValue.Text = "固定值";
            this.rbnWorkFixValue.UseVisualStyleBackColor = true;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(18, 25);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 47;
            this.labelControl2.Text = "列名：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(240, 89);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 14);
            this.labelControl6.TabIndex = 45;
            this.labelControl6.Text = "工作表名：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 92);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 47;
            this.labelControl3.Text = "表名：";
            // 
            // rbnWorkExcel
            // 
            this.rbnWorkExcel.AutoSize = true;
            this.rbnWorkExcel.Location = new System.Drawing.Point(227, 69);
            this.rbnWorkExcel.Name = "rbnWorkExcel";
            this.rbnWorkExcel.Size = new System.Drawing.Size(101, 16);
            this.rbnWorkExcel.TabIndex = 43;
            this.rbnWorkExcel.Text = "从当前Excel取";
            this.rbnWorkExcel.UseVisualStyleBackColor = true;
            // 
            // rbnWorkTable
            // 
            this.rbnWorkTable.AutoSize = true;
            this.rbnWorkTable.Location = new System.Drawing.Point(13, 69);
            this.rbnWorkTable.Name = "rbnWorkTable";
            this.rbnWorkTable.Size = new System.Drawing.Size(71, 16);
            this.rbnWorkTable.TabIndex = 44;
            this.rbnWorkTable.Text = "从表单取";
            this.rbnWorkTable.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.cbxTaskAllExplore);
            this.tabPage5.Controls.Add(this.cbxTaskExplore);
            this.tabPage5.Location = new System.Drawing.Point(4, 21);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(538, 495);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "控制权限";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // cbxTaskAllExplore
            // 
            this.cbxTaskAllExplore.AutoSize = true;
            this.cbxTaskAllExplore.Location = new System.Drawing.Point(24, 37);
            this.cbxTaskAllExplore.Name = "cbxTaskAllExplore";
            this.cbxTaskAllExplore.Size = new System.Drawing.Size(108, 16);
            this.cbxTaskAllExplore.TabIndex = 2;
            this.cbxTaskAllExplore.Text = "允许所有人导出";
            this.cbxTaskAllExplore.UseVisualStyleBackColor = true;
            // 
            // cbxTaskExplore
            // 
            this.cbxTaskExplore.AutoSize = true;
            this.cbxTaskExplore.Location = new System.Drawing.Point(24, 15);
            this.cbxTaskExplore.Name = "cbxTaskExplore";
            this.cbxTaskExplore.Size = new System.Drawing.Size(72, 16);
            this.cbxTaskExplore.TabIndex = 1;
            this.cbxTaskExplore.Text = "允许导出";
            this.cbxTaskExplore.UseVisualStyleBackColor = true;
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
            this.ClientSize = new System.Drawing.Size(558, 583);
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
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
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
            cbxTaskExplore.Checked = powerStr.IndexOf(WorkConst.WorkTask_WorkExplore) > -1;//允许导出
            cbxTaskAllExplore.Checked = powerStr.IndexOf(WorkConst.WorkTask_WorkAllExplore) > -1;//允许所有人导出
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
            if (ctrlTable != null && ctrlTable.Rows.Count > 0)
            {
                tbxFormName.Text = ctrlTable.Rows[0]["CellName"].ToString();
                UserControlId = ctrlTable.Rows[0]["LPID"].ToString();
            }
            //可操作字段
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
            //MethodInfo method = tp.GetMethod(methodName);

            //if (methodName == "")////窗体的构造函数不需要参数
            fromCtrl = Activator.CreateInstance(tp);
            //else//窗体的构造函数需要参数
            //    fromCtrl = Activator.CreateInstance(tp, method);
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
            //if (method != null)
            //{
            //    object[] objArray = new object[0];
            //    method.Invoke(fromCtrl, objArray);
            //}
            return fromCtrl;
        }
        public static object Execute(string assemblyName, string className, string methodName, object[] paramValues, Form mdi, ref object classInstance)
        {
            int num;
            if (assemblyName == null)
            {
                assemblyName = string.Empty;
            }
            if ((className == null) || (className == string.Empty))
            {
                return null;
            }
            if (string.IsNullOrEmpty(methodName))
            {
                methodName = "Show";
            }
            if (paramValues == null)
            {
                paramValues = new object[0];
            }
            object obj2 = null;
            Type type = Assembly.GetExecutingAssembly().GetType(className);
            if (null == type)
            {
                type = ((assemblyName == string.Empty) ? Assembly.GetExecutingAssembly() : Assembly.LoadFrom(Application.StartupPath + @"\" + assemblyName)).GetType(className, true);
            }
            Type[] types = new Type[paramValues.Length];
            for (num = 0; num < paramValues.Length; num++)
            {
                types[num] = paramValues[num].GetType();
            }
            MethodInfo method = type.GetMethod(methodName, types);
            if (method == null)
            {
                return obj2;
            }
            ParameterInfo[] parameters = method.GetParameters();
            if (parameters.Length != paramValues.Length)
            {
                return obj2;
            }
            object[] objArray = new object[paramValues.Length];
            for (num = 0; num < paramValues.Length; num++)
            {
                objArray[num] = Convert.ChangeType(paramValues[num], parameters[num].ParameterType, CultureInfo.InvariantCulture);
            }
            if (classInstance == null)
            {
                classInstance = method.IsStatic ? null : Activator.CreateInstance(type);
            }
            if ((classInstance is Form) && (mdi != null))
            {
                ((Form)classInstance).MdiParent = mdi;
            }
            else if (classInstance is UserControl)
            {
                return classInstance;
            }
            return method.Invoke(classInstance, objArray);
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
        //private void iniRiZhiData()
        //{

        //    WF_TaskVar tv = WorkFlowTask.GetTaskRiZhiVar(NowTask.TaskId, "工作地点");

        //    if (tv != null)
        //    {
        //        if (tv.VarModule == "固定值")
        //        {

        //            //rbnWorkFixValue.Checked = true;
        //            //tetWorkFixValue.Text = tv.InitValue;
        //            //iniRiZhiTablelcbxData(cbxWorkDataTable, cbxWorkTableColumns, NowTask.TaskId, UserControlId, "");
        //            //iniRiZhiDbcbxData(cbxWorkDbTable, cbxWorkDbTableColumns, varDbTableName, "", "");
        //        }
        //        else if (tv.VarModule == "表单")
        //        {

        //            //rbnWorkTable.Checked = true;
        //            //iniRiZhiTablelcbxData(cbxWorkDataTable, cbxWorkTableColumns, NowTask.TaskId, tv.TableName, tv.TableField);
        //            //iniRiZhiDbcbxData(cbxWorkDbTable, cbxWorkDbTableColumns, varDbTableName, "", "");
        //        }
        //        else if (tv.VarModule == "Excel")
        //        {
        //            rbnWorkExcel.Checked = true;
        //            tetWorkExcelName.Text = tv.TableName;
        //            tetWorkPos.Text = tv.TableField;

        //            iniRiZhiTablelcbxData(cbxWorkDataTable, cbxWorkTableColumns, NowTask.TaskId, UserControlId, "");
        //            iniRiZhiDbcbxData(cbxWorkDbTable, cbxWorkDbTableColumns, varDbTableName, "", "");
        //        }
        //        else if (tv.VarModule == "数据库")
        //        {
        //            rbnWorkDatabase.Checked = true;
        //            cbxWorkDbTable.Text = tv.TableName;
        //            cbxWorkDbTableColumns.Text = tv.TableField;
        //            iniRiZhiDbcbxData(cbxWorkDbTable, cbxWorkDbTableColumns, varDbTableName, tv.TableName, tv.TableField);
        //            iniRiZhiTablelcbxData(cbxWorkDataTable, cbxWorkTableColumns, NowTask.TaskId, UserControlId, "");
        //            tetWorkSQL.Text = tv.InitValue;
        //        }
        //    }
        //    else
        //    {

        //        iniRiZhiTablelcbxData(cbxWorkDataTable, cbxWorkTableColumns, NowTask.TaskId, UserControlId, "");
        //        iniRiZhiDbcbxData(cbxWorkDbTable, cbxWorkDbTableColumns, varDbTableName, "", "");
        //    }
        //    tv = WorkFlowTask.GetTaskRiZhiVar(NowTask.TaskId, "项目");
        //    if (tv != null)
        //    {
        //        if (tv.VarModule == "固定值")
        //        {
        //            rbnProjectFixValue.Checked = true;
        //            tetProjectFixValue.Text = tv.InitValue;

        //            iniRiZhiTablelcbxData(cbxProjectDataTable, cbxProjectTableColumns, NowTask.TaskId, UserControlId, "");
        //            iniRiZhiDbcbxData(cbxProjectDbTable, cbxProjectDbTableColumns, varDbTableName, "", "");
        //        }
        //        else if (tv.VarModule == "表单")
        //        {
        //            rbnProjectTable.Checked = true;
        //            iniRiZhiTablelcbxData(cbxProjectDataTable, cbxProjectTableColumns, NowTask.TaskId, tv.TableName, tv.TableField);
        //            iniRiZhiDbcbxData(cbxProjectDbTable, cbxProjectDbTableColumns, varDbTableName, "", "");
        //        }
        //        else if (tv.VarModule == "Excel")
        //        {
        //            rbnProjectExcel.Checked = true;
        //            tetProjectExcelName.Text = tv.TableName;
        //            tetProjectPos.Text = tv.TableField;
        //            iniRiZhiTablelcbxData(cbxProjectDataTable, cbxProjectTableColumns, NowTask.TaskId, UserControlId, "");
        //            iniRiZhiDbcbxData(cbxProjectDbTable, cbxProjectDbTableColumns, varDbTableName, "", "");
        //        }
        //        else if (tv.VarModule == "数据库")
        //        {

        //            rbnProjectDatabase.Checked = true;
        //            iniRiZhiDbcbxData(cbxProjectDbTable, cbxProjectDbTableColumns, varDbTableName, tv.TableName, tv.TableField);
        //            iniRiZhiTablelcbxData(cbxProjectDataTable, cbxProjectTableColumns, NowTask.TaskId, UserControlId, "");
        //            tetProjectSQL.Text = tv.InitValue;
        //        }
        //    }
        //    else
        //    {

        //        iniRiZhiTablelcbxData(cbxProjectDataTable, cbxProjectTableColumns, NowTask.TaskId, UserControlId, "");
        //        iniRiZhiDbcbxData(cbxProjectDbTable, cbxProjectDbTableColumns, varDbTableName, "", "");
        //    }
        //    tv = WorkFlowTask.GetTaskRiZhiVar(NowTask.TaskId, "负责人");
        //    if (tv != null)
        //    {
        //        if (tv.VarModule == "固定值")
        //        {
        //            rbnCharManFixValue.Checked = true;
        //            tetCharManFixValue.Text = tv.InitValue;
        //            iniRiZhiTablelcbxData(cbxCharManDataTable, cbxCharManTableColumns, NowTask.TaskId, UserControlId, "");
        //            iniRiZhiDbcbxData(cbxCharManDbTable, cbxCharManDbTableColumns, varDbTableName, "", "");
        //        }
        //        else if (tv.VarModule == "表单")
        //        {
        //            rbnCharManTable.Checked = true;
        //            iniRiZhiTablelcbxData(cbxCharManDataTable, cbxCharManTableColumns, NowTask.TaskId, tv.TableName, tv.TableField);
        //            iniRiZhiDbcbxData(cbxCharManDbTable, cbxCharManDbTableColumns, varDbTableName, "", "");
        //        }
        //        else if (tv.VarModule == "Excel")
        //        {
        //            rbnCharManExcel.Checked = true;
        //            tetCharManExcelName.Text = tv.TableName;
        //            tetCharManPos.Text = tv.TableField;
        //            iniRiZhiTablelcbxData(cbxCharManDataTable, cbxCharManTableColumns, NowTask.TaskId, UserControlId, "");
        //            iniRiZhiDbcbxData(cbxCharManDbTable, cbxCharManDbTableColumns, varDbTableName, "", "");
        //        }
        //        else if (tv.VarModule == "数据库")
        //        {

        //            rbnCharManDatabase.Checked = true;
        //            iniRiZhiDbcbxData(cbxCharManDbTable, cbxCharManDbTableColumns, varDbTableName, tv.TableName, tv.TableField);
        //            iniRiZhiTablelcbxData(cbxCharManDataTable, cbxCharManTableColumns, NowTask.TaskId, UserControlId, "");
        //            tetCharManSQL.Text = tv.InitValue;
        //        }
        //    }
        //    else
        //    {
        //        iniRiZhiTablelcbxData(cbxCharManDataTable, cbxCharManTableColumns, NowTask.TaskId, UserControlId, "");
        //        iniRiZhiDbcbxData(cbxCharManDbTable, cbxCharManDbTableColumns, varDbTableName, "", "");
        //    }
        //    tv = WorkFlowTask.GetTaskRiZhiVar(NowTask.TaskId, "参加人员");
        //    if (tv != null)
        //    {
        //        if (tv.VarModule == "固定值")
        //        {
        //            rbnAttendManFixValue.Checked = true;
        //            tetAttendManFixValue.Text = tv.InitValue;
        //            iniRiZhiTablelcbxData(cbxAttendManDataTable, cbxAttendManTableColumns, NowTask.TaskId, UserControlId, "");
        //            iniRiZhiDbcbxData(cbxAttendManDbTable, cbxAttendManDbTableColumns, varDbTableName, "", "");
        //        }
        //        else if (tv.VarModule == "表单")
        //        {
        //            rbnAttendManTable.Checked = true;
        //            iniRiZhiTablelcbxData(cbxAttendManDataTable, cbxAttendManTableColumns, NowTask.TaskId, tv.TableName, tv.TableField);
        //            iniRiZhiDbcbxData(cbxAttendManDbTable, cbxAttendManDbTableColumns, varDbTableName, "", "");

        //        }
        //        else if (tv.VarModule == "Excel")
        //        {
        //            rbnAttendManExcel.Checked = true;
        //            tetAttendManExcelName.Text = tv.TableName;
        //            tetAttendManPos.Text = tv.TableField;
        //            iniRiZhiTablelcbxData(cbxAttendManDataTable, cbxAttendManTableColumns, NowTask.TaskId, UserControlId, "");
        //            iniRiZhiDbcbxData(cbxAttendManDbTable, cbxAttendManDbTableColumns, varDbTableName, "", "");
        //        }
        //        else if (tv.VarModule == "数据库")
        //        {

        //            rbnAttendManDatabase.Checked = true;
        //            iniRiZhiDbcbxData(cbxAttendManDbTable, cbxAttendManDbTableColumns, varDbTableName, tv.TableName, tv.TableField);

        //            iniRiZhiTablelcbxData(cbxAttendManDataTable, cbxAttendManTableColumns, NowTask.TaskId, UserControlId, "");
        //            tetAttendManSQL.Text = tv.InitValue;
        //        }
        //    }
        //    else
        //    {

        //        iniRiZhiTablelcbxData(cbxAttendManDataTable, cbxAttendManTableColumns, NowTask.TaskId, UserControlId, "");
        //        iniRiZhiDbcbxData(cbxAttendManDbTable, cbxAttendManDbTableColumns, varDbTableName, "", "");
        //    }
        //}
        private void memoEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            e.Cancel = true;
        }
        private void iniRiZhiData()
        {
            int i = 0;
            memoEdit1.Text = "说明 SQL语句支持中的特殊代码\r\n 固定值中 数字+数字:{1+10}表示1到10用于序号 {sortid}:当前表单的序号为sortid的字段\r\n{recordid}:票LP_Record的ID\r\n{orgcode}:用户单位编号\r\n{userid}:用户编号\r\n";
            this.memoEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.memoEdit1_EditValueChanging);

            if (rizdt == null)
            {
                rizdt = new DataTable();
                rizdt.Columns.Add("name", typeof(string));
                rizdt.Columns.Add("sql", typeof(string));
                gridControl1.DataSource = rizdt;
                gridView1.Columns["name"].Caption = "列名";
                gridView1.Columns["name"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["name"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView1.Columns["name"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView1.Columns["sql"].Caption = "SQL语句";
                gridView1.Columns["sql"].OptionsColumn.AllowEdit = true;
                gridView1.Columns["sql"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView1.Columns["sql"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            rizdt.Rows.Clear();
            IList li = MainHelper.PlatformSqlMap.GetList("SelectLP_TempleList", " where ( ParentID not in (select LPID from LP_Temple where 1=1 and  CtrlSize!='目录') and  CtrlSize!='目录' ) order by cellname ");
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

            WF_TaskVar tv = WorkFlowTask.GetTaskRiZhiVar(NowTask.TaskId, "工作地点");
            if (tv == null) tv = new WF_TaskVar();
            DataRow dr = rizdt.NewRow();
            dr["name"] = "工作地点";
            dr["sql"] = tv.InitValue;
            rizdt.Rows.Add(dr);

            tv = WorkFlowTask.GetTaskRiZhiVar(NowTask.TaskId, "项目");
            if (tv == null) tv = new WF_TaskVar();
            dr = rizdt.NewRow();
            dr["name"] = "项目";
            dr["sql"] = tv.InitValue;
            rizdt.Rows.Add(dr);

            tv = WorkFlowTask.GetTaskRiZhiVar(NowTask.TaskId, "负责人");
            if (tv == null) tv = new WF_TaskVar();
            dr = rizdt.NewRow();
            dr["name"] = "负责人";
            dr["sql"] = tv.InitValue;
            rizdt.Rows.Add(dr);

            tv = WorkFlowTask.GetTaskRiZhiVar(NowTask.TaskId, "参加人员");
            if (tv == null) tv = new WF_TaskVar();
            dr = rizdt.NewRow();
            dr["name"] = "参加人员";
            dr["sql"] = tv.InitValue;
            rizdt.Rows.Add(dr);


            WinFormFun.LoadComboBox(columnBox, rizdt, "sql", "name");
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
            if (cbxTaskExplore.Checked)
            {
                WorkFlowTask.SetTaskPower(WorkConst.WorkTask_WorkExplore, NowTask.WorkFlowId, NowTask.TaskId);
            }
            if (cbxTaskAllExplore.Checked)
            {
                WorkFlowTask.SetTaskPower(WorkConst.WorkTask_WorkAllExplore, NowTask.WorkFlowId, NowTask.TaskId);
            }
            //保存关联表单
            WorkFlowTask.DeleteAllControls(NowTask.TaskId);
            if (UserControlId != "") WorkFlowTask.SetTaskUserCtrls(UserControlId, NowTask.WorkFlowId, NowTask.TaskId);
            //保存关联模块
            WorkFlowTask.DeleteAllModle(NowTask.TaskId);
            if (UserModleId != "") WorkFlowTask.SetTaskUserModle(UserModleId, NowTask.WorkFlowId, NowTask.TaskId);

        }
        //private void SaveRiZhiData()
        //{
        //    TaskVar tv = new TaskVar();
        //    tv.WorkFlowId = NowTask.WorkFlowId;
        //    tv.WorkTaskId = NowTask.TaskId;
        //    tv.VarName = "工作地点";
        //    tv.AccessType = WorkConst.WorkTask_WorkRiZhi;
        //    if (rbnWorkFixValue.Checked == true)
        //    {
        //        tv.VarModule = "固定值";
        //        tv.InitValue = tetWorkFixValue.Text;
        //    }
        //    else if (rbnWorkTable.Checked == true)
        //    {
        //        tv.VarModule = "表单";
        //        tv.TableName = ((ListItem)cbxWorkDataTable.SelectedItem).ID;
        //        tv.TableField = ((ListItem)cbxWorkTableColumns.SelectedItem).ID;
        //    }
        //    else if (rbnWorkExcel.Checked == true)
        //    {

        //        tv.VarModule = "Excel";
        //        tv.TableName = tetWorkExcelName.Text;
        //        tv.TableField = tetWorkPos.Text;
        //    }
        //    else if (rbnWorkDatabase.Checked == true)
        //    {

        //        tv.VarModule = "数据库";
        //        tv.TableName = ((ListItem)cbxWorkDbTable.SelectedItem).ID;
        //        tv.TableField = ((ListItem)cbxWorkDbTableColumns.SelectedItem).ID;
        //        tv.InitValue = tetWorkSQL.Text;
        //    }
        //    tv.InsertTaskVar();
        //    tv = new TaskVar();
        //    tv.WorkFlowId = NowTask.WorkFlowId;
        //    tv.WorkTaskId = NowTask.TaskId;
        //    tv.VarName = "项目";
        //    tv.AccessType = WorkConst.WorkTask_WorkRiZhi;
        //    if (tv != null)
        //    {
        //        if (rbnProjectFixValue.Checked == true)
        //        {
        //            tv.VarModule = "固定值";
        //            tv.InitValue = tetProjectFixValue.Text;
        //        }
        //        else if (rbnProjectTable.Checked == true)
        //        {

        //            tv.VarModule = "表单";
        //            tv.TableName = ((ListItem)cbxProjectDataTable.SelectedItem).ID;
        //            tv.TableField = ((ListItem)cbxProjectTableColumns.SelectedItem).ID;
        //        }
        //        else if (rbnProjectExcel.Checked == true)
        //        {

        //            tv.VarModule = "Excel";
        //            tv.TableName = tetProjectExcelName.Text;
        //            tv.TableField = tetProjectPos.Text;
        //        }
        //        else if (rbnProjectDatabase.Checked == true)
        //        {


        //            tv.VarModule = "数据库";
        //            tv.TableName = ((ListItem)cbxProjectDbTable.SelectedItem).ID;
        //            tv.TableField = ((ListItem)cbxProjectDbTableColumns.SelectedItem).ID;
        //            tv.InitValue = tetProjectSQL.Text;
        //        }
        //    }
        //    tv.InsertTaskVar();
        //    tv = new TaskVar();
        //    tv.WorkFlowId = NowTask.WorkFlowId;
        //    tv.WorkTaskId = NowTask.TaskId;
        //    tv.VarName = "负责人";
        //    tv.AccessType = WorkConst.WorkTask_WorkRiZhi;
        //    if (tv != null)
        //    {
        //        if (rbnCharManFixValue.Checked == true)
        //        {
        //            tv.VarModule = "固定值";
        //            tv.InitValue = tetCharManFixValue.Text;
        //        }
        //        else if (rbnCharManTable.Checked == true)
        //        {
        //            tv.VarModule = "表单";
        //            tv.TableName = ((ListItem)cbxCharManDataTable.SelectedItem).ID;
        //            tv.TableField = ((ListItem)cbxCharManTableColumns.SelectedItem).ID;
        //        }
        //        else if (rbnCharManExcel.Checked == true)
        //        {
        //            tv.VarModule = "Excel";
        //            tv.TableName = tetCharManExcelName.Text;
        //            tv.TableField = tetCharManPos.Text;
        //        }
        //        else if (rbnCharManDatabase.Checked == true)
        //        {

        //            tv.VarModule = "数据库";
        //            tv.TableName = ((ListItem)cbxCharManDbTable.SelectedItem).ID;
        //            tv.TableField = ((ListItem)cbxCharManDbTableColumns.SelectedItem).ID;
        //            tv.InitValue = tetCharManSQL.Text;
        //        }
        //    }
        //    tv.InsertTaskVar();
        //    tv = new TaskVar();
        //    tv.WorkFlowId = NowTask.WorkFlowId;
        //    tv.WorkTaskId = NowTask.TaskId;
        //    tv.VarName = "参加人员";
        //    tv.AccessType = WorkConst.WorkTask_WorkRiZhi;
        //    if (tv != null)
        //    {
        //        if (rbnAttendManFixValue.Checked == true)
        //        {
        //            tv.VarModule = "固定值";
        //            tv.InitValue = tetAttendManFixValue.Text;
        //        }
        //        else if (rbnAttendManTable.Checked == true)
        //        {
        //            tv.VarModule = "表单";
        //            tv.TableName = ((ListItem)cbxAttendManDataTable.SelectedItem).ID;
        //            tv.TableField = ((ListItem)cbxAttendManTableColumns.SelectedItem).ID;
        //        }
        //        else if (rbnAttendManExcel.Checked == true)
        //        {
        //            tv.VarModule = "Excel";
        //            tv.TableName = tetAttendManExcelName.Text;
        //            tv.TableField = tetAttendManPos.Text;
        //        }
        //        else if (rbnAttendManDatabase.Checked == true)
        //        {


        //            tv.VarModule = "数据库";
        //            tv.TableName = ((ListItem)cbxAttendManDbTable.SelectedItem).ID;
        //            tv.TableField = ((ListItem)cbxAttendManDbTableColumns.SelectedItem).ID;
        //            tv.InitValue = tetAttendManSQL.Text;
        //        }
        //    }
        //    tv.InsertTaskVar();

        //}
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
            tmpfmTaskVar.varTableColumnName = "";
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
                if (obj != null && obj.ModuTypes.IndexOf("frmLP") == -1)
                {
                    UserControlId = "节点审核";
                    tbxFormName.Text = "节点提交";

                    tbxFiledName.Tag = null;
                    tbxFiledName.Text = "不可用";
                    label2.Text = "处理(任务命令可用代码{01：提交文件模块，02：手动结束}):";
                    btnSelectCtrls.Enabled = false;
                    btnSelctField.Enabled = false;
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
                    btnSelectCtrls.Enabled = true;
                    btnSelctField.Enabled = true;
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
            if (stf.ShowDialog() == DialogResult.OK)
            {
                tbxFiledName.Tag = stf.StrFieldidList;
                tbxFiledName.Text = stf.StrFieldNameList;
                iniRiZhiData();
            }
        }

        private void cbxWorkDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxWorkDataTable.SelectedIndex == 0) return;

            IList li = MainHelper.PlatformSqlMap.GetList("SelectLP_TempleList",
                "where ParentID ='" + ((ListItem)cbxWorkDataTable.SelectedItem).ID + "' order by sortid");
            DataTable dt = new DataTable();
            if (li.Count > 0) dt = ConvertHelper.ToDataTable(li);
            for (int i = 0; i < dt.Rows.Count && li.Count > 0; i++)
            {
                dt.Rows[i]["cellname"] = dt.Rows[i]["SortID"] + " " + dt.Rows[i]["cellname"];

            }
            WinFormFun.LoadComboBox(cbxWorkTableColumns, dt, "LPID", "cellname");
            cbxWorkTableColumns.SelectedIndex = 0;
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
                simpleButton3.Text = "修改";
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
                simpleButton3.Text = "添加";
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
            simpleButton3.Text = "修改";
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















    }
}
