/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:kcgl
模块:库存管理
Itop.com 版权所有
生成者：Rabbit
生成时间:2012-8-2 16:29:31
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Kcgl.Model
{
    /// <summary>
    ///[v工程到货查询表]业务实体类
    ///对应表名:v工程到货查询表
    /// </summary>
    [Serializable]
    public class v工程到货查询表
    {
        
        #region Private 成员
        private string _项目名称=String.Empty; 
        private string _工程类别=String.Empty; 
        private string _材料名称=String.Empty; 
        private string _规格及型号=String.Empty; 
        private string _计量单位=String.Empty; 
        private double _计划数量=0; 
        private double _到货数量=0; 
        private double _差值=0; 
        private DateTime _计划日期=new DateTime(1900,1,1); 
        private DateTime _合同到货日期=new DateTime(1900,1,1); 
        private string _供货厂家=String.Empty; 
        private string _联系人=String.Empty; 
        private string _联系电话=String.Empty;   
        #endregion
		
        #region const 成员
        public const string f_项目名称= "项目名称"; 
        public const string f_工程类别= "工程类别"; 
        public const string f_材料名称= "材料名称"; 
        public const string f_规格及型号= "规格及型号"; 
        public const string f_计量单位= "计量单位"; 
        public const string f_计划数量= "计划数量"; 
        public const string f_到货数量= "到货数量"; 
        public const string f_差值= "差值"; 
        public const string f_计划日期= "计划日期"; 
        public const string f_合同到货日期= "合同到货日期"; 
        public const string f_供货厂家= "供货厂家"; 
        public const string f_联系人= "联系人"; 
        public const string f_联系电话= "联系电话";   
        #endregion
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：项目名称
        /// 属性描述：
        /// 字段信息：[项目名称],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 项目名称
        {
            get { return _项目名称; }
            set
            {			
		_项目名称=value;	
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
        /// 属性名称：计划数量
        /// 属性描述：
        /// 字段信息：[计划数量],float
        /// </summary>
        [DisplayNameAttribute("")]
        public double 计划数量
        {
            get { return _计划数量; }
            set
            {			
		_计划数量=value;	
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
        /// 属性名称：差值
        /// 属性描述：
        /// 字段信息：[差值],float
        /// </summary>
        [DisplayNameAttribute("")]
        public double 差值
        {
            get { return _差值; }
            set
            {			
		_差值=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：计划日期
        /// 属性描述：
        /// 字段信息：[计划日期],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime 计划日期
        {
            get { return _计划日期; }
            set
            {			
		_计划日期=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：合同到货日期
        /// 属性描述：
        /// 字段信息：[合同到货日期],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime 合同到货日期
        {
            get { return _合同到货日期; }
            set
            {			
		_合同到货日期=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：供货厂家
        /// 属性描述：
        /// 字段信息：[供货厂家],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 供货厂家
        {
            get { return _供货厂家; }
            set
            {			
		_供货厂家=value;	
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
		_联系人=value;	
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
		_联系电话=value;	
            }			 
        }
  
        #endregion 
  		
    }	
}
