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
using System.Collections;

namespace Ebada.Android.Service {
    /// <summary>
    /// 送电数据采集服务
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ScglBDService : IScglBDService {
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
            IList<sd_xl> list2 = Client.ClientHelper.PlatformSqlMap.GetList<sd_xl>("where orgcode='" + gdscode + "'");
            foreach (sd_xl xl in list2) {
                list.Add(new ps_xl() {
                    LineCode = xl.LineCode, LineID = xl.LineID, LineName = xl.LineName, LineVol = xl.LineVol,
                    WireLength = xl.WireLength.ToString(), WireType = xl.WireType, ParentID = xl.ParentID, OrgCode = xl.OrgCode, Contractor = xl.Contractor
                });
            }

            return list;
        }
        public List<ps_xl> GetXlList2(string username) {
            List<ps_xl> list = new List<ps_xl>();
            IList<sd_xl> list2 = Client.ClientHelper.PlatformSqlMap.GetList<sd_xl>("where Contractor='" + username + "'");
            foreach (sd_xl xl in list2) {
                list.Add(new ps_xl() {
                    LineCode = xl.LineCode, LineID = xl.LineID, LineName = xl.LineName, LineVol = xl.LineVol,
                    WireLength = xl.WireLength.ToString(), WireType = xl.WireType, ParentID = xl.ParentID, OrgCode = xl.OrgCode, Contractor = xl.Contractor
                });
            }

            return list;
        }
        public List<bd_sb> GetGtList(string xlcode) {
            List<bd_sb> list = new List<bd_sb>();
            IList<BD_SBTZ> list2 = Client.ClientHelper.PlatformSqlMap.GetList<BD_SBTZ>("where OrgCode='" + xlcode + "'");
            IDictionary dic = Client.ClientHelper.PlatformSqlMap.GetDictionary<BD_SBTZ_ZL>(null, "dm", "mc");
            Dictionary<string, IList<BD_SBTZ_SX>> dicsx = new Dictionary<string, IList<BD_SBTZ_SX>>();
            Dictionary<int, string> dicvalue = new Dictionary<int, string>();
            foreach (BD_SBTZ gt in list2) {
                bd_sb psgt = new bd_sb() {
                    sbid= gt.sb_id, bdzdm=gt.OrgCode, sbmc=gt.sbname, sbzl=gt.sbtype,sbzlmc=dic[gt.sbtype].ToString()
                };
                
                psgt.jsonData = getjsonData(gt.sb_id);
                try { psgt.jsonData2 = getjsonData(gt, dicsx,dicvalue); } catch(Exception err) {
                    Console.WriteLine(err.Message);
                    Console.WriteLine(err.Source);
                    Console.WriteLine(err.StackTrace);
                }
                list.Add(psgt);
            }

            return list;
        }

        private string getjsonData(BD_SBTZ gt, Dictionary<string, IList<BD_SBTZ_SX>> dicsx, Dictionary<int, string> dicvalue) {
            string jsondata = null;
            List<bd_sbsxz> gsonList = new List<bd_sbsxz>();
            Type t = gt.GetType();
            if (!dicsx.ContainsKey(gt.sbtype)) {
                dicsx.Add(gt.sbtype, Client.ClientHelper.PlatformSqlMap.GetList<BD_SBTZ_SX>(" where zldm='" + gt.sbtype + "' and sxcol<>'a1' "));
            }
            foreach(var zlsx in dicsx[gt.sbtype]){
                
                bd_sbsxz sx = new bd_sbsxz() {
                     k=zlsx.sxcol,t=zlsx.sxname,v=t.GetProperty(zlsx.sxcol).GetValue(gt,null).ToString()
                };
                setvalue(sx, zlsx,dicvalue);
                gsonList.Add(sx);
            }
            try {
                jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(gsonList);
            } catch (Exception err) { Console.WriteLine(err.Message); }
            return jsondata;
        }

        private void setvalue(bd_sbsxz sx, BD_SBTZ_SX zlsx, Dictionary<int, string> dicvalue) {
            switch (zlsx.sxtype) {
                case "1":
                case "下拉列表":
                    sx.type = "1";
                    break;
                case "2":
                case "日期":
                    sx.type = "2";
                    break;
                default:
                    sx.type = "0";
                    break;
            }
            if (!string.IsNullOrEmpty(zlsx.boxtype)) {
                if (zlsx.boxtype == "查询") {
                    try {
                        if (dicvalue.ContainsKey(zlsx.id)) {
                            sx.bv = dicvalue[zlsx.id];
                        } else {
                            IList list = Client.ClientHelper.PlatformSqlMap.GetList("SelectOneStr", zlsx.boxvalue);
                            if (list.Count > 0) {
                                string[] ss = new string[list.Count];
                                list.CopyTo(ss, 0);
                                sx.bv = string.Join("|", ss);
                            }
                            dicvalue.Add(zlsx.id, sx.bv);
                        }
                        
                    } catch (Exception err) {
                        Console.WriteLine(zlsx.sxname+Environment.NewLine+zlsx.boxvalue);
                        Console.WriteLine(err.Message);
                        Console.WriteLine(err.Source);
                    }

                } else {
                    sx.bv = zlsx.boxvalue;
                }
            }
        }

        private string gettype(string p) {
            throw new NotImplementedException();
        }

        private string getjsonData(string p) {
            IList<bd_sbtz_fssb> list = Client.ClientHelper.PlatformSqlMap.GetList<bd_sbtz_fssb>("where gtid='" + p + "'");
            string jsondata = null;
            if (list.Count > 0) {
                IList<ps_gtsb> gsonList = new List<ps_gtsb>();
                foreach (bd_sbtz_fssb sb in list) {
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
        public string UpdateGt(List<bd_sb> data) {
            string ret = "0";
            if (data != null) {
                ncount = 0;
                foreach (bd_sb gt in data) {
                    try { UpdateGtOne(gt); } catch (Exception err) { Console.WriteLine(err.Message); }
                }
                ret = data.Count.ToString();
                Console.WriteLine("update {0} count {1}", ret, ncount);
            }
            return ret;
        }
        public string UpdateGtOne(bd_sb data) {
            BD_SBTZ gt = Ebada.Client.ClientHelper.PlatformSqlMap.GetOneByKey<BD_SBTZ>(data.sbid);
            if (gt != null) {
               
                if (!string.IsNullOrEmpty(data.jsonData2)) {
                    Console.WriteLine("data.jsonData2;\r\n"+data.jsonData2);
                    List<bd_sbsxz> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<bd_sbsxz>>(data.jsonData2);
                    if (list != null) {
                        Type t = gt.GetType(); gt.sbname = data.sbmc;
                        foreach (var sx in list) {
                            t.GetProperty(sx.k).SetValue(gt, sx.v,null);
                        }
                        int n=Client.ClientHelper.PlatformSqlMap.Update<BD_SBTZ>(gt);
                        ncount += n>0?n:0;
                    }
                }
                if (!string.IsNullOrEmpty(data.jsonData)) {
                    Console.WriteLine("data.jsonData;\r\n" + data.jsonData);
                    List<ps_gtsb> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ps_gtsb>>(data.jsonData);
                    if (list != null) {
                        List<SqlQueryObject> sqllist = new List<SqlQueryObject>();
                        SqlQueryObject sqo = new SqlQueryObject(SqlQueryType.Delete, "Delete", "delete from bd_sbtz_fssb where gtid='" + gt.sb_id + "'");
                        sqllist.Add(sqo);
                        int num = 0;
                        foreach (ps_gtsb sb in list) {
                            num++;
                            bd_sbtz_fssb gtsb = new bd_sbtz_fssb() { gtID = gt.sb_id, sbModle = sb.xh, sbType = sb.zldm, sbNumber = short.Parse(sb.sl), sbName = sb.zl, sbCode = num.ToString("000") };
                            gtsb.sbID = gt.sb_id + num.ToString("000");
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
            var list = new List<ps_sbzl>();
            var list2 = Client.ClientHelper.PlatformSqlMap.GetList<bd_sbcs>("where c1='材料'");
            foreach (var gt in list2) {
                list.Add(new ps_sbzl() {
                    id = gt.ID, xh = gt.xh, bh = gt.bh, mc = gt.mc, parentid = gt.ParentID
                });
            }

            return list; 
        }
        string select_ver = "select value from msys where dm='androidver_bd'";
        public string GetVersion() {
            string ver = "0";
            try {
                object obj = null;
                try { obj = Client.ClientHelper.PlatformSqlMap.GetObject("Select", select_ver); } catch { }
                int nver = 0;
                if (obj != null) {
                    nver = int.Parse((obj as System.Collections.Hashtable)["value"].ToString());
                    ver = nver.ToString();
                    //Console.WriteLine(ver);
                }
            } catch { }
            return ver;
        }
        #endregion

        #region IScglService 成员

        static Dictionary<string, MemoryStream> imageCache = new Dictionary<string, MemoryStream>();
        public string UpdateGtImage(List<ps_image> list) {
            ps_image data = list[0];
            string msg = "";
            PS_Image image = new PS_Image() { ImageID = data.id, ImageType = "bd" };
            image.ImageData = Convert.FromBase64String(data.data);
            PS_Image image2 = new PS_Image() { ImageID = data.id };
            Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(image, null, image2);
            return msg;
        }
        public string upload_image(ps_image data) {

            return UpdateGtImage3(data.id, data.data, data.type);
        }
        
        public string UpdateGtImage3(string id, byte[] data, string type) {

            string msg = "";
            PS_Image image = new PS_Image() { ImageID = id, ImageType = "bd" };
            image.ImageData = data;
            PS_Image image2 = new PS_Image() { ImageID = id };
            BD_SBTZ gt = Client.ClientHelper.PlatformSqlMap.GetOneByKey<BD_SBTZ>(id);
            object update = null;
            object delete = image2;
            

            Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(image, update, delete);
            return msg;
        }
        public string UpdateGtImage3(string id, string data, string type) {

            string msg = "";
            PS_Image image = new PS_Image() { ImageID = id, ImageType = "bd" };
            image.ImageData = Convert.FromBase64String(data);
            PS_Image image2 = new PS_Image() { ImageID = id };
            sd_gt gt = Client.ClientHelper.PlatformSqlMap.GetOneByKey<sd_gt>(id);
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

        #region IScglBDService 成员


        public List<bd_bdz> GeBDZList(string gdscode) {
            string filter=string.Format("where orgtype='2' and orgcode='{0}' order by orgcode",gdscode);
            if (gdscode == "000")
                filter = "where orgtype='2'  order by orgcode";
            IList<mOrg> list = Client.ClientHelper.PlatformSqlMap.GetList<mOrg>(filter);
            List<bd_bdz> list2 = new List<bd_bdz>();
            foreach (var bdz in list) {
                list2.Add(new bd_bdz() {
                     bdzdm=bdz.OrgCode,
                     bdzmc=bdz.OrgName,
                     jd=bdz.C2,
                     wd=bdz.C3
                }
                );
            }
            return list2;
        }

        #endregion
    }
   
}
