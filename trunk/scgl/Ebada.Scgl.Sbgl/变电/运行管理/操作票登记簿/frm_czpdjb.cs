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
    public partial class frm_czpdjb : FormBase, IPopupFormEdit 
    {
        public frm_czpdjb()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_czpdjb rowData;
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
                    this.rowData = value as bdjl_czpdjb;
                    Initlkue();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_czpdjb>(value as bdjl_czpdjb, rowData);
                }
            }
        }

        private void Initlkue()
        {
            ComboBoxHelper.FillCBoxByDyk("变电操作票登记簿", "操作票使用编号", txtczpsybh);
            IList<mUser> userList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<mUser>("where OrgCode='" + rowData.OrgCode + "'");
            if (userList == null)
                return;
            List<DicType> userTypeList = new List<DicType>();
            foreach (mUser user in userList)
            {
                userTypeList.Add(new DicType(user.UserName, user.UserName));
            }
            SetComboBoxData(lkueczr, "Value", "Key", "请选择", "操作人", userTypeList);
            SetComboBoxData(lkuejhr, "Value", "Key", "请选择", "监护人", userTypeList);
            SetComboBoxData(lkuezbr, "Value", "Key", "请选择", "值班人", userTypeList);
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
            this.daterq.DataBindings.Add("EditValue", rowData, "dDate");
            this.txtczpsybh.DataBindings.Add("EditValue", rowData, "czpsybh");
            this.lkueczr.DataBindings.Add("EditValue", rowData, "czr");
            this.lkuejhr.DataBindings.Add("EditValue", rowData, "jhr");
            this.lkuezbr.DataBindings.Add("EditValue", rowData, "zbr");
            this.meoczrw.DataBindings.Add("EditValue", rowData, "czrw");

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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("变电操作票登记簿", "操作任务", meoczrw);

        }

    }
}