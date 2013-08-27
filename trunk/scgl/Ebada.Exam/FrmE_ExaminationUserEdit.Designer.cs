namespace Ebada.Exam
{
    partial class FrmE_ExaminationUserEdit
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
            this.uCmOrgUserTree1 = new Ebada.Exam.UCmOrgUserTree();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uCmOrgUserTree1
            // 
            this.uCmOrgUserTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uCmOrgUserTree1.Location = new System.Drawing.Point(0, 0);
            this.uCmOrgUserTree1.Name = "uCmOrgUserTree1";
            this.uCmOrgUserTree1.OrgIDAll = null;
            this.uCmOrgUserTree1.OrgIDs = null;
            this.uCmOrgUserTree1.Size = new System.Drawing.Size(605, 386);
            this.uCmOrgUserTree1.TabIndex = 0;
            this.uCmOrgUserTree1.UserIDs = null;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uCmOrgUserTree1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 386);
            this.panel1.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(423, 404);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确 定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(508, 404);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取 消";
            // 
            // FrmE_ExaminationUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 439);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmE_ExaminationUserEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑考试对象";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UCmOrgUserTree uCmOrgUserTree1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}