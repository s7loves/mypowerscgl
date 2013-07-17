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
using Ebada.Scgl.Core;

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
                    InitComboBox();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<sd_xsjhnr>(value as sd_xsjhnr, rowData);
                }
            }
        }

        private void InitComboBox()
        {
            ComboBoxHelper.FillCBoxByDyk("巡视计划内容", "缺陷类别", txtflag1);
            if (!string.IsNullOrEmpty(txtflag1.EditValue as string))
            {
                rowData.flag1 = txtflag1.EditValue as string;
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
            rowData.xssj = Convert.ToDateTime(txtxssj.EditValue).ToShortDateString();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

     

        private void txtflag1_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtflag1.EditValue as string))
                return;
            if (txtflag1.EditValue as string != "")
            {
                this.txtqxnr.Enabled = true;
            }
            else
            {
                this.txtqxnr.Enabled = false;
                this.txtqxnr.EditValue = "";
            }
        }

        
    }
}