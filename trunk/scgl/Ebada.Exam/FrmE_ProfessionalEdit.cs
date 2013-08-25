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
    public partial class FrmE_ProfessionalEdit :FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_gtsb> m_CityDic = new SortableSearchableBindingList<PS_gtsb>();
        public FrmE_ProfessionalEdit()
        {
            InitializeComponent();
        }

        void dataBind()
        {

            this.txtName.DataBindings.Add("EditValue", rowData, "PName");
            this.mtxtDesc.DataBindings.Add("EditValue", rowData, "Desc");

        }
        private E_Professional rowData = null;

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
                    this.rowData = value as E_Professional;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<E_Professional>(value as E_Professional, rowData);
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
                MsgBox.ShowWarningMessageBox("专业名称不能为空！");
                return;
            }
            IList<E_Professional> list = Client.ClientHelper.PlatformSqlMap.GetList<E_Professional>(" where PName='" + pname + "' ");
            if (list.Count>0&&rowData.ID!=list[0].ID)
            {
                MsgBox.ShowWarningMessageBox("已存在名称为【" + pname + "】的专业！");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

       
    }
}
