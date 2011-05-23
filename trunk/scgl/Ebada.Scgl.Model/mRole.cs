/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-17 22:06:06
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[mRole]业务实体类
    ///对应表名:mRole
    /// </summary>
    [Serializable]
    public class mRole
    {
        
        #region Private 成员
        private string _roleid=Newid(); 
        private string _rolecode=String.Empty; 
        private string _rolename=String.Empty; 
        private string _roletype=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty; 
        private string _c4=String.Empty; 
        private string _c5=String.Empty;   
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
        /// 属性名称：RoleCode
        /// 属性描述：角色编号
        /// 字段信息：[RoleCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("角色编号")]
        public string RoleCode
        {
            get { return _rolecode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[角色编号]长度不能大于50!");
                if (_rolecode as object == null || !_rolecode.Equals(value))
                {
                    _rolecode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：RoleName
        /// 属性描述：角色名称
        /// 字段信息：[RoleName],nvarchar
        /// </summary>
        [DisplayNameAttribute("角色名称")]
        public string RoleName
        {
            get { return _rolename; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[角色名称]长度不能大于50!");
                if (_rolename as object == null || !_rolename.Equals(value))
                {
                    _rolename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：RoleType
        /// 属性描述：特性
        /// 字段信息：[RoleType],nvarchar
        /// </summary>
        [DisplayNameAttribute("特性")]
        public string RoleType
        {
            get { return _roletype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[特性]长度不能大于50!");
                if (_roletype as object == null || !_roletype.Equals(value))
                {
                    _roletype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：C1
        /// 属性描述：未定义
        /// 字段信息：[C1],nvarchar
        /// </summary>
        [DisplayNameAttribute("未定义")]
        public string C1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[未定义]长度不能大于200!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：C2
        /// 属性描述：未定义2
        /// 字段信息：[C2],nvarchar
        /// </summary>
        [DisplayNameAttribute("未定义2")]
        public string C2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[未定义2]长度不能大于200!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：C3
        /// 属性描述：未定义3
        /// 字段信息：[C3],nvarchar
        /// </summary>
        [DisplayNameAttribute("未定义3")]
        public string C3
        {
            get { return _c3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[未定义3]长度不能大于200!");
                if (_c3 as object == null || !_c3.Equals(value))
                {
                    _c3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：C4
        /// 属性描述：未定义4
        /// 字段信息：[C4],nvarchar
        /// </summary>
        [DisplayNameAttribute("未定义4")]
        public string C4
        {
            get { return _c4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[未定义4]长度不能大于200!");
                if (_c4 as object == null || !_c4.Equals(value))
                {
                    _c4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：C5
        /// 属性描述：未定义5
        /// 字段信息：[C5],nvarchar
        /// </summary>
        [DisplayNameAttribute("未定义5")]
        public string C5
        {
            get { return _c5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[未定义5]长度不能大于200!");
                if (_c5 as object == null || !_c5.Equals(value))
                {
                    _c5 = value;
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
