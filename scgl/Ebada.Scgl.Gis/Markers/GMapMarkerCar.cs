using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Drawing;
using GMap.NET;

namespace Ebada.Scgl.Gis.Markers {
    [Serializable]
    internal class GMapMarkerCar : GMapMarkerVector {
        public Bitmap Image;
        public Bitmap ImageShadow;
        public GMapMarkerCar(PointLatLng p)
            : base(p) {
            Size =SizeSt= new Size(25, 25);
            Offset = new Point(-12, -12);
            Image = Gis.Properties.Resources.green_n_1;
        }

        static readonly Point[] Arrow = new Point[] { new Point(-7, -7), new Point(-7, 7), new Point(7, 7), new Point(7, -7) };
        public override System.Windows.Forms.ContextMenu CreatePopuMenu() {
            return new System.Windows.Forms.ContextMenu();
        }
        public override void OnRender(Graphics g) {
            GraphicsUnit gu = g.PageUnit;
            g.PageUnit = GraphicsUnit.Pixel;
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
                g.DrawImage(Image, LocalPosition.X, LocalPosition.Y,25,25);
            }
            if (Image == null) {
                g.FillPolygon(Brushes.Lime, Arrow);
            }
            g.PageUnit = gu;
        }
    }
}
