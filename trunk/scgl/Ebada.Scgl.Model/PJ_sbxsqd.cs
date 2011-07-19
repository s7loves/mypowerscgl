/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada物流企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-7-19 10:02:32
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_sbxsqd]业务实体类
    ///对应表名:PJ_sbxsqd
    /// </summary>
    [Serializable]
    public class PJ_sbxsqd
    {
        
        #region Private 成员
        private string _linecode=String.Empty; 
        private string _xsqdname=String.Empty; 
        private string _xsr1=String.Empty; 
        private string _xsr2=String.Empty; 
        private string _id=Newid();   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：LineCode
        /// 属性描述：线路编号
        /// 字段信息：[LineCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路编号")]
        public string LineCode
        {
            get { return _linecode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路编号]长度不能大于50!");
                if (_linecode as object == null || !_linecode.Equals(value))
                {
                    _linecode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：XsqdName
        /// 属性描述：巡视区段
        /// 字段信息：[XsqdName],nvarchar
        /// </summary>
        [DisplayNameAttribute("巡视区段")]
        public string XsqdName
        {
            get { return _xsqdname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 100)
                throw new Exception("[巡视区段]长度不能大于100!");
                if (_xsqdname as object == null || !_xsqdname.Equals(value))
                {
                    _xsqdname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：XSR1
        /// 属性描述：巡视人1
        /// 字段信息：[XSR1],nvarchar
        /// </summary>
        [DisplayNameAttribute("巡视人1")]
        public string XSR1
        {
            get { return _xsr1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[巡视人1]长度不能大于50!");
                if (_xsr1 as object == null || !_xsr1.Equals(value))
                {
                    _xsr1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：XSR2
        /// 属性描述：巡视人2
        /// 字段信息：[XSR2],nvarchar
        /// </summary>
        [DisplayNameAttribute("巡视人2")]
        public string XSR2
        {
            get { return _xsr2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[巡视人2]长度不能大于50!");
                if (_xsr2 as object == null || !_xsr2.Equals(value))
                {
                    _xsr2 = value;
                }
            }			 
        }
  
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
