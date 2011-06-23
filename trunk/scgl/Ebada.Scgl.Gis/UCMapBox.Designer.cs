namespace Ebada.Scgl.Gis {
    partial class UCMapBox {
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.documentControl1 = new TLVector.TLVectorControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.城市ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.卫星照片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // documentControl1
            // 
            this.documentControl1.CanEdit = false;
            this.documentControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.documentControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentControl1.FullDrawMode = true;
            this.documentControl1.IsPasteGrid = false;
            this.documentControl1.IsShowGrid = true;
            this.documentControl1.IsShowRule = true;
            this.documentControl1.IsShowTip = false;
            this.documentControl1.Location = new System.Drawing.Point(0, 0);
            this.documentControl1.Name = "documentControl1";
            this.documentControl1.Size = new System.Drawing.Size(394, 293);
            this.documentControl1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.城市ToolStripMenuItem,
            this.卫星照片ToolStripMenuItem,
            this.地形ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 70);
            // 
            // 城市ToolStripMenuItem
            // 
            this.城市ToolStripMenuItem.Name = "城市ToolStripMenuItem";
            this.城市ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.城市ToolStripMenuItem.Text = "城市";
            this.城市ToolStripMenuItem.Click += new System.EventHandler(this.地图ToolStripMenuItem_Click);
            // 
            // 卫星照片ToolStripMenuItem
            // 
            this.卫星照片ToolStripMenuItem.Name = "卫星照片ToolStripMenuItem";
            this.卫星照片ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.卫星照片ToolStripMenuItem.Text = "卫星";
            this.卫星照片ToolStripMenuItem.Click += new System.EventHandler(this.卫星ToolStripMenuItem_Click);
            // 
            // 地形ToolStripMenuItem
            // 
            this.地形ToolStripMenuItem.Name = "地形ToolStripMenuItem";
            this.地形ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.地形ToolStripMenuItem.Text = "地形";
            this.地形ToolStripMenuItem.Click += new System.EventHandler(this.地形ToolStripMenuItem_Click);
            // 
            // UCMapBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.documentControl1);
            this.Name = "UCMapBox";
            this.Size = new System.Drawing.Size(394, 293);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TLVector.TLVectorControl documentControl1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 城市ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 卫星照片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地形ToolStripMenuItem;
    }
}
