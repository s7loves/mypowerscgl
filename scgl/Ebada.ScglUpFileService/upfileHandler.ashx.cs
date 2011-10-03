using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.IO;

namespace Ebada.ScglUpFileService
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string filename = context.Request.QueryString["filename"].ToString();
            if (Directory.Exists(context.Server.MapPath("UpLoadFiles/")) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(context.Server.MapPath("UpLoadFiles/"));
            }
            using (FileStream inputStram = File.Create(context.Server.MapPath("UpLoadFiles/") + filename))
            {
                SaveFile(context.Request.InputStream, inputStram);
            }

        }
        protected void SaveFile(Stream stream, FileStream inputStream)
        {
            int bufSize = 1024;
            int byteGet = 0;
            byte[] buf = new byte[bufSize];
            while ((byteGet = stream.Read(buf, 0, bufSize)) > 0)
            {
                inputStream.Write(buf, 0, byteGet);
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
