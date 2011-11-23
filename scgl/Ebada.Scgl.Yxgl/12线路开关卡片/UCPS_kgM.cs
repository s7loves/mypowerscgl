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
            ucpS_kg1.SelectGdsChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.mOrg>(ucpS_kg1_SelectGdsChanged);
            ucpJ_12kgbd1.HideList();
            ucpJ_12kgjx1.HideList();
            ucpJ_12kgsy1.HideList();
        }

        void ucpS_kg1_SelectGdsChanged(object sender, Ebada.Scgl.Model.mOrg obj) {
            ucpJ_12kgbd1.ParentObj = obj;
            ucpJ_12kgjx1.ParentObj = obj;
            ucpJ_12kgsy1.ParentObj = obj;
        }

        void ucpS_kg1_FocusedRowChanged(object sender, Ebada.Scgl.Model.PS_kg obj)
        {
            ucpJ_12kgbd1.PSObj = obj;
            ucpJ_12kgjx1.PSObj = obj;
            ucpJ_12kgsy1.PSObj = obj;
        }

       
    }
}
