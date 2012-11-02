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
namespace Ebada.Scgl.Lcgl
{
    public partial class frm25zbdymxEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_25zbdymx> m_CityDic = new SortableSearchableBindingList<PJ_25zbdymx>();

        public frm25zbdymxEdit()
        {
            InitializeComponent();
        }
        void dataBind() {



            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "Type");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "azrq");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "xh");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "dy");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "gl");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "ts");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "sccj");

            //
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
           // this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private PJ_25zbdymx rowData = null;

        public object RowData {
            get {
               // rowData.dy = Convert.ToInt32(comboBoxEdit4.EditValue);
                rowData.gl = Convert.ToDouble(comboBoxEdit5.EditValue);
                //rowData.ts = Convert.ToInt32(comboBoxEdit6.EditValue);
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_25zbdymx;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_25zbdymx>(value as PJ_25zbdymx, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {

            //ComboBoxHelper.FillCBoxByDyk("11配电变压器卡片", "一次电压", comboBoxEdit4.Properties);
           
           // comboBoxEdit4.Text = rowData.dy.ToString();
            comboBoxEdit7.Properties.Items.Clear();
            comboBoxEdit7.Properties.Items.Add("哈尔滨电机厂");
            comboBoxEdit7.Properties.Items.Add("贵阳电机厂");
            comboBoxEdit7.Properties.Items.Add("绥化电机厂");
            comboBoxEdit3.Properties.Items.Clear();
            comboBoxEdit3.Properties.Items.Add("T23");
            comboBoxEdit3.Properties.Items.Add("6135N");
            comboBoxEdit5.Properties.Items.Clear();
            comboBoxEdit5.Properties.Items.Add("22");
            comboBoxEdit5.Properties.Items.Add("40");
            comboBoxEdit5.Properties.Items.Add("88");
            //this.m_CityDic.Clear();
            //this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<PJ_25>(" WHERE Citylevel = '2'"));
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit1.SelectedText == "发电机")
            {
                comboBoxEdit3.Properties.Items.Clear();
                comboBoxEdit3.Properties.Items.Add("T23");
                comboBoxEdit3.Properties.Items.Add("6135N");
                comboBoxEdit5.Properties.Items.Clear();
                comboBoxEdit5.Properties.Items.Add("22");
                comboBoxEdit5.Properties.Items.Add("40");
                comboBoxEdit5.Properties.Items.Add("88");
            }
            else if (comboBoxEdit1.SelectedText == "原动机")
            {
                comboBoxEdit3.Properties.Items.Clear();
                comboBoxEdit3.Properties.Items.Add("4115-T1");
                comboBoxEdit3.Properties.Items.Add("GF");
                comboBoxEdit5.Properties.Items.Clear();
                comboBoxEdit5.Properties.Items.Add("50");
                comboBoxEdit5.Properties.Items.Add("75");
              
            }
        }

      
    }
}