/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-3-7 10:08:58
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_anqgjcrkd]业务实体类
    ///对应表名:PJ_anqgjcrkd
    /// </summary>
    [Serializable]
    public class PJ_anqgjcrkd
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _num=String.Empty; 
        private string _orgname=String.Empty; 
        private string _orgcode=String.Empty; 
        private string _wpmc=String.Empty; 
        private string _wpgg=String.Empty; 
        private string _wpdw=String.Empty; 
        private string _wpsl=String.Empty; 
        private string _wpdj=String.Empty; 
        private string _wpcj=String.Empty; 
        private DateTime _ckdate=new DateTime(1900,1,1); 
        private string _cksl=String.Empty; 
        private string _kcsl=String.Empty; 
        private string _lqdw=String.Empty; 
        private string _zkcsl=String.Empty; 
        private string _ssgc=String.Empty; 
        private string _ssxm=String.Empty; 
        private DateTime _indate=new DateTime(1900,1,1); 
        private string _syzq=String.Empty; 
        private DateTime _scsydate=new DateTime(1900,1,1); 
        private string _synx=String.Empty; 
        private string _remark=String.Empty; 
        private string _type=String.Empty; 
        private DateTime _lasttime=new DateTime(1900,1,1); 
        private string _lyparent=String.Empty;   
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
        /// 属性名称：num
        /// 属性描述：出入库单号
        /// 字段信息：[num],nvarchar
        /// </summary>
        [DisplayNameAttribute("出入库单号")]
        public string num
        {
            get { return _num; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[出入库单号]长度不能大于50!");
                if (_num as object == null || !_num.Equals(value))
                {
                    _num = value;
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
                if( value.ToString().Length > 50)
                throw new Exception("[物品名称]长度不能大于50!");
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
        /// 属性名称：wpdj
        /// 属性描述：单价(单位:元)
        /// 字段信息：[wpdj],nvarchar
        /// </summary>
        [DisplayNameAttribute("单价(单位:元)")]
        public string wpdj
        {
            get { return _wpdj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单价(单位:元)]长度不能大于50!");
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
        /// 属性描述：该物品库存数量
        /// 字段信息：[kcsl],nvarchar
        /// </summary>
        [DisplayNameAttribute("该物品库存数量")]
        public string kcsl
        {
            get { return _kcsl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[该物品库存数量]长度不能大于50!");
                if (_kcsl as object == null || !_kcsl.Equals(value))
                {
                    _kcsl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lqdw
        /// 属性描述：领取人
        /// 字段信息：[lqdw],nvarchar
        /// </summary>
        [DisplayNameAttribute("领取人")]
        public string lqdw
        {
            get { return _lqdw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[领取人]长度不能大于50!");
                if (_lqdw as object == null || !_lqdw.Equals(value))
                {
                    _lqdw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zkcsl
        /// 属性描述：库存数量
        /// 字段信息：[zkcsl],nvarchar
        /// </summary>
        [DisplayNameAttribute("库存数量")]
        public string zkcsl
        {
            get { return _zkcsl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[库存数量]长度不能大于50!");
                if (_zkcsl as object == null || !_zkcsl.Equals(value))
                {
                    _zkcsl = value;
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
        /// 属性名称：ssxm
        /// 属性描述：所属分工程
        /// 字段信息：[ssxm],nvarchar
        /// </summary>
        [DisplayNameAttribute("所属分工程")]
        public string ssxm
        {
            get { return _ssxm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[所属分工程]长度不能大于50!");
                if (_ssxm as object == null || !_ssxm.Equals(value))
                {
                    _ssxm = value;
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
        /// 属性名称：syzq
        /// 属性描述：试验周期（年）
        /// 字段信息：[syzq],nvarchar
        /// </summary>
        [DisplayNameAttribute("试验周期（年）")]
        public string syzq
        {
            get { return _syzq; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[试验周期（年）]长度不能大于50!");
                if (_syzq as object == null || !_syzq.Equals(value))
                {
                    _syzq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：scsydate
        /// 属性描述：上次试验时间
        /// 字段信息：[scsydate],datetime
        /// </summary>
        [DisplayNameAttribute("上次试验时间")]
        public DateTime scsydate
        {
            get { return _scsydate; }
            set
            {			
                if (_scsydate as object == null || !_scsydate.Equals(value))
                {
                    _scsydate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：synx
        /// 属性描述：使用年限
        /// 字段信息：[synx],nvarchar
        /// </summary>
        [DisplayNameAttribute("使用年限")]
        public string synx
        {
            get { return _synx; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[使用年限]长度不能大于50!");
                if (_synx as object == null || !_synx.Equals(value))
                {
                    _synx = value;
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
        /// 属性名称：type
        /// 属性描述：类型
        /// 字段信息：[type],nvarchar
        /// </summary>
        [DisplayNameAttribute("类型")]
        public string type
        {
            get { return _type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[类型]长度不能大于50!");
                if (_type as object == null || !_type.Equals(value))
                {
                    _type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lasttime
        /// 属性描述：最后修改时间
        /// 字段信息：[lasttime],datetime
        /// </summary>
        [DisplayNameAttribute("最后修改时间")]
        public DateTime lasttime
        {
            get { return _lasttime; }
            set
            {			
                if (_lasttime as object == null || !_lasttime.Equals(value))
                {
                    _lasttime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lyparent
        /// 属性描述：材料来源ID
        /// 字段信息：[lyparent],nvarchar
        /// </summary>
        [DisplayNameAttribute("材料来源ID")]
        public string lyparent
        {
            get { return _lyparent; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[材料来源ID]长度不能大于50!");
                if (_lyparent as object == null || !_lyparent.Equals(value))
                {
                    _lyparent = value;
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
