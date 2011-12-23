using System;
using System.Drawing;
namespace Ebada.Scgl.Gis {
    /// <summary>
    /// 图纸接口
    /// </summary>
    public interface IDrawing {
        void Create(string p);
        void Draw(System.Drawing.Graphics g);
        string Title { get; set; }
        GMap.NET.RectLatLng Bounds { get; set; }
    }
}
