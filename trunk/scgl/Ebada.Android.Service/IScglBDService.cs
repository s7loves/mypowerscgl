﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using Ebada.Scgl.Model;
using System.IO;

namespace Ebada.Android.Service {
    [ServiceContract]
    public interface IScglBDService {
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
        /// <summary>
        /// 变电站
        /// </summary>
        /// <param name="gdscode"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetBDZList/{gdscode}", BodyStyle = WebMessageBodyStyle.Bare)]
        List<bd_bdz> GeBDZList(string gdscode);

        /// <summary>
        /// 获取线路列表
        /// </summary>
        /// <param name="gdscode"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetXlList/{gdscode}", BodyStyle = WebMessageBodyStyle.Bare)]
        List<ps_xl> GetXlList(string gdscode);
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetXlList2/{username}", BodyStyle = WebMessageBodyStyle.Bare)]
        List<ps_xl> GetXlList2(string username);
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetzlList", BodyStyle = WebMessageBodyStyle.Bare)]
        List<ps_sbzl> GetsbzlList();
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetVer", BodyStyle = WebMessageBodyStyle.Bare)]
        string GetVersion();
        /// <summary>
        /// 获取杆塔列表
        /// </summary>
        /// <param name="xlcode"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetGtList/{xlcode}", BodyStyle = WebMessageBodyStyle.Bare)]
        List<bd_sb> GetGtList(string xlcode);
        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateXl", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string UpdateXl(List<ps_xl> data);
        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateGtList", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string UpdateGt(List<ps_gt> data);
        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateGtOne", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string UpdateGtOne(ps_gt data);
        [OperationContract]
        [WebInvoke(UriTemplate = "UploadFile/{id}/{type}",Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        string UploadFile(string id,string type, Stream fileContents);

    }

}
