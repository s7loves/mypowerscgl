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
    public partial class UCPS_kgM : DevExpress.XtraEditors.XtraUserControl
    {
        public UCPS_kgM()
        {
            InitializeComponent();
            ucpS_kg1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.PS_kg>(ucpS_kg1_FocusedRowChanged);
        }

        void ucpS_kg1_FocusedRowChanged(object sender, Ebada.Scgl.Model.PS_kg obj)
        {
            ucpJ_12kgbd1.PSObj = obj;
            ucpJ_12kgjx1.PSObj = obj;
            ucpJ_12kgsy1.PSObj = obj;
        }

       
    }
}
