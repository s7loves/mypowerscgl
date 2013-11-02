namespace Ebada.Exam
{
    partial class FrmUserExam
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
            this.components = new System.ComponentModel.Container();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labLeftTime = new System.Windows.Forms.Label();
            this.labAllNum = new System.Windows.Forms.Label();
            this.labLeftNum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labMB = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 89);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1082, 540);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "试卷-答题区";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(2, 23);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1078, 515);
            this.panelControl1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1074, 511);
            this.panel1.TabIndex = 0;
            this.panel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 34;
            this.label1.Text = "剩余时间：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(862, 19);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 36);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "交 卷";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 36;
            this.label2.Text = "总试题数：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 37;
            this.label3.Text = "剩余题数：";
            // 
            // labLeftTime
            // 
            this.labLeftTime.AutoSize = true;
            this.labLeftTime.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.labLeftTime.ForeColor = System.Drawing.Color.Red;
            this.labLeftTime.Location = new System.Drawing.Point(89, 23);
            this.labLeftTime.Name = "labLeftTime";
            this.labLeftTime.Size = new System.Drawing.Size(155, 33);
            this.labLeftTime.TabIndex = 3;
            this.labLeftTime.Text = "剩余时间：";
            // 
            // labAllNum
            // 
            this.labAllNum.AutoSize = true;
            this.labAllNum.ForeColor = System.Drawing.Color.Blue;
            this.labAllNum.Location = new System.Drawing.Point(369, 19);
            this.labAllNum.Name = "labAllNum";
            this.labAllNum.Size = new System.Drawing.Size(67, 14);
            this.labAllNum.TabIndex = 39;
            this.labAllNum.Text = "总试题数：";
            // 
            // labLeftNum
            // 
            this.labLeftNum.AutoSize = true;
            this.labLeftNum.ForeColor = System.Drawing.Color.Blue;
            this.labLeftNum.Location = new System.Drawing.Point(370, 50);
            this.labLeftNum.Name = "labLeftNum";
            this.labLeftNum.Size = new System.Drawing.Size(67, 14);
            this.labLeftNum.TabIndex = 40;
            this.labLeftNum.Text = "总试题数：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.ForestGreen;
            this.label4.Location = new System.Drawing.Point(25, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(511, 14);
            this.label4.TabIndex = 41;
            this.label4.Text = "说明：如果考试因意中止，您可以再次考试，已答试题不会记录，考试时间从第一次开始累计。";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labMB
            // 
            this.labMB.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.labMB.Appearance.Options.UseFont = true;
            this.labMB.Location = new System.Drawing.Point(944, 65);
            this.labMB.Name = "labMB";
            this.labMB.Size = new System.Drawing.Size(102, 18);
            this.labMB.TabIndex = 42;
            this.labMB.Text = "labelControl1";
            this.labMB.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(971, 19);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(95, 36);
            this.simpleButton1.TabIndex = 43;
            this.simpleButton1.Text = "退  出";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FrmUserExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 629);
            this.ControlBox = false;
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labMB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labLeftNum);
            this.Controls.Add(this.labAllNum);
            this.Controls.Add(this.labLeftTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserExam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "下在";
            this.Load += new System.EventHandler(this.FrmUserExam_Load);
            this.Activated += new System.EventHandler(this.FrmUserExam_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labLeftTime;
        private System.Windows.Forms.Label labAllNum;
        private System.Windows.Forms.Label labLeftNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.LabelControl labMB;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}