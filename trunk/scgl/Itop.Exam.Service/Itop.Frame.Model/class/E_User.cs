/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ftpa辅助系统
模块:系统平台
Ftpa.com 版权所有
生成者：Rabbit
生成时间:2013-8-24 16:30:08
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Itop.Frame.Model
{
    /// <summary>
    ///[E_User]业务实体类
    ///对应表名:E_User
    /// </summary>
    [Serializable]
    public class E_User
    {
        
        #region Private 成员
        private string _userid=Newid(); 
        private string _usercode=String.Empty; 
        private string _username=String.Empty; 
        private string _sex=String.Empty; 
        private DateTime _birthday=new DateTime(1900,1,1); 
        private string _loginid=String.Empty; 
        private string _password=String.Empty; 
        private bool _valid=false; 
        private string _type=String.Empty; 
        private string _org_id=String.Empty; 
        private string _orgcode=String.Empty; 
        private string _orgname=String.Empty; 
        private string _national_id=String.Empty; 
        private string _post_id=String.Empty; 
        private string _postname=String.Empty; 
        private int _logintimes=0; 
        private DateTime _lastlogintime=new DateTime(1900,1,1); 
        private string _lastloginid=String.Empty; 
        private string _byscol1=String.Empty; 
        private string _byscol2=String.Empty; 
        private string _byscol3=String.Empty; 
        private string _byscol4=String.Empty; 
        private string _byscol5=String.Empty; 
        private string _remark=String.Empty; 
        private byte[] _rowversion=new byte[]{};   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：UserID
        /// 属性描述：
        /// 字段信息：[UserID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string UserID
        {
            get { return _userid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_userid as object == null || !_userid.Equals(value))
                {
                    _userid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserCode
        /// 属性描述：
        /// 字段信息：[UserCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string UserCode
        {
            get { return _usercode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_usercode as object == null || !_usercode.Equals(value))
                {
                    _usercode = value;
                }
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
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[]长度不能大于10!");
                if (_username as object == null || !_username.Equals(value))
                {
                    _username = value;
                }
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
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[]长度不能大于10!");
                if (_sex as object == null || !_sex.Equals(value))
                {
                    _sex = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Birthday
        /// 属性描述：
        /// 字段信息：[Birthday],datetime
        /// </summary>
        [DisplayNameAttribute("")]
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
        /// 属性描述：
        /// 字段信息：[LoginID],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string LoginID
        {
            get { return _loginid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_loginid as object == null || !_loginid.Equals(value))
                {
                    _loginid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Password
        /// 属性描述：
        /// 字段信息：[Password],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Password
        {
            get { return _password; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 150)
                throw new Exception("[]长度不能大于150!");
                if (_password as object == null || !_password.Equals(value))
                {
                    _password = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Valid
        /// 属性描述：
        /// 字段信息：[Valid],bit
        /// </summary>
        [DisplayNameAttribute("")]
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
        /// 属性描述：
        /// 字段信息：[Type],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Type
        {
            get { return _type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_type as object == null || !_type.Equals(value))
                {
                    _type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Org_ID
        /// 属性描述：部门ID
        /// 字段信息：[Org_ID],nvarchar
        /// </summary>
        [DisplayNameAttribute("部门ID")]
        public string Org_ID
        {
            get { return _org_id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[部门ID]长度不能大于50!");
                if (_org_id as object == null || !_org_id.Equals(value))
                {
                    _org_id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgCode
        /// 属性描述：部门编号
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
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
        /// 属性描述：
        /// 字段信息：[OrgName],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string OrgName
        {
            get { return _orgname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_orgname as object == null || !_orgname.Equals(value))
                {
                    _orgname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：National_ID
        /// 属性描述：民族
        /// 字段信息：[National_ID],nvarchar
        /// </summary>
        [DisplayNameAttribute("民族")]
        public string National_ID
        {
            get { return _national_id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[民族]长度不能大于50!");
                if (_national_id as object == null || !_national_id.Equals(value))
                {
                    _national_id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Post_ID
        /// 属性描述：职务
        /// 字段信息：[Post_ID],nvarchar
        /// </summary>
        [DisplayNameAttribute("职务")]
        public string Post_ID
        {
            get { return _post_id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[职务]长度不能大于50!");
                if (_post_id as object == null || !_post_id.Equals(value))
                {
                    _post_id = value;
                }
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
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_postname as object == null || !_postname.Equals(value))
                {
                    _postname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LoginTimes
        /// 属性描述：登录次数
        /// 字段信息：[LoginTimes],int
        /// </summary>
        [DisplayNameAttribute("登录次数")]
        public int LoginTimes
        {
            get { return _logintimes; }
            set
            {			
                if (_logintimes as object == null || !_logintimes.Equals(value))
                {
                    _logintimes = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LastLoginTime
        /// 属性描述：上次登录时间
        /// 字段信息：[LastLoginTime],datetime
        /// </summary>
        [DisplayNameAttribute("上次登录时间")]
        public DateTime LastLoginTime
        {
            get { return _lastlogintime; }
            set
            {			
                if (_lastlogintime as object == null || !_lastlogintime.Equals(value))
                {
                    _lastlogintime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LastLoginID
        /// 属性描述：上次登录地址
        /// 字段信息：[LastLoginID],nvarchar
        /// </summary>
        [DisplayNameAttribute("上次登录地址")]
        public string LastLoginID
        {
            get { return _lastloginid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[上次登录地址]长度不能大于50!");
                if (_lastloginid as object == null || !_lastloginid.Equals(value))
                {
                    _lastloginid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BySCol1
        /// 属性描述：备用1
        /// 字段信息：[BySCol1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用1")]
        public string BySCol1
        {
            get { return _byscol1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[备用1]长度不能大于200!");
                if (_byscol1 as object == null || !_byscol1.Equals(value))
                {
                    _byscol1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BySCol2
        /// 属性描述：备用2
        /// 字段信息：[BySCol2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用2")]
        public string BySCol2
        {
            get { return _byscol2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[备用2]长度不能大于200!");
                if (_byscol2 as object == null || !_byscol2.Equals(value))
                {
                    _byscol2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BySCol3
        /// 属性描述：备用3
        /// 字段信息：[BySCol3],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用3")]
        public string BySCol3
        {
            get { return _byscol3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[备用3]长度不能大于200!");
                if (_byscol3 as object == null || !_byscol3.Equals(value))
                {
                    _byscol3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BySCol4
        /// 属性描述：备用4
        /// 字段信息：[BySCol4],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用4")]
        public string BySCol4
        {
            get { return _byscol4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[备用4]长度不能大于200!");
                if (_byscol4 as object == null || !_byscol4.Equals(value))
                {
                    _byscol4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BySCol5
        /// 属性描述：备用5
        /// 字段信息：[BySCol5],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用5")]
        public string BySCol5
        {
            get { return _byscol5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[备用5]长度不能大于200!");
                if (_byscol5 as object == null || !_byscol5.Equals(value))
                {
                    _byscol5 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Remark
        /// 属性描述：备注
        /// 字段信息：[Remark],nvarchar
        /// </summary>
        [DisplayNameAttribute("备注")]
        public string Remark
        {
            get { return _remark; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 200)
                throw new Exception("[备注]长度不能大于200!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：RowVersion
        /// 属性描述：时间戳
        /// 字段信息：[RowVersion],timestamp
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("时间戳")]
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
