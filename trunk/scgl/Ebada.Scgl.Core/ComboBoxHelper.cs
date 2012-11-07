﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;

namespace Ebada.Scgl.Core {
    public class ComboBoxHelper {
        static Dictionary<string, ICollection> mCache = new Dictionary<string, ICollection>();
        /// <summary>
        /// 与系统默认时间进行比较，给定时间大于系统默认时间返回true否则返回false
        /// 
        /// </summary>
        /// <param name="dtime">给定时间</param>
        /// <returns></returns>
       public  static bool CompreDate(DateTime dtime)
        {
            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from pj_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}'", "公用属性", "默认时间"));

            if (list.Count < 1) return true;
           string str = list[0].ToString();
            DateTime dt = Convert.ToDateTime(str);
            if (dtime<=dt)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
       public static void ClearCache() {
           mCache.Clear();
       }
       /// <summary>
       /// 获取缺陷表记录ID方法
       /// </summary>
       /// <param name="str">
       /// 缺陷记录表类型:
       /// "01"[变压器预防性试验实施情况记录]
       /// "02"[断路器预防性试验实施情况记录]
       /// "03"[避雷器预防性试验实施情况记录]
       /// "04"[电容器预防性试验实施情况记录]
       /// "05"[接地装置检测记录]
       /// "06"[交叉跨越及对地距离测量记录]
       /// "07"[设备巡视及缺陷消除记录]
       /// </param>
       /// <param name="orgcode">供电所代码</param>
       /// <returns></returns>
       public static string GetQXID(string str,string orgcode)
       {
           return str +str+ DateTime.Now.Year + orgcode;
       }
        static bool mUseCache = false;
        public bool UseCache {
            get { return mUseCache; }
            set {                
                mUseCache = value;            
            }
        }
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
                if (mUseCache)
                    mCache.Add(key, list);
            }


            return list;
        }
        /// <summary>
        /// 获取供电所人员列表
        /// </summary>
        /// <param name="field"> 字段</param>
        /// <param name="zhi"> 值</param>
        /// <returns></returns>
        public static ICollection getRy(string field,string zhi)
        {
            string key = "all" + zhi;

            ICollection list = null;

            if (mUseCache && mCache.ContainsKey(key))
            {
                list = mCache[key];
            }
            else
            {
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select UserName from mUser where "+field+"='" + zhi + "'");
                if (mUseCache)
                    mCache.Add(key, list);
            }


            return list;
        }
        /// <summary>
        /// 获取供电所负责人 供电所所长或者是机关科室科长
        /// </summary>
        /// <param name="gdsID"></param>
        /// <returns></returns>
        public static ICollection GetGdsRyfzr(string gdsID)
        {
            string key = "fzr" + gdsID;

            ICollection list = null;

            if (mUseCache && mCache.ContainsKey(key))
            {
                list = mCache[key];
            }
            else
            {
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select UserName from mUser where orgcode='" + gdsID + "'and PostName in('所长','主值班长','科长')");
                if (mUseCache)
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
                if (mUseCache)
                    mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 获取供电所线路名称
        /// </summary>
        /// <param name="gdsID"></param>
        /// <returns></returns>
        public static ICollection GetGdsxl(string gdsID) {
            string key = "all" + gdsID;

            ICollection list = null;

            if (mUseCache && mCache.ContainsKey(key)) {
                list = mCache[key];
            } else {
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select LineName from PS_xl where OrgCode ='" + gdsID + "' and LineType='1' and linevol='10'");
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
            string key = "qqyy";
            if (mCache.ContainsKey(key)) {
                list = mCache[key];
            } else {
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
        public static ICollection GetKYName() {

            ICollection list = new ArrayList();
            string key = "ky";
            if (mCache.ContainsKey(key)) {
                list = mCache[key];
            } else {
                list = new string[] { "铁路", "公路", "村路", "通信线", "广播线", "建筑物", "树木", "电力线路", "河流" };

                mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 所属单位
        /// </summary>
        /// <returns></returns>
        public static ICollection GetSSDW() {

            ICollection list = new ArrayList();
            string key = "ssdw";
            if (mCache.ContainsKey(key)) {
                list = mCache[key];
            } else {
                list = new string[] { "铁路局", "公路处", "乡政府", "镇政府", "广电局", "联通公司", "移动公司" };

                mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 规定距离
        /// </summary>
        /// <returns></returns>
        public static ICollection GetGDJL() {

            ICollection list = new ArrayList();
            string key = "gdjl";
            if (mCache.ContainsKey(key)) {
                list = mCache[key];
            } else {
                list = new string[] { "7.5", "7", "6", "5.5", "5", "4", "3", "2.5", "2", "1", "0.8", "0.75", "0.5", "0.6", "0.3" };

                mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 停电性质
        /// </summary>
        /// <returns></returns>
        public static ICollection GetTDXZ() {

            ICollection list = new ArrayList();
            string key = "tdxz";
            if (mCache.ContainsKey(key)) {
                list = mCache[key];
            } else {
                list = new string[] { "临时停电", "计划停电", "事故停电" };

                mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 设备类型
        /// </summary>
        /// <returns></returns>
        public static ICollection GetSBLX() {

            ICollection list = new ArrayList();
            string key = "sblx";
            if (mCache.ContainsKey(key)) {
                list = mCache[key];
            } else {
                list = new string[] { "导线","金具","绝缘子","变压器","熔断器", "断路器", "电缆与架空线接头", "立瓶", "线路", "接户线" };

                mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 土质
        /// </summary>
        /// <returns></returns>
        public static ICollection GetTZ() {

            ICollection list = new ArrayList();
            string key = "tz";
            if (mCache.ContainsKey(key)) {
                list = mCache[key];
            } else {
                list = new string[] { "黑土", "粘土", "黄土", "沙土" };

                mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 获取缺陷类别列表
        /// </summary>
        /// <returns></returns>
        public static ICollection GetQxlb() {

            ICollection list = new ArrayList();
            string key = "qxlb";
            if (mCache.ContainsKey(key)) {
                list = mCache[key];
            } else {
                list = new string[] { "一般", "紧急", "重大" };

                mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 获取台区
        /// </summary>
        /// <returns></returns>
        public static ICollection Getbtq()
        {

            string key = "alltq";

            ICollection list = null;

            if (mUseCache && mCache.ContainsKey(key))
            {
                list = mCache[key];
            }
            else
            {
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select distinct Adress  from PS_tq where Adress is not null");
                if (mUseCache)
                    mCache.Add(key, list);
            }


            return list;
        }
        /// <summary>
        /// 获取台区
        /// </summary>
        /// <returns></returns>
        public static ICollection Getbtq(string gdscode) {

            string key = "tq"+gdscode;

            ICollection list = null;

            if (mUseCache && mCache.ContainsKey(key)) {
                list = mCache[key];
            } else {
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select tqname  from PS_tq where left(tqcode,3)='"+gdscode+"'");
                if (mUseCache)
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
                list = new string[] { "btAdd", "btEdit", "btDelete", "btFind", "btExport", "btRefresh", "btView" };

                mCache.Add(key, list);
            }
            return list;
        }

        /// <summary>
        /// 获取短语库属性列表，可以用来填充下拉列表框
        /// </summary>
        /// <param name="dx">对象中文名</param>
        /// <param name="sx">属性中文名</param>
        /// <returns></returns>
        public static ICollection GetDykList(string dx, string sx) {
            ICollection list = new ArrayList();
            string key = dx + sx;
            if (mCache.ContainsKey(key)) {
                list = mCache[key];
            } else {
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select nr from pj_dyk where  len(parentid)>1 and dx='{0}' and sx='{1}'", dx, sx));
                if (list.Count > 0)
                    mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 获取短语库属性列表填充下拉列表框
        /// </summary>
        /// <param name="dx">对象中文名</param>
        /// <param name="sx">属性中文名</param>
        /// <param name="cBox">列表对象</param>
        public static void FillCBoxByDyk(string dx, string sx, RepositoryItemComboBox cBox) {
            cBox.Items.Clear();
            cBox.Items.AddRange(GetDykList(dx, sx));
        }
        /// <summary>
        /// 获取短语库属性列表填充下拉列表框
        /// </summary>
        /// <param name="dx">对象中文名</param>
        /// <param name="sx">属性中文名</param>
        /// <param name="cBox">列表对象</param>
        public static void FillCBoxByDyk(string dx, string sx, ComboBoxEdit cBox) {
            FillCBoxByDyk(dx, sx, cBox.Properties);
        }
        #region 设备相关
        public static void FillCBoxByGttype(ComboBoxEdit c) {
            c.Properties.Items.Clear();
            c.Properties.Items.AddRange(GetGtType());
        }
        /// <summary>
        /// 获取杆塔分类
        /// </summary>
        /// <returns></returns>
        public static ICollection GetGtType() {

            ICollection list = new ArrayList();
            string key = "GtType";
            if (mCache.ContainsKey(key)) {
                list = mCache[key];
            } else {
                list = new string[] {"起始杆", "直线杆", "加强杆", "耐张杆", "转角杆", "终端杆", "分支杆"};
                mCache.Add(key, list);
            }
            return list;
        }
        public static ICollection GetsbxhList(string bh) {
            ICollection list = new ArrayList();
            string key = "sbxh"+bh;
            bh = bh.Substring(0, 2) + "001";
            if (mCache.ContainsKey(key)) {
                list = mCache[key];
            } else {
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", string.Format("select xh from ps_sbcs where  parentid ='{0}'", bh));
                if (list.Count > 0)
                    mCache.Add(key, list);
            }
            return list;
        }

        /// <summary>
        /// 获取电压等级
        /// </summary>
        /// <returns></returns>
        public static ICollection GetVoltage()
        {

            

            ICollection list = new ArrayList();
            string key = "GetVoltage";
            if (mCache.ContainsKey(key))
            {
                list = mCache[key];
            }
            else
            {
                list = new string[] { "65kV", "10kV", "0.4kV" };
                mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 获取电压等级
        /// </summary>
        /// <returns></returns>
        public static ICollection GetVoltageNokV()
        {



            ICollection list = new ArrayList();
            string key = "GetVoltage";
            if (mCache.ContainsKey(key))
            {
                list = mCache[key];
            }
            else
            {
                list = new string[] { "65", "10", "0.4" };
                mCache.Add(key, list);
            }
            return list;
        }
        /// <summary>
        /// 获取导线型号
        /// </summary>
        /// <returns></returns>
        public static ICollection GetLineTye()
        {
            ICollection list = new ArrayList();
            string key = "GetLineType";
            if (mCache.ContainsKey(key))
            {
                list = mCache[key];
            }
            else
            {
                list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", "select xh from ps_sbcs where  mc='导线' and xh !='' ");
                mCache.Add(key, list);
            }
            return list;
            
        }
        #endregion



        public static void Fillgdsry(ComboBoxEdit box, string p) {
            box.Properties.Items.Clear();
            box.Properties.Items.AddRange(GetGdsRy(p));
        }
    }
}
