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
        public static ICollection GetTables() {
            string key = "tables";

            ICollection list = null;

            if (mUseCache && mCache.ContainsKey(key)) {
                list = mCache[key];
            } else {
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "Select   [name]   From   SysObjects   Where   xType='U' order by [name]");
                if(mUseCache)
                    mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 获取供电所线路名称
        /// </summary>
        /// <param name="gdsID"></param>
        /// <returns></returns>
        public static ICollection GetGdsxl(string gdsID)
        {
            string key = "all" + gdsID;

            ICollection list = null;

            if (mUseCache && mCache.ContainsKey(key))
            {
                list = mCache[key];
            }
            else
            {
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select LineName from PS_xl where OrgCode ='" + gdsID + "'or OrgCode2='" + gdsID + "'and LineType='1'");
                if (mUseCache)
                    mCache.Add(key, list);
            }


            return list;
        }
        /// <summary>
        /// 获取缺勤人员列表
        /// </summary>
        /// <returns></returns>
        public static ICollection GetQqyy() {

            ICollection list = new ArrayList();
            string key ="qqyy";
            if (mCache.ContainsKey(key)) {
                list =mCache[key];
            }else{
                list = new string[] { "公出", "事假", "外出", "病假", "休假" };

                mCache.Add(key, list);
            } 
            return list;
        }
        /// <summary>
        /// 获取天气列表
        /// </summary>
        /// <returns></returns>
        public static ICollection GetTQ() {

            ICollection list = new ArrayList();
            string key = "tq";
            if (mCache.ContainsKey(key)) {
                list = mCache[key];
            } else {
                list = new string[] { "晴", "阴", "多云", "雨", "雪" };
                
                mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 被跨越物名称
        /// </summary>
        /// <returns></returns>
        public static ICollection GetKYName()
        {

            ICollection list = new ArrayList();
            string key = "ky";
            if (mCache.ContainsKey(key))
            {
                list = mCache[key];
            }
            else
            {
                list = new string[] { "铁路", "公路", "村路", "通信线", "广播线", "建筑物", "树木", "电力线路", "河流" };

                mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 所属单位
        /// </summary>
        /// <returns></returns>
        public static ICollection GetSSDW()
        {

            ICollection list = new ArrayList();
            string key = "ssdw";
            if (mCache.ContainsKey(key))
            {
                list = mCache[key];
            }
            else
            {
                list = new string[] { "铁路局", "公路处", "乡政府", "镇政府", "广电局", "联通公司", "移动公司" };

                mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 规定距离
        /// </summary>
        /// <returns></returns>
        public static ICollection GetGDJL()
        {

            ICollection list = new ArrayList();
            string key = "gdjl";
            if (mCache.ContainsKey(key))
            {
                list = mCache[key];
            }
            else
            {
                list = new string[] {"7.5", "7", "6","5.5", "5", "4", "3","2.5", "2", "1", "0.8", "0.75", "0.5", "0.6", "0.3" };

                mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 停电性质
        /// </summary>
        /// <returns></returns>
        public static ICollection GetTDXZ()
        {

            ICollection list = new ArrayList();
            string key = "tdxz";
            if (mCache.ContainsKey(key))
            {
                list = mCache[key];
            }
            else
            {
                list = new string[] { "临时停电", "计划停电", "事故停电" };

                mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 设备类型
        /// </summary>
        /// <returns></returns>
        public static ICollection GetSBLX()
        {

            ICollection list = new ArrayList();
            string key = "sblx";
            if (mCache.ContainsKey(key))
            {
                list = mCache[key];
            }
            else
            {
                list = new string[] { "变压器", "断路器", "电缆与架空线接头", "立瓶", "线路", "接户线" };

                mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 土质
        /// </summary>
        /// <returns></returns>
        public static ICollection GetTZ()
        {

            ICollection list = new ArrayList();
            string key = "tz";
            if (mCache.ContainsKey(key))
            {
                list = mCache[key];
            }
            else
            {
                list = new string[] { "黑土", "粘土", "黄土", "沙土"};

                mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 获取缺陷类别列表
        /// </summary>
        /// <returns></returns>
        public static ICollection GetQxlb()
        {

            ICollection list = new ArrayList();
            string key = "qxlb";
            if (mCache.ContainsKey(key))
            {
                list = mCache[key];
            }
            else
            {
                list = new string[] { "一般", "紧急","重大"};

                mCache.Add(key, list);
            }
            return list;
        }
        public static ICollection GetModuFuns() {

            ICollection list = new ArrayList();
            string key = "baseFuns";
            if (mCache.ContainsKey(key)) {
                list = mCache[key];
            } else {
                list = new string[] { "btAdd", "btEdit", "btDelete", "btFind", "btExport", "btRefresh","btView" };

                mCache.Add(key, list);
            }
            return list;
        }
    }
}
