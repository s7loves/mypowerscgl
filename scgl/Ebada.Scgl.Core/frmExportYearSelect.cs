﻿using System;
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
    public partial class frmExportYearSelect : DevExpress.XtraEditors.XtraForm
    {
        public frmExportYearSelect()
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
            dt1.Columns.Add("C", typeof(string));
            dt1.Columns.Add("D", typeof(bool));
            dt1.Columns.Add("E", typeof(string));
            dt1.Columns.Add("F", typeof(bool));
            //IList<string> list = Client.ClientHelper.PlatformSqlMap.GetList<string>("SelectOneStr", "select UserName from mUser where orgcode='" + gdscode+ "'");
            for (int i = 0; i < 3;i++ )
            {
                string y = (2009 + i).ToString();
                string y1 = (2012 + i).ToString();
                string y2 = (2015 + i).ToString();

                DataRow row = dt1.NewRow();
                row["A"] =y;
                row["B"] = false;
                row["C"] = y1;
                row["D"] = false;
                row["E"] = y2;
                row["F"] = false;
                dt1.Rows.Add(row);
            }
            //foreach (string rm in list)
            //{
            //    DataRow row = dt1.NewRow();
            //    row["A"] = rm;
            //    row["B"] = true;
            //    dt1.Rows.Add(row);
            //}
            gridControl2.DataSource = dt1;
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in dt1.Rows)
            {
                dr["B"] = checkEdit2.Checked;
                dr["D"] = checkEdit2.Checked;
                dr["F"] = checkEdit2.Checked;
            }
                
        }

        private void frmorgRySelect_Load(object sender, EventArgs e)
        {
            dt1.Rows.Clear();
            init();
        }
          
    }
}