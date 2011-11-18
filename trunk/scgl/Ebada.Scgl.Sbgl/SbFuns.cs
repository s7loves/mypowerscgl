using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Scgl.Model;

namespace Ebada.Scgl.Sbgl {
    public static class SbFuns {
        public struct PointLatLng {
            public PointLatLng(decimal lat, decimal lng) {
                Lat = (double)lat;
                Lng = (double)lng;
        }
            public double Lat;
            public double Lng;
        }
        /// <summary>
        /// 计算线路长度 单位米
        /// 1、计算线路杆塔的档距
        /// 2、统计线路长度，包括分支线路。
        /// </summary>
        /// <param name="xl"></param>
        public static double CountLineLen(PS_xl xl) {
            double dLen0 = 0;//总长度，包括下级线路
            double dLen1 = 0;//当前线路长度
            IList<PS_gt> gtList = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("where linecode='" + xl.LineCode + "'");
            PS_gt gt0 = new PS_gt();
            List<object> updateList = new List<object>();
            for(int i=0;i<gtList.Count;i++) {
                PS_gt gt = gtList[i];
                if (gt.gtLat == 0 || gt.gtLon == 0) continue;
                if (gt0.gtLat == 0 || gt0.gtLon == 0) {
                    gt0 = gt; continue;
                }
                double d1= GetDistance(new PointLatLng(gt.gtLat, gt.gtLon), new PointLatLng(gt0.gtLat, gt0.gtLon));
                gt.gtSpan = (decimal)Math.Round(d1,1);
                //gt.
                updateList.Add(gt);
                dLen1 += d1;
                gt0 = gt;
            }
            xl.WireLength =(int)(dLen1);//

            Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(null, updateList, null);
            updateList.Clear();
            IList<PS_xl> xlList = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("where parentid='" + xl.LineID + "'");
            foreach(PS_xl xl0 in xlList){
                double d0= CountLineLen(xl0);
                dLen0 += d0;
                if (xl0.TotalLength == (int)d0) continue;
                xl0.TotalLength = (int)d0;
                updateList.Add(xl0);
            }
            Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(null, updateList, null);
            dLen0 += dLen1;
            return dLen0;
        }
        /// <summary>
        /// 计算两经纬度间距离，单位(米)
        /// The Haversine formula, http://www.movable-type.co.uk/scripts/latlong.html
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double GetDistance(PointLatLng p1, PointLatLng p2) {
            double dLat1InRad = p1.Lat * (Math.PI / 180);
            double dLong1InRad = p1.Lng * (Math.PI / 180);
            double dLat2InRad = p2.Lat * (Math.PI / 180);
            double dLong2InRad = p2.Lng * (Math.PI / 180);
            double dLongitude = dLong2InRad - dLong1InRad;
            double dLatitude = dLat2InRad - dLat1InRad;
            double a = Math.Pow(Math.Sin(dLatitude / 2), 2) + Math.Cos(dLat1InRad) * Math.Cos(dLat2InRad) * Math.Pow(Math.Sin(dLongitude / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double dDistance = 6378137 * c;
            return dDistance;
        }
    }
}
