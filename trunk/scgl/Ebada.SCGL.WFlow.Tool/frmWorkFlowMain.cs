using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Data;
using System.IO;
using Ebada.Client;

namespace Ebada.SCGL.WorkFlow.Tool
{
	/// <summary>
	/// WorkFlowMainFM ��ժҪ˵����
	/// </summary>
	public class fmWorkFlowMain : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components;
        public string UserId = "";
        private ImageList imglistMain;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuSystem;
        private ToolStripMenuItem menuReset;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStrip toolStrip1;
        private TreeView treeFramework;
        private Splitter splitter1;
        private ContextMenuStrip frktreeContextMenuStrip;
        private ToolStripButton tsbRefrush;
        private ToolStripMenuItem WindowToolStripMenuItem;
        private ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private ToolStripMenuItem tileVerticalToolStripMenuItem;
        private ToolStripMenuItem cascadeToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem closeAllToolStripMenuItem;
        private ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem ����ToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
		public string UserName="";
        private ToolStripMenuItem NewToolfrkStripMenuItem;
        private ToolStripMenuItem ModifyfrkToolStripMenuItem;
        private ToolStripMenuItem DeletefrkToolStripMenuItem;
        const string rootflag = "####";
        FrmworkTreeNode NowtreeNode;
        private OpenFileDialog openFileDialog1;
        private ToolStripButton tbxNew;
        private ToolStripButton tsbDelete;
        private ToolStripButton tsbEdit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbHelp;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbExit;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem �½�ToolStripMenuItem;
        private ToolStripMenuItem �޸�ToolStripMenuItem;
        private ToolStripMenuItem ɾ��ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem ˢ��ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem ����ToolStripMenuItem;
        private ToolStripMenuItem ѡ��ToolStripMenuItem;

        string NowtreeNodeId;//��ǰ�ڵ��Id
		
		public  fmWorkFlowMain()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
            UserId = "001";

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmWorkFlowMain));
            this.imglistMain = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.�½�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�޸�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ɾ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ˢ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ѡ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbxNew = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefrush = new System.Windows.Forms.ToolStripButton();
            this.tsbHelp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.treeFramework = new System.Windows.Forms.TreeView();
            this.frktreeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewToolfrkStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifyfrkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeletefrkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.frktreeContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // imglistMain
            // 
            this.imglistMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglistMain.ImageStream")));
            this.imglistMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imglistMain.Images.SetKeyName(0, "folder.bmp");
            this.imglistMain.Images.SetKeyName(1, "arch.bmp");
            this.imglistMain.Images.SetKeyName(2, "12.bmp");
            this.imglistMain.Images.SetKeyName(3, "workflow1.bmp");
            this.imglistMain.Images.SetKeyName(4, "��.bmp");
            this.imglistMain.Images.SetKeyName(5, "03982.ico");
            this.imglistMain.Images.SetKeyName(6, "04367.ico");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSystem,
            this.����ToolStripMenuItem,
            this.WindowToolStripMenuItem,
            this.����ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(863, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuSystem
            // 
            this.menuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuReset,
            this.toolStripMenuItem4,
            this.�½�ToolStripMenuItem,
            this.�޸�ToolStripMenuItem,
            this.ɾ��ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.ˢ��ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.menuSystem.Name = "menuSystem";
            this.menuSystem.Size = new System.Drawing.Size(59, 20);
            this.menuSystem.Text = "ϵͳ(&S)";
            // 
            // menuReset
            // 
            this.menuReset.Name = "menuReset";
            this.menuReset.Size = new System.Drawing.Size(118, 22);
            this.menuReset.Text = "���µ�¼";
            this.menuReset.Click += new System.EventHandler(this.memuReset_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(115, 6);
            // 
            // �½�ToolStripMenuItem
            // 
            this.�½�ToolStripMenuItem.Name = "�½�ToolStripMenuItem";
            this.�½�ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.�½�ToolStripMenuItem.Text = "�½�";
            this.�½�ToolStripMenuItem.Click += new System.EventHandler(this.NewToolfrkStripMenuItem_Click);
            // 
            // �޸�ToolStripMenuItem
            // 
            this.�޸�ToolStripMenuItem.Name = "�޸�ToolStripMenuItem";
            this.�޸�ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.�޸�ToolStripMenuItem.Text = "�޸�";
            this.�޸�ToolStripMenuItem.Click += new System.EventHandler(this.ModifyfrkToolStripMenuItem_Click);
            // 
            // ɾ��ToolStripMenuItem
            // 
            this.ɾ��ToolStripMenuItem.Name = "ɾ��ToolStripMenuItem";
            this.ɾ��ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.ɾ��ToolStripMenuItem.Text = "ɾ��";
            this.ɾ��ToolStripMenuItem.Click += new System.EventHandler(this.DeletefrkToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(115, 6);
            // 
            // ˢ��ToolStripMenuItem
            // 
            this.ˢ��ToolStripMenuItem.Name = "ˢ��ToolStripMenuItem";
            this.ˢ��ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.ˢ��ToolStripMenuItem.Text = "ˢ��";
            this.ˢ��ToolStripMenuItem.Click += new System.EventHandler(this.tsbRefrush_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(115, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.exitToolStripMenuItem.Text = "�˳�";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ѡ��ToolStripMenuItem});
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.����ToolStripMenuItem.Text = "����(&T)";
            // 
            // ѡ��ToolStripMenuItem
            // 
            this.ѡ��ToolStripMenuItem.Name = "ѡ��ToolStripMenuItem";
            this.ѡ��ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.ѡ��ToolStripMenuItem.Text = "ѡ��(&O)...";
            // 
            // WindowToolStripMenuItem
            // 
            this.WindowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.closeAllToolStripMenuItem});
            this.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem";
            this.WindowToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.WindowToolStripMenuItem.Text = "����(&W)";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.cascadeToolStripMenuItem.Text = "���";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.tileHorizontalToolStripMenuItem.Text = "ˮƽƽ��";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.tileHorizontalToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.tileVerticalToolStripMenuItem.Text = "��ֱƽ��";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.tileVerticalToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.arrangeIconsToolStripMenuItem.Text = "����ͼ��";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.arrangeIconsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(115, 6);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.closeAllToolStripMenuItem.Text = "ȫ���ر�";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.����ToolStripMenuItem.Text = "����(&H)";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.helpToolStripMenuItem.Text = "��������";
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 531);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(863, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel1.Text = "��ǰ�û�:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbxNew,
            this.tsbEdit,
            this.tsbDelete,
            this.toolStripSeparator1,
            this.tsbRefrush,
            this.tsbHelp,
            this.toolStripSeparator2,
            this.tsbExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(863, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbxNew
            // 
            this.tbxNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbxNew.Image = ((System.Drawing.Image)(resources.GetObject("tbxNew.Image")));
            this.tbxNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbxNew.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tbxNew.Name = "tbxNew";
            this.tbxNew.Size = new System.Drawing.Size(23, 22);
            this.tbxNew.Text = "toolStripButton2";
            this.tbxNew.ToolTipText = "�½�";
            this.tbxNew.Click += new System.EventHandler(this.NewToolfrkStripMenuItem_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(23, 22);
            this.tsbEdit.Text = "toolStripButton4";
            this.tsbEdit.ToolTipText = "�޸�";
            this.tsbEdit.Click += new System.EventHandler(this.ModifyfrkToolStripMenuItem_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbDelete.Text = "toolStripButton3";
            this.tsbDelete.ToolTipText = "ɾ��";
            this.tsbDelete.Click += new System.EventHandler(this.DeletefrkToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRefrush
            // 
            this.tsbRefrush.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefrush.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefrush.Image")));
            this.tsbRefrush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefrush.Name = "tsbRefrush";
            this.tsbRefrush.Size = new System.Drawing.Size(23, 22);
            this.tsbRefrush.Text = "ˢ��";
            this.tsbRefrush.Click += new System.EventHandler(this.tsbRefrush_Click);
            // 
            // tsbHelp
            // 
            this.tsbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsbHelp.Image")));
            this.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHelp.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsbHelp.Name = "tsbHelp";
            this.tsbHelp.Size = new System.Drawing.Size(23, 22);
            this.tsbHelp.Text = "toolStripButton6";
            this.tsbHelp.ToolTipText = "����";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExit
            // 
            this.tsbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(23, 22);
            this.tsbExit.Text = "toolStripButton5";
            this.tsbExit.ToolTipText = "�˳�";
            this.tsbExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // treeFramework
            // 
            this.treeFramework.ContextMenuStrip = this.frktreeContextMenuStrip;
            this.treeFramework.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeFramework.ImageIndex = 0;
            this.treeFramework.ImageList = this.imglistMain;
            this.treeFramework.Location = new System.Drawing.Point(0, 49);
            this.treeFramework.Name = "treeFramework";
            this.treeFramework.SelectedImageIndex = 0;
            this.treeFramework.Size = new System.Drawing.Size(178, 482);
            this.treeFramework.TabIndex = 13;
            this.treeFramework.DoubleClick += new System.EventHandler(this.treeFramework_DoubleClick);
            this.treeFramework.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFramework_AfterSelect);
            // 
            // frktreeContextMenuStrip
            // 
            this.frktreeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolfrkStripMenuItem,
            this.ModifyfrkToolStripMenuItem,
            this.DeletefrkToolStripMenuItem});
            this.frktreeContextMenuStrip.Name = "contextMenuStrip1";
            this.frktreeContextMenuStrip.Size = new System.Drawing.Size(95, 70);
            // 
            // NewToolfrkStripMenuItem
            // 
            this.NewToolfrkStripMenuItem.Name = "NewToolfrkStripMenuItem";
            this.NewToolfrkStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.NewToolfrkStripMenuItem.Text = "�½�";
            this.NewToolfrkStripMenuItem.Click += new System.EventHandler(this.NewToolfrkStripMenuItem_Click);
            // 
            // ModifyfrkToolStripMenuItem
            // 
            this.ModifyfrkToolStripMenuItem.Name = "ModifyfrkToolStripMenuItem";
            this.ModifyfrkToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.ModifyfrkToolStripMenuItem.Text = "�޸�";
            this.ModifyfrkToolStripMenuItem.Click += new System.EventHandler(this.ModifyfrkToolStripMenuItem_Click);
            // 
            // DeletefrkToolStripMenuItem
            // 
            this.DeletefrkToolStripMenuItem.Name = "DeletefrkToolStripMenuItem";
            this.DeletefrkToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.DeletefrkToolStripMenuItem.Text = "ɾ��";
            this.DeletefrkToolStripMenuItem.Click += new System.EventHandler(this.DeletefrkToolStripMenuItem_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(178, 49);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 482);
            this.splitter1.TabIndex = 14;
            this.splitter1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "dialog";
            // 
            // fmWorkFlowMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(863, 553);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeFramework);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fmWorkFlowMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "���������ù���";
            this.Load += new System.EventHandler(this.fmWorkFlowMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.frktreeContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
           
                fmFlash tmpfmFlash = new fmFlash();
                tmpfmFlash.Show();
                tmpfmFlash.BringToFront();
                Application.Run(new fmWorkFlowMain());
           
			
		}
		/// <summary>
		/// �����Ӵ��������жϴ����Ƿ��
		/// </summary>
		/// <param name="ParentForm">������</param>
		/// <param name="formtitle">�Ӵ���ı���</param>
		/// <returns></returns>
		private System.Windows.Forms.Form FormExists(System.Windows.Forms.Form ParentForm,string formname)
		{
			System.Windows.Forms.Form bl=null;
			foreach(Form objForm in ParentForm.MdiChildren)
			{
                if (objForm.Name.Equals(formname))
                {
                    bl = objForm;
                    break;
                }
			}
			return bl;
		}
		
        private void cascadeToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			// ʵ�ֶ��������е�MDI����Ĳ������
			this.LayoutMdi ( MdiLayout.Cascade ) ;

		}

        private void tileHorizontalToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			// ʵ�ֶ��������е�MDI�����ˮƽƽ�̲���
            this.LayoutMdi(MdiLayout.TileHorizontal);

		}

        private void tileVerticalToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			// ʵ�ֶ��������е�MDI����Ĵ�ֱƽ�̲���
            this.LayoutMdi(MdiLayout.TileVertical);
		}
        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //����ͼ��
            LayoutMdi(MdiLayout.ArrangeIcons);
        }
        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }
		private void menuItemClose_Click(object sender, System.EventArgs e)
		{
			Close();
		}
        /// <summary>
        /// �ݹ�װ������������
        /// </summary>
        /// <param name="key"></param>
        /// <param name="startNodes"></param>
        public void LoadFrameTreeFromDB(string key, TreeNodeCollection startNodes)
        {
            if (startNodes == null) throw new Exception("����LoadFrameTreeFromDBʧ�ܣ�startNodesδָ����");

            //string tmpStr = "select * from FrmworkTree where isVisable=1 and FatherCode='" + key + "'";//��Ч������Ϣ
            try
            {
                DataTable table = FrmworkTreeNode.GetChildNodes(key);
                foreach (DataRow row in table.Rows)
                {
                    FrmworkTreeNode tmpNode = new FrmworkTreeNode();
                    tmpNode.NodeId = row["SelfCode"].ToString();
                    tmpNode.FatherId = row["FatherCode"].ToString();
                    tmpNode.ImageIndex = Convert.ToInt16(row["ImageIndex"]);
                    tmpNode.SelectedImageIndex = Convert.ToInt16(row["ImageIndex"]); 
                    tmpNode.Text = row["Caption"].ToString();
                    tmpNode.DllClassName = row["DllClassName"].ToString();
                    tmpNode.DllFileName = row["DllFileName"].ToString();
                    tmpNode.DllMethodName = row["DllMethodName"].ToString();
                    tmpNode.FormName = row["FormName"].ToString();
                    tmpNode.MouseIsClick = Convert.ToBoolean(row["MouseIsClick"]);
                    tmpNode.BlankWindows = Convert.ToBoolean(row["BlankWindows"]);
                    tmpNode.WindowsSDI = Convert.ToBoolean(row["SDIWindows"]);
                    tmpNode.CanVisable = Convert.ToBoolean(row["IsVisable"]);
                    tmpNode.ContextMenuStrip = frktreeContextMenuStrip;
                    tmpNode.Refresh = true;
                    tmpNode.NodeType = row["NodeType"].ToString();
                    startNodes.Add(tmpNode);
                    //LoadFrameTreeFromDB(tmpNode.NodeId, tmpNode.Nodes);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
		private void fmWorkFlowMain_Load(object sender, System.EventArgs e)
		{

            treeFramework.Nodes.Clear();
            LoadFrameTreeFromDB(rootflag, treeFramework.Nodes);
            treeFramework.ExpandAll();
            this.statusStrip1.Items[1].Text = UserId;

		}
        private void  loadskin()
        {
            //string skinpathfile = "";
            //string skinfilename = System.Configuration.ConfigurationSettings.AppSettings["skinfilename"];//Ƥ���ļ���������·��
            //skinpathfile = Application.StartupPath + @"\skins\" + skinfilename;
            //if (File.Exists(skinpathfile))
            //{
            //    skinEngine1.SkinFile = skinpathfile;
            //    if (!skinEngine1.Active)
            //        skinEngine1.Active = true;
            //}
      
        }
        /// <summary>
        /// ���ö�̬����
        /// </summary>
        /// <param name="e"></param>
        private void actionFramework(FrmworkTreeNode e)
        {


            if (e.NodeType == "Window")//���ô���
            {
                System.Windows.Forms.Form fromCtrl = null;
                fromCtrl = FormExists(this, e.FormName);//���ݴ��������Ҵ���
                if ((e.BlankWindows) || (!e.BlankWindows && fromCtrl==null))//�������´��ڴ򿪻���û�����ɴ���Ķ����´�������
                {
                    string DllPathName = Application.StartupPath + @"\" + e.DllFileName;
                    Object[] objArray = new object[3];//dll���๹�캯��������еĲ�������
                    objArray[0] = e.NodeId;
                    objArray[1] = this.UserId;
                    objArray[2] = this.UserName;
                    DynamicLibrary myDll = new DynamicLibrary();
                    myDll.DllFileName = DllPathName;
                    myDll.DllClassName = e.DllClassName;
                    myDll.MainForm = this;
                    myDll.ObjArray = objArray;
                    if (e.WindowsSDI)
                    {
                        fromCtrl = myDll.CallSDIWindows();
                    }
                    else
                    {
                        fromCtrl = myDll.CallMDIWindows();
                        fromCtrl.Text = e.Text;//���ô������
                    }
                   
                }
                
                else//�����Ѿ��򿪣���С���Ļ�ԭ������ʾ����ǰ��
                {
                    if (fromCtrl.WindowState == FormWindowState.Minimized)
                        fromCtrl.WindowState = FormWindowState.Normal;
                    fromCtrl.BringToFront();

                }
            }
            else
                if (e.NodeType == "Function")//���ù���
                {
                    string DllPathName = Application.StartupPath + @"\" + e.DllFileName;
                    Object[] objArray = new object[2];//dll���๹�캯���������2������
                    objArray[0] = this.UserId;
                    objArray[1] = this.UserName;
                    Object[] objMethodArray = new object[2];//dll���෽��������еĲ���
                    objMethodArray[0] = e.NodeId;
                    objMethodArray[1] = treeFramework.SelectedNode.Nodes;
                    DynamicLibrary myDll = new DynamicLibrary();
                    myDll.DllFileName = DllPathName;
                    myDll.DllClassName = e.DllClassName;
                    myDll.DllMethodName = e.DllMethodName;
                    myDll.ObjArray = objArray;
                    myDll.ObjMethodArray = objMethodArray;
                    myDll.CallMethod();

                }

                  
        }
 
        
        private void treeFramework_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            
             NowtreeNode = (FrmworkTreeNode)e.Node;
             NowtreeNodeId = NowtreeNode.NodeId;
             if (NowtreeNode.MouseIsClick)
                try
                {
                    actionFramework(NowtreeNode);
                }
                catch (Exception ex)
                {
                    MessageBox.Show  ("ִ��������󣬴�����룺"+ex.Message.ToString(),"����");
                }
      
            }
    

		
		

		

		

        

        private void memuReset_Click(object sender, EventArgs e)
        {
            

        }

        private void treeFramework_DoubleClick(object sender, EventArgs e)
        {
            if (NowtreeNode == null) return;

            if (!NowtreeNode.MouseIsClick)
            {
                try
                {
                    actionFramework(NowtreeNode);
                }
                catch (Exception ex)
                {
                    MessageBox.Show ("ִ��������󣬴�����룺" + ex.Message.ToString(),"����");
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void powerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (PowerData.IsPower("leg", "000000"))
            //{
            //    WorkDialog.WarningDlg("Ȩ����֤ͨ��!", "��ʾ");
            //}
            //else
            //{
            //    WorkDialog.WarningDlg("û��Ȩ��!","��ʾ");
            //}
        
        }

        private void NewToolfrkStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowtreeNode != null)
            {

                frmFrmworkTree tmpForm = new frmFrmworkTree("�½�", NowtreeNodeId, NowtreeNode);
                tmpForm.ShowDialog();
            }
        }

        private void ModifyfrkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowtreeNode != null)
            {
                frmFrmworkTree tmpForm = new frmFrmworkTree("�޸�", NowtreeNodeId, NowtreeNode);
                tmpForm.ShowDialog();
            }
         
        }

        private void DeletefrkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowtreeNode == null) return;
            string tmpNodeCaption = NowtreeNode.Text;
            if (NowtreeNode.Nodes.Count > 0)
            {
                MessageBox.Show(tmpNodeCaption+"���ӽڵ�,����ɾ���ӽڵ�!","����ɾ��");
                return;
            }
            if (MessageBox.Show("�Ƿ�ɾ�� " + tmpNodeCaption + " ,ɾ�����ָܻ�?", "ѯ��") == DialogResult.Yes)
            {
                NowtreeNode.DeleteNodeInfo();
                NowtreeNode.Remove();

            }

        }

        private void tsbRefrush_Click(object sender, EventArgs e)
        {
            //ˢ��
            if (NowtreeNode == null) return;
            if (NowtreeNode != null)
            {
                if (NowtreeNode.Level == 0)
                {
                    fmWorkFlowMain_Load(null, null);

                }
                actionFramework(NowtreeNode);
                NowtreeNode.ExpandAll();
            }
     
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MsgBox.ShowAskMessageBox("�Ƿ��˳�������ƹ���?");
            if (result == DialogResult.Yes)
            this.Close();
        }

       

       

        

       

      
	}
}
