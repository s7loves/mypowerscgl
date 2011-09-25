using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Drawing;
using GMap.NET;

namespace Ebada.Scgl.Gis.Markers {
    internal class GMapMarkerVector : GMapMarker {
        public System.Drawing.Size SizeSt = new Size(8, 8);
        public Pen Pen;
        public GMapMarkerVector(PointLatLng p)
            : base(p) {
            Size = SizeSt;
            Offset = new Point(-4, -4);
            Pen = new Pen(Color.Red, 2);

        }
        public override void OnRender(Graphics g) {
           
            System.Drawing.Point p1 = new System.Drawing.Point(LocalPosition.X, LocalPosition.Y);

            Rectangle r = new Rectangle(p1, SizeSt);
            g.FillEllipse(Brushes.White, r);
            g.DrawEllipse(Pen, r);
        }
    }
}
