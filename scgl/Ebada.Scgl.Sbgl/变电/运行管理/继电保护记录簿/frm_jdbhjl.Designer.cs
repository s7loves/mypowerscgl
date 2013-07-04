namespace Ebada.Scgl.Sbgl
{
    partial class frm_jdbhjl
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
            this.lblsbmc = new DevExpress.XtraEditors.LabelControl();
            this.lkuesbmc = new DevExpress.XtraEditors.LookUpEdit();
            this.lblrq = new DevExpress.XtraEditors.LabelControl();
            this.daterq = new DevExpress.XtraEditors.DateEdit();
            this.lbljdfzr = new DevExpress.XtraEditors.LabelControl();
            this.lblzbrjsz = new DevExpress.XtraEditors.LabelControl();
            this.lbltsnrjjl = new DevExpress.XtraEditors.LabelControl();
            this.memotsnrjjl = new DevExpress.XtraEditors.MemoEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lkuejdfzr = new DevExpress.XtraEditors.LookUpEdit();
            this.lkuezbrjsz = new DevExpress.XtraEditors.LookUpEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lkuesbmc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daterq.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daterq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memotsnrjjl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuejdfzr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuezbrjsz.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblsbmc
            // 
            this.lblsbmc.Location = new System.Drawing.Point(32, 32);
            this.lblsbmc.Name = "lblsbmc";
            this.lblsbmc.Size = new System.Drawing.Size(48, 14);
            this.lblsbmc.TabIndex = 0;
            this.lblsbmc.Text = "设备名称";
            // 
            // lkuesbmc
            // 
            this.lkuesbmc.Location = new System.Drawing.Point(142, 29);
            this.lkuesbmc.Name = "lkuesbmc";
            this.lkuesbmc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkuesbmc.Size = new System.Drawing.Size(403, 21);
            this.lkuesbmc.TabIndex = 1;
            // 
            // lblrq
            // 
            this.lblrq.Location = new System.Drawing.Point(32, 69);
            this.lblrq.Name = "lblrq";
            this.lblrq.Size = new System.Drawing.Size(24, 14);
            this.lblrq.TabIndex = 2;
            this.lblrq.Text = "日期";
            // 
            // daterq
            // 
            this.daterq.EditValue = null;
            this.daterq.Location = new System.Drawing.Point(142, 66);
            this.daterq.Name = "daterq";
            this.daterq.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.daterq.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.daterq.Size = new System.Drawing.Size(403, 21);
            this.daterq.TabIndex = 3;
            // 
            // lbljdfzr
            // 
            this.lbljdfzr.Location = new System.Drawing.Point(32, 106);
            this.lbljdfzr.Name = "lbljdfzr";
            this.lbljdfzr.Size = new System.Drawing.Size(60, 14);
            this.lbljdfzr.TabIndex = 4;
            this.lbljdfzr.Text = "继电负责人";
            // 
            // lblzbrjsz
            // 
            this.lblzbrjsz.Location = new System.Drawing.Point(32, 143);
            this.lblzbrjsz.Name = "lblzbrjsz";
            this.lblzbrjsz.Size = new System.Drawing.Size(72, 14);
            this.lblzbrjsz.TabIndex = 6;
            this.lblzbrjsz.Text = "值班人及所长";
            // 
            // lbltsnrjjl
            // 
            this.lbltsnrjjl.Location = new System.Drawing.Point(32, 177);
            this.lbltsnrjjl.Name = "lbltsnrjjl";
            this.lbltsnrjjl.Size = new System.Drawing.Size(84, 14);
            this.lbltsnrjjl.TabIndex = 8;
            this.lbltsnrjjl.Text = "调试内容及结论";
            // 
            // memotsnrjjl
            // 
            this.memotsnrjjl.Location = new System.Drawing.Point(142, 177);
            this.memotsnrjjl.Name = "memotsnrjjl";
            this.memotsnrjjl.Size = new System.Drawing.Size(403, 96);
            this.memotsnrjjl.TabIndex = 9;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(313, 288);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(434, 288);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lkuejdfzr
            // 
            this.lkuejdfzr.Location = new System.Drawing.Point(142, 103);
            this.lkuejdfzr.Name = "lkuejdfzr";
            this.lkuejdfzr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkuejdfzr.Size = new System.Drawing.Size(403, 21);
            this.lkuejdfzr.TabIndex = 12;
            // 
            // lkuezbrjsz
            // 
            this.lkuezbrjsz.Location = new System.Drawing.Point(142, 140);
            this.lkuezbrjsz.Name = "lkuezbrjsz";
            this.lkuezbrjsz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkuezbrjsz.Size = new System.Drawing.Size(403, 21);
            this.lkuezbrjsz.TabIndex = 13;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(552, 179);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(25, 23);
            this.simpleButton1.TabIndex = 14;
            this.simpleButton1.Text = "...";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frm_jdbhjl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 333);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.lkuezbrjsz);
            this.Controls.Add(this.lkuejdfzr);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.memotsnrjjl);
            this.Controls.Add(this.lbltsnrjjl);
            this.Controls.Add(this.lblzbrjsz);
            this.Controls.Add(this.lbljdfzr);
            this.Controls.Add(this.daterq);
            this.Controls.Add(this.lblrq);
            this.Controls.Add(this.lkuesbmc);
            this.Controls.Add(this.lblsbmc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_jdbhjl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "继电保护记录";
            ((System.ComponentModel.ISupportInitialize)(this.lkuesbmc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daterq.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daterq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memotsnrjjl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuejdfzr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuezbrjsz.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblsbmc;
        private DevExpress.XtraEditors.LookUpEdit lkuesbmc;
        private DevExpress.XtraEditors.LabelControl lblrq;
        private DevExpress.XtraEditors.DateEdit daterq;
        private DevExpress.XtraEditors.LabelControl lbljdfzr;
        private DevExpress.XtraEditors.LabelControl lblzbrjsz;
        private DevExpress.XtraEditors.LabelControl lbltsnrjjl;
        private DevExpress.XtraEditors.MemoEdit memotsnrjjl;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LookUpEdit lkuejdfzr;
        private DevExpress.XtraEditors.LookUpEdit lkuezbrjsz;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}