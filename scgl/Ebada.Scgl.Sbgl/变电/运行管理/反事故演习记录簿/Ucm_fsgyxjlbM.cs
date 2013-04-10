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
    public partial class Ucm_fsgyxjlbM : DevExpress.XtraEditors.XtraUserControl
    {
        public Ucm_fsgyxjlbM()
        {
            InitializeComponent();
            ucmOrg ucorg = new ucmOrg();
            ucorg.Dock = DockStyle.Fill;
            ucorg.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.mOrg>(ucorg_FocusedRowChanged);
            this.splitContainerControl1.Panel1.Controls.Add(ucorg);
        }

        void ucorg_FocusedRowChanged(object sender, Ebada.Scgl.Model.mOrg obj)
        {
            if (obj == null)
                return;
            this.ucm_fsgyxjlb1.ParentID = obj.OrgCode;
        }
    }
}
