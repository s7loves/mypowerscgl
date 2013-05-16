﻿using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Drawing;
using GMap.NET;
using Ebada.Scgl.Model;
using System.Windows.Forms;

namespace Ebada.Scgl.Gis.Markers {
    [Serializable]
    internal class GMapMarkerBDZ : GMapMarkerVector {
        
        private Font mFont;
        private string drawtype="rect";

        public string Drawtype {
            get { return drawtype; }
            set { drawtype = value; }
        }
        public GMapMarkerBDZ(PointLatLng p)
            : base(p) {
            Size = SizeSt = new Size(20, 20);
            Offset = new Point(-10, -10);
            Text = string.Empty;
            mFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
        }
        public override void OnRender(Graphics g) {
            System.Drawing.Point p1 = new System.Drawing.Point(LocalPosition.X, LocalPosition.Y);
            //new Pen(Color.FromArgb(144, Color.MidnightBlue));
            Rectangle r = new Rectangle(p1, SizeSt);
            Point pt1 = new Point(r.Left + r.Width / 2,r.Top);
            Point pt2 = new Point(r.Left, r.Bottom);
            Point pt3 = new Point(r.Right, r.Bottom);
            Pen p =new Pen(Color.Blue,2);
            g.FillRectangle(Brushes.White, r);
            g.DrawRectangle(p, r);
            g.FillPolygon(Brushes.Blue, new Point[3] { pt1, pt2, pt3 });
            
            //g.FillEllipse(Brushes.White, r);
            //g.DrawEllipse(Pen, r);
            if (!string.IsNullOrEmpty(Text)) {
                Size sf = g.MeasureString(Text, mFont).ToSize();

                g.DrawString(Text, mFont, Brushes.MidnightBlue, LocalPosition.X + 10 - sf.Width / 2, LocalPosition.Y + 30);
            }
        }

        internal override void Update() {
            PointOverLay lay = this.Overlay as PointOverLay;
            if (lay != null && lay.AllowEdit) {
                mOrg org = this.Tag as mOrg;
                org.C3 = this.Position.Lat.ToString();
                org.C2 = this.Position.Lng.ToString();
                Client.ClientHelper.PlatformSqlMap.Update<mOrg>(org);
            }
        }

        public override ContextMenu CreatePopuMenu() {
            ContextMenu contextMenu = new ContextMenu();
            MenuItem item = new MenuItem();
            item.Text = "变电所属性";
            item.Click += new EventHandler(属性_Click);
            contextMenu.MenuItems.Add(item);
            item = new MenuItem();
            item.Text = "变电所一次系统图";
            item.Click += new EventHandler(一次系统图_Click);
            contextMenu.MenuItems.Add(item);
            return contextMenu;
        }

        void 属性_Click(object sender, EventArgs e) {

            frmBdsEdit dlg = new frmBdsEdit();

            dlg.RowData = this.Tag;
            if (dlg.ShowDialog() == DialogResult.OK) {
                Client.ClientHelper.PlatformSqlMap.Update<mOrg>(dlg.RowData);
            }
        }
        void 一次系统图_Click(object sender, EventArgs e) {

            //显示一次系统图
        }
    }
}
