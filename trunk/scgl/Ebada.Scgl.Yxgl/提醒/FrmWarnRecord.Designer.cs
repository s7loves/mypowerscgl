namespace Ebada.Scgl.Yxgl
{
    partial class FrmWarnRecord
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
            this.ucWarnRecord1 = new Ebada.Scgl.Yxgl.UCWarnRecord();
            this.SuspendLayout();
            // 
            // ucWarnRecord1
            // 
            this.ucWarnRecord1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWarnRecord1.GridViewOperation = null;
            this.ucWarnRecord1.Location = new System.Drawing.Point(0, 0);
            this.ucWarnRecord1.Name = "ucWarnRecord1";
            this.ucWarnRecord1.Size = new System.Drawing.Size(783, 427);
            this.ucWarnRecord1.TabIndex = 0;
            // 
            // FrmWarnRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 427);
            this.Controls.Add(this.ucWarnRecord1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWarnRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提醒记录";
            this.ResumeLayout(false);

        }

        #endregion

        private UCWarnRecord ucWarnRecord1;
    }
}