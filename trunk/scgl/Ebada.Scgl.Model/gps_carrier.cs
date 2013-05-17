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
    ///[gps_carrier]业务实体类
    ///对应表名:gps_carrier
    /// </summary>
    [Serializable]
    public class gps_carrier
    {
        
        #region Private 成员
        private string _carrier_id=Newid(); 
        private string _carrier_type=String.Empty; 
        private string _model=String.Empty; 
        private string _year=String.Empty; 
        private string _color=String.Empty; 
        private string _plate=String.Empty; 
        private string _owner=String.Empty; 
        private string _driver=String.Empty; 
        private string _phone=String.Empty; 
        private string _last_modify=String.Empty; 
        private byte[] _rowversion=new byte[]{}; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：carrier_id
        /// 属性描述：
        /// 字段信息：[carrier_id],nvarchar
        /// </summary>
        [Browsable(false)]
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
        /// 属性名称：carrier_type
        /// 属性描述：载体类型,car
        /// 字段信息：[carrier_type],nvarchar
        /// </summary>
        [DisplayNameAttribute("载体类型")]
        public string carrier_type
        {
            get { return _carrier_type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[载体类型]长度不能大于50!");
                if (_carrier_type as object == null || !_carrier_type.Equals(value))
                {
                    _carrier_type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：model
        /// 属性描述：型号
        /// 字段信息：[model],nvarchar
        /// </summary>
        [DisplayNameAttribute("型号")]
        public string model
        {
            get { return _model; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[型号]长度不能大于50!");
                if (_model as object == null || !_model.Equals(value))
                {
                    _model = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：year
        /// 属性描述：年份
        /// 字段信息：[year],nvarchar
        /// </summary>
        [DisplayNameAttribute("年份")]
        public string year
        {
            get { return _year; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[年份]长度不能大于50!");
                if (_year as object == null || !_year.Equals(value))
                {
                    _year = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：color
        /// 属性描述：颜色
        /// 字段信息：[color],nvarchar
        /// </summary>
        [DisplayNameAttribute("颜色")]
        public string color
        {
            get { return _color; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[颜色]长度不能大于50!");
                if (_color as object == null || !_color.Equals(value))
                {
                    _color = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：plate
        /// 属性描述：车牌号
        /// 字段信息：[plate],nvarchar
        /// </summary>
        [DisplayNameAttribute("车牌号")]
        public string plate
        {
            get { return _plate; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[车牌号]长度不能大于50!");
                if (_plate as object == null || !_plate.Equals(value))
                {
                    _plate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：owner
        /// 属性描述：车辆所属
        /// 字段信息：[owner],nvarchar
        /// </summary>
        [DisplayNameAttribute("车辆所属")]
        public string owner
        {
            get { return _owner; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[车辆所属]长度不能大于50!");
                if (_owner as object == null || !_owner.Equals(value))
                {
                    _owner = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：driver
        /// 属性描述：司机
        /// 字段信息：[driver],nvarchar
        /// </summary>
        [DisplayNameAttribute("司机")]
        public string driver
        {
            get { return _driver; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[司机]长度不能大于50!");
                if (_driver as object == null || !_driver.Equals(value))
                {
                    _driver = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：phone
        /// 属性描述：联系电话
        /// 字段信息：[phone],nvarchar
        /// </summary>
        [DisplayNameAttribute("联系电话")]
        public string phone
        {
            get { return _phone; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[联系电话]长度不能大于50!");
                if (_phone as object == null || !_phone.Equals(value))
                {
                    _phone = value;
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
        /// 属性描述：
        /// 字段信息：[rowversion],timestamp
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("rowversion")]
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
