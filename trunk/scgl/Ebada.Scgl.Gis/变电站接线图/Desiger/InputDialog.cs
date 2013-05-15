using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ShapesLib.Design
{
	/// <summary>
	/// NewConnectDialog ��ժҪ˵����
	/// </summary>
	public class InputDialog :  DevExpress.XtraEditors.XtraForm
	{
		private Label label5;
        private TextBox tbName;
        private String inputText;
		/// <summary>
		/// ����������������
		/// </summary>
		private Container components = null;
        private Label label2;
        private DevExpress.XtraEditors.SimpleButton btOk;
        private DevExpress.XtraEditors.SimpleButton btCancel;

		public int inputLength;

		public InputDialog()
		{
			//
			// Windows ���������֧���������
			//
			inputText=string.Empty;
			inputLength=100;
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btOk = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(15, 12);
            this.tbName.MaxLength = 200;
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbName.Size = new System.Drawing.Size(265, 136);
            this.tbName.TabIndex = 0;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(8, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(272, 2);
            this.label5.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(12, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 14);
            this.label2.TabIndex = 5;
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Location = new System.Drawing.Point(172, 173);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(53, 23);
            this.btOk.TabIndex = 6;
            this.btOk.Text = "ȷ��";
            this.btOk.Click += new System.EventHandler(this.button2_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(232, 173);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(53, 23);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "ȡ��";
            // 
            // InputDialog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(295, 204);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "�����ı�";
            this.Load += new System.EventHandler(this.InputDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			this.tbName.Text=this.inputText;
			this.tbName.MaxLength=this.inputLength;
		}

		
		private void button2_Click(object sender, EventArgs e)
		{
			if (this.tbName.Text.Trim()==string.Empty)
				return;
			this.InputString=this.tbName.Text;

			this.DialogResult=DialogResult.OK;
			this.Close();
		}

		private void InputDialog_Load(object sender, System.EventArgs e)
		{
		
		}

		public string InputString
		{

			get
			{
				return inputText;
			}
			set
			{
				this.inputText=value;
			}
		}

		public int InputLength
		{
			get { return this.inputLength; }
			set {this.inputLength=value;}
        }

        private void tbName_TextChanged(object sender, EventArgs e) {
            if (tbName.Text.Length > 0) {
                label2.Text = "��" + tbName.Text.Length + "�ַ�";
            }
        }
	}
}
