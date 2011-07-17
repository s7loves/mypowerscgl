using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ebada.Android.Service {
    [DataContract]
    public class ps_gt {
        [DataMember]
        public string gtID { get; set; }
        [DataMember]
        public string LineCode { get; set; }
        [DataMember]
        public string gtCode { get; set; }
        [DataMember]
        public string gth { get; set; }
        [DataMember]
        public string gtType { get; set; }
        [DataMember]
        public string gtHeight { get; set; }
        [DataMember]
        public string gtLon { get; set; }
        [DataMember]
        public string gtLat { get; set; }
        /// <summary>
        /// 高程
        /// </summary>
        [DataMember]
        public string gtElev { get; set; }
        /// <summary>
        /// 档距
        /// </summary>
        [DataMember]
        public string gtSpan { get; set; }
    }
}
