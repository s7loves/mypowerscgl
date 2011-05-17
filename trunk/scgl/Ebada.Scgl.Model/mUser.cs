/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada物流企业ERP
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
    ///[mUser]业务实体类
    ///对应表名:mUser
    /// </summary>
    [Serializable]
    public class mUser
    {
        
        #region Private 成员
        private string _userid=Newid(); 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _usercode=String.Empty; 
        private string _username=String.Empty; 
        private string _sex=String.Empty; 
        private DateTime _birthday=new DateTime(1900,1,1); 
        private string _loginid=String.Empty; 
        private byte[] _password=new byte[]{}; 
        private string _alias=String.Empty; 
        private bool _valid=false; 
        private string _type=String.Empty; 
        private string _tel=String.Empty; 
        private string _mail=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty; 
        private string _c4=String.Empty; 
        private string _c5=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
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
  
        /// <summary>
        /// 属性名称：OrgCode
        /// 属性描述：部门编号
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("部门编号")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[部门编号]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgName
        /// 属性描述：部门名称
        /// 字段信息：[OrgName],nvarchar
        /// </summary>
        [DisplayNameAttribute("部门名称")]
        public string OrgName
        {
            get { return _orgname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[部门名称]长度不能大于50!");
                if (_orgname as object == null || !_orgname.Equals(value))
                {
                    _orgname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserCode
        /// 属性描述：职员编号
        /// 字段信息：[UserCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("职员编号")]
        public string UserCode
        {
            get { return _usercode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[职员编号]长度不能大于50!");
                if (_usercode as object == null || !_usercode.Equals(value))
                {
                    _usercode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserName
        /// 属性描述：姓名
        /// 字段信息：[UserName],nvarchar
        /// </summary>
        [DisplayNameAttribute("姓名")]
        public string UserName
        {
            get { return _username; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[姓名]长度不能大于10!");
                if (_username as object == null || !_username.Equals(value))
                {
                    _username = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Sex
        /// 属性描述：姓别
        /// 字段信息：[Sex],nvarchar
        /// </summary>
        [DisplayNameAttribute("姓别")]
        public string Sex
        {
            get { return _sex; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[姓别]长度不能大于10!");
                if (_sex as object == null || !_sex.Equals(value))
                {
                    _sex = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Birthday
        /// 属性描述：生日
        /// 字段信息：[Birthday],datetime
        /// </summary>
        [DisplayNameAttribute("生日")]
        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {			
                if (_birthday as object == null || !_birthday.Equals(value))
                {
                    _birthday = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LoginID
        /// 属性描述：登录ID
        /// 字段信息：[LoginID],nvarchar
        /// </summary>
        [DisplayNameAttribute("登录ID")]
        public string LoginID
        {
            get { return _loginid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[登录ID]长度不能大于50!");
                if (_loginid as object == null || !_loginid.Equals(value))
                {
                    _loginid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Password
        /// 属性描述：登录口令
        /// 字段信息：[Password],varbinary
        /// </summary>
        [DisplayNameAttribute("登录口令")]
        public byte[] Password
        {
            get { return _password; }
            set
            {			
                if (_password as object == null || !_password.Equals(value))
                {
                    _password = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Alias
        /// 属性描述：别名
        /// 字段信息：[Alias],nvarchar
        /// </summary>
        [DisplayNameAttribute("别名")]
        public string Alias
        {
            get { return _alias; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[别名]长度不能大于10!");
                if (_alias as object == null || !_alias.Equals(value))
                {
                    _alias = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Valid
        /// 属性描述：是否有效
        /// 字段信息：[Valid],bit
        /// </summary>
        [DisplayNameAttribute("是否有效")]
        public bool Valid
        {
            get { return _valid; }
            set
            {			
                if (_valid as object == null || !_valid.Equals(value))
                {
                    _valid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Type
        /// 属性描述：分类
        /// 字段信息：[Type],nvarchar
        /// </summary>
        [DisplayNameAttribute("分类")]
        public string Type
        {
            get { return _type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[分类]长度不能大于50!");
                if (_type as object == null || !_type.Equals(value))
                {
                    _type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Tel
        /// 属性描述：手机
        /// 字段信息：[Tel],nvarchar
        /// </summary>
        [DisplayNameAttribute("手机")]
        public string Tel
        {
            get { return _tel; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[手机]长度不能大于50!");
                if (_tel as object == null || !_tel.Equals(value))
                {
                    _tel = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Mail
        /// 属性描述：电子邮箱
        /// 字段信息：[Mail],nvarchar
        /// </summary>
        [DisplayNameAttribute("电子邮箱")]
        public string Mail
        {
            get { return _mail; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电子邮箱]长度不能大于50!");
                if (_mail as object == null || !_mail.Equals(value))
                {
                    _mail = value;
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
