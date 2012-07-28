/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:kcgl
模块:库存管理
Itop.com 版权所有
生成者：Rabbit
生成时间:2012-7-28 15:12:37
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Kcgl.Model
{
    /// <summary>
    ///[kc_账套]业务实体类
    ///对应表名:kc_账套
    /// </summary>
    [Serializable]
    public class kc_账套
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _账套名称=String.Empty; 
        private DateTime _创建时间=new DateTime(1900,1,1); 
        private string _创建人=String.Empty; 
        private string _备注=String.Empty; 
        private string _版本=String.Empty;   
        #endregion
		
        #region const 成员
        public const string f_ID= "ID"; 
        public const string f_账套名称= "账套名称"; 
        public const string f_创建时间= "创建时间"; 
        public const string f_创建人= "创建人"; 
        public const string f_备注= "备注"; 
        public const string f_版本= "版本";   
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
                throw new Exception("[ID]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：账套名称
        /// 属性描述：
        /// 字段信息：[账套名称],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 账套名称
        {
            get { return _账套名称; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[账套名称]长度不能大于50!");
                if (_账套名称 as object == null || !_账套名称.Equals(value))
                {
                    _账套名称 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：创建时间
        /// 属性描述：
        /// 字段信息：[创建时间],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime 创建时间
        {
            get { return _创建时间; }
            set
            {			
                if (_创建时间 as object == null || !_创建时间.Equals(value))
                {
                    _创建时间 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：创建人
        /// 属性描述：
        /// 字段信息：[创建人],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 创建人
        {
            get { return _创建人; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[创建人]长度不能大于50!");
                if (_创建人 as object == null || !_创建人.Equals(value))
                {
                    _创建人 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：备注
        /// 属性描述：
        /// 字段信息：[备注],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 备注
        {
            get { return _备注; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备注]长度不能大于50!");
                if (_备注 as object == null || !_备注.Equals(value))
                {
                    _备注 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：版本
        /// 属性描述：
        /// 字段信息：[版本],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 版本
        {
            get { return _版本; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[版本]长度不能大于50!");
                if (_版本 as object == null || !_版本.Equals(value))
                {
                    _版本 = value;
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
