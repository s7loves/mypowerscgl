namespace Ebada.Scgl.Core {
    partial class frmDykSelector {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ucpJ_dykSelector1 = new Ebada.Scgl.Core.UCPJ_dykSelector();
            this.SuspendLayout();
            // 
            // ucpJ_dykSelector1
            // 
            this.ucpJ_dykSelector1.ChildView = null;
            this.ucpJ_dykSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucpJ_dykSelector1.Location = new System.Drawing.Point(0, 0);
            this.ucpJ_dykSelector1.Name = "ucpJ_dykSelector1";
            this.ucpJ_dykSelector1.Size = new System.Drawing.Size(752, 385);
            this.ucpJ_dykSelector1.TabIndex = 0;
            this.ucpJ_dykSelector1.TextMemo = null;
            // 
            // frmDykSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 385);
            this.Controls.Add(this.ucpJ_dykSelector1);
            this.Location = new System.Drawing.Point(200, 100);
            this.Name = "frmDykSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "短语库";
            this.ResumeLayout(false);

        }

        #endregion

        public UCPJ_dykSelector ucpJ_dykSelector1;

    }
}