using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ebada.Android.Service {
    /// <summary>
    /// 变电站
    /// </summary>
    [DataContract]
    public class bd_bdz {
        [DataMember]
        public string bdzdm;
        [DataMember]
        public string bdzmc;
        [DataMember]
        //public string bdzvol;//一次电压
        //[DataMember]
        //public string bdzvol2;//二次电压
        //[DataMember]
        //public string bdzvol3;//三次电压
        //[DataMember]
        //public string gdsdm;
        //[DataMember]
        //public string gdsmc;
        //[DataMember]
        public string jd;
        [DataMember]
        public string wd;
        [DataMember]
        public string bz;
    }
}
