namespace Ebada.Modules.Demo {
    partial class UCBottomFind {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btFind = new DevExpress.XtraEditors.SimpleButton();
            this.btHide = new DevExpress.XtraEditors.SimpleButton();
            this.btReset = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btFind);
            this.groupControl1.Controls.Add(this.btHide);
            this.groupControl1.Controls.Add(this.btReset);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.textEdit1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(271, 110);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "查询";
            // 
            // btFind
            // 
            this.btFind.Location = new System.Drawing.Point(204, 74);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(52, 23);
            this.btFind.TabIndex = 5;
            this.btFind.Text = "查询";
            this.btFind.Click += new System.EventHandler(this.btFind_Click);
            // 
            // btHide
            // 
            this.btHide.Location = new System.Drawing.Point(85, 74);
            this.btHide.Name = "btHide";
            this.btHide.Size = new System.Drawing.Size(52, 23);
            this.btHide.TabIndex = 5;
            this.btHide.Text = "隐藏";
            this.btHide.Click += new System.EventHandler(this.btHide_Click);
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(143, 74);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(52, 23);
            this.btReset.TabIndex = 5;
            this.btReset.Text = "重置";
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "姓名";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(52, 36);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(204, 21);
            this.textEdit1.TabIndex = 3;
            // 
            // UC2Find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "UC2Find";
            this.Size = new System.Drawing.Size(271, 110);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btFind;
        private DevExpress.XtraEditors.SimpleButton btReset;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton btHide;

    }
}
