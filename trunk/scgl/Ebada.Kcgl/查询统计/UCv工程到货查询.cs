using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Ebada.Kcgl {
    public partial class UCv工程到货查询 : UserControl {
        public UCv工程到货查询() {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            //查询

           IList list= Client.ClientHelper.TransportSqlMap.GetList("Select", "select * from v工程到货查询表");

           gridControl1.DataSource = DataConvert.HashTablesToDataTable(list);
        }
       
    }
}
