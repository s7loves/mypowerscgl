using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.UI.Base;
using Ebada.Client;
using Ebada.Client.Platform;
using Ebada.Core;
using Ebada.Scgl.Model;
using Ebada.Scgl.Core;
using System.Collections;
namespace Ebada.Scgl.Lcgl
{
    public partial class frmXSQD : DevExpress.XtraEditors.XtraForm
    {

        public frmXSQD()
        {
            InitializeComponent();
        }
        public mOrg parentobj;
        public PJ_06sbxs xsobj;
        private void frmXSQD_Load(object sender, EventArgs e)
        {
            ucxsqd1.ParentObj = parentobj;
            ucxsqd1.SbxsObj = xsobj;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}