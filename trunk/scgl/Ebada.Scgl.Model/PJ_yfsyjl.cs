/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-8-31 18:19:01
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_yfsyjl]业务实体类
    ///对应表名:PJ_yfsyjl
    /// </summary>
    [Serializable]
    public class PJ_yfsyjl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private int _xh=0; 
        private string _type=String.Empty; 
        private string _sbinstalladress=String.Empty; 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _sbmodle=String.Empty; 
        private int _sbcapacity=0; 
        private int _sl=0; 
        private string _syproject=String.Empty; 
        private string _syperiod=String.Empty; 
        private DateTime _preexptime=new DateTime(1900,1,1); 
        private DateTime _planexptime=new DateTime(1900,1,1); 
        private DateTime _sjexptime=new DateTime(1900,1,1); 
        private string _gzrjid=String.Empty; 
        private string _iswc=String.Empty; 
        private string _syjg=String.Empty; 
        private string _charman=String.Empty; 
        private string _syman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1); 
        private string _remark=String.Empty; 
        private string _wcremark=String.Empty;
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
        /// 属性描述：ID
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("ID")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[ID]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xh
        /// 属性描述：序号
        /// 字段信息：[xh],int
        /// </summary>
        [DisplayNameAttribute("序号")]
        public int xh
        {
            get { return _xh; }
            set
            {			
                if (_xh as object == null || !_xh.Equals(value))
                {
                    _xh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：type
        /// 属性描述：试验类型
        /// 字段信息：[type],nvarchar
        /// </summary>
        [DisplayNameAttribute("试验类型")]
        public string type
        {
            get { return _type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[试验类型]长度不能大于50!");
                if (_type as object == null || !_type.Equals(value))
                {
                    _type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbInstallAdress
        /// 属性描述：设备安装位置
        /// 字段信息：[sbInstallAdress],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备安装位置")]
        public string sbInstallAdress
        {
            get { return _sbinstalladress; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[设备安装位置]长度不能大于250!");
                if (_sbinstalladress as object == null || !_sbinstalladress.Equals(value))
                {
                    _sbinstalladress = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgCode
        /// 属性描述：单位编码
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位编码")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单位编码]长度不能大于50!");
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
        /// 属性名称：sbModle
        /// 属性描述：设备型号
        /// 字段信息：[sbModle],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备型号")]
        public string sbModle
        {
            get { return _sbmodle; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备型号]长度不能大于50!");
                if (_sbmodle as object == null || !_sbmodle.Equals(value))
                {
                    _sbmodle = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbCapacity
        /// 属性描述：设备容量
        /// 字段信息：[sbCapacity],int
        /// </summary>
        [DisplayNameAttribute("设备容量")]
        public int sbCapacity
        {
            get { return _sbcapacity; }
            set
            {			
                if (_sbcapacity as object == null || !_sbcapacity.Equals(value))
                {
                    _sbcapacity = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sl
        /// 属性描述：数量
        /// 字段信息：[sl],int
        /// </summary>
        [DisplayNameAttribute("数量")]
        public int sl
        {
            get { return _sl; }
            set
            {			
                if (_sl as object == null || !_sl.Equals(value))
                {
                    _sl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：syProject
        /// 属性描述：试验项目
        /// 字段信息：[syProject],nvarchar
        /// </summary>
        [DisplayNameAttribute("试验项目")]
        public string syProject
        {
            get { return _syproject; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[试验项目]长度不能大于500!");
                if (_syproject as object == null || !_syproject.Equals(value))
                {
                    _syproject = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：syPeriod
        /// 属性描述：试验周期
        /// 字段信息：[syPeriod],nvarchar
        /// </summary>
        [DisplayNameAttribute("试验周期")]
        public string syPeriod
        {
            get { return _syperiod; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[试验周期]长度不能大于50!");
                if (_syperiod as object == null || !_syperiod.Equals(value))
                {
                    _syperiod = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：preExpTime
        /// 属性描述：上次试验时间
        /// 字段信息：[preExpTime],datetime
        /// </summary>
        [DisplayNameAttribute("上次试验时间")]
        public DateTime preExpTime
        {
            get { return _preexptime; }
            set
            {			
                if (_preexptime as object == null || !_preexptime.Equals(value))
                {
                    _preexptime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：planExpTime
        /// 属性描述：计划试验时间
        /// 字段信息：[planExpTime],datetime
        /// </summary>
        [DisplayNameAttribute("计划试验时间")]
        public DateTime planExpTime
        {
            get { return _planexptime; }
            set
            {			
                if (_planexptime as object == null || !_planexptime.Equals(value))
                {
                    _planexptime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sjExpTime
        /// 属性描述：完成试验时间
        /// 字段信息：[sjExpTime],datetime
        /// </summary>
        [DisplayNameAttribute("完成试验时间")]
        public DateTime sjExpTime
        {
            get { return _sjexptime; }
            set
            {			
                if (_sjexptime as object == null || !_sjexptime.Equals(value))
                {
                    _sjexptime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gzrjID
        /// 属性描述：日志
        /// 字段信息：[gzrjID],nvarchar
        /// </summary>
        [DisplayNameAttribute("日志")]
        public string gzrjID
        {
            get { return _gzrjid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[日志]长度不能大于50!");
                if (_gzrjid as object == null || !_gzrjid.Equals(value))
                {
                    _gzrjid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：iswc
        /// 属性描述：是否完成
        /// 字段信息：[iswc],nvarchar
        /// </summary>
        [DisplayNameAttribute("是否完成")]
        public string iswc
        {
            get { return _iswc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[是否完成]长度不能大于50!");
                if (_iswc as object == null || !_iswc.Equals(value))
                {
                    _iswc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：syjg
        /// 属性描述：实验结果
        /// 字段信息：[syjg],nvarchar
        /// </summary>
        [DisplayNameAttribute("实验结果")]
        public string syjg
        {
            get { return _syjg; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[实验结果]长度不能大于50!");
                if (_syjg as object == null || !_syjg.Equals(value))
                {
                    _syjg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：charMan
        /// 属性描述：落实人
        /// 字段信息：[charMan],nvarchar
        /// </summary>
        [DisplayNameAttribute("落实人")]
        public string charMan
        {
            get { return _charman; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[落实人]长度不能大于50!");
                if (_charman as object == null || !_charman.Equals(value))
                {
                    _charman = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：syMan
        /// 属性描述：实验人
        /// 字段信息：[syMan],nchar
        /// </summary>
        [DisplayNameAttribute("实验人")]
        public string syMan
        {
            get { return _syman; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[实验人]长度不能大于10!");
                if (_syman as object == null || !_syman.Equals(value))
                {
                    _syman = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateDate
        /// 属性描述：创建时间
        /// 字段信息：[CreateDate],datetime
        /// </summary>
        [DisplayNameAttribute("创建时间")]
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
                if( value.ToString().Length > 1073741823)
                throw new Exception("[备注]长度不能大于1073741823!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wcRemark
        /// 属性描述：说明
        /// 字段信息：[wcRemark],nvarchar
        /// </summary>
        [DisplayNameAttribute("说明")]
        public string wcRemark
        {
            get { return _wcremark; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[说明]长度不能大于1073741823!");
                if (_wcremark as object == null || !_wcremark.Equals(value))
                {
                    _wcremark = value;
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
