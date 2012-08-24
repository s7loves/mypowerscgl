/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:kcgl
模块:库存管理
Itop.com 版权所有
生成者：Rabbit
生成时间:2012-8-24 14:08:52
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Kcgl.Model
{
    /// <summary>
    ///[v出库汇总表_项目除返库]业务实体类
    ///对应表名:v出库汇总表_项目除返库
    /// </summary>
    [Serializable]
    public class v出库汇总表_项目除返库
    {
        
        #region Private 成员
        private string _工程类别_id=String.Empty; 
        private string _材料名称_id=String.Empty; 
        private string _出库单位_id=String.Empty; 
        private string _工程项目名称=String.Empty; 
        private string _材料名称=String.Empty; 
        private string _规格及型号=String.Empty; 
        private string _计量单位=String.Empty; 
        private decimal _单价=0; 
        private double _数量=0; 
        private double _总价=0;   
        #endregion
		
        #region const 成员
        public const string f_工程类别_ID= "工程类别_ID"; 
        public const string f_材料名称_ID= "材料名称_ID"; 
        public const string f_出库单位_ID= "出库单位_ID"; 
        public const string f_工程项目名称= "工程项目名称"; 
        public const string f_材料名称= "材料名称"; 
        public const string f_规格及型号= "规格及型号"; 
        public const string f_计量单位= "计量单位"; 
        public const string f_单价= "单价"; 
        public const string f_数量= "数量"; 
        public const string f_总价= "总价";   
        #endregion
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：工程类别_ID
        /// 属性描述：
        /// 字段信息：[工程类别_ID],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 工程类别_ID
        {
            get { return _工程类别_id; }
            set
            {			
		_工程类别_id=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：材料名称_ID
        /// 属性描述：
        /// 字段信息：[材料名称_ID],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 材料名称_ID
        {
            get { return _材料名称_id; }
            set
            {			
		_材料名称_id=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：出库单位_ID
        /// 属性描述：
        /// 字段信息：[出库单位_ID],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 出库单位_ID
        {
            get { return _出库单位_id; }
            set
            {			
		_出库单位_id=value;	
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
		_工程项目名称=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：材料名称
        /// 属性描述：
        /// 字段信息：[材料名称],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 材料名称
        {
            get { return _材料名称; }
            set
            {			
		_材料名称=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：规格及型号
        /// 属性描述：
        /// 字段信息：[规格及型号],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 规格及型号
        {
            get { return _规格及型号; }
            set
            {			
		_规格及型号=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：计量单位
        /// 属性描述：
        /// 字段信息：[计量单位],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 计量单位
        {
            get { return _计量单位; }
            set
            {			
		_计量单位=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：单价
        /// 属性描述：
        /// 字段信息：[单价],money
        /// </summary>
        [DisplayNameAttribute("")]
        public decimal 单价
        {
            get { return _单价; }
            set
            {			
		_单价=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：数量
        /// 属性描述：
        /// 字段信息：[数量],float
        /// </summary>
        [DisplayNameAttribute("")]
        public double 数量
        {
            get { return _数量; }
            set
            {			
		_数量=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：总价
        /// 属性描述：
        /// 字段信息：[总价],float
        /// </summary>
        [DisplayNameAttribute("")]
        public double 总价
        {
            get { return _总价; }
            set
            {			
		_总价=value;	
            }			 
        }
  
        #endregion 
  		
    }	
}
