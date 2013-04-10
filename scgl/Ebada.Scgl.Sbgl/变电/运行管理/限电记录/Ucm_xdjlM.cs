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
    public partial class Ucm_xdjlM : DevExpress.XtraEditors.XtraUserControl
    {
        Ucm_xdjl uc_xdjl;
        public Ucm_xdjlM()
        {
            InitializeComponent();
            ucmOrg ucOrg = new ucmOrg();
            ucOrg.Dock = DockStyle.Fill;
            uc_xdjl = new Ucm_xdjl();
            uc_xdjl.Dock = DockStyle.Fill;
            ucOrg.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.mOrg>(ucOrg_FocusedRowChanged);
            this.splitContainerControl1.Panel1.Controls.Add(ucOrg);
            this.splitContainerControl1.Panel2.Controls.Add(uc_xdjl);
        }

        void ucOrg_FocusedRowChanged(object sender, Ebada.Scgl.Model.mOrg obj)
        {
            if (obj == null)
                return;
            uc_xdjl.ParentID = obj.OrgCode;
        }
    }
}
