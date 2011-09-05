using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using Ebada.Core;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Reflection;
using Ebada.Client;
using Ebada.Client.Platform;

namespace Ebada.Scgl.Lcgl
{
    public partial class frmTemplate : DevExpress.XtraEditors.XtraForm
    {
       // Microsoft.Office.Interop.Excel.Application exc = new Microsoft.Office.Interop.Excel.Application(); //引用Excel对象
        string uid1 = "";
        string filename = "";
        string filepath = Path.GetTempPath();
       

        public frmTemplate()
        {
            InitializeComponent();
        }
     

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void frm26Template_Load(object sender, EventArgs e)
        {
           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.OK;
        }

        private void frm24Template_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

    }
}