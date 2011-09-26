using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Scgl.Model;
using GMap.NET;
using GMap.NET.WindowsForms;
using System.Drawing;
using Ebada.Scgl.Gis.Markers;
namespace Ebada.Scgl.Gis {
     class MapBuilder {
         static RectangleF box = new RectangleF( 126.98f-10,46.63f-5, 20, 10);
         static public List<PointLatLng> BuildLine(string LineCode) {
            IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>(string.Format("where Linecode='{0}'", LineCode));

            List<PointLatLng> points = new List<PointLatLng>();
            //GMapRoute route = new GMapRoute(points, LineCode);
             foreach(PS_gt gt in list){
                 PointF pf = new PointF((float)gt.gtLon, (float)gt.gtLat);
                 if (box.Contains(pf)) {
                     PointLatLng point = new PointLatLng(Convert.ToDouble(gt.gtLat), Convert.ToDouble(gt.gtLon));
                     points.Add(point);
                 }
             }

            return points;
        }
         /// <summary>
         /// 创建线路杆塔点标记
         /// </summary>
         /// <param name="LineCode"></param>
         /// <returns></returns>
         static public List<GMapMarker> BuildLineGT(string LineCode,string LineName) {
             IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>(string.Format("where Linecode='{0}' order by gtcode", LineCode));

             List<GMapMarker> markers = new List<GMapMarker>();
             //GMapRoute route = new GMapRoute(points, LineCode);
             GMapMarker marker = null;
             foreach (PS_gt gt in list) {
                 PointF pf = new PointF((float)gt.gtLon, (float)gt.gtLat);
                 if (box.Contains(pf)) {
                     PointLatLng point = new PointLatLng(Convert.ToDouble(gt.gtLat), Convert.ToDouble(gt.gtLon));
                     if (gt.gtType.Contains("方杆"))
                         marker = new GMapMarkerRect(point);
                     else
                         marker = new GMapMarkerVector(point);
                     marker.ToolTipText = gt.gth + "\n" + LineName;
                     marker.Tag = gt;
                     markers.Add(marker);
                 }
             }

             return markers;
         }
    }
}
