/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-6-5 8:54:05
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[xxgx_ycjc]业务实体类
    ///对应表名:xxgx_ycjc
    /// </summary>
    [Serializable]
    public class xxgx_ycjc
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _sj=String.Empty; 
        private string _xlmc=String.Empty; 
        private string _jldmc=String.Empty; 
        private string _bh=String.Empty; 
        private double? _zxygzdn=0; 
        private double? _fl1zxygdn=0; 
        private double? _fl2zxygdn=0; 
        private double? _fl3zxygdn=0; 
        private double? _fl4zxygdn=0; 
        private double? _fxygzdn=0; 
        private double? _fl1fxygdn=0; 
        private double? _fl2fxygdn=0; 
        private double? _fl3fxygdn=0; 
        private double? _fl4fxygdn=0; 
        private double? _zxwgzdn=0; 
        private double? _fl1zxwgdn=0; 
        private double? _fl2zxwgdn=0; 
        private double? _fl3zxwgdn=0; 
        private double? _fl4zxwgdn=0; 
        private double? _fxwgzdn=0; 
        private double? _fl1fxwgdn=0; 
        private double? _fl2fxwgdn=0; 
        private double? _fl3fxwgdn=0; 
        private double? _fl4fxwgdn=0; 
        private double? _wgdn=0; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：id
        /// 属性描述：
        /// 字段信息：[id],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("id")]
        public string id
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[id]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sj
        /// 属性描述：时间
        /// 字段信息：[sj],nvarchar
        /// </summary>
        [DisplayNameAttribute("时间")]
        public string sj
        {
            get { return _sj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[时间]长度不能大于50!");
                if (_sj as object == null || !_sj.Equals(value))
                {
                    _sj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xlmc
        /// 属性描述：线路名称
        /// 字段信息：[xlmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路名称")]
        public string xlmc
        {
            get { return _xlmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路名称]长度不能大于50!");
                if (_xlmc as object == null || !_xlmc.Equals(value))
                {
                    _xlmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jldmc
        /// 属性描述：计量点名称
        /// 字段信息：[jldmc],nvarchar
        /// </summary>
        [DisplayNameAttribute("计量点名称")]
        public string jldmc
        {
            get { return _jldmc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[计量点名称]长度不能大于50!");
                if (_jldmc as object == null || !_jldmc.Equals(value))
                {
                    _jldmc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bh
        /// 属性描述：表号
        /// 字段信息：[bh],nvarchar
        /// </summary>
        [DisplayNameAttribute("表号")]
        public string bh
        {
            get { return _bh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[表号]长度不能大于50!");
                if (_bh as object == null || !_bh.Equals(value))
                {
                    _bh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zxygzdn
        /// 属性描述：正向有功总电能
        /// 字段信息：[zxygzdn],float
        /// </summary>
        [DisplayNameAttribute("正向有功总电能")]
        public double? zxygzdn
        {
            get { return _zxygzdn; }
            set
            {			
                if (_zxygzdn as object == null || !_zxygzdn.Equals(value))
                {
                    _zxygzdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fl1zxygdn
        /// 属性描述：费率1正向有功电能
        /// 字段信息：[fl1zxygdn],float
        /// </summary>
        [DisplayNameAttribute("费率1正向有功电能")]
        public double? fl1zxygdn
        {
            get { return _fl1zxygdn; }
            set
            {			
                if (_fl1zxygdn as object == null || !_fl1zxygdn.Equals(value))
                {
                    _fl1zxygdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fl2zxygdn
        /// 属性描述：费率2正向有功电能
        /// 字段信息：[fl2zxygdn],float
        /// </summary>
        [DisplayNameAttribute("费率2正向有功电能")]
        public double? fl2zxygdn
        {
            get { return _fl2zxygdn; }
            set
            {			
                if (_fl2zxygdn as object == null || !_fl2zxygdn.Equals(value))
                {
                    _fl2zxygdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fl3zxygdn
        /// 属性描述：费率3正向有功电能
        /// 字段信息：[fl3zxygdn],float
        /// </summary>
        [DisplayNameAttribute("费率3正向有功电能")]
        public double? fl3zxygdn
        {
            get { return _fl3zxygdn; }
            set
            {			
                if (_fl3zxygdn as object == null || !_fl3zxygdn.Equals(value))
                {
                    _fl3zxygdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fl4zxygdn
        /// 属性描述：费率4正向有功电能
        /// 字段信息：[fl4zxygdn],float
        /// </summary>
        [DisplayNameAttribute("费率4正向有功电能")]
        public double? fl4zxygdn
        {
            get { return _fl4zxygdn; }
            set
            {			
                if (_fl4zxygdn as object == null || !_fl4zxygdn.Equals(value))
                {
                    _fl4zxygdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fxygzdn
        /// 属性描述：反向有功总电能
        /// 字段信息：[fxygzdn],float
        /// </summary>
        [DisplayNameAttribute("反向有功总电能")]
        public double? fxygzdn
        {
            get { return _fxygzdn; }
            set
            {			
                if (_fxygzdn as object == null || !_fxygzdn.Equals(value))
                {
                    _fxygzdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fl1fxygdn
        /// 属性描述：费率1反向有功电能
        /// 字段信息：[fl1fxygdn],float
        /// </summary>
        [DisplayNameAttribute("费率1反向有功电能")]
        public double? fl1fxygdn
        {
            get { return _fl1fxygdn; }
            set
            {			
                if (_fl1fxygdn as object == null || !_fl1fxygdn.Equals(value))
                {
                    _fl1fxygdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fl2fxygdn
        /// 属性描述：费率2反向有功电能
        /// 字段信息：[fl2fxygdn],float
        /// </summary>
        [DisplayNameAttribute("费率2反向有功电能")]
        public double? fl2fxygdn
        {
            get { return _fl2fxygdn; }
            set
            {			
                if (_fl2fxygdn as object == null || !_fl2fxygdn.Equals(value))
                {
                    _fl2fxygdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fl3fxygdn
        /// 属性描述：费率3反向有功电能
        /// 字段信息：[fl3fxygdn],float
        /// </summary>
        [DisplayNameAttribute("费率3反向有功电能")]
        public double? fl3fxygdn
        {
            get { return _fl3fxygdn; }
            set
            {			
                if (_fl3fxygdn as object == null || !_fl3fxygdn.Equals(value))
                {
                    _fl3fxygdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fl4fxygdn
        /// 属性描述：费率4反向有功电能
        /// 字段信息：[fl4fxygdn],float
        /// </summary>
        [DisplayNameAttribute("费率4反向有功电能")]
        public double? fl4fxygdn
        {
            get { return _fl4fxygdn; }
            set
            {			
                if (_fl4fxygdn as object == null || !_fl4fxygdn.Equals(value))
                {
                    _fl4fxygdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zxwgzdn
        /// 属性描述：正向无功总电能
        /// 字段信息：[zxwgzdn],float
        /// </summary>
        [DisplayNameAttribute("正向无功总电能")]
        public double? zxwgzdn
        {
            get { return _zxwgzdn; }
            set
            {			
                if (_zxwgzdn as object == null || !_zxwgzdn.Equals(value))
                {
                    _zxwgzdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fl1zxwgdn
        /// 属性描述：费率1正向无功电能
        /// 字段信息：[fl1zxwgdn],float
        /// </summary>
        [DisplayNameAttribute("费率1正向无功电能")]
        public double? fl1zxwgdn
        {
            get { return _fl1zxwgdn; }
            set
            {			
                if (_fl1zxwgdn as object == null || !_fl1zxwgdn.Equals(value))
                {
                    _fl1zxwgdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fl2zxwgdn
        /// 属性描述：费率2正向无功电能
        /// 字段信息：[fl2zxwgdn],float
        /// </summary>
        [DisplayNameAttribute("费率2正向无功电能")]
        public double? fl2zxwgdn
        {
            get { return _fl2zxwgdn; }
            set
            {			
                if (_fl2zxwgdn as object == null || !_fl2zxwgdn.Equals(value))
                {
                    _fl2zxwgdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fl3zxwgdn
        /// 属性描述：费率3正向无功电能
        /// 字段信息：[fl3zxwgdn],float
        /// </summary>
        [DisplayNameAttribute("费率3正向无功电能")]
        public double? fl3zxwgdn
        {
            get { return _fl3zxwgdn; }
            set
            {			
                if (_fl3zxwgdn as object == null || !_fl3zxwgdn.Equals(value))
                {
                    _fl3zxwgdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fl4zxwgdn
        /// 属性描述：费率4正向无功电能
        /// 字段信息：[fl4zxwgdn],float
        /// </summary>
        [DisplayNameAttribute("费率4正向无功电能")]
        public double? fl4zxwgdn
        {
            get { return _fl4zxwgdn; }
            set
            {			
                if (_fl4zxwgdn as object == null || !_fl4zxwgdn.Equals(value))
                {
                    _fl4zxwgdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fxwgzdn
        /// 属性描述：反向无功总电能
        /// 字段信息：[fxwgzdn],float
        /// </summary>
        [DisplayNameAttribute("反向无功总电能")]
        public double? fxwgzdn
        {
            get { return _fxwgzdn; }
            set
            {			
                if (_fxwgzdn as object == null || !_fxwgzdn.Equals(value))
                {
                    _fxwgzdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fl1fxwgdn
        /// 属性描述：费率1反向无功电能
        /// 字段信息：[fl1fxwgdn],float
        /// </summary>
        [DisplayNameAttribute("费率1反向无功电能")]
        public double? fl1fxwgdn
        {
            get { return _fl1fxwgdn; }
            set
            {			
                if (_fl1fxwgdn as object == null || !_fl1fxwgdn.Equals(value))
                {
                    _fl1fxwgdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fl2fxwgdn
        /// 属性描述：费率2反向无功电能
        /// 字段信息：[fl2fxwgdn],float
        /// </summary>
        [DisplayNameAttribute("费率2反向无功电能")]
        public double? fl2fxwgdn
        {
            get { return _fl2fxwgdn; }
            set
            {			
                if (_fl2fxwgdn as object == null || !_fl2fxwgdn.Equals(value))
                {
                    _fl2fxwgdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fl3fxwgdn
        /// 属性描述：费率3反向无功电能
        /// 字段信息：[fl3fxwgdn],float
        /// </summary>
        [DisplayNameAttribute("费率3反向无功电能")]
        public double? fl3fxwgdn
        {
            get { return _fl3fxwgdn; }
            set
            {			
                if (_fl3fxwgdn as object == null || !_fl3fxwgdn.Equals(value))
                {
                    _fl3fxwgdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：fl4fxwgdn
        /// 属性描述：费率4反向无功电能
        /// 字段信息：[fl4fxwgdn],float
        /// </summary>
        [DisplayNameAttribute("费率4反向无功电能")]
        public double? fl4fxwgdn
        {
            get { return _fl4fxwgdn; }
            set
            {			
                if (_fl4fxwgdn as object == null || !_fl4fxwgdn.Equals(value))
                {
                    _fl4fxwgdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：wgdn
        /// 属性描述：无功电能
        /// 字段信息：[wgdn],float
        /// </summary>
        [DisplayNameAttribute("无功电能")]
        public double? wgdn
        {
            get { return _wgdn; }
            set
            {			
                if (_wgdn as object == null || !_wgdn.Equals(value))
                {
                    _wgdn = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c1
        /// 属性描述：备用字段1
        /// 字段信息：[c1],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段1")]
        public string c1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段1]长度不能大于500!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c2
        /// 属性描述：备用字段2
        /// 字段信息：[c2],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段2")]
        public string c2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段2]长度不能大于500!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c3
        /// 属性描述：备用字段3
        /// 字段信息：[c3],nvarchar
        /// </summary>
        [DisplayNameAttribute("备用字段3")]
        public string c3
        {
            get { return _c3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[备用字段3]长度不能大于500!");
                if (_c3 as object == null || !_c3.Equals(value))
                {
                    _c3 = value;
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
