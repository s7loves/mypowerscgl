using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Ebada.Components;
using Ebada.Server;
using Itop.Frame.BLL;

namespace Itop.WebFrame {
    public class Global : System.Web.HttpApplication {
        public static Castle.Windsor.IWindsorContainer IOC;
        private static IBaseSqlMapDao sqlMapper;

        public static IBaseSqlMapDao SqlMapper {
            get { 
                if(sqlMapper==null)
                    sqlMapper = IOC.GetService<IBaseSqlMapDao>();
                
                return Global.sqlMapper;           
            }
        }
        public static T GetService<T>(){
            return IOC.GetService<T>();
        }
        protected void Application_Start(object sender, EventArgs e) {
            if (IOC == null) {
                new ServerContainer();
                IOC = ServerContainer.PlatformServer;
            }
            dbGameHelper.Create();
            gameHandler.ScoreList = dbGameHelper.getScores();
        }

        protected void Session_Start(object sender, EventArgs e) {
            ////测试用内容，用后删除
            //Session.Add("UserID", "testUser");

            //if (Session["UserID"] == null) throw new Exception("！！！！！！");
            Session.Timeout = 360;
        }

        protected void Application_BeginRequest(object sender, EventArgs e) {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {

        }

        protected void Application_Error(object sender, EventArgs e) {

        }

        protected void Session_End(object sender, EventArgs e) {
            dbGameHelper.Clear();
            dbGameHelper.Insert(gameHandler.ScoreList);
        }

        protected void Application_End(object sender, EventArgs e) {

        }
    }
}