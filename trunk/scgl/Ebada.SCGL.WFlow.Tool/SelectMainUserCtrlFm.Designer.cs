namespace Ebada.SCGL.WFlow.Tool
{
    partial class fmSelectMainUserCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmSelectMainUserCtrl));
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.lvMainUserCtrl = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxCaption = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.btnSearch);
            this.plclassFill.Controls.Add(this.tbxCaption);
            this.plclassFill.Controls.Add(this.label1);
            this.plclassFill.Controls.Add(this.lvMainUserCtrl);
            this.plclassFill.Dock = System.Windows.Forms.DockStyle.Top;
            this.plclassFill.Size = new System.Drawing.Size(494, 358);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Controls.Add(this.btnNew);
            this.plclassBottom.Controls.Add(this.btnModify);
            this.plclassBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plclassBottom.Location = new System.Drawing.Point(0, 358);
            this.plclassBottom.Size = new System.Drawing.Size(494, 50);
            this.plclassBottom.Controls.SetChildIndex(this.btnModify, 0);
            this.plclassBottom.Controls.SetChildIndex(this.btnNew, 0);
            this.plclassBottom.Controls.SetChildIndex(this.btnSave, 0);
            this.plclassBottom.Controls.SetChildIndex(this.btnClose, 0);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(236, 13);
            this.btnSave.Text = "ȷ��(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(354, 13);
            this.btnClose.Text = "ȡ��(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall.Images.SetKeyName(0, "12.bmp");
            // 
            // lvMainUserCtrl
            // 
            this.lvMainUserCtrl.FullRowSelect = true;
            this.lvMainUserCtrl.Location = new System.Drawing.Point(19, 47);
            this.lvMainUserCtrl.MultiSelect = false;
            this.lvMainUserCtrl.Name = "lvMainUserCtrl";
            this.lvMainUserCtrl.Size = new System.Drawing.Size(453, 305);
            this.lvMainUserCtrl.SmallImageList = this.imgListSmall;
            this.lvMainUserCtrl.TabIndex = 4;
            this.lvMainUserCtrl.UseCompatibleStateImageBehavior = false;
            this.lvMainUserCtrl.View = System.Windows.Forms.View.Details;
            this.lvMainUserCtrl.DoubleClick += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "�����ƣ�";
            // 
            // tbxCaption
            // 
            this.tbxCaption.Location = new System.Drawing.Point(108, 20);
            this.tbxCaption.Name = "tbxCaption";
            this.tbxCaption.Size = new System.Drawing.Size(236, 21);
            this.tbxCaption.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(365, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "��ѯ";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(20, 13);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(73, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "������";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(99, 13);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(69, 23);
            this.btnModify.TabIndex = 3;
            this.btnModify.Text = "�޸�";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Visible = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // fmSelectMainUserCtrl
            // 
            this.ClientSize = new System.Drawing.Size(494, 408);
            this.Name = "fmSelectMainUserCtrl";
            this.Text = "ѡ������";
            this.Load += new System.EventHandler(this.fmSelectUser_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassFill.PerformLayout();
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgListSmall;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxCaption;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListView lvMainUserCtrl;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnModify;
    }
}
