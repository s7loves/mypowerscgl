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
    public partial class Ucm_sbjxjlM : DevExpress.XtraEditors.XtraUserControl
    {
        public Ucm_sbjxjlM()
        {
            InitializeComponent();
            ucmOrg ucOrg = new ucmOrg();
            ucOrg.Dock = DockStyle.Fill;
            this.splitContainerControl1.Panel1.Controls.Add(ucOrg);
            ucOrg.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.mOrg>(ucOrg_FocusedRowChanged);
        }

        void ucOrg_FocusedRowChanged(object sender, Ebada.Scgl.Model.mOrg obj)
        {
            if (obj == null)
                return;
            this.ucm_sbjxjl1.ParentID = obj.OrgCode;
        }
    }
}
