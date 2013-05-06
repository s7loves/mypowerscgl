namespace Ebada.Scgl.Yxgl
{
    partial class frm_ddxljq
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
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbLineName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbljcrq = new DevExpress.XtraEditors.LabelControl();
            this.datejcrq = new DevExpress.XtraEditors.DateEdit();
            this.lblLineVol = new DevExpress.XtraEditors.LabelControl();
            this.cmbLineVol = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLineName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datejcrq.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datejcrq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLineVol.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(194, 125);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(291, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "线路名称";
            // 
            // cmbLineName
            // 
            this.cmbLineName.Location = new System.Drawing.Point(86, 23);
            this.cmbLineName.Name = "cmbLineName";
            this.cmbLineName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLineName.Size = new System.Drawing.Size(280, 21);
            this.cmbLineName.TabIndex = 6;
            this.cmbLineName.EditValueChanged += new System.EventHandler(this.cmbLineName_EditValueChanged);
            // 
            // lbljcrq
            // 
            this.lbljcrq.Location = new System.Drawing.Point(21, 94);
            this.lbljcrq.Name = "lbljcrq";
            this.lbljcrq.Size = new System.Drawing.Size(48, 14);
            this.lbljcrq.TabIndex = 7;
            this.lbljcrq.Text = "检测日期";
            // 
            // datejcrq
            // 
            this.datejcrq.EditValue = null;
            this.datejcrq.Location = new System.Drawing.Point(86, 91);
            this.datejcrq.Name = "datejcrq";
            this.datejcrq.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datejcrq.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datejcrq.Size = new System.Drawing.Size(280, 21);
            this.datejcrq.TabIndex = 8;
            // 
            // lblLineVol
            // 
            this.lblLineVol.Location = new System.Drawing.Point(21, 60);
            this.lblLineVol.Name = "lblLineVol";
            this.lblLineVol.Size = new System.Drawing.Size(48, 14);
            this.lblLineVol.TabIndex = 9;
            this.lblLineVol.Text = "线路电压";
            // 
            // cmbLineVol
            // 
            this.cmbLineVol.Location = new System.Drawing.Point(86, 57);
            this.cmbLineVol.Name = "cmbLineVol";
            this.cmbLineVol.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLineVol.Size = new System.Drawing.Size(280, 21);
            this.cmbLineVol.TabIndex = 10;
            // 
            // frm_ddxljq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 160);
            this.Controls.Add(this.cmbLineVol);
            this.Controls.Add(this.lblLineVol);
            this.Controls.Add(this.datejcrq);
            this.Controls.Add(this.lbljcrq);
            this.Controls.Add(this.cmbLineName);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ddxljq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导地线检测记录";
            ((System.ComponentModel.ISupportInitialize)(this.cmbLineName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datejcrq.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datejcrq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLineVol.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbLineName;
        private DevExpress.XtraEditors.LabelControl lbljcrq;
        private DevExpress.XtraEditors.DateEdit datejcrq;
        private DevExpress.XtraEditors.LabelControl lblLineVol;
        private DevExpress.XtraEditors.ComboBoxEdit cmbLineVol;

    }
}