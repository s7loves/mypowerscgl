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
    public partial class frm_sgyxjlb : FormBase, IPopupFormEdit
    {
        public frm_sgyxjlb()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_sgyxjlb rowData;
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
                    this.rowData = value as bdjl_sgyxjlb;
                    Initlkue();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_sgyxjlb>(value as bdjl_sgyxjlb, rowData);
                }
            }
        }

        private void dataBind()
        {
            this.daterq.DataBindings.Add("EditValue", rowData, "c1");
            this.lkuetq.DataBindings.Add("EditValue", rowData, "tq");
            this.cmbxcjry.DataBindings.Add("EditValue", rowData, "cjry");
            this.txtdsyxfs.DataBindings.Add("EditValue", rowData, "dsyxfs");
            this.txtyxtm.DataBindings.Add("EditValue", rowData, "yxtm");
            this.memosgxx.DataBindings.Add("EditValue", rowData, "sgxx");
            this.memoclbz.DataBindings.Add("EditValue", rowData, "clbz");
            this.txtshyj.DataBindings.Add("EditValue", rowData, "shyj");

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
            this.cmbxcjry.Properties.DataSource = userTypeList;
            this.cmbxcjry.Properties.DisplayMember = "Value";
            this.cmbxcjry.Properties.ValueMember = "Key";

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
            ComboBoxHelper.FillCBoxByDyk("变电事故预想记录", "当时运行方式", txtdsyxfs);
            ComboBoxHelper.FillCBoxByDyk("变电事故预想记录", "预想题目", txtyxtm);
            ComboBoxHelper.FillCBoxByDyk("变电事故预想记录", "审核意见", txtshyj);

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
            SelectorHelper.SelectDyk("变电事故预想记录", "事故现象", memosgxx);
            if (!string.IsNullOrEmpty(memosgxx.EditValue as string))
            {
                rowData.sgxx = memosgxx.EditValue as string;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("变电事故预想记录", "处理步骤", memoclbz);
            if (!string.IsNullOrEmpty(memoclbz.EditValue as string))
            {
                rowData.clbz = memoclbz.EditValue as string;
            }

        }
    }
}