using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ebada.Scgl.Yxgl
{
    [ToolboxItem(false)]
    public partial class UCSD_ddxljqM : DevExpress.XtraEditors.XtraUserControl
    {
        public UCSD_ddxljqM()
        {
            InitializeComponent();
            this.ucsD_ddxljq1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.sdjls_ddxljq>(ucsD_ddxljq1_FocusedRowChanged);
        }

        void ucsD_ddxljq1_FocusedRowChanged(object sender, Ebada.Scgl.Model.sdjls_ddxljq obj)
        {
            if (obj == null)
                return;
            this.ucsD_ddxljqnr1.ParentObj = obj;
        }

        
    }
}
