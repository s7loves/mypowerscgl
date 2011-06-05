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
    public partial class frmaqhdEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_02aqhd> m_CityDic = new SortableSearchableBindingList<PJ_02aqhd>();

        public frmaqhdEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "zcr");
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "kssj");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "jssj");
            this.comboBoxEdit2.DataBindings.Add("EditValue", rowData, "cjry");
            this.comboBoxEdit28.DataBindings.Add("EditValue", rowData, "qxry");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "hdnr");
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "hdxj");
            this.memoEdit3.DataBindings.Add("EditValue", rowData, "py");
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "qz");
            this.dateEdit4.DataBindings.Add("EditValue", rowData, "qzrq");

        }
        #region IPopupFormEdit Members
        private PJ_02aqhd rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_02aqhd;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_02aqhd>(value as PJ_02aqhd, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            //填充下拉列表数据
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
    }
}