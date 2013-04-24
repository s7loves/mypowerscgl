/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-4-19 8:51:29
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_gt]业务实体类
    ///对应表名:PS_gt
    /// </summary>
    [Serializable]
    public class PS_gt
    {
        
        #region Private 成员
        private string _gtid=Newid(); 
        private string _linecode=String.Empty; 
        private string _gtcode=String.Empty; 
        private string _gth=String.Empty; 
        private string _gttype=String.Empty; 
        private string _gtmodle=String.Empty; 
        private decimal _gtheight=0; 
        private decimal _gtlon=0; 
        private decimal _gtlat=0; 
        private int _gtelev=0; 
        private int _x54=0; 
        private int _y54=0; 
        private decimal _gtspan=0; 
        private decimal _gtms=0; 
        private string _gtzjfx=(""); 
        private string _gtzj=(""); 
        private string _gtjg=("否"); 
        private string _imageid=(""); 
        private string _dxplfs=(""); 
        private string _gtnode=String.Empty; 
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
        /// 属性名称：LineCode
        /// 属性描述：线路编号
        /// 字段信息：[LineCode],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("线路编号")]
        public string LineCode
        {
            get { return _linecode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路编号]长度不能大于50!");
                if (_linecode as object == null || !_linecode.Equals(value))
                {
                    _linecode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtCode
        /// 属性描述：杆塔编号,线路编号+杆塔号
        /// 字段信息：[gtCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("杆塔编号")]
        public string gtCode
        {
            get { return _gtcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[杆塔编号]长度不能大于50!");
                if (_gtcode as object == null || !_gtcode.Equals(value))
                {
                    _gtcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gth
        /// 属性描述：杆塔号
        /// 字段信息：[gth],nvarchar
        /// </summary>
        [DisplayNameAttribute("杆塔序号")]
        public string gth
        {
            get { return _gth; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                    throw new Exception("[杆塔序号]长度不能大于10!");
                if (_gth as object == null || !_gth.Equals(value))
                {
                    _gth = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtType
        /// 属性描述：杆塔类别
        /// 字段信息：[gtType],nvarchar
        /// </summary>
        [DisplayNameAttribute("杆塔类别")]
        public string gtType
        {
            get { return _gttype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[杆塔类别]长度不能大于50!");
                if (_gttype as object == null || !_gttype.Equals(value))
                {
                    _gttype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtModle
        /// 属性描述：型号
        /// 字段信息：[gtModle],nvarchar
        /// </summary>
        [DisplayNameAttribute("型号")]
        public string gtModle
        {
            get { return _gtmodle; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[型号]长度不能大于50!");
                if (_gtmodle as object == null || !_gtmodle.Equals(value))
                {
                    _gtmodle = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtHeight
        /// 属性描述：杆高
        /// 字段信息：[gtHeight],decimal
        /// </summary>
        [DisplayNameAttribute("杆高")]
        public decimal gtHeight
        {
            get { return _gtheight; }
            set
            {			
                if (_gtheight as object == null || !_gtheight.Equals(value))
                {
                    _gtheight = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtLon
        /// 属性描述：经度
        /// 字段信息：[gtLon],decimal
        /// </summary>
        [DisplayNameAttribute("经度")]
        public decimal gtLon
        {
            get { return _gtlon; }
            set
            {			
                if (_gtlon as object == null || !_gtlon.Equals(value))
                {
                    _gtlon = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtLat
        /// 属性描述：纬度
        /// 字段信息：[gtLat],decimal
        /// </summary>
        [DisplayNameAttribute("纬度")]
        public decimal gtLat
        {
            get { return _gtlat; }
            set
            {			
                if (_gtlat as object == null || !_gtlat.Equals(value))
                {
                    _gtlat = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtElev
        /// 属性描述：高程
        /// 字段信息：[gtElev],int
        /// </summary>
        [DisplayNameAttribute("高程")]
        public int gtElev
        {
            get { return _gtelev; }
            set
            {			
                if (_gtelev as object == null || !_gtelev.Equals(value))
                {
                    _gtelev = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：X54
        /// 属性描述：经度2
        /// 字段信息：[X54],int
        /// </summary>
        [DisplayNameAttribute("经度2")]
        public int X54
        {
            get { return _x54; }
            set
            {			
                if (_x54 as object == null || !_x54.Equals(value))
                {
                    _x54 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Y54
        /// 属性描述：纬度2
        /// 字段信息：[Y54],int
        /// </summary>
        [DisplayNameAttribute("纬度2")]
        public int Y54
        {
            get { return _y54; }
            set
            {			
                if (_y54 as object == null || !_y54.Equals(value))
                {
                    _y54 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtSpan
        /// 属性描述：档距
        /// 字段信息：[gtSpan],decimal
        /// </summary>
        [DisplayNameAttribute("档距")]
        public decimal gtSpan
        {
            get { return _gtspan; }
            set
            {			
                if (_gtspan as object == null || !_gtspan.Equals(value))
                {
                    _gtspan = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtMs
        /// 属性描述：
        /// 字段信息：[gtMs],decimal
        /// </summary>
        [DisplayNameAttribute("gtMs")]
        public decimal gtMs
        {
            get { return _gtms; }
            set
            {			
                if (_gtms as object == null || !_gtms.Equals(value))
                {
                    _gtms = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtZjfx
        /// 属性描述：
        /// 字段信息：[gtZjfx],nvarchar
        /// </summary>
        [DisplayNameAttribute("gtZjfx")]
        public string gtZjfx
        {
            get { return _gtzjfx; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[gtZjfx]长度不能大于10!");
                if (_gtzjfx as object == null || !_gtzjfx.Equals(value))
                {
                    _gtzjfx = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtZj
        /// 属性描述：
        /// 字段信息：[gtZj],nvarchar
        /// </summary>
        [DisplayNameAttribute("gtZj")]
        public string gtZj
        {
            get { return _gtzj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[gtZj]长度不能大于10!");
                if (_gtzj as object == null || !_gtzj.Equals(value))
                {
                    _gtzj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtJg
        /// 属性描述：
        /// 字段信息：[gtJg],nvarchar
        /// </summary>
        [DisplayNameAttribute("gtJg")]
        public string gtJg
        {
            get { return _gtjg; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1)
                throw new Exception("[gtJg]长度不能大于1!");
                if (_gtjg as object == null || !_gtjg.Equals(value))
                {
                    _gtjg = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ImageID
        /// 属性描述：
        /// 字段信息：[ImageID],nvarchar
        /// </summary>
        [DisplayNameAttribute("ImageID")]
        public string ImageID
        {
            get { return _imageid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 150)
                throw new Exception("[ImageID]长度不能大于150!");
                if (_imageid as object == null || !_imageid.Equals(value))
                {
                    _imageid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dxplfs
        /// 属性描述：导线排列方式
        /// 字段信息：[dxplfs],nvarchar
        /// </summary>
        [DisplayNameAttribute("导线排列方式")]
        public string dxplfs
        {
            get { return _dxplfs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[导线排列方式]长度不能大于50!");
                if (_dxplfs as object == null || !_dxplfs.Equals(value))
                {
                    _dxplfs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：gtNode
        /// 属性描述：节点,(是、否）
        /// 字段信息：[gtNode],nvarchar
        /// </summary>
        [DisplayNameAttribute("节点")]
        public string gtNode
        {
            get { return _gtnode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 10)
                throw new Exception("[节点]长度不能大于10!");
                if (_gtnode as object == null || !_gtnode.Equals(value))
                {
                    _gtnode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c1
        /// 属性描述：备
        /// 字段信息：[c1],nvarchar
        /// </summary>
        [Browsable(true)]
        [DisplayNameAttribute("杆号")]
        public string c1
        {
            get { return _c1; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
                if (_c1 as object == null || !_c1.Equals(value))
                {
                    _c1 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c2
        /// 属性描述：备
        /// 字段信息：[c2],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c2
        {
            get { return _c2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
                if (_c2 as object == null || !_c2.Equals(value))
                {
                    _c2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c3
        /// 属性描述：备
        /// 字段信息：[c3],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c3
        {
            get { return _c3; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
                if (_c3 as object == null || !_c3.Equals(value))
                {
                    _c3 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c4
        /// 属性描述：备
        /// 字段信息：[c4],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c4
        {
            get { return _c4; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
                if (_c4 as object == null || !_c4.Equals(value))
                {
                    _c4 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c5
        /// 属性描述：备
        /// 字段信息：[c5],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c5
        {
            get { return _c5; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
                if (_c5 as object == null || !_c5.Equals(value))
                {
                    _c5 = value;
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
