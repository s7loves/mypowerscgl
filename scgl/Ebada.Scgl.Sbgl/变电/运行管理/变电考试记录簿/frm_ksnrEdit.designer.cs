namespace Ebada.Scgl.Sbgl
{
    partial class frm_ksnrEdit
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
            this.btnpj = new DevExpress.XtraEditors.SimpleButton();
            this.memopj = new DevExpress.XtraEditors.MemoEdit();
            this.lblpj = new DevExpress.XtraEditors.LabelControl();
            this.btnnr = new DevExpress.XtraEditors.SimpleButton();
            this.memonr = new DevExpress.XtraEditors.MemoEdit();
            this.lblnr = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memopj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memonr.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnpj);
            this.groupBox1.Controls.Add(this.memopj);
            this.groupBox1.Controls.Add(this.lblpj);
            this.groupBox1.Controls.Add(this.btnnr);
            this.groupBox1.Controls.Add(this.memonr);
            this.groupBox1.Controls.Add(this.lblnr);
            this.groupBox1.Location = new System.Drawing.Point(26, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 289);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "考试内容信息";
            // 
            // btnpj
            // 
            this.btnpj.Location = new System.Drawing.Point(361, 181);
            this.btnpj.Name = "btnpj";
            this.btnpj.Size = new System.Drawing.Size(43, 23);
            this.btnpj.TabIndex = 5;
            this.btnpj.Text = "...";
            this.btnpj.Click += new System.EventHandler(this.btnpj_Click);
            // 
            // memopj
            // 
            this.memopj.Location = new System.Drawing.Point(87, 179);
            this.memopj.Name = "memopj";
            this.memopj.Size = new System.Drawing.Size(267, 88);
            this.memopj.TabIndex = 4;
            // 
            // lblpj
            // 
            this.lblpj.Location = new System.Drawing.Point(22, 181);
            this.lblpj.Name = "lblpj";
            this.lblpj.Size = new System.Drawing.Size(24, 14);
            this.lblpj.TabIndex = 3;
            this.lblpj.Text = "评价";
            // 
            // btnnr
            // 
            this.btnnr.Location = new System.Drawing.Point(361, 43);
            this.btnnr.Name = "btnnr";
            this.btnnr.Size = new System.Drawing.Size(43, 23);
            this.btnnr.TabIndex = 2;
            this.btnnr.Text = "...";
            this.btnnr.Click += new System.EventHandler(this.btnnr_Click);
            // 
            // memonr
            // 
            this.memonr.Location = new System.Drawing.Point(87, 41);
            this.memonr.Name = "memonr";
            this.memonr.Size = new System.Drawing.Size(267, 130);
            this.memonr.TabIndex = 1;
            // 
            // lblnr
            // 
            this.lblnr.Location = new System.Drawing.Point(22, 41);
            this.lblnr.Name = "lblnr";
            this.lblnr.Size = new System.Drawing.Size(24, 14);
            this.lblnr.TabIndex = 0;
            this.lblnr.Text = "内容";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(261, 307);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(361, 307);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frm_ksnrEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 340);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_ksnrEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考试内容";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memopj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memonr.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.MemoEdit memonr;
        private DevExpress.XtraEditors.LabelControl lblnr;
        private DevExpress.XtraEditors.SimpleButton btnpj;
        private DevExpress.XtraEditors.MemoEdit memopj;
        private DevExpress.XtraEditors.LabelControl lblpj;
        private DevExpress.XtraEditors.SimpleButton btnnr;


    }
}