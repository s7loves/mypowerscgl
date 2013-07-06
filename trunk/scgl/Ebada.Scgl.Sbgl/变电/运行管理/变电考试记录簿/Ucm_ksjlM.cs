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
    public partial class Ucm_ksjlM : DevExpress.XtraEditors.XtraUserControl
    {
        Ucm_ksjl ucmksjl;
        Ucm_ksnr ucmksnr;
        public Ucm_ksjlM()
        {
            InitializeComponent();
            ucmksjl = new Ucm_ksjl();
            ucmksjl.Dock = DockStyle.Fill;
            ucmksjl.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.bdjl_ksjl>(ucmksjl_FocusedRowChanged);
            ucmksnr = new Ucm_ksnr();
            ucmksnr.Dock = DockStyle.Fill;
            this.splitContainerControl1.Panel1.Controls.Clear();
            this.splitContainerControl1.Panel1.Controls.Add(ucmksjl);
            this.splitContainerControl1.Panel2.Controls.Clear();
            this.splitContainerControl1.Panel2.Controls.Add(ucmksnr);
        }

        void ucmksjl_FocusedRowChanged(object sender, Ebada.Scgl.Model.bdjl_ksjl obj)
        {
            if (obj == null)
                return;
            ucmksnr.ParentObj = obj;
        }

    }
}
