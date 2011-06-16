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
    public partial class frmtqbyqEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_tqbyq> m_CityDic = new SortableSearchableBindingList<PS_tqbyq>();

        public frmtqbyqEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "byqCode");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "byqName");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "byqModle");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "omniseal");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "byqOwner");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "byqVol");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "byqPhase");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "byqCapcity");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "byqLineGroup");
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "byqFactory");
            this.comboBoxEdit11.DataBindings.Add("EditValue", rowData, "byqNumber");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "byqMadeDate");
            this.comboBoxEdit12.DataBindings.Add("EditValue", rowData, "byqCycle");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "byqVolOne");
            this.spinEdit3.DataBindings.Add("EditValue", rowData, "byqVolTwo");
            this.spinEdit4.DataBindings.Add("EditValue", rowData, "byqCurrentOne");
            this.spinEdit5.DataBindings.Add("EditValue", rowData, "byqCurrentTwo");
            this.dateEdit4.DataBindings.Add("EditValue", rowData, "byqInstallDate");
            this.comboBoxEdit13.DataBindings.Add("EditValue", rowData, "byqInstallAdress");
            //this.comboBoxEdit14.DataBindings.Add("EditValue", rowData, "byqState");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "InDate");
            
            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PS_tqbyq rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PS_tqbyq;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PS_tqbyq>(value as PS_tqbyq, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            //this.m_CityDic.Clear();
            //this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<PS_tqbyq>(" WHERE Citylevel = '2'"));
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

        private void labelControl13_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit16_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}