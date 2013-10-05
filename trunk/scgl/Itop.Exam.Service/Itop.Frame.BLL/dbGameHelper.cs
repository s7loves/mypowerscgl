using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Scgl.Core;
using System.Data;
using System.Collections;
using System.Reflection;

namespace Itop.Frame.BLL {
    public class dbGameHelper {
        static dbGameHelper() {
            SqliteHelper.ConnStr ="Data Source="+ AppDomain.CurrentDomain.BaseDirectory + "\\app_data\\scores.db";
        }
        /// <summary>
        /// 清除数据库
        /// </summary>
        public static void Clear() {
            string del_xl = "delete from scores_dafeiji";
            SqliteHelper.UpdateData(del_xl);
        }

        public static void Create() {
            string del_xl = "CREATE TABLE IF NOT EXISTS scores_dafeiji(id integer PRIMARY KEY autoincrement,username text,score integer )";
            SqliteHelper.UpdateData(del_xl);
        }

        public static void Insert(List<GameScore> list) {
            DataSet1 ds1 = new DataSet1();
            DataTable dt = ds1.Table_scores.Clone();
            foreach (GameScore xl in list) {
                DataRow row = dt.NewRow();
                foreach (DataColumn c in dt.Columns) {
                    row[c] = xl.GetType().GetField(c.ColumnName).GetValue(xl);
                }
                dt.Rows.Add(row);
            }
            SqliteHelper.UpdateTable(dt, "scores_dafeiji");
        }
        public static List<GameScore> getScores() {
             DataTable dt= SqliteHelper.ExecuteDataTable("select username,score from scores_dafeiji order by score desc");
             List<GameScore> list = new List<GameScore>();
             foreach (DataRow row in dt.Rows) {
                 list.Add(new GameScore() { score = Convert.ToInt32(row[1]), username = row[0].ToString() });
             }
             return list;
        }
        public static void Update(GameScore item) {
            string sql = "delete from scores_dafeiji where username='"+item.username+"'";
            SqliteHelper.ExecuteNonQuery(sql);
            Insert(item);
        }
        public static void Insert(GameScore item) {
            
            //user.PassWord = Ebada.Client.Platform.MainHelper.Password;
            string sql = "insert into scores_dafeiji(username,score)values(?,?)";
            object[] ps = new object[] { item.username,item.score};
            SqliteHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
