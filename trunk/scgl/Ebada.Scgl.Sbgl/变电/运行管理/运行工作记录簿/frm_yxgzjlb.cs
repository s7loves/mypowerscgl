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
    public partial class frm_yxgzjlb : FormBase, IPopupFormEdit
    {
        public frm_yxgzjlb()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_yxgzjlb rowData;
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
                    this.rowData = value as bdjl_yxgzjlb;
                    Initlkue();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_yxgzjlb>(value as bdjl_yxgzjlb, rowData);
                }
            }
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
            SetComboBoxData(lkuejbfzr, "Value", "Key", "请选择", "接班负责人", userTypeList);
            SetComboBoxData(lkuejbry, "Value", "Key", "请选择", "接班人员", userTypeList);
            SetComboBoxData(lkuejbfzry, "Value", "Key", "请选择", "交班负责人", userTypeList);
            SetComboBoxData(lkuejbryy, "Value", "Key", "请选择", "交班人员", userTypeList);

            List<DicType> dicTypetqList = new List<DicType>();
            dicTypetqList.Add(new DicType("晴", "晴"));
            dicTypetqList.Add(new DicType("多云", "多云"));
            dicTypetqList.Add(new DicType("阴", "阴"));
            dicTypetqList.Add(new DicType("阵雨", "阵雨"));
            dicTypetqList.Add(new DicType("小雨", "小雨"));
            dicTypetqList.Add(new DicType("中雨", "中雨"));
            dicTypetqList.Add(new DicType("大雨", "大雨"));
            dicTypetqList.Add(new DicType("暴雨", "暴雨"));
            dicTypetqList.Add(new DicType("阵雪", "阵雪"));
            dicTypetqList.Add(new DicType("小雪", "小雪"));
            dicTypetqList.Add(new DicType("中雪", "中雪"));
            dicTypetqList.Add(new DicType("大雪", "大雪"));
            dicTypetqList.Add(new DicType("暴雪", "暴雪"));
            dicTypetqList.Add(new DicType("雨夹雪", "雨夹雪"));
            SetComboBoxData(this.lkuetq, "Value", "Key", "请选择", "天气", dicTypetqList);
        }

        private void dataBind()
        {
            this.daterq.DataBindings.Add("EditValue", rowData, "rq");
            this.lkuetq.DataBindings.Add("EditValue", rowData, "tq");
            this.lkuejbfzr.DataBindings.Add("EditValue", rowData, "jbfzr");
            this.lkuejbry.DataBindings.Add("EditValue", rowData, "jbry");
            this.lkuejbfzry.DataBindings.Add("EditValue", rowData, "jbfzry");
            this.lkuejbryy.DataBindings.Add("EditValue", rowData, "jbryy");

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



        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}