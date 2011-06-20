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
namespace Ebada.Scgl.Xtgl
{
    public partial class frmOrgEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<mOrg> m_CityDic = new SortableSearchableBindingList<mOrg>();

        public frmOrgEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.textEdit1.DataBindings.Add("EditValue", rowData, "OrgCode");
            this.textEdit2.DataBindings.Add("EditValue", rowData, "OrgName");
            this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

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
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<mOrg>(value as mOrg, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            //this.m_CityDic.Clear();
            //this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<mOrg>(" WHERE Citylevel = '2'"));
            IList<DicType> list = new List<DicType>();
            list.Add(new DicType("0", "机构"));
            list.Add(new DicType("1", "供电所"));
            list.Add(new DicType("2", "变电所"));
            this.SetComboBoxData(this.lookUpEdit1, "Value", "Key", "请选择", "种类", list);

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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post) {
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

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}