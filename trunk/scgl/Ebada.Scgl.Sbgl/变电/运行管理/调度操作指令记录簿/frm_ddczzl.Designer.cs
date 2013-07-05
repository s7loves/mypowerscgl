namespace Ebada.Scgl.Sbgl
{
    partial class frm_ddczzl
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
            this.lbllb = new DevExpress.XtraEditors.LabelControl();
            this.txtlb = new DevExpress.XtraEditors.TextEdit();
            this.lblkssj = new DevExpress.XtraEditors.LabelControl();
            this.datekssj = new DevExpress.XtraEditors.DateEdit();
            this.lbldd = new DevExpress.XtraEditors.LabelControl();
            this.lblbds = new DevExpress.XtraEditors.LabelControl();
            this.lblzlbh = new DevExpress.XtraEditors.LabelControl();
            this.lblnr = new DevExpress.XtraEditors.LabelControl();
            this.memonr = new DevExpress.XtraEditors.MemoEdit();
            this.lblzzsj = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.timezzsj = new DevExpress.XtraEditors.TimeEdit();
            this.txtdd = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtbds = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtzlbh = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtlb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datekssj.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datekssj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memonr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timezzsj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbds.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtzlbh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbllb
            // 
            this.lbllb.Location = new System.Drawing.Point(31, 30);
            this.lbllb.Name = "lbllb";
            this.lbllb.Size = new System.Drawing.Size(24, 14);
            this.lbllb.TabIndex = 0;
            this.lbllb.Text = "令别";
            // 
            // txtlb
            // 
            this.txtlb.Location = new System.Drawing.Point(97, 27);
            this.txtlb.Name = "txtlb";
            this.txtlb.Size = new System.Drawing.Size(431, 21);
            this.txtlb.TabIndex = 1;
            // 
            // lblkssj
            // 
            this.lblkssj.Location = new System.Drawing.Point(31, 63);
            this.lblkssj.Name = "lblkssj";
            this.lblkssj.Size = new System.Drawing.Size(48, 14);
            this.lblkssj.TabIndex = 2;
            this.lblkssj.Text = "开始时间";
            // 
            // datekssj
            // 
            this.datekssj.EditValue = null;
            this.datekssj.Location = new System.Drawing.Point(97, 60);
            this.datekssj.Name = "datekssj";
            this.datekssj.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datekssj.Properties.DisplayFormat.FormatString = "G";
            this.datekssj.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datekssj.Properties.EditFormat.FormatString = "G";
            this.datekssj.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datekssj.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.datekssj.Properties.Mask.EditMask = "G";
            this.datekssj.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.datekssj.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
            this.datekssj.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datekssj.Size = new System.Drawing.Size(431, 21);
            this.datekssj.TabIndex = 3;
            // 
            // lbldd
            // 
            this.lbldd.Location = new System.Drawing.Point(31, 96);
            this.lbldd.Name = "lbldd";
            this.lbldd.Size = new System.Drawing.Size(48, 14);
            this.lbldd.TabIndex = 4;
            this.lbldd.Text = "调度人员";
            // 
            // lblbds
            // 
            this.lblbds.Location = new System.Drawing.Point(31, 129);
            this.lblbds.Name = "lblbds";
            this.lblbds.Size = new System.Drawing.Size(60, 14);
            this.lblbds.TabIndex = 6;
            this.lblbds.Text = "变电所人员";
            // 
            // lblzlbh
            // 
            this.lblzlbh.Location = new System.Drawing.Point(31, 162);
            this.lblzlbh.Name = "lblzlbh";
            this.lblzlbh.Size = new System.Drawing.Size(48, 14);
            this.lblzlbh.TabIndex = 8;
            this.lblzlbh.Text = "指令编号";
            // 
            // lblnr
            // 
            this.lblnr.Location = new System.Drawing.Point(31, 192);
            this.lblnr.Name = "lblnr";
            this.lblnr.Size = new System.Drawing.Size(24, 14);
            this.lblnr.TabIndex = 10;
            this.lblnr.Text = "内容";
            // 
            // memonr
            // 
            this.memonr.Location = new System.Drawing.Point(97, 192);
            this.memonr.Name = "memonr";
            this.memonr.Size = new System.Drawing.Size(431, 96);
            this.memonr.TabIndex = 11;
            // 
            // lblzzsj
            // 
            this.lblzzsj.Location = new System.Drawing.Point(31, 303);
            this.lblzzsj.Name = "lblzzsj";
            this.lblzzsj.Size = new System.Drawing.Size(48, 14);
            this.lblzzsj.TabIndex = 12;
            this.lblzzsj.Text = "终止时间";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(307, 338);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(408, 338);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // timezzsj
            // 
            this.timezzsj.EditValue = null;
            this.timezzsj.Location = new System.Drawing.Point(97, 300);
            this.timezzsj.Name = "timezzsj";
            this.timezzsj.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timezzsj.Properties.DisplayFormat.FormatString = "HH:mm:ss";
            this.timezzsj.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.timezzsj.Properties.EditFormat.FormatString = "HH:mm:ss";
            this.timezzsj.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.timezzsj.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.timezzsj.Size = new System.Drawing.Size(431, 21);
            this.timezzsj.TabIndex = 16;
            // 
            // txtdd
            // 
            this.txtdd.Location = new System.Drawing.Point(97, 93);
            this.txtdd.Name = "txtdd";
            this.txtdd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtdd.Size = new System.Drawing.Size(431, 21);
            this.txtdd.TabIndex = 17;
            // 
            // txtbds
            // 
            this.txtbds.Location = new System.Drawing.Point(97, 129);
            this.txtbds.Name = "txtbds";
            this.txtbds.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtbds.Size = new System.Drawing.Size(386, 21);
            this.txtbds.TabIndex = 18;
            // 
            // txtzlbh
            // 
            this.txtzlbh.Location = new System.Drawing.Point(97, 162);
            this.txtzlbh.Name = "txtzlbh";
            this.txtzlbh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtzlbh.Size = new System.Drawing.Size(431, 21);
            this.txtzlbh.TabIndex = 19;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(535, 192);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(27, 23);
            this.simpleButton1.TabIndex = 20;
            this.simpleButton1.Text = "...";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(501, 129);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(27, 23);
            this.simpleButton2.TabIndex = 21;
            this.simpleButton2.Text = "...";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // frm_ddczzl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 375);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtzlbh);
            this.Controls.Add(this.txtbds);
            this.Controls.Add(this.txtdd);
            this.Controls.Add(this.timezzsj);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblzzsj);
            this.Controls.Add(this.memonr);
            this.Controls.Add(this.lblnr);
            this.Controls.Add(this.lblzlbh);
            this.Controls.Add(this.lblbds);
            this.Controls.Add(this.lbldd);
            this.Controls.Add(this.datekssj);
            this.Controls.Add(this.lblkssj);
            this.Controls.Add(this.txtlb);
            this.Controls.Add(this.lbllb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_ddczzl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "调度操作指令";
            ((System.ComponentModel.ISupportInitialize)(this.txtlb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datekssj.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datekssj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memonr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timezzsj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbds.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtzlbh.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbllb;
        private DevExpress.XtraEditors.TextEdit txtlb;
        private DevExpress.XtraEditors.LabelControl lblkssj;
        private DevExpress.XtraEditors.DateEdit datekssj;
        private DevExpress.XtraEditors.LabelControl lbldd;
        private DevExpress.XtraEditors.LabelControl lblbds;
        private DevExpress.XtraEditors.LabelControl lblzlbh;
        private DevExpress.XtraEditors.LabelControl lblnr;
        private DevExpress.XtraEditors.MemoEdit memonr;
        private DevExpress.XtraEditors.LabelControl lblzzsj;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TimeEdit timezzsj;
        private DevExpress.XtraEditors.ComboBoxEdit txtdd;
        private DevExpress.XtraEditors.ComboBoxEdit txtbds;
        private DevExpress.XtraEditors.ComboBoxEdit txtzlbh;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}