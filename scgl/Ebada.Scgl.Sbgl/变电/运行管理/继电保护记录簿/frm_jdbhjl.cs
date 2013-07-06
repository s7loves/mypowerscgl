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
    public partial class frm_jdbhjl : FormBase, IPopupFormEdit
    {
        public frm_jdbhjl()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_jdbhjl rowData;
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
                    this.rowData = value as bdjl_jdbhjl;
                    Initlkue();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_jdbhjl>(value as bdjl_jdbhjl, rowData);
                }
            }
        }

        private void dataBind()
        {
            this.lkuesbmc.DataBindings.Add("EditValue", rowData, "sbmc");
            this.daterq.DataBindings.Add("EditValue", rowData, "rq");
            this.lkuejdfzr.DataBindings.Add("EditValue", rowData, "jdfzr");
            this.lkuezbrjsz.DataBindings.Add("EditValue", rowData, "zbrjsz");
            this.memotsnrjjl.DataBindings.Add("EditValue", rowData, "tsnrjjl");
        }

        private void Initlkue()
        {
            
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
            List<string> strlist=new List<string> ();
            //List<DicType> userTypeList = new List<DicType>();
            foreach (mUser user in userList)
            {
                //userTypeList.Add(new DicType(user.UserName, user.UserName));
                strlist.Add(user.UserName);
            }
            lkuejdfzr.Properties.Items.AddRange((ICollection)strlist);
            lkuezbrjsz.Properties.Items.AddRange((ICollection)strlist);


            //SetComboBoxData(this.lkuejdfzr, "Value", "Key", "请选择", "继电负责人", userTypeList);
            //SetComboBoxData(this.lkuezbrjsz, "Value", "Key", "请选择", "值班人及所长", userTypeList);
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

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (lkuesbmc.EditValue == null)
            {
                MsgBox.ShowWarningMessageBox("请选择设备名称!");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void simpleButton1_Click(object sender, System.EventArgs e)
        {
            SelectorHelper.SelectDyk("变电继电保护记录", "调试内容及结论", memotsnrjjl);
            if (!string.IsNullOrEmpty(memotsnrjjl.EditValue as string))
            {
                rowData.tsnrjjl = memotsnrjjl.EditValue as string;
            }

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void frm_jdbhjl_Load(object sender, System.EventArgs e)
        {

        }

        

    }
}