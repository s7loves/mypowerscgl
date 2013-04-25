/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-4-25 9:39:19
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[sdjls_jyzylcl]业务实体类
    ///对应表名:sdjls_jyzylcl
    /// </summary>
    [Serializable]
    public class sdjls_jyzylcl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _linecode=String.Empty; 
        private string _linename=String.Empty; 
        private string _gh=String.Empty; 
        private string _wz=String.Empty; 
        private string _xh=String.Empty; 
        private string _bmj=String.Empty; 
        private string _wd=String.Empty; 
        private string _dzhyl=String.Empty; 
        private string _hdwhdj=String.Empty; 
        private string _whtz=String.Empty; 
        private string _scymz=String.Empty; 
        private string _scwhdj=String.Empty; 
        private DateTime _clrq=new DateTime(1900,1,1); 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty; 
        private string _c4=String.Empty; 
        private string _c5=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：记录ID
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("记录ID")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[记录ID]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgCode
        /// 属性描述：单位代码
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位代码")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单位代码]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgName
        /// 属性描述：单位名称
        /// 字段信息：[OrgName],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位名称")]
        public string OrgName
        {
            get { return _orgname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单位名称]长度不能大于50!");
                if (_orgname as object == null || !_orgname.Equals(value))
                {
                    _orgname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LineCode
        /// 属性描述：线路代码
        /// 字段信息：[LineCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路代码")]
        public string LineCode
        {
            get { return _linecode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路代码]长度不能大于50!");
                if (_linecode as object == null || !_linecode.Equals(value))
                {
                    _linecode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LineName
        /// 属性描述：线路名称
        /// 字段信息：[LineName],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路名称")]
        public string LineName
        {
            get { return _linename; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路名称]长度不能大于50!");
                if (_linename as object == null || !_linename.Equals(value))
                {
                    _linename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gh
        /// 属性描述：杆号
        /// 字段信息：[gh],nvarchar
        /// </summary>
        [DisplayNameAttribute("杆号")]
        public string gh
        {
            get { return _gh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[杆号]长度不能大于50!");
                if (_gh as object == null || !_gh.Equals(value))
                {
                    _gh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wz
        /// 属性描述：位置
        /// 字段信息：[wz],nvarchar
        /// </summary>
        [DisplayNameAttribute("位置")]
        public string wz
        {
            get { return _wz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[位置]长度不能大于50!");
                if (_wz as object == null || !_wz.Equals(value))
                {
                    _wz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xh
        /// 属性描述：型号
        /// 字段信息：[xh],nvarchar
        /// </summary>
        [DisplayNameAttribute("型号")]
        public string xh
        {
            get { return _xh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[型号]长度不能大于50!");
                if (_xh as object == null || !_xh.Equals(value))
                {
                    _xh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bmj
        /// 属性描述：表面积(c㎡)
        /// 字段信息：[bmj],nvarchar
        /// </summary>
        [DisplayNameAttribute("表面积(c㎡)")]
        public string bmj
        {
            get { return _bmj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[表面积(c㎡)]长度不能大于50!");
                if (_bmj as object == null || !_bmj.Equals(value))
                {
                    _bmj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wd
        /// 属性描述：温度℃
        /// 字段信息：[wd],nvarchar
        /// </summary>
        [DisplayNameAttribute("温度℃")]
        public string wd
        {
            get { return _wd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[温度℃]长度不能大于50!");
                if (_wd as object == null || !_wd.Equals(value))
                {
                    _wd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dzhyl
        /// 属性描述：标准盐密值(mg/c㎡)
        /// 字段信息：[dzhyl],nvarchar
        /// </summary>
        [DisplayNameAttribute("标准盐密值(mg/c㎡)")]
        public string dzhyl
        {
            get { return _dzhyl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[标准盐密值(mg/c㎡)]长度不能大于50!");
                if (_dzhyl as object == null || !_dzhyl.Equals(value))
                {
                    _dzhyl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：hdwhdj
        /// 属性描述：划定污秽等级
        /// 字段信息：[hdwhdj],nvarchar
        /// </summary>
        [DisplayNameAttribute("划定污秽等级")]
        public string hdwhdj
        {
            get { return _hdwhdj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[划定污秽等级]长度不能大于50!");
                if (_hdwhdj as object == null || !_hdwhdj.Equals(value))
                {
                    _hdwhdj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：whtz
        /// 属性描述：污秽特征
        /// 字段信息：[whtz],nvarchar
        /// </summary>
        [DisplayNameAttribute("污秽特征")]
        public string whtz
        {
            get { return _whtz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[污秽特征]长度不能大于500!");
                if (_whtz as object == null || !_whtz.Equals(value))
                {
                    _whtz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：scymz
        /// 属性描述：实测盐密值
        /// 字段信息：[scymz],nvarchar
        /// </summary>
        [DisplayNameAttribute("实测盐密值")]
        public string scymz
        {
            get { return _scymz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[实测盐密值]长度不能大于500!");
                if (_scymz as object == null || !_scymz.Equals(value))
                {
                    _scymz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：scwhdj
        /// 属性描述：实测污秽等级
        /// 字段信息：[scwhdj],nvarchar
        /// </summary>
        [DisplayNameAttribute("实测污秽等级")]
        public string scwhdj
        {
            get { return _scwhdj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[实测污秽等级]长度不能大于500!");
                if (_scwhdj as object == null || !_scwhdj.Equals(value))
                {
                    _scwhdj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：clrq
        /// 属性描述：测量日期
        /// 字段信息：[clrq],datetime
        /// </summary>
        [DisplayNameAttribute("测量日期")]
        public DateTime clrq
        {
            get { return _clrq; }
            set
            {			
                if (_clrq as object == null || !_clrq.Equals(value))
                {
                    _clrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c1
        /// 属性描述：备用字段1
        /// 字段信息：[c1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段1")]
        public string c1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段1]长度不能大于500!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c2
        /// 属性描述：备用字段2
        /// 字段信息：[c2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段2")]
        public string c2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段2]长度不能大于500!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c3
        /// 属性描述：备用字段3
        /// 字段信息：[c3],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段3")]
        public string c3
        {
            get { return _c3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段3]长度不能大于500!");
                if (_c3 as object == null || !_c3.Equals(value))
                {
                    _c3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c4
        /// 属性描述：备用字段4
        /// 字段信息：[c4],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段4")]
        public string c4
        {
            get { return _c4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段4]长度不能大于500!");
                if (_c4 as object == null || !_c4.Equals(value))
                {
                    _c4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c5
        /// 属性描述：备用字段5
        /// 字段信息：[c5],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段5")]
        public string c5
        {
            get { return _c5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段5]长度不能大于500!");
                if (_c5 as object == null || !_c5.Equals(value))
                {
                    _c5 = value;
                }
            }			 
        }
  
        #endregion 
  
        #region 方法
        public static string Newid(){
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        public string CreateID(){
            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        #endregion		
    }	
}
