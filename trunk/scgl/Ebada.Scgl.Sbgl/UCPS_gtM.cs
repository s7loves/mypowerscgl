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
            ucpS_TQ1.HideList();
            ucpS_KG1.HideList();
            ucpS_GTSB1.HideList();
            ucpS_GT1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.PS_gt>(ucpS_GT1_FocusedRowChanged);
        }

        void ucpS_GT1_FocusedRowChanged(object sender, Ebada.Scgl.Model.PS_gt obj) {
            if (obj!=null)
            {
                ucpS_TQ1.ParentID = obj.gtID;
                ucpS_TQ1.ParentObj = obj;
                ucpS_KG1.ParentID = obj.gtID;
                ucpS_KG1.ParentObj = obj;
                ucpS_GTSB1.ParentID = obj.gtID;
                ucpS_GTSB1.ParentObj = obj;
            }
            else
            {
                ucpS_TQ1.ParentID = null;
                ucpS_TQ1.ParentObj = null;
                ucpS_KG1.ParentID = null;
                ucpS_KG1.ParentObj = null;
                ucpS_GTSB1.ParentID = null;
                ucpS_GTSB1.ParentObj = null;
            }
           
            splitCC1.Panel2.Text = "杆塔编号：" + (obj != null ? obj.gtCode : "");
        }
    }
}
