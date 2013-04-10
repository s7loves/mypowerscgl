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

namespace Ebada.Scgl.Sbgl
{
    public partial class frm_yxgzjlb : FormBase, IPopupFormEdit
    {
        public frm_yxgzjlb()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_yxgzjlb rowData;
        public object RowData
        {
            get
            {
                return this.rowData;
            }
            set
            {
                if (value == null) return;
                if (rowData == null)
                {
                    this.rowData = value as bdjl_yxgzjlb;

                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_yxgzjlb>(value as bdjl_yxgzjlb, rowData);
                }
            }
        }

        private void dataBind()
        {
            this.daterq.DataBindings.Add("EditValue", rowData, "rq");
            this.txttq.DataBindings.Add("EditValue", rowData, "tq");
            this.txtjbfzr.DataBindings.Add("EditValue", rowData, "jbfzr");
            this.txtjbry.DataBindings.Add("EditValue", rowData, "jbry");
            this.txtjbfzry.DataBindings.Add("EditValue", rowData, "jbfzry");
            this.txtjbryy.DataBindings.Add("EditValue", rowData, "jbryy");

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