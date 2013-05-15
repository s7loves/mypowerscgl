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
        #region 私有成员
        private TaskShape task;
        #endregion

        #region 属性
        [DisplayName("日期")]
        [Description("任务时间,最多30个字符")]
        [Category("任务")]
        public string TaskDate {
            get {
                return task.TaskDate;
            }
            set {
                if (value.Length >= 30) {
                    Msg("不能超过30个字符");
                    return;
                }
                task.TaskDate = value;
                task.NotifyChanged();
            }
        }
        [DisplayName("负责人")]
        [Description("任务负责人,最多20个字符")]
        [Category("任务")]        
        public string TaskMan {
            get {
                return task.TaskMan;
            }
            set {
                if (value.Length >= 20) {
                    Msg("不能超过20个字符");
                    return;
                }
                task.TaskMan = value;
                task.NotifyChanged();
            }
        }
        [DisplayName("内容")]
        [Description("任务内容,最多50个字符")]
        [Category("任务")]
        [Editor(typeof(LabelTextEditor), typeof(UITypeEditor))]
        public string Task {
            get {
                return task.Task;
            }
            set {
                if (value.Length >= 50) {
                    Msg("不能超过50个字符");
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
