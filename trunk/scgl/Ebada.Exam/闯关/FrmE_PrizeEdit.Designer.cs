namespace Ebada.Exam
{
    partial class FrmE_PrizeEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmE_PrizeEdit));
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.memoOther = new DevExpress.XtraEditors.MemoEdit();
            this.spAllNum = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtType = new DevExpress.XtraEditors.TextEdit();
            this.spPrice = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.mtxtDesc = new DevExpress.XtraEditors.MemoEdit();
            this.txtPrizeName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSelectChar = new DevExpress.XtraEditors.TextEdit();
            this.dateBeginDate = new DevExpress.XtraEditors.DateEdit();
            this.dateEndDate = new DevExpress.XtraEditors.DateEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoOther.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spAllNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrizeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSelectChar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBeginDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBeginDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(534, 349);
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
            this.btnCancel.Location = new System.Drawing.Point(636, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取 消";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.pictureEdit1);
            this.groupControl1.Controls.Add(this.dateEndDate);
            this.groupControl1.Controls.Add(this.dateBeginDate);
            this.groupControl1.Controls.Add(this.txtSelectChar);
            this.groupControl1.Controls.Add(this.memoOther);
            this.groupControl1.Controls.Add(this.spAllNum);
            this.groupControl1.Controls.Add(this.labelControl10);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txtType);
            this.groupControl1.Controls.Add(this.spPrice);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.mtxtDesc);
            this.groupControl1.Controls.Add(this.txtPrizeName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(25, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(713, 329);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "奖品信息";
            // 
            // memoOther
            // 
            this.memoOther.Location = new System.Drawing.Point(88, 237);
            this.memoOther.Name = "memoOther";
            this.memoOther.Size = new System.Drawing.Size(333, 60);
            this.memoOther.TabIndex = 35;
            // 
            // spAllNum
            // 
            this.spAllNum.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spAllNum.Location = new System.Drawing.Point(278, 103);
            this.spAllNum.Name = "spAllNum";
            this.spAllNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spAllNum.Properties.MaxValue = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.spAllNum.Size = new System.Drawing.Size(145, 21);
            this.spAllNum.TabIndex = 34;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(23, 233);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(60, 14);
            this.labelControl10.TabIndex = 33;
            this.labelControl10.Text = "领取说明：";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(215, 141);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(60, 14);
            this.labelControl9.TabIndex = 32;
            this.labelControl9.Text = "结束日期：";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(23, 141);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(60, 14);
            this.labelControl8.TabIndex = 31;
            this.labelControl8.Text = "起始日期：";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(236, 106);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(36, 14);
            this.labelControl7.TabIndex = 30;
            this.labelControl7.Text = "数量：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(558, 29);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(48, 14);
            this.labelControl6.TabIndex = 29;
            this.labelControl6.Text = "奖品图片";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(23, 106);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 28;
            this.labelControl4.Text = "关键字：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(215, 72);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 27;
            this.labelControl5.Text = "兑换分数：";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(90, 69);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(105, 21);
            this.txtType.TabIndex = 26;
            // 
            // spPrice
            // 
            this.spPrice.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spPrice.Location = new System.Drawing.Point(278, 69);
            this.spPrice.Name = "spPrice";
            this.spPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spPrice.Properties.MaxValue = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.spPrice.Size = new System.Drawing.Size(145, 21);
            this.spPrice.TabIndex = 24;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(23, 72);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "分类：";
            // 
            // mtxtDesc
            // 
            this.mtxtDesc.Location = new System.Drawing.Point(88, 170);
            this.mtxtDesc.Name = "mtxtDesc";
            this.mtxtDesc.Size = new System.Drawing.Size(333, 49);
            this.mtxtDesc.TabIndex = 3;
            // 
            // txtPrizeName
            // 
            this.txtPrizeName.Location = new System.Drawing.Point(90, 37);
            this.txtPrizeName.Name = "txtPrizeName";
            this.txtPrizeName.Size = new System.Drawing.Size(331, 21);
            this.txtPrizeName.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 172);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "说明：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "奖品名称：";
            // 
            // txtSelectChar
            // 
            this.txtSelectChar.Location = new System.Drawing.Point(90, 103);
            this.txtSelectChar.Name = "txtSelectChar";
            this.txtSelectChar.Size = new System.Drawing.Size(105, 21);
            this.txtSelectChar.TabIndex = 36;
            // 
            // dateBeginDate
            // 
            this.dateBeginDate.EditValue = null;
            this.dateBeginDate.Location = new System.Drawing.Point(90, 138);
            this.dateBeginDate.Name = "dateBeginDate";
            this.dateBeginDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBeginDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateBeginDate.Size = new System.Drawing.Size(105, 21);
            this.dateBeginDate.TabIndex = 37;
            // 
            // dateEndDate
            // 
            this.dateEndDate.EditValue = null;
            this.dateEndDate.Location = new System.Drawing.Point(278, 138);
            this.dateEndDate.Name = "dateEndDate";
            this.dateEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEndDate.Size = new System.Drawing.Size(143, 21);
            this.dateEndDate.TabIndex = 38;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Location = new System.Drawing.Point(462, 51);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureEdit1.Properties.InitialImage")));
            this.pictureEdit1.Size = new System.Drawing.Size(230, 228);
            this.pictureEdit1.TabIndex = 39;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(541, 286);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(87, 27);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "选择图片";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FrmE_PrizeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 388);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "FrmE_PrizeEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑奖品";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoOther.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spAllNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrizeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSelectChar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBeginDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBeginDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.MemoEdit mtxtDesc;
        private DevExpress.XtraEditors.TextEdit txtPrizeName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit spPrice;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtType;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.MemoEdit memoOther;
        private DevExpress.XtraEditors.SpinEdit spAllNum;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.DateEdit dateEndDate;
        private DevExpress.XtraEditors.DateEdit dateBeginDate;
        private DevExpress.XtraEditors.TextEdit txtSelectChar;
    }
}