namespace Ebada.Scgl.Yxgl
{
    partial class frmyxfa
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
            this.lblyxtm = new DevExpress.XtraEditors.LabelControl();
            this.txtyxtm = new DevExpress.XtraEditors.TextEdit();
            this.lblyxfa = new DevExpress.XtraEditors.LabelControl();
            this.memoyxfa = new DevExpress.XtraEditors.MemoEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtyxtm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoyxfa.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblyxtm
            // 
            this.lblyxtm.Location = new System.Drawing.Point(21, 33);
            this.lblyxtm.Name = "lblyxtm";
            this.lblyxtm.Size = new System.Drawing.Size(48, 14);
            this.lblyxtm.TabIndex = 0;
            this.lblyxtm.Text = "演习题目";
            // 
            // txtyxtm
            // 
            this.txtyxtm.Location = new System.Drawing.Point(84, 30);
            this.txtyxtm.Name = "txtyxtm";
            this.txtyxtm.Size = new System.Drawing.Size(473, 21);
            this.txtyxtm.TabIndex = 1;
            // 
            // lblyxfa
            // 
            this.lblyxfa.Location = new System.Drawing.Point(21, 69);
            this.lblyxfa.Name = "lblyxfa";
            this.lblyxfa.Size = new System.Drawing.Size(48, 14);
            this.lblyxfa.TabIndex = 2;
            this.lblyxfa.Text = "演习方案";
            // 
            // memoyxfa
            // 
            this.memoyxfa.Location = new System.Drawing.Point(84, 67);
            this.memoyxfa.Name = "memoyxfa";
            this.memoyxfa.Size = new System.Drawing.Size(473, 362);
            this.memoyxfa.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(351, 443);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(454, 443);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmyxfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 478);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.memoyxfa);
            this.Controls.Add(this.lblyxfa);
            this.Controls.Add(this.txtyxtm);
            this.Controls.Add(this.lblyxtm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmyxfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "反事故演习方案";
            ((System.ComponentModel.ISupportInitialize)(this.txtyxtm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoyxfa.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblyxtm;
        private DevExpress.XtraEditors.TextEdit txtyxtm;
        private DevExpress.XtraEditors.LabelControl lblyxfa;
        private DevExpress.XtraEditors.MemoEdit memoyxfa;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;

    }
}