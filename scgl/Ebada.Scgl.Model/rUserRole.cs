/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada物流企业ERP
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
    ///[rUserRole]业务实体类
    ///对应表名:rUserRole
    /// </summary>
    [Serializable]
    public class rUserRole
    {
        
        #region Private 成员
        private string _roleid=Newid(); 
        private string _userid=Newid();   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：RoleID
        /// 属性描述：角色ID
        /// 字段信息：[RoleID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("角色ID")]
        public string RoleID
        {
            get { return _roleid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[角色ID]长度不能大于50!");
                if (_roleid as object == null || !_roleid.Equals(value))
                {
                    _roleid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserID
        /// 属性描述：职员ID
        /// 字段信息：[UserID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("职员ID")]
        public string UserID
        {
            get { return _userid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[职员ID]长度不能大于50!");
                if (_userid as object == null || !_userid.Equals(value))
                {
                    _userid = value;
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
