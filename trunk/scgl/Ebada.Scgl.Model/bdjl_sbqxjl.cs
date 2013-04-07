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
    ///[bdjl_sbqxjl]业务实体类
    ///对应表名:bdjl_sbqxjl
    /// </summary>
    [Serializable]
    public class bdjl_sbqxjl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _orgcode=String.Empty; 
        private string _sbmc=String.Empty; 
        private string _qxbh=String.Empty; 
        private DateTime _fxrq=new DateTime(1900,1,1); 
        private string _fxr=String.Empty; 
        private string _qxlb=String.Empty; 
        private string _qxnr=String.Empty; 
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
        /// 属性名称：sbmc
        /// 属性描述：设备名称
        /// 字段信息：[sbmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备名称")]
        public string sbmc
        {
            get { return _sbmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备名称]长度不能大于50!");
                if (_sbmc as object == null || !_sbmc.Equals(value))
                {
                    _sbmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qxbh
        /// 属性描述：缺陷编号
        /// 字段信息：[qxbh],nvarchar
        /// </summary>
        [DisplayNameAttribute("缺陷编号")]
        public string qxbh
        {
            get { return _qxbh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[缺陷编号]长度不能大于50!");
                if (_qxbh as object == null || !_qxbh.Equals(value))
                {
                    _qxbh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fxrq
        /// 属性描述：发现日期
        /// 字段信息：[fxrq],datetime
        /// </summary>
        [DisplayNameAttribute("发现日期")]
        public DateTime fxrq
        {
            get { return _fxrq; }
            set
            {			
                if (_fxrq as object == null || !_fxrq.Equals(value))
                {
                    _fxrq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fxr
        /// 属性描述：发现人
        /// 字段信息：[fxr],nvarchar
        /// </summary>
        [DisplayNameAttribute("发现人")]
        public string fxr
        {
            get { return _fxr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[发现人]长度不能大于50!");
                if (_fxr as object == null || !_fxr.Equals(value))
                {
                    _fxr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qxlb
        /// 属性描述：缺陷类别
        /// 字段信息：[qxlb],nvarchar
        /// </summary>
        [DisplayNameAttribute("缺陷类别")]
        public string qxlb
        {
            get { return _qxlb; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[缺陷类别]长度不能大于50!");
                if (_qxlb as object == null || !_qxlb.Equals(value))
                {
                    _qxlb = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：qxnr
        /// 属性描述：缺陷内容
        /// 字段信息：[qxnr],nvarchar
        /// </summary>
        [DisplayNameAttribute("缺陷内容")]
        public string qxnr
        {
            get { return _qxnr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[缺陷内容]长度不能大于500!");
                if (_qxnr as object == null || !_qxnr.Equals(value))
                {
                    _qxnr = value;
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
