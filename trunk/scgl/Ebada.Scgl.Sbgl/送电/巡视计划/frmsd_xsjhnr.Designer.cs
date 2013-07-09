namespace Ebada.Scgl.Sbgl
{
    partial class frmsd_xsjhnr
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.lkueEndGt = new DevExpress.XtraEditors.LookUpEdit();
            this.lblEndGt = new DevExpress.XtraEditors.LabelControl();
            this.lkueStartGt = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.lblxssj = new DevExpress.XtraEditors.LabelControl();
            this.datexssj = new DevExpress.XtraEditors.DateEdit();
            this.lblxszt = new DevExpress.XtraEditors.LabelControl();
            this.cmbxszt = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkueEndGt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkueStartGt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datexssj.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datexssj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbxszt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.xtraTabControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnOk);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(572, 424);
            this.splitContainerControl1.SplitterPosition = 379;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(572, 379);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.cmbxszt);
            this.xtraTabPage1.Controls.Add(this.lblxszt);
            this.xtraTabPage1.Controls.Add(this.datexssj);
            this.xtraTabPage1.Controls.Add(this.lblxssj);
            this.xtraTabPage1.Controls.Add(this.lkueEndGt);
            this.xtraTabPage1.Controls.Add(this.lblEndGt);
            this.xtraTabPage1.Controls.Add(this.lkueStartGt);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(565, 349);
            this.xtraTabPage1.Text = "杆塔范围";
            // 
            // lkueEndGt
            // 
            this.lkueEndGt.Location = new System.Drawing.Point(99, 75);
            this.lkueEndGt.Name = "lkueEndGt";
            this.lkueEndGt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkueEndGt.Size = new System.Drawing.Size(417, 21);
            this.lkueEndGt.TabIndex = 3;
            this.lkueEndGt.EditValueChanged += new System.EventHandler(this.lkueEndGt_EditValueChanged);
            // 
            // lblEndGt
            // 
            this.lblEndGt.Location = new System.Drawing.Point(28, 78);
            this.lblEndGt.Name = "lblEndGt";
            this.lblEndGt.Size = new System.Drawing.Size(48, 14);
            this.lblEndGt.TabIndex = 2;
            this.lblEndGt.Text = "终止杆塔";
            // 
            // lkueStartGt
            // 
            this.lkueStartGt.Location = new System.Drawing.Point(99, 29);
            this.lkueStartGt.Name = "lkueStartGt";
            this.lkueStartGt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkueStartGt.Size = new System.Drawing.Size(417, 21);
            this.lkueStartGt.TabIndex = 1;
            this.lkueStartGt.EditValueChanged += new System.EventHandler(this.lkueStartGt_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "起始杆塔";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(484, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(390, 13);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblxssj
            // 
            this.lblxssj.Location = new System.Drawing.Point(28, 124);
            this.lblxssj.Name = "lblxssj";
            this.lblxssj.Size = new System.Drawing.Size(48, 14);
            this.lblxssj.TabIndex = 4;
            this.lblxssj.Text = "巡视时间";
            // 
            // datexssj
            // 
            this.datexssj.EditValue = null;
            this.datexssj.Location = new System.Drawing.Point(99, 121);
            this.datexssj.Name = "datexssj";
            this.datexssj.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datexssj.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datexssj.Size = new System.Drawing.Size(417, 21);
            this.datexssj.TabIndex = 5;
            this.datexssj.EditValueChanged += new System.EventHandler(this.datexssj_EditValueChanged);
            // 
            // lblxszt
            // 
            this.lblxszt.Location = new System.Drawing.Point(28, 170);
            this.lblxszt.Name = "lblxszt";
            this.lblxszt.Size = new System.Drawing.Size(48, 14);
            this.lblxszt.TabIndex = 6;
            this.lblxszt.Text = "巡视状态";
            // 
            // cmbxszt
            // 
            this.cmbxszt.Location = new System.Drawing.Point(99, 167);
            this.cmbxszt.Name = "cmbxszt";
            this.cmbxszt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbxszt.Properties.Items.AddRange(new object[] {
            "已巡视",
            "未巡视"});
            this.cmbxszt.Size = new System.Drawing.Size(417, 21);
            this.cmbxszt.TabIndex = 7;
            this.cmbxszt.EditValueChanged += new System.EventHandler(this.cmbxszt_EditValueChanged);
            // 
            // frmsd_xsjhnr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 424);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmsd_xsjhnr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "详细任务列表";
            this.Load += new System.EventHandler(this.frmSBTZ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkueEndGt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkueStartGt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datexssj.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datexssj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbxszt.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.LookUpEdit lkueEndGt;
        private DevExpress.XtraEditors.LabelControl lblEndGt;
        private DevExpress.XtraEditors.LookUpEdit lkueStartGt;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblxszt;
        private DevExpress.XtraEditors.DateEdit datexssj;
        private DevExpress.XtraEditors.LabelControl lblxssj;
        private DevExpress.XtraEditors.ComboBoxEdit cmbxszt;

    }
}