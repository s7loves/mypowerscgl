using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Platform.Model;
using Ebada.UI.Base;
using Ebada.Client;
using Ebada.Client.Platform;
using Ebada.Core;
namespace Ebada.Modules.Demo
{
    public partial class frmOrg2Edit : FormBase, IPopupFormEdit
    {
        SortableSearchableBindingList<dicCity> m_CityDic = new SortableSearchableBindingList<dicCity>();

        public frmOrg2Edit()
        {
            InitializeComponent();
        }

        void SetOrgData(VOrgLevel org)
        {
            if (null == org)
                return;
            rowData = org;
            this.txtAddress.Text = org.Address;
            this.cltCity.Properties.KeyValue = org.CityCode;
            this.txtCnFullName.Text = org.cnFullName;
            this.txtCnName.Text = org.cnName;
            this.checkEditEnabled.Checked = org.Enabled == "1" ? true : false;
            this.txtEnFullName.Text = org.enFullName;
            this.txtEnName.Text = org.enName;
            this.txtOrgCode.Text = org.OrgCode;
            this.txtOurCompany.Text = org.OurCompany;
            this.txtPostCode.Text = org.Postcode;
            this.txtRemark.Text = org.Remark;
            this.txtWebsite.Text = org.Website;
        }

        VOrgLevel GetOrgData()
        {
            VOrgLevel org = rowData;
            org.Address = this.txtAddress.Text;

            object code = this.cltCity.Properties.KeyValue;

            if (null != code && code.ToString().Length > 0)
                org.CityCode = code.ToString();

            org.cnFullName = this.txtCnFullName.Text;
            org.cnName = this.txtCnName.Text;
            org.Enabled = this.checkEditEnabled.Checked ? "1" : "0";
            org.enFullName = this.txtEnFullName.Text;
            org.enName = this.txtEnName.Text;
            org.OrgCode = this.txtOrgCode.Text;
            org.OurCompany = this.txtOurCompany.Text;
            org.Postcode = this.txtPostCode.Text;
            org.Remark = this.txtRemark.Text;
            org.Website = this.txtWebsite.Text;

            return org;
        }

        #region IPopupFormEdit Members
        private VOrgLevel rowData = null;

        public object RowData
        {
            get
            {
                return this.GetOrgData();
            }
            set
            {
                this.rowData = value as VOrgLevel;
                this.SetOrgData(this.rowData);
                this.InitComboBoxData(this.rowData.CityCode);
            }
        }

        #endregion

        private void InitComboBoxData(string cityCode)
        {
            this.m_CityDic.Clear();
            this.m_CityDic.Add(MainHelper.GetSqlMap<mPost>().GetList<dicCity>(null));
            this.SetComboBoxData(this.cltCity, "cnName", "Code", "请选择", "城市名称", this.m_CityDic);

            if (null != cityCode && cityCode.Trim().Length > 0)
                this.cltCity.Properties.KeyValue = cityCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        /// <param name="nullTest"></param>
        /// <param name="cnStr"></param>
        /// <param name="post"></param>
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, SortableSearchableBindingList<dicCity> post)
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
    }
}