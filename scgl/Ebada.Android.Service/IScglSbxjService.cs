using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using Ebada.Scgl.Model;
using System.IO;

namespace Ebada.Android.Service {
    [ServiceContract]
    public interface IScglSbxjService {
        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetUser/{id}/{pwd}", BodyStyle = WebMessageBodyStyle.Bare)]
        User GetUserData(string id, string pwd);
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SetUser", Method = "POST")]
        User SetUserData(User user);
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetVer", BodyStyle = WebMessageBodyStyle.Bare)]
        string GetVersion();
        /// <summary>
        /// 下载计划
        /// </summary>
        /// <param name="gdscode"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetPlanList/{username}", BodyStyle = WebMessageBodyStyle.Bare)]
        string GetPlanList(string username);
        /// <summary>
        /// 上传计划
        /// </summary>
        /// <param name="xlcode"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "UpdatePlanList", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string UpdatePlanList(string data);
        [OperationContract]
        [WebInvoke(UriTemplate = "UpdatePlanList2", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string UpdatePlanList2(sbxj_jh data);
        [OperationContract]
        [WebInvoke(UriTemplate = "UploadFile/{id}/{type}",Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        string UploadFile(string id,string type, Stream fileContents);

    }
}
