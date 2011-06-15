using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ebada.Scgl.Yxgl
{
    public partial class UCPS_byqM : DevExpress.XtraEditors.XtraUserControl
    {
        public UCPS_byqM()
        {
            InitializeComponent();
            ucpS_tqbyq1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.PS_tqbyq>(ucpS_tqbyq1_FocusedRowChanged);
        }

        void ucpS_tqbyq1_FocusedRowChanged(object sender, Ebada.Scgl.Model.PS_tqbyq obj)
        {
            ucpJ_11byqbd1.PSObj = obj;
            ucpJ_11byqdy1.PSObj = obj;
            ucpJ_11byqdzcl1.PSObj = obj;
        }
    }
}
