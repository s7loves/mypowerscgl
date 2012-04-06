namespace Ebada.Scgl.Run
{
    partial class frmModuleEdit
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtFileName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtAssemfileName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtIcoName = new DevExpress.XtraEditors.ButtonEdit();
            this.spesequence = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAssemfileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIcoName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spesequence.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButton1.Location = new System.Drawing.Point(260, 226);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "确定";
            // 
            // simpleButton2
            // 
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton2.Location = new System.Drawing.Point(349, 226);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "取消";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(99, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(345, 21);
            this.txtName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(27, 18);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "子系统名称";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(99, 58);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(345, 21);
            this.txtFileName.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(27, 59);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "子系统文件";
            // 
            // txtAssemfileName
            // 
            this.txtAssemfileName.Location = new System.Drawing.Point(99, 104);
            this.txtAssemfileName.Name = "txtAssemfileName";
            this.txtAssemfileName.Size = new System.Drawing.Size(345, 21);
            this.txtAssemfileName.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(27, 105);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "集和文件名";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(39, 144);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "显示顺序";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(39, 190);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "图标名称";
            // 
            // txtIcoName
            // 
            this.txtIcoName.Location = new System.Drawing.Point(99, 189);
            this.txtIcoName.Name = "txtIcoName";
            this.txtIcoName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtIcoName.Size = new System.Drawing.Size(345, 21);
            this.txtIcoName.TabIndex = 12;
            this.txtIcoName.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtIcoName_ButtonClick);
            // 
            // spesequence
            // 
            this.spesequence.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spesequence.Location = new System.Drawing.Point(99, 148);
            this.spesequence.Name = "spesequence";
            this.spesequence.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spesequence.Size = new System.Drawing.Size(345, 21);
            this.spesequence.TabIndex = 13;
            // 
            // frmModuleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 263);
            this.Controls.Add(this.spesequence);
            this.Controls.Add(this.txtIcoName);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtAssemfileName);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Name = "frmModuleEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "子系统编辑";
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAssemfileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIcoName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spesequence.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtFileName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtAssemfileName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ButtonEdit txtIcoName;
        private DevExpress.XtraEditors.SpinEdit spesequence;
    }
}