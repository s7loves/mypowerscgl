namespace Ebada.jhgl
{
    partial class frmJH_weekmanEdit
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
            this.txtCommentMan = new DevExpress.XtraEditors.TextEdit();
            this.lblCommentMan = new DevExpress.XtraEditors.LabelControl();
            this.meUnCompleteReason = new DevExpress.XtraEditors.MemoEdit();
            this.lblUnCompleteReason = new DevExpress.XtraEditors.LabelControl();
            this.meSummryUp = new DevExpress.XtraEditors.MemoEdit();
            this.lblSumryUp = new DevExpress.XtraEditors.LabelControl();
            this.dateCompleteDate = new DevExpress.XtraEditors.DateEdit();
            this.lblCompleteTime = new DevExpress.XtraEditors.LabelControl();
            this.lblComplete = new DevExpress.XtraEditors.LabelControl();
            this.dateEndDate = new DevExpress.XtraEditors.DateEdit();
            this.lblEndDate = new DevExpress.XtraEditors.LabelControl();
            this.dateStartDate = new DevExpress.XtraEditors.DateEdit();
            this.lblStartDate = new DevExpress.XtraEditors.LabelControl();
            this.lblCooperationMan = new DevExpress.XtraEditors.LabelControl();
            this.meWorkContent = new DevExpress.XtraEditors.MemoEdit();
            this.lblWorkContent = new DevExpress.XtraEditors.LabelControl();
            this.mePlanPro = new DevExpress.XtraEditors.MemoEdit();
            this.lblPlanPro = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.cbxCompleteStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.meCooperationMan = new DevExpress.XtraEditors.MemoEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommentMan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meUnCompleteReason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meSummryUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCompleteDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCompleteDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStartDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meWorkContent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mePlanPro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCompleteStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meCooperationMan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.meCooperationMan);
            this.groupBox1.Controls.Add(this.cbxCompleteStatus);
            this.groupBox1.Controls.Add(this.txtCommentMan);
            this.groupBox1.Controls.Add(this.lblCommentMan);
            this.groupBox1.Controls.Add(this.meUnCompleteReason);
            this.groupBox1.Controls.Add(this.lblUnCompleteReason);
            this.groupBox1.Controls.Add(this.meSummryUp);
            this.groupBox1.Controls.Add(this.lblSumryUp);
            this.groupBox1.Controls.Add(this.dateCompleteDate);
            this.groupBox1.Controls.Add(this.lblCompleteTime);
            this.groupBox1.Controls.Add(this.lblComplete);
            this.groupBox1.Controls.Add(this.dateEndDate);
            this.groupBox1.Controls.Add(this.lblEndDate);
            this.groupBox1.Controls.Add(this.dateStartDate);
            this.groupBox1.Controls.Add(this.lblStartDate);
            this.groupBox1.Controls.Add(this.lblCooperationMan);
            this.groupBox1.Controls.Add(this.meWorkContent);
            this.groupBox1.Controls.Add(this.lblWorkContent);
            this.groupBox1.Controls.Add(this.mePlanPro);
            this.groupBox1.Controls.Add(this.lblPlanPro);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 481);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "周计划信息";
            // 
            // txtCommentMan
            // 
            this.txtCommentMan.Location = new System.Drawing.Point(109, 432);
            this.txtCommentMan.Name = "txtCommentMan";
            this.txtCommentMan.Size = new System.Drawing.Size(374, 21);
            this.txtCommentMan.TabIndex = 21;
            // 
            // lblCommentMan
            // 
            this.lblCommentMan.Location = new System.Drawing.Point(27, 432);
            this.lblCommentMan.Name = "lblCommentMan";
            this.lblCommentMan.Size = new System.Drawing.Size(60, 14);
            this.lblCommentMan.TabIndex = 20;
            this.lblCommentMan.Text = "评语考核人";
            // 
            // meUnCompleteReason
            // 
            this.meUnCompleteReason.Location = new System.Drawing.Point(109, 373);
            this.meUnCompleteReason.Name = "meUnCompleteReason";
            this.meUnCompleteReason.Size = new System.Drawing.Size(374, 53);
            this.meUnCompleteReason.TabIndex = 19;
            // 
            // lblUnCompleteReason
            // 
            this.lblUnCompleteReason.Location = new System.Drawing.Point(27, 373);
            this.lblUnCompleteReason.Name = "lblUnCompleteReason";
            this.lblUnCompleteReason.Size = new System.Drawing.Size(60, 14);
            this.lblUnCompleteReason.TabIndex = 18;
            this.lblUnCompleteReason.Text = "未完成原因";
            // 
            // meSummryUp
            // 
            this.meSummryUp.Location = new System.Drawing.Point(109, 315);
            this.meSummryUp.Name = "meSummryUp";
            this.meSummryUp.Size = new System.Drawing.Size(374, 52);
            this.meSummryUp.TabIndex = 17;
            // 
            // lblSumryUp
            // 
            this.lblSumryUp.Location = new System.Drawing.Point(27, 315);
            this.lblSumryUp.Name = "lblSumryUp";
            this.lblSumryUp.Size = new System.Drawing.Size(48, 14);
            this.lblSumryUp.TabIndex = 16;
            this.lblSumryUp.Text = "总结提升";
            // 
            // dateCompleteDate
            // 
            this.dateCompleteDate.EditValue = null;
            this.dateCompleteDate.Location = new System.Drawing.Point(109, 288);
            this.dateCompleteDate.Name = "dateCompleteDate";
            this.dateCompleteDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateCompleteDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateCompleteDate.Size = new System.Drawing.Size(374, 21);
            this.dateCompleteDate.TabIndex = 15;
            // 
            // lblCompleteTime
            // 
            this.lblCompleteTime.Location = new System.Drawing.Point(27, 288);
            this.lblCompleteTime.Name = "lblCompleteTime";
            this.lblCompleteTime.Size = new System.Drawing.Size(48, 14);
            this.lblCompleteTime.TabIndex = 14;
            this.lblCompleteTime.Text = "完成时间";
            // 
            // lblComplete
            // 
            this.lblComplete.Location = new System.Drawing.Point(27, 261);
            this.lblComplete.Name = "lblComplete";
            this.lblComplete.Size = new System.Drawing.Size(48, 14);
            this.lblComplete.TabIndex = 12;
            this.lblComplete.Text = "完成标记";
            // 
            // dateEndDate
            // 
            this.dateEndDate.EditValue = null;
            this.dateEndDate.Location = new System.Drawing.Point(109, 234);
            this.dateEndDate.Name = "dateEndDate";
            this.dateEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEndDate.Size = new System.Drawing.Size(374, 21);
            this.dateEndDate.TabIndex = 11;
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(27, 234);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(48, 14);
            this.lblEndDate.TabIndex = 10;
            this.lblEndDate.Text = "结束日期";
            // 
            // dateStartDate
            // 
            this.dateStartDate.EditValue = null;
            this.dateStartDate.Location = new System.Drawing.Point(109, 207);
            this.dateStartDate.Name = "dateStartDate";
            this.dateStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStartDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateStartDate.Size = new System.Drawing.Size(374, 21);
            this.dateStartDate.TabIndex = 9;
            // 
            // lblStartDate
            // 
            this.lblStartDate.Location = new System.Drawing.Point(27, 207);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(48, 14);
            this.lblStartDate.TabIndex = 8;
            this.lblStartDate.Text = "开始日期";
            // 
            // lblCooperationMan
            // 
            this.lblCooperationMan.Location = new System.Drawing.Point(27, 144);
            this.lblCooperationMan.Name = "lblCooperationMan";
            this.lblCooperationMan.Size = new System.Drawing.Size(48, 14);
            this.lblCooperationMan.TabIndex = 6;
            this.lblCooperationMan.Text = "协作人员";
            // 
            // meWorkContent
            // 
            this.meWorkContent.Location = new System.Drawing.Point(109, 80);
            this.meWorkContent.Name = "meWorkContent";
            this.meWorkContent.Size = new System.Drawing.Size(374, 58);
            this.meWorkContent.TabIndex = 5;
            // 
            // lblWorkContent
            // 
            this.lblWorkContent.Location = new System.Drawing.Point(27, 80);
            this.lblWorkContent.Name = "lblWorkContent";
            this.lblWorkContent.Size = new System.Drawing.Size(48, 14);
            this.lblWorkContent.TabIndex = 4;
            this.lblWorkContent.Text = "工作内容";
            // 
            // mePlanPro
            // 
            this.mePlanPro.Location = new System.Drawing.Point(109, 21);
            this.mePlanPro.Name = "mePlanPro";
            this.mePlanPro.Size = new System.Drawing.Size(374, 53);
            this.mePlanPro.TabIndex = 3;
            // 
            // lblPlanPro
            // 
            this.lblPlanPro.Location = new System.Drawing.Point(27, 21);
            this.lblPlanPro.Name = "lblPlanPro";
            this.lblPlanPro.Size = new System.Drawing.Size(48, 14);
            this.lblPlanPro.TabIndex = 2;
            this.lblPlanPro.Text = "计划项目";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(299, 489);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(389, 489);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbxCompleteStatus
            // 
            this.cbxCompleteStatus.Location = new System.Drawing.Point(109, 261);
            this.cbxCompleteStatus.Name = "cbxCompleteStatus";
            this.cbxCompleteStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxCompleteStatus.Size = new System.Drawing.Size(372, 21);
            this.cbxCompleteStatus.TabIndex = 22;
            // 
            // meCooperationMan
            // 
            this.meCooperationMan.Location = new System.Drawing.Point(109, 144);
            this.meCooperationMan.Name = "meCooperationMan";
            this.meCooperationMan.Size = new System.Drawing.Size(372, 57);
            this.meCooperationMan.TabIndex = 23;
            // 
            // frmJH_weekmanEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 520);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmJH_weekmanEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "员工周计划";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommentMan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meUnCompleteReason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meSummryUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCompleteDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCompleteDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStartDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meWorkContent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mePlanPro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCompleteStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meCooperationMan.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl lblPlanPro;
        private DevExpress.XtraEditors.MemoEdit mePlanPro;
        private DevExpress.XtraEditors.LabelControl lblWorkContent;
        private DevExpress.XtraEditors.MemoEdit meWorkContent;
        private DevExpress.XtraEditors.LabelControl lblCooperationMan;
        private DevExpress.XtraEditors.LabelControl lblStartDate;
        private DevExpress.XtraEditors.DateEdit dateEndDate;
        private DevExpress.XtraEditors.LabelControl lblEndDate;
        private DevExpress.XtraEditors.DateEdit dateStartDate;
        private DevExpress.XtraEditors.LabelControl lblComplete;
        private DevExpress.XtraEditors.DateEdit dateCompleteDate;
        private DevExpress.XtraEditors.LabelControl lblCompleteTime;
        private DevExpress.XtraEditors.LabelControl lblUnCompleteReason;
        private DevExpress.XtraEditors.MemoEdit meSummryUp;
        private DevExpress.XtraEditors.LabelControl lblSumryUp;
        private DevExpress.XtraEditors.LabelControl lblCommentMan;
        private DevExpress.XtraEditors.MemoEdit meUnCompleteReason;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit txtCommentMan;
        private DevExpress.XtraEditors.ComboBoxEdit cbxCompleteStatus;
        private DevExpress.XtraEditors.MemoEdit meCooperationMan;

    }
}