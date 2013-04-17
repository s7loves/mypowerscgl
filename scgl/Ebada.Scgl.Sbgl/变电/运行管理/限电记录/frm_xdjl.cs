using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.UI.Base;  
using Ebada.Client;
using Ebada.Client.Platform;
using Ebada.Core;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Collections;

namespace Ebada.Scgl.Sbgl
{
    public partial class frm_xdjl : FormBase, IPopupFormEdit
    {
        public frm_xdjl()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_xdjl rowData;
        public object RowData
        {
            get
            {
                return this.rowData;
            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as bdjl_xdjl;
                    Initlkue();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_xdjl>(value as bdjl_xdjl, rowData);
                }
            }
        }

        private void dataBind()
        {
            this.txtOrgName.DataBindings.Add("EditValue", rowData, "c1");
            this.datexdsj.DataBindings.Add("EditValue", rowData, "xdsj");
            this.lkuexdflr.DataBindings.Add("EditValue", rowData, "xdflr");
            this.lkuexdslr.DataBindings.Add("EditValue", rowData, "xdslr");
            this.txtxdxl.DataBindings.Add("EditValue", rowData, "xdxl");
            this.txtxddl.DataBindings.Add("EditValue", rowData, "xddl");
            this.datesdsj.DataBindings.Add("EditValue", rowData, "sdsj");
            this.lkuesdflr.DataBindings.Add("EditValue", rowData, "sdflr");
            this.lkuesdslr.DataBindings.Add("EditValue", rowData, "sdslr");
            this.txtsddl.DataBindings.Add("EditValue", rowData, "xdsdl");
            this.txtxdzhdl.DataBindings.Add("EditValue", rowData, "xdzhdl");
            this.txtbz.DataBindings.Add("EditValue", rowData, "bz");

        }

        private void Initlkue()
        {
            IList<mUser> userList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<mUser>("where OrgCode='" + rowData.OrgCode + "'");
            if (userList == null)
                return;
            List<DicType> userTypeList = new List<DicType>();
            foreach (mUser user in userList)
            {
                userTypeList.Add(new DicType(user.UserName, user.UserName));
            }
            SetComboBoxData(this.lkuexdflr, "Value", "Key", "请选择", "限电发令人", userTypeList);
            SetComboBoxData(this.lkuexdslr, "Value", "Key", "请选择", "限电受令人", userTypeList);
            SetComboBoxData(this.lkuesdflr, "Value", "Key", "请选择", "送电发令人", userTypeList);
            SetComboBoxData(this.lkuesdslr, "Value", "Key", "请选择", "送电受令人", userTypeList);
        }

        //SetComboBoxData(lkueStartGt, "Value", "Key", "请选择", "起始杆塔", gtDictypeList);
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post)
        {
            comboBox.Properties.Columns.Clear();
            comboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBox.Properties.DataSource = post;
            comboBox.Properties.DisplayMember = displayMember;
            comboBox.Properties.ValueMember = valueMember;
            comboBox.Properties.NullText = nullTest;
            comboBox.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(valueMember, "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember, cnStr)});
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(datesdsj.EditValue) < Convert.ToDateTime(datexdsj.EditValue))
            {
                MsgBox.ShowWarningMessageBox("送电时间必须晚于限电时间!");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

       

        
       
    }
}