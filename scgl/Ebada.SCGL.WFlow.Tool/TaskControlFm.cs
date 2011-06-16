using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace Ebada.SCGL.WorkFlow.Tool
{
	/// <summary>
	/// TaskControlFm 的摘要说明。
	/// </summary>
	public class fmTaskControl : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.RichTextBox rtbDes;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnVarChoose;
		private System.Windows.Forms.RichTextBox rtbExpression;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbNumOpe;
		private System.Windows.Forms.RadioButton rbVarConfig;
		private System.Windows.Forms.RadioButton rbSelfDef;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cmbControlType;
		private System.Windows.Forms.TextBox txtTaskName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.DataGrid dataGrid1;
		public ControlTask NowTask;
		public string UserId="";//操作人账号，用作权限判断。
		public string UserName="";//操作人姓名，用作显示。
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public fmTaskControl(ControlTask ctrlTask,string userId,string userName)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			NowTask=ctrlTask;
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.rtbDes = new System.Windows.Forms.RichTextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnVarChoose = new System.Windows.Forms.Button();
			this.rtbExpression = new System.Windows.Forms.RichTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbNumOpe = new System.Windows.Forms.ComboBox();
			this.rbVarConfig = new System.Windows.Forms.RadioButton();
			this.rbSelfDef = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbControlType = new System.Windows.Forms.ComboBox();
			this.txtTaskName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(344, 400);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 16;
			this.btnCancel.Text = "取消";
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(256, 400);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 15;
			this.btnOk.Text = "确定";
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
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.ItemSize = new System.Drawing.Size(60, 17);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(418, 379);
			this.tabControl1.TabIndex = 14;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox4);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(410, 354);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "基本信息";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.rtbDes);
			this.groupBox4.Location = new System.Drawing.Point(10, 237);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(390, 106);
			this.groupBox4.TabIndex = 18;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "任务说明";
			// 
			// rtbDes
			// 
			this.rtbDes.Location = new System.Drawing.Point(10, 16);
			this.rtbDes.Name = "rtbDes";
			this.rtbDes.Size = new System.Drawing.Size(370, 80);
			this.rtbDes.TabIndex = 0;
			this.rtbDes.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnVarChoose);
			this.groupBox2.Controls.Add(this.rtbExpression);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.cbNumOpe);
			this.groupBox2.Controls.Add(this.rbVarConfig);
			this.groupBox2.Controls.Add(this.rbSelfDef);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(10, 77);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(390, 157);
			this.groupBox2.TabIndex = 17;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "表达式配置";
			// 
			// btnVarChoose
			// 
			this.btnVarChoose.Location = new System.Drawing.Point(10, 39);
			this.btnVarChoose.Name = "btnVarChoose";
			this.btnVarChoose.TabIndex = 11;
			this.btnVarChoose.Text = "变量选择";
			// 
			// rtbExpression
			// 
			this.rtbExpression.Location = new System.Drawing.Point(66, 67);
			this.rtbExpression.Name = "rtbExpression";
			this.rtbExpression.Size = new System.Drawing.Size(300, 80);
			this.rtbExpression.TabIndex = 10;
			this.rtbExpression.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 67);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 23);
			this.label5.TabIndex = 9;
			this.label5.Text = "表达式";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbNumOpe
			// 
			this.cbNumOpe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbNumOpe.ItemHeight = 12;
			this.cbNumOpe.Items.AddRange(new object[] {
														  "<",
														  ">",
														  "=",
														  ">=",
														  "<=",
														  "!=",
														  "and",
														  "or",
														  "(",
														  ")"});
			this.cbNumOpe.Location = new System.Drawing.Point(175, 41);
			this.cbNumOpe.Name = "cbNumOpe";
			this.cbNumOpe.Size = new System.Drawing.Size(64, 20);
			this.cbNumOpe.TabIndex = 6;
			// 
			// rbVarConfig
			// 
			this.rbVarConfig.Checked = true;
			this.rbVarConfig.Location = new System.Drawing.Point(10, 15);
			this.rbVarConfig.Name = "rbVarConfig";
			this.rbVarConfig.Size = new System.Drawing.Size(80, 23);
			this.rbVarConfig.TabIndex = 0;
			this.rbVarConfig.TabStop = true;
			this.rbVarConfig.Text = "变量配置";
			this.rbVarConfig.Visible = false;
			// 
			// rbSelfDef
			// 
			this.rbSelfDef.Location = new System.Drawing.Point(195, 15);
			this.rbSelfDef.Name = "rbSelfDef";
			this.rbSelfDef.Size = new System.Drawing.Size(72, 23);
			this.rbSelfDef.TabIndex = 1;
			this.rbSelfDef.Text = "自定义";
			this.rbSelfDef.Visible = false;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(110, 41);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 23);
			this.label4.TabIndex = 5;
			this.label4.Text = "运算符";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmbControlType);
			this.groupBox1.Controls.Add(this.txtTaskName);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(10, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(390, 69);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "基本信息";
			// 
			// cmbControlType
			// 
			this.cmbControlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbControlType.ItemHeight = 12;
			this.cmbControlType.Items.AddRange(new object[] {
																"与",
																"或",
																"混合"});
			this.cmbControlType.Location = new System.Drawing.Point(66, 39);
			this.cmbControlType.Name = "cmbControlType";
			this.cmbControlType.Size = new System.Drawing.Size(300, 20);
			this.cmbControlType.TabIndex = 4;
			// 
			// txtTaskName
			// 
			this.txtTaskName.Location = new System.Drawing.Point(66, 15);
			this.txtTaskName.Name = "txtTaskName";
			this.txtTaskName.Size = new System.Drawing.Size(300, 21);
			this.txtTaskName.TabIndex = 3;
			this.txtTaskName.Text = "";
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(366, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(10, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "*";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "控件类型";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "任务名称";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.dataGrid1);
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(410, 354);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "任务变量";
			this.tabPage2.Visible = false;
			// 
			// dataGrid1
			// 
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.ContextMenu = this.contextMenu1;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(10, 10);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(390, 336);
			this.dataGrid1.TabIndex = 0;
			// 
			// fmTaskControl
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(432, 437);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.btnCancel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "fmTaskControl";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "控制节点配置";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
