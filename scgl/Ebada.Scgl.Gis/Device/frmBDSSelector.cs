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
    public partial class frmBDSSelector : frmBaseSelector {
        public frmBDSSelector() {
            InitializeComponent();
            this.Text = "变电所";
        }

        protected override void InitData() {
            gridControl1.DataSource = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>(" where orgtype='2' order by  orgcode");
            foreach (GridColumn c in gridView1.Columns) {
                c.Visible = false;

            }
            try {
                gridView1.Columns["OrgName"].Visible = true;
                gridView1.Columns["OrgCode"].Visible = true;
            } catch { }
        }
    }
}
