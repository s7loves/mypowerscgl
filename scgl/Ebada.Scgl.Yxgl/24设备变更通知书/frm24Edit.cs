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
    public partial class frm24Edit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PJ_24> m_CityDic = new SortableSearchableBindingList<PJ_24>();

        public frm24Edit() {
            InitializeComponent();
        }
        void dataBind() {


            this.comboBoxEdit1.DataBindings.Add("EditValue", rowData, "dd");
            this.dateEdit1.DataBindings.Add("EditValue", rowData, "sj");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "nr");
            this.memoEdit2.DataBindings.Add("EditValue", rowData, "Remark");

        }
        #region IPopupFormEdit Members
        private PJ_24 rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PJ_24;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PJ_24>(value as PJ_24, rowData);
                }
                if (rowData.dd=="")
                {
                    rowData.sj = DateTime.Now;
                    
                }
            }
            
        }

        #endregion

        private void InitComboBoxData() {
           ICollection ryList = ComboBoxHelper.Getbtq();
            if (ryList.Count > 0)
            {
                comboBoxEdit1.Properties.Items.AddRange(ryList);
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

      

        private void frmdlgzdhjtjlEdit_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text == "")
            {
                MsgBox.ShowTipMessageBox("变动地点不能为空。");
                comboBoxEdit1.Focus();
                return;
            }
            if (rowData.BigData == null)
            {
                rowData.BigData = new byte[0];
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

      
    }
}