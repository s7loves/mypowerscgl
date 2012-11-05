/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-11-5 9:43:04
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PJ_21dyjcdcbk]业务实体类
    ///对应表名:PJ_21dyjcdcbk
    /// </summary>
    [Serializable]
    public class PJ_21dyjcdcbk
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _gdscode=String.Empty; 
        private string _gdsname=String.Empty; 
        private string _year=String.Empty; 
        private string _type=String.Empty; 
        private int _num=0; 
        private string _zzxh=String.Empty; 
        private string _by1=String.Empty; 
        private string _by2=String.Empty; 
        private string _by3=String.Empty; 
        private string _by4=String.Empty; 
        private string _createman=String.Empty; 
        private DateTime _createdate=new DateTime(1900,1,1);   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：ID
        /// 属性描述：记录ID
        /// 字段信息：[ID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("记录ID")]
        public string ID
        {
            get { return _id; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[记录ID]长度不能大于50!");
                if (_id as object == null || !_id.Equals(value))
                {
                    _id = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：GdsCode
        /// 属性描述：供电所代码
        /// 字段信息：[GdsCode],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("供电所代码")]
        public string GdsCode
        {
            get { return _gdscode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[供电所代码]长度不能大于50!");
                if (_gdscode as object == null || !_gdscode.Equals(value))
                {
                    _gdscode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：GdsName
        /// 属性描述：供电所名称
        /// 字段信息：[GdsName],nvarchar
        /// </summary> 
        [DisplayNameAttribute("供电所名称")]
        public string GdsName
        {
            get { return _gdsname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[供电所名称]长度不能大于50!");
                if (_gdsname as object == null || !_gdsname.Equals(value))
                {
                    _gdsname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：year
        /// 属性描述：年度
        /// 字段信息：[year],nvarchar
        /// </summary>
        [DisplayNameAttribute("年度")]
        public string year
        {
            get { return _year; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[年度]长度不能大于50!");
                if (_year as object == null || !_year.Equals(value))
                {
                    _year = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：type
        /// 属性描述：电压检测点类型
        /// 字段信息：[type],nvarchar
        /// </summary>
        [DisplayNameAttribute("电压检测点类型")]
        public string type
        {
            get { return _type; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电压检测点类型]长度不能大于50!");
                if (_type as object == null || !_type.Equals(value))
                {
                    _type = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：num
        /// 属性描述：电压检测点序号
        /// 字段信息：[num],int
        /// </summary>
        [DisplayNameAttribute("电压检测点序号")]
        public int num
        {
            get { return _num; }
            set
            {			
                if (_num as object == null || !_num.Equals(value))
                {
                    _num = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zzxh
        /// 属性描述：装置型号
        /// 字段信息：[zzxh],nvarchar
        /// </summary>
        [DisplayNameAttribute("装置型号")]
        public string zzxh
        {
            get { return _zzxh; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[装置型号]长度不能大于50!");
                if (_zzxh as object == null || !_zzxh.Equals(value))
                {
                    _zzxh = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：by1
        /// 属性描述：
        /// 字段信息：[by1],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string by1
        {
            get { return _by1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_by1 as object == null || !_by1.Equals(value))
                {
                    _by1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：by2
        /// 属性描述：
        /// 字段信息：[by2],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string by2
        {
            get { return _by2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_by2 as object == null || !_by2.Equals(value))
                {
                    _by2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：by3
        /// 属性描述：
        /// 字段信息：[by3],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string by3
        {
            get { return _by3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_by3 as object == null || !_by3.Equals(value))
                {
                    _by3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：by4
        /// 属性描述：
        /// 字段信息：[by4],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("")]
        public string by4
        {
            get { return _by4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[]长度不能大于50!");
                if (_by4 as object == null || !_by4.Equals(value))
                {
                    _by4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateMan
        /// 属性描述：填写人
        /// 字段信息：[CreateMan],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("填写人")]
        public string CreateMan
        {
            get { return _createman; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[填写人]长度不能大于10!");
                if (_createman as object == null || !_createman.Equals(value))
                {
                    _createman = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：CreateDate
        /// 属性描述：填写日期
        /// 字段信息：[CreateDate],datetime
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("填写日期")]
        public DateTime CreateDate
        {
            get { return _createdate; }
            set
            {			
                if (_createdate as object == null || !_createdate.Equals(value))
                {
                    _createdate = value;
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
