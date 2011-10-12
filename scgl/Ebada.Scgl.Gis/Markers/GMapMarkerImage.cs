using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Drawing;
using GMap.NET;

namespace Ebada.Scgl.Gis.Markers {
    [Serializable]
    internal class GMapMarkerImage : GMapMarkerVector {
        public float? Bearing;

        public System.Drawing.Size SizeSt = new Size(14, 14);
        public Bitmap Image;
        public Bitmap ImageShadow;
        public GMapMarkerImage(PointLatLng p)
            : base(p) {
            Size = SizeSt;
            //Offset = new Point(-6, -6);
        }

        static readonly Point[] Arrow = new Point[] { new Point(-7, -7), new Point(-7, 7), new Point(7, 7), new Point(7, -7) };

        public override void OnRender(Graphics g) {

            if (!Bearing.HasValue && ImageShadow != null) {
                g.DrawImageUnscaled(ImageShadow, LocalPosition.X, LocalPosition.Y);
            }
            g.TranslateTransform(ToolTipPosition.X, ToolTipPosition.Y);

            if (Bearing.HasValue) {
                //g.RotateTransform(Bearing.Value - Overlay.Control.Bearing);
                g.FillPolygon(Brushes.Lime, Arrow);
            }

            g.ResetTransform();

            if (!Bearing.HasValue && Image != null) {
                g.DrawImageUnscaled(Image, LocalPosition.X, LocalPosition.Y);
            }
            if (Image == null) {
                g.FillPolygon(Brushes.Lime, Arrow);
            }
        }
    }
}
