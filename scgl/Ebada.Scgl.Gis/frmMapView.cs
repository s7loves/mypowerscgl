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
        IMapView mapview;
        public frmMapView() {
            InitializeComponent();
            mapview = ucMapBox1;
        }
        public void FullScrean() {
            FormState formState = new FormState();
            this.SetVisibleCore(false);
            formState.Maximize(this);
            this.SetVisibleCore(true);
            btFullScrean.Caption = "退出全屏";
        }
        #region 工具栏事件
        private void btFullScrean_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (btFullScrean.Caption == "退出全屏") {
                this.Close();
            } else {
                frmMapView dlg = new frmMapView();
                dlg.Show();
                dlg.FullScrean();
            }
        }
        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            switch (e.Item.Caption) {
                case "漫游":
                    mapview.Roam();
                    break;
                case "放大":
                    mapview.Zoomout();
                    break;
                case "缩小":
                    mapview.Zoomin();
                    break;
                case "测距":
                    mapview.Distance();
                    break;
                case "全景":
                    mapview.FullView();
                    break;
                case "飞行":
                    mapview.Fly();
                    break;                    
            }
        }
        #endregion

    }
}
