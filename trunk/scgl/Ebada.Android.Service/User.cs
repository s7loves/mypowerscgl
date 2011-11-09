using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ebada.Android.Service {
    [DataContract]
    public class User {
        [DataMember]
        public string UserName;
        [DataMember]
        public string PassWord;
        [DataMember]
        public string OrgCode;
        [DataMember]
        public string OrgName;
        [DataMember]
        public string LoginID;
        [DataMember]
        public string UserID;
        [DataMember]
        public string UserCode;
    }
}
