namespace Ebada.Exam
{
    partial class UcExamTroQuestonPD
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
            this.labQOrder = new DevExpress.XtraEditors.LabelControl();
            this.labTG = new DevExpress.XtraEditors.LabelControl();
            this.rOk = new System.Windows.Forms.RadioButton();
            this.rError = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // labQOrder
            // 
            this.labQOrder.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labQOrder.Appearance.Options.UseFont = true;
            this.labQOrder.Location = new System.Drawing.Point(13, 6);
            this.labQOrder.Name = "labQOrder";
            this.labQOrder.Size = new System.Drawing.Size(0, 14);
            this.labQOrder.TabIndex = 0;
            // 
            // labTG
            // 
            this.labTG.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labTG.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labTG.Appearance.Options.UseFont = true;
            this.labTG.Appearance.Options.UseForeColor = true;
            this.labTG.Appearance.Options.UseTextOptions = true;
            this.labTG.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.labTG.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labTG.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labTG.Location = new System.Drawing.Point(41, 6);
            this.labTG.Name = "labTG";
            this.labTG.Size = new System.Drawing.Size(917, 42);
            this.labTG.TabIndex = 1;
            this.labTG.Text = "asdfasfsdfsdfffffffffffffffffasdfasdfsadf";
            // 
            // rOk
            // 
            this.rOk.AutoSize = true;
            this.rOk.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold);
            this.rOk.ForeColor = System.Drawing.Color.Green;
            this.rOk.Location = new System.Drawing.Point(62, 58);
            this.rOk.Name = "rOk";
            this.rOk.Size = new System.Drawing.Size(84, 16);
            this.rOk.TabIndex = 2;
            this.rOk.TabStop = true;
            this.rOk.Text = "√ ( 对 )";
            this.rOk.UseVisualStyleBackColor = true;
            this.rOk.CheckedChanged += new System.EventHandler(this.rOk_CheckedChanged);
            // 
            // rError
            // 
            this.rError.AutoSize = true;
            this.rError.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold);
            this.rError.ForeColor = System.Drawing.Color.Red;
            this.rError.Location = new System.Drawing.Point(175, 58);
            this.rError.Name = "rError";
            this.rError.Size = new System.Drawing.Size(84, 16);
            this.rError.TabIndex = 3;
            this.rError.TabStop = true;
            this.rError.Text = "× ( 错 )";
            this.rError.UseVisualStyleBackColor = true;
            this.rError.CheckedChanged += new System.EventHandler(this.rError_CheckedChanged);
            // 
            // UcExamTroQuestonPD
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rError);
            this.Controls.Add(this.rOk);
            this.Controls.Add(this.labTG);
            this.Controls.Add(this.labQOrder);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "UcExamTroQuestonPD";
            this.Size = new System.Drawing.Size(980, 91);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labQOrder;
        private DevExpress.XtraEditors.LabelControl labTG;
        private System.Windows.Forms.RadioButton rOk;
        private System.Windows.Forms.RadioButton rError;
    }
}
