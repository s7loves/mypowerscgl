using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ebada.Exam
{
    public partial class FrmE_ExaminationUserEdit : DevExpress.XtraEditors.XtraForm
    {
        public FrmE_ExaminationUserEdit(string type, string orgidall, string orgids, string userids)
        {

            InitializeComponent();
            uCmOrgUserTree1.Type = type;
            uCmOrgUserTree1.OrgIDAll = orgidall;
            uCmOrgUserTree1.OrgIDs = orgids;
            //uCmOrgUserTree1.UserIDs = userids;
            _userids = userids;
            
        }
        public string type = "org";
        public string _orgidall = string.Empty;
        public string _orgids = string.Empty;
        public string _userids = string.Empty;
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            uCmOrgUserTree1.UserIDs = _userids;
        }
        //protected override void OnLoad(EventArgs e)
        //{
        //    uCmOrgUserTree1.Type = type;
        //    uCmOrgUserTree1.OrgIDAll = orgidall;
        //    uCmOrgUserTree1.OrgIDs = orgids;
        //    uCmOrgUserTree1.UserIDs = userids;
        //}

        string _getorgids = string.Empty;
        public string GetOgrIDS
        {
            get
            {
                return _getorgids;
            }
            
        }
        string _getuserids = string.Empty;
        public string GetUserIDS
        {
            get
            {
                return _getuserids;
            }

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            _getorgids = uCmOrgUserTree1.GetOrgIDS();
            _getuserids = uCmOrgUserTree1.GetUserIDS();
            this.DialogResult = DialogResult.OK;
        }
    }
}