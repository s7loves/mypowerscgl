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
    public partial class frm_aqhdjlb : FormBase, IPopupFormEdit 
    {
        public frm_aqhdjlb()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_aqhdjlb rowData;
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
                    this.rowData = value as bdjl_aqhdjlb;

                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_aqhdjlb>(value as bdjl_aqhdjlb, rowData);
                }
            }
        }

        private void dataBind()
        {
            this.txtzcr.DataBindings.Add("EditValue", rowData, "zcr");
            this.datehdkssj.DataBindings.Add("EditValue", rowData, "hdkssj");
            this.datehdjssj.DataBindings.Add("EditValue", rowData, "hdjssj");
            this.memocxry.DataBindings.Add("EditValue", rowData, "cxry");
            this.memoqxry.DataBindings.Add("EditValue", rowData, "qxry");
            this.memohdnr.DataBindings.Add("EditValue", rowData, "hdnr");
            this.memohdxj.DataBindings.Add("EditValue", rowData, "hdxj");
            this.memoldjcpy.DataBindings.Add("EditValue", rowData, "ldjcpy");
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