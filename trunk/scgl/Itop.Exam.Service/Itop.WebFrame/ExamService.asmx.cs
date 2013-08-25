using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Newtonsoft.Json;
using Itop.Frame.Model;
using PasswordHelper;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using Ebada.Client.Platform;
using System.ComponentModel;
namespace Itop.WebFrame
{
    /// <summary>
    /// ExamService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]


    public class ExamService : System.Web.Services.WebService
    {
        #region 基本

        static JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
        /// <summary>
        /// 调用返回数据格式
        /// </summary>
        /// <typeparam name="T"></typeparam>

        string GetJsonStr<T>(List<T> list)
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
            List<TurnE_Examination> tlist = new List<TurnE_Examination>();
            foreach (E_Examination ex in list)
            {
                TurnE_Examination tex = new TurnE_Examination();
                tex.ID = ex.ID;
                tex.EP_ID = ex.EP_ID;
                tex.E_Name = ex.E_Name;
                tex.StartTime = ex.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
                tex.EndTime = ex.EndTime.ToString("yyyy-MM-dd HH:mm:ss");
                tex.ShowResult = ex.ShowResult;
                tex.Time = ex.BySCol1;

                tlist.Add(tex);
            }
            return GetJsonStr<TurnE_Examination>(tlist);
        }

        [WebMethod(Description = "反回考试试题列表，参数examid为考试ID")]
        [ScriptMethod(UseHttpGet = false)]
        public string GetExamQuestionList(string examid)
        {
            //return GetModel<TermClass>(sqlwhere);
            IList<E_QuestionBank> list = Global.SqlMapper.GetList<E_QuestionBank>(" ");
            List<TurnE_QuestionBank> tlist = new List<TurnE_QuestionBank>();
            foreach (E_QuestionBank eq in list)
            {
                TurnE_QuestionBank teq = new TurnE_QuestionBank();
                teq.ID = eq.ID;
                teq.Type = eq.Type;
                teq.Title = eq.Title;
                teq.Option = eq.Option;
                teq.Answer = eq.Answer;
                teq.Explain = eq.Explain;
                teq.DifficultyLevel = eq.DifficultyLevel;
                teq.Professional = eq.Professional;
                teq.Sequence = eq.Sequence;

                tlist.Add(teq);
            }
            return GetJsonStr<TurnE_QuestionBank>(tlist);
        }


        [WebMethod(Description = "上传考试开始，参数examid为考试ID，userid为用户ID")]
        [ScriptMethod(UseHttpGet = false)]
        public string SendExamStart(string examid, string userid)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                E_Examination exam = Global.SqlMapper.GetOneByKey<E_Examination>(examid);
                string sqlwhere = " where E_ID='" + examid + "'  and EP_ID='" + exam.EP_ID + "' and UserID='" + userid + "'";
                IList<E_ExamResult> erlist = Global.SqlMapper.GetListByWhere<E_ExamResult>(sqlwhere);
                if (erlist.Count>0)
                {
                    result.Status = 0;
                    result.Details = "该生已开始考试，不能重复考试！";
                }
                else
                {
                    E_ExamResult er = new E_ExamResult();
                    er.E_ID = examid;
                    er.EP_ID = exam.EP_ID;
                    er.UserID = userid;
                    er.RealStartTime = DateTime.Now;
                    er.IsExamed = true;
                    Global.SqlMapper.Create<E_ExamResult>(er);
                    result.Status = 1;
                    result.Details = "已记录该考生考试数据！";

                }

            }
            catch (Exception ee)
            {
                result.Status = 0;
                result.Details = ee.Message;
            }
            return GetJsonStr<ResponseResult>(result);
        }

        [WebMethod(Description = "上传考试结束，参数examid为考试ID，userid为用户ID")]
        [ScriptMethod(UseHttpGet = false)]
        public string SendExamEnd(string examid, string userid)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                E_Examination exam = Global.SqlMapper.GetOneByKey<E_Examination>(examid);
                string sqlwhere = " where E_ID='" + examid + "'  and EP_ID='" + exam.EP_ID + "' and UserID='" + userid + "'";
                IList<E_ExamResult> erlist = Global.SqlMapper.GetListByWhere<E_ExamResult>(sqlwhere);
                if (erlist.Count > 0)
                {
                    erlist[0].RealEenTime = DateTime.Now;
                    Global.SqlMapper.Update<E_ExamResult>(erlist[0]);
                    result.Status = 1;
                    result.Details = "已记录该考生考试数据!";
                }
                else
                {
                    result.Status = 0;
                    result.Details = "该考生考没有开始考试数据，不能结束考试！";

                }

            }
            catch (Exception ee)
            {
                result.Status = 0;
                result.Details = ee.Message;
            }
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

            PdaExamResult per=new PdaExamResult ();
            per.Score=34;
            per.Pass=true;
            return GetJsonStr<PdaExamResult>(per);
        }


        [WebMethod(Description = "反回考试考试剩余时间(秒)，参数examid为考试ID，userid为用户ID")]
        [ScriptMethod(UseHttpGet = false)]
        public string GetRemainingTime(string examid, string userid)
        {
            SysRemainingTime rtime = new SysRemainingTime();
            rtime.Seconds = 0;
            try
            {
                E_Examination exam = Global.SqlMapper.GetOneByKey<E_Examination>(examid);
                string sqlwhere = " where E_ID='" + examid + "'  and EP_ID='" + exam.EP_ID + "' and UserID='" + userid + "'";
                IList<E_ExamResult> erlist = Global.SqlMapper.GetListByWhere<E_ExamResult>(sqlwhere);
                if (erlist.Count > 0)
                {
                    int time = 1;
                    int.TryParse(exam.BySCol1, out time);

                    DateTime endtime = erlist[0].RealStartTime.AddMinutes(time);

                    if (DateTime.Now>=endtime)
                    {
                        rtime.Seconds = 0;
                    }
                    else
                    {
                       rtime.Seconds= (int)endtime.Subtract(DateTime.Now).TotalSeconds;
                       
                    }
                }
            }
            catch (Exception ee)
            {
                
            }
            return GetJsonStr<SysRemainingTime>(rtime);
        }



        [WebMethod(Description = "反回系统时间")]
        [ScriptMethod(UseHttpGet = false)]
        public string GetSysTime()
        {
            SysTime time = new SysTime();
            time.Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");;
            return GetJsonStr<SysTime>(time);
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

    


    }
}
