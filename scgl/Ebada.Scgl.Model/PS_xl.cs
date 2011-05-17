/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada物流企业ERP
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-5-17 22:06:07
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_xl]业务实体类
    ///对应表名:PS_xl
    /// </summary>
    [Serializable]
    public class PS_xl
    {
        
        #region Private 成员
        private string _lineid=Newid(); 
        private string _parentid=String.Empty; 
        private string _linetype=String.Empty; 
        private string _linecode=String.Empty; 
        private string _linename=String.Empty; 
        private string _linenamepath=String.Empty; 
        private string _linevol=String.Empty; 
        private string _orgcode=String.Empty; 
        private string _linegtbegin=String.Empty; 
        private string _linegtend=String.Empty; 
        private string _wiretype=String.Empty; 
        private int _wirelength=0; 
        private int _totallength=0;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：LineID
        /// 属性描述：线路ID
        /// 字段信息：[LineID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("线路ID")]
        public string LineID
        {
            get { return _lineid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路ID]长度不能大于50!");
                if (_lineid as object == null || !_lineid.Equals(value))
                {
                    _lineid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ParentID
        /// 属性描述：ParentID
        /// 字段信息：[ParentID],nvarchar
        /// </summary>
        [DisplayNameAttribute("ParentID")]
        public string ParentID
        {
            get { return _parentid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[ParentID]长度不能大于50!");
                if (_parentid as object == null || !_parentid.Equals(value))
                {
                    _parentid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LineType
        /// 属性描述：线路级别,0干线/1支线/2分线
        /// 字段信息：[LineType],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路级别")]
        public string LineType
        {
            get { return _linetype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路级别]长度不能大于50!");
                if (_linetype as object == null || !_linetype.Equals(value))
                {
                    _linetype = value;
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
        /// 属性名称：LineName
        /// 属性描述：线路名称
        /// 字段信息：[LineName],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路名称")]
        public string LineName
        {
            get { return _linename; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路名称]长度不能大于50!");
                if (_linename as object == null || !_linename.Equals(value))
                {
                    _linename = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LineNamePath
        /// 属性描述：线路路径
        /// 字段信息：[LineNamePath],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路路径")]
        public string LineNamePath
        {
            get { return _linenamepath; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[线路路径]长度不能大于250!");
                if (_linenamepath as object == null || !_linenamepath.Equals(value))
                {
                    _linenamepath = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LineVol
        /// 属性描述：电压等级
        /// 字段信息：[LineVol],nvarchar
        /// </summary>
        [DisplayNameAttribute("电压等级")]
        public string LineVol
        {
            get { return _linevol; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电压等级]长度不能大于50!");
                if (_linevol as object == null || !_linevol.Equals(value))
                {
                    _linevol = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgCode
        /// 属性描述：所在单位
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("所在单位")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[所在单位]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LineGtbegin
        /// 属性描述：起始杆号
        /// 字段信息：[LineGtbegin],nvarchar
        /// </summary>
        [DisplayNameAttribute("起始杆号")]
        public string LineGtbegin
        {
            get { return _linegtbegin; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[起始杆号]长度不能大于50!");
                if (_linegtbegin as object == null || !_linegtbegin.Equals(value))
                {
                    _linegtbegin = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LineGtend
        /// 属性描述：终止杆号
        /// 字段信息：[LineGtend],nvarchar
        /// </summary>
        [DisplayNameAttribute("终止杆号")]
        public string LineGtend
        {
            get { return _linegtend; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[终止杆号]长度不能大于50!");
                if (_linegtend as object == null || !_linegtend.Equals(value))
                {
                    _linegtend = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WireType
        /// 属性描述：导线型号
        /// 字段信息：[WireType],nvarchar
        /// </summary>
        [DisplayNameAttribute("导线型号")]
        public string WireType
        {
            get { return _wiretype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[导线型号]长度不能大于50!");
                if (_wiretype as object == null || !_wiretype.Equals(value))
                {
                    _wiretype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：WireLength
        /// 属性描述：线路长度
        /// 字段信息：[WireLength],int
        /// </summary>
        [DisplayNameAttribute("线路长度")]
        public int WireLength
        {
            get { return _wirelength; }
            set
            {			
                if (_wirelength as object == null || !_wirelength.Equals(value))
                {
                    _wirelength = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TotalLength
        /// 属性描述：总长度
        /// 字段信息：[TotalLength],int
        /// </summary>
        [DisplayNameAttribute("总长度")]
        public int TotalLength
        {
            get { return _totallength; }
            set
            {			
                if (_totallength as object == null || !_totallength.Equals(value))
                {
                    _totallength = value;
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
