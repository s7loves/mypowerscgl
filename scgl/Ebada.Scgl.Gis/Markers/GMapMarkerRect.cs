using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Drawing;
using GMap.NET;

namespace Ebada.Scgl.Gis.Markers {
    internal class GMapMarkerRect : GMapMarkerVector {
        
        public GMapMarkerRect(PointLatLng p)
            : base(p) {

        }
        public override void OnRender(Graphics g) {
            System.Drawing.Point p1 = new System.Drawing.Point(LocalPosition.X, LocalPosition.Y);

            Rectangle r = new Rectangle(p1, SizeSt);
            g.FillEllipse(Brushes.White, r);
            g.DrawEllipse(Pen, r);

        }
    }
}
