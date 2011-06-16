namespace Ebada.SCGL.WFlow.Tool
{
    partial class fmSelectVar
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
            this.lvVar = new System.Windows.Forms.ListView();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.lvVar);
            this.plclassFill.Size = new System.Drawing.Size(426, 416);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 350);
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
            // lvVar
            // 
            this.lvVar.FullRowSelect = true;
            this.lvVar.Location = new System.Drawing.Point(12, 12);
            this.lvVar.MultiSelect = false;
            this.lvVar.Name = "lvVar";
            this.lvVar.Size = new System.Drawing.Size(402, 331);
            this.lvVar.TabIndex = 10;
            this.lvVar.UseCompatibleStateImageBehavior = false;
            this.lvVar.View = System.Windows.Forms.View.Details;
            // 
            // fmSelectVar
            // 
            this.ClientSize = new System.Drawing.Size(426, 416);
            this.Name = "fmSelectVar";
            this.Text = "选择变量";
            this.Load += new System.EventHandler(this.SelectVar_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView lvVar;
    }
}
