﻿namespace Ebada.Scgl.Core {
    partial class frmOfficeEdit {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.dsoFramerControl1 = new Ebada.Scgl.Core.DSOFramerControl();
            this.SuspendLayout();
            // 
            // dsoFramerControl1
            // 
            this.dsoFramerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dsoFramerControl1.Location = new System.Drawing.Point(0, 0);
            this.dsoFramerControl1.Name = "dsoFramerControl1";
            this.dsoFramerControl1.Size = new System.Drawing.Size(485, 307);
            this.dsoFramerControl1.TabIndex = 0;
            // 
            // frmOfficeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 307);
            this.Controls.Add(this.dsoFramerControl1);
            this.Name = "frmOfficeEdit";
            this.ShowInTaskbar = false;
            this.Text = "文档编辑";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private DSOFramerControl dsoFramerControl1;
    }
}