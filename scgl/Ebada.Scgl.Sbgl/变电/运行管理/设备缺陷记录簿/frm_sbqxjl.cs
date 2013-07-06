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
    public partial class frm_sbqxjl : FormBase, IPopupFormEdit 
    {
        public frm_sbqxjl()
        {
            InitializeComponent();
        }


        #region IPopupFormEdit 成员
        private bdjl_sbqxjl rowData;
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
                    this.rowData = value as bdjl_sbqxjl;
                    Initlkue();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_sbqxjl>(value as bdjl_sbqxjl, rowData);
                }
            }
        }

        private void Initlkue()
        {
            string sqlsbmc ="select distinct a2 from BD_SBTZ where OrgCode='" + rowData.OrgCode + "' and rtrim(ltrim(a2))!=''";
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
            SetComboBoxData(this.lkuefxr, "Value", "Key", "请选择", "发现人", userTypeList);
            SetComboBoxData(this.lkuexcr, "Value", "Key", "请选择", "消除人", userTypeList);
            SetComboBoxData(this.lkueysr, "Value", "Key", "请选择", "验收人", userTypeList);
        }

        private void dataBind()
        {
            this.lkuesbmc.DataBindings.Add("EditValue", rowData, "sbmc");
            this.txtqxbh.DataBindings.Add("EditValue", rowData, "qxbh");
            this.datefxrq.DataBindings.Add("EditValue", rowData, "fxrq");
            this.lkuefxr.DataBindings.Add("EditValue", rowData, "fxr");
            this.lkueqxlb.DataBindings.Add("EditValue", rowData, "qxlb");
            this.meoqxnr.DataBindings.Add("EditValue", rowData, "qxnr");
            this.datexcrq.DataBindings.Add("EditValue", rowData, "c1");
            this.lkuexcr.DataBindings.Add("EditValue", rowData, "c2");
            this.lkueysr.DataBindings.Add("EditValue", rowData, "c3");
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.lkuesbmc.EditValue == null)
            {
                MsgBox.ShowWarningMessageBox("请选择设备名称!");
                return;
            }
            //if (this.datexcrq.EditValue != null)
            //    rowData.c1 = Convert.ToDateTime(datexcrq.EditValue).ToShortDateString();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
          
            this.DialogResult = DialogResult.Cancel;
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

        private void frm_sbqxjl_Load(object sender, EventArgs e)
        {
            List<DicType> qxlbList = new List<DicType>();
            qxlbList.Add(new DicType("一般", "一般"));
            qxlbList.Add(new DicType("重大", "重大"));
            SetComboBoxData(lkueqxlb, "Value", "Key", "请选择", "缺陷类别", qxlbList);
            ComboBoxHelper.FillCBoxByDyk("变电设备缺陷记录", "缺陷编号", txtqxbh);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("变电设备缺陷记录", "缺陷内容", meoqxnr);
            if (!string.IsNullOrEmpty(meoqxnr.EditValue as string))
                rowData.qxnr = meoqxnr.EditValue as string;

        }
    }
}