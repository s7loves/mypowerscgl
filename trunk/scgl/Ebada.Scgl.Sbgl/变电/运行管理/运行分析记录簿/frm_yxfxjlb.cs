﻿using System;
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
    public partial class frm_yxfxjlb : FormBase, IPopupFormEdit 
    {
        public frm_yxfxjlb()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员
        private bdjl_yxfxjlb rowData;
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
                    this.rowData = value as bdjl_yxfxjlb;

                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<bdjl_yxfxjlb>(value as bdjl_yxfxjlb, rowData);
                }
            }
        }

        private void dataBind()
        {
            this.daterq.DataBindings.Add("EditValue", rowData, "sj");
            this.memocjry.DataBindings.Add("EditValue", rowData, "cjry");
            this.memonr.DataBindings.Add("EditValue", rowData, "nr");
            this.memojl.DataBindings.Add("EditValue", rowData, "jl");

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