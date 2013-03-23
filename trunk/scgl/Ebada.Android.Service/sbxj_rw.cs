using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ebada.Android.Service {
    /// <summary>
    /// 设备巡检计划-任务
    /// </summary>
    [DataContract]
    public class sbxj_rw {
        [DataMember]
        public string id;//
        [DataMember]
        public string pid;//计划ID
        [DataMember]
        public string sbbh;//设备编号(杆塔号)
        [DataMember]
        public string sbzt;//设备状态(是否有缺陷)
        [DataMember]
        public string qxnr;//缺陷
        [DataMember]
        public string jd;//经度
        [DataMember]
        public string wd;//纬度 

        [DataMember]
        public string jsonData;//备用可扩展数据
        
    }
}
