/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-6-16 10:16:13
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_UserRoleView]业务实体类
    ///对应表名:PS_UserRoleView
    /// </summary>
    [Serializable]
    public class WF_UserRoleView
    {
        
        #region Private 成员
        private string _roleid=String.Empty; 
        private string _userid=String.Empty; 
        private string _username=String.Empty; 
        private string _sex=String.Empty; 
        private byte[] _password=new byte[]{}; 
        private string _orgname=String.Empty; 
        private string _mail=String.Empty; 
        private string _tel=String.Empty; 
        private string _postname=String.Empty; 
        private string _rolename=String.Empty; 
        private string _roletype=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：RoleID
        /// 属性描述：
        /// 字段信息：[RoleID],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string RoleID
        {
            get { return _roleid; }
            set
            {			
		_roleid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserID
        /// 属性描述：
        /// 字段信息：[UserID],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string UserID
        {
            get { return _userid; }
            set
            {			
		_userid=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserName
        /// 属性描述：
        /// 字段信息：[UserName],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string UserName
        {
            get { return _username; }
            set
            {			
		_username=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：Sex
        /// 属性描述：
        /// 字段信息：[Sex],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Sex
        {
            get { return _sex; }
            set
            {			
		_sex=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：Password
        /// 属性描述：
        /// 字段信息：[Password],varbinary
        /// </summary>
        [DisplayNameAttribute("")]
        public byte[] Password
        {
            get { return _password; }
            set
            {			
		_password=value;	
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
        /// 属性名称：Mail
        /// 属性描述：
        /// 字段信息：[Mail],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Mail
        {
            get { return _mail; }
            set
            {			
		_mail=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：Tel
        /// 属性描述：
        /// 字段信息：[Tel],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Tel
        {
            get { return _tel; }
            set
            {			
		_tel=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：PostName
        /// 属性描述：
        /// 字段信息：[PostName],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string PostName
        {
            get { return _postname; }
            set
            {			
		_postname=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：RoleName
        /// 属性描述：
        /// 字段信息：[RoleName],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string RoleName
        {
            get { return _rolename; }
            set
            {			
		_rolename=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：RoleType
        /// 属性描述：
        /// 字段信息：[RoleType],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string RoleType
        {
            get { return _roletype; }
            set
            {			
		_roletype=value;	
            }			 
        }
  
        #endregion 
  		
    }	
}
