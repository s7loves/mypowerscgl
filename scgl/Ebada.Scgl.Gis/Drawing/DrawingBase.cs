using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GMap.NET;

namespace Ebada.Scgl.Gis {
    public abstract class DrawingBase : IDrawing {
        string title=string.Empty;
        Font titleFont = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);
        RectLatLng bounds = RectLatLng.Empty;
        protected RMap map;
        
        public virtual void Draw(Graphics g) {

        }
        public virtual string Title {
            get { return title; }
            set { title = value; }
        }
        public virtual void Create(string p){

        }
        public virtual GMap.NET.RectLatLng Bounds {
            get { return bounds; }
            set { bounds = value; }
        }
    }
}
