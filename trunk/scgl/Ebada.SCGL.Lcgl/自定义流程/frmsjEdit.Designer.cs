namespace Ebada.Scgl.Lcgl
{
    partial class frmsjEdit
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
            this.lblcjsj = new DevExpress.XtraEditors.LabelControl();
            this.dateCreateTime = new DevExpress.XtraEditors.DateEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dateCreateTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCreateTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblcjsj
            // 
            this.lblcjsj.Location = new System.Drawing.Point(23, 15);
            this.lblcjsj.Name = "lblcjsj";
            this.lblcjsj.Size = new System.Drawing.Size(48, 14);
            this.lblcjsj.TabIndex = 0;
            this.lblcjsj.Text = "创建时间";
            // 
            // dateCreateTime
            // 
            this.dateCreateTime.EditValue = null;
            this.dateCreateTime.Location = new System.Drawing.Point(89, 12);
            this.dateCreateTime.Name = "dateCreateTime";
            this.dateCreateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateCreateTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateCreateTime.Size = new System.Drawing.Size(271, 21);
            this.dateCreateTime.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(239, 39);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(48, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(302, 39);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(48, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmsjEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 67);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dateCreateTime);
            this.Controls.Add(this.lblcjsj);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmsjEdit";
            this.Text = "修改时间";
            this.Load += new System.EventHandler(this.frmsjEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateCreateTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCreateTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblcjsj;
        private DevExpress.XtraEditors.DateEdit dateCreateTime;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}