using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Components;
using System.Collections;
namespace Ebada.Server.Host {
    internal class DBHelper {
        internal int mVer = 5;
        string mSelect = "Select";
        string mUpdate = "Update";
        IBaseSqlMapDao sqlMap;
        string  create_msys="if not exists (select 1 from  sysobjects where  id = object_id('dbo.mSys')  and   type = 'U') "
            +" create table dbo.msys(DM  nvarchar(20)    not null,  Title    nvarchar(20)   null,   Value     nvarchar(20)   null, constraint PK_MSYS primary key (DM)"
            +") "
            +" insert into msys values('dbver','数据库版本','1')";
        string select_ver = "select value from msys where dm='dbver'";
        string update_ver = "update msys set value='{0}' where dm='dbver'";
        string update_AndroidVer = "update msys set value='{0}' where dm='androidver'";
        string insertAndroidVer = "insert msys values('androidver','手机端软件版本','2')";
        public IBaseSqlMapDao SqlMap {
            get {
                if (sqlMap == null)
                    sqlMap = ServerContainer.PlatformServer.GetService<IBaseSqlMapDao>();
                return sqlMap; }
            set { sqlMap = value; }
        }
        public void UpdateDatabase() {
            object obj = null;
            try { obj=SqlMap.GetObject("Select", select_ver); } catch { }
            int ver = 0;
            if (obj != null) {
                ver = int.Parse((obj as Hashtable)["value"].ToString());
                Console.WriteLine("当前数据库版本ver:{0}", ver);
            }
            if (ver == 0) 
                SqlMap.Update(mUpdate, create_msys);
            if (ver < 2) {
                try {
                    SqlMap.Update(mUpdate, string.Format(update_ver, 2));
                    Console.WriteLine("更新数据库版本ver:{0}",2);
                } catch (Exception e) { throw e; }

            }
            if (ver < 3) {
                try {
                    sqlMap.Update(mUpdate, insertAndroidVer);
                    SqlMap.Update(mUpdate, string.Format(update_ver, 3));
                    Console.WriteLine("更新数据库版本ver:{0}", 3);
                } catch (Exception e) { throw e; }

            }
            //if (ver < 4) {
            //    try {
            //        sqlMap.Update(mUpdate, string.Format(update_AndroidVer,3));//更新android客户端
            //        SqlMap.Update(mUpdate, string.Format(update_ver, 4));
            //        Console.WriteLine("更新数据库版本ver:{0}", 4);
            //        Console.WriteLine("更新手机服务器版本ver:{0}", 3);
            //    } catch (Exception e) { throw e; }

            //}
            //if (ver < 5) {
            //    try {
            //        sqlMap.Update(mUpdate, string.Format(update_AndroidVer, 4));//更新android客户端，增加上传图片功能
            //        SqlMap.Update(mUpdate, string.Format(update_ver, 5));
            //        Console.WriteLine("更新数据库版本ver:{0}", 5);
            //        Console.WriteLine("更新手机服务器版本ver:{0}", 4);
            //    } catch (Exception e) { throw e; }

            //}
            if (ver < 7) {
                try {
                    sqlMap.Update(mUpdate, string.Format(update_AndroidVer, 6));//5版本更新android客户端，修正串号
                    SqlMap.Update(mUpdate, string.Format(update_ver, 7));
                    Console.WriteLine("更新数据库版本ver:{0}", 7);
                    Console.WriteLine("更新手机服务器版本ver:{0}", 6);
                } catch (Exception e) { throw e; }

            }
            try { SqlMap.Update(mUpdate, "alter table ps_gt add dxplfs nvarchar(50) "); } catch { }//2011.11.27
        }
    }
}
