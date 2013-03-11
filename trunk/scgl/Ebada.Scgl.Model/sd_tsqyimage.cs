/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-3-11 10:05:54
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[sd_tsqyimage]业务实体类
    ///对应表名:sd_tsqyimage
    /// </summary>
    [Serializable]
    public class sd_tsqyimage
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _parentid=String.Empty; 
        private string _type=String.Empty; 
        private string _text=String.Empty; 
        private byte[] _data=new byte[]{}; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("ID")]
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
        /// 属性名称：ParentID
        /// 属性描述：
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [DisplayNameAttribute("ParentID")]
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
  
        /// <summary>
        /// 属性名称：type
        /// 属性描述：
        /// 字段信息：[type],nvarchar
        /// </summary>
        [DisplayNameAttribute("type")]
        public string type
        {
            get { return _type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[type]长度不能大于50!");
                if (_type as object == null || !_type.Equals(value))
                {
                    _type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：text
        /// 属性描述：
        /// 字段信息：[text],nvarchar
        /// </summary>
        [DisplayNameAttribute("text")]
        public string text
        {
            get { return _text; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[text]长度不能大于500!");
                if (_text as object == null || !_text.Equals(value))
                {
                    _text = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：data
        /// 属性描述：
        /// 字段信息：[data],image
        /// </summary>
        [DisplayNameAttribute("data")]
        public byte[] data
        {
            get { return _data; }
            set
            {			
                if (_data as object == null || !_data.Equals(value))
                {
                    _data = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c1
        /// 属性描述：
        /// 字段信息：[c1],nvarchar
        /// </summary>
        [DisplayNameAttribute("c1")]
        public string c1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[c1]长度不能大于50!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c2
        /// 属性描述：
        /// 字段信息：[c2],nvarchar
        /// </summary>
        [DisplayNameAttribute("c2")]
        public string c2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[c2]长度不能大于50!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
                }
            }			 
        }
  
        #endregion 
  
        #region 方法
        public static string Newid(){
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        public string CreateID(){
            Thread.Sleep(new TimeSpan(100000));//0.1毫秒
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        #endregion		
    }	
}
