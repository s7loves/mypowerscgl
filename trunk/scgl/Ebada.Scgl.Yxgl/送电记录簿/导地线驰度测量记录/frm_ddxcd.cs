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
    public partial class frm_ddxcd : FormBase, IPopupFormEdit 
    {
        public frm_ddxcd()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员

        private sdjls_ddxcd rowData;
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
                    this.rowData = value as sdjls_ddxcd;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<sdjls_ddxcd>(value as sdjls_ddxcd, rowData);
                }
            }
        }

        private void InitComboBoxData()
        {
            //耐张杆号
            IList<sd_gt> gtList= Client.ClientHelper.PlatformSqlMap.GetListByWhere<sd_gt>("where LineCode='"+rowData.LineCode+"'");
            foreach (sd_gt gt in gtList)
            {
                this.cmbnzdgh.Properties.Items.Add(gt.gth);
                this.cmbcldgh.Properties.Items.Add(gt.gth);
            }
            //型号
            ComboBoxHelper.FillCBoxByDyk("送电导地线驰度测量记录", "导线型号", this.cmbdxxh);
            ComboBoxHelper.FillCBoxByDyk("送电导地线驰度测量记录", "地线型号", this.cmbddxxh);

            List<string> jlList = new List<string>();
            jlList.Add("合格");
            jlList.Add("不合格");
            this.cmddxjl.Properties.Items.AddRange(jlList);
            this.cmbddxjl.Properties.Items.AddRange(jlList);
            //测量人
            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);//获取供电所人员列表
            cmbclr.Properties.Items.AddRange(ryList);
        }

        private void dataBind()
        {
            this.cmbnzdgh.DataBindings.Add("EditValue", rowData, "nzdgh");
            this.cmbcldgh.DataBindings.Add("EditValue", rowData, "cldgh");
            this.cmbdxxh.DataBindings.Add("EditValue", rowData, "dxxh");
            this.cmbddxxh.DataBindings.Add("EditValue", rowData, "ddxxh");
            this.txtdxbzz.DataBindings.Add("EditValue", rowData, "dxbzz");
            this.txtddxbzz.DataBindings.Add("EditValue", rowData, "ddxbzz");
            this.txtdxscz.DataBindings.Add("EditValue", rowData, "dxscz");
            this.txtdxsczz.DataBindings.Add("EditValue", rowData, "dxsczz");
            this.txtdxszzy.DataBindings.Add("EditValue", rowData, "dxsczy");
            this.txtddxszz.DataBindings.Add("EditValue", rowData, "ddxscz");
            this.txtddxsczy.DataBindings.Add("EditValue", rowData, "ddxsczy");
            this.txtdxwcz.DataBindings.Add("EditValue", rowData, "dxwcz");
            this.txtdxwczz.DataBindings.Add("EditValue", rowData, "dxwczz");
            this.txtdxwcy.DataBindings.Add("EditValue", rowData, "dxwcy");
            this.txtddwcz.DataBindings.Add("EditValue", rowData, "ddwcz");
            this.txtddwcy.DataBindings.Add("EditValue", rowData, "ddwcy");
            this.spewd.DataBindings.Add("EditValue", rowData, "wd");
            this.dateclrq.DataBindings.Add("EditValue", rowData, "clrq");
            this.cmbclr.DataBindings.Add("EditValue", rowData, "clr");
            this.cmddxjl.DataBindings.Add("EditValue", rowData, "dxjl");
            this.cmbddxjl.DataBindings.Add("EditValue", rowData, "ddxjl");
        }

        #endregion

        /// <summary>
        /// 刷新导线误差率
        /// </summary>
        private void RefreshDxwc(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtdxbzz.EditValue) <= 0)
                return;
            if (Convert.ToDouble(txtdxscz.EditValue) > 0)
            {
                txtdxwcz.EditValue = Math.Round(((Convert.ToDouble(txtdxbzz.EditValue) - Convert.ToDouble(txtdxscz.EditValue)) / Convert.ToDouble(txtdxbzz.EditValue)), 2) * 100;
                rowData.dxwcz = txtdxwcz.EditValue.ToString();
            }

            if (Convert.ToDouble(txtdxsczz.EditValue) > 0)
            {
                txtdxwczz.EditValue = Math.Round(((Convert.ToDouble(txtdxbzz.EditValue) - Convert.ToDouble(txtdxsczz.EditValue)) / Convert.ToDouble(txtdxbzz.EditValue)), 2) * 100;
                rowData.dxwczz = txtdxwczz.EditValue.ToString();
            }
            if (Convert.ToDouble(txtdxszzy.EditValue) > 0)
            {
                txtdxwcy.EditValue = Math.Round((Convert.ToDouble(txtdxbzz.EditValue) - Convert.ToDouble(txtdxszzy.EditValue)) / Convert.ToDouble(txtdxbzz.EditValue), 2) * 100;
                rowData.dxwcy = txtdxwcy.EditValue.ToString();
            }
        }
        /// <summary>
        /// 刷新导地线误差率
        /// </summary>
        private void RefreshDDxwc(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtddxbzz.EditValue) <= 0)
                return;
            if (Convert.ToDouble(txtddxszz.EditValue) > 0)
            {
                txtddwcz.EditValue = Math.Round(((Convert.ToDouble(txtddxbzz.EditValue) - Convert.ToDouble(txtddxszz.EditValue)) / Convert.ToDouble(txtddxbzz.EditValue)), 2) * 100;
                rowData.ddwcz = txtddwcz.EditValue.ToString();
            }
            if (Convert.ToDouble(txtddxsczy.EditValue) > 0)
            {
                txtddwcy.EditValue = Math.Round(((Convert.ToDouble(txtddxbzz.EditValue) - Convert.ToDouble(txtddxsczy.EditValue)) / Convert.ToDouble(txtddxbzz.EditValue)), 2) * 100;
                rowData.ddwcy = txtddwcy.EditValue.ToString();
            }
            
        }

       
    }
}