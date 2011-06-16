
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Ebada.SCGL.WorkFlow.Tool
{
	/// <summary>
	/// LinkConfig 的摘要说明。
	/// </summary>
    public class fmLinkConfig : BaseForm_Single
    {
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Button btnVarChoose;
        private Label label5;
        private ComboBox cbOperator;
        private Label label4;
        private GroupBox groupBox3;
        private Label label1;
        private NumericUpDown ndPriority;
        private TextBox tbxDes;
        private TextBox tbxCondition;
        private ComboBox cbxCommandName;

		private Link NowLink;


        public fmLinkConfig(Link link, string userId, string userName)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			NowLink=link;
            

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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxDes = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxCondition = new System.Windows.Forms.TextBox();
            this.btnVarChoose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbOperator = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxCommandName = new System.Windows.Forms.ComboBox();
            this.ndPriority = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.groupBox3);
            this.plclassFill.Controls.Add(this.groupBox2);
            this.plclassFill.Controls.Add(this.groupBox1);
            this.plclassFill.Size = new System.Drawing.Size(384, 378);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 320);
            this.plclassBottom.Size = new System.Drawing.Size(384, 58);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(154, 16);
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(265, 16);
            this.btnClose.Text = "取消(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxDes);
            this.groupBox2.Location = new System.Drawing.Point(11, 215);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 87);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "备注说明";
            // 
            // tbxDes
            // 
            this.tbxDes.Location = new System.Drawing.Point(20, 21);
            this.tbxDes.Multiline = true;
            this.tbxDes.Name = "tbxDes";
            this.tbxDes.Size = new System.Drawing.Size(323, 60);
            this.tbxDes.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxCondition);
            this.groupBox1.Controls.Add(this.btnVarChoose);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbOperator);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(19, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 150);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "表达式配置";
            // 
            // tbxCondition
            // 
            this.tbxCondition.Location = new System.Drawing.Point(12, 72);
            this.tbxCondition.Multiline = true;
            this.tbxCondition.Name = "tbxCondition";
            this.tbxCondition.Size = new System.Drawing.Size(323, 72);
            this.tbxCondition.TabIndex = 12;
            // 
            // btnVarChoose
            // 
            this.btnVarChoose.Location = new System.Drawing.Point(12, 20);
            this.btnVarChoose.Name = "btnVarChoose";
            this.btnVarChoose.Size = new System.Drawing.Size(75, 23);
            this.btnVarChoose.TabIndex = 11;
            this.btnVarChoose.Text = "变量选择";
            this.btnVarChoose.Click += new System.EventHandler(this.btnVarChoose_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "表达式";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbOperator
            // 
            this.cbOperator.Items.AddRange(new object[] {
            "<",
            ">",
            "=",
            ">=",
            "<=",
            "!=",
            "(",
            ")",
            "And",
            "Or",
            ""});
            this.cbOperator.Location = new System.Drawing.Point(168, 22);
            this.cbOperator.Name = "cbOperator";
            this.cbOperator.Size = new System.Drawing.Size(71, 20);
            this.cbOperator.TabIndex = 6;
            this.cbOperator.SelectedIndexChanged += new System.EventHandler(this.cbOperator_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(106, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "运算符";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxCommandName);
            this.groupBox3.Controls.Add(this.ndPriority);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(20, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(352, 44);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "命令优先级";
            // 
            // cbxCommandName
            // 
            this.cbxCommandName.FormattingEnabled = true;
            this.cbxCommandName.Location = new System.Drawing.Point(11, 17);
            this.cbxCommandName.Name = "cbxCommandName";
            this.cbxCommandName.Size = new System.Drawing.Size(93, 20);
            this.cbxCommandName.TabIndex = 8;
            this.cbxCommandName.SelectedIndexChanged += new System.EventHandler(this.cbxCommandName_SelectedIndexChanged);
            // 
            // ndPriority
            // 
            this.ndPriority.Location = new System.Drawing.Point(110, 16);
            this.ndPriority.Name = "ndPriority";
            this.ndPriority.Size = new System.Drawing.Size(44, 21);
            this.ndPriority.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(160, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "(优先级由高到低0,1,2,3)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fmLinkConfig
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(384, 378);
            this.Name = "fmLinkConfig";
            this.Text = "连线配置";
            this.Load += new System.EventHandler(this.LinkConfig_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ndPriority)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private void loadCombobox(ComboBox cbx, DataTable dt,string fieldName)
        {
            cbx.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                cbx.Items.Add(dr[fieldName].ToString());
                
 
            }
        }

		private void LinkConfig_Load(object sender, System.EventArgs e)
		{

            DataTable dt = WorkFlowTask.GetTaskCommands(NowLink.flowGuid, NowLink.startTask.TaskId);
            loadCombobox(cbxCommandName, dt, "CommandName");
            tbxCondition.Text = NowLink.Condition;
            ndPriority.Value = NowLink.Priority;
            cbxCommandName.Text = NowLink.CommandName;
            tbxDes.Text = NowLink.Des;

		}

        private void btnSave_Click(object sender, EventArgs e)
        {
            NowLink.Condition = tbxCondition.Text;
            NowLink.Priority =Convert.ToInt16(ndPriority.Value);
            NowLink.CommandName = cbxCommandName.SelectedItem.ToString();
            NowLink.Des = tbxDes.Text;
            NowLink.SaveUpdateLink();
            Close();


        }

       
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbxCommandName_SelectedIndexChanged(object sender, EventArgs e)
        {
 
             tbxDes.Text = cbxCommandName.SelectedItem.ToString();

        }

        private void btnVarChoose_Click(object sender, EventArgs e)
        {
            fmSelectVar tmpSelectVar = new fmSelectVar(NowLink.flowGuid,NowLink.startTask.TaskId);
            tmpSelectVar.ShowDialog();
            DialogResult dlr = tmpSelectVar.DialogResult;
            if (dlr == DialogResult.OK && tmpSelectVar.lvVar.SelectedItems.Count > 0)
            {
                tbxCondition.Text =tbxCondition.Text+"<%"+tmpSelectVar.lvVar.SelectedItems[0].Text+"%>";
            }
        }

        private void cbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxCondition.Text = tbxCondition.Text + cbOperator.SelectedItem.ToString();
        }
	}
}
