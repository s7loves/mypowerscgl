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
using System.Drawing;
namespace Ebada.Scgl.Gis {
    public class PloyLineOverLay : GMapOverlay, IUpdateable, IPopuMenu {
         
        private GMapControl control;
        private bool allowEdit;
        ContextMenu contextMenu;
        GMapMarker selectedMarker;
        public PloyLineOverLay(GMapControl map, string layid)
            : base(map, layid) {
            control = map;
            map.OnMarkerEnter += new MarkerEnter(map_OnMarkerEnter);
            map.OnMarkerLeave += new MarkerLeave(map_OnMarkerLeave);
            map.OnMapZoomChanged += new MapZoomChanged(map_OnMapZoomChanged);
        }
        private bool firstload = true;
        private int fontsize = 0;
        void map_OnMapZoomChanged() {
            
        }
        
        void map_OnMarkerLeave(GMapMarker item) {
            if (item.Overlay == this)
                selectedMarker = null;
        }

        void map_OnMarkerEnter(GMapMarker item) {
            if (item.Overlay == this)
                selectedMarker = item;
        }
        public bool AllowEdit {
            get { return allowEdit; }
            set {
                if (value != allowEdit) {
                    foreach (var item in Markers) {
                        item.IsVisible = value;
                    }
                } 
                allowEdit = value;
            }
        }
        public virtual ContextMenu CreatePopuMenu() {
            
            GMapMarkerVector mv = selectedMarker as GMapMarkerVector;
            ContextMenu menu = new ContextMenu();
            if (mv != null) menu = mv.CreatePopuMenu();
            return menu;
        }
        
        protected override void DrawRoutes(System.Drawing.Graphics g) {
            base.DrawRoutes(g);
        }
        public override void Render(System.Drawing.Graphics g) {
            
            base.Render(g);
            
        }
        private string pointstostring() {
            StringBuilder sb = new StringBuilder();
            
            foreach (var item in Markers) {
                sb.Append(Math.Round(item.Position.Lng,6).ToString()+" "+Math.Round(item.Position.Lat,6).ToString()+"," );
            }
            return sb.ToString();
        }
        public void Update(GMapMarker marker) {
            GMapMarkerPoint p = marker as GMapMarkerPoint;
            if (p != null && p.Polygon!=null && p.Polygon.Tag is TX_Polygon) {
                (p.Polygon.Tag as TX_Polygon).Points = pointstostring();
                Client.ClientHelper.PlatformSqlMap.Update<TX_Polygon>(p.Polygon.Tag);
            }
        }
        public virtual void OnMarkerChanged(GMapMarker marker) {
            GMapMarkerVector markerv = marker as GMapMarkerVector;
            if (markerv.Polygon != null) {
                markerv.Polygon.UpdateRoutePostion(markerv);
                control.UpdatePolygonLocalPosition(markerv.Polygon);
            }
        }
    }
}
