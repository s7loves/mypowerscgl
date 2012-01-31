namespace Ebada.SCGL.WFlow.Tool
{
    partial class frmExcelEditSQLSet
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
            this.ceBind = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.tetWorkSQL = new DevExpress.XtraEditors.MemoEdit();
            this.cbxWorkDbTableColumns = new System.Windows.Forms.ComboBox();
            this.cbxWorkDbTable = new System.Windows.Forms.ComboBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.rbnWorkDatabase = new System.Windows.Forms.RadioButton();
            this.tetWorkPos = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.cbxWorkTableColumns = new System.Windows.Forms.ComboBox();
            this.cbxWorkExcelTable = new System.Windows.Forms.ComboBox();
            this.cbxWorkDataTable = new System.Windows.Forms.ComboBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.rbnWorkFixValue = new System.Windows.Forms.RadioButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.rbnWorkExcel = new System.Windows.Forms.RadioButton();
            this.rbnWorkTable = new System.Windows.Forms.RadioButton();
            this.tetWorkFixValue = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceBind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkSQL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkPos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkFixValue.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // m_DefaultLookAndFeel
            // 
            
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.memoEdit1);
            this.groupControl1.Controls.Add(this.ceBind);
            this.groupControl1.Controls.Add(this.simpleButton2);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.tetWorkFixValue);
            this.groupControl1.Controls.Add(this.tetWorkSQL);
            this.groupControl1.Controls.Add(this.cbxWorkDbTableColumns);
            this.groupControl1.Controls.Add(this.cbxWorkDbTable);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl23);
            this.groupControl1.Controls.Add(this.labelControl24);
            this.groupControl1.Controls.Add(this.rbnWorkDatabase);
            this.groupControl1.Controls.Add(this.tetWorkPos);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.cbxWorkTableColumns);
            this.groupControl1.Controls.Add(this.cbxWorkExcelTable);
            this.groupControl1.Controls.Add(this.cbxWorkDataTable);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.rbnWorkFixValue);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.rbnWorkExcel);
            this.groupControl1.Controls.Add(this.rbnWorkTable);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(611, 359);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "设置";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(390, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 66;
            this.labelControl1.Text = "说明";
            // 
            // memoEdit1
            // 
            this.memoEdit1.EditValue = "";
            this.memoEdit1.Location = new System.Drawing.Point(390, 47);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(209, 286);
            this.memoEdit1.TabIndex = 65;
            // 
            // ceBind
            // 
            this.ceBind.EditValue = true;
            this.ceBind.Location = new System.Drawing.Point(39, 1);
            this.ceBind.Name = "ceBind";
            this.ceBind.Properties.Caption = "关联流程记录";
            this.ceBind.Size = new System.Drawing.Size(108, 19);
            this.ceBind.TabIndex = 64;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Location = new System.Drawing.Point(543, 335);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(56, 23);
            this.simpleButton2.TabIndex = 63;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(465, 335);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(59, 23);
            this.simpleButton1.TabIndex = 62;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // tetWorkSQL
            // 
            this.tetWorkSQL.Location = new System.Drawing.Point(62, 174);
            this.tetWorkSQL.Name = "tetWorkSQL";
            this.tetWorkSQL.Size = new System.Drawing.Size(322, 159);
            this.tetWorkSQL.TabIndex = 61;
            // 
            // cbxWorkDbTableColumns
            // 
            this.cbxWorkDbTableColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkDbTableColumns.FormattingEnabled = true;
            this.cbxWorkDbTableColumns.Location = new System.Drawing.Point(276, 144);
            this.cbxWorkDbTableColumns.Name = "cbxWorkDbTableColumns";
            this.cbxWorkDbTableColumns.Size = new System.Drawing.Size(108, 22);
            this.cbxWorkDbTableColumns.TabIndex = 59;
            this.cbxWorkDbTableColumns.SelectedIndexChanged += new System.EventHandler(this.cbxWorkDbTableColumns_SelectedIndexChanged);
            // 
            // cbxWorkDbTable
            // 
            this.cbxWorkDbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkDbTable.FormattingEnabled = true;
            this.cbxWorkDbTable.Location = new System.Drawing.Point(62, 146);
            this.cbxWorkDbTable.Name = "cbxWorkDbTable";
            this.cbxWorkDbTable.Size = new System.Drawing.Size(127, 22);
            this.cbxWorkDbTable.TabIndex = 60;
            this.cbxWorkDbTable.SelectedIndexChanged += new System.EventHandler(this.cbxWorkDbTable_SelectedIndexChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(14, 183);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 14);
            this.labelControl4.TabIndex = 56;
            this.labelControl4.Text = "SQL：";
            // 
            // labelControl23
            // 
            this.labelControl23.Location = new System.Drawing.Point(227, 146);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(36, 14);
            this.labelControl23.TabIndex = 57;
            this.labelControl23.Text = "字段：";
            // 
            // labelControl24
            // 
            this.labelControl24.Location = new System.Drawing.Point(14, 149);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(36, 14);
            this.labelControl24.TabIndex = 58;
            this.labelControl24.Text = "表名：";
            // 
            // rbnWorkDatabase
            // 
            this.rbnWorkDatabase.AutoSize = true;
            this.rbnWorkDatabase.Location = new System.Drawing.Point(12, 126);
            this.rbnWorkDatabase.Name = "rbnWorkDatabase";
            this.rbnWorkDatabase.Size = new System.Drawing.Size(85, 18);
            this.rbnWorkDatabase.TabIndex = 55;
            this.rbnWorkDatabase.Text = "从数据库取";
            this.rbnWorkDatabase.UseVisualStyleBackColor = true;
            // 
            // tetWorkPos
            // 
            this.tetWorkPos.Location = new System.Drawing.Point(274, 94);
            this.tetWorkPos.Name = "tetWorkPos";
            this.tetWorkPos.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tetWorkPos.Properties.Mask.EditMask = "([a-zA-Z]{1,2}\\d{1,3}[|])+";
            this.tetWorkPos.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.tetWorkPos.Size = new System.Drawing.Size(110, 21);
            this.tetWorkPos.TabIndex = 52;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(191, 97);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(72, 14);
            this.labelControl7.TabIndex = 51;
            this.labelControl7.Text = "单元格位置：";
            this.labelControl7.UseWaitCursor = true;
            // 
            // cbxWorkTableColumns
            // 
            this.cbxWorkTableColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkTableColumns.FormattingEnabled = true;
            this.cbxWorkTableColumns.Location = new System.Drawing.Point(62, 93);
            this.cbxWorkTableColumns.Name = "cbxWorkTableColumns";
            this.cbxWorkTableColumns.Size = new System.Drawing.Size(126, 22);
            this.cbxWorkTableColumns.TabIndex = 48;
            // 
            // cbxWorkExcelTable
            // 
            this.cbxWorkExcelTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkExcelTable.FormattingEnabled = true;
            this.cbxWorkExcelTable.Location = new System.Drawing.Point(274, 68);
            this.cbxWorkExcelTable.Name = "cbxWorkExcelTable";
            this.cbxWorkExcelTable.Size = new System.Drawing.Size(110, 22);
            this.cbxWorkExcelTable.TabIndex = 49;
            // 
            // cbxWorkDataTable
            // 
            this.cbxWorkDataTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkDataTable.FormattingEnabled = true;
            this.cbxWorkDataTable.Location = new System.Drawing.Point(62, 69);
            this.cbxWorkDataTable.Name = "cbxWorkDataTable";
            this.cbxWorkDataTable.Size = new System.Drawing.Size(126, 22);
            this.cbxWorkDataTable.TabIndex = 49;
            this.cbxWorkDataTable.SelectedIndexChanged += new System.EventHandler(this.cbxWorkDataTable_SelectedIndexChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(13, 95);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 46;
            this.labelControl5.Text = "字段：";
            // 
            // rbnWorkFixValue
            // 
            this.rbnWorkFixValue.AutoSize = true;
            this.rbnWorkFixValue.Checked = true;
            this.rbnWorkFixValue.Location = new System.Drawing.Point(11, 26);
            this.rbnWorkFixValue.Name = "rbnWorkFixValue";
            this.rbnWorkFixValue.Size = new System.Drawing.Size(61, 18);
            this.rbnWorkFixValue.TabIndex = 50;
            this.rbnWorkFixValue.TabStop = true;
            this.rbnWorkFixValue.Text = "固定值";
            this.rbnWorkFixValue.UseVisualStyleBackColor = true;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(202, 72);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 14);
            this.labelControl6.TabIndex = 45;
            this.labelControl6.Text = "工作表名：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 71);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 47;
            this.labelControl3.Text = "表名：";
            // 
            // rbnWorkExcel
            // 
            this.rbnWorkExcel.AutoSize = true;
            this.rbnWorkExcel.Location = new System.Drawing.Point(202, 48);
            this.rbnWorkExcel.Name = "rbnWorkExcel";
            this.rbnWorkExcel.Size = new System.Drawing.Size(101, 18);
            this.rbnWorkExcel.TabIndex = 43;
            this.rbnWorkExcel.Text = "从当前Excel取";
            this.rbnWorkExcel.UseVisualStyleBackColor = true;
            // 
            // rbnWorkTable
            // 
            this.rbnWorkTable.AutoSize = true;
            this.rbnWorkTable.Location = new System.Drawing.Point(12, 48);
            this.rbnWorkTable.Name = "rbnWorkTable";
            this.rbnWorkTable.Size = new System.Drawing.Size(73, 18);
            this.rbnWorkTable.TabIndex = 44;
            this.rbnWorkTable.Text = "从表单取";
            this.rbnWorkTable.UseVisualStyleBackColor = true;
            // 
            // tetWorkFixValue
            // 
            this.tetWorkFixValue.Location = new System.Drawing.Point(69, 26);
            this.tetWorkFixValue.Name = "tetWorkFixValue";
            this.tetWorkFixValue.Size = new System.Drawing.Size(315, 22);
            this.tetWorkFixValue.TabIndex = 61;
            // 
            // frmExcelEditSQLSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 359);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmExcelEditSQLSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置关联SQL语句";
            this.Load += new System.EventHandler(this.frmExcelEditSQLSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceBind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkSQL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkPos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetWorkFixValue.Properties)).EndInit();
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
        private System.Windows.Forms.RadioButton rbnWorkDatabase;
        private DevExpress.XtraEditors.TextEdit tetWorkPos;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.ComboBox cbxWorkTableColumns;
        private System.Windows.Forms.ComboBox cbxWorkDataTable;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.RadioButton rbnWorkFixValue;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.RadioButton rbnWorkExcel;
        private System.Windows.Forms.RadioButton rbnWorkTable;
        private System.Windows.Forms.ComboBox cbxWorkExcelTable;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.CheckEdit ceBind;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit tetWorkFixValue;
    }
}