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
    ///[PS_tqbyq]业务实体类
    ///对应表名:PS_tqbyq
    /// </summary>
    [Serializable]
    public class PS_tqbyq
    {
        
        #region Private 成员
        private string _tqid=String.Empty; 
        private string _byqid=Newid(); 
        private string _byqcode=String.Empty; 
        private string _byqname=String.Empty; 
        private string _byqmodle=String.Empty; 
        private bool _omniseal=false; 
        private string _byqowner=String.Empty; 
        private string _byqvol=String.Empty; 
        private string _byqphase=String.Empty; 
        private int _byqcapcity=0; 
        private string _byqlinegroup=String.Empty; 
        private string _byqfactory=String.Empty; 
        private string _byqnumber=String.Empty; 
        private DateTime _byqmadedate=new DateTime(1900,1,1); 
        private string _byqcycle=String.Empty; 
        private decimal _byqvolone=0; 
        private decimal _byqvoltwo=0; 
        private decimal _byqcurrentone=0; 
        private decimal _byqcurrenttwo=0; 
        private DateTime _byqinstalldate=new DateTime(1900,1,1); 
        private string _byqinstalladress=String.Empty; 
        private string _byqstate=String.Empty; 
        private DateTime _indate=new DateTime(1900,1,1);   
        #endregion
  
  
        #region Public 成员
   
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
        /// 属性名称：byqID
        /// 属性描述：变压器ID
        /// 字段信息：[byqID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("变压器ID")]
        public string byqID
        {
            get { return _byqid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[变压器ID]长度不能大于50!");
                if (_byqid as object == null || !_byqid.Equals(value))
                {
                    _byqid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqCode
        /// 属性描述：变压器编号
        /// 字段信息：[byqCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("变压器编号")]
        public string byqCode
        {
            get { return _byqcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[变压器编号]长度不能大于50!");
                if (_byqcode as object == null || !_byqcode.Equals(value))
                {
                    _byqcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqName
        /// 属性描述：变压器名称
        /// 字段信息：[byqName],nvarchar
        /// </summary>
        [DisplayNameAttribute("变压器名称")]
        public string byqName
        {
            get { return _byqname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[变压器名称]长度不能大于50!");
                if (_byqname as object == null || !_byqname.Equals(value))
                {
                    _byqname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqModle
        /// 属性描述：变压器型号
        /// 字段信息：[byqModle],nvarchar
        /// </summary>
        [DisplayNameAttribute("变压器型号")]
        public string byqModle
        {
            get { return _byqmodle; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[变压器型号]长度不能大于50!");
                if (_byqmodle as object == null || !_byqmodle.Equals(value))
                {
                    _byqmodle = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：omniseal
        /// 属性描述：全密封
        /// 字段信息：[omniseal],bit
        /// </summary>
        [DisplayNameAttribute("全密封")]
        public bool omniseal
        {
            get { return _omniseal; }
            set
            {			
                if (_omniseal as object == null || !_omniseal.Equals(value))
                {
                    _omniseal = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqOwner
        /// 属性描述：所属
        /// 字段信息：[byqOwner],nvarchar
        /// </summary>
        [DisplayNameAttribute("所属")]
        public string byqOwner
        {
            get { return _byqowner; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[所属]长度不能大于50!");
                if (_byqowner as object == null || !_byqowner.Equals(value))
                {
                    _byqowner = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqVol
        /// 属性描述：电压等级
        /// 字段信息：[byqVol],nvarchar
        /// </summary>
        [DisplayNameAttribute("电压等级")]
        public string byqVol
        {
            get { return _byqvol; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电压等级]长度不能大于50!");
                if (_byqvol as object == null || !_byqvol.Equals(value))
                {
                    _byqvol = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqPhase
        /// 属性描述：相别
        /// 字段信息：[byqPhase],nvarchar
        /// </summary>
        [DisplayNameAttribute("相别")]
        public string byqPhase
        {
            get { return _byqphase; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[相别]长度不能大于50!");
                if (_byqphase as object == null || !_byqphase.Equals(value))
                {
                    _byqphase = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqCapcity
        /// 属性描述：容量
        /// 字段信息：[byqCapcity],int
        /// </summary>
        [DisplayNameAttribute("容量")]
        public int byqCapcity
        {
            get { return _byqcapcity; }
            set
            {			
                if (_byqcapcity as object == null || !_byqcapcity.Equals(value))
                {
                    _byqcapcity = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqLineGroup
        /// 属性描述：结线组别
        /// 字段信息：[byqLineGroup],nvarchar
        /// </summary>
        [DisplayNameAttribute("结线组别")]
        public string byqLineGroup
        {
            get { return _byqlinegroup; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[结线组别]长度不能大于50!");
                if (_byqlinegroup as object == null || !_byqlinegroup.Equals(value))
                {
                    _byqlinegroup = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqFactory
        /// 属性描述：制造厂
        /// 字段信息：[byqFactory],nvarchar
        /// </summary>
        [DisplayNameAttribute("制造厂")]
        public string byqFactory
        {
            get { return _byqfactory; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[制造厂]长度不能大于50!");
                if (_byqfactory as object == null || !_byqfactory.Equals(value))
                {
                    _byqfactory = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqNumber
        /// 属性描述：制造号
        /// 字段信息：[byqNumber],nvarchar
        /// </summary>
        [DisplayNameAttribute("制造号")]
        public string byqNumber
        {
            get { return _byqnumber; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[制造号]长度不能大于50!");
                if (_byqnumber as object == null || !_byqnumber.Equals(value))
                {
                    _byqnumber = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqMadeDate
        /// 属性描述：制造日期
        /// 字段信息：[byqMadeDate],datetime
        /// </summary>
        [DisplayNameAttribute("制造日期")]
        public DateTime byqMadeDate
        {
            get { return _byqmadedate; }
            set
            {			
                if (_byqmadedate as object == null || !_byqmadedate.Equals(value))
                {
                    _byqmadedate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqCycle
        /// 属性描述：周波
        /// 字段信息：[byqCycle],nvarchar
        /// </summary>
        [DisplayNameAttribute("周波")]
        public string byqCycle
        {
            get { return _byqcycle; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[周波]长度不能大于50!");
                if (_byqcycle as object == null || !_byqcycle.Equals(value))
                {
                    _byqcycle = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqVolOne
        /// 属性描述：一次电压
        /// 字段信息：[byqVolOne],decimal
        /// </summary>
        [DisplayNameAttribute("一次电压")]
        public decimal byqVolOne
        {
            get { return _byqvolone; }
            set
            {			
                if (_byqvolone as object == null || !_byqvolone.Equals(value))
                {
                    _byqvolone = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqVolTwo
        /// 属性描述：二次电压
        /// 字段信息：[byqVolTwo],decimal
        /// </summary>
        [DisplayNameAttribute("二次电压")]
        public decimal byqVolTwo
        {
            get { return _byqvoltwo; }
            set
            {			
                if (_byqvoltwo as object == null || !_byqvoltwo.Equals(value))
                {
                    _byqvoltwo = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqCurrentOne
        /// 属性描述：一次额定电流
        /// 字段信息：[byqCurrentOne],decimal
        /// </summary>
        [DisplayNameAttribute("一次额定电流")]
        public decimal byqCurrentOne
        {
            get { return _byqcurrentone; }
            set
            {			
                if (_byqcurrentone as object == null || !_byqcurrentone.Equals(value))
                {
                    _byqcurrentone = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqCurrentTwo
        /// 属性描述：二次额定电流
        /// 字段信息：[byqCurrentTwo],decimal
        /// </summary>
        [DisplayNameAttribute("二次额定电流")]
        public decimal byqCurrentTwo
        {
            get { return _byqcurrenttwo; }
            set
            {			
                if (_byqcurrenttwo as object == null || !_byqcurrenttwo.Equals(value))
                {
                    _byqcurrenttwo = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqInstallDate
        /// 属性描述：安装日期
        /// 字段信息：[byqInstallDate],datetime
        /// </summary>
        [DisplayNameAttribute("安装日期")]
        public DateTime byqInstallDate
        {
            get { return _byqinstalldate; }
            set
            {			
                if (_byqinstalldate as object == null || !_byqinstalldate.Equals(value))
                {
                    _byqinstalldate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqInstallAdress
        /// 属性描述：安装地点
        /// 字段信息：[byqInstallAdress],nvarchar
        /// </summary>
        [DisplayNameAttribute("安装地点")]
        public string byqInstallAdress
        {
            get { return _byqinstalladress; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[安装地点]长度不能大于250!");
                if (_byqinstalladress as object == null || !_byqinstalladress.Equals(value))
                {
                    _byqinstalladress = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：byqState
        /// 属性描述：状态
        /// 字段信息：[byqState],nvarchar
        /// </summary>
        [DisplayNameAttribute("状态")]
        public string byqState
        {
            get { return _byqstate; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[状态]长度不能大于50!");
                if (_byqstate as object == null || !_byqstate.Equals(value))
                {
                    _byqstate = value;
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
