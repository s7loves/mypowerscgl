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
namespace Ebada.Scgl.Lcgl
{
    public partial class frmGDSSelect : FormBase
    {
        /// <summary>
        /// 要导出的供电所 
        /// </summary>
        public string OrgCode { get; set; }

        /// <summary>
        /// 经办人
        /// </summary>
        public string JingBanRen { get; set; }

        public frmGDSSelect()
        {
            InitializeComponent();
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "1")
            {
                this.lkeGDS.Text = MainHelper.UserOrg.OrgName;
                this.lkeGDS.EditValue = MainHelper.UserOrg.OrgCode;
            }
            else
            {
                this.lkeGDS.Properties.DataSource = DicTypeHelper.GdsDic;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lkeGDS.EditValue == null)
            {
                MsgBox.ShowTipMessageBox("请选择要导出的供电所！");
            }
            else if (lkeGDS.EditValue == null)
            {
                MsgBox.ShowTipMessageBox("请选择经办人！");
            }
            else
            {
                OrgCode = lkeGDS.EditValue.ToString();
                JingBanRen = lkeGDS.EditValue.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void lkeGDS_EditValueChanged(object sender, EventArgs e)
        {
            if (lkeGDS.EditValue != null)
            {
                comjingbanren.Properties.Items.AddRange(ComboBoxHelper.GetGdsRy(lkeGDS.EditValue.ToString()));
            }
        }
    }
}