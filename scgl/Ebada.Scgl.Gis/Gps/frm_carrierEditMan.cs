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
namespace Ebada.Scgl.Gis.Gps
{
    public partial class frm_carrierEditMan : FormBase, IPopupFormEdit {

        public frm_carrierEditMan()
        {
            InitializeComponent();
            
        }
        void dataBind() {

            
            this.txtplate.DataBindings.Add("EditValue", rowData, "plate");
            this.txtphone.DataBindings.Add("EditValue", rowData, "phone");
        }
        #region IPopupFormEdit Members
        private gps_carrier rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as gps_carrier;
                    this.InitComboBoxData();
                    if (MainHelper.User != null)
                        rowData.last_modify = MainHelper.User.UserName;
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<gps_carrier>(value as gps_carrier, rowData);
                    InitComboBoxData();
                }
               
            }
        }

        #endregion

        private void InitComboBoxData() {
           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (IsTelephone(txtphone.EditValue.ToString()) || IsHandset(txtphone.EditValue.ToString())||string.IsNullOrEmpty(txtphone.EditValue.ToString()))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MsgBox.ShowWarningMessageBox("请填写正确的联系方式");
                return;
            }
        }

        public bool IsTelephone(string str_telephone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$");
        }

        public bool IsHandset(string str_handset)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^[1]+[3,5]+\d{9}");
        }

        private void dateyear_EditValueChanged(object sender, EventArgs e)
        {
        }



    }
}