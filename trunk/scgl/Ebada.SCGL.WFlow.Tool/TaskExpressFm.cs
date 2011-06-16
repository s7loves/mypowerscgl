using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace Ebada.SCGL.WFlow.Tool
{
	/// <summary>
	/// TaskExpressFm ��ժҪ˵����
	/// </summary>
	public class fmTaskExpress : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox LeaderLevel3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.ComboBox LeaderLevel2;
		private System.Windows.Forms.ComboBox LeaderLevel;
		private System.Windows.Forms.ComboBox LeaderLevel1;
		private System.Windows.Forms.CheckBox �ϼ��쵼;
		private System.Windows.Forms.CheckBox ѡ���û���ϵ;
		private System.Windows.Forms.RadioButton rbUpArchi;
		private System.Windows.Forms.RadioButton rbArchi;
		private System.Windows.Forms.RadioButton rbDomiArchi;
		private System.Windows.Forms.RadioButton rbPart;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.ComboBox cmbvarP;
		private System.Windows.Forms.RadioButton rbsomevarP;
		private System.Windows.Forms.ComboBox cmbsometaskP;
		private System.Windows.Forms.RadioButton rbsometaskP;
		private System.Windows.Forms.RadioButton EveryOne;
		private System.Windows.Forms.ComboBox cmbVar;
		private System.Windows.Forms.ComboBox cmbSomeTask;
		private System.Windows.Forms.RadioButton rbVar;
		private System.Windows.Forms.RadioButton rbSomeTask;
		private System.Windows.Forms.RadioButton rbFlowStartor;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public fmTaskExpress()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.LeaderLevel3 = new System.Windows.Forms.ComboBox();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.LeaderLevel2 = new System.Windows.Forms.ComboBox();
			this.LeaderLevel = new System.Windows.Forms.ComboBox();
			this.LeaderLevel1 = new System.Windows.Forms.ComboBox();
			this.�ϼ��쵼 = new System.Windows.Forms.CheckBox();
			this.ѡ���û���ϵ = new System.Windows.Forms.CheckBox();
			this.rbUpArchi = new System.Windows.Forms.RadioButton();
			this.rbArchi = new System.Windows.Forms.RadioButton();
			this.rbDomiArchi = new System.Windows.Forms.RadioButton();
			this.rbPart = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.cmbvarP = new System.Windows.Forms.ComboBox();
			this.rbsomevarP = new System.Windows.Forms.RadioButton();
			this.cmbsometaskP = new System.Windows.Forms.ComboBox();
			this.rbsometaskP = new System.Windows.Forms.RadioButton();
			this.EveryOne = new System.Windows.Forms.RadioButton();
			this.cmbVar = new System.Windows.Forms.ComboBox();
			this.cmbSomeTask = new System.Windows.Forms.ComboBox();
			this.rbVar = new System.Windows.Forms.RadioButton();
			this.rbSomeTask = new System.Windows.Forms.RadioButton();
			this.rbFlowStartor = new System.Windows.Forms.RadioButton();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(320, 432);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "ȡ��";
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(232, 432);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 6;
			this.btnOk.Text = "ȷ��";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Controls.Add(this.ѡ���û���ϵ);
			this.groupBox2.Controls.Add(this.rbUpArchi);
			this.groupBox2.Controls.Add(this.rbArchi);
			this.groupBox2.Controls.Add(this.rbDomiArchi);
			this.groupBox2.Controls.Add(this.rbPart);
			this.groupBox2.Location = new System.Drawing.Point(8, 232);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(398, 192);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.LeaderLevel3);
			this.groupBox3.Controls.Add(this.radioButton4);
			this.groupBox3.Controls.Add(this.radioButton3);
			this.groupBox3.Controls.Add(this.radioButton2);
			this.groupBox3.Controls.Add(this.radioButton1);
			this.groupBox3.Controls.Add(this.LeaderLevel2);
			this.groupBox3.Controls.Add(this.LeaderLevel);
			this.groupBox3.Controls.Add(this.LeaderLevel1);
			this.groupBox3.Controls.Add(this.�ϼ��쵼);
			this.groupBox3.Location = new System.Drawing.Point(8, 40);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(272, 144);
			this.groupBox3.TabIndex = 13;
			this.groupBox3.TabStop = false;
			// 
			// LeaderLevel3
			// 
			this.LeaderLevel3.Items.AddRange(new object[] {
															  "�ݹ�ȫ��",
															  "�ݹ�����"});
			this.LeaderLevel3.Location = new System.Drawing.Point(136, 112);
			this.LeaderLevel3.Name = "LeaderLevel3";
			this.LeaderLevel3.Size = new System.Drawing.Size(121, 20);
			this.LeaderLevel3.TabIndex = 17;
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(16, 112);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.TabIndex = 16;
			this.radioButton4.Text = "�ݹ����쵼";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(16, 88);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.TabIndex = 15;
			this.radioButton3.Text = "�������쵼";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(16, 64);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.TabIndex = 14;
			this.radioButton2.Text = "�ϼ������쵼";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(16, 40);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 13;
			this.radioButton1.Text = "�������쵼";
			// 
			// LeaderLevel2
			// 
			this.LeaderLevel2.Location = new System.Drawing.Point(136, 88);
			this.LeaderLevel2.Name = "LeaderLevel2";
			this.LeaderLevel2.Size = new System.Drawing.Size(121, 20);
			this.LeaderLevel2.TabIndex = 11;
			// 
			// LeaderLevel
			// 
			this.LeaderLevel.Location = new System.Drawing.Point(136, 40);
			this.LeaderLevel.Name = "LeaderLevel";
			this.LeaderLevel.Size = new System.Drawing.Size(121, 20);
			this.LeaderLevel.TabIndex = 7;
			// 
			// LeaderLevel1
			// 
			this.LeaderLevel1.Location = new System.Drawing.Point(136, 64);
			this.LeaderLevel1.Name = "LeaderLevel1";
			this.LeaderLevel1.Size = new System.Drawing.Size(121, 20);
			this.LeaderLevel1.TabIndex = 9;
			// 
			// �ϼ��쵼
			// 
			this.�ϼ��쵼.Location = new System.Drawing.Point(16, 8);
			this.�ϼ��쵼.Name = "�ϼ��쵼";
			this.�ϼ��쵼.TabIndex = 14;
			this.�ϼ��쵼.Text = "�ϼ��쵼";
			// 
			// ѡ���û���ϵ
			// 
			this.ѡ���û���ϵ.Location = new System.Drawing.Point(8, 16);
			this.ѡ���û���ϵ.Name = "ѡ���û���ϵ";
			this.ѡ���û���ϵ.Size = new System.Drawing.Size(104, 20);
			this.ѡ���û���ϵ.TabIndex = 6;
			this.ѡ���û���ϵ.Text = "ѡ���û���ϵ";
			// 
			// rbUpArchi
			// 
			this.rbUpArchi.Location = new System.Drawing.Point(304, 72);
			this.rbUpArchi.Name = "rbUpArchi";
			this.rbUpArchi.Size = new System.Drawing.Size(72, 23);
			this.rbUpArchi.TabIndex = 2;
			this.rbUpArchi.Text = "�ϼ�����";
			// 
			// rbArchi
			// 
			this.rbArchi.Location = new System.Drawing.Point(304, 96);
			this.rbArchi.Name = "rbArchi";
			this.rbArchi.Size = new System.Drawing.Size(72, 23);
			this.rbArchi.TabIndex = 3;
			this.rbArchi.Text = "���ڻ���";
			// 
			// rbDomiArchi
			// 
			this.rbDomiArchi.Location = new System.Drawing.Point(304, 120);
			this.rbDomiArchi.Name = "rbDomiArchi";
			this.rbDomiArchi.Size = new System.Drawing.Size(72, 23);
			this.rbDomiArchi.TabIndex = 4;
			this.rbDomiArchi.Text = "��Ͻ����";
			// 
			// rbPart
			// 
			this.rbPart.Location = new System.Drawing.Point(304, 144);
			this.rbPart.Name = "rbPart";
			this.rbPart.Size = new System.Drawing.Size(72, 23);
			this.rbPart.TabIndex = 5;
			this.rbPart.Text = "��Խ�ɫ";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton6);
			this.groupBox1.Controls.Add(this.radioButton5);
			this.groupBox1.Controls.Add(this.cmbvarP);
			this.groupBox1.Controls.Add(this.rbsomevarP);
			this.groupBox1.Controls.Add(this.cmbsometaskP);
			this.groupBox1.Controls.Add(this.rbsometaskP);
			this.groupBox1.Controls.Add(this.EveryOne);
			this.groupBox1.Controls.Add(this.cmbVar);
			this.groupBox1.Controls.Add(this.cmbSomeTask);
			this.groupBox1.Controls.Add(this.rbVar);
			this.groupBox1.Controls.Add(this.rbSomeTask);
			this.groupBox1.Controls.Add(this.rbFlowStartor);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(398, 219);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "�û�ѡ��";
			// 
			// radioButton6
			// 
			this.radioButton6.Location = new System.Drawing.Point(128, 40);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(208, 24);
			this.radioButton6.TabIndex = 12;
			this.radioButton6.Text = "��һ�����ʵ��ִ�������ڸ�λ";
			// 
			// radioButton5
			// 
			this.radioButton5.Location = new System.Drawing.Point(128, 16);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(160, 24);
			this.radioButton5.TabIndex = 11;
			this.radioButton5.Text = "��һ�����ʵ��ִ����";
			// 
			// cmbvarP
			// 
			this.cmbvarP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbvarP.Location = new System.Drawing.Point(224, 184);
			this.cmbvarP.Name = "cmbvarP";
			this.cmbvarP.Size = new System.Drawing.Size(120, 20);
			this.cmbvarP.TabIndex = 10;
			// 
			// rbsomevarP
			// 
			this.rbsomevarP.Location = new System.Drawing.Point(8, 184);
			this.rbsomevarP.Name = "rbsomevarP";
			this.rbsomevarP.Size = new System.Drawing.Size(174, 24);
			this.rbsomevarP.TabIndex = 9;
			this.rbsomevarP.Text = "�ӱ����л�ȡ������λ";
			// 
			// cmbsometaskP
			// 
			this.cmbsometaskP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbsometaskP.Location = new System.Drawing.Point(224, 128);
			this.cmbsometaskP.Name = "cmbsometaskP";
			this.cmbsometaskP.Size = new System.Drawing.Size(120, 20);
			this.cmbsometaskP.TabIndex = 8;
			// 
			// rbsometaskP
			// 
			this.rbsometaskP.Location = new System.Drawing.Point(8, 128);
			this.rbsometaskP.Name = "rbsometaskP";
			this.rbsometaskP.Size = new System.Drawing.Size(206, 24);
			this.rbsometaskP.TabIndex = 7;
			this.rbsometaskP.Text = "ĳһ�����ʵ��ִ�������ڸ�λ";
			// 
			// EveryOne
			// 
			this.EveryOne.Location = new System.Drawing.Point(10, 40);
			this.EveryOne.Name = "EveryOne";
			this.EveryOne.Size = new System.Drawing.Size(104, 23);
			this.EveryOne.TabIndex = 6;
			this.EveryOne.Text = "������";
			// 
			// cmbVar
			// 
			this.cmbVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVar.Location = new System.Drawing.Point(224, 160);
			this.cmbVar.Name = "cmbVar";
			this.cmbVar.Size = new System.Drawing.Size(120, 20);
			this.cmbVar.TabIndex = 5;
			// 
			// cmbSomeTask
			// 
			this.cmbSomeTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSomeTask.Location = new System.Drawing.Point(224, 104);
			this.cmbSomeTask.Name = "cmbSomeTask";
			this.cmbSomeTask.Size = new System.Drawing.Size(120, 20);
			this.cmbSomeTask.TabIndex = 4;
			// 
			// rbVar
			// 
			this.rbVar.Location = new System.Drawing.Point(8, 160);
			this.rbVar.Name = "rbVar";
			this.rbVar.Size = new System.Drawing.Size(134, 23);
			this.rbVar.TabIndex = 3;
			this.rbVar.Text = "�ӱ����л�ȡ������";
			// 
			// rbSomeTask
			// 
			this.rbSomeTask.Location = new System.Drawing.Point(8, 104);
			this.rbSomeTask.Name = "rbSomeTask";
			this.rbSomeTask.Size = new System.Drawing.Size(148, 23);
			this.rbSomeTask.TabIndex = 2;
			this.rbSomeTask.Text = "ĳһ�����ʵ��ִ����";
			// 
			// rbFlowStartor
			// 
			this.rbFlowStartor.Checked = true;
			this.rbFlowStartor.Location = new System.Drawing.Point(10, 16);
			this.rbFlowStartor.Name = "rbFlowStartor";
			this.rbFlowStartor.Size = new System.Drawing.Size(104, 23);
			this.rbFlowStartor.TabIndex = 0;
			this.rbFlowStartor.TabStop = true;
			this.rbFlowStartor.Text = "����������";
			// 
			// fmTaskExpress
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(416, 461);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "fmTaskExpress";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "���ʽ";
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
