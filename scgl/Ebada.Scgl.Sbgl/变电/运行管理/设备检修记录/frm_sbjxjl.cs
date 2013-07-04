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
    public partial class frm_sbjxjl : FormBase, IPopupFormEdit 
    {
        public frm_sbjxjl()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_sbjxjl rowData;
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
                    this.rowData = value as bdjl_sbjxjl;
                    Initlkue();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_sbjxjl>(value as bdjl_sbjxjl, rowData);
                }
            }
        }

       

        private void dataBind()
        {
            this.datejxrq.DataBindings.Add("EditValue", rowData, "jxrq");
            this.lkuesbmc.DataBindings.Add("EditValue", rowData, "sbmc");
            this.txtjxxz.DataBindings.Add("EditValue", rowData, "jxxz");
            this.lkuejxfzr.DataBindings.Add("EditValue", rowData, "jxfzr");
            this.lkueysr.DataBindings.Add("EditValue", rowData, "ysr");
            this.txtjxxm.DataBindings.Add("EditValue", rowData, "jxxm");
            this.txtysyj.DataBindings.Add("EditValue", rowData, "ysyj");
        }

        private void Initlkue()
        {

            ComboBoxHelper.FillCBoxByDyk("变电设备检修记录", "检修性质", txtjxxz);
            ComboBoxHelper.FillCBoxByDyk("变电设备检修记录", "检修项目", txtjxxm);
            ComboBoxHelper.FillCBoxByDyk("变电设备检修记录", "验收意见", txtysyj);

            string sqlsbmc = "select distinct a2 from BD_SBTZ where OrgCode='" + rowData.OrgCode + "' and rtrim(ltrim(a2))!=''";
            IList<string> ls = Client.ClientHelper.PlatformSqlMap.GetList<string>("SelectOneStr", sqlsbmc);
            List<DicType> sbmcList = new List<DicType>();
            foreach (string mc in ls)
            {
                sbmcList.Add(new DicType(mc, mc));
            }
            SetComboBoxData(lkuesbmc, "Value", "Key", "请选择", "设备名称", sbmcList);

            IList<mUser> userList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<mUser>("where OrgCode='" + rowData.OrgCode + "'");
            if (userList == null)
                return;
            List<DicType> userTypeList = new List<DicType>();
            foreach (mUser user in userList)
            {
                userTypeList.Add(new DicType(user.UserName, user.UserName));
            }
            SetComboBoxData(this.lkuejxfzr, "Value", "Key", "请选择", "检修负责人", userTypeList);
            SetComboBoxData(this.lkueysr, "Value", "Key", "请选择", "验收人", userTypeList);
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lkuesbmc.EditValue == null)
            {
                MsgBox.ShowWarningMessageBox("请选择设备名称!");
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