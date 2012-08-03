/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:kcgl
模块:库存管理
Itop.com 版权所有
生成者：Rabbit
生成时间:2012-8-3 12:16:24
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Kcgl.Model
{
    /// <summary>
    ///[v库存汇总表]业务实体类
    ///对应表名:v库存汇总表
    /// </summary>
    [Serializable]
    public class v库存汇总表
    {
        
        #region Private 成员
        private string _材料名称=String.Empty; 
        private string _规格及型号=String.Empty; 
        private string _计量单位=String.Empty; 
        private double _库存数量=0; 
        private string _备注=String.Empty;   
        #endregion
		
        #region const 成员
        public const string f_材料名称= "材料名称"; 
        public const string f_规格及型号= "规格及型号"; 
        public const string f_计量单位= "计量单位"; 
        public const string f_库存数量= "库存数量"; 
        public const string f_备注= "备注";   
        #endregion
  
        #region Public 成员
   
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
        /// 属性名称：备注
        /// 属性描述：
        /// 字段信息：[备注],varchar
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
