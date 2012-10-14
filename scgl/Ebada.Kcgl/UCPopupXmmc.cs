using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;
using System.Data;
using Ebada.Core;
using System.Collections;

namespace Ebada.Kcgl {
    public class UCPopupEdit : PopupContainerEdit {
        UCPopupSelectorBase xlselector;
        public UCPopupEdit()
            : base() {
            xlselector = new UCPopupSelectorBase();
            xlselector.RowSelected += new EventHandler(xlselector_RowSelected);
            this.Properties.PopupControl = new PopupContainerControl();
            this.Properties.PopupControl.Size = xlselector.Size;
            this.Properties.PopupControl.Controls.Add(xlselector);
            this.QueryPopUp += new System.ComponentModel.CancelEventHandler(UCPopupLine_QueryPopUp);
            this.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(UCPopupLine_QueryResultValue);
            this.CustomDisplayText+=new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(UCPopupLine_CustomDisplayText);
        }

        void  UCPopupLine_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && xlselector.DataSource!=null) {
               DataRow[] rows= xlselector.DataSource.Select(valueField+"='" + e.Value.ToString() + "'");
               if (rows.Length > 0) {
                   e.DisplayText = rows[0][displayField].ToString();
               }
            }
        }

        void UCPopupLine_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e) {
                     
        }

        void UCPopupLine_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e) {
            
        }
        void xlselector_RowSelected(object sender, EventArgs e) {
            DataRow  item = xlselector.GetFocusedDataRow();
            if (item != null) {
                EditValue = item[valueField];
            }   
            this.ClosePopup();
        }       
       
        public string GetDisplayText() {
            return this.EditViewInfo.DisplayText;
        }
        string displayField = "";
        public string DisplayField {
            get { return displayField; }
            set { 
                displayField = value;
                xlselector.SetColumnsVisible(value);
            }
        }
        string valueField = "";
        public string ValueField {
            get { return valueField; }
            set { valueField = value; }
        }
        string filterField = "xlpy";
        //public string FilterField {
        //    get { return filterField; }
        //    set { filterField = value;            
            
        //    }
        //}
        public object DataSource {
            get { return xlselector.DataSource; }
            set {
                if (value is DataTable) {
                    xlselector.DataSource = (DataTable)value;
                } else {
                    xlselector.DataSource = ConvertHelper.ToDataTable((IList)value);
                }
                DataTable dt = xlselector.DataSource as DataTable;
                createFilterColumn(dt);
                xlselector.SetColumnsVisible(displayField);
                xlselector.SetFilterColumns(filterField);                
            }
        }

        private void createFilterColumn(DataTable dt) {
            bool find = false;
            foreach (DataColumn item in dt.Columns) {
                if (item.ColumnName == filterField) {
                    find = true; break;
                }
            }
            if (!find) {
                dt.Columns.Add(filterField, typeof(string));
                foreach (DataRow row in dt.Rows) {

                    if (string.IsNullOrEmpty(row[displayField].ToString())) continue;
                    row[filterField] = Ebada.Scgl.Core.SelectorHelper.GetPysm(row[displayField].ToString());
                }
            }
        }
    }
}
