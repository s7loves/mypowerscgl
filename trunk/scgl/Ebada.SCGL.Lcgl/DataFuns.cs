using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Ebada.Scgl.Lcgl {
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
        public static ICollection GetItems() {
            ArrayList list = new ArrayList();
            list.Add(new SqlClass() { Caption = "", Sql = "" });

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
