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
    public class g_device {
        [DataMember]
        public string IMEI;//设备标识号
        [DataMember]
        public string state;//设备状态,0-未注册,1-已注册
        [DataMember]
        public string jsonData;//设备系统版本
        [DataMember]
        public int id;//设备id        
    }
}
