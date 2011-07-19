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
namespace Ebada.Scgl.Yxgl
{
    public partial class frmXSQD : DevExpress.XtraEditors.XtraForm
    {

        public frmXSQD()
        {
            InitializeComponent();
        }
        public mOrg parentobj;

        private void frmXSQD_Load(object sender, EventArgs e)
        {
            ucxsqd1.ParentObj = parentobj;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}