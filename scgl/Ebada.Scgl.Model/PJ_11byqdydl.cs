/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-26 20:53:59
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_11byqdydl]业务实体类
    ///对应表名:PJ_11byqdydl
    /// </summary>
    [Serializable]
    public class PJ_11byqdydl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _byqid=String.Empty; 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private DateTime _clrq=new DateTime(1900,1,1); 
        private string _fjtwz=String.Empty; 
        private decimal _ao=0; 
        private decimal _bo=0; 
        private decimal _co=0; 
        private decimal _a=0; 
        private decimal _b=0; 
        private decimal _c=0; 
        private decimal _ao2=0; 
        private decimal _bo2=0; 
        private decimal _co2=0; 
        private string _gznrid=String.Empty; 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1);   
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
        /// 属性名称：byqID
        /// 属性描述：变压器ID
        /// 字段信息：[byqID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("变压器ID")]
        public string byqID
        {
            get { return _byqid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[变压器ID]长度不能大于50!");
                if (_byqid as object == null || !_byqid.Equals(value))
                {
                    _byqid = value;
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
        /// 属性名称：clrq
        /// 属性描述：测量日期
        /// 字段信息：[clrq],datetime
        /// </summary>
        [DisplayNameAttribute("测量日期")]
        public DateTime clrq
        {
            get { return _clrq; }
            set
            {			
                if (_clrq as object == null || !_clrq.Equals(value))
                {
                    _clrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fjtwz
        /// 属性描述：分接头位置
        /// 字段信息：[fjtwz],nvarchar
        /// </summary>
        [DisplayNameAttribute("分接头位置")]
        public string fjtwz
        {
            get { return _fjtwz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[分接头位置]长度不能大于50!");
                if (_fjtwz as object == null || !_fjtwz.Equals(value))
                {
                    _fjtwz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ao
        /// 属性描述：ao
        /// 字段信息：[ao],decimal
        /// </summary>
        [DisplayNameAttribute("ao")]
        public decimal ao
        {
            get { return _ao; }
            set
            {			
                if (_ao as object == null || !_ao.Equals(value))
                {
                    _ao = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bo
        /// 属性描述：bo
        /// 字段信息：[bo],decimal
        /// </summary>
        [DisplayNameAttribute("bo")]
        public decimal bo
        {
            get { return _bo; }
            set
            {			
                if (_bo as object == null || !_bo.Equals(value))
                {
                    _bo = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：co
        /// 属性描述：co
        /// 字段信息：[co],decimal
        /// </summary>
        [DisplayNameAttribute("co")]
        public decimal co
        {
            get { return _co; }
            set
            {			
                if (_co as object == null || !_co.Equals(value))
                {
                    _co = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：a
        /// 属性描述：a
        /// 字段信息：[a],decimal
        /// </summary>
        [DisplayNameAttribute("a")]
        public decimal a
        {
            get { return _a; }
            set
            {			
                if (_a as object == null || !_a.Equals(value))
                {
                    _a = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：b
        /// 属性描述：b
        /// 字段信息：[b],decimal
        /// </summary>
        [DisplayNameAttribute("b")]
        public decimal b
        {
            get { return _b; }
            set
            {			
                if (_b as object == null || !_b.Equals(value))
                {
                    _b = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c
        /// 属性描述：c
        /// 字段信息：[c],decimal
        /// </summary>
        [DisplayNameAttribute("c")]
        public decimal c
        {
            get { return _c; }
            set
            {			
                if (_c as object == null || !_c.Equals(value))
                {
                    _c = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ao2
        /// 属性描述：ao2
        /// 字段信息：[ao2],decimal
        /// </summary>
        [DisplayNameAttribute("ao2")]
        public decimal ao2
        {
            get { return _ao2; }
            set
            {			
                if (_ao2 as object == null || !_ao2.Equals(value))
                {
                    _ao2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bo2
        /// 属性描述：bo2
        /// 字段信息：[bo2],decimal
        /// </summary>
        [DisplayNameAttribute("bo2")]
        public decimal bo2
        {
            get { return _bo2; }
            set
            {			
                if (_bo2 as object == null || !_bo2.Equals(value))
                {
                    _bo2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：co2
        /// 属性描述：co2
        /// 字段信息：[co2],decimal
        /// </summary>
        [DisplayNameAttribute("co2")]
        public decimal co2
        {
            get { return _co2; }
            set
            {			
                if (_co2 as object == null || !_co2.Equals(value))
                {
                    _co2 = value;
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
