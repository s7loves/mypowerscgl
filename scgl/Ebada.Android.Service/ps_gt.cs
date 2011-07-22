using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ebada.Android.Service {
    [DataContract]
    public class ps_gt {
        [DataMember]
        public string gtID;
        [DataMember]
        public string LineCode;
        [DataMember]
        public string gtCode;
        [DataMember]
        public string gth;
        [DataMember]
        public string gtType;
        [DataMember]
        public string gtModle;
        [DataMember]
        public string gtHeight;
        [DataMember]
        public string gtLon;
        [DataMember]
        public string gtLat;
        /// <summary>
        /// 高程
        /// </summary>
        [DataMember]
        public string gtElev;
        /// <summary>
        /// 档距
        /// </summary>
        [DataMember]
        public string gtSpan;
    }
}
