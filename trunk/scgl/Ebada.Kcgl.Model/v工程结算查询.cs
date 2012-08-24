/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:kcgl
模块:库存管理
Itop.com 版权所有
生成者：Rabbit
生成时间:2012-8-24 14:08:20
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Kcgl.Model
{
    /// <summary>
    ///[v工程结算查询]业务实体类
    ///对应表名:v工程结算查询
    /// </summary>
    [Serializable]
    public class v工程结算查询
    {
        
        #region Private 成员
        private string _工程类别=String.Empty; 
        private string _材料名称=String.Empty; 
        private string _规格及型号=String.Empty; 
        private string _计量单位=String.Empty; 
        private decimal _单价=0; 
        private double _到货数量=0; 
        private double _使用数量=0; 
        private double _结余数量=0; 
        private double _总价=0; 
        private string _id=String.Empty;   
        #endregion
		
        #region const 成员
        public const string f_工程类别= "工程类别"; 
        public const string f_材料名称= "材料名称"; 
        public const string f_规格及型号= "规格及型号"; 
        public const string f_计量单位= "计量单位"; 
        public const string f_单价= "单价"; 
        public const string f_到货数量= "到货数量"; 
        public const string f_使用数量= "使用数量"; 
        public const string f_结余数量= "结余数量"; 
        public const string f_总价= "总价"; 
        public const string f_ID= "ID";   
        #endregion
  
        #region Public 成员
   
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
		_工程类别=value;	
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
        /// 属性名称：到货数量
        /// 属性描述：
        /// 字段信息：[到货数量],float
        /// </summary>
        [DisplayNameAttribute("")]
        public double 到货数量
        {
            get { return _到货数量; }
            set
            {			
		_到货数量=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：使用数量
        /// 属性描述：
        /// 字段信息：[使用数量],float
        /// </summary>
        [DisplayNameAttribute("")]
        public double 使用数量
        {
            get { return _使用数量; }
            set
            {			
		_使用数量=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：结余数量
        /// 属性描述：
        /// 字段信息：[结余数量],float
        /// </summary>
        [DisplayNameAttribute("")]
        public double 结余数量
        {
            get { return _结余数量; }
            set
            {			
		_结余数量=value;	
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
  
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ID
        {
            get { return _id; }
            set
            {			
		_id=value;	
            }			 
        }
  
        #endregion 
  		
    }	
}
