using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ebada.Android.Service {
    [DataContract]
    public class ps_sbzl {
        [DataMember]
        public string id;
        [DataMember]
        public string bh;
        [DataMember]
        public string mc;
        [DataMember]
        public string xh;
        [DataMember]
        public string parentid;
    }
}
