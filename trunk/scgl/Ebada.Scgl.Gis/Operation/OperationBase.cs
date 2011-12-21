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
        protected Point endPoint;
        protected Point localPoint;
        private GMapOverlay curOverlay;        
        protected Boolean canAddMarker;
        protected Boolean canEditMarker;
        protected GMapMarker updateMarker;
        protected ContextMenu mMenu;
        private bool isMoving;
        public OperationBase(RMap mapcontrol){
            rMap1 = mapcontrol;
            mMenu = CreatePopuMenu();
            canEditMarker = true;
        }
        #region 属性
        protected GMapOverlay CurOverlay {
            get { return curOverlay; }
            set { curOverlay = value; }
        }
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
            if (e.Button == MouseButtons.Left && isMouseDown) {
                isMouseDown = false;
                if (updateMarker != null && updateMarker is GMapMarkerVector) {
                    (updateMarker as GMapMarkerVector).Update();
                }
            } else if (e.Button == MouseButtons.Right && isMoving) {
                endPoint = e.Location;
                //moveMap();
                isMoving = false;

            }
        }
        private double GetDistance(Point p1, Point p2) {
            return GetDistance(p1.X, p1.Y, p2.X, p2.Y);
        }
        private double GetDistance(int A_x, int A_y, int B_x, int B_y) {
            int x = System.Math.Abs(B_x - A_x);
            int y = System.Math.Abs(B_y - A_y);
            return Math.Sqrt(x * x + y * y);
        } 

        bool beginMove = false;
        private void moveMap() {
            int len=(int)GetDistance(beginPoint, endPoint);
            if ( len< 10) return;
            int x0 = 10 * (endPoint.X - beginPoint.X) / len;
            int y0 = 10 * (endPoint.Y - beginPoint.Y) / len;
            beginMove=true;
            MethodInvoker m = delegate {
                int t = 0;
                int b = 0;
                int c = 10;
                int d = 10;
                GPoint gp = rMap1.FromLatLngToLocal(rMap1.Position);
                rMap1.debugMsg = "";
                while (beginMove) {
                    int offx = (int)Math.Ceiling(Ebada.Scgl.Core.Easing.GetTween(t, b, x0, d, Ebada.Scgl.Core.Easing.Mode.linear));
                    int offy = (int)Math.Ceiling(Ebada.Scgl.Core.Easing.GetTween(t, b, y0, d, Ebada.Scgl.Core.Easing.Mode.linear));
                    //rMap1.debugMsg += t + "_" + (gp.X + offx) + ",";
                    t++;
                    if (!beginMove)
                        break;
                    rMap1.Position= rMap1.FromLocalToLatLng(gp.X - offx, gp.Y-offy);
                    if (t > d)
                        break;


                    System.Threading.Thread.Sleep(20);
                }
            };
            m.BeginInvoke(null, null);

        }
        public virtual void MouseDown(object sender, MouseEventArgs e) {
            beginMove = false;
            beginPoint = new Point(e.X, e.Y);
            if (currentMarker != null && currentMarker.IsMouseOver) {
                if (currentMarker.Overlay is IUpdateable)
                   canEditMarker= (currentMarker.Overlay as IUpdateable).AllowEdit;
            }
            if (e.Button == MouseButtons.Left) {
                isMouseDown = true;
                //beginPoint = new Point(e.X, e.Y);
                if (currentMarker != null && currentMarker.IsMouseOver) {
                    selectedMarker = currentMarker;
                    GPoint p = rMap1.FromLatLngToLocal(currentMarker.Position);
                    localPoint = new Point(p.X, p.Y);

                } else
                    selectedMarker = null;
            } else if (e.Button == MouseButtons.Right) {
                if (currentMarker != null && currentMarker.IsMouseOver) {
                    selectedMarker = currentMarker;
                    if (currentMarker.Overlay is IPopuMenu)
                        (currentMarker.Overlay as IPopuMenu).CreatePopuMenu().Show(rMap1, e.Location);
                } else {
                    isMoving = true;
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
                        
                        OnMarkerChanged(currentMarker);
                        updateMarker = currentMarker;
                    }
                } 
            }
        }
        public virtual void Reset() { }

        public virtual void OnMarkerChanged(GMapMarker marker) {
            IUpdateable layer = marker.Overlay as IUpdateable;
            if (layer!=null && layer.AllowEdit) {
                layer.OnMarkerChanged(currentMarker as GMapMarkerVector);
            } else {

            }
        }
        public virtual ContextMenu CreatePopuMenu() {
            ContextMenu menu = new ContextMenu();
            //MenuItem item = new MenuItem();
            //item.Text = "杆塔属性";
            //item.Click += new EventHandler(杆塔属性_Click);
            //menu.MenuItems.Add(item);
            //item = new MenuItem();
            //item.Text = "线路属性";
            //item.Click += new EventHandler(线路属性_Click);
            //menu.MenuItems.Add(item);
            return menu;

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
