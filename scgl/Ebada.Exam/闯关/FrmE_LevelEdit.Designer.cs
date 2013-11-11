namespace Ebada.Exam
{
    partial class FrmE_LevelEdit
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
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.spSequence = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.mtxtDesc = new DevExpress.XtraEditors.MemoEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spSequence.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(269, 303);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 27);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确 定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(371, 303);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取 消";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.spinEdit1);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.spSequence);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.mtxtDesc);
            this.groupControl1.Controls.Add(this.txtName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(25, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(466, 272);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "季-关卡信息";
            // 
            // spSequence
            // 
            this.spSequence.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spSequence.Location = new System.Drawing.Point(102, 77);
            this.spSequence.Name = "spSequence";
            this.spSequence.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spSequence.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spSequence.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spSequence.Size = new System.Drawing.Size(346, 21);
            this.spSequence.TabIndex = 23;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(46, 79);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "序号：";
            // 
            // mtxtDesc
            // 
            this.mtxtDesc.Location = new System.Drawing.Point(102, 150);
            this.mtxtDesc.Name = "mtxtDesc";
            this.mtxtDesc.Size = new System.Drawing.Size(346, 108);
            this.mtxtDesc.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(102, 48);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(346, 21);
            this.txtName.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(46, 143);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "描述：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "关卡名：";
            // 
            // spinEdit1
            // 
            this.spinEdit1.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(102, 109);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit1.Properties.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spinEdit1.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit1.Size = new System.Drawing.Size(346, 21);
            this.spinEdit1.TabIndex = 25;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(22, 111);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 24;
            this.labelControl4.Text = "积分系数：";
            // 
            // FrmE_LevelEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 342);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "FrmE_LevelEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑季-关卡";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spSequence.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.MemoEdit mtxtDesc;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit spSequence;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}