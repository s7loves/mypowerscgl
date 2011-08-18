using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Ebada.Client.Platform;
using Ebada.Scgl.Model;
using Ebada.Components;

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
            uCmFunctionTree1.FocusedNodeChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.mModule>(uCmFunctionTree1_FocusedNodeChanged);
        }

        void uCmFunctionTree1_FocusedNodeChanged(object sender, Ebada.Scgl.Model.mModule obj) {
            initcheckbox(obj.Modu_ID);
            allCheckEdit.CheckState = CheckState.Unchecked;
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
        private void initcheckbox(string modu_id) {
            checkedListBoxControl1.Items.Clear();
            IList<mModulFun> li = MainHelper.PlatformSqlMap.GetList<mModulFun>("SelectmModulFunList", " where Modu_ID='" + modu_id + "'");
            foreach(mModulFun mf in li) 
            {
                CheckedListBoxItem item = new CheckedListBoxItem();
                item.Description  = mf.FunName ;
                item.Value = mf.FunID;
                rRoleFun md = (rRoleFun)MainHelper.PlatformSqlMap.GetObject("SelectrRoleFunList", " where FunID='" + mf.FunID + "' and RoleID='" + mRoleID + "'");
                if (md != null)
                {
                    item.CheckState = CheckState.Checked;
                }
                else
                {
                    item.CheckState = CheckState.Unchecked;
                }
                checkedListBoxControl1.Items.Add(item);
            }
        }

        private void checkedListBoxControl1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e) {
           
            
                MainHelper.PlatformSqlMap.DeleteByWhere<rRoleFun>(" where FunID='" + checkedListBoxControl1.Items[e.Index].Value + "'");
                if (e.State == CheckState.Checked)
                {
                    rRoleFun md = new rRoleFun();
                    md.FunID = checkedListBoxControl1.Items[e.Index].Value.ToString();
                    md.RoleID = this.mRoleID;
                    MainHelper.PlatformSqlMap.Create<rRoleFun>(md);
                }
        }

        private void checkedListBoxControl1_ItemChecking(object sender, ItemCheckingEventArgs e)
        {
            if (uCmFunctionTree1.FocusedNode.Checked == false) e.Cancel = true;
        }

        private void allCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (uCmFunctionTree1.FocusedNode.Checked == false)
            {
                allCheckEdit.CheckState = CheckState.Unchecked;
                return;
            }
           

            for (int i = 0; i < checkedListBoxControl1.Items.Count; i++)
            {
                checkedListBoxControl1.Items[i].CheckState = allCheckEdit.CheckState;
                MainHelper.PlatformSqlMap.DeleteByWhere<rRoleFun>(" where FunID='" + checkedListBoxControl1.Items[i].Value  + "'");
                if (checkedListBoxControl1.Items[i].CheckState  == CheckState.Checked)
                {
                    rRoleFun md = new rRoleFun();
                    md.FunID = checkedListBoxControl1.Items[i].Value.ToString();
                    md.RoleID = this.mRoleID;
                    MainHelper.PlatformSqlMap.Create<rRoleFun>(md);
                }
            }
        }
    }
}