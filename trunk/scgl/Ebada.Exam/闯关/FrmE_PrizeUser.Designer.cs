namespace Ebada.Exam
{
    partial class FrmE_PrizeUser
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.ucE_PrizeLeft1 = new Ebada.Exam.UCE_PrizeLeft();
            this.ucE_UserPrizeRecordBy1 = new Ebada.Exam.UCE_UserPrizeRecordBy();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(884, 352);
            this.splitContainerControl1.SplitterPosition = 407;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.ucE_UserPrizeRecordBy1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(471, 352);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "个人兑换奖品记录";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.ucE_PrizeLeft1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(407, 352);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "可兑换奖品列表";
            // 
            // ucE_PrizeLeft1
            // 
            this.ucE_PrizeLeft1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucE_PrizeLeft1.Location = new System.Drawing.Point(2, 23);
            this.ucE_PrizeLeft1.Name = "ucE_PrizeLeft1";
            this.ucE_PrizeLeft1.Size = new System.Drawing.Size(403, 327);
            this.ucE_PrizeLeft1.TabIndex = 0;
            // 
            // ucE_UserPrizeRecordBy1
            // 
            this.ucE_UserPrizeRecordBy1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucE_UserPrizeRecordBy1.Location = new System.Drawing.Point(2, 23);
            this.ucE_UserPrizeRecordBy1.Name = "ucE_UserPrizeRecordBy1";
            this.ucE_UserPrizeRecordBy1.Size = new System.Drawing.Size(467, 327);
            this.ucE_UserPrizeRecordBy1.TabIndex = 0;
            // 
            // FrmE_PrizeUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 352);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FrmE_PrizeUser";
            this.Text = "FrmE_PrizeUser";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private UCE_PrizeLeft ucE_PrizeLeft1;
        private UCE_UserPrizeRecordBy ucE_UserPrizeRecordBy1;
    }
}