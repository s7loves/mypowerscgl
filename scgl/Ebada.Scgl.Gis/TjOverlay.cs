using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;

namespace Ebada.Scgl.Gis {
    internal class TjOverlay : GMapOverlay {
        public TjOverlay(GMapControl map, string lineCode)
            : base(map, lineCode) {
    }
        protected override void DrawPolygons(System.Drawing.Graphics g) {
            base.DrawPolygons(g);
        }
    }
}
