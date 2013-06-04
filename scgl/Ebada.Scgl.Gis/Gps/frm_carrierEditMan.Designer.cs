namespace Ebada.Scgl.Gis.Gps
{
    partial class frm_carrierEditMan
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
            this.txtplate = new DevExpress.XtraEditors.TextEdit();
            this.lblplate = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtphone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtplate.Properties)).BeginInit();
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
            this.groupBox1.Controls.Add(this.txtphone);
            this.groupBox1.Controls.Add(this.lblphone);
            this.groupBox1.Controls.Add(this.txtplate);
            this.groupBox1.Controls.Add(this.lblplate);
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "人员信息";
            // 
            // txtphone
            // 
            this.txtphone.Location = new System.Drawing.Point(75, 72);
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(372, 21);
            this.txtphone.TabIndex = 15;
            // 
            // lblphone
            // 
            this.lblphone.Location = new System.Drawing.Point(21, 75);
            this.lblphone.Name = "lblphone";
            this.lblphone.Size = new System.Drawing.Size(48, 14);
            this.lblphone.TabIndex = 14;
            this.lblphone.Text = "联系电话";
            // 
            // txtplate
            // 
            this.txtplate.Location = new System.Drawing.Point(75, 30);
            this.txtplate.Name = "txtplate";
            this.txtplate.Size = new System.Drawing.Size(372, 21);
            this.txtplate.TabIndex = 9;
            // 
            // lblplate
            // 
            this.lblplate.Location = new System.Drawing.Point(21, 33);
            this.lblplate.Name = "lblplate";
            this.lblplate.Size = new System.Drawing.Size(24, 14);
            this.lblplate.TabIndex = 8;
            this.lblplate.Text = "姓名";
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
            // frm_carrierEditMan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 262);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_carrierEditMan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "人员登记";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtphone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtplate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.TextEdit txtplate;
        private DevExpress.XtraEditors.LabelControl lblplate;
        private DevExpress.XtraEditors.TextEdit txtphone;
        private DevExpress.XtraEditors.LabelControl lblphone;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;

    }
}