using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ebada.Scgl.Sbgl
{
    public partial class UCPS_gtM : DevExpress.XtraEditors.XtraUserControl
    {
        public UCPS_gtM()
        {
            InitializeComponent();
            ucpS_GT1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.PS_gt>(ucpS_GT1_FocusedRowChanged);
        }

        void ucpS_GT1_FocusedRowChanged(object sender, Ebada.Scgl.Model.PS_gt obj) {
            splitCC1.Panel2.Text = "杆塔编号：" + (obj != null ? obj.gtCode : "");
        }
    }
}
