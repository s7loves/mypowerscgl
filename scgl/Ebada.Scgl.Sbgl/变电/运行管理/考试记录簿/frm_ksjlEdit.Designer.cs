namespace Ebada.Scgl.Sbgl
{
    partial class frm_ksjlEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExamEndTime = new DevExpress.XtraEditors.TimeEdit();
            this.lblExamEndTime = new DevExpress.XtraEditors.LabelControl();
            this.timeStartTime = new DevExpress.XtraEditors.TimeEdit();
            this.lblExamStartTime = new DevExpress.XtraEditors.LabelControl();
            this.dateLastExamTime = new DevExpress.XtraEditors.DateEdit();
            this.lblLastExamTime = new DevExpress.XtraEditors.LabelControl();
            this.spePostAge = new DevExpress.XtraEditors.SpinEdit();
            this.lblpostage = new DevExpress.XtraEditors.LabelControl();
            this.txtPostName = new DevExpress.XtraEditors.TextEdit();
            this.lblpostname = new DevExpress.XtraEditors.LabelControl();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.lblusername = new DevExpress.XtraEditors.LabelControl();
            this.cmbksxm = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblksxm = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExamEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateLastExamTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateLastExamTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spePostAge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbksxm.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ExamEndTime);
            this.groupBox1.Controls.Add(this.lblExamEndTime);
            this.groupBox1.Controls.Add(this.timeStartTime);
            this.groupBox1.Controls.Add(this.lblExamStartTime);
            this.groupBox1.Controls.Add(this.dateLastExamTime);
            this.groupBox1.Controls.Add(this.lblLastExamTime);
            this.groupBox1.Controls.Add(this.spePostAge);
            this.groupBox1.Controls.Add(this.lblpostage);
            this.groupBox1.Controls.Add(this.txtPostName);
            this.groupBox1.Controls.Add(this.lblpostname);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.lblusername);
            this.groupBox1.Controls.Add(this.cmbksxm);
            this.groupBox1.Controls.Add(this.lblksxm);
            this.groupBox1.Location = new System.Drawing.Point(26, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 289);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "考试记录信息";
            // 
            // ExamEndTime
            // 
            this.ExamEndTime.EditValue = new System.DateTime(2013, 7, 5, 0, 0, 0, 0);
            this.ExamEndTime.Location = new System.Drawing.Point(127, 230);
            this.ExamEndTime.Name = "ExamEndTime";
            this.ExamEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ExamEndTime.Size = new System.Drawing.Size(242, 21);
            this.ExamEndTime.TabIndex = 13;
            // 
            // lblExamEndTime
            // 
            this.lblExamEndTime.Location = new System.Drawing.Point(25, 234);
            this.lblExamEndTime.Name = "lblExamEndTime";
            this.lblExamEndTime.Size = new System.Drawing.Size(72, 14);
            this.lblExamEndTime.TabIndex = 12;
            this.lblExamEndTime.Text = "考试结束时间";
            // 
            // timeStartTime
            // 
            this.timeStartTime.EditValue = new System.DateTime(2013, 7, 5, 0, 0, 0, 0);
            this.timeStartTime.Location = new System.Drawing.Point(127, 197);
            this.timeStartTime.Name = "timeStartTime";
            this.timeStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeStartTime.Size = new System.Drawing.Size(242, 21);
            this.timeStartTime.TabIndex = 11;
            // 
            // lblExamStartTime
            // 
            this.lblExamStartTime.Location = new System.Drawing.Point(25, 199);
            this.lblExamStartTime.Name = "lblExamStartTime";
            this.lblExamStartTime.Size = new System.Drawing.Size(72, 14);
            this.lblExamStartTime.TabIndex = 10;
            this.lblExamStartTime.Text = "考试开始时间";
            // 
            // dateLastExamTime
            // 
            this.dateLastExamTime.EditValue = null;
            this.dateLastExamTime.Location = new System.Drawing.Point(127, 164);
            this.dateLastExamTime.Name = "dateLastExamTime";
            this.dateLastExamTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateLastExamTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateLastExamTime.Size = new System.Drawing.Size(242, 21);
            this.dateLastExamTime.TabIndex = 9;
            // 
            // lblLastExamTime
            // 
            this.lblLastExamTime.Location = new System.Drawing.Point(25, 166);
            this.lblLastExamTime.Name = "lblLastExamTime";
            this.lblLastExamTime.Size = new System.Drawing.Size(96, 14);
            this.lblLastExamTime.TabIndex = 8;
            this.lblLastExamTime.Text = "最近一次考试日期";
            // 
            // spePostAge
            // 
            this.spePostAge.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spePostAge.Location = new System.Drawing.Point(127, 131);
            this.spePostAge.Name = "spePostAge";
            this.spePostAge.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spePostAge.Size = new System.Drawing.Size(242, 21);
            this.spePostAge.TabIndex = 7;
            // 
            // lblpostage
            // 
            this.lblpostage.Location = new System.Drawing.Point(25, 134);
            this.lblpostage.Name = "lblpostage";
            this.lblpostage.Size = new System.Drawing.Size(60, 14);
            this.lblpostage.TabIndex = 6;
            this.lblpostage.Text = "本职位工龄";
            // 
            // txtPostName
            // 
            this.txtPostName.Enabled = false;
            this.txtPostName.Location = new System.Drawing.Point(127, 98);
            this.txtPostName.Name = "txtPostName";
            this.txtPostName.Size = new System.Drawing.Size(242, 21);
            this.txtPostName.TabIndex = 5;
            // 
            // lblpostname
            // 
            this.lblpostname.Location = new System.Drawing.Point(25, 101);
            this.lblpostname.Name = "lblpostname";
            this.lblpostname.Size = new System.Drawing.Size(24, 14);
            this.lblpostname.TabIndex = 4;
            this.lblpostname.Text = "职称";
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(127, 65);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(242, 21);
            this.txtUserName.TabIndex = 3;
            // 
            // lblusername
            // 
            this.lblusername.Location = new System.Drawing.Point(25, 70);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(24, 14);
            this.lblusername.TabIndex = 2;
            this.lblusername.Text = "姓名";
            // 
            // cmbksxm
            // 
            this.cmbksxm.Location = new System.Drawing.Point(127, 32);
            this.cmbksxm.Name = "cmbksxm";
            this.cmbksxm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbksxm.Size = new System.Drawing.Size(242, 21);
            this.cmbksxm.TabIndex = 1;
            // 
            // lblksxm
            // 
            this.lblksxm.Location = new System.Drawing.Point(25, 35);
            this.lblksxm.Name = "lblksxm";
            this.lblksxm.Size = new System.Drawing.Size(48, 14);
            this.lblksxm.TabIndex = 0;
            this.lblksxm.Text = "考试项目";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(261, 307);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(361, 307);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            // 
            // frm_ksjlEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 340);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_ksjlEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考试记录";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExamEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateLastExamTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateLastExamTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spePostAge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbksxm.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.TextEdit txtPostName;
        private DevExpress.XtraEditors.LabelControl lblpostname;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl lblusername;
        private DevExpress.XtraEditors.ComboBoxEdit cmbksxm;
        private DevExpress.XtraEditors.LabelControl lblksxm;
        private DevExpress.XtraEditors.TimeEdit ExamEndTime;
        private DevExpress.XtraEditors.LabelControl lblExamEndTime;
        private DevExpress.XtraEditors.TimeEdit timeStartTime;
        private DevExpress.XtraEditors.LabelControl lblExamStartTime;
        private DevExpress.XtraEditors.DateEdit dateLastExamTime;
        private DevExpress.XtraEditors.LabelControl lblLastExamTime;
        private DevExpress.XtraEditors.SpinEdit spePostAge;
        private DevExpress.XtraEditors.LabelControl lblpostage;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;


    }
}