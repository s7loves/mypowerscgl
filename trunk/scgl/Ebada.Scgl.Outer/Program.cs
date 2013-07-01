using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;

namespace Ebada.Scgl.Outer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            YYUpdate ydate = new YYUpdate();
            ydate.UpdateUserTable();
        }
    }
}
