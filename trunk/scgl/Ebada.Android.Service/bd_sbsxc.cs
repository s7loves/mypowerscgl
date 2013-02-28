using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ebada.Android.Service {
    /// <summary>
    /// 变电属性键值类
    /// </summary>
    [DataContract]
    public class bd_sbsxz {
        [DataMember]
        public string k;//列名
        [DataMember]
        public string t;//属性名
        [DataMember]
        public string v;//属性值
        [DataMember]
        public string type;
        [DataMember]
        public string bv;
    }
}
