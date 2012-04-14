namespace Ebada.Scgl.Lcgl
{
    partial class WorkFlowOne
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
            this.uCmLPRecord1 = new Ebada.Scgl.Lcgl.UCmLPRecord();
            this.SuspendLayout();
            // 
            // uCmLPRecord1
            // 
            this.uCmLPRecord1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uCmLPRecord1.Location = new System.Drawing.Point(0, 0);
            this.uCmLPRecord1.Name = "uCmLPRecord1";
            this.uCmLPRecord1.Size = new System.Drawing.Size(1028, 396);
            this.uCmLPRecord1.TabIndex = 0;
            // 
            // WorkFlowOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 396);
            this.Controls.Add(this.uCmLPRecord1);
            this.Name = "WorkFlowOne";
            this.Text = "流程信息";
            this.ResumeLayout(false);

        }

        #endregion

        private UCmLPRecord uCmLPRecord1;



    }
}