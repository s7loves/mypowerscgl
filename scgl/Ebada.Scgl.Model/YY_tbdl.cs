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
    ///[YY_tbdl]业务实体类
    ///对应表名:YY_tbdl
    /// </summary>
    [Serializable]
    public class YY_tbdl
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _tqcode=String.Empty; 
        private string _tqname=String.Empty; 
        private int _month=0; 
        private double _lastmonthvalue=0; 
        private double _currtenmonthvalue=0; 
        private double _dl=0; 
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
        /// 属性名称：TqCode
        /// 属性描述：台区编号
        /// 字段信息：[TqCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("台区编号")]
        public string TqCode
        {
            get { return _tqcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[台区编号]长度不能大于50!");
                if (_tqcode as object == null || !_tqcode.Equals(value))
                {
                    _tqcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TqName
        /// 属性描述：台区名称
        /// 字段信息：[TqName],nvarchar
        /// </summary>
        [DisplayNameAttribute("台区名称")]
        public string TqName
        {
            get { return _tqname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[台区名称]长度不能大于50!");
                if (_tqname as object == null || !_tqname.Equals(value))
                {
                    _tqname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Month
        /// 属性描述：月份
        /// 字段信息：[Month],int
        /// </summary>
        [DisplayNameAttribute("月份")]
        public int Month
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
