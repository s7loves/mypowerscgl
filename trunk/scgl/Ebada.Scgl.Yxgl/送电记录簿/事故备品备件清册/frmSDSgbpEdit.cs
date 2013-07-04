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
    public partial class frmSDSgbpEdit : FormBase, IPopupFormEdit {

        public frmSDSgbpEdit()
        {
            InitializeComponent();
        }
        
        #region IPopupFormEdit Members
        private sdjls_sgbp rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as sdjls_sgbp;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<sdjls_sgbp>(value as sdjls_sgbp, rowData);
                }
            }
        }

        void dataBind()
        {
            this.cmbbpbjmc.DataBindings.Add("EditValue", rowData, "bpbjmc");
            this.cmbgexh.DataBindings.Add("EditValue", rowData, "gexh");
            this.cmbdw.DataBindings.Add("EditValue", rowData, "dw");
            this.spelrsl.DataBindings.Add("EditValue", rowData, "lrsl");
            this.datelrsj.DataBindings.Add("EditValue", rowData, "lrsj");
            this.spelcsl.DataBindings.Add("EditValue", rowData, "lcsl");
            this.datelcsj.DataBindings.Add("EditValue", rowData, "lcsj");
            this.cmblyr.DataBindings.Add("EditValue", rowData, "lyr");
            this.spekcsl.DataBindings.Add("EditValue", rowData, "kcsl");
        }

        #endregion

        private void InitComboBoxData() {

            ICollection ryList = ComboBoxHelper.GetGdsRy(rowData.OrgCode);//获取供电所人员列表
            this.cmblyr.Properties.Items.AddRange(ryList);
            ComboBoxHelper.FillCBoxByDyk("送电事故备品备件清册", "备品备件名称", cmbbpbjmc.Properties);
            ComboBoxHelper.FillCBoxByDyk("送电事故备品备件清册", "规格型号", cmbgexh.Properties);

            ComboBoxHelper.FillCBoxByDyk("公用属性", "单位", cmbdw.Properties);
        }
   }
}