namespace Ebada.SCGL.WFlow.Tool
{
    partial class fmSelectWorkflow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmSelectWorkflow));
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxWorkflowCaption = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvWorkflow = new System.Windows.Forms.ListView();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.btnSearch);
            this.plclassFill.Controls.Add(this.tbxWorkflowCaption);
            this.plclassFill.Controls.Add(this.label1);
            this.plclassFill.Controls.Add(this.lvWorkflow);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxWorkflowCaption
            // 
            resources.ApplyResources(this.tbxWorkflowCaption, "tbxWorkflowCaption");
            this.tbxWorkflowCaption.Name = "tbxWorkflowCaption";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lvWorkflow
            // 
            this.lvWorkflow.FullRowSelect = true;
            resources.ApplyResources(this.lvWorkflow, "lvWorkflow");
            this.lvWorkflow.MultiSelect = false;
            this.lvWorkflow.Name = "lvWorkflow";
            this.lvWorkflow.UseCompatibleStateImageBehavior = false;
            this.lvWorkflow.View = System.Windows.Forms.View.Details;
            // 
            // fmSelectWorkflow
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "fmSelectWorkflow";
            this.Load += new System.EventHandler(this.fmSelectWorkflow_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassFill.PerformLayout();
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxWorkflowCaption;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListView lvWorkflow;
    }
}
