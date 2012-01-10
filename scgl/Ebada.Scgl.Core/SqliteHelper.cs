using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Ebada.Scgl.Core {
    public class SqliteHelper {
        /// <summary>
        /// 获得连接对象
        /// </summary>
        /// <returns></returns>
        public static SQLiteConnection GetSQLiteConnection() {
            return new SQLiteConnection(ConnStr);
        }
        public static string ConnStr = @"Data Source=scgl.db";
        /// <summary>
        /// 修改数据表记录
        /// </summary>
        /// <returns></returns>
        public static bool UpdateTable(DataTable srcTable, string tableName) {
            bool isok = false;
            try {
                SQLiteCommand command = new SQLiteCommand();
                using (SQLiteConnection conn = GetSQLiteConnection()) {
                    if (conn.State != ConnectionState.Open) conn.Open();
                    command.Connection = conn;
                    command.CommandText = "SELECT * FROM " + tableName;
                    SQLiteDataAdapter SQLiteDA = new SQLiteDataAdapter(command);
                    SQLiteCommandBuilder SQLiteCB = new SQLiteCommandBuilder(SQLiteDA);
                    SQLiteDA.InsertCommand = SQLiteCB.GetInsertCommand();
                    SQLiteDA.DeleteCommand = SQLiteCB.GetDeleteCommand();
                    SQLiteDA.UpdateCommand = SQLiteCB.GetUpdateCommand();
                    SQLiteDA.Update(srcTable);
                }
                isok = true;
            } catch { ;}
            return isok;
        }
        /// <summary>
        /// 读取返回数据表
        /// </summary>        
        public static DataTable ExecuteDataTable(string SQLStr) {
            DataTable datatable = new DataTable("mytabe");
            SQLiteCommand command = new SQLiteCommand();
            using (SQLiteConnection conn = GetSQLiteConnection()) {
                if (conn.State != ConnectionState.Open) conn.Open();
                command.Connection = conn;
                command.CommandText = SQLStr;
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                da.Fill(datatable);
                conn.Close();
            }
            return datatable;
        }

        /// <summary>
        /// 返回受影响的行数
        /// </summary>       
        public static int UpdateData(string SQLStr) {
            SQLiteCommand command = new SQLiteCommand();
            using (SQLiteConnection conn = GetSQLiteConnection()) {
                if (conn.State != ConnectionState.Open) conn.Open();
                command.Connection = conn;
                command.CommandText = SQLStr;
                command.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
        }
        //绑定数据表格
        public static void BindGrid(DataGridView mydatagrid, string SQLStr) {
            mydatagrid.DataSource = ExecuteDataTable(SQLStr);
        }
        //绑定数据下拉式文本框
        public static void BindCbox(ComboBox cbox, string SQLStr, string DspyFld) {
            cbox.DataSource = ExecuteDataTable(SQLStr);
            cbox.DisplayMember = DspyFld;
        }
        //设定数据表格的列宽
        public static void SetGridWidth(DataGridView mydatagrid, int[] width) {
            for (int i = 0; i < width.Length; i++)
                mydatagrid.Columns[i].Width = width[i];
        }
        //返回得到data数据
        public static string[,] GetData(string SQLStr) {
            DataTable datatable = ExecuteDataTable(SQLStr);
            string[,] reData = new string[datatable.Rows.Count, datatable.Columns.Count];
            for (int i = 0; i < datatable.Rows.Count; i++) {
                for (int j = 0; j < datatable.Columns.Count; j++) {
                    reData[i, j] = datatable.Rows[i][j].ToString();
                }
            }
            return reData;
        }
        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, string cmdText, params object[] p) {

            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Parameters.Clear();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 30;

            if (p != null) {
                foreach (object parm in p)
                    cmd.Parameters.AddWithValue(string.Empty, parm);
                //for (int i = 0; i < p.Length; i++)
                //    cmd.Parameters[i].Value = p[i];
            }
        }

        public static DataSet ExecuteDataset(string cmdText, params object[] p) {
            DataSet ds = new DataSet();
            SQLiteCommand command = new SQLiteCommand();
            using (SQLiteConnection connection = GetSQLiteConnection()) {
                PrepareCommand(command, connection, cmdText, p);
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                da.Fill(ds);
            }

            return ds;
        }

        public static DataRow ExecuteDataRow(string cmdText, params object[] p) {
            DataSet ds = ExecuteDataset(cmdText, p);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0];
            return null;
        }

        /// <summary>
        /// 返回受影响的行数
        /// </summary>
        /// <param name="cmdText">a</param>
        /// <param name="commandParameters">传入的参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText, params object[] p) {
            SQLiteCommand command = new SQLiteCommand();

            using (SQLiteConnection connection = GetSQLiteConnection()) {
                PrepareCommand(command, connection, cmdText, p);
                return command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 返回SqlDataReader对象
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters">传入的参数</param>
        /// <returns></returns>
        public static SQLiteDataReader ExecuteReader(string cmdText, params object[] p) {
            SQLiteCommand command = new SQLiteCommand();
            SQLiteConnection connection = GetSQLiteConnection();
            try {
                PrepareCommand(command, connection, cmdText, p);
                SQLiteDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            } catch {
                connection.Close();
                throw;
            }
        }

        /// <summary>
        /// 返回结果集中的第一行第一列，忽略其他行或列
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters">传入的参数</param>
        /// <returns></returns>
        public static object ExecuteScalar(string cmdText, params object[] p) {
            SQLiteCommand cmd = new SQLiteCommand();

            using (SQLiteConnection connection = GetSQLiteConnection()) {
                PrepareCommand(cmd, connection, cmdText, p);
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="recordCount"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="cmdText"></param>
        /// <param name="countText"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static DataSet ExecutePager(ref int recordCount, int pageIndex, int pageSize, string cmdText, string countText, params object[] p) {
            if (recordCount < 0)
                recordCount = int.Parse(ExecuteScalar(countText, p).ToString());

            DataSet ds = new DataSet();

            SQLiteCommand command = new SQLiteCommand();
            using (SQLiteConnection connection = GetSQLiteConnection()) {
                PrepareCommand(command, connection, cmdText, p);
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                da.Fill(ds, (pageIndex - 1) * pageSize, pageSize, "result");
            }
            return ds;
        }


    }
}