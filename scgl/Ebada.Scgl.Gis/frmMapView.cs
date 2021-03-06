﻿/**********************************************
系统:地理信息
模块:
作者:Rabbit
创建时间:2011-9-4
最后一次修改:2011-9-4
***********************************************/
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
            ucMapBox1.documentControl1.OnTipEvent += new TLVector.Core.Interface.OnTipEventHandler(documentControl1_OnTipEvent);
        }

        void documentControl1_OnTipEvent(object sender, string tooltip, byte TipType) {
            if (TipType == 2) 
            barStaticItem1.Caption = tooltip+"["+TipType+"]";
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
