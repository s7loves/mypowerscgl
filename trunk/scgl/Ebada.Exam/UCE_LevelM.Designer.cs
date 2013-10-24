namespace Ebada.Exam
{
    partial class UCE_LevelM
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.ucE_LevelSeason1 = new Ebada.Exam.UCE_LevelSeason();
            this.ucE_Level1 = new Ebada.Exam.UCE_Level();
            this.ucE_LevelStop1 = new Ebada.Exam.UCE_LevelStop();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl3);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerControl1.Size = new System.Drawing.Size(980, 434);
            this.splitContainerControl1.SplitterPosition = 228;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerControl2.Size = new System.Drawing.Size(980, 200);
            this.splitContainerControl2.SplitterPosition = 464;
            this.splitContainerControl2.TabIndex = 1;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.ucE_Level1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(464, 200);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "季->关卡";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.ucE_LevelStop1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(510, 200);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "关卡->站点";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.ucE_LevelSeason1);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(980, 228);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "闯关->季";
            // 
            // ucE_LevelSeason1
            // 
            this.ucE_LevelSeason1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucE_LevelSeason1.Location = new System.Drawing.Point(2, 23);
            this.ucE_LevelSeason1.Name = "ucE_LevelSeason1";
            this.ucE_LevelSeason1.Size = new System.Drawing.Size(976, 203);
            this.ucE_LevelSeason1.TabIndex = 0;
            // 
            // ucE_Level1
            // 
            this.ucE_Level1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucE_Level1.Location = new System.Drawing.Point(2, 23);
            this.ucE_Level1.Name = "ucE_Level1";
            this.ucE_Level1.Size = new System.Drawing.Size(460, 175);
            this.ucE_Level1.TabIndex = 0;
            // 
            // ucE_LevelStop1
            // 
            this.ucE_LevelStop1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucE_LevelStop1.Location = new System.Drawing.Point(2, 23);
            this.ucE_LevelStop1.Name = "ucE_LevelStop1";
            this.ucE_LevelStop1.ParentIDB = null;
            this.ucE_LevelStop1.Size = new System.Drawing.Size(506, 175);
            this.ucE_LevelStop1.TabIndex = 0;
            // 
            // UCE_LevelM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "UCE_LevelM";
            this.Size = new System.Drawing.Size(980, 434);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private UCE_LevelSeason ucE_LevelSeason1;
        private UCE_Level ucE_Level1;
        private UCE_LevelStop ucE_LevelStop1;
    }
}
