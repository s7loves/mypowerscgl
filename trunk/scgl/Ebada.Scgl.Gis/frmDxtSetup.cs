using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ebada.UI.Base;

namespace Ebada.Scgl.Gis {
    public partial class frmDxtSetup : FormBase {
        public frmDxtSetup() {
            InitializeComponent();
            spinEdit1.Value = DrawingDxt2.mWidth;
            spinEdit2.Value = DrawingDxt2.mHeight;
            spinEdit3.Value = DrawingDxt2.mMinDJ;
            checkEdit1.Checked = DrawingDxt2.isHrow;
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            DrawingDxt2.mWidth = (int)spinEdit1.Value;
            DrawingDxt2.mHeight = (int)spinEdit2.Value;
            DrawingDxt2.mMinDJ = (int)spinEdit3.Value;
            DrawingDxt2.isHrow = checkEdit1.Checked;
            DialogResult = DialogResult.OK;
        }
    }
}
