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
    public partial class frmkgEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_kg> m_CityDic = new SortableSearchableBindingList<PS_kg>();

        public frmkgEdit() {
            InitializeComponent();
        }
        void dataBind() {
            this.comboBoxEdit13.DataBindings.Add("EditValue", rowData, "kgCode");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "kgMadeDate");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "kgInstallDate");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "InDate");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "kgName");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "kgModle");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "kgVol");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "kgPhase");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "kgFactory");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "kgCloseVol");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "kgOpenEle");
            this.comboBoxEdit9.DataBindings.Add("EditValue", rowData, "kgLineGroup");
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "kgNumber");
            this.comboBoxEdit11.DataBindings.Add("EditValue", rowData, "kgInstallAdress");
            this.comboBoxEdit12.DataBindings.Add("EditValue", rowData, "kgState");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "kgCapcity");


        }
        #region IPopupFormEdit Members
        private PS_kg rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PS_kg;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PS_kg>(value as PS_kg, rowData);
                }
                if(rowData.kgCode==""){
                    rowData.InDate = DateTime.Now;
                    rowData.kgInstallDate = DateTime.Now;
                    rowData.kgMadeDate = DateTime.Now;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit13.Text == "")
            {
                MsgBox.ShowTipMessageBox("开关编号不能为空。");
                comboBoxEdit13.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}