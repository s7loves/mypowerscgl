namespace Ebada.SCGL.WFlow.Tool
{
    partial class fmSelectTaskOperUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmSelectTaskOperUser));
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.lvTask = new System.Windows.Forms.ListView();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.lvTask);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Text = "取消(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall.Images.SetKeyName(0, "交互节点.ico");
            // 
            // lvTask
            // 
            this.lvTask.FullRowSelect = true;
            this.lvTask.Location = new System.Drawing.Point(20, 25);
            this.lvTask.MultiSelect = false;
            this.lvTask.Name = "lvTask";
            this.lvTask.Size = new System.Drawing.Size(387, 368);
            this.lvTask.SmallImageList = this.imgListSmall;
            this.lvTask.TabIndex = 11;
            this.lvTask.UseCompatibleStateImageBehavior = false;
            this.lvTask.View = System.Windows.Forms.View.Details;
            // 
            // fmSelectTaskOperUser
            // 
            this.ClientSize = new System.Drawing.Size(426, 466);
            this.Name = "fmSelectTaskOperUser";
            this.Text = "选择任务";
            this.Load += new System.EventHandler(this.fmSelectTaskOperUser_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView lvTask;
        private System.Windows.Forms.ImageList imgListSmall;
    }
}
