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
    ///[bdjl_czpdjb]业务实体类
    ///对应表名:bdjl_czpdjb
    /// </summary>
    [Serializable]
    public class bdjl_czpdjb
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private DateTime _ddate=new DateTime(1900,1,1); 
        private string _czpsybh=String.Empty; 
        private string _czr=String.Empty; 
        private string _jhr=String.Empty; 
        private string _zbr=String.Empty; 
        private string _czrw=String.Empty; 
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
        /// 属性名称：dDate
        /// 属性描述：日期
        /// 字段信息：[dDate],datetime
        /// </summary>
        [DisplayNameAttribute("日期")]
        public DateTime dDate
        {
            get { return _ddate; }
            set
            {			
                if (_ddate as object == null || !_ddate.Equals(value))
                {
                    _ddate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：czpsybh
        /// 属性描述：操作票使用编号
        /// 字段信息：[czpsybh],nvarchar
        /// </summary>
        [DisplayNameAttribute("操作票使用编号")]
        public string czpsybh
        {
            get { return _czpsybh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[操作票使用编号]长度不能大于50!");
                if (_czpsybh as object == null || !_czpsybh.Equals(value))
                {
                    _czpsybh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：czr
        /// 属性描述：操作人
        /// 字段信息：[czr],nvarchar
        /// </summary>
        [DisplayNameAttribute("操作人")]
        public string czr
        {
            get { return _czr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[操作人]长度不能大于50!");
                if (_czr as object == null || !_czr.Equals(value))
                {
                    _czr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jhr
        /// 属性描述：监护人
        /// 字段信息：[jhr],nvarchar
        /// </summary>
        [DisplayNameAttribute("监护人")]
        public string jhr
        {
            get { return _jhr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[监护人]长度不能大于50!");
                if (_jhr as object == null || !_jhr.Equals(value))
                {
                    _jhr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zbr
        /// 属性描述：执行人
        /// 字段信息：[zbr],nvarchar
        /// </summary>
        [DisplayNameAttribute("执行人")]
        public string zbr
        {
            get { return _zbr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[执行人]长度不能大于50!");
                if (_zbr as object == null || !_zbr.Equals(value))
                {
                    _zbr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：czrw
        /// 属性描述：操作任务
        /// 字段信息：[czrw],nvarchar
        /// </summary>
        [DisplayNameAttribute("操作任务")]
        public string czrw
        {
            get { return _czrw; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[操作任务]长度不能大于500!");
                if (_czrw as object == null || !_czrw.Equals(value))
                {
                    _czrw = value;
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
                if( value.ToString().Length > 200)
                throw new Exception("[备用字段1]长度不能大于200!");
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
                if( value.ToString().Length > 200)
                throw new Exception("[备用字段2]长度不能大于200!");
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
                if( value.ToString().Length > 200)
                throw new Exception("[备用字段3]长度不能大于200!");
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
