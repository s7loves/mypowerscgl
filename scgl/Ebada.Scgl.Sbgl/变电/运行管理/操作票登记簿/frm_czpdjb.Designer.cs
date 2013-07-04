namespace Ebada.Scgl.Sbgl
{
    partial class frm_czpdjb
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
            this.lblOrgName = new DevExpress.XtraEditors.LabelControl();
            this.txtOrgName = new DevExpress.XtraEditors.TextEdit();
            this.lbldate = new DevExpress.XtraEditors.LabelControl();
            this.daterq = new DevExpress.XtraEditors.DateEdit();
            this.lblczpbh = new DevExpress.XtraEditors.LabelControl();
            this.lblczr = new DevExpress.XtraEditors.LabelControl();
            this.lbljhr = new DevExpress.XtraEditors.LabelControl();
            this.lblzbr = new DevExpress.XtraEditors.LabelControl();
            this.lblczrw = new DevExpress.XtraEditors.LabelControl();
            this.meoczrw = new DevExpress.XtraEditors.MemoEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lkueczr = new DevExpress.XtraEditors.LookUpEdit();
            this.lkuejhr = new DevExpress.XtraEditors.LookUpEdit();
            this.lkuezbr = new DevExpress.XtraEditors.LookUpEdit();
            this.txtczpsybh = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrgName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daterq.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daterq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meoczrw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkueczr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuejhr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuezbr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtczpsybh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOrgName
            // 
            this.lblOrgName.Location = new System.Drawing.Point(23, 23);
            this.lblOrgName.Name = "lblOrgName";
            this.lblOrgName.Size = new System.Drawing.Size(48, 14);
            this.lblOrgName.TabIndex = 0;
            this.lblOrgName.Text = "单位名称";
            // 
            // txtOrgName
            // 
            this.txtOrgName.Enabled = false;
            this.txtOrgName.Location = new System.Drawing.Point(135, 20);
            this.txtOrgName.Name = "txtOrgName";
            this.txtOrgName.Size = new System.Drawing.Size(306, 21);
            this.txtOrgName.TabIndex = 1;
            // 
            // lbldate
            // 
            this.lbldate.Location = new System.Drawing.Point(23, 55);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(24, 14);
            this.lbldate.TabIndex = 2;
            this.lbldate.Text = "日期";
            // 
            // daterq
            // 
            this.daterq.EditValue = null;
            this.daterq.Location = new System.Drawing.Point(135, 52);
            this.daterq.Name = "daterq";
            this.daterq.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.daterq.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.daterq.Size = new System.Drawing.Size(306, 21);
            this.daterq.TabIndex = 3;
            // 
            // lblczpbh
            // 
            this.lblczpbh.Location = new System.Drawing.Point(23, 87);
            this.lblczpbh.Name = "lblczpbh";
            this.lblczpbh.Size = new System.Drawing.Size(84, 14);
            this.lblczpbh.TabIndex = 4;
            this.lblczpbh.Text = "操作票使用编号";
            // 
            // lblczr
            // 
            this.lblczr.Location = new System.Drawing.Point(23, 119);
            this.lblczr.Name = "lblczr";
            this.lblczr.Size = new System.Drawing.Size(36, 14);
            this.lblczr.TabIndex = 6;
            this.lblczr.Text = "操作人";
            // 
            // lbljhr
            // 
            this.lbljhr.Location = new System.Drawing.Point(23, 151);
            this.lbljhr.Name = "lbljhr";
            this.lbljhr.Size = new System.Drawing.Size(36, 14);
            this.lbljhr.TabIndex = 8;
            this.lbljhr.Text = "监护人";
            // 
            // lblzbr
            // 
            this.lblzbr.Location = new System.Drawing.Point(23, 183);
            this.lblzbr.Name = "lblzbr";
            this.lblzbr.Size = new System.Drawing.Size(36, 14);
            this.lblzbr.TabIndex = 10;
            this.lblzbr.Text = "值班人";
            // 
            // lblczrw
            // 
            this.lblczrw.Location = new System.Drawing.Point(23, 212);
            this.lblczrw.Name = "lblczrw";
            this.lblczrw.Size = new System.Drawing.Size(48, 14);
            this.lblczrw.TabIndex = 12;
            this.lblczrw.Text = "操作任务";
            // 
            // meoczrw
            // 
            this.meoczrw.Location = new System.Drawing.Point(135, 212);
            this.meoczrw.Name = "meoczrw";
            this.meoczrw.Size = new System.Drawing.Size(306, 58);
            this.meoczrw.TabIndex = 13;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(243, 286);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(344, 286);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lkueczr
            // 
            this.lkueczr.Location = new System.Drawing.Point(135, 116);
            this.lkueczr.Name = "lkueczr";
            this.lkueczr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkueczr.Size = new System.Drawing.Size(306, 21);
            this.lkueczr.TabIndex = 16;
            // 
            // lkuejhr
            // 
            this.lkuejhr.Location = new System.Drawing.Point(135, 148);
            this.lkuejhr.Name = "lkuejhr";
            this.lkuejhr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkuejhr.Size = new System.Drawing.Size(306, 21);
            this.lkuejhr.TabIndex = 17;
            // 
            // lkuezbr
            // 
            this.lkuezbr.Location = new System.Drawing.Point(135, 180);
            this.lkuezbr.Name = "lkuezbr";
            this.lkuezbr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkuezbr.Size = new System.Drawing.Size(306, 21);
            this.lkuezbr.TabIndex = 18;
            // 
            // txtczpsybh
            // 
            this.txtczpsybh.Location = new System.Drawing.Point(135, 87);
            this.txtczpsybh.Name = "txtczpsybh";
            this.txtczpsybh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtczpsybh.Size = new System.Drawing.Size(306, 21);
            this.txtczpsybh.TabIndex = 19;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(447, 214);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(23, 23);
            this.simpleButton1.TabIndex = 20;
            this.simpleButton1.Text = "...";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frm_czpdjb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 336);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtczpsybh);
            this.Controls.Add(this.lkuezbr);
            this.Controls.Add(this.lkuejhr);
            this.Controls.Add(this.lkueczr);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.meoczrw);
            this.Controls.Add(this.lblczrw);
            this.Controls.Add(this.lblzbr);
            this.Controls.Add(this.lbljhr);
            this.Controls.Add(this.lblczr);
            this.Controls.Add(this.lblczpbh);
            this.Controls.Add(this.daterq);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.txtOrgName);
            this.Controls.Add(this.lblOrgName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_czpdjb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "操作票登记簿";
            ((System.ComponentModel.ISupportInitialize)(this.txtOrgName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daterq.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daterq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meoczrw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkueczr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuejhr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuezbr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtczpsybh.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblOrgName;
        private DevExpress.XtraEditors.TextEdit txtOrgName;
        private DevExpress.XtraEditors.LabelControl lbldate;
        private DevExpress.XtraEditors.DateEdit daterq;
        private DevExpress.XtraEditors.LabelControl lblczpbh;
        private DevExpress.XtraEditors.LabelControl lblczr;
        private DevExpress.XtraEditors.LabelControl lbljhr;
        private DevExpress.XtraEditors.LabelControl lblzbr;
        private DevExpress.XtraEditors.LabelControl lblczrw;
        private DevExpress.XtraEditors.MemoEdit meoczrw;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LookUpEdit lkueczr;
        private DevExpress.XtraEditors.LookUpEdit lkuejhr;
        private DevExpress.XtraEditors.LookUpEdit lkuezbr;
        private DevExpress.XtraEditors.ComboBoxEdit txtczpsybh;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}