namespace Ebada.Scgl.Lcgl {
    partial class UCmLPRecord {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCmLPRecord));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btAddfrm = new DevExpress.XtraBars.BarButtonItem();
            this.barView = new DevExpress.XtraBars.BarButtonItem();
            this.btEditfrm = new DevExpress.XtraBars.BarButtonItem();
            this.btDeletefrm = new DevExpress.XtraBars.BarButtonItem();
            this.btRefresh1 = new DevExpress.XtraBars.BarButtonItem();
            this.btFind = new DevExpress.XtraBars.BarButtonItem();
            this.barBack = new DevExpress.XtraBars.BarButtonItem();
            this.barChange = new DevExpress.XtraBars.BarButtonItem();
            this.barSus = new DevExpress.XtraBars.BarButtonItem();
            this.barReChange = new DevExpress.XtraBars.BarButtonItem();
            this.btReExport = new DevExpress.XtraBars.BarButtonItem();
            this.btClose = new DevExpress.XtraBars.BarButtonItem();
            this.barCopy = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bsItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btExport = new DevExpress.XtraBars.BarSubItem();
            this.barReExport = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageList1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btAddfrm,
            this.btEditfrm,
            this.btDeletefrm,
            this.btFind,
            this.btRefresh1,
            this.btClose,
            this.bsItem1,
            this.btExport,
            this.barBack,
            this.barChange,
            this.barSus,
            this.barReExport,
            this.btReExport,
            this.barReChange,
            this.barView,
            this.barCopy});
            this.barManager1.MaxItemId = 24;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btAddfrm),
            new DevExpress.XtraBars.LinkPersistInfo(this.barView),
            new DevExpress.XtraBars.LinkPersistInfo(this.btEditfrm),
            new DevExpress.XtraBars.LinkPersistInfo(this.btDeletefrm),
            new DevExpress.XtraBars.LinkPersistInfo(this.btRefresh1),
            new DevExpress.XtraBars.LinkPersistInfo(this.btFind, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBack, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barChange, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSus, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barReChange, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btReExport, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btClose, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCopy)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // btAddfrm
            // 
            this.btAddfrm.Caption = "新建";
            this.btAddfrm.Id = 0;
            this.btAddfrm.ImageIndex = 6;
            this.btAddfrm.Name = "btAddfrm";
            this.btAddfrm.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btAddfrm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btAddfrm_ItemClick);
            // 
            // barView
            // 
            this.barView.Caption = "全程跟踪";
            this.barView.Id = 20;
            this.barView.ImageIndex = 1;
            this.barView.Name = "barView";
            this.barView.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barView.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barView_ItemClick);
            // 
            // btEditfrm
            // 
            this.btEditfrm.Caption = "修改";
            this.btEditfrm.Id = 1;
            this.btEditfrm.ImageIndex = 1;
            this.btEditfrm.Name = "btEditfrm";
            this.btEditfrm.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btEditfrm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btEditfrm_ItemClick);
            // 
            // btDeletefrm
            // 
            this.btDeletefrm.Caption = "删除";
            this.btDeletefrm.Id = 2;
            this.btDeletefrm.ImageIndex = 12;
            this.btDeletefrm.Name = "btDeletefrm";
            this.btDeletefrm.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btDeletefrm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btDeletefrm_ItemClick);
            // 
            // btRefresh1
            // 
            this.btRefresh1.Caption = "刷新";
            this.btRefresh1.Id = 4;
            this.btRefresh1.ImageIndex = 9;
            this.btRefresh1.Name = "btRefresh1";
            this.btRefresh1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btRefresh1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btRefresh1_ItemClick);
            // 
            // btFind
            // 
            this.btFind.Caption = "查询";
            this.btFind.Id = 3;
            this.btFind.ImageIndex = 5;
            this.btFind.Name = "btFind";
            this.btFind.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barBack
            // 
            this.barBack.Caption = "退回";
            this.barBack.Id = 14;
            this.barBack.ImageIndex = 9;
            this.barBack.LargeImageIndex = 6;
            this.barBack.Name = "barBack";
            this.barBack.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBack.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBack_ItemClick);
            // 
            // barChange
            // 
            this.barChange.Caption = "变更";
            this.barChange.Id = 15;
            this.barChange.ImageIndex = 1;
            this.barChange.LargeImageIndex = 4;
            this.barChange.Name = "barChange";
            this.barChange.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barChange.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barChange_ItemClick);
            // 
            // barSus
            // 
            this.barSus.Caption = "延期";
            this.barSus.Id = 16;
            this.barSus.ImageIndex = 13;
            this.barSus.LargeImageIndex = 3;
            this.barSus.Name = "barSus";
            this.barSus.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barSus.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSus_ItemClick);
            // 
            // barReChange
            // 
            this.barReChange.Caption = "跳转";
            this.barReChange.Id = 19;
            this.barReChange.ImageIndex = 3;
            this.barReChange.Name = "barReChange";
            this.barReChange.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barReChange.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barReChange_ItemClick);
            // 
            // btReExport
            // 
            this.btReExport.Caption = "导出";
            this.btReExport.Id = 18;
            this.btReExport.ImageIndex = 7;
            this.btReExport.Name = "btReExport";
            this.btReExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btReExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barReExport_ItemClick);
            // 
            // btClose
            // 
            this.btClose.Caption = "关闭";
            this.btClose.Id = 5;
            this.btClose.ImageIndex = 11;
            this.btClose.Name = "btClose";
            this.btClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barCopy
            // 
            this.barCopy.Caption = "拷贝设置";
            this.barCopy.Id = 23;
            this.barCopy.ImageIndex = 1;
            this.barCopy.Name = "barCopy";
            this.barCopy.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCopy_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bsItem1)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // bsItem1
            // 
            this.bsItem1.Id = 6;
            this.bsItem1.Name = "bsItem1";
            this.bsItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(868, 25);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 289);
            this.barDockControlBottom.Size = new System.Drawing.Size(868, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 25);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 264);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(868, 25);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 264);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "KSave1.png");
            this.imageList1.Images.SetKeyName(1, "Kedit.png");
            this.imageList1.Images.SetKeyName(2, "Kopen.png");
            this.imageList1.Images.SetKeyName(3, "Koption.png");
            this.imageList1.Images.SetKeyName(4, "KPrint1.png");
            this.imageList1.Images.SetKeyName(5, "find5.png");
            this.imageList1.Images.SetKeyName(6, "add2.png");
            this.imageList1.Images.SetKeyName(7, "ToExcel.bmp");
            this.imageList1.Images.SetKeyName(8, "New.png");
            this.imageList1.Images.SetKeyName(9, "Focus.png");
            this.imageList1.Images.SetKeyName(10, "delete.png");
            this.imageList1.Images.SetKeyName(11, "exit1.png");
            this.imageList1.Images.SetKeyName(12, "toolStripMenuItemCancelApplyRevise.Image.png");
            this.imageList1.Images.SetKeyName(13, "toolStripButtonOKSubmitRevise.Image.png");
            // 
            // btExport
            // 
            this.btExport.Caption = "导出";
            this.btExport.Id = 8;
            this.btExport.ImageIndex = 7;
            this.btExport.Name = "btExport";
            this.btExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btExport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barReExport
            // 
            this.barReExport.Caption = "导出";
            this.barReExport.Id = 17;
            this.barReExport.Name = "barReExport";
            this.barReExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barReExport_ItemClick);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl1.Location = new System.Drawing.Point(0, 25);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.gridControl1.Size = new System.Drawing.Size(868, 264);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.UseIndicatorForSelection = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.MaxLength = 12;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.NullText = "输入密码";
            this.repositoryItemTextEdit1.PasswordChar = '*';
            // 
            // UCmLPRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UCmLPRecord";
            this.Size = new System.Drawing.Size(868, 314);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btAddfrm;
        private DevExpress.XtraBars.BarButtonItem btEditfrm;
        private DevExpress.XtraBars.BarButtonItem btDeletefrm;
        private DevExpress.XtraBars.BarButtonItem btFind;
        private DevExpress.XtraBars.BarButtonItem btRefresh1;
        private DevExpress.XtraBars.BarButtonItem btClose;
        private DevExpress.XtraBars.BarStaticItem bsItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarSubItem btExport;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem barBack;
        private DevExpress.XtraBars.BarButtonItem barChange;
        private DevExpress.XtraBars.BarButtonItem barSus;
        private DevExpress.XtraBars.BarButtonItem barReExport;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarButtonItem btReExport;
        private DevExpress.XtraBars.BarButtonItem barReChange;
        private DevExpress.XtraBars.BarButtonItem barView;
        private DevExpress.XtraBars.BarButtonItem barCopy;
    }
}
