/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2013-1-4 10:23:28
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[sd_xl]业务实体类
    ///对应表名:sd_xl
    /// </summary>
    [Serializable]
    public class sd_xl
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
        private string _owner=String.Empty; 
        private string _contractor=String.Empty; 
        private string _runstate=String.Empty; 
        private DateTime _indate=new DateTime(1900,1,1); 
        private string _linegtbegin=String.Empty; 
        private string _linegtend=String.Empty; 
        private string _wiretype=String.Empty; 
        private int _wirelength=0; 
        private int _totallength=0; 
        private int _gdbj=0; 
        private decimal _theoryloss=0; 
        private decimal _actualloss=0; 
        private string _parentgt=String.Empty; 
        private decimal _linep=0; 
        private decimal _lineq=0; 
        private decimal _k=0; 
        private string _linekind=String.Empty; 
        private string _linenum=String.Empty; 
        private decimal _totalt=0; 
        private string _sectionalizedmessage=String.Empty; 
        private string _xlpy=String.Empty; 
        private string _c1=String.Empty; 
        private string _c2=String.Empty; 
        private string _c3=String.Empty; 
        private string _c4=String.Empty; 
        private string _c5=String.Empty; 
        private string _c6=String.Empty; 
        private string _c7=String.Empty; 
        private string _c8=String.Empty; 
        private string _c9=String.Empty;   
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
        /// 属性名称：gdbj
        /// 属性描述：供电半径
        /// 字段信息：[gdbj],int
        /// </summary>
        [DisplayNameAttribute("供电半径")]
        public int gdbj
        {
            get { return _gdbj; }
            set
            {			
                if (_gdbj as object == null || !_gdbj.Equals(value))
                {
                    _gdbj = value;
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
  
        /// <summary>
        /// 属性名称：ParentGT
        /// 属性描述：
        /// 字段信息：[ParentGT],nvarchar
        /// </summary>
        [DisplayNameAttribute("ParentGT")]
        public string ParentGT
        {
            get { return _parentgt; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[ParentGT]长度不能大于50!");
                if (_parentgt as object == null || !_parentgt.Equals(value))
                {
                    _parentgt = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LineP
        /// 属性描述：
        /// 字段信息：[LineP],decimal
        /// </summary>
        [DisplayNameAttribute("LineP")]
        public decimal LineP
        {
            get { return _linep; }
            set
            {			
                if (_linep as object == null || !_linep.Equals(value))
                {
                    _linep = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：LineQ
        /// 属性描述：
        /// 字段信息：[LineQ],decimal
        /// </summary>
        [DisplayNameAttribute("LineQ")]
        public decimal LineQ
        {
            get { return _lineq; }
            set
            {			
                if (_lineq as object == null || !_lineq.Equals(value))
                {
                    _lineq = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：K
        /// 属性描述：
        /// 字段信息：[K],decimal
        /// </summary>
        [DisplayNameAttribute("K")]
        public decimal K
        {
            get { return _k; }
            set
            {			
                if (_k as object == null || !_k.Equals(value))
                {
                    _k = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lineKind
        /// 属性描述：线路种类
        /// 字段信息：[lineKind],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路种类")]
        public string lineKind
        {
            get { return _linekind; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路种类]长度不能大于50!");
                if (_linekind as object == null || !_linekind.Equals(value))
                {
                    _linekind = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：lineNum
        /// 属性描述：线路号
        /// 字段信息：[lineNum],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路号")]
        public string lineNum
        {
            get { return _linenum; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路号]长度不能大于50!");
                if (_linenum as object == null || !_linenum.Equals(value))
                {
                    _linenum = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：TotalT
        /// 属性描述：投入运行时间
        /// 字段信息：[TotalT],decimal
        /// </summary>
        [DisplayNameAttribute("投入运行时间")]
        public decimal TotalT
        {
            get { return _totalt; }
            set
            {			
                if (_totalt as object == null || !_totalt.Equals(value))
                {
                    _totalt = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：SectionalizedMessage
        /// 属性描述：线路分段信息
        /// 字段信息：[SectionalizedMessage],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路分段信息")]
        public string SectionalizedMessage
        {
            get { return _sectionalizedmessage; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 1000)
                throw new Exception("[线路分段信息]长度不能大于1000!");
                if (_sectionalizedmessage as object == null || !_sectionalizedmessage.Equals(value))
                {
                    _sectionalizedmessage = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xlpy
        /// 属性描述：线路拼音
        /// 字段信息：[xlpy],nvarchar
        /// </summary>
        [DisplayNameAttribute("线路拼音")]
        public string xlpy
        {
            get { return _xlpy; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[线路拼音]长度不能大于50!");
                if (_xlpy as object == null || !_xlpy.Equals(value))
                {
                    _xlpy = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c1
        /// 属性描述：备
        /// 字段信息：[c1],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
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
  
        /// <summary>
        /// 属性名称：c6
        /// 属性描述：备
        /// 字段信息：[c6],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c6
        {
            get { return _c6; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
                if (_c6 as object == null || !_c6.Equals(value))
                {
                    _c6 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c7
        /// 属性描述：备
        /// 字段信息：[c7],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c7
        {
            get { return _c7; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
                if (_c7 as object == null || !_c7.Equals(value))
                {
                    _c7 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c8
        /// 属性描述：备
        /// 字段信息：[c8],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c8
        {
            get { return _c8; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
                if (_c8 as object == null || !_c8.Equals(value))
                {
                    _c8 = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：c9
        /// 属性描述：备
        /// 字段信息：[c9],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("备")]
        public string c9
        {
            get { return _c9; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[备]长度不能大于50!");
                if (_c9 as object == null || !_c9.Equals(value))
                {
                    _c9 = value;
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
