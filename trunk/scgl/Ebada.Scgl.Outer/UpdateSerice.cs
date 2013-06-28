using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;

namespace Ebada.Scgl.Outer
{
    partial class UpdateSerice : ServiceBase
    {
        public UpdateSerice()
        {
            InitializeComponent();
            timer1.Start();
            timer2.Start();
        }

        YYUpdate update = new YYUpdate();
        protected override void OnStart(string[] args)
        {
            // TODO: 在此处添加代码以启动服务。

        }

        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
        }
        bool flag = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour==23&&!flag)
            {
                flag = true;
                update.UpdateUserTable();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour == 22 && flag)
            {
                flag = false;
            }
        }
    }
}
