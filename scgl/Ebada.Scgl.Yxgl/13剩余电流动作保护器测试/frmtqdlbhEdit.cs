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
    public partial class frmtqdlbhEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_tqdlbh> m_CityDic = new SortableSearchableBindingList<PS_tqdlbh>();

        public frmtqdlbhEdit() {
            InitializeComponent();
        }
        void dataBind() {



            this.textEdit1.DataBindings.Add("EditValue", rowData, "sbCode");
            this.textEdit2.DataBindings.Add("EditValue", rowData, "Number");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "MadeDate");
            this.dateEdit4.DataBindings.Add("EditValue", rowData, "InDate");
            this.dateEdit5.DataBindings.Add("EditValue", rowData, "InstallDate");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "State");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "sbModle");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "glr");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "dzdl");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "tqName");
            this.comboBoxEdit11.DataBindings.Add("EditValue", rowData, "InstallAdress");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "dzsj");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "sbName");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "Factory");

        }
        #region IPopupFormEdit Members
        private PS_tqdlbh rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PS_tqdlbh;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PS_tqdlbh>(value as PS_tqdlbh, rowData);
                }
                if(rowData.sbCode==""){
                    rowData.InstallDate = DateTime.Now;
                    rowData.InDate = DateTime.Now;
                    rowData.MadeDate = DateTime.Now;
                }
            }
        }

        #endregion

        private void InitComboBoxData() {

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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit5.Text == "")
            {
                MsgBox.ShowTipMessageBox("台区名称不能为空。");
                comboBoxEdit5.Focus();
                return;
            }
            if (textEdit1.Text == "")
            {
                MsgBox.ShowTipMessageBox("设备编号不能为空。");
                textEdit1.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}