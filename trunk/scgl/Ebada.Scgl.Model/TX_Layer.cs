/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-12-19 21:04:16
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[TX_Layer]业务实体类
    ///对应表名:TX_Layer
    /// </summary>
    [Serializable]
    public class TX_Layer
    {
        
        #region Private 成员
        private string _proid=String.Empty; 
        private string _layerid=Newid(); 
        private string _parentid=String.Empty; 
        private string _layername=String.Empty; 
        private string _description=String.Empty; 
        private int _layerorder=0; 
        private string _layertype=String.Empty; 
        private string _exattribute=String.Empty; 
        private byte[] _exdata=new byte[]{};   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ProID
        /// 属性描述：
        /// 字段信息：[ProID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string ProID
        {
            get { return _proid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_proid as object == null || !_proid.Equals(value))
                {
                    _proid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LayerID
        /// 属性描述：
        /// 字段信息：[LayerID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string LayerID
        {
            get { return _layerid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_layerid as object == null || !_layerid.Equals(value))
                {
                    _layerid = value;
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
                throw new Exception("[]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LayerName
        /// 属性描述：
        /// 字段信息：[LayerName],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string LayerName
        {
            get { return _layername; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[]长度不能大于250!");
                if (_layername as object == null || !_layername.Equals(value))
                {
                    _layername = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Description
        /// 属性描述：
        /// 字段信息：[Description],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Description
        {
            get { return _description; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[]长度不能大于250!");
                if (_description as object == null || !_description.Equals(value))
                {
                    _description = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LayerOrder
        /// 属性描述：
        /// 字段信息：[LayerOrder],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int LayerOrder
        {
            get { return _layerorder; }
            set
            {			
                if (_layerorder as object == null || !_layerorder.Equals(value))
                {
                    _layerorder = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LayerType
        /// 属性描述：
        /// 字段信息：[LayerType],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string LayerType
        {
            get { return _layertype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_layertype as object == null || !_layertype.Equals(value))
                {
                    _layertype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ExAttribute
        /// 属性描述：
        /// 字段信息：[ExAttribute],ntext
        /// </summary>
        [DisplayNameAttribute("")]
        public string ExAttribute
        {
            get { return _exattribute; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[]长度不能大于1073741823!");
                if (_exattribute as object == null || !_exattribute.Equals(value))
                {
                    _exattribute = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ExData
        /// 属性描述：
        /// 字段信息：[ExData],image
        /// </summary>
        [DisplayNameAttribute("")]
        public byte[] ExData
        {
            get { return _exdata; }
            set
            {			
                if (_exdata as object == null || !_exdata.Equals(value))
                {
                    _exdata = value;
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
