/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:kcgl
模块:库存管理
Itop.com 版权所有
生成者：Rabbit
生成时间:2012-7-22 16:24:55
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Kcgl.Model
{
    /// <summary>
    ///[供货厂家]业务实体类
    ///对应表名:供货厂家
    /// </summary>
    [Serializable]
    public class 供货厂家
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private int _序号=0; 
        private string _厂家名称=String.Empty; 
        private string _联系人=String.Empty; 
        private string _联系电话=String.Empty; 
        private string _备注=String.Empty;   
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
        /// 属性名称：厂家名称
        /// 属性描述：
        /// 字段信息：[厂家名称],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 厂家名称
        {
            get { return _厂家名称; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[厂家名称]长度不能大于50!");
                if (_厂家名称 as object == null || !_厂家名称.Equals(value))
                {
                    _厂家名称 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：联系人
        /// 属性描述：
        /// 字段信息：[联系人],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 联系人
        {
            get { return _联系人; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[联系人]长度不能大于50!");
                if (_联系人 as object == null || !_联系人.Equals(value))
                {
                    _联系人 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：联系电话
        /// 属性描述：
        /// 字段信息：[联系电话],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 联系电话
        {
            get { return _联系电话; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[联系电话]长度不能大于50!");
                if (_联系电话 as object == null || !_联系电话.Equals(value))
                {
                    _联系电话 = value;
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
                if( value.ToString().Length > 100)
                throw new Exception("[备注]长度不能大于100!");
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
