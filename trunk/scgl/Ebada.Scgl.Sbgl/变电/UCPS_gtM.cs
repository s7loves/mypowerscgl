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
    public partial class UCBD_SBTZM : DevExpress.XtraEditors.XtraUserControl
    {
        public UCBD_SBTZM()
        {
            InitializeComponent();
            ucpS_GTSB1.HideList();
            xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(xtraTabControl1_SelectedPageChanged);
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            init();
        }
        private void init() {
            ucpS_GT1.HideList();
            
            xltree = new UCmOrgBds();
            if (MainHelper.UserOrg != null && MainHelper.UserOrg.OrgType == "2") {//如果是供电所人员，则锁定
                xltree.SetShowOrg(MainHelper.UserOrg);
            }
            xltree.Dock = DockStyle.Fill;
            xltree.Parent = splitContainerControl2.Panel1;
            xltree.HideList();
            UCBD_SBTZ_ZL zl = new UCBD_SBTZ_ZL();
            zl.HideList();
            zl.Dock = DockStyle.Fill;
            zl.Parent = splitContainerControl2.Panel2;
            zl.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.BD_SBTZ_ZL>(zl_FocusedRowChanged);
            xltree.FocusedRowChanged += new Ebada.Client.SendDataEventHandler<Ebada.Scgl.Model.mOrg>(xltree_FocusedRowChanged);
        }

        void zl_FocusedRowChanged(object sender, Ebada.Scgl.Model.BD_SBTZ_ZL obj) {
            ucpS_GT1.ParentType =ptype= obj;
        }

        void xltree_FocusedRowChanged(object sender, Ebada.Scgl.Model.mOrg obj) {
            ucpS_GT1.ParentObj =pobj= obj;
        }
        BD_SBTZ_ZL ptype = null;
        mOrg pobj = null;
        void setCaption(){
            splitContainerControl1.Panel2.Text = string.Format("设备列表-{0}-{1}", pobj != null ? pobj.OrgName : "", ptype != null ? ptype.mc : "");
        }
        UCmOrgBds xltree;
        Ebada.Scgl.Model.BD_SBTZ mgt;
        void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e) {
            
        }

        void ucpS_GT1_FocusedRowChanged(object sender, Ebada.Scgl.Model.BD_SBTZ obj) {
            
            if (obj!=null)
            {
                mgt = obj;
                //ucpS_GTSB1.ParentObj = obj;
            }
            else
            {
                mgt = null;
                ucpS_GTSB1.ParentObj = null;
            }
            //if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
            //    ucps_jcky.ParentObj = mgt;

            //splitCC1.Panel2.Text = "杆塔编号：" + (obj != null ? obj.gtCode : "");
        }
    }
}
