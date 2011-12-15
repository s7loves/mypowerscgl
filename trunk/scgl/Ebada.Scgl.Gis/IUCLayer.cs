using System;
namespace Ebada.Scgl.Gis {
    interface IUCLayer {
        GMap.NET.WindowsForms.GMapOverlay AddLayer(string strName);
        void InitLayer();
        RMap MapControl { get; set; }
        bool ShowToolbar { get; set; }
    }
}
