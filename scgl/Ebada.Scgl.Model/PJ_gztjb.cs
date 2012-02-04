/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-2-4 12:52:10
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_gztjb]业务实体类
    ///对应表名:PJ_gztjb
    /// </summary>
    [Serializable]
    public class PJ_gztjb
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _lineid=String.Empty; 
        private string _linename=String.Empty; 
        private string _gzd=String.Empty; 
        private string _gznr=String.Empty; 
        private string _qxlb=String.Empty; 
        private DateTime _gzrq=new DateTime(1900,1,1); 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1); 
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
        /// 属性名称：gzd
        /// 属性描述：故障点
        /// 字段信息：[gzd],nvarchar
        /// </summary>
        [DisplayNameAttribute("故障点")]
        public string gzd
        {
            get { return _gzd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[故障点]长度不能大于50!");
                if (_gzd as object == null || !_gzd.Equals(value))
                {
                    _gzd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gznr
        /// 属性描述：故障内容
        /// 字段信息：[gznr],nvarchar
        /// </summary>
        [DisplayNameAttribute("故障内容")]
        public string gznr
        {
            get { return _gznr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[故障内容]长度不能大于500!");
                if (_gznr as object == null || !_gznr.Equals(value))
                {
                    _gznr = value;
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
        /// 属性名称：gzrq
        /// 属性描述：故障日期
        /// 字段信息：[gzrq],datetime
        /// </summary>
        [DisplayNameAttribute("故障日期")]
        public DateTime gzrq
        {
            get { return _gzrq; }
            set
            {			
                if (_gzrq as object == null || !_gzrq.Equals(value))
                {
                    _gzrq = value;
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
        /// 属性名称：Remark
        /// 属性描述：说明
        /// 字段信息：[Remark],nvarchar
        /// </summary>
        [DisplayNameAttribute("说明")]
        public string Remark
        {
            get { return _remark; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[说明]长度不能大于1073741823!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S1
        /// 属性描述：
        /// 字段信息：[S1],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string S1
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
        /// 属性名称：S2
        /// 属性描述：
        /// 字段信息：[S2],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string S2
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
        /// 属性名称：S3
        /// 属性描述：
        /// 字段信息：[S3],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string S3
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
