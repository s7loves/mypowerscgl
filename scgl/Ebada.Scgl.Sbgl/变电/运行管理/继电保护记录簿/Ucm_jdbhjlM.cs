using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Client.Platform;

using DevExpress.XtraGrid.Columns;
using System.Reflection;
using Ebada.Client;
using DevExpress.XtraGrid.Views.Base;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Sbgl
{
    public partial class Ucm_jdbhjlM : DevExpress.XtraEditors.XtraUserControl
    {
        public Ucm_jdbhjlM()
        {
            InitializeComponent();
            ucmOrg ucorg = new ucmOrg();
            ucorg.Dock = DockStyle.Fill;
            this.splitContainerControl1.Panel1.Controls.Add(ucorg);
            ucorg.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.mOrg>(ucorg_FocusedRowChanged);
        }

        void ucorg_FocusedRowChanged(object sender, Ebada.Scgl.Model.mOrg obj)
        {
            if (obj == null)
                return;
            this.ucm_jdbhjl1.ParentID = obj.OrgCode;
        }
    }
}
