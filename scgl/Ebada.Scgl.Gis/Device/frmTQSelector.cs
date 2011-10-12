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
    public partial class frmTQSelector : frmBaseSelector {
        public frmTQSelector() {
            InitializeComponent();
            
        }

        protected override void InitData() {
            gridControl1.DataSource = Client.ClientHelper.PlatformSqlMap.GetList<PS_tq>(" order by  tqcode");
            foreach (GridColumn c in gridView1.Columns) {
                c.Visible = false;

            }
            try {
                gridView1.Columns["tqName"].Visible = true;
                gridView1.Columns["tqCode"].Visible = true;
            } catch { }
        }
    }
}
