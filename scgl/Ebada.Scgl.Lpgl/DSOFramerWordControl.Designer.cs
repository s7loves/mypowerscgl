namespace TONLI.dsoframers {
    partial class DSOFramerWordControl {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSOFramerWordControl));
            this.axFramerControl1 = new AxDSOFramer.AxFramerControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.axFramerControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axFramerControl1
            // 
            this.axFramerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axFramerControl1.Enabled = true;
            this.axFramerControl1.Location = new System.Drawing.Point(0, 0);
            this.axFramerControl1.Name = "axFramerControl1";
            this.axFramerControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFramerControl1.OcxState")));
            this.axFramerControl1.Size = new System.Drawing.Size(288, 209);
            this.axFramerControl1.TabIndex = 0;
            this.axFramerControl1.BeforeDocumentClosed += new AxDSOFramer._DFramerCtlEvents_BeforeDocumentClosedEventHandler(this.axFramerControl1_BeforeDocumentClosed);
            this.axFramerControl1.OnDocumentOpened += new AxDSOFramer._DFramerCtlEvents_OnDocumentOpenedEventHandler(this.axFramerControl1_OnDocumentOpened);
            this.axFramerControl1.OnDocumentClosed += new System.EventHandler(this.axFramerControl1_OnDocumentClosed);
            this.axFramerControl1.OnFileCommand += new AxDSOFramer._DFramerCtlEvents_OnFileCommandEventHandler(this.axFramerControl1_OnFileCommand);
            this.axFramerControl1.BeforeDocumentSaved += new AxDSOFramer._DFramerCtlEvents_BeforeDocumentSavedEventHandler(this.axFramerControl1_BeforeDocumentSaved);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DSOFramerWordControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axFramerControl1);
            this.Name = "DSOFramerWordControl";
            this.Size = new System.Drawing.Size(288, 209);
            ((System.ComponentModel.ISupportInitialize)(this.axFramerControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxDSOFramer.AxFramerControl axFramerControl1;
        private System.Windows.Forms.Timer timer1;

    }
}
