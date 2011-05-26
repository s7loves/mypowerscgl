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
        private string _orgcode2=String.Empty; 
        private string _owner=("局属"); 
        private string _contractor=String.Empty; 
        private string _runstate=("运行"); 
        private DateTime _indate=new DateTime(1900,1,1); 
        private string _linegtbegin=String.Empty; 
        private string _linegtend=String.Empty; 
        private string _wiretype=String.Empty; 
        private int _wirelength=0; 
        private int _totallength=0; 
        private decimal _theoryloss=0; 
        private decimal _actualloss=0;   
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
        /// 属性描述：线路级别,1干线/2支线/3分线
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
        /// 属性描述：所属供电所
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("所属供电所")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[所属供电所]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgCode2
        /// 属性描述：配出变电所
        /// 字段信息：[OrgCode2],nvarchar
        /// </summary>
        [DisplayNameAttribute("配出变电所")]
        public string OrgCode2
        {
            get { return _orgcode2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[配出变电所]长度不能大于50!");
                if (_orgcode2 as object == null || !_orgcode2.Equals(value))
                {
                    _orgcode2 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Owner
        /// 属性描述：产权
        /// 字段信息：[Owner],nvarchar
        /// </summary>
        [DisplayNameAttribute("产权")]
        public string Owner
        {
            get { return _owner; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[产权]长度不能大于50!");
                if (_owner as object == null || !_owner.Equals(value))
                {
                    _owner = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Contractor
        /// 属性描述：承包人
        /// 字段信息：[Contractor],nvarchar
        /// </summary>
        [DisplayNameAttribute("承包人")]
        public string Contractor
        {
            get { return _contractor; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[承包人]长度不能大于50!");
                if (_contractor as object == null || !_contractor.Equals(value))
                {
                    _contractor = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：RunState
        /// 属性描述：运行状态
        /// 字段信息：[RunState],nvarchar
        /// </summary>
        [DisplayNameAttribute("运行状态")]
        public string RunState
        {
            get { return _runstate; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[运行状态]长度不能大于50!");
                if (_runstate as object == null || !_runstate.Equals(value))
                {
                    _runstate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：InDate
        /// 属性描述：投运日期
        /// 字段信息：[InDate],datetime
        /// </summary>
        [DisplayNameAttribute("投运日期")]
        public DateTime InDate
        {
            get { return _indate; }
            set
            {			
                if (_indate as object == null || !_indate.Equals(value))
                {
                    _indate = value;
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
  
        /// <summary>
        /// 属性名称：TheoryLoss
        /// 属性描述：理论线损
        /// 字段信息：[TheoryLoss],decimal
        /// </summary>
        [DisplayNameAttribute("理论线损")]
        public decimal TheoryLoss
        {
            get { return _theoryloss; }
            set
            {			
                if (_theoryloss as object == null || !_theoryloss.Equals(value))
                {
                    _theoryloss = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ActualLoss
        /// 属性描述：实际线损
        /// 字段信息：[ActualLoss],decimal
        /// </summary>
        [DisplayNameAttribute("实际线损")]
        public decimal ActualLoss
        {
            get { return _actualloss; }
            set
            {			
                if (_actualloss as object == null || !_actualloss.Equals(value))
                {
                    _actualloss = value;
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
