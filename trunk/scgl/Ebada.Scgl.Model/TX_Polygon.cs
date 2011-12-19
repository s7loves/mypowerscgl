/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Itop隐患排查
模块:系统平台
Itop.com 版权所有
生成者：Rabbit
生成时间:2011-12-19 17:01:32
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Itop.YHPC.Model
{
    /// <summary>
    ///[TX_Polygon]业务实体类
    ///对应表名:TX_Polygon
    /// </summary>
    [Serializable]
    public class TX_Polygon
    {
        
        #region Private 成员
        private string _layerid=String.Empty; 
        private string _id=Newid(); 
        private double _seq=0; 
        private string _text=String.Empty; 
        private string _points=String.Empty; 
        private string _type=String.Empty; 
        private string _exattribute=String.Empty; 
        private string _x=String.Empty; 
        private string _y=String.Empty; 
        private string _width=String.Empty; 
        private string _height=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
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
                throw new Exception("[]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Seq
        /// 属性描述：
        /// 字段信息：[Seq],float
        /// </summary>
        [DisplayNameAttribute("")]
        public double Seq
        {
            get { return _seq; }
            set
            {			
                if (_seq as object == null || !_seq.Equals(value))
                {
                    _seq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Text
        /// 属性描述：
        /// 字段信息：[Text],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Text
        {
            get { return _text; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[]长度不能大于250!");
                if (_text as object == null || !_text.Equals(value))
                {
                    _text = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Points
        /// 属性描述：
        /// 字段信息：[Points],ntext
        /// </summary>
        [DisplayNameAttribute("")]
        public string Points
        {
            get { return _points; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1073741823)
                throw new Exception("[]长度不能大于1073741823!");
                if (_points as object == null || !_points.Equals(value))
                {
                    _points = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Type
        /// 属性描述：
        /// 字段信息：[Type],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string Type
        {
            get { return _type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_type as object == null || !_type.Equals(value))
                {
                    _type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ExAttribute
        /// 属性描述：
        /// 字段信息：[ExAttribute],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string ExAttribute
        {
            get { return _exattribute; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[]长度不能大于500!");
                if (_exattribute as object == null || !_exattribute.Equals(value))
                {
                    _exattribute = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：x
        /// 属性描述：
        /// 字段信息：[x],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string x
        {
            get { return _x; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_x as object == null || !_x.Equals(value))
                {
                    _x = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：y
        /// 属性描述：
        /// 字段信息：[y],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string y
        {
            get { return _y; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_y as object == null || !_y.Equals(value))
                {
                    _y = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：width
        /// 属性描述：
        /// 字段信息：[width],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string width
        {
            get { return _width; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_width as object == null || !_width.Equals(value))
                {
                    _width = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：height
        /// 属性描述：
        /// 字段信息：[height],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string height
        {
            get { return _height; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_height as object == null || !_height.Equals(value))
                {
                    _height = value;
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
