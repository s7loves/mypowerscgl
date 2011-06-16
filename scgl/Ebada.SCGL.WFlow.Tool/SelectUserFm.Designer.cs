namespace Ebada.SCGL.WFlow.Tool
{
    partial class fmSelectUser
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmSelectUser));
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.lvUser = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxUserId = new System.Windows.Forms.TextBox();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.btnSearch);
            this.plclassFill.Controls.Add(this.tbxUserName);
            this.plclassFill.Controls.Add(this.label2);
            this.plclassFill.Controls.Add(this.tbxUserId);
            this.plclassFill.Controls.Add(this.label1);
            this.plclassFill.Controls.Add(this.lvUser);
            this.plclassFill.Dock = System.Windows.Forms.DockStyle.Top;
            this.plclassFill.Size = new System.Drawing.Size(494, 358);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plclassBottom.Location = new System.Drawing.Point(0, 358);
            this.plclassBottom.Size = new System.Drawing.Size(494, 50);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(236, 13);
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(354, 13);
            this.btnClose.Text = "取消(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall.Images.SetKeyName(0, "12.bmp");
            // 
            // lvUser
            // 
            this.lvUser.FullRowSelect = true;
            this.lvUser.Location = new System.Drawing.Point(19, 74);
            this.lvUser.MultiSelect = false;
            this.lvUser.Name = "lvUser";
            this.lvUser.Size = new System.Drawing.Size(453, 278);
            this.lvUser.SmallImageList = this.imgListSmall;
            this.lvUser.TabIndex = 4;
            this.lvUser.UseCompatibleStateImageBehavior = false;
            this.lvUser.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "帐号：";
            // 
            // tbxUserId
            // 
            this.tbxUserId.Location = new System.Drawing.Point(61, 33);
            this.tbxUserId.Name = "tbxUserId";
            this.tbxUserId.Size = new System.Drawing.Size(135, 21);
            this.tbxUserId.TabIndex = 6;
            // 
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(260, 33);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(135, 21);
            this.tbxUserName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "姓名：";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(401, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // fmSelectUser
            // 
            this.ClientSize = new System.Drawing.Size(494, 408);
            this.Name = "fmSelectUser";
            this.Text = "选择用户";
            this.Load += new System.EventHandler(this.fmSelectUser_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassFill.PerformLayout();
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgListSmall;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxUserId;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListView lvUser;
    }
}
