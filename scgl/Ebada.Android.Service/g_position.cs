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
    public class g_position {
        [DataMember]
        public double lng;//经度
        [DataMember]
        public double lat;//纬度
        [DataMember]
        public string dt;//记录时间
        [DataMember]
        public double h;//高度
        [DataMember]
        public double s;//速度
        [DataMember]
        public int id;//设备id        
    }
}
