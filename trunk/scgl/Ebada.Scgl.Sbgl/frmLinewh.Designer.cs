namespace Ebada.Scgl.Sbgl {
    partial class frmLinewh {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucPopupLine1 = new Ebada.Scgl.Sbgl.UCPopupLine();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.memoEdit2 = new DevExpress.XtraEditors.MemoEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucPopupLine1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.memoEdit1);
            this.groupBox1.Controls.Add(this.ucPopupLine1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 430);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "变更前线路";
            // 
            // ucPopupLine1
            // 
            this.ucPopupLine1.DataSource = null;
            this.ucPopupLine1.DisplayField = "LineName";
            this.ucPopupLine1.EditValue = "请选择变更线路...";
            this.ucPopupLine1.Location = new System.Drawing.Point(17, 20);
            this.ucPopupLine1.Name = "ucPopupLine1";
            this.ucPopupLine1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ucPopupLine1.Properties.NullText = "请选择...";
            this.ucPopupLine1.Size = new System.Drawing.Size(252, 21);
            this.ucPopupLine1.TabIndex = 0;
            this.ucPopupLine1.ValueField = "LineID";
            this.ucPopupLine1.EditValueChanged += new System.EventHandler(this.ucPopupLine1_EditValueChanged);
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(17, 47);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.MaxLength = 500;
            this.memoEdit1.Size = new System.Drawing.Size(252, 365);
            this.memoEdit1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOK);
            this.groupBox2.Controls.Add(this.textEdit1);
            this.groupBox2.Controls.Add(this.memoEdit2);
            this.groupBox2.Location = new System.Drawing.Point(318, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(290, 430);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "变更后线路";
            // 
            // memoEdit2
            // 
            this.memoEdit2.Location = new System.Drawing.Point(17, 47);
            this.memoEdit2.Name = "memoEdit2";
            this.memoEdit2.Properties.MaxLength = 500;
            this.memoEdit2.Size = new System.Drawing.Size(252, 365);
            this.memoEdit2.TabIndex = 1;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(17, 20);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.NullText = "输入新线路代码";
            this.textEdit1.Size = new System.Drawing.Size(194, 21);
            this.textEdit1.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(214, 20);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(55, 21);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "变更";
            // 
            // frmLinewh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 454);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLinewh";
            this.Text = "线路代码变更";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucPopupLine1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private UCPopupLine ucPopupLine1;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.MemoEdit memoEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton btnOK;

    }
}