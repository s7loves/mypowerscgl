namespace Ebada.SCGL.WFlow.Tool
{
    partial class fmWorkFlowClass
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
            this.grpBase = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxPath = new System.Windows.Forms.TextBox();
            this.btnBussWebPage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxCllevel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxClassCaption = new System.Windows.Forms.TextBox();
            this.tbxFatherClassCaption = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.grpBase.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.groupBox1);
            this.plclassFill.Controls.Add(this.grpBase);
            this.plclassFill.Size = new System.Drawing.Size(426, 285);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 219);
            // 
            // btnSave
            // 
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpBase
            // 
            this.grpBase.Controls.Add(this.label5);
            this.grpBase.Controls.Add(this.tbxPath);
            this.grpBase.Controls.Add(this.btnBussWebPage);
            this.grpBase.Controls.Add(this.label2);
            this.grpBase.Controls.Add(this.tbxCllevel);
            this.grpBase.Controls.Add(this.label3);
            this.grpBase.Controls.Add(this.tbxClassCaption);
            this.grpBase.Controls.Add(this.tbxFatherClassCaption);
            this.grpBase.Controls.Add(this.label4);
            this.grpBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBase.Location = new System.Drawing.Point(0, 0);
            this.grpBase.Name = "grpBase";
            this.grpBase.Size = new System.Drawing.Size(426, 133);
            this.grpBase.TabIndex = 15;
            this.grpBase.TabStop = false;
            this.grpBase.Text = "基本信息";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 125;
            this.label5.Text = "选择模块:";
            // 
            // tbxPath
            // 
            this.tbxPath.Location = new System.Drawing.Point(78, 99);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.Size = new System.Drawing.Size(242, 21);
            this.tbxPath.TabIndex = 124;
            // 
            // btnBussWebPage
            // 
            this.btnBussWebPage.Location = new System.Drawing.Point(326, 99);
            this.btnBussWebPage.Name = "btnBussWebPage";
            this.btnBussWebPage.Size = new System.Drawing.Size(41, 23);
            this.btnBussWebPage.TabIndex = 123;
            this.btnBussWebPage.Click += new System.EventHandler(this.btnBussWebPage_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "分类级别:";
            // 
            // tbxCllevel
            // 
            this.tbxCllevel.Location = new System.Drawing.Point(78, 72);
            this.tbxCllevel.Name = "tbxCllevel";
            this.tbxCllevel.ReadOnly = true;
            this.tbxCllevel.Size = new System.Drawing.Size(50, 21);
            this.tbxCllevel.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "上级分类:";
            // 
            // tbxClassCaption
            // 
            this.tbxClassCaption.Location = new System.Drawing.Point(77, 45);
            this.tbxClassCaption.Name = "tbxClassCaption";
            this.tbxClassCaption.Size = new System.Drawing.Size(289, 21);
            this.tbxClassCaption.TabIndex = 5;
            // 
            // tbxFatherClassCaption
            // 
            this.tbxFatherClassCaption.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tbxFatherClassCaption.Location = new System.Drawing.Point(78, 15);
            this.tbxFatherClassCaption.Name = "tbxFatherClassCaption";
            this.tbxFatherClassCaption.ReadOnly = true;
            this.tbxFatherClassCaption.Size = new System.Drawing.Size(289, 21);
            this.tbxFatherClassCaption.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "本级分类:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxDescription);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 104);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(36, 34);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(343, 64);
            this.tbxDescription.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "分类描述:";
            // 
            // fmWorkFlowClass
            // 
            this.ClientSize = new System.Drawing.Size(426, 285);
            this.Name = "fmWorkFlowClass";
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.grpBase.ResumeLayout(false);
            this.grpBase.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxClassCaption;
        private System.Windows.Forms.TextBox tbxFatherClassCaption;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxCllevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxPath;
        private System.Windows.Forms.Button btnBussWebPage;
    }
}
