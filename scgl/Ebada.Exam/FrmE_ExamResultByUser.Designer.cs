namespace Ebada.Exam
{
    partial class FrmE_ExamResultByUser
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
            this.ucE_ExamResult1 = new Ebada.Exam.UCE_ExamResult();
            this.SuspendLayout();
            // 
            // ucE_ExamResult1
            // 
            this.ucE_ExamResult1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucE_ExamResult1.Location = new System.Drawing.Point(0, 0);
            this.ucE_ExamResult1.Name = "ucE_ExamResult1";
            this.ucE_ExamResult1.Size = new System.Drawing.Size(518, 306);
            this.ucE_ExamResult1.TabIndex = 0;
            // 
            // FrmE_ExamResultByUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 306);
            this.Controls.Add(this.ucE_ExamResult1);
            this.Name = "FrmE_ExamResultByUser";
            this.Text = "查看考试结果";
            this.ResumeLayout(false);

        }

        #endregion

        private UCE_ExamResult ucE_ExamResult1;
    }
}