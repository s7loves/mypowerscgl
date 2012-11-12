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
    ///[PJ_07jdzzjl]业务实体类
    ///对应表名:PJ_07jdzzjl
    /// </summary>
    [Serializable]
    public class PJ_07jdzzjl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _jdzzid=String.Empty; 
        private DateTime _clrq=new DateTime(1900,1,1); 
        private string _tq=String.Empty; 
        private decimal _scz=0; 
        private decimal _hsz=0; 
        private string _jcqk=String.Empty; 
        private string _jr=String.Empty; 
        private string _jcr=String.Empty; 
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
        /// 属性名称：jdzzID
        /// 属性描述：接地装置ID
        /// 字段信息：[jdzzID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("接地装置ID")]
        public string jdzzID
        {
            get { return _jdzzid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[接地装置ID]长度不能大于50!");
                if (_jdzzid as object == null || !_jdzzid.Equals(value))
                {
                    _jdzzid = value;
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
        /// 属性名称：tq
        /// 属性描述：天气
        /// 字段信息：[tq],nvarchar
        /// </summary>
        [DisplayNameAttribute("天气")]
        public string tq
        {
            get { return _tq; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[天气]长度不能大于50!");
                if (_tq as object == null || !_tq.Equals(value))
                {
                    _tq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：scz
        /// 属性描述：实测值
        /// 字段信息：[scz],decimal
        /// </summary>
        [DisplayNameAttribute("实测值")]
        public decimal scz
        {
            get { return _scz; }
            set
            {			
                if (_scz as object == null || !_scz.Equals(value))
                {
                    _scz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：hsz
        /// 属性描述：换算值
        /// 字段信息：[hsz],decimal
        /// </summary>
        [DisplayNameAttribute("换算值")]
        public decimal hsz
        {
            get { return _hsz; }
            set
            {			
                if (_hsz as object == null || !_hsz.Equals(value))
                {
                    _hsz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jcqk
        /// 属性描述：检测情况
        /// 字段信息：[jcqk],nvarchar
        /// </summary>
        [DisplayNameAttribute("检测情况")]
        public string jcqk
        {
            get { return _jcqk; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[检测情况]长度不能大于50!");
                if (_jcqk as object == null || !_jcqk.Equals(value))
                {
                    _jcqk = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jr
        /// 属性描述：结论
        /// 字段信息：[jr],nvarchar
        /// </summary>
        [DisplayNameAttribute("结论")]
        public string jr
        {
            get { return _jr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[结论]长度不能大于50!");
                if (_jr as object == null || !_jr.Equals(value))
                {
                    _jr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jcr
        /// 属性描述：检测人
        /// 字段信息：[jcr],nvarchar
        /// </summary>
        [DisplayNameAttribute("检测人")]
        public string jcr
        {
            get { return _jcr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[检测人]长度不能大于10!");
                if (_jcr as object == null || !_jcr.Equals(value))
                {
                    _jcr = value;
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
