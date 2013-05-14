using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;
using Ebada.Core;
using Ebada.UI.Base;
using Ebada.Client;

namespace Ebada.Scgl.Sbgl
{
    public partial class frmsd_xsjhnrEdit : FormBase, IPopupFormEdit
    {
        public frmsd_xsjhnrEdit()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员

        private sd_xsjhnr rowData;
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
                    this.rowData = value as sd_xsjhnr;

                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<sd_xsjhnr>(value as sd_xsjhnr, rowData);
                }
            }
        }

        private void dataBind()
        {
            this.txtgtid.DataBindings.Add("EditValue", rowData, "gtid");
            this.txtgtbh.DataBindings.Add("EditValue", rowData, "gtbh");
            this.txtflag1.DataBindings.Add("EditValue", rowData, "flag1");
            this.txtlng.DataBindings.Add("EditValue", rowData, "lng");
            this.txtlat.DataBindings.Add("EditValue", rowData, "lat");
            this.txtflag2.DataBindings.Add("EditValue", rowData, "flag2");
            this.txtxssj.DataBindings.Add("EditValue", rowData, "xssj");
            this.txtqxnr.DataBindings.Add("EditValue", rowData, "qxnr");
        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmsd_xsjhnrEdit_Load(object sender, EventArgs e)
        {

        }
    }
}