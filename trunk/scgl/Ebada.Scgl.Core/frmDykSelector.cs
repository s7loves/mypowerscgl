using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ebada.Scgl.Core {
    public partial class frmDykSelector : DevExpress.XtraEditors.XtraForm {
        public frmDykSelector() {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            if (this.Owner != null)
                this.StartPosition = FormStartPosition.CenterParent;
        }
    }
}