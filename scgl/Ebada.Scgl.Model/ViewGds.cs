/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-17 22:06:07
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[ViewGds]业务实体类
    ///对应表名:ViewGds
    /// </summary>
    [Serializable]
    public class ViewGds
    {
        
        #region Private 成员
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private DateTime _psafetime=new DateTime(1900,1,1); 
        private DateTime _dsafetime=new DateTime(1900,1,1);   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：OrgCode
        /// 属性描述：
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
		_orgcode=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgName
        /// 属性描述：
        /// 字段信息：[OrgName],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string OrgName
        {
            get { return _orgname; }
            set
            {			
		_orgname=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：PSafeTime
        /// 属性描述：
        /// 字段信息：[PSafeTime],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime PSafeTime
        {
            get { return _psafetime; }
            set
            {			
		_psafetime=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：DSafeTime
        /// 属性描述：
        /// 字段信息：[DSafeTime],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime DSafeTime
        {
            get { return _dsafetime; }
            set
            {			
		_dsafetime=value;	
            }			 
        }
  
        #endregion 
  		
    }	
}
