/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-26 20:54:00
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_21gzbxdh]业务实体类
    ///对应表名:PJ_21gzbxdh
    /// </summary>
    [Serializable]
    public class PJ_21gzbxdh
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _rq=String.Empty; 
        private string _lxfs=String.Empty; 
        private string _yhdz=String.Empty; 
        private string _gzjk=String.Empty; 
        private string _djr=String.Empty; 
        private string _clr=String.Empty; 
        private string _gzrjid=String.Empty; 
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
        /// 字段信息：[rq],nvarchar
        /// </summary>
        [DisplayNameAttribute("日期")]
        public string rq
        {
            get { return _rq; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[日期]长度不能大于50!");
                if (_rq as object == null || !_rq.Equals(value))
                {
                    _rq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lxfs
        /// 属性描述：联系方式
        /// 字段信息：[lxfs],nvarchar
        /// </summary>
        [DisplayNameAttribute("联系方式")]
        public string lxfs
        {
            get { return _lxfs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[联系方式]长度不能大于50!");
                if (_lxfs as object == null || !_lxfs.Equals(value))
                {
                    _lxfs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：yhdz
        /// 属性描述：用户地址
        /// 字段信息：[yhdz],nvarchar
        /// </summary>
        [DisplayNameAttribute("用户地址")]
        public string yhdz
        {
            get { return _yhdz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[用户地址]长度不能大于50!");
                if (_yhdz as object == null || !_yhdz.Equals(value))
                {
                    _yhdz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gzjk
        /// 属性描述：故障简况
        /// 字段信息：[gzjk],nvarchar
        /// </summary>
        [DisplayNameAttribute("故障简况")]
        public string gzjk
        {
            get { return _gzjk; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[故障简况]长度不能大于50!");
                if (_gzjk as object == null || !_gzjk.Equals(value))
                {
                    _gzjk = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：djr
        /// 属性描述：登记人
        /// 字段信息：[djr],nvarchar
        /// </summary>
        [DisplayNameAttribute("登记人")]
        public string djr
        {
            get { return _djr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[登记人]长度不能大于10!");
                if (_djr as object == null || !_djr.Equals(value))
                {
                    _djr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：clr
        /// 属性描述：处理人
        /// 字段信息：[clr],nvarchar
        /// </summary>
        [DisplayNameAttribute("处理人")]
        public string clr
        {
            get { return _clr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[处理人]长度不能大于10!");
                if (_clr as object == null || !_clr.Equals(value))
                {
                    _clr = value;
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
