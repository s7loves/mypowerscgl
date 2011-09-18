using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Windows.Forms;
using Ebada.Scgl.Gis.Markers;
using System.Drawing;

namespace Ebada.Scgl.Gis.Operation {
    internal class OperationBase {
        protected RMap rMap1;
        protected GMapMarker currentMarker;
        protected Boolean isMouseDown;
        protected GMapMarker selectedMarker;
        public OperationBase(RMap mapcontrol){
            rMap1 = mapcontrol;
        }
        public virtual void OnMarkerLeave(GMapMarker item) {
            if (!isMouseDown && currentMarker == item)
                currentMarker = null;
        }

        public virtual void OnMarkerEnter(GMapMarker item) {
            if (!isMouseDown)
                currentMarker = item;
        }

        public virtual void MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                isMouseDown = false;
            }
        }
        public virtual void MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                isMouseDown = true;
                if (currentMarker.IsMouseOver)
                    selectedMarker = currentMarker;
                else
                    selectedMarker = null;
            }
        }
        public virtual void OnRander(Graphics g) {

        }
        // move current marker with left holding
        public virtual void MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left && isMouseDown) {
                if (currentMarker != null) {
                    if (currentMarker.IsVisible) {
                        currentMarker.Position = rMap1.FromLocalToLatLng(e.X, e.Y);
                        currentMarker.ToolTipText = currentMarker.Position.ToString();
                    }
                } 
            }
        }
    }
}
