namespace Ebada.Scgl.Yxgl
{
    partial class frm_whdd
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
            this.lblwhqdmc = new DevExpress.XtraEditors.LabelControl();
            this.txtwhqdmc = new DevExpress.XtraEditors.TextEdit();
            this.lblwhqdxx = new DevExpress.XtraEditors.LabelControl();
            this.memowhxx = new DevExpress.XtraEditors.MemoEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbwhdj = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblwhdj = new DevExpress.XtraEditors.LabelControl();
            this.cmbwyxz = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblwyxz = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtwhqdmc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memowhxx.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbwhdj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbwyxz.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblwhqdmc
            // 
            this.lblwhqdmc.Location = new System.Drawing.Point(12, 24);
            this.lblwhqdmc.Name = "lblwhqdmc";
            this.lblwhqdmc.Size = new System.Drawing.Size(48, 14);
            this.lblwhqdmc.TabIndex = 0;
            this.lblwhqdmc.Text = "区段名称";
            // 
            // txtwhqdmc
            // 
            this.txtwhqdmc.Location = new System.Drawing.Point(66, 21);
            this.txtwhqdmc.Name = "txtwhqdmc";
            this.txtwhqdmc.Size = new System.Drawing.Size(276, 21);
            this.txtwhqdmc.TabIndex = 1;
            // 
            // lblwhqdxx
            // 
            this.lblwhqdxx.Location = new System.Drawing.Point(12, 111);
            this.lblwhqdxx.Name = "lblwhqdxx";
            this.lblwhqdxx.Size = new System.Drawing.Size(48, 14);
            this.lblwhqdxx.TabIndex = 2;
            this.lblwhqdxx.Text = "区段描述";
            // 
            // memowhxx
            // 
            this.memowhxx.Location = new System.Drawing.Point(66, 111);
            this.memowhxx.Name = "memowhxx";
            this.memowhxx.Size = new System.Drawing.Size(276, 61);
            this.memowhxx.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbwhdj);
            this.groupBox1.Controls.Add(this.memowhxx);
            this.groupBox1.Controls.Add(this.lblwhqdxx);
            this.groupBox1.Controls.Add(this.lblwhdj);
            this.groupBox1.Controls.Add(this.cmbwyxz);
            this.groupBox1.Controls.Add(this.lblwyxz);
            this.groupBox1.Controls.Add(this.txtwhqdmc);
            this.groupBox1.Controls.Add(this.lblwhqdmc);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 184);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "污秽地段信息";
            // 
            // cmbwhdj
            // 
            this.cmbwhdj.Location = new System.Drawing.Point(66, 81);
            this.cmbwhdj.Name = "cmbwhdj";
            this.cmbwhdj.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbwhdj.Size = new System.Drawing.Size(276, 21);
            this.cmbwhdj.TabIndex = 5;
            // 
            // lblwhdj
            // 
            this.lblwhdj.Location = new System.Drawing.Point(12, 84);
            this.lblwhdj.Name = "lblwhdj";
            this.lblwhdj.Size = new System.Drawing.Size(48, 14);
            this.lblwhdj.TabIndex = 4;
            this.lblwhdj.Text = "污秽等级";
            // 
            // cmbwyxz
            // 
            this.cmbwyxz.Location = new System.Drawing.Point(66, 51);
            this.cmbwyxz.Name = "cmbwyxz";
            this.cmbwyxz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbwyxz.Size = new System.Drawing.Size(276, 21);
            this.cmbwyxz.TabIndex = 3;
            // 
            // lblwyxz
            // 
            this.lblwyxz.Location = new System.Drawing.Point(12, 54);
            this.lblwyxz.Name = "lblwyxz";
            this.lblwyxz.Size = new System.Drawing.Size(48, 14);
            this.lblwyxz.TabIndex = 2;
            this.lblwyxz.Text = "污源性质";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(198, 202);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "确定";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(289, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            // 
            // frm_whdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 236);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_whdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "污秽地段";
            ((System.ComponentModel.ISupportInitialize)(this.txtwhqdmc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memowhxx.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbwhdj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbwyxz.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblwhqdmc;
        private DevExpress.XtraEditors.TextEdit txtwhqdmc;
        private DevExpress.XtraEditors.LabelControl lblwhqdxx;
        private DevExpress.XtraEditors.MemoEdit memowhxx;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbwyxz;
        private DevExpress.XtraEditors.LabelControl lblwyxz;
        private DevExpress.XtraEditors.ComboBoxEdit cmbwhdj;
        private DevExpress.XtraEditors.LabelControl lblwhdj;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;




    }
}