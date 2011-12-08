/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-12-8 15:02:55
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_cysbmfdtz]业务实体类
    ///对应表名:PJ_cysbmfdtz
    /// </summary>
    [Serializable]
    public class PJ_cysbmfdtz
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _sbmc=String.Empty; 
        private string _installplace=String.Empty; 
        private string _sbmodle=String.Empty; 
        private string _sbcapcity=String.Empty; 
        private string _cysbmc=String.Empty; 
        private string _cysbfactory=String.Empty; 
        private DateTime _indate=new DateTime(1900,1,1); 
        private DateTime _changedate=new DateTime(1900,1,1); 
        private string _mfstatus=String.Empty; 
        private string _jcr=String.Empty; 
        private string _jcdate=String.Empty; 
        private string _remark=String.Empty; 
        private string _s1=String.Empty; 
        private string _s2=String.Empty; 
        private string _s3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
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
        /// 属性名称：sbmc
        /// 属性描述：设备名称
        /// 字段信息：[sbmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备名称")]
        public string sbmc
        {
            get { return _sbmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 100)
                throw new Exception("[设备名称]长度不能大于100!");
                if (_sbmc as object == null || !_sbmc.Equals(value))
                {
                    _sbmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：InstallPlace
        /// 属性描述：安装地点
        /// 字段信息：[InstallPlace],nvarchar
        /// </summary>
        [DisplayNameAttribute("安装地点")]
        public string InstallPlace
        {
            get { return _installplace; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[安装地点]长度不能大于50!");
                if (_installplace as object == null || !_installplace.Equals(value))
                {
                    _installplace = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbModle
        /// 属性描述：型号
        /// 字段信息：[sbModle],nvarchar
        /// </summary>
        [DisplayNameAttribute("型号")]
        public string sbModle
        {
            get { return _sbmodle; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[型号]长度不能大于50!");
                if (_sbmodle as object == null || !_sbmodle.Equals(value))
                {
                    _sbmodle = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbCapcity
        /// 属性描述：容量
        /// 字段信息：[sbCapcity],nvarchar
        /// </summary>
        [DisplayNameAttribute("容量")]
        public string sbCapcity
        {
            get { return _sbcapcity; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[容量]长度不能大于50!");
                if (_sbcapcity as object == null || !_sbcapcity.Equals(value))
                {
                    _sbcapcity = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cysbmc
        /// 属性描述：充油部件名称
        /// 字段信息：[cysbmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("充油部件名称")]
        public string cysbmc
        {
            get { return _cysbmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[充油部件名称]长度不能大于50!");
                if (_cysbmc as object == null || !_cysbmc.Equals(value))
                {
                    _cysbmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cysbFactory
        /// 属性描述：
        /// 字段信息：[cysbFactory],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string cysbFactory
        {
            get { return _cysbfactory; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 100)
                throw new Exception("[]长度不能大于100!");
                if (_cysbfactory as object == null || !_cysbfactory.Equals(value))
                {
                    _cysbfactory = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：inDate
        /// 属性描述：装设日期
        /// 字段信息：[inDate],datetime
        /// </summary>
        [DisplayNameAttribute("装设日期")]
        public DateTime inDate
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
        /// 属性名称：changeDate
        /// 属性描述：下次更换日期
        /// 字段信息：[changeDate],datetime
        /// </summary>
        [DisplayNameAttribute("下次更换日期")]
        public DateTime changeDate
        {
            get { return _changedate; }
            set
            {			
                if (_changedate as object == null || !_changedate.Equals(value))
                {
                    _changedate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：mfStatus
        /// 属性描述：密封点状况
        /// 字段信息：[mfStatus],nvarchar
        /// </summary>
        [DisplayNameAttribute("密封点状况")]
        public string mfStatus
        {
            get { return _mfstatus; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[密封点状况]长度不能大于50!");
                if (_mfstatus as object == null || !_mfstatus.Equals(value))
                {
                    _mfstatus = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jcr
        /// 属性描述：检查人
        /// 字段信息：[jcr],nvarchar
        /// </summary>
        [DisplayNameAttribute("检查人")]
        public string jcr
        {
            get { return _jcr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[检查人]长度不能大于50!");
                if (_jcr as object == null || !_jcr.Equals(value))
                {
                    _jcr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jcDate
        /// 属性描述：检查日期
        /// 字段信息：[jcDate],nvarchar
        /// </summary>
        [DisplayNameAttribute("检查日期")]
        public string jcDate
        {
            get { return _jcdate; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[检查日期]长度不能大于50!");
                if (_jcdate as object == null || !_jcdate.Equals(value))
                {
                    _jcdate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：remark
        /// 属性描述：备注
        /// 字段信息：[remark],nvarchar
        /// </summary>
        [DisplayNameAttribute("备注")]
        public string remark
        {
            get { return _remark; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备注]长度不能大于500!");
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
