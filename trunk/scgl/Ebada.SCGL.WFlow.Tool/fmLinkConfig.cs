using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ebada.SCGL.WFlow.Tool
{
    public class fmLinkConfig : System.Windows.Forms.Form
    {

        private Link NowLink;
        public fmLinkConfig(Link link, string userId, string userName)
        {
            InitializeComponent();
            NowLink = link;
        }

        private Label label2;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxDes = new System.Windows.Forms.TextBox();
            this.tbxCondition = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVarChoose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbOperator = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxCommandName = new System.Windows.Forms.ComboBox();
            this.ndPriority = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxDes);
            this.groupBox2.Location = new System.Drawing.Point(20, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 87);
            this.groupBox2.TabIndex = 8;
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
            // tbxCondition
            // 
            this.tbxCondition.Location = new System.Drawing.Point(6, 114);
            this.tbxCondition.Multiline = true;
            this.tbxCondition.Name = "tbxCondition";
            this.tbxCondition.Size = new System.Drawing.Size(323, 72);
            this.tbxCondition.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxCondition);
            this.groupBox1.Controls.Add(this.btnVarChoose);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbOperator);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(25, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 192);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "表达式配置";
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
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(347, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "表达式(语句规则按SQL语句规则变量附加条件按(\'0\'=\'0\' and 条";
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
            this.groupBox3.Location = new System.Drawing.Point(26, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(352, 44);
            this.groupBox3.TabIndex = 9;
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
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(203, 353);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "确定(&O)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(285, 353);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "取消(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "件) 0表示 表达式里第一个变量，以此类推";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fmLinkConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 388);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "fmLinkConfig";
            this.Text = "连线配置";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ndPriority)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbxDes;
        private System.Windows.Forms.TextBox tbxCondition;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnVarChoose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbOperator;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbxCommandName;
        private System.Windows.Forms.NumericUpDown ndPriority;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private void loadCombobox(ComboBox cbx, DataTable dt, string fieldName)
        {
            cbx.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                cbx.Items.Add(dr[fieldName].ToString());


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NowLink.Condition = tbxCondition.Text;
            NowLink.Priority = Convert.ToInt16(ndPriority.Value);
            if(cbxCommandName.SelectedItem!=null)
            NowLink.CommandName = cbxCommandName.SelectedItem.ToString();
            NowLink.Des = tbxDes.Text;
            NowLink.SaveUpdateLink();
            Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable dt = WorkFlowTask.GetTaskCommands(NowLink.flowGuid, NowLink.startTask.TaskId);
            loadCombobox(cbxCommandName, dt, "CommandName");
            tbxCondition.Text = NowLink.Condition;
            ndPriority.Value = NowLink.Priority;
            cbxCommandName.Text = NowLink.CommandName;
            tbxDes.Text = NowLink.Des;
        }

        private void btnVarChoose_Click(object sender, EventArgs e)
        {
            fmSelectVar tmpSelectVar = new fmSelectVar(NowLink.flowGuid, NowLink.startTask.TaskId);
            tmpSelectVar.ShowDialog();
            DialogResult dlr = tmpSelectVar.DialogResult;
            if (dlr == DialogResult.OK && tmpSelectVar.lvVar.SelectedItems.Count > 0)
            {
                tbxCondition.Text = tbxCondition.Text + "<%" + tmpSelectVar.lvVar.SelectedItems[0].Text + "%>";
            }
        }
    }
}
