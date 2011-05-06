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
namespace Ebada.Modules.Demo {
    public partial class frmOrgEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<dicCity> m_CityDic = new SortableSearchableBindingList<dicCity>();

        public frmOrgEdit() {
            InitializeComponent();
        }
        void dataBind() {
            this.checkEditEnabled.Properties.ValueChecked = "1";
            this.checkEditEnabled.Properties.ValueUnchecked = "0";

            this.cltCity.DataBindings.Add("EditValue", rowData, "CityCode");
            this.txtCnFullName.DataBindings.Add("EditValue", rowData, "cnFullName");
            this.txtCnName.DataBindings.Add("EditValue", rowData, "cnName");
            this.checkEditEnabled.DataBindings.Add("EditValue", rowData, "Enabled");
            this.txtEnFullName.DataBindings.Add("EditValue", rowData, "enFullName");
            this.txtEnName.DataBindings.Add("EditValue", rowData, "enName");
            this.txtOrgCode.DataBindings.Add("EditValue", rowData, "OrgCode");
            this.txtOurCompany.DataBindings.Add("EditValue", rowData, "OurCompany");
            this.txtPostCode.DataBindings.Add("EditValue", rowData, "Postcode");
            this.txtRemark.DataBindings.Add("EditValue", rowData, "Remark");
            this.txtWebsite.DataBindings.Add("EditValue", rowData, "Website");
            this.txtAddress.DataBindings.Add("EditValue", rowData, "Address");

        }
        #region IPopupFormEdit Members
        private mOrg rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as mOrg;
                    this.InitComboBoxData(this.rowData.CityCode);
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<mOrg>(value as mOrg, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData(string cityCode) {
            this.m_CityDic.Clear();
            this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<dicCity>(" WHERE Citylevel = '2'"));
            this.SetComboBoxData(this.cltCity, "cnName", "AreaCode", "请选择", "城市名称", this.m_CityDic);

            //if (null != cityCode && cityCode.Trim().Length > 0)
            //    this.cltCity.Properties.KeyValue = cityCode;
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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, SortableSearchableBindingList<dicCity> post) {
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