namespace Ebada.Exam
{
    partial class FrmE_UserPrizeRecordEdit
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
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.spNUM = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lkueUser = new DevExpress.XtraEditors.LookUpEdit();
            this.lkuePrize = new DevExpress.XtraEditors.LookUpEdit();
            this.dateSendTime = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.memoRecord = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.dateExchangeTime = new DevExpress.XtraEditors.DateEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spNUM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkueUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuePrize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSendTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSendTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoRecord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateExchangeTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateExchangeTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(335, 332);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 27);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确 定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(437, 332);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取 消";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dateSendTime);
            this.groupControl1.Controls.Add(this.lkuePrize);
            this.groupControl1.Controls.Add(this.lkueUser);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.spNUM);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Location = new System.Drawing.Point(25, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(511, 151);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "兑换信息";
            // 
            // spNUM
            // 
            this.spNUM.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spNUM.Location = new System.Drawing.Point(91, 109);
            this.spNUM.Name = "spNUM";
            this.spNUM.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spNUM.Properties.MaxValue = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.spNUM.Properties.ReadOnly = true;
            this.spNUM.Size = new System.Drawing.Size(62, 21);
            this.spNUM.TabIndex = 23;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(21, 112);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "数量：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(21, 45);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 26;
            this.labelControl5.Text = "兑换人：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(21, 75);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(36, 14);
            this.labelControl6.TabIndex = 27;
            this.labelControl6.Text = "奖品：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(182, 112);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 28;
            this.labelControl4.Text = "提交日期：";
            // 
            // lkueUser
            // 
            this.lkueUser.Location = new System.Drawing.Point(91, 42);
            this.lkueUser.Name = "lkueUser";
            this.lkueUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkueUser.Properties.NullText = "选择试卷";
            this.lkueUser.Properties.ReadOnly = true;
            this.lkueUser.Size = new System.Drawing.Size(403, 21);
            this.lkueUser.TabIndex = 30;
            // 
            // lkuePrize
            // 
            this.lkuePrize.Location = new System.Drawing.Point(91, 75);
            this.lkuePrize.Name = "lkuePrize";
            this.lkuePrize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkuePrize.Properties.NullText = "选择试卷";
            this.lkuePrize.Properties.ReadOnly = true;
            this.lkuePrize.Size = new System.Drawing.Size(403, 21);
            this.lkuePrize.TabIndex = 31;
            // 
            // dateSendTime
            // 
            this.dateSendTime.EditValue = null;
            this.dateSendTime.Location = new System.Drawing.Point(260, 109);
            this.dateSendTime.Name = "dateSendTime";
            this.dateSendTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateSendTime.Properties.ReadOnly = true;
            this.dateSendTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateSendTime.Size = new System.Drawing.Size(234, 21);
            this.dateSendTime.TabIndex = 32;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 72);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "兑换记事：";
            // 
            // memoRecord
            // 
            this.memoRecord.Location = new System.Drawing.Point(82, 76);
            this.memoRecord.Name = "memoRecord";
            this.memoRecord.Size = new System.Drawing.Size(412, 53);
            this.memoRecord.TabIndex = 3;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(16, 40);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(60, 14);
            this.labelControl8.TabIndex = 29;
            this.labelControl8.Text = "兑换日期：";
            // 
            // dateExchangeTime
            // 
            this.dateExchangeTime.EditValue = null;
            this.dateExchangeTime.Location = new System.Drawing.Point(82, 37);
            this.dateExchangeTime.Name = "dateExchangeTime";
            this.dateExchangeTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateExchangeTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateExchangeTime.Size = new System.Drawing.Size(412, 21);
            this.dateExchangeTime.TabIndex = 33;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.memoRecord);
            this.groupControl2.Controls.Add(this.dateExchangeTime);
            this.groupControl2.Controls.Add(this.labelControl8);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Location = new System.Drawing.Point(25, 171);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(511, 151);
            this.groupControl2.TabIndex = 33;
            this.groupControl2.Text = "确认兑换";
            // 
            // FrmE_UserPrizeRecordEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 371);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "FrmE_UserPrizeRecordEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "支付奖品";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spNUM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkueUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuePrize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSendTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateSendTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoRecord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateExchangeTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateExchangeTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit spNUM;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit lkuePrize;
        private DevExpress.XtraEditors.LookUpEdit lkueUser;
        private DevExpress.XtraEditors.DateEdit dateSendTime;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit memoRecord;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.DateEdit dateExchangeTime;
        private DevExpress.XtraEditors.GroupControl groupControl2;
    }
}