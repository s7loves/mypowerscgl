﻿namespace Ebada.Scgl.Yxgl
{
    partial class frmSD26Edit
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
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControlOrg = new DevExpress.XtraEditors.GroupControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lkuexlmc = new DevExpress.XtraEditors.LookUpEdit();
            this.lblxlmc = new DevExpress.XtraEditors.LabelControl();
            this.memoEdit3 = new DevExpress.XtraEditors.MemoEdit();
            this.memoEdit2 = new DevExpress.XtraEditors.MemoEdit();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.comboBoxEdit3 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOrg)).BeginInit();
            this.groupControlOrg.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkuexlmc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(431, 442);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(52, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(376, 442);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(49, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupControlOrg
            // 
            this.groupControlOrg.Controls.Add(this.groupBox1);
            this.groupControlOrg.Controls.Add(this.btnCancel);
            this.groupControlOrg.Controls.Add(this.btnOK);
            this.groupControlOrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlOrg.Location = new System.Drawing.Point(0, 0);
            this.groupControlOrg.Name = "groupControlOrg";
            this.groupControlOrg.Size = new System.Drawing.Size(541, 498);
            this.groupControlOrg.TabIndex = 9;
            this.groupControlOrg.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControlOrg_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lkuexlmc);
            this.groupBox1.Controls.Add(this.lblxlmc);
            this.groupBox1.Controls.Add(this.memoEdit3);
            this.groupBox1.Controls.Add(this.memoEdit2);
            this.groupBox1.Controls.Add(this.memoEdit1);
            this.groupBox1.Controls.Add(this.comboBoxEdit3);
            this.groupBox1.Controls.Add(this.comboBoxEdit1);
            this.groupBox1.Controls.Add(this.labelControl3);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.labelControl5);
            this.groupBox1.Controls.Add(this.dateEdit1);
            this.groupBox1.Controls.Add(this.labelControl4);
            this.groupBox1.Controls.Add(this.labelControl8);
            this.groupBox1.Controls.Add(this.labelControl9);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Location = new System.Drawing.Point(20, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 388);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "电力线路防护通知书";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lkuexlmc
            // 
            this.lkuexlmc.Location = new System.Drawing.Point(122, 100);
            this.lkuexlmc.Name = "lkuexlmc";
            this.lkuexlmc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkuexlmc.Size = new System.Drawing.Size(308, 21);
            this.lkuexlmc.TabIndex = 20;
            // 
            // lblxlmc
            // 
            this.lblxlmc.Location = new System.Drawing.Point(38, 103);
            this.lblxlmc.Name = "lblxlmc";
            this.lblxlmc.Size = new System.Drawing.Size(48, 14);
            this.lblxlmc.TabIndex = 19;
            this.lblxlmc.Text = "线路名称";
            // 
            // memoEdit3
            // 
            this.memoEdit3.Location = new System.Drawing.Point(122, 200);
            this.memoEdit3.Name = "memoEdit3";
            this.memoEdit3.Size = new System.Drawing.Size(308, 51);
            this.memoEdit3.TabIndex = 18;
            // 
            // memoEdit2
            // 
            this.memoEdit2.Location = new System.Drawing.Point(122, 135);
            this.memoEdit2.Name = "memoEdit2";
            this.memoEdit2.Size = new System.Drawing.Size(308, 51);
            this.memoEdit2.TabIndex = 18;
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(122, 265);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(308, 98);
            this.memoEdit1.TabIndex = 18;
            // 
            // comboBoxEdit3
            // 
            this.comboBoxEdit3.Location = new System.Drawing.Point(122, 65);
            this.comboBoxEdit3.Name = "comboBoxEdit3";
            this.comboBoxEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit3.Size = new System.Drawing.Size(53, 21);
            this.comboBoxEdit3.TabIndex = 15;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(122, 30);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Size = new System.Drawing.Size(100, 21);
            this.comboBoxEdit1.TabIndex = 15;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(181, 68);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(13, 14);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Kv";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(38, 68);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "电压等级";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(38, 200);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "处理措施";
            this.labelControl5.Click += new System.EventHandler(this.labelControl2_Click);
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(330, 30);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(100, 21);
            this.dateEdit1.TabIndex = 10;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(38, 135);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "发现问题";
            this.labelControl4.Click += new System.EventHandler(this.labelControl2_Click);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(38, 33);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(48, 14);
            this.labelControl8.TabIndex = 8;
            this.labelControl8.Text = "通知单位";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(38, 265);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(48, 14);
            this.labelControl9.TabIndex = 2;
            this.labelControl9.Text = "备      注";
            this.labelControl9.Click += new System.EventHandler(this.labelControl2_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(253, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "通知日期";
            this.labelControl2.Click += new System.EventHandler(this.labelControl2_Click);
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
            // frmSD26Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 498);
            this.Controls.Add(this.groupControlOrg);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSD26Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电力线路防护通知书";
            this.Load += new System.EventHandler(this.frmdlgzdhjtjlEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOrg)).EndInit();
            this.groupControlOrg.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkuexlmc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.GroupControl groupControlOrg;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit memoEdit3;
        private DevExpress.XtraEditors.MemoEdit memoEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit lkuexlmc;
        private DevExpress.XtraEditors.LabelControl lblxlmc;

    }
}