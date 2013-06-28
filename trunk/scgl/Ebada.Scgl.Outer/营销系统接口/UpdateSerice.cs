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
        }

        //YYUpdate update = new YYUpdate();
        protected override void OnStart(string[] args)
        {
            // TODO: 在此处添加代码以启动服务。
            timer1.Start();
            timer2.Start();
            System.Windows.Forms.MessageBox.Show("数据更新服务已启动");
        }

        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
            timer1.Stop();
            timer2.Stop();
            System.Windows.Forms.MessageBox.Show("数据更新服务已关闭");
        }
        bool flag = false;
        
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now.Hour == 23 && !flag)
            {
                flag = true;
                //update.UpdateUserTable();
            }
        }

        private void timer2_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now.Hour == 22 && flag)
            {
                flag = false;
            }
        }
    }
}
