using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ebada.Android.Service {
    [DataContract]
    public class ps_xl {
        [DataMember]
        public string LineID;
        [DataMember]
        public string ParentID;
        [DataMember]
        public string LineCode;
        [DataMember]
        public string LineName;
        [DataMember]
        public string LineVol;
        [DataMember]
        public string OrgCode;
        [DataMember]
        public string Contractor;
        /// <summary>
        /// 导线型号
        /// </summary>
        [DataMember]
        public string WireType ;
        /// <summary>
        /// 线路长度
        /// </summary>
        [DataMember]
        public string WireLength;
    }
}
