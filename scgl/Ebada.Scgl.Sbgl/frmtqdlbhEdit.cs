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
    public partial class frmtqdlbhEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_tqdlbh> m_CityDic = new SortableSearchableBindingList<PS_tqdlbh>();

        public frmtqdlbhEdit()
        {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "sbCode");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "sbModle");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "sbName");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "tqName");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "InstallAdress");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "Factory");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "Number");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "MadeDate");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "dzdl");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "dzsj");
            this.comboBoxEdit10.DataBindings.Add("EditValue", rowData, "glr");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "InstallDate");
            this.comboBoxEdit12.DataBindings.Add("EditValue", rowData, "State");
            this.dateEdit4.DataBindings.Add("EditValue", rowData, "InDate");
           

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
                    rowData.MadeDate = DateTime.Now;
                    rowData.InDate = DateTime.Now;
                    rowData.dzsj = DateTime.Now.ToString("yyyy-MM-dd");
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
            if (comboBoxEdit1.Text == "")
            {
                MsgBox.ShowTipMessageBox("设备编号不能为空。");
                comboBoxEdit1.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
      
     
    }
}