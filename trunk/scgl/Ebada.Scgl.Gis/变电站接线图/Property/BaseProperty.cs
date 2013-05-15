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
            //MessageBox.Show((IWin32Window)null,msg, "��Ч������ֵ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            throw new Exception("��Ч������ֵ��" + msg);
        }
        #region ����

        [DisplayName("����")]
        [Description("������ʾ���ֵ�����")]
        [Category("���")]
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

        [DisplayName("������ɫ")]
        [Description("������ʾ���ֵ���ɫ")]
        [Category("���")]
        public virtual Color FontColor {
            get {
                return shape.TextColor;
            }
            set {
                shape.TextColor = value;
                shape.Invalidate();
            }
        }
        [DisplayName("���ɫ")]
        [Description("����ͼԪ�����ɫ")]
        [Category("���")]
        public virtual Color ShapeColor {
            get {
                return shape.ShapeColor;
            }
            set {
                shape.ShapeColor = value;
                shape.Invalidate();
            }
        }
        //[DisplayName("�߿�ɫ")]
        //[Description("����ͼԪ�߿���ɫ")]
        //[Category("���")]
        //public Pen ShapePen {
        //    get {
        //        return shape.Pen;
        //    }
        //    set {
        //        shape.Pen = value;
        //        shape.Invalidate();
        //    }
        //}
        [DisplayName("����")]
        [Description("������ʾ����")]
        [Category("���")]
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
        [DisplayName("˳��")]
        [Description("������ʾ˳��")]
        [Category("���")]
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
