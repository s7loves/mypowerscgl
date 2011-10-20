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
using System.Collections;
namespace Ebada.Scgl.Gis
{
    public partial class frmBdsEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<mOrg> m_CityDic = new SortableSearchableBindingList<mOrg>();

        public frmBdsEdit() {
            InitializeComponent();
        }
        void dataBind() {


            this.textEdit1.DataBindings.Add("EditValue", rowData, "OrgCode");
            this.textEdit2.DataBindings.Add("EditValue", rowData, "OrgName");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "c1");
            this.spinEdit3.DataBindings.Add("EditValue", rowData, "c2");
            this.memoEdit1.DataBindings.Add("EditValue", rowData, "c3");
            //this.lookUpEdit1.DataBindings.Add("EditValue", rowData, "OrgType");
            //this.dateEdit1.DataBindings.Add("EditValue", rowData, "PSafeTime");           
            //this.dateEdit2.DataBindings.Add("EditValue", rowData, "DSafeTime");

        }
        #region IPopupFormEdit Members
        private mOrg rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as mOrg;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<mOrg>(value as mOrg, rowData);
                }
            }
        }

        #endregion

        private void InitComboBoxData() {
            
        }


        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}