using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ebada.Scgl.Sbgl {
    public class ps_xl {
        public string LineID;
        public string ParentID;
        public string LineCode;
        public string LineName;
        public string LineVol;
        public string OrgCode;
        public string Contractor;
        /// <summary>
        /// 导线型号
        /// </summary>
        public string WireType ;
        /// <summary>
        /// 线路长度
        /// </summary>
        public string WireLength;
    }
}
