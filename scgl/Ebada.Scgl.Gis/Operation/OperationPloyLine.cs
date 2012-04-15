using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Windows.Forms;
using Ebada.Scgl.Gis.Markers;
using System.Drawing;
using GMap.NET;
using Ebada.Scgl.Gis.Device;
using System.Drawing.Drawing2D;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Gis {
    /// <summary>
    /// 区域统计操作
    /// </summary>
    internal class OperationPloyLine:OperationBase {
        GMapOverlay routes;
        bool isBegin = true;
        public OperationPloyLine(RMap mapcontrol)
            : base(mapcontrol) {
        }

        void Markers_CollectionChanged(object sender, GMap.NET.ObjectModel.NotifyCollectionChangedEventArgs e) {
            refreshRoute();
        }
        void refreshRoute() {
            List<PointLatLng> linePoints = new List<PointLatLng>();

            foreach (GMapMarker m in routes.Markers) {                
                m.Tag = linePoints.Count;
                linePoints.Add(m.Position);
                m.ToolTipMode = MarkerTooltipMode.Never;
            }
            
            if (linePoints.Count > 0) {
                GMapPolygon route = new GMapPolygon(linePoints, "qytj");
                route.Stroke = new Pen(Color.Green);
                route.Stroke.Width = 2;
                routes.Polygons.Clear();
                routes.Polygons.Add(route);
            }
        }
        public override void Reset() {
            routes.Markers.Clear();
            routes.Polygons.Clear();
            isBegin=true;
        }
        public override void MouseDown(object sender, MouseEventArgs e) {

            if (e.Button == MouseButtons.Left) {
                isMouseDown = true;
                if (currentMarker == null && isBegin) {
                    GMapMarker marker = createMarker(rMap1.FromLocalToLatLng(e.X, e.Y));
                }
            } else if (e.Button == MouseButtons.Right) {
                if (isBegin) {
                    //统计设备
                    if(routes.Markers.Count<2)return;

                    List<PS_gt> gtlist = new List<PS_gt>();
                    int bl = 1000000;
                    using (GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath()) {
                        List<PointF> list = new List<PointF>();
                        foreach (PointLatLng pll in routes.Polygons[0].Points) {
                            list.Add(new PointF((float)pll.Lng * bl, (float)pll.Lat * bl));

                        }
                        gp.AddPolygon(list.ToArray());
                        Region r = new Region(gp);
                        
                        foreach (GMapOverlay lay in this.rMap1.Overlays) {
                            if (!lay.IsVisibile|| !(lay is LineOverlay)) continue;
                            LineOverlay lo = lay as LineOverlay;
                            foreach (GMapMarker m in lo.Markers) {
                                if (r.IsVisible(new PointF((float)m.Position.Lng * bl, (float)m.Position.Lat * bl))) {
                                    if(m.Tag is PS_gt)
                                        gtlist.Add(m.Tag as PS_gt);
                                }

                            }
                        }
                    }
                    frmQytj dlg = new frmQytj(gtlist);
                    dlg.StartPosition = FormStartPosition.CenterScreen;

                    dlg.Show(this.rMap1);
                }
                isBegin = false;
            }
        }
        public override ContextMenu CreatePopuMenu() {


            return new ContextMenu();
        }
       
        GMapMarker createMarker(PointLatLng pos) {
            GMapMarkerVector marker = new GMapMarkerVector(pos);

            marker.Pen = new Pen(Color.FromArgb(144, Color.MidnightBlue), 2);
            marker.IsHitTestVisible = false;
            //marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            routes.Markers.Add(marker);

            return marker;
        }
    }
}
