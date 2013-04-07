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
    ///[bdjl_gzpdjb]业务实体类
    ///对应表名:bdjl_gzpdjb
    /// </summary>
    [Serializable]
    public class bdjl_gzpdjb
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _gzpbh=String.Empty; 
        private string _gzpzl=String.Empty; 
        private string _gzpfzr=String.Empty; 
        private DateTime _gzkssj=new DateTime(1900,1,1); 
        private DateTime _gzjssj=new DateTime(1900,1,1); 
        private string _gzxkr=String.Empty; 
        private string _zbz=String.Empty; 
        private string _gzpqfr=String.Empty; 
        private string _gzddjnr=String.Empty; 
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
        /// 属性描述：单位编号
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("单位编号")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单位编号]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gzpbh
        /// 属性描述：工作票编号
        /// 字段信息：[gzpbh],nvarchar
        /// </summary>
        [DisplayNameAttribute("工作票编号")]
        public string gzpbh
        {
            get { return _gzpbh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[工作票编号]长度不能大于50!");
                if (_gzpbh as object == null || !_gzpbh.Equals(value))
                {
                    _gzpbh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gzpzl
        /// 属性描述：工作票种类
        /// 字段信息：[gzpzl],nvarchar
        /// </summary>
        [DisplayNameAttribute("工作票种类")]
        public string gzpzl
        {
            get { return _gzpzl; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[工作票种类]长度不能大于50!");
                if (_gzpzl as object == null || !_gzpzl.Equals(value))
                {
                    _gzpzl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gzpfzr
        /// 属性描述：工作负责人
        /// 字段信息：[gzpfzr],nvarchar
        /// </summary>
        [DisplayNameAttribute("工作负责人")]
        public string gzpfzr
        {
            get { return _gzpfzr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[工作负责人]长度不能大于50!");
                if (_gzpfzr as object == null || !_gzpfzr.Equals(value))
                {
                    _gzpfzr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gzkssj
        /// 属性描述：工作开始时间
        /// 字段信息：[gzkssj],datetime
        /// </summary>
        [DisplayNameAttribute("工作开始时间")]
        public DateTime gzkssj
        {
            get { return _gzkssj; }
            set
            {			
                if (_gzkssj as object == null || !_gzkssj.Equals(value))
                {
                    _gzkssj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gzjssj
        /// 属性描述：工作结束时间
        /// 字段信息：[gzjssj],datetime
        /// </summary>
        [DisplayNameAttribute("工作结束时间")]
        public DateTime gzjssj
        {
            get { return _gzjssj; }
            set
            {			
                if (_gzjssj as object == null || !_gzjssj.Equals(value))
                {
                    _gzjssj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gzxkr
        /// 属性描述：工作许可人
        /// 字段信息：[gzxkr],nvarchar
        /// </summary>
        [DisplayNameAttribute("工作许可人")]
        public string gzxkr
        {
            get { return _gzxkr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[工作许可人]长度不能大于50!");
                if (_gzxkr as object == null || !_gzxkr.Equals(value))
                {
                    _gzxkr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zbz
        /// 属性描述：值班长
        /// 字段信息：[zbz],nvarchar
        /// </summary>
        [DisplayNameAttribute("值班长")]
        public string zbz
        {
            get { return _zbz; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[值班长]长度不能大于50!");
                if (_zbz as object == null || !_zbz.Equals(value))
                {
                    _zbz = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gzpqfr
        /// 属性描述：工作票签发人
        /// 字段信息：[gzpqfr],nvarchar
        /// </summary>
        [DisplayNameAttribute("工作票签发人")]
        public string gzpqfr
        {
            get { return _gzpqfr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[工作票签发人]长度不能大于50!");
                if (_gzpqfr as object == null || !_gzpqfr.Equals(value))
                {
                    _gzpqfr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gzddjnr
        /// 属性描述：工作地点及工作内容
        /// 字段信息：[gzddjnr],nvarchar
        /// </summary>
        [DisplayNameAttribute("工作地点及工作内容")]
        public string gzddjnr
        {
            get { return _gzddjnr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[工作地点及工作内容]长度不能大于500!");
                if (_gzddjnr as object == null || !_gzddjnr.Equals(value))
                {
                    _gzddjnr = value;
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
