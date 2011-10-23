/**********************************************
系统:地理信息
模块:
作者:Rabbit
创建时间:2011-9-4
最后一次修改:2011-9-4
***********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GMap.NET.MapProviders;
using GMap.NET;
using Ebada.Client;
using System.Globalization;
using GMap.NET.WindowsForms;
using System.Diagnostics;
using GMap.NET.WindowsForms.Markers;
using Ebada.Scgl.Gis.Markers;
using Ebada.Scgl.Gis.Device;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Gis {
    public partial class frmMap : XtraForm {
        TONLI.MapCore.IMapServer mapServer;
        IMapView mapview;
        bool isMouseDown=false;
        GMapMarker currentMarker;
        internal GMapOverlay objects;//杆塔
        internal GMapOverlay routes;//线路
        OperationBase curOperation;

        internal OperationBase CurOperation {
            get { return curOperation; }
            set {
                if (null == value || curOperation == value) return;
                if (curOperation is OperationDistance)
                    curOperation.Reset();
                curOperation = value; 
            
            }
        }
        OperationInstances oInstances;
        bool canAddMarker;
        public frmMap() {
            InitializeComponent();
            rMap1 = new RMap();

            rMap1.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            rMap1.Dock = DockStyle.Fill;
            Controls.Add(rMap1);
            mapview = rMap1;
            rMap1.Manager.Mode = GMap.NET.AccessMode.ServerOnly;
            GoogleChinaMap map = GoogleChinaMap.Instance;
            map.TryCorrectVersion = false;
            rMap1.MapProvider = map;
            //rMap1.Position = new PointLatLng(46.6, 130);
            rMap1.MaxZoom = 16;
            rMap1.MinZoom = 9;
            mapServer = ClientServer.PlatformServer.GetService<TONLI.MapCore.IMapServer>();

            objects = new GMapOverlay(rMap1, "objects");
            routes = new GMapOverlay(rMap1, "LineCode");
            
            rMap1.Overlays.Add(routes);
            rMap1.Overlays.Add(objects);

            routes.Markers.CollectionChanged += new GMap.NET.ObjectModel.NotifyCollectionChangedEventHandler(Markers_CollectionChanged);
            
            oInstances = new OperationInstances(rMap1);
            curOperation = oInstances.LineOperation;
            rMap1.OnMapZoomChanged += new MapZoomChanged(rMap1_OnMapZoomChanged);
            rMap1.MouseEnter += new EventHandler(rMap1_MouseEnter);
            rMap1.MouseMove += new MouseEventHandler(rMap1_MouseMove);
            rMap1.MouseMove += new MouseEventHandler(MainMap_MouseMove);
            rMap1.MouseDown += new MouseEventHandler(MainMap_MouseDown);
            rMap1.MouseUp += new MouseEventHandler(MainMap_MouseUp);
            rMap1.OnMarkerEnter += new MarkerEnter(MainMap_OnMarkerEnter);
            rMap1.OnMarkerLeave += new MarkerLeave(MainMap_OnMarkerLeave);

            barButtonItem10.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            barButtonItem10.AllowAllUp = true;
            barButtonItem4.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            barButtonItem4.DownChanged += new DevExpress.XtraBars.ItemClickEventHandler(测距_DownChanged);
            barButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        void 测距_DownChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (barButtonItem4.Down)
                CurOperation = oInstances.DistanceOperation;
            else
                CurOperation = oInstances.LineOperation;
        }
        void refreshRoute(){
            List<PointLatLng> linePoints = new List<PointLatLng>();

            foreach (GMapMarker m in routes.Markers) {
                if (true) {
                    m.Tag = linePoints.Count;
                    linePoints.Add(m.Position);
                }
            }
            if (linePoints.Count > 0) {
                LineRoute route = new LineRoute(linePoints, "LineCode");
                route.Stroke.Width = 4;
                routes.Routes.Clear();
                routes.Routes.Add(route);
                
            }
        }
        void Markers_CollectionChanged(object sender, GMap.NET.ObjectModel.NotifyCollectionChangedEventArgs e) {
            refreshRoute();

        }
        public frmMap(RMap map) {
            InitializeComponent();
            rMap1 = map;
            Controls.Add(rMap1);
            
        }
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            mapview.FullView();
        }
        public void FullScrean() {
            FormState formState = new FormState();
            this.SetVisibleCore(false);
            formState.Maximize(this);
            this.SetVisibleCore(true);
            btFullScrean.Caption = "退出全屏";
        }
        #region 工具栏事件
        private void btFullScrean_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (btFullScrean.Caption == "退出全屏") {
                this.Close();
            } else {
                frmMap dlg = new frmMap();
                dlg.Show();
                dlg.FullScrean();
            }
        }
        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            switch (e.Item.Caption) {
                case "漫游":
                    mapview.Roam();
                    break;
                case "放大":
                    mapview.Zoomout();
                    break;
                case "缩小":
                    mapview.Zoomin();
                    break;
                case "测距":
                    //curOperation = oInstances.DistanceOperation;
                    break;
                case "全景":
                    mapview.FullView();
                    break;
                case "飞行":
                    mapview.Fly();
                    break;
                case "变台":
                    showTQ();
                    break;
                case "变电站(所)":
                    showBDS();
                    break; 
            }
        }

        private void showBDS() {
            frmBDSSelector dlg = new frmBDSSelector();
            if (dlg.ShowDialog(this) == DialogResult.OK) {
                mOrg obj = dlg.GetSelected() as mOrg;
                if (obj != null) {
                    GMapMarker marker = rMap1.FindMarker(obj);
                    if (marker != null)
                        rMap1.Position = marker.Position;
                }
            }
        }

        private void showTQ() {
            // 台区
            frmTQSelector dlg = new frmTQSelector();
            if (dlg.ShowDialog(this) == DialogResult.OK) {
                PS_tq obj = dlg.GetSelected() as PS_tq;
                if (obj != null) {
                    GMapOverlay lay = rMap1.FindOverlay(obj.tqCode);
                    if (lay != null)
                        rMap1.Overlays.Remove(lay);
                    rMap1.Overlays.Add(LineOverlay.CreateTQLine(rMap1,obj.tqCode,obj.tqName));
                    rMap1.ZoomAndCenterRoutes(obj.tqCode);
                }
            }
        }
        #endregion
        #region -- map events --
        void MainMap_OnMarkerLeave(GMapMarker item) {
            //if (!isMouseDown && currentMarker==item)
            //    currentMarker = null;
            curOperation.OnMarkerLeave(item);
        }

        void MainMap_OnMarkerEnter(GMapMarker item) {
            //if (!isMouseDown)
            //    currentMarker = item;
            curOperation.OnMarkerEnter(item);
        }

        void MainMap_OnMapTypeChanged(GMapProvider type) {
            

            //if (radioButtonTransport.Checked) {
            //    MainMap.ZoomAndCenterMarkers("objects");
            //}
        }

        void MainMap_MouseUp(object sender, MouseEventArgs e) {
            //if (e.Button == MouseButtons.Left) {
            //    isMouseDown = false;
            //    currentMarker = null;
            //}
            curOperation.MouseUp(sender, e);
        }
        GMapMarker createMarker(PointLatLng pos) {
            GMapMarkerVector marker = new GMapMarkerVector(pos);
            if (objects.Markers.Count % 2.0 == 0)
                marker = new GMapMarkerRect(pos);
            marker.Pen =new Pen(Color.FromArgb(144, Color.MidnightBlue),2);
            marker.IsHitTestVisible = true;
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            routes.Markers.Add(marker);
            if (routes.Markers.Count > 1)

                marker.ToolTipText = routes.Routes[0].Distance + "";// rMap1.Manager.GetDistance(pos, objects.Markers[objects.Markers.Count - 1].Position) + "";
            
            return marker;
        }
        void MainMap_MouseDown(object sender, MouseEventArgs e) {
            curOperation.MouseDown(sender, e);
            
        }

        // move current marker with left holding
        void MainMap_MouseMove(object sender, MouseEventArgs e) {
            curOperation.MouseMove(sender, e);
            //if (e.Button == MouseButtons.Left && isMouseDown) {
            //    if (currentMarker != null) {
            //        if (currentMarker.IsVisible) {
            //            currentMarker.Position = rMap1.FromLocalToLatLng(e.X, e.Y);
            //            currentMarker.ToolTipText = currentMarker.Position.ToString();
            //            refreshRoute();
            //        }
            //    } else // move rect marker
            //{
            //        //PointLatLng pnew = rMap1.FromLocalToLatLng(e.X, e.Y);

            //        //int? pIndex = (int?)CurentRectMarker.Tag;
            //        //if (pIndex.HasValue) {
            //        //    if (pIndex < polygon.Points.Count) {
            //        //        polygon.Points[pIndex.Value] = pnew;
            //        //        rMap1.UpdatePolygonLocalPosition(polygon);
            //        //    }
            //        //}

            //        //if (currentMarker.IsVisible) {
            //        //    currentMarker.Position = pnew;
            //        //}
            //        //CurentRectMarker.Position = pnew;

            //        //if (CurentRectMarker.InnerMarker != null) {
            //        //    CurentRectMarker.InnerMarker.Position = pnew;
            //        //}
            //    }
            //}
        }

        // MapZoomChanged
        void MainMap_OnMapZoomChanged() {
            //trackBar1.Value = (int)(MainMap.Zoom);
            //textBoxZoomCurrent.Text = MainMap.Zoom.ToString();
            //center.Position = MainMap.Position;
        }

        // click on some marker
        void MainMap_OnMarkerClick(GMapMarker item, MouseEventArgs e) {
            //if (e.Button == System.Windows.Forms.MouseButtons.Left) {
            //    if (item is GMapMarkerRect) {
            //        Placemark pos = GMaps.Instance.GetPlacemarkFromGeocoder(item.Position);
            //        if (pos != null) {
            //            GMapMarkerRect v = item as GMapMarkerRect;
            //            {
            //                v.ToolTipText = pos.Address;
            //            }
            //            MainMap.Invalidate(false);
            //        }
            //    } else {
            //        if (item.Tag != null) {
            //            if (currentTransport != null) {
            //                currentTransport.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            //                currentTransport = null;
            //            }
            //            currentTransport = item;
            //            currentTransport.ToolTipMode = MarkerTooltipMode.Always;
            //        }
            //    }
            //}
        }

        // loader start loading tiles
        void MainMap_OnTileLoadStart() {
            //MethodInvoker m = delegate() {
            //    panelMenu.Text = "Menu: loading tiles...";
            //};
            //try {
            //    BeginInvoke(m);
            //} catch {
            //}
        }

        // loader end loading tiles
        void MainMap_OnTileLoadComplete(long ElapsedMilliseconds) {
            //MainMap.ElapsedMilliseconds = ElapsedMilliseconds;

            //MethodInvoker m = delegate() {
            //    panelMenu.Text = "Menu, last load in " + MainMap.ElapsedMilliseconds + "ms";

            //    textBoxMemory.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.00}MB of {1:0.00}MB", MainMap.Manager.MemoryCacheSize, MainMap.Manager.MemoryCacheCapacity);
            //};
            //try {
            //    BeginInvoke(m);
            //} catch {
            //}
        }

        // current point changed
        void MainMap_OnPositionChanged(PointLatLng point) {
            //center.Position = point;
            //textBoxLatCurrent.Text = point.Lat.ToString(CultureInfo.InvariantCulture);
            //textBoxLngCurrent.Text = point.Lng.ToString(CultureInfo.InvariantCulture);
        }

        // center markers on start
        //private void Form_Load(object sender, EventArgs e) {
        //    if (objects.Markers.Count > 0) {
        //        MainMap.ZoomAndCenterMarkers(null);
        //        trackBar1.Value = (int)MainMap.Zoom;
        //    }
        //}

        // ensure focus on map, trackbar can have it too
        PointLatLng offsize = new PointLatLng(0.00187f, 0.00654f);
        void rMap1_MouseMove(object sender, MouseEventArgs e) {
            PointLatLng ll = rMap1.FromLocalToLatLng(e.X, e.Y);
            barStaticItem1.Caption = string.Format("纬度:{0},经度:{1}", ll.Lat, ll.Lng );
           
            //barStaticItem1.Caption = string.Format("lat:{0},lng:{1}", ll.Lat-offsize.Lat, ll.Lng-offsize.Lng);
        }

        void rMap1_MouseEnter(object sender, EventArgs e) {
            rMap1.Focus();
        }
         #endregion
       protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

        }

        void rMap1_OnMapZoomChanged() {
            //trackBar1.Value = (int)rMap1.Zoom;
        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e) {
            int n = int.Parse(barEditItem1.EditValue.ToString());
            switch (n) {

                case 1:
                    rMap1.MapProvider = GoogleChinaMap.Instance;
                    break;
                case 2:
                    rMap1.MapProvider = GoogleChinaHybridMap.Instance;
                    break;
                default:
                    rMap1.MapProvider = GoogleChinaMap.Instance;

                    break;
            }
        }
        // clear cache
        private void btClear_Click(object sender, EventArgs e) {
            if (MessageBox.Show("请确认?", "清除本地地图缓存?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) {
                try {
                    System.IO.Directory.Delete(rMap1.CacheLocation, true);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            //barButtonItem10.Down = !canAddMarker;
        }

        private void barButtonItem10_DownChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            canAddMarker = barButtonItem10.Down;
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            //线路 
            frmLineSelector dlg = new frmLineSelector();
            if (dlg.ShowDialog(this) == DialogResult.OK) {
                PS_xl obj = dlg.GetSelected() as PS_xl;
                if (obj != null) {                  
                    GMapOverlay lay = rMap1.FindOverlay(obj.LineCode);
                    if (lay != null)
                        rMap1.Overlays.Remove(lay);
                    rMap1.Overlays.Add(LineOverlay.CreateLine(rMap1, obj.LineCode,obj.LineName));
                    rMap1.ZoomAndCenterRoutes(obj.LineCode);
                }
            }
        }

    }
}
