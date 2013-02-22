using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using GMap.NET;
using Ebada.Scgl.Model;
using Ebada.Scgl.Sbgl;
using System.Data;
using Ebada.Scgl.Gis.Markers;
using System.Windows.Forms;
using TLMapPlatform;
using Ebada.Scgl.Gis.Device;
namespace Ebada.Scgl.Gis {
    /// <summary>
    /// 配电线路层
    /// </summary>
    public class LineOverlay : GMapOverlay, IUpdateable,IDisposable,IPopuMenu,ILineInfo {

        private GMapControl control;
        private bool allowEdit;
        ContextMenu contextMenu;
        GMapMarker selectedMarker;
        public bool AllowEdit {
            get { return allowEdit; }
            set { allowEdit = value; }
        }
        public LineOverlay(GMapControl map, string lineCode)
            : base(map, lineCode) {
            map.OnMarkerEnter += new MarkerEnter(map_OnMarkerEnter);
            map.OnMarkerLeave += new MarkerLeave(map_OnMarkerLeave);
            map.OnMapZoomChanged += new MapZoomChanged(map_OnMapZoomChanged);
            this.Markers.CollectionChanged += new GMap.NET.ObjectModel.NotifyCollectionChangedEventHandler(Markers_CollectionChanged);
            control = map;
        }

        void Markers_CollectionChanged(object sender, GMap.NET.ObjectModel.NotifyCollectionChangedEventArgs e) {
            firstload = true;
        }
        private bool markervisible=true;
        private bool firstload = true;
        private bool showMarker = true;

        public bool ShowMarker {
            get { return showMarker; }
            set { showMarker = value; }
        }
        void map_OnMapZoomChanged() {
            
            if (control.Zoom >= 14 ) {
                if (!markervisible ) {
                    markervisible = true;
                    //foreach (GMapMarker marker in Markers) {
                    //    marker.IsVisible = true;
                    //}
                    //int count = 0;
                    //foreach (IText marker in Markers) {
                    //    marker.ShowText = count % 3 == 0 ? true : false;
                    //    count++;
                    //}
                }
            } else {
                if (markervisible || firstload) {
                    firstload=markervisible=false;
                    
                    //foreach (GMapMarker marker in Markers) {
                    //    marker.IsVisible = false;
                    //}
                }

            }
        }
        
        void map_OnMarkerLeave(GMapMarker item) {
            if (item.Overlay == this)
                selectedMarker = null;
        }

        void map_OnMarkerEnter(GMapMarker item) {

            if (item.Overlay == this)
                selectedMarker = item;
        }
        /// <summary>
        /// 创建线路层
        /// </summary>
        /// <param name="map"></param>
        /// <param name="lineCode"></param>
        /// <returns></returns>
        public static LineOverlay CreateLine(GMapControl map, string lineCode,string lineName){
            LineOverlay lay = new LineOverlay(map, lineCode);
            List<PointLatLng> points=new List<PointLatLng>();
            if (lineCode.Substring(3, 1) == "3") {
                MapBuilder.Build35kVLines(ref lay, lineCode);
            } else {
                MapBuilder.Build10kVLines(ref lay, lineCode);
            }
            return lay;
        }
        public static LineOverlay CreateLine(GMapControl map, PS_xl xl){

            LineOverlay lay = CreateLine(map, xl.LineCode, xl.LineName);
            GMapRoute route = lay.Routes[0];
            if (route.Points.Count > 0)
                CreateLineSub(route, null);
            return lay;
        }
        private static void CreateLineSub(GMapRoute r,DataRow[] rows){
             

        }
        public static LineOverlay CreateTQLine(GMapControl map, string tqCode, string tqName) {
            LineOverlay lay = new LineOverlay(map, tqCode);
            if (tqCode.StartsWith("tq"))
                tqCode = tqCode.Substring(2);
            MapBuilder.BuildTQLines(ref lay,tqCode, tqName);

            return lay;
        }
        public void OnMarkerChanged(GMapMarker marker) {
            GMapMarkerVector markerv = marker as GMapMarkerVector;
            if (markerv.Route != null) {
                markerv.Route.UpdateRoutePostion(markerv);
                control.UpdateRouteLocalPosition(markerv.Route);
            }
        }
        protected override void DrawRoutes(System.Drawing.Graphics g) {
            base.DrawRoutes(g);
        }
        public override void Render(System.Drawing.Graphics g) {
            bool flag=control.MarkersEnabled;
            if (firstload) {
                map_OnMapZoomChanged();
            }

            base.Render(g);
            control.MarkersEnabled = flag;
        }
        public void Update(GMapMarker marker) {
            PS_gt gt = marker.Tag as PS_gt;
            if (gt != null) {
                gt.gtLat = (decimal)marker.Position.Lat;
                gt.gtLon = (decimal)marker.Position.Lng;
                Client.ClientHelper.PlatformSqlMap.Update("UpdatePS_gtLatLng", gt);
            } else if(marker.Tag is sd_gt) {
                sd_gt gt2 = marker.Tag as sd_gt;
                gt2.gtLat = (decimal)marker.Position.Lat;
                gt2.gtLon = (decimal)marker.Position.Lng;
                string sql = string.Format("update sd_gt set gtlat={0},gtlon={1} where gtid='{2}'", gt2.gtLat, gt2.gtLon,gt2.gtID);
                Client.ClientHelper.PlatformSqlMap.Update("Update", sql);
            }
        }
        public virtual ContextMenu CreatePopuMenu() {
            GMapMarkerVector mv = selectedMarker as GMapMarkerVector;
            ContextMenu menu = new ContextMenu();
            if (mv != null) menu = mv.CreatePopuMenu();
            return menu;
            

        }

       
        public void ShowDialog(GMapMarker marker) {
            if (marker.Tag is sd_gt) {

                ShowDialogSD(marker);
                return;
            }
            frmgtEdit frm = new frmgtEdit();            
            PS_gt gt0 = marker.Tag as PS_gt;
            GMapMarkerVector pm = (marker as GMapMarkerVector).ParentMarker;
            if (pm != null) {
                gt0.gtSpan = (decimal)Math.Round(control.Manager.GetDistance(pm.Position, marker.Position)*1000, 1);
            }
            PS_gt gt2 = new PS_gt();
            Ebada.Core.ConvertHelper.CopyTo(gt0, gt2);
            frm.RowData =  gt2;
            frm.ShowTab2 = true;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK && allowEdit) {
                Ebada.Core.ConvertHelper.CopyTo(frm.RowData, gt0);
                PS_gt gt = gt0;
                PS_Image image = frm.GetPS_Image();
                if (frm.GetImage() != null) {
                    if (gt.ImageID == "" || image == null) {
                        image = new PS_Image();
                        image.ImageName = "杆塔照片";
                        image.ImageType = "gt";
                        image.ImageData = (byte[])frm.GetImage();
                        gt.ImageID = image.ImageID;
                        Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(image, gt, null);
                    } else {

                        Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(null, new object[] { gt, image }, null);
                    }

                } else {
                    Client.ClientHelper.PlatformSqlMap.Update<PS_gt>(gt);
                }
                
                marker.Position = new PointLatLng((double)gt.gtLat, (double)gt.gtLon);
                OnMarkerChanged(marker as GMapMarkerVector);
            }
        }
        public void ShowDialogSD(GMapMarker marker) {

            frmsdgtEdit frm = new frmsdgtEdit();
            sd_gt gt0 = marker.Tag as sd_gt;
            GMapMarkerVector pm = (marker as GMapMarkerVector).ParentMarker;
            if (pm != null) {
                gt0.gtSpan = (decimal)Math.Round(control.Manager.GetDistance(pm.Position, marker.Position) * 1000, 1);
            }
            sd_gt gt2 = new sd_gt();
            Ebada.Core.ConvertHelper.CopyTo(gt0, gt2);
            frm.RowData = gt2;
            frm.ShowTab2 = true;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK && allowEdit) {
                Ebada.Core.ConvertHelper.CopyTo(frm.RowData, gt0);
                sd_gt gt = gt0;
                PS_Image image = frm.GetPS_Image();
                if (frm.GetImage() != null) {
                    if (gt.ImageID == "" || image == null) {
                        image = new PS_Image();
                        image.ImageName = "杆塔照片";
                        image.ImageType = "gt";
                        image.ImageData = (byte[])frm.GetImage();
                        gt.ImageID = image.ImageID;
                        Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(image, gt, null);
                    } else {

                        Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(null, new object[] { gt, image }, null);
                    }

                } else {
                    Client.ClientHelper.PlatformSqlMap.Update<sd_gt>(gt);
                }

                marker.Position = new PointLatLng((double)gt.gtLat, (double)gt.gtLon);
                OnMarkerChanged(marker as GMapMarkerVector);
            }
        }
        public void ShowDialog(string type,GMapMarker marker) {
            if (type == "jcky") {//交叉跨跃
                PS_gt gt = selectedMarker.Tag as PS_gt;
                Ebada.Scgl.Sbgl.UCPS_jcky jcky = new UCPS_jcky();
                jcky.ParentObj = gt;
                DevExpress.XtraEditors.XtraForm dlg = new DevExpress.XtraEditors.XtraForm();
                dlg.Controls.Add(jcky);
                jcky.Dock = DockStyle.Fill;
                jcky.HideList();
                dlg.Size = new System.Drawing.Size(800, 600);
                dlg.StartPosition = FormStartPosition.CenterScreen;
                dlg.Text = "交叉跨越-" + gt.gth;
                dlg.ShowDialog();
            } else {
                MessageBox.Show("此功能正在开发中。。。");
            }
        }
        
        public void ShowLineinfo(GMapMarker selectedMarker) {
            if (selectedMarker.Tag is sd_gt) {
                ShowLineinfoSD(selectedMarker);
            } else {
                PS_gt gt = selectedMarker.Tag as PS_gt;
                string linecode = gt.gtCode.Substring(0, gt.gtCode.Length - 4);
                PS_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>("where linecode='" + linecode + "'");
                if (xl != null) {
                    frmxlEdit dlg = new frmxlEdit();
                    dlg.RowData = xl;
                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK && allowEdit) {
                        Client.ClientHelper.PlatformSqlMap.Update<PS_xl>(dlg.RowData);
                    }
                }
            }

        }
        public void ShowLineinfoSD(GMapMarker selectedMarker) {
            sd_gt gt = selectedMarker.Tag as sd_gt;
            string linecode = gt.gtCode.Substring(0, gt.gtCode.Length - 4);
            sd_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<sd_xl>("where linecode='" + linecode + "'");
            if (xl != null) {
                frmsdxlEdit dlg = new frmsdxlEdit();
                dlg.RowData = xl;
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK && allowEdit) {
                    Client.ClientHelper.PlatformSqlMap.Update<sd_xl>(dlg.RowData);
                }
            }

        }
        public void ShowLineSB(GMapMarker selectedMarker)
        {
            PS_gt gt = selectedMarker.Tag as PS_gt;
            string linecode = gt.gtCode.Substring(0, gt.gtCode.Length - 4);
            PS_xl xl = Client.ClientHelper.PlatformSqlMap.GetOne<PS_xl>("where linecode='" + linecode + "'");
            if (xl != null)
            {
                frmXLSbtj dlg = new frmXLSbtj();
                dlg.SetXL(xl);
                dlg.ShowDialog();
            }
        }
        #region IDisposable 成员

        public void Dispose() {
            control.OnMarkerEnter -= map_OnMarkerEnter;
            control.OnMarkerLeave -= map_OnMarkerLeave;            
        }

        #endregion

        internal void ShowLineTT(GMapMarkerVector selectedMarker) {
            PS_gt gt = selectedMarker.Tag as PS_gt;
            string linecode = gt.gtCode.Substring(0, gt.gtCode.Length - 4);
            UCMapLayer.ShowTT(linecode);
        }

        #region ILineInfo 成员
        bool loadline = false;
        public bool IsLoad {
            get {
                return loadline;
            }
            set {
                loadline=value;
            }
        }

        #endregion
    }
}
