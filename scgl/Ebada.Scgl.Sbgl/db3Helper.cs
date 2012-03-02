using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Scgl.Core;
using System.Data;
using System.Collections;
using System.Reflection;

namespace Ebada.Scgl.Sbgl {
    internal class db3Helper {
        static db3Helper() {

        }
        /// <summary>
        /// 清除数据库
        /// </summary>
        internal static void Clear() {
            string del_xl = "delete from ps_xl";
            string del_gt = "delete from ps_gt";
            string del_sbzl = "delete from ps_gtsbzl";
            string del_user = "delete from user";
            SqliteHelper.UpdateData(del_xl);
            SqliteHelper.UpdateData(del_gt);
            SqliteHelper.UpdateData(del_sbzl);
            SqliteHelper.UpdateData(del_user);
        }

        internal static void Create() {

        }

        internal static void Insert(List<ps_xl> list) {
            DSandroid ds1 = new DSandroid();
            DataTable dt = ds1.ps_xl.Clone();
            foreach (ps_xl xl in list) {
                DataRow row = dt.NewRow();
                foreach (DataColumn c in dt.Columns) {
                    row[c] = xl.GetType().GetField(c.ColumnName).GetValue(xl);
                }
                dt.Rows.Add(row);
            }
            SqliteHelper.UpdateTable(dt, "ps_xl");
        }
        internal static void Insert(List<ps_gt> list) {
            DSandroid ds1 = new DSandroid();
            DataTable dt = ds1.ps_gt.Clone();
            foreach (ps_gt item in list) {
                DataRow row = dt.NewRow();
                foreach (DataColumn c in dt.Columns) {
                    row[c] = item.GetType().GetField(c.ColumnName).GetValue(item);
                }
                dt.Rows.Add(row);
            }
            SqliteHelper.UpdateTable(dt, "ps_gt");
        }
        internal static void Insert(List<ps_gtsbzl> list) {
            DSandroid ds1 = new DSandroid();
            DataTable dt = ds1.ps_gtsbzl.Clone();
            foreach (ps_gtsbzl item in list) {
                DataRow row = dt.NewRow();
                foreach (DataColumn c in dt.Columns) {
                    row[c] = item.GetType().GetField(c.ColumnName).GetValue(item);
                }
                dt.Rows.Add(row);
            }
            SqliteHelper.UpdateTable(dt, "ps_gtsbzl");
        }

        internal static void Insert(Ebada.Scgl.Model.mUser mUser) {
            User user = new User();
            FieldInfo[] fields= user.GetType().GetFields();
            foreach (FieldInfo f in fields) {
                try {
                    f.SetValue(user, mUser.GetType().GetProperty(f.Name).GetValue(mUser,null));
                } catch { }
            }
            //user.PassWord = Ebada.Client.Platform.MainHelper.Password;
            string sql = "insert into user(userid,username,loginid,orgcode,orgname,password)values(?,?,?,?,?,?)";
            object[] ps = new object[] { user.UserID, user.UserName, user.LoginID, user.OrgCode, user.OrgName, Client.Platform.MainHelper.Password };
            SqliteHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
