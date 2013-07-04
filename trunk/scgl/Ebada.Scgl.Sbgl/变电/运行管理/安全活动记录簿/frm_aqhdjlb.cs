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
    public partial class frm_aqhdjlb : FormBase, IPopupFormEdit 
    {
        IList<mUser> userList;
        List<DicType> userTypeList;
        public frm_aqhdjlb()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_aqhdjlb rowData;
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
                    this.rowData = value as bdjl_aqhdjlb;
                    Initlkue();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_aqhdjlb>(value as bdjl_aqhdjlb, rowData);
                }
            }
        }

        private void Initlkue()
        {
            userList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<mUser>("where OrgCode='" + rowData.OrgCode + "'");
            if (userList == null)
                return;
            userTypeList = new List<DicType>();
            foreach (mUser user in userList)
            {
                userTypeList.Add(new DicType(user.UserName, user.UserName));
            }
            SetComboBoxData(lkuezcr, "Value", "Key", "请选择", "主持人", userTypeList);

            combxCxry.Properties.DataSource = GetList(rowData.qxry);
            combxCxry.Properties.DisplayMember = "Value";
            combxCxry.Properties.ValueMember = "Key";

            combxqxry.Properties.DataSource = GetList(rowData.cxry);
            combxqxry.Properties.DisplayMember = "Value";
            combxqxry.Properties.ValueMember = "Key";
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

        private void dataBind()
        {
            
            this.lkuezcr.DataBindings.Add("EditValue", rowData, "zcr");
            this.datehdkssj.DataBindings.Add("EditValue", rowData, "hdkssj");
            this.datehdjssj.DataBindings.Add("EditValue", rowData, "hdjssj");
            this.combxCxry.DataBindings.Add("EditValue", rowData, "cxry");
            this.combxqxry.DataBindings.Add("EditValue", rowData, "qxry");
            this.memohdnr.DataBindings.Add("EditValue", rowData, "hdnr");
            this.memohdxj.DataBindings.Add("EditValue", rowData, "hdxj");
            this.memoldjcpy.DataBindings.Add("EditValue", rowData, "ldjcpy");
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void lkuezcr_EditValueChanged(object sender, EventArgs e)
        {
            if (lkuezcr.EditValue == null)
                return;
            string zcr = lkuezcr.EditValue.ToString().Trim();
            string sp = "";
            if (combxCxry.EditValue != null && combxCxry.EditValue.ToString().Trim() != "")
            {
                sp = zcr + "," + combxCxry.EditValue.ToString();
            }
            else
            {
                sp = zcr;
            }
            
            combxqxry.Properties.DataSource = GetList(sp);
            combxqxry.Properties.ValueMember = "Key";
            combxqxry.Properties.DisplayMember = "Value";
            string qxr = "";
            foreach (string str in rowData.qxry.Split(','))
            {
                if (str.Trim() != zcr.Trim())
                {
                    qxr += str + ",";
                }
            }
            if (qxr.Length > 1)
            {
                qxr = qxr.Substring(0, qxr.Length - 1);
                rowData.qxry = qxr;
                combxqxry.EditValue = qxr;
                combxqxry.Text = qxr;
                combxqxry.RefreshEditValue();
            }
            
            
        }

        private void combxCxry_EditValueChanged(object sender, EventArgs e)
        {
            if (combxCxry.EditValue == null)
                return;
            combxqxry.Properties.DataSource = GetList(this.combxCxry.EditValue.ToString());
            combxqxry.Properties.ValueMember = "Key";
            combxqxry.Properties.DisplayMember = "Value";
            

        }
        private List<DicType> GetList(string eidtValue)
        {
            string[] arr = eidtValue.Split(',');
            List<DicType> tempList = new List<DicType>();
            List<DicType> tempqxList = new List<DicType>();
            foreach (DicType dic in userTypeList)
            {
                tempqxList.Add(dic);
            }
            foreach (DicType dic in tempqxList)
            {
                foreach (string str in arr)
                {
                    if (dic.Value == str.Trim())
                    {
                        if (!tempList.Contains(dic))
                        {
                            tempList.Add(dic);
                        }
                    }
                }
            }
            foreach (DicType dic in tempList)
            {
                tempqxList.Remove(dic);
            }
            return tempqxList;
        }

        private void combxqxry_EditValueChanged(object sender, EventArgs e)
        {
            if (this.combxqxry.EditValue == null)
                return;
            this.combxCxry.Properties.DataSource = GetList(combxqxry.EditValue.ToString());
            combxCxry.Properties.ValueMember = "Key";
            combxCxry.Properties.DisplayMember = "Value";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("变电安全活动记录", "安全活动", memohdnr, memohdxj, memoldjcpy);
        }
    }
}