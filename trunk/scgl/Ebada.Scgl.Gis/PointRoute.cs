using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using GMap.NET;
using Ebada.Scgl.Gis.Markers;

namespace Ebada.Scgl.Gis {
    /// <summary>
    /// 可编辑折线
    /// </summary>
    [Serializable]
    public class PointRoute:GMapRoute {
        public PointRoute(List<PointLatLng> points, string name)
            : base(points, name) {
            Markers = new GMap.NET.ObjectModel.ObservableCollectionThreadSafe<GMapMarkerVector>();
        }
        public GMap.NET.ObjectModel.ObservableCollectionThreadSafe<GMapMarkerVector> Markers;

        public void UpdateRoutePostion(GMapMarkerVector marker) {
            this.Points[Markers.IndexOf(marker)] = marker.Position;
        }
    }
}
