namespace Ebada.SCGL
{
    using Ebada.UI.Base;
    using System;
    using System.Drawing;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using Ebada.Core;
    using Ebada.SCGL.Properties;
    using Ebada.Client;
    using Ebada.Client.Platform;
    
    public partial class frmLogin : FormBase
    {
        public frmLogin()
        {
            this.InitializeComponent();

            this.Shown += new System.EventHandler(this.FormLogin_Shown);
            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);

            this.txtLoginName.KeyDown += new KeyEventHandler(txtLoginName_KeyDown);
            this.txtPassword.KeyDown += new KeyEventHandler(txtPassword_KeyDown);
        }

        void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.btnOK_Click(sender, e);
        }

        void txtLoginName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.btnOK_Click(sender, e);
        }

        private UserBase m_UserBase = null;

        private void btnOK_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (this.txtLoginName.Text.Trim() == string.Empty)
                {
                    ClientHelper.ControlCheck(this, this.txtLoginName, "登录名不能为空", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                    this.txtLoginName.Focus();
                }
                else if (this.txtPassword.Text.Trim() == string.Empty)
                {
                    ClientHelper.ControlCheck(this, this.txtPassword, "密码不能为空", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                    this.txtPassword.Focus();
                }
                else
                {
                    string str = MainHelper.EncryptoPassword(this.txtPassword.Text);
                    MainHelper.LoginName = this.txtLoginName.Text.Trim();
                    MainHelper.Password = str;
                    
                    this.m_UserBase = MainHelper.ValidateLogin();
                    MainHelper.UserBaseX.User_ID = this.m_UserBase.LoginName;
                    MainHelper.UserBaseX.Empolyee_ID = this.m_UserBase.UserID;
                    MainHelper.UserBaseX.Empolyee_Name = this.m_UserBase.RealName;

                    base.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception exception)
            {
                MainHelper.ShowException(exception);
            }
        }

        public string UserID
        {
            get { return this.m_UserBase.UserID; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.RememberLoginName = this.cmbRememberLoginName.Checked;
            Settings.Default.LoginName = this.cmbRememberLoginName.Checked ? this.txtLoginName.Text : "";
            Settings.Default.Save();
        }

        private void FormLogin_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            if (Settings.Default.RememberLoginName)
            {
                this.cmbRememberLoginName.Checked = true;
                this.txtLoginName.Text = Settings.Default.LoginName;
            }
            if (this.txtLoginName.Text.Length > 0)
            {
                this.txtPassword.Focus();
            }
            else
            {
                this.txtLoginName.Focus();
            }
        }
    }
}

