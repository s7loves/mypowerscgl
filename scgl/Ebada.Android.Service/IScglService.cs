using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using Ebada.Scgl.Model;

namespace Ebada.Android.Service {
    [ServiceContract]
    public interface IScglService {
        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetUser/{id}/{pwd}", BodyStyle = WebMessageBodyStyle.Bare)]
        User GetUserData(string id,string pwd);
        /// <summary>
        /// 获取线路列表
        /// </summary>
        /// <param name="gdscode"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetXlList/{gdscode}", BodyStyle = WebMessageBodyStyle.Bare)]
        List<PS_xl> GetXlList(string gdscode);
        /// <summary>
        /// 获取杆塔列表
        /// </summary>
        /// <param name="xlcode"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetGtList/{xlcode}", BodyStyle = WebMessageBodyStyle.Bare)]
        List<PS_gt> GetGtList(string xlcode);
        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateXl", Method = "POST", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Json)]
        string UpdateXl(List<PS_xl> data);
        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateGt", Method = "POST", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Json)]
        string UpdateGt(List<PS_gt> data);
    }
}
