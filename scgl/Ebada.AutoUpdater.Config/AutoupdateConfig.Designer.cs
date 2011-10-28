namespace Ebada.AutoUpdater.Config
{
    partial class AutoupdateConfig
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.fileCheckBox = new System.Windows.Forms.CheckBox();
            this.DelRAR = new System.Windows.Forms.Button();
            this.AddRAR = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.BuildXML = new System.Windows.Forms.Button();
            this.Delbut = new System.Windows.Forms.Button();
            this.Addbut = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.fileCheckBox);
            this.panel1.Controls.Add(this.DelRAR);
            this.panel1.Controls.Add(this.AddRAR);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.BuildXML);
            this.panel1.Controls.Add(this.Delbut);
            this.panel1.Controls.Add(this.Addbut);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 260);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "设置域名";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 21);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "localhost";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(250, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "设置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fileCheckBox
            // 
            this.fileCheckBox.AutoSize = true;
            this.fileCheckBox.Location = new System.Drawing.Point(4, 239);
            this.fileCheckBox.Name = "fileCheckBox";
            this.fileCheckBox.Size = new System.Drawing.Size(48, 16);
            this.fileCheckBox.TabIndex = 6;
            this.fileCheckBox.Text = "全选";
            this.fileCheckBox.UseVisualStyleBackColor = true;
            this.fileCheckBox.CheckedChanged += new System.EventHandler(this.fileCheckBox_CheckedChanged);
            // 
            // DelRAR
            // 
            this.DelRAR.Location = new System.Drawing.Point(557, 122);
            this.DelRAR.Name = "DelRAR";
            this.DelRAR.Size = new System.Drawing.Size(84, 23);
            this.DelRAR.TabIndex = 5;
            this.DelRAR.Text = "后缀去RAR";
            this.DelRAR.UseVisualStyleBackColor = true;
            this.DelRAR.Click += new System.EventHandler(this.DelRAR_Click);
            // 
            // AddRAR
            // 
            this.AddRAR.Location = new System.Drawing.Point(557, 93);
            this.AddRAR.Name = "AddRAR";
            this.AddRAR.Size = new System.Drawing.Size(84, 23);
            this.AddRAR.TabIndex = 5;
            this.AddRAR.Text = "后缀添加RAR";
            this.AddRAR.UseVisualStyleBackColor = true;
            this.AddRAR.Click += new System.EventHandler(this.AddRAR_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(281, 241);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(282, 16);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "添加更新文件夹里所有文件(ScglUpdateService)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // BuildXML
            // 
            this.BuildXML.Location = new System.Drawing.Point(558, 64);
            this.BuildXML.Name = "BuildXML";
            this.BuildXML.Size = new System.Drawing.Size(75, 23);
            this.BuildXML.TabIndex = 3;
            this.BuildXML.Text = "生成XML";
            this.BuildXML.UseVisualStyleBackColor = true;
            this.BuildXML.Click += new System.EventHandler(this.BuildXML_Click);
            // 
            // Delbut
            // 
            this.Delbut.Location = new System.Drawing.Point(558, 64);
            this.Delbut.Name = "Delbut";
            this.Delbut.Size = new System.Drawing.Size(75, 23);
            this.Delbut.TabIndex = 2;
            this.Delbut.Text = "删除文件";
            this.Delbut.UseVisualStyleBackColor = true;
            this.Delbut.Visible = false;
            // 
            // Addbut
            // 
            this.Addbut.Location = new System.Drawing.Point(558, 35);
            this.Addbut.Name = "Addbut";
            this.Addbut.Size = new System.Drawing.Size(75, 23);
            this.Addbut.TabIndex = 1;
            this.Addbut.Text = "增加文件";
            this.Addbut.UseVisualStyleBackColor = true;
            this.Addbut.Click += new System.EventHandler(this.Addbut_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(4, 35);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.gridControl1.Size = new System.Drawing.Size(548, 200);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn6});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "选择文件";
            this.gridColumn5.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn5.FieldName = "HaveSelected";
            this.gridColumn5.MaxWidth = 50;
            this.gridColumn5.MinWidth = 50;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 50;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "文件名";
            this.gridColumn1.FieldName = "FileName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "版本号";
            this.gridColumn2.FieldName = "Version";
            this.gridColumn2.MaxWidth = 75;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "大小";
            this.gridColumn3.FieldName = "Size";
            this.gridColumn3.MaxWidth = 75;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "是否需要重启";
            this.gridColumn4.ColumnEdit = this.repositoryItemCheckEdit2;
            this.gridColumn4.FieldName = "NeedRestart";
            this.gridColumn4.MaxWidth = 50;
            this.gridColumn4.MinWidth = 50;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 50;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "全文件名";
            this.gridColumn6.FieldName = "FullFileName";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // fileDialog1
            // 
            this.fileDialog1.FileName = "openFileDialog1";
            // 
            // AutoupdateConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 266);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AutoupdateConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动更新配置工具";
            this.Load += new System.EventHandler(this.AutoupdateConfig_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog fileDialog1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.Button Addbut;
        private System.Windows.Forms.Button Delbut;
        private System.Windows.Forms.Button BuildXML;
        private System.Windows.Forms.CheckBox checkBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private System.Windows.Forms.Button DelRAR;
        private System.Windows.Forms.Button AddRAR;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.CheckBox fileCheckBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

