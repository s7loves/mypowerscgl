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
namespace Ebada.Scgl.Lcgl
{
    public partial class frmgzrjnrEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_gzrjnr> m_CityDic = new SortableSearchableBindingList<PJ_gzrjnr>();

        public frmgzrjnrEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.dateEdit1.DataBindings.Add("EditValue", rowData, "fssj");
            this.textEdit1.DataBindings.Add("EditValue", rowData, "seq");
            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "fzr");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "gznr",false, DataSourceUpdateMode.OnPropertyChanged);
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "cjry",false, DataSourceUpdateMode.OnPropertyChanged);


        }
        #region IPopupFormEdit Members
        private PJ_gzrjnr rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_gzrjnr;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_gzrjnr>(value as PJ_gzrjnr, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            ICollection ryList = ComboBoxHelper.GetGdsRy(UCPJ_gzrjnr.GetGdsCode());//获取供电所人员列表
            {
                ((ComboBoxEdit)groupBox1.Controls["comboBoxEdit1"]).Properties.Items.Clear();
                ((ComboBoxEdit)groupBox1.Controls["comboBoxEdit1"]).Properties.Items.AddRange(ryList);
            }
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("01工作日记", "工作地址及项目", memoEdit1);
        }
    }
}