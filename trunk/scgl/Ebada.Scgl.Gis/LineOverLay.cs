using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using GMap.NET;
using Ebada.Scgl.Model;
using Ebada.Scgl.Sbgl;
using System.Data;
using Ebada.Scgl.Gis.Markers;
namespace Ebada.Scgl.Gis {
    public class LineOverlay :GMapOverlay{

        private GMapControl control;
        public LineOverlay(GMapControl map, string lineCode)
            : base(map, lineCode) {
            
            control = map;
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
        public void OnMarkerChanged(GMapMarkerVector marker) {
            marker.Route.UpdateRoutePostion(marker);
            control.UpdateRouteLocalPosition(marker.Route);

        }
        protected override void DrawRoutes(System.Drawing.Graphics g) {
            base.DrawRoutes(g);
        }
        public override void Render(System.Drawing.Graphics g) {
            bool flag=control.MarkersEnabled;
            if (control.Zoom < 15)
                control.MarkersEnabled = false;
            base.Render(g);
            control.MarkersEnabled = flag;
        }
        public void Update(GMapMarker marker) {
            PS_gt gt = marker.Tag as PS_gt;
            gt.gtLat = (decimal)marker.Position.Lat;
            gt.gtLon = (decimal)marker.Position.Lng;
            Client.ClientHelper.PlatformSqlMap.Update<PS_gt>(gt);
        }

        public void ShowDialog(GMapMarker marker, bool canEdit) { 

            frmgtEdit frm = new frmgtEdit();
            frm.RowData = marker.Tag;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK && canEdit) {
                marker.Tag = frm.RowData;
                PS_gt gt =marker.Tag as PS_gt;
                Client.ClientHelper.PlatformSqlMap.Update<PS_gt>(marker.Tag);
                marker.Position = new PointLatLng((double)gt.gtLat, (double)gt.gtLon);
                OnMarkerChanged(marker as GMapMarkerVector);
                //control.UpdateMarkerLocalPosition(marker);
            }
        }

        public void ShowLineinfo(GMapMarker selectedMarker, bool canEditMarker) {
            PS_gt gt = selectedMarker.Tag as PS_gt;
            string linecode=gt.gtCode.Substring(0, gt.gtCode.Length - 4);
            PS_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>("where linecode='" + linecode + "'");
            if (xl != null) {
                frmxlEdit dlg = new frmxlEdit();
                dlg.RowData = xl;
                dlg.ShowDialog();
            }

        }
    }
}
