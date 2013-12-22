namespace Ebada.Exam
{
    partial class FrmE_UUserBuyPrize
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.spPriceScore = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.spPrizeLeftNum = new DevExpress.XtraEditors.SpinEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.spBuyNum = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labShowScore = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spPriceScore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPrizeLeftNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spBuyNum.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(278, 176);
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
            this.btnCancel.Location = new System.Drawing.Point(380, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取 消";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.spPrizeLeftNum);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.spPriceScore);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(25, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(439, 69);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "奖品信息";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(0, 14);
            this.labelControl1.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(84, 14);
            this.labelControl2.TabIndex = 29;
            this.labelControl2.Text = "将品价值分数：";
            // 
            // spPriceScore
            // 
            this.spPriceScore.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spPriceScore.Location = new System.Drawing.Point(113, 31);
            this.spPriceScore.Name = "spPriceScore";
            this.spPriceScore.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spPriceScore.Properties.MaxValue = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.spPriceScore.Properties.ReadOnly = true;
            this.spPriceScore.Size = new System.Drawing.Size(102, 21);
            this.spPriceScore.TabIndex = 28;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(243, 34);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 31;
            this.labelControl3.Text = "剩余数量：";
            // 
            // spPrizeLeftNum
            // 
            this.spPrizeLeftNum.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spPrizeLeftNum.Location = new System.Drawing.Point(310, 31);
            this.spPrizeLeftNum.Name = "spPrizeLeftNum";
            this.spPrizeLeftNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spPrizeLeftNum.Properties.MaxValue = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.spPrizeLeftNum.Properties.ReadOnly = true;
            this.spPrizeLeftNum.Size = new System.Drawing.Size(102, 21);
            this.spPrizeLeftNum.TabIndex = 30;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Controls.Add(this.spBuyNum);
            this.groupControl2.Controls.Add(this.labelControl8);
            this.groupControl2.Location = new System.Drawing.Point(25, 87);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(439, 77);
            this.groupControl2.TabIndex = 32;
            this.groupControl2.Text = "兑换信息";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(23, 36);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 14);
            this.labelControl7.TabIndex = 27;
            this.labelControl7.Text = "兑换数量：";
            // 
            // spBuyNum
            // 
            this.spBuyNum.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spBuyNum.Location = new System.Drawing.Point(90, 33);
            this.spBuyNum.Name = "spBuyNum";
            this.spBuyNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spBuyNum.Properties.MaxValue = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.spBuyNum.Size = new System.Drawing.Size(322, 21);
            this.spBuyNum.TabIndex = 24;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(23, 40);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(0, 14);
            this.labelControl8.TabIndex = 0;
            // 
            // labShowScore
            // 
            this.labShowScore.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labShowScore.Appearance.Options.UseForeColor = true;
            this.labShowScore.Location = new System.Drawing.Point(25, 176);
            this.labShowScore.Name = "labShowScore";
            this.labShowScore.Size = new System.Drawing.Size(108, 14);
            this.labShowScore.TabIndex = 32;
            this.labShowScore.Text = "您当前可用分数为：";
            // 
            // FrmE_UUserBuyPrize
            // 
            this.Appearance.ForeColor = System.Drawing.Color.Red;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 215);
            this.Controls.Add(this.labShowScore);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "FrmE_UUserBuyPrize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "兑换奖品";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spPriceScore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPrizeLeftNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spBuyNum.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit spPrizeLeftNum;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit spPriceScore;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SpinEdit spBuyNum;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labShowScore;
    }
}