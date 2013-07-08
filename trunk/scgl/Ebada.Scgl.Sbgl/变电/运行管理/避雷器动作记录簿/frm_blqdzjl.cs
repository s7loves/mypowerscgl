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
    public partial class frm_blqdzjl : FormBase, IPopupFormEdit
    {
        public frm_blqdzjl()
        {
            InitializeComponent();
        }


        #region IPopupFormEdit 成员
        private bdjl_blqdzjlcs rowData;
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
                    this.rowData = value as bdjl_blqdzjlcs;
                    Initlkue();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_blqdzjlcs>(value as bdjl_blqdzjlcs, rowData);
                }
            }
        }

        private void dataBind()
        {
            this.lkueblqmc.DataBindings.Add("EditValue", rowData, "blqmc");
            this.datedzrq.DataBindings.Add("EditValue", rowData, "dzrq");
            this.datedzsj.DataBindings.Add("EditValue", rowData, "dzsj");
            this.txtajsq.DataBindings.Add("EditValue", rowData, "Axjsqzss");
            this.txtbjsq.DataBindings.Add("EditValue", rowData, "Bxjsqzss");
            this.txtcjsq.DataBindings.Add("EditValue", rowData, "Cxjsqzss");
            this.lkuejlr.DataBindings.Add("EditValue", rowData, "jlr");
            this.memodzyy.DataBindings.Add("EditValue", rowData, "dzyy");
            this.speAdzcs.DataBindings.Add("EditValue", rowData, "c1");
            this.spebdzcs.DataBindings.Add("EditValue", rowData, "c2");
            this.specdzcs.DataBindings.Add("EditValue", rowData, "c3");
        }

        private void Initlkue()
        {
            //10代表避雷器
            string sqlsbmc = "select distinct a2 from BD_SBTZ where OrgCode='" + rowData.OrgCode + "' and rtrim(ltrim(a2))!='' and sbtype='16'";
            IList<string> ls = Client.ClientHelper.PlatformSqlMap.GetList<string>("SelectOneStr", sqlsbmc);
            List<DicType> sbmcList = new List<DicType>();
            foreach (string mc in ls)
            {
                sbmcList.Add(new DicType(mc, mc));
            }
            SetComboBoxData(lkueblqmc, "Value", "Key", "请选择", "避雷器名称", sbmcList);
            IList<mUser> userList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<mUser>("where OrgCode='" + rowData.OrgCode + "'");
            if (userList == null)
                return;
            List<DicType> userTypeList = new List<DicType>();
            foreach (mUser user in userList)
            {
                userTypeList.Add(new DicType(user.UserName, user.UserName));
            }
            SetComboBoxData(lkuejlr, "Value", "Key", "请选择", "记录人", userTypeList);
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
            if (lkueblqmc.EditValue == null)
            {
                MsgBox.ShowWarningMessageBox("请选择避雷器名称!");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("变电避雷器动作记录", "动作原因", memodzyy);
            if (!string.IsNullOrEmpty(memodzyy.EditValue as string))
                rowData.dzyy = memodzyy.EditValue as string;
        }
    }
}