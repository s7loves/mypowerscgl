using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ebada.Android.Service {
    /// <summary>
    /// 设备巡检计划-巡视规迹
    /// </summary>
    [DataContract]
    public class sbxj_gj {
        [DataMember]
        public double jd;//经度
        [DataMember]
        public double wd;//纬度
        [DataMember]
        public DateTime dt;//记录时间
        
    }
}
