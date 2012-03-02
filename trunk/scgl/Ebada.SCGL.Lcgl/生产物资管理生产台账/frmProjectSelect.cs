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
    public partial class frmProjectSelect : FormBase, IPopupFormEdit {


        public frmProjectSelect()
        {
            InitializeComponent();
        }
        private string strSQL = "";
        public string StrSQL
        {
            get { return strSQL; }
            set { strSQL = value; }
        }
        private string strproject = "";//工程
        public string strProject
        {
            get { return strproject; }
            set { strproject = value; }
        }
        private string strfenproject = "";//分工程
        public string strFenproject
        {
            get { return strfenproject; }
            set { strfenproject = value; }
        }
        private string strtype = "";//现在条件
        public string strType
        {
            get { return strtype; }
            set { strtype = value; }
        }
        void dataBind() {


            //this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "LineName");
            //this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "Remark");

            IList wflist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr", StrSQL);

            this.comboBoxEdit1.Properties.Items.Clear();
            this.comboBoxEdit1.Properties.Items.Add("全部");
            this.comboBoxEdit2.Properties.Items.Clear();
            this.comboBoxEdit2.Properties.Items.Add("全部"); 
            foreach (string  str in wflist)
            {
                this.comboBoxEdit1.Properties.Items.Add(str);  
            
            }
            if (wflist.Count > 0) this.comboBoxEdit1.SelectedIndex = 0;

            this.comboBoxEdit2.SelectedIndex = 0;
        }
        #region IPopupFormEdit Members
        private PJ_17 rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_17;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_17>(value as PJ_17, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            //this.m_CityDic.Clear();
            //this.m_CityDic.Add(ClientHelper.PlatformSqlMap.GetList<PJ_17>(" WHERE Citylevel = '2'"));
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
            dataBind();
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            strproject = this.comboBoxEdit1.EditValue.ToString();
            strfenproject = this.comboBoxEdit2.EditValue.ToString();
            this.DialogResult = DialogResult.OK;  
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxEdit2.Properties.Items.Clear();
            this.comboBoxEdit2.Properties.Items.Add("全部");
            if (comboBoxEdit1.EditValue.ToString() == "全部")
            {
                this.comboBoxEdit2.SelectedIndex = 0;
                return;
            }
            IList wflist = ClientHelper.PlatformSqlMap.GetList("SelectOneStr",
              "select distinct ssxm  from PJ_clcrkd where ssgc='" + comboBoxEdit1.EditValue.ToString() + "' and ssxm!='' " + strType);


            this.comboBoxEdit2.Properties.Items.AddRange(wflist);
            if (wflist.Count > 0) this.comboBoxEdit2.SelectedIndex = 0;
        }
    }
}