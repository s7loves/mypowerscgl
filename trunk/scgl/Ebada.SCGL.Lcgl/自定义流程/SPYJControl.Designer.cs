﻿namespace Ebada.Scgl.Lcgl
{
    partial class SPYJControl
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
            this.components = new System.ComponentModel.Container();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.preMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.nowMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.同意ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.不同意ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.preMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nowMemoEdit.Properties)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(275, 204);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.splitContainerControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(268, 174);
            this.xtraTabPage1.Text = "会签意见";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.preMemoEdit);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.nowMemoEdit);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(268, 174);
            this.splitContainerControl1.SplitterPosition = 52;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // preMemoEdit
            // 
            this.preMemoEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preMemoEdit.Location = new System.Drawing.Point(0, 0);
            this.preMemoEdit.Name = "preMemoEdit";
            this.preMemoEdit.Size = new System.Drawing.Size(268, 116);
            this.preMemoEdit.TabIndex = 0;
            // 
            // nowMemoEdit
            // 
            this.nowMemoEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nowMemoEdit.Location = new System.Drawing.Point(0, 0);
            this.nowMemoEdit.Name = "nowMemoEdit";
            this.nowMemoEdit.Properties.ContextMenuStrip = this.contextMenuStrip1;
            this.nowMemoEdit.Size = new System.Drawing.Size(268, 52);
            this.nowMemoEdit.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.同意ToolStripMenuItem,
            this.不同意ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // 同意ToolStripMenuItem
            // 
            this.同意ToolStripMenuItem.Name = "同意ToolStripMenuItem";
            this.同意ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.同意ToolStripMenuItem.Text = "同意";
            // 
            // 不同意ToolStripMenuItem
            // 
            this.不同意ToolStripMenuItem.Name = "不同意ToolStripMenuItem";
            this.不同意ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.不同意ToolStripMenuItem.Text = "不同意";
            // 
            // SPYJControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "SPYJControl";
            this.Size = new System.Drawing.Size(275, 204);
            this.Load += new System.EventHandler(this.SPYJControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.preMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nowMemoEdit.Properties)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        public DevExpress.XtraEditors.MemoEdit nowMemoEdit;
        public DevExpress.XtraEditors.MemoEdit preMemoEdit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 同意ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 不同意ToolStripMenuItem;
    }
}
