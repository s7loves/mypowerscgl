/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Itop隐患排查
模块:系统平台
Itop.com 版权所有
生成者：Rabbit
生成时间:2011-12-19 17:01:31
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Itop.YHPC.Model
{
    /// <summary>
    ///[PX_Objects]业务实体类
    ///对应表名:PX_Objects
    /// </summary>
    [Serializable]
    public class PX_Objects
    {
        
        #region Private 成员
        private string _layerid=String.Empty; 
        private string _id=Newid(); 
        private string _sbid=String.Empty; 
        private string _symbolid=String.Empty; 
        private int _seq=0; 
        private string _text=String.Empty; 
        private string _type=String.Empty; 
        private string _points=String.Empty; 
        private byte[] _exdata=new byte[]{}; 
        private double _x=0; 
        private double _y=0; 
        private double _width=0; 
        private double _height=0; 
        private byte[] _rowstate=new byte[]{};   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：layerid
        /// 属性描述：
        /// 字段信息：[layerid],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string layerid
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
        /// 属性名称：id
        /// 属性描述：
        /// 字段信息：[id],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string id
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
        /// 属性名称：sbid
        /// 属性描述：
        /// 字段信息：[sbid],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string sbid
        {
            get { return _sbid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_sbid as object == null || !_sbid.Equals(value))
                {
                    _sbid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：symbolid
        /// 属性描述：
        /// 字段信息：[symbolid],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string symbolid
        {
            get { return _symbolid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_symbolid as object == null || !_symbolid.Equals(value))
                {
                    _symbolid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：seq
        /// 属性描述：
        /// 字段信息：[seq],int
        /// </summary>
        [DisplayNameAttribute("")]
        public int seq
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
        /// 属性名称：text
        /// 属性描述：
        /// 字段信息：[text],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string text
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
        /// 属性名称：type
        /// 属性描述：
        /// 字段信息：[type],nvarchar
        /// </summary>
        [DisplayNameAttribute("")]
        public string type
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
        /// 属性名称：points
        /// 属性描述：
        /// 字段信息：[points],ntext
        /// </summary>
        [DisplayNameAttribute("")]
        public string points
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
  
        /// <summary>
        /// 属性名称：X
        /// 属性描述：
        /// 字段信息：[X],float
        /// </summary>
        [DisplayNameAttribute("")]
        public double X
        {
            get { return _x; }
            set
            {			
                if (_x as object == null || !_x.Equals(value))
                {
                    _x = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Y
        /// 属性描述：
        /// 字段信息：[Y],float
        /// </summary>
        [DisplayNameAttribute("")]
        public double Y
        {
            get { return _y; }
            set
            {			
                if (_y as object == null || !_y.Equals(value))
                {
                    _y = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Width
        /// 属性描述：
        /// 字段信息：[Width],float
        /// </summary>
        [DisplayNameAttribute("")]
        public double Width
        {
            get { return _width; }
            set
            {			
                if (_width as object == null || !_width.Equals(value))
                {
                    _width = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Height
        /// 属性描述：
        /// 字段信息：[Height],float
        /// </summary>
        [DisplayNameAttribute("")]
        public double Height
        {
            get { return _height; }
            set
            {			
                if (_height as object == null || !_height.Equals(value))
                {
                    _height = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Rowstate
        /// 属性描述：
        /// 字段信息：[Rowstate],timestamp
        /// </summary>
        [DisplayNameAttribute("")]
        public byte[] Rowstate
        {
            get { return _rowstate; }
            set
            {			
                if (_rowstate as object == null || !_rowstate.Equals(value))
                {
                    _rowstate = value;
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
