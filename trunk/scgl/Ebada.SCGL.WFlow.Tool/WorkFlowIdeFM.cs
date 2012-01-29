using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data;
using Ebada.Client;



namespace Ebada.SCGL.WFlow.Tool
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class fmWorkFlowIDE : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ImageList toolBarImage;
        public WorkPlace wpClient;
		public string WorkFlowId="";
        public string UserId = "";
        private Panel panel1;
        private Panel plClient;
        private Panel plLeft;
        private TabControl tabControl1;
        private TabPage   tabPage2;
        private TreeView  treeWorkflow;
        private ImageList imglistMain;//操作人账号，用作权限判断。
		public string     UserName="";//操作人姓名，用作显示。
        BaseTreeNode nowTreeNode;
        private ToolStripMenuItem newWftoolStripMenuItem1;
        private ToolStripMenuItem updateWftoolStripMenuItem2;
        private ToolStripMenuItem delWftoolStripMenuItem3;
        public ContextMenuStrip workflowcontextMenuStrip;
        private ToolStripMenuItem newclassToolStripMenuItem;
        private ToolStripMenuItem updateclassToolStripMenuItem;
        private ToolStripMenuItem delclassToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem moveWfclsToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem wfExportToolStripMenuItem;
        private ToolStripMenuItem wfinputToolStripMenuItem;
        private ToolStripMenuItem UsedToolStripMenuItem;
        private ToolStripMenuItem unUsedToolStripMenuItem;
        private Panel panel2;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbReset;
        private ToolStripButton tsbLock;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton tsbStart;
        private ToolStripButton tsbStop;
        private ToolStripButton tsbAlter;
        private ToolStripButton tsbCtrl;
        private ToolStripButton tsbView;
        private ToolStripButton tsbSub;
        private ToolStripButton tsbLine;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbSave;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton tsbLeft;
        private ToolStripButton tsbRight;
        private ToolStripButton tsbTop;
        private ToolStripButton tsbBottom;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbEixt;
        private Panel panel3;
        private Button button1;
        private Splitter splitter1;
        private ToolStripButton tsbParallel;//当前节点
        string            nowTreeNodeId;//当前节点的Id

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        //[STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fmWorkFlowIDE());

        }
        public fmWorkFlowIDE()
        {
            InitializeComponent();
        }

		public  fmWorkFlowIDE(string workFlowId,string userId,string userName)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			
			InitializeComponent();
			WorkFlowId=workFlowId;
			UserId=userId;
			UserName=userName;
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmWorkFlowIDE));
            this.toolBarImage = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.plClient = new System.Windows.Forms.Panel();
            this.plLeft = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeWorkflow = new System.Windows.Forms.TreeView();
            this.workflowcontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newclassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateclassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delclassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.newWftoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.updateWftoolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.delWftoolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.moveWfclsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UsedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unUsedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.wfExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wfinputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imglistMain = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbReset = new System.Windows.Forms.ToolStripButton();
            this.tsbLock = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbStart = new System.Windows.Forms.ToolStripButton();
            this.tsbStop = new System.Windows.Forms.ToolStripButton();
            this.tsbAlter = new System.Windows.Forms.ToolStripButton();
            this.tsbCtrl = new System.Windows.Forms.ToolStripButton();
            this.tsbView = new System.Windows.Forms.ToolStripButton();
            this.tsbSub = new System.Windows.Forms.ToolStripButton();
            this.tsbParallel = new System.Windows.Forms.ToolStripButton();
            this.tsbLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLeft = new System.Windows.Forms.ToolStripButton();
            this.tsbRight = new System.Windows.Forms.ToolStripButton();
            this.tsbTop = new System.Windows.Forms.ToolStripButton();
            this.tsbBottom = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEixt = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.plLeft.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.workflowcontextMenuStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBarImage
            // 
            this.toolBarImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("toolBarImage.ImageStream")));
            this.toolBarImage.TransparentColor = System.Drawing.Color.Transparent;
            this.toolBarImage.Images.SetKeyName(0, "");
            this.toolBarImage.Images.SetKeyName(1, "");
            this.toolBarImage.Images.SetKeyName(2, "");
            this.toolBarImage.Images.SetKeyName(3, "");
            this.toolBarImage.Images.SetKeyName(4, "");
            this.toolBarImage.Images.SetKeyName(5, "");
            this.toolBarImage.Images.SetKeyName(6, "");
            this.toolBarImage.Images.SetKeyName(7, "");
            this.toolBarImage.Images.SetKeyName(8, "");
            this.toolBarImage.Images.SetKeyName(9, "");
            this.toolBarImage.Images.SetKeyName(10, "");
            this.toolBarImage.Images.SetKeyName(11, "");
            this.toolBarImage.Images.SetKeyName(12, "");
            this.toolBarImage.Images.SetKeyName(13, "");
            this.toolBarImage.Images.SetKeyName(14, "");
            this.toolBarImage.Images.SetKeyName(15, "");
            this.toolBarImage.Images.SetKeyName(16, "");
            this.toolBarImage.Images.SetKeyName(17, "");
            this.toolBarImage.Images.SetKeyName(18, "");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.plClient);
            this.panel1.Controls.Add(this.plLeft);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 455);
            this.panel1.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(199, 51);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 404);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(199, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(511, 23);
            this.panel3.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(511, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "图形区";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // plClient
            // 
            this.plClient.AutoScroll = true;
            this.plClient.AutoScrollMinSize = new System.Drawing.Size(5000, 5000);
            this.plClient.BackColor = System.Drawing.Color.White;
            this.plClient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plClient.Location = new System.Drawing.Point(199, 28);
            this.plClient.Name = "plClient";
            this.plClient.Size = new System.Drawing.Size(511, 427);
            this.plClient.TabIndex = 2;
            // 
            // plLeft
            // 
            this.plLeft.Controls.Add(this.tabControl1);
            this.plLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.plLeft.Location = new System.Drawing.Point(0, 28);
            this.plLeft.Name = "plLeft";
            this.plLeft.Size = new System.Drawing.Size(199, 427);
            this.plLeft.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(199, 427);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.treeWorkflow);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(191, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "树";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // treeWorkflow
            // 
            this.treeWorkflow.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.treeWorkflow.ContextMenuStrip = this.workflowcontextMenuStrip;
            this.treeWorkflow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeWorkflow.ImageIndex = 0;
            this.treeWorkflow.ImageList = this.imglistMain;
            this.treeWorkflow.Location = new System.Drawing.Point(3, 3);
            this.treeWorkflow.Name = "treeWorkflow";
            this.treeWorkflow.SelectedImageIndex = 0;
            this.treeWorkflow.Size = new System.Drawing.Size(185, 396);
            this.treeWorkflow.StateImageList = this.imglistMain;
            this.treeWorkflow.TabIndex = 0;
            this.treeWorkflow.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeWorkflow_AfterSelect);
            // 
            // workflowcontextMenuStrip
            // 
            this.workflowcontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newclassToolStripMenuItem,
            this.updateclassToolStripMenuItem,
            this.delclassToolStripMenuItem,
            this.toolStripMenuItem1,
            this.newWftoolStripMenuItem1,
            this.updateWftoolStripMenuItem2,
            this.delWftoolStripMenuItem3,
            this.toolStripMenuItem2,
            this.moveWfclsToolStripMenuItem,
            this.UsedToolStripMenuItem,
            this.unUsedToolStripMenuItem,
            this.toolStripMenuItem3,
            this.wfExportToolStripMenuItem,
            this.wfinputToolStripMenuItem});
            this.workflowcontextMenuStrip.Name = "classcontextMenuStrip";
            this.workflowcontextMenuStrip.Size = new System.Drawing.Size(119, 264);
            // 
            // newclassToolStripMenuItem
            // 
            this.newclassToolStripMenuItem.Name = "newclassToolStripMenuItem";
            this.newclassToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.newclassToolStripMenuItem.Text = "新建分类";
            this.newclassToolStripMenuItem.Click += new System.EventHandler(this.newClassToolStripMenuItem_Click);
            // 
            // updateclassToolStripMenuItem
            // 
            this.updateclassToolStripMenuItem.Name = "updateclassToolStripMenuItem";
            this.updateclassToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.updateclassToolStripMenuItem.Text = "修改分类";
            this.updateclassToolStripMenuItem.Click += new System.EventHandler(this.updateclassToolStripMenuItem_Click);
            // 
            // delclassToolStripMenuItem
            // 
            this.delclassToolStripMenuItem.Name = "delclassToolStripMenuItem";
            this.delclassToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.delclassToolStripMenuItem.Tag = "070102";
            this.delclassToolStripMenuItem.Text = "删除分类";
            this.delclassToolStripMenuItem.Click += new System.EventHandler(this.delclassToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(115, 6);
            // 
            // newWftoolStripMenuItem1
            // 
            this.newWftoolStripMenuItem1.Name = "newWftoolStripMenuItem1";
            this.newWftoolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.newWftoolStripMenuItem1.Text = "新建流程";
            this.newWftoolStripMenuItem1.Click += new System.EventHandler(this.newWftoolStripMenuItem1_Click);
            // 
            // updateWftoolStripMenuItem2
            // 
            this.updateWftoolStripMenuItem2.Name = "updateWftoolStripMenuItem2";
            this.updateWftoolStripMenuItem2.Size = new System.Drawing.Size(118, 22);
            this.updateWftoolStripMenuItem2.Text = "修改流程";
            this.updateWftoolStripMenuItem2.Click += new System.EventHandler(this.updateWftoolStripMenuItem2_Click);
            // 
            // delWftoolStripMenuItem3
            // 
            this.delWftoolStripMenuItem3.Name = "delWftoolStripMenuItem3";
            this.delWftoolStripMenuItem3.Size = new System.Drawing.Size(118, 22);
            this.delWftoolStripMenuItem3.Tag = "070101";
            this.delWftoolStripMenuItem3.Text = "删除流程";
            this.delWftoolStripMenuItem3.Click += new System.EventHandler(this.delWftoolStripMenuItem3_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(115, 6);
            // 
            // moveWfclsToolStripMenuItem
            // 
            this.moveWfclsToolStripMenuItem.Name = "moveWfclsToolStripMenuItem";
            this.moveWfclsToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.moveWfclsToolStripMenuItem.Text = "移动分类";
            this.moveWfclsToolStripMenuItem.Click += new System.EventHandler(this.moveWfclsToolStripMenuItem_Click);
            // 
            // UsedToolStripMenuItem
            // 
            this.UsedToolStripMenuItem.Name = "UsedToolStripMenuItem";
            this.UsedToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.UsedToolStripMenuItem.Text = "启用";
            this.UsedToolStripMenuItem.Click += new System.EventHandler(this.UsedToolStripMenuItem_Click);
            // 
            // unUsedToolStripMenuItem
            // 
            this.unUsedToolStripMenuItem.Name = "unUsedToolStripMenuItem";
            this.unUsedToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.unUsedToolStripMenuItem.Text = "禁用";
            this.unUsedToolStripMenuItem.Click += new System.EventHandler(this.unUsedToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(115, 6);
            // 
            // wfExportToolStripMenuItem
            // 
            this.wfExportToolStripMenuItem.Name = "wfExportToolStripMenuItem";
            this.wfExportToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.wfExportToolStripMenuItem.Text = "流程导出";
            this.wfExportToolStripMenuItem.Click += new System.EventHandler(this.wfExportToolStripMenuItem_Click);
            // 
            // wfinputToolStripMenuItem
            // 
            this.wfinputToolStripMenuItem.Name = "wfinputToolStripMenuItem";
            this.wfinputToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.wfinputToolStripMenuItem.Text = "流程导入";
            this.wfinputToolStripMenuItem.Click += new System.EventHandler(this.wfinputToolStripMenuItem_Click);
            // 
            // imglistMain
            // 
            this.imglistMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglistMain.ImageStream")));
            this.imglistMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imglistMain.Images.SetKeyName(0, "");
            this.imglistMain.Images.SetKeyName(1, "12.bmp");
            this.imglistMain.Images.SetKeyName(2, "03982.ico");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(710, 28);
            this.panel2.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.Enabled = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbReset,
            this.tsbLock,
            this.toolStripSeparator4,
            this.tsbStart,
            this.tsbStop,
            this.tsbAlter,
            this.tsbCtrl,
            this.tsbView,
            this.tsbSub,
            this.tsbParallel,
            this.tsbLine,
            this.toolStripSeparator1,
            this.tsbSave,
            this.toolStripSeparator3,
            this.tsbLeft,
            this.tsbRight,
            this.tsbTop,
            this.tsbBottom,
            this.toolStripSeparator2,
            this.tsbEixt});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.toolStrip1.Size = new System.Drawing.Size(710, 28);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // tsbReset
            // 
            this.tsbReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReset.Image = ((System.Drawing.Image)(resources.GetObject("tsbReset.Image")));
            this.tsbReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReset.Name = "tsbReset";
            this.tsbReset.Size = new System.Drawing.Size(23, 24);
            this.tsbReset.Text = "-2";
            this.tsbReset.ToolTipText = "指针";
            // 
            // tsbLock
            // 
            this.tsbLock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLock.Image = ((System.Drawing.Image)(resources.GetObject("tsbLock.Image")));
            this.tsbLock.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbLock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLock.Name = "tsbLock";
            this.tsbLock.Size = new System.Drawing.Size(23, 24);
            this.tsbLock.Text = "-3";
            this.tsbLock.ToolTipText = "锁定";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbStart
            // 
            this.tsbStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStart.Image = ((System.Drawing.Image)(resources.GetObject("tsbStart.Image")));
            this.tsbStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStart.Name = "tsbStart";
            this.tsbStart.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsbStart.Size = new System.Drawing.Size(26, 24);
            this.tsbStart.Text = "1";
            this.tsbStart.ToolTipText = "启动节点";
            // 
            // tsbStop
            // 
            this.tsbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStop.Image = ((System.Drawing.Image)(resources.GetObject("tsbStop.Image")));
            this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStop.Name = "tsbStop";
            this.tsbStop.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsbStop.Size = new System.Drawing.Size(26, 24);
            this.tsbStop.Text = "2";
            this.tsbStop.ToolTipText = "结束节点";
            // 
            // tsbAlter
            // 
            this.tsbAlter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAlter.Image = ((System.Drawing.Image)(resources.GetObject("tsbAlter.Image")));
            this.tsbAlter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAlter.Name = "tsbAlter";
            this.tsbAlter.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsbAlter.Size = new System.Drawing.Size(26, 24);
            this.tsbAlter.Text = "3";
            this.tsbAlter.ToolTipText = "交互节点";
            this.tsbAlter.Click += new System.EventHandler(this.tsbAlter_Click);
            // 
            // tsbCtrl
            // 
            this.tsbCtrl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCtrl.Image = ((System.Drawing.Image)(resources.GetObject("tsbCtrl.Image")));
            this.tsbCtrl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCtrl.Name = "tsbCtrl";
            this.tsbCtrl.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.tsbCtrl.Size = new System.Drawing.Size(28, 24);
            this.tsbCtrl.Text = "4";
            this.tsbCtrl.ToolTipText = "控制节点";
            // 
            // tsbView
            // 
            this.tsbView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbView.Image = ((System.Drawing.Image)(resources.GetObject("tsbView.Image")));
            this.tsbView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbView.Name = "tsbView";
            this.tsbView.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.tsbView.Size = new System.Drawing.Size(28, 24);
            this.tsbView.Text = "5";
            this.tsbView.ToolTipText = "查看节点";
            // 
            // tsbSub
            // 
            this.tsbSub.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSub.Image = ((System.Drawing.Image)(resources.GetObject("tsbSub.Image")));
            this.tsbSub.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSub.Name = "tsbSub";
            this.tsbSub.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsbSub.Size = new System.Drawing.Size(26, 24);
            this.tsbSub.Text = "6";
            this.tsbSub.ToolTipText = "子流程";
            // 
            // tsbParallel
            // 
            this.tsbParallel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbParallel.Image = ((System.Drawing.Image)(resources.GetObject("tsbParallel.Image")));
            this.tsbParallel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbParallel.Name = "tsbParallel";
            this.tsbParallel.Size = new System.Drawing.Size(24, 24);
            this.tsbParallel.Text = "7";
            // 
            // tsbLine
            // 
            this.tsbLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLine.Image = ((System.Drawing.Image)(resources.GetObject("tsbLine.Image")));
            this.tsbLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLine.Name = "tsbLine";
            this.tsbLine.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsbLine.Size = new System.Drawing.Size(26, 24);
            this.tsbLine.Text = "0";
            this.tsbLine.ToolTipText = "连线";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 24);
            this.tsbSave.Text = "save";
            this.tsbSave.ToolTipText = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbLeft
            // 
            this.tsbLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLeft.Image = ((System.Drawing.Image)(resources.GetObject("tsbLeft.Image")));
            this.tsbLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbLeft.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsbLeft.Name = "tsbLeft";
            this.tsbLeft.Size = new System.Drawing.Size(23, 24);
            this.tsbLeft.Text = "left";
            this.tsbLeft.ToolTipText = "左对齐";
            // 
            // tsbRight
            // 
            this.tsbRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRight.Image = ((System.Drawing.Image)(resources.GetObject("tsbRight.Image")));
            this.tsbRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRight.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsbRight.Name = "tsbRight";
            this.tsbRight.Size = new System.Drawing.Size(23, 24);
            this.tsbRight.Text = "right";
            this.tsbRight.ToolTipText = "右对齐";
            // 
            // tsbTop
            // 
            this.tsbTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTop.Image = ((System.Drawing.Image)(resources.GetObject("tsbTop.Image")));
            this.tsbTop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTop.Name = "tsbTop";
            this.tsbTop.Size = new System.Drawing.Size(23, 24);
            this.tsbTop.Text = "top";
            this.tsbTop.ToolTipText = "上对齐";
            // 
            // tsbBottom
            // 
            this.tsbBottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBottom.Image = ((System.Drawing.Image)(resources.GetObject("tsbBottom.Image")));
            this.tsbBottom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbBottom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBottom.Name = "tsbBottom";
            this.tsbBottom.Size = new System.Drawing.Size(23, 24);
            this.tsbBottom.Text = "bottom";
            this.tsbBottom.ToolTipText = "下对齐";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbEixt
            // 
            this.tsbEixt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEixt.Image = ((System.Drawing.Image)(resources.GetObject("tsbEixt.Image")));
            this.tsbEixt.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEixt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEixt.Name = "tsbEixt";
            this.tsbEixt.Size = new System.Drawing.Size(23, 24);
            this.tsbEixt.Text = "exit";
            this.tsbEixt.ToolTipText = "关闭";
            this.tsbEixt.Click += new System.EventHandler(this.tsbEixt_Click);
            // 
            // fmWorkFlowIDE
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(710, 455);
            this.Controls.Add(this.panel1);
            this.Name = "fmWorkFlowIDE";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "流程图设置";
            this.Load += new System.EventHandler(this.fmWorkFlowIDE_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmWorkFlowIDE_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.plLeft.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.workflowcontextMenuStrip.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
	

		private void fmWorkFlowIDE_Load(object sender, System.EventArgs e)
		{
            //UserId = "admin";
            WorkFlowClassTreeNode.LoadWorkFlowClass("####", treeWorkflow.Nodes);
            treeWorkflow.ExpandAll();
            
			
		}


	
        private void menuEnable(string state)
        {
            if (state == WorkConst.WORKFLOW_CLASS)
            {
                newWftoolStripMenuItem1.Enabled=true;
                updateWftoolStripMenuItem2.Enabled=false;
                delWftoolStripMenuItem3.Enabled=false;
                newclassToolStripMenuItem.Enabled=true;
                updateclassToolStripMenuItem.Enabled=true;
                delclassToolStripMenuItem.Enabled=true;
                wfinputToolStripMenuItem.Enabled = true;
                wfExportToolStripMenuItem.Enabled = false;
                UsedToolStripMenuItem.Enabled = false;
                unUsedToolStripMenuItem.Enabled = false;
                moveWfclsToolStripMenuItem.Enabled = false;
            }
            else
                if (state == WorkConst.WORKFLOW_FLOW)
                {
                    newWftoolStripMenuItem1.Enabled = true;
                    updateWftoolStripMenuItem2.Enabled = true;
                    delWftoolStripMenuItem3.Enabled = true;
                    newclassToolStripMenuItem.Enabled = false;
                    updateclassToolStripMenuItem.Enabled = false;
                    delclassToolStripMenuItem.Enabled = false;
                    wfinputToolStripMenuItem.Enabled = false;
                    wfExportToolStripMenuItem.Enabled = true;
                    moveWfclsToolStripMenuItem.Enabled = true ;
                    UsedToolStripMenuItem.Enabled = (nowTreeNode as WorkFlowTreeNode).Status == "0";
                    unUsedToolStripMenuItem.Enabled =(nowTreeNode as WorkFlowTreeNode).Status == "1"; ;
   
                }
        
        }
        private void treeWorkflow_AfterSelect(object sender, TreeViewEventArgs e)
        {
            nowTreeNode = (BaseTreeNode)treeWorkflow.SelectedNode;
            nowTreeNodeId = nowTreeNode.NodeId;
            menuEnable(nowTreeNode.NodeType);
            if (nowTreeNode.NodeType == WorkConst.WORKFLOW_CLASS)
            {
                nowTreeNode.Nodes.Clear();
                WorkFlowClassTreeNode.LoadWorkFlowClassSelectNode(nowTreeNodeId, nowTreeNode.Nodes);
                WorkFlowTreeNode.LoadWorkFlowSelectNode(nowTreeNodeId, nowTreeNode.Nodes);
            }
            if (nowTreeNode.NodeType == WorkConst.WORKFLOW_FLOW)
            {
                
                if (wpClient != null)
                    wpClient.closeFlow();
                this.plClient.Controls.Clear();
                wpClient = new WorkPlace(nowTreeNodeId, UserId, UserName);
                wpClient.WorkFlowCaption = nowTreeNode.Text;
                wpClient.CanEdit = true;
                wpClient.State = WorkConst.STATE_MOD;
                this.plClient.Controls.Add(wpClient);
                toolStrip1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void newClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmWorkFlowClass tmpWorkFlowClassFm = new fmWorkFlowClass(UserId, UserName, WorkConst.STATE_ADD, nowTreeNodeId, nowTreeNode);
            tmpWorkFlowClassFm.ShowDialog();
        }

        private void newWftoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fmAddWorkFlow tmpWorkFlowFm = new fmAddWorkFlow(UserId,UserName,WorkConst.STATE_ADD,nowTreeNodeId,nowTreeNode);
            tmpWorkFlowFm.ShowDialog();

        }

        private void updateWftoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            fmAddWorkFlow tmpWorkFlowFm = new fmAddWorkFlow(UserId, UserName, WorkConst.STATE_MOD, nowTreeNodeId, nowTreeNode);
            tmpWorkFlowFm.ShowDialog();
        }

       

        private void updateclassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmWorkFlowClass tmpWorkFlowClassFm = new fmWorkFlowClass(UserId, UserName, WorkConst.STATE_MOD, nowTreeNodeId, nowTreeNode);
            tmpWorkFlowClassFm.ShowDialog();
        }

        private void delclassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DesignerHelper.IsPower(UserId, (sender as ToolStripMenuItem).Tag.ToString()) == false) return;
            if (nowTreeNode.Nodes.Count > 0)
            {
                MsgBox.ShowWarningMessageBox ("删除失败,流程分类下面有子分类或者流程不能删除!");
                return;
            }
            if (MsgBox.ShowAskMessageBox("是否删除分类[" + nowTreeNode.Text + "]?删除后不能回复。") == DialogResult.OK)
           {
               WorkFlowClassTreeNode.DeleteSelectClassNode(nowTreeNodeId);
               nowTreeNode.Remove();
           }
        }

        private void delWftoolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (DesignerHelper.IsPower(UserId, (sender as ToolStripMenuItem).Tag.ToString()) == false) return;
            if (MsgBox.ShowAskMessageBox("是否删除流程[" + nowTreeNode.Text + "]? 删除后不能回复。") == DialogResult.OK)
            {
                WorkFlowTreeNode.DeleteSelectWorkflowNode(nowTreeNodeId);
                nowTreeNode.Remove();
            }
        }

        private void wfExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmWorkflowExport f = new fmWorkflowExport(nowTreeNodeId, nowTreeNode.Text);
            f.ShowDialog();
        }

        private void wfinputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fmWorkflowInput f = new fmWorkflowInput(nowTreeNodeId, nowTreeNode.Text);
            //f.ShowDialog();
        }

        private void UsedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkFlowTemplate.SetWorkflowStatus(nowTreeNodeId,"1");
            (nowTreeNode as WorkFlowTreeNode).Status = "1";
        }

        private void unUsedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkFlowTemplate.SetWorkflowStatus(nowTreeNodeId, "0");
            (nowTreeNode as WorkFlowTreeNode).Status = "0";
        }

        private void moveWfclsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmSelectClass f = new fmSelectClass();
            DialogResult dlg= f.ShowDialog();
            if (dlg == DialogResult.OK)
            { 
                WorkFlowTemplate.SetWorkflowClass(nowTreeNodeId,f.workflowClassId);
                nowTreeNode.Remove();
            }
        }
        private void setTsbButton(bool b)
        {
            foreach (ToolStripItem button in toolStrip1.Items)
            {
                if (button is ToolStripButton)
                    (button as ToolStripButton).Checked = b;
            }
        }
        private void setTaskState(string buttonText)
        {
            switch (buttonText)
            {
                case "-1":
                    wpClient.Module = -1;
                    break;
                case "0":
                    wpClient.Module = 0;
                    break;
                case "1":
                    wpClient.Module = 1;
                    break;
                case "2":
                    wpClient.Module = 2;
                    break;
                case "3":
                    wpClient.Module = 3;
                    break;
                case "4":
                    wpClient.Module = 4;
                    break;
                case "5":
                    wpClient.Module = 5;
                    break;
                case "6":
                    wpClient.Module = 6;
                    break;
                case "7":
                    wpClient.Module = 7;
                    break;
                case "left":
                    Dragger dragger = new Dragger(wpClient, wpClient.SelectedItems);
                    dragger.Align(2);
                    dragger = null;
                    wpClient.Module = -2;
                    break;
                case "right":
                    Dragger dragger2 = new Dragger(wpClient, wpClient.SelectedItems);
                    dragger2.Align(3);
                    wpClient.Module = -2;
                
                    break;
                case "top":
                    Dragger dragger3 = new Dragger(wpClient, wpClient.SelectedItems);
                    dragger3.Align(1);
                    wpClient.Module = -2;
                               
                    break;
                case "bottom":
                    Dragger dragger4 = new Dragger(wpClient, wpClient.SelectedItems);
                    dragger4.Align(4);
                    wpClient.Module = -2;
                    break;
                case "exit":
                    this.Close();
                    break;
                case "save":
                    wpClient.SaveWorkFlow();
                    wpClient.Module = -2;
                    break;
            }
        }
        private void setIntoModle()
        {
            wpClient.toolModel = true;
           
        }
        private void setOutModle()
        {
            wpClient.toolModel = false;
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
            ToolStripButton nowToolBtn;
            if (e.ClickedItem != null)
            {
                bool b = e.ClickedItem is ToolStripButton;
                if (b == false) return;
                nowToolBtn = (ToolStripButton)e.ClickedItem;
                if (nowToolBtn.Text == "-2")//指针
                {
                    setTsbButton(false);
                    nowToolBtn.Checked = true;
                    //退出设计模式
                    setOutModle();
                    return;
                }

                if (nowToolBtn.Text != "-3")//不是“加锁”
                {
                    wpClient.LockModel = false ;
                    setTsbButton(false);
                    nowToolBtn.Checked = true;
                    setIntoModle();
                    //进入设计模式
                    wpClient.nowButton = nowToolBtn;
                    setTaskState(nowToolBtn.Text);
                    //设置待画节点类型
                }
                else//加锁状态
                {
                    wpClient.LockModel = true;
                    nowToolBtn.Checked = !nowToolBtn.Checked;
                    if (nowToolBtn.Checked == false)
                    {
                        setTsbButton(false);
                        setOutModle();
                        //退出设计模式
                    }
                }
            }
        }

        private void tbarDrawClient_ButtonClick_1(object sender, ToolBarButtonClickEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void fmWorkFlowIDE_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (nowTreeNode == null) return;
            if (wpClient != null && nowTreeNode.NodeType == WorkConst.WORKFLOW_FLOW)
                wpClient.closeFlow();
        }

        private void tsbEixt_Click(object sender, EventArgs e)
        {
           
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {

        }

        private void tsbAlter_Click(object sender, EventArgs e)
        {

        }

       

	
	}
}
