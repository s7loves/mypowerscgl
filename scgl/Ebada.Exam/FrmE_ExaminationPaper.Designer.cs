namespace Ebada.Exam
{
    partial class FrmE_ExaminationPaperEdit
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
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnEditQuestion = new DevExpress.XtraEditors.SimpleButton();
            this.checkOrderRand = new DevExpress.XtraEditors.CheckEdit();
            this.cobType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lkueSetting = new DevExpress.XtraEditors.LookUpEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkOrderRand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkueSetting.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(315, 218);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 27);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确 定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(408, 218);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取 消";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnEditQuestion);
            this.groupControl1.Controls.Add(this.checkOrderRand);
            this.groupControl1.Controls.Add(this.cobType);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.lkueSetting);
            this.groupControl1.Controls.Add(this.txtName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(25, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(472, 185);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "试卷";
            // 
            // btnEditQuestion
            // 
            this.btnEditQuestion.Enabled = false;
            this.btnEditQuestion.Location = new System.Drawing.Point(370, 145);
            this.btnEditQuestion.Name = "btnEditQuestion";
            this.btnEditQuestion.Size = new System.Drawing.Size(75, 23);
            this.btnEditQuestion.TabIndex = 6;
            this.btnEditQuestion.Text = "编辑试题";
            this.btnEditQuestion.Click += new System.EventHandler(this.btnEditQuestion_Click);
            // 
            // checkOrderRand
            // 
            this.checkOrderRand.Location = new System.Drawing.Point(67, 143);
            this.checkOrderRand.Name = "checkOrderRand";
            this.checkOrderRand.Properties.Caption = "试题顺序随机";
            this.checkOrderRand.Size = new System.Drawing.Size(104, 19);
            this.checkOrderRand.TabIndex = 8;
            // 
            // cobType
            // 
            this.cobType.Location = new System.Drawing.Point(69, 105);
            this.cobType.Name = "cobType";
            this.cobType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cobType.Properties.Items.AddRange(new object[] {
            "指定试题",
            "随机试题"});
            this.cobType.Size = new System.Drawing.Size(376, 21);
            this.cobType.TabIndex = 6;
            this.cobType.SelectedIndexChanged += new System.EventHandler(this.cobType_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(24, 105);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "类型：";
            // 
            // lkueSetting
            // 
            this.lkueSetting.Location = new System.Drawing.Point(69, 70);
            this.lkueSetting.Name = "lkueSetting";
            this.lkueSetting.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkueSetting.Properties.NullText = "选择设置";
            this.lkueSetting.Size = new System.Drawing.Size(376, 21);
            this.lkueSetting.TabIndex = 4;
            this.lkueSetting.EditValueChanged += new System.EventHandler(this.lkueSetting_EditValueChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(69, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(376, 21);
            this.txtName.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(24, 73);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "设置：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "名称：";
            // 
            // FrmE_ExaminationPaperEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 260);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "FrmE_ExaminationPaperEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑试卷";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkOrderRand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkueSetting.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit checkOrderRand;
        private DevExpress.XtraEditors.ComboBoxEdit cobType;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lkueSetting;
        private DevExpress.XtraEditors.SimpleButton btnEditQuestion;
    }
}