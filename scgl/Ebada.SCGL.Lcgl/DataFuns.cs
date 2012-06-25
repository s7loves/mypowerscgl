using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Ebada.Scgl.Lcgl {
    /// <summary>
    /// 流程取数公式
    /// 1、 取全部生产机构名称的下拉列表代码
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
