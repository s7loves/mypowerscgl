using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Configuration;

namespace Itop.WebFrame {
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    public class verHandler : IHttpHandler {
        static string baseUrl = "http://222.170.135.12:8087/";
        public void ProcessRequest(HttpContext context) {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            
            context.Response.ContentType = "application/json";
            string model = context.Request.Params["model"];
            string jsonStr = "\"ver\":\"{0}\",\"url\":\"{1}\"";
            string msg = string.Empty;
            string ver = ConfigurationManager.AppSettings.Get("ver");
            string url =baseUrl+ "qwks"+ver+".apk";
            if (model == "dafeiji") {
                ver=ConfigurationManager.AppSettings.Get("dafeijiver");
                url = baseUrl + "dafeiji" + ver + ".apk";
            }
            msg = "{" + string.Format(jsonStr, ver, url) + "}";
            context.Response.Write(msg);
            context.Response.End();
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}
