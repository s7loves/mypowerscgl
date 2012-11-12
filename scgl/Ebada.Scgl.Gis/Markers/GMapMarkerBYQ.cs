using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Drawing;
using GMap.NET;
using Ebada.Scgl.Model;
using System.Windows.Forms;

namespace Ebada.Scgl.Gis.Markers {
    [Serializable]
    internal class GMapMarkerBYQ : GMapMarkerVector {
        
        private Font mFont;
        public GMapMarkerBYQ(PointLatLng p)
            : base(p) {
            Size=SizeSt = new Size(15, 10);
            Offset = new Point(-7, -5);
            Text = string.Empty;
            mFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
        }
        public override void OnRender(Graphics g) {
            System.Drawing.Point p1 = new System.Drawing.Point(LocalPosition.X, LocalPosition.Y);
            //new Pen(Color.FromArgb(144, Color.MidnightBlue));
            Rectangle r = new Rectangle(p1.X,p1.Y,10,10);
            Rectangle r2 = new Rectangle(p1.X+5, p1.Y, 10, 10);
            //g.FillEllipse(Brushes.White, r);
            //g.FillEllipse(Brushes.White, r2);
            g.DrawEllipse(Pens.Blue, r);
            g.DrawEllipse(Pens.Blue, r2);
            if (ShowText && !string.IsNullOrEmpty(Text)) {
                Size sf=g.MeasureString(Text, mFont).ToSize();

                g.DrawString(Text, mFont, Brushes.Black, LocalPosition.X+7  - sf.Width / 2, LocalPosition.Y - 15);
            }
        }
        
        internal override void Update() {
            if (Tag is TX_Point) {
                TX_Point pt = Tag as TX_Point;
                pt.x = this.Position.Lng.ToString();
                pt.y = this.Position.Lat.ToString();
                pt.Text = this.Text;
                TX_PointHelper.Update(pt);
            } else if (Tag is string) {
                TX_Point pt = new TX_Point();
                pt.x = this.Position.Lng.ToString();
                pt.y = this.Position.Lat.ToString();
                pt.Text = this.Text;
                pt.Type = "byqobject";
                pt.LayerID = this.Overlay.Id;
                pt.ID = Tag.ToString();
                TX_PointHelper.Create(pt);

                this.Tag = pt;
            }
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
            PS_tqbyq byq=null;
            if (this.Tag is string) {
                 byq= Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_tqbyq>(this.Tag);
            } else if (this.Tag is TX_Point) {
                TX_Point tp = this.Tag as TX_Point;

                byq = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_tqbyq>(tp.ID);
            }
            if (byq == null) return;
            Ebada.Scgl.Sbgl.frmtqbyqEdit dlg = new Ebada.Scgl.Sbgl.frmtqbyqEdit();
            dlg.RowData = byq;
            if (dlg.ShowDialog() == DialogResult.OK) {
                Client.ClientHelper.PlatformSqlMap.Update<PS_tqbyq>(dlg.RowData);
            }
        }
    }
}
