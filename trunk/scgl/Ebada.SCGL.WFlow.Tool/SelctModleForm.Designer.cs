namespace Ebada.SCGL.WFlow.Tool
{
    partial class SelctModleForm
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.treeList3 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.RemoveMoudle = new DevExpress.XtraEditors.SimpleButton();
            this.AddMoudle = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.treeList2 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.splitContainerControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(646, 302);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl3);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl4);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(642, 298);
            this.splitContainerControl1.SplitterPosition = 256;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl2.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl2.Controls.Add(this.treeList1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(256, 298);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "模块列表";
            // 
            // treeList1
            // 
            this.treeList1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeList1.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.treeList1.Appearance.FocusedRow.Options.UseFont = true;
            this.treeList1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treeList1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treeList1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treeList1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeList1.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.treeList1.Appearance.SelectedRow.Options.UseFont = true;
            this.treeList1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.KeyFieldName = "Modu_ID";
            this.treeList1.Location = new System.Drawing.Point(2, 23);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsSelection.InvertSelection = true;
            this.treeList1.OptionsSelection.UseIndicatorForSelection = true;
            this.treeList1.Size = new System.Drawing.Size(252, 273);
            this.treeList1.TabIndex = 1;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn1.Caption = "功能名称";
            this.treeListColumn1.FieldName = "ModuName";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 100;
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl3.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl3.Controls.Add(this.treeList3);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(199, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(183, 298);
            this.groupControl3.TabIndex = 3;
            this.groupControl3.Text = "可以操作的功能";
            // 
            // treeList3
            // 
            this.treeList3.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeList3.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.treeList3.Appearance.FocusedRow.Options.UseFont = true;
            this.treeList3.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treeList3.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treeList3.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treeList3.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeList3.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.treeList3.Appearance.SelectedRow.Options.UseFont = true;
            this.treeList3.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treeList3.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn3});
            this.treeList3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList3.KeyFieldName = "Modu_ID";
            this.treeList3.Location = new System.Drawing.Point(2, 23);
            this.treeList3.Name = "treeList3";
            this.treeList3.OptionsBehavior.Editable = false;
            this.treeList3.OptionsSelection.InvertSelection = true;
            this.treeList3.OptionsSelection.UseIndicatorForSelection = true;
            this.treeList3.Size = new System.Drawing.Size(179, 273);
            this.treeList3.TabIndex = 1;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn3.Caption = "功能名称";
            this.treeListColumn3.FieldName = "ModuName";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 0;
            this.treeListColumn3.Width = 100;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.RemoveMoudle);
            this.panelControl1.Controls.Add(this.AddMoudle);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(168, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(31, 298);
            this.panelControl1.TabIndex = 5;
            // 
            // RemoveMoudle
            // 
            this.RemoveMoudle.Location = new System.Drawing.Point(1, 172);
            this.RemoveMoudle.Name = "RemoveMoudle";
            this.RemoveMoudle.Size = new System.Drawing.Size(28, 23);
            this.RemoveMoudle.TabIndex = 1;
            this.RemoveMoudle.Text = "<<";
            // 
            // AddMoudle
            // 
            this.AddMoudle.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.AddMoudle.Appearance.Options.UseFont = true;
            this.AddMoudle.Location = new System.Drawing.Point(1, 133);
            this.AddMoudle.Name = "AddMoudle";
            this.AddMoudle.Size = new System.Drawing.Size(28, 23);
            this.AddMoudle.TabIndex = 0;
            this.AddMoudle.Text = ">>";
            // 
            // groupControl4
            // 
            this.groupControl4.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl4.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl4.Controls.Add(this.treeList2);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl4.Location = new System.Drawing.Point(0, 0);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(168, 298);
            this.groupControl4.TabIndex = 4;
            this.groupControl4.Text = "功能列表";
            // 
            // treeList2
            // 
            this.treeList2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeList2.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.treeList2.Appearance.FocusedRow.Options.UseFont = true;
            this.treeList2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treeList2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treeList2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treeList2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeList2.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.treeList2.Appearance.SelectedRow.Options.UseFont = true;
            this.treeList2.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treeList2.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn2});
            this.treeList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList2.KeyFieldName = "Modu_ID";
            this.treeList2.Location = new System.Drawing.Point(2, 23);
            this.treeList2.Name = "treeList2";
            this.treeList2.OptionsBehavior.Editable = false;
            this.treeList2.OptionsSelection.InvertSelection = true;
            this.treeList2.OptionsSelection.UseIndicatorForSelection = true;
            this.treeList2.Size = new System.Drawing.Size(164, 273);
            this.treeList2.TabIndex = 0;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn2.Caption = "功能名称";
            this.treeListColumn2.FieldName = "ModuName";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 0;
            this.treeListColumn2.Width = 100;
            // 
            // SelctModleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 302);
            this.Controls.Add(this.groupControl1);
            this.Name = "SelctModleForm";
            this.Text = "选择操作模块";
            this.Load += new System.EventHandler(this.SelctModleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraTreeList.TreeList treeList3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton RemoveMoudle;
        private DevExpress.XtraEditors.SimpleButton AddMoudle;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraTreeList.TreeList treeList2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;

    }
}