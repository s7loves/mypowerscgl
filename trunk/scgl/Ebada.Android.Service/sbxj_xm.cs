using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ebada.Android.Service {
    /// <summary>
    /// 设备巡检计划-项目
    /// </summary>
    [DataContract]
    public class sbxj_xm {
        [DataMember]
        public string id;//
        [DataMember]
        public string xmlb;//项目类别
        [DataMember]
        public string xmnr;//项目内容
        [DataMember]
        public string bj;//标记
        [DataMember]
        public int norder;//序号
        
    }
}
