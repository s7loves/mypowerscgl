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
	/// WorkFlowMainFM 的摘要说明。
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
        private ToolStripMenuItem 帮助ToolStripMenuItem;
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
        private ToolStripMenuItem 新建ToolStripMenuItem;
        private ToolStripMenuItem 修改ToolStripMenuItem;
        private ToolStripMenuItem 删除ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem 刷新ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem 工具ToolStripMenuItem;
        private ToolStripMenuItem 选项ToolStripMenuItem;

        string NowtreeNodeId;//当前节点的Id
		
		public  fmWorkFlowMain()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            UserId = "001";

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmWorkFlowMain));
            this.imglistMain = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.imglistMain.Images.SetKeyName(4, "表单.bmp");
            this.imglistMain.Images.SetKeyName(5, "03982.ico");
            this.imglistMain.Images.SetKeyName(6, "04367.ico");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSystem,
            this.工具ToolStripMenuItem,
            this.WindowToolStripMenuItem,
            this.帮助ToolStripMenuItem});
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
            this.新建ToolStripMenuItem,
            this.修改ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.刷新ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.menuSystem.Name = "menuSystem";
            this.menuSystem.Size = new System.Drawing.Size(59, 20);
            this.menuSystem.Text = "系统(&S)";
            // 
            // menuReset
            // 
            this.menuReset.Name = "menuReset";
            this.menuReset.Size = new System.Drawing.Size(118, 22);
            this.menuReset.Text = "重新登录";
            this.menuReset.Click += new System.EventHandler(this.memuReset_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(115, 6);
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.新建ToolStripMenuItem.Text = "新建";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.NewToolfrkStripMenuItem_Click);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.ModifyfrkToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.DeletefrkToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(115, 6);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.tsbRefrush_Click);
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
            this.exitToolStripMenuItem.Text = "退出";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选项ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.工具ToolStripMenuItem.Text = "工具(&T)";
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.选项ToolStripMenuItem.Text = "选项(&O)...";
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
            this.WindowToolStripMenuItem.Text = "窗口(&W)";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.cascadeToolStripMenuItem.Text = "层叠";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.tileHorizontalToolStripMenuItem.Text = "水平平铺";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.tileHorizontalToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.tileVerticalToolStripMenuItem.Text = "垂直平铺";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.tileVerticalToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.arrangeIconsToolStripMenuItem.Text = "排列图标";
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
            this.closeAllToolStripMenuItem.Text = "全部关闭";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.帮助ToolStripMenuItem.Text = "帮助(&H)";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.helpToolStripMenuItem.Text = "帮助主题";
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
            this.toolStripStatusLabel1.Text = "当前用户:";
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
            this.tbxNew.ToolTipText = "新建";
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
            this.tsbEdit.ToolTipText = "修改";
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
            this.tsbDelete.ToolTipText = "删除";
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
            this.tsbRefrush.Text = "刷新";
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
            this.tsbHelp.ToolTipText = "帮助";
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
            this.tsbExit.ToolTipText = "退出";
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
            this.NewToolfrkStripMenuItem.Text = "新建";
            this.NewToolfrkStripMenuItem.Click += new System.EventHandler(this.NewToolfrkStripMenuItem_Click);
            // 
            // ModifyfrkToolStripMenuItem
            // 
            this.ModifyfrkToolStripMenuItem.Name = "ModifyfrkToolStripMenuItem";
            this.ModifyfrkToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.ModifyfrkToolStripMenuItem.Text = "修改";
            this.ModifyfrkToolStripMenuItem.Click += new System.EventHandler(this.ModifyfrkToolStripMenuItem_Click);
            // 
            // DeletefrkToolStripMenuItem
            // 
            this.DeletefrkToolStripMenuItem.Name = "DeletefrkToolStripMenuItem";
            this.DeletefrkToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.DeletefrkToolStripMenuItem.Text = "删除";
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
            this.Text = "工作流配置工具";
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
		/// 应用程序的主入口点。
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
		/// 根据子窗体名字判断窗体是否打开
		/// </summary>
		/// <param name="ParentForm">主窗体</param>
		/// <param name="formtitle">子窗体的标题</param>
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
			// 实现对主窗体中的MDI窗体的层叠操作
			this.LayoutMdi ( MdiLayout.Cascade ) ;

		}

        private void tileHorizontalToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			// 实现对主窗体中的MDI窗体的水平平铺操作
            this.LayoutMdi(MdiLayout.TileHorizontal);

		}

        private void tileVerticalToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			// 实现对主窗体中的MDI窗体的垂直平铺操作
            this.LayoutMdi(MdiLayout.TileVertical);
		}
        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //排列图标
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
        /// 递归装载主窗体框架树
        /// </summary>
        /// <param name="key"></param>
        /// <param name="startNodes"></param>
        public void LoadFrameTreeFromDB(string key, TreeNodeCollection startNodes)
        {
            if (startNodes == null) throw new Exception("调用LoadFrameTreeFromDB失败，startNodes未指定！");

            //string tmpStr = "select * from FrmworkTree where isVisable=1 and FatherCode='" + key + "'";//有效的树信息
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
            //string skinfilename = System.Configuration.ConfigurationSettings.AppSettings["skinfilename"];//皮肤文件名，不含路径
            //skinpathfile = Application.StartupPath + @"\skins\" + skinfilename;
            //if (File.Exists(skinpathfile))
            //{
            //    skinEngine1.SkinFile = skinpathfile;
            //    if (!skinEngine1.Active)
            //        skinEngine1.Active = true;
            //}
      
        }
        /// <summary>
        /// 调用动态加载
        /// </summary>
        /// <param name="e"></param>
        private void actionFramework(FrmworkTreeNode e)
        {


            if (e.NodeType == "Window")//调用窗体
            {
                System.Windows.Forms.Form fromCtrl = null;
                fromCtrl = FormExists(this, e.FormName);//根据窗体名查找窗体
                if ((e.BlankWindows) || (!e.BlankWindows && fromCtrl==null))//允许在新窗口打开或者没有生成窗体的都重新创建窗体
                {
                    string DllPathName = Application.StartupPath + @"\" + e.DllFileName;
                    Object[] objArray = new object[3];//dll中类构造函数必须具有的参数数组
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
                        fromCtrl.Text = e.Text;//设置窗体标题
                    }
                   
                }
                
                else//窗体已经打开，最小化的还原，并显示在最前面
                {
                    if (fromCtrl.WindowState == FormWindowState.Minimized)
                        fromCtrl.WindowState = FormWindowState.Normal;
                    fromCtrl.BringToFront();

                }
            }
            else
                if (e.NodeType == "Function")//调用功能
                {
                    string DllPathName = Application.StartupPath + @"\" + e.DllFileName;
                    Object[] objArray = new object[2];//dll中类构造函数必须具有2个参数
                    objArray[0] = this.UserId;
                    objArray[1] = this.UserName;
                    Object[] objMethodArray = new object[2];//dll中类方法必须具有的参数
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
                    MessageBox.Show  ("执行命令错误，错误代码："+ex.Message.ToString(),"错误");
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
                    MessageBox.Show ("执行命令错误，错误代码：" + ex.Message.ToString(),"错误");
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
            //    WorkDialog.WarningDlg("权限验证通过!", "提示");
            //}
            //else
            //{
            //    WorkDialog.WarningDlg("没有权限!","提示");
            //}
        
        }

        private void NewToolfrkStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowtreeNode != null)
            {

                frmFrmworkTree tmpForm = new frmFrmworkTree("新建", NowtreeNodeId, NowtreeNode);
                tmpForm.ShowDialog();
            }
        }

        private void ModifyfrkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowtreeNode != null)
            {
                frmFrmworkTree tmpForm = new frmFrmworkTree("修改", NowtreeNodeId, NowtreeNode);
                tmpForm.ShowDialog();
            }
         
        }

        private void DeletefrkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowtreeNode == null) return;
            string tmpNodeCaption = NowtreeNode.Text;
            if (NowtreeNode.Nodes.Count > 0)
            {
                MessageBox.Show(tmpNodeCaption+"有子节点,请先删除子节点!","不能删除");
                return;
            }
            if (MessageBox.Show("是否删除 " + tmpNodeCaption + " ,删除后不能恢复?", "询问") == DialogResult.Yes)
            {
                NowtreeNode.DeleteNodeInfo();
                NowtreeNode.Remove();

            }

        }

        private void tsbRefrush_Click(object sender, EventArgs e)
        {
            //刷新
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
            DialogResult result = MsgBox.ShowAskMessageBox("是否退出流程设计工具?");
            if (result == DialogResult.Yes)
            this.Close();
        }

       

       

        

       

      
	}
}
