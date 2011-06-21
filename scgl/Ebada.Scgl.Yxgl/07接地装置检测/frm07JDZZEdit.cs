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
    public partial class frm07JDZZEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_07jdzz> m_CityDic = new SortableSearchableBindingList<PJ_07jdzz>();

        public frm07JDZZEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "LineName");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "gth");
            this.comboBoxEdit3.DataBindings.Add("EditValue", rowData, "gzwz");
            this.comboBoxEdit4.DataBindings.Add("EditValue", rowData, "sbmc");
            this.comboBoxEdit5.DataBindings.Add("EditValue", rowData, "xhgg");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "jddz");
            this.comboBoxEdit7.DataBindings.Add("EditValue", rowData, "tz");
            this.comboBoxEdit8.DataBindings.Add("EditValue", rowData, "trdzr");

        }
        #region IPopupFormEdit Members
        private PJ_07jdzz rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_07jdzz;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_07jdzz>(value as PJ_07jdzz, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {

            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "设备名称", comboBoxEdit4);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "变压器型号", comboBoxEdit5);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "变压器规格", comboBoxEdit9);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "接地电阻", comboBoxEdit6);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "土质", comboBoxEdit7);
            ComboBoxHelper.FillCBoxByDyk("07接地装置检测记录", "土壤电阻率", comboBoxEdit8);
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

        private void frm07JDZZEdit_Load(object sender, EventArgs e)
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
    }
}