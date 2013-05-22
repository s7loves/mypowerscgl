/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-5-17 14:04:11
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[gps_position_now]业务实体类
    ///对应表名:gps_position_now
    /// </summary>
    [Serializable]
    public class gps_position_now
    {
        
        #region Private 成员
        private long _id=0; 
        private int _device_id=0; 
        private DateTime _date=new DateTime(1900,1,1); 
        private double _lng=0; 
        private double _lat=0; 
        private double _lng2=0; 
        private double _lat2=0; 
        private double _altitude=0; 
        private double _speed=0; 
        private double _direction=0; 
        private int _position_type=0; 
        private DateTime _gps_realtime_position=new DateTime(1900,1,1); 
        private string _lbs_info=String.Empty; 
        private double _g_force=0; 
        private double _distance_from_last_gps=0; 
        private int _carrier_acc=0; 
        private int _status_byte=0; 
        private string _status_string=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：id
        /// 属性描述：
        /// 字段信息：[id],bigint
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("id")]
        public long id
        {
            get { return _id; }
            set
            {			
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：device_id
        /// 属性描述：
        /// 字段信息：[device_id],nvarchar
        /// </summary>
        [DisplayNameAttribute("device_id")]
        public int device_id
        {
            get { return _device_id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[device_id]长度不能大于50!");
                if (_device_id as object == null || !_device_id.Equals(value))
                {
                    _device_id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：date
        /// 属性描述：日期
        /// 字段信息：[date],datetime
        /// </summary>
        [DisplayNameAttribute("日期")]
        public DateTime date
        {
            get { return _date; }
            set
            {			
                if (_date as object == null || !_date.Equals(value))
                {
                    _date = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lng
        /// 属性描述：经度
        /// 字段信息：[lng],float
        /// </summary>
        [DisplayNameAttribute("经度")]
        public double lng
        {
            get { return _lng; }
            set
            {			
                if (_lng as object == null || !_lng.Equals(value))
                {
                    _lng = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lat
        /// 属性描述：纬度
        /// 字段信息：[lat],float
        /// </summary>
        [DisplayNameAttribute("纬度")]
        public double lat
        {
            get { return _lat; }
            set
            {			
                if (_lat as object == null || !_lat.Equals(value))
                {
                    _lat = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lng2
        /// 属性描述：经度2
        /// 字段信息：[lng2],float
        /// </summary>
        [DisplayNameAttribute("经度2")]
        public double lng2
        {
            get { return _lng2; }
            set
            {			
                if (_lng2 as object == null || !_lng2.Equals(value))
                {
                    _lng2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lat2
        /// 属性描述：纬度2
        /// 字段信息：[lat2],float
        /// </summary>
        [DisplayNameAttribute("纬度2")]
        public double lat2
        {
            get { return _lat2; }
            set
            {			
                if (_lat2 as object == null || !_lat2.Equals(value))
                {
                    _lat2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：altitude
        /// 属性描述：高度
        /// 字段信息：[altitude],float
        /// </summary>
        [DisplayNameAttribute("高度")]
        public double altitude
        {
            get { return _altitude; }
            set
            {			
                if (_altitude as object == null || !_altitude.Equals(value))
                {
                    _altitude = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：speed
        /// 属性描述：速度
        /// 字段信息：[speed],float
        /// </summary>
        [DisplayNameAttribute("速度")]
        public double speed
        {
            get { return _speed; }
            set
            {			
                if (_speed as object == null || !_speed.Equals(value))
                {
                    _speed = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：direction
        /// 属性描述：方向
        /// 字段信息：[direction],float
        /// </summary>
        [DisplayNameAttribute("方向")]
        public double direction
        {
            get { return _direction; }
            set
            {			
                if (_direction as object == null || !_direction.Equals(value))
                {
                    _direction = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：position_type
        /// 属性描述：定位类型,gps|基站
        /// 字段信息：[position_type],int
        /// </summary>
        [DisplayNameAttribute("定位类型")]
        public int position_type
        {
            get { return _position_type; }
            set
            {			
                if (_position_type as object == null || !_position_type.Equals(value))
                {
                    _position_type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gps_realtime_position
        /// 属性描述：定位时间
        /// 字段信息：[gps_realtime_position],datetime
        /// </summary>
        [DisplayNameAttribute("定位时间")]
        public DateTime gps_realtime_position
        {
            get { return _gps_realtime_position; }
            set
            {			
                if (_gps_realtime_position as object == null || !_gps_realtime_position.Equals(value))
                {
                    _gps_realtime_position = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lbs_info
        /// 属性描述：基站信息
        /// 字段信息：[lbs_info],nvarchar
        /// </summary>
        [DisplayNameAttribute("基站信息")]
        public string lbs_info
        {
            get { return _lbs_info; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[基站信息]长度不能大于500!");
                if (_lbs_info as object == null || !_lbs_info.Equals(value))
                {
                    _lbs_info = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：g_force
        /// 属性描述：
        /// 字段信息：[g_force],float
        /// </summary>
        [DisplayNameAttribute("g_force")]
        public double g_force
        {
            get { return _g_force; }
            set
            {			
                if (_g_force as object == null || !_g_force.Equals(value))
                {
                    _g_force = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：distance_from_last_gps
        /// 属性描述：与前一点距离
        /// 字段信息：[distance_from_last_gps],float
        /// </summary>
        [DisplayNameAttribute("与前一点距离")]
        public double distance_from_last_gps
        {
            get { return _distance_from_last_gps; }
            set
            {			
                if (_distance_from_last_gps as object == null || !_distance_from_last_gps.Equals(value))
                {
                    _distance_from_last_gps = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：carrier_acc
        /// 属性描述：
        /// 字段信息：[carrier_acc],int
        /// </summary>
        [DisplayNameAttribute("carrier_acc")]
        public int carrier_acc
        {
            get { return _carrier_acc; }
            set
            {			
                if (_carrier_acc as object == null || !_carrier_acc.Equals(value))
                {
                    _carrier_acc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：status_byte
        /// 属性描述：
        /// 字段信息：[status_byte],int
        /// </summary>
        [DisplayNameAttribute("status_byte")]
        public int status_byte
        {
            get { return _status_byte; }
            set
            {			
                if (_status_byte as object == null || !_status_byte.Equals(value))
                {
                    _status_byte = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：status_string
        /// 属性描述：
        /// 字段信息：[status_string],nvarchar
        /// </summary>
        [DisplayNameAttribute("status_string")]
        public string status_string
        {
            get { return _status_string; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 500)
                throw new Exception("[status_string]长度不能大于500!");
                if (_status_string as object == null || !_status_string.Equals(value))
                {
                    _status_string = value;
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
  
        /// <summary>
        /// 属性名称：c3
        /// 属性描述：
        /// 字段信息：[c3],nvarchar
        /// </summary>
        [DisplayNameAttribute("c3")]
        public string c3
        {
            get { return _c3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[c3]长度不能大于50!");
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
