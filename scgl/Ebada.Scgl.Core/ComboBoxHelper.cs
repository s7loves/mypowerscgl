using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Ebada.Scgl.Core {
    public class ComboBoxHelper {
        static Dictionary<string, ICollection> mCache=new Dictionary<string,ICollection>();
        static bool mUseCache = false;
        /// <summary>
        /// 获取供电所人员列表
        /// </summary>
        /// <param name="gdsID"></param>
        /// <returns></returns>
        public static ICollection GetGdsRy(string gdsID) {
            string key = "all" + gdsID;

            ICollection list = null;

            if (mUseCache && mCache.ContainsKey(key)) {
                list = mCache[key];
            } else {
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select UserName from mUser where orgcode='" + gdsID + "'");
                if(mUseCache)
                    mCache.Add(key, list);
            }


            return list;
        }
        /// <summary>
        /// 获取缺勤人员列表
        /// </summary>
        /// <returns></returns>
        public static ICollection GetQqyy() {

            IList list = new ArrayList();
            string key ="qqyy";
            if (mCache.ContainsKey(key)) {
                list =mCache[key] as IList;
            }else{
                string[] yys = new string[] { "公出", "事假", "外出", "病假", "休假" };
                foreach (string str in yys) {
                    list.Add(str);
                }
                mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 获取天气列表
        /// </summary>
        /// <returns></returns>
        public static ICollection GetTQ() {

            IList list = new ArrayList();
            string key = "tq";
            if (mCache.ContainsKey(key)) {
                list = mCache[key] as IList;
            } else {
                string[] yys = new string[] { "晴", "阴", "多云", "雨", "雪" };
                foreach (string str in yys) {
                    list.Add(str);
                }
                mCache.Add(key, list);
            }
            return list;
        }
    }
}
