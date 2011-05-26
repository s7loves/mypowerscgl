/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-26 20:54:00
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_gtsb]业务实体类
    ///对应表名:PS_gtsb
    /// </summary>
    [Serializable]
    public class PS_gtsb
    {
        
        #region Private 成员
        private string _gtid=String.Empty; 
        private string _sbid=Newid(); 
        private string _sbcode=String.Empty; 
        private string _sbtype=String.Empty; 
        private string _sbmodle=String.Empty; 
        private string _sbname=String.Empty; 
        private short _sbnumber=0; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty; 
        private string _c4=String.Empty; 
        private string _c5=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：gtID
        /// 属性描述：杆塔ID
        /// 字段信息：[gtID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("杆塔ID")]
        public string gtID
        {
            get { return _gtid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[杆塔ID]长度不能大于50!");
                if (_gtid as object == null || !_gtid.Equals(value))
                {
                    _gtid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbID
        /// 属性描述：设备ID
        /// 字段信息：[sbID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("设备ID")]
        public string sbID
        {
            get { return _sbid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备ID]长度不能大于50!");
                if (_sbid as object == null || !_sbid.Equals(value))
                {
                    _sbid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbCode
        /// 属性描述：设备编号
        /// 字段信息：[sbCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备编号")]
        public string sbCode
        {
            get { return _sbcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备编号]长度不能大于50!");
                if (_sbcode as object == null || !_sbcode.Equals(value))
                {
                    _sbcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbType
        /// 属性描述：设备种类
        /// 字段信息：[sbType],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备种类")]
        public string sbType
        {
            get { return _sbtype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备种类]长度不能大于50!");
                if (_sbtype as object == null || !_sbtype.Equals(value))
                {
                    _sbtype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbModle
        /// 属性描述：设备型号
        /// 字段信息：[sbModle],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备型号")]
        public string sbModle
        {
            get { return _sbmodle; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备型号]长度不能大于50!");
                if (_sbmodle as object == null || !_sbmodle.Equals(value))
                {
                    _sbmodle = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbName
        /// 属性描述：设备名称
        /// 字段信息：[sbName],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备名称")]
        public string sbName
        {
            get { return _sbname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备名称]长度不能大于50!");
                if (_sbname as object == null || !_sbname.Equals(value))
                {
                    _sbname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sbNumber
        /// 属性描述：设备数量
        /// 字段信息：[sbNumber],smallint
        /// </summary>
        [DisplayNameAttribute("设备数量")]
        public short sbNumber
        {
            get { return _sbnumber; }
            set
            {			
                if (_sbnumber as object == null || !_sbnumber.Equals(value))
                {
                    _sbnumber = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：C1
        /// 属性描述：设备参数
        /// 字段信息：[C1],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备参数")]
        public string C1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备参数]长度不能大于50!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：C2
        /// 属性描述：设备参数2
        /// 字段信息：[C2],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备参数2")]
        public string C2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备参数2]长度不能大于50!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：C3
        /// 属性描述：设备参数3
        /// 字段信息：[C3],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备参数3")]
        public string C3
        {
            get { return _c3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备参数3]长度不能大于50!");
                if (_c3 as object == null || !_c3.Equals(value))
                {
                    _c3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：C4
        /// 属性描述：设备参数4
        /// 字段信息：[C4],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备参数4")]
        public string C4
        {
            get { return _c4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备参数4]长度不能大于50!");
                if (_c4 as object == null || !_c4.Equals(value))
                {
                    _c4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：C5
        /// 属性描述：设备参数5
        /// 字段信息：[C5],nvarchar
        /// </summary>
        [DisplayNameAttribute("设备参数5")]
        public string C5
        {
            get { return _c5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[设备参数5]长度不能大于50!");
                if (_c5 as object == null || !_c5.Equals(value))
                {
                    _c5 = value;
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
