using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.UI.Base;
using System.Collections;

namespace Ebada.Scgl.Lcgl
{
    public partial class frmExploreSelect : FormBase
    {
        public frmExploreSelect()
        {
            InitializeComponent();
        }
        private DataTable sourcedt = null;
        private Hashtable checkIndexhs = new Hashtable();
        public DataTable SourceDt
        {
            set { sourcedt = value; RefreashData(); }
            get { return sourcedt; }
        }
        public Hashtable CheckIndehs
        {

            get { return checkIndexhs; }
        }
        private void RefreashData()
        {

            if (sourcedt != null) gridControl1.DataSource = sourcedt;
        
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            checkIndexhs.Clear();
            for (int i = 0; i < sourcedt.Rows.Count; i++)
            {
                if( sourcedt.Rows[i]["Checked"].ToString()=="1" )
                {
                    checkIndexhs.Add(sourcedt.Rows[i]["Index"], sourcedt.Rows[i]["Name"]);
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < sourcedt.Rows.Count; i++)
            {
                sourcedt.Rows[i]["Checked"] = checkEdit1.Checked;

            }
        }
    }
}
