/**********************************************
这是代码自动生成的，如果重新生成，所做的改动将会丢失
系统:Ebada农电局生产管理
模块:系统平台
Ebada.com 版权所有
生成者：Rabbit
生成时间:2011-9-21 10:25:52
***********************************************/

using System;
using System.Threading;
using System.ComponentModel;
namespace Ebada.Scgl.Model
{
    /// <summary>
    ///[PS_kg]业务实体类
    ///对应表名:PS_kg
    /// </summary>
    [Serializable]
    public class PS_kg
    {
        
        #region Private 成员
        private string _gtid=String.Empty; 
        private string _kgid=Newid(); 
        private string _kgcode=String.Empty; 
        private string _kgname=String.Empty; 
        private string _kgmodle=String.Empty; 
        private string _kgvol=String.Empty; 
        private string _kgphase=String.Empty; 
        private int _kgcapcity=0; 
        private string _kglinegroup=String.Empty; 
        private string _kgfactory=String.Empty; 
        private string _kgnumber=String.Empty; 
        private DateTime _kgmadedate=new DateTime(1900,1,1); 
        private string _kgclosevol=String.Empty; 
        private string _kgopenele=String.Empty; 
        private string _kgfgb=String.Empty; 
        private DateTime _kginstalldate=new DateTime(1900,1,1); 
        private string _kginstalladress=String.Empty; 
        private string _kgstate=String.Empty; 
        private DateTime _indate=new DateTime(1900,1,1);   
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
        /// 属性名称：kgID
        /// 属性描述：开关ID
        /// 字段信息：[kgID],nvarchar
        /// </summary>
        [Browsable(false)]
        [DisplayNameAttribute("开关ID")]
        public string kgID
        {
            get { return _kgid; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[开关ID]长度不能大于50!");
                if (_kgid as object == null || !_kgid.Equals(value))
                {
                    _kgid = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgCode
        /// 属性描述：开关编号
        /// 字段信息：[kgCode],nvarchar
        /// </summary>
        [DisplayNameAttribute("开关编号")]
        public string kgCode
        {
            get { return _kgcode; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[开关编号]长度不能大于50!");
                if (_kgcode as object == null || !_kgcode.Equals(value))
                {
                    _kgcode = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgName
        /// 属性描述：开关名称
        /// 字段信息：[kgName],nvarchar
        /// </summary>
        [DisplayNameAttribute("开关名称")]
        public string kgName
        {
            get { return _kgname; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[开关名称]长度不能大于50!");
                if (_kgname as object == null || !_kgname.Equals(value))
                {
                    _kgname = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgModle
        /// 属性描述：开关型号
        /// 字段信息：[kgModle],nvarchar
        /// </summary>
        [DisplayNameAttribute("开关型号")]
        public string kgModle
        {
            get { return _kgmodle; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[开关型号]长度不能大于50!");
                if (_kgmodle as object == null || !_kgmodle.Equals(value))
                {
                    _kgmodle = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgVol
        /// 属性描述：电压等级
        /// 字段信息：[kgVol],nvarchar
        /// </summary>
        [DisplayNameAttribute("电压等级")]
        public string kgVol
        {
            get { return _kgvol; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[电压等级]长度不能大于50!");
                if (_kgvol as object == null || !_kgvol.Equals(value))
                {
                    _kgvol = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgPhase
        /// 属性描述：遮断容量
        /// 字段信息：[kgPhase],nvarchar
        /// </summary>
        [DisplayNameAttribute("遮断容量")]
        public string kgPhase
        {
            get { return _kgphase; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[遮断容量]长度不能大于50!");
                if (_kgphase as object == null || !_kgphase.Equals(value))
                {
                    _kgphase = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgCapcity
        /// 属性描述：容量
        /// 字段信息：[kgCapcity],int
        /// </summary>
        [DisplayNameAttribute("容量")]
        public int kgCapcity
        {
            get { return _kgcapcity; }
            set
            {			
                if (_kgcapcity as object == null || !_kgcapcity.Equals(value))
                {
                    _kgcapcity = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgLineGroup
        /// 属性描述：重合装置
        /// 字段信息：[kgLineGroup],nvarchar
        /// </summary>
        [DisplayNameAttribute("重合装置")]
        public string kgLineGroup
        {
            get { return _kglinegroup; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[重合装置]长度不能大于50!");
                if (_kglinegroup as object == null || !_kglinegroup.Equals(value))
                {
                    _kglinegroup = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgFactory
        /// 属性描述：制造厂
        /// 字段信息：[kgFactory],nvarchar
        /// </summary>
        [DisplayNameAttribute("制造厂")]
        public string kgFactory
        {
            get { return _kgfactory; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[制造厂]长度不能大于50!");
                if (_kgfactory as object == null || !_kgfactory.Equals(value))
                {
                    _kgfactory = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgNumber
        /// 属性描述：制造号
        /// 字段信息：[kgNumber],nvarchar
        /// </summary>
        [DisplayNameAttribute("制造号")]
        public string kgNumber
        {
            get { return _kgnumber; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[制造号]长度不能大于50!");
                if (_kgnumber as object == null || !_kgnumber.Equals(value))
                {
                    _kgnumber = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgMadeDate
        /// 属性描述：制造日期
        /// 字段信息：[kgMadeDate],datetime
        /// </summary>
        [DisplayNameAttribute("制造日期")]
        public DateTime kgMadeDate
        {
            get { return _kgmadedate; }
            set
            {			
                if (_kgmadedate as object == null || !_kgmadedate.Equals(value))
                {
                    _kgmadedate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgCloseVol
        /// 属性描述：合闸线圈电压
        /// 字段信息：[kgCloseVol],nvarchar
        /// </summary>
        [DisplayNameAttribute("合闸线圈电压")]
        public string kgCloseVol
        {
            get { return _kgclosevol; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[合闸线圈电压]长度不能大于50!");
                if (_kgclosevol as object == null || !_kgclosevol.Equals(value))
                {
                    _kgclosevol = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgOpenEle
        /// 属性描述：跳闸电流
        /// 字段信息：[kgOpenEle],nvarchar
        /// </summary>
        [DisplayNameAttribute("跳闸电流")]
        public string kgOpenEle
        {
            get { return _kgopenele; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[跳闸电流]长度不能大于50!");
                if (_kgopenele as object == null || !_kgopenele.Equals(value))
                {
                    _kgopenele = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgfgb
        /// 属性描述：开关互感器变比
        /// 字段信息：[kgfgb],nvarchar
        /// </summary>
        [DisplayNameAttribute("开关互感器变比")]
        public string kgfgb
        {
            get { return _kgfgb; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[开关互感器变比]长度不能大于50!");
                if (_kgfgb as object == null || !_kgfgb.Equals(value))
                {
                    _kgfgb = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgInstallDate
        /// 属性描述：安装日期
        /// 字段信息：[kgInstallDate],datetime
        /// </summary>
        [DisplayNameAttribute("安装日期")]
        public DateTime kgInstallDate
        {
            get { return _kginstalldate; }
            set
            {			
                if (_kginstalldate as object == null || !_kginstalldate.Equals(value))
                {
                    _kginstalldate = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgInstallAdress
        /// 属性描述：安装地点
        /// 字段信息：[kgInstallAdress],nvarchar
        /// </summary>
        [DisplayNameAttribute("安装地点")]
        public string kgInstallAdress
        {
            get { return _kginstalladress; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 250)
                throw new Exception("[安装地点]长度不能大于250!");
                if (_kginstalladress as object == null || !_kginstalladress.Equals(value))
                {
                    _kginstalladress = value;
                }
            }			 
        }
  
        /// <summary>
        /// 属性名称：kgState
        /// 属性描述：状态
        /// 字段信息：[kgState],nvarchar
        /// </summary>
        [DisplayNameAttribute("状态")]
        public string kgState
        {
            get { return _kgstate; }
            set
            {			
                if(value==null)return;
                if( value.ToString().Length > 50)
                throw new Exception("[状态]长度不能大于50!");
                if (_kgstate as object == null || !_kgstate.Equals(value))
                {
                    _kgstate = value;
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
