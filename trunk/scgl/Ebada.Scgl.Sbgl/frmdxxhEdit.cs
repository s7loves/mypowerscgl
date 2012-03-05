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
namespace Ebada.Scgl.Sbgl
{
    public partial class frmdxxhEdit : FormBase, IPopupFormEdit {
        SortableSearchableBindingList<PS_dxxh> m_CityDic = new SortableSearchableBindingList<PS_dxxh>();

        public frmdxxhEdit() {
            InitializeComponent();
        }
        void dataBind() {

          
            this.spinEdit1.DataBindings.Add("EditValue", rowData, "dwdz");
            this.spinEdit2.DataBindings.Add("EditValue", rowData, "jmj");

            this.textEdit1.DataBindings.Add("EditValue", rowData, "dydj");
            this.textEdit2.DataBindings.Add("EditValue", rowData, "dxxh");


        }
        #region IPopupFormEdit Members
        private PS_dxxh rowData = null;

        public object RowData {
            get {
                return rowData;
            }
            set {
                if (value == null) return;
                if (rowData == null) {
                    this.rowData = value as PS_dxxh;
                    this.InitComboBoxData();
                    dataBind();
                } else {
                    ConvertHelper.CopyTo<PS_dxxh>(value as PS_dxxh, rowData);
                }     
            }
        }

        #endregion

        private void InitComboBoxData() {
            pdsbModelHelper.FillCBox(textEdit2, pdsbModelHelper.dxxh);
            this.textEdit1.Properties.Items.AddRange(ComboBoxHelper.GetVoltage()); 
        }

    }
}