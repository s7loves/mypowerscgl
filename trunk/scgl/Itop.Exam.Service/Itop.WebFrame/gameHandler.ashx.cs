using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using Itop.Frame.BLL;
namespace Itop.WebFrame {
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class gameHandler : IHttpHandler {
        static JavaScriptSerializer jsonHelper = new JavaScriptSerializer();
        static List<GameScore> _scoreList = null;
        
        public static List<GameScore> ScoreList {
            get {
                if (_scoreList == null)
                    _scoreList = dbGameHelper.getScores();
                return _scoreList;
            }
            set {
                _scoreList = value;
            }
        }
        static object lockObj = new object();
        public void ProcessRequest(HttpContext context) {
            GameResult result = new GameResult();
            string m = context.Request.QueryString["method"];
            if (!string.IsNullOrEmpty(m)) {
                switch (m.ToLower()) {
                    case "getranking"://获取排名
                        result = getRanking(context);
                        break;
                    case "setscore":
                        result = setScore(context);
                        break;
                    case "getscore":
                        result = getScore(context);
                        break;
                    default:
                        result.errorCode = -1;
                        result.result = "不支持的方法调用!";
                        break;
                }
            } else {
                result.errorCode = -1;
                result.result = "不支持的方法调用!";
            }
            context.Response.ContentType = "application/json;charset=utf-8";            
            context.Response.Write(jsonHelper.Serialize(result));
            context.Response.End();
        }

        private GameResult getScore(HttpContext context) {
            GameResult result = new GameResult();
            string username = context.Request.Params["username"];
            if (!string.IsNullOrEmpty(username)) {
                GameScore gs = new GameScore() { username = username };
                lock (lockObj) {
                    foreach (GameScore score in ScoreList) {
                        if (score.username == username) {
                            gs.score = score.score;
                            break;
                        }
                    }
                }
                result.data = jsonHelper.Serialize(gs);
            }

            return result;
        }

        private GameResult setScore(HttpContext context) {
            GameResult result = new GameResult();
            string data = context.Request.Params["data"];

            if (!string.IsNullOrEmpty(data)) {
                GameScore gs = null;
                try {
                   gs= Newtonsoft.Json.JsonConvert.DeserializeObject<GameScore>(data);
                
                
                } catch {

                }
                if (gs != null && !string.IsNullOrEmpty(gs.username)) {
                    lock (lockObj) {
                        List<GameScore> scoreList = ScoreList;
                        bool isupdate = false;
                        for (int i = scoreList.Count-1; i>=0 ; i--) {
                            if (gs.username == scoreList[i].username ) {
                                if (gs.score > scoreList[i].score) {
                                    scoreList.RemoveAt(i);
                                    break;
                                } else {
                                    return result;
                                }
                            }
                        }

                        for (int i = 0; i < scoreList.Count; i++) {
                            if (gs.score > scoreList[i].score) {
                                scoreList.Insert(i, gs);
                                dbGameHelper.Update(gs);
                                gs = null;
                                break;
                            }
                        }
                        if (gs != null) {
                            scoreList.Add(gs);
                            dbGameHelper.Update(gs);
                        }
                    }
                } else {
                    result.errorCode = -3;
                    result.result = "成绩提交格式非法!";
                }

            } else {

                result.errorCode = -3;
                result.result = "成绩提交格式非法!";
            }


            return result;
        }

        private GameResult getRanking(HttpContext context) {
            GameResult result = new GameResult();
            string gameKey = context.Request.Params["gamekey"];
            string limit = context.Request.Params["limit"];
            int nlimit = 5;
            int.TryParse(limit, out nlimit);
            List<GameScore> scoreList = ScoreList;
            nlimit = Math.Min(scoreList.Count, Math.Max(nlimit, 5));
            if (gameKey == "dafeiji") {
                result.data = jsonHelper.Serialize(scoreList.GetRange(0,nlimit));

            } else {
                result.result = "不支持的游戏类型排名";
                result.errorCode = -2;
            }
            return result;
        }
        class GameResult {
            public string result = "OK";
            public int errorCode = 0;
            public string data = "";
        }
        
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}
