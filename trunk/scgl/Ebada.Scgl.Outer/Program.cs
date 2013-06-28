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
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new sertest()
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
