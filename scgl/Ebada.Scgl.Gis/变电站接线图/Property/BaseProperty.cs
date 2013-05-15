//create by rabbit 2007.04.03
using System;
using System.Collections.Generic;
using System.Text;
using Netron.GraphLib;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Design;
using ShapesLib.Design;

namespace ShapesLib {
    public class BaseProperty {
        protected Shape shape;
        public BaseProperty(Shape shapeNode) {
            shape = shapeNode;
        }
        protected void Msg(string msg) {
            //MessageBox.Show((IWin32Window)null,msg, "无效的属性值", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            throw new Exception("无效的属性值，" + msg);
        }
        #region 属性

        [DisplayName("字体")]
        [Description("设置显示文字的字体")]
        [Category("外观")]
        public virtual Font Font {
            get {
                return shape.Font;
            }
            set {
                shape.Font = value;
                shape.Invalidate();
                shape.FontSize = value.Size;
                
            }
        }

        [DisplayName("文字颜色")]
        [Description("设置显示文字的颜色")]
        [Category("外观")]
        public virtual Color FontColor {
            get {
                return shape.TextColor;
            }
            set {
                shape.TextColor = value;
                shape.Invalidate();
            }
        }
        [DisplayName("填充色")]
        [Description("设置图元填充颜色")]
        [Category("外观")]
        public virtual Color ShapeColor {
            get {
                return shape.ShapeColor;
            }
            set {
                shape.ShapeColor = value;
                shape.Invalidate();
            }
        }
        //[DisplayName("边框色")]
        //[Description("设置图元边框颜色")]
        //[Category("外观")]
        //public Pen ShapePen {
        //    get {
        //        return shape.Pen;
        //    }
        //    set {
        //        shape.Pen = value;
        //        shape.Invalidate();
        //    }
        //}
        [DisplayName("文字")]
        [Description("设置显示文字")]
        [Category("外观")]
        [Editor(typeof(LabelTextEditor), typeof(UITypeEditor))]
        public virtual string Text {
            get {
                return shape.Text;
            }
            set {
                shape.Text = value;
                shape.Invalidate();
            }
        }
        [DisplayName("顺序")]
        [Description("设置显示顺序")]
        [Category("外观")]
        //[Editor(typeof(LabelTextEditor), typeof(UITypeEditor))]
        public virtual int ZOrder {
            get {
                return shape.ZOrder;
            }
            set {
                shape.ZOrder = value;
                shape.Invalidate();
            }
        }

        public virtual ConnectorCollection Connectors { get { return shape.Connectors; } }
        public virtual string UID { get { return shape.UID.ToString(); } }
        
        public virtual Shape Shape { get { return shape; } }
        #endregion
    }
}
