using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ebada.Android.Service {
    [DataContract]
    public class User {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string PassWord { get; set; }
        [DataMember]
        public string OrgCode { get; set; }
        [DataMember]
        public string OrgName { get; set; }
        [DataMember]
        public string LoginID { get; set; }
        [DataMember]
        public string UserID { get; set; }
        [DataMember]
        public string UserCode { get; set; }
    }
}
