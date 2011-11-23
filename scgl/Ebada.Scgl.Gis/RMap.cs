/**********************************************
系统:地理信息
模块:
作者:Rabbit
创建时间:2011-9-4
最后一次修改:2011-9-4
***********************************************/
namespace Ebada.Scgl.Gis {
    using System.Windows.Forms;
    using GMap.NET.WindowsForms;
    using System.Drawing;
    using System;
    using GMap.NET;
    using Ebada.Scgl.Gis.Markers;

    /// <summary>
    /// custom map of GMapControl
    /// </summary>
    public class RMap : GMapControl, IMapView {
        public long ElapsedMilliseconds;
        public PointOverLay bdzLayer;

#if DEBUG
        private int counter;
        readonly Font DebugFont = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Regular);
#endif
        public RMap()
            : base() {
            InitializeComponent();
        }
        /// <summary>
        /// any custom drawing here
        /// </summary>
        /// <param name="drawingContext"></param>
        protected override void OnPaintOverlays(System.Drawing.Graphics g) {
            base.OnPaintOverlays(g);

#if DEBUG
            //g.DrawString(string.Format("lat：{0},lon:{1}", this.Position.Lat, this.Position.Lng), DebugFont, Brushes.Red, 36, 36);
            //g.DrawString("render: " + counter++ + ", load: " + ElapsedMilliseconds + "ms", DebugFont, Brushes.Blue, 36, 36);
            g.DrawString(debugMsg, DebugFont, Brushes.Blue, 36, 36);
#endif
        }
        public string debugMsg = "";
        private void InitializeComponent() {
            
            this.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            //MapScaleInfoEnabled = true;
            initOverlay();
        }
        private void initOverlay() {
            bdzLayer = new PointOverLay(this, "bdz");
            bdzLayer.Text = "变电所";
            this.Overlays.Add(bdzLayer);
        }
        protected override void OnDoubleClick(EventArgs e) {
            base.OnDoubleClick(e);
            //测试
            //Point pt =this.PointToClient(new Point( MousePosition.X,MousePosition.Y));
            ////createMarker(rMap1.FromLocalToLatLng(pt.X, pt.Y));
            //frmText dlg = new frmText();
            //if (dlg.ShowDialog() == DialogResult.OK) {
            //    GMapMarkerText marker = new GMapMarkerText(this.FromLocalToLatLng(pt.X, pt.Y));
            //    marker.Text = dlg.MarkerText;
            //    bdzLayer.Markers.Add(marker);
            //}
        }
        public GMapOverlay FindOverlay(string id) {
            GMapOverlay lay = null;
            foreach (GMapOverlay item in Overlays) {
                if (item.Id == id) {
                    lay = item;
                    break;

                }
            }

            return lay;
        }

        #region IMapView 成员

        public void Zoomin() {
            Zoom -= 1;
        }

        public void Zoomout() {
            Zoom += 1;
        }

        public void Roam() {

        }

        public void Fly() {
            throw new NotImplementedException("功能正在开发。。。");
        }

        public void Distance() {
            throw new NotImplementedException("功能正在开发。。。");
        }

        public void FullView() {
            Zoom = 9;
            Position = new PointLatLng(46.63, 126.98);
        }

        #endregion

        internal GMapMarker FindMarker(Ebada.Scgl.Model.mOrg obj) {
            GMapMarkerBDZ marker =null;
            foreach (GMapMarkerBDZ bdz in bdzLayer.Markers) {
                if (bdz.Id == obj.OrgCode) {
                    marker = bdz;
                    break;
                }
            }
            if (marker == null) {
                //新建
                double d1=this.Position.Lat;
                double d2 =this.Position.Lng;
                double.TryParse(obj.C1, out d1);
                double.TryParse(obj.C2, out d2);
                if (d1 == 0 || d2 == 0)
                    marker = new GMapMarkerBDZ(Position);
                else
                    marker = new GMapMarkerBDZ(new PointLatLng(d1, d2));
                marker.Tag = obj;
                marker.Id = obj.OrgCode;
                marker.Text = obj.OrgName;
                marker.ToolTipText = obj.OrgName;
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                bdzLayer.Markers.Add(marker);
            }
            return marker;
        }

        internal void RefreshOverlay(string p) {

            GMapOverlay layer = FindOverlay(p);

            if (p.Length >= 6) {
                bool flag = false;
                if (layer != null) {
                    this.Overlays.Remove(layer);
                    flag = (layer as IUpdateable).AllowEdit;
                }

                layer= FindCreateLine(p);
                (layer as IUpdateable).AllowEdit = flag;
            }
        }

        internal void LocationOverlay(string p) {
            GMapOverlay layer= FindOverlay(p);
            if (layer != null)
                this.ZoomAndCenterRoutes(p);
        }

        internal GMapOverlay FindCreateLine(string lineCode) {

            GMapOverlay lay = FindOverlay(lineCode);
            if (lay == null) {
                if (lineCode.Length == 10)
                    lay = LineOverlay.CreateTQLine(this, lineCode, "");
                else
                    lay = LineOverlay.CreateLine(this, lineCode, "");

                this.Overlays.Add(lay);
                
            }
            return lay;
        }
    }
}
