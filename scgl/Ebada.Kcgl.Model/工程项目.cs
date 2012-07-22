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
    ///[工程项目]业务实体类
    ///对应表名:工程项目
    /// </summary>
    [Serializable]
    public class 工程项目
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _工程类别=String.Empty; 
        private string _工程项目名称=String.Empty; 
        private double _预算费用=0; 
        private DateTime _开工日期=new DateTime(1900,1,1); 
        private DateTime _完成日期=new DateTime(1900,1,1);   
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
        /// 属性名称：工程类别
        /// 属性描述：
        /// 字段信息：[工程类别],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 工程类别
        {
            get { return _工程类别; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[工程类别]长度不能大于50!");
                if (_工程类别 as object == null || !_工程类别.Equals(value))
                {
                    _工程类别 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：工程项目名称
        /// 属性描述：
        /// 字段信息：[工程项目名称],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 工程项目名称
        {
            get { return _工程项目名称; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[工程项目名称]长度不能大于50!");
                if (_工程项目名称 as object == null || !_工程项目名称.Equals(value))
                {
                    _工程项目名称 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：预算费用
        /// 属性描述：
        /// 字段信息：[预算费用],float
        /// </summary>
        [DisplayNameAttribute("")]
        public double 预算费用
        {
            get { return _预算费用; }
            set
            {			
                if (_预算费用 as object == null || !_预算费用.Equals(value))
                {
                    _预算费用 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：开工日期
        /// 属性描述：
        /// 字段信息：[开工日期],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime 开工日期
        {
            get { return _开工日期; }
            set
            {			
                if (_开工日期 as object == null || !_开工日期.Equals(value))
                {
                    _开工日期 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：完成日期
        /// 属性描述：
        /// 字段信息：[完成日期],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime 完成日期
        {
            get { return _完成日期; }
            set
            {			
                if (_完成日期 as object == null || !_完成日期.Equals(value))
                {
                    _完成日期 = value;
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
