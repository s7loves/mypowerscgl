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
    public partial class frm_deviceEdit : FormBase, IPopupFormEdit {

        private string ztType = string.Empty;
        public frm_deviceEdit()
        {
            InitializeComponent();
            
        }
        void dataBind() {

            this.txtdevice_serial.DataBindings.Add("EditValue", rowData, "device_serial");
            this.cmbdevice_type.DataBindings.Add("EditValue", rowData, "device_type");
            this.cmbdevice_model.DataBindings.Add("EditValue", rowData, "device_model");
            this.datedevice_expire.DataBindings.Add("EditValue", rowData, "device_expire");
            this.memodevice_desc.DataBindings.Add("EditValue", rowData, "device_desc");
            this.cmbdevice_state.DataBindings.Add("EditValue", rowData, "device_state");
            this.datedevice_made_date.DataBindings.Add("EditValue", rowData, "device_made_date");
            this.txtsoftware_version.DataBindings.Add("EditValue", rowData, "software_version");
            this.txtsystem_version.DataBindings.Add("EditValue", rowData, "system_version");
            this.txtdevice_owner.DataBindings.Add("EditValue", rowData, "device_owner");
            this.txtphone_number.DataBindings.Add("EditValue", rowData, "phone_number");
            this.txtsim_id.DataBindings.Add("EditValue", rowData, "sim_id");
            this.btncarrier_id.DataBindings.Add("EditValue", rowData, "c1");
            
        }
        #region IPopupFormEdit Members
        private gps_device rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as gps_device;
                    
                    if (MainHelper.User != null)
                        rowData.last_modify = MainHelper.User.UserName;
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<gps_device>(value as gps_device, rowData);
                    
                }
               
            }
        }

        #endregion

        private void InitComboBoxData() {
           
            ComboBoxHelper.FillCBoxByDyk("监控设备", "设备类型", cmbdevice_type);
            ComboBoxHelper.FillCBoxByDyk("监控设备", "设备型号", cmbdevice_model);
            List<DicType> dicList = new List<DicType>();
            dicList.Add(new DicType("0", "未注册"));
            dicList.Add(new DicType("1", "已注册"));
            SetComboBoxData(this.cmbdevice_state, "Value", "Key", "请选择", "设备状态", dicList);

            List<DicType> dicztList = new List<DicType>();
            dicztList.Add(new DicType("车辆", "车辆"));
            dicztList.Add(new DicType("人员", "人员"));
            SetComboBoxData(this.lkuezttype, "Value", "Key", "请选择", "载体类型", dicztList);
        }




        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post)
        {
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
         

        public bool IsTelephone(string str_telephone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$");
        }

        

        public bool IsHandset(string str_handset)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^[1]+[3,5]+\d{9}");
        }

        private void btncarrier_id_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (string.IsNullOrEmpty(ztType))
            {
                MsgBox.ShowWarningMessageBox("请选择载体类型!");
                return;
            }
            
            frm_carrierselect frm = new frm_carrierselect();
            frm.ZtType = ztType;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.btncarrier_id.EditValue = frm.Plate;
                rowData.c1 = frm.Plate;
                if (string.IsNullOrEmpty(rowData.c1))
                {
                    rowData.carrier_id = string.Empty;
                }
                else
                {
                    rowData.carrier_id = frm.CarrierID;
                }
                
            }
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rowData.c1))
            {
                rowData.carrier_id = string.Empty;
            }
            rowData.c2 = lkuezttype.EditValue.ToString();
            if (IsTelephone(txtphone_number.EditValue.ToString()) || IsHandset(txtphone_number.EditValue.ToString())||string.IsNullOrEmpty(txtphone_number.EditValue.ToString()))
            {
                
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MsgBox.ShowWarningMessageBox("请填写正确的联系方式!");
                return;
            }
        }

        private void frm_deviceEdit_Load(object sender, EventArgs e)
        {
            InitComboBoxData();
        }

        private void lkuezttype_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lkuezttype.EditValue as string))
            {
                ztType = string.Empty;
            }
            ztType = lkuezttype.EditValue.ToString();
        }

        

       



    }
}