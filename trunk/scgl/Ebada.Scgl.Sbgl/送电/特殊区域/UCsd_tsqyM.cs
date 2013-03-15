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
        Dictionary<string, string> dictsqyZl = new Dictionary<string, string>();
        public UCsd_tsqyM()
        {
            InitializeComponent();
            //ucpS_GTSB1.HideList();
            dictsqyZl.Add("1", "01");
            dictsqyZl.Add("2", "02");
            dictsqyZl.Add("3", "03");
            dictsqyZl.Add("4", "04");
            dictsqyZl.Add("5", "05");
            dictsqyZl.Add("6", "06");
            dictsqyZl.Add("7", "07");
            

        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            init();
        }
        private void init() {
            UCsd_tsqy.HideList();
           
            
            sdxlTree = new UCsdxlTree();
            sdxlTree.Dock = DockStyle.Fill;
            sdxlTree.Parent = splitContainerControl2.Panel1;
            sdxlTree.LineSelectionChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.sd_xl>(xltree_FocusedRowChanged);
            UCsd_tsqy.ParentType = Client.ClientHelper.PlatformSqlMap.GetOne<sd_tsqyzl>("where zldm='" + tsqyZL + "'");

        }
        public Control Show(string i)
        {
            if (dictsqyZl.ContainsKey(i))
            {
                tsqyZL = dictsqyZl[i];
            }
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
