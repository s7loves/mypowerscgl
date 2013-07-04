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
    public partial class frm_jyzylcl : FormBase, IPopupFormEdit 
    {
        public frm_jyzylcl()
        {
            InitializeComponent();
        }

        #region IPopupFormEdit 成员

        private sdjls_jyzylcl rowData;
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
                    this.rowData = value as sdjls_jyzylcl;
                    this.InitComboBoxData();
                    dataBind();
                }
                else
                {
                    ConvertHelper.CopyTo<sdjls_jyzylcl>(value as sdjls_jyzylcl, rowData);
                }
            }
        }

        private void InitComboBoxData()
        {
            ICollection list = new ArrayList();
            list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select gth from sd_gt where   LineCode='{0}' ", rowData.LineCode));
            cmbgh.Properties.Items.AddRange(list);
            ComboBoxHelper.FillCBoxByDyk("绝缘子", "型号", this.cmbxh.Properties);
            ComboBoxHelper.FillCBoxByDyk("绝缘子", "污秽等级", this.cmbwhdj.Properties);
        }

        private void dataBind()
        {
            this.cmbgh.DataBindings.Add("EditValue", rowData, "gh");
            this.cmbxh.DataBindings.Add("EditValue", rowData, "xh");
            this.spewd.DataBindings.Add("EditValue", rowData, "wd");
            this.spebmj.DataBindings.Add("EditValue", rowData, "bmj");
            this.memowz.DataBindings.Add("EditValue", rowData, "wz");
            this.spedzhyl.DataBindings.Add("EditValue", rowData, "dzhyl");
            this.spescymz.DataBindings.Add("EditValue", rowData, "scymz");
            this.cmbwhdj.DataBindings.Add("EditValue", rowData, "scwhdj");
            this.dateclrq.DataBindings.Add("EditValue", rowData, "clrq");
            this.memowytz.DataBindings.Add("EditValue", rowData, "whtz");
        }

        #endregion

        private void btnwz_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("绝缘子", "位置", this.memowz);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectorHelper.SelectDyk("绝缘子", "污源特征", this.memowytz);
        }

       
       
        
        
    }
}