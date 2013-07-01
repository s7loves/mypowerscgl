using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;


namespace Ebada.Scgl.Outer
{
    public class YYUpdate
    {


        /// <summary>
        /// 数据操作失败时记录该100条的条件，以备重新作操
        /// </summary>
        Dictionary<string, string> errordic = new Dictionary<string, string>();

        //oracle操作类
        OraHelper orahelper = new OraHelper();
        SqlServerHelper sqlherlper = new SqlServerHelper();
       
        //一次读取数据库记录条数
        int OneDelNumber = 100;

        //更新失败的
        Dictionary<int, DataTable> updatedic = new Dictionary<int, DataTable>();
        //插入失败的
        Dictionary<int, DataTable> insertdic = new Dictionary<int, DataTable>();

        /// <summary>
        /// 更新用户表，规则：从oracel数据库读取用户数据，以“用户编号”为匹配依据，如果sqlServer中存在该用户数据则更新，不存在则插入
        /// </summary>
        /// <returns></returns>
        public bool UpdateUserTable()
        {
            UpdateLog.WritLog("sdfasdfasfdaghsdfghsdfgsdfgdf99234892384g");
            int errortimes = 0;
            string errorstr = string.Empty;
            updatedic.Clear();
            insertdic.Clear();

            string updateerror=string.Empty;
            string inserterror=string.Empty;

            bool result = false;
            //用户代码字段
            string usercode=GetOraUserSql("sqlusercode");
            //sqlserver用户表名
            string sqltable=GetOraUserSql("sqltablename");

            int recordcount = 0;
            //处理次数
            int times = orahelper.GetPageCount(GetOraUserSql("orakey"), GetOraUserSql("oratablename"), "", OneDelNumber,ref  recordcount);
            for (int i = 1; i <= times; i++)
            {
                //从oracel查询数据
                DataTable dt = orahelper.GetDataSet(GetOraUserSql(""), OneDelNumber, i, "table").Tables["table"];

                //生成用户代码字符串
                string usercodestr = GetUserCode(dt, usercode);

                //从sql数据查询已有的用户代码
                string sqlusercode = " select " + usercode + "  from " + sqltable + " where " + usercode + " in (" + usercodestr + ")";

                ////则试
                //test.Test();

                DataTable sqldt = sqlherlper.GetDataSet(sqlusercode, "sqltable").Tables["sqltable"];

                //将已有用户代码保存
                Dictionary<string, string> usercodedic = GetDic(sqldt, usercode);

                //建立副本结构
                DataTable dtupdate = dt.Copy();
                DataTable dtinsert = dt.Copy();
                dtupdate.Rows.Clear();
                dtinsert.Rows.Clear();

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (!usercodedic.ContainsKey(dt.Rows[j][usercode].ToString()))
                    {
                        dtinsert.Rows.Add(dt.Rows[j].ItemArray);
                    }
                    else
                    {
                        dtupdate.Rows.Add(dt.Rows[j].ItemArray);
                    }

                }
                //更新失败则记录
                if (dtupdate.Rows.Count>0)
                {
                    if (!sqlherlper.CommitTransUpDate(dtupdate, sqltable, usercode,  out updateerror))
                    {
                        updatedic.Add(i,dtupdate);

                    }
                    
                }
                //插入失败则记录
                 if (dtinsert.Rows.Count>0)
                {
                    if (!sqlherlper.CommitTransInsert(dtinsert, sqltable, "ID",out inserterror))
                    {
                        insertdic.Add(i, dtinsert);

                    }
                    
                }
            }

            
            //处理失败的记录
            if (updatedic.Count>0)
            {              
                foreach (int key in updatedic.Keys)
                {
                    int temptimes=0;
                    if (!sqlherlper.CommitTransUpDateOneByone(updatedic[key], sqltable, usercode,out temptimes,out updateerror))
                    {
                        errortimes += temptimes;
                        errorstr +="\r\n更新数据错误【" +updateerror+"】";
                    }
                }
                
            }
            if (insertdic.Count > 0)
            {
                foreach (int key in insertdic.Keys)
                {
                    int temptimes = 0;
                    if (!sqlherlper.CommitTransInsertOneByOne(insertdic[key], sqltable, "ID",out temptimes,out inserterror))
                    {
                        errortimes += temptimes;
                        errorstr += "\r\n插入数据错误【" + updateerror + "】";
                    }
                }
               

            }
            if ((insertdic.Count+updatedic.Count)==0)
            {
                result = true;
            }
            string log = string.Empty;
            if (result)
            {
                log = " 更新数据成功，更新记录[" + recordcount+"]条";
            }
            else
            {
                log = " 更新数据， 有失败记录 \r\n总计录数【" + recordcount + "】条 \r\n成功【" + (recordcount - errortimes) + "】条 \r\n失败【" +errortimes+ "】条";
                log += "\r\n详细信息如下：\r\n" + errorstr;
            }
            
            UpdateLog.WritLog(log);
            return result;
        }
        //拼接字符串
        private string GetUserCode(DataTable dt,string fieldname)
        {
            string result = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += "'"+dt.Rows[i][fieldname]+"',";
            }
            if (result.Length>0)
            {
                result=result.Substring(0,result.Length-1);
            }
            return result;
        }
        //将已有的用户加入字典,将做更新处理，其它人做插入处理
        private Dictionary<string, string> GetDic(DataTable dt, string fieldname)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!dic.ContainsKey(dt.Rows[i][fieldname].ToString()))
                {
                    dic.Add(dt.Rows[i][fieldname].ToString(), dt.Rows[i][fieldname].ToString());
                }
            }
            return dic;
        }
        #region Oracel 数据库查询语句
        
        #endregion
        public string GetOraUserSql( string key)
        {
            #region oracel表信息

            #endregion
            ////ora表名
            //string oratablename = "";
            ////主键
            //string oraKeyField = "";
            ////用户编号
            //string orausercode = "";
            ////用户名
            //string orausername = "";
            ////类型
            //string oratype = "";
            ////地址
            //string oraaddress = "";
            ////表箱号
            //string orabxcode = "";
            ////表号
            //string orabcode = "";
            ////电话
            //string oratelnumber = "";
            ////电价
            //string oradprice = "";
            ////所属台区
            //string orasutqcode = "";

            #region 测试

            //ora表名
            string oratablename = "YY_ORAUSER";
            //主键
            string oraKeyField = "IDA";
            //用户编号
            string orausercode = "ORACODE";
            //用户名
            string orausername = "ORANAME";
            //类型
            string oratype = "TYPE";
            //地址
            string oraaddress = "ADDRESS";
            //表箱号
            string orabxcode = "BXCODE";
            //表号
            string orabcode = "BCODE";
            //电话
            string oratelnumber = "TELNUMBER";
            //电价
            string oradprice = "DPRICE";
            //所属台区
            string orasutqcode = "SUDQ";
            #endregion



            #region sql表信息
            //ora表名
            string sqltablename = "YY_user";
            //主键
            string sqlKeyField = "ID";
            //用户编号
            string sqlusercode = "UserCode";
            //用户名
            string sqlusername = "UserName";
            //类型
            string sqltype = "Type";
            //地址
            string sqladdress = "Address";
            //表箱号
            string sqlbxcode = "BxCode";
            //表号
            string sqlbcode = "BCode";
            //电话
            string sqltelnumber = "TelNumber";
            //电价
            string sqldprice = "DPrice";
            //所属台区
            string sqlsutqcode = "SuTqCode";

            #endregion

            string sql = " select ";
            sql += orausercode + " as " + sqlusercode + ", ";
            sql += orausername + " as " + sqlusername + ", ";
            sql += oratype + " as " + sqltype + ", ";
            sql += oraaddress + " as " + sqladdress + ", ";
            sql += orabxcode + " as " + sqlbxcode + ", ";
            sql += orabcode + " as " + sqlbcode + ", ";
            sql += oratelnumber + " as " + sqltelnumber + ", ";
            sql += oradprice + " as " + sqldprice + ", ";
            sql += orasutqcode + " as " + sqlsutqcode;
            sql += " from " + oratablename;

            if (key == "oratablename")
            {
                return oratablename;
            }
            if (key=="orakey")
            {
                return oraKeyField;
            }
            if (key == "sqltablename")
            {
                return sqltablename;
            }
            if (key == "sqlkey")
            {
                return sqlKeyField;
            }

            if (key == "sqlusercode")
            {
                return sqlusercode;
            }

            return sql;

        }

    }
}
