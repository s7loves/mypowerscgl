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
    public partial class frm_gzpdjb : FormBase, IPopupFormEdit 
    {
        public frm_gzpdjb()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_gzpdjb rowData;
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
                    this.rowData = value as bdjl_gzpdjb;
                    Initlkue();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_gzpdjb>(value as bdjl_gzpdjb, rowData);
                }
            }
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
            SetComboBoxData(this.lkuegzfpr, "Value", "Key", "请选择", "工作票签发人", userTypeList);
            SetComboBoxData(this.lkuegzfzr, "Value", "Key", "请选择", "工作负责人", userTypeList);
            SetComboBoxData(this.lkuegzxkr, "Value", "Key", "请选择", "工作许可人", userTypeList);
            SetComboBoxData(this.lkuezbz, "Value", "Key", "请选择", "值班长", userTypeList);
        }
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
        private void dataBind()
        {
            this.txtOrgName.DataBindings.Add("EditValue", rowData, "c1");
            this.txtgzpbh.DataBindings.Add("EditValue", rowData, "gzpbh");
            this.txtgzpzl.DataBindings.Add("EditValue", rowData, "gzpzl");
            this.lkuegzfzr.DataBindings.Add("EditValue", rowData, "gzpfzr");
            this.dateStartTime.DataBindings.Add("EditValue", rowData, "gzkssj");
            this.dateEndTime.DataBindings.Add("EditValue", rowData, "gzjssj");
            this.lkuegzxkr.DataBindings.Add("EditValue", rowData, "gzxkr");
            this.lkuezbz.DataBindings.Add("EditValue", rowData, "zbz");
            this.lkuegzfpr.DataBindings.Add("EditValue", rowData, "gzpqfr");
            this.meogzddjnr.DataBindings.Add("EditValue", rowData, "gzddjnr");
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}