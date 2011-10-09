using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Windows.Forms;
using Ebada.Scgl.Gis.Markers;
using System.Drawing;
using GMap.NET;

namespace Ebada.Scgl.Gis {
    internal class OperationDistance:OperationBase {
        GMapOverlay routes;
        public OperationDistance(RMap mapcontrol):base(mapcontrol) {

            routes = new GMapOverlay(mapcontrol, "distance");
            routes.Markers.CollectionChanged += new GMap.NET.ObjectModel.NotifyCollectionChangedEventHandler(Markers_CollectionChanged);
            mapcontrol.Overlays.Add(routes);
        }

        void Markers_CollectionChanged(object sender, GMap.NET.ObjectModel.NotifyCollectionChangedEventArgs e) {
            refreshRoute();
        }
        void refreshRoute() {
            List<PointLatLng> linePoints = new List<PointLatLng>();

            foreach (GMapMarker m in routes.Markers) {                
                m.Tag = linePoints.Count;
                linePoints.Add(m.Position);
                m.ToolTipMode = MarkerTooltipMode.Never;
            }
            if (routes.Markers.Count > 1) {
                routes.Markers[routes.Markers.Count - 1].ToolTipMode = MarkerTooltipMode.Always;
            }
            if (linePoints.Count > 0) {
                GMapRoute route = new GMapRoute(linePoints, "distance");
                route.Stroke.Width = 4;
                routes.Routes.Clear();
                routes.Routes.Add(route);
            }
        }
        public override void Reset() {
            routes.Markers.Clear();
            routes.Routes.Clear();
        }
        public override void MouseDown(object sender, MouseEventArgs e) {

            if (e.Button == MouseButtons.Left) {
                isMouseDown = true;
                if (currentMarker == null) {
                    GMapMarker marker = createMarker(rMap1.FromLocalToLatLng(e.X, e.Y));
                }
            }
        }
        public override ContextMenu CreatePopuMenu() {


            return new ContextMenu();
        }
        //GMapMarker createMarker(PointLatLng pos) {
        //    GMapMarkerVector marker = new GMapMarkerVector(pos);
        //    marker.Pen = new Pen(Color.FromArgb(144, Color.GreenYellow), 2);
        //    marker.IsHitTestVisible = false;
        //    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
        //    return marker;
        //}
        GMapMarker createMarker(PointLatLng pos) {
            GMapMarkerVector marker = new GMapMarkerVector(pos);

            marker.Pen = new Pen(Color.FromArgb(144, Color.MidnightBlue), 2);
            marker.IsHitTestVisible = false;
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            routes.Markers.Add(marker);
            if (routes.Markers.Count > 1)
                marker.ToolTipText = routes.Routes[0].Distance + "";// rMap1.Manager.GetDistance(pos, objects.Markers[objects.Markers.Count - 1].Position) + "";

            return marker;
        }
    }
}
