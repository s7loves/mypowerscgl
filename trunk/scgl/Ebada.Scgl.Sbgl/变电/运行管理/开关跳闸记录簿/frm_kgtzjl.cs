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
    public partial class frm_kgtzjl : FormBase, IPopupFormEdit 
    {
        public frm_kgtzjl()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_kgtzjl rowData;
        public object RowData
        {
            get
            {
                return this.rowData;
            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as bdjl_kgtzjl;
                    Initlkue();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_kgtzjl>(value as bdjl_kgtzjl, rowData);
                }
            }
        }

        private void dataBind()
        {
            this.lkuekgmc.DataBindings.Add("EditValue", rowData, "kgmc");
            this.datetzrq.DataBindings.Add("EditValue", rowData, "tzrq");
            this.timetzsj.DataBindings.Add("EditValue", rowData, "tzsj");
            this.txtkgms.DataBindings.Add("EditValue", rowData, "kgms");
            this.spedlqtzcs.DataBindings.Add("EditValue", rowData, "dlqyxgztzcs");
            this.spesgtzcs.DataBindings.Add("EditValue", rowData, "sgtzcs");
            this.spesdfzcs.DataBindings.Add("EditValue", rowData, "sdfzcs");
            this.txtjlr.DataBindings.Add("EditValue", rowData, "jlr");
            this.memotzdz.DataBindings.Add("EditValue", rowData, "bhzhzzdqk");
        }

        private void Initlkue()
        {
            //13代表刀闸
            string sqlsbmc = "select distinct a2 from BD_SBTZ where OrgCode='" + rowData.OrgCode + "' and rtrim(ltrim(a2))!='' and sbtype='13'";
            IList<string> ls = Client.ClientHelper.PlatformSqlMap.GetList<string>("SelectOneStr", sqlsbmc);
            List<DicType> sbmcList = new List<DicType>();
            foreach (string mc in ls)
            {
                sbmcList.Add(new DicType(mc, mc));
            }
            SetComboBoxData(lkuekgmc, "Value", "Key", "请选择", "设备名称", sbmcList);

        }

        //SetComboBoxData(lkueStartGt, "Value", "Key", "请选择", "起始杆塔", gtDictypeList);
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

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lkuekgmc.EditValue == null)
            {
                MsgBox.ShowWarningMessageBox("请选择开关名称!");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}