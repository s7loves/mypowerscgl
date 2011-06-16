using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Ebada.SCGL.WFlow.Tool
{
	/// <summary>
	/// BaseForm_Single ��ժҪ˵����
	/// </summary>
	public class BaseForm_Single : System.Windows.Forms.Form
	{
		protected System.Windows.Forms.Panel plclassFill;
		protected System.Windows.Forms.Panel plclassBottom;
		protected System.Windows.Forms.Button btnSave;
		protected System.Windows.Forms.Button btnClose;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BaseForm_Single()
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
            this.plclassFill = new System.Windows.Forms.Panel();
            this.plclassBottom = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plclassFill.Location = new System.Drawing.Point(0, 0);
            this.plclassFill.Name = "plclassFill";
            this.plclassFill.Size = new System.Drawing.Size(426, 466);
            this.plclassFill.TabIndex = 0;
            // 
            // plclassBottom
            // 
            this.plclassBottom.Controls.Add(this.btnClose);
            this.plclassBottom.Controls.Add(this.btnSave);
            this.plclassBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plclassBottom.Location = new System.Drawing.Point(0, 400);
            this.plclassBottom.Name = "plclassBottom";
            this.plclassBottom.Size = new System.Drawing.Size(426, 66);
            this.plclassBottom.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(304, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "�ر�(&E)";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(208, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "����(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BaseForm_Single
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(426, 466);
            this.Controls.Add(this.plclassBottom);
            this.Controls.Add(this.plclassFill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseForm_Single";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "��Ϣά��";
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
	}
}
