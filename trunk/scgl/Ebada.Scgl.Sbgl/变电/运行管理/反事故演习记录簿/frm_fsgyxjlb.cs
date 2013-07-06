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
    public partial class frm_fsgyxjlb : FormBase, IPopupFormEdit
    {
        public frm_fsgyxjlb()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_fsgyxjlb rowData;
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
                    this.rowData = value as bdjl_fsgyxjlb;
                    Initlkue();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_fsgyxjlb>(value as bdjl_fsgyxjlb, rowData);
                }
            }
        }

        private void dataBind()
        {
            this.dateyxrq.DataBindings.Add("EditValue", rowData, "c1");
            this.txtyxdd.DataBindings.Add("EditValue", rowData, "yxdd");
            this.txtyxtm.DataBindings.Add("EditValue", rowData, "yxtm");
            this.timeyxkssj.DataBindings.Add("EditValue", rowData, "yxkssj");
            this.timeyxjssj.DataBindings.Add("EditValue", rowData, "yxjssj");
            this.cmbxcjry.DataBindings.Add("EditValue", rowData, "cjry");
            this.memocljg.DataBindings.Add("EditValue", rowData, "cljg");
            this.memowtjcs.DataBindings.Add("EditValue", rowData, "wtjcs");
            this.memojljpj.DataBindings.Add("EditValue", rowData, "jljpj");
        }

        private void Initlkue()
        {
            IList<mUser> userList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<mUser>("where OrgCode='" + rowData.OrgCode + "'");
            if (userList == null)
                return;
            List<DicType> userTypeList = new List<DicType>();
            foreach (mUser user in userList)
            {
                userTypeList.Add(new DicType(user.UserName, user.UserName));
            }
            cmbxcjry.Properties.DataSource = userTypeList;
            cmbxcjry.Properties.DisplayMember = "Value";
            cmbxcjry.Properties.ValueMember = "Key";

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
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
          PJ_dyk pjdyk=  SelectorHelper.SelectDyk("变电反事故演习记录", "反事故信息", memocljg, memowtjcs, memojljpj);
          if (pjdyk != null)
          {
              memocljg.EditValue = pjdyk.nr;
              memowtjcs.EditValue = pjdyk.nr2;
              memojljpj.EditValue = pjdyk.nr3;
              rowData.cljg = pjdyk.nr;
              rowData.wtjcs = pjdyk.nr2;
              rowData.jljpj = pjdyk.nr3;
          }
        }
    }
}