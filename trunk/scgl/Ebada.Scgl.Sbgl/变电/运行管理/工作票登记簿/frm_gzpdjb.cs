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
    public partial class frm_gzpdjb : FormBase, IPopupFormEdit 
    {
        public frm_gzpdjb()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_gzpdjb rowData;
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
                    this.rowData = value as bdjl_gzpdjb;

                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_gzpdjb>(value as bdjl_gzpdjb, rowData);
                }
            }
        }

        private void dataBind()
        {
            this.txtOrgName.DataBindings.Add("EditValue", rowData, "c1");
            this.txtgzpbh.DataBindings.Add("EditValue", rowData, "gzpbh");
            this.txtgzpzl.DataBindings.Add("EditValue", rowData, "gzpzl");
            this.txtgzfzr.DataBindings.Add("EditValue", rowData, "gzpfzr");
            this.dateStartTime.DataBindings.Add("EditValue", rowData, "gzkssj");
            this.dateEndTime.DataBindings.Add("EditValue", rowData, "gzjssj");
            this.txtgzxkr.DataBindings.Add("EditValue", rowData, "gzxkr");
            this.txtzbz.DataBindings.Add("EditValue", rowData, "zbz");
            this.txtgzpqfr.DataBindings.Add("EditValue", rowData, "gzpqfr");
            this.meogzddjnr.DataBindings.Add("EditValue", rowData, "gzddjnr");
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