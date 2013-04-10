namespace Ebada.Scgl.Sbgl
{
    partial class frm_gzjlzb
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
            this.lblsj = new DevExpress.XtraEditors.LabelControl();
            this.timesj = new DevExpress.XtraEditors.TimeEdit();
            this.lblnr = new DevExpress.XtraEditors.LabelControl();
            this.memonr = new DevExpress.XtraEditors.MemoEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.timesj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memonr.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblsj
            // 
            this.lblsj.Location = new System.Drawing.Point(39, 45);
            this.lblsj.Name = "lblsj";
            this.lblsj.Size = new System.Drawing.Size(24, 14);
            this.lblsj.TabIndex = 0;
            this.lblsj.Text = "时间";
            // 
            // timesj
            // 
            this.timesj.EditValue = new System.DateTime(2013, 4, 10, 0, 0, 0, 0);
            this.timesj.Location = new System.Drawing.Point(89, 45);
            this.timesj.Name = "timesj";
            this.timesj.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timesj.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.timesj.Size = new System.Drawing.Size(356, 21);
            this.timesj.TabIndex = 1;
            // 
            // lblnr
            // 
            this.lblnr.Location = new System.Drawing.Point(39, 97);
            this.lblnr.Name = "lblnr";
            this.lblnr.Size = new System.Drawing.Size(24, 14);
            this.lblnr.TabIndex = 2;
            this.lblnr.Text = "内容";
            // 
            // memonr
            // 
            this.memonr.Location = new System.Drawing.Point(89, 82);
            this.memonr.Name = "memonr";
            this.memonr.Size = new System.Drawing.Size(356, 129);
            this.memonr.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(247, 240);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(357, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frm_gzjlzb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 275);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.memonr);
            this.Controls.Add(this.lblnr);
            this.Controls.Add(this.timesj);
            this.Controls.Add(this.lblsj);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_gzjlzb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工作记录内容";
            ((System.ComponentModel.ISupportInitialize)(this.timesj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memonr.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblsj;
        private DevExpress.XtraEditors.TimeEdit timesj;
        private DevExpress.XtraEditors.LabelControl lblnr;
        private DevExpress.XtraEditors.MemoEdit memonr;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}