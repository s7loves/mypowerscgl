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
            xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(xtraTabControl1_SelectedPageChanged);
        }
        UCPS_jcky ucps_jcky;
        Ebada.Scgl.Model.PS_gt mgt;
        void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e) {
            if (e.Page == xtraTabPage4) {
                if (ucps_jcky == null) {
                    ucps_jcky = new UCPS_jcky();
                    ucps_jcky.Dock = DockStyle.Fill;
                    xtraTabPage4.Controls.Add(ucps_jcky);
                    ucps_jcky.HideList();
                }
                ucps_jcky.ParentObj = mgt;
            }
        }

        void ucpS_GT1_FocusedRowChanged(object sender, Ebada.Scgl.Model.PS_gt obj) {
            
            if (obj!=null)
            {
                mgt = obj;
                ucpS_TQ1.ParentObj = obj;
                ucpS_KG1.ParentObj = obj;
                ucpS_GTSB1.ParentObj = obj;
            }
            else
            {
                mgt = null;
                ucpS_TQ1.ParentObj = null;
                ucpS_KG1.ParentObj = null;
                ucpS_GTSB1.ParentObj = null;
            }
            if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
                ucps_jcky.ParentObj = mgt;

            splitCC1.Panel2.Text = "杆塔编号：" + (obj != null ? obj.gtCode : "");
        }
    }
}
