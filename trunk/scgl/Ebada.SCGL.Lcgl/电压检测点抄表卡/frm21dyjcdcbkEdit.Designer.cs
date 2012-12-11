namespace Ebada.Scgl.Lcgl
{
    partial class frm21dyjcdcbkEdit
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControlOrg = new DevExpress.XtraEditors.GroupControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cobNum = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cobType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cobGds = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cobModel = new DevExpress.XtraEditors.ComboBoxEdit();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.cobYear = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOrg)).BeginInit();
            this.groupControlOrg.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cobNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobGds.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobYear.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobYear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(394, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(318, 190);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 23);
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
            this.groupControlOrg.Size = new System.Drawing.Size(489, 225);
            this.groupControlOrg.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cobYear);
            this.groupBox1.Controls.Add(this.cobNum);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.cobType);
            this.groupBox1.Controls.Add(this.labelControl6);
            this.groupBox1.Controls.Add(this.labelControl7);
            this.groupBox1.Controls.Add(this.labelControl8);
            this.groupBox1.Controls.Add(this.cobGds);
            this.groupBox1.Controls.Add(this.cobModel);
            this.groupBox1.Location = new System.Drawing.Point(11, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 130);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "抄表卡表头";
            // 
            // cobNum
            // 
            this.cobNum.Location = new System.Drawing.Point(329, 84);
            this.cobNum.Name = "cobNum";
            this.cobNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cobNum.Properties.DisplayFormat.FormatString = "d";
            this.cobNum.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cobNum.Properties.EditFormat.FormatString = "d";
            this.cobNum.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cobNum.Properties.Items.AddRange(new object[] {
            "增容",
            "减容",
            "大修",
            "设备改造",
            "烧毁"});
            this.cobNum.Size = new System.Drawing.Size(118, 21);
            this.cobNum.TabIndex = 23;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(239, 87);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(88, 14);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "电压检测点序号:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 87);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 20;
            this.labelControl1.Text = "装置型号:";
            // 
            // cobType
            // 
            this.cobType.Location = new System.Drawing.Point(329, 53);
            this.cobType.Name = "cobType";
            this.cobType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cobType.Properties.DisplayFormat.FormatString = "d";
            this.cobType.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cobType.Properties.EditFormat.FormatString = "d";
            this.cobType.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cobType.Properties.Items.AddRange(new object[] {
            "增容",
            "减容",
            "大修",
            "设备改造",
            "烧毁"});
            this.cobType.Size = new System.Drawing.Size(118, 21);
            this.cobType.TabIndex = 19;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(23, 25);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(48, 14);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "供电所：";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(23, 56);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(36, 14);
            this.labelControl7.TabIndex = 11;
            this.labelControl7.Text = "年度：";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(239, 56);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(88, 14);
            this.labelControl8.TabIndex = 12;
            this.labelControl8.Text = "电压检测点类型:";
            // 
            // cobGds
            // 
            this.cobGds.Location = new System.Drawing.Point(92, 21);
            this.cobGds.Name = "cobGds";
            this.cobGds.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.cobGds.Properties.ReadOnly = true;
            this.cobGds.Size = new System.Drawing.Size(355, 21);
            this.cobGds.TabIndex = 14;
            // 
            // cobModel
            // 
            this.cobModel.Location = new System.Drawing.Point(92, 84);
            this.cobModel.Name = "cobModel";
            this.cobModel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cobModel.Properties.DisplayFormat.FormatString = "d";
            this.cobModel.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cobModel.Properties.EditFormat.FormatString = "d";
            this.cobModel.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.cobModel.Size = new System.Drawing.Size(134, 21);
            this.cobModel.TabIndex = 21;
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
            // cobYear
            // 
            this.cobYear.EditValue = null;
            this.cobYear.Location = new System.Drawing.Point(92, 53);
            this.cobYear.Name = "cobYear";
            this.cobYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cobYear.Properties.Mask.EditMask = "yyyy年";
            this.cobYear.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.cobYear.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.cobYear.Size = new System.Drawing.Size(134, 21);
            this.cobYear.TabIndex = 24;
            // 
            // frm21dyjcdcbkEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 225);
            this.Controls.Add(this.groupControlOrg);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm21dyjcdcbkEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "供电所电压抄表卡";
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOrg)).EndInit();
            this.groupControlOrg.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cobNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobGds.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobYear.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobYear.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.GroupControl groupControlOrg;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit cobGds;
        private DevExpress.XtraEditors.ComboBoxEdit cobModel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cobType;
        private DevExpress.XtraEditors.ComboBoxEdit cobNum;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit cobYear;

    }
}