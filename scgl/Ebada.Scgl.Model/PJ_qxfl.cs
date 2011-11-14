/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada物流企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-11-14 11:10:09
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_qxfl]业务实体类
    ///对应表名:PJ_qxfl
    /// </summary>
    [Serializable]
    public class PJ_qxfl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _lineid=String.Empty; 
        private string _linename=String.Empty; 
        private string _xlqd=String.Empty; 
        private DateTime _xssj=new DateTime(1900,1,1); 
        private string _xsr=String.Empty; 
        private string _qxnr=String.Empty; 
        private string _qxlb=String.Empty; 
        private string _xcqx=String.Empty; 
        private string _xcr=String.Empty; 
        private DateTime _xcrq=new DateTime(1900,1,1); 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1); 
        private string _gzrjid=String.Empty; 
        private string _qxly=String.Empty; 
        private string _remark=String.Empty; 
        private string _s1=String.Empty; 
        private string _s2=String.Empty; 
        private string _s3=String.Empty;   
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
        /// 属性描述：供电所代码
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("供电所代码")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[供电所代码]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgName
        /// 属性描述：供电所名称
        /// 字段信息：[OrgName],nvarchar
        /// </summary>
        [DisplayNameAttribute("供电所名称")]
        public string OrgName
        {
            get { return _orgname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[供电所名称]长度不能大于50!");
                if (_orgname as object == null || !_orgname.Equals(value))
                {
                    _orgname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LineID
        /// 属性描述：线路代码
        /// 字段信息：[LineID],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路代码")]
        public string LineID
        {
            get { return _lineid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路代码]长度不能大于50!");
                if (_lineid as object == null || !_lineid.Equals(value))
                {
                    _lineid = value;
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
        /// 属性名称：xlqd
        /// 属性描述：巡视区段
        /// 字段信息：[xlqd],nvarchar
        /// </summary>
        [DisplayNameAttribute("巡视区段")]
        public string xlqd
        {
            get { return _xlqd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[巡视区段]长度不能大于50!");
                if (_xlqd as object == null || !_xlqd.Equals(value))
                {
                    _xlqd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xssj
        /// 属性描述：巡视时间
        /// 字段信息：[xssj],datetime
        /// </summary>
        [DisplayNameAttribute("巡视时间")]
        public DateTime xssj
        {
            get { return _xssj; }
            set
            {			
                if (_xssj as object == null || !_xssj.Equals(value))
                {
                    _xssj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xsr
        /// 属性描述：巡视人
        /// 字段信息：[xsr],nvarchar
        /// </summary>
        [DisplayNameAttribute("巡视人")]
        public string xsr
        {
            get { return _xsr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[巡视人]长度不能大于50!");
                if (_xsr as object == null || !_xsr.Equals(value))
                {
                    _xsr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qxnr
        /// 属性描述：缺陷内容
        /// 字段信息：[qxnr],nvarchar
        /// </summary>
        [DisplayNameAttribute("缺陷内容")]
        public string qxnr
        {
            get { return _qxnr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[缺陷内容]长度不能大于500!");
                if (_qxnr as object == null || !_qxnr.Equals(value))
                {
                    _qxnr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qxlb
        /// 属性描述：缺陷类别
        /// 字段信息：[qxlb],nvarchar
        /// </summary>
        [DisplayNameAttribute("缺陷类别")]
        public string qxlb
        {
            get { return _qxlb; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[缺陷类别]长度不能大于50!");
                if (_qxlb as object == null || !_qxlb.Equals(value))
                {
                    _qxlb = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xcqx
        /// 属性描述：
        /// 字段信息：[xcqx],nvarchar
        /// </summary>
        [DisplayNameAttribute("消除期限")]
        public string xcqx
        {
            get { return _xcqx; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_xcqx as object == null || !_xcqx.Equals(value))
                {
                    _xcqx = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xcr
        /// 属性描述：消除人
        /// 字段信息：[xcr],nvarchar
        /// </summary>
        [DisplayNameAttribute("消除人")]
        public string xcr
        {
            get { return _xcr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[消除人]长度不能大于50!");
                if (_xcr as object == null || !_xcr.Equals(value))
                {
                    _xcr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xcrq
        /// 属性描述：消除日期
        /// 字段信息：[xcrq],datetime
        /// </summary>
        [DisplayNameAttribute("消除日期")]
        public DateTime xcrq
        {
            get { return _xcrq; }
            set
            {			
                if (_xcrq as object == null || !_xcrq.Equals(value))
                {
                    _xcrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateMan
        /// 属性描述：填写人
        /// 字段信息：[CreateMan],nvarchar
        /// </summary>
        [DisplayNameAttribute("填写人")]
        public string CreateMan
        {
            get { return _createman; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[填写人]长度不能大于10!");
                if (_createman as object == null || !_createman.Equals(value))
                {
                    _createman = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateDate
        /// 属性描述：填写日期
        /// 字段信息：[CreateDate],datetime
        /// </summary>
        [DisplayNameAttribute("填写日期")]
        public DateTime CreateDate
        {
            get { return _createdate; }
            set
            {			
                if (_createdate as object == null || !_createdate.Equals(value))
                {
                    _createdate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gzrjID
        /// 属性描述：gzrjID
        /// 字段信息：[gzrjID],nvarchar
        /// </summary>
        [DisplayNameAttribute("gzrjID")]
        public string gzrjID
        {
            get { return _gzrjid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[gzrjID]长度不能大于50!");
                if (_gzrjid as object == null || !_gzrjid.Equals(value))
                {
                    _gzrjid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qxly
        /// 属性描述：
        /// 字段信息：[qxly],nvarchar
        /// </summary>
        [DisplayNameAttribute("缺陷来源")]
        public string qxly
        {
            get { return _qxly; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_qxly as object == null || !_qxly.Equals(value))
                {
                    _qxly = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：remark
        /// 属性描述：
        /// 字段信息：[remark],nvarchar
        /// </summary>
        [DisplayNameAttribute("说明")]
        public string remark
        {
            get { return _remark; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[]长度不能大于1073741823!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：s1
        /// 属性描述：
        /// 字段信息：[s1],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string s1
        {
            get { return _s1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_s1 as object == null || !_s1.Equals(value))
                {
                    _s1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：s2
        /// 属性描述：
        /// 字段信息：[s2],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string s2
        {
            get { return _s2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_s2 as object == null || !_s2.Equals(value))
                {
                    _s2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：s3
        /// 属性描述：
        /// 字段信息：[s3],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string s3
        {
            get { return _s3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_s3 as object == null || !_s3.Equals(value))
                {
                    _s3 = value;
                }
            }			 
        }
  
        #endregion 
  
        #region 方法
        public static string Newid(){
            return DateTime.Now.ToString("yyyyMMddHHmmssffffff");
        }
        public string CreateID(){
            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            return DateTime.Now.ToString("yyyyMMddHHmmssffffff");
        }
        #endregion		
    }	
}
