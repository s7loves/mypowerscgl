using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using TONLI.MapView;
using TLVector.Core.Document;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using DevExpress.XtraEditors;
using Ebada.Client;
using Ebada.Client.Platform;
namespace Ebada.Scgl.Gis {
    public partial class UCMapBox : XtraUserControl,IMapView {
        static UCMapBox() {

            TLVector.SpecialCursors.LoadCursors();//加载光标资源 
        }
        public UCMapBox() {
            InitializeComponent();
            
        }

        void map_OnDownCompleted(ClassImage mapclass) {
            if (mapclass.PicImage != null)
                documentControl1.DrawArea.InvadateRect(mapclass.Bounds);
        }
        void initcontrol() {
            double jd = double.Parse(ConfigurationManager.AppSettings["jd"]);
            double wd = double.Parse(ConfigurationManager.AppSettings["wd"]);
            bool showmapinfo = bool.Parse(ConfigurationManager.AppSettings["showmapinfo"]);
            int viewwidth = int.Parse(ConfigurationManager.AppSettings["mapview"]);
            string maptype = ConfigurationManager.AppSettings["maptype"];

            MapViewGoogle map = new TONLI.MapView.MapViewGoogle();
            map.ShowMapInfo = showmapinfo;
            mapview = map;
            if (TONLI.MapView.DataHelper.IMapServer != null) {
                map.OnDownCompleted += new DownCompleteEventHandler(map_OnDownCompleted);
                map.IsDownMap = true;
            }
            this.documentControl1.AfterPaintPage += new TLVector.DrawArea.PaintMapEventHandler(documentControl1_AfterPaintPage);
            this.documentControl1.DrawArea.ViewMargin = new Size(viewwidth, viewwidth);
            mapview.ZeroLongLat = new LongLat(jd, wd);
            this.documentControl1.DrawArea.FreeSelect = true;
            this.documentControl1.FullDrawMode = true;
            SvgDocument.BkImageLoad = true;
            this.documentControl1.BackColor = Color.BurlyWood;
            this.documentControl1.DrawArea.MaxScale = 2;
            this.documentControl1.DrawArea.MinSacle = 8f / (float)Math.Pow(2, (18 - 7));

            this.documentControl1.DrawMode = DrawModeType.ScreenImage;
            this.documentControl1.CanEdit = false;
            this.documentControl1.MoveIn += new TLVector.DrawArea.SvgElementEventHandler(documentControl1_MoveIn);
            this.documentControl1.MoveOut += new TLVector.DrawArea.SvgElementEventHandler(documentControl1_MoveOut);
            this.documentControl1.DrawArea.MouseDown += new MouseEventHandler(DrawArea_MouseDown);
            this.documentControl1.DrawArea.MouseUp += new MouseEventHandler(DrawArea_MouseUp);
            this.documentControl1.Operation = ToolOperation.Roam;
        }
        public void Init() {
            if (Site != null && Site.DesignMode) return;
            
            initcontrol();
            
            try {
                TONLI.MapView.DataHelper.IMapServer = ClientServer.PlatformServer.GetService<TONLI.MapCore.IMapServer>();

            } catch (Exception e) { MsgBox.ShowTipMessageBox("地图服务器连接失败！" + e.Message); }
            documentControl1.NewFile();

            setLevel(9);
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            Init();
            
        }
        void setLevel(int level) {
            documentControl1.ScaleRatio = 8f / (float)Math.Pow(2, (19 - level));
        }
        void DrawArea_MouseUp(object sender, MouseEventArgs e) {
            isdown = false;
            beginPoint = Point.Empty;
            backbmp = null;
        }
        Point beginPoint = Point.Empty;
        bool isdown = false;
        void DrawArea_MouseDown(object sender, MouseEventArgs e) {
            isdown = true;
            beginPoint = Control.MousePosition;
        }
        TONLI.MapView.IMapViewObj mapview = null;

        public TONLI.MapView.IMapViewObj Mapview {
            get { return mapview; }
            set { mapview = value; }
        }

        System.Drawing.Image backbmp = null;
        int mapLevle = 9;
        int MaxLevle = 17;
        int MinLevel = 9;
        private void documentControl1_AfterPaintPage(object sender, TLVector.Core.PaintMapEventArgs e) {

            if (Site != null && Site.DesignMode) return;
            if (isdown) return;
            if (Control.MouseButtons == MouseButtons.Left) {
                e.G.Clear(Color.White);
                return;

            }
            //(mapview as MapViewBase).ShowMapInfo = true;
            int nScale = 0;
            float nn = 1;
            nScale = mapview.Getlevel(documentControl1.ScaleRatio);

            if (nScale == -1) return;

            mapLevle = nScale;
            LongLat longlat = LongLat.Empty;
            //计算中心点经纬度

            longlat = mapview.OffSet(mapview.ZeroLongLat, nScale, (int)(e.CenterPoint.X / nn), (int)(e.CenterPoint.Y / nn));

            //创建地图

            System.Drawing.Image image = backbmp;
            //if (image != null && isdown) { } else
            if (nn >= 1)
                image = mapview.CreateMap(e.Bounds.Width, e.Bounds.Height, nScale, longlat.Longitude, longlat.Latitude);
            else
                image = mapview.CreateMap((int)(e.Bounds.Width / nn), (int)(e.Bounds.Height / nn), nScale, longlat.Longitude, longlat.Latitude);
            //backbmp = image;
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMatrix matrix1 = new ColorMatrix();
            matrix1.Matrix00 = 1f;
            matrix1.Matrix11 = 1f;
            matrix1.Matrix22 = 1f;
            matrix1.Matrix33 = 0.9f;//地图透明度
            matrix1.Matrix44 = 1f;
            //设置地图透明度
            imageAttributes.SetColorMatrix(matrix1, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            //绘制地图

            if (nn > 1) {
                int w1 = (int)(e.Bounds.Width * ((nn - 1) / 2));
                int h1 = (int)(e.Bounds.Height * ((nn - 1) / 2));

                Rectangle rt1 = e.Bounds;
                rt1.Inflate(w1, h1);
                e.G.CompositingQuality = CompositingQuality.HighQuality;
                e.G.DrawImage((Bitmap)image, rt1, 0f, 0f, (float)image.Width, (float)image.Height, GraphicsUnit.Pixel, imageAttributes);
            } else
                e.G.DrawImage((Bitmap)image, e.Bounds, 0f, 0f, (float)image.Width, (float)image.Height, GraphicsUnit.Pixel, imageAttributes);
            SolidBrush brush = new SolidBrush(Color.FromArgb(220, 75, 75, 75));
            //e.G.FillRectangle( brush,e.G.VisibleClipBounds);
            //绘制中心点
            e.G.DrawEllipse(Pens.Red, e.Bounds.Width / 2 - 2, e.Bounds.Height / 2 - 2, 4, 4);
            e.G.DrawEllipse(Pens.Red, e.Bounds.Width / 2 - 1, e.Bounds.Height / 2 - 1, 2, 2);
            ///107,159
            //{//绘制比例尺
            //    Point p1 = new Point(20, e.Bounds.Height - 30);
            //    Point p2 = new Point(20, e.Bounds.Height - 20);
            //    Point p3 = new Point(80, e.Bounds.Height - 20);
            //    Point p4 = new Point(80, e.Bounds.Height - 30);

            //    e.G.DrawLines(new Pen(Color.Black, 2), new Point[4] { p1, p2, p3, p4 });
            //    string str1 = string.Format("{0}公里", mapview.GetMiles(nScale));
            //    e.G.DrawString(str1, new Font("宋体", 10), Brushes.Black, 30, e.Bounds.Height - 40);
            //}

        }

        private void DrawArea_OnBeforeRenderTo(object sender, TLVector.Core.PaintMapEventArgs e) {

        }

        private void documentControl1_MoveIn(object sender, TLVector.DrawArea.SvgElementSelectedEventArgs e) {
            //(e.SvgElement as IGraph).CanSelect=false;
            this.documentControl1.SetToolTip(((TLVector.Core.SvgElement)e.SvgElement).GetAttribute("info-name"));

        }

        private void documentControl1_MoveOut(object sender, TLVector.DrawArea.SvgElementSelectedEventArgs e) {
            this.documentControl1.SetToolTip("");

        }
        private void 地图ToolStripMenuItem_Click(object sender, EventArgs e) {
            (mapview as MapViewGoogle).SetTileType(1);
            documentControl1.Refresh();
        }

        private void 卫星ToolStripMenuItem_Click(object sender, EventArgs e) {
            (mapview as MapViewGoogle).SetTileType(2);
            documentControl1.Refresh();
        }
        private void 地形ToolStripMenuItem_Click(object sender, EventArgs e) {
            (mapview as MapViewGoogle).SetTileType(8);
            documentControl1.Refresh();
        }

        #region IMapView 成员

        public void Zoomin() {
            setLevel(mapLevle - 1);
        }

        public void Zoomout() {
            setLevel(mapLevle + 1);
        }

        public void Roam() {
            this.documentControl1.Operation = ToolOperation.Roam;
        }

        public void Fly() {
            throw new NotImplementedException("功能正在开发。。。");
        }

        public void Distance() {
            throw new NotImplementedException("功能正在开发。。。");
        }

        public void FullView() {
            setLevel(9);
        }

        #endregion
    }
}
