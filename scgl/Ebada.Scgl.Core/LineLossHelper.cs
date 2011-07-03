using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Scgl.Model;
using System.Collections;

namespace Ebada.Scgl.Core
{
    public class LineLossHelper
    {
        public static List<PS_xl> GetChildrenList(string id)
        {
            List<PS_xl> list = null;
            IList<PS_xl> list1 = new List<PS_xl>();
            list1 = Client.ClientHelper.PlatformSqlMap.GetListByParentid<PS_xl>(id);
            list.AddRange(list1);
            foreach (PS_xl xl in list1)
            {
                list.AddRange(GetChildrenList(xl.LineID));
            }
            return list;
        }
    }
}
