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
    ///[PJ_dlxldrqtz]业务实体类
    ///对应表名:PJ_dlxldrqtz
    /// </summary>
    [Serializable]
    public class PJ_dlxldrqtz
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _linename=String.Empty; 
        private string _gtnumber=String.Empty; 
        private string _drqmodle=String.Empty; 
        private string _edvol=String.Empty; 
        private string _capcity=String.Empty; 
        private string _sbnum=String.Empty; 
        private string _sbfactory=String.Empty; 
        private string _tqfs=String.Empty; 
        private string _indate=String.Empty; 
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
        /// 属性描述：
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgName
        /// 属性描述：
        /// 字段信息：[OrgName],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string OrgName
        {
            get { return _orgname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_orgname as object == null || !_orgname.Equals(value))
                {
                    _orgname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lineName
        /// 属性描述：线路名称
        /// 字段信息：[lineName],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路名称")]
        public string lineName
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
        /// 属性名称：gtNumber
        /// 属性描述：杆号
        /// 字段信息：[gtNumber],nvarchar
        /// </summary>
        [DisplayNameAttribute("杆号")]
        public string gtNumber
        {
            get { return _gtnumber; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[杆号]长度不能大于50!");
                if (_gtnumber as object == null || !_gtnumber.Equals(value))
                {
                    _gtnumber = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：drqModle
        /// 属性描述：
        /// 字段信息：[drqModle],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string drqModle
        {
            get { return _drqmodle; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_drqmodle as object == null || !_drqmodle.Equals(value))
                {
                    _drqmodle = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：edVol
        /// 属性描述：额定电压
        /// 字段信息：[edVol],nvarchar
        /// </summary>
        [DisplayNameAttribute("额定电压")]
        public string edVol
        {
            get { return _edvol; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[额定电压]长度不能大于50!");
                if (_edvol as object == null || !_edvol.Equals(value))
                {
                    _edvol = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Capcity
        /// 属性描述：容量
        /// 字段信息：[Capcity],nvarchar
        /// </summary>
        [DisplayNameAttribute("容量")]
        public string Capcity
        {
            get { return _capcity; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[容量]长度不能大于50!");
                if (_capcity as object == null || !_capcity.Equals(value))
                {
                    _capcity = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbnum
        /// 属性描述：台数
        /// 字段信息：[sbnum],nvarchar
        /// </summary>
        [DisplayNameAttribute("台数")]
        public string sbnum
        {
            get { return _sbnum; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[台数]长度不能大于50!");
                if (_sbnum as object == null || !_sbnum.Equals(value))
                {
                    _sbnum = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbFactory
        /// 属性描述：
        /// 字段信息：[sbFactory],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string sbFactory
        {
            get { return _sbfactory; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_sbfactory as object == null || !_sbfactory.Equals(value))
                {
                    _sbfactory = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tqfs
        /// 属性描述：投切方式
        /// 字段信息：[tqfs],nvarchar
        /// </summary>
        [DisplayNameAttribute("投切方式")]
        public string tqfs
        {
            get { return _tqfs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[投切方式]长度不能大于50!");
                if (_tqfs as object == null || !_tqfs.Equals(value))
                {
                    _tqfs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：inDate
        /// 属性描述：投运日期
        /// 字段信息：[inDate],nvarchar
        /// </summary>
        [DisplayNameAttribute("投运日期")]
        public string inDate
        {
            get { return _indate; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[投运日期]长度不能大于50!");
                if (_indate as object == null || !_indate.Equals(value))
                {
                    _indate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Reamrk
        /// 属性描述：
        /// 字段信息：[Reamrk],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Remark
        {
            get { return _remark; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
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
