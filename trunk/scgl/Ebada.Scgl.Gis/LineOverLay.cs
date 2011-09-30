using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using GMap.NET;
using Ebada.Scgl.Model;
using Ebada.Scgl.Sbgl;
namespace Ebada.Scgl.Gis {
    public class LineOverlay :GMapOverlay{

        private GMapControl control;
        private GMapRoute mRoute;
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
            List<GMapMarker> list = MapBuilder.BuildLineGT(lineCode,lineName);
            foreach(GMapMarker item in list){
                lay.Markers.Add(item);
                points.Add(item.Position);
            }
            GMapRoute route = new GMapRoute(points, lineCode);
            lay.mRoute = route;
            if (list.Count > 1)
                list[0].ToolTipText += "\n" + route.Distance;
            lay.Routes.Add(route);
            return lay;
        }
        public void OnMarkerChanged(GMapMarker marker) {
            this.Routes[0].Points[this.Markers.IndexOf(marker)] = marker.Position;
            control.UpdateRouteLocalPosition(mRoute);

        }
        public void Update(GMapMarker marker) {
            PS_gt gt = marker.Tag as PS_gt;
            gt.gtLat = (decimal)marker.Position.Lat;
            gt.gtLon = (decimal)marker.Position.Lng;
            Client.ClientHelper.PlatformSqlMap.Update<PS_gt>(gt);
        }

        internal void ShowDialog(GMapMarker marker,bool canEdit) { 

            frmgtEdit frm = new frmgtEdit();
            frm.RowData = marker.Tag;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK && canEdit) {
                marker.Tag = frm.RowData;
                PS_gt gt =marker.Tag as PS_gt;
                Client.ClientHelper.PlatformSqlMap.Update<PS_gt>(marker.Tag);
                marker.Position = new PointLatLng((double)gt.gtLat, (double)gt.gtLon);
                OnMarkerChanged(marker);
                //control.UpdateMarkerLocalPosition(marker);
            }
        }
    }
}
