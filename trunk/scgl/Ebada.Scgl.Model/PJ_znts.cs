/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-3-12 20:13:05
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_znts]业务实体类
    ///对应表名:PJ_znts
    /// </summary>
    [Serializable]
    public class PJ_znts
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _szdx=String.Empty; 
        private string _sql=String.Empty; 
        private string _type=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：唯一ID
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("唯一ID")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[唯一ID]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：szdx
        /// 属性描述：标题
        /// 字段信息：[szdx],nvarchar
        /// </summary>
        [DisplayNameAttribute("标题")]
        public string szdx
        {
            get { return _szdx; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[标题]长度不能大于500!");
                if (_szdx as object == null || !_szdx.Equals(value))
                {
                    _szdx = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sql
        /// 属性描述：SQL信息
        /// 字段信息：[sql],nvarchar
        /// </summary>
        [DisplayNameAttribute("SQL信息")]
        public string sql
        {
            get { return _sql; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[SQL信息]长度不能大于1073741823!");
                if (_sql as object == null || !_sql.Equals(value))
                {
                    _sql = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：type
        /// 属性描述：类型
        /// 字段信息：[type],nvarchar
        /// </summary>
        [DisplayNameAttribute("类型")]
        public string type
        {
            get { return _type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[类型]长度不能大于50!");
                if (_type as object == null || !_type.Equals(value))
                {
                    _type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c1
        /// 属性描述：备用
        /// 字段信息：[c1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用")]
        public string c1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用]长度不能大于50!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c2
        /// 属性描述：备用
        /// 字段信息：[c2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用")]
        public string c2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用]长度不能大于50!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c3
        /// 属性描述：备用
        /// 字段信息：[c3],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用")]
        public string c3
        {
            get { return _c3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备用]长度不能大于50!");
                if (_c3 as object == null || !_c3.Equals(value))
                {
                    _c3 = value;
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
