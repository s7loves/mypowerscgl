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
    ///[PS_tqdlbh]业务实体类
    ///对应表名:PS_tqdlbh
    /// </summary>
    [Serializable]
    public class PS_tqdlbh
    {
        
        #region Private 成员
        private string _tqid=String.Empty; 
        private string _sbid=Newid(); 
        private string _tqname=String.Empty; 
        private string _installadress=String.Empty; 
        private string _sbcode=String.Empty; 
        private string _sbmodle=String.Empty; 
        private string _sbname=String.Empty; 
        private string _factory=String.Empty; 
        private string _number=String.Empty; 
        private DateTime _madedate=new DateTime(1900,1,1); 
        private string _dzdl=String.Empty; 
        private string _dzsj=String.Empty; 
        private string _glr=String.Empty; 
        private DateTime _installdate=new DateTime(1900,1,1); 
        private string _state=String.Empty; 
        private DateTime _indate=new DateTime(1900,1,1);
        private string _orgCode = String.Empty; 
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：tqID
        /// 属性描述：台区ID
        /// 字段信息：[tqID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("台区ID")]
        public string tqID
        {
            get { return _tqid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[台区ID]长度不能大于50!");
                if (_tqid as object == null || !_tqid.Equals(value))
                {
                    _tqid = value;
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
        /// 属性名称：tqName
        /// 属性描述：台区名称
        /// 字段信息：[tqName],nvarchar
        /// </summary>
        [DisplayNameAttribute("台区名称")]
        public string tqName
        {
            get { return _tqname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[台区名称]长度不能大于50!");
                if (_tqname as object == null || !_tqname.Equals(value))
                {
                    _tqname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：InstallAdress
        /// 属性描述：安装地点
        /// 字段信息：[InstallAdress],nvarchar
        /// </summary>
        [DisplayNameAttribute("安装地点")]
        public string InstallAdress
        {
            get { return _installadress; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[安装地点]长度不能大于50!");
                if (_installadress as object == null || !_installadress.Equals(value))
                {
                    _installadress = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbCode
        /// 属性描述：设备编号
        /// 字段信息：[sbCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备编号")]
        public string sbCode
        {
            get { return _sbcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备编号]长度不能大于50!");
                if (_sbcode as object == null || !_sbcode.Equals(value))
                {
                    _sbcode = value;
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
        /// 属性名称：sbName
        /// 属性描述：设备名称
        /// 字段信息：[sbName],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备名称")]
        public string sbName
        {
            get { return _sbname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备名称]长度不能大于50!");
                if (_sbname as object == null || !_sbname.Equals(value))
                {
                    _sbname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Factory
        /// 属性描述：制造厂
        /// 字段信息：[Factory],nvarchar
        /// </summary>
        [DisplayNameAttribute("制造厂")]
        public string Factory
        {
            get { return _factory; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[制造厂]长度不能大于50!");
                if (_factory as object == null || !_factory.Equals(value))
                {
                    _factory = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Number
        /// 属性描述：制造号
        /// 字段信息：[Number],nvarchar
        /// </summary>
        [DisplayNameAttribute("制造号")]
        public string Number
        {
            get { return _number; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[制造号]长度不能大于50!");
                if (_number as object == null || !_number.Equals(value))
                {
                    _number = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：MadeDate
        /// 属性描述：制造日期
        /// 字段信息：[MadeDate],datetime
        /// </summary>
        [DisplayNameAttribute("制造日期")]
        public DateTime MadeDate
        {
            get { return _madedate; }
            set
            {			
                if (_madedate as object == null || !_madedate.Equals(value))
                {
                    _madedate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dzdl
        /// 属性描述：动作电流
        /// 字段信息：[dzdl],nvarchar
        /// </summary>
        [DisplayNameAttribute("动作电流")]
        public string dzdl
        {
            get { return _dzdl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[动作电流]长度不能大于50!");
                if (_dzdl as object == null || !_dzdl.Equals(value))
                {
                    _dzdl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dzsj
        /// 属性描述：动作时间
        /// 字段信息：[dzsj],nvarchar
        /// </summary>
        [DisplayNameAttribute("动作时间")]
        public string dzsj
        {
            get { return _dzsj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[动作时间]长度不能大于50!");
                if (_dzsj as object == null || !_dzsj.Equals(value))
                {
                    _dzsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：glr
        /// 属性描述：管理人
        /// 字段信息：[glr],nvarchar
        /// </summary>
        [DisplayNameAttribute("管理人")]
        public string glr
        {
            get { return _glr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[管理人]长度不能大于50!");
                if (_glr as object == null || !_glr.Equals(value))
                {
                    _glr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：InstallDate
        /// 属性描述：安装日期
        /// 字段信息：[InstallDate],datetime
        /// </summary>
        [DisplayNameAttribute("安装日期")]
        public DateTime InstallDate
        {
            get { return _installdate; }
            set
            {			
                if (_installdate as object == null || !_installdate.Equals(value))
                {
                    _installdate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：State
        /// 属性描述：状态
        /// 字段信息：[State],nvarchar
        /// </summary>
        [DisplayNameAttribute("状态")]
        public string State
        {
            get { return _state; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[状态]长度不能大于50!");
                if (_state as object == null || !_state.Equals(value))
                {
                    _state = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：InDate
        /// 属性描述：投运日期
        /// 字段信息：[InDate],datetime
        /// </summary>
        [DisplayNameAttribute("投运日期")]
        public DateTime InDate
        {
            get { return _indate; }
            set
            {			
                if (_indate as object == null || !_indate.Equals(value))
                {
                    _indate = value;
                }
            }			 
        }
        /// <summary>
        /// 属性名称：orgCode
        /// 属性描述：供电所
        /// 字段信息：[orgCode],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("供电所编号")]
        public string orgCode
        {
            get { return _orgCode; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[台区ID]长度不能大于50!");
                if (_orgCode as object == null || !_orgCode.Equals(value))
                {
                    _orgCode = value;
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
