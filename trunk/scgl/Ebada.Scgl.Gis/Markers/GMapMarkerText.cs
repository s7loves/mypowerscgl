﻿using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Drawing;
using GMap.NET;
using System.Windows.Forms;

namespace Ebada.Scgl.Gis.Markers {
    [Serializable]
    internal class GMapMarkerText : GMapMarkerVector {
        
        public GMapMarkerText(PointLatLng p)
            : base(p) {
            Size = SizeSt = new Size(20, 20);
            Offset = new Point(-10, -10);
            Text = string.Empty;
        }
        public override Font Font {
            get {
                return base.Font;
            }
            set {
                base.Font = value;
                MeasureRect();
            }
        }
        public override string Text {
            get {
                return base.Text;
            }
            set {
                if(base.Text == value) return;
                base.Text = value;
                MeasureRect();
            }
        }
        private void MeasureRect() {
            Size = SizeSt = new Control().CreateGraphics().MeasureString(Text, Font).ToSize();

            Offset = new Point(-Size.Width / 2, -Size.Height / 2);
        }
        public override void OnRender(Graphics g) {

            //g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            
            System.Drawing.Point p1 = new System.Drawing.Point(LocalPosition.X, LocalPosition.Y);

            //Rectangle r = new Rectangle(p1, SizeSt);
            //g.DrawRectangle(Pen, r);

            g.DrawString(Text, Font, Brushes.Black, p1);
        }
        public override ContextMenu CreatePopuMenu() {
            ContextMenu contextMenu = new ContextMenu();
            MenuItem item = new MenuItem();
            item.Text = "文字属性";
            item.Click += new EventHandler(属性_Click);
            contextMenu.MenuItems.Add(item);
            return contextMenu;
        }

        void 属性_Click(object sender, EventArgs e) {
            frmText dlg = new frmText();
            dlg.MarkerText = this.Text;
            if (dlg.ShowDialog() == DialogResult.OK) {
                Text = dlg.MarkerText;

            }
            
        }
    }
}
