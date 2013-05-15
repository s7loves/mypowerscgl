using System;
using System.Collections.Generic;
using System.Text;
using Netron.GraphLib;
using System.ComponentModel;
using ShapesLib.BasicShapes;
using ShapesLib.Design;
using System.Drawing.Design;
using Netron.GraphLib.Entitology;

namespace ShapesLib {
    public class ImageShapeProperty:BaseProperty {
        public ImageShapeProperty(ImageShape shapeNode)
            : base(shapeNode) {
            shape = shapeNode;
        }
        #region ˽�г�Ա
        private ImageShape shape;
        #endregion

        #region ����
        [DisplayName("ͼƬ�ļ�")]
        [Description("ͼƬ�ļ�·��")]
        [Category("ͼƬ")]
        [Editor(typeof(FilenameUIEditor), typeof(UITypeEditor))]
        public string ImagePath {
            get {
                return shape.ImagePath;
            }
            set {
                shape.ImagePath=value;
                shape.Invalidate();
            }
        }
        [Browsable(false)]
        public override string Text {
            get {
                return base.Text;
            }
            set {
                base.Text = value;
            }
        }
        #endregion
    }
}
