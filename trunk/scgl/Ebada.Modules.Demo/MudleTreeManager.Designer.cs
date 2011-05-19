namespace sample1
{
    partial class MudleTreeManager 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MudleTreeManager));
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colModuName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colModuTypes = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAssemblyFileName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.MethodName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSequence = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btAdd2 = new DevExpress.XtraBars.BarButtonItem();
            this.btEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.mModuleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mModuleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.AllowDrop = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colModuName,
            this.colModuTypes,
            this.colAssemblyFileName,
            this.MethodName,
            this.colSequence,
            this.colDescription,
            this.treeListColumn1});
            this.treeList1.DataSource = this.bindingSource1;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.KeyFieldName = "Modu_ID";
            this.treeList1.Location = new System.Drawing.Point(0, 26);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.DragNodes = true;
            this.treeList1.Size = new System.Drawing.Size(589, 393);
            this.treeList1.TabIndex = 0;
            // 
            // colModuName
            // 
            this.colModuName.Caption = "模块名";
            this.colModuName.FieldName = "ModuName";
            this.colModuName.Name = "colModuName";
            this.colModuName.Visible = true;
            this.colModuName.VisibleIndex = 0;
            this.colModuName.Width = 100;
            // 
            // colModuTypes
            // 
            this.colModuTypes.Caption = "模块对象";
            this.colModuTypes.FieldName = "ModuTypes";
            this.colModuTypes.Name = "colModuTypes";
            this.colModuTypes.Visible = true;
            this.colModuTypes.VisibleIndex = 1;
            this.colModuTypes.Width = 100;
            // 
            // colAssemblyFileName
            // 
            this.colAssemblyFileName.Caption = "程序集名";
            this.colAssemblyFileName.FieldName = "AssemblyFileName";
            this.colAssemblyFileName.Name = "colAssemblyFileName";
            this.colAssemblyFileName.Visible = true;
            this.colAssemblyFileName.VisibleIndex = 2;
            this.colAssemblyFileName.Width = 63;
            // 
            // MethodName
            // 
            this.MethodName.Caption = "方法名";
            this.MethodName.FieldName = "MethodName";
            this.MethodName.Name = "MethodName";
            this.MethodName.Visible = true;
            this.MethodName.VisibleIndex = 5;
            // 
            // colSequence
            // 
            this.colSequence.Caption = "显示顺序";
            this.colSequence.FieldName = "Sequence";
            this.colSequence.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSequence.Name = "colSequence";
            this.colSequence.Visible = true;
            this.colSequence.VisibleIndex = 3;
            this.colSequence.Width = 30;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "描述";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 4;
            this.colDescription.Width = 62;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "图标Index";
            this.treeListColumn1.FieldName = "IconName";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 6;
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
            this.barManager1.Images = this.imageCollection2;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btAdd,
            this.btAdd2,
            this.btEdit,
            this.btDelete,
            this.barButtonItem1,
            this.btRefresh});
            this.barManager1.MaxItemId = 7;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btAdd2),
            new DevExpress.XtraBars.LinkPersistInfo(this.btEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.btRefresh)});
            this.bar1.Text = "Tools";
            // 
            // btAdd
            // 
            this.btAdd.Caption = "增加模块";
            this.btAdd.Description = "增加同级模块";
            this.btAdd.Id = 0;
            this.btAdd.ImageIndex = 6;
            this.btAdd.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btAdd.Name = "btAdd";
            this.btAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btAdd2
            // 
            this.btAdd2.Caption = "增加子模块";
            this.btAdd2.Description = "增加下级模块";
            this.btAdd2.Id = 1;
            this.btAdd2.ImageIndex = 0;
            this.btAdd2.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M));
            this.btAdd2.Name = "btAdd2";
            this.btAdd2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btAdd2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btAdd2_ItemClick);
            // 
            // btEdit
            // 
            this.btEdit.Caption = "修改";
            this.btEdit.Id = 2;
            this.btEdit.ImageIndex = 27;
            this.btEdit.Name = "btEdit";
            this.btEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btEdit_ItemClick);
            // 
            // btDelete
            // 
            this.btDelete.Caption = "删除";
            this.btDelete.Id = 3;
            this.btDelete.ImageIndex = 13;
            this.btDelete.Name = "btDelete";
            this.btDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btDelete_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "|";
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btRefresh
            // 
            this.btRefresh.Caption = "刷新";
            this.btRefresh.Id = 6;
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btRefresh_ItemClick);
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
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(589, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 419);
            this.barDockControlBottom.Size = new System.Drawing.Size(589, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 393);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(589, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 393);
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            // 
            // mModuleBindingSource
            // 
            this.mModuleBindingSource.DataSource = typeof(Ebada.Platform.Model.mModule);
            // 
            // MudleTreeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MudleTreeManager";
            this.Size = new System.Drawing.Size(589, 441);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mModuleBindingSource)).EndInit();
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
        private DevExpress.Utils.ImageCollection imageCollection2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colModuName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colModuTypes;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAssemblyFileName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSequence;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private System.Windows.Forms.BindingSource mModuleBindingSource;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btRefresh;
        private DevExpress.XtraTreeList.Columns.TreeListColumn MethodName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
    }
}
