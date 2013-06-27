/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada物流企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-6-26 15:40:31
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[YY_user]业务实体类
    ///对应表名:YY_user
    /// </summary>
    [Serializable]
    public class YY_user
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _usercode=String.Empty; 
        private string _username=String.Empty; 
        private string _type=String.Empty; 
        private string _address=String.Empty; 
        private string _bxcode=String.Empty; 
        private string _bcode=String.Empty; 
        private string _telnumber=String.Empty; 
        private double _dprice=0; 
        private string _sutqcode=String.Empty; 
        private string _byscol1=String.Empty; 
        private string _byscol2=String.Empty; 
        private string _byscol3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserCode
        /// 属性描述：用户号
        /// 字段信息：[UserCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("用户号")]
        public string UserCode
        {
            get { return _usercode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[用户号]长度不能大于50!");
                if (_usercode as object == null || !_usercode.Equals(value))
                {
                    _usercode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：UserName
        /// 属性描述：用户名
        /// 字段信息：[UserName],nvarchar
        /// </summary>
        [DisplayNameAttribute("用户名")]
        public string UserName
        {
            get { return _username; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[用户名]长度不能大于50!");
                if (_username as object == null || !_username.Equals(value))
                {
                    _username = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Type
        /// 属性描述：用户类型
        /// 字段信息：[Type],nvarchar
        /// </summary>
        [DisplayNameAttribute("用户类型")]
        public string Type
        {
            get { return _type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[用户类型]长度不能大于50!");
                if (_type as object == null || !_type.Equals(value))
                {
                    _type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Address
        /// 属性描述：住址
        /// 字段信息：[Address],nvarchar
        /// </summary>
        [DisplayNameAttribute("住址")]
        public string Address
        {
            get { return _address; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[住址]长度不能大于50!");
                if (_address as object == null || !_address.Equals(value))
                {
                    _address = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BxCode
        /// 属性描述：表箱号
        /// 字段信息：[BxCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("表箱号")]
        public string BxCode
        {
            get { return _bxcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[表箱号]长度不能大于50!");
                if (_bxcode as object == null || !_bxcode.Equals(value))
                {
                    _bxcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：BCode
        /// 属性描述：表号
        /// 字段信息：[BCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("表号")]
        public string BCode
        {
            get { return _bcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[表号]长度不能大于50!");
                if (_bcode as object == null || !_bcode.Equals(value))
                {
                    _bcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TelNumber
        /// 属性描述：电话
        /// 字段信息：[TelNumber],nvarchar
        /// </summary>
        [DisplayNameAttribute("电话")]
        public string TelNumber
        {
            get { return _telnumber; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电话]长度不能大于50!");
                if (_telnumber as object == null || !_telnumber.Equals(value))
                {
                    _telnumber = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：DPrice
        /// 属性描述：电价
        /// 字段信息：[DPrice],float
        /// </summary>
        [DisplayNameAttribute("电价")]
        public double DPrice
        {
            get { return _dprice; }
            set
            {			
                if (_dprice as object == null || !_dprice.Equals(value))
                {
                    _dprice = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SuTqCode
        /// 属性描述：所属台区
        /// 字段信息：[SuTqCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("所属台区")]
        public string SuTqCode
        {
            get { return _sutqcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[所属台区]长度不能大于50!");
                if (_sutqcode as object == null || !_sutqcode.Equals(value))
                {
                    _sutqcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ByScol1
        /// 属性描述：备用1
        /// 字段信息：[ByScol1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用1")]
        public string ByScol1
        {
            get { return _byscol1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用1]长度不能大于50!");
                if (_byscol1 as object == null || !_byscol1.Equals(value))
                {
                    _byscol1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ByScol2
        /// 属性描述：备用2
        /// 字段信息：[ByScol2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用2")]
        public string ByScol2
        {
            get { return _byscol2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用2]长度不能大于50!");
                if (_byscol2 as object == null || !_byscol2.Equals(value))
                {
                    _byscol2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ByScol3
        /// 属性描述：备用3
        /// 字段信息：[ByScol3],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用3")]
        public string ByScol3
        {
            get { return _byscol3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用3]长度不能大于50!");
                if (_byscol3 as object == null || !_byscol3.Equals(value))
                {
                    _byscol3 = value;
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
