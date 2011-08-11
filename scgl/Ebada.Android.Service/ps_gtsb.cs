using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ebada.Android.Service {
    [DataContract]
    public class ps_gtsb {
        [DataMember]
        public string zl;
        [DataMember]
        public string xh;
        [DataMember]
        public string sl;
        [DataMember]
        public string zldm;
    }
}
