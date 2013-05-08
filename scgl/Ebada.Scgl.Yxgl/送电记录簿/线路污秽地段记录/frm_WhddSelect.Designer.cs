namespace Ebada.Scgl.Yxgl
{
    partial class frm_WhddSelect
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
            this.ucsD_whdd1 = new Ebada.Scgl.Yxgl.UCSD_whdd();
            this.SuspendLayout();
            // 
            // ucsD_whdd1
            // 
            this.ucsD_whdd1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucsD_whdd1.Location = new System.Drawing.Point(0, 0);
            this.ucsD_whdd1.Name = "ucsD_whdd1";
            this.ucsD_whdd1.Size = new System.Drawing.Size(589, 430);
            this.ucsD_whdd1.TabIndex = 0;
            // 
            // frm_WhddSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 430);
            this.Controls.Add(this.ucsD_whdd1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_WhddSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "污秽区段选择";
            this.ResumeLayout(false);

        }

        #endregion

        private UCSD_whdd ucsD_whdd1;





    }
}