/**********************************************
系统:地理信息
模块:
作者:Rabbit
创建时间:2011-9-4
最后一次修改:2011-9-4
***********************************************/
namespace Ebada.Scgl.Gis {
    using System.Windows.Forms;
    using GMap.NET.WindowsForms;
    using System.Drawing;
    using System;
    using GMap.NET;
    using Ebada.Scgl.Gis.Markers;
    using System.Collections;
    using System.Data;
    using System.Collections.Generic;
    /// <summary>
    /// custom map of GMapControl
    /// </summary>
    public class RMap : GMapControl, IMapView {
        public long ElapsedMilliseconds;
        public PointOverLay bdzLayer;

#if DEBUG
        private int counter;
        readonly Font DebugFont = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Regular);
#endif
        public RMap()
            : base() {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            //if(!SelectedArea.IsEmpty)
            //    e.Graphics.DrawRectangle(SelectionPen,
        }
        /// <summary>
        /// any custom drawing here
        /// </summary>
        /// <param name="drawingContext"></param>
        protected override void OnPaintOverlays(System.Drawing.Graphics g) {
            base.OnPaintOverlays(g);

#if DEBUG
            //g.DrawString(string.Format("lat：{0},lon:{1}", this.Position.Lat, this.Position.Lng), DebugFont, Brushes.Red, 36, 36);
            //g.DrawString("render: " + counter++ + ", load: " + ElapsedMilliseconds + "ms", DebugFont, Brushes.Blue, 36, 36);
            g.DrawString(debugMsg, DebugFont, Brushes.Blue, 36, 36);
#endif
            if (!MapBounds.IsEmpty) {
                GPoint p1 = FromLatLngToLocal(MapBounds.LocationTopLeft);
                GPoint p2 = FromLatLngToLocal(MapBounds.LocationRightBottom);
                Font font=new Font(FontFamily.GenericSansSerif,30, FontStyle.Bold);
                SizeF fs =g.MeasureString(MapTitle,font);
                int x1 = p1.X;
                int y1 = p1.Y;
                int x2 = p2.X;
                int y2 = p2.Y;
                Rectangle r1 = new Rectangle(x1, y1-(int)fs.Height, x2 - x1, y2 - y1+(int)fs.Height);
                tableHeight =(int) (Font.GetHeight(g) * (sbTable.Rows.Count+1));
                tableWidth = 60 * 3;
                tableRect = new RectangleF(r1.Right, r1.Top +fs.Height, tableWidth, tableHeight);
                r1.Width += tableWidth;
                r1.Height =(int) Math.Max(r1.Height, 2 * fs.Height + tableHeight);
                Rectangle r2 = r1;
                r2.Inflate(5, 5);
                Point p3 = new Point(r1.Left + (r1.Width - (int)fs.Width)/2, r1.Top + 5);
                g.DrawString(MapTitle, font, Brushes.Black, p3);
                g.DrawRectangle(penin, r1);
                g.DrawRectangle(penout, r2);
                tableRect.Y = r1.Bottom - tableRect.Height-1;
                drawsbtjInfo(g, tableRect.Location);
            }
        }
        RectangleF tableRect = Rectangle.Empty;
        private Pen penin = new Pen(Color.Black, 2);
        private Pen penout = new Pen(Color.Black, 4);
        public GMap.NET.RectLatLng MapBounds = RectLatLng.Empty;
        public string debugMsg = "";
        public string MapTitle = "";
        private void InitializeComponent() {
            
            this.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            //MapScaleInfoEnabled = true;
            initOverlay();
        }
        private void initOverlay() {
            bdzLayer = new PointOverLay(this, "bdz");
            bdzLayer.Text = "变电所";
            this.Overlays.Add(bdzLayer);
        }
        protected override void OnDoubleClick(EventArgs e) {
            base.OnDoubleClick(e);
            //测试
            //Point pt =this.PointToClient(new Point( MousePosition.X,MousePosition.Y));
            ////createMarker(rMap1.FromLocalToLatLng(pt.X, pt.Y));
            //frmText dlg = new frmText();
            //if (dlg.ShowDialog() == DialogResult.OK) {
            //    GMapMarkerText marker = new GMapMarkerText(this.FromLocalToLatLng(pt.X, pt.Y));
            //    marker.Text = dlg.MarkerText;
            //    bdzLayer.Markers.Add(marker);
            //}
        }
        public GMapOverlay FindOverlay(string id) {
            GMapOverlay lay = null;
            foreach (GMapOverlay item in Overlays) {
                if (item.Id == id) {
                    lay = item;
                    break;

                }
            }

            return lay;
        }

        #region IMapView 成员

        public void Zoomin() {
            Zoom -= 1;
        }

        public void Zoomout() {
            Zoom += 1;
        }

        public void Roam() {

        }

        public void Fly() {
            throw new NotImplementedException("功能正在开发。。。");
        }

        public void Distance() {
            throw new NotImplementedException("功能正在开发。。。");
        }

        public void FullView() {
            Zoom = 9;
            Position = new PointLatLng(46.63, 126.98);
        }

        #endregion

        internal GMapMarker FindMarker(Ebada.Scgl.Model.mOrg obj) {
            GMapMarkerBDZ marker =null;
            foreach (GMapMarkerBDZ bdz in bdzLayer.Markers) {
                if (bdz.Id == obj.OrgCode) {
                    marker = bdz;
                    break;
                }
            }
            if (marker == null) {
                //新建
                double d1=this.Position.Lat;
                double d2 =this.Position.Lng;
                double.TryParse(obj.C1, out d1);
                double.TryParse(obj.C2, out d2);
                if (d1 == 0 || d2 == 0)
                    marker = new GMapMarkerBDZ(Position);
                else
                    marker = new GMapMarkerBDZ(new PointLatLng(d1, d2));
                marker.Tag = obj;
                marker.Id = obj.OrgCode;
                marker.Text = obj.OrgName;
                marker.ToolTipText = obj.OrgName;
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                bdzLayer.Markers.Add(marker);
            }
            return marker;
        }

        internal void RefreshOverlay(string p) {

            GMapOverlay layer = FindOverlay(p);

            if (p.Length >= 6) {
                bool flag = false;
                if (layer != null) {
                    this.Overlays.Remove(layer);
                    flag = (layer as IUpdateable).AllowEdit;
                }

                layer= FindCreateLine(p);
                (layer as IUpdateable).AllowEdit = flag;
            }
        }

        internal void LocationOverlay(string p) {
            GMapOverlay layer= FindOverlay(p);
            if (layer != null)
                this.ZoomAndCenterRoutes(p);
        }

        internal GMapOverlay FindCreateLine(string lineCode) {

            GMapOverlay lay = FindOverlay(lineCode);
            if (lay == null) {
                if (lineCode.Length == 10)
                    lay = LineOverlay.CreateTQLine(this, lineCode, "");
                else
                    lay = LineOverlay.CreateLine(this, lineCode, "");

                this.Overlays.Add(lay);
                
            }
            return lay;
        }
        #region 设备统计信息
        /// <summary>
        /// 创建设备统计层
        /// </summary>
        private GMapOverlay getSbtjLay(string p) {
            GMapOverlay tjlay = null;
            string id= "sbtj"+p;
            foreach (GMapOverlay lay in Overlays) {
                if (lay.Id == id) {
                    tjlay = lay; break;
                }
            }
            if (tjlay == null) {
                tjlay = new GMapOverlay(this, id);
            }
            return tjlay;
        }
        DataTable sbTable;
        int tableHeight = 0;
        int tableWidth = 0;
        class sbrow {
            public string zl;
            public string xh;
            public int sl;
            public object[] DataArray {
                get { return new object[] {zl,xh,sl }; }
            }
        }
        Dictionary<string, sbrow> sbrows = new Dictionary<string, sbrow>();
        internal void CreateSbtjInfoLine(string p){
            //GMapOverlay lay = getSbtjLay(p);
            
            //lay.IsVisibile = false;
            //lay.Markers.Clear();
            //lay.Routes.Clear();
            //亘长
            //杆塔
            sbrows.Clear();
            sbrows.Add("水泥杆", new sbrow() { zl = "杆塔", xh = "水泥杆" });
            sbrows.Add("木杆", new sbrow() { zl = "杆塔", xh = "木杆" });
            sbrows.Add("铁塔", new sbrow() { zl = "杆塔", xh = "铁塔" });
            sbrows.Add("其它杆", new sbrow() { zl = "杆塔", xh = "其它" });
            sbrows.Add("S7", new sbrow() { zl = "变压器", xh = "S7" });
            sbrows.Add("S9", new sbrow() { zl = "变压器", xh = "S9" });
            sbrows.Add("S10", new sbrow() { zl = "变压器", xh = "S10" });
            sbrows.Add("其它", new sbrow() { zl = "变压器", xh = "其它" });
            sbrows.Add("kg", new sbrow() { zl = "开关", xh = "全部" });

            if (sbTable == null) {
                sbTable = new DataTable();
                sbTable.Columns.Add("zl", typeof(String));
                sbTable.Columns.Add("xh", typeof(String));
                sbTable.Columns.Add("sl", typeof(int));
            }
            sbTable.Rows.Clear();
            
            string gtfilter = string.Format("select gttype zl,gtheight xh,count(gtid) sl from ps_gt "
            +"where gtjg='否' and  linecode in (select linecode from ps_xl  where left(Linecode,{0})='{1}' and LineVol = '10')"
            +" group by gttype,gtheight", p.Length,p);
            IList gtlist=Client.ClientHelper.PlatformSqlMap.GetList("Select", gtfilter);
            DataTable dt = null;
            
            dt = DataConvert.HashTablesToDataTable(gtlist);
            if (dt != null) {
                foreach (DataRow row in dt.Rows) {
                    string zl = row["zl"].ToString();
                    if (zl.Contains("混")) {
                        sbrows["水泥杆"].sl +=Convert.ToInt32( row["sl"]);
                    } else if (zl.Contains("木")) {
                        sbrows["木杆"].sl += Convert.ToInt32(row["sl"]);
                    } else if (zl.Contains("铁")) {
                        sbrows["铁塔"].sl += Convert.ToInt32(row["sl"]);
                    } else {
                        sbrows["其它杆"].sl += Convert.ToInt32(row["sl"]);
                    }
                }
            }

            //变压器
            string byqf = string.Format("select left(byqmodle,2) zl,byqcapcity xh,count(byqid) sl from ps_tqbyq where left(byqcode,6)='{0}' group by byqmodle,byqcapcity", p);
            IList byqlist = Client.ClientHelper.PlatformSqlMap.GetList("Select", byqf);
            
            dt = DataConvert.HashTablesToDataTable(byqlist);
            if (dt != null) {
                
                    foreach (DataRow row in dt.Rows) {
                        string zl = row["zl"].ToString();
                        if (zl.Contains("S7")) {
                            sbrows["S7"].sl += Convert.ToInt32(row["sl"]);
                        } else if (zl.Contains("S9")) {
                            sbrows["S9"].sl += Convert.ToInt32(row["sl"]);
                        } else if (zl.Contains("S1")) {
                            sbrows["S10"].sl += Convert.ToInt32(row["sl"]);
                        } else {
                            sbrows["其它"].sl += Convert.ToInt32(row["sl"]);
                        }
                    }
                
            }

            //开关

            string kgf = string.Format("select kgmodle zl,kgcapcity xh,count(kgid) sl from ps_kg where gtid in (select gtid from ps_gt where left(gtcode,{0})='{1}') group by kgmodle,kgcapcity", p.Length,p);
            IList kglist = Client.ClientHelper.PlatformSqlMap.GetList("Select", kgf);

            dt = DataConvert.HashTablesToDataTable(kglist);
            if (dt != null) {
                foreach (DataRow row in dt.Rows) {
                    sbrows["kg"].sl += Convert.ToInt32(row["sl"]);
                }
            }
/*            */
            //绝缘子
            //避雷器
            //
            foreach (string key in sbrows.Keys) {
                sbTable.Rows.Add(sbrows[key].DataArray);
            }
            //lay.IsVisibile = true;
        }
        internal void CreateSbtjInfoGds(string p) {

        }
        internal void CreateSbtjInfoAll() {

        }
        void drawsbtjInfo(Graphics g,PointF pt) {
            if(sbTable==null  || sbTable.Rows.Count==0)return;
            float h=Font.GetHeight(g);
            float rh = h * sbTable.Rows.Count+h;
            float rw1 = 60;// g.MeasureString("12345678901234", Font).Width;
            float rw = rw1*3;
            g.FillRectangle(Brushes.White, pt.X, pt.Y, rw, rh);
            g.DrawRectangle(Pens.Black, pt.X, pt.Y, rw, rh);
            
            float x=pt.X;
            float y=pt.Y;
            g.DrawString("种类", Font, Brushes.Black, x, y);
            g.DrawString("规格", Font, Brushes.Black, x + rw / 3, y);
            g.DrawString("数量", Font, Brushes.Black, x + rw / 3 * 2, y);
            g.DrawLine(Pens.Black, x + rw1, y, x + rw1, y + rh);
            g.DrawLine(Pens.Black, x + rw1*2, y, x + rw1*2, y + rh);
            y += h;

            foreach (DataRow row in sbTable.Rows) {
                object[] data = row.ItemArray;
                g.DrawLine(Pens.Black, x, y, x + rw, y);
                g.DrawString(data[0].ToString(), Font, Brushes.Black, x, y);
                g.DrawString(data[1].ToString(), Font, Brushes.Black, x + rw / 3, y);
                g.DrawString(data[2].ToString(), Font, Brushes.Black, x + rw / 3 * 2, y);
                y += h;
            }
             
        }
        #endregion
        #region 图层信息
        bool showgt=true;
        bool showgth;
        bool showbyq=true;
        bool showbyqrl=true;
        bool showkg;
        bool showxlmc;
        public bool Showgt{
            get {
                return showgt;
            }
            set {
                if (value == showgt) return;
                showgt = value;
                foreach (GMapOverlay lay in Overlays) {
                    foreach (GMapMarkerVector marker in lay.Markers) {
                        try {
                            if (marker.MarkerType == MarkerEnum.gt) {
                                marker.IsVisible = showgt;
                            }
                        } catch { }
                    }

                }
            }
        }
        public bool Showgth {
            get {
                return showgth;
            }
            set {
                if (value == showgth) return;
                showgth = value;
                foreach (GMapOverlay lay in Overlays) {
                    foreach (GMapMarkerVector marker in lay.Markers) {
                        try {
                            if (marker.MarkerType == MarkerEnum.gt) {
                                marker.ShowText = showgth;
                            }
                        } catch { }
                    }

                }
                this.Invalidate();
            }
        }
        public bool Showbyq{
            get {
                return showbyq;
            }
            set {
                if (value == showbyq) return;
                showbyq = value;
                foreach (GMapOverlay lay in Overlays) {
                    foreach (GMapMarkerVector marker in lay.Markers) {
                        try {
                            if (marker.MarkerType == MarkerEnum.byq) {
                                marker.IsVisible = value;
                            }
                        } catch { }
                    }

                }
            }

        }
        public bool Showbyqrl{
            get {
                return showbyqrl;
            }
            set {
                if (value == showbyqrl) return;
                showbyqrl = value;
                foreach (GMapOverlay lay in Overlays) {
                    foreach (GMapMarkerVector marker in lay.Markers) {
                        try {
                            if (marker.MarkerType == MarkerEnum.byq) {
                                marker.ShowText = value;
                            }
                        } catch { }
                    }

                }
                this.Invalidate();
            }

        }
        public bool Showkg{
            get {
                return showkg;
            }
            set {
                if (value == showkg) return;
                showkg = value;
                foreach (GMapOverlay lay in Overlays) {
                    foreach (GMapMarkerVector marker in lay.Markers) {
                        try {
                            if (marker.MarkerType == MarkerEnum.kg) {
                                marker.IsVisible = value;
                            }
                        } catch { }
                    }

                }
            }
        }
        public bool Showxlmc {
            get {
                return showxlmc;
            }
            set {
                if (value == showxlmc) return;
                showxlmc = value;
                foreach (GMapOverlay lay in Overlays) {
                    foreach (GMapMarkerVector marker in lay.Markers) {
                        try {
                            if (marker.MarkerType == MarkerEnum.xlmc) {
                                marker.IsVisible = value;
                            }
                        } catch { }
                    }

                }
            }
        }
        #endregion
    }
}
