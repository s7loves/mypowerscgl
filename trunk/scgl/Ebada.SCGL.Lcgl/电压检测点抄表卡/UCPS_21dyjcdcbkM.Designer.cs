namespace Ebada.Scgl.Lcgl
{
    partial class UCPS_21dyjcdcbkM
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
            this.splitCC1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.down = new Ebada.Scgl.Lcgl.UCPJ_21dyjcdcbkchild();
            this.up = new Ebada.Scgl.Lcgl.UCPJ_21dyjcdcbk();
            ((System.ComponentModel.ISupportInitialize)(this.splitCC1)).BeginInit();
            this.splitCC1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitCC1
            // 
            this.splitCC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCC1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitCC1.Horizontal = false;
            this.splitCC1.Location = new System.Drawing.Point(0, 0);
            this.splitCC1.Name = "splitCC1";
            this.splitCC1.Panel1.Controls.Add(this.up);
            this.splitCC1.Panel1.Text = "Panel1";
            this.splitCC1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitCC1.Panel2.Controls.Add(this.down);
            this.splitCC1.Panel2.ShowCaption = true;
            this.splitCC1.Panel2.Text = "抄表明细";
            this.splitCC1.ShowCaption = true;
            this.splitCC1.Size = new System.Drawing.Size(594, 437);
            this.splitCC1.SplitterPosition = 219;
            this.splitCC1.TabIndex = 1;
            this.splitCC1.Text = "splitContainerControl1";
            // 
            // down
            // 
            this.down.Dock = System.Windows.Forms.DockStyle.Fill;
            this.down.Location = new System.Drawing.Point(0, 0);
            this.down.Name = "down";
            this.down.ReadOnly = false;
            this.down.Size = new System.Drawing.Size(590, 194);
            this.down.TabIndex = 0;
            // 
            // up
            // 
            this.up.CurrRecord = null;
            this.up.Dock = System.Windows.Forms.DockStyle.Fill;
            this.up.Location = new System.Drawing.Point(0, 0);
            this.up.Name = "up";
            this.up.ParentTemple = null;
            this.up.ReadOnly = false;
            this.up.RecordWorkFlowData = null;
            this.up.Size = new System.Drawing.Size(594, 212);
            this.up.TabIndex = 0;
            this.up.VarDbTableName = "PJ_21dyjcdcbk,LP_Record";
            // 
            // UCPS_21dyjcdcbkM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitCC1);
            this.Name = "UCPS_21dyjcdcbkM";
            this.Size = new System.Drawing.Size(594, 437);
            ((System.ComponentModel.ISupportInitialize)(this.splitCC1)).EndInit();
            this.splitCC1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitCC1;
        private UCPJ_21dyjcdcbkchild down;
        private UCPJ_21dyjcdcbk up;
    }
}
