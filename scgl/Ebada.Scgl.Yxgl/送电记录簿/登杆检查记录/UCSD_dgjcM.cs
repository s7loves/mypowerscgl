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
    public partial class UCSD_dgjcM : DevExpress.XtraEditors.XtraUserControl
    {
        public UCSD_dgjcM()
        {
            InitializeComponent();
            this.ucsD_dgjc1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.sdjls_dgjcjl>(ucsD_dgjc1_FocusedRowChanged);
        }

        void ucsD_dgjc1_FocusedRowChanged(object sender, Ebada.Scgl.Model.sdjls_dgjcjl obj)
        {
            if (obj == null)
                return;
            this.ucsD_dgjcjl1.ParentObj = obj;
        }
    }
}
