/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-26 20:54:00
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_aqgj]业务实体类
    ///对应表名:PS_aqgj
    /// </summary>
    [Serializable]
    public class PS_aqgj
    {
        
        #region Private 成员
        private string _sbid=Newid(); 
        private string _orgid=String.Empty; 
        private string _sbcode=String.Empty; 
        private string _sbname=String.Empty;
        private string _syzq = String.Empty; 
        private string _syxm=String.Empty; 
        private DateTime _syrq=new DateTime(1900,1,1); 
        private DateTime _syrq2=new DateTime(1900,1,1); 
        private string _sbtype=String.Empty; 
        private string _sbmodle=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：sbID
        /// 属性描述：设备ID
        /// 字段信息：[sbID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("设备ID")]
        public string sbID
        {
            get { return _sbid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备ID]长度不能大于50!");
                if (_sbid as object == null || !_sbid.Equals(value))
                {
                    _sbid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgID
        /// 属性描述：部门ID
        /// 字段信息：[OrgID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("部门ID")]
        public string OrgID
        {
            get { return _orgid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[部门ID]长度不能大于50!");
                if (_orgid as object == null || !_orgid.Equals(value))
                {
                    _orgid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbCode
        /// 属性描述：设备编号
        /// 字段信息：[sbCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备编号")]
        public string sbCode
        {
            get { return _sbcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备编号]长度不能大于50!");
                if (_sbcode as object == null || !_sbcode.Equals(value))
                {
                    _sbcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbName
        /// 属性描述：设备名称
        /// 字段信息：[sbName],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备名称")]
        public string sbName
        {
            get { return _sbname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备名称]长度不能大于50!");
                if (_sbname as object == null || !_sbname.Equals(value))
                {
                    _sbname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：syzq
        /// 属性描述：试验周期
        /// 字段信息：[syzq],int
        /// </summary>
        [DisplayNameAttribute("试验周期")]
        public string syzq
        {
            get { return _syzq; }
            set
            {			
                if (_syzq as object == null || !_syzq.Equals(value))
                {
                    _syzq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：syxm
        /// 属性描述：试验项目
        /// 字段信息：[syxm],nvarchar
        /// </summary>
        [DisplayNameAttribute("试验项目")]
        public string syxm
        {
            get { return _syxm; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[试验项目]长度不能大于50!");
                if (_syxm as object == null || !_syxm.Equals(value))
                {
                    _syxm = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：syrq
        /// 属性描述：试验日期
        /// 字段信息：[syrq],datetime
        /// </summary>
        [DisplayNameAttribute("试验日期")]
        public DateTime syrq
        {
            get { return _syrq; }
            set
            {			
                if (_syrq as object == null || !_syrq.Equals(value))
                {
                    _syrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：syrq2
        /// 属性描述：下次试验日期
        /// 字段信息：[syrq2],datetime
        /// </summary>
        [DisplayNameAttribute("下次试验日期")]
        public DateTime syrq2
        {
            get { return _syrq2; }
            set
            {			
                if (_syrq2 as object == null || !_syrq2.Equals(value))
                {
                    _syrq2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbType
        /// 属性描述：设备种类
        /// 字段信息：[sbType],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备种类")]
        public string sbType
        {
            get { return _sbtype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备种类]长度不能大于50!");
                if (_sbtype as object == null || !_sbtype.Equals(value))
                {
                    _sbtype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbModle
        /// 属性描述：设备型号
        /// 字段信息：[sbModle],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备型号")]
        public string sbModle
        {
            get { return _sbmodle; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备型号]长度不能大于50!");
                if (_sbmodle as object == null || !_sbmodle.Equals(value))
                {
                    _sbmodle = value;
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
