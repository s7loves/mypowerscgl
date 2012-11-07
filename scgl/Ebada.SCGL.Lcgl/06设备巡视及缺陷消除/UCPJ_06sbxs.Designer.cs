namespace Ebada.Scgl.Lcgl
{
    partial class UCPJ_06sbxs
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
            this.ucTop = new Ebada.Scgl.Lcgl.UCPJ_06sbxsmain();
            this.ucBottom = new Ebada.Scgl.Lcgl.UCPJ_06sbxsmx();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucTop
            // 
            this.ucTop.CurrRecord = null;
            this.ucTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTop.Location = new System.Drawing.Point(0, 0);
            this.ucTop.Name = "ucTop";
            this.ucTop.ParentTemple = null;
            this.ucTop.ReadOnly = false;
            this.ucTop.RecordWorkFlowData = null;
            this.ucTop.Size = new System.Drawing.Size(646, 157);
            this.ucTop.TabIndex = 0;
            this.ucTop.VarDbTableName = "PJ_06sbxs,PJ_06sbxsmx,LP_Record";
            // 
            // ucBottom
            // 
            this.ucBottom.CurrRecord = null;
            this.ucBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBottom.Location = new System.Drawing.Point(0, 0);
            this.ucBottom.Name = "ucBottom";
            this.ucBottom.ParentTemple = null;
            this.ucBottom.ReadOnly = false;
            this.ucBottom.RecordWorkFlowData = null;
            this.ucBottom.Size = new System.Drawing.Size(646, 212);
            this.ucBottom.TabIndex = 0;
            this.ucBottom.VarDbTableName = "PJ_06sbxs,PJ_06sbxsmx,LP_Record";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel1.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.splitContainerControl1.Panel1.Controls.Add(this.ucTop);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "设备巡视及缺陷主表";
            this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel2.Controls.Add(this.ucBottom);
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "设备巡视及缺陷消除子表";
            this.splitContainerControl1.Size = new System.Drawing.Size(650, 425);
            this.splitContainerControl1.SplitterPosition = 182;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // UCPJ_06sbxs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "UCPJ_06sbxs";
            this.Size = new System.Drawing.Size(650, 425);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private UCPJ_06sbxsmain ucTop;
        private UCPJ_06sbxsmx ucBottom;
    }
}
