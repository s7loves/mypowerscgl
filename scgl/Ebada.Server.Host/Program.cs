using System;
using System.Collections.Generic;
using System.Text;
using Castle.Windsor;
using log4net.Config;

namespace Ebada.Server.Host
{
    class Program
    {
        /// <summary>
        /// 测试用控台服务
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo("log4net.config"));
            //log4net.ILog Log = log4net.LogManager.GetLogger("IBatisNet.DataMapper.SqlMapSession");
            //Log.Info("***************应用程序服务器准备启动****************");
            try {
                ServerContainer container = new ServerContainer();//container
                //IWindsorContainer container2 = new RemotingContainer2();
                
                Console.WriteLine("服务开启,按任意键关闭...");
                DBHelper dbhelper = new DBHelper();
                dbhelper.UpdateDatabase();

                Console.ReadLine();
            } catch (Exception er) { 
                Console.WriteLine(er.Message); Console.ReadLine(); }
        }
    }
}
