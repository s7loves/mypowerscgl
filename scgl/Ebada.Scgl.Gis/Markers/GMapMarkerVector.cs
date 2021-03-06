﻿using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Drawing;
using GMap.NET;
using System.Windows.Forms;

namespace Ebada.Scgl.Gis.Markers {

    [Serializable]
    public class GMapMarkerVector : GMapMarker,ICloneable, IText, IEditable {

        public float? Bearing;

        public System.Drawing.Size SizeSt = new Size(4, 4);
        public Pen Pen;
        private List<GMapMarkerVector> items;
        private GMapMarkerVector parentMarker;
        private string id;
        private PointRoute route;
        private string text;
        private bool showText;
        private Font font;
        private MarkerEnum markerType= MarkerEnum.none;
        private object ownerLine;//所在线路
        public PointPolygon Polygon ;
        public object OwnerLine {
            get { return ownerLine; }
            set { ownerLine = value; }
        }
        public MarkerEnum MarkerType {
            get { return markerType; }
            set { markerType = value; }
        }
        public virtual Font Font {
            get { return font; }
            set { font = value; }
        }
        public bool ShowText {
            get { return showText; }
            set { showText = value; }
        }

        public virtual string Text {
            get {
                
                return text; 
            }
            set {
                if (value == text) return;
                text = value; 
            }
        }
        public PointRoute Route {
            get { return route; }
            set { route = value; }
        }
        public string Id {
            get { return id; }
            set { id = value; }
        }
        public GMapMarkerVector NextMarker {
            get {
                GMapMarkerVector next = null;
                if (items.Count > 0)
                    next=items[0];
                return next; 
            }
            set {
                if (value==null||items.Contains(value)) return;
                items.Add(value);
            }
        }
        public GMapMarkerVector ParentMarker {
            get { return parentMarker; }
            set { parentMarker = value; }
        }
        public GMapMarkerVector(PointLatLng p)
            : base(p) {
            Size = SizeSt;
            Offset = new Point(-2, -2);
            Pen = new Pen(Color.Blue, 1);
            items = new List<GMapMarkerVector>();
            font = new Font("宋体", 9);
        }
        public override void OnRender(Graphics g) {
            //g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            System.Drawing.Point p1 = new System.Drawing.Point(LocalPosition.X, LocalPosition.Y);

            Rectangle r = new Rectangle(p1, SizeSt);
            g.FillEllipse(Brushes.White, r);
            g.DrawEllipse(Pen, r);
            if (showText && !string.IsNullOrEmpty(Text)) {

                g.DrawString(Text,font , Brushes.Blue, r.Right + 3, r.Top - 3);
            }
        }
        /// <summary>
        /// 绘制表箱
        /// </summary>
        /// <param name="g"></param>
        private void drawbx(Graphics g) {

        }
        void 线路属性_Click(object sender, EventArgs e) {
            (this.Overlay as LineOverlay).ShowLineinfo(this);
        }

        void 杆塔属性_Click(object sender, EventArgs e) {
            (this.Overlay as LineOverlay).ShowDialog(this);
        }
        void 线路条图_Click(object sender, EventArgs e) {
            (this.Overlay as LineOverlay).ShowLineTT(this);
        }
        void 交叉跨越_Click(object sender, EventArgs e) {
            (this.Overlay as LineOverlay).ShowDialog("jcky",this);
        }
        void 线路设备统计_Click(object sender, EventArgs e) {         
            (this.Overlay as LineOverlay).ShowLineSB(this);
        }
        public virtual ContextMenu CreatePopuMenu() {
           
            ContextMenu contextMenu = new ContextMenu();
            MenuItem item = new MenuItem();
            item.Text = "杆塔属性";
            item.Click += new EventHandler(杆塔属性_Click);
            contextMenu.MenuItems.Add(item);
            item = new MenuItem();
            item.Text = "线路属性";
            item.Click += new EventHandler(线路属性_Click);
            contextMenu.MenuItems.Add(item);
            item = new MenuItem();
            item.Text = "交叉跨越";
            item.Click += new EventHandler(交叉跨越_Click);
            contextMenu.MenuItems.Add(item);
            if (this.Tag is Ebada.Scgl.Model.PS_gt) {
                item = new MenuItem();
                item.Text = "线路条图";
                item.Click += new EventHandler(线路条图_Click);
                contextMenu.MenuItems.Add(item);
                
                item = new MenuItem();
                item.Text = "统计线路设备";
                item.Click += new EventHandler(线路设备统计_Click);
                contextMenu.MenuItems.Add(item);
            }
            return contextMenu;
        }

        
        public virtual void Update() {
            if (this.Overlay is IUpdateable && allowEdit)
                (this.Overlay as IUpdateable).Update(this);
        }

        #region ICloneable 成员

        public object Clone() {
            return null;
        }

        #endregion

        private bool allowEdit = true;
        public virtual bool AllowEdit {
            get {
                return allowEdit;
            }
            set {
                allowEdit = value;
            }
        }
    }
}
