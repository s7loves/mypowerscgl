using System;
using System.Collections.Generic;
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
namespace Itop.WebFrame
{
    /// <summary>
    /// PdaService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]



  
    public class PdaService : System.Web.Services.WebService
    {
        //#region 基本

        //static JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
        ///// <summary>
        ///// 调用返回数据格式
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
      
        //string GetJsonStr<T>(List<T> list)
        //{
        //    string str = string.Empty;
        //    if (list!=null)
        //    {
        //        str = jsonSerializer.Serialize(list);
        //    }
        //    return str;
        //}
        //static string GetJsonStr<T>(T t)
        //{
        //    string str = string.Empty;
        //    if (t != null)
        //    {
        //        str = jsonSerializer.Serialize(t);
        //    }
        //    return str;
        //}

        //static string JsonOK = GetJsonStr<string>("1");
        //static string JsonError = GetJsonStr<string>("0");

        //private string GetModel<T>(string sqlwhere)
        //{
        //    List<T> modellist = null;
        //    try
        //    {
        //        modellist = (List<T>)Global.SqlMapper.GetList<T>(sqlwhere);
        //        return GetJsonStr<T>(modellist);

        //    }
        //    catch (Exception e)
        //    {
        //        return JsonError;
        //    }
        //}
        //private string GetModel<T>(string sqlid,string sqlwhere)
        //{
        //    List<T> modellist = null;
        //    try
        //    {
        //        modellist = (List<T>)Global.SqlMapper.GetList<T>(sqlid,sqlwhere);
        //        return GetJsonStr<T>(modellist);

        //    }
        //    catch (Exception e)
        //    {
        //        return JsonError;
        //    }
        //}
        
        //#endregion

        //#region WebService方法

        //#region 基础类型

        //[WebMethod(Description = "返回期班表（TermClass）参数为空返回所有，参数写法' where UserCode='admin'")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string GetTermClassList(string sqlwhere)
        //{
        //    return GetModel<TermClass>(sqlwhere);
        //}

        //[WebMethod(Description = "返回专业表（TeachingSpecialty）参数为空返回所有，参数写法' where UserCode='admin'")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string GetTeachingSpecialtyList(string sqlwhere)
        //{
        //    return GetModel<TeachingSpecialty>(sqlwhere);
        //}

        //[WebMethod(Description = "返回组织机构（mOrg）参数为空返回所有，参数写法' where UserCode='admin'")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string GetmOrgList(string sqlwhere)
        //{
        //    return GetModel<mOrg>(sqlwhere);
        //}

        //#endregion


        //#region 与用户相关

        //[WebMethod(Description = "返回用户表(mUser)，参数为空返回所有，参数写法' where UserCode='admin'")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string  GetUserList(string sqlwhere)
        //{
        //    List<mUser> userlist = null;
        //    try
        //    {
        //        userlist = (List<mUser>)Global.SqlMapper.GetList<mUser>(sqlwhere);
        //        if (userlist!=null&&userlist.Count > 0)
        //        {
        //            foreach (mUser user in userlist)
        //            {
        //                user.Password = PasswordHelper.CoreManager.DecryptoPassword(user.Password);
        //            }
        //        }
        //        return GetJsonStr<mUser>(userlist);

        //    }
        //    catch (Exception e)
        //    {
        //        return JsonError;
        //    }

        //}

        //#endregion

        //#region 体能训练

        //[WebMethod(Description = "返回体能训练算分规则（PhysicalTrainingRule）")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string  GetRuleList()
        //{
        //    return GetModel<PhysicalTrainingRule>(string.Empty);
        //}

        //[WebMethod(Description = "返回体能训练表（ScorePhysical）,参数为空返回所有，参数写法' where UserCode='admin'")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string  GetScorePhysicalList(string sqlwhere)
        //{
        //    return GetModel<ScorePhysical>(sqlwhere);

        //}

        //[WebMethod(Description = "返回体能训考核名称表（Tb_Weight_Sequence）,参数为空返回所有，参数写法' where UserCode='admin'")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string  GetCheckNameList(string sqlwhere)
        //{
        //    return GetModel<Tb_Weight_Sequence>(sqlwhere);
        //}

        //[WebMethod(Description = "返回体能训考核类型（BusinessType）")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string  GetCheckTypeList()
        //{
            
        //    string sqlwhere = " where ParentID='20120918094731406250'";
        //    return GetModel<BusinessType>(sqlwhere);

        //}

        //#endregion

        //#region 讲评相关

        //[WebMethod(Description = "返回任务规划表（TaskPlaning）参数为空返回所有，参数写法' where UserCode='admin'")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string GetTaskPlaningList(string sqlwhere)
        //{
        //    return GetModel<TaskPlaning>(sqlwhere);
        //}

        //[WebMethod(Description = "返回飞行科目表（FlightSubjects）参数为空返回所有，参数写法' where UserCode='admin'")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string GetFlightSubjectsList(string sqlwhere)
        //{
        //    return GetModel<FlightSubjects>(sqlwhere);
        //}

        //[WebMethod(Description = "返回关键动作表（KeyPose）参数为空返回所有，参数写法' where UserCode='admin'")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string GetKeyPoseList(string sqlwhere)
        //{
        //    return GetModel<KeyPose>(sqlwhere);
        //}

        //[WebMethod(Description = "返回练习项目表（PracticeProject）参数为空返回所有，参数写法' where UserCode='admin'")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string GetPracticeProjectList(string sqlwhere)
        //{
        //    return GetModel<PracticeProject>("GetPracticeProjectSelectOrderByTJ","");
        //}

        //[WebMethod(Description = "返回讲评_本组教员（CommentInGroup）参数为空返回所有，参数写法' where UserCode='admin'")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string GetCommentInGroupList(string sqlwhere)
        //{
        //    return GetModel<CommentInGroup>(sqlwhere);
        //}

        //[WebMethod(Description = "返回讲评_动作掌握情况表（CommentForPoseInfo）参数为空返回所有，参数写法' where UserCode='admin'")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string GetCommentForPoseInfoList(string sqlwhere)
        //{
        //    return GetModel<CommentForPoseInfo>(sqlwhere);
        //}

        //[WebMethod(Description = "返回讲评表（Comment）参数为空返回所有，参数写法' where UserCode='admin'")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string GetCommentList(string sqlwhere)
        //{
        //    return GetModel<Comment>(sqlwhere);
        //}

        //[WebMethod(Description = "返回讲评_动作掌握分数表（CommentForPose）参数为空返回所有，参数写法' where UserCode='admin'")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string GetCommentForPoseList(string sqlwhere)
        //{
        //    return GetModel<CommentForPose>(sqlwhere);
        //}

        //[WebMethod(Description = "返回讲评_训练时间表（StudentsProgress）参数为空返回所有，参数写法' where UserCode='admin'")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string GetStudentsProgressList(string sqlwhere)
        //{
        //    return GetModel<StudentsProgress>(sqlwhere);
        //}

        //[WebMethod(Description = "返回任务规划_关键动作表（TaskPlainingKeyPost）参数为空返回所有，参数写法' where UserCode='admin'")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string GetTaskPlainingKeyPostList(string sqlwhere)
        //{
        //    return GetModel<TaskPlainingKeyPost>(sqlwhere);
        //}

        //[WebMethod(Description = "返回教学中队任务完成表（TeachingMidTeam）参数为空返回所有，参数写法' where UserCode='admin'")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string GetTeachingMidTeamList(string sqlwhere)
        //{
        //    return GetModel<TeachingMidTeam>(sqlwhere);
        //}
        //#endregion




        //#region 同步体能训练成绩
        //[WebMethod(Description = "上传体能训成绩（ScorePhysical）,参数为json串")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string SendScorePhysicalList(string jsonstr)
        //{
        //    List<ScorePhysical> splist = null;
        //    splist = JsonDeserialize<ScorePhysical>(jsonstr);
        //    ResponseResult result = new ResponseResult();
        //    if (splist != null && splist.Count > 0)
        //    {
        //        string sql1 = string.Empty;
        //        string sql2 = string.Empty;
        //        int count1 = 0;
        //        int count2 = 0;
        //        int scusess = 0;
        //        int allrows = splist.Count;
        //        string returnstr = string.Empty;
               
        //        try
        //        {
        //            foreach (ScorePhysical sp in splist)
        //            {
        //                sql1 = string.Format(" where StudentID='{0}' and ExamType='{1}' and BySCol1='{2}'", sp.StudentID, sp.ExamType, sp.BySCol1);
        //                sql2 = string.Format(" where ID='{0}' ", sp.ID);

        //                count1 = Global.SqlMapper.GetRowCount<ScorePhysical>(sql1);
        //                count2 = Global.SqlMapper.GetRowCount<ScorePhysical>(sql2);
        //                if ((count1 + count2) == 0)
        //                {
        //                    if (sp.ExamTime.Year<1999)
        //                    {
        //                        sp.ExamTime = DateTime.Now;
        //                    }
        //                    Global.SqlMapper.Create<ScorePhysical>(sp);
        //                    scusess++;
        //                }

        //            }

        //            if (allrows != scusess)
        //            {
        //                result.Details = "部分数据与服务器数据冲突，不能上传!已上传数据【" + scusess + "】条.";
        //            }
        //            else
        //            {
        //                result.Details = "操作成功！已上传数据【" + scusess + "】条.";
        //            }
        //            result.Status = 1;
        //        }
        //        catch (Exception)
        //        {
        //            result.Status = 0;
        //            result.Details = "操作遇到问题！已上传数据【" + scusess + "】条.";

        //        }

               

        //    }
        //    else
        //    {
        //        result.Status = 0;
        //        result.Details = "json转换失败";
        //    }
        //    return GetJsonStr<ResponseResult>(result);

        //}

        //#endregion

        //#region 同步讲评成绩
        //[WebMethod(Description = "上传教学中队任务完成表（TeachingMidTeam）,参数为json串")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string SendTeachingMidTeamList(string jsonstr)
        //{
        //    List<TeachingMidTeam> splist = null;
        //    splist = JsonDeserialize<TeachingMidTeam>(jsonstr);
        //    ResponseResult result = new ResponseResult();
        //    if (splist != null && splist.Count > 0)
        //    {
        //        string sql1 = string.Empty;
        //        string sql2 = string.Empty;
        //        int count1 = 0;
        //        int count2 = 0;
        //        int scusess = 0;
        //        int allrows = splist.Count;
        //        string returnstr = string.Empty;

        //        try
        //        {
        //            foreach (TeachingMidTeam sp in splist)
        //            {
        //                sql2 = string.Format(" where ID='{0}' ", sp.ID);
        //                count2 = Global.SqlMapper.GetRowCount<TeachingMidTeam>(sql2);
        //                if ( count2 == 0)
        //                {
        //                    Global.SqlMapper.Create<TeachingMidTeam>(sp);
        //                    scusess++;
        //                }

        //            }

        //            if (allrows != scusess)
        //            {
        //                result.Details = "部分数据与服务器数据冲突，不能上传!已上传数据【" + scusess + "】条.";
        //            }
        //            else
        //            {
        //                result.Details = "操作成功！已上传数据【" + scusess + "】条.";
        //            }
        //            result.Status = 1;
        //        }
        //        catch (Exception)
        //        {
        //            result.Status = 0;
        //            result.Details = "操作遇到问题！已上传数据【" + scusess + "】条.";

        //        }



        //    }
        //    else
        //    {
        //        result.Status = 0;
        //        result.Details = "json转换失败";
        //    }
        //    return GetJsonStr<ResponseResult>(result);

        //}

        //[WebMethod(Description = "上传讲评_训练时间表（StudentsProgress）,参数为json串")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string SendStudentsProgressList(string jsonstr)
        //{
        //    List<StudentsProgress> splist = null;
        //    splist = JsonDeserialize<StudentsProgress>(jsonstr);
        //    ResponseResult result = new ResponseResult();
        //    if (splist != null && splist.Count > 0)
        //    {
        //        string sql1 = string.Empty;
        //        string sql2 = string.Empty;
        //        int count1 = 0;
        //        int count2 = 0;
        //        int scusess = 0;
        //        int allrows = splist.Count;
        //        string returnstr = string.Empty;

        //        try
        //        {
        //            foreach (StudentsProgress sp in splist)
        //            {
        //                sql2 = string.Format(" where ID='{0}' ", sp.ID);
        //                count2 = Global.SqlMapper.GetRowCount<StudentsProgress>(sql2);
        //                if (count2 == 0)
        //                {
        //                    Global.SqlMapper.Create<StudentsProgress>(sp);
        //                    scusess++;
        //                }

        //            }

        //            if (allrows != scusess)
        //            {
        //                result.Details = "部分数据与服务器数据冲突，不能上传!已上传数据【" + scusess + "】条.";
        //            }
        //            else
        //            {
        //                result.Details = "操作成功！已上传数据【" + scusess + "】条.";
        //            }
        //            result.Status = 1;
        //        }
        //        catch (Exception)
        //        {
        //            result.Status = 0;
        //            result.Details = "操作遇到问题！已上传数据【" + scusess + "】条.";

        //        }



        //    }
        //    else
        //    {
        //        result.Status = 0;
        //        result.Details = "json转换失败";
        //    }
        //    return GetJsonStr<ResponseResult>(result);

        //}

        //[WebMethod(Description = "上传讲评_动作掌握分数表（CommentForPose）,参数为json串")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string SendCommentForPoseList(string jsonstr)
        //{
        //    List<CommentForPose> splist = null;
        //    splist = JsonDeserialize<CommentForPose>(jsonstr);
        //    ResponseResult result = new ResponseResult();
        //    if (splist != null && splist.Count > 0)
        //    {
        //        string sql1 = string.Empty;
        //        string sql2 = string.Empty;
        //        int count1 = 0;
        //        int count2 = 0;
        //        int scusess = 0;
        //        int allrows = splist.Count;
        //        string returnstr = string.Empty;

        //        try
        //        {
        //            foreach (CommentForPose sp in splist)
        //            {
        //                sql2 = string.Format(" where ID='{0}' ", sp.ID);
        //                count2 = Global.SqlMapper.GetRowCount<CommentForPose>(sql2);
        //                if (count2 == 0)
        //                {
        //                    Global.SqlMapper.Create<CommentForPose>(sp);
        //                    scusess++;
        //                }

        //            }

        //            if (allrows != scusess)
        //            {
        //                result.Details = "部分数据与服务器数据冲突，不能上传!已上传数据【" + scusess + "】条.";
        //            }
        //            else
        //            {
        //                result.Details = "操作成功！已上传数据【" + scusess + "】条.";
        //            }
        //            result.Status = 1;
        //        }
        //        catch (Exception)
        //        {
        //            result.Status = 0;
        //            result.Details = "操作遇到问题！已上传数据【" + scusess + "】条.";

        //        }



        //    }
        //    else
        //    {
        //        result.Status = 0;
        //        result.Details = "json转换失败";
        //    }
        //    return GetJsonStr<ResponseResult>(result);

        //}

        //[WebMethod(Description = "上传讲评_动作掌握情况表（CommentForPoseInfo）,参数为json串")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string SendCommentForPoseInfoList(string jsonstr)
        //{
        //    List<CommentForPoseInfo> splist = null;
        //    splist = JsonDeserialize<CommentForPoseInfo>(jsonstr);
        //    ResponseResult result = new ResponseResult();
        //    if (splist != null && splist.Count > 0)
        //    {
        //        string sql1 = string.Empty;
        //        string sql2 = string.Empty;
        //        int count1 = 0;
        //        int count2 = 0;
        //        int scusess = 0;
        //        int allrows = splist.Count;
        //        string returnstr = string.Empty;

        //        try
        //        {
        //            foreach (CommentForPoseInfo sp in splist)
        //            {
        //                sql2 = string.Format(" where ID='{0}' ", sp.ID);
        //                count2 = Global.SqlMapper.GetRowCount<CommentForPoseInfo>(sql2);
        //                if (count2 == 0)
        //                {
        //                    Global.SqlMapper.Create<CommentForPoseInfo>(sp);
        //                    scusess++;
        //                }

        //            }

        //            if (allrows != scusess)
        //            {
        //                result.Details = "部分数据与服务器数据冲突，不能上传!已上传数据【" + scusess + "】条.";
        //            }
        //            else
        //            {
        //                result.Details = "操作成功！已上传数据【" + scusess + "】条.";
        //            }
        //            result.Status = 1;
        //        }
        //        catch (Exception)
        //        {
        //            result.Status = 0;
        //            result.Details = "操作遇到问题！已上传数据【" + scusess + "】条.";

        //        }



        //    }
        //    else
        //    {
        //        result.Status = 0;
        //        result.Details = "json转换失败";
        //    }
        //    return GetJsonStr<ResponseResult>(result);

        //}


        //[WebMethod(Description = "上传讲评_本组教员（CommentInGroup）,参数为json串")]
        //[ScriptMethod(UseHttpGet = false)]
        //public string SendCommentInGroupList(string jsonstr)
        //{
        //    List<CommentInGroup> splist = null;
        //    splist = JsonDeserialize<CommentInGroup>(jsonstr);
        //    ResponseResult result = new ResponseResult();
        //    if (splist != null && splist.Count > 0)
        //    {
        //        string sql1 = string.Empty;
        //        string sql2 = string.Empty;
        //        int count1 = 0;
        //        int count2 = 0;
        //        int scusess = 0;
        //        int allrows = splist.Count;
        //        string returnstr = string.Empty;

        //        try
        //        {
        //            foreach (CommentInGroup sp in splist)
        //            {
        //                sql2 = string.Format(" where ID='{0}' ", sp.ID);
        //                count2 = Global.SqlMapper.GetRowCount<CommentInGroup>(sql2);
        //                if (count2 == 0)
        //                {
        //                    Global.SqlMapper.Create<CommentInGroup>(sp);
        //                    scusess++;
        //                }

        //            }

        //            if (allrows != scusess)
        //            {
        //                result.Details = "部分数据与服务器数据冲突，不能上传!已上传数据【" + scusess + "】条.";
        //            }
        //            else
        //            {
        //                result.Details = "操作成功！已上传数据【" + scusess + "】条.";
        //            }
        //            result.Status = 1;
        //        }
        //        catch (Exception)
        //        {
        //            result.Status = 0;
        //            result.Details = "操作遇到问题！已上传数据【" + scusess + "】条.";

        //        }



        //    }
        //    else
        //    {
        //        result.Status = 0;
        //        result.Details = "json转换失败";
        //    }
        //    return GetJsonStr<ResponseResult>(result);

        //}
        // [WebMethod(Description = "测试链接是否成功")]
        // [ScriptMethod(UseHttpGet = false)]
        // public string IsConnected()
        //{
           
        //    ResponseResult result = new ResponseResult();
        //    result.Status = 1;
        //    return GetJsonStr<ResponseResult>(result);

        //}


        //#endregion

        ////#region 测试读取
        ////[WebMethod(Description = "读取测试")]
        //// [ScriptMethod(UseHttpGet = false)]
        ////public string SendUserList(string  str)
        ////{
        ////    List<mUser> userlist = null;
        ////    userlist=JsonDeserialize<mUser>(str);
        ////    if (userlist!=null&&userlist.Count>0)
        ////    {
        ////        return GetJsonStr<string>("1");

        ////    }
        ////    else
        ////    {
        ////        return GetJsonStr<string>("0");
        ////    }
           
           
        ////}
        ////#endregion



        //public static List<T> JsonDeserialize<T>(string jsonString) 
        //{
        //    List<T> obj = new List<T>();
        //    try
        //    {
        //         obj = jsonSerializer.Deserialize<List<T>>(jsonString);
        //    }
        //    catch (Exception)
        //    {
                
        //    }
        //     return obj; 
        //}

        //#endregion

        //class ResponseResult
        //{

        //    public string Details { get; set; }

        //    public int Status { get; set; }

        //}

    }
}
