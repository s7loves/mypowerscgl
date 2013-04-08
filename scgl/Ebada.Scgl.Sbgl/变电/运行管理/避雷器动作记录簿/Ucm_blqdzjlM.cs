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
    public partial class Ucm_blqdzjlM : DevExpress.XtraEditors.XtraUserControl
    {
        Ucm_blqdzjl ucblq;
        public Ucm_blqdzjlM()
        {
            InitializeComponent();
            ucmOrg ucOrg = new ucmOrg();
            ucOrg.Dock = DockStyle.Fill;
            this.splitContainerControl1.Panel1.Controls.Add(ucOrg);
            ucblq = new Ucm_blqdzjl();
            ucblq.Dock = DockStyle.Fill;
            this.splitContainerControl1.Panel2.Controls.Add(ucblq);
            ucOrg.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.mOrg>(ucOrg_FocusedRowChanged);
        }

        void ucOrg_FocusedRowChanged(object sender, Ebada.Scgl.Model.mOrg obj)
        {
            if (obj == null)
                return;
            ucblq.ParentID = obj.OrgCode;
        }
    }
}
