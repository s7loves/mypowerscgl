﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ebada.Client.Platform;
using Ebada.Scgl.Model;
using System.Reflection;
using System.ComponentModel;
using Ebada.Components;
using System.IO;
using System.ServiceModel.Activation;
using System.Web;
using System.Threading;
using System.Runtime.Serialization;

namespace Ebada.Android.Service {
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]  
    public class GpsService : IGpsService {
        #region IScglService 成员

        public User GetUserData(string id, string pwd) {
            string str = MainHelper.EncryptoPassword(pwd);
            User user = new User();
            mUser muser = Client.ClientHelper.PlatformSqlMap.GetOne<mUser>(string.Format("where LoginID='{0}' and password='{1}' ", id, str));
            

            if (muser == null) {
                user.UserName = "用户名或密码错误！";
            } else {
                Type t = user.GetType();
                Type t2 = muser.GetType();
                foreach (FieldInfo info in t.GetFields()) {
                    try {
                        object obj = t2.GetProperty(info.Name).GetValue(muser, null);
                        t.GetField(info.Name).SetValue(user, obj);
                    } catch {
                    }
                }
                //user.UserName = "";
                //user.UserID = muser.UserID;
                //user.LoginID = muser.LoginID;
                user.PassWord = pwd;
                //user.OrgCode = muser.OrgCode;
                //user.OrgName = "";
                //user.UserCode = muser.UserCode;
                //Ebada.Core.ConvertHelper.CopyTo(muser, user);
            }

            return user;
        }
        public User SetUserData(User user) {
            Console.WriteLine("orgname:{0}", user.OrgName);
            return user;
        }
        public List<ps_xl> GetXlList(string gdscode) {
            List<ps_xl> list = new List<ps_xl>();
            IList<PS_xl> list2 = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("where orgcode='" + gdscode + "'");
            foreach (PS_xl xl in list2) {
                list.Add(new ps_xl() {
                    LineCode = xl.LineCode, LineID = xl.LineID, LineName = xl.LineName, LineVol = xl.LineVol,
                    WireLength = xl.WireLength.ToString(), WireType = xl.WireType, ParentID = xl.ParentID, OrgCode = xl.OrgCode, Contractor = xl.Contractor
                });
            }

            return list;
        }
        public List<ps_xl> GetXlList2(string username) {
            List<ps_xl> list = new List<ps_xl>();
            IList<PS_xl> list2 = Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("where Contractor='" + username + "'");
            foreach (PS_xl xl in list2) {
                list.Add(new ps_xl() {
                    LineCode = xl.LineCode, LineID = xl.LineID, LineName = xl.LineName, LineVol = xl.LineVol,
                    WireLength = xl.WireLength.ToString(), WireType = xl.WireType, ParentID = xl.ParentID, OrgCode = xl.OrgCode, Contractor = xl.Contractor
                });
            }

            return list;
        }
        public List<ps_gt> GetGtList(string xlcode) {
            List<ps_gt> list = new List<ps_gt>();
            IList<PS_gt> list2 = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("where LineCode='" + xlcode + "'");
            foreach (PS_gt gt in list2) {
                ps_gt psgt = new ps_gt() {
                    LineCode = gt.LineCode,
                    gtCode = gt.gtCode, gtElev = gt.gtElev.ToString(), gtHeight = gt.gtHeight.ToString(),
                    gth = gt.gth, gtID = gt.gtID, gtLat = gt.gtLat.ToString(), gtLon = gt.gtLon.ToString(), gtSpan = gt.gtJg,
                    gtModle = gt.gtModle, gtType = gt.gtType.ToString()
                };
                list.Add(psgt);
                psgt.jsonData = getjsonData(gt.gtID);
            }

            return list;
        }

        private string getjsonData(string p) {
            IList<PS_gtsb> list = Client.ClientHelper.PlatformSqlMap.GetList<PS_gtsb>("where gtid='" + p + "'");
            string jsondata = null;
            if (list.Count > 0) {
                IList<ps_gtsb> gsonList = new List<ps_gtsb>();
                foreach (PS_gtsb sb in list) {
                    ps_gtsb gtsb = new ps_gtsb() { sl = sb.sbNumber.ToString(), xh = sb.sbModle, zl = sb.sbName, zldm = sb.sbType };
                    gsonList.Add(gtsb);
                }
                try {
                    jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(gsonList);
                    //Console.WriteLine(jsondata);
                } catch (Exception err) { Console.WriteLine(err.Message); }

            }
            return jsondata;
        }



        public string UpdateXl(List<ps_xl> data) {

            return "";
        }
        int ncount = 0;
        public string UpdateGt(List<ps_gt> data) {
            string ret = "0";
            if (data != null) {
                ncount = 0;
                foreach (ps_gt gt in data) {
                    try { UpdateGtOne(gt); } catch (Exception err) { Console.WriteLine(err.Message); }
                }
                ret = data.Count.ToString();
                Console.WriteLine("update {0} count {1}", ret, ncount);
            }
            return ret;
        }
        public string UpdateGtOne(ps_gt data) {
            PS_gt gt = Ebada.Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_gt>(data.gtID);
            if (gt != null) {
                //foreach(FieldInfo fi in data.GetType().GetFields()){
                //    try {
                //        gt.GetType().GetProperty(fi.Name).SetValue(gt, fi.GetValue(data), null);
                //    } catch { }
                //}
                gt.gtType = data.gtType;
                gt.gtModle = data.gtModle;
                gt.gtElev = (int)decimal.Parse(data.gtElev);
                gt.gtLat = decimal.Parse(data.gtLat);
                gt.gtLon = decimal.Parse(data.gtLon);
                gt.gtHeight = decimal.Parse(data.gtHeight);
                gt.gtJg = data.gtSpan == "是" ? "是" : "否";//借杆
                if ((gt.gtLat + gt.gtLon) > 0) {
                    int n = Ebada.Client.ClientHelper.PlatformSqlMap.Update<PS_gt>(gt);
                    ncount += n;
                }
                if (data.jsonData != null) {
                    Console.WriteLine(data.jsonData);
                    List<ps_gtsb> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ps_gtsb>>(data.jsonData);
                    if (list != null) {
                        List<SqlQueryObject> sqllist = new List<SqlQueryObject>();
                        SqlQueryObject sqo = new SqlQueryObject(SqlQueryType.Delete, "Delete", "delete from ps_gtsb where gtid='" + gt.gtID + "'");
                        sqllist.Add(sqo);
                        int num = 0;
                        foreach (ps_gtsb sb in list) {
                            num++;
                            PS_gtsb gtsb = new PS_gtsb() { gtID = gt.gtID, sbModle = sb.xh, sbType = sb.zldm, sbNumber = short.Parse(sb.sl), sbName = sb.zl, sbCode = num.ToString("000") };
                            gtsb.sbID = gt.gtID + num.ToString("000");
                            sqo = new SqlQueryObject(SqlQueryType.Insert, gtsb);
                            sqllist.Add(sqo);
                        }
                        Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(sqllist);
                    }
                    //Console.WriteLine(list != null ? list.Count : 0);
                }
                //Console.WriteLine("update {0} count {1}", gt.gtCode, n);
            }

            return "";
        }
        #endregion

        #region IScglService 成员


        public List<ps_sbzl> GetsbzlList() {
            List<ps_sbzl> list = new List<ps_sbzl>();
            IList<PS_sbcs> list2 = Client.ClientHelper.PlatformSqlMap.GetList<PS_sbcs>("where c1='材料'");
            foreach (PS_sbcs gt in list2) {
                list.Add(new ps_sbzl() {
                    id = gt.ID, xh = gt.xh, bh = gt.bh, mc = gt.mc, parentid = gt.ParentID
                });
            }

            return list; throw new NotImplementedException();
        }
        string select_ver = "select value from msys where dm='androidver_gps'";
        public string GetVersion() {
            Console.WriteLine("{0},开始调用方法:{1}", DateTime.Now.ToString(), this.GetType().Name + "/GetVer");
            string ver = "0";
            try {
                object obj = null;
                try { obj = Client.ClientHelper.PlatformSqlMap.GetObject("Select", select_ver); }
                catch (Exception err) { Console.WriteLine(err.Message); }
                int nver = 0;
                if (obj != null) {
                    nver = int.Parse((obj as System.Collections.Hashtable)["value"].ToString());
                    ver = nver.ToString();
                    Console.WriteLine("{0},调用方法成功:{1}", DateTime.Now.ToString(), this.GetType().Name+"/GetVer");
                }
            }
            catch (Exception err) { Console.WriteLine(err.Message); }
            return ver;
        }
        string ak = "BC6aa1ebfad0839ce2cccfeeea579d3a";
        string url = "http://api.map.baidu.com/geocoder/v2/?ak={0}&location={1}&output=json";
        double lngdeviation = 1.0000568461567492425578691530827;//经度偏差

        double latdeviation = 1.0002012762190961772159526495686;//纬度偏差
        public string UpPosition(g_position pos)
        {
            if (pos.id > 0)
            {
                gps_position_now gp = new gps_position_now()
                {
                    date = DateTime.Now,
                    lat = pos.lat,
                    lng = pos.lng,
                    speed = pos.s,
                    altitude = pos.h
                    ,
                    gps_realtime_position = Convert.ToDateTime(pos.dt),
                    device_id = pos.id,
                    position_type = pos.locType,
                    c1 = pos.addr
                    ,
                    distance_from_last_gps = pos.dis
                };
                try
                {
                    Thread thread = new Thread(getdress);
                    thread.IsBackground = true;
                    thread.Start(gp);
                }
                catch (Exception err) { Console.WriteLine(err.Message); }



            }
            Console.WriteLine("{0},调用方法:{1}", DateTime.Now.ToString(), this.GetType().Name + "/UpPosition/" + pos.toString());
            return "ok";
        }
        private void getdress(object obj){
            gps_position_now pos = obj as gps_position_now;
            if (string.IsNullOrEmpty(pos.c1))
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                string loc = string.Format("{0},{1}", pos.lat, pos.lng);
                string surl = string.Format(url, ak, HttpUtility.UrlEncode(loc));
                try
                {
                    wc.Headers.Add("content-type", "application/json;charset=utf-8");
                    string adrress = wc.DownloadString(surl);
                    dressResult ret= Newtonsoft.Json.JsonConvert.DeserializeObject<dressResult>(adrress);
                    if (ret != null && ret.status == "0")
                    {
                        pos.c1 = ret.result.formatted_address;
                    }
                    Console.WriteLine(adrress);
                }
                catch (Exception err) { Console.WriteLine(err.Message); }
            }
            try
                {
            Client.ClientHelper.PlatformSqlMap.Update<gps_position_now>(pos);
                }
            catch (Exception err) { Console.WriteLine(err.Message); }
        }
        [DataContract]
        public class dressResult
        {
            [DataMember]
            public string status;
            [DataMember]
            public dress result;
        }
        public class dress
        {
            [DataMember]
            public string formatted_address;
        }
        public g_position_now GetPosition(int id) {
            g_position_now gp = null;
            gps_position_now gps_now = Client.ClientHelper.PlatformSqlMap.GetOne<gps_position_now>("where device_id=" + id);
            if (gps_now != null) {
                gp = new g_position_now() {
                     addr=gps_now.c1,  dt=gps_now.date.ToString("yyyy-HH-dd HH:mm:ss"), lat=gps_now.lat,lng=gps_now.lng, s=gps_now.speed
                };
            }
            return gp;
        }
        public g_device GetDevice(g_device dev) {
            g_device device = null;
            string IMEI = dev.IMEI;
            if (IMEI == "0") {
                device = new g_device() {
                    id = 0, IMEI = "0", state = "0"
                };
            } else if(IMEI.Length>10) {
                gps_device gpsdevice = Client.ClientHelper.PlatformSqlMap.GetOne<gps_device>("where device_serial='" + IMEI + "'");
                if (gpsdevice == null) {
                    gpsdevice = new gps_device() {
                        device_serial = IMEI,phone_number=dev.jsonData, device_state = "1", device_type = "phone", device_expire = DateTime.Now, device_desc = "程序自动注册"
                    };
                    Client.ClientHelper.PlatformSqlMap.Create<gps_device>(gpsdevice);
                }
                if (gpsdevice.device_id > 0) {
                    device = new g_device();
                    device.id = gpsdevice.device_id;
                    device.state = gpsdevice.device_state;
                    device.IMEI = IMEI;
                }
            }

            Console.WriteLine("{0},调用方法:{1}", DateTime.Now.ToString(), this.GetType().Name + "/GetDevice/"+dev.ToString());
            return device;
        }
        #endregion

        #region IScglService 成员

        static Dictionary<string, MemoryStream> imageCache = new Dictionary<string, MemoryStream>();
        public string UpdateGtImage(List<ps_image> list) {
            ps_image data = list[0];
            string msg = "";
            PS_Image image = new PS_Image() { ImageID = data.id, ImageType = "gt" };
            image.ImageData = Convert.FromBase64String(data.data);
            PS_Image image2 = new PS_Image() { ImageID = data.id };
            Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(image, null, image2);
            return msg;
        }
        public string upload_image(ps_image data) {

            return UpdateGtImage3(data.id, data.data, data.type);
        }
        //public string UpdateGtImage2(string id, string data, string type,int flag) {
        //    switch (flag) {
        //        case 1:
        //            if (!imageCache.ContainsKey(id)) {
        //                imageCache.Add(id, new MemoryStream());
        //            } else {
        //                imageCache[id] = new MemoryStream();
        //            }
        //            imageCache[id].WriteBase64String(data);
        //            break;
        //        case 2:
        //            imageCache[id].WriteBase64String(data);
        //            break;
        //        case 0:
        //            return UpdateGtImage3(id, data, type);
        //        case 100:
        //            imageCache[id].WriteBase64String(data);
        //            byte[] buff = imageCache[id].ToArray();
        //            imageCache.Remove(id);
        //            return UpdateGtImage3(id, buff, type);
        //        default:
        //            break;
        //    }
        //    string msg = "1";
            
        //    return msg;
        //}
        public string UpdateGtImage3(string id, byte[] data, string type) {

            string msg = "";
            PS_Image image = new PS_Image() { ImageID = id, ImageType = "gt" };
            image.ImageData = data;
            PS_Image image2 = new PS_Image() { ImageID = id };
            PS_gt gt = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_gt>(id);
            object update = null;
            object delete = image2;
            if (gt != null && gt.ImageID != id) {
                if (gt.ImageID != "") {
                    delete = new PS_Image() { ImageID = gt.ImageID };
                    delete = new object[] { image2, delete };
                }
                gt.ImageID = id;
                update = gt;
            }

            Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(image, update, delete);
            return msg;
        }
        public string UpdateGtImage3(string id, string data, string type) {

            string msg = "";
            PS_Image image = new PS_Image() { ImageID = id, ImageType = "gt" };
            image.ImageData = Convert.FromBase64String(data);
            PS_Image image2 = new PS_Image() { ImageID = id };
            PS_gt gt = Client.ClientHelper.PlatformSqlMap.GetOneByKey<PS_gt>(id);
            object update = null;
            object delete = image2;
            if (gt != null && gt.ImageID != id) {
                if (gt.ImageID != "") {
                    delete = new PS_Image() { ImageID = gt.ImageID };
                    delete = new object[] { image2, delete };
                }
                gt.ImageID = id;
                update = gt;
            }

            Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(image, update, delete);
            return msg;
        }
        public string UploadFile(string id,string type, Stream fileContents) {
            byte[] buffer = new byte[10000];
            int bytesRead, totalBytesRead = 0;
            MemoryStream ms = new MemoryStream();
            do {
                bytesRead = fileContents.Read(buffer, 0, buffer.Length);
                ms.Write(buffer, 0, bytesRead);
                totalBytesRead += bytesRead;
            } while (bytesRead > 0);
            UpdateGtImage3(id, ms.ToArray(), type);
            ms.Close();
            ms.Dispose();
            
            //Console.WriteLine("Service: Received file {0} with {1} bytes", id, totalBytesRead);
            return id;
        }

        #endregion
    }
    //public static class Extensions {

    //    public static void WriteBase64String(this MemoryStream m, string data) {
    //        byte[] bytes = Convert.FromBase64String(data);
    //        m.Write(bytes, 0, bytes.Length);
    //    }
    //}
}
