using System;
using System.Collections.Generic;
using System.Text;
using Netron.GraphLib;
using System.ComponentModel;
using ShapesLib.BasicShapes;
using ShapesLib.Design;
using System.Drawing.Design;

namespace ShapesLib {
    public class TaskProperty:BaseProperty {
        public TaskProperty(TaskShape shapeNode):base(shapeNode){
            task = shapeNode;
        }
        #region ˽�г�Ա
        private TaskShape task;
        #endregion

        #region ����
        [DisplayName("����")]
        [Description("����ʱ��,���30���ַ�")]
        [Category("����")]
        public string TaskDate {
            get {
                return task.TaskDate;
            }
            set {
                if (value.Length >= 30) {
                    Msg("���ܳ���30���ַ�");
                    return;
                }
                task.TaskDate = value;
                task.NotifyChanged();
            }
        }
        [DisplayName("������")]
        [Description("��������,���20���ַ�")]
        [Category("����")]        
        public string TaskMan {
            get {
                return task.TaskMan;
            }
            set {
                if (value.Length >= 20) {
                    Msg("���ܳ���20���ַ�");
                    return;
                }
                task.TaskMan = value;
                task.NotifyChanged();
            }
        }
        [DisplayName("����")]
        [Description("��������,���50���ַ�")]
        [Category("����")]
        [Editor(typeof(LabelTextEditor), typeof(UITypeEditor))]
        public string Task {
            get {
                return task.Task;
            }
            set {
                if (value.Length >= 50) {
                    Msg("���ܳ���50���ַ�");
                    return;
                }
                task.Task = value;
                task.NotifyChanged();
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
