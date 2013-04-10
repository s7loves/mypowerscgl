namespace Ebada.Scgl.Sbgl
{
    partial class frm_yxfxjlb
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
            this.lblrq = new DevExpress.XtraEditors.LabelControl();
            this.daterq = new DevExpress.XtraEditors.DateEdit();
            this.lblcjry = new DevExpress.XtraEditors.LabelControl();
            this.memocjry = new DevExpress.XtraEditors.MemoEdit();
            this.lblnr = new DevExpress.XtraEditors.LabelControl();
            this.memonr = new DevExpress.XtraEditors.MemoEdit();
            this.lbljl = new DevExpress.XtraEditors.LabelControl();
            this.memojl = new DevExpress.XtraEditors.MemoEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.daterq.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daterq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memocjry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memonr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memojl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblrq
            // 
            this.lblrq.Location = new System.Drawing.Point(39, 46);
            this.lblrq.Name = "lblrq";
            this.lblrq.Size = new System.Drawing.Size(24, 14);
            this.lblrq.TabIndex = 0;
            this.lblrq.Text = "日期";
            // 
            // daterq
            // 
            this.daterq.EditValue = null;
            this.daterq.Location = new System.Drawing.Point(102, 39);
            this.daterq.Name = "daterq";
            this.daterq.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.daterq.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.daterq.Size = new System.Drawing.Size(441, 21);
            this.daterq.TabIndex = 1;
            // 
            // lblcjry
            // 
            this.lblcjry.Location = new System.Drawing.Point(39, 103);
            this.lblcjry.Name = "lblcjry";
            this.lblcjry.Size = new System.Drawing.Size(48, 14);
            this.lblcjry.TabIndex = 2;
            this.lblcjry.Text = "参加人员";
            // 
            // memocjry
            // 
            this.memocjry.Location = new System.Drawing.Point(102, 75);
            this.memocjry.Name = "memocjry";
            this.memocjry.Size = new System.Drawing.Size(441, 71);
            this.memocjry.TabIndex = 3;
            // 
            // lblnr
            // 
            this.lblnr.Location = new System.Drawing.Point(39, 184);
            this.lblnr.Name = "lblnr";
            this.lblnr.Size = new System.Drawing.Size(24, 14);
            this.lblnr.TabIndex = 4;
            this.lblnr.Text = "内容";
            // 
            // memonr
            // 
            this.memonr.Location = new System.Drawing.Point(102, 161);
            this.memonr.Name = "memonr";
            this.memonr.Size = new System.Drawing.Size(441, 77);
            this.memonr.TabIndex = 5;
            // 
            // lbljl
            // 
            this.lbljl.Location = new System.Drawing.Point(39, 259);
            this.lbljl.Name = "lbljl";
            this.lbljl.Size = new System.Drawing.Size(24, 14);
            this.lbljl.TabIndex = 6;
            this.lbljl.Text = "结论";
            // 
            // memojl
            // 
            this.memojl.Location = new System.Drawing.Point(102, 256);
            this.memojl.Name = "memojl";
            this.memojl.Size = new System.Drawing.Size(441, 88);
            this.memojl.TabIndex = 7;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(320, 359);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(433, 359);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frm_yxfxjlb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 394);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.memojl);
            this.Controls.Add(this.lbljl);
            this.Controls.Add(this.memonr);
            this.Controls.Add(this.lblnr);
            this.Controls.Add(this.memocjry);
            this.Controls.Add(this.lblcjry);
            this.Controls.Add(this.daterq);
            this.Controls.Add(this.lblrq);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_yxfxjlb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "运行分析记录";
            ((System.ComponentModel.ISupportInitialize)(this.daterq.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daterq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memocjry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memonr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memojl.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblrq;
        private DevExpress.XtraEditors.DateEdit daterq;
        private DevExpress.XtraEditors.LabelControl lblcjry;
        private DevExpress.XtraEditors.MemoEdit memocjry;
        private DevExpress.XtraEditors.LabelControl lblnr;
        private DevExpress.XtraEditors.MemoEdit memonr;
        private DevExpress.XtraEditors.LabelControl lbljl;
        private DevExpress.XtraEditors.MemoEdit memojl;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;

    }
}