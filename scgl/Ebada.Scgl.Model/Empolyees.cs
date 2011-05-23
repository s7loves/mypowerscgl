/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-17 22:23:25
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[Empolyees]业务实体类
    ///对应表名:Empolyees
    /// </summary>
    [Serializable]
    public class Empolyees
    {
        
        #region Private 成员
        private string _empolyee_id=Newid(); 
        private string _org_id=String.Empty; 
        private string _empolyee_name=String.Empty; 
        private string _alias=String.Empty; 
        private string _fax=String.Empty; 
        private string _email=String.Empty; 
        private string _tel=String.Empty; 
        private string _user_id=String.Empty; 
        private string _password=String.Empty; 
        private string _remark=String.Empty; 
        private string _enabled=String.Empty; 
        private byte[] _rowversion=new byte[]{};   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：Empolyee_ID
        /// 属性描述：职员ID
        /// 字段信息：[Empolyee_ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("职员ID")]
        public string Empolyee_ID
        {
            get { return _empolyee_id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[职员ID]长度不能大于50!");
                if (_empolyee_id as object == null || !_empolyee_id.Equals(value))
                {
                    _empolyee_id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Org_ID
        /// 属性描述：
        /// 字段信息：[Org_ID],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Org_ID
        {
            get { return _org_id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_org_id as object == null || !_org_id.Equals(value))
                {
                    _org_id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Empolyee_Name
        /// 属性描述：职员名称
        /// 字段信息：[Empolyee_Name],nvarchar
        /// </summary>
        [DisplayNameAttribute("职员名称")]
        public string Empolyee_Name
        {
            get { return _empolyee_name; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[职员名称]长度不能大于50!");
                if (_empolyee_name as object == null || !_empolyee_name.Equals(value))
                {
                    _empolyee_name = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：alias
        /// 属性描述：化名
        /// 字段信息：[alias],nvarchar
        /// </summary>
        [DisplayNameAttribute("化名")]
        public string alias
        {
            get { return _alias; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[化名]长度不能大于50!");
                if (_alias as object == null || !_alias.Equals(value))
                {
                    _alias = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Fax
        /// 属性描述：传真
        /// 字段信息：[Fax],nvarchar
        /// </summary>
        [DisplayNameAttribute("传真")]
        public string Fax
        {
            get { return _fax; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[传真]长度不能大于50!");
                if (_fax as object == null || !_fax.Equals(value))
                {
                    _fax = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Email
        /// 属性描述：电子邮箱
        /// 字段信息：[Email],nvarchar
        /// </summary>
        [DisplayNameAttribute("电子邮箱")]
        public string Email
        {
            get { return _email; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电子邮箱]长度不能大于50!");
                if (_email as object == null || !_email.Equals(value))
                {
                    _email = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Tel
        /// 属性描述：电话
        /// 字段信息：[Tel],nvarchar
        /// </summary>
        [DisplayNameAttribute("电话")]
        public string Tel
        {
            get { return _tel; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电话]长度不能大于50!");
                if (_tel as object == null || !_tel.Equals(value))
                {
                    _tel = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：User_ID
        /// 属性描述：用户ID
        /// 字段信息：[User_ID],nvarchar
        /// </summary>
        [DisplayNameAttribute("用户ID")]
        public string User_ID
        {
            get { return _user_id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[用户ID]长度不能大于50!");
                if (_user_id as object == null || !_user_id.Equals(value))
                {
                    _user_id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Password
        /// 属性描述：密码
        /// 字段信息：[Password],nvarchar
        /// </summary>
        [DisplayNameAttribute("密码")]
        public string Password
        {
            get { return _password; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[密码]长度不能大于50!");
                if (_password as object == null || !_password.Equals(value))
                {
                    _password = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Remark
        /// 属性描述：说明
        /// 字段信息：[Remark],nvarchar
        /// </summary>
        [DisplayNameAttribute("说明")]
        public string Remark
        {
            get { return _remark; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[说明]长度不能大于200!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Enabled
        /// 属性描述：有效
        /// 字段信息：[Enabled],nvarchar
        /// </summary>
        [DisplayNameAttribute("有效")]
        public string Enabled
        {
            get { return _enabled; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[有效]长度不能大于50!");
                if (_enabled as object == null || !_enabled.Equals(value))
                {
                    _enabled = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：RowVersion
        /// 属性描述：行版本
        /// 字段信息：[RowVersion],timestamp
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("行版本")]
        public byte[] RowVersion
        {
            get { return _rowversion; }
            set
            {			
                if (_rowversion as object == null || !_rowversion.Equals(value))
                {
                    _rowversion = value;
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
