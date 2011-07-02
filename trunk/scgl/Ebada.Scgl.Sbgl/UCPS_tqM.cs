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
            ucpS_TQBYQ1.HideList();
            ucpS_TQDLBH1.HideList();
            ucpS_TQSB1.HideList();
            ucpS_TQ1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.PS_tq>(ucpS_TQ1_FocusedRowChanged);
        }

        void ucpS_TQ1_FocusedRowChanged(object sender, Ebada.Scgl.Model.PS_tq obj) {
            if (obj != null)
            {
                ucpS_TQBYQ1.ParentID = obj.tqID;
                ucpS_TQBYQ1.ParentObj = obj;
                ucpS_TQDLBH1.ParentID = obj.tqID;
                ucpS_TQDLBH1.ParentObj = obj;
                ucpS_TQSB1.ParentID = obj.tqID;
                ucpS_TQSB1.ParentObj = obj;
            }
            else
            {
                ucpS_TQBYQ1.ParentID = null;
                ucpS_TQBYQ1.ParentObj = null;
                ucpS_TQDLBH1.ParentID = null;
                ucpS_TQDLBH1.ParentObj = null;
                ucpS_TQSB1.ParentID = null;
                ucpS_TQSB1.ParentObj = null;
            }
            splitCC1.Panel2.Text = "台区名：" + (obj != null ? obj.tqName : "");
        }

    }
}
