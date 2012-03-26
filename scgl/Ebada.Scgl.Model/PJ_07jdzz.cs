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
    ///[PJ_07jdzz]业务实体类
    ///对应表名:PJ_07jdzz
    /// </summary>
    [Serializable]
    public class PJ_07jdzz
    {
        
        #region Private 成员
        private string _jdzzid=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _lineid=String.Empty; 
        private string _linename=String.Empty; 
        private string _gth=String.Empty; 
        private string _gzwz=String.Empty; 
        private string _sbmc=String.Empty; 
        private string _xhgg=String.Empty; 
        private decimal _jddz=0; 
        private string _tz=String.Empty; 
        private decimal _trdzr=0; 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1); 
        private string _sbid=String.Empty;
        private string _fzxl = String.Empty;
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：jdzzID
        /// 属性描述：记录ID
        /// 字段信息：[jdzzID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("记录ID")]
        public string jdzzID
        {
            get { return _jdzzid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[记录ID]长度不能大于50!");
                if (_jdzzid as object == null || !_jdzzid.Equals(value))
                {
                    _jdzzid = value;
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
        /// 属性名称：gth
        /// 属性描述：杆号
        /// 字段信息：[gth],nvarchar
        /// </summary>
        [DisplayNameAttribute("杆号")]
        public string gth
        {
            get { return _gth; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[杆号]长度不能大于50!");
                if (_gth as object == null || !_gth.Equals(value))
                {
                    _gth = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gzwz
        /// 属性描述：安装位置
        /// 字段信息：[gzwz],nvarchar
        /// </summary>
        [DisplayNameAttribute("安装位置")]
        public string gzwz
        {
            get { return _gzwz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[安装位置]长度不能大于50!");
                if (_gzwz as object == null || !_gzwz.Equals(value))
                {
                    _gzwz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbmc
        /// 属性描述：保护设备名称
        /// 字段信息：[sbmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("保护设备名称")]
        public string sbmc
        {
            get { return _sbmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[保护设备名称]长度不能大于50!");
                if (_sbmc as object == null || !_sbmc.Equals(value))
                {
                    _sbmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xhgg
        /// 属性描述：型号规格
        /// 字段信息：[xhgg],nvarchar
        /// </summary>
        [DisplayNameAttribute("型号规格")]
        public string xhgg
        {
            get { return _xhgg; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[型号规格]长度不能大于50!");
                if (_xhgg as object == null || !_xhgg.Equals(value))
                {
                    _xhgg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jddz
        /// 属性描述：接地电阻不大于(Ω)
        /// 字段信息：[jddz],decimal
        /// </summary>
        [DisplayNameAttribute("接地电阻不大于(Ω)")]
        public decimal jddz
        {
            get { return _jddz; }
            set
            {			
                if (_jddz as object == null || !_jddz.Equals(value))
                {
                    _jddz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tz
        /// 属性描述：土质
        /// 字段信息：[tz],nvarchar
        /// </summary>
        [DisplayNameAttribute("土质")]
        public string tz
        {
            get { return _tz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[土质]长度不能大于500!");
                if (_tz as object == null || !_tz.Equals(value))
                {
                    _tz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：trdzr
        /// 属性描述：土壤电阻率(Ω.m)
        /// 字段信息：[trdzr],decimal
        /// </summary>
        [DisplayNameAttribute("土壤电阻率(Ω.m)")]
        public decimal trdzr
        {
            get { return _trdzr; }
            set
            {			
                if (_trdzr as object == null || !_trdzr.Equals(value))
                {
                    _trdzr = value;
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
        /// 属性名称：sbID
        /// 属性描述：关联设备ID
        /// 字段信息：[sbID],nvarchar
        /// </summary>
        [DisplayNameAttribute("关联设备ID")]
        public string sbID
        {
            get { return _sbid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[关联设备ID]长度不能大于50!");
                if (_sbid as object == null || !_sbid.Equals(value))
                {
                    _sbid = value;
                }
            }			 
        }
        /// <summary>
        /// 属性名称：fzxl
        /// 属性描述：分支线路名称
        /// 字段信息：[fzxl],nvarchar
        /// </summary>
        [DisplayNameAttribute("分支线路")]
        public string fzxl
        {
            get { return _fzxl; }
            set
            {
                if (value == null) return;
                if (value.ToString().Length > 50)
                    throw new Exception("[分支线路]长度不能大于50!");
                if (_fzxl as object == null || !_fzxl.Equals(value))
                {
                    _fzxl = value;
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
