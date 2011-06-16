namespace Ebada.SCGL.WorkFlow.Tool
{
    partial class frmFrmworkTree
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
            this.grpDynamic = new System.Windows.Forms.GroupBox();
            this.tbxFormName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxMouseClick = new System.Windows.Forms.CheckBox();
            this.cmbxNodeType = new System.Windows.Forms.ComboBox();
            this.tbxMethodName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxDllFile = new System.Windows.Forms.TextBox();
            this.tbxClassName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbxImageIndex = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxNodeCaption = new System.Windows.Forms.TextBox();
            this.tbxFatherCaption = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxVisable = new System.Windows.Forms.CheckBox();
            this.cbxBlankWindow = new System.Windows.Forms.CheckBox();
            this.grpBase = new System.Windows.Forms.GroupBox();
            this.cbxSDIWindows = new System.Windows.Forms.CheckBox();
            this.grpCommand = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpDynamic.SuspendLayout();
            this.grpBase.SuspendLayout();
            this.grpCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDynamic
            // 
            this.grpDynamic.Controls.Add(this.tbxFormName);
            this.grpDynamic.Controls.Add(this.label6);
            this.grpDynamic.Controls.Add(this.cbxMouseClick);
            this.grpDynamic.Controls.Add(this.cmbxNodeType);
            this.grpDynamic.Controls.Add(this.tbxMethodName);
            this.grpDynamic.Controls.Add(this.label10);
            this.grpDynamic.Controls.Add(this.tbxDllFile);
            this.grpDynamic.Controls.Add(this.tbxClassName);
            this.grpDynamic.Controls.Add(this.label9);
            this.grpDynamic.Controls.Add(this.label7);
            this.grpDynamic.Controls.Add(this.label8);
            this.grpDynamic.Location = new System.Drawing.Point(1, 131);
            this.grpDynamic.Name = "grpDynamic";
            this.grpDynamic.Size = new System.Drawing.Size(426, 179);
            this.grpDynamic.TabIndex = 19;
            this.grpDynamic.TabStop = false;
            this.grpDynamic.Text = "动态调用参数";
            // 
            // tbxFormName
            // 
            this.tbxFormName.Location = new System.Drawing.Point(77, 147);
            this.tbxFormName.Name = "tbxFormName";
            this.tbxFormName.Size = new System.Drawing.Size(289, 21);
            this.tbxFormName.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "Dll文件名:";
            // 
            // cbxMouseClick
            // 
            this.cbxMouseClick.AutoSize = true;
            this.cbxMouseClick.Location = new System.Drawing.Point(231, 91);
            this.cbxMouseClick.Name = "cbxMouseClick";
            this.cbxMouseClick.Size = new System.Drawing.Size(72, 16);
            this.cbxMouseClick.TabIndex = 9;
            this.cbxMouseClick.Text = "单击执行";
            this.cbxMouseClick.UseVisualStyleBackColor = true;
            // 
            // cmbxNodeType
            // 
            this.cmbxNodeType.FormattingEnabled = true;
            this.cmbxNodeType.Items.AddRange(new object[] {
            "NullType",
            "Function",
            "Window"});
            this.cmbxNodeType.Location = new System.Drawing.Point(77, 89);
            this.cmbxNodeType.Name = "cmbxNodeType";
            this.cmbxNodeType.Size = new System.Drawing.Size(148, 20);
            this.cmbxNodeType.TabIndex = 8;
            // 
            // tbxMethodName
            // 
            this.tbxMethodName.Location = new System.Drawing.Point(77, 115);
            this.tbxMethodName.Name = "tbxMethodName";
            this.tbxMethodName.Size = new System.Drawing.Size(289, 21);
            this.tbxMethodName.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "执行方式:";
            // 
            // tbxDllFile
            // 
            this.tbxDllFile.Location = new System.Drawing.Point(78, 29);
            this.tbxDllFile.Name = "tbxDllFile";
            this.tbxDllFile.Size = new System.Drawing.Size(289, 21);
            this.tbxDllFile.TabIndex = 10;
            // 
            // tbxClassName
            // 
            this.tbxClassName.Location = new System.Drawing.Point(77, 61);
            this.tbxClassName.Name = "tbxClassName";
            this.tbxClassName.Size = new System.Drawing.Size(289, 21);
            this.tbxClassName.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "窗体名:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "类名:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "方法名:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "图标:";
            // 
            // cmbxImageIndex
            // 
            this.cmbxImageIndex.FormattingEnabled = true;
            this.cmbxImageIndex.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cmbxImageIndex.Location = new System.Drawing.Point(77, 83);
            this.cmbxImageIndex.Name = "cmbxImageIndex";
            this.cmbxImageIndex.Size = new System.Drawing.Size(96, 20);
            this.cmbxImageIndex.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "上级节点:";
            // 
            // tbxNodeCaption
            // 
            this.tbxNodeCaption.Location = new System.Drawing.Point(77, 56);
            this.tbxNodeCaption.Name = "tbxNodeCaption";
            this.tbxNodeCaption.Size = new System.Drawing.Size(289, 21);
            this.tbxNodeCaption.TabIndex = 5;
            // 
            // tbxFatherCaption
            // 
            this.tbxFatherCaption.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tbxFatherCaption.Location = new System.Drawing.Point(77, 29);
            this.tbxFatherCaption.Name = "tbxFatherCaption";
            this.tbxFatherCaption.ReadOnly = true;
            this.tbxFatherCaption.Size = new System.Drawing.Size(289, 21);
            this.tbxFatherCaption.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "当前节点:";
            // 
            // cbxVisable
            // 
            this.cbxVisable.AutoSize = true;
            this.cbxVisable.Checked = true;
            this.cbxVisable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxVisable.Location = new System.Drawing.Point(9, 371);
            this.cbxVisable.Name = "cbxVisable";
            this.cbxVisable.Size = new System.Drawing.Size(72, 16);
            this.cbxVisable.TabIndex = 17;
            this.cbxVisable.Text = "是否显示";
            this.cbxVisable.UseVisualStyleBackColor = true;
            // 
            // cbxBlankWindow
            // 
            this.cbxBlankWindow.AutoSize = true;
            this.cbxBlankWindow.Location = new System.Drawing.Point(98, 20);
            this.cbxBlankWindow.Name = "cbxBlankWindow";
            this.cbxBlankWindow.Size = new System.Drawing.Size(108, 16);
            this.cbxBlankWindow.TabIndex = 9;
            this.cbxBlankWindow.Text = "在新窗口中打开";
            this.cbxBlankWindow.UseVisualStyleBackColor = true;
            // 
            // grpBase
            // 
            this.grpBase.Controls.Add(this.label5);
            this.grpBase.Controls.Add(this.cmbxImageIndex);
            this.grpBase.Controls.Add(this.label3);
            this.grpBase.Controls.Add(this.tbxNodeCaption);
            this.grpBase.Controls.Add(this.tbxFatherCaption);
            this.grpBase.Controls.Add(this.label4);
            this.grpBase.Location = new System.Drawing.Point(3, 0);
            this.grpBase.Name = "grpBase";
            this.grpBase.Size = new System.Drawing.Size(426, 125);
            this.grpBase.TabIndex = 18;
            this.grpBase.TabStop = false;
            this.grpBase.Text = "基本信息";
            // 
            // cbxSDIWindows
            // 
            this.cbxSDIWindows.AutoSize = true;
            this.cbxSDIWindows.Location = new System.Drawing.Point(242, 20);
            this.cbxSDIWindows.Name = "cbxSDIWindows";
            this.cbxSDIWindows.Size = new System.Drawing.Size(72, 16);
            this.cbxSDIWindows.TabIndex = 10;
            this.cbxSDIWindows.Text = "模态窗口";
            this.cbxSDIWindows.UseVisualStyleBackColor = true;
            // 
            // grpCommand
            // 
            this.grpCommand.Controls.Add(this.cbxSDIWindows);
            this.grpCommand.Controls.Add(this.cbxBlankWindow);
            this.grpCommand.Location = new System.Drawing.Point(1, 316);
            this.grpCommand.Name = "grpCommand";
            this.grpCommand.Size = new System.Drawing.Size(426, 49);
            this.grpCommand.TabIndex = 20;
            this.grpCommand.TabStop = false;
            this.grpCommand.Text = "窗口模式";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(354, 394);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "关闭(&E)";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(273, 394);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // frmFrmworkTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 429);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpDynamic);
            this.Controls.Add(this.cbxVisable);
            this.Controls.Add(this.grpBase);
            this.Controls.Add(this.grpCommand);
            this.Name = "frmFrmworkTree";
            this.Text = "信息维护";
            this.grpDynamic.ResumeLayout(false);
            this.grpDynamic.PerformLayout();
            this.grpBase.ResumeLayout(false);
            this.grpBase.PerformLayout();
            this.grpCommand.ResumeLayout(false);
            this.grpCommand.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDynamic;
        private System.Windows.Forms.TextBox tbxFormName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbxMouseClick;
        private System.Windows.Forms.ComboBox cmbxNodeType;
        private System.Windows.Forms.TextBox tbxMethodName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxDllFile;
        private System.Windows.Forms.TextBox tbxClassName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbxImageIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxNodeCaption;
        private System.Windows.Forms.TextBox tbxFatherCaption;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbxVisable;
        private System.Windows.Forms.CheckBox cbxBlankWindow;
        private System.Windows.Forms.GroupBox grpBase;
        private System.Windows.Forms.CheckBox cbxSDIWindows;
        private System.Windows.Forms.GroupBox grpCommand;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}