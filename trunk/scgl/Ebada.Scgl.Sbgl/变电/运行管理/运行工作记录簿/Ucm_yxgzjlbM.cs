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
    [ToolboxItem(false)]
    public partial class Ucm_yxgzjlbM : DevExpress.XtraEditors.XtraUserControl
    {
        Ucm_yxgzjlb yxgzjlb;
        Ucm_gzjlzb gzjlzb;
        public Ucm_yxgzjlbM()
        {
            InitializeComponent();
            ucmOrg ucorg = new ucmOrg();
            ucorg.Dock = DockStyle.Fill;
            ucorg.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.mOrg>(ucorg_FocusedRowChanged);
            yxgzjlb = new Ucm_yxgzjlb();
            yxgzjlb.Dock = DockStyle.Fill;
            yxgzjlb.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.bdjl_yxgzjlb>(yxgzjlb_FocusedRowChanged);
            gzjlzb = new Ucm_gzjlzb();
            gzjlzb.Dock = DockStyle.Fill;
            this.splitContainerControl1.Panel1.Controls.Add(ucorg);
            this.splitContainerControl2.Panel1.Controls.Add(yxgzjlb);
            this.splitContainerControl2.Panel2.Controls.Add(gzjlzb);
        }

        void yxgzjlb_FocusedRowChanged(object sender, Ebada.Scgl.Model.bdjl_yxgzjlb obj)
        {
            if (obj == null)
            {
                gzjlzb.ParentID = "";
            }
            else
            {
                this.gzjlzb.ParentID = obj.ID;
            }
        }

        void ucorg_FocusedRowChanged(object sender, Ebada.Scgl.Model.mOrg obj)
        {
            if (obj == null)
                return;
            this.yxgzjlb.ParentID = obj.OrgCode;
        }
    }
}
