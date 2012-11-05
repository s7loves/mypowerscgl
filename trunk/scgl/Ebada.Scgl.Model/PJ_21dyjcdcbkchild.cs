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
    ///[PJ_21dyjcdcbkchild]业务实体类
    ///对应表名:PJ_21dyjcdcbkchild
    /// </summary>
    [Serializable]
    public class PJ_21dyjcdcbkchild
    {
        
        #region Private 成员
        private string _id=Newid(); 
        private string _parentid=String.Empty; 
        private string _gdscode=String.Empty; 
        private string _gdsname=String.Empty; 
        private string _year=String.Empty; 
        private int _month=0; 
        private int _alltime=0; 
        private int _uptime=0; 
        private int _downtime=0; 
        private int _hegetime=0; 
        private double _csxl=0; 
        private double _cxxl=0; 
        private double _hegel=0; 
        private double _bignumvalue=0; 
        private DateTime _bigshowtime=new DateTime(1900,1,1); 
        private double _minnumvalue=0; 
        private DateTime _minshowtime=new DateTime(1900,1,1); 
        private string _cbr=String.Empty; 
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
        /// 属性名称：ParentID
        /// 属性描述：父ID
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("父ID")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[父ID]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
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
        [Browsable(false)]
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
        [Browsable(false)]
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
        /// 属性名称：month
        /// 属性描述：月份
        /// 字段信息：[month],int
        /// </summary>
        [DisplayNameAttribute("月份")]
        public int month
        {
            get { return _month; }
            set
            {			
                if (_month as object == null || !_month.Equals(value))
                {
                    _month = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：alltime
        /// 属性描述：总时间
        /// 字段信息：[alltime],int
        /// </summary>
        [DisplayNameAttribute("总时间")]
        public int alltime
        {
            get { return _alltime; }
            set
            {			
                if (_alltime as object == null || !_alltime.Equals(value))
                {
                    _alltime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：uptime
        /// 属性描述：超上限
        /// 字段信息：[uptime],int
        /// </summary>
        [DisplayNameAttribute("超上限")]
        public int uptime
        {
            get { return _uptime; }
            set
            {			
                if (_uptime as object == null || !_uptime.Equals(value))
                {
                    _uptime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：downtime
        /// 属性描述：超下限
        /// 字段信息：[downtime],int
        /// </summary>
        [DisplayNameAttribute("超下限")]
        public int downtime
        {
            get { return _downtime; }
            set
            {			
                if (_downtime as object == null || !_downtime.Equals(value))
                {
                    _downtime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：hegetime
        /// 属性描述：合格时间
        /// 字段信息：[hegetime],int
        /// </summary>
        [DisplayNameAttribute("合格时间")]
        public int hegetime
        {
            get { return _hegetime; }
            set
            {			
                if (_hegetime as object == null || !_hegetime.Equals(value))
                {
                    _hegetime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：csxl
        /// 属性描述：超上限率
        /// 字段信息：[csxl],float
        /// </summary>
        [DisplayNameAttribute("超上限率")]
        public double csxl
        {
            get { return _csxl; }
            set
            {			
                if (_csxl as object == null || !_csxl.Equals(value))
                {
                    _csxl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cxxl
        /// 属性描述：超下限率
        /// 字段信息：[cxxl],float
        /// </summary>
        [DisplayNameAttribute("超下限率")]
        public double cxxl
        {
            get { return _cxxl; }
            set
            {			
                if (_cxxl as object == null || !_cxxl.Equals(value))
                {
                    _cxxl = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：hegel
        /// 属性描述：合格率
        /// 字段信息：[hegel],float
        /// </summary>
        [DisplayNameAttribute("合格率")]
        public double hegel
        {
            get { return _hegel; }
            set
            {			
                if (_hegel as object == null || !_hegel.Equals(value))
                {
                    _hegel = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bignumvalue
        /// 属性描述：最大电压数值
        /// 字段信息：[bignumvalue],float
        /// </summary>
        [DisplayNameAttribute("最大电压数值")]
        public double bignumvalue
        {
            get { return _bignumvalue; }
            set
            {			
                if (_bignumvalue as object == null || !_bignumvalue.Equals(value))
                {
                    _bignumvalue = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bigshowtime
        /// 属性描述：最大电压出显时间
        /// 字段信息：[bigshowtime],datetime
        /// </summary>
        [DisplayNameAttribute("最大电压出显时间")]
        public DateTime bigshowtime
        {
            get { return _bigshowtime; }
            set
            {			
                if (_bigshowtime as object == null || !_bigshowtime.Equals(value))
                {
                    _bigshowtime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：minnumvalue
        /// 属性描述：最小电压数值
        /// 字段信息：[minnumvalue],float
        /// </summary>
        [DisplayNameAttribute("最小电压数值")]
        public double minnumvalue
        {
            get { return _minnumvalue; }
            set
            {			
                if (_minnumvalue as object == null || !_minnumvalue.Equals(value))
                {
                    _minnumvalue = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：minshowtime
        /// 属性描述：最小电压出显时间
        /// 字段信息：[minshowtime],datetime
        /// </summary>
        [DisplayNameAttribute("最小电压出显时间")]
        public DateTime minshowtime
        {
            get { return _minshowtime; }
            set
            {			
                if (_minshowtime as object == null || !_minshowtime.Equals(value))
                {
                    _minshowtime = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cbr
        /// 属性描述：抄表人
        /// 字段信息：[cbr],nvarchar
        /// </summary>
        [DisplayNameAttribute("抄表人")]
        public string cbr
        {
            get { return _cbr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[抄表人]长度不能大于50!");
                if (_cbr as object == null || !_cbr.Equals(value))
                {
                    _cbr = value;
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
