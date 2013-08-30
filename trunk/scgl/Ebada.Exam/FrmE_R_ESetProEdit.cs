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
    public partial class FrmE_R_ESetProEdit :FormBase, IPopupFormEdit {
        SortableSearchableBindingList<E_R_ESetPro> m_CityDic = new SortableSearchableBindingList<E_R_ESetPro>();
        public FrmE_R_ESetProEdit()
        {
            InitializeComponent();
        }
       

        void dataBind()
        {

            this.spinEdit1.DataBindings.Add("EditValue", rowData,"JudgeNUM");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "SelectNUM");
            this.spinEdit3.DataBindings.Add("EditValue", rowData, "MuSelectNUM");

        }
        private E_R_ESetPro rowData = null;

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
                    this.rowData = value as E_R_ESetPro;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<E_R_ESetPro>(value as E_R_ESetPro, rowData);
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
           
            this.DialogResult = DialogResult.OK;
        }

       
    }
}
