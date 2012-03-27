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
    public partial class frm18gysbpjmxEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_18gysbpjmx> m_CityDic = new SortableSearchableBindingList<PJ_18gysbpjmx>();

        public frm18gysbpjmxEdit() {
            InitializeComponent();
        }
        void dataBind() {

            PJ_18gysbpjmx temp = new PJ_18gysbpjmx();
         
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "rq");
            //this.dateEdit2.DataBindings.Add("EditValue", rowData, "CreateDate");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "xh");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "one");
            this.spinEdit3.DataBindings.Add("EditValue", rowData, "two");
            this.spinEdit4.DataBindings.Add("EditValue", rowData, "three");
            this.spinEdit5.DataBindings.Add("EditValue", rowData, "whl");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "sbdy");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "fzdw");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "qxlb");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "qxnr", false, DataSourceUpdateMode.OnPropertyChanged);
            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_18gysbpjmx rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_18gysbpjmx;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_18gysbpjmx>(value as PJ_18gysbpjmx, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            //this.m_CityDic.Clear();
            //this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<PJ_18gysbpjmx>(" WHERE Citylevel = '2'"));
          /*  IList<DicType> list = new List<DicType>();
            list.Add(new DicType("0", "机构"));
            list.Add(new DicType("1", "供电所"));
            list.Add(new DicType("2", "变电所"));
            this.SetComboBoxData(this.lookUpEdit1, "Value", "Key", "请选择", "种类", list);*/

            //if (null != cityCode && cityCode.Trim().Length > 0)
            //    this.cltCity.Properties.KeyValue = cityCode;
            //ComboBoxHelper.FillCBoxByDyk("18高压配电设备评级表", "设备单元名称", comboBoxEdit1);
            ComboBoxHelper.FillCBoxByDyk("06设备巡视及缺陷消除记录", "缺陷类别", comboBoxEdit4.Properties);
            
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("18高压配电设备评级表", "缺陷内容", memoEdit1);

        }
    }
}