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
namespace Ebada.Scgl.Yxgl
{
    public partial class frm22Edit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_22> m_CityDic = new SortableSearchableBindingList<PJ_22>();

        public frm22Edit() {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "OrgName");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "ph");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "bxsj");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "bxdd");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "xlfzr");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "xlry");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "zbslr");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "bggzqc");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "bgfs");
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "bxrxm");
            this.comboBoxEdit11.DataBindings.Add("EditValue", rowData, "lxdh");
            this.comboBoxEdit12.DataBindings.Add("EditValue", rowData, "sjgzqc");
            this.comboBoxEdit13.DataBindings.Add("EditValue", rowData, "sycl");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "dsj");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "wsj");
            this.comboBoxEdit14.DataBindings.Add("EditValue", rowData, "jhry");
            this.comboBoxEdit15.DataBindings.Add("EditValue", rowData, "czry");
            this.comboBoxEdit16.DataBindings.Add("EditValue", rowData, "yhqm");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "tdsj");
            this.dateEdit4.DataBindings.Add("EditValue", rowData, "sdsj");
            this.comboBoxEdit17.DataBindings.Add("EditValue", rowData, "tdxl");
            this.comboBoxEdit18.DataBindings.Add("EditValue", rowData, "czxm");
            this.comboBoxEdit19.DataBindings.Add("EditValue", rowData, "ddsb");
            this.comboBoxEdit20.DataBindings.Add("EditValue", rowData, "wxd");
            this.comboBoxEdit21.DataBindings.Add("EditValue", rowData, "cljg");
            this.comboBoxEdit22.DataBindings.Add("EditValue", rowData, "Remark");
        }
        #region IPopupFormEdit Members
        private PJ_22 rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_22;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_22>(value as PJ_22, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            //this.m_CityDic.Clear();
            //this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<PJ_22>(" WHERE Citylevel = '2'"));
          /*  IList<DicType> list = new List<DicType>();
            list.Add(new DicType("0", "机构"));
            list.Add(new DicType("1", "供电所"));
            list.Add(new DicType("2", "变电所"));
            this.SetComboBoxData(this.lookUpEdit1, "Value", "Key", "请选择", "种类", list);*/

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

        private void groupControlOrg_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmdlgzdhjtjlEdit_Load(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click_1(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}