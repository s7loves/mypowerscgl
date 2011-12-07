namespace Ebada.Scgl.Lcgl
{
    partial class frm20Template
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
            this.components = new System.ComponentModel.Container();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dsoFramerWordControl1 = new Ebada.Scgl.Core.DSOFramerControl();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.AutoScroll = true;
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("fcd8e35e-d579-45cc-ae9c-18f4bd63c9f5");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(473, 200);
            this.dockPanel1.Size = new System.Drawing.Size(473, 487);
            this.dockPanel1.Text = "操作栏";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.AutoScroll = true;
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(467, 459);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dsoFramerWordControl1
            // 
            this.dsoFramerWordControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dsoFramerWordControl1.Location = new System.Drawing.Point(473, 0);
            this.dsoFramerWordControl1.Name = "dsoFramerWordControl1";
            this.dsoFramerWordControl1.Size = new System.Drawing.Size(253, 487);
            this.dsoFramerWordControl1.TabIndex = 1;
            // 
            // frmLP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 487);
            this.Controls.Add(this.dsoFramerWordControl1);
            this.Controls.Add(this.dockPanel1);
            this.Name = "frmLP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "表单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LPFrm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLP_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLP_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private new Ebada.Scgl.Core.DSOFramerControl dsoFramerWordControl1;
    }
}