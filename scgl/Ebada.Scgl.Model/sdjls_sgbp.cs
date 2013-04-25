/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-4-25 9:39:19
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[sdjls_sgbp]业务实体类
    ///对应表名:sdjls_sgbp
    /// </summary>
    [Serializable]
    public class sdjls_sgbp
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _bpbjmc=String.Empty; 
        private string _gexh=String.Empty; 
        private string _dw=String.Empty; 
        private string _lrsl=String.Empty; 
        private DateTime _lrsj=new DateTime(1900,1,1); 
        private string _lcsl=String.Empty; 
        private string _lcsj=String.Empty; 
        private string _lyr=String.Empty; 
        private string _kcsl=String.Empty; 
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
        /// 属性描述：单位代码
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位代码")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单位代码]长度不能大于50!");
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
        /// 属性名称：bpbjmc
        /// 属性描述：备品备件名称
        /// 字段信息：[bpbjmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("备品备件名称")]
        public string bpbjmc
        {
            get { return _bpbjmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备品备件名称]长度不能大于50!");
                if (_bpbjmc as object == null || !_bpbjmc.Equals(value))
                {
                    _bpbjmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gexh
        /// 属性描述：规格型号
        /// 字段信息：[gexh],nvarchar
        /// </summary>
        [DisplayNameAttribute("规格型号")]
        public string gexh
        {
            get { return _gexh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[规格型号]长度不能大于50!");
                if (_gexh as object == null || !_gexh.Equals(value))
                {
                    _gexh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dw
        /// 属性描述：单位
        /// 字段信息：[dw],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位")]
        public string dw
        {
            get { return _dw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单位]长度不能大于50!");
                if (_dw as object == null || !_dw.Equals(value))
                {
                    _dw = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lrsl
        /// 属性描述：领入数量
        /// 字段信息：[lrsl],nvarchar
        /// </summary>
        [DisplayNameAttribute("领入数量")]
        public string lrsl
        {
            get { return _lrsl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[领入数量]长度不能大于50!");
                if (_lrsl as object == null || !_lrsl.Equals(value))
                {
                    _lrsl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lrsj
        /// 属性描述：领入时间
        /// 字段信息：[lrsj],datetime
        /// </summary>
        [DisplayNameAttribute("领入时间")]
        public DateTime lrsj
        {
            get { return _lrsj; }
            set
            {			
                if (_lrsj as object == null || !_lrsj.Equals(value))
                {
                    _lrsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lcsl
        /// 属性描述：领出数量
        /// 字段信息：[lcsl],nvarchar
        /// </summary>
        [DisplayNameAttribute("领出数量")]
        public string lcsl
        {
            get { return _lcsl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[领出数量]长度不能大于50!");
                if (_lcsl as object == null || !_lcsl.Equals(value))
                {
                    _lcsl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lcsj
        /// 属性描述：领出时间
        /// 字段信息：[lcsj],nvarchar
        /// </summary>
        [DisplayNameAttribute("领出时间")]
        public string lcsj
        {
            get { return _lcsj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[领出时间]长度不能大于50!");
                if (_lcsj as object == null || !_lcsj.Equals(value))
                {
                    _lcsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lyr
        /// 属性描述：领用人
        /// 字段信息：[lyr],nvarchar
        /// </summary>
        [DisplayNameAttribute("领用人")]
        public string lyr
        {
            get { return _lyr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[领用人]长度不能大于50!");
                if (_lyr as object == null || !_lyr.Equals(value))
                {
                    _lyr = value;
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
