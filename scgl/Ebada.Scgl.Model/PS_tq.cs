/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2012-4-5 15:57:09
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_tq]业务实体类
    ///对应表名:PS_tq
    /// </summary>
    [Serializable]
    public class PS_tq
    {
        
        #region Private 成员
        private string _gtid=String.Empty; 
        private string _tqid=Newid(); 
        private string _tqcode=String.Empty; 
        private string _tqname=String.Empty; 
        private string _remark=String.Empty; 
        private string _adress=String.Empty; 
        private string _xlcode=String.Empty; 
        private string _xlcode2=String.Empty; 
        private string _owner=String.Empty; 
        private string _cby=String.Empty; 
        private string _cfy=String.Empty; 
        private string _contractor=String.Empty; 
        private decimal _lowlossrate=0; 
        private string _class=String.Empty; 
        private short _tclr=0; 
        private short _hclr=0; 
        private string _orgcode=String.Empty; 
        private DateTime _indate=new DateTime(1900,1,1); 
        private string _bttype=String.Empty; 
        private string _btkind=String.Empty; 
        private string _bcdr=String.Empty; 
        private string _ddj=String.Empty; 
        private string _jj=String.Empty; 
        private string _nfy=String.Empty; 
        private string _zmfs=String.Empty; 
        private string _dxbs=String.Empty; 
        private string _sxbs=String.Empty;   
        #endregion
  
  
        #region Public 成员
   
        /// <summary>
        /// 属性名称：gtID
        /// 属性描述：杆塔ID
        /// 字段信息：[gtID],nvarchar
        /// </summary>
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
        /// 属性名称：tqID
        /// 属性描述：台区ID
        /// 字段信息：[tqID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("台区ID")]
        public string tqID
        {
            get { return _tqid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[台区ID]长度不能大于50!");
                if (_tqid as object == null || !_tqid.Equals(value))
                {
                    _tqid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tqCode
        /// 属性描述：台区编号
        /// 字段信息：[tqCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("台区编号")]
        public string tqCode
        {
            get { return _tqcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[台区编号]长度不能大于50!");
                if (_tqcode as object == null || !_tqcode.Equals(value))
                {
                    _tqcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tqName
        /// 属性描述：台区名称
        /// 字段信息：[tqName],nvarchar
        /// </summary>
        [DisplayNameAttribute("台区名称")]
        public string tqName
        {
            get { return _tqname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[台区名称]长度不能大于50!");
                if (_tqname as object == null || !_tqname.Equals(value))
                {
                    _tqname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Remark
        /// 属性描述：备注
        /// 字段信息：[Remark],nvarchar
        /// </summary>
        [DisplayNameAttribute("备注")]
        public string Remark
        {
            get { return _remark; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[备注]长度不能大于250!");
                if (_remark as object == null || !_remark.Equals(value))
                {
                    _remark = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Adress
        /// 属性描述：变台地址
        /// 字段信息：[Adress],nvarchar
        /// </summary>
        [DisplayNameAttribute("变台地址")]
        public string Adress
        {
            get { return _adress; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[变台地址]长度不能大于50!");
                if (_adress as object == null || !_adress.Equals(value))
                {
                    _adress = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xlCode
        /// 属性描述：所属线路
        /// 字段信息：[xlCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("所属线路")]
        public string xlCode
        {
            get { return _xlcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[所属线路]长度不能大于50!");
                if (_xlcode as object == null || !_xlcode.Equals(value))
                {
                    _xlcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：xlCode2
        /// 属性描述：所属分支线路
        /// 字段信息：[xlCode2],nvarchar
        /// </summary>
        [DisplayNameAttribute("所属分支线路")]
        public string xlCode2
        {
            get { return _xlcode2; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[所属分支线路]长度不能大于50!");
                if (_xlcode2 as object == null || !_xlcode2.Equals(value))
                {
                    _xlcode2 = value;
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
        /// 属性名称：cby
        /// 属性描述：抄表员
        /// 字段信息：[cby],nvarchar
        /// </summary>
        [DisplayNameAttribute("抄表员")]
        public string cby
        {
            get { return _cby; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[抄表员]长度不能大于50!");
                if (_cby as object == null || !_cby.Equals(value))
                {
                    _cby = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：cfy
        /// 属性描述：催费员
        /// 字段信息：[cfy],nvarchar
        /// </summary>
        [DisplayNameAttribute("催费员")]
        public string cfy
        {
            get { return _cfy; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[催费员]长度不能大于50!");
                if (_cfy as object == null || !_cfy.Equals(value))
                {
                    _cfy = value;
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
        /// 属性名称：Lowlossrate
        /// 属性描述：低损率
        /// 字段信息：[Lowlossrate],decimal
        /// </summary>
        [DisplayNameAttribute("低损率")]
        public decimal Lowlossrate
        {
            get { return _lowlossrate; }
            set
            {			
                if (_lowlossrate as object == null || !_lowlossrate.Equals(value))
                {
                    _lowlossrate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：Class
        /// 属性描述：运行班次
        /// 字段信息：[Class],nvarchar
        /// </summary>
        [DisplayNameAttribute("运行班次")]
        public string Class
        {
            get { return _class; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[运行班次]长度不能大于50!");
                if (_class as object == null || !_class.Equals(value))
                {
                    _class = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：tclr
        /// 属性描述：台抄例日
        /// 字段信息：[tclr],smallint
        /// </summary>
        [DisplayNameAttribute("台抄例日")]
        public short tclr
        {
            get { return _tclr; }
            set
            {			
                if (_tclr as object == null || !_tclr.Equals(value))
                {
                    _tclr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：hclr
        /// 属性描述：户抄例日
        /// 字段信息：[hclr],smallint
        /// </summary>
        [DisplayNameAttribute("户抄例日")]
        public short hclr
        {
            get { return _hclr; }
            set
            {			
                if (_hclr as object == null || !_hclr.Equals(value))
                {
                    _hclr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：OrgCode
        /// 属性描述：表字录入单位
        /// 字段信息：[OrgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("表字录入单位")]
        public string OrgCode
        {
            get { return _orgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[表字录入单位]长度不能大于50!");
                if (_orgcode as object == null || !_orgcode.Equals(value))
                {
                    _orgcode = value;
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
        /// 属性名称：bttype
        /// 属性描述：变台型号
        /// 字段信息：[bttype],nvarchar
        /// </summary>
        [DisplayNameAttribute("变台型号")]
        public string bttype
        {
            get { return _bttype; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[变台型号]长度不能大于50!");
                if (_bttype as object == null || !_bttype.Equals(value))
                {
                    _bttype = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：btKind
        /// 属性描述：完好类型
        /// 字段信息：[btKind],nvarchar
        /// </summary>
        [DisplayNameAttribute("完好类型")]
        public string btKind
        {
            get { return _btkind; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[完好类型]长度不能大于50!");
                if (_btkind as object == null || !_btkind.Equals(value))
                {
                    _btkind = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：bcdr
        /// 属性描述：补偿电容
        /// 字段信息：[bcdr],nvarchar
        /// </summary>
        [DisplayNameAttribute("补偿电容")]
        public string bcdr
        {
            get { return _bcdr; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[补偿电容]长度不能大于50!");
                if (_bcdr as object == null || !_bcdr.Equals(value))
                {
                    _bcdr = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：ddj
        /// 属性描述：电动机
        /// 字段信息：[ddj],nvarchar
        /// </summary>
        [DisplayNameAttribute("电动机")]
        public string ddj
        {
            get { return _ddj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电动机]长度不能大于50!");
                if (_ddj as object == null || !_ddj.Equals(value))
                {
                    _ddj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：jj
        /// 属性描述：机井
        /// 字段信息：[jj],nvarchar
        /// </summary>
        [DisplayNameAttribute("机井")]
        public string jj
        {
            get { return _jj; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[机井]长度不能大于50!");
                if (_jj as object == null || !_jj.Equals(value))
                {
                    _jj = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：nfy
        /// 属性描述：农副业
        /// 字段信息：[nfy],nvarchar
        /// </summary>
        [DisplayNameAttribute("农副业")]
        public string nfy
        {
            get { return _nfy; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[农副业]长度不能大于50!");
                if (_nfy as object == null || !_nfy.Equals(value))
                {
                    _nfy = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：zmfs
        /// 属性描述：照明户数
        /// 字段信息：[zmfs],nvarchar
        /// </summary>
        [DisplayNameAttribute("照明户数")]
        public string zmfs
        {
            get { return _zmfs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[照明户数]长度不能大于50!");
                if (_zmfs as object == null || !_zmfs.Equals(value))
                {
                    _zmfs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：dxbs
        /// 属性描述：单相表数
        /// 字段信息：[dxbs],nvarchar
        /// </summary>
        [DisplayNameAttribute("单相表数")]
        public string dxbs
        {
            get { return _dxbs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[单相表数]长度不能大于50!");
                if (_dxbs as object == null || !_dxbs.Equals(value))
                {
                    _dxbs = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：sxbs
        /// 属性描述：三相表数
        /// 字段信息：[sxbs],nvarchar
        /// </summary>
        [DisplayNameAttribute("三相表数")]
        public string sxbs
        {
            get { return _sxbs; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[三相表数]长度不能大于50!");
                if (_sxbs as object == null || !_sxbs.Equals(value))
                {
                    _sxbs = value;
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
