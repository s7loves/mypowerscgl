using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Drawing;
using GMap.NET;
using Ebada.Scgl.Gis.Properties;
using System.Windows.Forms;
using Ebada.Scgl.Model;
using Ebada.Client;
using System.Collections;

namespace Ebada.Scgl.Gis.Markers {
    [Serializable]
    internal class GMapMarkerGzbx : GMapMarkerImage {
        public GMapMarkerGzbx(PointLatLng p)
            : base(p) {
            Image = Resources.marker;
            ImageShadow = Resources.shadow50;
            Size = SizeSt = new Size(Image.Width, Image.Height);
            Offset = new Point(-10, -34);
        }
        public override System.Windows.Forms.ContextMenu CreatePopuMenu() {
            ContextMenu menu = new ContextMenu();
            MenuItem item = new MenuItem("属性");
            item.Click += new EventHandler(item_属性);
            menu.MenuItems.Add(item);
            if (ToolTipMode == MarkerTooltipMode.Always) {
                item = new MenuItem("隐藏信息");
                item.Click += new EventHandler(item_隐藏信息);
            } else {
                item = new MenuItem("显示信息");
                item.Click += new EventHandler(item_显示信息);
            }
            
            menu.MenuItems.Add(item);
            item = new MenuItem("消除固障");
            item.Click += new EventHandler(item_Click);
            menu.MenuItems.Add(item);
            return menu;
        }

        void item_Click(object sender, EventArgs e) {

            if (MsgBox.ShowAskMessageBox("请确认是否消除故障.") == DialogResult.OK) {
                this.Overlay.Markers.Remove(this);
                PJ_21gzbxdh obj = Tag as PJ_21gzbxdh;
                obj.xcbj = "已消除";
                string sql = string.Format("update PJ_21gzbxdh set xcbj='{0}' where id='{1}'", obj.xcbj, obj.ID);
                Client.ClientHelper.PlatformSqlMap.Update("Update", sql);
            }
        }

        void item_隐藏信息(object sender, EventArgs e) {
            this.ToolTipMode = MarkerTooltipMode.OnMouseOver;
        }
        void item_显示信息(object sender, EventArgs e) {
            this.ToolTipMode = MarkerTooltipMode.Always;
        }
        public override void RefreshToolText() {
            PJ_21gzbxdh obj = Tag as PJ_21gzbxdh;
            this.ToolTipText = string.Format("登记日期:{0}\n地址:{1}\n固障简况:{4}\n联系方式:{2}\n供电所:{3}", obj.rq.ToString(), obj.yhdz, obj.lxfs, obj.OrgName,obj.gzjk);
            this.ToolTip.Format.Alignment = StringAlignment.Near;
 
        }
        void item_属性(object sender, EventArgs e) {

            frm21gzbxdhEdit dlg = new frm21gzbxdhEdit();
            dlg.OnBeginLocation += new ObjectEventHandler<PJ_21gzbxdh>(dlg_OnBeginLocation);
            dlg.RowData = Tag as PJ_21gzbxdh;
            if (dlg.ShowDialog() == DialogResult.OK) {
                Tag = dlg.RowData;
                Client.ClientHelper.PlatformSqlMap.Update<PJ_21gzbxdh>(dlg.RowData);
                RefreshToolText();
            }
        }

        void dlg_OnBeginLocation(PJ_21gzbxdh obj) {
            PointOverLay lay = this.Overlay as PointOverLay;
            if (lay != null) {
                frmMapCar95 frm = lay.MapControl.FindForm() as frmMapCar95;
                if (frm != null) {
                    frm.OnBeginLocation(obj);
                }
            }
        }
        public override void Update() {
            PointOverLay lay = this.Overlay as PointOverLay;
            if (lay != null && lay.AllowEdit) {
                PJ_21gzbxdh org = this.Tag as PJ_21gzbxdh;
                org.wd = this.Position.Lat;
                org.jd = this.Position.Lng;
                Client.ClientHelper.PlatformSqlMap.Update<PJ_21gzbxdh>(org);
            }
        }
    }
}
