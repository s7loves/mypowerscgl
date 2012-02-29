/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-2-27 19:34:11
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_sctz]业务实体类
    ///对应表名:PJ_sctz
    /// </summary>
    [Serializable]
    public class PJ_sctz
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgname=String.Empty; 
        private string _orgcode=String.Empty; 
        private string _wpmc=String.Empty; 
        private string _wpgg=String.Empty; 
        private string _wpdw=String.Empty; 
        private string _wpsl=String.Empty; 
        private DateTime _indate=new DateTime(1900,1,1); 
        private string _wpdj=String.Empty; 
        private string _wpcj=String.Empty; 
        private string _ssgc=String.Empty; 
        private DateTime _ckdate=new DateTime(1900,1,1); 
        private string _yt=String.Empty; 
        private string _cksl=String.Empty; 
        private string _kcsl=String.Empty; 
        private string _lqdw=String.Empty; 
        private string _remark=String.Empty; 
        private string _s1=String.Empty; 
        private string _s2=String.Empty; 
        private string _s3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：唯一ID
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("唯一ID")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[唯一ID]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
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
        /// 属性名称：wpmc
        /// 属性描述：物品名称
        /// 字段信息：[wpmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("物品名称")]
        public string wpmc
        {
            get { return _wpmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[物品名称]长度不能大于500!");
                if (_wpmc as object == null || !_wpmc.Equals(value))
                {
                    _wpmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wpgg
        /// 属性描述：物品规格
        /// 字段信息：[wpgg],nvarchar
        /// </summary>
        [DisplayNameAttribute("物品规格")]
        public string wpgg
        {
            get { return _wpgg; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[物品规格]长度不能大于50!");
                if (_wpgg as object == null || !_wpgg.Equals(value))
                {
                    _wpgg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wpdw
        /// 属性描述：物品单位
        /// 字段信息：[wpdw],nvarchar
        /// </summary>
        [DisplayNameAttribute("物品单位")]
        public string wpdw
        {
            get { return _wpdw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[物品单位]长度不能大于50!");
                if (_wpdw as object == null || !_wpdw.Equals(value))
                {
                    _wpdw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wpsl
        /// 属性描述：数量
        /// 字段信息：[wpsl],nvarchar
        /// </summary>
        [DisplayNameAttribute("数量")]
        public string wpsl
        {
            get { return _wpsl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[数量]长度不能大于50!");
                if (_wpsl as object == null || !_wpsl.Equals(value))
                {
                    _wpsl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：indate
        /// 属性描述：入库时间
        /// 字段信息：[indate],datetime
        /// </summary>
        [DisplayNameAttribute("入库时间")]
        public DateTime indate
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
        /// 属性名称：wpdj
        /// 属性描述：单价
        /// 字段信息：[wpdj],nvarchar
        /// </summary>
        [DisplayNameAttribute("单价")]
        public string wpdj
        {
            get { return _wpdj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单价]长度不能大于50!");
                if (_wpdj as object == null || !_wpdj.Equals(value))
                {
                    _wpdj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wpcj
        /// 属性描述：厂家
        /// 字段信息：[wpcj],nvarchar
        /// </summary>
        [DisplayNameAttribute("厂家")]
        public string wpcj
        {
            get { return _wpcj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[厂家]长度不能大于50!");
                if (_wpcj as object == null || !_wpcj.Equals(value))
                {
                    _wpcj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ssgc
        /// 属性描述：所属工程
        /// 字段信息：[ssgc],nvarchar
        /// </summary>
        [DisplayNameAttribute("所属工程")]
        public string ssgc
        {
            get { return _ssgc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[所属工程]长度不能大于50!");
                if (_ssgc as object == null || !_ssgc.Equals(value))
                {
                    _ssgc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ckdate
        /// 属性描述：出库时间
        /// 字段信息：[ckdate],datetime
        /// </summary>
        [DisplayNameAttribute("出库时间")]
        public DateTime ckdate
        {
            get { return _ckdate; }
            set
            {			
                if (_ckdate as object == null || !_ckdate.Equals(value))
                {
                    _ckdate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：yt
        /// 属性描述：用途
        /// 字段信息：[yt],nvarchar
        /// </summary>
        [DisplayNameAttribute("用途")]
        public string yt
        {
            get { return _yt; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[用途]长度不能大于500!");
                if (_yt as object == null || !_yt.Equals(value))
                {
                    _yt = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cksl
        /// 属性描述：出库数量
        /// 字段信息：[cksl],nvarchar
        /// </summary>
        [DisplayNameAttribute("出库数量")]
        public string cksl
        {
            get { return _cksl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[出库数量]长度不能大于50!");
                if (_cksl as object == null || !_cksl.Equals(value))
                {
                    _cksl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kcsl
        /// 属性描述：库存数量
        /// 字段信息：[kcsl],nvarchar
        /// </summary>
        [DisplayNameAttribute("库存数量")]
        public string kcsl
        {
            get { return _kcsl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[库存数量]长度不能大于50!");
                if (_kcsl as object == null || !_kcsl.Equals(value))
                {
                    _kcsl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lqdw
        /// 属性描述：领取单位
        /// 字段信息：[lqdw],nvarchar
        /// </summary>
        [DisplayNameAttribute("领取单位")]
        public string lqdw
        {
            get { return _lqdw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[领取单位]长度不能大于50!");
                if (_lqdw as object == null || !_lqdw.Equals(value))
                {
                    _lqdw = value;
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
        /// 属性描述：备用
        /// 字段信息：[S1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用")]
        public string S1
        {
            get { return _s1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用]长度不能大于50!");
                if (_s1 as object == null || !_s1.Equals(value))
                {
                    _s1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S2
        /// 属性描述：备用
        /// 字段信息：[S2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用")]
        public string S2
        {
            get { return _s2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用]长度不能大于50!");
                if (_s2 as object == null || !_s2.Equals(value))
                {
                    _s2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：S3
        /// 属性描述：备用
        /// 字段信息：[S3],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用")]
        public string S3
        {
            get { return _s3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用]长度不能大于50!");
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
