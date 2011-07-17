using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ebada.Android.Service {
    [DataContract]
    public class ps_xl {
        [DataMember]
        public string LineID { get; set; }
        [DataMember]
        public string LineCode { get; set; }
        [DataMember]
        public string LineName { get; set; }
        [DataMember]
        public string LineVol { get; set; }
        /// <summary>
        /// 导线型号
        /// </summary>
        [DataMember]
        public string WireType { get; set; }
        /// <summary>
        /// 线路长度
        /// </summary>
        [DataMember]
        public string WireLength { get; set; }
    }
}
