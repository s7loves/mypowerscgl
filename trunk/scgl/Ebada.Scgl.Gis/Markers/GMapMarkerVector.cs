using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Drawing;
using GMap.NET;

namespace Ebada.Scgl.Gis.Markers {

    [Serializable]
    public class GMapMarkerVector : GMapMarker {
        public System.Drawing.Size SizeSt = new Size(8, 8);
        public Pen Pen;
        private List<GMapMarkerVector> items;
        private GMapMarkerVector parentMarker;
        private string id;
        private LineRoute route;

        public LineRoute Route {
            get { return route; }
            set { route = value; }
        }
        public string Id {
            get { return id; }
            set { id = value; }
        }
        public GMapMarkerVector NextMarker {
            get {
                GMapMarkerVector next = null;
                if (items.Count > 0)
                    next=items[0];
                return next; 
            }
            set {
                if (value==null||items.Contains(value)) return;
                items.Add(value);
            }
        }
        public GMapMarkerVector ParentMarker {
            get { return parentMarker; }
            set { parentMarker = value; }
        }
        public GMapMarkerVector(PointLatLng p)
            : base(p) {
            Size = SizeSt;
            Offset = new Point(-4, -4);
            Pen = new Pen(Color.Red, 2);
            items = new List<GMapMarkerVector>();
        }
        public override void OnRender(Graphics g) {
           
            System.Drawing.Point p1 = new System.Drawing.Point(LocalPosition.X, LocalPosition.Y);

            Rectangle r = new Rectangle(p1, SizeSt);
            g.FillEllipse(Brushes.White, r);
            g.DrawEllipse(Pen, r);
        }



        internal virtual void Update() {
            if (this.Overlay is LineOverlay)
                (this.Overlay as LineOverlay).Update(this);
        }
    }
}
