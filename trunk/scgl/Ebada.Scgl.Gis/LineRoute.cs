using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using GMap.NET;
using Ebada.Scgl.Gis.Markers;

namespace Ebada.Scgl.Gis {
    [Serializable]
    public class LineRoute:GMapRoute {
        public LineRoute(List<PointLatLng> points,string name): base(points, name) {
            Markers = new GMap.NET.ObjectModel.ObservableCollectionThreadSafe<GMapMarkerVector>();
        }
        public GMap.NET.ObjectModel.ObservableCollectionThreadSafe<GMapMarkerVector> Markers;

        public void UpdateRoutePostion(GMapMarkerVector marker) {
            this.Points[Markers.IndexOf(marker)] = marker.Position;
        }
    }
}
