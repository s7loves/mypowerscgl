namespace Ebada.Exam
{
    partial class FrmE_AddQuestion
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labMB = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabpagePD = new System.Windows.Forms.TabPage();
            this.tabpageSelect = new System.Windows.Forms.TabPage();
            this.tabpageMuSelect = new System.Windows.Forms.TabPage();
            this.ucm_EaddQuestionPD = new Ebada.Exam.Ucm_EaddQuestion();
            this.ucm_EaddQuestionSelect = new Ebada.Exam.Ucm_EaddQuestion();
            this.ucm_EaddQuestionMuSelect = new Ebada.Exam.Ucm_EaddQuestion();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabpagePD.SuspendLayout();
            this.tabpageSelect.SuspendLayout();
            this.tabpageMuSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Location = new System.Drawing.Point(12, 9);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(783, 118);
            this.groupControl2.TabIndex = 29;
            this.groupControl2.Text = "试卷试题情况";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl1.Location = new System.Drawing.Point(2, 23);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(779, 93);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
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
            // labMB
            // 
            this.labMB.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.labMB.Appearance.Options.UseFont = true;
            this.labMB.Location = new System.Drawing.Point(2, 195);
            this.labMB.Name = "labMB";
            this.labMB.Size = new System.Drawing.Size(102, 18);
            this.labMB.TabIndex = 31;
            this.labMB.Text = "labelControl1";
            this.labMB.Visible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tab);
            this.groupControl1.Location = new System.Drawing.Point(0, 133);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1025, 529);
            this.groupControl1.TabIndex = 32;
            this.groupControl1.Text = "编辑试题";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(801, 54);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 36);
            this.btnOK.TabIndex = 33;
            this.btnOK.Text = "确 定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(902, 54);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 36);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "取消";
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabpagePD);
            this.tab.Controls.Add(this.tabpageSelect);
            this.tab.Controls.Add(this.tabpageMuSelect);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(2, 23);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1021, 504);
            this.tab.TabIndex = 0;
            // 
            // tabpagePD
            // 
            this.tabpagePD.Controls.Add(this.ucm_EaddQuestionPD);
            this.tabpagePD.Location = new System.Drawing.Point(4, 23);
            this.tabpagePD.Name = "tabpagePD";
            this.tabpagePD.Padding = new System.Windows.Forms.Padding(3);
            this.tabpagePD.Size = new System.Drawing.Size(1013, 477);
            this.tabpagePD.TabIndex = 0;
            this.tabpagePD.Text = "判断题";
            this.tabpagePD.UseVisualStyleBackColor = true;
            // 
            // tabpageSelect
            // 
            this.tabpageSelect.Controls.Add(this.ucm_EaddQuestionSelect);
            this.tabpageSelect.Location = new System.Drawing.Point(4, 23);
            this.tabpageSelect.Name = "tabpageSelect";
            this.tabpageSelect.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageSelect.Size = new System.Drawing.Size(1013, 477);
            this.tabpageSelect.TabIndex = 1;
            this.tabpageSelect.Text = "单项选择题";
            this.tabpageSelect.UseVisualStyleBackColor = true;
            // 
            // tabpageMuSelect
            // 
            this.tabpageMuSelect.Controls.Add(this.ucm_EaddQuestionMuSelect);
            this.tabpageMuSelect.Location = new System.Drawing.Point(4, 23);
            this.tabpageMuSelect.Name = "tabpageMuSelect";
            this.tabpageMuSelect.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageMuSelect.Size = new System.Drawing.Size(1013, 477);
            this.tabpageMuSelect.TabIndex = 2;
            this.tabpageMuSelect.Text = "多项选择题";
            this.tabpageMuSelect.UseVisualStyleBackColor = true;
            // 
            // ucm_EaddQuestionPD
            // 
            this.ucm_EaddQuestionPD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucm_EaddQuestionPD.Location = new System.Drawing.Point(3, 3);
            this.ucm_EaddQuestionPD.Name = "ucm_EaddQuestionPD";
            this.ucm_EaddQuestionPD.Size = new System.Drawing.Size(1007, 471);
            this.ucm_EaddQuestionPD.TabIndex = 0;
            // 
            // ucm_EaddQuestionSelect
            // 
            this.ucm_EaddQuestionSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucm_EaddQuestionSelect.Location = new System.Drawing.Point(3, 3);
            this.ucm_EaddQuestionSelect.Name = "ucm_EaddQuestionSelect";
            this.ucm_EaddQuestionSelect.Size = new System.Drawing.Size(1007, 471);
            this.ucm_EaddQuestionSelect.TabIndex = 0;
            // 
            // ucm_EaddQuestionMuSelect
            // 
            this.ucm_EaddQuestionMuSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucm_EaddQuestionMuSelect.Location = new System.Drawing.Point(3, 3);
            this.ucm_EaddQuestionMuSelect.Name = "ucm_EaddQuestionMuSelect";
            this.ucm_EaddQuestionMuSelect.Size = new System.Drawing.Size(1007, 471);
            this.ucm_EaddQuestionMuSelect.TabIndex = 0;
            // 
            // FrmE_AddQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 661);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labMB);
            this.Controls.Add(this.groupControl2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmE_AddQuestion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑试卷试题";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tab.ResumeLayout(false);
            this.tabpagePD.ResumeLayout(false);
            this.tabpageSelect.ResumeLayout(false);
            this.tabpageMuSelect.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labMB;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabpagePD;
        private System.Windows.Forms.TabPage tabpageSelect;
        private System.Windows.Forms.TabPage tabpageMuSelect;
        private Ucm_EaddQuestion ucm_EaddQuestionPD;
        private Ucm_EaddQuestion ucm_EaddQuestionSelect;
        private Ucm_EaddQuestion ucm_EaddQuestionMuSelect;
    }
}