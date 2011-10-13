using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Windows.Forms;
using Ebada.Scgl.Gis.Markers;
using System.Drawing;
using GMap.NET;

namespace Ebada.Scgl.Gis {
    internal class OperationBase {
        protected RMap rMap1;
        protected GMapMarker currentMarker;
        protected Boolean isMouseDown;
        protected GMapMarker selectedMarker;
        protected Point beginPoint;
        protected Point localPoint;
        protected GMapOverlay routes;
        protected Boolean canAddMarker;
        protected Boolean canEditMarker;
        protected GMapMarker updateMarker;
        protected ContextMenu mMenu;
        public OperationBase(RMap mapcontrol){
            rMap1 = mapcontrol;
            //routes = new GMapOverlay(rMap1, "Line");
            mMenu = CreatePopuMenu();
            canEditMarker = true;
        }
        #region 属性
        public Boolean CanEditMarker {
            get { return canEditMarker; }
            set { canEditMarker = value; }
        }
        #endregion
        void rMap1_Paint(object sender, PaintEventArgs e) {
            OnPaint(e.Graphics);
        }
        public virtual void OnMarkerLeave(GMapMarker item) {
            if (!isMouseDown && currentMarker == item)
                currentMarker = null;
        }

        public virtual void OnMarkerEnter(GMapMarker item) {
            if (!isMouseDown)
                currentMarker = item;
        }
        public virtual void OnPaint(Graphics g) {

        }
        public virtual void MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                isMouseDown = false;
                if (updateMarker != null && updateMarker is GMapMarkerVector) {
                    (updateMarker as GMapMarkerVector).Update();
                }
            }
        }
        public virtual void MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                isMouseDown = true;
                beginPoint = new Point(e.X, e.Y);
                if (currentMarker != null && currentMarker.IsMouseOver) {
                    selectedMarker = currentMarker;
                    GPoint p= rMap1.FromLatLngToLocal(currentMarker.Position);
                    localPoint = new Point(p.X, p.Y);
                    routes = currentMarker.Overlay;
                } else
                    selectedMarker = null;
            } else if (e.Button == MouseButtons.Right) {
                if (currentMarker != null && currentMarker.IsMouseOver) {
                    selectedMarker = currentMarker;

                    mMenu.Show(rMap1, e.Location);
                } 
            }
        }

        // move current marker with left holding
        public virtual void MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left && isMouseDown) {
                if (currentMarker != null) {
                    if (currentMarker.IsVisible && canEditMarker) {
                        Point p0 = localPoint;
                        Point p1 = new Point(p0.X + e.X - beginPoint.X, p0.Y + e.Y - beginPoint.Y);
                        currentMarker.Position = rMap1.FromLocalToLatLng(p1.X, p1.Y);
                        if (currentMarker.Overlay is LineOverlay) {
                            (currentMarker.Overlay as LineOverlay).OnMarkerChanged(currentMarker as GMapMarkerVector);

                        } else {
                            OnMarkerChanged(currentMarker);
                        }
                        updateMarker = currentMarker;
                    }
                } 
            }
        }
        public virtual void Reset() { }

        public virtual void OnMarkerChanged(GMapMarker marker) {

        }
        public virtual ContextMenu CreatePopuMenu() {
            ContextMenu menu = new ContextMenu();
            MenuItem item = new MenuItem();
            item.Text = "杆塔属性";
            item.Click += new EventHandler(杆塔属性_Click);
            menu.MenuItems.Add(item);
            item = new MenuItem();
            item.Text = "线路属性";
            item.Click += new EventHandler(线路属性_Click);
            menu.MenuItems.Add(item);
            return menu;

        }

        void 线路属性_Click(object sender, EventArgs e) {
            if (selectedMarker != null && selectedMarker.Overlay is LineOverlay) {
                (selectedMarker.Overlay as LineOverlay).ShowLineinfo(selectedMarker, canEditMarker);
            }
        }

        void 杆塔属性_Click(object sender, EventArgs e) {

            if (selectedMarker != null && selectedMarker.Overlay is LineOverlay) {
                (selectedMarker.Overlay as LineOverlay).ShowDialog(selectedMarker,canEditMarker);
            }
                
        }
        GMapMarker createMarker(PointLatLng pos) {
            GMapMarkerVector marker = new GMapMarkerVector(pos);
            marker.Pen = new Pen(Color.FromArgb(144, Color.MidnightBlue), 2);
            marker.IsHitTestVisible = true;
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            return marker;
        }
    }
}
