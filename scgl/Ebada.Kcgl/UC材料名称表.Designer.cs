﻿namespace Ebada.Kcgl
{
    partial class UC材料名称
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC材料名称));
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btAdd2 = new DevExpress.XtraBars.BarButtonItem();
            this.btEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btFind = new DevExpress.XtraBars.BarButtonItem();
            this.btExport = new DevExpress.XtraBars.BarButtonItem();
            this.btClose = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btOK = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
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
            this.treeList1.Size = new System.Drawing.Size(624, 349);
            this.treeList1.TabIndex = 0;
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
            this.btExport,
            this.btFind,
            this.btOK,
            this.barStaticItem1});
            this.barManager1.MaxItemId = 12;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btEdit, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btFind, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btExport, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btClose, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btOK)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // btAdd
            // 
            this.btAdd.Caption = "增加同级";
            this.btAdd.Description = "增加同级材料";
            this.btAdd.Id = 0;
            this.btAdd.ImageIndex = 6;
            this.btAdd.Name = "btAdd";
            this.btAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btAdd2
            // 
            this.btAdd2.Caption = "增加下级";
            this.btAdd2.Description = "增加下级材料";
            this.btAdd2.Id = 1;
            this.btAdd2.ImageIndex = 13;
            this.btAdd2.Name = "btAdd2";
            this.btAdd2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btEdit
            // 
            this.btEdit.Caption = "修改";
            this.btEdit.Id = 2;
            this.btEdit.ImageIndex = 1;
            this.btEdit.Name = "btEdit";
            this.btEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
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
            this.btRefresh.Caption = "刷新";
            this.btRefresh.Id = 6;
            this.btRefresh.ImageIndex = 9;
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btFind
            // 
            this.btFind.Caption = "查询";
            this.btFind.Id = 9;
            this.btFind.ImageIndex = 5;
            this.btFind.Name = "btFind";
            this.btFind.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btExport
            // 
            this.btExport.Caption = "导出";
            this.btExport.Id = 8;
            this.btExport.ImageIndex = 7;
            this.btExport.Name = "btExport";
            this.btExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
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
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1)});
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
            this.barDockControlTop.Size = new System.Drawing.Size(624, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 375);
            this.barDockControlBottom.Size = new System.Drawing.Size(624, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 349);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(624, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 349);
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
            this.imageList1.Images.SetKeyName(14, "OK.png");
            // 
            // btOK
            // 
            this.btOK.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btOK.Caption = "确认";
            this.btOK.Id = 10;
            this.btOK.ImageIndex = 14;
            this.btOK.Name = "btOK";
            this.btOK.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btOK.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Id = 11;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // UC材料名称
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UC材料名称";
            this.Size = new System.Drawing.Size(624, 400);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btExport;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarButtonItem btFind;
        private DevExpress.XtraBars.BarButtonItem btOK;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
    }
}
