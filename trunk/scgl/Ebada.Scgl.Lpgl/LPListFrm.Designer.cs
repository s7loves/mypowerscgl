namespace Ebada.Scgl.Lpgl
{
    partial class LPListFrm
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.kind = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btn_Add = new DevExpress.XtraBars.BarSubItem();
            this.add_yzgzp = new DevExpress.XtraBars.BarButtonItem();
            this.add_ezgzp = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Edit = new DevExpress.XtraBars.BarSubItem();
            this.edit_yzgzp = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Del = new DevExpress.XtraBars.BarSubItem();
            this.del_yzgzp = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl1.Location = new System.Drawing.Point(0, 23);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(537, 287);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.kind,
            this.CreateTime,
            this.id});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // kind
            // 
            this.kind.Caption = "票种";
            this.kind.FieldName = "Kind";
            this.kind.Name = "kind";
            this.kind.Visible = true;
            this.kind.VisibleIndex = 0;
            this.kind.Width = 211;
            // 
            // CreateTime
            // 
            this.CreateTime.Caption = "创建时间";
            this.CreateTime.FieldName = "CreateTime";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.Visible = true;
            this.CreateTime.VisibleIndex = 1;
            this.CreateTime.Width = 369;
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "LPID";
            this.id.Name = "id";
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
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_Add,
            this.add_yzgzp,
            this.add_ezgzp,
            this.btn_Edit,
            this.btn_Del,
            this.edit_yzgzp,
            this.del_yzgzp});
            this.barManager1.MaxItemId = 11;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Add),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Edit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Del)});
            this.bar1.Text = "Tools";
            // 
            // btn_Add
            // 
            this.btn_Add.Caption = "增加";
            this.btn_Add.Id = 3;
            this.btn_Add.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.add_yzgzp),
            new DevExpress.XtraBars.LinkPersistInfo(this.add_ezgzp)});
            this.btn_Add.Name = "btn_Add";
            // 
            // add_yzgzp
            // 
            this.add_yzgzp.Caption = "一种工作票";
            this.add_yzgzp.Id = 4;
            this.add_yzgzp.Name = "add_yzgzp";
            this.add_yzgzp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.add_yzgzp_ItemClick);
            // 
            // add_ezgzp
            // 
            this.add_ezgzp.Caption = "二种工作票";
            this.add_ezgzp.Id = 5;
            this.add_ezgzp.Name = "add_ezgzp";
            // 
            // btn_Edit
            // 
            this.btn_Edit.Caption = "修改";
            this.btn_Edit.Id = 6;
            this.btn_Edit.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.edit_yzgzp)});
            this.btn_Edit.Name = "btn_Edit";
            // 
            // edit_yzgzp
            // 
            this.edit_yzgzp.Caption = "一种工作票";
            this.edit_yzgzp.Id = 9;
            this.edit_yzgzp.Name = "edit_yzgzp";
            this.edit_yzgzp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.edit_yzgzp_ItemClick);
            // 
            // btn_Del
            // 
            this.btn_Del.Caption = "删除";
            this.btn_Del.Id = 8;
            this.btn_Del.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.del_yzgzp)});
            this.btn_Del.Name = "btn_Del";
            // 
            // del_yzgzp
            // 
            this.del_yzgzp.Caption = "一种工作票";
            this.del_yzgzp.Id = 10;
            this.del_yzgzp.Name = "del_yzgzp";
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
            this.barDockControlTop.Size = new System.Drawing.Size(537, 23);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 310);
            this.barDockControlBottom.Size = new System.Drawing.Size(537, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 23);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 287);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(537, 23);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 287);
            // 
            // LPListFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 332);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "LPListFrm";
            this.Text = "两票列表";
            this.Load += new System.EventHandler(this.LPListFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem btn_Add;
        private DevExpress.XtraBars.BarButtonItem add_yzgzp;
        private DevExpress.XtraBars.BarButtonItem add_ezgzp;
        private DevExpress.XtraGrid.Columns.GridColumn kind;
        private DevExpress.XtraGrid.Columns.GridColumn CreateTime;
        private DevExpress.XtraBars.BarSubItem btn_Edit;
        private DevExpress.XtraBars.BarButtonItem edit_yzgzp;
        private DevExpress.XtraBars.BarSubItem btn_Del;
        private DevExpress.XtraBars.BarButtonItem del_yzgzp;
        private DevExpress.XtraGrid.Columns.GridColumn id;
    }
}