namespace Ebada.Scgl.Lcgl
{
    partial class frmSQLSet
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.tetWorkSQL = new DevExpress.XtraEditors.MemoEdit();
            this.cbxWorkDbTableColumns = new System.Windows.Forms.ComboBox();
            this.cbxWorkDbTable = new System.Windows.Forms.ComboBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.cbxWorkTableColumns = new System.Windows.Forms.ComboBox();
            this.cbxWorkDataTable = new System.Windows.Forms.ComboBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkSQL.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.memoEdit1);
            this.groupControl1.Controls.Add(this.simpleButton2);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.tetWorkSQL);
            this.groupControl1.Controls.Add(this.cbxWorkDbTableColumns);
            this.groupControl1.Controls.Add(this.cbxWorkDbTable);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl23);
            this.groupControl1.Controls.Add(this.labelControl24);
            this.groupControl1.Controls.Add(this.cbxWorkTableColumns);
            this.groupControl1.Controls.Add(this.cbxWorkDataTable);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(511, 360);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "设置";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 238);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 66;
            this.labelControl1.Text = "说明：";
            // 
            // memoEdit1
            // 
            this.memoEdit1.EditValue = "";
            this.memoEdit1.Location = new System.Drawing.Point(59, 238);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(437, 83);
            this.memoEdit1.TabIndex = 65;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Location = new System.Drawing.Point(426, 330);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(70, 23);
            this.simpleButton2.TabIndex = 63;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(348, 330);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(70, 23);
            this.simpleButton1.TabIndex = 62;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // tetWorkSQL
            // 
            this.tetWorkSQL.Location = new System.Drawing.Point(58, 95);
            this.tetWorkSQL.Name = "tetWorkSQL";
            this.tetWorkSQL.Size = new System.Drawing.Size(438, 134);
            this.tetWorkSQL.TabIndex = 61;
            // 
            // cbxWorkDbTableColumns
            // 
            this.cbxWorkDbTableColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkDbTableColumns.FormattingEnabled = true;
            this.cbxWorkDbTableColumns.Location = new System.Drawing.Point(332, 64);
            this.cbxWorkDbTableColumns.Name = "cbxWorkDbTableColumns";
            this.cbxWorkDbTableColumns.Size = new System.Drawing.Size(164, 22);
            this.cbxWorkDbTableColumns.TabIndex = 59;
            this.cbxWorkDbTableColumns.SelectedIndexChanged += new System.EventHandler(this.cbxWorkDbTableColumns_SelectedIndexChanged);
            // 
            // cbxWorkDbTable
            // 
            this.cbxWorkDbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkDbTable.FormattingEnabled = true;
            this.cbxWorkDbTable.Location = new System.Drawing.Point(58, 64);
            this.cbxWorkDbTable.Name = "cbxWorkDbTable";
            this.cbxWorkDbTable.Size = new System.Drawing.Size(207, 22);
            this.cbxWorkDbTable.TabIndex = 60;
            this.cbxWorkDbTable.SelectedIndexChanged += new System.EventHandler(this.cbxWorkDbTable_SelectedIndexChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 95);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 14);
            this.labelControl4.TabIndex = 56;
            this.labelControl4.Text = "SQL：";
            // 
            // labelControl23
            // 
            this.labelControl23.Location = new System.Drawing.Point(283, 69);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(36, 14);
            this.labelControl23.TabIndex = 57;
            this.labelControl23.Text = "字段：";
            // 
            // labelControl24
            // 
            this.labelControl24.Location = new System.Drawing.Point(12, 67);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(36, 14);
            this.labelControl24.TabIndex = 58;
            this.labelControl24.Text = "表名：";
            // 
            // cbxWorkTableColumns
            // 
            this.cbxWorkTableColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkTableColumns.FormattingEnabled = true;
            this.cbxWorkTableColumns.Location = new System.Drawing.Point(332, 33);
            this.cbxWorkTableColumns.Name = "cbxWorkTableColumns";
            this.cbxWorkTableColumns.Size = new System.Drawing.Size(164, 22);
            this.cbxWorkTableColumns.TabIndex = 48;
            this.cbxWorkTableColumns.SelectedIndexChanged += new System.EventHandler(this.cbxWorkTableColumns_SelectedIndexChanged);
            // 
            // cbxWorkDataTable
            // 
            this.cbxWorkDataTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkDataTable.FormattingEnabled = true;
            this.cbxWorkDataTable.Location = new System.Drawing.Point(59, 33);
            this.cbxWorkDataTable.Name = "cbxWorkDataTable";
            this.cbxWorkDataTable.Size = new System.Drawing.Size(206, 22);
            this.cbxWorkDataTable.TabIndex = 49;
            this.cbxWorkDataTable.SelectedIndexChanged += new System.EventHandler(this.cbxWorkDataTable_SelectedIndexChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(283, 37);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 46;
            this.labelControl5.Text = "字段：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 35);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 47;
            this.labelControl3.Text = "表单名：";
            // 
            // frmSQLSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 360);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmSQLSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置SQL语句";
            this.Load += new System.EventHandler(this.frmExcelEditSQLSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkSQL.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.MemoEdit tetWorkSQL;
        private System.Windows.Forms.ComboBox cbxWorkDbTableColumns;
        private System.Windows.Forms.ComboBox cbxWorkDbTable;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private System.Windows.Forms.ComboBox cbxWorkTableColumns;
        private System.Windows.Forms.ComboBox cbxWorkDataTable;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}