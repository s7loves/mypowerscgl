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
    public partial class frm_ddxljqnr : FormBase, IPopupFormEdit 
    {
        public frm_ddxljqnr()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员

        private sdjls_ddxljqnr rowData;
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
                    this.rowData = value as sdjls_ddxljqnr;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<sdjls_ddxljqnr>(value as sdjls_ddxljqnr, rowData);
                }
            }
        }

        private void InitComboBoxData()
        {
            IList<sd_gt> gtList = Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_gt>("where LineCode='" + rowData.c1 + "'");
            foreach (sd_gt gt in gtList)
            {
                this.cmbgh.Properties.Items.Add(gt.gth);
            }
            ComboBoxHelper.FillCBoxByDyk("送电导地线连接器检测记录","相别", this.cmbxb);
            ComboBoxHelper.FillCBoxByDyk("送电导地线连接器检测记录", "连接型式", this.cmbljxs);
            ComboBoxHelper.FillCBoxByDyk("送电导地线连接器检测记录", "导地线型号", this.cmbddxxh);
            ComboBoxHelper.FillCBoxByDyk("送电导地线连接器检测记录", "连接器型号", this.cmbljqxh);
            ComboBoxHelper.FillCBoxByDyk("送电导地线连接器检测记录", "生产厂家", this.cmbsccj);
            ComboBoxHelper.FillCBoxByDyk("送电导地线连接器检测记录", "档距", this.txtdj);
            ComboBoxHelper.FillCBoxByDyk("送电导地线连接器检测记录", "档距中位置", this.txtdjzwz);
        }

        private void dataBind()
        {
            this.cmbgh.DataBindings.Add("EditValue", rowData, "gth");
            this.cmbxb.DataBindings.Add("EditValue", rowData, "xb");
            this.txtdj.DataBindings.Add("EditValue", rowData, "dj");
            this.cmbljxs.DataBindings.Add("EditValue", rowData, "ljxs");
            this.txtdjzwz.DataBindings.Add("EditValue", rowData, "djzwz");
            this.cmbddxxh.DataBindings.Add("EditValue", rowData, "ddxxh");
            this.cmbljqxh.DataBindings.Add("EditValue", rowData, "ljqxh");
            this.cmbsccj.DataBindings.Add("EditValue", rowData, "sccj");
            this.txtbz.DataBindings.Add("EditValue", rowData, "bz");
           
        }

        #endregion

        private void cmbgh_EditValueChanged(object sender, EventArgs e)
        {
            if (this.cmbgh.EditValue == null)
                return;
            if (string.IsNullOrEmpty(cmbgh.EditValue.ToString()))
                return;
            sd_gt gt= Client.ClientHelper.PlatformSqlMap.GetOne<sd_gt>("where gth='"+this.cmbgh.EditValue+"'");
            rowData.dj = gt.gtSpan.ToString();
            this.txtdj.EditValue = gt.gtSpan.ToString();
        }

        

       
    }
}