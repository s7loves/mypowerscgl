/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-12-21 21:39:27
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_bdsdldrqtz]业务实体类
    ///对应表名:PJ_bdsdldrqtz
    /// </summary>
    [Serializable]
    public class PJ_bdsdldrqtz
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgname=String.Empty; 
        private string _zzdz=String.Empty; 
        private string _drqmodle=String.Empty; 
        private string _edvol=String.Empty; 
        private string _capcity=String.Empty; 
        private string _sbnum=String.Empty; 
        private string _sbfactory=String.Empty; 
        private string _tqfs=String.Empty; 
        private DateTime _indate=new DateTime(1900,1,1); 
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
        /// 属性名称：OrgName
        /// 属性描述：变电所
        /// 字段信息：[OrgName],nvarchar
        /// </summary>
        [DisplayNameAttribute("变电所")]
        public string OrgName
        {
            get { return _orgname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[变电所]长度不能大于50!");
                if (_orgname as object == null || !_orgname.Equals(value))
                {
                    _orgname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zzdz
        /// 属性描述：装置地点
        /// 字段信息：[zzdz],nvarchar
        /// </summary>
        [DisplayNameAttribute("装置地点")]
        public string zzdz
        {
            get { return _zzdz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[装置地点]长度不能大于50!");
                if (_zzdz as object == null || !_zzdz.Equals(value))
                {
                    _zzdz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：drqModle
        /// 属性描述：电容器型号
        /// 字段信息：[drqModle],nvarchar
        /// </summary>
        [DisplayNameAttribute("电容器型号")]
        public string drqModle
        {
            get { return _drqmodle; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电容器型号]长度不能大于50!");
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
        /// 属性描述：制造厂
        /// 字段信息：[sbFactory],nvarchar
        /// </summary>
        [DisplayNameAttribute("制造厂")]
        public string sbFactory
        {
            get { return _sbfactory; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[制造厂]长度不能大于50!");
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
        /// 字段信息：[inDate],datetime
        /// </summary>
        [DisplayNameAttribute("投运日期")]
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
