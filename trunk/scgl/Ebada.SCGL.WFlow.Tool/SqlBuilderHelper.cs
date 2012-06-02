using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Ebada.SCGL.WFlow.Tool {
    /// <summary>
    /// 流程取数公式
    /// 1、 取全部生产机构名称的下拉列表代码
    //2、 取本单位的科、所长的特定代码
    //3、 取本单位人员的特定代码
    //4、 取本单位的所有台区名称
    //5、 取本单位的所有10kv线路名称
    //6、 取本单位的所有0.4kv线路名称
    //7、 取本单位的所有台区名称
    //8、 取短语库里的内容
    //9、 取某条线路的所有下级线路
    //10、取某条线路的所有台区或变压器
    //<#公式#>
    /// </summary>
    public class SqlBuilderHelper {
        public static List<SqlClass> GetItems() {
            List<SqlClass> list = new List<SqlClass>();
            list.Add(new SqlClass() { Caption = "取全局生产机构名称列表", Sql = "select orgname from morg where 11=11 and c1='是' and parentid<>'0'" });
            list.Add(new SqlClass() { Caption = "取本单位的科、所长", Sql = "select username from muser where 11=11 and orgcode='{orgcode}' and postname in ('所长','科长') " });
            list.Add(new SqlClass() { Caption = "取本单位所有人员", Sql = "select username from muser where 11=11 and orgcode='{orgcode}'" });
            list.Add(new SqlClass() { Caption = "取本单位的所有台区名称", Sql = "select tqname from ps_tq where 11=11 and tqcode like '{orgcode}%'" });
            list.Add(new SqlClass() { Caption = "取本单位的所有10kv线路名称", Sql = "select linename from ps_xl where 11=11 and orgcode='{orgcode}' and linevol='10' order by linecode" });
            list.Add(new SqlClass() { Caption = "取本单位的所有0.4kv线路名称", Sql = "select linename from ps_xl where 11=11 and orgcode='{orgcode}' and linevol='0.4' order by linecode" });
            list.Add(new SqlClass() { Caption = "取短语库里的内容", Sql = "select nr from pj_dyk where 11=11 and sx='属性名' "});

            return list;
        }

    }

    public class SqlClass {
        public string Caption = string.Empty;
        public string Sql = string.Empty;
        public override string ToString() {
            return Caption;
        }
    }
}
