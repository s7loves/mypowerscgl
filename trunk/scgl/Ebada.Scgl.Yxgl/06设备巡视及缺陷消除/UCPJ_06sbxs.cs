using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Yxgl
{
    public partial class UCPJ_06sbxs: DevExpress.XtraEditors.XtraUserControl
    {
        public UCPJ_06sbxs()
        {
            InitializeComponent();
            ucTop.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<PJ_06sbxs>(ucTop_FocusedRowChanged);
        }
        void ucTop_FocusedRowChanged(object sender, PJ_06sbxs obj)
        {
            ucBottom.ParentObj = obj;
            //splitCC1.Panel2.Text = "测量记录：" + (obj != null ? obj.kymc : "");
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ucTop.initcomment();
        }
    }
}
