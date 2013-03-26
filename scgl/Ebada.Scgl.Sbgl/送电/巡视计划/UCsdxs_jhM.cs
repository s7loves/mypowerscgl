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
        private string state;
        public Control Show(string parastate)
        {
            this.state = parastate;
            uCsdxs_jh1.CheckState = state;
            if (parastate == "03")
            {
                xtraTabControl1.TabPages.RemoveAt(1);
                uCsdxs_jh1.isSearch = true;
                uCsdxs_jhnr1.issearch = true;
                uCsdxs_jhnr1.isqx = true;
            }
            return this;
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
