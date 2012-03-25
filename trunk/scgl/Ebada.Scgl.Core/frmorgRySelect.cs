using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Client;
using DevExpress.XtraGrid.Views.Base;
using Ebada.Scgl.Model;
using Ebada.Client.Platform;

namespace Ebada.Scgl.Core
{
    public partial class frmorgRySelect : DevExpress.XtraEditors.XtraForm
    {
        public frmorgRySelect()
        {
            InitializeComponent();
        }
        public string gdscode;
        private DataTable dt1 = new DataTable();

        public DataTable DT1
        {
            get { return dt1; }
        }

        private void init()
        {
            dt1.Columns.Add("A", typeof(string));
            dt1.Columns.Add("B", typeof(bool));
            IList<string> list = Client.ClientHelper.PlatformSqlMap.GetList<string>("SelectOneStr", "select UserName from mUser where orgcode='" + gdscode+ "'");
            foreach (string rm in list)
            {
                DataRow row = dt1.NewRow();
                row["A"] = rm;
                row["B"] = true;
                dt1.Rows.Add(row);
            }
            gridControl2.DataSource = dt1;
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in dt1.Rows)
                dr["B"] = checkEdit2.Checked;
        }

        private void frmorgRySelect_Load(object sender, EventArgs e)
        {
            dt1.Rows.Clear();
            init();
        }
          
    }
}