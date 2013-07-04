namespace Ebada.Scgl.Sbgl
{
    partial class frmsd_xsxm
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
            this.lblzl = new DevExpress.XtraEditors.LabelControl();
            this.lblmc = new DevExpress.XtraEditors.LabelControl();
            this.lblflag = new DevExpress.XtraEditors.LabelControl();
            this.lblxssj = new DevExpress.XtraEditors.LabelControl();
            this.datexssj = new DevExpress.XtraEditors.DateEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtzl = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtmc = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtflag = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.datexssj.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datexssj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtzl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtflag.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblzl
            // 
            this.lblzl.Location = new System.Drawing.Point(25, 23);
            this.lblzl.Name = "lblzl";
            this.lblzl.Size = new System.Drawing.Size(48, 14);
            this.lblzl.TabIndex = 0;
            this.lblzl.Text = "项目种类";
            // 
            // lblmc
            // 
            this.lblmc.Location = new System.Drawing.Point(25, 56);
            this.lblmc.Name = "lblmc";
            this.lblmc.Size = new System.Drawing.Size(48, 14);
            this.lblmc.TabIndex = 2;
            this.lblmc.Text = "项目内容";
            // 
            // lblflag
            // 
            this.lblflag.Location = new System.Drawing.Point(25, 89);
            this.lblflag.Name = "lblflag";
            this.lblflag.Size = new System.Drawing.Size(48, 14);
            this.lblflag.TabIndex = 4;
            this.lblflag.Text = "巡视状态";
            // 
            // lblxssj
            // 
            this.lblxssj.Location = new System.Drawing.Point(25, 122);
            this.lblxssj.Name = "lblxssj";
            this.lblxssj.Size = new System.Drawing.Size(48, 14);
            this.lblxssj.TabIndex = 6;
            this.lblxssj.Text = "巡检时间";
            // 
            // datexssj
            // 
            this.datexssj.EditValue = null;
            this.datexssj.Location = new System.Drawing.Point(89, 119);
            this.datexssj.Name = "datexssj";
            this.datexssj.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datexssj.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datexssj.Size = new System.Drawing.Size(315, 21);
            this.datexssj.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(238, 146);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(319, 146);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtzl
            // 
            this.txtzl.Location = new System.Drawing.Point(89, 20);
            this.txtzl.Name = "txtzl";
            this.txtzl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtzl.Size = new System.Drawing.Size(315, 21);
            this.txtzl.TabIndex = 10;
            // 
            // txtmc
            // 
            this.txtmc.Location = new System.Drawing.Point(89, 53);
            this.txtmc.Name = "txtmc";
            this.txtmc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtmc.Size = new System.Drawing.Size(315, 21);
            this.txtmc.TabIndex = 11;
            // 
            // txtflag
            // 
            this.txtflag.Location = new System.Drawing.Point(89, 86);
            this.txtflag.Name = "txtflag";
            this.txtflag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtflag.Size = new System.Drawing.Size(315, 21);
            this.txtflag.TabIndex = 12;
            // 
            // frmsd_xsxm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 192);
            this.Controls.Add(this.txtflag);
            this.Controls.Add(this.txtmc);
            this.Controls.Add(this.txtzl);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.datexssj);
            this.Controls.Add(this.lblxssj);
            this.Controls.Add(this.lblflag);
            this.Controls.Add(this.lblmc);
            this.Controls.Add(this.lblzl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmsd_xsxm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "巡检项目信息";
            this.Load += new System.EventHandler(this.frmsd_xsxm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datexssj.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datexssj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtzl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtflag.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblzl;
        private DevExpress.XtraEditors.LabelControl lblmc;
        private DevExpress.XtraEditors.LabelControl lblflag;
        private DevExpress.XtraEditors.LabelControl lblxssj;
        private DevExpress.XtraEditors.DateEdit datexssj;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.ComboBoxEdit txtzl;
        private DevExpress.XtraEditors.ComboBoxEdit txtmc;
        private DevExpress.XtraEditors.ComboBoxEdit txtflag;
    }
}