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
using System.IO;

namespace Ebada.Exam
{
    public partial class FrmE_PropEdit :FormBase, IPopupFormEdit {
        SortableSearchableBindingList<E_Prop> m_CityDic = new SortableSearchableBindingList<E_Prop>();
        public FrmE_PropEdit()
        {
            InitializeComponent();
        }

        void dataBind()
        {

            this.txtPropName.DataBindings.Add("EditValue", rowData, "PropName");
            this.mtxtFunction.DataBindings.Add("EditValue", rowData, "Function");
            this.spPrice.DataBindings.Add("EditValue", rowData, "Price");
            this.txtCode.DataBindings.Add("EditValue", rowData, "Code");
            
        }
        private E_Prop rowData = null;

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
                    this.rowData = value as E_Prop;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<E_Prop>(value as E_Prop, rowData);
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
            string pname = txtPropName.Text.Trim();
            if (pname.Length== 0)
            {
                MsgBox.ShowWarningMessageBox("道具名称不能为空！");
                return;
            }

            if (txtCode.Text.Trim().Length==0)
            {
                MsgBox.ShowWarningMessageBox("代码不能为空！");
                return;
            }


            this.DialogResult = DialogResult.OK;
        }

   

       
    }
}
