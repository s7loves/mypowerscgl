namespace Ebada.Scgl.Gis.Gps
{
    partial class frm_carrierEdit
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
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtphone = new DevExpress.XtraEditors.TextEdit();
            this.lblphone = new DevExpress.XtraEditors.LabelControl();
            this.txtdriver = new DevExpress.XtraEditors.TextEdit();
            this.lbldriver = new DevExpress.XtraEditors.LabelControl();
            this.txtowner = new DevExpress.XtraEditors.TextEdit();
            this.lblowner = new DevExpress.XtraEditors.LabelControl();
            this.txtplate = new DevExpress.XtraEditors.TextEdit();
            this.lblplate = new DevExpress.XtraEditors.LabelControl();
            this.clcolor = new DevExpress.XtraEditors.ColorEdit();
            this.lblcolor = new DevExpress.XtraEditors.LabelControl();
            this.lblyear = new DevExpress.XtraEditors.LabelControl();
            this.cmbmodel = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblmodel = new DevExpress.XtraEditors.LabelControl();
            this.cmbcarrier_type = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblcarrier_type = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.dateyear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtphone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdriver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtowner.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtplate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clcolor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbmodel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbcarrier_type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateyear.Properties)).BeginInit();
            this.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateyear);
            this.groupBox1.Controls.Add(this.txtphone);
            this.groupBox1.Controls.Add(this.lblphone);
            this.groupBox1.Controls.Add(this.txtdriver);
            this.groupBox1.Controls.Add(this.lbldriver);
            this.groupBox1.Controls.Add(this.txtowner);
            this.groupBox1.Controls.Add(this.lblowner);
            this.groupBox1.Controls.Add(this.txtplate);
            this.groupBox1.Controls.Add(this.lblplate);
            this.groupBox1.Controls.Add(this.clcolor);
            this.groupBox1.Controls.Add(this.lblcolor);
            this.groupBox1.Controls.Add(this.lblyear);
            this.groupBox1.Controls.Add(this.cmbmodel);
            this.groupBox1.Controls.Add(this.lblmodel);
            this.groupBox1.Controls.Add(this.cmbcarrier_type);
            this.groupBox1.Controls.Add(this.lblcarrier_type);
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 205);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "车辆登记信息";
            // 
            // txtphone
            // 
            this.txtphone.Location = new System.Drawing.Point(75, 161);
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(372, 21);
            this.txtphone.TabIndex = 15;
            // 
            // lblphone
            // 
            this.lblphone.Location = new System.Drawing.Point(21, 164);
            this.lblphone.Name = "lblphone";
            this.lblphone.Size = new System.Drawing.Size(48, 14);
            this.lblphone.TabIndex = 14;
            this.lblphone.Text = "联系电话";
            // 
            // txtdriver
            // 
            this.txtdriver.Location = new System.Drawing.Point(295, 95);
            this.txtdriver.Name = "txtdriver";
            this.txtdriver.Size = new System.Drawing.Size(152, 21);
            this.txtdriver.TabIndex = 13;
            // 
            // lbldriver
            // 
            this.lbldriver.Location = new System.Drawing.Point(256, 98);
            this.lbldriver.Name = "lbldriver";
            this.lbldriver.Size = new System.Drawing.Size(24, 14);
            this.lbldriver.TabIndex = 12;
            this.lbldriver.Text = "司机";
            // 
            // txtowner
            // 
            this.txtowner.Location = new System.Drawing.Point(75, 128);
            this.txtowner.Name = "txtowner";
            this.txtowner.Size = new System.Drawing.Size(372, 21);
            this.txtowner.TabIndex = 11;
            // 
            // lblowner
            // 
            this.lblowner.Location = new System.Drawing.Point(21, 131);
            this.lblowner.Name = "lblowner";
            this.lblowner.Size = new System.Drawing.Size(48, 14);
            this.lblowner.TabIndex = 10;
            this.lblowner.Text = "车辆所属";
            // 
            // txtplate
            // 
            this.txtplate.Location = new System.Drawing.Point(75, 95);
            this.txtplate.Name = "txtplate";
            this.txtplate.Size = new System.Drawing.Size(152, 21);
            this.txtplate.TabIndex = 9;
            // 
            // lblplate
            // 
            this.lblplate.Location = new System.Drawing.Point(21, 98);
            this.lblplate.Name = "lblplate";
            this.lblplate.Size = new System.Drawing.Size(36, 14);
            this.lblplate.TabIndex = 8;
            this.lblplate.Text = "车牌号";
            // 
            // clcolor
            // 
            this.clcolor.EditValue = System.Drawing.Color.Empty;
            this.clcolor.Location = new System.Drawing.Point(295, 62);
            this.clcolor.Name = "clcolor";
            this.clcolor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.clcolor.Properties.ShowPopupShadow = false;
            this.clcolor.Properties.ShowSystemColors = false;
            this.clcolor.Properties.ShowWebColors = false;
            this.clcolor.Size = new System.Drawing.Size(152, 21);
            this.clcolor.TabIndex = 7;
            // 
            // lblcolor
            // 
            this.lblcolor.Location = new System.Drawing.Point(256, 65);
            this.lblcolor.Name = "lblcolor";
            this.lblcolor.Size = new System.Drawing.Size(24, 14);
            this.lblcolor.TabIndex = 6;
            this.lblcolor.Text = "颜色";
            // 
            // lblyear
            // 
            this.lblyear.Location = new System.Drawing.Point(21, 65);
            this.lblyear.Name = "lblyear";
            this.lblyear.Size = new System.Drawing.Size(24, 14);
            this.lblyear.TabIndex = 4;
            this.lblyear.Text = "年份";
            // 
            // cmbmodel
            // 
            this.cmbmodel.Location = new System.Drawing.Point(295, 29);
            this.cmbmodel.Name = "cmbmodel";
            this.cmbmodel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbmodel.Size = new System.Drawing.Size(152, 21);
            this.cmbmodel.TabIndex = 3;
            // 
            // lblmodel
            // 
            this.lblmodel.Location = new System.Drawing.Point(256, 32);
            this.lblmodel.Name = "lblmodel";
            this.lblmodel.Size = new System.Drawing.Size(24, 14);
            this.lblmodel.TabIndex = 2;
            this.lblmodel.Text = "型号";
            // 
            // cmbcarrier_type
            // 
            this.cmbcarrier_type.Location = new System.Drawing.Point(75, 29);
            this.cmbcarrier_type.Name = "cmbcarrier_type";
            this.cmbcarrier_type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbcarrier_type.Size = new System.Drawing.Size(152, 21);
            this.cmbcarrier_type.TabIndex = 1;
            // 
            // lblcarrier_type
            // 
            this.lblcarrier_type.Location = new System.Drawing.Point(21, 32);
            this.lblcarrier_type.Name = "lblcarrier_type";
            this.lblcarrier_type.Size = new System.Drawing.Size(48, 14);
            this.lblcarrier_type.TabIndex = 0;
            this.lblcarrier_type.Text = "载体类型";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(301, 223);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(394, 223);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            // 
            // dateyear
            // 
            this.dateyear.Location = new System.Drawing.Point(75, 62);
            this.dateyear.Name = "dateyear";
            this.dateyear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateyear.Size = new System.Drawing.Size(152, 21);
            this.dateyear.TabIndex = 16;
            // 
            // frm_carrierEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 266);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_carrierEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "车辆登记";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtphone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdriver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtowner.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtplate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clcolor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbmodel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbcarrier_type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateyear.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbcarrier_type;
        private DevExpress.XtraEditors.LabelControl lblcarrier_type;
        private DevExpress.XtraEditors.LabelControl lblmodel;
        private DevExpress.XtraEditors.ComboBoxEdit cmbmodel;
        private DevExpress.XtraEditors.LabelControl lblyear;
        private DevExpress.XtraEditors.ColorEdit clcolor;
        private DevExpress.XtraEditors.LabelControl lblcolor;
        private DevExpress.XtraEditors.TextEdit txtplate;
        private DevExpress.XtraEditors.LabelControl lblplate;
        private DevExpress.XtraEditors.LabelControl lblowner;
        private DevExpress.XtraEditors.TextEdit txtowner;
        private DevExpress.XtraEditors.LabelControl lbldriver;
        private DevExpress.XtraEditors.TextEdit txtdriver;
        private DevExpress.XtraEditors.TextEdit txtphone;
        private DevExpress.XtraEditors.LabelControl lblphone;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.ComboBoxEdit dateyear;

    }
}