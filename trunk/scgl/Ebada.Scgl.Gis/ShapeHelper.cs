using System;
using System.Collections.Generic;
using System.Text;

namespace Ebada.Scgl.Gis
{
    internal class ShapeHelper
    {
        static Dictionary<string, string> typedic;
        static ShapeHelper() {
            typedic=  new Dictionary<string, string>();
            typedic.Add("gt", "57AF94BA-4129-45dc-0010-000000000001");
            typedic.Add("kg", "57AF94BA-4129-45dc-0010-000000000002");
            typedic.Add("bx", "57AF94BA-4129-45dc-0010-000000000003");
            typedic.Add("text", "57AF94BA-4129-45dc-B8FD-000000000003");
        }
        public static string GetShapeKey(string type){
            return typedic[type];
        }
        
    }
}
