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
using System.Collections;
using System.Data;
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
                 route.Stroke.Width = 1;
                 int count = 0;
                 IList<TX_Point> listp = Client.ClientHelper.PlatformSqlMap.GetList<TX_Point>("where layerid='" + tqcode + "'");
                 Dictionary<string, TX_Point> dicp = new Dictionary<string, TX_Point>();
                 foreach (TX_Point p in listp) {
                     dicp.Add(p.ID, p);
                 }
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
                         marker.MarkerType = MarkerEnum.gt;
                         preMarker = marker;
                         marker.ToolTipText = gt.gth + "\n" + line.LineName;
                         marker.Text = count+"";
                         marker.Tag = gt;
                         marker.Id = gt.gtID;
                         layer.Markers.Add(marker);
                         route.Markers.Add(marker);
                         marker.Route = route;
                     }
                     count++;
                 }
                 //线路名文字
                 if (route.Points.Count > 0) {
                     if (dicp.ContainsKey(line.LineCode)) {
                         TX_Point pt = dicp[line.LineCode];
                         GMapMarkerText text = new GMapMarkerText(new PointLatLng(double.Parse(pt.y), double.Parse(pt.x)));
                         text.Text = pt.Text;
                         text.IsVisible = false;
                         text.MarkerType = MarkerEnum.xlmc;
                         layer.Markers.Add(text);
                         text.Tag = pt;
                     } else {
                         GMapMarkerText text = new GMapMarkerText(route.Points[0]);
                         text.Tag = line.LineCode;
                         text.Text = line.LineName;
                         text.IsVisible = false;
                         text.MarkerType = MarkerEnum.xlmc;
                         layer.Markers.Add(text);
                     }
                 }
                 if (route.Points.Count > 0) {
                     
                     layer.Routes.Add(route);
                 }
             }
         }
         internal static void Build10kVLines(ref LineOverlay layer, string lineCode) {
             IList<PS_xl> xllist = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>(string.Format("where left(Linecode,{0})='{1}' and LineVol = '10'", lineCode.Length, lineCode));
             string linecode = "";
             string kgfilter = " where gtid in (select gtid from ps_gt  where Linecode='{0}')";
             string byqfilter = " tqid  in (select a.tqid from ps_tq a, ps_gt b  where a.gtid=b.gtid and b.Linecode='{0}') ";
             string byqfilter2 = "select a.*,b.gtid from ps_tqbyq a ,ps_tq b,ps_gt c  where a.tqid=b.tqid and  b.gtid=c.gtid and c.Linecode='{0}' ";
             Dictionary<string, PointLatLng> gtdic = new Dictionary<string, PointLatLng>();
             IList<PS_gt> list;
             IList<PS_kg> kglist;
             IList byqlist;
             IList<TX_Point> listp = Client.ClientHelper.PlatformSqlMap.GetList<TX_Point>("where layerid='" + lineCode + "'");
             Dictionary<string, TX_Point> dicp = new Dictionary<string, TX_Point>();
             foreach (TX_Point p in listp) {
                 dicp.Add(p.ID, p);
             }
             foreach (PS_xl line in xllist) {
                 linecode = line.LineCode;
                 list= Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>(string.Format("where Linecode='{0}' order by gtcode", linecode));
                 kglist = Client.ClientHelper.PlatformSqlMap.GetList<PS_kg>(string.Format(kgfilter, linecode));
                 byqlist = Client.ClientHelper.PlatformSqlMap.GetList("Select",string.Format(byqfilter2, linecode));
                 DataTable byqtable = DataConvert.HashTablesToDataTable(byqlist);
                 GMapMarkerVector marker = null;
                 GMapMarkerVector preMarker = null;
                 List<PointLatLng> points = new List<PointLatLng>();
                 LineRoute route = new LineRoute(points, linecode);
                 //route.Stroke.Color = Color.Black;
                 if (linecode.Length == 6)
                     route.Stroke.Width = 3;
                 else
                     route.Stroke.Width = 3;
                 int count = 0;
                 gtdic.Clear();
                 foreach (PS_gt gt in list) {
                     PointF pf = new PointF((float)gt.gtLon, (float)gt.gtLat);
                     if (count == 0) {
                         int.TryParse(gt.gth, out count);
                         count /= 10;
                     }
                     
                     if (box.Contains(pf)) {
                         
                         PointLatLng point = new PointLatLng(Convert.ToDouble(gt.gtLat), Convert.ToDouble(gt.gtLon));
                         gtdic.Add(gt.gtID, point);//放入字典供杆塔设备定位
                         route.Points.Add(point);
                         if (gt.gtType.Contains("方杆"))
                             marker = new GMapMarkerRect(point);
                         else
                             marker = new GMapMarkerVector(point);
                         if (preMarker != null) {
                             marker.ParentMarker = preMarker;
                             preMarker.NextMarker = marker;
                         }
                         marker.MarkerType = MarkerEnum.gt;
                         preMarker = marker;
                         marker.ToolTipText = gt.gth + "\n" + line.LineName;
                         marker.Tag = gt;
                         if(count%2==1)
                         marker.Text = count+"";
                         marker.Id = gt.gtID;
                         layer.Markers.Add(marker);
                         route.Markers.Add(marker);
                         marker.Route = route;
                     }
                     count++;
                 }
                 //线路名文字
                 if (route.Points.Count > 0) {
                     if(dicp.ContainsKey(line.LineCode)){
                         TX_Point pt=dicp[line.LineCode];
                         GMapMarkerText text = new GMapMarkerText(new PointLatLng(double.Parse(pt.y),double.Parse(pt.x)));
                         text.Text = pt.Text;
                         text.IsVisible = false;
                         text.MarkerType = MarkerEnum.xlmc;
                         layer.Markers.Add(text);
                         text.Tag = pt;
                     }else{
                     GMapMarkerText text = new GMapMarkerText(route.Points[0]);
                     text.Tag = line.LineCode;
                     text.Text = line.LineName;
                     text.IsVisible = false;
                     text.MarkerType = MarkerEnum.xlmc;
                     layer.Markers.Add(text);
                     }
                 }
                 //变压器
                 if (byqtable!=null && byqtable.Rows.Count>0) {
                     foreach (DataRow row in byqtable.Rows) {
                         if (!gtdic.ContainsKey(row["gtid"].ToString())) continue;

                         PointLatLng point = gtdic[row["gtid"].ToString()];
                         marker = new GMapMarkerBYQ(point);
                         marker.MarkerType = MarkerEnum.byq;
                         marker.ShowText = true;
                         marker.Text = string.Format("{0}",  row["byqCapcity"]);
                         marker.ToolTipText = string.Format("安装地点：{0}\r\n型号：{1}\r\n容量：{2}", row["byqName"], row["byqModle"], row["byqCapcity"]);
                         marker.Tag = row["byqID"];
                         //marker.IsHitTestVisible = false;
                         layer.Markers.Add(marker);
                     }
                 }
                 if (kglist != null && kglist.Count > 0) {
                     foreach (PS_kg row in kglist) {
                         if (!gtdic.ContainsKey(row.gtID)) continue;

                         PointLatLng point = gtdic[row.gtID];
                         marker = new GMapMarkerKG(point);
                         marker.IsVisible = false;
                         marker.MarkerType = MarkerEnum.kg;
                         //marker.Text = string.Format("{0}", row.kgModle);
                         marker.ToolTipText = string.Format("安装地点：{0}\r\n型号：{1}\r\n容量：{2}", row.kgInstallAdress, row.kgModle, row.kgCapcity);
                         marker.Tag = row;
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
