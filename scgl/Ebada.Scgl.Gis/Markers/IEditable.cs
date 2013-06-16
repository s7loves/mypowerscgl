using System;
namespace Ebada.Scgl.Gis {
    interface IEditable {
        bool AllowEdit { get; set; }
        void Update();
    }
}
