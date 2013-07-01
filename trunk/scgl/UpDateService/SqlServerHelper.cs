using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;

namespace UpDateService
{
    public class SqlServerHelper
    {
        //获取数据库连接字符串，其属于静态变量且只读，项目中所有文档可以直接使用，但不能修改
        //private static string ConnectionStringLocalTransaction = ConfigurationManager.AppSettings["SqlConnStr"];

       public  SqlServerHelper()
        {
            ConnStr = ConfigurationManager.AppSettings["SqlConnStr"].ToString();
            Conn = new SqlConnection(ConnStr);
        }
       private static string ConnStr;
       public static SqlConnection Conn;

       #region 打开数据库连接
       /// <summary>
       /// 打开数据库连接
       /// </summary>
       private static void Open()
       {
           //打开数据库连接

           if (Conn.State == ConnectionState.Closed)
           {
               try
               {
                   //打开数据库连接
                   Conn.Open();
               }
               catch (Exception e)
               {
                   throw e;
               }
           }
       }
       #endregion
       #region 关闭数据库连接
       /// <summary>
       /// 关闭数据库连接
       /// </summary>
       private static void Close()
       {
           //判断连接的状态是否已经打开
           if (Conn.State == ConnectionState.Open)
           {
               Conn.Close();
           }
       }
       #endregion

       // 哈希表用来存储缓存的参数信息，哈希表可以存储任意类型的参数。
       private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

       /// <summary>
       ///执行一个不需要返回值的SqlCommand命令，通过指定专用的连接字符串。
       /// 使用参数数组形式提供参数列表 
       /// </summary>
       /// <remarks>
       /// 使用示例：
       ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
       /// </remarks>
       /// <param name="connectionString">一个有效的数据库连接字符串</param>
       /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
       /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
       /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
       /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
       public  int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
       {

           SqlCommand cmd = new SqlCommand();

           using (SqlConnection conn = new SqlConnection(connectionString))
           {
               //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中
               PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
               int val = cmd.ExecuteNonQuery();

               //清空SqlCommand中的参数列表
               cmd.Parameters.Clear();
               return val;
           }
       }

       /// <summary>
       ///执行一条不返回结果的SqlCommand，通过一个已经存在的数据库连接 
       /// 使用参数数组提供参数
       /// </summary>
       /// <remarks>
       /// 使用示例：  
       ///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
       /// </remarks>
       /// <param name="conn">一个现有的数据库连接</param>
       /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
       /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
       /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
       /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
       public  int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
       {

           SqlCommand cmd = new SqlCommand();

           PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
           int val = cmd.ExecuteNonQuery();
           cmd.Parameters.Clear();
           return val;
       }

       /// <summary>
       /// 执行一条不返回结果的SqlCommand，通过一个已经存在的数据库事物处理 
       /// 使用参数数组提供参数
       /// </summary>
       /// <remarks>
       /// 使用示例： 
       ///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
       /// </remarks>
       /// <param name="trans">一个存在的 sql 事物处理</param>
       /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
       /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
       /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
       /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
       public  int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
       {
           SqlCommand cmd = new SqlCommand();
           PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
           int val = cmd.ExecuteNonQuery();
           cmd.Parameters.Clear();
           return val;
       }

       /// <summary>
       /// 执行一条返回结果集的SqlCommand命令，通过专用的连接字符串。
       /// 使用参数数组提供参数
       /// </summary>
       /// <remarks>
       /// 使用示例：  
       ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
       /// </remarks>
       /// <param name="connectionString">一个有效的数据库连接字符串</param>
       /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
       /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
       /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
       /// <returns>返回一个包含结果的SqlDataReader</returns>
       public  SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
       {
           SqlCommand cmd = new SqlCommand();
           SqlConnection conn = new SqlConnection(connectionString);

           // 在这里使用try/catch处理是因为如果方法出现异常，则SqlDataReader就不存在，
           //CommandBehavior.CloseConnection的语句就不会执行，触发的异常由catch捕获。
           //关闭数据库连接，并通过throw再次引发捕捉到的异常。
           try
           {
               PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
               SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
               cmd.Parameters.Clear();
               return rdr;
           }
           catch
           {
               conn.Close();
               throw;
           }
       }

       /// <summary>
       /// 执行一条返回第一条记录第一列的SqlCommand命令，通过专用的连接字符串。 
       /// 使用参数数组提供参数
       /// </summary>
       /// <remarks>
       /// 使用示例：  
       ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
       /// </remarks>
       /// <param name="connectionString">一个有效的数据库连接字符串</param>
       /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
       /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
       /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
       /// <returns>返回一个object类型的数据，可以通过 Convert.To{Type}方法转换类型</returns>
       public  object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
       {
           SqlCommand cmd = new SqlCommand();

           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
               object val = cmd.ExecuteScalar();
               cmd.Parameters.Clear();
               return val;
           }
       }

       /// <summary>
       /// 执行一条返回第一条记录第一列的SqlCommand命令，通过已经存在的数据库连接。
       /// 使用参数数组提供参数
       /// </summary>
       /// <remarks>
       /// 使用示例： 
       ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
       /// </remarks>
       /// <param name="conn">一个已经存在的数据库连接</param>
       /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
       /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
       /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
       /// <returns>返回一个object类型的数据，可以通过 Convert.To{Type}方法转换类型</returns>
       public  object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
       {

           SqlCommand cmd = new SqlCommand();

           PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
           object val = cmd.ExecuteScalar();
           cmd.Parameters.Clear();
           return val;
       }

       /// <summary>
       /// 缓存参数数组
       /// </summary>
       /// <param name="cacheKey">参数缓存的键值</param>
       /// <param name="cmdParms">被缓存的参数列表</param>
       public  void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
       {
           parmCache[cacheKey] = commandParameters;
       }

       /// <summary>
       /// 获取被缓存的参数
       /// </summary>
       /// <param name="cacheKey">用于查找参数的KEY值</param>
       /// <returns>返回缓存的参数数组</returns>
       public  SqlParameter[] GetCachedParameters(string cacheKey)
       {
           SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

           if (cachedParms == null)
               return null;

           //新建一个参数的克隆列表
           SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

           //通过循环为克隆参数列表赋值
           for (int i = 0, j = cachedParms.Length; i < j; i++)
               //使用clone方法复制参数列表中的参数
               clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

           return clonedParms;
       }

       /// <summary>
       /// 为执行命令准备参数
       /// </summary>
       /// <param name="cmd">SqlCommand 命令</param>
       /// <param name="conn">已经存在的数据库连接</param>
       /// <param name="trans">数据库事物处理</param>
       /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
       /// <param name="cmdText">Command text，T-SQL语句 例如 Select * from Products</param>
       /// <param name="cmdParms">返回带参数的命令</param>
       private  void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
       {

           //判断数据库连接状态
           if (conn.State != ConnectionState.Open)
               conn.Open();

           cmd.Connection = conn;
           cmd.CommandText = cmdText;

           //判断是否需要事物处理
           if (trans != null)
               cmd.Transaction = trans;

           cmd.CommandType = cmdType;

           if (cmdParms != null)
           {
               foreach (SqlParameter parm in cmdParms)
                   cmd.Parameters.Add(parm);
           }
       }

       public  DataSet GetDataSet(string sql, string DataSetName)
       {
           DataSet ds = new DataSet();
           Open();//打开数据连接
           SqlDataAdapter adapter = new SqlDataAdapter(sql, Conn);
           adapter.Fill(ds, DataSetName);
           Close();//关闭数据库连接
           return ds;
       }

       public bool CommitTransUpDate(DataTable dt, string tablename, string fieldkey,  out string errorstr)
       {
           DataRow errow = dt.NewRow();
           bool result = true;
           Open();
           SqlTransaction trans = Conn.BeginTransaction();
           try
           {
               string str = string.Empty;
               foreach (DataColumn col in dt.Columns)
               {
                   if (col.ColumnName != fieldkey)
                   {
                       str += "[" + col.ColumnName + "]=@" + col.ColumnName + " ,";
                   }

               }
               if (str.Length > 0)
               {
                   str = str.Substring(0, str.Length - 1);
               }
               str += " where [" + fieldkey + "]=@" + fieldkey;
               foreach (DataRow dr in dt.Rows)
               {
                   errow = dr;
                   SqlCommand cm = new SqlCommand();
                   cm.Connection = Conn;
                   cm.Transaction = trans;

                   cm.CommandText = "update   " + tablename + "   set   " + str;
                   foreach (DataColumn col in dt.Columns)
                   {
                       cm.Parameters.Add("@" + col.ColumnName,GetType(col));
                       cm.Parameters["@" + col.ColumnName].Value = dr[col.ColumnName];
                   }
                   cm.ExecuteNonQuery();
               }
                trans.Commit();
           }
           catch
           {
               result = false;
               trans.Rollback();
           }
           finally
           {
               Close();
               trans.Dispose();

           }
           errorstr = errow.ItemArray.ToString();
           return result;
       }
       public bool CommitTransUpDateOneByone(DataTable dt, string tablename, string fieldkey, out int errortimes, out string errorstr)
       {
           DataRow errow = dt.NewRow();
           bool result = true;
           int times=0;
           string strcw = string.Empty;
           Open();
           SqlTransaction trans = Conn.BeginTransaction();
           try
           {
               string str = string.Empty;
               foreach (DataColumn col in dt.Columns)
               {
                   if (col.ColumnName != fieldkey)
                   {
                       str += "[" + col.ColumnName + "]=@" + col.ColumnName + " ,";
                   }

               }
               if (str.Length > 0)
               {
                   str = str.Substring(0, str.Length - 1);
               }
               str += " where [" + fieldkey + "]=@" + fieldkey;
               foreach (DataRow dr in dt.Rows)
               {
                   try
                   {
                       errow = dr;
                       SqlCommand cm = new SqlCommand();
                       cm.Connection = Conn;
                       cm.Transaction = trans;

                       cm.CommandText = "update   " + tablename + "   set   " + str;
                       foreach (DataColumn col in dt.Columns)
                       {
                           cm.Parameters.Add("@" + col.ColumnName, GetType(col));
                           cm.Parameters["@" + col.ColumnName].Value = dr[col.ColumnName];
                       }
                       cm.ExecuteNonQuery();

                       trans.Commit();
                   }
                   catch 
                   {
                       times++;
                       strcw += "\r\n" + errow.ItemArray.ToString();
                       break;
                   }
                  
     
               }
              
           }
           catch
           {
               result = false;
               trans.Rollback();
           }
           finally
           {
               Close();
               trans.Dispose();

           }
           errortimes = times;
           errorstr = strcw;
           return result;
       }
       public bool CommitTransInsert(DataTable dt, string tablename, string fieldkey,out string errorstr)
       {
           bool result = true;
           Open();
           SqlTransaction trans = Conn.BeginTransaction();
           DataRow errow = dt.NewRow();
           int index = 0;
           try
           {
               string strcol = string.Empty;
               string strvalue = string.Empty;
               strcol += "[" + fieldkey + "] ,";
               strvalue += "@" + fieldkey + " ,";

               foreach (DataColumn col in dt.Columns)
               {
                   if (col.ColumnName != fieldkey)
                   {
                       strcol += "[" + col.ColumnName + "] ,";
                       strvalue += "@" + col.ColumnName + " ,";
                   }

               }

               if (strcol.Length > 0)
               {
                   strcol = strcol.Substring(0, strcol.Length - 1);
               }
               if (strvalue.Length > 0)
               {
                   strvalue = strvalue.Substring(0, strvalue.Length - 1);
               }
               foreach (DataRow dr in dt.Rows)
               {
                   errow = dr;
                   SqlCommand cm = new SqlCommand();
                   cm.Connection = Conn;
                   cm.Transaction = trans;

                   if (index == 9)
                   {
                       index = 0;
                   }
                   index++;
                   cm.CommandText = "insert  into  " + tablename + " (" + strcol + ") values (" + strvalue + ")";
                   cm.Parameters.Add("@" + fieldkey,SqlDbType.NVarChar);
                   cm.Parameters["@" + fieldkey].Value = Newid() + index;
                   foreach (DataColumn col in dt.Columns)
                   {
                       cm.Parameters.Add("@" + col.ColumnName, GetType(col));
                       cm.Parameters["@" + col.ColumnName].Value = dr[col.ColumnName];
                   }
                   cm.ExecuteNonQuery();
               }
                trans.Commit();
           }
           catch
           {
               result = false;
               trans.Rollback();
           }
           finally
           {
               Close();
               trans.Dispose();

           }
           errorstr = errow.ItemArray.ToString();
           return result;
       }
       public bool CommitTransInsertOneByOne(DataTable dt, string tablename, string fieldkey, out int errortimes, out string errorstr)
       {
           bool result = true;
           Open();
           int times = 0;
           string strcw = string.Empty;

           SqlTransaction trans = Conn.BeginTransaction();
           DataRow errow = dt.NewRow();
           int index = 0;
           try
           {
               string strcol = string.Empty;
               string strvalue = string.Empty;
               strcol += "[" + fieldkey + "] ,";
               strvalue += "@" + fieldkey + " ,";

               foreach (DataColumn col in dt.Columns)
               {
                   if (col.ColumnName != fieldkey)
                   {
                       strcol += "[" + col.ColumnName + "] ,";
                       strvalue += "@" + col.ColumnName + " ,";
                   }

               }

               if (strcol.Length > 0)
               {
                   strcol = strcol.Substring(0, strcol.Length - 1);
               }
               if (strvalue.Length > 0)
               {
                   strvalue = strvalue.Substring(0, strvalue.Length - 1);
               }
               foreach (DataRow dr in dt.Rows)
               {
                   try
                   {
                       errow = dr;
                       SqlCommand cm = new SqlCommand();
                       cm.Connection = Conn;
                       cm.Transaction = trans;

                       if (index == 9)
                       {
                           index = 0;
                       }
                       index++;
                       cm.CommandText = "insert  into  " + tablename + " (" + strcol + ") values (" + strvalue + ")";
                       cm.Parameters.Add("@" + fieldkey, SqlDbType.NVarChar);
                       cm.Parameters["@" + fieldkey].Value = Newid() + index;
                       foreach (DataColumn col in dt.Columns)
                       {
                           cm.Parameters.Add("@" + col.ColumnName, GetType(col));
                           cm.Parameters["@" + col.ColumnName].Value = dr[col.ColumnName];
                       }
                       cm.ExecuteNonQuery();
                       trans.Commit();
                   }
                   catch 
                   {
                       times++;
                       strcw += "\r\n" + errow.ItemArray.ToString();
                       break;

                   }
                  
               }
              
           }
           catch
           {
               result = false;
               trans.Rollback();
           }
           finally
           {
               Close();
               trans.Dispose();

           }
           errortimes = times;
           errorstr = strcw;
           return result;
       }
       public static string Newid()
       {
           return DateTime.Now.ToString("yyyyMMddHHmmssfff");
       }
       public static  Dictionary<string, SqlDbType> typdic = new Dictionary<string, SqlDbType>();
       public SqlDbType GetType(DataColumn col)
       {
           string name = col.DataType.Name;
           if (!typdic.ContainsKey(name))
           {
               if (name== typeof(DateTime).Name)
               {
                   typdic.Add(name, SqlDbType.DateTime);
               }
               else
               {
                   if (name== typeof(bool).Name)
                   {
                       typdic.Add(name, SqlDbType.Bit);
                   }
                   else
                   {
                       if (name== typeof(byte).Name)
                       {
                           typdic.Add(name, SqlDbType.TinyInt);
                       }
                       else
                       {
                           if (name== typeof(short).Name )
                           {
                               typdic.Add(name, SqlDbType.SmallInt);
                           }
                           else
                           {
                               if (name== typeof(int).Name)
                               {
                                   typdic.Add(name, SqlDbType.Int);
                               }
                               else
                               {
                                   if (name== typeof(long).Name)
                                   {
                                       typdic.Add(name, SqlDbType.BigInt);
                                   }
                                   else
                                   {
                                       if (name== typeof(float).Name)
                                       {
                                           typdic.Add(name, SqlDbType.Real);
                                       }
                                       else
                                       {
                                           if (name== typeof(double).Name || name== typeof(decimal).Name)
                                           {
                                               typdic.Add(name, SqlDbType.Float);
                                           }
                                           else
                                           {
                                               if (name== typeof(byte[]).Name)
                                               {
                                                   typdic.Add(name, SqlDbType.Image);
                                               }
                                               else
                                               {
                                                  typdic.Add(name, SqlDbType.VarChar);
   
                                               }
                                           }
                                       }
                                   }
                               }
                           }
                       }
                   }
               }

           }

          return typdic[name];
       }
    }
}



