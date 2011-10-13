﻿using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Drawing;
using GMap.NET;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Gis.Markers {
    [Serializable]
    internal class GMapMarkerBDZ : GMapMarkerVector {
        public string Text;
        private Font mFont;
        public GMapMarkerBDZ(PointLatLng p)
            : base(p) {
            Size=SizeSt = new Size(20, 20);
            Offset = new Point(-10, -10);
            Text = string.Empty;
            mFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
        }
        public override void OnRender(Graphics g) {
            System.Drawing.Point p1 = new System.Drawing.Point(LocalPosition.X, LocalPosition.Y);
            //new Pen(Color.FromArgb(144, Color.MidnightBlue));
            Rectangle r = new Rectangle(p1, SizeSt);
            g.FillEllipse(Brushes.White, r);
            g.DrawEllipse(Pen, r);
            if (!string.IsNullOrEmpty(Text)) {
                Size sf=g.MeasureString(Text, mFont).ToSize();

                g.DrawString(Text, mFont,Brushes.MidnightBlue, LocalPosition.X + 10 - sf.Width / 2, LocalPosition.Y + 30);
            }
        }
        
        internal override void Update() {
            PointOverLay lay = this.Overlay as PointOverLay;
            if (lay != null && lay.AllowEdit) {
                mOrg org = this.Tag as mOrg;
                org.C1 = this.Position.Lat.ToString();
                org.C2 = this.Position.Lng.ToString();
                Client.ClientHelper.PlatformSqlMap.Update<mOrg>(org);
            }
        }
    }
}
