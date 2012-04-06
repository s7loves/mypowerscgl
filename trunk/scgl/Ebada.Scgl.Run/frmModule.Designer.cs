namespace Ebada.Scgl.Run
{
    partial class frmModule
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
            this.uCmSystemTree1 = new Ebada.Scgl.Run.UCmSystemTree();
            this.SuspendLayout();
            // 
            // uCmSystemTree1
            // 
            this.uCmSystemTree1.ChildView = null;
            this.uCmSystemTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uCmSystemTree1.Location = new System.Drawing.Point(0, 0);
            this.uCmSystemTree1.Name = "uCmSystemTree1";
            this.uCmSystemTree1.Size = new System.Drawing.Size(587, 294);
            this.uCmSystemTree1.TabIndex = 0;
            // 
            // frmModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 294);
            this.Controls.Add(this.uCmSystemTree1);
            this.Name = "frmModule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmModule";
            this.Load += new System.EventHandler(this.frmModule_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UCmSystemTree uCmSystemTree1;

    }
}