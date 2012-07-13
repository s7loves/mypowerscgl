using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Drawing;
using GMap.NET;

namespace Ebada.Scgl.Gis.Markers {
    [Serializable]
    internal class GMapMarkerPoint : GMapMarkerVector {

        public GMapMarkerPoint(PointLatLng p)
            : base(p) {

        }
        public override void OnRender(Graphics g) {
            System.Drawing.Point p1 = new System.Drawing.Point(LocalPosition.X, LocalPosition.Y);

            Rectangle r = new Rectangle(p1, SizeSt);
            g.FillRectangle(Brushes.White, r);
            g.DrawRectangle(Pen, r);

        }
        public override System.Windows.Forms.ContextMenu CreatePopuMenu() {
            return new System.Windows.Forms.ContextMenu();
        }
        internal override void Update() {
            base.Update();
        }
    }
}
