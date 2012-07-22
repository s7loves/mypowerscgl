/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:kcgl
模块:库存管理
Itop.com 版权所有
生成者：Rabbit
生成时间:2012-7-22 22:56:42
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Kcgl.Model
{
    /// <summary>
    ///[工程类别]业务实体类
    ///对应表名:工程类别
    /// </summary>
    [Serializable]
    public class 工程类别
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private int _序号=0; 
        private string _工程类别name=String.Empty; 
        private string _备注=String.Empty;   
        #endregion
		
        #region const 成员
        public const string f_ID= "ID"; 
        public const string f_序号= "序号"; 
        public const string f_工程类别= "工程类别"; 
        public const string f_备注= "备注";   
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
        /// 属性名称：序号
        /// 属性描述：
        /// 字段信息：[序号],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int 序号
        {
            get { return _序号; }
            set
            {			
                if (_序号 as object == null || !_序号.Equals(value))
                {
                    _序号 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：工程类别Name
        /// 属性描述：
        /// 字段信息：[工程类别],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 工程类别Name
        {
            get { return _工程类别name; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[工程类别]长度不能大于50!");
                if (_工程类别name as object == null || !_工程类别name.Equals(value))
                {
                    _工程类别name = value;
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
