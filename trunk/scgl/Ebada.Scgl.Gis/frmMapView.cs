using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ebada.Scgl.Gis {
    public partial class frmMapView : XtraForm {
        public frmMapView() {
            InitializeComponent();
        }
        public void FullScrean() {
            FormState formState = new FormState();
            this.SetVisibleCore(false);
            formState.Maximize(this);
            this.SetVisibleCore(true);
        }
        #region 工具栏事件
        private void btFullScrean_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (btFullScrean.Caption == "退出全屏") {
                this.Close();
            } else {
                frmMapView dlg = new frmMapView();
                dlg.Show();
                dlg.FullScrean();
                btFullScrean.Caption = "退出全屏";
            }
        }
        #endregion
    }
}
