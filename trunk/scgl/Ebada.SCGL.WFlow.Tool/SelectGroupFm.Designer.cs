namespace Ebada.SCGL.WFlow.Tool
{
    partial class fmSelectGroup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmSelectGroup));
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxGroupName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lvGroup = new System.Windows.Forms.ListView();
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.btnSearch);
            this.plclassFill.Controls.Add(this.tbxGroupName);
            this.plclassFill.Controls.Add(this.label2);
            this.plclassFill.Controls.Add(this.lvGroup);
            this.plclassFill.Paint += new System.Windows.Forms.PaintEventHandler(this.plclassFill_Paint);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Text = "ȷ��(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Text = "ȡ��(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(283, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 23);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "��ѯ";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxGroupName
            // 
            this.tbxGroupName.Location = new System.Drawing.Point(99, 27);
            this.tbxGroupName.Name = "tbxGroupName";
            this.tbxGroupName.Size = new System.Drawing.Size(160, 21);
            this.tbxGroupName.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "��ɫ���ƣ�";
            // 
            // lvGroup
            // 
            this.lvGroup.FullRowSelect = true;
            this.lvGroup.Location = new System.Drawing.Point(12, 57);
            this.lvGroup.MultiSelect = false;
            this.lvGroup.Name = "lvGroup";
            this.lvGroup.Size = new System.Drawing.Size(387, 320);
            this.lvGroup.SmallImageList = this.imgListSmall;
            this.lvGroup.TabIndex = 10;
            this.lvGroup.UseCompatibleStateImageBehavior = false;
            this.lvGroup.View = System.Windows.Forms.View.Details;
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall.Images.SetKeyName(0, "13.bmp");
            // 
            // fmSelectGroup
            // 
            this.ClientSize = new System.Drawing.Size(426, 466);
            this.Name = "fmSelectGroup";
            this.Text = "ѡ���ɫ";
            this.Load += new System.EventHandler(this.SelectGroupFm_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassFill.PerformLayout();
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxGroupName;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ListView lvGroup;
        private System.Windows.Forms.ImageList imgListSmall;
    }
}
