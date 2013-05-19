/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-5-19 15:36:43
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[gps_device]业务实体类
    ///对应表名:gps_device
    /// </summary>
    [Serializable]
    public class gps_device
    {
        
        #region Private 成员
        private int _device_id=0; 
        private string _device_serial=String.Empty; 
        private string _device_type=String.Empty; 
        private string _device_model=String.Empty; 
        private DateTime _device_expire=new DateTime(1900,1,1); 
        private string _device_desc=String.Empty; 
        private string _device_state=String.Empty; 
        private DateTime _device_made_date=new DateTime(1900,1,1); 
        private string _software_version=String.Empty; 
        private string _system_version=String.Empty; 
        private string _last_modify=String.Empty; 
        private byte[] _rowversion=new byte[]{}; 
        private string _device_owner=String.Empty; 
        private string _phone_number=String.Empty; 
        private string _sim_id=String.Empty; 
        private string _carrier_id=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：device_id
        /// 属性描述：
        /// 字段信息：[device_id],int
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("device_id")]
        public int device_id
        {
            get { return _device_id; }
            set
            {			
                if (_device_id as object == null || !_device_id.Equals(value))
                {
                    _device_id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：device_serial
        /// 属性描述：设备标识(IMEI)
        /// 字段信息：[device_serial],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备标识(IMEI)")]
        public string device_serial
        {
            get { return _device_serial; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备标识(IMEI)]长度不能大于50!");
                if (_device_serial as object == null || !_device_serial.Equals(value))
                {
                    _device_serial = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：device_type
        /// 属性描述：设备类型
        /// 字段信息：[device_type],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备类型")]
        public string device_type
        {
            get { return _device_type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备类型]长度不能大于50!");
                if (_device_type as object == null || !_device_type.Equals(value))
                {
                    _device_type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：device_model
        /// 属性描述：设备型号
        /// 字段信息：[device_model],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备型号")]
        public string device_model
        {
            get { return _device_model; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备型号]长度不能大于50!");
                if (_device_model as object == null || !_device_model.Equals(value))
                {
                    _device_model = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：device_expire
        /// 属性描述：过期时间
        /// 字段信息：[device_expire],datetime
        /// </summary>
        [DisplayNameAttribute("过期时间")]
        public DateTime device_expire
        {
            get { return _device_expire; }
            set
            {			
                if (_device_expire as object == null || !_device_expire.Equals(value))
                {
                    _device_expire = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：device_desc
        /// 属性描述：描述
        /// 字段信息：[device_desc],nvarchar
        /// </summary>
        [DisplayNameAttribute("描述")]
        public string device_desc
        {
            get { return _device_desc; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[描述]长度不能大于50!");
                if (_device_desc as object == null || !_device_desc.Equals(value))
                {
                    _device_desc = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：device_state
        /// 属性描述：设备状态,0-未启用,1-启用
        /// 字段信息：[device_state],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备状态")]
        public string device_state
        {
            get { return _device_state; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备状态]长度不能大于50!");
                if (_device_state as object == null || !_device_state.Equals(value))
                {
                    _device_state = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：device_made_date
        /// 属性描述：生产时间
        /// 字段信息：[device_made_date],datetime
        /// </summary>
        [DisplayNameAttribute("生产时间")]
        public DateTime device_made_date
        {
            get { return _device_made_date; }
            set
            {			
                if (_device_made_date as object == null || !_device_made_date.Equals(value))
                {
                    _device_made_date = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：software_version
        /// 属性描述：软件版本
        /// 字段信息：[software_version],nvarchar
        /// </summary>
        [DisplayNameAttribute("软件版本")]
        public string software_version
        {
            get { return _software_version; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[软件版本]长度不能大于50!");
                if (_software_version as object == null || !_software_version.Equals(value))
                {
                    _software_version = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：system_version
        /// 属性描述：系统版本
        /// 字段信息：[system_version],nvarchar
        /// </summary>
        [DisplayNameAttribute("系统版本")]
        public string system_version
        {
            get { return _system_version; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[系统版本]长度不能大于50!");
                if (_system_version as object == null || !_system_version.Equals(value))
                {
                    _system_version = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：last_modify
        /// 属性描述：最后修改者
        /// 字段信息：[last_modify],nvarchar
        /// </summary>
        [DisplayNameAttribute("最后修改者")]
        public string last_modify
        {
            get { return _last_modify; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[最后修改者]长度不能大于50!");
                if (_last_modify as object == null || !_last_modify.Equals(value))
                {
                    _last_modify = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：rowversion
        /// 属性描述：最后修改时间
        /// 字段信息：[rowversion],timestamp
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("最后修改时间")]
        public byte[] rowversion
        {
            get { return _rowversion; }
            set
            {			
                if (_rowversion as object == null || !_rowversion.Equals(value))
                {
                    _rowversion = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：device_owner
        /// 属性描述：设备所属
        /// 字段信息：[device_owner],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备所属")]
        public string device_owner
        {
            get { return _device_owner; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备所属]长度不能大于50!");
                if (_device_owner as object == null || !_device_owner.Equals(value))
                {
                    _device_owner = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：phone_number
        /// 属性描述：联系电话
        /// 字段信息：[phone_number],nvarchar
        /// </summary>
        [DisplayNameAttribute("联系电话")]
        public string phone_number
        {
            get { return _phone_number; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[联系电话]长度不能大于50!");
                if (_phone_number as object == null || !_phone_number.Equals(value))
                {
                    _phone_number = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sim_id
        /// 属性描述：
        /// 字段信息：[sim_id],nvarchar
        /// </summary>
        [DisplayNameAttribute("sim_id")]
        public string sim_id
        {
            get { return _sim_id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[sim_id]长度不能大于50!");
                if (_sim_id as object == null || !_sim_id.Equals(value))
                {
                    _sim_id = value;
                }
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
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[carrier_id]长度不能大于50!");
                if (_carrier_id as object == null || !_carrier_id.Equals(value))
                {
                    _carrier_id = value;
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
