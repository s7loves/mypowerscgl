namespace Ebada.Scgl.Gis
{
    partial class frmMapXlt
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
            this.ucXianLuTu1 = new Ebada.Scgl.Gis.变电站接线图.UCXianLuTu();
            this.SuspendLayout();
            // 
            // ucXianLuTu1
            // 
            this.ucXianLuTu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucXianLuTu1.Location = new System.Drawing.Point(0, 0);
            this.ucXianLuTu1.Name = "ucXianLuTu1";
            this.ucXianLuTu1.OrgCode = null;
            this.ucXianLuTu1.ShowBar = true;
            this.ucXianLuTu1.Size = new System.Drawing.Size(984, 564);
            this.ucXianLuTu1.TabIndex = 0;
            // 
            // frmMapXlt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 564);
            this.Controls.Add(this.ucXianLuTu1);
            this.Name = "frmMapXlt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "变电站接线图";
            this.ResumeLayout(false);

        }

        #endregion

        private Ebada.Scgl.Gis.变电站接线图.UCXianLuTu ucXianLuTu1;
    }
}