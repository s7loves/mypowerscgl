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
    public partial class Ucm_kgtzjlM : DevExpress.XtraEditors.XtraUserControl
    {
        public Ucm_kgtzjlM()
        {
            InitializeComponent();
            ucmOrg ucm = new ucmOrg();
            ucm.Dock = DockStyle.Fill;
            this.splitContainerControl1.Panel1.Controls.Add(ucm);
            ucm.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.mOrg>(ucm_FocusedRowChanged);
        }

        void ucm_FocusedRowChanged(object sender, Ebada.Scgl.Model.mOrg obj)
        {
            if (obj == null)
                return;
            this.ucm_kgtzjl1.ParentID = obj.OrgCode;
        }
    }
}
