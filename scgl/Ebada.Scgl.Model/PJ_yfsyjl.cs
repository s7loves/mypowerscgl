/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-8-29 20:07:10
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
        private string _syproject=String.Empty; 
        private string _syperiod=String.Empty; 
        private int _sl=0; 
        private DateTime _preexptime=new DateTime(1900,1,1); 
        private DateTime _planexptime=new DateTime(1900,1,1); 
        private string _gzrjid=String.Empty; 
        private string _charman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1); 
        private string _remark=String.Empty;   
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
