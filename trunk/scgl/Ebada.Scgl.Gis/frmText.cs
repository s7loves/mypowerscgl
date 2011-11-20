using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ebada.Scgl.Gis {
    public partial class frmText : XtraForm {
        public frmText() {
            InitializeComponent();
            simpleButton1.Click += new EventHandler(simpleButton1_Click);
            simpleButton2.Click += new EventHandler(simpleButton2_Click);
            
        }

        void simpleButton2_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

        void simpleButton1_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }
        public string MarkerText {
            get { return memoEdit1.Text; }
            set { memoEdit1.Text = value; }
        }
    }
}
