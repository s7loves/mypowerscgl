/**********************************************
系统:地理信息
模块:
作者:Rabbit
创建时间:2011-9-4
最后一次修改:2011-9-4
***********************************************/
namespace Ebada.Scgl.Gis
{
   using System.Windows.Forms;
   using GMap.NET.WindowsForms;
   using System.Drawing;
    using System;
    using GMap.NET;

   /// <summary>
   /// custom map of GMapControl
   /// </summary>
    public class RMap : GMapControl,IMapView
   {
      public long ElapsedMilliseconds;

#if DEBUG
      private int counter;
      readonly Font DebugFont = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Regular);
#endif

      /// <summary>
      /// any custom drawing here
      /// </summary>
      /// <param name="drawingContext"></param>
      protected override void OnPaintOverlays(System.Drawing.Graphics g)
      {
         base.OnPaintOverlays(g);

#if DEBUG
         //g.DrawString(string.Format("lat：{0},lon:{1}", this.Position.Lat, this.Position.Lng), DebugFont, Brushes.Red, 36, 36);
         //g.DrawString("render: " + counter++ + ", load: " + ElapsedMilliseconds + "ms", DebugFont, Brushes.Blue, 36, 36);
#endif
      }

      private void InitializeComponent() {
          this.SuspendLayout();
          // 
          // RMap
          // 
          this.DoubleBuffered = true;
          //this.GrayScaleMode = true;
          this.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
          this.Name = "RMap";
          this.Size = new System.Drawing.Size(243, 210);
          this.ResumeLayout(false);

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
    }
}
