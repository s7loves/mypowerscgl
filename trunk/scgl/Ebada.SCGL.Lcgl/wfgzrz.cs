using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Scgl.Model;
using System.Threading;
using Ebada.Client.Platform;

namespace Ebada.Scgl.Lcgl
{
    class wfgzrz
    {
        public static void CreatRiZhi(PJ_06sbxsmx obj)
        {


            PJ_gzrjnr gzr = new PJ_gzrjnr();
            gzr.gzrjID = gzr.CreateID();
            gzr.ParentID = obj.ID;
            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            IList<PJ_01gzrj> gzrj01 = MainHelper.PlatformSqlMap.GetList<PJ_01gzrj>("SelectPJ_01gzrjList", "where GdsCode='" + MainHelper.User.OrgCode + "' and rq between '" + DateTime.Now.ToString("yyyy-MM-dd 00:00:00") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd 23:59:59") + "'");

            if (gzrj01.Count > 0)
            {
                gzr.gzrjID = gzrj01[0].gzrjID;
            }
            else
            {
                PJ_01gzrj pj = new PJ_01gzrj();
                pj.gzrjID = pj.CreateID();
                pj.GdsCode = MainHelper.User.OrgCode;
                pj.GdsName = MainHelper.User.OrgName;
                pj.CreateDate = DateTime.Now;
                pj.CreateMan = MainHelper.User.UserName;
                gzr.gzrjID = pj.gzrjID;
                pj.rq = DateTime.Now.Date;
                pj.xq = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
                pj.rsaqts = (DateTime.Today - MainHelper.UserOrg.PSafeTime.Date).Days;
                pj.sbaqts = (DateTime.Today - MainHelper.UserOrg.DSafeTime.Date).Days;
                Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                MainHelper.PlatformSqlMap.Create<PJ_01gzrj>(pj);


            }
            IList<PJ_gzrjnr> gzrlist = MainHelper.PlatformSqlMap.GetList<PJ_gzrjnr>("SelectPJ_gzrjnrList", "where gzrjID  = '" + gzr.gzrjID + "' order by seq  ");
            if (gzrlist.Count > 0)
            {
                gzr.seq = gzrlist[gzrlist.Count - 1].seq + 1;
            }
            else
                gzr.seq = 1;

            gzr.gznr =obj.LineName+ "线路设备巡视";
            gzr.fzr = "配电班长";
            string[] strli = obj.xsr.Split(';');
            if (strli.Length < 3)
                gzr.cjry = obj.xsr;
            else
            {
                gzr.cjry = strli[0] + "、" + strli[1] + "等" + strli.Length + "人";
            }
            gzr.CreateDate = DateTime.Now;
            gzr.CreateMan = MainHelper.User.UserName;
            gzr.fssj = DateTime.Now;
            MainHelper.PlatformSqlMap.Create<PJ_gzrjnr>(gzr);

        }
        public static void CreatRiZhi(PJ_13dlbhjl obj)
        {


            PJ_gzrjnr gzr = new PJ_gzrjnr();
            gzr.gzrjID = gzr.CreateID();
            gzr.ParentID = obj.ID;
            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            IList<PJ_01gzrj> gzrj01 = MainHelper.PlatformSqlMap.GetList<PJ_01gzrj>("SelectPJ_01gzrjList", "where GdsCode='" + MainHelper.User.OrgCode + "' and rq between '" + DateTime.Now.ToString("yyyy-MM-dd 00:00:00") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd 23:59:59") + "'");

            if (gzrj01.Count > 0)
            {
                gzr.gzrjID = gzrj01[0].gzrjID;
            }
            else
            {
                PJ_01gzrj pj = new PJ_01gzrj();
                pj.gzrjID = pj.CreateID();
                pj.GdsCode = MainHelper.User.OrgCode;
                pj.GdsName = MainHelper.User.OrgName;
                pj.CreateDate = DateTime.Now;
                pj.CreateMan = MainHelper.User.UserName;
                gzr.gzrjID = pj.gzrjID;
                pj.rq = DateTime.Now.Date;
                pj.xq = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
                pj.rsaqts = (DateTime.Today - MainHelper.UserOrg.PSafeTime.Date).Days;
                pj.sbaqts = (DateTime.Today - MainHelper.UserOrg.DSafeTime.Date).Days;
                Thread.Sleep(new TimeSpan(100000));//0.1毫秒
                MainHelper.PlatformSqlMap.Create<PJ_01gzrj>(pj);


            }
            IList<PJ_gzrjnr> gzrlist = MainHelper.PlatformSqlMap.GetList<PJ_gzrjnr>("SelectPJ_gzrjnrList", "where gzrjID  = '" + gzr.gzrjID + "' order by seq  ");
            if (gzrlist.Count > 0)
            {
                gzr.seq = gzrlist[gzrlist.Count - 1].seq + 1;
            }
            else
                gzr.seq = 1;

            gzr.gznr = "全所目前运行的×个台区剩余电流动作保护期测试";
            gzr.fzr = "配电班长";
            string[] strli = obj.csr.Split(';');
            if (strli.Length < 3)
                gzr.cjry = obj.csr;
            else
            {
                gzr.cjry = strli[0] + "、" + strli[1] + "等" + strli.Length + "人";
            }
            gzr.CreateDate = DateTime.Now;
            gzr.CreateMan = MainHelper.User.UserName;
            gzr.fssj = DateTime.Now;
            MainHelper.PlatformSqlMap.Create<PJ_gzrjnr>(gzr);

        }
    }
}
