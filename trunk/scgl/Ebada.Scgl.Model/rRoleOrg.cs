/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-2-25 16:42:01
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[rRoleOrg]业务实体类
    ///对应表名:rRoleOrg
    /// </summary>
    [Serializable]
    public class rRoleOrg
    {
        
        #region Private 成员
        private string _roleid=Newid(); 
        private string _orgid=Newid();   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：RoleID
        /// 属性描述：
        /// 字段信息：[RoleID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("RoleID")]
        public string RoleID
        {
            get { return _roleid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[RoleID]长度不能大于50!");
                if (_roleid as object == null || !_roleid.Equals(value))
                {
                    _roleid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgID
        /// 属性描述：
        /// 字段信息：[OrgID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("OrgID")]
        public string OrgID
        {
            get { return _orgid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[OrgID]长度不能大于50!");
                if (_orgid as object == null || !_orgid.Equals(value))
                {
                    _orgid = value;
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
