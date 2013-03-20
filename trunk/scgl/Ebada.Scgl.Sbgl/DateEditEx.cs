using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Ebada.Scgl.Sbgl {
    public class DateEditEx:DevExpress.XtraEditors.DateEdit {
        object source;
        string member;
        public DateEditEx()
            : base() {
        }

        void DateEditEx_EditValueChanged(object sender, EventArgs e) {
            Type t = source.GetType();

            t.GetProperty(member).SetValue(source, this.DateTime.Year>1900? this.DateTime.ToString(this.Properties.DisplayFormat.FormatString):"", null);
        }

        internal void BindingData(object rowData, string p) {
            source = rowData;
            member = p;
            Type t = rowData.GetType();
            this.EditValue = t.GetProperty(p).GetValue(rowData, null);
            this.EditValueChanged += new EventHandler(DateEditEx_EditValueChanged);
        }
    }
}
