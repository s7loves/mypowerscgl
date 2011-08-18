namespace Ebada.Scgl.Xtgl
{
    partial class frmRoleModul
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
            this.uCmFunctionTree1 = new Ebada.Scgl.Xtgl.UCmRoleModulTree();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.allCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelOpera)).BeginInit();
            this.panelOpera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allCheckEdit.Properties)).BeginInit();
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
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(523, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(442, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            // 
            // uCmFunctionTree1
            // 
            this.uCmFunctionTree1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uCmFunctionTree1.Location = new System.Drawing.Point(0, 0);
            this.uCmFunctionTree1.Name = "uCmFunctionTree1";
            this.uCmFunctionTree1.Size = new System.Drawing.Size(384, 419);
            this.uCmFunctionTree1.TabIndex = 13;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.allCheckEdit);
            this.groupControl1.Controls.Add(this.checkedListBoxControl1);
            this.groupControl1.Location = new System.Drawing.Point(387, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(216, 419);
            this.groupControl1.TabIndex = 14;
            this.groupControl1.Text = "模块操作";
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxControl1.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("aa", "aaa")});
            this.checkedListBoxControl1.Location = new System.Drawing.Point(2, 23);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(212, 394);
            this.checkedListBoxControl1.TabIndex = 0;
            this.checkedListBoxControl1.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.checkedListBoxControl1_ItemCheck);
            this.checkedListBoxControl1.ItemChecking += new DevExpress.XtraEditors.Controls.ItemCheckingEventHandler(this.checkedListBoxControl1_ItemChecking);
            // 
            // allCheckEdit
            // 
            this.allCheckEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.allCheckEdit.Location = new System.Drawing.Point(2, 398);
            this.allCheckEdit.Name = "allCheckEdit";
            this.allCheckEdit.Properties.Caption = "全选";
            this.allCheckEdit.Size = new System.Drawing.Size(212, 19);
            this.allCheckEdit.TabIndex = 1;
            this.allCheckEdit.CheckedChanged += new System.EventHandler(this.allCheckEdit_CheckedChanged);
            // 
            // frmRoleModul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 454);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.uCmFunctionTree1);
            this.Controls.Add(this.panelOpera);
            this.MinimizeBox = false;
            this.Name = "frmRoleModul";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "角色的授权模块";
            ((System.ComponentModel.ISupportInitialize)(this.panelOpera)).EndInit();
            this.panelOpera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allCheckEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelOpera;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        public  UCmRoleModulTree uCmFunctionTree1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private DevExpress.XtraEditors.CheckEdit allCheckEdit;

    }
}