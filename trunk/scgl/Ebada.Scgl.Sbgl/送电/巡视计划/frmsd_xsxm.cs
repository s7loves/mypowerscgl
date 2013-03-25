using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Client.Platform;

using DevExpress.XtraGrid.Columns;
using System.Reflection;
using Ebada.Client;
using DevExpress.XtraGrid.Views.Base;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using DevExpress.XtraEditors.Repository;
using System.Collections;
using Ebada.Core;
using Ebada.UI.Base;

namespace Ebada.Scgl.Sbgl
{
    public partial class frmsd_xsxm : FormBase, IPopupFormEdit
    {
        public bool isupdate = false;
        public frmsd_xsxm()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private sd_xsxm rowData;
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
                    this.rowData = value as sd_xsxm;
                    
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<sd_xsxm>(value as sd_xsxm, rowData);
                }
            }
        }

        private void dataBind()
        {
            if (!isupdate)
            {
                this.datexssj.EditValue = DateTime.Now;
                rowData.xssj = DateTime.Now;
            }
            this.txtzl.DataBindings.Add("EditValue", rowData, "zl");
            this.txtmc.DataBindings.Add("EditValue", rowData, "mc");
            this.txtflag.DataBindings.Add("EditValue", rowData, "flag");
            this.datexssj.DataBindings.Add("EditValue", rowData, "xssj");
           
        }

        private void Initlkue()
        {
            
        }

        #endregion

        private void frmsd_xsxm_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}