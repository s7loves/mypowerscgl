using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Ebada.Client;

namespace Ebada.SCGL.WFlow.Tool
{
	/// <summary>
	/// TaskSubFm 的摘要说明。
	/// </summary>
	public class fmTaskSub : BaseForm_Single
    {
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
        public SubFlowTask NowTask;
        public string UserId = "";
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label4;
        private TextBox tbxTaskDes;
        private TextBox tbxWorkflowCaption;
        private Button btnSelectWf;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private ComboBox cbxStartTasks;//
        public string fmState = "";
		public string UserName="";//操作人姓名，用作显示。
        public string WorkflowId = "";
        public string SubId = "";
        public string WorkTaskId = "";
        public string SubWorkflowId = "";
        public string SubWorkflowCaption = "";
        public string SubStartTaskId = "";
        public string Description = "";
		public fmTaskSub(SubFlowTask subTask,string userId,string userName)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            
			NowTask=subTask;
			this.UserId=userId;
			this.UserName=userName;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmTaskSub));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxStartTasks = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxTaskDes = new System.Windows.Forms.TextBox();
            this.tbxWorkflowCaption = new System.Windows.Forms.TextBox();
            this.btnSelectWf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.tabControl1);
            this.plclassFill.Size = new System.Drawing.Size(451, 285);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 219);
            this.plclassBottom.Size = new System.Drawing.Size(451, 66);
            // 
            // btnSave
            // 
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Text = "取消(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(432, 211);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cbxStartTasks);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tbxTaskDes);
            this.tabPage1.Controls.Add(this.tbxWorkflowCaption);
            this.tabPage1.Controls.Add(this.btnSelectWf);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(424, 186);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "常规";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 127;
            this.label2.Text = "启动节点:";
            // 
            // cbxStartTasks
            // 
            this.cbxStartTasks.FormattingEnabled = true;
            this.cbxStartTasks.Location = new System.Drawing.Point(114, 81);
            this.cbxStartTasks.Name = "cbxStartTasks";
            this.cbxStartTasks.Size = new System.Drawing.Size(212, 20);
            this.cbxStartTasks.TabIndex = 126;
            this.cbxStartTasks.SelectedIndexChanged += new System.EventHandler(this.cbxStartTasks_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(40, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 23);
            this.label4.TabIndex = 125;
            this.label4.Text = "任务描述:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxTaskDes
            // 
            this.tbxTaskDes.Location = new System.Drawing.Point(114, 113);
            this.tbxTaskDes.Name = "tbxTaskDes";
            this.tbxTaskDes.Size = new System.Drawing.Size(259, 21);
            this.tbxTaskDes.TabIndex = 124;
            // 
            // tbxWorkflowCaption
            // 
            this.tbxWorkflowCaption.Location = new System.Drawing.Point(114, 53);
            this.tbxWorkflowCaption.Name = "tbxWorkflowCaption";
            this.tbxWorkflowCaption.Size = new System.Drawing.Size(212, 21);
            this.tbxWorkflowCaption.TabIndex = 116;
            // 
            // btnSelectWf
            // 
            this.btnSelectWf.Location = new System.Drawing.Point(332, 52);
            this.btnSelectWf.Name = "btnSelectWf";
            this.btnSelectWf.Size = new System.Drawing.Size(41, 23);
            this.btnSelectWf.TabIndex = 117;
            this.btnSelectWf.Text = "";
            this.btnSelectWf.Click += new System.EventHandler(this.btnSelectWf_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(27, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 23);
            this.label1.TabIndex = 115;
            this.label1.Text = "子流程名称:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 34);
            this.pictureBox1.TabIndex = 109;
            this.pictureBox1.TabStop = false;
            // 
            // fmTaskSub
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(451, 285);
            this.Name = "fmTaskSub";
            this.Text = "子流程节点配置";
            this.Load += new System.EventHandler(this.fmTaskSub_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private void btnSunFlow_Click(object sender, EventArgs e)
        {

        }
        private void InitData()
        {
            DataTable dt = SubWorkFlow.GetSubWorkflowTable(NowTask.WorkFlowId,NowTask.TaskId);
            if (dt != null && dt.Rows.Count > 0)
            {
                fmState = WorkConst.STATE_MOD;//修改
                SubId = dt.Rows[0]["SubId"].ToString();
                WorkflowId = dt.Rows[0]["WorkflowId"].ToString();
                WorkTaskId = dt.Rows[0]["WorkTaskId"].ToString();
                SubWorkflowId = dt.Rows[0]["subWorkflowId"].ToString();
                SubStartTaskId = dt.Rows[0]["subStartTaskId"].ToString();
                SubWorkflowCaption = dt.Rows[0]["SubWorkflowCaption"].ToString();
                Description = dt.Rows[0]["Description"].ToString();

                tbxWorkflowCaption.Text = SubWorkflowCaption;
                DataTable dt1 = WorkFlowTask.GetStartTask(SubWorkflowId);
                cbxStartTasks.DisplayMember = "TaskCaption";
                cbxStartTasks.ValueMember = "WorkTaskId";
                cbxStartTasks.DataSource = dt1;
                cbxStartTasks.SelectedValue = SubStartTaskId;
                tbxTaskDes.Text = Description;
                this.Text = "新建子流程配置";
            }
            else
            {
                fmState = WorkConst.STATE_ADD;
                SubId = Guid.NewGuid().ToString();
                WorkflowId = NowTask.WorkFlowId;
                WorkTaskId = NowTask.TaskId;
                this.Text = "修改子流程配置";
            }
        }

        private void btnSelectWf_Click(object sender, EventArgs e)
        {
            fmSelectWorkflow tmpfmSelectWf = new fmSelectWorkflow();
            tmpfmSelectWf.ShowDialog();
            DialogResult dlr = tmpfmSelectWf.DialogResult;
            if (dlr == DialogResult.OK && tmpfmSelectWf.lvWorkflow.SelectedItems.Count > 0)
            {
                tbxWorkflowCaption.Text = tmpfmSelectWf.lvWorkflow.SelectedItems[0].Text;
                SubWorkflowId = tmpfmSelectWf.lvWorkflow.SelectedItems[0].SubItems[1].Text;
                DataTable dt = WorkFlowTask.GetStartTask(SubWorkflowId);
                cbxStartTasks.DisplayMember = "TaskCaption";
                cbxStartTasks.ValueMember = "WorkTaskId";
                cbxStartTasks.DataSource = dt;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxWorkflowCaption.Text.Length < 0)
            {
                MsgBox.ShowWarningMessageBox("请选择子流程!");
                return;
            }
            if (cbxStartTasks.SelectedItem == null)
            {
                MsgBox.ShowWarningMessageBox("请选择子流程的接入节点!");
                return;
            }
            Description = tbxTaskDes.Text;
            SubWorkflowCaption = tbxWorkflowCaption.Text;
            SubStartTaskId = cbxStartTasks.SelectedValue.ToString();

            SubWorkFlow subworkflow = new SubWorkFlow();
            subworkflow.SubId = SubId;
            subworkflow.WorkflowId = WorkflowId;
            subworkflow.WorkTaskId = WorkTaskId;
            subworkflow.SubWorkflowId = SubWorkflowId;
            subworkflow.SubWorkflowCaption = SubWorkflowCaption;
            subworkflow.SubStartTaskId = SubStartTaskId;
            subworkflow.Description = Description;
            if (fmState == WorkConst.STATE_ADD)
            {
                
                subworkflow.InsertSubWorkFlow();
            }
            else
            {
                subworkflow.UpdateSubWorkFlow();
            }

            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fmTaskSub_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void cbxStartTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
	}
}
