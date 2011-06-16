namespace Ebada.SCGL.WFlow.Tool
{
    partial class fmOperator
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectTask = new System.Windows.Forms.Button();
            this.btnSelectVar = new System.Windows.Forms.Button();
            this.btnSelectDuty = new System.Windows.Forms.Button();
            this.btnSelectArch = new System.Windows.Forms.Button();
            this.tbxOpr8 = new System.Windows.Forms.TextBox();
            this.tbxOpr7 = new System.Windows.Forms.TextBox();
            this.tbxOpr5 = new System.Windows.Forms.TextBox();
            this.rbtOpr9 = new System.Windows.Forms.RadioButton();
            this.rbtOpr8 = new System.Windows.Forms.RadioButton();
            this.rbtOpr7 = new System.Windows.Forms.RadioButton();
            this.rbtOpr6 = new System.Windows.Forms.RadioButton();
            this.rbtOpr5 = new System.Windows.Forms.RadioButton();
            this.btnSelectRole = new System.Windows.Forms.Button();
            this.tbxOpr4 = new System.Windows.Forms.TextBox();
            this.rbtOpr4 = new System.Windows.Forms.RadioButton();
            this.tbxOpr6 = new System.Windows.Forms.TextBox();
            this.btnSelectUser = new System.Windows.Forms.Button();
            this.tbxOpr3 = new System.Windows.Forms.TextBox();
            this.rbtOpr3 = new System.Windows.Forms.RadioButton();
            this.btnSelectOpr = new System.Windows.Forms.Button();
            this.tbxOpr2 = new System.Windows.Forms.TextBox();
            this.rbtOpr2 = new System.Windows.Forms.RadioButton();
            this.rbtOpr1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxRelation = new System.Windows.Forms.CheckBox();
            this.rbtRlt6 = new System.Windows.Forms.RadioButton();
            this.rbtRlt5 = new System.Windows.Forms.RadioButton();
            this.rbtRlt4 = new System.Windows.Forms.RadioButton();
            this.rbtRlt3 = new System.Windows.Forms.RadioButton();
            this.rbtRlt2 = new System.Windows.Forms.RadioButton();
            this.rbtRlt1 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtExclude = new System.Windows.Forms.RadioButton();
            this.rbtInclude = new System.Windows.Forms.RadioButton();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.groupBox3);
            this.plclassFill.Controls.Add(this.groupBox2);
            this.plclassFill.Controls.Add(this.groupBox1);
            this.plclassFill.Size = new System.Drawing.Size(436, 480);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 414);
            this.plclassBottom.Size = new System.Drawing.Size(436, 66);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Text = "取消(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectTask);
            this.groupBox1.Controls.Add(this.btnSelectVar);
            this.groupBox1.Controls.Add(this.btnSelectDuty);
            this.groupBox1.Controls.Add(this.btnSelectArch);
            this.groupBox1.Controls.Add(this.tbxOpr8);
            this.groupBox1.Controls.Add(this.tbxOpr7);
            this.groupBox1.Controls.Add(this.tbxOpr5);
            this.groupBox1.Controls.Add(this.rbtOpr9);
            this.groupBox1.Controls.Add(this.rbtOpr8);
            this.groupBox1.Controls.Add(this.rbtOpr7);
            this.groupBox1.Controls.Add(this.rbtOpr6);
            this.groupBox1.Controls.Add(this.rbtOpr5);
            this.groupBox1.Controls.Add(this.btnSelectRole);
            this.groupBox1.Controls.Add(this.tbxOpr4);
            this.groupBox1.Controls.Add(this.rbtOpr4);
            this.groupBox1.Controls.Add(this.tbxOpr6);
            this.groupBox1.Controls.Add(this.btnSelectUser);
            this.groupBox1.Controls.Add(this.tbxOpr3);
            this.groupBox1.Controls.Add(this.rbtOpr3);
            this.groupBox1.Controls.Add(this.btnSelectOpr);
            this.groupBox1.Controls.Add(this.tbxOpr2);
            this.groupBox1.Controls.Add(this.rbtOpr2);
            this.groupBox1.Controls.Add(this.rbtOpr1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 256);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "人员";
            // 
            // btnSelectTask
            // 
            this.btnSelectTask.Enabled = false;
            this.btnSelectTask.Location = new System.Drawing.Point(335, 224);
            this.btnSelectTask.Name = "btnSelectTask";
            this.btnSelectTask.Size = new System.Drawing.Size(36, 23);
            this.btnSelectTask.TabIndex = 22;
            this.btnSelectTask.Text = "";
            this.btnSelectTask.UseVisualStyleBackColor = true;
            this.btnSelectTask.Visible = false;
            this.btnSelectTask.Click += new System.EventHandler(this.btnSelectTask_Click);
            // 
            // btnSelectVar
            // 
            this.btnSelectVar.Enabled = false;
            this.btnSelectVar.Location = new System.Drawing.Point(335, 177);
            this.btnSelectVar.Name = "btnSelectVar";
            this.btnSelectVar.Size = new System.Drawing.Size(36, 23);
            this.btnSelectVar.TabIndex = 21;
            this.btnSelectVar.Text = "";
            this.btnSelectVar.UseVisualStyleBackColor = true;
            // 
            // btnSelectDuty
            // 
            this.btnSelectDuty.Enabled = false;
            this.btnSelectDuty.Location = new System.Drawing.Point(277, 149);
            this.btnSelectDuty.Name = "btnSelectDuty";
            this.btnSelectDuty.Size = new System.Drawing.Size(36, 23);
            this.btnSelectDuty.TabIndex = 20;
            this.btnSelectDuty.Text = "";
            this.btnSelectDuty.UseVisualStyleBackColor = true;
            this.btnSelectDuty.Click += new System.EventHandler(this.btnSelectDuty_Click);
            // 
            // btnSelectArch
            // 
            this.btnSelectArch.Enabled = false;
            this.btnSelectArch.Location = new System.Drawing.Point(277, 97);
            this.btnSelectArch.Name = "btnSelectArch";
            this.btnSelectArch.Size = new System.Drawing.Size(36, 23);
            this.btnSelectArch.TabIndex = 19;
            this.btnSelectArch.Text = "";
            this.btnSelectArch.UseVisualStyleBackColor = true;
            this.btnSelectArch.Click += new System.EventHandler(this.btnSelectArch_Click);
            // 
            // tbxOpr8
            // 
            this.tbxOpr8.Location = new System.Drawing.Point(160, 224);
            this.tbxOpr8.Name = "tbxOpr8";
            this.tbxOpr8.ReadOnly = true;
            this.tbxOpr8.Size = new System.Drawing.Size(169, 21);
            this.tbxOpr8.TabIndex = 18;
            this.tbxOpr8.Visible = false;
            // 
            // tbxOpr7
            // 
            this.tbxOpr7.Location = new System.Drawing.Point(160, 178);
            this.tbxOpr7.Name = "tbxOpr7";
            this.tbxOpr7.ReadOnly = true;
            this.tbxOpr7.Size = new System.Drawing.Size(169, 21);
            this.tbxOpr7.TabIndex = 17;
            // 
            // tbxOpr5
            // 
            this.tbxOpr5.Location = new System.Drawing.Point(90, 123);
            this.tbxOpr5.Name = "tbxOpr5";
            this.tbxOpr5.ReadOnly = true;
            this.tbxOpr5.Size = new System.Drawing.Size(180, 21);
            this.tbxOpr5.TabIndex = 16;
            // 
            // rbtOpr9
            // 
            this.rbtOpr9.AutoSize = true;
            this.rbtOpr9.Location = new System.Drawing.Point(11, 202);
            this.rbtOpr9.Name = "rbtOpr9";
            this.rbtOpr9.Size = new System.Drawing.Size(59, 16);
            this.rbtOpr9.TabIndex = 15;
            this.rbtOpr9.TabStop = true;
            this.rbtOpr9.Text = "所有人";
            this.rbtOpr9.UseVisualStyleBackColor = true;
            this.rbtOpr9.CheckedChanged += new System.EventHandler(this.rbtOpr9_CheckedChanged);
            // 
            // rbtOpr8
            // 
            this.rbtOpr8.AutoSize = true;
            this.rbtOpr8.Location = new System.Drawing.Point(11, 224);
            this.rbtOpr8.Name = "rbtOpr8";
            this.rbtOpr8.Size = new System.Drawing.Size(143, 16);
            this.rbtOpr8.TabIndex = 14;
            this.rbtOpr8.TabStop = true;
            this.rbtOpr8.Text = "某一任务选择的处理者";
            this.rbtOpr8.UseVisualStyleBackColor = true;
            this.rbtOpr8.Visible = false;
            this.rbtOpr8.CheckedChanged += new System.EventHandler(this.rbtOpr8_CheckedChanged);
            // 
            // rbtOpr7
            // 
            this.rbtOpr7.AutoSize = true;
            this.rbtOpr7.Location = new System.Drawing.Point(11, 180);
            this.rbtOpr7.Name = "rbtOpr7";
            this.rbtOpr7.Size = new System.Drawing.Size(95, 16);
            this.rbtOpr7.TabIndex = 13;
            this.rbtOpr7.TabStop = true;
            this.rbtOpr7.Text = "从变量中获取";
            this.rbtOpr7.UseVisualStyleBackColor = true;
            this.rbtOpr7.CheckedChanged += new System.EventHandler(this.rbtOpr7_CheckedChanged);
            // 
            // rbtOpr6
            // 
            this.rbtOpr6.AutoSize = true;
            this.rbtOpr6.Location = new System.Drawing.Point(11, 154);
            this.rbtOpr6.Name = "rbtOpr6";
            this.rbtOpr6.Size = new System.Drawing.Size(47, 16);
            this.rbtOpr6.TabIndex = 12;
            this.rbtOpr6.TabStop = true;
            this.rbtOpr6.Text = "岗位";
            this.rbtOpr6.UseVisualStyleBackColor = true;
            this.rbtOpr6.CheckedChanged += new System.EventHandler(this.rbtOpr6_CheckedChanged);
            // 
            // rbtOpr5
            // 
            this.rbtOpr5.AutoSize = true;
            this.rbtOpr5.Location = new System.Drawing.Point(11, 128);
            this.rbtOpr5.Name = "rbtOpr5";
            this.rbtOpr5.Size = new System.Drawing.Size(47, 16);
            this.rbtOpr5.TabIndex = 11;
            this.rbtOpr5.TabStop = true;
            this.rbtOpr5.Text = "角色";
            this.rbtOpr5.UseVisualStyleBackColor = true;
            this.rbtOpr5.CheckedChanged += new System.EventHandler(this.rbtOpr5_CheckedChanged);
            // 
            // btnSelectRole
            // 
            this.btnSelectRole.Enabled = false;
            this.btnSelectRole.Location = new System.Drawing.Point(277, 123);
            this.btnSelectRole.Name = "btnSelectRole";
            this.btnSelectRole.Size = new System.Drawing.Size(36, 23);
            this.btnSelectRole.TabIndex = 10;
            this.btnSelectRole.Text = "";
            this.btnSelectRole.UseVisualStyleBackColor = true;
            this.btnSelectRole.Click += new System.EventHandler(this.btnSelectRole_Click);
            // 
            // tbxOpr4
            // 
            this.tbxOpr4.Location = new System.Drawing.Point(91, 98);
            this.tbxOpr4.Name = "tbxOpr4";
            this.tbxOpr4.ReadOnly = true;
            this.tbxOpr4.Size = new System.Drawing.Size(180, 21);
            this.tbxOpr4.TabIndex = 9;
            // 
            // rbtOpr4
            // 
            this.rbtOpr4.AutoSize = true;
            this.rbtOpr4.Location = new System.Drawing.Point(11, 102);
            this.rbtOpr4.Name = "rbtOpr4";
            this.rbtOpr4.Size = new System.Drawing.Size(47, 16);
            this.rbtOpr4.TabIndex = 8;
            this.rbtOpr4.TabStop = true;
            this.rbtOpr4.Text = "部门";
            this.rbtOpr4.UseVisualStyleBackColor = true;
            this.rbtOpr4.CheckedChanged += new System.EventHandler(this.rbtOpr4_CheckedChanged);
            // 
            // tbxOpr6
            // 
            this.tbxOpr6.Location = new System.Drawing.Point(91, 151);
            this.tbxOpr6.Name = "tbxOpr6";
            this.tbxOpr6.ReadOnly = true;
            this.tbxOpr6.Size = new System.Drawing.Size(180, 21);
            this.tbxOpr6.TabIndex = 7;
            // 
            // btnSelectUser
            // 
            this.btnSelectUser.Enabled = false;
            this.btnSelectUser.Location = new System.Drawing.Point(277, 71);
            this.btnSelectUser.Name = "btnSelectUser";
            this.btnSelectUser.Size = new System.Drawing.Size(36, 23);
            this.btnSelectUser.TabIndex = 6;
            this.btnSelectUser.Text = "";
            this.btnSelectUser.UseVisualStyleBackColor = true;
            this.btnSelectUser.Click += new System.EventHandler(this.btnSelectUser_Click);
            // 
            // tbxOpr3
            // 
            this.tbxOpr3.Location = new System.Drawing.Point(91, 72);
            this.tbxOpr3.Name = "tbxOpr3";
            this.tbxOpr3.ReadOnly = true;
            this.tbxOpr3.Size = new System.Drawing.Size(180, 21);
            this.tbxOpr3.TabIndex = 5;
            // 
            // rbtOpr3
            // 
            this.rbtOpr3.AutoSize = true;
            this.rbtOpr3.Location = new System.Drawing.Point(11, 73);
            this.rbtOpr3.Name = "rbtOpr3";
            this.rbtOpr3.Size = new System.Drawing.Size(71, 16);
            this.rbtOpr3.TabIndex = 4;
            this.rbtOpr3.TabStop = true;
            this.rbtOpr3.Text = "指定人员";
            this.rbtOpr3.UseVisualStyleBackColor = true;
            this.rbtOpr3.CheckedChanged += new System.EventHandler(this.rbtOpr3_CheckedChanged);
            // 
            // btnSelectOpr
            // 
            this.btnSelectOpr.Enabled = false;
            this.btnSelectOpr.Location = new System.Drawing.Point(335, 43);
            this.btnSelectOpr.Name = "btnSelectOpr";
            this.btnSelectOpr.Size = new System.Drawing.Size(36, 23);
            this.btnSelectOpr.TabIndex = 3;
            this.btnSelectOpr.Text = "";
            this.btnSelectOpr.UseVisualStyleBackColor = true;
            this.btnSelectOpr.Click += new System.EventHandler(this.btnSelectOpr_Click);
            // 
            // tbxOpr2
            // 
            this.tbxOpr2.Location = new System.Drawing.Point(149, 45);
            this.tbxOpr2.Name = "tbxOpr2";
            this.tbxOpr2.ReadOnly = true;
            this.tbxOpr2.Size = new System.Drawing.Size(180, 21);
            this.tbxOpr2.TabIndex = 2;
            // 
            // rbtOpr2
            // 
            this.rbtOpr2.AutoSize = true;
            this.rbtOpr2.Location = new System.Drawing.Point(11, 49);
            this.rbtOpr2.Name = "rbtOpr2";
            this.rbtOpr2.Size = new System.Drawing.Size(131, 16);
            this.rbtOpr2.TabIndex = 1;
            this.rbtOpr2.TabStop = true;
            this.rbtOpr2.Text = "某一任务实际执行者";
            this.rbtOpr2.UseVisualStyleBackColor = true;
            this.rbtOpr2.CheckedChanged += new System.EventHandler(this.rbtOpr2_CheckedChanged);
            // 
            // rbtOpr1
            // 
            this.rbtOpr1.AutoSize = true;
            this.rbtOpr1.Location = new System.Drawing.Point(11, 25);
            this.rbtOpr1.Name = "rbtOpr1";
            this.rbtOpr1.Size = new System.Drawing.Size(83, 16);
            this.rbtOpr1.TabIndex = 0;
            this.rbtOpr1.TabStop = true;
            this.rbtOpr1.Text = "流程启动者";
            this.rbtOpr1.UseVisualStyleBackColor = true;
            this.rbtOpr1.CheckedChanged += new System.EventHandler(this.rbtOpr1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxRelation);
            this.groupBox2.Controls.Add(this.rbtRlt6);
            this.groupBox2.Controls.Add(this.rbtRlt5);
            this.groupBox2.Controls.Add(this.rbtRlt4);
            this.groupBox2.Controls.Add(this.rbtRlt3);
            this.groupBox2.Controls.Add(this.rbtRlt2);
            this.groupBox2.Controls.Add(this.rbtRlt1);
            this.groupBox2.Location = new System.Drawing.Point(12, 284);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 62);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // cbxRelation
            // 
            this.cbxRelation.AutoSize = true;
            this.cbxRelation.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbxRelation.Location = new System.Drawing.Point(1, 0);
            this.cbxRelation.Name = "cbxRelation";
            this.cbxRelation.Size = new System.Drawing.Size(144, 16);
            this.cbxRelation.TabIndex = 6;
            this.cbxRelation.Text = "与处理者的关系和筛选";
            this.cbxRelation.UseVisualStyleBackColor = true;
            this.cbxRelation.CheckedChanged += new System.EventHandler(this.cbxRelation_CheckedChanged);
            // 
            // rbtRlt6
            // 
            this.rbtRlt6.AutoSize = true;
            this.rbtRlt6.Enabled = false;
            this.rbtRlt6.Location = new System.Drawing.Point(119, 40);
            this.rbtRlt6.Name = "rbtRlt6";
            this.rbtRlt6.Size = new System.Drawing.Size(71, 16);
            this.rbtRlt6.TabIndex = 5;
            this.rbtRlt6.TabStop = true;
            this.rbtRlt6.Text = "下级领导";
            this.rbtRlt6.UseVisualStyleBackColor = true;
            // 
            // rbtRlt5
            // 
            this.rbtRlt5.AutoSize = true;
            this.rbtRlt5.Enabled = false;
            this.rbtRlt5.Location = new System.Drawing.Point(11, 40);
            this.rbtRlt5.Name = "rbtRlt5";
            this.rbtRlt5.Size = new System.Drawing.Size(71, 16);
            this.rbtRlt5.TabIndex = 4;
            this.rbtRlt5.TabStop = true;
            this.rbtRlt5.Text = "上级领导";
            this.rbtRlt5.UseVisualStyleBackColor = true;
            // 
            // rbtRlt4
            // 
            this.rbtRlt4.AutoSize = true;
            this.rbtRlt4.Enabled = false;
            this.rbtRlt4.Location = new System.Drawing.Point(277, 20);
            this.rbtRlt4.Name = "rbtRlt4";
            this.rbtRlt4.Size = new System.Drawing.Size(71, 16);
            this.rbtRlt4.TabIndex = 3;
            this.rbtRlt4.TabStop = true;
            this.rbtRlt4.Text = "下级部门";
            this.rbtRlt4.UseVisualStyleBackColor = true;
            // 
            // rbtRlt3
            // 
            this.rbtRlt3.AutoSize = true;
            this.rbtRlt3.Enabled = false;
            this.rbtRlt3.Location = new System.Drawing.Point(196, 21);
            this.rbtRlt3.Name = "rbtRlt3";
            this.rbtRlt3.Size = new System.Drawing.Size(71, 16);
            this.rbtRlt3.TabIndex = 2;
            this.rbtRlt3.TabStop = true;
            this.rbtRlt3.Text = "上级部门";
            this.rbtRlt3.UseVisualStyleBackColor = true;
            // 
            // rbtRlt2
            // 
            this.rbtRlt2.AutoSize = true;
            this.rbtRlt2.Enabled = false;
            this.rbtRlt2.Location = new System.Drawing.Point(119, 21);
            this.rbtRlt2.Name = "rbtRlt2";
            this.rbtRlt2.Size = new System.Drawing.Size(71, 16);
            this.rbtRlt2.TabIndex = 1;
            this.rbtRlt2.TabStop = true;
            this.rbtRlt2.Text = "所在部门";
            this.rbtRlt2.UseVisualStyleBackColor = true;
            // 
            // rbtRlt1
            // 
            this.rbtRlt1.AutoSize = true;
            this.rbtRlt1.Enabled = false;
            this.rbtRlt1.Location = new System.Drawing.Point(11, 21);
            this.rbtRlt1.Name = "rbtRlt1";
            this.rbtRlt1.Size = new System.Drawing.Size(83, 16);
            this.rbtRlt1.TabIndex = 0;
            this.rbtRlt1.TabStop = true;
            this.rbtRlt1.Text = "本部门领导";
            this.rbtRlt1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtExclude);
            this.groupBox3.Controls.Add(this.rbtInclude);
            this.groupBox3.Location = new System.Drawing.Point(12, 352);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 56);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "包含或排除";
            // 
            // rbtExclude
            // 
            this.rbtExclude.AutoSize = true;
            this.rbtExclude.Location = new System.Drawing.Point(107, 21);
            this.rbtExclude.Name = "rbtExclude";
            this.rbtExclude.Size = new System.Drawing.Size(47, 16);
            this.rbtExclude.TabIndex = 1;
            this.rbtExclude.Text = "排除";
            this.rbtExclude.UseVisualStyleBackColor = true;
            this.rbtExclude.CheckedChanged += new System.EventHandler(this.rbtExclude_CheckedChanged);
            // 
            // rbtInclude
            // 
            this.rbtInclude.AutoSize = true;
            this.rbtInclude.Checked = true;
            this.rbtInclude.Location = new System.Drawing.Point(11, 21);
            this.rbtInclude.Name = "rbtInclude";
            this.rbtInclude.Size = new System.Drawing.Size(47, 16);
            this.rbtInclude.TabIndex = 0;
            this.rbtInclude.TabStop = true;
            this.rbtInclude.Text = "包含";
            this.rbtInclude.UseVisualStyleBackColor = true;
            this.rbtInclude.CheckedChanged += new System.EventHandler(this.rbtInclude_CheckedChanged);
            // 
            // fmOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 480);
            this.Name = "fmOperator";
            this.Text = "增加处理者";
            this.Load += new System.EventHandler(this.fmOperator_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtOpr1;
        private System.Windows.Forms.Button btnSelectOpr;
        private System.Windows.Forms.TextBox tbxOpr2;
        private System.Windows.Forms.RadioButton rbtOpr2;
        private System.Windows.Forms.Button btnSelectUser;
        private System.Windows.Forms.TextBox tbxOpr3;
        private System.Windows.Forms.RadioButton rbtOpr3;
        private System.Windows.Forms.TextBox tbxOpr6;
        private System.Windows.Forms.Button btnSelectRole;
        private System.Windows.Forms.TextBox tbxOpr4;
        private System.Windows.Forms.RadioButton rbtOpr4;
        private System.Windows.Forms.RadioButton rbtOpr5;
        private System.Windows.Forms.RadioButton rbtOpr9;
        private System.Windows.Forms.RadioButton rbtOpr8;
        private System.Windows.Forms.RadioButton rbtOpr7;
        private System.Windows.Forms.RadioButton rbtOpr6;
        private System.Windows.Forms.TextBox tbxOpr8;
        private System.Windows.Forms.TextBox tbxOpr7;
        private System.Windows.Forms.TextBox tbxOpr5;
        private System.Windows.Forms.Button btnSelectTask;
        private System.Windows.Forms.Button btnSelectVar;
        private System.Windows.Forms.Button btnSelectDuty;
        private System.Windows.Forms.Button btnSelectArch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtRlt1;
        private System.Windows.Forms.RadioButton rbtRlt3;
        private System.Windows.Forms.RadioButton rbtRlt2;
        private System.Windows.Forms.RadioButton rbtRlt4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtRlt6;
        private System.Windows.Forms.RadioButton rbtRlt5;
        private System.Windows.Forms.CheckBox cbxRelation;
        private System.Windows.Forms.RadioButton rbtExclude;
        private System.Windows.Forms.RadioButton rbtInclude;

    }
}