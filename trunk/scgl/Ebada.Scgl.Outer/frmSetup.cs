using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.UI.Base;

namespace Ebada.Scgl.Outer {
    public partial class frmSetup : FormBase {
        public frmSetup() {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            textEdit1.Text = DBATLLibHelper.dbServer;
            spinEdit1.Value = DBATLLibHelper.dbAreaNo;
            spinEdit2.Value = DBATLLibHelper.dbKgNo;
        }
        private void simpleButton1_Click(object sender, EventArgs e) {
            DBATLLibHelper.dbServer = textEdit1.Text;
            DBATLLibHelper.dbAreaNo = (int)spinEdit1.Value;
            DBATLLibHelper.dbKgNo = (int)spinEdit2.Value;

        }
    }
}
