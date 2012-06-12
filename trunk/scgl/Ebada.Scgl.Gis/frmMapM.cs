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
    public partial class frmMapM : XtraForm {
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
        public frmMapM() {
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
            rMap1.OnTileLoadStart += new TileLoadStart(MainMap_OnTileLoadStart);

            rMap1.OnTileLoadComplete += new TileLoadComplete(MainMap_OnTileLoadComplete);
            barButtonItem10.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            barButtonItem10.AllowAllUp = true;
            barButtonItem4.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            barButtonItem4.DownChanged += new DevExpress.XtraBars.ItemClickEventHandler(测距_DownChanged);
            barTJ.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            barTJ.DownChanged += new DevExpress.XtraBars.ItemClickEventHandler(barTJ_DownChanged);
            barButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        void barTJ_DownChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (barTJ.Down) {
                CurOperation = oInstances.TjOperation;
            } else {
                oInstances.TjOperation.Reset();
                CurOperation = oInstances.LineOperation;
            }
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
        
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            mapview.FullView();
            ucMapLayer1.MapControl = rMap1;
            ucMapLayer1.ShowToolbar = false;
            ucMapLayer1.InitLayer();
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
            //线路 
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
            curOperation.OnMarkerLeave(item);
        }

        void MainMap_OnMarkerEnter(GMapMarker item) {
            curOperation.OnMarkerEnter(item);
        }

        void MainMap_OnMapTypeChanged(GMapProvider type) {
        }

        void MainMap_MouseUp(object sender, MouseEventArgs e) {
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
        }

        // MapZoomChanged
        void MainMap_OnMapZoomChanged() {
        }

        // click on some marker
        void MainMap_OnMarkerClick(GMapMarker item, MouseEventArgs e) {
        }

        // loader start loading tiles
        void MainMap_OnTileLoadStart() {
            MethodInvoker m = delegate() {
                //panelMenu.Text = "Menu: loading tiles...";
                barEditItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            };
            try {
                BeginInvoke(m);
            } catch {
            }
        }

        // loader end loading tiles
        void MainMap_OnTileLoadComplete(long ElapsedMilliseconds) {
            //MainMap.ElapsedMilliseconds = ElapsedMilliseconds;

            MethodInvoker m = delegate() {
                //panelMenu.Text = "Menu, last load in " + MainMap.ElapsedMilliseconds + "ms";
                barEditItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //textBoxMemory.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.00}MB of {1:0.00}MB", MainMap.Manager.MemoryCacheSize, MainMap.Manager.MemoryCacheCapacity);
            };
            try {
                BeginInvoke(m);
            } catch {
            }
        }

        // current point changed
        void MainMap_OnPositionChanged(PointLatLng point) {
            //center.Position = point;
            //textBoxLatCurrent.Text = point.Lat.ToString(CultureInfo.InvariantCulture);
            //textBoxLngCurrent.Text = point.Lng.ToString(CultureInfo.InvariantCulture);
        }

        // center markers on start
       

        // ensure focus on map, trackbar can have it too
        //PointLatLng offsize = new PointLatLng(0.00187f, 0.00654f);
        void rMap1_MouseMove(object sender, MouseEventArgs e) {
            PointLatLng ll = rMap1.FromLocalToLatLng(e.X, e.Y);
            barStaticItem1.Caption = string.Format("纬度:{0},经度:{1}", ll.Lat, ll.Lng );
           
        }

        void rMap1_MouseEnter(object sender, EventArgs e) {
            rMap1.Focus();
        }
         #endregion
       protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            initcity();
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
                    rMap1.MapProvider = GoogleChinaMapNull.Instance;

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

        private void barCAD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Ebada.SCGL.CADLib.CAD cad = new Ebada.SCGL.CADLib.CAD();
            List<string> list=new List<string>();
            foreach (GMapOverlay lay in rMap1.Overlays) {
                if (lay is LineOverlay) {
                    if(lay.IsVisibile)
                        list.Add(lay.Id);
                }
            }
            if(list.Count>0)
            cad.ToDwg(list.ToArray());
        }

        private void barTJ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            //MessageBox.Show("功能正在调试，近期完成。。。");
        }
        private void initcity() {
            string s1 = "127.043175 47.167316,127.006096 47.166382,126.988243 47.154243,126.971764 47.131828,126.98275 47.11594,126.971764 47.095379,126.96627 47.083221,126.964897 47.062645,126.964897 47.035511,126.949791 47.028957,126.962151 46.981197,126.951164 46.968079,126.948418 46.952145,126.923698 46.942768,126.909966 46.929642,126.901726 46.912758,126.898979 46.885548,126.903099 46.861137,126.898979 46.846111,126.898979 46.831081,126.911339 46.812286,126.912712 46.779381,126.905846 46.766212,126.875633 46.767155,126.872887 46.756805,126.860527 46.756805,126.845421 46.755863,126.838554 46.746456,126.827568 46.755863,126.813835 46.741749,126.797356 46.739868,126.77401 46.731396,126.717705 46.717278,126.706718 46.703152,126.699852 46.69656,126.673759 46.692791,126.632561 46.68808,126.605095 46.687138,126.580376 46.675835,126.555656 46.657928,126.533684 46.658871,126.515831 46.647556,126.510338 46.637188,126.493858 46.647556,126.470512 46.647556,126.470512 46.631531,126.462273 46.622097,126.45266 46.607006,126.451286 46.599457,126.451286 46.5853,126.429314 46.58247,126.44442 46.566422,126.459526 46.557922,126.470512 46.547535,126.488365 46.525806,126.499352 46.505016,126.529564 46.467194,126.566643 46.439758,126.566643 46.416092,126.581749 46.391472,126.609215 46.364944,126.610588 46.354519,126.625694 46.33366,126.66964 46.340298,126.684746 46.380104,126.697105 46.398102,126.723198 46.399048,126.742424 46.4142,126.776756 46.42556,126.819328 46.432186,126.823448 46.453949,126.855034 46.487999,126.893486 46.497456,126.904472 46.514469,126.97451 46.526752,127.021202 46.549423,127.039055 46.578693,127.066521 46.5853,127.09124 46.599457,127.150291 46.623985,127.201103 46.647556,127.247795 46.650387,127.29174 46.652271,127.339806 46.670177,127.342552 46.701267,127.323326 46.737045,127.30822 46.759628,127.287621 46.791607,127.273888 46.802887,127.264275 46.813225,127.278008 46.825443,127.268394 46.846111,127.234062 46.859261,127.206596 46.862076,127.224449 46.879913,127.265648 46.886486,127.298607 46.898685,127.298607 46.920261,127.305473 46.958706,127.327446 46.972763,127.334312 47.013977,127.349419 47.02615,127.372765 47.051418,127.375511 47.06826,127.346672 47.081352,127.328819 47.054226,127.293114 47.050484,127.261528 47.060776,127.228569 47.075741,127.213463 47.07761,127.217583 47.090702,127.236809 47.116875,127.229942 47.143036,127.181877 47.14584,127.166771 47.149574,127.125572 47.150509,127.096733 47.161716,127.073387 47.162647,127.052788 47.162647,127.040428 47.163582";
            string[] lls = s1.Split(',');
            
            List<PointLatLng> list = new List<PointLatLng>();
            foreach (string s in lls) {
                string[] ls = s.Split(' ');
                if (ls.Length == 2) {
                    list.Add(new PointLatLng(double.Parse(ls[1]),double.Parse(ls[0])));                    
                }
            }
            GMapPolygon gp=new GMapPolygon(list,"绥化");
            rMap1.bdzLayer.Polygons.Add(gp);
        }

    }
}
