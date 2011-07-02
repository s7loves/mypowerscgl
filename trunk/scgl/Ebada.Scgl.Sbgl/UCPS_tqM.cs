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
    public partial class UCPS_tqM : DevExpress.XtraEditors.XtraUserControl
    {
        public UCPS_tqM()
        {
            InitializeComponent();
            ucpS_TQ1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.PS_tq>(ucpS_TQ1_FocusedRowChanged);
        }

        void ucpS_TQ1_FocusedRowChanged(object sender, Ebada.Scgl.Model.PS_tq obj) {
            splitCC1.Panel2.Text = "台区名：" + (obj != null ? obj.tqName : "");
        }

    }
}
