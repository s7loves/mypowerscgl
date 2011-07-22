using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ebada.Client.Platform;
using Ebada.Scgl.Model;
using System.Reflection;
using System.ComponentModel;

namespace Ebada.Android.Service {
    public class ScglService : IScglService {
        #region IScglService 成员

        public User GetUserData(string id, string pwd) {
            string str = MainHelper.EncryptoPassword(pwd);
            User user = new User();
            mUser muser= Client.ClientHelper.PlatformSqlMap.GetOne<mUser>(string.Format("where LoginID='{0}' and password='{1}' ",id,str));
            Type t = user.GetType();/*
            Type t2 = muser.GetType();
            PropertyInfo[] infos=t2.GetProperties();
            foreach (PropertyInfo info in t.GetProperties()) {
                
                    try {
                        object obj=t2.GetProperty(info.Name).GetValue(muser,null);
                        info.SetValue(t,(string)obj , null);
                    } catch {
                    }
                
            }*/

            if (muser == null) {
                user.UserName = "用户名或密码错误！";
            } else {
                user.UserName = muser.UserName;
                user.UserID = muser.UserID;
                user.LoginID = muser.LoginID;
                user.PassWord = pwd;
                user.OrgCode = muser.OrgCode;
                user.OrgName = muser.OrgName;
                user.UserCode = muser.UserCode;
                //Ebada.Core.ConvertHelper.CopyTo(muser, user);
            }

            return user;
        }

        public List<ps_xl> GetXlList(string gdscode) {
            List<ps_xl> list =new List<ps_xl>();
            IList<PS_xl> list2 =Client.ClientHelper.PlatformSqlMap.GetList<PS_xl>("where orgcode='" + gdscode + "'");
            foreach (PS_xl xl in list2) {
                list.Add(new ps_xl() {LineCode=xl.LineCode,LineID=xl.LineID,LineName=xl.LineName,LineVol=xl.LineVol,
                    WireLength=xl.WireLength.ToString(),WireType=xl.WireType ,ParentID=xl.ParentID});
            }

            return list;
        }

        public List<ps_gt> GetGtList(string xlcode) {
            List<ps_gt> list = new List<ps_gt>();
            IList<PS_gt> list2 = Client.ClientHelper.PlatformSqlMap.GetList<PS_gt>("where LineCode='" + xlcode + "'");
            foreach (PS_gt gt in list2) {
                list.Add(new ps_gt() { LineCode = gt.LineCode,
                    gtCode=gt.gtCode,gtElev=gt.gtElev.ToString(),gtHeight=gt.gtHeight.ToString(),
                gth=gt.gth,gtID=gt.gtID,gtLat=gt.gtLat.ToString(),gtLon=gt.gtLon.ToString(),gtSpan=gt.gtSpan.ToString(),
                gtModle=gt.gtModle,gtType=gt.gtType.ToString()});
            }

            return list;
        }

        

        public string UpdateXl(List<ps_xl> data) {

            return "";
        }

        public string UpdateGt(List<ps_gt> data) {
            throw new NotImplementedException();
        }

        #endregion
    }
}
