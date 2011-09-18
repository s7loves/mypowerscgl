using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ebada.Android.Service {
    [DataContract]
    public class ps_image {
        [DataMember]
        public string id;
        [DataMember]
        public string type;
        [DataMember]
        public string data;
        [DataMember]
        public string name;
    }
}
