/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada物流企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-6-26 15:40:32
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[YY_userdata]业务实体类
    ///对应表名:YY_userdata
    /// </summary>
    [Serializable]
    public class YY_userdata
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _usercode=String.Empty; 
        private string _username=String.Empty; 
        private string _type=String.Empty; 
        private int _month=0; 
        private double _lastmonthvalue=0; 
        private double _currtenmonthvalue=0; 
        private double _doublenumber=0; 
        private double _changedl=0; 
        private double _dl=0; 
        private double _dcharge=0; 
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
        /// 属性描述：用电类型
        /// 字段信息：[Type],nvarchar
        /// </summary>
        [DisplayNameAttribute("用电类型")]
        public string Type
        {
            get { return _type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[用电类型]长度不能大于50!");
                if (_type as object == null || !_type.Equals(value))
                {
                    _type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：month
        /// 属性描述：月份
        /// 字段信息：[month],int
        /// </summary>
        [DisplayNameAttribute("月份")]
        public int month
        {
            get { return _month; }
            set
            {			
                if (_month as object == null || !_month.Equals(value))
                {
                    _month = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LastMonthValue
        /// 属性描述：上月示数
        /// 字段信息：[LastMonthValue],float
        /// </summary>
        [DisplayNameAttribute("上月示数")]
        public double LastMonthValue
        {
            get { return _lastmonthvalue; }
            set
            {			
                if (_lastmonthvalue as object == null || !_lastmonthvalue.Equals(value))
                {
                    _lastmonthvalue = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CurrtenMonthValue
        /// 属性描述：本月示数
        /// 字段信息：[CurrtenMonthValue],float
        /// </summary>
        [DisplayNameAttribute("本月示数")]
        public double CurrtenMonthValue
        {
            get { return _currtenmonthvalue; }
            set
            {			
                if (_currtenmonthvalue as object == null || !_currtenmonthvalue.Equals(value))
                {
                    _currtenmonthvalue = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：DoubleNumber
        /// 属性描述：倍率
        /// 字段信息：[DoubleNumber],float
        /// </summary>
        [DisplayNameAttribute("倍率")]
        public double DoubleNumber
        {
            get { return _doublenumber; }
            set
            {			
                if (_doublenumber as object == null || !_doublenumber.Equals(value))
                {
                    _doublenumber = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ChangeDL
        /// 属性描述：增减电量
        /// 字段信息：[ChangeDL],float
        /// </summary>
        [DisplayNameAttribute("增减电量")]
        public double ChangeDL
        {
            get { return _changedl; }
            set
            {			
                if (_changedl as object == null || !_changedl.Equals(value))
                {
                    _changedl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：DL
        /// 属性描述：电量
        /// 字段信息：[DL],float
        /// </summary>
        [DisplayNameAttribute("电量")]
        public double DL
        {
            get { return _dl; }
            set
            {			
                if (_dl as object == null || !_dl.Equals(value))
                {
                    _dl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：DCharge
        /// 属性描述：电费
        /// 字段信息：[DCharge],float
        /// </summary>
        [DisplayNameAttribute("电费")]
        public double DCharge
        {
            get { return _dcharge; }
            set
            {			
                if (_dcharge as object == null || !_dcharge.Equals(value))
                {
                    _dcharge = value;
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
