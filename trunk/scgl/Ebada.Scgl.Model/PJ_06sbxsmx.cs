/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-8-25 22:00:53
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_06sbxsmx]业务实体类
    ///对应表名:PJ_06sbxsmx
    /// </summary>
    [Serializable]
    public class PJ_06sbxsmx
    {
        
        #region Private 成员
        private string _id=Newid();
         private string _ParentID=String.Empty;
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _lineid=String.Empty; 
        private string _linename=String.Empty; 
        private string _xlqd=String.Empty; 
        private DateTime _xssj=new DateTime(1900,1,1); 
        private string _xsr=String.Empty; 
        private string _qxnr=String.Empty;
        private string _qxlb = String.Empty;
        private string _xcqx = String.Empty;    
        private string _xcr=String.Empty; 
        private DateTime _xcrq=new DateTime(1900,1,1); 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1); 
        private string _gzrjid=String.Empty;
        private string _xlid = String.Empty;
        private string _byqid = String.Empty;
        private string _tqid = String.Empty;
        private string _kgid = String.Empty;
        private string _xlname = String.Empty;
        private string _byqname = String.Empty;
        private string _tqname = String.Empty;
        private string _kgname = String.Empty;

        private string _gdstemp = String.Empty;
        private string _linetemp = String.Empty;
        private string _othertemp = String.Empty; 
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
        /// 属性名称：ParentID
        /// 属性描述：ParentID
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("ParentID")]
        public string ParentID
        {
            get { return _ParentID; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[记录ID]长度不能大于50!");
                if (_ParentID as object == null || !_ParentID.Equals(value))
                {
                    _ParentID = value;
                }
            }			 
        }
        /// <summary>
        /// 属性名称：OrgCode
        /// 属性描述：供电所代码
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [Browsable(false)]
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
        [Browsable(false)]
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
        [Browsable(false)]
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
        [Browsable(false)]
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
        [Browsable(false)]
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
        /// 属性描述：消缺期限
        /// 字段信息：[xcqx],nvarchar
        /// </summary>
        [DisplayNameAttribute("消缺期限")]
        public string xcqx
        {
            get { return _xcqx; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[消缺期限]长度不能大于50!");
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
  
        /// <summary>
        /// 属性名称：gzrjID
        /// 属性描述：gzrjID
        /// 字段信息：[gzrjID],nvarchar
        /// </summary>
        [Browsable(false)]
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
        /// 属性名称：xlid
        /// 属性描述：
        /// 字段信息：[xlid],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("xlid")]
        public string xlid
        {
            get { return _xlid; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[xlid]长度不能大于50!");
                if (_xlid as object == null || !_xlid.Equals(value))
                {
                    _xlid = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：byqid
        /// 属性描述：
        /// 字段信息：[byqid],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("byqid")]
        public string byqid
        {
            get { return _byqid; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[byqid]长度不能大于50!");
                if (_byqid as object == null || !_byqid.Equals(value))
                {
                    _byqid = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：tqid
        /// 属性描述：
        /// 字段信息：[tqid],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("tqid")]
        public string tqid
        {
            get { return _tqid; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[tqid]长度不能大于50!");
                if (_tqid as object == null || !_tqid.Equals(value))
                {
                    _tqid = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：kgid
        /// 属性描述：
        /// 字段信息：[kgid],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("kgid")]
        public string kgid
        {
            get { return _kgid; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[kgid]长度不能大于50!");
                if (_kgid as object == null || !_kgid.Equals(value))
                {
                    _kgid = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：xlname
        /// 属性描述：线路
        /// 字段信息：[xlname],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("线路")]
        public string xlname
        {
            get { return _xlname; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[线路]长度不能大于50!");
                if (_xlname as object == null || !_xlname.Equals(value))
                {
                    _xlname = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：byqname
        /// 属性描述：变压器
        /// 字段信息：[byqname],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("变压器")]
        public string byqname
        {
            get { return _byqname; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[变压器]长度不能大于50!");
                if (_byqname as object == null || !_byqname.Equals(value))
                {
                    _byqname = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：tqname
        /// 属性描述：台区
        /// 字段信息：[tqname],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("台区")]
        public string tqname
        {
            get { return _tqname; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[台区]长度不能大于50!");
                if (_tqname as object == null || !_tqname.Equals(value))
                {
                    _tqname = value;
                }
            }
        }
        /// <summary>
        /// 属性名称：kgname
        /// 属性描述：开关
        /// 字段信息：[kgname],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("开关")]
        public string kgname
        {
            get { return _kgname; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[开关]长度不能大于50!");
                if (_kgname as object == null || !_kgname.Equals(value))
                {
                    _kgname = value;
                }
            }
        }
        /// <summary>
        /// 属性名称：gdstemp
        /// 属性描述：供电所临时
        /// 字段信息：[gdstemp],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("供电所临时")]
        public string gdstemp
        {
            get { return _gdstemp; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[供电所临时]长度不能大于50!");
                if (_gdstemp as object == null || !_gdstemp.Equals(value))
                {
                    _gdstemp = value;
                }
            }
        }

        /// <summary>
        /// 属性名称：linetemp
        /// 属性描述：线路临时
        /// 字段信息：[linetemp],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("线路临时")]
        public string linetemp
        {
            get { return _linetemp; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[线路临时]长度不能大于50!");
                if (_linetemp as object == null || !_linetemp.Equals(value))
                {
                    _linetemp = value;
                }
            }
        }
        /// <summary>
        /// 属性名称：othertemp
        /// 属性描述：其它临时
        /// 字段信息：[othertemp],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("其它临时")]
        public string othertemp
        {
            get { return _othertemp; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[其它临时]长度不能大于50!");
                if (_othertemp as object == null || !_othertemp.Equals(value))
                {
                    _othertemp = value;
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
