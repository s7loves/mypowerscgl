using System;
using System.Drawing;
namespace Ebada.Scgl.Gis {
    interface IText {
        Font Font { get; set; }
        bool ShowText { get; set; }
        string Text { get; set; }
    }
}
