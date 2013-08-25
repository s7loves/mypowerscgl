using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using Ebada.Core;
using Ebada.Client.Platform;
using Ebada.Client;
using Ebada.UI.Base;

namespace Ebada.Exam
{
    public partial class FrmE_R_EBankProEdit :FormBase, IPopupFormEdit {
        SortableSearchableBindingList<E_R_EBankPro> m_CityDic = new SortableSearchableBindingList<E_R_EBankPro>();
        public FrmE_R_EBankProEdit()
        {
            InitializeComponent();
        }

        void dataBind()
        {

            this.lkueorg.DataBindings.Add("EditValue", rowData, "PROID");

        }
        private E_R_EBankPro rowData = null;

        public object RowData
        {
            get
            {
                return rowData;
            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as E_R_EBankPro;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<E_R_EBankPro>(value as E_R_EBankPro, rowData);
                }
            }
        }

        private void InitComboBoxData()
        {
            IList<E_Professional> orglist = Client.ClientHelper.PlatformSqlMap.GetList<E_Professional>("");
            SetComboBoxData(lkueorg, "PName", "ID", "请选择", "专业", orglist);
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lkueorg.EditValue == null)
            {
                MsgBox.ShowWarningMessageBox("请选择专业！");
                return;
            }
            IList<E_R_EBankPro> list = Client.ClientHelper.PlatformSqlMap.GetList<E_R_EBankPro>(" where PROID='" + lkueorg.EditValue.ToString() + "' and EBID='" + rowData.EBID + "'");
            if (list.Count > 0&&rowData.ID!=list[0].ID)
            {
                MsgBox.ShowWarningMessageBox("该题库已添加名为【" + lkueorg.Text + "】的专业！");
                return;
            }
            this.DialogResult = DialogResult.OK;
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
        public void SetComboBoxData(DevExpress.XtraEditors.LookUpEdit comboBox, string displayMember, string valueMember, string nullTest, string cnStr, IList<E_Professional> post)
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
    }
}
