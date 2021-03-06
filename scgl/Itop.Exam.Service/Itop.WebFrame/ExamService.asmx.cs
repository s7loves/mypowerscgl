﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using Newtonsoft.Json;
using Itop.Frame.Model;
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

            #region 考试相关


            #region 获取

            [WebMethod(Description = "反回考试列表，参数userid为用户ID")]
            [ScriptMethod(UseHttpGet = false)]
          
            public string GetExamList(string userid)
            {
                List<TurnE_Examination> tlist = new List<TurnE_Examination>();
                try
                {
                    string datatimestr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    string sqlwhere = " where StartTime<'" + datatimestr + "' and EndTime>'" + datatimestr + "' and UserIDS like '%," + userid + ",%'  and  id not in( select E_ID from dbo.E_ExamResult where IsExamed=1 and UserID='" + userid + "' ) order by StartTime asc";
                    IList<E_Examination> list = Global.SqlMapper.GetList<E_Examination>(sqlwhere);

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
                        tex.PdNum = ex.BySCol2;
                        tex.XzNum = ex.BySCol3;
                        tex.DxXzNum = ex.BySCol4;
                        tex.AllScore = ex.BySCol5;
                        tex.Remark = ex.Remark;
                        tlist.Add(tex);
                    }
                }
                catch (Exception)
                {
                }
                
                return GetJsonStr<TurnE_Examination>(tlist);
            }


            [WebMethod(Description = "反回已考试列表，参数userid为用户ID")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetHasExamList(string userid)
            {
                List<TurnE_Examination> tlist = new List<TurnE_Examination>();
                try
                {
                    string sql = " where ID in (select E_ID from dbo.E_ExamResult where IsExamed=1 and UserID='" + userid + "' ) order by StartTime desc";
                    IList<E_Examination> list = Global.SqlMapper.GetList<E_Examination>(sql);
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
                        tex.PdNum = ex.BySCol2;
                        tex.XzNum = ex.BySCol3;
                        tex.DxXzNum = ex.BySCol4;
                        tex.AllScore = ex.BySCol5;
                        tex.Remark = ex.Remark;
                        tlist.Add(tex);
                    }
                }
                catch (Exception)
                {

                }
               
                return GetJsonStr<TurnE_Examination>(tlist);
            }

            [WebMethod(Description = "反回考试试题列表，参数examid为考试ID")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetExamQuestionList(string examid)
            {
                Pdlist.Clear();
                Selectlist.Clear();
                MuSelectlist.Clear();
                IList<E_QuestionBank> returnlist = new List<E_QuestionBank>();

                try
                {

                    E_Examination exam = Global.SqlMapper.GetOneByKey<E_Examination>(examid);
                    if (exam != null)
                    {
                        E_ExaminationPaper eep = Global.SqlMapper.GetOneByKey<E_ExaminationPaper>(exam.EP_ID);
                        if (eep != null)
                        {
                            if (eep.Paper_Type == "指定试题")
                            {
                                //试题已经准备好了
                                if (eep.BySCol1 == "1")
                                {
                                        string strtemp = " select QuID from E_ExaminationPaperQuestion where ExID='" + eep.ID + "'";
                                        string stsqlwhere = " where ID in (" + strtemp + ") order by  Type";
                                        IList<E_QuestionBank> banklist = Global.SqlMapper.GetListByWhere<E_QuestionBank>(stsqlwhere);

                                        if (banklist.Count > 0)
                                        {
                                            foreach (E_QuestionBank item in banklist)
                                            {
                                                if (item.Type == "判断题")
                                                {
                                                    Pdlist.Add(item);
                                                }
                                                if (item.Type == "单项选择题")
                                                {
                                                    Selectlist.Add(item);
                                                }
                                                if (item.Type == "多项选择题")
                                                {
                                                    MuSelectlist.Add(item);
                                                }
                                            }
                                            //随机顺序
                                            if (eep.OrderRandom)
                                            {
                                                int[] pdtemparray = Helper.OrderINT(Pdlist.Count);
                                                for (int i = 0; i < pdtemparray.Length; i++)
                                                {
                                                    returnlist.Add(Pdlist[pdtemparray[i]]);
                                                }
                                                int[] selecttemparray = Helper.OrderINT(Selectlist.Count);
                                                for (int i = 0; i < selecttemparray.Length; i++)
                                                {
                                                    returnlist.Add(Selectlist[selecttemparray[i]]);
                                                }
                                                int[] muselecttemparray = Helper.OrderINT(MuSelectlist.Count);
                                                for (int i = 0; i < muselecttemparray.Length; i++)
                                                {
                                                    returnlist.Add(MuSelectlist[muselecttemparray[i]]);
                                                }
                                            }
                                            else
                                            {
                                                for (int i = 0; i < Pdlist.Count; i++)
                                                {
                                                    returnlist.Add(Pdlist[i]);
                                                }
                                                for (int i = 0; i < Selectlist.Count; i++)
                                                {
                                                    returnlist.Add(Selectlist[i]);
                                                }
                                                int[] muselecttemparray = Helper.OrderINT(MuSelectlist.Count);
                                                for (int i = 0; i < MuSelectlist.Count; i++)
                                                {
                                                    returnlist.Add(MuSelectlist[i]);
                                                }

                                            }


                                        }
                                        //没有试题,则用随机试题
                                        else
                                        {
                                            CreateRandomQuestion(eep.SettingID, returnlist);
                                        }
                                    
                                }
                                //没有准备好，则用随机试题
                                else
                                {
                                    CreateRandomQuestion(eep.SettingID, returnlist);
                                }
                            }
                            else if (eep.Paper_Type == "随机试题")
                            {
                                CreateRandomQuestion(eep.SettingID, returnlist);

                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
                
                return GetQuestionStr(returnlist);
            }


            [WebMethod(Description = "反回练习试题列表，参数pdnum为判断题数,参数dxnum为单面选择题数,参数mdxnum为多项选择题数")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetPracticeQuestionListRand(int pdnum,int dxnum,int mdxnum)
            {
               
                IList<E_QuestionBank> returnlist = new List<E_QuestionBank>();

                try
                {

                   CreateRandomQuestion(pdnum,dxnum,mdxnum, returnlist);

                }
                catch (Exception)
                {

                }
                return GetQuestionStr(returnlist);
            }


            [WebMethod(Description = "反回考试结果，参数examid为考试ID，userid为用户ID")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetExamResult(string examid, string userid)
            {
                PdaExamResult per = new PdaExamResult();
                try
                {
                    E_Examination exam = Global.SqlMapper.GetOneByKey<E_Examination>(examid);
                    string sqlresultwhere = " where E_ID='" + examid + "' and EP_ID='" + exam.EP_ID + "' and UserID='" + userid + "'";
                    IList<E_ExamResult> resultlist = Global.SqlMapper.GetList<E_ExamResult>(sqlresultwhere);
                    //有考试记录
                    if (resultlist.Count > 0)
                    {
                        //是否已经提交结果
                        if (resultlist[0].IsExamed)
                        {
                            //是否已经计算过分数
                            if (resultlist[0].BySCol1 == "1")
                            {
                                per.Score = resultlist[0].Score;
                                per.Pass = resultlist[0].IsPassed;
                            }

                            else
                            {
                                per = CountExamResult(examid, userid);
                            }

                        }

                    }
                }
                catch (Exception)
                {

                }
                return GetJsonStr<PdaExamResult>(per);
            }

            [WebMethod(Description = "反回考试结果，参数examid为考试ID，userid为用户ID,ReCount 是否重新算分")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetExamResultReCount(string examid, string userid, bool ReCount)
            {
                PdaExamResult per = new PdaExamResult();
                try
                {
                    E_Examination exam = Global.SqlMapper.GetOneByKey<E_Examination>(examid);
                    string sqlresultwhere = " where E_ID='" + examid + "' and EP_ID='" + exam.EP_ID + "' and UserID='" + userid + "'";
                    IList<E_ExamResult> resultlist = Global.SqlMapper.GetList<E_ExamResult>(sqlresultwhere);
                    //有考试记录
                    if (resultlist.Count > 0)
                    {
                        //是否已经提交结果
                        if (resultlist[0].IsExamed)
                        {
                            //是否已经计算过分数
                            if (resultlist[0].BySCol1 == "1")
                            {
                                // 是否重新计算分数
                                if (ReCount)
                                {
                                    per = CountExamResult(examid, userid);
                                }
                                else
                                {
                                    per.Score = resultlist[0].Score;
                                    per.Pass = resultlist[0].IsPassed;
                                }

                            }

                            else
                            {
                                per = CountExamResult(examid, userid);
                            }

                        }
                    }
                }
                catch (Exception)
                {

                }
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

                        if (DateTime.Now >= endtime)
                        {
                            rtime.Seconds = 0;
                        }
                        else
                        {
                            rtime.Seconds = (int)endtime.Subtract(DateTime.Now).TotalSeconds;

                        }
                    }
                }
                catch (Exception ee)
                {

                }
                return GetJsonStr<SysRemainingTime>(rtime);
            }

            [WebMethod(Description = "反回考试排名列表，参数examid为考试ID，topnum为用前多少名,topnum为零时返回当次考试所有排名")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetEaxmResultOrder(string examid, int topnum)
            {
                List<PdaExamResultOrder> tlist = new List<PdaExamResultOrder>();
                try
                {
                    string sqlwere = string.Empty;
                    if (topnum > 0)
                    {
                        sqlwere += " SELECT top " + topnum;
                    }
                    else
                    {
                        sqlwere += " SELECT ";
                    }
                    sqlwere += "  a.[ID],a.[E_ID],a.[EP_ID],a.[UserID],a.[RealStartTime], a.[RealEenTime],a.[IsExamed], a.[Score],a.[IsPassed],a.[Comment],a.[CheckPeople],a.[Sequence],a.[ShowScore],b.[UserName] as [BySCol1],c.[E_Name] as [BySCol2],a.[BySCol3], a.[BySCol4],a.[BySCol5],a.[Remark],a.[RowVersion]";
                    sqlwere += " FROM E_ExamResult as a,mUser as b,E_Examination  as c where a.[UserID]=b.[UserID] and a.[E_ID]=c.[ID] order by a.Score desc";

                    IList<E_ExamResult> resultlist = Global.SqlMapper.GetList<E_ExamResult>("SelectE_ExamResultOrder", sqlwere);


                    int i = 1;
                    foreach (E_ExamResult eer in resultlist)
                    {
                        PdaExamResultOrder per = new PdaExamResultOrder();
                        per.ID = eer.ID;
                        per.UserID = eer.UserID;
                        per.ExamID = eer.E_ID;
                        per.ExamName = eer.BySCol2;
                        per.UserName = eer.BySCol1;
                        per.OrderNum = i;
                        per.Score = eer.Score;
                        per.Pass = eer.IsPassed;
                        tlist.Add(per);
                        i++;
                    }

                }
                catch (Exception)
                {
                }
               
                return GetJsonStr<PdaExamResultOrder>(tlist);
            }

            [WebMethod(Description = "反回考试排名列表，参数examid为考试ID，userid为用户ID")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetEaxmResultOrderByUser(string examid, string userid)
            {
                PdaExamResultOrder per = new PdaExamResultOrder();
                try
                {
                    string sqlwere = string.Empty;
                    sqlwere += " SELECT ";
                    sqlwere += "  a.[ID],a.[E_ID],a.[EP_ID],a.[UserID],a.[RealStartTime], a.[RealEenTime],a.[IsExamed], a.[Score],a.[IsPassed],a.[Comment],a.[CheckPeople],a.[Sequence],a.[ShowScore],b.[UserName] as [BySCol1],c.[E_Name] as [BySCol2],a.[BySCol3], a.[BySCol4],a.[BySCol5],a.[Remark],a.[RowVersion]";
                    sqlwere += " FROM E_ExamResult as a,mUser as b,E_Examination  as c where a.[UserID]=b.[UserID] and a.[E_ID]=c.[ID] order by a.Score desc";

                    IList<E_ExamResult> resultlist = Global.SqlMapper.GetList<E_ExamResult>("SelectE_ExamResultOrder", sqlwere);
                    int i = 0;
                    foreach (E_ExamResult eer in resultlist)
                    {
                        i++;
                        if (eer.UserID == userid)
                        {
                            per.ID = eer.ID;
                            per.UserID = eer.UserID;
                            per.ExamID = eer.E_ID;
                            per.ExamName = eer.BySCol2;
                            per.UserName = eer.BySCol1;
                            per.OrderNum = i;
                            per.Score = eer.Score;
                            per.Pass = eer.IsPassed;
                        }
                    }
                }
                catch (Exception)
                {
                }
                return GetJsonStr<PdaExamResultOrder>(per);
            }

            [WebMethod(Description = "反回系统时间")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetSysTime()
            {
                SysTime time = new SysTime();
                time.Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); ;
                return GetJsonStr<SysTime>(time);
            }

            [WebMethod(Description = "校验登录，username用户名，pwd密码")]
            [ScriptMethod(UseHttpGet = false)]
            public string CheckLogin(string username, string pwd)
            {
                ResponseResultUser res = new ResponseResultUser();
                try
                {
                    string name = username.Trim();
                    string password = MainHelper.EncryptoPassword(pwd.Trim());
                    string sqlwhere = " where LoginID='" + name + "' and Password='" + password + "'";
                    IList<mUser> list = Global.SqlMapper.GetListByWhere<mUser>(sqlwhere);
                    if (list.Count > 0)
                    {
                        res.Status = 1;
                        res.Details = list[0].UserID;
                        res.UserName = list[0].UserName;
                    }
                    else
                    {
                        res.Status = 0;
                        res.Details = "验证失败!";
                    }
                }
                catch (Exception ee)
                {
                    res.Status = 0;
                    res.Details = ee.Message;
                }
               
                return GetJsonStr<ResponseResultUser>(res);
            }

            [WebMethod(Description = "反回题库列表")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetEQBankList()
            {
                List<TurnE_QBank> teqblist = new List<TurnE_QBank>();
                try
                {
                    IList<E_QBank> eqblist = Global.SqlMapper.GetListByWhere<E_QBank>(string.Empty);
                    foreach (E_QBank item in eqblist)
                    {
                        TurnE_QBank teqb = new TurnE_QBank();
                        teqb.ID = item.ID;
                        teqb.TKName = item.TKName;
                        teqb.Desc = item.Desc;
                        try {
                            teqb.EProList = GetTEPList(item.ID);
                            teqblist.Add(teqb);
                        }
                        catch { }
                    }
                }
                catch (Exception)
                {

                }
                
                return GetJsonStr<TurnE_QBank>(teqblist);
            }
            [WebMethod(Description = "反回题库列表,参数userid为用户ID")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetEQBankListByUserID(string userid)
            {
                List<TurnE_QBank> teqblist = new List<TurnE_QBank>();
                try
                {
                    string sqlwhere=" where  ID in (select  EBID from  dbo.E_R_EBankORG where ORGID in( select OrgCode from muser where UserID='"+userid+"'))";
                    IList<E_QBank> eqblist = Global.SqlMapper.GetListByWhere<E_QBank>(sqlwhere);
                    foreach (E_QBank item in eqblist)
                    {
                        TurnE_QBank teqb = new TurnE_QBank();
                        teqb.ID = item.ID;
                        teqb.TKName = item.TKName;
                        teqb.Desc = item.Desc;
                        teqb.EProList = GetTEPList(item.ID);
                        teqblist.Add(teqb);
                    }
                }
                catch (Exception)
                {

                }
                
                return GetJsonStr<TurnE_QBank>(teqblist);
            }
            [WebMethod(Description = "反回练习题列表（根据题库），tkid参数为题库ID，dxnum参数为判断题数，dxnum参数为单项选择题数，dxnum参数为多项选择题数")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetPractiseListByTK(string tkid, int pdnum, int dxnum, int dxxnum)
            {

                IList<E_QuestionBank> resultlist = new List<E_QuestionBank>();

                try
                {
                    IList<E_QuestionBank> pdlist = GetQuBankListByTK(tkid, "判断题");

                    IList<E_QuestionBank> dxlist = GetQuBankListByTK(tkid, "单项选择题");

                    IList<E_QuestionBank> dxxlist = GetQuBankListByTK(tkid, "多项选择题");

                    IList<E_QuestionBank> respdlist = new List<E_QuestionBank>();
                    IList<E_QuestionBank> resdxlist = new List<E_QuestionBank>();
                    IList<E_QuestionBank> resdxxlist = new List<E_QuestionBank>();

                    //随机生成判断题放入respdlist
                    RandSelectQuestion(pdlist, pdnum, respdlist);
                    //随机生成单项选择题放入resdxlist
                    RandSelectQuestion(dxlist, dxnum, resdxlist);
                    //随机生成多项选择题放入resdxxlist
                    RandSelectQuestion(dxxlist, dxnum, resdxxlist);

                    //将三项整合到结果表
                    AddQuestion(respdlist, resultlist);
                    AddQuestion(resdxlist, resultlist);
                    AddQuestion(resdxxlist, resultlist);

                }
                catch (Exception)
                {
                }
                return GetQuestionStr(resultlist);
            }

            [WebMethod(Description = "反回练习题列表（根据题库），tkid为题库ID，basepdnum为判断基数，dxnum为判断题数，basedxnum为单选基数，dxnum参数为单项选择题数，basedxxnum为多选基数，dxnum为多项选择题数")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetPractiseListByTKOrder(string tkid, int basepdnum, int pdnum, int basedxnum, int dxnum, int basedxxnum, int dxxnum)
            {

                IList<E_QuestionBank> resultlist = new List<E_QuestionBank>();
                try
                {
                    IList<E_QuestionBank> pdlist = GetQuBankListByTKOrder(tkid, "判断题", basepdnum, pdnum);

                    IList<E_QuestionBank> dxlist = GetQuBankListByTKOrder(tkid, "单项选择题", basepdnum, pdnum);

                    IList<E_QuestionBank> dxxlist = GetQuBankListByTKOrder(tkid, "多项选择题", basepdnum, pdnum);

                    //将三项整合到结果表
                    AddQuestion(pdlist, resultlist);
                    AddQuestion(dxlist, resultlist);
                    AddQuestion(dxxlist, resultlist);

                }
                catch (Exception)
                {
                    
                }
                return GetQuestionStr(resultlist);
            }

            [WebMethod(Description = "反回练习题列表（根据专业），zyid参数为专业ID，dxnum参数为判断题数，dxnum参数为单项选择题数，dxnum参数为多项选择题数")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetPractiseListByZY(string zyid, int pdnum, int dxnum, int dxxnum)
            {
                IList<E_QuestionBank> resultlist = new List<E_QuestionBank>();
                try
                {
                    IList<E_QuestionBank> pdlist = GetQuBankListByZY(zyid, "判断题");

                    IList<E_QuestionBank> dxlist = GetQuBankListByZY(zyid, "单项选择题");

                    IList<E_QuestionBank> dxxlist = GetQuBankListByZY(zyid, "多项选择题");

                    IList<E_QuestionBank> respdlist = new List<E_QuestionBank>();
                    IList<E_QuestionBank> resdxlist = new List<E_QuestionBank>();
                    IList<E_QuestionBank> resdxxlist = new List<E_QuestionBank>();

                    //随机生成判断题放入respdlist
                    RandSelectQuestion(pdlist, pdnum, respdlist);
                    //随机生成单项选择题放入resdxlist
                    RandSelectQuestion(dxlist, dxnum, resdxlist);
                    //随机生成多项选择题放入resdxxlist
                    RandSelectQuestion(dxxlist, dxnum, resdxxlist);

                    //将三项整合到结果表
                    AddQuestion(respdlist, resultlist);
                    AddQuestion(resdxlist, resultlist);
                    AddQuestion(resdxxlist, resultlist);
                }
                catch (Exception)
                {
                }
                return GetQuestionStr(resultlist);
            }


            [WebMethod(Description = "反回练习题列表（根据专业），tkid为题库ID，basepdnum为判断基数，dxnum为判断题数，basedxnum为单选基数，dxnum参数为单项选择题数，basedxxnum为多选基数，dxnum为多项选择题数")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetPractiseListByZYOrder(string zyid, int basepdnum, int pdnum, int basedxnum, int dxnum, int basedxxnum, int dxxnum)
            {
                IList<E_QuestionBank> resultlist = new List<E_QuestionBank>();
                try
                {
                    IList<E_QuestionBank> pdlist = GetQuBankListByZYOrder(zyid, "判断题", basepdnum, pdnum);

                    IList<E_QuestionBank> dxlist = GetQuBankListByZYOrder(zyid, "单项选择题", basepdnum, pdnum);

                    IList<E_QuestionBank> dxxlist = GetQuBankListByZYOrder(zyid, "多项选择题", basepdnum, pdnum);

                    //将三项整合到结果表
                    AddQuestion(pdlist, resultlist);
                    AddQuestion(dxlist, resultlist);
                    AddQuestion(dxxlist, resultlist);

                }
                catch (Exception)
                {

                }

                return GetQuestionStr(resultlist);
            }

            [WebMethod(Description = "反回模拟试题，tkid为题库ID")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetFalseExamQuestionList(string tkid)
            {
                string strresult = string.Empty;
                try
                {
                    strresult = GetPractiseListByTKFalseExam(tkid, FalseExamPdNum, FalseExamDxNum, FalseExamDXxNum);
                }
                catch (Exception)
                {

                }
                return strresult;
            }



            #region 通知、企业信息

            [WebMethod(Description = "反回通知列表，StartIndex为起始序号，Num为通知条数")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetENoticeList(int StartIndex,int Num)
            {
                List<TurnE_BusinesInfo> teqblist = new List<TurnE_BusinesInfo>();
                string sql = " select top " + Num + " * from (select top " + (Num +StartIndex-1)+ " * from dbo.E_BusinesInfo order by CreateTime desc ) as a order by a.CreateTime asc";
                try
                {
                    IList<E_BusinesInfo> eqblist = Global.SqlMapper.GetList<E_BusinesInfo>("SelectE_BusinesInfoByUserCondition", sql);

                    foreach (E_BusinesInfo item in eqblist)
                    {
                        TurnE_BusinesInfo teqb = new TurnE_BusinesInfo();
                        teqb.ID = item.ID;
                        teqb.Title = item.Title;
                        teqb.Content = item.Content;
                        teqb.Other =item.Other;
                        teqb.UserID = item.UserID;
                        teqb.CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                        teqblist.Add(teqb);
                    }
                }
                catch (Exception)
                {

                }
                return GetJsonStr<TurnE_BusinesInfo>(teqblist);
            }
            public List<TurnE_BusinesInfo> GetENoticeList2(int StartIndex, int Num)
            {
                List<TurnE_BusinesInfo> list = new List<TurnE_BusinesInfo>();
                string str = string.Concat(new object[] { " select top ", Num, " * from (select top ", (Num + StartIndex) - 1, " * from dbo.E_BusinesInfo order by CreateTime desc ) as a order by a.CreateTime desc" });
                try
                {
                    IList<E_BusinesInfo> list2 = Global.SqlMapper.GetList<E_BusinesInfo>("SelectE_BusinesInfoByUserCondition", str);
                    foreach (E_BusinesInfo info in list2)
                    {
                        TurnE_BusinesInfo item = new TurnE_BusinesInfo
                        {
                            ID = info.ID,
                            Title = info.Title,
                            UserID = info.UserID,
                            CreateTime = info.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")
                        };
                        list.Add(item);
                    }
                }
                catch (Exception)
                {
                }
                return list;
            }


            [WebMethod(Description = "反回通知，NoticeID为通知ID")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetENotice(string NoticeID)
            {
                TurnE_BusinesInfo teqb = new TurnE_BusinesInfo();
                try
                {
                    E_BusinesInfo item = Global.SqlMapper.GetOneByKey<E_BusinesInfo>(NoticeID);
                    teqb.ID = item.ID;
                    teqb.Title = item.Title;
                    teqb.Content = item.Content;
                    teqb.Other = item.Other;
                    teqb.UserID = item.UserID;
                    teqb.CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch (Exception)
                {

                }
                return GetJsonStr<TurnE_BusinesInfo>(teqb);
            }


            [WebMethod(Description = "反回企业信息表，StartIndex为起始序号，Num为企业信息条数")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetEBusinesInfoList(int StartIndex, int Num)
            {
                List<TurnE_Notice> teqblist = new List<TurnE_Notice>();
                string sql = " select top " + Num + " * from (select top " + (Num + StartIndex - 1) + " * from dbo.E_Notice order by CreateTime desc ) as a order by a.CreateTime asc";
                try
                {
                    IList<E_Notice> eqblist = Global.SqlMapper.GetList<E_Notice>("SelectE_NoticeListByUserCondition", sql);


                    foreach (E_Notice item in eqblist)
                    {
                        TurnE_Notice teqb = new TurnE_Notice();
                        teqb.ID = item.ID;
                        teqb.Title = item.Title;
                        teqb.Content = item.Content;
                        teqb.UserID = item.UserID;
                        teqb.CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                        teqblist.Add(teqb);
                    }
                }
                catch (Exception)
                {

                }
                return GetJsonStr<TurnE_Notice>(teqblist);
            }
            public List<TurnE_Notice> GetEBusinesInfoList2(int StartIndex, int Num)
            {
                List<TurnE_Notice> list = new List<TurnE_Notice>();
                string str = string.Concat(new object[] { " select top ", Num, " * from (select top ", (Num + StartIndex) - 1, " * from dbo.E_Notice order by CreateTime desc ) as a order by a.CreateTime desc" });
                try
                {
                    IList<E_Notice> list2 = Global.SqlMapper.GetList<E_Notice>("SelectE_NoticeListByUserCondition", str);
                    foreach (E_Notice notice in list2)
                    {
                        TurnE_Notice item = new TurnE_Notice
                        {
                            ID = notice.ID,
                            Title = notice.Title,
                            UserID = notice.UserID,
                            CreateTime = notice.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")
                        };
                        list.Add(item);
                    }
                }
                catch (Exception)
                {
                }
                return list;
            }


            [WebMethod(Description = "反回企业信息，BusinesInfoID为企业信息ID")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetEBusinesInfo(string BusinesInfoID)
            {
                TurnE_Notice teqb = new TurnE_Notice();
                try
                {
                    E_Notice item = Global.SqlMapper.GetOneByKey<E_Notice>(BusinesInfoID);
                    teqb.ID = item.ID;
                    teqb.Title = item.Title;
                    teqb.Content = item.Content;
                    teqb.UserID = item.UserID;
                    teqb.CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch (Exception)
                {

                }
                return GetJsonStr<TurnE_Notice>(teqb);
            }

            //存放附件文件目录
            static string FileDir = "Files";
            [WebMethod(Description = "反回通知附件,NoticeID通知ID")]
            [ScriptMethod(UseHttpGet = false)]
            public string GetENoticeFile(string NoticeID)
            {
                E_File efile = new E_File();
                try
                {
                 string BaseAddress=AppDomain.CurrentDomain.BaseDirectory+"/"+FileDir;
                 if (!Directory.Exists(BaseAddress))
                 {
                     Directory.CreateDirectory(BaseAddress);
                 }
                E_BusinesInfo eb = Global.SqlMapper.GetOneByKey<E_BusinesInfo>(NoticeID);
                if (eb!=null&&eb.WordData.Length>0)
                {
                   
                    string filename=eb.ID+eb.BySCol1;
                    string address = BaseAddress + "/" + filename;
                    GetFile(eb.WordData, address);


                     efile.FileName = eb.Other;
                     efile.Address = FileDir + "/" + filename;
                }
                }
                catch (Exception)
                {

                }
                return GetJsonStr<E_File>(efile);
            }

            #endregion




            #endregion


            #region 上传


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
                    if (erlist.Count > 0)
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
                        er.IsExamed = false;
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
                        erlist[0].IsExamed = true;
                        Global.SqlMapper.Update<E_ExamResult>(erlist[0]);
                        //计算考试结果
                        CountExamResult(examid, userid);
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
                        string sqlwhere = " where E_ID='" + splist[0].E_ID + "' and EP_ID='" + splist[0].EP_ID + "' and UserID='" + splist[0].UserID + "'";
                        Global.SqlMapper.DeleteByWhere<E_ExamAnswerResult>(sqlwhere);
                        for (int i = 0; i < splist.Count; i++)
                        {
                            E_ExamAnswerResult eear = new E_ExamAnswerResult();
                            eear.ID += i.ToString();
                            eear.E_ID = splist[i].E_ID;
                            eear.EP_ID = splist[i].EP_ID;
                            eear.UserID = splist[i].UserID;
                            eear.ExamQueston_ID = splist[i].ExamQueston_ID;
                            eear.ExamQuestonType = splist[i].ExamQuestonType;
                            eear.Answer = splist[i].Answer;
                            eear.RandomID = splist[i].RandomID;
                            Global.SqlMapper.Create<E_ExamAnswerResult>(eear);
                        }
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


            [WebMethod(Description = "上传练习记录，参数jsonstr为json串")]
            [ScriptMethod(UseHttpGet = false)]
            public string SendE_PracticeRecord(string jsonstr)
            {
                List<TurnE_PracticeRecord> splist = null;
                splist = JsonDeserialize<TurnE_PracticeRecord>(jsonstr);
                ResponseResult result = new ResponseResult();
                if (splist != null && splist.Count > 0)
                {

                    try
                    {
                        for (int i = 0; i < splist.Count; i++)
                        {
                            E_PracticeRecord eear = new E_PracticeRecord();
                            eear.ID += i.ToString();
                            eear.UserID = splist[i].UserID;
                            eear.PracticeDate = DateTime.Parse(splist[i].PracticeDate);
                            eear.PracticeNum = int.Parse(splist[i].PracticeNum);
                            eear.RightPercent = double.Parse(splist[i].RightPercent);
                            Global.SqlMapper.Create<E_PracticeRecord>(eear);
                        }
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
            #endregion



            #endregion


            #region 闯关相关

              #region 获取

                #region 关卡版本


                [WebMethod(Description = "获取闯关的版本信息")]
                [ScriptMethod(UseHttpGet = false)]
                public string GetLevelChat()
                {
                    ChatStr chat = new ChatStr();

                    int lastchat = 1;
                    try
                    {
                        lastchat = (int)Global.SqlMapper.GetObject("GetE_LevelChartBySqlWhere", "");

                    }
                    catch (Exception)
                    {
                    }
                    chat.Value = lastchat.ToString();
                    return GetJsonStr<ChatStr>(chat);
                }


                #endregion

                #region   季、关、站点
                [WebMethod(Description = "获取闯关关口站点信息")]
                [ScriptMethod(UseHttpGet = false)]
                public string GetLevelInfo()
                {
                    List<TurnSeason> tslist = new List<TurnSeason>();
                    List<TurnLevel> tllist = new List<TurnLevel>();
                    List<TurnLevelStop> tlslist = new List<TurnLevelStop>();

                    try
                    {
                        string sqlwhere = "  Order by Sequence asc";
                        IList<E_LevelSeason> elslist = Global.SqlMapper.GetList<E_LevelSeason>(sqlwhere);

                        foreach (E_LevelSeason item in elslist)
                        {
                            string sqlwhere2 = "  where SeasonID='" + item.ID + "' Order by Sequence asc";
                            IList<E_Level> elevellist = Global.SqlMapper.GetList<E_Level>(sqlwhere2);
                            tllist = new List<TurnLevel>();
                            foreach (E_Level item2 in elevellist)
                            {
                                string sqlwhere3 = "  where LevelID='" + item2.ID + "' Order by Sequence asc";
                                IList<E_LevelStop> Eelslist = Global.SqlMapper.GetList<E_LevelStop>(sqlwhere3);
                                tlslist = new List<TurnLevelStop>();
                                foreach (E_LevelStop item3 in Eelslist)
                                {
                                    TurnLevelStop tempstop = new TurnLevelStop();
                                    tempstop.ID = item3.ID;
                                    tempstop.SeasonID = item3.SeasonID;
                                    tempstop.LevelID = item3.LevelID;
                                    tempstop.Name = item3.Name;
                                    tempstop.Desc = item3.Desc;
                                    tempstop.Sequence = item3.Sequence;
                                    tempstop.QuestionAllNUM = item3.QuestionAllNUM;
                                    tempstop.Remark = item3.Remark;
                                    tlslist.Add(tempstop);

                                }
                                TurnLevel temptl = new TurnLevel();
                                temptl.ID = item2.ID;
                                temptl.SeasonID = item2.SeasonID;
                                temptl.Name = item2.Name;
                                temptl.Desc = item2.Desc;
                                temptl.Sequence = item2.Sequence;
                                temptl.StopNum = item2.StopNum;
                                temptl.ExChange = item2.ExChange;
                                temptl.Remark = item2.Remark;
                                temptl.StopList = tlslist;
                                tllist.Add(temptl);

                            }
                            TurnSeason tempts = new TurnSeason();
                            tempts.ID = item.ID;
                            tempts.Name = item.Name;
                            tempts.Desc = item.Desc;
                            tempts.Sequence = item.Sequence;
                            tempts.LevelNum = item.LevelNum;
                            tempts.Remark = item.Remark;
                            tempts.LevelList = tllist;
                            tslist.Add(tempts);

                        }
                    }
                    catch (Exception ee)
                    {
                    }
                    return GetJsonStr<TurnSeason>(tslist);
                }


                #endregion

                #region 闯关信息

                [WebMethod(Description = "获取闯关信息，参数userid为用户ID")]
                [ScriptMethod(UseHttpGet = false)]
                public string GetLevelInfoByUser(string userid)
                {
                    List<TurnSeasonState> tsslist = new List<TurnSeasonState>();
                    List<TurnLevelState> tlslist = new List<TurnLevelState>();
                    try
                    {
                        string sqlwhere = string.Empty;
                        sqlwhere += " SELECT    ID, Sequence, CASE WHEN( A.LevelNum=(SELECT     COUNT(*) AS Expr1 FROM  dbo.E_LevelTryRecord WHERE (SeasonID = A.ID and UserID='" + userid + "'))) Then 1 ELSE  0 end as State";
                        sqlwhere += " FROM   dbo.E_LevelSeason AS A  ORDER BY Sequence asc";

                        DataTable dt = Global.SqlMapper.GetDataTable("SelectDataTableBySql", sqlwhere);
                        tsslist = (List<TurnSeasonState>)ConvertHelper.ToIList<TurnSeasonState>(dt);

                        int lastState = 0;
                        for (int i = 0; i < tsslist.Count; i++)
                        {
                            //如果第一季为没有通过，则可以开始第一季
                            if (tsslist[i].State == 0 && i == 0)
                            {
                                tsslist[i].State = 2;
                            }
                            //如果上一季已通过，则本季可以开始
                            if (lastState == 1 && tsslist[i].State == 0)
                            {
                                tsslist[i].State = 2;
                            }
                            lastState = tsslist[i].State;

                            int lastLevelState = 0;
                            string sqlwhere2 = string.Empty;
                            sqlwhere2 += " SELECT ID, Sequence, CASE WHEN (SELECT     COUNT(*) AS Expr1  FROM  dbo.E_LevelTryRecord WHERE  (LevelID = A.ID  and UserID='" + userid + "' )) < 1 THEN 0 ELSE 1 END AS State, SeasonID ";
                            sqlwhere2 += " FROM  dbo.E_Level AS A where  A.SeasonID='" + tsslist[i].ID + "' ORDER BY Sequence asc";
                            DataTable dt2 = Global.SqlMapper.GetDataTable("SelectDataTableBySql", sqlwhere2);
                            tlslist = (List<TurnLevelState>)ConvertHelper.ToIList<TurnLevelState>(dt2);

                            for (int j = 0; j < tlslist.Count; j++)
                            {
                                if (tsslist[i].State == 2)
                                {
                                    //如果季可以开始，并且该季的第一关没有通过，则可以开始第一关
                                    if (tlslist[j].State == 0 && j == 0)
                                    {
                                        tlslist[j].State = 2;
                                        break;
                                    }
                                    //如果上一关已通过，则本关可以开始
                                    if (lastLevelState == 1 && tlslist[j].State == 0)
                                    {
                                        tlslist[j].State = 2;
                                        break;
                                    }
                                    lastLevelState = tlslist[j].State;
                                }
                            }
                            tsslist[i].LevelStateList = tlslist;

                        }

                    }
                    catch (Exception ee)
                    {

                    }
                    return GetJsonStr<TurnSeasonState>(tsslist);
                }

                #endregion

                #region 获取随机试题

                [WebMethod(Description = "获取闯关试题，参数stopid为站点ID")]
                [ScriptMethod(UseHttpGet = false)]
                public string GetQuestonListByLevelStop(string stopid)
                {
                    IList<E_QuestionBank> eqblist = new List<E_QuestionBank>();
                    try
                    {
                        E_LevelStop els = Global.SqlMapper.GetOneByKey<E_LevelStop>(stopid);
                        string pdstr = els.PdNumAndLevel;
                        string dxstr = els.DxNumAndLevel;
                        string ddxstr = els.DDxNumAndLevel;

                        string[] pdarray = pdstr.Split(';');
                        for (int i = 0; i < pdarray.Length; i++)
                        {
                            string[] pdarray2 = pdarray[i].Split(',');
                            if (pdarray2.Length == 2)
                            {
                                int nd = 0;
                                int xl = 0;
                                int.TryParse(pdarray2[0], out nd);
                                int.TryParse(pdarray2[1], out xl);
                                string sql = " where Type='判断题' and DifficultyLevel=" + nd;
                                IList<E_QuestionBank> templist = Global.SqlMapper.GetList<E_QuestionBank>(sql);
                                RandSelectQuestion(templist, xl, eqblist);

                            }
                        }

                        string[] dxarray = dxstr.Split(';');
                        for (int i = 0; i < dxarray.Length; i++)
                        {
                            string[] dxarray2 = dxarray[i].Split(',');
                            if (dxarray2.Length == 2)
                            {
                                int nd = 0;
                                int xl = 0;
                                int.TryParse(dxarray2[0], out nd);
                                int.TryParse(dxarray2[1], out xl);
                                string sql = " where Type='单项选择题' and DifficultyLevel=" + nd;
                                IList<E_QuestionBank> templist = Global.SqlMapper.GetList<E_QuestionBank>(sql);
                                RandSelectQuestion(templist, xl, eqblist);

                            }
                        }

                        string[] ddxarray = ddxstr.Split(';');
                        for (int i = 0; i < ddxarray.Length; i++)
                        {
                            string[] ddxarray2 = ddxarray[i].Split(',');
                            if (ddxarray2.Length == 2)
                            {
                                int nd = 0;
                                int xl = 0;
                                int.TryParse(ddxarray2[0], out nd);
                                int.TryParse(ddxarray2[1], out xl);
                                string sql = " where Type='多项选择题' and DifficultyLevel=" + nd;
                                IList<E_QuestionBank> templist = Global.SqlMapper.GetList<E_QuestionBank>(sql);
                                RandSelectQuestion(templist, xl, eqblist);

                            }
                        }
                    }
                    catch (Exception ee)
                    {


                    }

                    return GetQuestionStr(eqblist);
                }


                #endregion

                #region 获取分数
                [WebMethod(Description = "获取闯关分数，参数userid为用户ID")]
                [ScriptMethod(UseHttpGet = false)]
                public string GetUserScoreByUser(string userid)
                {
                    TurnE_UserScore teus = new TurnE_UserScore();
                    try
                    {
                        string sqlwhere = " where UserID='" + userid + "'";
                        E_UserScore ues = Global.SqlMapper.GetOne<E_UserScore>(sqlwhere);
                        if (ues != null)
                        {
                            teus.ID = ues.ID;
                            teus.AllScore = ues.AllScore;
                            teus.CurrtenScore = ues.CurrtenScore;
                            teus.UserID = ues.UserID;
                            teus.UpdateTime = ues.UpdateTime;
                        }

                    } 
                    catch (Exception)
                    {

                    }


                    return GetJsonStr<TurnE_UserScore>(teus);
                }
         
                #endregion

                #region 获取荣誉称号
                [WebMethod(Description = "获取荣誉称号，参数userid为用户ID")]
                [ScriptMethod(UseHttpGet = false)]
                public string GetUserHonoraryTitleByUser(string userid)
                {
                    TurnE_HonoraryTitle teht = new TurnE_HonoraryTitle();
                    try
                    {
                        string sqlwhere = " where UserID='" + userid + "'";
                        E_UserScore ues = Global.SqlMapper.GetOne<E_UserScore>(sqlwhere);

                        string sqlwhere2 = " where StartScore<=" + ues.CurrtenScore + " and " + ues.CurrtenScore + "<=EndScore";
                        E_HonoraryTitle eht = Global.SqlMapper.GetOne<E_HonoraryTitle>(sqlwhere2);
                        if (eht != null)
                        {
                            teht.Name = eht.HonoraryTitle;
                            teht.StartScore = eht.StartScore;
                            teht.EndScore = eht.EndScore;
                            
                        }

                    }
                    catch (Exception)
                    {

                    }
                    return GetJsonStr<TurnE_HonoraryTitle>(teht);
                }

                #endregion

                #region 奖品列表
                [WebMethod(Description = "获取奖品列表")]
                [ScriptMethod(UseHttpGet = false)]
                public string GetE_PrizeList()
                {
                    List<TurnE_Prize> teplist = new List<TurnE_Prize>();
                    
                    try
                    {
                        DateTime dt = DateTime.Now;
                        string sqlwhere = " where BeginDate<'" + dt + "'  and  '" + dt + "'< EndDate";
                        IList <E_Prize>  eplist= Global.SqlMapper.GetList<E_Prize>(sqlwhere);
                        foreach (E_Prize item in eplist)
                        {
                            TurnE_Prize tep = new TurnE_Prize();
                            tep.ID = item.ID;
                            tep.PrizeName = item.PrizeName;
                            tep.Type = item.Type;
                            tep.SelectChar = item.SelectChar;
                            tep.Image = item.Image;
                            tep.AllNum = item.AllNum;
                            tep.CurrentNum = item.CurrentNum;
                            tep.Desc = item.Desc;
                            tep.BeginDate = item.BeginDate;
                            tep.EndDate = item.EndDate;
                            tep.Price = item.Price;
                            teplist.Add(tep);
                        }

                    }
                    catch (Exception)
                    {

                    }


                    return GetJsonStr<TurnE_Prize>(teplist);
                }
                #endregion

                #region 道具列表
                [WebMethod(Description = "获取道具列表")]
                [ScriptMethod(UseHttpGet = false)]
                public string GetE_PropList()
                {
                    List<TrunE_Prop> teplist = new List<TrunE_Prop>();

                    try
                    {

                        IList<E_Prop> eplist = Global.SqlMapper.GetList<E_Prop>("");
                        foreach (E_Prop item in eplist)
                        {
                            TrunE_Prop tep = new TrunE_Prop();
                            tep.ID = item.ID;
                            tep.PropName = item.PropName;
                            tep.Function = item.Function;
                            tep.Code = item.Code;
                            tep.Price = item.Price;
                            teplist.Add(tep);
                        }

                    }
                    catch (Exception)
                    {

                    }
                    return GetJsonStr<TrunE_Prop>(teplist);
                }
                #endregion


                #region 某人道具列表
                [WebMethod(Description = "获取某人道具列表,参数userid为用户id")]
                [ScriptMethod(UseHttpGet = false)]
                public string GetE_PropListByUser(string userid)
                {
                    List<TrunE_UserProp> teplist = new List<TrunE_UserProp>();

                    try
                    {
                        string sqlwhere = " where UserID='" + userid + "'  and CanUseNum>0";

                        IList<E_UserProp> eplist = Global.SqlMapper.GetList<E_UserProp>(sqlwhere);
                        foreach (E_UserProp item in eplist)
                        {
                            TrunE_UserProp tep = new TrunE_UserProp();
                            tep.ID = item.ID;
                            tep.UserID = item.UserID;
                            tep.PropID = item.PropID;
                            tep.Num = item.Num;
                            tep.UsedNum = item.UsedNum;
                            tep.CanUseNum = item.CanUseNum;
                            teplist.Add(tep);
                        }

                    }
                    catch (Exception)
                    {

                    }
                    return GetJsonStr<TrunE_UserProp>(teplist);
                }
                #endregion


                #region 获取成绩排名
                [WebMethod(Description = "获取闯关成绩排名前50名")]
                [ScriptMethod(UseHttpGet = false)]
                public string GetE_UserScoreOrder()
                {
                    List<TrunE_UserScoreOrder> teplist = new List<TrunE_UserScoreOrder>();

                    try
                    {


                        IList<E_UserScore> eplist = Global.SqlMapper.GetList<E_UserScore>("SelectE_UserScoreListTopwushi", "");
                        foreach (E_UserScore item in eplist)
                        {
                            TrunE_UserScoreOrder tep = new TrunE_UserScoreOrder();
                            tep.ID = item.ID;
                            tep.UserName = item.UserID;
                            tep.AllScore = item.AllScore;
                            tep.CurrtenScore = item.CurrtenScore;
                            tep.Order = int.Parse(item.BySCol1);
                            teplist.Add(tep);
                        }

                    }
                    catch (Exception)
                    {

                    }
                    return GetJsonStr<TrunE_UserScoreOrder>(teplist);
                }
                #endregion
                #endregion

                #region 上传

                #region 上传闯关记录

                [WebMethod(Description = "上传闯关记录，参数jsonstr为json串")]
                [ScriptMethod(UseHttpGet = false)]
                public string SendE_LevelTryRecord(string jsonstr)
                {
                    List<TrunE_LevelTryRecord> splist = null;
                    splist = JsonDeserialize<TrunE_LevelTryRecord>(jsonstr);
                    ResponseResult result = new ResponseResult();
                    if (splist != null && splist.Count > 0)
                    {

                        try
                        {
                            for (int i = 0; i < splist.Count; i++)
                            {
                                E_LevelTryRecord eear = new E_LevelTryRecord();
                                eear.ID += i.ToString();
                                eear.UserID = splist[i].UserID;
                                eear.SeasonID = splist[i].SeasonID;
                                eear.LevelID = splist[i].LevelID;
                                eear.PassDate = splist[i].PassDate;
                                eear.TryTimes = splist[i].TryTimes;
                                eear.Remark = splist[i].Remark;

                                Global.SqlMapper.Create<E_LevelTryRecord>(eear);
                            }
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
                #endregion

                #region 上传兑换奖品记录
                [WebMethod(Description = "上传兑换奖品记录，参数userid为用户id,参数prizeid为奖品id,参数num为兑换奖品数量")]
                [ScriptMethod(UseHttpGet = false)]
                public string SendE_UserBuyPrize(string userid,string prizeid,int num)
                {
                    ResponseResult result = new ResponseResult();
                    try
                    {
                        E_Prize ep = Global.SqlMapper.GetOneByKey<E_Prize>(prizeid);
                        if (ep.CurrentNum>=num)
                        {
                            E_UserPrizeRecord eupr = new E_UserPrizeRecord();
                            eupr.UserID = userid;
                            eupr.PrizeID = prizeid;
                            eupr.PrizeNum = num;
                            eupr.SendTime = DateTime.Now;
                            eupr.HasFinished = false;
                            Global.SqlMapper.Create<E_UserPrizeRecord>(eupr);

                            result.Details = "成功";
                            result.Status = 1;
                        }
                        else
                        {
                            result.Status = 0;
                            result.Details = "当前奖品剩余数量："+ep.CurrentNum+" 个";
                        }

                       
                    }
                    catch (Exception)
                    {
                        result.Status = 0;
                        result.Details = "操作遇到问题！";

                    }
                   
                    return GetJsonStr<ResponseResult>(result);
                   
                }
                #endregion

                #region 上传购买道具记录
                [WebMethod(Description = "上传购买道具记录，参数userid为用户id,参数propid为道具id,参数num为购买道具数量")]
                [ScriptMethod(UseHttpGet = false)]
                public string SendE_UserBuyProp(string userid, string propid, int num)
                {
                    ResponseResult result = new ResponseResult();
                    try
                    {

                        E_UserPropRecord eupr = new E_UserPropRecord();
                        eupr.UserID = userid;
                        eupr.PropID = propid;
                        eupr.Num= num;
                        eupr.BuyOrUseTime = DateTime.Now;
                        eupr.Flag = "+1";
                        Global.SqlMapper.Create<E_UserPropRecord>(eupr);
                        result.Details = "成功";
                        result.Status = 1;
                      
                    }
                    catch (Exception)
                    {
                        result.Status = 0;
                        result.Details = "操作遇到问题！";

                    }

                    return GetJsonStr<ResponseResult>(result);

                }
                #endregion

                #region 上传使用道具记录
                [WebMethod(Description = "上传使用道具记录，参数userid为用户id,参数propid为道具id,参数num为使用道具数量")]
                [ScriptMethod(UseHttpGet = false)]
                public string SendE_UserUseProp(string userid, string propid, int num)
                {
                    ResponseResult result = new ResponseResult();
                    try
                    {
                        E_UserProp eup = Global.SqlMapper.GetOne<E_UserProp>(" where UserID='" + userid + "' and PropID='" + propid + "'");
                        //判断该用户的该种道具是否可用
                        if (eup.CanUseNum >= num)
                        {
                            E_UserPropRecord eupr = new E_UserPropRecord();
                            eupr.UserID = userid;
                            eupr.PropID = propid;
                            eupr.Num = num;
                            eupr.BuyOrUseTime = DateTime.Now;
                            eupr.Flag = "-1";
                            Global.SqlMapper.Create<E_UserPropRecord>(eupr);
                            result.Details = "成功";
                            result.Status = 1;
                        }
                        else
                        {
                            result.Details = "该用户的该种道具不足";
                            result.Status = 0;
                        }

                    }
                    catch (Exception)
                    {
                        result.Status = 0;
                        result.Details = "操作遇到问题！";

                    }

                    return GetJsonStr<ResponseResult>(result);

                }
                #endregion
                #region 上传闯关分数
                [WebMethod(Description = "上传闯关分数，参数userid为用户id,参数score为得分，参数remark为得分简纪")]
                [ScriptMethod(UseHttpGet = false)]
                public string SendE_UserScoreRecord(string userid, int score,string remark)
                {
                    ResponseResult result = new ResponseResult();
                    try
                    {
                        E_UserScoreRecord eusr = new E_UserScoreRecord();
                        eusr.UserID = userid;
                        eusr.Score = score;
                        eusr.Flag = "+1";
                        eusr.Reason = "闯关得分"; 
                        eusr.BySCol4 = remark;
                        eusr.CreateTime = DateTime.Now;
                        Global.SqlMapper.Create<E_UserScoreRecord>(eusr);

                        result.Details = "成功";
                        result.Status = 1;

                    }
                    catch (Exception)
                    {
                        result.Status = 0;
                        result.Details = "操作遇到问题！";

                    }

                    return GetJsonStr<ResponseResult>(result);

                }
                #endregion

              
                #endregion


            #endregion

        #endregion
              
        
        #region 辅助方法

                List<E_QuestionBank> Pdlist = new List<E_QuestionBank>();
        List<E_QuestionBank> Selectlist = new List<E_QuestionBank>();
        List<E_QuestionBank> MuSelectlist = new List<E_QuestionBank>();
        Random rand = new Random();

        /// <summary>
        /// 生成随机试题
        /// </summary>
        /// <param name="SetId">设置ID</param>
        /// <param name="eqblist">结果表</param>
        /// <returns></returns>
        private bool CreateRandomQuestion(string SetId, IList<E_QuestionBank> eqblist)
        {

            bool hasst = true;
            string sqlwhere = " where ESETID='" + SetId + "'";
            IList<E_R_ESetPro> eresblist = Global.SqlMapper.GetList<E_R_ESetPro>(sqlwhere);

            foreach (E_R_ESetPro item in eresblist)
            {

                string sqlwherepd = " where Professional='" + item.PROID + "' and Type='判断题'  and ByScol1!='del' ";
                IList<E_QuestionBank> eqpdblist = Global.SqlMapper.GetListByWhere<E_QuestionBank>(sqlwherepd);
                E_Professional ep = Global.SqlMapper.GetOneByKey<E_Professional>(item.PROID);

                RandSelectQuestion(eqpdblist, item.JudgeNUM, eqblist);

                string sqlwhereselect = " where Professional='" + item.PROID + "' and Type='单项选择题' and ByScol1!='del' ";
                IList<E_QuestionBank> eqselectblist = Global.SqlMapper.GetListByWhere<E_QuestionBank>(sqlwhereselect);

                RandSelectQuestion(eqselectblist, item.SelectNUM, eqblist);

                string sqlwheremuselect = " where Professional='" + item.PROID + "' and Type='多项选择题' and ByScol1!='del' ";
                IList<E_QuestionBank> eqmuselectblist = Global.SqlMapper.GetListByWhere<E_QuestionBank>(sqlwheremuselect);

                RandSelectQuestion(eqmuselectblist, item.MuSelectNUM, eqblist);

            }
            return hasst;
        }

        /// <summary>
        /// 生成随机试题
        /// </summary>
        /// <param name="pdnum">判断题数</param>
        /// <param name="dxnum">单选题数</param>
        /// <param name="mdxnum">多选题数</param>
        /// <param name="eqblist">结果列表</param>
        private void  CreateRandomQuestion(int pdnum, int dxnum,int mdxnum,IList<E_QuestionBank> eqblist)
        {

          
            string sqlwherepd = " where  Type='判断题'  and ByScol1!='del' ";
            IList<E_QuestionBank> eqpdblist = Global.SqlMapper.GetListByWhere<E_QuestionBank>(sqlwherepd);
           
            RandSelectQuestion(eqpdblist, pdnum, eqblist);

            string sqlwhereselect = " where  Type='单项选择题' and ByScol1!='del' ";
            IList<E_QuestionBank> eqselectblist = Global.SqlMapper.GetListByWhere<E_QuestionBank>(sqlwhereselect);

            RandSelectQuestion(eqselectblist, dxnum, eqblist);

            string sqlwheremuselect = " where Type='多项选择题' and ByScol1!='del' ";
            IList<E_QuestionBank> eqmuselectblist = Global.SqlMapper.GetListByWhere<E_QuestionBank>(sqlwheremuselect);

            RandSelectQuestion(eqmuselectblist, mdxnum, eqblist);

        }

        /// <summary>
        /// 从列表中随机取题
        /// </summary>
        /// <param name="eqlist">有试题的列表</param>
        /// <param name="randnum">选取试题数量</param>
        /// <param name="eqblist">生成的结果表</param>
        private void RandSelectQuestion(IList<E_QuestionBank> eqlist, int randnum, IList<E_QuestionBank> eqblist)
        {
            string type = eqlist[0].Type;
            int qunumall = eqlist.Count;
            //如果总试题数不多，小于2 倍的出题数，侧采用减少试题的方法
            if (eqlist.Count <= randnum * 2)
            {

                for (int i = 0; i < qunumall - randnum; i++)
                {
                    int index = rand.Next(eqlist.Count);
                    eqlist.RemoveAt(index);
                }
                AddQuestion(eqlist, eqblist);

            }
            else
            {
                //如果总试题比较多，侧采用抽选试题的方法
                Dictionary<string, E_QuestionBank> tempdic = new Dictionary<string, E_QuestionBank>();
                for (int i = 0; i < randnum; i++)
                {
                    bool hasdel = true;
                    while (hasdel)
                    {
                        int index = rand.Next(qunumall);
                        if (!tempdic.ContainsKey(eqlist[index].ID))
                        {
                            tempdic.Add(eqlist[index].ID, eqlist[index]);
                            hasdel = false;
                        }
                    }
                }
                AddQuestion(tempdic, eqblist);

            }

        }
        /// <summary>
        /// 从一个列表加入另一个列表
        /// </summary>
        /// <param name="frmeqlist">源表</param>
        /// <param name="toeqlist">目标表</param>
        private void AddQuestion(IList<E_QuestionBank> frmeqlist, IList<E_QuestionBank> toeqlist)
        {
            int i = 1;
            foreach (E_QuestionBank item in frmeqlist)
            {
                item.Sequence = i;
                toeqlist.Add(item);
                i++;
            }
        }

        /// <summary>
        /// 从一个列表加入另一个列表
        /// </summary>
        /// <param name="frmeqlist">源表</param>
        /// <param name="score"> 分数</param>
        /// <param name="toeqlist">目标表</param>
        private void AddQuestionFalseExam(IList<E_QuestionBank> frmeqlist, double score, IList<E_QuestionBank> toeqlist)
        {
            int i = 1;
            foreach (E_QuestionBank item in frmeqlist)
            {
                item.Sequence = i;
                item.ScoreNum = score;
                toeqlist.Add(item);
                i++;
            }
        }
        /// <summary>
        /// 从一个集合加入另一个表
        /// </summary>
        /// <param name="dicold">源集合</param>
        /// <param name="toeqlist">目标表</param>
        private void AddQuestion(Dictionary<string, E_QuestionBank> dicold, IList<E_QuestionBank> toeqlist)
        {
            int i = 1;
            foreach (string item in dicold.Keys)
            {
                E_QuestionBank eq = dicold[item];
                eq.Sequence = i;
                toeqlist.Add(eq);
                i++;
            }
        }

        /// <summary>
        /// 转换试题列表，反回json串
        /// </summary>
        /// <param name="list">试题列表 </param>
        /// <returns></returns>
        private string GetQuestionStr(IList<E_QuestionBank> list)
        {
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
                teq.Score = eq.ScoreNum;
                teq.DifficultyLevel = eq.DifficultyLevel;
                teq.Professional = eq.Professional;
                teq.Sequence = eq.Sequence;

                tlist.Add(teq);
            }
            return GetJsonStr<TurnE_QuestionBank>(tlist);

        }

        /// <summary>
        /// 获取专业列表
        /// </summary>
        /// <param name="eqbid">题库id</param>
        /// <returns></returns>
        private List<TurnE_Professional> GetTEPList(string eqbid)
        {

            List<TurnE_Professional> teplist = new List<TurnE_Professional>();

            IList<E_Professional> eplist = Global.SqlMapper.GetListByWhere<E_Professional>("");

            IList<E_R_EBankPro> ereblist = Global.SqlMapper.GetListByWhere<E_R_EBankPro>(" where EBID='" + eqbid + "'");
            foreach (E_R_EBankPro item in ereblist)
            {
                E_Professional ep = Global.SqlMapper.GetOneByKey<E_Professional>(item.PROID);
                if (ep == null) continue;
                TurnE_Professional tep = new TurnE_Professional();
                string sqlwhere = " where Professional='" + item.PROID + "' ";
                string pdsql = sqlwhere + " and Type='判断题' and ByScol1!='del' ";
                string dxsql = sqlwhere + " and Type='单项选择题' and ByScol1!='del' ";
                string dxxsql = sqlwhere + " and Type='多项选择题' and ByScol1!='del' ";


                tep.ID = item.PROID;
                tep.PName = ep.PName;
                tep.Desc = ep.Desc;
                tep.PdNum = Global.SqlMapper.GetRowCount<E_QuestionBank>(pdsql);
                tep.DxNum = Global.SqlMapper.GetRowCount<E_QuestionBank>(dxsql);
                tep.DXxNum = Global.SqlMapper.GetRowCount<E_QuestionBank>(dxxsql);

                teplist.Add(tep);
            }

            return teplist;
        }

        /// <summary>
        /// 根据题库ID及类型返回试题列表
        /// </summary>
        /// <param name="tkid">题库id</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        private IList<E_QuestionBank> GetQuBankListByTK(string tkid, string type)
        {

            IList<E_QuestionBank> eqblist = new List<E_QuestionBank>();
            IList<E_R_EBankPro> ereblist = Global.SqlMapper.GetListByWhere<E_R_EBankPro>(" where EBID='" + tkid + "' order by ProID asc");
            foreach (E_R_EBankPro item in ereblist)
            {
                string sqlwhere = " where Professional='" + item.PROID + "'  and Type='" + type + "' and ByScol1!='del'  order by Sequence asc";
                IList<E_QuestionBank> templist = Global.SqlMapper.GetListByWhere<E_QuestionBank>(sqlwhere);
                AddQuestion(templist, eqblist);
            }

            return eqblist;
        }

        /// <summary>
        /// 返回顺序试题列表
        /// </summary>
        /// <param name="tkid">题库id</param>
        /// <param name="type">类型</param>
        /// <param name="basenum">基数</param>
        /// <param name="num">题数</param>
        /// <returns></returns>
        private IList<E_QuestionBank> GetQuBankListByTKOrder(string tkid, string type, int basenum, int num)
        {
            IList<E_QuestionBank> eqblist = new List<E_QuestionBank>();
            IList<E_QuestionBank> reseqblist = new List<E_QuestionBank>();
            if (basenum > 0 && num > 0)
            {
                IList<E_R_EBankPro> ereblist = Global.SqlMapper.GetListByWhere<E_R_EBankPro>(" where EBID='" + tkid + "' order by ProID asc");
                foreach (E_R_EBankPro item in ereblist)
                {
                    string sqlwhere = " where Professional='" + item.PROID + "'  and Type='" + type + "' and ByScol1!='del'  order by Sequence asc";
                    IList<E_QuestionBank> templist = Global.SqlMapper.GetListByWhere<E_QuestionBank>(sqlwhere);
                    AddQuestion(templist, eqblist);
                }
                for (int i = basenum; i < basenum + num; i++)
                {
                    if (i < eqblist.Count)
                    {
                        reseqblist.Add(eqblist[i]);
                    }
                }
            }
            return reseqblist;
        }

        /// <summary>
        /// 根据专业ID及类型返回试题列表
        /// </summary>
        /// <param name="zyid">专业id</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        private IList<E_QuestionBank> GetQuBankListByZY(string zyid, string type)
        {
            IList<E_QuestionBank> eqblist = new List<E_QuestionBank>();
            string sqlwhere = " where Professional='" + zyid + "'  and Type='" + type + "' and ByScol1!='del'  order by Sequence asc";
            IList<E_QuestionBank> templist = Global.SqlMapper.GetListByWhere<E_QuestionBank>(sqlwhere);
            AddQuestion(templist, eqblist);

            return eqblist;
        }

        /// <summary>
        /// 返回顺序试题列表
        /// </summary>
        /// <param name="zyid">专业id</param>
        /// <param name="type">类型</param>
        /// <param name="basenum">基数</param>
        /// <param name="num">题数</param>
        /// <returns></returns>
        private IList<E_QuestionBank> GetQuBankListByZYOrder(string zyid, string type, int basenum, int num)
        {
            IList<E_QuestionBank> eqblist = new List<E_QuestionBank>();
            IList<E_QuestionBank> reseqblist = new List<E_QuestionBank>();
            if (basenum > 0 && num > 0)
            {
                string sqlwhere = " where Professional='" + zyid + "'  and Type='" + type + "' and ByScol1!='del'  order by Sequence asc";
                IList<E_QuestionBank> templist = Global.SqlMapper.GetListByWhere<E_QuestionBank>(sqlwhere);
                AddQuestion(templist, eqblist);

                for (int i = basenum; i < basenum + num; i++)
                {
                    if (i < eqblist.Count)
                    {
                        reseqblist.Add(eqblist[i]);
                    }
                }
            }


            return reseqblist;
        }

        /// <summary>
        /// 返回模拟考试试题
        /// </summary>
        /// <param name="tkid"></param>
        /// <param name="pdnum"></param>
        /// <param name="dxnum"></param>
        /// <param name="dxxnum"></param>
        /// <returns></returns>
        public string GetPractiseListByTKFalseExam(string tkid, int pdnum, int dxnum, int dxxnum)
        {

            IList<E_QuestionBank> resultlist = new List<E_QuestionBank>();

            IList<E_QuestionBank> pdlist = GetQuBankListByTK(tkid, "判断题");

            IList<E_QuestionBank> dxlist = GetQuBankListByTK(tkid, "单项选择题");

            IList<E_QuestionBank> dxxlist = GetQuBankListByTK(tkid, "多项选择题");

            IList<E_QuestionBank> respdlist = new List<E_QuestionBank>();
            IList<E_QuestionBank> resdxlist = new List<E_QuestionBank>();
            IList<E_QuestionBank> resdxxlist = new List<E_QuestionBank>();

            //随机生成判断题放入respdlist
            RandSelectQuestion(pdlist, pdnum, respdlist);
            //随机生成单项选择题放入resdxlist
            RandSelectQuestion(dxlist, dxnum, resdxlist);
            //随机生成多项选择题放入resdxxlist
            RandSelectQuestion(dxxlist, dxnum, resdxxlist);

            //将三项整合到结果表
            AddQuestionFalseExam(respdlist,FalseExamPdScore, resultlist);
            AddQuestionFalseExam(resdxlist,FalseExamDxScore,resultlist); 
            AddQuestionFalseExam(resdxxlist,FalseExamDXxScore, resultlist);

            return GetQuestionStr(resultlist);
        }


        /// <summary>
        /// 计算分数
        /// </summary>
        /// <param name="examid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        private PdaExamResult CountExamResult(string examid, string userid)
        {
            PdaExamResult per = new PdaExamResult();
            per.Score = 0;
            per.Pass = false;

            E_Examination exam = Global.SqlMapper.GetOneByKey<E_Examination>(examid);
            E_ExaminationPaper expaper = Global.SqlMapper.GetOneByKey<E_ExaminationPaper>(exam.EP_ID);
            E_ExamSetting eset = Global.SqlMapper.GetOneByKey<E_ExamSetting>(expaper.SettingID);

            string sqlwhere = "  b.E_ID='" + examid + "' and b.EP_ID='" + expaper.ID + "' and b.UserID='" + userid + "'";
            IList<E_QuestionBank> qqblist = Global.SqlMapper.GetList<E_QuestionBank>("SelectE_QuestionBankCount",sqlwhere);

            double score = 0;
                for (int i = 0; i < qqblist.Count; i++)
                {
                    if (qqblist[i].Type == "判断题")
                    {
                        bool temp = false;
                        if (bool.TryParse(qqblist[i].Answer, out temp))
                        {
                            bool temp2 = false;
                            if (bool.TryParse(qqblist[i].BySCol5, out temp2))
                            {
                                if (temp == temp2)
                                {
                                    score += eset.JudgeScore;
                                }
                            }

                        }

                    }
                    if (qqblist[i].Type == "单项选择题")
                    {
                        if (qqblist[i].Answer.Trim() == qqblist[i].BySCol5.Trim())
                        {
                            score += eset.SelectScore;
                        }
                    }
                    if (qqblist[i].Type == "多项选择题")
                    {
                        if (qqblist[i].Answer.Trim() == qqblist[i].BySCol5.Trim())
                        {
                            score += eset.MuSelectScore;
                        }
                    }

                }
                per.Score = score;
                if (score >= eset.PassScore)
                {
                    per.Pass = true;
                }

            string sqlresultwhere = " where E_ID='" + examid + "' and EP_ID='" + expaper.ID + "' and UserID='" + userid + "'";
            IList<E_ExamResult> resultlist = Global.SqlMapper.GetList<E_ExamResult>(sqlresultwhere);
            if (resultlist.Count > 0)
            {
                resultlist[0].Score = per.Score;
                resultlist[0].IsPassed = per.Pass;
                resultlist[0].BySCol1 = "1";
                Global.SqlMapper.Update<E_ExamResult>(resultlist[0]);
            }
            return per;

        }
        #endregion


        #region 属性定义

        /// <summary>
        /// 模拟考试判断题数
        /// </summary>
        private static int FalseExamPdNum = 10;
        /// <summary>
        /// 模拟考试单项选择题数
        /// </summary>
        private static int FalseExamDxNum = 10;
        /// <summary>
        /// 模拟考试多项选择题数
        /// </summary>
        private static int FalseExamDXxNum = 10;


        /// <summary>
        /// 模拟考试判断题每题分数
        /// </summary>
        private static double FalseExamPdScore = 3;
        /// <summary>
        /// 模拟考试单项选择每题分数
        /// </summary>
        private static double FalseExamDxScore = 3;
        /// <summary>
        /// 模拟考试多项选择每题分数
        /// </summary>
        private static double FalseExamDXxScore = 4;


        #endregion


        #region 其它

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

        public static void GetFile(byte[] bt, string filename)
        {
            BinaryWriter bw;
            FileStream fs;
            try
            {
                fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                bw = new BinaryWriter(fs);
                bw.Write(bt);
                bw.Flush();
                bw.Close();
                fs.Close();

            }
            catch
            {

            }
        }

        #endregion





    }
}
        