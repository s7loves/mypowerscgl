using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Windows.Forms;
using Ebada.Scgl.Gis.Markers;
using System.Drawing;
using GMap.NET;

namespace Ebada.Scgl.Gis {
    internal class OperationPoint:OperationBase {
        public OperationPoint(RMap mapcontrol)
            : base(mapcontrol) {
            NewVectorType = typeof(GMapMarkerVector);            
        }

        
        public override void MouseDown(object sender, MouseEventArgs e) {

            if (e.Button == MouseButtons.Left) {
                isMouseDown = true;
                if (currentMarker == null && CurOverlay!=null) {
                    GMapMarker marker = createMarker(rMap1.FromLocalToLatLng(e.X, e.Y));
                    CurOverlay.Markers.Add(marker);
                }
            }
        }
        public override ContextMenu CreatePopuMenu() {


            return new ContextMenu();
        }
        //GMapMarker createMarker(PointLatLng pos) {
        //    GMapMarkerVector marker = new GMapMarkerVector(pos);
        //    marker.Pen = new Pen(Color.FromArgb(144, Color.GreenYellow), 2);
        //    marker.IsHitTestVisible = false;
        //    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
        //    return marker;
        //}

        public Type NewVectorType;
        GMapMarker createMarker(PointLatLng pos) {
            GMapMarker marker = null;
            object newobj= Activator.CreateInstance(NewVectorType);
            if (newobj is GMapMarker)
                marker = newobj as GMapMarker;
            if (marker == null) {
                marker = new GMapMarkerVector(pos);
                marker.IsHitTestVisible = false;                
            }
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            return marker;
        }
    }
}
