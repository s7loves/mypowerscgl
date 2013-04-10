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
    public partial class Ucm_sgzaycM : DevExpress.XtraEditors.XtraUserControl
    {
        Ucm_sgzayc ucsg;
        public Ucm_sgzaycM()
        {
            InitializeComponent();
            ucmOrg ucorg = new ucmOrg();
            ucorg.Dock = DockStyle.Fill;
            ucorg.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.mOrg>(ucorg_FocusedRowChanged);
            ucsg = new Ucm_sgzayc();
            ucsg.Dock = DockStyle.Fill;
            this.splitContainerControl1.Panel1.Controls.Add(ucorg);
            this.splitContainerControl1.Panel2.Controls.Add(ucsg);
        }

        void ucorg_FocusedRowChanged(object sender, Ebada.Scgl.Model.mOrg obj)
        {
            if (obj == null)
                return;
            this.ucsg.ParentID = obj.OrgCode;
        }
    }
}
