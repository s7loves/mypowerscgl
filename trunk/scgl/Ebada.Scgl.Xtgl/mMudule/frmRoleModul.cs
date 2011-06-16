using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ebada.Scgl.Xtgl
{
    public partial class frmRoleModul:XtraForm
    {
        string mRoleID = "";
        public frmRoleModul(string roleid,string rolename)
        {
            InitializeComponent();
            mRoleID = roleid;
            Text += string.Format("—（{0}）", rolename);
            this.btnOK.Click += new EventHandler(btnOK_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            this.uCmFunctionTree1.Save();
            this.DialogResult = DialogResult.OK;
        }
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            uCmFunctionTree1.RoleID = mRoleID;
        }
    }
}