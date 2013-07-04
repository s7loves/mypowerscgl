namespace Ebada.Scgl.Yxgl
{
    partial class frm_Dgjc
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
            this.lbldwmc = new DevExpress.XtraEditors.LabelControl();
            this.cmbOrg = new DevExpress.XtraEditors.ComboBoxEdit();
            this.grpdgjc = new System.Windows.Forms.GroupBox();
            this.cmbLineVol = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblLineVol = new DevExpress.XtraEditors.LabelControl();
            this.cmbline = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblxlmc = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrg.Properties)).BeginInit();
            this.grpdgjc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLineVol.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbline.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbldwmc
            // 
            this.lbldwmc.Location = new System.Drawing.Point(13, 30);
            this.lbldwmc.Name = "lbldwmc";
            this.lbldwmc.Size = new System.Drawing.Size(48, 14);
            this.lbldwmc.TabIndex = 0;
            this.lbldwmc.Text = "单位名称";
            // 
            // cmbOrg
            // 
            this.cmbOrg.Location = new System.Drawing.Point(81, 30);
            this.cmbOrg.Name = "cmbOrg";
            this.cmbOrg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbOrg.Size = new System.Drawing.Size(302, 21);
            this.cmbOrg.TabIndex = 1;
            this.cmbOrg.EditValueChanged += new System.EventHandler(this.cmbOrg_EditValueChanged);
            // 
            // grpdgjc
            // 
            this.grpdgjc.Controls.Add(this.cmbLineVol);
            this.grpdgjc.Controls.Add(this.lblLineVol);
            this.grpdgjc.Controls.Add(this.cmbline);
            this.grpdgjc.Controls.Add(this.lblxlmc);
            this.grpdgjc.Controls.Add(this.cmbOrg);
            this.grpdgjc.Controls.Add(this.lbldwmc);
            this.grpdgjc.Location = new System.Drawing.Point(21, 12);
            this.grpdgjc.Name = "grpdgjc";
            this.grpdgjc.Size = new System.Drawing.Size(412, 152);
            this.grpdgjc.TabIndex = 2;
            this.grpdgjc.TabStop = false;
            this.grpdgjc.Text = "线路信息";
            // 
            // cmbLineVol
            // 
            this.cmbLineVol.Location = new System.Drawing.Point(81, 101);
            this.cmbLineVol.Name = "cmbLineVol";
            this.cmbLineVol.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLineVol.Size = new System.Drawing.Size(302, 21);
            this.cmbLineVol.TabIndex = 5;
            // 
            // lblLineVol
            // 
            this.lblLineVol.Location = new System.Drawing.Point(13, 108);
            this.lblLineVol.Name = "lblLineVol";
            this.lblLineVol.Size = new System.Drawing.Size(48, 14);
            this.lblLineVol.TabIndex = 4;
            this.lblLineVol.Text = "线路电压";
            // 
            // cmbline
            // 
            this.cmbline.Location = new System.Drawing.Point(81, 66);
            this.cmbline.Name = "cmbline";
            this.cmbline.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbline.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbline.Size = new System.Drawing.Size(302, 21);
            this.cmbline.TabIndex = 3;
            this.cmbline.EditValueChanged += new System.EventHandler(this.cmbline_EditValueChanged);
            // 
            // lblxlmc
            // 
            this.lblxlmc.Location = new System.Drawing.Point(13, 66);
            this.lblxlmc.Name = "lblxlmc";
            this.lblxlmc.Size = new System.Drawing.Size(48, 14);
            this.lblxlmc.TabIndex = 2;
            this.lblxlmc.Text = "线路名称";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(231, 172);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(329, 172);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            // 
            // frm_Dgjc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 207);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grpdgjc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Dgjc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登杆检查";
            this.Load += new System.EventHandler(this.frm_Dgjc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrg.Properties)).EndInit();
            this.grpdgjc.ResumeLayout(false);
            this.grpdgjc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLineVol.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbline.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbldwmc;
        private DevExpress.XtraEditors.ComboBoxEdit cmbOrg;
        private System.Windows.Forms.GroupBox grpdgjc;
        private DevExpress.XtraEditors.ComboBoxEdit cmbLineVol;
        private DevExpress.XtraEditors.LabelControl lblLineVol;
        private DevExpress.XtraEditors.ComboBoxEdit cmbline;
        private DevExpress.XtraEditors.LabelControl lblxlmc;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;

    }
}