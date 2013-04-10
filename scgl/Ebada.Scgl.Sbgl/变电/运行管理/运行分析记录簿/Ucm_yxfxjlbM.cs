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
    public partial class Ucm_yxfxjlbM : DevExpress.XtraEditors.XtraUserControl
    {
        Ucm_yxfxjlb ucyxfx;
        public Ucm_yxfxjlbM()
        {
            InitializeComponent();
            ucmOrg ucOrg = new ucmOrg();
            ucOrg.Dock = DockStyle.Fill;
            ucOrg.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.mOrg>(ucOrg_FocusedRowChanged);
            ucyxfx = new Ucm_yxfxjlb();
            ucyxfx.Dock = DockStyle.Fill;
            this.splitContainerControl1.Panel1.Controls.Add(ucOrg);
            this.splitContainerControl1.Panel2.Controls.Add(ucyxfx);
        }

        void ucOrg_FocusedRowChanged(object sender, Ebada.Scgl.Model.mOrg obj)
        {
            if (obj == null)
                return;
            this.ucyxfx.ParentID = obj.OrgCode;
        }
    }
}
