namespace Ebada.Scgl.Yxgl
{
    partial class UCPJ_17
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPJ_17));
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.typeCBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.typeLookUp = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btGdsList = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btXlList = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btAdd2 = new DevExpress.XtraBars.BarButtonItem();
            this.btReAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barCreat = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btFind = new DevExpress.XtraBars.BarButtonItem();
            this.btExport0 = new DevExpress.XtraBars.BarButtonItem();
            this.btClose = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeCBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeLookUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.AllowDrop = true;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 26);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treeList1.OptionsBehavior.DragNodes = true;
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsBehavior.EnableFiltering = true;
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.typeCBox,
            this.typeLookUp});
            this.treeList1.Size = new System.Drawing.Size(980, 326);
            this.treeList1.TabIndex = 0;
            // 
            // typeCBox
            // 
            this.typeCBox.AutoHeight = false;
            this.typeCBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.typeCBox.Name = "typeCBox";
            // 
            // typeLookUp
            // 
            this.typeLookUp.AutoHeight = false;
            this.typeLookUp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.typeLookUp.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name3", "Name3", 61, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name4", "Name4", 48, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.typeLookUp.Name = "typeLookUp";
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
            this.btAdd,
            this.btAdd2,
            this.btEdit,
            this.btDelete,
            this.btRefresh,
            this.btClose,
            this.btExport0,
            this.btFind,
            this.btGdsList,
            this.btReAdd,
            this.btXlList,
            this.barCreat,
            this.barButtonItem1});
            this.barManager1.MaxItemId = 16;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2});
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.btGdsList, "", false, true, true, 114),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.btXlList, "", false, true, true, 97),
            new DevExpress.XtraBars.LinkPersistInfo(this.btAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btAdd2),
            new DevExpress.XtraBars.LinkPersistInfo(this.btReAdd, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCreat, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btEdit, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btFind, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btExport0, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btClose, true)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.Text = "Tools";
            // 
            // btGdsList
            // 
            this.btGdsList.Caption = "barEditItem1";
            this.btGdsList.Edit = this.repositoryItemLookUpEdit1;
            this.btGdsList.Id = 10;
            this.btGdsList.Name = "btGdsList";
            this.btGdsList.EditValueChanged += new System.EventHandler(this.btGDS_EditValueChanged);
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "请选择供电所";
            // 
            // btXlList
            // 
            this.btXlList.Caption = "barEditItem1";
            this.btXlList.Edit = this.repositoryItemLookUpEdit2;
            this.btXlList.Id = 13;
            this.btXlList.Name = "btXlList";
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LineCode", "Name5", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LineName", "线路名称")});
            this.repositoryItemLookUpEdit2.DisplayMember = "LineName";
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.NullText = "请选择线路";
            // 
            // btAdd
            // 
            this.btAdd.Caption = "增加同级";
            this.btAdd.Description = "增加同级模块";
            this.btAdd.Id = 0;
            this.btAdd.ImageIndex = 6;
            this.btAdd.Name = "btAdd";
            this.btAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btAdd2
            // 
            this.btAdd2.Caption = "增加下级";
            this.btAdd2.Description = "增加下级模块";
            this.btAdd2.Id = 1;
            this.btAdd2.ImageIndex = 13;
            this.btAdd2.Name = "btAdd2";
            this.btAdd2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btAdd2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btReAdd
            // 
            this.btReAdd.Caption = "添加";
            this.btReAdd.Id = 11;
            this.btReAdd.ImageIndex = 8;
            this.btReAdd.Name = "btReAdd";
            this.btReAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btReAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btReAdd_ItemClick);
            // 
            // barCreat
            // 
            this.barCreat.Caption = "生成条图";
            this.barCreat.Id = 14;
            this.barCreat.ImageIndex = 3;
            this.barCreat.Name = "barCreat";
            this.barCreat.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barCreat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCreat_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "打开";
            this.barButtonItem1.Id = 15;
            this.barButtonItem1.ImageIndex = 2;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btEdit
            // 
            this.btEdit.Caption = "修改";
            this.btEdit.Id = 2;
            this.btEdit.ImageIndex = 1;
            this.btEdit.Name = "btEdit";
            this.btEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btDelete
            // 
            this.btDelete.Caption = "删除";
            this.btDelete.Id = 3;
            this.btDelete.ImageIndex = 12;
            this.btDelete.Name = "btDelete";
            this.btDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btRefresh
            // 
            this.btRefresh.Caption = "检索";
            this.btRefresh.Description = "加载数据";
            this.btRefresh.Id = 6;
            this.btRefresh.ImageIndex = 9;
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btFind
            // 
            this.btFind.Caption = "查询";
            this.btFind.Id = 9;
            this.btFind.ImageIndex = 5;
            this.btFind.Name = "btFind";
            this.btFind.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btFind.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btExport0
            // 
            this.btExport0.Caption = "导出";
            this.btExport0.Id = 8;
            this.btExport0.ImageIndex = 7;
            this.btExport0.Name = "btExport0";
            this.btExport0.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btExport0.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btExport_ItemClick);
            // 
            // btClose
            // 
            this.btClose.Caption = "关闭";
            this.btClose.Id = 7;
            this.btClose.ImageIndex = 11;
            this.btClose.Name = "btClose";
            this.btClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            this.bar3.Visible = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(980, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 352);
            this.barDockControlBottom.Size = new System.Drawing.Size(980, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 326);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(980, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 326);
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
            // UCPJ_17
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UCPJ_17";
            this.Size = new System.Drawing.Size(980, 374);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeCBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeLookUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btAdd;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btAdd2;
        private DevExpress.XtraBars.BarButtonItem btEdit;
        private DevExpress.XtraBars.BarButtonItem btDelete;
        private DevExpress.XtraBars.BarButtonItem btRefresh;
        private DevExpress.XtraBars.BarButtonItem btClose;
        private DevExpress.XtraBars.BarButtonItem btExport0;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarButtonItem btFind;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox typeCBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit typeLookUp;
        private DevExpress.XtraBars.BarEditItem btGdsList;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraBars.BarButtonItem btReAdd;
        private DevExpress.XtraBars.BarEditItem btXlList;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraBars.BarButtonItem barCreat;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}
