/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada物流企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012/3/23 16:06:01
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_wgclrkysd]业务实体类
    ///对应表名:PJ_wgclrkysd
    /// </summary>
    [Serializable]
    public class PJ_wgclrkysd
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _ssgc=String.Empty; 
        private string _ssxm=String.Empty; 
        private string _xmdw=String.Empty; 
        private string _ghdw=String.Empty; 
        private string _xmtz=String.Empty; 
        private string _dhht=String.Empty; 
        private string _fpbh=String.Empty; 
        private string _wpmc=String.Empty; 
        private string _wpgg=String.Empty; 
        private string _wpdw=String.Empty; 
        private string _wpsl=String.Empty; 
        private string _wpdj=String.Empty; 
        private string _htjg=String.Empty; 
        private string _yfk=String.Empty; 
        private string _scbh=String.Empty; 
        private string _jcjg=String.Empty; 
        private string _czwt=String.Empty; 
        private DateTime _indate=new DateTime(1900,1,1); 
        private string _cljg=String.Empty; 
        private string _ysr=String.Empty; 
        private string _jsfzr=String.Empty; 
        private string _zgjz=String.Empty; 
        private string _remark=String.Empty;   
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
        /// 属性描述：供电所编号
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("供电所编号")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[供电所编号]长度不能大于50!");
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
        /// 属性名称：ssgc
        /// 属性描述：工程项目
        /// 字段信息：[ssgc],nvarchar
        /// </summary>
        [DisplayNameAttribute("工程项目")]
        public string ssgc
        {
            get { return _ssgc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[工程项目]长度不能大于50!");
                if (_ssgc as object == null || !_ssgc.Equals(value))
                {
                    _ssgc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ssxm
        /// 属性描述：分工程项目
        /// 字段信息：[ssxm],nvarchar
        /// </summary>
        [DisplayNameAttribute("分工程项目")]
        public string ssxm
        {
            get { return _ssxm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[分工程项目]长度不能大于50!");
                if (_ssxm as object == null || !_ssxm.Equals(value))
                {
                    _ssxm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xmdw
        /// 属性描述：项目单位
        /// 字段信息：[xmdw],nvarchar
        /// </summary>
        [DisplayNameAttribute("项目单位")]
        public string xmdw
        {
            get { return _xmdw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[项目单位]长度不能大于50!");
                if (_xmdw as object == null || !_xmdw.Equals(value))
                {
                    _xmdw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ghdw
        /// 属性描述：供货单位
        /// 字段信息：[ghdw],nvarchar
        /// </summary>
        [DisplayNameAttribute("供货单位")]
        public string ghdw
        {
            get { return _ghdw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[供货单位]长度不能大于50!");
                if (_ghdw as object == null || !_ghdw.Equals(value))
                {
                    _ghdw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xmtz
        /// 属性描述：项目投资（万元）
        /// 字段信息：[xmtz],nvarchar
        /// </summary>
        [DisplayNameAttribute("项目投资（万元）")]
        public string xmtz
        {
            get { return _xmtz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[项目投资（万元）]长度不能大于50!");
                if (_xmtz as object == null || !_xmtz.Equals(value))
                {
                    _xmtz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dhht
        /// 属性描述：订货合同
        /// 字段信息：[dhht],nvarchar
        /// </summary>
        [DisplayNameAttribute("订货合同")]
        public string dhht
        {
            get { return _dhht; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[订货合同]长度不能大于50!");
                if (_dhht as object == null || !_dhht.Equals(value))
                {
                    _dhht = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fpbh
        /// 属性描述：发票编号
        /// 字段信息：[fpbh],nvarchar
        /// </summary>
        [DisplayNameAttribute("发票编号")]
        public string fpbh
        {
            get { return _fpbh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 100)
                throw new Exception("[发票编号]长度不能大于100!");
                if (_fpbh as object == null || !_fpbh.Equals(value))
                {
                    _fpbh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wpmc
        /// 属性描述：产品名称
        /// 字段信息：[wpmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("产品名称")]
        public string wpmc
        {
            get { return _wpmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[产品名称]长度不能大于50!");
                if (_wpmc as object == null || !_wpmc.Equals(value))
                {
                    _wpmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wpgg
        /// 属性描述：规格型号
        /// 字段信息：[wpgg],nvarchar
        /// </summary>
        [DisplayNameAttribute("规格型号")]
        public string wpgg
        {
            get { return _wpgg; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[规格型号]长度不能大于50!");
                if (_wpgg as object == null || !_wpgg.Equals(value))
                {
                    _wpgg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wpdw
        /// 属性描述：单位
        /// 字段信息：[wpdw],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位")]
        public string wpdw
        {
            get { return _wpdw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单位]长度不能大于50!");
                if (_wpdw as object == null || !_wpdw.Equals(value))
                {
                    _wpdw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wpsl
        /// 属性描述：交货数量
        /// 字段信息：[wpsl],nvarchar
        /// </summary>
        [DisplayNameAttribute("交货数量")]
        public string wpsl
        {
            get { return _wpsl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[交货数量]长度不能大于50!");
                if (_wpsl as object == null || !_wpsl.Equals(value))
                {
                    _wpsl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wpdj
        /// 属性描述：单价（元）
        /// 字段信息：[wpdj],nvarchar
        /// </summary>
        [DisplayNameAttribute("单价（元）")]
        public string wpdj
        {
            get { return _wpdj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单价（元）]长度不能大于50!");
                if (_wpdj as object == null || !_wpdj.Equals(value))
                {
                    _wpdj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：htjg
        /// 属性描述：合同价格（元）
        /// 字段信息：[htjg],nvarchar
        /// </summary>
        [DisplayNameAttribute("合同价格（元）")]
        public string htjg
        {
            get { return _htjg; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[合同价格（元）]长度不能大于50!");
                if (_htjg as object == null || !_htjg.Equals(value))
                {
                    _htjg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：yfk
        /// 属性描述：应付款90%金
        /// 字段信息：[yfk],nvarchar
        /// </summary>
        [DisplayNameAttribute("应付款90%金")]
        public string yfk
        {
            get { return _yfk; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[应付款90%金]长度不能大于50!");
                if (_yfk as object == null || !_yfk.Equals(value))
                {
                    _yfk = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：scbh
        /// 属性描述：交货数量的生产编号
        /// 字段信息：[scbh],nvarchar
        /// </summary>
        [DisplayNameAttribute("交货数量的生产编号")]
        public string scbh
        {
            get { return _scbh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[交货数量的生产编号]长度不能大于50!");
                if (_scbh as object == null || !_scbh.Equals(value))
                {
                    _scbh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jcjg
        /// 属性描述：检查结果
        /// 字段信息：[jcjg],nvarchar
        /// </summary>
        [DisplayNameAttribute("检查结果")]
        public string jcjg
        {
            get { return _jcjg; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 800)
                throw new Exception("[检查结果]长度不能大于800!");
                if (_jcjg as object == null || !_jcjg.Equals(value))
                {
                    _jcjg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：czwt
        /// 属性描述：存在问题
        /// 字段信息：[czwt],nvarchar
        /// </summary>
        [DisplayNameAttribute("存在问题")]
        public string czwt
        {
            get { return _czwt; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 800)
                throw new Exception("[存在问题]长度不能大于800!");
                if (_czwt as object == null || !_czwt.Equals(value))
                {
                    _czwt = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：indate
        /// 属性描述：验收时间
        /// 字段信息：[indate],datetime
        /// </summary>
        [DisplayNameAttribute("验收时间")]
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
        /// 属性名称：cljg
        /// 属性描述：处理结果
        /// 字段信息：[cljg],nvarchar
        /// </summary>
        [DisplayNameAttribute("处理结果")]
        public string cljg
        {
            get { return _cljg; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 800)
                throw new Exception("[处理结果]长度不能大于800!");
                if (_cljg as object == null || !_cljg.Equals(value))
                {
                    _cljg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ysr
        /// 属性描述：验收人
        /// 字段信息：[ysr],nvarchar
        /// </summary>
        [DisplayNameAttribute("验收人")]
        public string ysr
        {
            get { return _ysr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[验收人]长度不能大于50!");
                if (_ysr as object == null || !_ysr.Equals(value))
                {
                    _ysr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jsfzr
        /// 属性描述：技术负责人
        /// 字段信息：[jsfzr],nvarchar
        /// </summary>
        [DisplayNameAttribute("技术负责人")]
        public string jsfzr
        {
            get { return _jsfzr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[技术负责人]长度不能大于50!");
                if (_jsfzr as object == null || !_jsfzr.Equals(value))
                {
                    _jsfzr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zgjz
        /// 属性描述：主管局长
        /// 字段信息：[zgjz],nvarchar
        /// </summary>
        [DisplayNameAttribute("主管局长")]
        public string zgjz
        {
            get { return _zgjz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[主管局长]长度不能大于50!");
                if (_zgjz as object == null || !_zgjz.Equals(value))
                {
                    _zgjz = value;
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
                if( value.ToString().Length > 800)
                throw new Exception("[备注]长度不能大于800!");
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
