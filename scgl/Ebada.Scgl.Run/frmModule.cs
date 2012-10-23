using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ebada.Scgl.Run
{
    public partial class frmModule : DevExpress.XtraEditors.XtraForm
    {
        public frmModule()
        {
            InitializeComponent();
            this.Text = "子系统管理";
        }
        public frmModule(string xtdm)
        {
            InitializeComponent();
            this.Text = "子系统管理";
uCmSystemTree1.xtdm=xtdm;
        }

        private void frmModule_Load(object sender, EventArgs e)
        {

        }
    }
}