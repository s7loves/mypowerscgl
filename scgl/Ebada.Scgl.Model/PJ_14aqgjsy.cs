/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-16 14:34:00
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_14aqgjsy]业务实体类
    ///对应表名:PJ_14aqgjsy
    /// </summary>
    [Serializable]
    public class PJ_14aqgjsy
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _sbid=String.Empty; 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private DateTime _rq=new DateTime(1900,1,1); 
        private string _jr=String.Empty; 
        private string _sjr=String.Empty; 
        private string _syr=String.Empty; 
        private string _ajqz=String.Empty; 
        private DateTime _xcsyrq=new DateTime(1900,1,1); 
        private string _gznrid=String.Empty; 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1);   
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
        /// 属性名称：sbID
        /// 属性描述：设备ID
        /// 字段信息：[sbID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("设备ID")]
        public string sbID
        {
            get { return _sbid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备ID]长度不能大于50!");
                if (_sbid as object == null || !_sbid.Equals(value))
                {
                    _sbid = value;
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
        /// 属性名称：rq
        /// 属性描述：日期
        /// 字段信息：[rq],datetime
        /// </summary>
        [DisplayNameAttribute("日期")]
        public DateTime rq
        {
            get { return _rq; }
            set
            {			
                if (_rq as object == null || !_rq.Equals(value))
                {
                    _rq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jr
        /// 属性描述：结 论
        /// 字段信息：[jr],nvarchar
        /// </summary>
        [DisplayNameAttribute("结 论")]
        public string jr
        {
            get { return _jr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[结 论]长度不能大于250!");
                if (_jr as object == null || !_jr.Equals(value))
                {
                    _jr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sjr
        /// 属性描述：送检人
        /// 字段信息：[sjr],nvarchar
        /// </summary>
        [DisplayNameAttribute("送检人")]
        public string sjr
        {
            get { return _sjr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[送检人]长度不能大于10!");
                if (_sjr as object == null || !_sjr.Equals(value))
                {
                    _sjr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：syr
        /// 属性描述：试验人
        /// 字段信息：[syr],nvarchar
        /// </summary>
        [DisplayNameAttribute("试验人")]
        public string syr
        {
            get { return _syr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[试验人]长度不能大于10!");
                if (_syr as object == null || !_syr.Equals(value))
                {
                    _syr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ajqz
        /// 属性描述：安监签字
        /// 字段信息：[ajqz],nvarchar
        /// </summary>
        [DisplayNameAttribute("安监签字")]
        public string ajqz
        {
            get { return _ajqz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[安监签字]长度不能大于50!");
                if (_ajqz as object == null || !_ajqz.Equals(value))
                {
                    _ajqz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xcsyrq
        /// 属性描述：下次试验日期
        /// 字段信息：[xcsyrq],datetime
        /// </summary>
        [DisplayNameAttribute("下次试验日期")]
        public DateTime xcsyrq
        {
            get { return _xcsyrq; }
            set
            {			
                if (_xcsyrq as object == null || !_xcsyrq.Equals(value))
                {
                    _xcsyrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gznrID
        /// 属性描述：gznrID
        /// 字段信息：[gznrID],nvarchar
        /// </summary>
        [DisplayNameAttribute("gznrID")]
        public string gznrID
        {
            get { return _gznrid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[gznrID]长度不能大于50!");
                if (_gznrid as object == null || !_gznrid.Equals(value))
                {
                    _gznrid = value;
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
        [Browsable(false)]
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
