using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Scgl.Model;
using DevExpress.Utils;

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
                double d1 = 0;
                if (gt.gtLat == 0 || gt.gtLon == 0) d1=-1;
                if (gt0.gtLat == 0 || gt0.gtLon == 0) {
                    gt0 = gt; d1=-1;
                }
                if (d1 == 0) {
                    d1 = GetDistance(new PointLatLng(gt.gtLat, gt.gtLon), new PointLatLng(gt0.gtLat, gt0.gtLon));
                    gt.gtSpan = (decimal)Math.Round(d1, 1);
                } else {
                    gt.gtSpan = 0;
                }
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
        /// <summary>
        /// 备份一条线路的杆塔经纬度
        /// </summary>
        /// <param name="lineCode"></param>
        internal static void BackupGTLatLng(string lineCode) {
            IList<PS_gt> gtList = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("where linecode='" + lineCode + "'");
            List<object> updateList = new List<object>();
            
            foreach (PS_gt gt in gtList) {
                if(gt.gtLat==0 ||gt.gtLon==0)continue;
                double[] dd = LBtoXY54((double)gt.gtLon, (double)gt.gtLat);
                if ((int)dd[1] == gt.Y54 && gt.X54 == (int)dd[0]) continue;
                gt.Y54 = (int)dd[1];
                gt.X54 = (int)dd[0];
                updateList.Add(gt);
            }
            if(updateList.Count>0)
            Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(null, updateList, null);

        }
         /// <summary>
        /// 备份一个台区的杆塔经纬度
        /// </summary>
        /// <param name="lineCode"></param>
        internal static void BackupGTLatLngTQ(string tqCode) {
            WaitDialogForm waitdlg = new WaitDialogForm("", "备份台区经纬度");
            string sql = string.Format("where left(linecode,{0})='{1}' and linevol='0.4'", tqCode.Length, tqCode);
            IList<PS_xl> listxl = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>(sql);
            foreach (PS_xl item in listxl) {
                waitdlg.SetCaption(item.LineName);
                
                BackupGTLatLng(item.LineCode);
                
            }

            waitdlg.Close();
        }
        /// <summary>
        /// 备份一个台区的杆塔经纬度
        /// </summary>
        /// <param name="lineCode"></param>
        internal static void RestoreGTLatLngTQ(string tqCode) {
            WaitDialogForm waitdlg = new WaitDialogForm("", "恢复台区经纬度");
            IList<PS_xl> listxl = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>(string.Format("where left(linecode,{0})='{1}' and linevol='0.4'", tqCode.Length, tqCode));
            foreach (PS_xl item in listxl) {
                waitdlg.SetCaption(item.LineName);

                RestoreGTLatLng(item.LineCode);

            }

            waitdlg.Close();
        }
        /// <summary>
        /// 恢复一条线路的杆塔经纬度
        /// </summary>
        /// <param name="p"></param>
        internal static void RestoreGTLatLng(string lineCode) {
            IList<PS_gt> gtList = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("where linecode='" + lineCode + "'");
            List<object> updateList = new List<object>();

            foreach (PS_gt gt in gtList) {
                if (gt.Y54 == 0 || gt.X54 == 0) continue;
                double[] dd = LBtoXY54((double)gt.gtLon, (double)gt.gtLat);
                if ((int)dd[1] == gt.Y54 && gt.X54 == (int)dd[0]) continue;
                dd = XY54toLB((double)gt.X54, (double)gt.Y54);
                //if ((int)dd[1] == gt.gtLat && gt.gtLon == (int)dd[0]) continue;
                gt.gtLat = (decimal)dd[1];
                gt.gtLon = (decimal)dd[0];
                updateList.Add(gt);
            }
            if (updateList.Count > 0)
                Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(null, updateList, null);
        }
        public static int ZoneWide = 3; //带宽
         
        
        /// <summary>
        /// 54坐标转经纬度
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static double[] XY54toLB(double X, double Y) {
            int ProjNo;
            double X0 = 0, Y0 = 0;
            ////带宽 
            double longitude1, latitude1, longitude0, latitude0, xval, yval;
            double e1, e2, f, a, ee, NN, T, C, M, D, R, u, fai, iPI;
            iPI = 0.0174532925199433; ////3.1415926535898/180.0; 
            a = 6378245.0; f = 1.0 / 298.3; //54年北京坐标系参数

            ProjNo = (int)(X / 1000000L); //查找带号
            if (ZoneWide == 6)
                longitude0 = (ProjNo - 1) * ZoneWide + ZoneWide / 2.0;
            else
                longitude0 = (ProjNo) * ZoneWide;
            //longitude0 = 108; //河池地区
            longitude0 = longitude0 * iPI; //中央经线 
            X0 = ProjNo * 1000000L + 500000L;
            Y0 = 0;
            xval = X - X0;
            yval = Y - Y0; //带内大地坐标 
            e2 = 2 * f - f * f;
            e1 = (1.0 - Math.Sqrt(1 - e2)) / (1.0 + Math.Sqrt(1.0 - e2));
            ee = e2 / (1.0 - e2);
            M = yval; u = M / (a * (1.0 - e2 / 4.0 - 3 * e2 * e2 / 64.0 - 5 * e2 * e2 * e2 / 256.0));
            fai = u + (3 * e1 / 2.0 - 27 * e1 * e1 * e1 / 32.0) * Math.Sin(2 * u) + (21 * e1 * e1 / 16.0 - 55 * e1 * e1 * e1 * e1 / 32.0) * Math.Sin(4 * u) + (151 * e1 * e1 * e1 / 96.0) * Math.Sin(6 * u) + (1097 * e1 * e1 * e1 * e1 / 512.0) * Math.Sin(8 * u);
            C = ee * Math.Cos(fai) * Math.Cos(fai);
            T = Math.Tan(fai) * Math.Tan(fai);
            NN = a / Math.Sqrt(1.0 - e2 * Math.Sin(fai) * Math.Sin(fai));
            R = a * (1.0 - e2) / Math.Sqrt((1.0 - e2 * Math.Sin(fai) * Math.Sin(fai)) * (1.0 - e2 * Math.Sin(fai) * Math.Sin(fai)) * (1.0 - e2 * Math.Sin(fai) * Math.Sin(fai)));
            D = xval / NN;
            //计算经度(Longitude) 纬度(Latitude) 
            longitude1 = longitude0 + (D - (1 + 2 * T + C) * D * D * D / 6.0 + (5.0 - 2 * C + 28 * T - 3 * C * C + 8 * ee + 24 * T * T) * D * D * D * D * D / 120.0) / Math.Cos(fai);
            latitude1 = fai - (NN * Math.Tan(fai) / R) * (D * D / 2.0 - (5 + 3 * T + 10 * C - 4 * C * C - 9 * ee) * D * D * D * D / 24.0 + (61 + 90 * T + 298 * C + 45 * T * T - 256 * ee - 3 * C * C) * D * D * D * D * D * D / 720.0); //转换为度        DD 
            double longitude;
            double latitude;
            longitude = longitude1 / iPI;
            latitude = latitude1 / iPI;
            return new double[] { longitude, latitude };
        }
        /// <summary>
        /// 经纬度转５４坐标
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public static double[] LBtoXY54(double longitude, double latitude) {
            int ProjNo = 0;
            double X0 = 0, Y0 = 0;
            double longitude1, latitude1, longitude0, latitude0, xval, yval; ////0.0174532925199433; 
            double a, f, e2, ee, NN, T, C, A, M, iPI; iPI = 3.1415926535898 / 180.0;
            a = 6378245.0; f = 1.0 / 298.3; //54年北京坐标系参数 
            ProjNo = (int)(longitude / ZoneWide);
            if (ZoneWide == 6)
                longitude0 = ProjNo * ZoneWide + ZoneWide / 2.0;
            else
                longitude0 = ProjNo * ZoneWide;
            //longitude0 = 108; //河池地区
            longitude0 = longitude0 * iPI;
            latitude0 = 0;
            longitude1 = longitude * iPI; //经度转换为弧度 
            latitude1 = latitude * iPI; //纬度转换为弧度 
            e2 = 2.0 * f - f * f; ee = e2 * (1.0 - e2);
            NN = a / Math.Sqrt(1.0 - e2 * Math.Sin(latitude1) * Math.Sin(latitude1));
            T = Math.Tan(latitude1) * Math.Tan(latitude1);
            C = ee * Math.Cos(latitude1) * Math.Cos(latitude1);
            A = (longitude1 - longitude0) * Math.Cos(latitude1);
            M = a * ((1.0 - e2 / 4.0 - 3.0 * e2 * e2 / 64.0 - 5 * e2 * e2 * e2 / 256.0) * latitude1 - (3 * e2 / 8.0 + 3 * e2 * e2 / 32.0 + 45 * e2 * e2 * e2 / 1024.0) * Math.Sin(2 * latitude1) + (15 * e2 * e2 / 256.0 + 45 * e2 * e2 * e2 / 1024.0) * Math.Sin(4.0 * latitude1) - (35 * e2 * e2 * e2 / 3072.0) * Math.Sin(6 * latitude1));
            xval = NN * (A + (1.0 - T + C) * A * A * A / 6.0 + (5.0 - 18 * T + T * T + 72 * C - 58 * ee) * A * A * A * A * A / 120.0);
            yval = M + NN * Math.Tan(latitude1) * (A * A / 2.0 + (5.0 - T + 9 * C + 4 * C * C) * A * A * A * A / 24.0 + (61.0 - 58 * T + T * T + 600 * C - 330 * ee) * A * A * A * A * A * A / 720.0);
            if (ZoneWide == 6)
                X0 = 1000000L * (ProjNo + 1) + 500000L;
            else
                X0 = 1000000L * ProjNo + 500000L;
            Y0 = 0;
            //X0 = 0;
            xval = xval + X0;
            yval = yval + Y0;
            return new double[] { xval, yval };
        }
    }
}
