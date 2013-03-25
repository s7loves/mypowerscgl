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
    public partial class UCsdxs_jhM : DevExpress.XtraEditors.XtraUserControl
    {
        public UCsdxs_jhM()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Init();
            
        }

        private void Init()
        {
            uCsdxs_jh1.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.sd_xsjh>(uCsdxs_jh1_FocusedRowChanged);
            
        }

        void uCsdxs_jh1_FocusedRowChanged(object sender, Ebada.Scgl.Model.sd_xsjh obj)
        {
            if (obj == null)
                return;
            uCsdxs_jhnr1.ParentObj = obj;
            uCsd_xsxm1.ParentObj = obj;
        }
    }
}
