namespace TLMapPlatform
{
    partial class UCMapLayer
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCMapLayer));
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.controlNavigator1 = new DevExpress.XtraEditors.ControlNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.BestFitVisibleOnly = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4});
            this.treeList1.ColumnsImageList = this.imageCollection1;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.ImmediateEditor = false;
            this.treeList1.OptionsSelection.InvertSelection = true;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowFocusedFrame = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowRoot = false;
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageComboBox2,
            this.repositoryItemImageComboBox3});
            this.treeList1.Size = new System.Drawing.Size(198, 151);
            this.treeList1.TabIndex = 0;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseClick);
            this.treeList1.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeList1_CellValueChanging);
            this.treeList1.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeList1_CellValueChanged);
            this.treeList1.NodeChanged += new DevExpress.XtraTreeList.NodeChangedEventHandler(this.treeList1_NodeChanged);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "显示";
            this.treeListColumn1.ColumnEdit = this.repositoryItemImageComboBox1;
            this.treeListColumn1.FieldName = "显示";
            this.treeListColumn1.ImageIndex = 0;
            this.treeListColumn1.MinWidth = 22;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowFocus = false;
            this.treeListColumn1.OptionsColumn.AllowMove = false;
            this.treeListColumn1.OptionsColumn.AllowSize = false;
            this.treeListColumn1.OptionsColumn.AllowSort = false;
            this.treeListColumn1.OptionsColumn.FixedWidth = true;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 22;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "0", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "1", 0)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.SmallImages = this.imageCollection1;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "view_16x16.bmp");
            this.imageCollection1.Images.SetKeyName(1, "edit_16x16.bmp");
            this.imageCollection1.Images.SetKeyName(2, "table_(edit)_16x16.bmp");
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "编辑";
            this.treeListColumn2.ColumnEdit = this.repositoryItemImageComboBox2;
            this.treeListColumn2.FieldName = "编辑";
            this.treeListColumn2.MinWidth = 22;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.OptionsColumn.AllowFocus = false;
            this.treeListColumn2.OptionsColumn.AllowMove = false;
            this.treeListColumn2.OptionsColumn.AllowSize = false;
            this.treeListColumn2.OptionsColumn.FixedWidth = true;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 22;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "0", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "1", 1)});
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            this.repositoryItemImageComboBox2.SmallImages = this.imageCollection1;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "层名";
            this.treeListColumn3.FieldName = "层";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.AllowSort = false;
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "图层属性...";
            this.treeListColumn4.ColumnEdit = this.repositoryItemImageComboBox3;
            this.treeListColumn4.FieldName = "layer";
            this.treeListColumn4.MinWidth = 22;
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.OptionsColumn.AllowEdit = false;
            this.treeListColumn4.OptionsColumn.AllowFocus = false;
            this.treeListColumn4.OptionsColumn.AllowMove = false;
            this.treeListColumn4.OptionsColumn.AllowSize = false;
            this.treeListColumn4.OptionsColumn.AllowSort = false;
            this.treeListColumn4.OptionsColumn.FixedWidth = true;
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 3;
            this.treeListColumn4.Width = 22;
            // 
            // repositoryItemImageComboBox3
            // 
            this.repositoryItemImageComboBox3.AutoHeight = false;
            this.repositoryItemImageComboBox3.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox3.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "1", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "0", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", null, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "", -1)});
            this.repositoryItemImageComboBox3.Name = "repositoryItemImageComboBox3";
            this.repositoryItemImageComboBox3.SmallImages = this.imageCollection1;
            // 
            // controlNavigator1
            // 
            this.controlNavigator1.Buttons.Append.Hint = "增加";
            this.controlNavigator1.Buttons.Append.Tag = "Add";
            this.controlNavigator1.Buttons.CancelEdit.Visible = false;
            this.controlNavigator1.Buttons.Edit.Hint = "修改";
            this.controlNavigator1.Buttons.Edit.Tag = "Edit";
            this.controlNavigator1.Buttons.EndEdit.Hint = "确认";
            this.controlNavigator1.Buttons.First.Visible = false;
            this.controlNavigator1.Buttons.Last.Visible = false;
            this.controlNavigator1.Buttons.Next.Visible = false;
            this.controlNavigator1.Buttons.NextPage.Visible = false;
            this.controlNavigator1.Buttons.Prev.Visible = false;
            this.controlNavigator1.Buttons.PrevPage.Visible = false;
            this.controlNavigator1.Buttons.Remove.Hint = "删除";
            this.controlNavigator1.Buttons.Remove.Tag = "Del2";
            this.controlNavigator1.Buttons.Remove.Visible = false;
            this.controlNavigator1.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 10, true, true, "删除", "Del"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 14, true, true, "上移", "Up"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 17, true, true, "下移", "Down")});
            this.controlNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator1.Location = new System.Drawing.Point(0, 151);
            this.controlNavigator1.Name = "controlNavigator1";
            this.controlNavigator1.NavigatableControl = this.treeList1;
            this.controlNavigator1.ShowToolTips = true;
            this.controlNavigator1.Size = new System.Drawing.Size(198, 25);
            this.controlNavigator1.TabIndex = 3;
            this.controlNavigator1.Text = "controlNavigator1";
            this.controlNavigator1.Click += new System.EventHandler(this.controlNavigator1_Click);
            this.controlNavigator1.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.controlNavigator1_ButtonClick);
            // 
            // UCMapLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.controlNavigator1);
            this.Name = "UCMapLayer";
            this.Size = new System.Drawing.Size(198, 176);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox3;
    }
}
