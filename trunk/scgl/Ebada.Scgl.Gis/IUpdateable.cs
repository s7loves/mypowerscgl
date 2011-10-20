using System;
using GMap.NET.WindowsForms;
namespace Ebada.Scgl.Gis {
    interface IUpdateable {
        void Update(GMap.NET.WindowsForms.GMapMarker marker);
        bool AllowEdit { get; set; }
        void OnMarkerChanged(GMapMarker marker);
    }
}
