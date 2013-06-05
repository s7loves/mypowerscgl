namespace Ebada.Scgl.Yxgl
{
    partial class frmSbnb
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
            this.groupControlOrg = new DevExpress.XtraEditors.GroupControl();
            this.lkuesj = new DevExpress.XtraEditors.LookUpEdit();
            this.lblsj = new DevExpress.XtraEditors.LabelControl();
            this.lbldwmc = new DevExpress.XtraEditors.LabelControl();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.lblfilename = new DevExpress.XtraEditors.LabelControl();
            this.btnSelectFile = new DevExpress.XtraEditors.ButtonEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lkueorg = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOrg)).BeginInit();
            this.groupControlOrg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkuesj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelectFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkueorg.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControlOrg
            // 
            this.groupControlOrg.Controls.Add(this.lkueorg);
            this.groupControlOrg.Controls.Add(this.btnCancel);
            this.groupControlOrg.Controls.Add(this.btnOk);
            this.groupControlOrg.Controls.Add(this.btnSelectFile);
            this.groupControlOrg.Controls.Add(this.lblfilename);
            this.groupControlOrg.Controls.Add(this.lkuesj);
            this.groupControlOrg.Controls.Add(this.lblsj);
            this.groupControlOrg.Controls.Add(this.lbldwmc);
            this.groupControlOrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlOrg.Location = new System.Drawing.Point(0, 0);
            this.groupControlOrg.Name = "groupControlOrg";
            this.groupControlOrg.Size = new System.Drawing.Size(433, 174);
            this.groupControlOrg.TabIndex = 9;
            // 
            // lkuesj
            // 
            this.lkuesj.Location = new System.Drawing.Point(89, 73);
            this.lkuesj.Name = "lkuesj";
            this.lkuesj.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkuesj.Size = new System.Drawing.Size(325, 21);
            this.lkuesj.TabIndex = 3;
            // 
            // lblsj
            // 
            this.lblsj.Location = new System.Drawing.Point(26, 76);
            this.lblsj.Name = "lblsj";
            this.lblsj.Size = new System.Drawing.Size(24, 14);
            this.lblsj.TabIndex = 2;
            this.lblsj.Text = "时间";
            // 
            // lbldwmc
            // 
            this.lbldwmc.Location = new System.Drawing.Point(26, 44);
            this.lbldwmc.Name = "lbldwmc";
            this.lbldwmc.Size = new System.Drawing.Size(48, 14);
            this.lbldwmc.TabIndex = 0;
            this.lbldwmc.Text = "单位名称";
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(669, 23);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 385);
            // 
            // lblfilename
            // 
            this.lblfilename.Location = new System.Drawing.Point(26, 107);
            this.lblfilename.Name = "lblfilename";
            this.lblfilename.Size = new System.Drawing.Size(48, 14);
            this.lblfilename.TabIndex = 4;
            this.lblfilename.Text = "文件名称";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(89, 107);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnSelectFile.Size = new System.Drawing.Size(325, 21);
            this.btnSelectFile.TabIndex = 5;
            this.btnSelectFile.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnSelectFile_ButtonClick);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(231, 135);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(327, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            // 
            // lkueorg
            // 
            this.lkueorg.Location = new System.Drawing.Point(89, 44);
            this.lkueorg.Name = "lkueorg";
            this.lkueorg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkueorg.Size = new System.Drawing.Size(325, 21);
            this.lkueorg.TabIndex = 8;
            // 
            // frmAqxpj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 174);
            this.Controls.Add(this.groupControlOrg);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAqxpj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "安全性评价";
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOrg)).EndInit();
            this.groupControlOrg.ResumeLayout(false);
            this.groupControlOrg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkuesj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelectFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkueorg.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlOrg;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.LookUpEdit lkuesj;
        private DevExpress.XtraEditors.LabelControl lblsj;
        private DevExpress.XtraEditors.LabelControl lbldwmc;
        private DevExpress.XtraEditors.LabelControl lblfilename;
        private DevExpress.XtraEditors.ButtonEdit btnSelectFile;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.LookUpEdit lkueorg;

    }
}