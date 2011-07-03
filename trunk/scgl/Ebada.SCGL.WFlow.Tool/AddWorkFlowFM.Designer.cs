namespace Ebada.SCGL.WFlow.Tool
{
    partial class fmAddWorkFlow
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
            this.tbxClassCaption = new System.Windows.Forms.TextBox();
            this.tbxWorkflowCaption = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpBase = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPath = new System.Windows.Forms.TextBox();
            this.btnBussWebPage = new System.Windows.Forms.Button();
            this.cbxStatus = new System.Windows.Forms.CheckBox();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.grpBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.label1);
            this.plclassFill.Controls.Add(this.tbxDescription);
            this.plclassFill.Controls.Add(this.grpBase);
            this.plclassFill.Size = new System.Drawing.Size(426, 287);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 240);
            this.plclassBottom.Size = new System.Drawing.Size(426, 47);
            // 
            // btnSave
            // 
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbxClassCaption
            // 
            this.tbxClassCaption.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tbxClassCaption.Location = new System.Drawing.Point(84, 19);
            this.tbxClassCaption.Name = "tbxClassCaption";
            this.tbxClassCaption.ReadOnly = true;
            this.tbxClassCaption.Size = new System.Drawing.Size(289, 21);
            this.tbxClassCaption.TabIndex = 2;
            // 
            // tbxWorkflowCaption
            // 
            this.tbxWorkflowCaption.Location = new System.Drawing.Point(84, 50);
            this.tbxWorkflowCaption.Name = "tbxWorkflowCaption";
            this.tbxWorkflowCaption.Size = new System.Drawing.Size(289, 21);
            this.tbxWorkflowCaption.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "流程分类:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "流程名称:";
            // 
            // grpBase
            // 
            this.grpBase.Controls.Add(this.label2);
            this.grpBase.Controls.Add(this.tbxPath);
            this.grpBase.Controls.Add(this.btnBussWebPage);
            this.grpBase.Controls.Add(this.cbxStatus);
            this.grpBase.Controls.Add(this.label3);
            this.grpBase.Controls.Add(this.tbxWorkflowCaption);
            this.grpBase.Controls.Add(this.tbxClassCaption);
            this.grpBase.Controls.Add(this.label4);
            this.grpBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBase.Location = new System.Drawing.Point(0, 0);
            this.grpBase.Name = "grpBase";
            this.grpBase.Size = new System.Drawing.Size(426, 133);
            this.grpBase.TabIndex = 14;
            this.grpBase.TabStop = false;
            this.grpBase.Text = "基本信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 122;
            this.label2.Text = "选择模块:";
            // 
            // tbxPath
            // 
            this.tbxPath.Location = new System.Drawing.Point(84, 82);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.Size = new System.Drawing.Size(242, 21);
            this.tbxPath.TabIndex = 121;
            // 
            // btnBussWebPage
            // 
            this.btnBussWebPage.Location = new System.Drawing.Point(332, 82);
            this.btnBussWebPage.Name = "btnBussWebPage";
            this.btnBussWebPage.Size = new System.Drawing.Size(41, 23);
            this.btnBussWebPage.TabIndex = 120;
            this.btnBussWebPage.Click += new System.EventHandler(this.btnBussWebPage_Click);
            // 
            // cbxStatus
            // 
            this.cbxStatus.AutoSize = true;
            this.cbxStatus.Location = new System.Drawing.Point(23, 111);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(48, 16);
            this.cbxStatus.TabIndex = 7;
            this.cbxStatus.Text = "启用";
            this.cbxStatus.UseVisualStyleBackColor = true;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(23, 160);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(343, 64);
            this.tbxDescription.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "流程描述:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fmAddWorkFlow
            // 
            this.ClientSize = new System.Drawing.Size(426, 287);
            this.Name = "fmAddWorkFlow";
            this.plclassFill.ResumeLayout(false);
            this.plclassFill.PerformLayout();
            this.plclassBottom.ResumeLayout(false);
            this.grpBase.ResumeLayout(false);
            this.grpBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxClassCaption;
        private System.Windows.Forms.TextBox tbxWorkflowCaption;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.CheckBox cbxStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxPath;
        private System.Windows.Forms.Button btnBussWebPage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
