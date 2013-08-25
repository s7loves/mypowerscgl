namespace Ebada.Exam
{
    partial class UcEBNK
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ucE_QBank1 = new Ebada.Exam.UCE_QBank();
            this.ucE_R_EBankPro1 = new Ebada.Exam.UCE_R_EBankPro();
            this.ucE_R_EBankORG1 = new Ebada.Exam.UCE_R_EBankORG();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.ucE_QBank1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerControl1.Size = new System.Drawing.Size(534, 434);
            this.splitContainerControl1.SplitterPosition = 287;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.ucE_R_EBankPro1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.ucE_R_EBankORG1);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerControl2.Size = new System.Drawing.Size(534, 287);
            this.splitContainerControl2.SplitterPosition = 278;
            this.splitContainerControl2.TabIndex = 1;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // ucE_QBank1
            // 
            this.ucE_QBank1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucE_QBank1.Location = new System.Drawing.Point(0, 0);
            this.ucE_QBank1.Name = "ucE_QBank1";
            this.ucE_QBank1.Size = new System.Drawing.Size(534, 141);
            this.ucE_QBank1.TabIndex = 0;
            // 
            // ucE_R_EBankPro1
            // 
            this.ucE_R_EBankPro1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucE_R_EBankPro1.Location = new System.Drawing.Point(0, 0);
            this.ucE_R_EBankPro1.Name = "ucE_R_EBankPro1";
            this.ucE_R_EBankPro1.Size = new System.Drawing.Size(250, 287);
            this.ucE_R_EBankPro1.TabIndex = 0;
            // 
            // ucE_R_EBankORG1
            // 
            this.ucE_R_EBankORG1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucE_R_EBankORG1.Location = new System.Drawing.Point(0, 0);
            this.ucE_R_EBankORG1.Name = "ucE_R_EBankORG1";
            this.ucE_R_EBankORG1.Size = new System.Drawing.Size(278, 287);
            this.ucE_R_EBankORG1.TabIndex = 0;
            // 
            // UcEBNK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "UcEBNK";
            this.Size = new System.Drawing.Size(534, 434);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private UCE_QBank ucE_QBank1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private UCE_R_EBankPro ucE_R_EBankPro1;
        private UCE_R_EBankORG ucE_R_EBankORG1;
    }
}
