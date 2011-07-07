namespace Ebada.Scgl.Xtgl
{
    partial class frmUserRole
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
            this.panelOpera = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.uCmFunctionTree1 = new Ebada.Scgl.Xtgl.UCmUserRoleTree();
            ((System.ComponentModel.ISupportInitialize)(this.panelOpera)).BeginInit();
            this.panelOpera.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOpera
            // 
            this.panelOpera.Controls.Add(this.btnCancel);
            this.panelOpera.Controls.Add(this.btnOK);
            this.panelOpera.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelOpera.Location = new System.Drawing.Point(0, 419);
            this.panelOpera.Name = "panelOpera";
            this.panelOpera.Size = new System.Drawing.Size(603, 35);
            this.panelOpera.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(523, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(442, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            // 
            // uCmFunctionTree1
            // 
            this.uCmFunctionTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uCmFunctionTree1.Location = new System.Drawing.Point(0, 0);
            this.uCmFunctionTree1.Name = "uCmFunctionTree1";
            this.uCmFunctionTree1.Size = new System.Drawing.Size(603, 419);
            this.uCmFunctionTree1.TabIndex = 13;
            // 
            // frmUserRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 454);
            this.Controls.Add(this.uCmFunctionTree1);
            this.Controls.Add(this.panelOpera);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserRole";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "角色的授权用户";
            ((System.ComponentModel.ISupportInitialize)(this.panelOpera)).EndInit();
            this.panelOpera.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelOpera;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        public  UCmUserRoleTree uCmFunctionTree1;

    }
}