using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;

namespace Ebada.Scgl.Gis.Device {
    public partial class frmLineSelector : frmBaseSelector {
        public frmLineSelector() {
            InitializeComponent();
            
        }

        protected override void InitData() {
            gridControl1.DataSource = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("where len(linecode)=6 order by linecode");
            foreach (GridColumn c in gridView1.Columns) {
                c.Visible = false;

            }
            try {
                gridView1.Columns["LineName"].Visible = true;
                gridView1.Columns["LineCode"].Visible = true;
            } catch { }
        }
    }
}
