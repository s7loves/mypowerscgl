namespace Ebada.Scgl.Lpgl
{
    partial class DownFileControl
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.fjgridControl = new DevExpress.XtraGrid.GridControl();
            this.fjgridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.FileListLable = new System.Windows.Forms.Label();
            this.openFolderButton = new DevExpress.XtraEditors.SimpleButton();
            this.downfileButton = new DevExpress.XtraEditors.SimpleButton();
            this.upfileButton = new DevExpress.XtraEditors.SimpleButton();
            this.selctFileButton = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tipLabelControl = new DevExpress.XtraEditors.LabelControl();
            this.progressBarControlTol = new DevExpress.XtraEditors.ProgressBarControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fjgridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fjgridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlTol.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(564, 300);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.splitContainerControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(559, 273);
            this.xtraTabPage1.Text = "附件下载";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.fjgridControl);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.FileListLable);
            this.splitContainerControl1.Panel2.Controls.Add(this.openFolderButton);
            this.splitContainerControl1.Panel2.Controls.Add(this.downfileButton);
            this.splitContainerControl1.Panel2.Controls.Add(this.upfileButton);
            this.splitContainerControl1.Panel2.Controls.Add(this.selctFileButton);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel2.Controls.Add(this.tipLabelControl);
            this.splitContainerControl1.Panel2.Controls.Add(this.progressBarControlTol);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(559, 273);
            this.splitContainerControl1.SplitterPosition = 63;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // fjgridControl
            // 
            this.fjgridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fjgridControl.Location = new System.Drawing.Point(0, 0);
            this.fjgridControl.MainView = this.fjgridView;
            this.fjgridControl.Name = "fjgridControl";
            this.fjgridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemProgressBar1,
            this.repositoryItemPictureEdit1,
            this.repositoryItemHyperLinkEdit2,
            this.repositoryItemCheckEdit1});
            this.fjgridControl.Size = new System.Drawing.Size(559, 206);
            this.fjgridControl.TabIndex = 0;
            this.fjgridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fjgridView});
            // 
            // fjgridView
            // 
            this.fjgridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn6});
            this.fjgridView.GridControl = this.fjgridControl;
            this.fjgridView.Name = "fjgridView";
            this.fjgridView.OptionsView.ShowColumnHeaders = false;
            this.fjgridView.OptionsView.ShowGroupPanel = false;
            this.fjgridView.OptionsView.ShowIndicator = false;
            this.fjgridView.DoubleClick += new System.EventHandler(this.fjgridView_DoubleClick);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "选择";
            this.gridColumn7.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn7.FieldName = "SlectFile";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.ToolTip = "双击打开文件";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "文件名";
            this.gridColumn1.FieldName = "FileName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.ToolTip = "双击打开文件";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 300;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "进度";
            this.gridColumn4.ColumnEdit = this.repositoryItemProgressBar1;
            this.gridColumn4.FieldName = "Progress";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.ToolTip = "双击打开文件";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 125;
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            this.repositoryItemProgressBar1.NullText = "等待提交";
            this.repositoryItemProgressBar1.ShowTitle = true;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "删除";
            this.gridColumn3.ColumnEdit = this.repositoryItemHyperLinkEdit2;
            this.gridColumn3.FieldName = "DelBut";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.ToolTip = "双击打开文件";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 73;
            // 
            // repositoryItemHyperLinkEdit2
            // 
            this.repositoryItemHyperLinkEdit2.AutoHeight = false;
            this.repositoryItemHyperLinkEdit2.Caption = "删除";
            this.repositoryItemHyperLinkEdit2.Name = "repositoryItemHyperLinkEdit2";
            this.repositoryItemHyperLinkEdit2.Click += new System.EventHandler(this.repositoryItemHyperLinkEdit2_Click);
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "查看";
            this.gridColumn2.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.gridColumn2.FieldName = "DownBut";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.ToolTip = "双击打开文件";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 55;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Caption = "下载";
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.Click += new System.EventHandler(this.repositoryItemHyperLinkEdit1_Click);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "文件路径";
            this.gridColumn5.FieldName = "FilePath";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "状态";
            this.gridColumn6.FieldName = "Kind";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // FileListLable
            // 
            this.FileListLable.AutoSize = true;
            this.FileListLable.Location = new System.Drawing.Point(3, -3);
            this.FileListLable.Name = "FileListLable";
            this.FileListLable.Size = new System.Drawing.Size(11, 12);
            this.FileListLable.TabIndex = 3;
            this.FileListLable.Text = "l";
            this.FileListLable.Visible = false;
            // 
            // openFolderButton
            // 
            this.openFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openFolderButton.Location = new System.Drawing.Point(423, 37);
            this.openFolderButton.Name = "openFolderButton";
            this.openFolderButton.Size = new System.Drawing.Size(69, 23);
            this.openFolderButton.TabIndex = 2;
            this.openFolderButton.Text = "浏览文件夹";
            this.openFolderButton.Visible = false;
            this.openFolderButton.Click += new System.EventHandler(this.openFolderButton_Click);
            // 
            // downfileButton
            // 
            this.downfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.downfileButton.Location = new System.Drawing.Point(498, 37);
            this.downfileButton.Name = "downfileButton";
            this.downfileButton.Size = new System.Drawing.Size(55, 23);
            this.downfileButton.TabIndex = 2;
            this.downfileButton.Text = "下载文件";
            this.downfileButton.Visible = false;
            this.downfileButton.Click += new System.EventHandler(this.downfileButton_Click);
            // 
            // upfileButton
            // 
            this.upfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.upfileButton.Location = new System.Drawing.Point(498, 37);
            this.upfileButton.Name = "upfileButton";
            this.upfileButton.Size = new System.Drawing.Size(55, 23);
            this.upfileButton.TabIndex = 2;
            this.upfileButton.Text = "上传文件";
            this.upfileButton.Click += new System.EventHandler(this.upfileButton_Click);
            // 
            // selctFileButton
            // 
            this.selctFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selctFileButton.Location = new System.Drawing.Point(362, 37);
            this.selctFileButton.Name = "selctFileButton";
            this.selctFileButton.Size = new System.Drawing.Size(55, 23);
            this.selctFileButton.TabIndex = 2;
            this.selctFileButton.Text = "设置路径";
            this.selctFileButton.Visible = false;
            this.selctFileButton.Click += new System.EventHandler(this.selctFileButton_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Location = new System.Drawing.Point(5, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "总进度";
            // 
            // tipLabelControl
            // 
            this.tipLabelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tipLabelControl.Location = new System.Drawing.Point(43, 21);
            this.tipLabelControl.Name = "tipLabelControl";
            this.tipLabelControl.Size = new System.Drawing.Size(30, 14);
            this.tipLabelControl.TabIndex = 1;
            this.tipLabelControl.Text = "0.0%";
            this.tipLabelControl.Visible = false;
            // 
            // progressBarControlTol
            // 
            this.progressBarControlTol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarControlTol.EditValue = "0";
            this.progressBarControlTol.Location = new System.Drawing.Point(43, 3);
            this.progressBarControlTol.Name = "progressBarControlTol";
            this.progressBarControlTol.Properties.ShowTitle = true;
            this.progressBarControlTol.Size = new System.Drawing.Size(510, 16);
            this.progressBarControlTol.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // DownFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "DownFileControl";
            this.Size = new System.Drawing.Size(564, 300);
            this.Load += new System.EventHandler(this.DownFileControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fjgridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fjgridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlTol.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl fjgridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView fjgridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.LabelControl tipLabelControl;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControlTol;
        private DevExpress.XtraEditors.SimpleButton upfileButton;
        private DevExpress.XtraEditors.SimpleButton selctFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label FileListLable;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton downfileButton;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.SimpleButton openFolderButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
