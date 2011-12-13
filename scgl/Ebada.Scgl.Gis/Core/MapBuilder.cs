/**********************************************
系统:地理信息
模块:
作者:Rabbit
创建时间:2011-9-20
最后一次修改:2011-9-30
***********************************************/
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
            IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>(string.Format("where Linecode='{0}' order by gtcode", LineCode));

            List<PointLatLng> points = new List<PointLatLng>();
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
         static public List<GMapMarkerVector> BuildLineGT(string LineCode, string LineName) {
             IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>(string.Format("where Linecode='{0}' order by gtcode", LineCode));

             List<GMapMarkerVector> markers = new List<GMapMarkerVector>();
             GMapMarkerVector marker = null;
             GMapMarkerVector preMarker = null;
             foreach (PS_gt gt in list) {
                 PointF pf = new PointF((float)gt.gtLon, (float)gt.gtLat);
                 if (box.Contains(pf)) {
                     PointLatLng point = new PointLatLng(Convert.ToDouble(gt.gtLat), Convert.ToDouble(gt.gtLon));
                     if (gt.gtType.Contains("方杆")) 
                         marker = new GMapMarkerRect(point);
                     else
                         marker = new GMapMarkerVector(point);
                     if (preMarker != null) {
                         marker.ParentMarker = preMarker;
                         preMarker.NextMarker = marker;
                     }
                     preMarker = marker;
                     marker.ToolTipText = gt.gth + "\n" + LineName;
                     marker.Tag = gt;

                     markers.Add(marker);
                 }
             }

             return markers;
         }
         internal static void BuildTQLines(ref LineOverlay layer, string tqcode, string tqname) {
             IList<PS_xl> xllist=Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>(string.Format("where left(Linecode,{0})='{1}' and LineVol = '0.4'",tqcode.Length,tqcode));
             
             string linecode = "";

             foreach (PS_xl line in xllist) {
                 linecode = line.LineCode;
                 IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>(string.Format("where Linecode='{0}' order by gtcode", linecode));


                 GMapMarkerVector marker = null;
                 GMapMarkerVector preMarker = null;
                 List<PointLatLng> points = new List<PointLatLng>();
                 LineRoute route = new LineRoute(points, linecode);
                 int count = 0;
                 foreach (PS_gt gt in list) {
                     PointF pf = new PointF((float)gt.gtLon, (float)gt.gtLat);
                     if (count == 0) {
                         int.TryParse(gt.gth, out count);
                         count /= 10;
                     }
                     if (box.Contains(pf)) {
                         PointLatLng point = new PointLatLng(Convert.ToDouble(gt.gtLat), Convert.ToDouble(gt.gtLon));
                         route.Points.Add(point);
                         if (gt.gtType.Contains("方杆"))
                             marker = new GMapMarkerRect(point);
                         else
                             marker = new GMapMarkerVector(point);
                         if (preMarker != null) {
                             marker.ParentMarker = preMarker;
                             preMarker.NextMarker = marker;
                         }
                         
                         preMarker = marker;
                         marker.ToolTipText = gt.gth + "\n" + line.LineName;
                         marker.Text = count+"#";
                         marker.Tag = gt;
                         marker.Id = gt.gtID;
                         layer.Markers.Add(marker);
                         route.Markers.Add(marker);
                         marker.Route = route;
                     }
                     count++;
                 }
                 if (route.Points.Count > 0) {
                     
                     layer.Routes.Add(route);
                 }
             }
         }
         internal static void Build10kVLines(ref LineOverlay layer, string lineCode) {
             IList<PS_xl> xllist = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>(string.Format("where left(Linecode,{0})='{1}' and LineVol = '10'", lineCode.Length, lineCode));
             string linecode = "";
             foreach (PS_xl line in xllist) {
                 linecode = line.LineCode;
                 IList<PS_gt> list = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>(string.Format("where Linecode='{0}' order by gtcode", linecode));


                 GMapMarkerVector marker = null;
                 GMapMarkerVector preMarker = null;
                 List<PointLatLng> points = new List<PointLatLng>();
                 LineRoute route = new LineRoute(points, linecode);
                 //route.Stroke.Color = Color.Black;
                 if (linecode.Length == 6)
                     route.Stroke.Width = 4;
                 else
                     route.Stroke.Width = 2;
                 int count = 0;
                 foreach (PS_gt gt in list) {
                     PointF pf = new PointF((float)gt.gtLon, (float)gt.gtLat);
                     if (count == 0) {
                         int.TryParse(gt.gth, out count);
                         count /= 10;
                     }
                     
                     if (box.Contains(pf)) {
                         PointLatLng point = new PointLatLng(Convert.ToDouble(gt.gtLat), Convert.ToDouble(gt.gtLon));
                         route.Points.Add(point);
                         if (gt.gtType.Contains("方杆"))
                             marker = new GMapMarkerRect(point);
                         else
                             marker = new GMapMarkerVector(point);
                         if (preMarker != null) {
                             marker.ParentMarker = preMarker;
                             preMarker.NextMarker = marker;
                         }
                         
                         preMarker = marker;
                         marker.ToolTipText = gt.gth + "\n" + line.LineName;
                         marker.Tag = gt;
                         marker.Text = count+"#";
                         marker.Id = gt.gtID;
                         layer.Markers.Add(marker);
                         route.Markers.Add(marker);
                         marker.Route = route;
                     }
                     count++;
                 }
                 //变压器
                 if (linecode.Length > 6 && list.Count > 0) {
                     PS_gt gt = list[list.Count - 1];
                     PointF pf = new PointF((float)gt.gtLon, (float)gt.gtLat);
                     if (box.Contains(pf)) {
                         PointLatLng point = new PointLatLng(Convert.ToDouble(gt.gtLat), Convert.ToDouble(gt.gtLon));
                         marker = new GMapMarkerBYQ(point);
                         //marker.IsHitTestVisible = false;
                         layer.Markers.Add(marker);
                     }
                 }
                 if (route.Points.Count > 0) {
                     
                     layer.Routes.Add(route);
                 }
             }
         }
     }
}
