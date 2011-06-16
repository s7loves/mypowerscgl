/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-11 10:17:52
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_OperContentView]业务实体类
    ///对应表名:PS_OperContentView
    /// </summary>
    [Serializable]
    public class WF_OperContentView
    {
        
        #region Private 成员
        private string _opercontent=String.Empty; 
        private string _userid=String.Empty; 
        private int _opercontenttype=0;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：operContent
        /// 属性描述：
        /// 字段信息：[operContent],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string operContent
        {
            get { return _opercontent; }
            set
            {			
		_opercontent=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserId
        /// 属性描述：
        /// 字段信息：[UserId],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string UserId
        {
            get { return _userid; }
            set
            {			
		_userid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：operContentType
        /// 属性描述：
        /// 字段信息：[operContentType],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int operContentType
        {
            get { return _opercontenttype; }
            set
            {			
		_opercontenttype=value;	
            }			 
        }
  
        #endregion 
  		
    }	
}
