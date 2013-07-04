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
    public partial class frm_xlwhdd : FormBase, IPopupFormEdit 
    {
        public frm_xlwhdd()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员

        private sdjls_xlwhjl rowData;
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
                    this.rowData = value as sdjls_xlwhjl;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<sdjls_xlwhjl>(value as sdjls_xlwhjl, rowData);
                }
            }
        }

        private void InitComboBoxData()
        {
            ComboBoxHelper.FillCBoxByDyk("绝缘子", "型号", this.cmbzxjyzxh.Properties);
            ComboBoxHelper.FillCBoxByDyk("绝缘子", "型号", this.cmbnzjyzxh.Properties);
            ComboBoxHelper.FillCBoxByDyk("绝缘子", "污秽等级", cmbwhdj.Properties);
            ComboBoxHelper.FillCBoxByDyk("绝缘子", "污源性质", cmbwyxz.Properties);
        }

        private void dataBind()
        {

            string[] zx = rowData.jyzxh.Split('|');
            string[] nz = rowData.zhfs.Split('|');
            if (zx.Length == 2)
            {
                cmbzxjyzxh.EditValue = zx[0];
                txtzxzhfs.EditValue = zx[1];
            }
            if (nz.Length == 2)
            {
                cmbnzjyzxh.EditValue = nz[0];
                txtnzzhfs.EditValue = nz[1];
            }
            this.txtwhqd.DataBindings.Add("EditValue", rowData, "whqd");
            this.cmbwyxz.DataBindings.Add("EditValue", rowData, "wyxz");
            this.cmbwhdj.DataBindings.Add("EditValue", rowData, "whdj");
            this.txtxlbj.DataBindings.Add("EditValue", rowData, "xlbj");
            this.memobz.DataBindings.Add("EditValue", rowData, "bz");
            
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            string zxzhfs = string.IsNullOrEmpty(txtzxzhfs.EditValue as string) ? "" : txtnzzhfs.EditValue as string;
            string nzzhfs = string.IsNullOrEmpty(txtnzzhfs.EditValue as string) ? "" : txtnzzhfs.EditValue as string;
            rowData.jyzxh = cmbzxjyzxh.EditValue.ToString() + "|" + zxzhfs;
            rowData.zhfs = cmbnzjyzxh.EditValue.ToString() + "|" + nzzhfs;
        }

        private void btnwhqd_Click(object sender, EventArgs e)
        {
            frm_WhddSelect frm = new frm_WhddSelect();
            frm.SetLineCode(rowData.LineCode);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.txtwhqd.EditValue = frm.Whqd.whqd;
                rowData.whqd = frm.Whqd.whqd;
                this.cmbwyxz.EditValue = frm.Whqd.whxz;
                rowData.wyxz = frm.Whqd.whxz;
                this.cmbwhdj.EditValue = frm.Whqd.whdj;
                rowData.whdj = frm.Whqd.whdj;
            }
        }

    }
}