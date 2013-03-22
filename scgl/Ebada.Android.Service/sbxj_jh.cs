using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ebada.Android.Service {
    /// <summary>
    /// 设备巡检计划
    /// </summary>
    [DataContract]
    public class sbxj_jh {
        [DataMember]
        public string id;//
        [DataMember]
        public string LineName;//线路名称
        [DataMember]
        public string vol;//电压等级
        [DataMember]
        public string xslb;//巡视类别
        [DataMember]
        public string xsnr;//巡视内容
        [DataMember]
        public string xsr;//巡视人
        [DataMember]
        public DateTime jhsj;//计划时间
        [DataMember]
        public DateTime kssj;//开始时间
        [DataMember]
        public DateTime wcsj;//完成时间
        [DataMember]
        public string wcbj;//是否完成
        [DataMember]
        public string qxnr;//缺陷内容
        [DataMember]
        public IList<sbxj_rw> rwlist;//详细任务列表
        [DataMember]
        public IList<sbxj_xm> xmlist;//巡视项目列表
        [DataMember]
        public List<sbxj_gj> gjlist;//巡视规迹

        [DataMember]
        public string jsonData;//备用可扩展数据
        
    }
}
