/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:kcgl
模块:库存管理
Itop.com 版权所有
生成者：Rabbit
生成时间:2012-8-3 10:17:05
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Kcgl.Model
{
    /// <summary>
    ///[v库存明细表]业务实体类
    ///对应表名:v库存明细表
    /// </summary>
    [Serializable]
    public class v库存明细表
    {
        
        #region Private 成员
        private string _工程类别=String.Empty; 
        private string _材料名称=String.Empty; 
        private string _规格及型号=String.Empty; 
        private string _计量单位=String.Empty; 
        private double _库存数量=0; 
        private decimal _单价=0; 
        private double _总计=0; 
        private string _备注=String.Empty;   
        #endregion
		
        #region const 成员
        public const string f_工程类别= "工程类别"; 
        public const string f_材料名称= "材料名称"; 
        public const string f_规格及型号= "规格及型号"; 
        public const string f_计量单位= "计量单位"; 
        public const string f_库存数量= "库存数量"; 
        public const string f_单价= "单价"; 
        public const string f_总计= "总计"; 
        public const string f_备注= "备注";   
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
        /// 属性名称：库存数量
        /// 属性描述：
        /// 字段信息：[库存数量],float
        /// </summary>
        [DisplayNameAttribute("")]
        public double 库存数量
        {
            get { return _库存数量; }
            set
            {			
		_库存数量=value;	
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
        /// 属性名称：总计
        /// 属性描述：
        /// 字段信息：[总计],float
        /// </summary>
        [DisplayNameAttribute("")]
        public double 总计
        {
            get { return _总计; }
            set
            {			
		_总计=value;	
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
		_备注=value;	
            }			 
        }
  
        #endregion 
  		
    }	
}
