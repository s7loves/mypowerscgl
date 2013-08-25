using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.Data;
using Itop.Frame.Model;

namespace Itop.WebFrame
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string HelloWorld1(string text)
        {
            return text;
        }

        [WebMethod]
        public string HelloWorld2(string text, string text1)
        {
            return text + "," + text1;
        }
        [WebMethod]
        public string GetWish(string value1, string value2, string value3, int value4)
        {
            return string.Format("祝您在{3}年里 {0}、{1}、{2}", value1, value2, value3, value4);
        }
        [WebMethod]
        public List<int> GetArray(int i)
        {
            List<int> list = new List<int>();
            while (i >= 0)
            {
                list.Add(i--);
            }
            return list;
        }
        [WebMethod]
        public Class1 GetClass()
        {
            Class1 a = new Class1();
            a.ID = "1";
            a.Value = "牛年大吉";
            return a;
        }
        [WebMethod]
        public DataSet GetDataSet()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Table1");
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Value", Type.GetType("System.String"));
            DataRow dr = dt.NewRow();
            dr["ID"] = "1";
            dr["Value"] = "新年快乐";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["ID"] = "2";
            dr["Value"] = "万事如意";
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary> 
        /// 传入参数 
        /// </summary> 
        /// <param name="name"></param> 
        /// <returns></returns> 
        [WebMethod]
        public string Hello(string name)
        {
            return string.Format("Hello {0}", name);
        }

        /// <summary> 
        /// 返回泛型列表 
        /// </summary> 
        /// <param name="i"></param> 
        /// <returns></returns> 
        [WebMethod]
        public List<int> CreateArray(int i)
        {
            List<int> list = new List<int>();

            while (i >= 0)
            {
                list.Add(i--);
            }

            return list;
        }

        /// <summary> 
        /// 返回复杂类型 
        /// </summary> 
        /// <param name="name"></param> 
        /// <param name="age"></param> 
        /// <returns></returns> 
        [WebMethod]
        public Person GetPerson(string name, int age)
        {
            return new Person()
            {
                Name = name,
                Age = age
            };
        }
        #region 获取用户信息



        [WebMethod]

        public void GetUserList(string userName)
        {

            List<Personal> m_PersonalList = new List<Personal>();

            string[] strArr = userName.Split(',');

            foreach (string item in strArr)
            {

                Personal m_Personal = GetUserByName(item);

                if (m_Personal != null)
                {

                    m_PersonalList.Add(m_Personal);

                }

            }

            ResponseResult responseResult = new ResponseResult();

            if (m_PersonalList.Count == 0)
            {

                responseResult.ResponseDetails = "没有查到该用户！";

                responseResult.ResponseStatus = 0;

            }

            else
            {

                responseResult.ResponseData = m_PersonalList;

                responseResult.ResponseDetails = "查询用户信息成功！";

                responseResult.ResponseStatus = 1;

            }

            string jsoncallback = HttpContext.Current.Request["jsoncallback"];

            //返回数据的方式

            //  其中将泛型集合使用了Json库(第三方序列json数据的dll)转变成json数据字符串

            string result = jsoncallback + "(" + JsonConvert.SerializeObject(responseResult, Formatting.Indented) + ")";

            HttpContext.Current.Response.Write(result);

            HttpContext.Current.Response.End();

        }
           [WebMethod]
        public void GetUserListNew(string sqlwhere)
        {
            //List<mUser> userlist = (List<mUser>)Global.SqlMapper.GetList<mUser>(sqlwhere);
            //ResponseResult2 responseResult = new ResponseResult2();
            
            //if (userlist.Count == 0)
            //{

            //    responseResult.ResponseDetails = "没有查到该用户！";

            //    responseResult.ResponseStatus = 0;

            //}

            //else
            //{

            //    responseResult.ResponseData = userlist;

            //    responseResult.ResponseDetails = "查询用户信息成功！";

            //    responseResult.ResponseStatus = 1;

            //}

            //string jsoncallback = HttpContext.Current.Request["jsoncallback"];

            ////返回数据的方式

            ////  其中将泛型集合使用了Json库(第三方序列json数据的dll)转变成json数据字符串

            //string result = jsoncallback + "(" + JsonConvert.SerializeObject(responseResult, Formatting.Indented) + ")";

            //HttpContext.Current.Response.Write(result);

            //HttpContext.Current.Response.End();

        }
           [WebMethod]
           public void GetUserListNew3(string sqlwhere)
           {
               //sqlwhere = " where usercode='admin'";
               //List<mUser> userlist = (List<mUser>)Global.SqlMapper.GetList<mUser>(sqlwhere);
               //ResponseResult responseResult = new ResponseResult();

               //List<Personal> perlist = new List<Personal>();
               //Personal aa = new Personal();
               //aa.Name = userlist[0].UserName;
               //aa.Id = userlist[0].UserID;
               //perlist.Add(aa);
               //if (userlist.Count == 0)
               //{

               //    responseResult.ResponseDetails = "没有查到该用户！";

               //    responseResult.ResponseStatus = 0;

               //}

               //else
               //{

               //    responseResult.ResponseData = perlist;

               //    responseResult.ResponseDetails = "查询用户信息成功！";

               //    responseResult.ResponseStatus = 1;

               //}

               //string jsoncallback = HttpContext.Current.Request["jsoncallback"];

               ////返回数据的方式

               ////  其中将泛型集合使用了Json库(第三方序列json数据的dll)转变成json数据字符串

               //string result = jsoncallback + "(" + JsonConvert.SerializeObject(responseResult, Formatting.Indented) + ")";

               //HttpContext.Current.Response.Write(result);

               //HttpContext.Current.Response.End();

           }

        #endregion



        #region 模拟数据库处理结果



        /// <summary>

        /// 根据用户名查询用户

        /// </summary>

        /// <param name="userName">用户名</param>

        /// <returns></returns>

        Personal GetUserByName(string userName)
        {

            List<Personal> m_PersonalList = new List<Personal>();

            m_PersonalList.Add(new Personal()

            {

                Id = "01",

                Name = "liger_zql",

                Sex = "男",

                Age = 21,

                Remark = "你猜......"

            });

            m_PersonalList.Add(new Personal()

            {

                Id = "02",

                Name = "漠然",

                Sex = "女",

                Age = 22,

                Remark = "猜不透......"

            });

            foreach (Personal m_Personal in m_PersonalList)
            {

                if (m_Personal.Name == userName)
                {

                    return m_Personal;

                }

            }

            return null;

        }



        #endregion



        #region json数据序列化所需类



        /// <summary>

        /// 处理信息类

        ///     ResponseData--输出处理数据

        ///     ResponseDetails--处理详细信息

        ///     ResponseStatus--处理状态

        ///         -1=失败,0=没有获取数据,1=处理成功！

        /// </summary>

        class ResponseResult
        {

            public List<Personal> ResponseData { get; set; }

            public string ResponseDetails { get; set; }

            public int ResponseStatus { get; set; }

        }
        class ResponseResult2
        {

            //public List<mUser> ResponseData { get; set; }

            public string ResponseDetails { get; set; }

            public int ResponseStatus { get; set; }

        }


        /// <summary>

        /// 用户信息类

        /// </summary>

        class Personal
        {

            public string Id { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }

            public string Sex { get; set; }

            public string Remark { get; set; }

        }



        #endregion

    }

    /// <summary> 
    /// 复杂类型 
    /// </summary> 
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
    //自定义的类，只有两个属性 
    public class Class1
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }
}