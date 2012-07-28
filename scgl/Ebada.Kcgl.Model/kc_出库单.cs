/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:kcgl
模块:库存管理
Itop.com 版权所有
生成者：Rabbit
生成时间:2012-7-28 15:12:36
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Kcgl.Model
{
    /// <summary>
    ///[kc_出库单]业务实体类
    ///对应表名:kc_出库单
    /// </summary>
    [Serializable]
    public class kc_出库单
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _出库单号=String.Empty; 
        private DateTime _出库时间=new DateTime(1900,1,1); 
        private string _工程项目_id=String.Empty; 
        private string _工程类别_id=String.Empty; 
        private string _出库单位_id=String.Empty; 
        private string _提供人=String.Empty;   
        #endregion
		
        #region const 成员
        public const string f_ID= "ID"; 
        public const string f_出库单号= "出库单号"; 
        public const string f_出库时间= "出库时间"; 
        public const string f_工程项目_ID= "工程项目_ID"; 
        public const string f_工程类别_ID= "工程类别_ID"; 
        public const string f_出库单位_ID= "出库单位_ID"; 
        public const string f_提供人= "提供人";   
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
        /// 属性名称：出库单号
        /// 属性描述：
        /// 字段信息：[出库单号],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 出库单号
        {
            get { return _出库单号; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[出库单号]长度不能大于50!");
                if (_出库单号 as object == null || !_出库单号.Equals(value))
                {
                    _出库单号 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：出库时间
        /// 属性描述：
        /// 字段信息：[出库时间],datetime
        /// </summary>
        [DisplayNameAttribute("")]
        public DateTime 出库时间
        {
            get { return _出库时间; }
            set
            {			
                if (_出库时间 as object == null || !_出库时间.Equals(value))
                {
                    _出库时间 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：工程项目_ID
        /// 属性描述：
        /// 字段信息：[工程项目_ID],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 工程项目_ID
        {
            get { return _工程项目_id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[工程项目_ID]长度不能大于50!");
                if (_工程项目_id as object == null || !_工程项目_id.Equals(value))
                {
                    _工程项目_id = value;
                }
            }			 
        }
  
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
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[工程类别_ID]长度不能大于50!");
                if (_工程类别_id as object == null || !_工程类别_id.Equals(value))
                {
                    _工程类别_id = value;
                }
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
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[出库单位_ID]长度不能大于50!");
                if (_出库单位_id as object == null || !_出库单位_id.Equals(value))
                {
                    _出库单位_id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：提供人
        /// 属性描述：
        /// 字段信息：[提供人],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string 提供人
        {
            get { return _提供人; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[提供人]长度不能大于50!");
                if (_提供人 as object == null || !_提供人.Equals(value))
                {
                    _提供人 = value;
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
