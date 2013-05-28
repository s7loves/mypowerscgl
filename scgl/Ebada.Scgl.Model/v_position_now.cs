/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-5-28 11:07:02
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[v_position_now]业务实体类
    ///对应表名:v_position_now
    /// </summary>
    [Serializable]
    public class v_position_now
    {
        
        #region Private 成员
        private int _device_id=0; 
        private string _carrier_id=String.Empty; 
        private string _device_serial=String.Empty; 
        private string _device_type=String.Empty; 
        private string _device_model=String.Empty; 
        private DateTime _device_expire=new DateTime(1900,1,1); 
        private string _device_desc=String.Empty; 
        private string _device_state=String.Empty; 
        private string _phone_number=String.Empty; 
        private string _device_owner=String.Empty; 
        private string _device_name=String.Empty; 
        private DateTime _date=new DateTime(1900,1,1); 
        private double _lng=0; 
        private double _lat=0; 
        private double _lng2=0; 
        private double _lat2=0; 
        private double _speed=0; 
        private double _direction=0; 
        private int _position_type=0; 
        private DateTime _gps_realtime_position=new DateTime(1900,1,1); 
        private double _distance_from_last_gps=0; 
        private string _adress=String.Empty; 
        private string _carrier_type=String.Empty; 
        private string _model=String.Empty; 
        private string _color=String.Empty; 
        private string _year=String.Empty; 
        private string _owner=String.Empty; 
        private string _driver=String.Empty; 
        private string _phone=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：device_id
        /// 属性描述：
        /// 字段信息：[device_id],int
        /// </summary>
        [DisplayNameAttribute("device_id")]
        public int device_id
        {
            get { return _device_id; }
            set
            {			
		_device_id=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：carrier_id
        /// 属性描述：
        /// 字段信息：[carrier_id],nvarchar
        /// </summary>
        [DisplayNameAttribute("carrier_id")]
        public string carrier_id
        {
            get { return _carrier_id; }
            set
            {			
		_carrier_id=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：device_serial
        /// 属性描述：
        /// 字段信息：[device_serial],nvarchar
        /// </summary>
        [DisplayNameAttribute("device_serial")]
        public string device_serial
        {
            get { return _device_serial; }
            set
            {			
		_device_serial=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：device_type
        /// 属性描述：
        /// 字段信息：[device_type],nvarchar
        /// </summary>
        [DisplayNameAttribute("device_type")]
        public string device_type
        {
            get { return _device_type; }
            set
            {			
		_device_type=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：device_model
        /// 属性描述：
        /// 字段信息：[device_model],nvarchar
        /// </summary>
        [DisplayNameAttribute("device_model")]
        public string device_model
        {
            get { return _device_model; }
            set
            {			
		_device_model=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：device_expire
        /// 属性描述：
        /// 字段信息：[device_expire],datetime
        /// </summary>
        [DisplayNameAttribute("device_expire")]
        public DateTime device_expire
        {
            get { return _device_expire; }
            set
            {			
		_device_expire=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：device_desc
        /// 属性描述：
        /// 字段信息：[device_desc],nvarchar
        /// </summary>
        [DisplayNameAttribute("device_desc")]
        public string device_desc
        {
            get { return _device_desc; }
            set
            {			
		_device_desc=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：device_state
        /// 属性描述：
        /// 字段信息：[device_state],nvarchar
        /// </summary>
        [DisplayNameAttribute("device_state")]
        public string device_state
        {
            get { return _device_state; }
            set
            {			
		_device_state=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：phone_number
        /// 属性描述：
        /// 字段信息：[phone_number],nvarchar
        /// </summary>
        [DisplayNameAttribute("phone_number")]
        public string phone_number
        {
            get { return _phone_number; }
            set
            {			
		_phone_number=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：device_owner
        /// 属性描述：
        /// 字段信息：[device_owner],nvarchar
        /// </summary>
        [DisplayNameAttribute("device_owner")]
        public string device_owner
        {
            get { return _device_owner; }
            set
            {			
		_device_owner=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：device_name
        /// 属性描述：
        /// 字段信息：[device_name],nvarchar
        /// </summary>
        [DisplayNameAttribute("device_name")]
        public string device_name
        {
            get { return _device_name; }
            set
            {			
		_device_name=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：date
        /// 属性描述：
        /// 字段信息：[date],datetime
        /// </summary>
        [DisplayNameAttribute("date")]
        public DateTime date
        {
            get { return _date; }
            set
            {			
		_date=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：lng
        /// 属性描述：
        /// 字段信息：[lng],float
        /// </summary>
        [DisplayNameAttribute("lng")]
        public double lng
        {
            get { return _lng; }
            set
            {			
		_lng=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：lat
        /// 属性描述：
        /// 字段信息：[lat],float
        /// </summary>
        [DisplayNameAttribute("lat")]
        public double lat
        {
            get { return _lat; }
            set
            {			
		_lat=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：lng2
        /// 属性描述：
        /// 字段信息：[lng2],float
        /// </summary>
        [DisplayNameAttribute("lng2")]
        public double lng2
        {
            get { return _lng2; }
            set
            {			
		_lng2=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：lat2
        /// 属性描述：
        /// 字段信息：[lat2],float
        /// </summary>
        [DisplayNameAttribute("lat2")]
        public double lat2
        {
            get { return _lat2; }
            set
            {			
		_lat2=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：speed
        /// 属性描述：
        /// 字段信息：[speed],float
        /// </summary>
        [DisplayNameAttribute("speed")]
        public double speed
        {
            get { return _speed; }
            set
            {			
		_speed=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：direction
        /// 属性描述：
        /// 字段信息：[direction],float
        /// </summary>
        [DisplayNameAttribute("direction")]
        public double direction
        {
            get { return _direction; }
            set
            {			
		_direction=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：position_type
        /// 属性描述：
        /// 字段信息：[position_type],int
        /// </summary>
        [DisplayNameAttribute("position_type")]
        public int position_type
        {
            get { return _position_type; }
            set
            {			
		_position_type=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：gps_realtime_position
        /// 属性描述：
        /// 字段信息：[gps_realtime_position],datetime
        /// </summary>
        [DisplayNameAttribute("gps_realtime_position")]
        public DateTime gps_realtime_position
        {
            get { return _gps_realtime_position; }
            set
            {			
		_gps_realtime_position=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：distance_from_last_gps
        /// 属性描述：
        /// 字段信息：[distance_from_last_gps],float
        /// </summary>
        [DisplayNameAttribute("distance_from_last_gps")]
        public double distance_from_last_gps
        {
            get { return _distance_from_last_gps; }
            set
            {			
		_distance_from_last_gps=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：adress
        /// 属性描述：
        /// 字段信息：[adress],nvarchar
        /// </summary>
        [DisplayNameAttribute("adress")]
        public string adress
        {
            get { return _adress; }
            set
            {			
		_adress=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：carrier_type
        /// 属性描述：
        /// 字段信息：[carrier_type],nvarchar
        /// </summary>
        [DisplayNameAttribute("carrier_type")]
        public string carrier_type
        {
            get { return _carrier_type; }
            set
            {			
		_carrier_type=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：model
        /// 属性描述：
        /// 字段信息：[model],nvarchar
        /// </summary>
        [DisplayNameAttribute("model")]
        public string model
        {
            get { return _model; }
            set
            {			
		_model=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：color
        /// 属性描述：
        /// 字段信息：[color],nvarchar
        /// </summary>
        [DisplayNameAttribute("color")]
        public string color
        {
            get { return _color; }
            set
            {			
		_color=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：year
        /// 属性描述：
        /// 字段信息：[year],nvarchar
        /// </summary>
        [DisplayNameAttribute("year")]
        public string year
        {
            get { return _year; }
            set
            {			
		_year=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：owner
        /// 属性描述：
        /// 字段信息：[owner],nvarchar
        /// </summary>
        [DisplayNameAttribute("owner")]
        public string owner
        {
            get { return _owner; }
            set
            {			
		_owner=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：driver
        /// 属性描述：
        /// 字段信息：[driver],nvarchar
        /// </summary>
        [DisplayNameAttribute("driver")]
        public string driver
        {
            get { return _driver; }
            set
            {			
		_driver=value;	
            }			 
        }
  
        /// <summary>
        /// 属性名称：phone
        /// 属性描述：
        /// 字段信息：[phone],nvarchar
        /// </summary>
        [DisplayNameAttribute("phone")]
        public string phone
        {
            get { return _phone; }
            set
            {			
		_phone=value;	
            }			 
        }
  
        #endregion 
  		
    }	
}
