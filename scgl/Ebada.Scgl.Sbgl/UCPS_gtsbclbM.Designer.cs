namespace Ebada.Scgl.Sbgl {
    partial class UCPS_gtsbclbM {
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
            this.splitCC1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ucTop = new Ebada.Scgl.Sbgl.UCPS_gtsbclb();
            this.ucBottom = new Ebada.Scgl.Sbgl.UCPS_gtsbclb();
            ((System.ComponentModel.ISupportInitialize)(this.splitCC1)).BeginInit();
            this.splitCC1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitCC1
            // 
            this.splitCC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCC1.Location = new System.Drawing.Point(0, 0);
            this.splitCC1.Name = "splitCC1";
            this.splitCC1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.splitCC1.Panel1.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.splitCC1.Panel1.Controls.Add(this.ucTop);
            this.splitCC1.Panel1.ShowCaption = true;
            this.splitCC1.Panel1.Text = "台区类型";
            this.splitCC1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitCC1.Panel2.Controls.Add(this.ucBottom);
            this.splitCC1.Panel2.ShowCaption = true;
            this.splitCC1.Panel2.Text = "台区类型详细信息";
            this.splitCC1.ShowCaption = true;
            this.splitCC1.Size = new System.Drawing.Size(555, 460);
            this.splitCC1.SplitterPosition = 265;
            this.splitCC1.TabIndex = 0;
            this.splitCC1.Text = "splitContainerControl1";
            // 
            // ucTop
            // 
            this.ucTop.ChildView = null;
            this.ucTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTop.Location = new System.Drawing.Point(0, 0);
            this.ucTop.Name = "ucTop";
            this.ucTop.Size = new System.Drawing.Size(261, 435);
            this.ucTop.TabIndex = 0;
            // 
            // ucBottom
            // 
            this.ucBottom.ChildView = null;
            this.ucBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBottom.Location = new System.Drawing.Point(0, 0);
            this.ucBottom.Name = "ucBottom";
            this.ucBottom.Size = new System.Drawing.Size(280, 435);
            this.ucBottom.TabIndex = 0;
            // 
            // UCPS_gtsbclbM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitCC1);
            this.Name = "UCPS_gtsbclbM";
            this.Size = new System.Drawing.Size(555, 460);
            ((System.ComponentModel.ISupportInitialize)(this.splitCC1)).EndInit();
            this.splitCC1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SplitContainerControl splitCC1;
        private UCPS_gtsbclb ucTop;
        private UCPS_gtsbclb ucBottom;

    }
}
