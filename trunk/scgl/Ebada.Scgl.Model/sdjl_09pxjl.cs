/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-4-18 15:15:41
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[sdjl_09pxjl]业务实体类
    ///对应表名:sdjl_09pxjl
    /// </summary>
    [Serializable]
    public class sdjl_09pxjl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private DateTime _rq=new DateTime(1900,1,1); 
        private string _hydd=String.Empty; 
        private string _xxss=String.Empty; 
        private string _cjrs=String.Empty; 
        private string _zcr=String.Empty; 
        private string _zjr=String.Empty; 
        private string _tm=String.Empty; 
        private string _nr=String.Empty; 
        private string _py=String.Empty; 
        private string _qz=String.Empty; 
        private DateTime _qzrq=new DateTime(1900,1,1); 
        private string _gznrid=String.Empty; 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1); 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty; 
        private string _c4=String.Empty; 
        private string _c5=String.Empty;   
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
        /// 属性名称：rq
        /// 属性描述：日期
        /// 字段信息：[rq],datetime
        /// </summary>
        [DisplayNameAttribute("日期")]
        public DateTime rq
        {
            get { return _rq; }
            set
            {			
                if (_rq as object == null || !_rq.Equals(value))
                {
                    _rq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：hydd
        /// 属性描述：会议地点
        /// 字段信息：[hydd],nvarchar
        /// </summary>
        [DisplayNameAttribute("会议地点")]
        public string hydd
        {
            get { return _hydd; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[会议地点]长度不能大于50!");
                if (_hydd as object == null || !_hydd.Equals(value))
                {
                    _hydd = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xxss
        /// 属性描述：学习时数
        /// 字段信息：[xxss],nvarchar
        /// </summary>
        [DisplayNameAttribute("学习时数")]
        public string xxss
        {
            get { return _xxss; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[学习时数]长度不能大于50!");
                if (_xxss as object == null || !_xxss.Equals(value))
                {
                    _xxss = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cjrs
        /// 属性描述：参加人数
        /// 字段信息：[cjrs],nvarchar
        /// </summary>
        [DisplayNameAttribute("参加人数")]
        public string cjrs
        {
            get { return _cjrs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[参加人数]长度不能大于50!");
                if (_cjrs as object == null || !_cjrs.Equals(value))
                {
                    _cjrs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zcr
        /// 属性描述：主持人
        /// 字段信息：[zcr],nvarchar
        /// </summary>
        [DisplayNameAttribute("主持人")]
        public string zcr
        {
            get { return _zcr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[主持人]长度不能大于50!");
                if (_zcr as object == null || !_zcr.Equals(value))
                {
                    _zcr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zjr
        /// 属性描述：主讲人
        /// 字段信息：[zjr],nvarchar
        /// </summary>
        [DisplayNameAttribute("主讲人")]
        public string zjr
        {
            get { return _zjr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[主讲人]长度不能大于50!");
                if (_zjr as object == null || !_zjr.Equals(value))
                {
                    _zjr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tm
        /// 属性描述：题目
        /// 字段信息：[tm],nvarchar
        /// </summary>
        [DisplayNameAttribute("题目")]
        public string tm
        {
            get { return _tm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[题目]长度不能大于250!");
                if (_tm as object == null || !_tm.Equals(value))
                {
                    _tm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：nr
        /// 属性描述：内容
        /// 字段信息：[nr],nvarchar
        /// </summary>
        [DisplayNameAttribute("内容")]
        public string nr
        {
            get { return _nr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 4000)
                throw new Exception("[内容]长度不能大于4000!");
                if (_nr as object == null || !_nr.Equals(value))
                {
                    _nr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：py
        /// 属性描述：评语
        /// 字段信息：[py],nvarchar
        /// </summary>
        [DisplayNameAttribute("评语")]
        public string py
        {
            get { return _py; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[评语]长度不能大于200!");
                if (_py as object == null || !_py.Equals(value))
                {
                    _py = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qz
        /// 属性描述：签字
        /// 字段信息：[qz],nvarchar
        /// </summary>
        [DisplayNameAttribute("签字")]
        public string qz
        {
            get { return _qz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[签字]长度不能大于50!");
                if (_qz as object == null || !_qz.Equals(value))
                {
                    _qz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qzrq
        /// 属性描述：签字日期
        /// 字段信息：[qzrq],datetime
        /// </summary>
        [DisplayNameAttribute("签字日期")]
        public DateTime qzrq
        {
            get { return _qzrq; }
            set
            {			
                if (_qzrq as object == null || !_qzrq.Equals(value))
                {
                    _qzrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gznrID
        /// 属性描述：gznrID
        /// 字段信息：[gznrID],nvarchar
        /// </summary>
        [DisplayNameAttribute("gznrID")]
        public string gznrID
        {
            get { return _gznrid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[gznrID]长度不能大于50!");
                if (_gznrid as object == null || !_gznrid.Equals(value))
                {
                    _gznrid = value;
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
        /// 属性名称：c1
        /// 属性描述：备用字段1
        /// 字段信息：[c1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段1")]
        public string c1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段1]长度不能大于500!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c2
        /// 属性描述：备用字段2
        /// 字段信息：[c2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段2")]
        public string c2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段2]长度不能大于500!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c3
        /// 属性描述：备用字段3
        /// 字段信息：[c3],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段3")]
        public string c3
        {
            get { return _c3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段3]长度不能大于500!");
                if (_c3 as object == null || !_c3.Equals(value))
                {
                    _c3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c4
        /// 属性描述：备用字段4
        /// 字段信息：[c4],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段4")]
        public string c4
        {
            get { return _c4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段4]长度不能大于500!");
                if (_c4 as object == null || !_c4.Equals(value))
                {
                    _c4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c5
        /// 属性描述：备用字段5
        /// 字段信息：[c5],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段5")]
        public string c5
        {
            get { return _c5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段5]长度不能大于500!");
                if (_c5 as object == null || !_c5.Equals(value))
                {
                    _c5 = value;
                }
            }			 
        }
  
        #endregion 
  
        #region 方法
        public static string Newid(){
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        public string CreateID(){
            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        #endregion		
    }	
}
