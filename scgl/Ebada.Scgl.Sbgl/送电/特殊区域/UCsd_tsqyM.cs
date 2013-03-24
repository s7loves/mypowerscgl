using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ebada.Client.Platform;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Sbgl
{
    [ToolboxItem(false)]
    public partial class UCsd_tsqyM : DevExpress.XtraEditors.XtraUserControl
    {
        UCsdxlTree sdxlTree;
        private string tsqyZL;
        public UCsd_tsqyM()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            init();
        }
        private void init() {
            UCsd_tsqy.HideList();
            sdxlTree = new UCsdxlTree();
            sdxlTree.LineSelectionChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.sd_xl>(xltree_FocusedRowChanged);
            UCsd_tsqy.ParentType = Client.ClientHelper.PlatformSqlMap.GetOne<sd_tsqyzl>("where zldm='" + tsqyZL + "'");
            sdxlTree.Dock = DockStyle.Fill;
            sdxlTree.Parent = splitContainerControl2.Panel1;
        }
        public Control Show(string i)
        {
            tsqyZL = i;
            return this;
        }
        void xltree_FocusedRowChanged(object sender, Ebada.Scgl.Model.sd_xl obj)
        {
            UCsd_tsqy.ParentObj =pobj= obj;
            setCaption();
        }
        sd_tsqyzl ptype = null;
        sd_xl pobj = null;
        void setCaption(){
            splitContainerControl1.Panel2.Text = string.Format("线路-{0}-{1}", pobj != null ? pobj.LineName : "", ptype != null ? ptype.zlmc : "");
        }
        void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e) {
            
        }

        private void UCsd_tsqyM_Load(object sender, EventArgs e)
        {
        } 
    }
}
