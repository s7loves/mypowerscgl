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
            this.层 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.显示 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.编辑 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.Layer = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.controlNavigator1 = new DevExpress.XtraEditors.ControlNavigator();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.checkxlmc = new DevExpress.XtraEditors.CheckEdit();
            this.checkgth = new DevExpress.XtraEditors.CheckEdit();
            this.checkbyqrl = new DevExpress.XtraEditors.CheckEdit();
            this.checkkg = new DevExpress.XtraEditors.CheckEdit();
            this.checkbyq = new DevExpress.XtraEditors.CheckEdit();
            this.checkgt = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkxlmc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkgth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkbyqrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkkg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkbyq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkgt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.BestFitVisibleOnly = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.层,
            this.显示,
            this.编辑,
            this.Layer});
            this.treeList1.ColumnsImageList = this.imageCollection1;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 25);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.ImmediateEditor = false;
            this.treeList1.OptionsSelection.InvertSelection = true;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageComboBox2,
            this.repositoryItemImageComboBox3});
            this.treeList1.Size = new System.Drawing.Size(198, 131);
            this.treeList1.TabIndex = 0;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseClick);
            this.treeList1.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeList1_CellValueChanging);
            this.treeList1.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeList1_CellValueChanged);
            this.treeList1.NodeChanged += new DevExpress.XtraTreeList.NodeChangedEventHandler(this.treeList1_NodeChanged);
            // 
            // 层
            // 
            this.层.Caption = "层名";
            this.层.FieldName = "层";
            this.层.Name = "层";
            this.层.OptionsColumn.AllowEdit = false;
            this.层.OptionsColumn.AllowMove = false;
            this.层.OptionsColumn.AllowSort = false;
            this.层.Visible = true;
            this.层.VisibleIndex = 0;
            this.层.Width = 125;
            // 
            // 显示
            // 
            this.显示.ColumnEdit = this.repositoryItemImageComboBox1;
            this.显示.FieldName = "显示";
            this.显示.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.显示.ImageIndex = 0;
            this.显示.MinWidth = 22;
            this.显示.Name = "显示";
            this.显示.OptionsColumn.AllowEdit = false;
            this.显示.OptionsColumn.AllowFocus = false;
            this.显示.OptionsColumn.AllowMove = false;
            this.显示.OptionsColumn.AllowSize = false;
            this.显示.OptionsColumn.AllowSort = false;
            this.显示.OptionsColumn.FixedWidth = true;
            this.显示.Visible = true;
            this.显示.VisibleIndex = 1;
            this.显示.Width = 26;
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
            // 编辑
            // 
            this.编辑.ColumnEdit = this.repositoryItemImageComboBox2;
            this.编辑.FieldName = "编辑";
            this.编辑.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.编辑.ImageIndex = 1;
            this.编辑.MinWidth = 22;
            this.编辑.Name = "编辑";
            this.编辑.OptionsColumn.AllowEdit = false;
            this.编辑.OptionsColumn.AllowFocus = false;
            this.编辑.OptionsColumn.AllowMove = false;
            this.编辑.OptionsColumn.AllowSize = false;
            this.编辑.OptionsColumn.FixedWidth = true;
            this.编辑.Visible = true;
            this.编辑.VisibleIndex = 2;
            this.编辑.Width = 26;
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
            // Layer
            // 
            this.Layer.ColumnEdit = this.repositoryItemImageComboBox3;
            this.Layer.FieldName = "Layer";
            this.Layer.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.Layer.ImageIndex = 2;
            this.Layer.MinWidth = 22;
            this.Layer.Name = "Layer";
            this.Layer.OptionsColumn.AllowEdit = false;
            this.Layer.OptionsColumn.AllowFocus = false;
            this.Layer.OptionsColumn.AllowMove = false;
            this.Layer.OptionsColumn.AllowSize = false;
            this.Layer.OptionsColumn.AllowSort = false;
            this.Layer.OptionsColumn.FixedWidth = true;
            this.Layer.Visible = true;
            this.Layer.VisibleIndex = 3;
            this.Layer.Width = 26;
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
            this.controlNavigator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlNavigator1.Location = new System.Drawing.Point(0, 0);
            this.controlNavigator1.Name = "controlNavigator1";
            this.controlNavigator1.NavigatableControl = this.treeList1;
            this.controlNavigator1.ShowToolTips = true;
            this.controlNavigator1.Size = new System.Drawing.Size(198, 25);
            this.controlNavigator1.TabIndex = 3;
            this.controlNavigator1.Text = "controlNavigator1";
            this.controlNavigator1.Click += new System.EventHandler(this.controlNavigator1_Click);
            this.controlNavigator1.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.controlNavigator1_ButtonClick);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.checkxlmc);
            this.groupControl1.Controls.Add(this.checkgth);
            this.groupControl1.Controls.Add(this.checkbyqrl);
            this.groupControl1.Controls.Add(this.checkkg);
            this.groupControl1.Controls.Add(this.checkbyq);
            this.groupControl1.Controls.Add(this.checkgt);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 156);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(198, 116);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "图层信息";
            // 
            // checkxlmc
            // 
            this.checkxlmc.Location = new System.Drawing.Point(24, 88);
            this.checkxlmc.Name = "checkxlmc";
            this.checkxlmc.Properties.Caption = "线路名称";
            this.checkxlmc.Size = new System.Drawing.Size(86, 19);
            this.checkxlmc.TabIndex = 2;
            this.checkxlmc.CheckedChanged += new System.EventHandler(this.checkxlmc_CheckedChanged);
            // 
            // checkgth
            // 
            this.checkgth.Location = new System.Drawing.Point(91, 34);
            this.checkgth.Name = "checkgth";
            this.checkgth.Properties.Caption = "杆塔号";
            this.checkgth.Size = new System.Drawing.Size(65, 19);
            this.checkgth.TabIndex = 1;
            this.checkgth.CheckedChanged += new System.EventHandler(this.checkgth_CheckedChanged);
            // 
            // checkbyqrl
            // 
            this.checkbyqrl.EditValue = true;
            this.checkbyqrl.Location = new System.Drawing.Point(91, 51);
            this.checkbyqrl.Name = "checkbyqrl";
            this.checkbyqrl.Properties.Caption = "变压器容器";
            this.checkbyqrl.Size = new System.Drawing.Size(83, 19);
            this.checkbyqrl.TabIndex = 0;
            this.checkbyqrl.CheckedChanged += new System.EventHandler(this.checkbyqrl_CheckedChanged);
            // 
            // checkkg
            // 
            this.checkkg.Location = new System.Drawing.Point(24, 68);
            this.checkkg.Name = "checkkg";
            this.checkkg.Properties.Caption = "开关";
            this.checkkg.Size = new System.Drawing.Size(61, 19);
            this.checkkg.TabIndex = 0;
            this.checkkg.CheckedChanged += new System.EventHandler(this.checkkg_CheckedChanged);
            // 
            // checkbyq
            // 
            this.checkbyq.EditValue = true;
            this.checkbyq.Location = new System.Drawing.Point(24, 50);
            this.checkbyq.Name = "checkbyq";
            this.checkbyq.Properties.Caption = "变压器";
            this.checkbyq.Size = new System.Drawing.Size(61, 19);
            this.checkbyq.TabIndex = 0;
            this.checkbyq.CheckedChanged += new System.EventHandler(this.checkbyq_CheckedChanged);
            // 
            // checkgt
            // 
            this.checkgt.EditValue = true;
            this.checkgt.Location = new System.Drawing.Point(24, 34);
            this.checkgt.Name = "checkgt";
            this.checkgt.Properties.Caption = "杆塔";
            this.checkgt.Size = new System.Drawing.Size(61, 19);
            this.checkgt.TabIndex = 0;
            this.checkgt.CheckedChanged += new System.EventHandler(this.checkgt_CheckedChanged);
            // 
            // UCMapLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.controlNavigator1);
            this.Name = "UCMapLayer";
            this.Size = new System.Drawing.Size(198, 272);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkxlmc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkgth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkbyqrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkkg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkbyq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkgt.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn 层;
        private DevExpress.XtraTreeList.Columns.TreeListColumn 显示;
        private DevExpress.XtraTreeList.Columns.TreeListColumn 编辑;
        private DevExpress.XtraTreeList.Columns.TreeListColumn Layer;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit checkbyqrl;
        private DevExpress.XtraEditors.CheckEdit checkkg;
        private DevExpress.XtraEditors.CheckEdit checkbyq;
        private DevExpress.XtraEditors.CheckEdit checkgt;
        private DevExpress.XtraEditors.CheckEdit checkgth;
        private DevExpress.XtraEditors.CheckEdit checkxlmc;
    }
}
