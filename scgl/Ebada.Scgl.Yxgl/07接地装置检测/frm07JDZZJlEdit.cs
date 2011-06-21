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
namespace Ebada.Scgl.Yxgl
{
    public partial class frm07JDZZJlEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_07jdzzjl> m_CityDic = new SortableSearchableBindingList<PJ_07jdzzjl>();

        public frm07JDZZJlEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.dateEdit1.DataBindings.Add("EditValue", rowData, "clrq");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "tq");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "scz");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "hsz");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "jcqk");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "jr");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "jcr");

        }
        #region IPopupFormEdit Members
        private PJ_07jdzzjl rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_07jdzzjl;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_07jdzzjl>(value as PJ_07jdzzjl, rowData);
                }
                if (rowData.jr == "")
                {
                    rowData.clrq = DateTime.Now;
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "天气", comboBoxEdit1);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "检查情况", comboBoxEdit4);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "结论", comboBoxEdit6);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        /// <param name="nullTest"></param>
        /// <param name="cnStr"></param>
        /// <param name="post"></param>
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<DicType> post) {
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

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControlOrg_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm07JDZZJlEdit_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click_1(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (comboBoxEdit6.Text == "")
            {
                MsgBox.ShowTipMessageBox("结论不能为空。");
                comboBoxEdit6.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}