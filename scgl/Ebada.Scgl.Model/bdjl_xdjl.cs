/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-4-7 10:59:29
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[bdjl_xdjl]业务实体类
    ///对应表名:bdjl_xdjl
    /// </summary>
    [Serializable]
    public class bdjl_xdjl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private DateTime _xdsj=new DateTime(1900,1,1); 
        private string _xdflr=String.Empty; 
        private string _xdslr=String.Empty; 
        private string _xdxl=String.Empty; 
        private string _xddl=String.Empty; 
        private DateTime _sdsj=new DateTime(1900,1,1); 
        private string _sdflr=String.Empty; 
        private string _sdslr=String.Empty; 
        private string _xdsdl=String.Empty; 
        private string _xdzhdl=String.Empty; 
        private string _bz=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：ID
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("ID")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[ID]长度不能大于50!");
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
        /// 属性名称：xdsj
        /// 属性描述：限电时间
        /// 字段信息：[xdsj],datetime
        /// </summary>
        [DisplayNameAttribute("限电时间")]
        public DateTime xdsj
        {
            get { return _xdsj; }
            set
            {			
                if (_xdsj as object == null || !_xdsj.Equals(value))
                {
                    _xdsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xdflr
        /// 属性描述：限电发令人
        /// 字段信息：[xdflr],nvarchar
        /// </summary>
        [DisplayNameAttribute("限电发令人")]
        public string xdflr
        {
            get { return _xdflr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[限电发令人]长度不能大于50!");
                if (_xdflr as object == null || !_xdflr.Equals(value))
                {
                    _xdflr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xdslr
        /// 属性描述：限电受令人
        /// 字段信息：[xdslr],nvarchar
        /// </summary>
        [DisplayNameAttribute("限电受令人")]
        public string xdslr
        {
            get { return _xdslr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[限电受令人]长度不能大于50!");
                if (_xdslr as object == null || !_xdslr.Equals(value))
                {
                    _xdslr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xdxl
        /// 属性描述：限电线路
        /// 字段信息：[xdxl],nvarchar
        /// </summary>
        [DisplayNameAttribute("限电线路")]
        public string xdxl
        {
            get { return _xdxl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[限电线路]长度不能大于50!");
                if (_xdxl as object == null || !_xdxl.Equals(value))
                {
                    _xdxl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xddl
        /// 属性描述：限电电流(A)
        /// 字段信息：[xddl],nvarchar
        /// </summary>
        [DisplayNameAttribute("限电电流(A)")]
        public string xddl
        {
            get { return _xddl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[限电电流(A)]长度不能大于50!");
                if (_xddl as object == null || !_xddl.Equals(value))
                {
                    _xddl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdsj
        /// 属性描述：送电时间
        /// 字段信息：[sdsj],datetime
        /// </summary>
        [DisplayNameAttribute("送电时间")]
        public DateTime sdsj
        {
            get { return _sdsj; }
            set
            {			
                if (_sdsj as object == null || !_sdsj.Equals(value))
                {
                    _sdsj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdflr
        /// 属性描述：送电发令人
        /// 字段信息：[sdflr],nvarchar
        /// </summary>
        [DisplayNameAttribute("送电发令人")]
        public string sdflr
        {
            get { return _sdflr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[送电发令人]长度不能大于50!");
                if (_sdflr as object == null || !_sdflr.Equals(value))
                {
                    _sdflr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sdslr
        /// 属性描述：送电受令人
        /// 字段信息：[sdslr],nvarchar
        /// </summary>
        [DisplayNameAttribute("送电受令人")]
        public string sdslr
        {
            get { return _sdslr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[送电受令人]长度不能大于50!");
                if (_sdslr as object == null || !_sdslr.Equals(value))
                {
                    _sdslr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xdsdl
        /// 属性描述：送电时电流(A)
        /// 字段信息：[xdsdl],nvarchar
        /// </summary>
        [DisplayNameAttribute("送电时电流(A)")]
        public string xdsdl
        {
            get { return _xdsdl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[送电时电流(A)]长度不能大于50!");
                if (_xdsdl as object == null || !_xdsdl.Equals(value))
                {
                    _xdsdl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xdzhdl
        /// 属性描述：限电折合电量(KWH)
        /// 字段信息：[xdzhdl],nvarchar
        /// </summary>
        [DisplayNameAttribute("限电折合电量(KWH)")]
        public string xdzhdl
        {
            get { return _xdzhdl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[限电折合电量(KWH)]长度不能大于50!");
                if (_xdzhdl as object == null || !_xdzhdl.Equals(value))
                {
                    _xdzhdl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bz
        /// 属性描述：备注
        /// 字段信息：[bz],nvarchar
        /// </summary>
        [DisplayNameAttribute("备注")]
        public string bz
        {
            get { return _bz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备注]长度不能大于500!");
                if (_bz as object == null || !_bz.Equals(value))
                {
                    _bz = value;
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
