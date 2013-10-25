using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace Itop.WebFrame
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class newshandler : IHttpHandler
    {
        private static JavaScriptSerializer jsonHelper;
        static newshandler()
        {
            jsonHelper = new JavaScriptSerializer();
        }

        public void ProcessRequest(HttpContext context)
        {
            string str7;
            ExamService service = new ExamService();
            string str = context.Request.Params["meth"];
            str = str ?? "1";
            string str2 = context.Request.Params["classid"];
            str2 = str2 ?? "1";
            string s = context.Request.Params["start"];
            string businesInfoID = context.Request.Params["newsid"];
            businesInfoID = businesInfoID ?? "1";
            s = s ?? "0";
            string str5 = context.Request.Params["limit"];
            str5 = str5 ?? "10";
            string eBusinesInfo = "";
            if (!(str2 == "1"))
            {
                if (str2 == "2")
                {
                    str7 = str;
                    if (str7 != null)
                    {
                        if (!(str7 == "1"))
                        {
                            if (str7 == "2")
                            {
                                eBusinesInfo = service.GetEBusinesInfo(businesInfoID);
                            }
                        }
                        else
                        {
                            List<TurnE_Notice> list2 = service.GetEBusinesInfoList2(int.Parse(s) + 1, int.Parse(str5));
                            eBusinesInfo = jsonHelper.Serialize(new { count = list2.Count, isend = (list2.Count < int.Parse(str5)) ? 1 : 0, data = list2 });
                        }
                    }
                }
            }
            else
            {
                str7 = str;
                if (str7 != null)
                {
                    if (!(str7 == "1"))
                    {
                        if (str7 == "2")
                        {
                            eBusinesInfo = service.GetENotice(businesInfoID);
                        }
                        else if (str7 == "3")
                        {
                            eBusinesInfo = service.GetENoticeFile(businesInfoID);
                        }
                    }
                    else
                    {
                        List<TurnE_BusinesInfo> list = service.GetENoticeList2(int.Parse(s) + 1, int.Parse(str5));
                        eBusinesInfo = jsonHelper.Serialize(new { count = list.Count, isend = (list.Count < int.Parse(str5)) ? 1 : 0, data = list });
                    }
                }
            }
            context.Response.ContentType = "application/json;charset=utf-8";
            context.Response.Write(eBusinesInfo);
            context.Response.End();

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
