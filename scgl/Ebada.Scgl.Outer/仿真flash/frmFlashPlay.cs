using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ebada.Scgl.Outer {
    public partial class frmFlashPlay : Form {
        public frmFlashPlay() {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            axShockwaveFlash1.Movie = AppDomain.CurrentDomain.BaseDirectory + "\\" + mfilename;
        }
        string mfilename = "仿真变电站.swf";
        public Control ShowFlash(string filename) {

            mfilename = filename;
            return this;
        }
    }
}
