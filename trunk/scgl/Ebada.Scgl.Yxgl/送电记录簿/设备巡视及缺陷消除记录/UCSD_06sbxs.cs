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
    [ToolboxItem(false)]
    public partial class UCSD_06sbxs : DevExpress.XtraEditors.XtraUserControl
    {
        public UCSD_06sbxs()
        {
            InitializeComponent();
            ucTop.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<sdjl_06sbxs>(ucTop_FocusedRowChanged);
            splitContainerControl1.SplitterPosition = 500;
        }
        void ucTop_FocusedRowChanged(object sender, sdjl_06sbxs obj)
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
