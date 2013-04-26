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
    public partial class frmyxfa : FormBase, IPopupFormEdit 
    {
        public frmyxfa()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员

        private sdjls_fsgyxfa rowData;
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
                    this.rowData = value as sdjls_fsgyxfa;
                    
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<sdjls_fsgyxfa>(value as sdjls_fsgyxfa, rowData);
                }
            }
        }

       

        private void dataBind()
        {
            this.txtyxtm.DataBindings.Add("EditValue", rowData, "yxtm");
            this.memoyxfa.DataBindings.Add("EditValue", rowData, "yxfa");
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}