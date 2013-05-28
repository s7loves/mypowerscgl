﻿using System;
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
            Image = Gis.Properties.Resources.green_n_1;
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
