using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Drawing;
using GMap.NET;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Gis.Markers {
    [Serializable]
    internal class GMapMarkerBDZ : GMapMarkerVector {

        public GMapMarkerBDZ(PointLatLng p)
            : base(p) {
            Size=SizeSt = new Size(20, 20);
            Offset = new Point(-10, -10);
        }
        public override void OnRender(Graphics g) {
            System.Drawing.Point p1 = new System.Drawing.Point(LocalPosition.X, LocalPosition.Y);

            Rectangle r = new Rectangle(p1, SizeSt);
            g.FillEllipse(Brushes.White, r);
            g.DrawEllipse(Pen, r);
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
