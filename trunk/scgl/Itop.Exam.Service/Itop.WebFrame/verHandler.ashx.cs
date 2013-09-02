using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace Itop.WebFrame {
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    public class verHandler : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            context.Response.ContentType = "application/json";
            //string model = context.Request["model"].ToString();
            string jsonStr = "\"ver\":\"{0}\",\"url\":\"{1}\"";
            string msg = string.Empty;
            string ver = "1.0";
            string url = "http://222.170.135.12:8087/qwks.apk";
            //res.GetVerInfo(model, ref ver, ref url);
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
