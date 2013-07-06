namespace Ebada.Scgl.Sbgl
{
    partial class frm_xdctzjlb
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
            this.lblsj = new DevExpress.XtraEditors.LabelControl();
            this.datesj = new DevExpress.XtraEditors.DateEdit();
            this.lbldcdy = new DevExpress.XtraEditors.LabelControl();
            this.lbldl = new DevExpress.XtraEditors.LabelControl();
            this.lbltrdcgs = new DevExpress.XtraEditors.LabelControl();
            this.lblbzdcdy = new DevExpress.XtraEditors.LabelControl();
            this.lbljcr = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lkuejcr = new DevExpress.XtraEditors.LookUpEdit();
            this.txtdcdy = new DevExpress.XtraEditors.SpinEdit();
            this.txtdl = new DevExpress.XtraEditors.SpinEdit();
            this.txttrdcgs = new DevExpress.XtraEditors.SpinEdit();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.datesj.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datesj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuejcr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdcdy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttrdcgs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblsj
            // 
            this.lblsj.Location = new System.Drawing.Point(41, 36);
            this.lblsj.Name = "lblsj";
            this.lblsj.Size = new System.Drawing.Size(24, 14);
            this.lblsj.TabIndex = 0;
            this.lblsj.Text = "时间";
            // 
            // datesj
            // 
            this.datesj.EditValue = null;
            this.datesj.Location = new System.Drawing.Point(150, 33);
            this.datesj.Name = "datesj";
            this.datesj.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datesj.Properties.DisplayFormat.FormatString = "G";
            this.datesj.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datesj.Properties.EditFormat.FormatString = "G";
            this.datesj.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datesj.Properties.Mask.EditMask = "G";
            this.datesj.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.datesj.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True;
            this.datesj.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.datesj.Size = new System.Drawing.Size(396, 21);
            this.datesj.TabIndex = 1;
            // 
            // lbldcdy
            // 
            this.lbldcdy.Location = new System.Drawing.Point(41, 71);
            this.lbldcdy.Name = "lbldcdy";
            this.lbldcdy.Size = new System.Drawing.Size(70, 14);
            this.lbldcdy.TabIndex = 2;
            this.lbldcdy.Text = "电池电压(伏)";
            // 
            // lbldl
            // 
            this.lbldl.Location = new System.Drawing.Point(41, 106);
            this.lbldl.Name = "lbldl";
            this.lbldl.Size = new System.Drawing.Size(46, 14);
            this.lbldl.TabIndex = 4;
            this.lbldl.Text = "电流(安)";
            // 
            // lbltrdcgs
            // 
            this.lbltrdcgs.Location = new System.Drawing.Point(41, 141);
            this.lbltrdcgs.Name = "lbltrdcgs";
            this.lbltrdcgs.Size = new System.Drawing.Size(72, 14);
            this.lbltrdcgs.TabIndex = 6;
            this.lbltrdcgs.Text = "投入电池个数";
            // 
            // lblbzdcdy
            // 
            this.lblbzdcdy.Location = new System.Drawing.Point(41, 174);
            this.lblbzdcdy.Name = "lblbzdcdy";
            this.lblbzdcdy.Size = new System.Drawing.Size(94, 14);
            this.lblbzdcdy.TabIndex = 8;
            this.lblbzdcdy.Text = "标准电池电压(伏)\r\n";
            // 
            // lbljcr
            // 
            this.lbljcr.Location = new System.Drawing.Point(41, 273);
            this.lbljcr.Name = "lbljcr";
            this.lbljcr.Size = new System.Drawing.Size(36, 14);
            this.lbljcr.TabIndex = 10;
            this.lbljcr.Text = "检测人";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(363, 322);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(455, 322);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lkuejcr
            // 
            this.lkuejcr.Location = new System.Drawing.Point(150, 275);
            this.lkuejcr.Name = "lkuejcr";
            this.lkuejcr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkuejcr.Size = new System.Drawing.Size(396, 21);
            this.lkuejcr.TabIndex = 14;
            // 
            // txtdcdy
            // 
            this.txtdcdy.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtdcdy.Location = new System.Drawing.Point(150, 68);
            this.txtdcdy.Name = "txtdcdy";
            this.txtdcdy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtdcdy.Size = new System.Drawing.Size(396, 21);
            this.txtdcdy.TabIndex = 15;
            // 
            // txtdl
            // 
            this.txtdl.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtdl.Location = new System.Drawing.Point(150, 103);
            this.txtdl.Name = "txtdl";
            this.txtdl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtdl.Size = new System.Drawing.Size(396, 21);
            this.txtdl.TabIndex = 16;
            // 
            // txttrdcgs
            // 
            this.txttrdcgs.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txttrdcgs.Location = new System.Drawing.Point(150, 138);
            this.txttrdcgs.Name = "txttrdcgs";
            this.txttrdcgs.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txttrdcgs.Size = new System.Drawing.Size(396, 21);
            this.txttrdcgs.TabIndex = 17;
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(150, 175);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(396, 84);
            this.memoEdit1.TabIndex = 18;
            this.memoEdit1.ToolTip = "请用英文逗号分隔";
            // 
            // frm_xdctzjlb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 367);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.txttrdcgs);
            this.Controls.Add(this.txtdl);
            this.Controls.Add(this.txtdcdy);
            this.Controls.Add(this.lkuejcr);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lbljcr);
            this.Controls.Add(this.lblbzdcdy);
            this.Controls.Add(this.lbltrdcgs);
            this.Controls.Add(this.lbldl);
            this.Controls.Add(this.lbldcdy);
            this.Controls.Add(this.datesj);
            this.Controls.Add(this.lblsj);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_xdctzjlb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "蓄电池调整及检测记录簿";
            ((System.ComponentModel.ISupportInitialize)(this.datesj.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datesj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuejcr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdcdy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttrdcgs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblsj;
        private DevExpress.XtraEditors.DateEdit datesj;
        private DevExpress.XtraEditors.LabelControl lbldcdy;
        private DevExpress.XtraEditors.LabelControl lbldl;
        private DevExpress.XtraEditors.LabelControl lbltrdcgs;
        private DevExpress.XtraEditors.LabelControl lblbzdcdy;
        private DevExpress.XtraEditors.LabelControl lbljcr;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LookUpEdit lkuejcr;
        private DevExpress.XtraEditors.SpinEdit txtdcdy;
        private DevExpress.XtraEditors.SpinEdit txtdl;
        private DevExpress.XtraEditors.SpinEdit txttrdcgs;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
    }
}