namespace Ebada.SCGL.WFlow.Tool
{
    partial class fmAddWorkFlow
    {
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���

        /// <summary>
        /// �����֧������ķ��� - ��Ҫ
        /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxClassCaption = new System.Windows.Forms.TextBox();
            this.tbxWorkflowCaption = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpBase = new System.Windows.Forms.GroupBox();
            this.checkHuiQianYiJian = new System.Windows.Forms.CheckBox();
            this.cbxExplore = new System.Windows.Forms.CheckBox();
            this.cbxFuJian = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPath = new System.Windows.Forms.TextBox();
            this.btnBussWebPage = new System.Windows.Forms.Button();
            this.checkFollow = new System.Windows.Forms.CheckBox();
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
            this.plclassFill.Controls.Add(this.btnBussWebPage);
            this.plclassFill.Controls.Add(this.label2);
            this.plclassFill.Controls.Add(this.tbxPath);
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
            this.tbxClassCaption.Location = new System.Drawing.Point(79, 33);
            this.tbxClassCaption.Name = "tbxClassCaption";
            this.tbxClassCaption.ReadOnly = true;
            this.tbxClassCaption.Size = new System.Drawing.Size(289, 21);
            this.tbxClassCaption.TabIndex = 2;
            // 
            // tbxWorkflowCaption
            // 
            this.tbxWorkflowCaption.Location = new System.Drawing.Point(77, 69);
            this.tbxWorkflowCaption.Name = "tbxWorkflowCaption";
            this.tbxWorkflowCaption.Size = new System.Drawing.Size(289, 21);
            this.tbxWorkflowCaption.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "���̷���:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "��������:";
            // 
            // grpBase
            // 
            this.grpBase.Controls.Add(this.checkHuiQianYiJian);
            this.grpBase.Controls.Add(this.cbxExplore);
            this.grpBase.Controls.Add(this.cbxFuJian);
            this.grpBase.Controls.Add(this.checkFollow);
            this.grpBase.Controls.Add(this.cbxStatus);
            this.grpBase.Controls.Add(this.label3);
            this.grpBase.Controls.Add(this.tbxWorkflowCaption);
            this.grpBase.Controls.Add(this.tbxClassCaption);
            this.grpBase.Controls.Add(this.label4);
            this.grpBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBase.Location = new System.Drawing.Point(0, 0);
            this.grpBase.Name = "grpBase";
            this.grpBase.Size = new System.Drawing.Size(426, 146);
            this.grpBase.TabIndex = 14;
            this.grpBase.TabStop = false;
            this.grpBase.Text = "������Ϣ";
            // 
            // checkHuiQianYiJian
            // 
            this.checkHuiQianYiJian.AutoSize = true;
            this.checkHuiQianYiJian.Location = new System.Drawing.Point(82, 105);
            this.checkHuiQianYiJian.Name = "checkHuiQianYiJian";
            this.checkHuiQianYiJian.Size = new System.Drawing.Size(96, 16);
            this.checkHuiQianYiJian.TabIndex = 129;
            this.checkHuiQianYiJian.Text = "��ӻ�ǩ���";
            this.checkHuiQianYiJian.UseVisualStyleBackColor = true;
            // 
            // cbxExplore
            // 
            this.cbxExplore.AutoSize = true;
            this.cbxExplore.Location = new System.Drawing.Point(277, 103);
            this.cbxExplore.Name = "cbxExplore";
            this.cbxExplore.Size = new System.Drawing.Size(132, 16);
            this.cbxExplore.TabIndex = 128;
            this.cbxExplore.Text = "���̽�����������";
            this.cbxExplore.UseVisualStyleBackColor = true;
            // 
            // cbxFuJian
            // 
            this.cbxFuJian.AutoSize = true;
            this.cbxFuJian.Location = new System.Drawing.Point(179, 104);
            this.cbxFuJian.Name = "cbxFuJian";
            this.cbxFuJian.Size = new System.Drawing.Size(96, 16);
            this.cbxFuJian.TabIndex = 128;
            this.cbxFuJian.Text = "������Ӹ���";
            this.cbxFuJian.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 122;
            this.label2.Text = "ѡ��ģ��:";
            this.label2.Visible = false;
            // 
            // tbxPath
            // 
            this.tbxPath.Location = new System.Drawing.Point(195, 144);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.Size = new System.Drawing.Size(242, 21);
            this.tbxPath.TabIndex = 121;
            this.tbxPath.Visible = false;
            // 
            // btnBussWebPage
            // 
            this.btnBussWebPage.Location = new System.Drawing.Point(368, 144);
            this.btnBussWebPage.Name = "btnBussWebPage";
            this.btnBussWebPage.Size = new System.Drawing.Size(41, 23);
            this.btnBussWebPage.TabIndex = 120;
            this.btnBussWebPage.Visible = false;
            this.btnBussWebPage.Click += new System.EventHandler(this.btnBussWebPage_Click);
            // 
            // checkFollow
            // 
            this.checkFollow.AutoSize = true;
            this.checkFollow.Location = new System.Drawing.Point(23, 130);
            this.checkFollow.Name = "checkFollow";
            this.checkFollow.Size = new System.Drawing.Size(72, 16);
            this.checkFollow.TabIndex = 7;
            this.checkFollow.Text = "ȫ�̸���";
            this.checkFollow.UseVisualStyleBackColor = true;
            // 
            // cbxStatus
            // 
            this.cbxStatus.AutoSize = true;
            this.cbxStatus.Location = new System.Drawing.Point(23, 105);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(48, 16);
            this.cbxStatus.TabIndex = 7;
            this.cbxStatus.Text = "����";
            this.cbxStatus.UseVisualStyleBackColor = true;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(23, 171);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(343, 64);
            this.tbxDescription.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "��������:";
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
        private System.Windows.Forms.CheckBox checkHuiQianYiJian;
        private System.Windows.Forms.CheckBox cbxFuJian;
        private System.Windows.Forms.CheckBox cbxExplore;
        private System.Windows.Forms.CheckBox checkFollow;
    }
}
