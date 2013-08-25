using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;
using System.ServiceModel.Web;

namespace Itop.WebFrame
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IWcfExamSercice”。
    [ServiceContract]
    public interface IWcfExamSercice
    {
        [OperationContract]
      

        #region WebService方法

        #region 基础类型

        //[OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "GetExamList")]
         string GetExamList(string userid);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "GetExamQuestionList")]
         string GetExamQuestionList(string examid);

        [OperationContract]
        [WebInvoke(UriTemplate = "SendExamStart", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
         string SendExamStart(string examid, string userid);

        [OperationContract]
        [WebInvoke(UriTemplate = "SendExamEnd", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
         string SendExamEnd(string examid, string userid);

        [OperationContract]
        [WebInvoke(UriTemplate = "SendExamAnswer", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
         string SendExamAnswer(string jsonstr);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "GetExamResult")]
         string GetExamResult(string examid, string userid);
       
        #endregion


        #region 与用户相关

       
         string GetUserList(string sqlwhere);

        #endregion

        #region 同步讲评成绩
       
         string SendTeachingMidTeamList(string jsonstr);

        #endregion

        #endregion

       

        


    }
}
