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
    public partial class FrmE_QBankEdit :FormBase, IPopupFormEdit {
        SortableSearchableBindingList<E_QBank> m_CityDic = new SortableSearchableBindingList<E_QBank>();
        public FrmE_QBankEdit()
        {
            InitializeComponent();
        }

        void dataBind()
        {

            this.txtName.DataBindings.Add("EditValue", rowData, "TKName");
            this.mtxtDesc.DataBindings.Add("EditValue", rowData, "Desc");

        }
        private E_QBank rowData = null;

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
                    this.rowData = value as E_QBank;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<E_QBank>(value as E_QBank, rowData);
                }
            }
        }

        private void InitComboBoxData()
        {

            //SetComboBoxData(comboBoxEdit2, "mc", "bh", "", "种类", Ebada.Client.ClientHelper.PlatformSqlMap.GetList<PS_sbcs>("where len(bh)=5 order by bh"));
            //comboBoxEdit2.EditValueChanged += new EventHandler(comboBoxEdit2_EditValueChanged);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string pname = txtName.Text.Trim();
            if (pname.Length== 0)
            {
                MsgBox.ShowWarningMessageBox("题库名称不能为空！");
                return;
            }
            IList<E_QBank> list = Client.ClientHelper.PlatformSqlMap.GetList<E_QBank>(" where TKName='" + pname + "' ");
            if (list.Count>0&&rowData.ID!=list[0].ID)
            {
                MsgBox.ShowWarningMessageBox("已存在名称为【" + pname + "】的题库！");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

       
    }
}
