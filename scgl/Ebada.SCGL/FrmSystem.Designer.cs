namespace Ebada.SCGL
{
    partial class FrmSystem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSystem));
            this.picback = new DevExpress.XtraEditors.PictureEdit();
            this.labAbout = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labbuttom = new DevExpress.XtraEditors.LabelControl();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.listView3 = new System.Windows.Forms.ListView();
            this.labshow = new DevExpress.XtraEditors.LabelControl();
            this.listView1 = new System.Windows.Forms.ListView();
            this.labSet = new System.Windows.Forms.Label();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbctSystem = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.labExit = new System.Windows.Forms.Label();
            this.labdate2 = new DevExpress.XtraEditors.LabelControl();
            this.labdate = new DevExpress.XtraEditors.LabelControl();
            this.labTime = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.picback.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbctSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picback
            // 
            this.picback.Location = new System.Drawing.Point(2, 2);
            this.picback.Name = "picback";
            this.picback.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.picback.Properties.Appearance.Options.UseBackColor = true;
            this.picback.Size = new System.Drawing.Size(906, 526);
            this.picback.TabIndex = 0;
            // 
            // labAbout
            // 
            this.labAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labAbout.BackColor = System.Drawing.SystemColors.Info;
            this.labAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labAbout.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labAbout.Image = ((System.Drawing.Image)(resources.GetObject("labAbout.Image")));
            this.labAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labAbout.Location = new System.Drawing.Point(215, 493);
            this.labAbout.Name = "labAbout";
            this.labAbout.Size = new System.Drawing.Size(26, 17);
            this.labAbout.TabIndex = 26;
            this.labAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labbuttom
            // 
            this.labbuttom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labbuttom.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.labbuttom.Appearance.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labbuttom.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labbuttom.Appearance.Options.UseBackColor = true;
            this.labbuttom.Appearance.Options.UseFont = true;
            this.labbuttom.Appearance.Options.UseForeColor = true;
            this.labbuttom.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labbuttom.Location = new System.Drawing.Point(244, 489);
            this.labbuttom.Name = "labbuttom";
            this.labbuttom.Size = new System.Drawing.Size(644, 27);
            this.labbuttom.TabIndex = 25;
            this.labbuttom.Text = "           ";
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "navBarItem3";
            this.navBarItem3.Name = "navBarItem3";
            // 
            // listView3
            // 
            this.listView3.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listView3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView3.BackColor = System.Drawing.SystemColors.Info;
            this.listView3.BackgroundImageTiled = true;
            this.listView3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.listView3.Location = new System.Drawing.Point(205, 485);
            this.listView3.Margin = new System.Windows.Forms.Padding(429);
            this.listView3.MultiSelect = false;
            this.listView3.Name = "listView3";
            this.listView3.ShowItemToolTips = true;
            this.listView3.Size = new System.Drawing.Size(693, 33);
            this.listView3.TabIndex = 24;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // labshow
            // 
            this.labshow.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labshow.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labshow.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labshow.Appearance.Options.UseBackColor = true;
            this.labshow.Appearance.Options.UseFont = true;
            this.labshow.Appearance.Options.UseForeColor = true;
            this.labshow.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labshow.Location = new System.Drawing.Point(12, 8);
            this.labshow.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labshow.Name = "labshow";
            this.labshow.Size = new System.Drawing.Size(84, 12);
            this.labshow.TabIndex = 22;
            this.labshow.Text = "            ";
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.listView1.BackgroundImageTiled = true;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.listView1.Location = new System.Drawing.Point(205, 136);
            this.listView1.Margin = new System.Windows.Forms.Padding(429);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(693, 343);
            this.listView1.TabIndex = 14;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // labSet
            // 
            this.labSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labSet.BackColor = System.Drawing.Color.Transparent;
            this.labSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labSet.Font = new System.Drawing.Font("Tahoma", 8F);
            this.labSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.labSet.Image = global::Ebada.SCGL.Properties.Resources._1;
            this.labSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labSet.Location = new System.Drawing.Point(761, 64);
            this.labSet.Name = "labSet";
            this.labSet.Size = new System.Drawing.Size(54, 20);
            this.labSet.TabIndex = 21;
            this.labSet.Text = "       设置";
            this.labSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labSet.MouseLeave += new System.EventHandler(this.labSet_MouseLeave);
            this.labSet.Click += new System.EventHandler(this.labSet_Click);
            this.labSet.MouseEnter += new System.EventHandler(this.labSet_MouseEnter);
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "navBarItem2";
            this.navBarItem2.Name = "navBarItem2";
            // 
            // nbctSystem
            // 
            this.nbctSystem.ActiveGroup = this.navBarGroup1;
            this.nbctSystem.AllowSelectedLink = true;
            this.nbctSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.nbctSystem.Appearance.Background.BorderColor = System.Drawing.Color.Black;
            this.nbctSystem.Appearance.Background.Options.UseBorderColor = true;
            this.nbctSystem.BackColor = System.Drawing.Color.White;
            this.nbctSystem.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.nbctSystem.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2});
            this.nbctSystem.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem1,
            this.navBarItem2,
            this.navBarItem3});
            this.nbctSystem.Location = new System.Drawing.Point(12, 106);
            this.nbctSystem.LookAndFeel.SkinName = "Money Twins";
            this.nbctSystem.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nbctSystem.Name = "nbctSystem";
            this.nbctSystem.OptionsNavPane.ExpandedWidth = 233;
            this.nbctSystem.OptionsNavPane.ShowExpandButton = false;
            this.nbctSystem.OptionsNavPane.ShowOverflowButton = false;
            this.nbctSystem.Padding = new System.Windows.Forms.Padding(7);
            this.nbctSystem.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.nbctSystem.Size = new System.Drawing.Size(187, 412);
            this.nbctSystem.TabIndex = 17;
            this.nbctSystem.Text = "navBarControl1";
            this.nbctSystem.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("Blue");
            this.nbctSystem.ActiveGroupChanged += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.navBarControl1_ActiveGroupChanged);
            this.nbctSystem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbctSystem_LinkClicked);
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "navBarGroup1";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Small;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "navBarGroup2";
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "navBarItem1";
            this.navBarItem1.Name = "navBarItem1";
            // 
            // labExit
            // 
            this.labExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labExit.BackColor = System.Drawing.Color.Transparent;
            this.labExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labExit.Font = new System.Drawing.Font("Tahoma", 8F);
            this.labExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.labExit.Image = global::Ebada.SCGL.Properties.Resources._2;
            this.labExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labExit.Location = new System.Drawing.Point(814, 64);
            this.labExit.Name = "labExit";
            this.labExit.Size = new System.Drawing.Size(54, 20);
            this.labExit.TabIndex = 20;
            this.labExit.Text = "       退出";
            this.labExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labExit.MouseLeave += new System.EventHandler(this.labExit_MouseLeave);
            this.labExit.Click += new System.EventHandler(this.labExit_Click);
            this.labExit.MouseEnter += new System.EventHandler(this.labExit_MouseEnter);
            // 
            // labdate2
            // 
            this.labdate2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labdate2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labdate2.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labdate2.Appearance.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labdate2.Appearance.Options.UseBackColor = true;
            this.labdate2.Appearance.Options.UseFont = true;
            this.labdate2.Appearance.Options.UseForeColor = true;
            this.labdate2.Appearance.Options.UseTextOptions = true;
            this.labdate2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labdate2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labdate2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labdate2.Location = new System.Drawing.Point(767, 43);
            this.labdate2.Name = "labdate2";
            this.labdate2.Size = new System.Drawing.Size(99, 19);
            this.labdate2.TabIndex = 19;
            this.labdate2.Text = "labelControl1";
            // 
            // labdate
            // 
            this.labdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labdate.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labdate.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labdate.Appearance.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labdate.Appearance.Options.UseBackColor = true;
            this.labdate.Appearance.Options.UseFont = true;
            this.labdate.Appearance.Options.UseForeColor = true;
            this.labdate.Appearance.Options.UseTextOptions = true;
            this.labdate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labdate.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labdate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labdate.Location = new System.Drawing.Point(767, 19);
            this.labdate.Name = "labdate";
            this.labdate.Size = new System.Drawing.Size(99, 19);
            this.labdate.TabIndex = 18;
            this.labdate.Text = "labelControl1";
            // 
            // labTime
            // 
            this.labTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labTime.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labTime.Appearance.Font = new System.Drawing.Font("Arial Black", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTime.Appearance.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labTime.Appearance.Options.UseBackColor = true;
            this.labTime.Appearance.Options.UseFont = true;
            this.labTime.Appearance.Options.UseForeColor = true;
            this.labTime.Appearance.Options.UseTextOptions = true;
            this.labTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labTime.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labTime.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labTime.Location = new System.Drawing.Point(682, 27);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(60, 27);
            this.labTime.TabIndex = 16;
            this.labTime.Text = "time";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureEdit1.Location = new System.Drawing.Point(12, 12);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Menu;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.PictureAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.pictureEdit1.Size = new System.Drawing.Size(886, 88);
            this.pictureEdit1.TabIndex = 15;
            this.pictureEdit1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureEdit1_MouseUp);
            this.pictureEdit1.MouseEnter += new System.EventHandler(this.pictureEdit1_MouseEnter);
            this.pictureEdit1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureEdit1_MouseMove);
            this.pictureEdit1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureEdit1_MouseDown);
            this.pictureEdit1.MouseLeave += new System.EventHandler(this.pictureEdit1_MouseLeave);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Azure;
            this.panelControl1.Appearance.BorderColor = System.Drawing.Color.Black;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseBorderColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl1.Controls.Add(this.labshow);
            this.panelControl1.Location = new System.Drawing.Point(205, 106);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(693, 26);
            this.panelControl1.TabIndex = 27;
            // 
            // FrmSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(910, 530);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labAbout);
            this.Controls.Add(this.labbuttom);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.labSet);
            this.Controls.Add(this.nbctSystem);
            this.Controls.Add(this.labExit);
            this.Controls.Add(this.labdate2);
            this.Controls.Add(this.labdate);
            this.Controls.Add(this.labTime);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.picback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSystem";
            this.Load += new System.EventHandler(this.FrmSystem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picback.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbctSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picback;
        private System.Windows.Forms.Label labAbout;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.LabelControl labbuttom;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private System.Windows.Forms.ListView listView3;
        private DevExpress.XtraEditors.LabelControl labshow;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label labSet;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarControl nbctSystem;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private System.Windows.Forms.Label labExit;
        private DevExpress.XtraEditors.LabelControl labdate2;
        private DevExpress.XtraEditors.LabelControl labdate;
        private DevExpress.XtraEditors.LabelControl labTime;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl1;


    }
}