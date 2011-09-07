/**********************************************
系统:企业ERP
模块:地图缓存
作者:Rabbit
创建时间:2011-9-6
最后一次修改:2011-6-6
***********************************************/
using System;
using System.Collections.Generic;
using System.Text;
using Db4objects.Db4o;
using System.Windows.Forms;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Query;
using TONLI.MapView.Tables;

namespace Ebada.Scgl.Gis{
    internal class MapHelper {
        static MapCache MapCache;
        static MapHelper() {
           MapCache = new MapCache();
        }
        public static byte[] GetImage(string mapType, string src) {
            return MapCache.GetImage(mapType, src);
        }
        public static void SetImage(string mapType, string src, byte[] data) {
            MapCache.SetImage(mapType, src, data);
        }
    }
    internal class MapCache  {
        #region IMapServer 成员
        static IObjectContainer db;
        static IObjectContainer db2;
        static IObjectContainer db3;
        static IObjectContainer db4;
        static Dictionary<string, IObjectContainer> dbDic;
        static MapCache() {
            IConfiguration config = Db4oFactory.CloneConfiguration();
            config.ObjectClass(typeof(TONLI.MapView.Tables.MapClass)).ObjectField("_picUrl").Indexed(true);
            db = Db4oFactory.OpenFile(config, Application.StartupPath + "\\MapData.map");
            db2 = Db4oFactory.OpenFile(config, Application.StartupPath + "\\MapData2.map");
            db3 = Db4oFactory.OpenFile(config, Application.StartupPath + "\\MapData3.map");
            db4 = Db4oFactory.OpenFile(config, Application.StartupPath + "\\MapData4.map");
            dbDic = new Dictionary<string, IObjectContainer>();
            dbDic.Add("m1_", db);
            dbDic.Add("m2_", db2);
            dbDic.Add("m3_", db3);
            dbDic.Add("m4_", db4);
        }
        public byte[] GetImage(string mapType, string src) {
            byte[] bt = null;
            if (dbDic.ContainsKey(mapType)) {
                IObjectContainer db0 = dbDic[mapType];
                string key = mapType + src;
                IQuery query = db0.Query();
                query.Constrain(typeof(MapClass));
                query.Descend("_picUrl").Constrain(key);

                IObjectSet result = query.Execute();
                if (result.Count > 0) {
                    bt = (result[0] as MapClass).Stream;

                }
            }
            return bt;
        }
        public void SetImage(string mapType, string src,byte[] data) {            
            if (dbDic.ContainsKey(mapType)) {
                IObjectContainer db0 = dbDic[mapType];
                string key = mapType + src;
                MapClass obj = new MapClass(key, data);
                db0.Set(obj);
                db0.Commit();
            }
        }
        #endregion
    }
}
