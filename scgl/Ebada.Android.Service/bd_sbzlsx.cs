using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ebada.Android.Service {
    /// <summary>
    /// 变电设备种类属性
    /// </summary>
    [DataContract]
    public class bd_sbzlsx {
        [DataMember]
        public string zldm;
        [DataMember]
        public string zlmc;
    }
}
