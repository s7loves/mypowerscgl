/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-26 20:53:59
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_12kgbd]业务实体类
    ///对应表名:PJ_12kgbd
    /// </summary>
    [Serializable]
    public class PJ_12kgbd
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _kgid=String.Empty; 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private DateTime _azrq=new DateTime(1900,1,1); 
        private string _azdd=String.Empty; 
        private string _gtbh=String.Empty; 
        private string _kgcode=String.Empty; 
        private DateTime _ccrq=new DateTime(1900,1,1); 
        private string _ccyy=String.Empty; 
        private string _remark=String.Empty; 
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
        /// 属性名称：kgID
        /// 属性描述：开关ID
        /// 字段信息：[kgID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("开关ID")]
        public string kgID
        {
            get { return _kgid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[开关ID]长度不能大于50!");
                if (_kgid as object == null || !_kgid.Equals(value))
                {
                    _kgid = value;
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
        /// 属性名称：azrq
        /// 属性描述：安装日期
        /// 字段信息：[azrq],datetime
        /// </summary>
        [DisplayNameAttribute("安装日期")]
        public DateTime azrq
        {
            get { return _azrq; }
            set
            {			
                if (_azrq as object == null || !_azrq.Equals(value))
                {
                    _azrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：azdd
        /// 属性描述：安装地点
        /// 字段信息：[azdd],nvarchar
        /// </summary>
        [DisplayNameAttribute("安装地点")]
        public string azdd
        {
            get { return _azdd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[安装地点]长度不能大于50!");
                if (_azdd as object == null || !_azdd.Equals(value))
                {
                    _azdd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtbh
        /// 属性描述：杆号
        /// 字段信息：[gtbh],nvarchar
        /// </summary>
        [DisplayNameAttribute("杆号")]
        public string gtbh
        {
            get { return _gtbh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[杆号]长度不能大于50!");
                if (_gtbh as object == null || !_gtbh.Equals(value))
                {
                    _gtbh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgCode
        /// 属性描述：开关编号
        /// 字段信息：[kgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("开关编号")]
        public string kgCode
        {
            get { return _kgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[开关编号]长度不能大于50!");
                if (_kgcode as object == null || !_kgcode.Equals(value))
                {
                    _kgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ccrq
        /// 属性描述：撤除日期
        /// 字段信息：[ccrq],datetime
        /// </summary>
        [DisplayNameAttribute("撤除日期")]
        public DateTime ccrq
        {
            get { return _ccrq; }
            set
            {			
                if (_ccrq as object == null || !_ccrq.Equals(value))
                {
                    _ccrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ccyy
        /// 属性描述：撤除原因
        /// 字段信息：[ccyy],nvarchar
        /// </summary>
        [DisplayNameAttribute("撤除原因")]
        public string ccyy
        {
            get { return _ccyy; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[撤除原因]长度不能大于50!");
                if (_ccyy as object == null || !_ccyy.Equals(value))
                {
                    _ccyy = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Remark
        /// 属性描述：备注
        /// 字段信息：[Remark],nvarchar
        /// </summary>
        [DisplayNameAttribute("备注")]
        public string Remark
        {
            get { return _remark; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备注]长度不能大于50!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
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
