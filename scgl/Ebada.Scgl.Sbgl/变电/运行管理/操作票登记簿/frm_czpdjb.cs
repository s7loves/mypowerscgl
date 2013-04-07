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
    public partial class frm_czpdjb : FormBase, IPopupFormEdit 
    {
        public frm_czpdjb()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_czpdjb rowData;
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
                    this.rowData = value as bdjl_czpdjb;
                    
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_czpdjb>(value as bdjl_czpdjb, rowData);
                }
            }
        }

        private void dataBind()
        {
            this.txtOrgName.DataBindings.Add("EditValue", rowData, "c1");
            this.daterq.DataBindings.Add("EditValue", rowData, "dDate");
            this.txtczpsybh.DataBindings.Add("EditValue", rowData, "czpsybh");
            this.txtczr.DataBindings.Add("EditValue", rowData, "czr");
            this.txtjhr.DataBindings.Add("EditValue", rowData, "jhr");
            this.txtzbr.DataBindings.Add("EditValue", rowData, "zbr");
            this.meoczrw.DataBindings.Add("EditValue", rowData, "czrw");

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