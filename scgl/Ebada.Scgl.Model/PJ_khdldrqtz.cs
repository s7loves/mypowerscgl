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
    ///[PJ_khdldrqtz]业务实体类
    ///对应表名:PJ_khdldrqtz
    /// </summary>
    [Serializable]
    public class PJ_khdldrqtz
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _zhm=String.Empty; 
        private string _hm=String.Empty; 
        private string _pdrl=String.Empty; 
        private string _drqmodle=String.Empty; 
        private string _capcity=String.Empty; 
        private string _sbnum=String.Empty; 
        private string _sbsumfactory=String.Empty; 
        private string _tqfs=String.Empty; 
        private string _khvol=String.Empty; 
        private string _tystatus=String.Empty; 
        private string _reamrk=String.Empty; 
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
        /// 属性名称：zhm
        /// 属性描述：总户号
        /// 字段信息：[zhm],nvarchar
        /// </summary>
        [DisplayNameAttribute("总户号")]
        public string zhm
        {
            get { return _zhm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 100)
                throw new Exception("[总户号]长度不能大于100!");
                if (_zhm as object == null || !_zhm.Equals(value))
                {
                    _zhm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：hm
        /// 属性描述：户号
        /// 字段信息：[hm],nvarchar
        /// </summary>
        [DisplayNameAttribute("户号")]
        public string hm
        {
            get { return _hm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[户号]长度不能大于50!");
                if (_hm as object == null || !_hm.Equals(value))
                {
                    _hm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：pdrl
        /// 属性描述：配变容量（kVA）
        /// 字段信息：[pdrl],nvarchar
        /// </summary>
        [DisplayNameAttribute("配变容量（kVA）")]
        public string pdrl
        {
            get { return _pdrl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[配变容量（kVA）]长度不能大于50!");
                if (_pdrl as object == null || !_pdrl.Equals(value))
                {
                    _pdrl = value;
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
        /// 属性名称：sbsumFactory
        /// 属性描述：总容量
        /// 字段信息：[sbsumFactory],nvarchar
        /// </summary>
        [DisplayNameAttribute("总容量")]
        public string sbsumFactory
        {
            get { return _sbsumfactory; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[总容量]长度不能大于50!");
                if (_sbsumfactory as object == null || !_sbsumfactory.Equals(value))
                {
                    _sbsumfactory = value;
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
        /// 属性名称：khVol
        /// 属性描述：客户电压等级
        /// 字段信息：[khVol],nvarchar
        /// </summary>
        [DisplayNameAttribute("客户电压等级")]
        public string khVol
        {
            get { return _khvol; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[客户电压等级]长度不能大于50!");
                if (_khvol as object == null || !_khvol.Equals(value))
                {
                    _khvol = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tyStatus
        /// 属性描述：
        /// 字段信息：[tyStatus],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string tyStatus
        {
            get { return _tystatus; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_tystatus as object == null || !_tystatus.Equals(value))
                {
                    _tystatus = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Reamrk
        /// 属性描述：
        /// 字段信息：[Reamrk],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Reamrk
        {
            get { return _reamrk; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_reamrk as object == null || !_reamrk.Equals(value))
                {
                    _reamrk = value;
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
