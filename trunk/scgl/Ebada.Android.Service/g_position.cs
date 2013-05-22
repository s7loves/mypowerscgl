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
        [DataMember]
        public String addr;//位置信息
        [DataMember]
        public int locType;//定位类型
        //[DataMember]
        //public double radius;//定位精度(米)
        [DataMember]
        public double dis;//和上一点距离
	public  String toString() {
		return "g_position [lng=" + lng + ", lat=" + lat + ", dt=" + dt
                + ", h=" + h + ", addr=" + addr + ", s=" + s + ", id=" + id + "]";
	}
    }
}
