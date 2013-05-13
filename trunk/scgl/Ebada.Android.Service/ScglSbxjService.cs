using System;
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
    public class ScglSbxjService : IScglSbxjService {
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
       

        private string getjsonData(BD_SBTZ gt,Dictionary<string, IList<BD_SBTZ_SX>> dicsx) {
            string jsondata = null;
            List<bd_sbsxz> gsonList = new List<bd_sbsxz>();
            Type t = gt.GetType();
            if (!dicsx.ContainsKey(gt.sbtype)) {
                dicsx.Add(gt.sbtype, Client.ClientHelper.PlatformSqlMap.GetList<BD_SBTZ_SX>(" where zldm='" + gt.sbtype + "' and sxcol<>'a1' "));
            }
            foreach(var zlsx in dicsx[gt.sbtype]){
                
                bd_sbsxz sx = new bd_sbsxz() {
                     k=zlsx.sxcol,t=zlsx.sxname,v=t.GetProperty(zlsx.sxcol).GetValue(gt,null).ToString(),
                      bv=zlsx.boxvalue,type=zlsx.sxtype
                };

                gsonList.Add(sx);
            }
            try {
                jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(gsonList);
            } catch (Exception err) { Console.WriteLine(err.Message); }
            return jsondata;
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


        string select_ver = "select value from msys where dm='androidver_sdxj'";
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


        #region IScglSbxjService 成员


       
        public string GetPlanList(string username) {
            List<sbxj_jh> jhlist = new List<sbxj_jh>();
            IList<sd_xsjh> list1 = Client.ClientHelper.PlatformSqlMap.GetList<sd_xsjh>("where sxr like '%"+username+"%' and wcbj<>'完成'");
            foreach (var jh in list1) {


                jhlist.Add(new sbxj_jh() {
                    id = jh.ID, LineName = jh.LineName, xslb = jh.xslb, xsnr = jh.xsnr, wcbj = jh.wcbj, vol = jh.vol
                        ,
                    jhsj = jh.jhsj.ToString("yyyy-MM-dd HH:mm:ss")
                        ,
                    wcsj = jh.xswcsj.ToString("yyyy-MM-dd HH:mm:ss")
                        ,
                    kssj = jh.xskssj.ToString("yyyy-MM-dd HH:mm:ss")
                    ,
                    qxnr = jh.qxnr
                    ,
                    xsr = jh.sxr
                    ,
                    rwlist = getrwlist(jh.ID)
                    ,
                    xmlist = getxmlist(jh.ID)
                });
            }
            Console.WriteLine(string.Format("{0},调用方法:{1}({2})",DateTime.Now.ToString(),"GetPlanList",username));
            return Newtonsoft.Json.JsonConvert.SerializeObject(jhlist);
        }
        List<sbxj_rw> getrwlist(string pid) {
            List<sbxj_rw> rwlist = new List<sbxj_rw>();
            IList<sd_xsjhnr> list2 = Client.ClientHelper.PlatformSqlMap.GetList<sd_xsjhnr>("where parentid='" + pid + "'");
            foreach (var nr in list2) {
                rwlist.Add(new sbxj_rw() {
                    id=nr.ID, sbbh=nr.gtbh,pid=pid, jd=nr.lng,wd=nr.lat
                });
            }
            return rwlist;
        }
        List<sbxj_xm> getxmlist(string pid) {
            List<sbxj_xm> rwlist = new List<sbxj_xm>();
            IList<sd_xsxm> list2 = Client.ClientHelper.PlatformSqlMap.GetList<sd_xsxm>("where parentid='" + pid + "'");
            foreach (var nr in list2) {
                rwlist.Add(new sbxj_xm() {
                    id = nr.ID, xmlb = nr.zl, xmnr = nr.mc,  norder=nr.norder
                });
            }
            return rwlist;
        }
        public string UpdatePlanList2(sbxj_jh data) {
            
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            sbxj_jh jh = data;
            sd_xsjh sjh = Client.ClientHelper.PlatformSqlMap.GetOneByKey<sd_xsjh>(jh.id);
            if (sjh != null) {
                sjh.xskssj = DateTime.Parse(jh.kssj);
                sjh.xswcsj = DateTime.Parse(jh.wcsj);
                sjh.qxnr = jh.qxnr;
                sjh.wcbj = jh.wcbj;
            }
            if (jh.gjlist != null && jh.gjlist.Count > 0) {
                updateGjlist(jh.id, jh.gjlist);
            }
            Client.ClientHelper.PlatformSqlMap.Update<sd_xsjh>(sjh);
            Console.WriteLine(string.Format("{0},调用方法:{1},共更新{2}条计划。", DateTime.Now.ToString(), "UpdatePlanList", 1));
            return "ok";
        }
        public string UpdatePlanList(string data) {
            Console.WriteLine(data);
            IList<sbxj_jh> list = new List<sbxj_jh>();
            try {
                list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<sbxj_jh>>(data);
            } catch(Exception er) {
                Console.WriteLine(er.Message);
                return "json数据有问题："+er.Message;
            }
             List<sd_xsjh> list2 = new List<sd_xsjh>();
             Console.Write(data);
             foreach (sbxj_jh jh in list) {
                 sd_xsjh sjh = Client.ClientHelper.PlatformSqlMap.GetOneByKey<sd_xsjh>(jh.id);
                 if (sjh != null) {
                     sjh.xskssj = DateTime.Parse(jh.kssj);
                     sjh.xswcsj = DateTime.Parse(jh.wcsj);
                     sjh.qxnr = jh.qxnr;
                     sjh.wcbj = jh.wcbj;
                     list2.Add(sjh);
                 }
                 if (jh.gjlist != null && jh.gjlist.Count > 0) {
                     updateGjlist(jh.id, jh.gjlist);
                 }
             }
             if (list2.Count > 0) {
                 Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(null, list2.ToArray(), null);
                 Console.WriteLine(string.Format("{0},调用方法:{1},共更新{2}条计划。", DateTime.Now.ToString(), "UpdatePlanList", list2.Count));
             }
            return "ok";
        }

        private void updateGjlist(string rwid, List<sbxj_gj> list) {
            List<sd_xsgj> gjlist = new List<sd_xsgj>();
            List<SqlQueryObject> sqllist = new List<SqlQueryObject>();
            int n = Client.ClientHelper.PlatformSqlMap.GetRowCount<sd_xsgj>(string.Format(" where rwid='{0}' and sj='{1}'", rwid, list[0].dt));
            SqlQueryObject sqo = null;
            if (n >0) {
                sqo = new SqlQueryObject(SqlQueryType.Delete, "Delete", "delete from sd_xsgj where rwID='" + rwid + "'");
                sqllist.Add(sqo);
            }
            foreach (sbxj_gj gj in list) {
                sqo = new SqlQueryObject(SqlQueryType.Insert, new sd_xsgj() {
                    rwID = rwid, jd = gj.jd, wd = gj.wd, sj = DateTime.Parse(gj.dt)
                });
                sqllist.Add(sqo);
            }
            Client.ClientHelper.PlatformSqlMap.ExecuteTransationUpdate(gjlist.ToArray(), null, null);
            Console.WriteLine("{0},调用方法:{1},共插入{2}个巡视轨迹点。", DateTime.Now.ToString(), "updateGjlist", list.Count);
        }

        #endregion
    }
   
}
