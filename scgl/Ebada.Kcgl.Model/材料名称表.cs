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
    ///[材料名称表]业务实体类
    ///对应表名:材料名称表
    /// </summary>
    [Serializable]
    public class 材料名称表
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private int _序号=0; 
        private string _材料代码=String.Empty; 
        private string _材料名称=String.Empty; 
        private string _计量单位=String.Empty; 
        private string _规格及型号=String.Empty; 
        private string _parentid=String.Empty;   
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
        /// 属性名称：材料代码
        /// 属性描述：
        /// 字段信息：[材料代码],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 材料代码
        {
            get { return _材料代码; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[材料代码]长度不能大于50!");
                if (_材料代码 as object == null || !_材料代码.Equals(value))
                {
                    _材料代码 = value;
                }
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
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[材料名称]长度不能大于50!");
                if (_材料名称 as object == null || !_材料名称.Equals(value))
                {
                    _材料名称 = value;
                }
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
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[计量单位]长度不能大于50!");
                if (_计量单位 as object == null || !_计量单位.Equals(value))
                {
                    _计量单位 = value;
                }
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
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[规格及型号]长度不能大于50!");
                if (_规格及型号 as object == null || !_规格及型号.Equals(value))
                {
                    _规格及型号 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ParentID
        /// 属性描述：
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[ParentID]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
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
