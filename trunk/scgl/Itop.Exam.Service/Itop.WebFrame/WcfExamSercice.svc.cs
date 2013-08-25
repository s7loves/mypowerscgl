using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;
using System.ComponentModel;
using System.Web.Services;
using System.Web.Script.Services;
using Itop.Frame.Model;

namespace Itop.WebFrame
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“WcfExamSercice”。
    public class WcfExamSercice : IWcfExamSercice
    {
       
        #region 基本

        static JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
        /// <summary>
        /// 调用返回数据格式
        /// </summary>
        /// <typeparam name="T"></typeparam>

        static string GetJsonStr<T>(List<T> list)
        {
            string str = string.Empty;
            if (list != null)
            {
                str = jsonSerializer.Serialize(list);
            }
            return str;
        }
        static string GetJsonStr<T>(T t)
        {
            string str = string.Empty;
            if (t != null)
            {
                str = jsonSerializer.Serialize(t);
            }
            return str;
        }

        static string JsonOK = GetJsonStr<string>("1");
        static string JsonError = GetJsonStr<string>("0");

        private string GetModel<T>(string sqlwhere)
        {
            List<T> modellist = null;
            try
            {
                modellist = (List<T>)Global.SqlMapper.GetList<T>(sqlwhere);
                return GetJsonStr<T>(modellist);

            }
            catch (Exception e)
            {
                return JsonError;
            }
        }
        private string GetModel<T>(string sqlid, string sqlwhere)
        {
            List<T> modellist = null;
            try
            {
                modellist = (List<T>)Global.SqlMapper.GetList<T>(sqlid, sqlwhere);
                return GetJsonStr<T>(modellist);

            }
            catch (Exception e)
            {
                return JsonError;
            }
        }

        #endregion

        #region WebService方法

        #region 基础类型

        [WebMethod(Description = "反回考试列表，参数userid为用户ID")]
        [ScriptMethod(UseHttpGet = false)]
        public string GetExamList(string userid)
        {
            //return GetModel<TermClass>(sqlwhere);
            IList<E_Examination> list = Global.SqlMapper.GetList<E_Examination>(" ");

            return GetModel<E_Examination>("");

        }

        [WebMethod(Description = "反回考试试题列表，参数examid为考试ID")]
        [ScriptMethod(UseHttpGet = false)]
        public string GetExamQuestionList(string examid)
        {
            //return GetModel<TermClass>(sqlwhere);
            IList<E_QuestionBank> list = Global.SqlMapper.GetList<E_QuestionBank>(" ");
            return GetModel<E_QuestionBank>("");
        }


        [WebMethod(Description = "上传考试开始，参数examid为考试ID，userid为用户ID")]
        [ScriptMethod(UseHttpGet = false)]
        public string SendExamStart(string examid, string userid)
        {
            //return GetModel<TermClass>(sqlwhere);

            ResponseResult result = new ResponseResult();
            result.Status = 1;
            result.Details = "收到数据！";

            return GetJsonStr<ResponseResult>(result);
        }

        [WebMethod(Description = "上传考试结束，参数examid为考试ID，userid为用户ID")]
        [ScriptMethod(UseHttpGet = false)]
        public string SendExamEnd(string examid, string userid)
        {
            //return GetModel<TermClass>(sqlwhere);

            ResponseResult result = new ResponseResult();
            result.Status = 1;
            result.Details = "收到数据！";

            return GetJsonStr<ResponseResult>(result);
        }


        [WebMethod(Description = "上传考试考试答案，参数jsonstr为json串")]
        [ScriptMethod(UseHttpGet = false)]
        public string SendExamAnswer(string jsonstr)
        {
            List<PdaAnswer> splist = null;
            splist = JsonDeserialize<PdaAnswer>(jsonstr);
            ResponseResult result = new ResponseResult();
            if (splist != null && splist.Count > 0)
            {

                try
                {

                    result.Details = "成功";
                    result.Status = 1;
                }
                catch (Exception)
                {
                    result.Status = 0;
                    result.Details = "操作遇到问题！";

                }
            }
            else
            {
                result.Status = 0;
                result.Details = "json转换失败";
            }
            return GetJsonStr<ResponseResult>(result);
        }

        [WebMethod(Description = "反回考试结果，参数examid为考试ID，userid为用户ID")]
        [ScriptMethod(UseHttpGet = false)]
        public string GetExamResult(string examid, string userid)
        {
            //return GetModel<TermClass>(sqlwhere);
            //IList<E_QuestionBank> list = Global.SqlMapper.GetList<E_QuestionBank>(" ");
            //return GetModel<E_QuestionBank>("");

            PdaExamResult per = new PdaExamResult();
            per.Score = 34;
            per.Pass = true;
            return GetJsonStr<PdaExamResult>(per);
        }


        #endregion


        #region 与用户相关

        //[WebMethod(Description = "返回用户表(mUser)，参数为空返回所有，参数写法' where UserCode='admin'")]
        //[ScriptMethod(UseHttpGet = false)]
        public string GetUserList(string sqlwhere)
        {
            //List<mUser> userlist = null;
            //try
            //{
            //    userlist = (List<mUser>)Global.SqlMapper.GetList<mUser>(sqlwhere);
            //    if (userlist!=null&&userlist.Count > 0)
            //    {
            //        foreach (mUser user in userlist)
            //        {
            //            user.Password = PasswordHelper.CoreManager.DecryptoPassword(user.Password);
            //        }
            //    }
            //    return GetJsonStr<mUser>(userlist);

            //}
            //catch (Exception e)
            //{
            //    return JsonError;
            //}
            return "";

        }

        #endregion




        #region 同步讲评成绩
        //[WebMethod(Description = "上传教学中队任务完成表（TeachingMidTeam）,参数为json串")]
        //[ScriptMethod(UseHttpGet = false)]
        public string SendTeachingMidTeamList(string jsonstr)
        {
            //List<TeachingMidTeam> splist = null;
            //splist = JsonDeserialize<TeachingMidTeam>(jsonstr);
            //ResponseResult result = new ResponseResult();
            //if (splist != null && splist.Count > 0)
            //{
            //    string sql1 = string.Empty;
            //    string sql2 = string.Empty;
            //    int count1 = 0;
            //    int count2 = 0;
            //    int scusess = 0;
            //    int allrows = splist.Count;
            //    string returnstr = string.Empty;

            //    try
            //    {
            //        foreach (TeachingMidTeam sp in splist)
            //        {
            //            sql2 = string.Format(" where ID='{0}' ", sp.ID);
            //            count2 = Global.SqlMapper.GetRowCount<TeachingMidTeam>(sql2);
            //            if ( count2 == 0)
            //            {
            //                Global.SqlMapper.Create<TeachingMidTeam>(sp);
            //                scusess++;
            //            }

            //        }

            //        if (allrows != scusess)
            //        {
            //            result.Details = "部分数据与服务器数据冲突，不能上传!已上传数据【" + scusess + "】条.";
            //        }
            //        else
            //        {
            //            result.Details = "操作成功！已上传数据【" + scusess + "】条.";
            //        }
            //        result.Status = 1;
            //    }
            //    catch (Exception)
            //    {
            //        result.Status = 0;
            //        result.Details = "操作遇到问题！已上传数据【" + scusess + "】条.";

            //    }



            //}
            //else
            //{
            //    result.Status = 0;
            //    result.Details = "json转换失败";
            //}
            //return GetJsonStr<ResponseResult>(result);

            return "";

        }


        #endregion


        public static List<T> JsonDeserialize<T>(string jsonString)
        {
            List<T> obj = new List<T>();
            try
            {
                obj = jsonSerializer.Deserialize<List<T>>(jsonString);
            }
            catch (Exception)
            {

            }
            return obj;
        }

        #endregion

        class ResponseResult
        {

            public string Details { get; set; }

            public int Status { get; set; }

        }

        class PdaAnswer
        {
            [DisplayNameAttribute("考试ID")]
            public string E_ID { get; set; }

            [DisplayNameAttribute("试卷ID")]
            public string EP_ID { get; set; }

            [DisplayNameAttribute("考试试题编号")]
            public string ExamQueston_ID { get; set; }

            [DisplayNameAttribute("答案")]
            public string Answer { get; set; }

            [DisplayNameAttribute("随机试题号")]
            public string RandomID { get; set; }

            [DisplayNameAttribute("试题类型")]
            public string ExamQuestonType { get; set; }

            [DisplayNameAttribute("考试人员")]
            public string UserID { get; set; }

        }

        class PdaExamResult
        {
            [DisplayNameAttribute("考试分数")]
            public int Score { get; set; }

            [DisplayNameAttribute("是否通过")]
            public bool Pass { get; set; }

        }

    }
}
