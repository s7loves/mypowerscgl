namespace Ebada.SCGL.WFlow.Tool
{
    partial class fmSelectArch
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmSelectArch));
            this.tvArch = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.label1);
            this.plclassFill.Controls.Add(this.tvArch);
            this.plclassFill.Size = new System.Drawing.Size(368, 414);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 348);
            this.plclassBottom.Size = new System.Drawing.Size(368, 66);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(161, 16);
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(260, 16);
            this.btnClose.Text = "取消(&C)";
            // 
            // tvArch
            // 
            this.tvArch.ImageIndex = 0;
            this.tvArch.ImageList = this.imgListSmall;
            this.tvArch.Location = new System.Drawing.Point(23, 33);
            this.tvArch.Name = "tvArch";
            this.tvArch.SelectedImageIndex = 0;
            this.tvArch.Size = new System.Drawing.Size(321, 309);
            this.tvArch.StateImageList = this.imgListSmall;
            this.tvArch.TabIndex = 0;
            this.tvArch.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvArch_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "请选择部门：";
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall.Images.SetKeyName(0, "12.bmp");
            this.imgListSmall.Images.SetKeyName(1, "duty.bmp");
            // 
            // fmSelectArch
            // 
            this.ClientSize = new System.Drawing.Size(368, 414);
            this.Name = "fmSelectArch";
            this.Text = "选择部门";
            this.Load += new System.EventHandler(this.SelectDutyFm_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassFill.PerformLayout();
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TreeView tvArch;
        private System.Windows.Forms.ImageList imgListSmall;
    }
}
