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
    public partial class frmsgzaycEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_04sgzayc> m_CityDic = new SortableSearchableBindingList<PJ_04sgzayc>();

        public frmsgzaycEdit() {
            InitializeComponent();
        }
        void dataBind() {
            this.textEdit2.DataBindings.Add("EditValue", rowData, "fsdd"); 
            this.dateEdit2.DataBindings.Add("EditValue", rowData, "tdsj");
            this.dateEdit3.DataBindings.Add("EditValue", rowData, "sdsj");
            //this.textEdit1.DataBindings.Add("EditValue", rowData, "gtdsj");
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "ssdl");
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "clqk",false, DataSourceUpdateMode.OnPropertyChanged);
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "yyfx", false, DataSourceUpdateMode.OnPropertyChanged);
            this.memoEdit4.DataBindings.Add("EditValue", rowData, "fzdc", false, DataSourceUpdateMode.OnPropertyChanged);
            this.comboBoxEdit6.DataBindings.Add("EditValue", rowData, "zxr");

        }
        #region IPopupFormEdit Members
        private PJ_04sgzayc rowData = null;

        public object RowData {
            get {
               // rowData.gtdsj = rowData.sdsj - rowData.tdsj;
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_04sgzayc;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_04sgzayc>(value as PJ_04sgzayc, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            //填充下拉列表数据
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);//获取供电所人员列表
            if (ryList.Count>0)
            {
                this.comboBoxEdit6.Properties.Items.AddRange(ryList);
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("04事故异常运行记录", "异常运行内容", memoEdit2, memoEdit1,memoEdit4);
            //memoEdit2.Focus();,
        }
    }
}