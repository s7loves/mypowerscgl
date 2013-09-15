namespace Ebada.Exam
{
    partial class Ucm_EaddQuestion
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.ucE_QuestionBankForAdd1 = new Ebada.Exam.UCE_QuestionBankForAdd();
            this.ucE_QuestionBankForAdd2 = new Ebada.Exam.UCE_QuestionBankForAdd();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupControl2);
            this.splitContainer1.Size = new System.Drawing.Size(869, 437);
            this.splitContainer1.SplitterDistance = 440;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.ucE_QuestionBankForAdd1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(440, 437);
            this.groupControl1.TabIndex = 33;
            this.groupControl1.Text = "可选试题（双击某行即可选中试题）";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.ucE_QuestionBankForAdd2);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(425, 437);
            this.groupControl2.TabIndex = 34;
            this.groupControl2.Text = "已选试题（双击某行即可移除试题）";
            // 
            // ucE_QuestionBankForAdd1
            // 
            this.ucE_QuestionBankForAdd1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucE_QuestionBankForAdd1.Location = new System.Drawing.Point(2, 23);
            this.ucE_QuestionBankForAdd1.Name = "ucE_QuestionBankForAdd1";
            this.ucE_QuestionBankForAdd1.Size = new System.Drawing.Size(436, 412);
            this.ucE_QuestionBankForAdd1.TabIndex = 0;
            // 
            // ucE_QuestionBankForAdd2
            // 
            this.ucE_QuestionBankForAdd2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucE_QuestionBankForAdd2.Location = new System.Drawing.Point(2, 23);
            this.ucE_QuestionBankForAdd2.Name = "ucE_QuestionBankForAdd2";
            this.ucE_QuestionBankForAdd2.Size = new System.Drawing.Size(421, 412);
            this.ucE_QuestionBankForAdd2.TabIndex = 0;
            // 
            // Ucm_EaddQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Ucm_EaddQuestion";
            this.Size = new System.Drawing.Size(869, 437);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private UCE_QuestionBankForAdd ucE_QuestionBankForAdd1;
        private UCE_QuestionBankForAdd ucE_QuestionBankForAdd2;
    }
}
