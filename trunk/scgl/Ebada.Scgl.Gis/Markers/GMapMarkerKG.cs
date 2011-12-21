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
    internal class GMapMarkerKG : GMapMarkerVector {
        
        private Font mFont;
        public GMapMarkerKG(PointLatLng p)
            : base(p) {
            Size = SizeSt = new Size(10, 6);
            Offset = new Point(-5, -3);
            Text = string.Empty;
            mFont = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold);
        }
        public override void OnRender(Graphics g) {
            System.Drawing.Point p1 = new System.Drawing.Point(LocalPosition.X, LocalPosition.Y);
            //new Pen(Color.FromArgb(144, Color.MidnightBlue));
            Rectangle r = new Rectangle(p1, SizeSt);
            g.FillRectangle(Brushes.White, r);
            g.DrawRectangle(Pen, r);
            if (!string.IsNullOrEmpty(Text)) {
                Size sf = g.MeasureString(Text, mFont).ToSize();

                g.DrawString(Text, mFont, Brushes.MidnightBlue, LocalPosition.X + 10 , LocalPosition.Y );
            }
        }

        internal override void Update() {
            
        }

        public override ContextMenu CreatePopuMenu() {
            ContextMenu contextMenu = new ContextMenu();
            MenuItem item = new MenuItem();
            item.Text = "属性";
            item.Click += new EventHandler(属性_Click);
            contextMenu.MenuItems.Add(item);
            return contextMenu;
        }

        void 属性_Click(object sender, EventArgs e) {

            PS_kg obj = this.Tag as PS_kg;
            if (obj == null) return;
            Ebada.Scgl.Sbgl.frmkgEdit dlg = new Ebada.Scgl.Sbgl.frmkgEdit();
            dlg.RowData = obj;
            if (dlg.ShowDialog() == DialogResult.OK) {
                Client.ClientHelper.PlatformSqlMap.Update<PS_kg>(dlg.RowData);
                this.Tag = dlg.RowData;
            }
        }
    }
}
