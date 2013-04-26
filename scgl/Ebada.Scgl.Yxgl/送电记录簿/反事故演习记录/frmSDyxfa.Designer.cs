namespace Ebada.Scgl.Yxgl
{
    partial class frmSDyxfa
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
            this.ucsD_yxfa1 = new Ebada.Scgl.Yxgl.UCSD_yxfa();
            this.SuspendLayout();
            // 
            // ucsD_yxfa1
            // 
            this.ucsD_yxfa1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucsD_yxfa1.Location = new System.Drawing.Point(0, 0);
            this.ucsD_yxfa1.Name = "ucsD_yxfa1";
            this.ucsD_yxfa1.Size = new System.Drawing.Size(618, 437);
            this.ucsD_yxfa1.TabIndex = 0;
            // 
            // frmSDyxfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 437);
            this.Controls.Add(this.ucsD_yxfa1);
            this.Name = "frmSDyxfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "演习方案";
            this.ResumeLayout(false);

        }

        #endregion

        private UCSD_yxfa ucsD_yxfa1;

    }
}