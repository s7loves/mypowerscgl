using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Gis.Device {
    public partial class frmQytj : DevExpress.XtraEditors.XtraForm {
        List<PS_gt> gtList;

        public frmQytj(List<PS_gt> gtlist) {
            InitializeComponent();
            gtList = gtlist;
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            StringBuilder sb = new StringBuilder();
            foreach (PS_gt gt in gtList) {
                sb.AppendLine(gt.gtCode);
            }
            memoEdit1.Text = sb.ToString();
        }
    }
}