using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ebada.Android.Service {
    /// <summary>
    /// 变电设备
    /// </summary>
    [DataContract]
    public class bd_sb {
        [DataMember]
        public string sbid;
        [DataMember]
        public string sbmc;
        [DataMember]
        public string bdzdm;
        [DataMember]
        public string sbzl;//设备种类
        [DataMember]
        public string sbzlmc;//设备种类名称
        [DataMember]
        public string jsonData;
        [DataMember]
        public string jsonData2;//a1-a51值
    }
}
