using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace Ebada.SCGL.WFlow.Tool
{
	/// <summary>
	/// TaskJudgeFm 的摘要说明。
	/// </summary>
	public class fmTaskJudge : BaseForm_Single
    {
		public string UserId="";//操作人账号，用作权限判断。
		public string UserName="";//操作人姓名，用作显示。
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
        private System.ComponentModel.Container components = null;
        private GroupBox groupBox1;
        private RadioButton rbtOr;
        private RadioButton rbtAnd;
        private Label label1;
        private TextBox tbxTaskName;
		public JudgeTask NowTask;

		public fmTaskJudge(JudgeTask jTask,string userId,string userName)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            NowTask=jTask;
			this.UserId=userId;
			this.UserName=userName;
            tbxTaskName.Text = NowTask.TaskName;
            if (NowTask.TaskTypeAndOr == WorkConst.Command_And)
                rbtAnd.Checked=true;
            else
                if (NowTask.TaskTypeAndOr == WorkConst.Command_Or)
                    rbtOr.Checked=true;
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtOr = new System.Windows.Forms.RadioButton();
            this.rbtAnd = new System.Windows.Forms.RadioButton();
            this.tbxTaskName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.label1);
            this.plclassFill.Controls.Add(this.tbxTaskName);
            this.plclassFill.Controls.Add(this.groupBox1);
            this.plclassFill.Size = new System.Drawing.Size(382, 215);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 149);
            this.plclassBottom.Size = new System.Drawing.Size(382, 66);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(146, 16);
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(235, 16);
            this.btnClose.Text = "取消(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtOr);
            this.groupBox1.Controls.Add(this.rbtAnd);
            this.groupBox1.Location = new System.Drawing.Point(12, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "判断类型";
            // 
            // rbtOr
            // 
            this.rbtOr.AutoSize = true;
            this.rbtOr.Location = new System.Drawing.Point(149, 20);
            this.rbtOr.Name = "rbtOr";
            this.rbtOr.Size = new System.Drawing.Size(59, 16);
            this.rbtOr.TabIndex = 1;
            this.rbtOr.TabStop = true;
            this.rbtOr.Text = "或(or)";
            this.rbtOr.UseVisualStyleBackColor = true;
            // 
            // rbtAnd
            // 
            this.rbtAnd.AutoSize = true;
            this.rbtAnd.Location = new System.Drawing.Point(28, 21);
            this.rbtAnd.Name = "rbtAnd";
            this.rbtAnd.Size = new System.Drawing.Size(65, 16);
            this.rbtAnd.TabIndex = 0;
            this.rbtAnd.TabStop = true;
            this.rbtAnd.Text = "与(and)";
            this.rbtAnd.UseVisualStyleBackColor = true;
            // 
            // tbxTaskName
            // 
            this.tbxTaskName.Location = new System.Drawing.Point(63, 24);
            this.tbxTaskName.Name = "tbxTaskName";
            this.tbxTaskName.Size = new System.Drawing.Size(272, 21);
            this.tbxTaskName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "名称:";
            // 
            // fmTaskJudge
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(382, 215);
            this.Name = "fmTaskJudge";
            this.Text = "控制节点配置";
            this.plclassFill.ResumeLayout(false);
            this.plclassFill.PerformLayout();
            this.plclassBottom.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (rbtAnd.Checked)
                NowTask.TaskTypeAndOr = WorkConst.Command_And;
            else
                if (rbtOr.Checked)
            NowTask.TaskTypeAndOr = WorkConst.Command_Or;
            NowTask.TaskName = tbxTaskName.Text;
            NowTask.SaveUpdateTask();
            Close();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
	}
}
