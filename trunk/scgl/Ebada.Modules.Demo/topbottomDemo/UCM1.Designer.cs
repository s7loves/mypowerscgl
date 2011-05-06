namespace Ebada.Modules.Demo {
    partial class UCM1 {
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
            this.ucTop1 = new Ebada.Modules.Demo.UCTop();
            this.ucBottom1 = new Ebada.Modules.Demo.UCBottom();
            ((System.ComponentModel.ISupportInitialize)(this.splitCC1)).BeginInit();
            this.splitCC1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitCC1
            // 
            this.splitCC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCC1.Horizontal = false;
            this.splitCC1.Location = new System.Drawing.Point(0, 0);
            this.splitCC1.Name = "splitCC1";
            this.splitCC1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.splitCC1.Panel1.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.splitCC1.Panel1.Controls.Add(this.ucTop1);
            this.splitCC1.Panel1.ShowCaption = true;
            this.splitCC1.Panel1.Text = "单位";
            this.splitCC1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitCC1.Panel2.Controls.Add(this.ucBottom1);
            this.splitCC1.Panel2.ShowCaption = true;
            this.splitCC1.Panel2.Text = "职员";
            this.splitCC1.ShowCaption = true;
            this.splitCC1.Size = new System.Drawing.Size(400, 349);
            this.splitCC1.SplitterPosition = 235;
            this.splitCC1.TabIndex = 0;
            this.splitCC1.Text = "splitContainerControl1";
            // 
            // ucTop1
            // 
            this.ucTop1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTop1.Location = new System.Drawing.Point(0, 0);
            this.ucTop1.Name = "ucTop1";
            this.ucTop1.Size = new System.Drawing.Size(396, 210);
            this.ucTop1.TabIndex = 0;
            // 
            // ucBottom1
            // 
            this.ucBottom1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBottom1.Location = new System.Drawing.Point(0, 0);
            this.ucBottom1.Name = "ucBottom1";
            this.ucBottom1.Size = new System.Drawing.Size(396, 83);
            this.ucBottom1.TabIndex = 0;
            // 
            // UCM1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitCC1);
            this.Name = "UCM1";
            this.Size = new System.Drawing.Size(400, 349);
            ((System.ComponentModel.ISupportInitialize)(this.splitCC1)).EndInit();
            this.splitCC1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SplitContainerControl splitCC1;
        private UCTop ucTop1;
        private UCBottom ucBottom1;

    }
}
