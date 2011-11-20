using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using GMap.NET;
using Ebada.Scgl.Model;
using Ebada.Scgl.Sbgl;
using System.Data;
using Ebada.Scgl.Gis.Markers;
using System.Windows.Forms;
namespace Ebada.Scgl.Gis {
    public class LineOverlay : GMapOverlay, IUpdateable,IDisposable,IPopuMenu {

        private GMapControl control;
        private bool allowEdit;
        ContextMenu contextMenu;
        GMapMarker selectedMarker;
        public bool AllowEdit {
            get { return allowEdit; }
            set { allowEdit = value; }
        }
        public LineOverlay(GMapControl map, string lineCode)
            : base(map, lineCode) {
            map.OnMarkerEnter += new MarkerEnter(map_OnMarkerEnter);
            map.OnMarkerLeave += new MarkerLeave(map_OnMarkerLeave);
            control = map;
        }
        
        void map_OnMarkerLeave(GMapMarker item) {
            if (item.Overlay == this)
                selectedMarker = null;
        }

        void map_OnMarkerEnter(GMapMarker item) {

            if (item.Overlay == this)
                selectedMarker = item;
        }
        /// <summary>
        /// 创建线路层
        /// </summary>
        /// <param name="map"></param>
        /// <param name="lineCode"></param>
        /// <returns></returns>
        public static LineOverlay CreateLine(GMapControl map, string lineCode,string lineName){
            LineOverlay lay = new LineOverlay(map, lineCode);
            List<PointLatLng> points=new List<PointLatLng>();
            MapBuilder.Build10kVLines(ref lay, lineCode);
            return lay;
        }
        public static LineOverlay CreateLine(GMapControl map, PS_xl xl){

            LineOverlay lay = CreateLine(map, xl.LineCode, xl.LineName);
            GMapRoute route = lay.Routes[0];
            if (route.Points.Count > 0)
                CreateLineSub(route, null);
            return lay;
        }
        private static void CreateLineSub(GMapRoute r,DataRow[] rows){
             

        }
        public static LineOverlay CreateTQLine(GMapControl map, string tqCode, string tqName) {
            LineOverlay lay = new LineOverlay(map, tqCode);

            MapBuilder.BuildTQLines(ref lay,tqCode, tqName);

            return lay;
        }
        public void OnMarkerChanged(GMapMarker marker) {
            GMapMarkerVector markerv = marker as GMapMarkerVector;
            if (markerv.Route != null) {
                markerv.Route.UpdateRoutePostion(markerv);
                control.UpdateRouteLocalPosition(markerv.Route);
            }
        }
        protected override void DrawRoutes(System.Drawing.Graphics g) {
            base.DrawRoutes(g);
        }
        public override void Render(System.Drawing.Graphics g) {
            bool flag=control.MarkersEnabled;
            if (control.Zoom < 14)
                control.MarkersEnabled = false;
            base.Render(g);
            control.MarkersEnabled = flag;
        }
        public void Update(GMapMarker marker) {
            PS_gt gt = marker.Tag as PS_gt;
            gt.gtLat = (decimal)marker.Position.Lat;
            gt.gtLon = (decimal)marker.Position.Lng;
            Client.ClientHelper.PlatformSqlMap.Update("UpdatePS_gtLatLng", gt);
        }
        public virtual ContextMenu CreatePopuMenu() {
            if (contextMenu == null) {
                contextMenu = new ContextMenu();
                MenuItem item = new MenuItem();
                item.Text = "杆塔属性";
                item.Click += new EventHandler(杆塔属性_Click);
                contextMenu.MenuItems.Add(item);
                item = new MenuItem();
                item.Text = "线路属性";
                item.Click += new EventHandler(线路属性_Click);
                contextMenu.MenuItems.Add(item);

            }
            return contextMenu;

        }

        void 线路属性_Click(object sender, EventArgs e) {
            if (selectedMarker != null) {
                this.ShowLineinfo(selectedMarker, allowEdit);
            }
        }

        void 杆塔属性_Click(object sender, EventArgs e) {

            if (selectedMarker != null ) {
                this.ShowDialog(selectedMarker, allowEdit);
            }

        }
        public void ShowDialog(GMapMarker marker, bool canEdit) { 
            
            frmgtEdit frm = new frmgtEdit();            
            PS_gt gt0 = marker.Tag as PS_gt;
            GMapMarkerVector pm = (marker as GMapMarkerVector).ParentMarker;
            if (pm != null) {
                gt0.gtSpan = (decimal)Math.Round(control.Manager.GetDistance(pm.Position, marker.Position)*1000, 1);
            }
            PS_gt gt2 = new PS_gt();
            Ebada.Core.ConvertHelper.CopyTo(gt0, gt2);
            frm.RowData =  gt2;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK && allowEdit) {
                Ebada.Core.ConvertHelper.CopyTo(gt2, gt0);
                PS_gt gt =marker.Tag as PS_gt;
                Client.ClientHelper.PlatformSqlMap.Update<PS_gt>(marker.Tag);
                marker.Position = new PointLatLng((double)gt.gtLat, (double)gt.gtLon);
                OnMarkerChanged(marker as GMapMarkerVector);
            }
        }

        public void ShowLineinfo(GMapMarker selectedMarker, bool canEditMarker) {
            PS_gt gt = selectedMarker.Tag as PS_gt;
            string linecode=gt.gtCode.Substring(0, gt.gtCode.Length - 4);
            PS_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>("where linecode='" + linecode + "'");
            if (xl != null) {
                frmxlEdit dlg = new frmxlEdit();
                dlg.RowData = xl;
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK && allowEdit) {
                    Client.ClientHelper.PlatformSqlMap.Update<PS_xl>(dlg.RowData);
                }
            }

        }

        #region IDisposable 成员

        public void Dispose() {
            control.OnMarkerEnter -= map_OnMarkerEnter;
            control.OnMarkerLeave -= map_OnMarkerLeave;            
        }

        #endregion
    }
}
